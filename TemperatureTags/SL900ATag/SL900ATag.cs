using System;
using System.Collections.Generic;
using System.Text;

using NurApiDotNet;

namespace SL900A
{
	/// <summary>
	/// Class that represents the SL900A temperature / sensor tag.	
	/// </summary>
	public partial class SL900ATag : NurApi.Tag
	{
		/* API instance required for unselected operations. */
		private NurApi hLocalApi = null;

		private NurApi.CustomExchangeParams mLastExchange;
		private bool mLastIsValid = false;

		/* 20 ms by default for read. */
        private const uint DEFAULT_RX_TIMEOUT = 25;
		/* 30 ms by default for write operations. */
        private const uint DEFAULT_WRITE_TIMEOUT = 35;

		/* Timeout minimum and maximum in milliseconds. */
		private const uint MIN_RX_TIMEOUT = 20;
		private const uint MAX_RX_TIMEOUT = 100;

		private uint mReadTimeout = DEFAULT_RX_TIMEOUT;
		private uint mWriteTimeout = DEFAULT_WRITE_TIMEOUT;
		
		/* Prepended to each command. */
		private const uint CUSTOM_CMD_VALUE = 0xE0;

		/* Whether to add a plain parameter or an EBV. */
		private const bool ADD_PARAMETER = false;
		private const bool ADD_EBV = true;

