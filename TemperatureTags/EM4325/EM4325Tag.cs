using System;
using System.Collections.Generic;
using System.Text;

using System.Diagnostics;
using System.Reflection;

using NurApiDotNet;

namespace EM4325
{
	/// <summary>
	/// The class representing a tag using the EM4325 chip.
	/// </summary>
	public partial class EM4325Tag : NurApi.Tag
	{
		private NurApi hNur = null;
		private uint mWriteTimeout = MIN_WRITETIMEOUT;
		private uint mReadTimeout = MIN_READTIMEOUT;

		private UIDResponse mUID;
		private bool mValidUID = false;

		private bool useTargetReset = false;

		public bool UseTargetReset
		{
			set { useTargetReset = value; }
			get { return useTargetReset; }
		}

		/// <summary>
		/// Tag's EPC. The tag is addressed by this EPC value whenever accessed.
		/// </summary>
		public byte[] mEPC = null;
		/// <summary>
		/// Set to password value for tag access if needed.
		/// </summary>
		public uint mPassword = 0;		
		/// <summary>
		/// Is set to true then the access password <see cref="mPassword"/> is used.
		/// </summary>
		public bool mSecured = false;

		/// <summary>
		/// Constructor v1.
		/// </summary>
		/// <param name="tag">A tag object that is received e.g. from an inventory.</param>
		public EM4325Tag(NurApi.Tag tag) : base(tag)
		{
			ushort pc = tag.pc;
			int checkLen;

			hNur = tag.hApi;
			/* Check for XPC presence. */

			checkLen = (pc >> 11) - 1;
			checkLen *= 2;

			if ((checkLen != tag.epc.Length) && (pc & 0x0200) != 0)
			{				
				int newLen;

				hNur.ULog("Fixing EPC " + tag.GetEpcString() + " (len = " + tag.epc.Length + ", checkLen = " + checkLen + ", PC = 0x" + tag.pc.ToString("X4") + ").");

				newLen = tag.epc.Length - 2;
				
				pc >>= 11;
				pc--;
				pc &= 0x1F;
				pc <<= 11;				
				tag.pc |= pc;

				mEPC = new byte[newLen];
				System.Array.Copy(tag.epc, 2, mEPC, 0, newLen);
				base.epc = new byte[newLen];				
				System.Array.Copy(mEPC, 0, base.epc, 0, newLen);
				hNur.ULog("Fixed EPC = " + base.GetEpcString() + ".");
			}
			else
			{
				mEPC = new byte[tag.epc.Length];
				System.Array.Copy(tag.epc, mEPC, mEPC.Length);
			}
		}

		private static int AdjustUIDResponseLength(int respLen, int error)
		{
			if (((respLen & 1) != 0) && (error == NurApiErrors.NUR_NO_ERROR) && (respLen >= RESPLEN_ALLOC_E0))
			{
				return respLen - 1;
			}

			return respLen;
		}

		/// <summary>
		/// Set/get the current read timeout value in ms.
		/// </summary>
		/// <exception cref="ApplicationException">Exception is thrown when the value is out of range.</exception>
		/// <see cref="MIN_READTIMEOUT"/>
		/// <see cref="MAX_TIMEOUT"/>
		public uint ReadTimeout
		{
			get { return mReadTimeout; }
			set
			{
				if (value < MIN_READTIMEOUT || value > MAX_TIMEOUT)
					throw new ApplicationException("Invalid read timeout value of " + value + ".\nRange is " + MIN_READTIMEOUT + "..." + MAX_TIMEOUT + ".");
				mReadTimeout = value;
			}
		}

		/// <summary>
		/// Set/get the current write timeout value in ms.
		/// </summary>
		/// <exception cref="ApplicationException">Exception is thrown when the value is out of range.</exception>
		/// <see cref="MIN_WRITETIMEOUT"/>
		/// <see cref="MAX_TIMEOUT"/>
		public uint WriteTimeout
		{
			get { return mWriteTimeout; }
			set
			{
				if (value < MIN_WRITETIMEOUT || value > MAX_TIMEOUT)
					throw new ApplicationException("Invalid write timeout value of " + value + ".\nRange is " + MIN_WRITETIMEOUT + "..." + MAX_TIMEOUT + ".");
				mReadTimeout = value;
			}
		}

