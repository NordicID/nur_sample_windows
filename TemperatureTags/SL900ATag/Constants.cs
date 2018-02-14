using System;
using System.Collections.Generic;
using System.Text;

using NurApiDotNet;

namespace SL900A
{
	public partial class SL900ATag : NurApi.Tag
	{
		// Error byte + two bytes for handle.
		private const int MIN_ERROR_RESP_LENGTH = 3;
		
		/* Maybe later. */
		private const byte CMD_SET_CALIBRATION = 0xA5;
		private const byte CMD_GET_CALIBRATION = 0xA9;		

		private const int LM_INTERVAL_LSH = 1;
		private const int LM_INTERVAL_BITS = 15;
		private const uint LM_INTERVAL_MASKVAL = ((1 << LM_INTERVAL_BITS) - 1);
		private const uint LM_INTERVAL_MASK = (LM_INTERVAL_MASKVAL << LM_INTERVAL_LSH);

		private const int LM_BATTCHK_LSH = 16;
		private const int LM_BATTCHK_BIT = LM_BATTCHK_LSH;
		private const uint LM_BATTCHK_EN = (1 << LM_BATTCHK_LSH);

		private const int LM_TEMPSENS_LSH = 17;
		private const int LM_TEMPSENS_BIT = LM_TEMPSENS_LSH;
		private const uint LM_TEMPSENS_EN = (1 << LM_TEMPSENS_LSH);

		private const int LM_EXT2EN_LSH = 18;
		private const int LM_EXT2EN_BIT = LM_EXT2EN_LSH;
		private const uint LM_EXT2EN_EN = (1 << LM_EXT2EN_LSH);

		private const int LM_EXT1EN_LSH = 19;
		private const int LM_EXT1EN_BIT = LM_EXT1EN_LSH;
		private const uint LM_EXT1EN_EN = (1 << LM_EXT1EN_LSH);

		private const int LM_ROLLING_LSH = 20;
		private const int LM_ROLLING_BIT = LM_ROLLING_LSH;
		private const uint LM_ROLLING_EN = (1 << LM_ROLLING_LSH);

		private const int LM_FORMMASK_LSH = 21;
		private const uint LM_FORMMASK_VAL = 7;
		private const uint LM_FORMMASK = (LM_FORMMASK_VAL << LM_FORMMASK_LSH);

		/* In get measure setup the "log mode"-byte is somewhat different. */
		private const int LM_MEAS_FORM_LSH = 5;
		private const byte LM_MEAS_FORM_MASKVAL = (byte)LM_FORMMASK_VAL;
		private const byte LM_MEAS_FORM_MASK = (LM_MEAS_FORM_MASKVAL << LM_MEAS_FORM_LSH);

		private const int LM_MEAS_ROLL_BIT = 4;
		private const int LM_MEAS_EXT1_BIT = 3;
		private const int LM_MEAS_EXT2_BIT = 2;
		private const int LM_MEAS_BATTCHK_BIT = 1;
		private const int LM_MEAS_TEMPSENS_BIT = 0;

		/* Measurement setup delay time related. */
		private const int LM_MEAS_DLY_LSH = 4;
		private const uint LM_MEAS_DLY_MASKVAL = (1 << 12) - 1;
		private const uint LM_MEAS_DLY_MASK = (LM_MEAS_DLY_MASKVAL << LM_MEAS_DLY_LSH);
		private const int LM_MEAS_DLYMODE_LSH = 1;
		private const int LM_MEAS_DLYMODE_BIT = LM_MEAS_DLYMODE_LSH;

		private const int LM_MEAS_IRQTME_EN_LSH = 0;
		private const int LM_MEAS_IRQTME_EN_BIT = 0;

		private const int LM_MEAS_APPDATA_LSH = 7;
		private const uint LM_MEAS_APPDATA_MASKVAL = (1 << 9) - 1;
		private const uint LM_MEAS_APPDATA_MASK = (LM_MEAS_APPDATA_MASKVAL << LM_MEAS_APPDATA_LSH);
		private const uint LM_MEAS_BROKEN_MASK = (1 << 3) - 1;

