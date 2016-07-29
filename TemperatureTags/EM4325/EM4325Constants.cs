using System;
using System.Collections.Generic;
using System.Text;

using NurApiDotNet;

namespace EM4325
{
	public partial class EM4325Tag
	{
		/*
		 * Custom commands.
		 * Prefix for all commands in case some extension needs to be implemented.
		 * In suca a case this is added as a byte value (8 bits)
		 * and the command specification as a secon byte value.
		 */
		private const uint CUSTOM_PREFIX = 0xE0;

		private const bool DO_AS_WRITE = true;
		private const bool DO_AS_READ = false;
		private const bool NO_HANDLE_STRIP = false;
		private const bool STRIP_HANDLE = true;

		/// <summary>
		/// User memory size in bytes.
		/// </summary>
		public const int USERMEM_BYTE_SIZE = 0x180;

		/// <summary>
		/// User memory size in words (16-bit).
		/// </summary>
		public const int USERMEM_WORD_SIZE = USERMEM_BYTE_SIZE / 2;


		/// <summary>
		/// User memory size in DWORDs (32-bit unsigned).
		/// </summary>
		public const int USERMEM_DW_SIZE = USERMEM_BYTE_SIZE / 4;

		/// <summary>
		/// Number of bits in a proprietary/custom command.
		/// </summary>
		public const int PROPRIETARY_BITS = 16;

		/// <summary>
		/// Minimum value for write operations' timeout in ms.
		/// </summary>
		public const uint MIN_WRITETIMEOUT = 25;
		/// <summary>
		/// Minimum value for read operations' timeout in ms.
		/// </summary>
		public const uint MIN_READTIMEOUT = 20;
		/// <summary>
		/// Maximum timeout valur for read and write operations in ms.
		/// </summary>
		public const uint MAX_TIMEOUT = 100;

		/// <summary>
		/// Get UID as specified by the EM4325 datasheet.
		/// </summary>
		public const uint CMD_GET_UID = 0xE000;

		/// <summary>
		/// Expected number of bytes in UID response with allocation class E0.
		/// </summary>
		public const int RESPLEN_ALLOC_E0 = 8;
		/// <summary>
		/// Expected number of bytes in UID response with allocation class E3.
		/// </summary>
		public const int RESPLEN_ALLOC_E3 = 10;
		/// <summary>
		/// Expected number of bytes in UID response with allocation class E2.
		/// </summary>
		public const int RESPLEN_ALLOC_E2 = 12;

		/// <summary>
		/// Get sensor data.
		/// </summary>
		public const uint CMD_GET_SENSORDATA = 0xE001;

		/// <summary>
		/// SendSPI command.
		/// </summary>
		public const uint CMD_SEND_SPI = 0xE002;

		/// <summary>
		/// Reset alarms command.
		/// </summary>
		public const uint CMD_RESET_ALARMS = 0xE004;

		
		/// <summary>
		/// Minimum threshold value for temperature.
		/// </summary>
		public static float MIN_TEMP_THRESH = -64.0f;
		/// <summary>
		/// Maximum threshold value for temperature.
		/// </summary>
		public static float MAX_TEMP_THRESH = 63.75f;
		/// <summary>
		/// Temperature value in C defining the step value per bit.
		/// </summary>
		public static float TEMP_STEP_PER_BIT = 0.25f;

		/* 
		 * System addresses. 
		 * Adresses are word addresses each addressing a 16-bit word. 
		 */
		/// <summary>
		/// Temperature sensor 1.
		/// </summary>
		public const uint ADDR_CTLWORD_1 = 0xEC;
		/// <summary>
		/// Temperature sensor 2.
		/// </summary>
		public const uint ADDR_CTLWORD_2 = 0xED;
		/// <summary>
		/// Temperature sensor 3.
		/// </summary>
		public const uint ADDR_CTLWORD_3 = 0xEE;
		/// <summary>
		/// Calibration word.
		/// </summary>
		public const uint ADDR_CALIBRATION_WORD = 0xEF;
		/// <summary>
		/// I/O control word.
		/// </summary>
		public const uint ADDR_IOCTL_WORD = 0xF0;
		/// <summary>
		/// Battery management word 1.
		/// </summary>
		public const uint ADDR_BATT_MGMT_WORD_1 = 0xF1;
		/// <summary>
		/// Battery management word 2.
		/// </summary>
		public const uint ADDR_BATT_MGMT_WORD_2 = 0xF2;
		/// <summary>
		/// TOTAL word.
		/// </summary>
		public const uint ADDR_TOTAL_WORD = 0xF3;