		/// <summary>
		/// Stop all by writing the control words to zero except for the enabled reset alarms bit which is set to '1'.
		/// </summary>
		/// <exception cref="NurApiException">Exception can be thrown after a communication error with the tag.</exception>
		public void Stop()
		{
			byte []wrData = new byte [] { 0x40, 0, 0, 0, 0, 0 };

			if (mSecured)
				BlockWrite(mPassword, NurApi.BANK_USER, ADDR_CTLWORD_1, wrData, 3);
			else
				BlockWrite(NurApi.BANK_USER, ADDR_CTLWORD_1, wrData, 3);
		}

		private static string BoolToYesNo(bool b)
		{
			return b ? "YES" : "NO";
		}

		public static string[] ConfigToStrings(EM4325Tag.ConfigData cfg)
		{
			List<string> theStrings = new List<string>();

			theStrings.Add("Simple sensor: " + BoolToYesNo(cfg.simpleSensor));
			theStrings.Add("Timestamp required: " + BoolToYesNo(cfg.tsRequired));
			theStrings.Add("ResetAlarms enabled: " + BoolToYesNo(cfg.resetEn));

			if (cfg.simpleSensor)
			{
				SSDConfig ssd = cfg.ssd;

				theStrings.Add("SSD alarms:");
				theStrings.Add("highAlarm: " + BoolToYesNo(ssd.highAlarm));
				theStrings.Add("lowAlarm: " + BoolToYesNo(ssd.lowAlarm));
				theStrings.Add("lowBatt: " + BoolToYesNo(ssd.lowBatt));
				theStrings.Add("tampered: " + BoolToYesNo(ssd.tampered));
			}
			else
			{
				CustomConfig cust = cfg.custom;
				theStrings.Add("CUSTOM:");
				theStrings.Add("delayUnits: " + cust.delayUnits);
				theStrings.Add("delayValue: " + cust.delayValue);
				theStrings.Add("intvalUnits: " + cust.intvalUnits);
				theStrings.Add("intvalValue: " + cust.intvalValue);
				theStrings.Add("nrOverTemp: " + cust.nrOverTemp);
				theStrings.Add("nrUnderTemp: " + cust.nrUnderTemp);
				theStrings.Add("overTemp: " + cust.overTemp.ToString("F2"));
				theStrings.Add("underTemp: " + cust.underTemp.ToString("F2"));
			}

			return theStrings.ToArray();
		}

		public void ForceSimple()
		{
			byte[] ctlWord;

			ResetToA();
			ctlWord = ReadTag(mPassword, mSecured, NurApi.BANK_USER, ADDR_CTLWORD_1, 2);

			// Bit 7 in 1st byte.
			if (BitToBool(ctlWord[0], 7) == false)
			{
				hNur.ULog("ForceSimple(): setting simple bit to '1'.");
				ctlWord[0] |= (1 << 7);
				ResetToA();
				WriteTag(mPassword, mSecured, NurApi.BANK_USER, ADDR_CTLWORD_1, ctlWord);
				hNur.ULog("ForceSimple(): control word written.");
			}
			else
				hNur.ULog("ForceSimple(): already confiured as simple sensor.");
		}

		private const int USERMEM_CHUNKSIZE = 64;