		private const int YEAR_BITS = 6;
		private const int YEAR_LSH = 26;
		private const uint YEAR_MASK_VAL = (1 << YEAR_BITS) - 1;
		private const int MONTH_BITS = 4;
		private const int MONTH_LSH = 22;
		private const uint MONTH_MASK_VAL = (1 << MONTH_BITS) - 1;
		private const int DAY_BITS = 5;
		private const int DAY_LSH = 17;
		private const uint DAY_MASK_VAL = (1 << DAY_BITS) - 1;
		private const int HOUR_BITS = 5;
		private const int HOUR_LSH = 12;
		private const uint HOUR_MASK_VAL = (1 << HOUR_BITS) - 1;
		private const int MIN_BITS = 6;
		private const int MIN_LSH = 6;
		private const uint MIN_MASK_VAL = (1 << MIN_BITS) - 1;
		private const int SEC_BITS = 6;
		private const uint SEC_MASK_VAL = (1 << SEC_BITS) - 1;

		/* Structures etc. */

		/// <summary>
		/// Describes how the logging should be done.
		/// </summary>
		public enum LoggingForm
		{
			/// <summary>
			/// All values stored (0).
			/// </summary>
			Dense,
			/// <summary>
			/// All values out of limits are stored (1).
			/// </summary>
			AllOut,
			/// <summary>
			/// Only crossing points are stored (3).
			/// </summary>
			Crossing,
			/// <summary>
			/// Triggered by IRQ1 (5).
			/// </summary>
			IRQ1,
			/// <summary>
			/// Triggered by IRQ1 (6).
			/// </summary>
			IRQ2,
			/// <summary>
			/// Triggered by either IRQ (7).
			/// </summary>
			BothIRQs
		};

        /// <summary>
		/// Parameter structure for logging limits.
		/// </summary>
		public struct LogLimits
		{
			/// <summary>
			/// Extreme lower limit.
			/// </summary>
			public uint extLower;
			/// <summary>
			/// Lower limit.
			/// </summary>
			public uint lower;
			/// <summary>
			/// Upper limit.
			/// </summary>
			public uint upper;
			/// <summary>
			/// Extreme upper limit.
			/// </summary>
			public uint extUpper;
		};

		/// <summary>
		/// SFE (Sensor Front End) parameters as described by the SL900A specification.
		/// </summary>
		public struct SFESetup
		{
			/// <summary>
			/// Verify sensor ID.
			/// </summary>
			public uint verSensID;
			/// <summary>
			/// Automatic range disable.
			/// </summary>
			public bool disAutoRange;
			/// <summary>
			/// External sensor 2 high impedance input / not.
			/// </summary>
			/// <remarks>
			/// <list type="table"> <listheader><term>value</term><description>External sensor 1</description></listheader>
			/// <item><term>true</term><description>High impedance input, voltage follower, bridge</description></item>
			/// <item><term>false</term><description>Linear conductive sensor</description></item> 
			/// </list>
			/// </remarks>
			public bool ext2HighImp;

			/// <summary>
			/// External sensor 1 type.
			/// </summary>
			/// <remarks>
			/// <list type="table"><listheader><term>Member ext1Type</term><description>External sensor 1 type is</description></listheader>
			/// <item><term>0</term><description>Linear resistive</description></item>
			/// <item><term>1</term><description>High impedance input, voltage follower, bridge</description></item> 
			/// <item><term>2</term><description>Reserved</description></item>
			/// <item><term>3</term><description>capacitive or resistive sensor without DC (AC signal on EXC1)</description></item>
			/// </list>
			/// </remarks>
			public uint ext1Type;
			/// <summary>
			/// External sensor 1 range (current source value).
			/// </summary>
			public uint ext1Range;

			/// <summary>
			/// External sensor 2 range (resistive ladder).
			/// </summary>
			public uint ext2Range;
		}

		/// <summary>
		/// Structure representing the FIFO status register as specified by
		/// the SL900A specification.
		/// </summary>
		public struct FIFOStatusReg
		{
			/// <summary>
			/// Bit 7: FIFO busy.
			/// </summary>
			/// <remarks>IF this member is true when read then the FIFO was busy because of other access i.e. access via SPI.</remarks>
			public bool busy;
			/// <summary>
			/// Bit 6: data ready.
			/// </summary>
			public bool dataReady;
			/// <summary>
			/// Bit 5: no data.
			/// </summary>
			public bool noData;
			/// <summary>
			/// Bit 4: 0 = data from SPI, 1 = data from RFID.
			/// </summary>
			public bool fromRFID;
			/// <summary>
			/// Number of valid bytes in FIFO.
			/// </summary>
			public uint byteCount;
		}

