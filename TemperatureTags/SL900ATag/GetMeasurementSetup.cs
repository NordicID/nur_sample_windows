/* 
  Copyright © 2014- Nordic ID 
  NORDIC ID DEMO SOFTWARE DISCLAIMER

  You are about to use Nordic ID Demo Software ("Software"). 
  It is explicitly stated that Nordic ID does not give any kind of warranties, 
  expressed or implied, for this Software. Software is provided "as is" and with 
  all faults. Under no circumstances is Nordic ID liable for any direct, special, 
  incidental or indirect damages or for any economic consequential damages to you 
  or to any third party.

  The use of this software indicates your complete and unconditional understanding 
  of the terms of this disclaimer. 
  
  IF YOU DO NOT AGREE OF THE TERMS OF THIS DISCLAIMER, DO NOT USE THE SOFTWARE.  
*/

using System;
using System.Collections.Generic;
using System.Text;

using NurApiDotNet;

namespace SL900A
{
	public partial class SL900ATag : NurApi.Tag
	{
		private const byte CMD_GET_MEAS_SETUP = 0xA3;
		private const ushort GETMEAS_RESP_LEN = 144;
		private const int GETMEAS_RESP_BYTES = (GETMEAS_RESP_LEN / 8);

		/* Byte sizes and offsets. */
		private const int MEAS_OFFSET_START = 0;
		private const int MEAS_SZ_START = 4;

		/* Log limit data. */
		private const int MEAS_OFFSET_LIMITS = MEAS_OFFSET_START + MEAS_SZ_START;
		private const int MEAS_SZ_LIMITS = 5;
		/* Log mode */
		private const int MEAS_OFFSET_MODE = MEAS_OFFSET_LIMITS + MEAS_SZ_LIMITS;
		private const int MEAS_SZ_MODE = 1;
		/* Interval  */
		private const int MEAS_OFFSET_INTVAL = MEAS_OFFSET_MODE + MEAS_SZ_MODE;
		private const int MEAS_SZ_INTVAL = 2;
		/* Delay time */
		private const int MEAS_OFFSET_DELAY = MEAS_OFFSET_INTVAL + MEAS_SZ_INTVAL;
		private const int MEAS_SZ_DELAY = 2;
		/* Application data */
		private const int MEAS_OFFSET_APPDATA = MEAS_OFFSET_DELAY + MEAS_SZ_DELAY;
		private const int MEAS_SZ_APPDATA = 2;

		/* Bit offsets for limits. */
		private const int BITOFS_EXTLOWER = 0;
		private const int BITOFS_LOWER = BITOFS_EXTLOWER + LL_LIMIT_MASKLEN;
		private const int BITOFS_UPPER = BITOFS_LOWER + LL_LIMIT_MASKLEN;
		private const int BITOFS_EXTUPPER = BITOFS_UPPER + LL_LIMIT_MASKLEN;

		/// <summary>
		/// Received when the <see cref="Setup"/> is read.
		/// </summary>
		public struct MeasurementSetup
		{
			/// <summary>
			/// Start time as spcified by the SL900A specification.
			/// </summary>
			public uint startTime;
			/// <summary>
			/// Log limits as specified by <see cref="LogLimits"/>.
			/// </summary>
			public LogLimits limits;
			/// <summary>
			/// Logging form as specified by <see cref="LoggingForm"/>.
			/// </summary>
			public LoggingForm form;
			/// <summary>
			/// If true then the storage rolls over when full.
			/// Otherwise it stops.
			/// </summary>
			public bool roll;
			/// <summary>
			/// Battery check enabled / not.
			/// </summary>
			public bool battChkEn;
			/// <summary>
			/// Temperature sensor enmabled / not.
			/// </summary>
			public bool tempSensEn;
			/// <summary>
			/// External sensor 1 enabled / not.
			/// </summary>
			public bool ext1En;
			/// <summary>
			/// External sensor 2 enabled / not.
			/// </summary>
			public bool ext2En;
			/// <summary>
			/// Logging interval as spcified by the SL900A specification.
			/// </summary>
			public uint interval;

			/// <summary>
			/// Delay time as spcified by the SL900A specification.
			/// </summary>
			public ushort delayTime;
			/// <summary>
			/// If true the then delay mode is "external switch", otherwise "timer".
			/// </summary>
			public bool delayModeExt;
			/// <summary>
			/// IRQ + timer enabled / not.
			/// </summary>
			public bool irqTimerEn;
			/// <summary>
			/// Number of words for application data.
			/// </summary>
			public uint appDataWords;
			/// <summary>
			/// Broken word pointer.
			/// </summary>
			public uint brokenWordPtr;
		}

		/* Return the start time in system endian (little). */
		/* Assume src is the whole response. */
		private uint ExtractStartTime(byte[] src)
		{
			byte[] timeBytes = new byte[MEAS_SZ_START];
			System.Array.Copy(src, timeBytes, MEAS_OFFSET_START);
			/* To little-endian. */
			System.Array.Reverse(timeBytes);
			
			return BitConverter.ToUInt32(timeBytes, 0);
		}