		/// <summary>
		/// SPI write enable 1.
		/// </summary>
		public const uint ADDR_SPI_WREN_1 = 0xF4;
		/// <summary>
		/// SPI write enable 2.
		/// </summary>
		public const uint ADDR_SPI_WREN_2 = 0xF5;
		/// <summary>
		/// SPI write enable 3.
		/// </summary>
		public const uint ADDR_SPI_WREN_3 = 0xF6;
		/// <summary>
		/// SPI write enable 4.
		/// </summary>
		public const uint ADDR_SPI_WREN_4 = 0xF7;

		/// <summary>
		/// Lock word 1A.
		/// </summary>
		public const uint ADDR_LOCKWORD_1A = 0xF8;
		/// <summary>
		/// Lock word 2A.
		/// </summary>
		public const uint ADDR_LOCKWORD_2A = 0xF9;
		/// <summary>
		/// Lock word 3A.
		/// </summary>
		public const uint ADDR_LOCKWORD_3A = 0xFA;
		/// <summary>
		/// Lock word 4A.
		/// </summary>
		public const uint ADDR_LOCKWORD_4A = 0xFB;
		/// <summary>
		/// Lock word 1B.
		/// </summary>
		public const uint ADDR_LOCKWORD_1B = 0xFC;
		/// <summary>
		/// Lock word 2B.
		/// </summary>
		public const uint ADDR_LOCKWORD_2B = 0xFD;
		/// <summary>
		/// Lock word 3B.
		/// </summary>
		public const uint ADDR_LOCKWORD_3B = 0xFE;
		/// <summary>
		/// Lock word 4B.
		/// </summary>
		public const uint ADDR_LOCKWORD_4B = 0xFF;

		/// <summary>
		/// 32-bit sensor data MSW's address.
		/// </summary>
		public const uint ADDR_SENSORDATA_MSW = 0x100;
		/// <summary>
		/// 32-bit sensor data LSW's address.
		/// </summary>
		public const uint ADDR_SENSORDATA_LSW = 0x101;
		/// <summary>
		/// 32-bit UTC value's MSW address.
		/// </summary>
		public const uint ADDR_UTC_MSW = 0x102;
		/// <summary>
		/// 32-bit UTC value's LSW address.
		/// </summary>
		public const uint ADDR_UTC_LSW = 0x103;

		/// <summary>
		/// Register file base address.
		/// </summary>
		public const uint ADDR_REGFILE_BASE = 0x104;
		/// <summary>
		/// Number of register file words.
		/// </summary>
		public const int NR_REGFILE = 8;

		/// <summary>
		/// I/O word address.
		/// </summary>
		public const uint ADDR_IOWORD = 0x10C;
		/// <summary>
		/// BAP mode word address.
		/// </summary>
		public const uint ADDR_BAP_MODE = 0x10D;

		/// <summary>
		/// Maximum bytes in the SPI response.
		/// </summary>
		public const int MAX_SPI_RESPBYTES = (1 << 3) - 1;

		/// <summary>
		/// Two bits for the SPI clock definition.
		/// </summary>
		public const uint MAX_SPI_SCLK = (1 << 2) - 1;

		/// <summary>
		/// Two bits for the initial SCLK.
		/// </summary>
		public const uint MAX_SPI_INITDELAY = (1 << 2) - 1;

		/// <summary>
		/// Set 'uint boolean' based on value.
		/// </summary>
		/// <param name="b">Boolean to evaluate.</param>
		/// <returns>1 if b is true, zero otherwise.</returns>
		public static uint BoolToUint(bool b)
		{
			return (uint)(b ? 1 : 0);
		}
		/// <summary>
		/// Two bits for the delay time between bytes.
		/// </summary>
		public const uint MAX_SPI_BYTEDELAY = (1 << 2) - 1;