		private string UintYesNo(uint u)
		{
			if (u != 0)
				return "YES (" + u + ")";

			return "No (0)";
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
		/// Time in milliseconds used when the operation is type of "write".
		/// Range is 30...100.
		/// </summary>
		/// <exception cref="ApplicationException">Is thrown when the value is out of range.</exception>
		public uint WriteTimeout
		{
			set
			{
				if (value < MIN_RX_TIMEOUT || value > MAX_RX_TIMEOUT)
					throw new ApplicationException("WriteTimeout " + value + " is out of range " + MIN_RX_TIMEOUT + "..." + MAX_RX_TIMEOUT + ".");
				mWriteTimeout = value;
			}
			get { return mWriteTimeout; }
		}

		/// <summary>
		/// Time in milliseconds used when the operation is type of "read".
		/// Range is 20...100.
		/// </summary>
		/// <exception cref="ApplicationException">Is thrown when the value is out of range.</exception>
		public uint ReadTimeout
		{
			set
			{
				if (value < MIN_RX_TIMEOUT || value > MAX_RX_TIMEOUT)
					throw new ApplicationException("ReadTimeout " + value + " is out of range " + MIN_RX_TIMEOUT + "..." + MAX_RX_TIMEOUT + ".");
				mReadTimeout = value;
			}
			get { return mReadTimeout; }
		}

		private struct BitEntry
		{
			public bool isEBV;
			public int bitLen;
			public uint paramValue;
		}

		private struct BitBuffer
		{
			public int actualLength;
			public byte[] bytes;
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="tag">The NurApi.tag class, <see cref="NurApi.Tag"/></param>
		public SL900ATag(NurApi.Tag tag) : base(tag)
		{
			hLocalApi = tag.hApi;
		}

		/// <summary>
		/// Constructor that can be use to implement an "empty" tag that can be used to read sensor values without EPC singulation.
		/// </summary>
		/// <param name="hApi">The NurApi instance required for tag operation(s).</param>
		public SL900ATag(NurApi hApi)
		{
			hLocalApi = hApi;
		}

		private BitEntry BuildEntry(bool isEBV, uint paramVal, int bitLen)
		{
			if (bitLen < 0 || bitLen > 32)
				throw new ApplicationException("Internal error: BuildEntry() : invalid bit length of " + bitLen);

			BitEntry be = new BitEntry();
			be.isEBV = isEBV;
			be.bitLen = bitLen;
			be.paramValue = paramVal;

			return be;
		}

		private static uint BoolToUint(bool b)
		{
			return (uint)(b ? 1 : 0);
		}

		/// <summary>
		/// Return whether a specified bit in a value is set or not.
		/// </summary>
		/// <param name="val">Value to check the bit from.</param>
		/// <param name="bit">Bit number running from 0 to 31 to check.</param>
		/// <returns>Returns true if the bit is set.</returns>
		/// <exception cref="IndexOutOfRangeException">Exception is thrown when the bit number is invalid (less than 0 or greater than 31).</exception>
		public static bool IsMaskBitSet(uint val, int bit)
		{
			if (bit < 0 || bit > 31)
				throw new IndexOutOfRangeException("IsMaskBitSet: invalid bit number " + bit + ".");

			return ((1 << bit) & val) != 0;
		}

		/// <summary>
		/// Build default exchange.
		/// </summary>
		/// <param name="bb">Bit buffer to copy the bit data from.</param>
		/// <param name="expRespLength">Expected response length in bits. If zero, no specific RX length is expected.</param>
		/// <param name="stripHandle">Whether to strip the handle from the reponse or not (last two bytes).</param>
		/// <param name="isWrite">If true then the exchange will act like it is a write (air parameter and response timeout related behavior).</param>
		/// <returns>The built custom exchange parameters.</returns>
		private NurApi.CustomExchangeParams BuildDefault(BitBuffer bb, ushort expRespLength, bool stripHandle, bool isWrite)
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
			/* Use the set timeout. */
			xch.rxTimeout = isWrite ? mWriteTimeout : mReadTimeout;
			/* TX shall use normal CRC. */
			xch.txCRC5 = BoolToUint(false);
			/* Copy number of bits to transmit. */
			xch.txLen = (ushort)bb.actualLength;
			/* We want a response. */
			xch.txOnly = BoolToUint(false);
			/* There is no cover coding required. */
			xch.xorRN16 = BoolToUint(false);

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

		private BitBuffer BuildCommand(byte cmdValue, List<BitEntry> entries)
		{
			NurApi curApi = hApi != null ? hApi : hLocalApi;
			int localLen = 0;
			BitBuffer bb = new BitBuffer();
			bb.bytes = new byte[NurApi.MAX_BITSTR_BITS / 8];
			bb.actualLength = 0;

			if (entries != null)
				curApi.ULog("BuildCommand(" + cmdValue.ToString("X2") + ", <cnt = " + entries.Count + ">)");
			else
				curApi.ULog("BuildCommand(" + cmdValue.ToString("X2") + ", null)");

			localLen = NurApi.BitBufferAddValue(bb.bytes, CUSTOM_CMD_VALUE, 8, localLen);
			localLen = NurApi.BitBufferAddValue(bb.bytes, cmdValue, 8, localLen);

			curApi.ULog("BuildCommand: cmds localLen = " + localLen);

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
			curApi.ULog("BuildCommand: bb.actualLength = " + bb.actualLength);
			return bb;
		}

		private BitBuffer BuildCommand2(byte cmdValue, List<BitEntry> entries)
		{
			NurApi curApi = hApi != null ? hApi : hLocalApi;
			int localLen = 0;
			BitBuffer bb = new BitBuffer();
			bb.bytes = new byte[NurApi.MAX_BITSTR_BITS / 8];
			bb.actualLength = 0;

			localLen = NurApi.BitBufferAddValue(bb.bytes, CUSTOM_CMD_VALUE, 8, localLen);
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

		/* Some helpers. */
		/// <summary>
		/// Byte address to bit address.
		/// </summary>
		/// <param name="byteAddr">E.g. byte offset in an array. </param>
		/// <returns>Bit address for the byte offset.</returns>
		public static int BytesToBits(int byteAddr)
		{
			return byteAddr * 8;
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
		/// Get value from bytes by extracting bits; return with system endian (little).
		/// </summary>
		/// <param name="src">Source byte array.</param>
		/// <param name="bitAddress">First bit's address (left most bit, big-endian i.e. MSB).</param>
		/// <param name="nBits">Number of bits in the value.</param>
		/// <returns>Extracted value in little endian format.</returns>
		/// <exception cref="IndexOutOfRangeException">Can throw exception if addressed outside of the byte array.</exception>
		public static uint GetBitsBigEndian(byte[] src, int bitAddress, int nBits)
		{
			int i, end;
			uint res = 0;
			end = bitAddress + nBits;

			for (i = bitAddress; i < end; i++)
			{
				res |= GetBit(src, i);
				res <<= 1;
			}
			return res;
		}

		/// <summary>
		/// Get a big-endian coded unsigned 32-bit integer from a specified position in a byte array.
		/// </summary>
		/// <param name="src">Source byte array.</param>
		/// <param name="offset">Offset where to start the extracting.</param>
		/// <returns>32-bit unsigned integer value in little-endian format.</returns>
		/// <exception cref="IndexOutOfRangeException">Thrown if the operation tries to address the array out of its size.</exception>
		/// <exception cref="NullReferenceException">Thrown if <paramref name="src"/> is null.</exception>
		public static uint GetBigEndian32FromBytes(byte[] src, int offset)
		{
			if (src == null)
				throw new NullReferenceException("Get big endian: parameter is null");

			uint ret = 0;		
			ret = src[offset++];
			ret <<= 8;
			ret |= src[offset++];
			ret <<= 8;
			ret |= src[offset++];
			ret <<= 8;
			ret |= src[offset];

			return ret;
		}

		/// <summary>
		/// Convert logging mode parameter to uint.
		/// </summary>
		/// <param name="lm">Logging mode <see cref="LogMode"/>.</param>
		/// <returns>Unsigned int representing the bit fields in the log mode command.</returns>
		public static uint LogModeToBits(LogMode lm)
		{
			uint ret = 0;

			/* Interval. */
			ret = lm.interval & LM_INTERVAL_MASKVAL;
			/* Put to right place. */
			ret <<= LM_INTERVAL_LSH;

			/* Batt check */
			if (lm.battChkEn)
				ret |= LM_BATTCHK_EN;
			/* Temperature sensor enable. */
			if (lm.tempSensEn)
				ret |= LM_TEMPSENS_EN;
			/* External sensor 1 enable. */
			if (lm.ext1En)
				ret |= LM_EXT1EN_EN;
			/* External sensor 2 enable. */
			if (lm.ext2En)
				ret |= LM_EXT2EN_EN;
			/* Rule: true = start from beginning when oveflow in EEPROM. */
			if (lm.roll)
				ret |= LM_ROLLING_EN;

			/* Finally store the mode. */
			ret |= (LoggingFormToUint(lm.form) << LM_FORMMASK_LSH);

			return ret;
		}

		/// <summary>
		/// Convert the 32-bit presentation of the logging mode 
		/// as specified in SL900A spec into <see cref="LogMode"/>.
		/// </summary>
		/// <param name="logMode"></param>
		/// <returns></returns>
		public static LogMode UintToLogMode(uint logMode)
		{
			LogMode lm = new LogMode();
			/* Interval. */
			lm.interval = (logMode & LM_INTERVAL_MASK) >> LM_INTERVAL_LSH;

			/* Batt check */
			lm.battChkEn = IsMaskBitSet(logMode, LM_BATTCHK_BIT);

			/* Temperature sensor enable. */
			lm.tempSensEn = IsMaskBitSet(logMode, LM_TEMPSENS_BIT);
			/* External sensor 1 enable. */
			lm.ext1En = IsMaskBitSet(logMode, LM_EXT1EN_BIT);
			/* External sensor 2 enable. */
			lm.ext2En = IsMaskBitSet(logMode, LM_EXT2EN_BIT);
			/* Rule. */
			lm.roll = IsMaskBitSet(logMode, LM_ROLLING_BIT);

			/* Finally store the mode. */
			lm.form = UintToLoggingForm((logMode >> LM_FORMMASK_LSH) & LM_FORMMASK_VAL);

			return lm;
		}

		/// <summary>
		/// Build 32-bit start time value as specified by the SL900A specification.
		/// </summary>
		/// <param name="s">Seconds.</param>
		/// <param name="min">Minutes.</param>
		/// <param name="h">Hours.</param>
		/// <param name="d">Day.</param>
		/// <param name="month">Month.</param>
		/// <param name="y">Year.</param>
		/// <returns>32-bit representation of the start time.</returns>
		public static uint BuildStartTime(uint s, uint min, uint h, uint d, uint month, uint y)
		{
			uint ret = 0;

			ret = (y & YEAR_MASK_VAL);
			ret <<= YEAR_LSH;

			ret |= (month & MONTH_MASK_VAL);
			ret <<= MONTH_LSH;

			ret |= (d & DAY_MASK_VAL);
			ret <<= DAY_LSH;

			ret |= (h & HOUR_MASK_VAL);
			ret <<= HOUR_LSH;

			ret |= (min & MIN_MASK_VAL);
			ret <<= MIN_LSH;

			ret |= (s & SEC_MASK_VAL);

			return ret;
		}

		/// <summary>
		/// Convert "logger time" structure to 32-bit unsigned presentation of the time
		/// as specified by the SL900A specification.
		/// </summary>
		/// <param name="lt"><see cref="LoggerTime"/> time structure.</param>
		/// <returns>32-bit representation of the start time.</returns>
		public static uint LoggerTimeToUint(LoggerTime lt)
		{
			return BuildStartTime(lt.sec, lt.min, lt.hour, lt.day, lt.month, lt.year);
		}

		/// <summary>
		/// Convert the temperature sensor's A/D result into temperature 
		/// based on the given reference voltages v01 and v02 as specified
		/// by the SL900A datasheet, page 19.
		/// </summary>
		/// <param name="vo1mV">The Vo1 reference voltage in mV.</param>
		/// <param name="vo2mV">The Vo2 reference voltage in mV.</param>
		/// <param name="adValue"></param>
		/// <returns></returns>
		public static double TemperatureConversion(double vo1mV, double vo2mV, uint adValue)
		{
			double code = (double)adValue;
			double result = 0.0;

			double div, denom;

			// As per SL900A tag's datasheet, page 19:
			div = 1.686 * 1024.0;

			denom = (vo2mV * (code + 1024.0)) - (code * vo1mV);

			result = (denom / div) - 273.15;

			return result;
		}

		/*public static double TemperatureDefault(uint adValue)
		{
			double code = (double)adValue;
			double result = 0.0;

			double div, denom;

			// Values expected in mV:
			vo1mV /= 1000.0;
			vo2mV /= 1000.0;

			// As per SL900A tag's datasheet, page 19:
			div = 1.686 * 1024.0;

			denom = (vo2mV * (code + 1024.0)) - (code * vo1mV);

			result = (denom / div) - 273.15;

			return result;
		} */
	}
}