		/* Assume that "src" is the whole response. */
		private LogLimits ExtractLogLimits(byte[] src)
		{
			LogLimits ll = new LogLimits();
			int bitAddress;

			bitAddress = BytesToBits(MEAS_OFFSET_LIMITS) + BITOFS_EXTLOWER;
			ll.extLower = GetBitsBigEndian(src, bitAddress, LL_LIMIT_MASKLEN);
			bitAddress += LL_LIMIT_MASKLEN;
			ll.lower = GetBitsBigEndian(src, bitAddress, LL_LIMIT_MASKLEN);
			bitAddress += LL_LIMIT_MASKLEN;
			ll.upper = GetBitsBigEndian(src, bitAddress, LL_LIMIT_MASKLEN);
			bitAddress += LL_LIMIT_MASKLEN;
			ll.extUpper = GetBitsBigEndian(src, bitAddress, LL_LIMIT_MASKLEN);

			return ll;
		}

		private LoggingForm ExtractLoggingForm(byte[] src)
		{
			uint val = src[MEAS_OFFSET_MODE];
			return UintToLoggingForm((val >> LM_MEAS_FORM_LSH) & LM_MEAS_FORM_MASKVAL);
		}

		/* Get the current measurement setup from the tag. */
        private MeasurementSetup MeasurementSetupExchange(uint password, bool secured)
		{
			MeasurementSetup theSetup = new MeasurementSetup();
			BitBuffer bb;
			NurApi.CustomExchangeParams xch;
			NurApi.CustomExchangeResponse resp;
			uint tmp;
			int respLen;

			/* Build the command. */
			bb = BuildCommand(CMD_GET_MEAS_SETUP, null);			
			//xch = BuildDefault(bb, 0, false, false);
			xch = BuildDefault(bb, GETMEAS_RESP_LEN, false, false);			
			
			resp = hApi.CustomExchangeSingulated(password, secured, NurApi.BANK_EPC, 32, epc.Length * 8, epc, xch);
			respLen = resp.tagBytes.Length;

			if (resp.error != NurApiErrors.NUR_NO_ERROR || respLen != GETMEAS_RESP_BYTES)
			{
				hApi.ULog("Get setup error: " + resp.error + ", len = " + respLen + ".");
				if (respLen >= MIN_ERROR_RESP_LENGTH)
					InterpretedException("Measurement setup", resp);
				DoException("Measurement setup", resp);
			}

			theSetup.startTime = ExtractStartTime(resp.tagBytes);
			theSetup.limits = ExtractLogLimits(resp.tagBytes);
			theSetup.form = ExtractLoggingForm(resp.tagBytes);

			theSetup.roll = IsMaskBitSet(resp.tagBytes[MEAS_OFFSET_MODE], LM_MEAS_ROLL_BIT);
			theSetup.interval = GetBitsBigEndian(resp.tagBytes, BytesToBits(MEAS_OFFSET_INTVAL), BytesToBits(MEAS_SZ_INTVAL));

			theSetup.battChkEn = IsMaskBitSet(resp.tagBytes[MEAS_OFFSET_MODE], LM_MEAS_BATTCHK_BIT);
			theSetup.tempSensEn = IsMaskBitSet(resp.tagBytes[MEAS_OFFSET_MODE], LM_MEAS_TEMPSENS_BIT);
			theSetup.ext1En = IsMaskBitSet(resp.tagBytes[MEAS_OFFSET_MODE], LM_MEAS_EXT1_BIT);
			theSetup.ext2En = IsMaskBitSet(resp.tagBytes[MEAS_OFFSET_MODE], LM_MEAS_EXT2_BIT);

            tmp = resp.tagBytes[MEAS_OFFSET_DELAY];
            tmp <<= 8;
            tmp |= resp.tagBytes[MEAS_OFFSET_DELAY+1];

			theSetup.delayModeExt = IsMaskBitSet(tmp, LM_MEAS_DLYMODE_BIT);
			theSetup.irqTimerEn = IsMaskBitSet(tmp, LM_MEAS_IRQTME_EN_BIT);
			theSetup.delayTime = (ushort)((tmp >> LM_MEAS_DLY_LSH) & LM_MEAS_DLY_MASKVAL);

            tmp = resp.tagBytes[MEAS_OFFSET_APPDATA];
            tmp <<= 8;
            tmp |= resp.tagBytes[MEAS_OFFSET_APPDATA + 1];

			theSetup.appDataWords = ((tmp >> LM_MEAS_APPDATA_LSH) & LM_MEAS_APPDATA_MASKVAL);
			theSetup.brokenWordPtr = (tmp & LM_MEAS_BROKEN_MASK);

			return theSetup;
		}

        /// <summary>
        /// Return the tag's current measurement setup.
        /// </summary>
        /// <seealso cref="MeasurementSetup"/>
		/// <exception cref="ApplicationException">Thrown when tag responded with an error or the tag's response length was invalid.</exception>
		/// <exception cref="NurApiException">Exception is thrown when communication error occured with the tag or module.</exception>
        public MeasurementSetup Setup
        {
            get
            {
                return MeasurementSetupExchange(0, false);
            }
        }
	}
}
