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
		private const byte CMD_SET_SFE_PARAMS = 0xA4;
		private const ushort SFESET_RESP_LEN = 16;	/* Handle only. */
		private const int SFE_RANGE_BITS = 5;
		private const int SFE_SETI_BITS = 5;
		private const int SFE_EXT1_BITS = 2;
		private const int SFE_EXT2_BITS = 1;
		private const int SFE_AUTORANGE_BITS = 1;
		private const int SFE_VERSENSID_BITS = 2;

		private void SFEExchange(uint password, bool secured,
				uint ext2Range, uint ext1Range, uint ext1Type, bool ext2HighImp, bool disAutoRange, uint verSensId)
		{
			List<BitEntry> entries = new List<BitEntry>();
			BitBuffer bb;
			NurApi.CustomExchangeParams xch;
			NurApi.CustomExchangeResponse resp;
			int respLen;

			entries.Add(BuildEntry(ADD_PARAMETER, ext2Range, SFE_RANGE_BITS));
			entries.Add(BuildEntry(ADD_PARAMETER, ext1Range, SFE_SETI_BITS));
			entries.Add(BuildEntry(ADD_PARAMETER, ext1Type, SFE_EXT1_BITS));
			entries.Add(BuildEntry(ADD_PARAMETER, (uint)(ext2HighImp ? 1 : 0), SFE_EXT2_BITS));
			entries.Add(BuildEntry(ADD_PARAMETER, (uint)(disAutoRange ? 1 : 0), SFE_AUTORANGE_BITS));
			entries.Add(BuildEntry(ADD_PARAMETER, verSensId, SFE_VERSENSID_BITS));
			
			bb = BuildCommand(CMD_SET_SFE_PARAMS, entries);			
			/* No handle strip, handle is the only response content. */
			xch = BuildDefault(bb, 0, false, true);
			
			resp = hApi.CustomExchangeSingulated(password, secured, NurApi.BANK_EPC, 32, epc.Length * 8, epc, xch);

			respLen = resp.tagBytes.Length;

			if (resp.error != NurApiErrors.NUR_NO_ERROR)
			{
				if (respLen >= MIN_ERROR_RESP_LENGTH)
					InterpretedException("Set SFE parameters", resp);
				DoException("Set SFE parameters", resp);
			}
		}

		/// <summary>
		/// Set specific SFE (Sensor Front End) parameters.
		/// </summary>
		/// <param name="ext1Range">External sensor 1 range.</param>
		/// <param name="ext2Range">External sensor 2 range.</param>
		/// <param name="verSensID">Verify sensor ID (0...3).</param>
		/// <param name="disAutoRange">Disable automatic range.</param>
		/// <param name="ext2HighImp">If true then the sensor 2 is considered as high impedance input otherwise linear conductive.</param>
		/// <param name="ext1Type">Value is 0...3.</param>
		/// <exception cref="ApplicationException">Thrown when tag responded with an error or the tag's response length was invalid.</exception>
		/// <exception cref="NurApiException">Exception is thrown when communication error occured with the tag or module.</exception>
		/// <remarks>
		/// <list type="table"><listheader><term>Parameter <paramref name="ext1Type"/></term><description>External sensor 1 type is</description></listheader>
		/// <item><term>1</term><description>Linear resistive</description></item>
		/// <item><term>2</term><description>High impedance input, voltage follower, bridge</description></item> 
		/// <item><term>3</term><description>Reserved</description></item>
		/// <item><term>4</term><description>capacitive or resistive sensor without DC (AC signal on EXC1)</description></item>
		/// </list>
		/// <list type="table"><listheader><term>Parameter <paramref name="ext2HighImp"/></term><description>External sensor 2 type is</description></listheader>
		/// <item><term>true</term><description>High impedance input, voltage follower, bridge</description></item>
		/// <item><term>false</term><description>Linear conductive sensor</description></item>
		/// </list>
		/// </remarks>
		public void SetSFEParameters(uint ext1Range, uint ext2Range, uint verSensID, bool disAutoRange, bool ext2HighImp, uint ext1Type)
		{
			SFEExchange(0, false, ext2Range, ext1Range, ext1Type, ext2HighImp, disAutoRange, verSensID);
		}

		/// <summary>
		/// SFE (Sensor Front End) attribute.
		/// </summary>
		/// <exception cref="NurApiException">Thrown when communication error with module or tag.</exception>
		/// <exception cref="ApplicationException">Thrown when tag responded with an error or the tag's response length was invalid.</exception>
		/// <exception cref="NurApiException">Exception is thrown when communication error occured with the tag or module.</exception>
		public SFESetup SFE
		{
			set
			{
				SFEExchange(0, false, value.ext2Range, value.ext1Range, value.ext1Type, value.ext2HighImp, value.disAutoRange, value.verSensID);
			}
			/* get { } */
		}
	}
}
