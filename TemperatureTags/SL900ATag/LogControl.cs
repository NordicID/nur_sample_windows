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
		private const byte CMD_ENDLOG = 0xA6;
		private const byte CMD_STARTLOG = 0xA7;
        private const ushort STARTSTOP_RESP_LEN = 0;	// Ready to receive error code.
        private const int STARTSTOP_TIME_LEN = 32;

		/// <summary>
		/// Logger time parameter as a structure.
		/// </summary>
		public struct LoggerTime
		{
			/// <summary>
			/// Seconds.
			/// </summary>
			public uint sec;
			/// <summary>
			/// Minutes.
			/// </summary>
			public uint min;
			/// <summary>
			/// Hours.
			/// </summary>
			public uint hour;
			/// <summary>
			/// Day of the month.
			/// </summary>
			public uint day;
			/// <summary>
			/// Month of the year.
			/// </summary>
			public uint month;
			/// <summary>
			/// Year.
			/// </summary>
			public uint year;
		}


        private void StartStopExchange(uint password, bool secured, bool start, uint uintTime)
		{
			BitBuffer bb;
			NurApi.CustomExchangeParams xch;
			NurApi.CustomExchangeResponse resp;
			int respLen;

			if (start)
			{
				List<BitEntry> entries = new List<BitEntry>();
				/* 32 bits in the start time definition. */
				entries.Add(BuildEntry(ADD_PARAMETER, uintTime, STARTSTOP_TIME_LEN));
				bb = BuildCommand(CMD_STARTLOG, entries);
				xch = BuildDefault(bb, 0, false, false);
			}
			else
			{
				bb = BuildCommand(CMD_ENDLOG, null);
				xch = BuildDefault(bb, 0, false, false);
			}

			resp = hApi.CustomExchangeSingulated(password, secured, NurApi.BANK_EPC, 32, epc.Length * 8, epc, xch);
			respLen = resp.tagBytes.Length;

			if (resp.error != NurApiErrors.NUR_NO_ERROR)
			{
				string pref = start ? "START" : "STOP";
				if (respLen >= MIN_ERROR_RESP_LENGTH)
					InterpretedException(pref, resp);
				DoException(pref, resp);
			}
		}

        /// <summary>
        /// Start or stop logging.
        /// </summary>
		/// <exception cref="ApplicationException">Thrown when tag responded with an error or the tag's response length was invalid.</exception>
		/// <exception cref="NurApiException">Exception is thrown when communication error occured with the tag or module.</exception>
        public bool Logging
        {
            set
            {
                if (value)
                    StartLog();
                else
                    StopLog();
            }
            get
            {
				LogStateInfo ls = LogState;
                return ls.actLogging;
            }
        }
		
		/// <summary>
		/// Start logging with given start time.
		/// </summary>
        /// <param name="lt">Start time parameter, <see cref="LoggerTime"/>.</param>
		/// <exception cref="ApplicationException">Thrown when tag responded with an error or the tag's response length was invalid.</exception>
		/// <exception cref="NurApiException">Exception is thrown when communication error occured with the tag or module.</exception>
        public void StartLog(LoggerTime lt)
		{
			StartStopExchange(0, false, true, LoggerTimeToUint(lt));
		}

		/// <summary>
		/// Start logging by getting the system time as a start value.
		/// </summary>
		/// <exception cref="ApplicationException">Thrown when tag responded with an error or the tag's response length was invalid.</exception>
		/// <exception cref="NurApiException">Exception is thrown when communication error occured with the tag or module.</exception>
		public void StartLog()
		{
			DateTime dt = DateTime.Now;
			uint sec, min, hr, day, mon, yr;

			sec = (uint)dt.Second;
			min = (uint)dt.Minute;
			hr = (uint)dt.Hour;
			day = (uint)dt.Day;
			mon = (uint)dt.Month;
			yr = (uint)dt.Year;
						
			StartStopExchange(0, false, true, BuildStartTime(sec, min, hr, day, mon, yr));
		}

        /// <summary>
        /// Stop logging.
        /// </summary>
		/// <exception cref="ApplicationException">Thrown when tag responded with an error or the tag's response length was invalid.</exception>
		/// <exception cref="NurApiException">Exception is thrown when communication error occured with the tag or module.</exception>
		public void StopLog()
		{
			StartStopExchange(0, false, false, 0);
		}
	}
}
