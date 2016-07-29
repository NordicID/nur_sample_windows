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
		private const byte CMD_SET_PASSWORD = 0xA0;		
		private const uint PWD_LEVEL_SYSTEM = 1;
		private const uint PWD_LEVEL_APP = 2;
		private const uint PWD_LEVEL_MEAS = 3;
		private const int PWD_LEVELBITS = 8;
		private const int PASSWORDBITS = 32;
		private const ushort PWD_RESP_LEN = 16;	// Bits, handle only.

		private void SetPassword(uint password, bool secured, uint level, uint areaPassword)
		{
			List<BitEntry> entries = new List<BitEntry>();
			BitBuffer bb;
			NurApi.CustomExchangeParams xch;
			NurApi.CustomExchangeResponse resp;
			int respLen;

			/* Add password level. */
			entries.Add(BuildEntry(ADD_PARAMETER, level, PWD_LEVELBITS));
			/* Add password. */
			entries.Add(BuildEntry(ADD_PARAMETER, areaPassword, PASSWORDBITS));
			/* Build the command. */
			bb = BuildCommand(CMD_SET_PASSWORD, entries);

			/* Handle false, because it is the only content in the response. */
			xch = BuildDefault(bb, 0, false, true);

			resp = hApi.CustomExchangeSingulated(password, secured, NurApi.BANK_EPC, 32, epc.Length * 8, epc, xch);
			respLen = resp.tagBytes.Length;

			if (resp.error != NurApiErrors.NUR_NO_ERROR)
			{
				if (respLen >= MIN_ERROR_RESP_LENGTH)
					InterpretedException("Set password", resp);
				DoException("Set password", resp);
			}
		}

		/// <summary>
		/// Set the system password.
		/// </summary>
		/// <exception cref="ApplicationException">Thrown when tag responded with an error or the tag's response length was invalid.</exception>
		/// <exception cref="NurApiException">Exception is thrown when communication error occured with the tag or module.</exception>
		public uint SystemPassword
		{
			set
			{
				SetPassword(0, false, PWD_LEVEL_SYSTEM, value);
			}
		}

		/// <summary>
		/// Set the application password.
		/// </summary>
		/// <exception cref="ApplicationException">Thrown when tag responded with an error or the tag's response length was invalid.</exception>
		/// <exception cref="NurApiException">Exception is thrown when communication error occured with the tag or module.</exception>
		public uint ApplicationPassword
		{
			set
			{
				SetPassword(0, false, PWD_LEVEL_APP, value);
			}
		}

		/// <summary>
		/// Set the measurement password.
		/// </summary>
		/// <exception cref="ApplicationException">Thrown when tag responded with an error or the tag's response length was invalid.</exception>
		/// <exception cref="NurApiException">Exception is thrown when communication error occured with the tag or module.</exception>
		public uint MeasurementPassword
		{
			set
			{
				SetPassword(0, false, PWD_LEVEL_MEAS, value);
			}
		}
	}
}

