using System;
using System.Collections.Generic;
using System.Text;

using NurApiDotNet;

namespace EM4325
{
	public partial class EM4325Tag : NurApi.Tag
	{
		private static UIDResponse AllocUIDResponse()
		{
			UIDResponse uid = new UIDResponse();
			uid.allocClass = 0;
			uid.mdid = -1;
			uid.modelNum = -1;
			uid.serial = 0;
			uid.xtid = -1;
			uid.xtidHdr = -1;
			uid.umSize = -1;
			uid.mid = -1;
			uid.cn = -1;
			uid.CRC16 = -1;
			uid.raw = null;
			return uid;
		}

		private UIDResponse ReadUID(bool doSelect)
		{
			if (mValidUID && doSelect)
				return mUID;

			NurApi.CustomExchangeParams xch;
			NurApi.CustomExchangeResponse resp;

			int txLen = 0;
			int respLen = 0;

			xch = BuildDefault(0, DO_AS_READ, STRIP_HANDLE);

			txLen = NurApi.BitBufferAddValue(xch.bitBuffer, CMD_GET_UID, PROPRIETARY_BITS, txLen);
			xch.txLen = (ushort)txLen;

			/* Important. */
			xch.rxTimeout = mReadTimeout;

			ResetToA();
			
			if (doSelect)
				resp = hNur.CustomExchangeByEPC(mPassword, mSecured, mEPC, xch);
			else
				resp = hNur.CustomExchange(mPassword, mSecured, xch);

			respLen = resp.tagBytes.Length;

			respLen = AdjustUIDResponseLength(respLen, resp.error);

			// Extract response. Expecting 8, 10 or 12 bytes.
			// Note: E0 also covers the classes 0x44, 0x45, 0x46 and 0x47 (legacy TOTAL as per spec.).
			if (respLen == RESPLEN_ALLOC_E0 || respLen == RESPLEN_ALLOC_E2 || respLen == RESPLEN_ALLOC_E3)
			{
				if (doSelect)
				{
					mUID = InterpretUIDResponse(hNur, resp.tagBytes, respLen);
					mValidUID = true;
					return mUID;
				}
				else
					return mUID = InterpretUIDResponse(hNur, resp.tagBytes, respLen);
			}

			throw
				new ApplicationException("GetUID: invalid response length of " + respLen + " bytes.");
		}

