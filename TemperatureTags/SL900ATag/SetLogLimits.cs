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
		private const byte CMD_SET_LOGLIMITS = 0xA2;
		/* Log limit related. */
		/* 10 bits per limit. */
		private const int LL_LIMIT_MASKLEN = 10;
		private const int LL_LIMIT_MASK = (1 << 10) - 1;
		private const ushort LIMITS_EXPECTED_BITS = 32;		// Bits

		private void LogLimitExchange(uint password, bool secured, uint eLower, uint lower, uint upper, uint eUpper)
		{
			List<BitEntry> entries = new List<BitEntry>();
			BitBuffer bb;
			NurApi.CustomExchangeParams xch;
			NurApi.CustomExchangeResponse resp;
			int respLen;

			eLower &= LL_LIMIT_MASK;
			lower &= LL_LIMIT_MASK;
			upper &= LL_LIMIT_MASK;
			eUpper &= LL_LIMIT_MASK;

			/* Add limits. */
			entries.Add(BuildEntry(ADD_PARAMETER, eLower, LL_LIMIT_MASKLEN));
			entries.Add(BuildEntry(ADD_PARAMETER, lower, LL_LIMIT_MASKLEN));
			entries.Add(BuildEntry(ADD_PARAMETER, upper, LL_LIMIT_MASKLEN));
			entries.Add(BuildEntry(ADD_PARAMETER, eUpper, LL_LIMIT_MASKLEN));

			/* Build the command. */
			bb = BuildCommand(CMD_SET_LOGLIMITS, entries);

			/* Handle false, because it is the only content in the response. */
			xch = BuildDefault(bb, 0, false, true);

			resp = hApi.CustomExchangeSingulated(password, secured, NurApi.BANK_EPC, 32, epc.Length * 8, epc, xch);

			respLen = resp.tagBytes.Length;

			if (resp.error != NurApiErrors.NUR_NO_ERROR)
			{
				if (respLen >= MIN_ERROR_RESP_LENGTH)
					InterpretedException("Set limits", resp);
				DoException("Set limits", resp);
			}
		}

		private void LogLimitExchange(uint password, bool secured, LogLimits ll)
		{
			LogLimitExchange(password, secured, ll.extLower, ll.lower, ll.upper, ll.extUpper);
		}

        /// <summary>
        /// Get or set the lmit information, <see cref="LogLimits"/>.
        /// </summary>
		/// <exception cref="ApplicationException">Thrown when tag responded with an error or the tag's response length was invalid.</exception>
		/// <exception cref="NurApiException">Exception is thrown when communication error occured with the tag or module.</exception>
		public LogLimits Limits
        {
            set
            {
                LogLimitExchange(0, false, value);
            }
            get
            {
				MeasurementSetup ms = Setup;
                return ms.limits;
            }
        }

		/// <summary>
		/// Set log limits based on the given parameters.
		/// </summary>
		/// <param name="eLower">Extreme lower limit as defined in the LS900A specification.</param>
        /// <param name="lower">Loower limit as defined in the LS900A specification.</param>
        /// <param name="upper">Upper limit as defined in the LS900A specification.</param>
        /// <param name="eUpper">Extreme upper limit as defined in the LS900A specification.</param>
		/// <exception cref="ApplicationException">Thrown when tag responded with an error or the tag's response length was invalid.</exception>
		/// <exception cref="NurApiException">Exception is thrown when communication error occured with the tag or module.</exception>
        public void SetLogLimits(uint eLower, uint lower, uint upper, uint eUpper)
		{
			LogLimitExchange(0, false, eLower, lower, upper, eUpper);
		}
	}
}
