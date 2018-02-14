using System;
using System.Collections.Generic;
using System.Text;

using NurApiDotNet;

namespace CommandBuilder
{
	public class NurCmdBuilder
	{
		private NurApi.CustomExchangeParams mLastExchange;
		private bool mLastIsValid = false;
		private NurApi hApi;

		/* Whteher to add a plain parameter or an EBV. */
		public const bool ADD_PARAMETER = false;
		public const bool ADD_EBV = true;

		NurCmdBuilder(NurApi api)
		{
			hApi = api;
		}

		public struct BitEntry
		{
			public bool isEBV;
			public int bitLen;
			public uint paramValue;
		}

		public struct BitBuffer
		{
			public int actualLength;
			public byte[] bytes;
		}

		public BitEntry BuildEntry(bool isEBV, uint paramVal, int bitLen)
		{
			if (bitLen < 0 || bitLen > 32)
				throw new ApplicationException("Internal error: BuildEntry() : invalid bit length of " + bitLen);

			BitEntry be = new BitEntry();
			be.isEBV = isEBV;
			be.bitLen = bitLen;
			be.paramValue = paramVal;

			return be;
		}

		private string UintYesNo(uint u)
		{
			if (u != 0)
				return "YES (" + u + ")";

			return "No (0)";
		}

		private static uint BoolToUint(bool b)
		{
			return (uint)(b ? 1 : 0);
		}

		/// <summary>
		/// Build default exchange.
		/// </summary>
		/// <param name="bb">Bit buffer to copy the bit data from.</param>
		/// <param name="expRespLength">Expected response length in bits. If zero, no specific RX length is expected.</param>
		/// <param name="stripHandle">Whether to strip the handle from the reponse or not (last two bytes).</param>
		/// <param name="isWrite">If true then the exchange will act like it is a write (air parameter and response timeout related behavior).</param>
		/// <param name="timeout">Timeout in milliseconds to wait the response.</param>
		/// <returns>The built custom exchange parameters.</returns>
		public NurApi.CustomExchangeParams BuildDefault(BitBuffer bb, ushort expRespLength, bool stripHandle, bool isWrite, uint timeout)
		{
			NurApi.CustomExchangeParams xch = new NurApi.CustomExchangeParams();
			int byteLength;

			byteLength = bb.actualLength/8;
			
			if ((bb.actualLength % 8) != 0)
				byteLength++;

			/* Byte default all commands require handle. */
			xch.appendHandle = BoolToUint(true);
			/* May require write like response wait. */
			xch.asWrite = BoolToUint(isWrite);
			/* Copy built bytes. */
			xch.bitBuffer = new byte[NurApi.MAX_BITSTR_BITS / 8];
			System.Array.Copy(bb.bytes, xch.bitBuffer, byteLength);

			/* We want the RX CRC. */
			xch.noRxCRC = BoolToUint(false);
			/* By default all the commands are appended with CRC. */
			xch.noTxCRC = BoolToUint(false);
			/* Number of bits expected in the response including the 16-bit handle. */
			xch.rxLen = expRespLength;
			/* If length is set to 0 it means that the response length is unknown. */
			xch.rxLenUnknown = (uint)((expRespLength == 0) ? 1 : 0);
			/* The application may want to see the handle. */
			xch.rxStripHandle = BoolToUint(stripHandle);
			/* Timeout in milliseconds. */
			xch.rxTimeout = timeout;
			/* TX shall use normal CRC. */
			xch.txCRC5 = BoolToUint(false);
			/* Copy number of bits to transmit. */
			xch.txLen = (ushort)bb.actualLength;
			/* We want a response. */
			xch.txOnly = BoolToUint(false);
			/* There is no cover coding required. */
			xch.xorRN16 = BoolToUint(false);

			/* Copy laast for possible debugging. */
			CopyToLast(xch);

			return xch;
		}

		private void CopyToLast(NurApi.CustomExchangeParams xch)
		{

			mLastExchange.appendHandle = xch.appendHandle;
			/* May require write like response wait. */
			mLastExchange.asWrite =xch.asWrite;
			/* Copy built bytes. */
			mLastExchange.bitBuffer =xch.bitBuffer; // = new byte[NurApi.MAX_BITSTR_BITS / 8];
			//System.Array.Copy(bb.bytes, xch.bitBuffer, byteLength);

			/* We want the RX CRC. */
			mLastExchange.noRxCRC =xch.noRxCRC;
			/* By default all the commands are appended with CRC. */
			mLastExchange.noTxCRC =xch.noTxCRC;
			/* Number of bits expected in the response including the 16-bit handle. */
			mLastExchange.rxLen =xch.rxLen;
			/* If length is set to 0 it means that the response length is unknown. */
			mLastExchange.rxLenUnknown =xch.rxLenUnknown;
			/* The application may want to see the handle. */
			mLastExchange.rxStripHandle = xch.rxStripHandle;
			/* Use the set timeout. */
			mLastExchange.rxTimeout =xch.rxTimeout;
			/* TX shall use normal CRC. */
			mLastExchange.txCRC5 =xch.txCRC5;
			/* Copy number of bits to transmit. */
			mLastExchange.txLen =xch.txLen;
			/* We want a response. */
			mLastExchange.txOnly =xch.txOnly;
			/* There is no cover coding required. */
			mLastExchange.xorRN16 = xch.xorRN16;

			mLastIsValid = true;
		}