		/// <summary>
		/// Build default custom excange parameters.
		/// </summary>
		/// <param name="rxLen">Reception length in bits.</param>
		/// <param name="asWrite">If true then the reader's AFE shall behave like the reponse is to a write (longer timeout etc.).</param>
		/// <param name="stripHandle">Whether to strip the handle from the response  or not.</param>
		/// <returns>Pre-built custom exchange parameters, <see cref="NurApi.CustomExchangeParams"/>.</returns>
		public static NurApi.CustomExchangeParams BuildDefault(ushort rxLen, bool asWrite, bool stripHandle)
		{
			NurApi.CustomExchangeParams xch = new NurApi.CustomExchangeParams();

			// Each command has an appended handle.
			xch.appendHandle = BoolToUint(true);
			// Controls the behavior of the reader's AFE when operation is write or write-like.
			xch.asWrite = BoolToUint(asWrite);

			// Maximum number of bits -> bytes.
			xch.bitBuffer = new byte[NurApi.MAX_BITSTR_BITS / 8];
			// Responses expect CRC-16. 
			xch.noRxCRC = BoolToUint(false);
			// All commands use trasnmission's CRC-16.
			xch.noTxCRC = BoolToUint(false);
			
			// Careful.
			if (rxLen == 0)
			{
				xch.rxLen = 0;
				xch.rxLenUnknown = BoolToUint(true);
			}
			else
			{
				xch.rxLen = rxLen;
				xch.rxLenUnknown = BoolToUint(false);
			}

			// Usually the handle is removed from the responses. 
			// If a command contains handle only then this may be in order to set to 0.
			xch.rxStripHandle = BoolToUint(stripHandle);

			// Transmission does not use CRC-5.
			xch.txCRC5 = BoolToUint(false);

			// Updated when the transmitted bitstream is built.
			xch.txLen = 0;

			// No. We are expecting a response from the tag.
			xch.txOnly = BoolToUint(false);

			// No. There is no 'write-like' 16-bit data to be transmitted.
			xch.xorRN16 = BoolToUint(false);

			return xch;
		}


		/// <summary>
		/// Response structure for the GetUID command.
		/// </summary>
		public struct UIDResponse
		{
			/// <summary>
			/// The allocation class aas specified by the EM4325 specification (E0, E2, E3).
			/// </summary>
			public byte allocClass;
			/// <summary>
			/// Tag's 48-bit serial.
			/// </summary>
			public ulong serial;
			/// <summary>
			/// XTID header value. -1 means 'not present'.
			/// </summary>
			public int xtidHdr;
			/// <summary>
			/// Model number. -1 means 'not present'.
			/// </summary>
			public int modelNum;
			
			/// <summary>
			/// MDID value. -1 means 'not present'.
			/// </summary>
			public int mdid;
			/// <summary>
			/// XTID: 0 or 1, -1 means 'not present'.
			/// </summary>
			public int xtid;

			/// <summary>
			/// User memory size. -1 means 'not present'.
			/// </summary>
			public int umSize;

			/// <summary>
			/// Manufacturer ID. -1 means 'not present'.
			/// </summary>
			public int mid;

			/// <summary>
			/// Customer number. -1 means 'not present'.
			/// </summary>
			public int cn;

			/// <summary>
			/// CRC-16 for legacy TOTAL. -1 means 'not present'.
			/// </summary>			
			public int CRC16;

			/// <summary>
			/// Raw bytes of the response.
			/// </summary>
			public byte[] raw;
		}

		/// <summary>
		/// Sensor data structure.
		/// </summary>
		public struct SensorData
		{
			/// <summary>
			/// If true then the uid field is valid.
			/// </summary>
			public bool hasUid;
			/// <summary>
			/// The interpreted UID data from the tag if requested.
			/// </summary>
			public UIDResponse uid;
			/// <summary>
			/// Raw byte data from the tag.
			/// </summary>
			public byte[] raw;
			/// <summary>
			/// The 32-bit unsigned integer from the tag.
			/// </summary>
			public uint data;
			/// <summary>
			/// Interpreted temperature value from 'data'.
			/// </summary>
			public float temp;
			/// <summary>
			/// Battery alarm yes/no.
			/// </summary>
			public bool battAlarm;
			/// <summary>
			/// Battery AUX alarm.
			/// </summary>
			public bool auxAlarm;
			/// <summary>
			/// Over temperature alarm yes/no.
			/// </summary>
			public bool overTemp;
			/// <summary>
			/// Under temperature alarm yes/no.
			/// </summary>
			public bool underTemp;
			/// <summary>
			/// P3 input level.
			/// </summary>
			public int p3level;

			/// <summary>
			/// Monitoring enabled / not.
			/// </summary>
			public bool enabled;
			/// <summary>
			/// Simple sensor / not.
			/// </summary>
			public bool isSimple;
			/// <summary>
			/// Number of aborted measurements.
			/// </summary>
			public int abortCount;
			/// <summary>
			/// Number of under temperatures.
			/// </summary>
			public int underCount;
			/// <summary>
			/// Number of over temperatures.
			/// </summary>
			public int overCount;			
			/// <summary>
			/// The 32-bit unsigned integer prepresenting the UTC value.
			/// </summary>
			public uint utc;
		}
	}
}
