using System;
using System.Collections.Generic;
using System.Text;

using NurApiDotNet;

namespace SL900A
{
	public partial class SL900ATag : NurApi.Tag
	{
        private const byte CMD_SET_LOGMODE = 0xA1;
        private const int LM_VALUEBITS = 24;	// Bits
        private const ushort LM_RESP_LEN = 32;	// Bits

		/// <summary>
		/// Constant defining the dense logging from.
		/// </summary>
		public const uint LFORM_DENSE = 0;
		/// <summary>
		/// Constant defining the dense logging from.
		/// </summary>
		public const uint LFORM_ALLOUT = 1;
		/// <summary>
		/// Constant defining the limits crossing logging from.
		/// </summary>
		public const uint LFORM_CROSSING = 3;
		/// <summary>
		/// Constant defining the IRQ1 based logging.
		/// </summary>
		public const uint LFORM_IRQ1 = 5;
		/// <summary>
		/// Constant defining the IRQ2 based logging.
		/// </summary>
		public const uint LFORM_IRQ2 = 6;
		/// <summary>
		/// Constant defining logging based on both IRQs.
		/// </summary>
		public const uint LFORM_BOTHIRQS = 7;

        /// <summary>
        /// Structure that represents the logging mode parameters.
        /// </summary>
        public struct LogMode
        {
            /// <summary>
            /// Definition for the logging form;
            /// </summary>
            public LoggingForm form;
            /// <summary>
            /// If the EEPROM is full and this flag is true,  then the tag
            /// continues from the beginning of the EEPROM and writes over old data.
            /// </summary>
            public bool roll;
            /// <summary>
            /// Enables external sensor 1.
            /// </summary>
            public bool ext1En;
            /// <summary>
            /// Enables external sensor 2.
            /// </summary>
			public bool ext2En;
            /// <summary>
            /// Enables temperature sensor.
            /// </summary>
            public bool tempSensEn;
            /// <summary>
            /// Enables battery check.
            /// </summary>
            public bool battChkEn;
            /// <summary>
            /// The logging interval.
            /// </summary>
            public uint interval;
        };

		/// <summary>
		/// Convert <see cref="LoggingForm"/> to an unsigned integer.
		/// </summary>
		/// <param name="form">Logging form enumeration <see cref="LoggingForm"/>.</param>
		/// <returns>Converted unsigned integer that represents the logging form.</returns>
		public static uint LoggingFormToUint(LoggingForm form)
		{
			uint ret = LFORM_DENSE;
			switch (form)
			{
				default:
				case LoggingForm.Dense: break;
				case LoggingForm.AllOut: ret = LFORM_ALLOUT; break;
				case LoggingForm.Crossing: ret = LFORM_CROSSING; break;
				case LoggingForm.IRQ1: ret = LFORM_IRQ1; break;
				case LoggingForm.IRQ2: ret = LFORM_IRQ2; break;
				case LoggingForm.BothIRQs: ret = LFORM_BOTHIRQS; break;
			}

			return ret;
		}

		/// <summary>
		/// Convert a 32-bit logging form value, as specified in the SL900A specification, to the <see cref="LoggingForm"/> structure.
		/// </summary>
		/// <param name="lfValue">The value backscattered by the tag.</param>
		/// <returns><see cref="LoggingForm"/></returns>
		/// <exception cref="ApplicationException">Thrown with invalid value.</exception>		
		public static LoggingForm UintToLoggingForm(uint lfValue)
		{
			LoggingForm ret;

			switch (lfValue)
			{
				case 0: ret = LoggingForm.Dense; break;
				case 1: ret = LoggingForm.AllOut; break;
				case 3: ret = LoggingForm.Crossing; break;
				case 5: ret = LoggingForm.IRQ1; break;
				case 6: ret = LoggingForm.IRQ2; break;
				case 7: ret = LoggingForm.BothIRQs; break;

				default:
					throw new ApplicationException("UintToLoggingForm: invalid value " + lfValue);
			}

			return ret;
		}

		private NurApi.CustomExchangeParams ModeToParameters(LogMode lm)
		{
            NurApi.CustomExchangeParams xch;
			List<BitEntry> entries = new List<BitEntry>();
			BitBuffer bb;
			uint paramValue = 0;

			paramValue = LogModeToBits(lm);

			entries.Add(BuildEntry(ADD_PARAMETER, paramValue, LM_VALUEBITS));
			/* Build the command. */
			bb = BuildCommand(CMD_SET_LOGMODE, entries);

			xch = BuildDefault(bb, 0, false, true);

			return xch;
		}

		private void LogModeExchange(uint accessPwd, bool secured, LogMode lm)
		{
			NurApi.CustomExchangeParams xch;
			NurApi.CustomExchangeResponse resp;
			int respLen;

			xch = ModeToParameters(lm);
			resp = hApi.CustomExchangeSingulated(accessPwd, secured, NurApi.BANK_EPC, 32, epc.Length * 8, epc, xch);
			respLen = resp.tagBytes.Length;

			if (resp.error != NurApiErrors.NUR_NO_ERROR)
			{
				if (respLen >= MIN_ERROR_RESP_LENGTH)
					InterpretedException("Log mode", resp);
				DoException("Log mode", resp);
			}
		}

        /// <summary>
        /// Attribute used the set or get the logging mode.
        /// </summary>
		/// <exception cref="ApplicationException">Thrown when tag responded with an error or the tag's response length was invalid.</exception>
		/// <exception cref="NurApiException">Exception is thrown when communication error occured with the tag or module.</exception>
		public LogMode Mode
        {
            set
            {
                LogModeExchange(0, false, value);
            }
            get
            {
				MeasurementSetup setup = Setup;
				LogMode lm = new LogMode();
				
				lm.roll = setup.roll;
				lm.battChkEn = setup.battChkEn;
				lm.ext1En = setup.ext1En;
				lm.ext2En = setup.ext2En;
				lm.tempSensEn = setup.tempSensEn;
				lm.interval = setup.interval;
				lm.form = setup.form;

				return lm;
            }
        }
	}
}