		/// <summary>
		/// Return a bit value from "big-endian source".
		/// </summary>
		/// <param name="src">Byte array source.</param>
		/// <param name="bitAddress">Bit address in the array.</param>
		/// <returns>Return whether the bit at <paramref name="bitAddress"/> is 1 or 0.</returns>
		/// <exception cref="IndexOutOfRangeException">Can throw exception if addressed outside of the byte array.</exception>
		public static uint GetBit(byte[] src, int bitAddress)
		{
			int offset, rem;
			byte mask = 0x80;

			offset = bitAddress / 8;
			rem = bitAddress % 8;
			mask >>= rem;

			return (uint)(((src[offset] & mask) != 0 ? 1 : 0));

		}

		/// <summary>
		/// Debug information about the last exchange.
		/// </summary>
		/// <returns>String array explaining the contents of the last exchange.</returns>
		/// <exception cref="ApplicationException">Throws "nothing to do" application exception if there is no last exchange available.</exception>
		public string[] LastToStrings()
		{
			if (!mLastIsValid)
				throw new ApplicationException("LastToStrings(): nothing to do.");

			List<string> theStrings = new List<string>();
			String tmp;
			ushort i;

			theStrings.Add("Command bytes: " + mLastExchange.bitBuffer[0].ToString("X2") + " " + mLastExchange.bitBuffer[1].ToString("X2"));
			theStrings.Add("Append handle = " + UintYesNo(mLastExchange.appendHandle));
			theStrings.Add("Is write = " + UintYesNo(mLastExchange.asWrite));
			theStrings.Add("No RX CRC = " + UintYesNo(mLastExchange.noRxCRC));
			theStrings.Add("No TX CRC = " + UintYesNo(mLastExchange.noTxCRC));
			theStrings.Add("RX length = " + mLastExchange.rxLen);
			theStrings.Add("Unknown RX length = " + UintYesNo(mLastExchange.rxLenUnknown));
			theStrings.Add("Strip handle = " + UintYesNo(mLastExchange.rxStripHandle));

			if (mLastExchange.asWrite != 0)
				theStrings.Add("Write resp timeout = " + mLastExchange.rxTimeout);
			else
				theStrings.Add("Read resp timeout = " + mLastExchange.rxTimeout);

			theStrings.Add("TX CRC-5 = " + UintYesNo(mLastExchange.txCRC5));
			theStrings.Add("TX length = " + mLastExchange.txLen);
			theStrings.Add("TX only = " + UintYesNo(mLastExchange.txOnly));
			theStrings.Add("XOR RN16 = " + UintYesNo(mLastExchange.xorRN16));

			tmp = "Bits (" + mLastExchange.txLen + "): ";
			for (i = 0; i < mLastExchange.txLen; i++)
				tmp += GetBit(mLastExchange.bitBuffer, i).ToString();

			theStrings.Add(tmp);

			return theStrings.ToArray();
		}

		/// <summary>
		/// Build command with given prefix and command value.
		/// </summary>
		/// <param name="customPrefix">Used prefix.</param>
		/// <param name="cmdValue">Custom command value; tag/IC manufacturer specific.</param>
		/// <param name="entries">The entries to be add to the command. If null the no entries are added.</param>
		/// <returns>Bit buffer structure representing the actually transmitted data.</returns>		
		public BitBuffer BuildCommand(byte customPrefix, byte cmdValue, List<BitEntry> entries)
		{
			int localLen = 0;
			BitBuffer bb = new BitBuffer();
			bb.bytes = new byte[NurApi.MAX_BITSTR_BITS / 8];
			bb.actualLength = 0;

			/* customPrefix usually is 0xE0. */
			localLen = NurApi.BitBufferAddValue(bb.bytes, customPrefix, 8, localLen);
			localLen = NurApi.BitBufferAddValue(bb.bytes, cmdValue, 8, localLen);

			if (entries != null)
			{
				foreach (BitEntry be in entries)
				{
					if (be.isEBV)
						localLen = NurApi.BitBufferAddEBV32(bb.bytes, be.paramValue, localLen);
					else
						localLen = NurApi.BitBufferAddValue(bb.bytes, be.paramValue, be.bitLen, localLen);
				}
			}

			bb.actualLength = localLen;			
			return bb;
		}