		/// <summary>
		/// Error code when password is required but the provided one is either missing or incorrect.
		/// </summary>
		public const byte ERR_PASSWORD = 0xA0;
		/// <summary>
		/// Battery error i.e. the tag is in fully passive mode and the battery level was requested.
		/// </summary>
		public const byte ERR_BATTERY = 0xA2;
		/// <summary>
		/// Command is not allowed in current mode.
		/// </summary>
		public const byte ERR_NOT_ALLOWED = 0xA3;
		/// <summary>
		/// EEPROM was busy when tried to access.
		/// </summary>
		public const byte ERR_EEPROM_BUSY = 0xA6;

		/// <summary>
		/// Checks whether given error can be interpreted as one backscattered by an SL900A tag.
		/// </summary>
		/// <param name="error">Tag backscattered error code.</param>
		/// <returns>True if the given error code is recognized as an SL900A error code.</returns>
		/// <remarks>
		/// <list type="table"><listheader><term>Value</term><description>Error meaning</description></listheader>
		/// <item>
		/// <term><see>ERR_PASSWORD</see></term><description>Error code when password is required but the provided one is either missing or incorrect.</description>
		/// </item>
		/// <item>
		/// <term><see>ERR_BATTERY</see></term><description>Battery error i.e. the tag is in fully passive mode and the battery level was requested.</description>
		/// </item>
		/// <item>
		/// <term><see>ERR_NOT_ALLOWED</see></term><description>Command is not allowed in current mode.</description>
		/// </item>
		/// <item>
		/// <term><see>ERR_EEPROM_BUSY</see></term><description>EEPROM was busy when tried to access.</description>
		/// </item>
		/// </list>
		/// </remarks>
		public static bool IsSL900AError(byte error)
		{
			if (error==ERR_PASSWORD || error==ERR_BATTERY || error==ERR_NOT_ALLOWED || error==ERR_EEPROM_BUSY) 
				return true;
			
			return false;
		}

		/// <summary>
		/// Interpret SL900A tag error with prefix string to the message.
		/// </summary>
		/// <param name="pref">Prefix to add to the error message.</param>
		/// <param name="tagError">Byte error received from the tag.</param>
		/// <returns>Prefixed string representing the error if recognized.</returns>
		/// <see cref="ERR_PASSWORD"/>
		/// <see cref="ERR_BATTERY"/>
		/// <see cref="ERR_NOT_ALLOWED"/>
		/// <see cref="ERR_EEPROM_BUSY"/>
		public static string InterpretError(string pref, byte tagError)
		{
			string ret = "";

			if (string.IsNullOrEmpty(pref) == false)
				ret = pref + ": ";
			
			ret += "SL900A tag error 0x" + tagError.ToString("X2") + ": ";
			switch (tagError)
			{
				case ERR_PASSWORD: ret += "invalid password - tag not open."; break;
				case ERR_BATTERY: ret += "no battery present, cannot measure voltage."; break;
				case ERR_NOT_ALLOWED: ret += "command is not allowed in active state."; break;
				case ERR_EEPROM_BUSY: ret += "EEPROM is busy - could not access at the moment."; break;
				default: ret += "unknown error code."; break;
			}

			return ret;
		}

		/// <summary>
		/// Interpret SL900A tag error.
		/// </summary>
		/// <param name="tagError">Byte error received from the tag.</param>
		/// <returns>String representing the error if recognized.</returns>
		/// <see cref="ERR_PASSWORD"/>
		/// <see cref="ERR_BATTERY"/>
		/// <see cref="ERR_NOT_ALLOWED"/>
		/// <see cref="ERR_EEPROM_BUSY"/>
		public static string InterpretError(byte tagError)
		{
			return InterpretError("", tagError);
		}

		private void InterpretedException(string funcStr, NurApi.CustomExchangeResponse resp)
		{
			throw new ApplicationException(InterpretError(funcStr, resp.tagBytes[0]));
		}

		private void DoException(string prefix, NurApi.CustomExchangeResponse resp)
		{
			string msg = prefix + ", error = " + resp.error;
			if (resp.tagBytes != null)
				msg += ", length = " + resp.tagBytes.Length;
			else msg += " (bytes = null)";

			throw new ApplicationException(msg);
		}
	}
}
