using System;
using System.Collections.Generic;
using System.Text;

using NurApiDotNet;

namespace SL900A
{
	public partial class SL900ATag : NurApi.Tag
	{
		private const byte CMD_INITIALIZE = 0xAC;
		/* Capture possible error(s) so no length. */
		private const ushort INITCMD_RESP_LEN = 0;
        /* Only handle. */
        private const int INITCMD_RESP_BYTES = 2;

		private const int DELAYTIME_BITS = 12;
        private const int DELAYTIME_LSH = 4;
		private const uint DELAYTIME_MASK_VAL = (1 << DELAYTIME_BITS) - 1;

        private const int DELAYMODE_LSH = 1;
        private const uint DELAYMODE_MASK = (1 << DELAYMODE_LSH);


		private const int BROKENWORD_BITS = 3;
		private const uint BROKENWORD_MASK_VAL = (1 << BROKENWORD_BITS) - 1;

		private const int APPWORDCOUNT_BITS = 9;
		private const uint APPWORDCOUNT_MASK_VAL = (1 << APPWORDCOUNT_BITS) - 1;
		
		private const int PARAMBITS_DELAYTIME = 16;
		private const int PARAMBITS_APPDATA = 16;

		private void InitExchange(uint password, bool secured,
			bool enIrqTimer, bool dmExtSwitch, uint delayTime, uint brokenWordPtr, uint appWordCount)
		{
			CheckInitParams(delayTime, brokenWordPtr, appWordCount);

			List<BitEntry> entries = new List<BitEntry>();
			BitBuffer bb;
			NurApi.CustomExchangeParams xch;
			NurApi.CustomExchangeResponse resp;
			int respLen;

			uint delayTimePar = 0;
			uint appDataParam = 0;

			delayTimePar = BuildDelayTimePar(enIrqTimer, dmExtSwitch, delayTime);
			appDataParam = BuildAppDataParam(brokenWordPtr, appWordCount);

			entries.Add(BuildEntry(ADD_PARAMETER, delayTimePar, PARAMBITS_DELAYTIME));
			entries.Add(BuildEntry(ADD_PARAMETER, appDataParam, PARAMBITS_APPDATA));

			bb = BuildCommand(CMD_INITIALIZE, entries);
			/* No handle strip, handle is the only response content. 
			 * TODO: is write / not?
			 */
			xch = BuildDefault(bb, 0, false, true);

			resp = hApi.CustomExchangeSingulated(password, secured, NurApi.BANK_EPC, 32, epc.Length * 8, epc, xch);
			respLen = resp.tagBytes.Length;
            hApi.ULog("INIT: len = " + respLen + ".");
            if (resp.error != NurApiErrors.NUR_NO_ERROR) 
			{
				if (respLen >= MIN_ERROR_RESP_LENGTH)
					InterpretedException("Initialize", resp);
				DoException("Initialize", resp);
			}
		}

		private uint BuildDelayTimePar(bool enIrqTimer, bool dmExtSwitch, uint delayTime)
		{
			uint ret = 0;
            uint tmp;

            tmp = delayTime & DELAYTIME_MASK_VAL;
            tmp <<= DELAYTIME_LSH;
            ret |= tmp;

            if (dmExtSwitch)
                ret |= DELAYMODE_MASK;
			
            /* Bit 0 */
            ret |= BoolToUint(enIrqTimer);

			return ret;
		}

		private uint BuildAppDataParam(uint brokenWordPtr, uint appWordCount)
		{
			uint ret = 0;

			ret = (appWordCount & APPWORDCOUNT_MASK_VAL);
			ret <<= (4 + BROKENWORD_BITS);	// 4 = RFU
			ret |= (brokenWordPtr & BROKENWORD_MASK_VAL);

			return ret;
		}

		private void CheckInitParams(uint delayTime, uint brokenWordPtr, uint appWordCount)
		{
			if (delayTime > DELAYTIME_MASK_VAL ||
				brokenWordPtr > BROKENWORD_MASK_VAL ||
				appWordCount > APPWORDCOUNT_MASK_VAL)
			{
				//throw new ApplicationException("Initialize: one or more invalid parameters.");
				throw new ApplicationException("Initialize: one or more invalid parameters: " + delayTime + ", " + brokenWordPtr + ", " + appWordCount + ".");
			}
		}

		/// <summary>
		/// Structure that represents the initialization data as specified by the 
		/// SL900A specification.
		/// </summary>
		public struct InitData
		{
			/// <summary>
			/// Enable IRQ + timer.
			/// </summary>
			public bool enIrqTimer;
			/// <summary>
			/// If true then the delay mode field is set to "external switch".
			/// </summary>
			public bool dmExtSwitch;
			/// <summary>
			/// 12-bit value for delay time.
			/// </summary>
			public uint delayTime;

			/// <summary>
			/// The 3-bit value for the "broken word pointer"-field.
			/// </summary>
			public uint brokenWordPtr;

			/// <summary>
			/// Number of words for application data.
			/// </summary>
			public uint appWordCount;
		}

		/// <summary>
		/// Do the initialization command.
		/// </summary>		
		/// <exception cref="ApplicationException">Thrown when tag responded with an error or the tag's response length was invalid.</exception>
		/// <exception cref="NurApiException">Exception is thrown when communication error occured with the tag or module.</exception>
		public InitData Initialize
		{
			set
			{
				hApi.ULog("Initialize: " + value.delayTime + ", " + value.brokenWordPtr + ", " + value.appWordCount + ".");
				InitExchange(0, false, value.enIrqTimer, value.dmExtSwitch, value.delayTime, value.brokenWordPtr, value.appWordCount);
			}
		}
	}
}
