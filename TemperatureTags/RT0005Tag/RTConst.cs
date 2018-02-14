using System;
using System.Collections.Generic;
using System.Text;

namespace CAENRT0005
{
	public class RTConst
	{
		/// <summary>
		/// Reserved memorys extra bytes' word address.
		/// </summary>
		public const uint PASSWD_EXTRA_ADDR = 4;

		/// <summary>
		/// Number of bytes in the password memory word address 4.
		/// </summary>
		public const int NR_PASSWD_EXTRA_BYTES = 56;

		/// <summary>
		/// Number of "BINs" the tag can handle.
		/// </summary>
		public const int NR_BINS = 16;

		/// <summary>
		/// Index/number of the last BIN.
		/// </summary>
		public const int LAST_BIN = 15;

		/// <summary>
		/// Minimum number of registers to read at once with multiread.
		/// </summary>
		public const int MIN_RD_COUNT = 1;

		/// <summary>
		/// Maximum number of registers to read at once with multiread.
		/// </summary>
		public const int MAX_RD_COUNT = 32;

		/// <summary>
		/// Control register: reset bit.
		/// </summary>
		public const ushort CTL_RESET_MASK = 1;

		/// <summary>
		/// Control register: button enable bit.
		/// </summary>
		public const int CTL_BTNEN_LSH = 1;

		/// <summary>
		/// Control register: button enable mask.
		/// </summary>
		public const ushort CTL_BTNEN_MASK = (1 << CTL_BTNEN_LSH);

		/// <summary>
		/// Control register: button enable bit.
		/// </summary>
		public const int CTL_LOGEN_LSH = 2;

		/// <summary>
		/// Control register: logging enable mask.
		/// </summary>
		public const ushort CTL_LOGEN_MASK = (1 << CTL_LOGEN_LSH);

		/// <summary>
		/// Control register: sample delay enable bit.
		/// </summary>
		public const int CTL_DLYEN_LSH = 3;

		/// <summary>
		/// Control register: sample delay enable mask.
		/// </summary>
		public const ushort CTL_DLYEN_MASK = (1 << CTL_DLYEN_LSH);

		/// <summary>
		/// Control register: left shift for RF sensitivity mask.
		/// </summary>
		public const int CTL_RFSENS_LSH = 4;

		/// <summary>
		/// Control register: mask for the RF sensitivity.
		/// </summary>
		public const ushort CTL_RFSENSEN_MASK = (3 << CTL_RFSENS_LSH);

		/// <summary>
		/// Control register: Mean Kinetic Energy Enable bit.
		/// </summary>
		public const int CTL_MKTEN_LSH = 6;

		/// <summary>
		/// Control register: Mean Kinetic Energy Enable mask.
		/// </summary>
		public const ushort CTL_MKTEN_MASK = (1 << CTL_MKTEN_LSH);

		/// <summary>
		/// Control register: Arrhenius enable bit.
		/// </summary>
		public const int CTL_ARREN_LSH = 7;

		/// <summary>
		/// Control register: Arrhenius enable mask.
		/// </summary>
		public const ushort CTL_ARREN_MASK = (1 << CTL_ARREN_LSH);

		/// <summary>
		/// Control register: stop (button) disable bit.
		/// </summary>
		public const int CTL_STOPDIS_LSH = 11;

		/// <summary>
		/// Bits [0:1] are the battery status.
		/// </summary>
		public const ushort STAT_BATT_MASK = 3;

		/// <summary>
		/// Control register: stop (button) disable mask.
		/// </summary>
		public const ushort CTL_STOPDIS_MASK = (1 << CTL_STOPDIS_LSH);

		/// <summary>
		/// Status register: memory full bit.
		/// </summary>
		public const int STAT_MEMFULL_LSH = 2;

		/// <summary>
		/// Status register: memory full mask.
		/// </summary>
		public const ushort STAT_MEMFULL_MASK = (ushort)(1 << STAT_MEMFULL_LSH);

		/// <summary>
		/// Status register: Estimated Time of Arrival alarm bit.
		/// </summary>
		public const int STAT_ETA_ALARM_LSH = 3;

		/// <summary>
		/// Status register: estimated Time of Arrival alarm mask.
		/// </summary>
		public const ushort STAT_ETA_ALARM_MASK = (ushort)(1 << STAT_ETA_ALARM_LSH);

		/// <summary>
		/// Status register: BIN alarm bit.
		/// </summary>
		public const int STAT_BIN_ALARM_LSH = 4;

		/// <summary>
		/// Status register: BIN alarm mask.
		/// </summary>
		public const ushort STAT_BIN_ALARM_MASK = (ushort)(1 << STAT_BIN_ALARM_LSH);