		/// <summary>
		/// Read all user memory.
		/// </summary>
		/// <returns>Return byte array containing user data.</returns>
		/// <exception cref="NurApiException">Exception thrown upon read error.</exception>
		public byte[] ReadUserBytes()
		{
			byte[] ret = null;
			byte[] rdData = null;
			int i;
			int chunks, rem, totalReads;
			int ptr;
			uint addr;

			chunks = USERMEM_BYTE_SIZE / USERMEM_CHUNKSIZE;
			rem = USERMEM_BYTE_SIZE % USERMEM_CHUNKSIZE;

			totalReads = chunks;
			if (rem != 0)
				totalReads++;

			ret = new byte[USERMEM_BYTE_SIZE];

			addr = 0;
			ptr = 0;
			for (i = 0; i < chunks; i++)
			{
				hNur.ULog("ReadUserBytes(" + (i + 1) + " / " + totalReads + ")");
				hNur.ULog("EPC[1] = " + GetEpcString());
				hNur.ULog("EPC[2] = " + NurApi.BinToHexString(mEPC));
				if (mSecured)
				{
					hNur.ULog("Using password 0x" + mPassword.ToString("X8") + ".");
				}
				hNur.ULog("Bank/addr/byteLen = " + string.Format("{0} / {1} / {2}", NurApi.BANK_USER, addr, USERMEM_CHUNKSIZE));
				rdData = ReadTag(mPassword, mSecured, NurApi.BANK_USER, addr, USERMEM_CHUNKSIZE);
				System.Array.Copy(rdData, 0, ret, ptr, rdData.Length);
				ptr += rdData.Length;
				addr += (USERMEM_CHUNKSIZE / 2);
			}

			if (rem != 0)
			{
				hNur.ULog("ReadUserBytes, remainder = " + rem + " bytes.");
				hNur.ULog("EPC[1] = " + GetEpcString());
				hNur.ULog("EPC[2] = " + NurApi.BinToHexString(mEPC));
				if (mSecured)
				{
					hNur.ULog("Using password 0x" + mPassword.ToString("X8") + ".");
				}
				hNur.ULog("Bank/addr/byteLen = " + string.Format("{0} / {1} / {2}", NurApi.BANK_USER, addr, rem));
				rdData = ReadTag(mPassword, mSecured, NurApi.BANK_USER, addr, rem);
				System.Array.Copy(rdData, 0, ret, ptr, rdData.Length);
			}

			return ret;
		}

		/// <summary>
		/// Read all user memory.
		/// </summary>
		/// <returns>Return array of unsigned 16-bit integers from user memory in correct endian.</returns>
		/// <exception cref="NurApiException">Exception thrown upon read error.</exception>
		public ushort[] ReadUserUshort()
		{
			byte[] rdData;
			ushort []ret;
			ushort us;
			int i;
			rdData = ReadUserBytes();
			ret = new ushort[rdData.Length / 2];

			for (i = 0; i < ret.Length; i++)
			{
				us = rdData[i * 2];
				us <<= 8;
				us |= rdData[i * 2 + 1];
				ret[i] = us;
			}

			return ret;
		}

		/// <summary>
		/// Read all user memory.
		/// </summary>
		/// <returns>Return array of unsigned 32-bit integers from user memory in correct endian.</returns>
		/// <exception cref="NurApiException">Exception thrown upon read error.</exception>
		public uint[] ReadUserUint()
		{
			byte[] rdData;
			int i, j;
			byte[] uiData = new byte[4];
			uint[] ret;
			rdData = ReadUserBytes();

			j = 0;
			ret = new uint[rdData.Length / 4];
			for (i = 0; i < rdData.Length; i+=4)
			{
				System.Array.Copy(rdData, i, uiData, 0, 4);
				System.Array.Reverse(uiData);
				ret[j++] = BitConverter.ToUInt32(uiData, 0);
			}

			return ret;
		}

		/* Call this before each read, write or custom command; the tag may not respond if battery assistance is 'on'. */
		private void ResetToA()
		{
			int i;

			if (UseTargetReset)
			{
				hNur.ULog("EM4325::ResetToA()");

				for (i = 0; i < 2; i++)
				{
					try { hNur.ResetToTarget(0, true); }
					catch { }
				}
			}
		}
	}
}

#if !WindowsCE
namespace EM4325
{
	/// <summary>
	/// The EM4325 namespace contains classes for tags with the EM4325 chip.
	/// Supported products:
	/// </summary>
	[System.Runtime.CompilerServices.CompilerGenerated]
	class NamespaceDoc
	{
	}
}
#endif