		/// <summary>
		/// Build plain command just using the entries.
		/// </summary>
		/// <param name="entries">Entries to ad into the bit buffer.</param>
		/// <returns>The transmittable bit buffer to be used in the exchange parameter.</returns>
		public BitBuffer BuildPlain(List<BitEntry> entries)
		{
			int localLen = 0;
			BitBuffer bb = new BitBuffer();
			bb.bytes = new byte[NurApi.MAX_BITSTR_BITS / 8];
			bb.actualLength = 0;

			if (entries != null)
			{
				foreach (BitEntry be in entries)
				{
					if (be.isEBV)
						localLen = NurApi.BitBufferAddEBV32(bb.bytes, be.paramValue, localLen);
					else
						localLen = NurApi.BitBufferAddValue(bb.bytes, be.paramValue, be.bitLen, localLen);
				}
			}

			bb.actualLength = localLen;
			return bb;
		}

		/// <summary>
		/// Do simple exchange with the built command using no password.
		/// </summary>
		/// <param name="epc">Tag's EPC.</param>
		/// <param name="xch">Exchange parameters.</param>
		/// <returns>Return the custom exchange result if successful.</returns>
		/// <exception cref="NurApiException">Exception is thrown with communication error.</exception>
		public NurApi.CustomExchangeResponse ExchangeCommand(byte []epc, NurApi.CustomExchangeParams xch)
		{
			return ExchangeCommand(0, false, epc, xch);
		}

		/// <summary>
		/// Do simple exchange with the built command using password.
		/// </summary>
		/// <param name="password">Password for accessing the module.</param>
		/// <param name="secured"></param>
		/// <param name="epc"></param>
		/// <param name="xch"></param>
		/// <returns></returns>
		public NurApi.CustomExchangeResponse ExchangeCommand(uint password, bool secured, byte[] epc, NurApi.CustomExchangeParams xch)
		{
			NurApi.CustomExchangeResponse resp;

			resp = hApi.CustomExchangeByEPC(password, secured, epc, xch);

			return resp;
		}

		/// <summary>
		/// Example command using password.
		/// </summary>
		/// <param name="custPrefix">Prefix for the command. This replaces the Gen2 command; usually 0xE0.</param>
		/// <param name="cmd">The actual command following the prefix; tag manufacturer specific.</param>
		/// <param name="uParams">An imaginary uint array of parameters.</param>
		/// <returns>Return the custom exchange parameter that can be used with <see>Exchange</see>.</returns>
		public NurApi.CustomExchangeParams ExampleCommand(byte custPrefix, byte cmd, uint[] uParams)
		{
			List<BitEntry> entries = new List<BitEntry>();
			NurApi.CustomExchangeParams xch;

			BitBuffer bb;

			foreach (uint u in uParams)
				entries.Add(BuildEntry(ADD_PARAMETER, u, 32));

			bb = BuildCommand(custPrefix, cmd, entries);

			/* 0 for possible error reception. */
			xch = BuildDefault(bb, 0, false, false, 20);

			/* Custom built command is now ready for exchange. */
			return xch;
		}


		/// <summary>
		/// Example on how to compose a simple read command (Gen2 standard).
		/// </summary>
		/// <param name="bank">Bank to read from.</param>
		/// <param name="address">Word address to start the read from.</param>
		/// <param name="nWords">Number of 16-bit words to read.</param>
		/// <returns>The custom exchange parameter implementing the Gen2 standard read command.</returns>
		public NurApi.CustomExchangeParams ReadCmdExample(uint bank, uint address, uint nWords)
		{
			List<BitEntry> entries = new List<BitEntry>();
			NurApi.CustomExchangeParams xch;

			BitBuffer bb;

			/* Add the read command parameters as specified*/
			/* Command value; 8 bits. */
			entries.Add(BuildEntry(ADD_PARAMETER, 0xC2, 8));
			/* Bank to read from; 2 bits. */
			entries.Add(BuildEntry(ADD_PARAMETER, bank, 2));
			/* Word address to read from; EBV. */
			entries.Add(BuildEntry(ADD_EBV, address, 0));
			/* Number of words to read; 8 bits. */
			entries.Add(BuildEntry(ADD_PARAMETER, nWords, 8));

			bb = BuildPlain(entries);

			/* 0 for possible error reception. */
			/* Response length is set to nWords * 16 + 16 (handle)*/
			/* We want to also strip the handle as it has no information for us. */
			xch = BuildDefault(bb, (ushort)(nWords * 16 + 16), true, false, 20);

			/* Custom built command is now ready for exchange. */
			return xch;
		}
	}
}