		/// <summary>
		/// Status register: Mean Kinetic Temperature alarm bit.
		/// </summary>
		public const int STAT_MKT_ALARM_LSH = 5;

		/// <summary>
		/// Status register: Mean Kinetic Temperature alarm mask.
		/// </summary>
		public const ushort STAT_MKT_ALARM_MASK = (ushort)(1 << STAT_MKT_ALARM_LSH);

		/// <summary>
		/// Status register: Shelf Life Alarm bit.
		/// </summary>
		public const int STAT_SHL_ALARM_LSH = 6;

		/// <summary>
		/// Status register: Shelf Life Alarm mask.
		/// </summary>
		public const ushort STAT_SHL_ALARM_MASK = (ushort)(1 << STAT_SHL_ALARM_LSH);

		/// <summary>
		/// Generic alarm mask for status register.
		/// </summary>
		public const ushort STAT_ALARM_MASK = (STAT_MEMFULL_MASK | STAT_ETA_ALARM_MASK | STAT_BIN_ALARM_MASK | STAT_MKT_ALARM_MASK | STAT_SHL_ALARM_MASK);

		/// <summary>
		/// First sample's location.
		/// </summary>
		public const uint LOG_AREA_BASE = 0x8A;

		/// <summary>
		/// Last address of the log memory.
		/// </summary>
		public const uint LOG_AREA_LAST = 0xFFE;

		/// <summary>
		/// Number of 16-bit words in the log memory.
		/// </summary>
		public const int NR_LOG_WORDS = (int)((LOG_AREA_LAST + 1) - LOG_AREA_BASE);

		/// <summary>
		/// Number of bytes in the log memory.
		/// </summary>
		public const int NR_LOG_BYTES = NR_LOG_WORDS * 2;

		/// <summary>
		/// Number of bytes in a "read chunk" when reading the samples.
		/// </summary>
		public const int READ_CHUNK_BYTES = 64;

		/// <summary>
		/// Number of 16-bit words in a "read chunk" when reading the samples.
		/// </summary>
		public const int READ_CHUNK_WORDS = (READ_CHUNK_BYTES / 2);

		/// <summary>
		/// Enumeration for simple logging.
		/// </summary>
		public enum LOGINTERVAL
		{
			/// <summary>
			/// 0 = no delay. Not to be used with sampling time.
			/// </summary>
			INT_NONE = 0,
			INT_1MIN,
			INT_2MIN,
			INT_5MIN,
			INT_10MIN,
			INT_15MIN,
			INT_30MIN,
			INT_1HR
		};


		/// <summary>
		/// A mask value to use for checking the validity 
		/// of the given 8.5. fixed format value.
		/// </summary>
		public const ushort US_TEMP_VALID_MASK = (ushort)(0x1FFF ^ 0xFFFF);

		/// <summary>
		/// Conversion divider constant.
		/// </summary>
		public const double TEMP_DIV = 32.0;

		/// <summary>
		/// 
		/// </summary>
		public const double NEG_CONST = 8192.0;

		/// <summary>
		/// 
		/// </summary>
		public const ushort FIXED_70LIM = (ushort)(70 * 32);
		
		/// <summary>
		/// 
		/// </summary>
		public const ushort FIXED_MINUS20LIM = (ushort)0x1D80;

		/// <summary>
		/// 
		/// </summary>
		public const double MIN_TEMP = -20.0;
		
		/// <summary>
		/// 
		/// </summary>
		public const double MAX_TEMP = 70.0;

		public struct SAMPLEDATA
		{
			/// <summary>
			/// Minimum value in the samples.
			/// </summary>
			public double min;

			/// <summary>
			/// Maximum value in the samples.
			/// </summary>
			public double max;

			/// <summary>
			/// Sample values
			/// </summary>
			public double[] values;
		}

		/// <summary>
		/// Register range check access type: 16-bit = short register.
		/// </summary>
		public const bool RW_16BIT = false;

		/// <summary>
		/// Register range check access type: 32-bit = UInt32 register.
		/// </summary>
		public const bool RW_32BIT = true;


		public static void RegRangeCheck(uint rtReg, string prefix, bool rwType32Bit)
		{
			uint lim = RTConst.LOG_AREA_LAST;

			if (rwType32Bit == RW_32BIT)
				lim--;

			if (rtReg < RTRegs.CONTROL || rtReg > lim)
			{
				string regStr = rtReg.ToString() + "(0x" + rtReg.ToString("8X") + ")";
				throw new IndexOutOfRangeException(prefix + ": register/memory index " + regStr + " is out of range");
			}
		}
		
		public static void RWCountCheck(int regCount, string exMsg)
		{
			if (regCount < RTConst.MIN_RD_COUNT || regCount > RTConst.MAX_RD_COUNT)
				throw new RTException(exMsg + ": range is 1...32");
		}
	}
}