		/// <summary>
		/// Interpret the UID response data received from the tag.
		/// </summary>
		/// <param name="hApi">NUR API handle. Used for user log trace/debug.</param>		
		/// <param name="src"></param>
		/// <param name="contentLen">Actual length of the resposen. Needed if the UID is a part of another reponse.</param>
		/// <returns>Interpreted UID response: <see cref="UIDResponse"/>.</returns>
		/// <exception cref="ApplicationException">Throws an exception if the allocation class is not recognized.</exception>
		public static UIDResponse InterpretUIDResponse(NurApi hApi, byte[] src, int contentLen)
		{
			UIDResponse uidResp;
			bool doCopySerial;
			byte allocClass;
			int srcPtr;
			uint tmpVal;

			uidResp = AllocUIDResponse();

			srcPtr = 0;

			// First byte is the allocation class.
			allocClass = src[srcPtr++];
			uidResp.allocClass = allocClass;

			// Legacy TOTAL check later.
			doCopySerial = true;

			if (allocClass == 0xE2)
			{
				// Next three bytes.
				tmpVal = src[srcPtr++];
				tmpVal <<= 8;
				tmpVal |= src[srcPtr++];
				tmpVal <<= 8;
				tmpVal |= src[srcPtr++];
				
				// First 12 bits from right is model number.
				uidResp.modelNum = (int)(tmpVal & ((1 << 12) - 1));
				tmpVal >>= 12;
				// Following 11 bits for MDID.
				uidResp.mdid = (int)(tmpVal & ((1 << 11) - 1));
				tmpVal >>= 11;
				
				// Last bit is XTID (0 / 1).
				uidResp.xtid = (int)(tmpVal & 1);

				// Followed by 16 bits of XTID header value.
				tmpVal = src[srcPtr++];
				tmpVal <<= 8;
				tmpVal |= src[srcPtr++];

				uidResp.xtidHdr = (int)tmpVal;
			}
			else if (allocClass == 0xE3)
			{
				// Following byte is MID.
				uidResp.mid = src[srcPtr++];
				// Next 16 bits for user memory size.
				tmpVal = src[srcPtr++];
				tmpVal <<= 8;
				tmpVal |= src[srcPtr++];
				uidResp.umSize = (int)tmpVal;
			}
			else if (allocClass == 0xE0)
			{
				// Following byte is MID.
				uidResp.mid = src[srcPtr++];
			}
			else if (allocClass >= 0x44 && allocClass <= 0x47)
			{
				// Legacy TOTAL as per spec.
				doCopySerial = false;	// No 48-bit serial copy.
				// MDID + customer number = 6 + 10.
				tmpVal = src[srcPtr++];
				tmpVal <<= 8;
				tmpVal |= src[srcPtr++];
				// 10 bits for CN.
				uidResp.cn = (int)(tmpVal & ((1 << 10) - 1));
				tmpVal >>= 10;
				// Rest for MDID.
				uidResp.mdid = (int)(tmpVal & ((1 << 6) - 1));
				// Serial
				tmpVal = src[srcPtr++];
				tmpVal <<= 8;
				tmpVal |= src[srcPtr++];
				tmpVal <<= 8;
				tmpVal |= src[srcPtr++];
				tmpVal <<= 8;
				tmpVal |= src[srcPtr++];
				uidResp.serial = tmpVal;
				// CRC 16
				tmpVal = src[srcPtr++];
				tmpVal <<= 8;
				tmpVal |= src[srcPtr++];
				uidResp.CRC16 = (int)tmpVal;
			}
			else
			{
				string s = "0x" + allocClass.ToString("X2");
				if (hApi != null)
					hApi.ULog("About to throw exception with illegal class allocation value of " + s + ".");
				throw
					new ApplicationException("GetUID::InterpretUIDResponse(): illegal allocation class " + s + ".");
			}

			if (doCopySerial)
			{
				int len = src.Length;
				byte[] ulongArr = new byte[8];
				ulongArr[0] = 0;
				ulongArr[1] = 0;
				// Get 48 big-endian bits.
				System.Array.Copy(src, srcPtr, ulongArr, 2, 6);
				// To little-endian.
				System.Array.Reverse(ulongArr);
				uidResp.serial = BitConverter.ToUInt64(ulongArr, 0);
			}

			// Copy raw data.
			uidResp.raw = new byte[contentLen];
			System.Array.Copy(src, uidResp.raw, contentLen);

			return uidResp;
		}

		/// <summary>
		/// The GetUID command implementation.
		/// </summary>
		/// <returns>The UID response structure.</returns>
		/// <exception cref="NurApiException">Exception is thrown with module or tag communication error.</exception>
		/// <exception cref="IndexOutOfRangeException">Exception is thrown if the response array indexing is out of range.</exception>
		/// <exception cref="ApplicationException">Is thrown with an invalid response (length or allocation class).</exception>
		public UIDResponse GetUID()
		{
			return ReadUID(true);
		}

		/// <summary>
		/// The UID as an attribute.
		/// </summary>
		/// <exception cref="NurApiException">Exception is thrown with module or tag communication error.</exception>
		/// <exception cref="IndexOutOfRangeException">Exception is thrown if the response array indexing is out of range.</exception>
		/// <exception cref="ApplicationException">Is thrown with an invalid response (length or allocation class).</exception>
		public UIDResponse UID
		{
			get { return GetUID(); }
			set { }
		}
	}
}
