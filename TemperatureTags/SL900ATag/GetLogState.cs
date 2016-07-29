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
		private const byte CMD_GET_LOGSTATE = 0xA8;
		private const ushort SHELF_LIFE_BYTE_LEN = ((64 + 24) / 8);
		/* Expected "get log state" query's response length when when "shelf life" = '1', in bytes: request with "no RX length". */
		private const ushort LOGSTATE_FULL_BYTE_LEN = (32 + 32 + 64 + 24 + 8) / 8;
		/* Expected "get log state" query's response length when when "shelf life" = '0', in bytes: request with "no RX length". */
		private const ushort LOGSTATE_SHORT_BYTE_LEN = LOGSTATE_FULL_BYTE_LEN - SHELF_LIFE_BYTE_LEN;

		private const int FLG_ACT_LOG_BIT = 7;
		private const int FLG_MEASFULL_BIT = 6;
		private const int FLG_OVRWR_BIT = 5;
		private const int FLG_ADERR_BIT = 4;
		private const int FLG_LOWBATT_BIT = 3;
		private const int FLG_SLLOWERRR_BIT = 2;
		private const int FLG_SLHIGHERRR_BIT = 1;
		private const int FLG_SLEXP_BIT = 0;

		private const int FLAG_SL_EN_BIT = 2;
		private const int FLAG_SL_NEG_EN_BIT = 3;
		private const int SL_SENSID_LSH = 4;
		private const int SL_SENSID_BITS = 2;
		private const uint SL_SENSID_MASKVAL = (1 << SL_SENSID_BITS) - 1;
		private const int SL_INITTEMP_LSH = 6;
		private const int SL_INITTEMP_BITS = 10;
		private const uint SL_INITTEMP_MASKVAL = (1 << SL_INITTEMP_BITS) - 1;
		private const int SL_INITLIFE_LSH = 16;
		private const int SL_INITLIFE_BITS = 16;
		private const uint SL_INITLIFE_MASKVAL = (1 << SL_INITLIFE_BITS) - 1;

		/// <summary>
		/// Structure defining the "get log state" response.
		/// </summary>
		public struct LogStateInfo
		{
			/// <summary>
			/// Extreme low limit counter.
			/// </summary>
			public int eLowCnt;
			/// <summary>
			/// Low limit counter.
			/// </summary>
			public int lowCnt;
			/// <summary>
			/// Upper limit counter.
			/// </summary>
			public int uprCnt;
			/// <summary>
			/// Extreme upper limit counter.
			/// </summary>
			public int eUprCnt;

			/// <summary>
			/// The measurement address pointer.
			/// </summary>
			public int addrPtr;

			/// <summary>
			/// Number of memory replacements.
			/// </summary>
			public int nrOfRepl;

			/// <summary>
			/// Number of measurements.
			/// </summary>
			public int nrOfMeas;

			/// <summary>
			/// System active / not.
			/// </summary>
			public bool sysActive;
			/// <summary>
			/// Active (logging process).
			/// </summary>
			public bool actLogging;
			/// <summary>
			/// Measurement area full.
			/// </summary>
			public bool full;
			/// <summary>
			/// Measurement(s) overwritten.
			/// </summary>
			public bool overWritten;
			/// <summary>
			/// A/D error.
			/// </summary>
			public bool adError;
			/// <summary>
			/// Low battery.
			/// </summary>
			public bool battLow;
			/// <summary>
			/// Shelf life low error.
			/// </summary>
			public bool slLowError;
			/// <summary>
			/// Shelf life high error.
			/// </summary>			
			public bool slHighError;
			/// <summary>
			/// Shelf life expired.
			/// </summary>
			public bool expired;

			/********************* SHELF LIFE PART *******************/
			/// <summary>
			/// Tells whether the shelf life related fields are valid or not.
			/// </summary>
			public bool hasShelfLife;

			/// <summary>
			/// Shelf Life Parameters.
			/// <see cref="ShelfLifeParam"/>
			/// </summary>
			public ShelfLifeParam shelfLife;
		}

        /* Get the curent log state from the tag. */
		private LogStateInfo LogStateExchange(uint password, bool secured)
		{
			BitBuffer bb;
			NurApi.CustomExchangeParams xch;
			NurApi.CustomExchangeResponse resp;
			int respLen, bytePtr;
			byte flags;

			LogStateInfo ls = new LogStateInfo();

			/* Build the command. */
			bb = BuildCommand(CMD_GET_LOGSTATE, null);

			/* No expected length because shelf life is unknown; handle not needed here. */
			xch = BuildDefault(bb, 0, true, false);

			resp = hApi.CustomExchangeSingulated(password, secured, NurApi.BANK_EPC, 32, epc.Length * 8, epc, xch);
			respLen = resp.tagBytes.Length;

			if (resp.error != NurApiErrors.NUR_NO_ERROR)
			{
				if (respLen >= MIN_ERROR_RESP_LENGTH)
					InterpretedException("Get log state", resp);
				DoException("Get log state", resp);
			}

			/* If the response is full, then the shelf life blocks and current shelf life are present. */
			ls.hasShelfLife = (respLen >= LOGSTATE_FULL_BYTE_LEN);
			
			/* Big-endian bytes for crossings. */
			bytePtr = 0;
			ls.eLowCnt = resp.tagBytes[bytePtr++];
			ls.lowCnt = resp.tagBytes[bytePtr++];
			ls.uprCnt = resp.tagBytes[bytePtr++];
			ls.eUprCnt = resp.tagBytes[bytePtr++];

			/* TODO: convert to uint -> get by masks. It is the "System Status" field, 32 bits.  */
			/* Measurement address pointer. */
			ls.addrPtr = (int)GetBitsBigEndian(resp.tagBytes, BytesToBits(bytePtr), 10);

			/* Number of memory replacements. */
			ls.nrOfRepl  = (int)GetBitsBigEndian(resp.tagBytes, BytesToBits(bytePtr) + 10, 6);

			/* Number of measurements. */
			ls.nrOfMeas = (int)GetBitsBigEndian(resp.tagBytes, BytesToBits(bytePtr) + 16, 15);
			
			/* Active? */
			ls.sysActive = GetBit(resp.tagBytes, BytesToBits(bytePtr) + 15)==1;

			bytePtr += 4;
			
			if (ls.hasShelfLife)
			{
				uint tmpVal;

				/* 64 bits for Shelf life block 0 & 1 + 24 bits for current shelf life = 8 + 3 = 11 bytes. */

				/* Shelf life block 0: */
				ls.shelfLife.actEnergy = resp.tagBytes[bytePtr++];
				ls.shelfLife.normTemp = resp.tagBytes[bytePtr++];
				ls.shelfLife.minTemp = resp.tagBytes[bytePtr++];
				ls.shelfLife.maxTemp = resp.tagBytes[bytePtr++];

				/* Shelf life block 1: */
				tmpVal = GetBigEndian32FromBytes(resp.tagBytes, bytePtr);
				bytePtr += 4;

				ls.shelfLife.slAlgEn = IsMaskBitSet(tmpVal, FLAG_SL_EN_BIT);
				ls.shelfLife.negSlEn = IsMaskBitSet(tmpVal, FLAG_SL_NEG_EN_BIT);

				ls.shelfLife.slSensId = ((tmpVal >> SL_SENSID_LSH) & SL_SENSID_MASKVAL);
				ls.shelfLife.initTemp = ((tmpVal >> SL_INITTEMP_LSH) & SL_INITTEMP_MASKVAL);

				ls.shelfLife.initLife = ((tmpVal >> SL_INITLIFE_LSH) & SL_INITLIFE_MASKVAL); ;
				
				/* Big-endian 24-bit value. */
				ls.shelfLife.curShelfLife = resp.tagBytes[bytePtr++];
				ls.shelfLife.curShelfLife <<= 8;
				ls.shelfLife.curShelfLife |= resp.tagBytes[bytePtr++];
				ls.shelfLife.curShelfLife <<= 8;
				ls.shelfLife.curShelfLife |= resp.tagBytes[bytePtr++];				
			}


			flags = resp.tagBytes[bytePtr];
			ls.actLogging = IsMaskBitSet(flags, FLG_ACT_LOG_BIT);
			ls.full = IsMaskBitSet(flags, FLG_MEASFULL_BIT);
			ls.overWritten = IsMaskBitSet(flags, FLG_OVRWR_BIT);
			ls.adError = IsMaskBitSet(flags, FLG_ADERR_BIT);
			ls.battLow = IsMaskBitSet(flags, FLG_LOWBATT_BIT);
			ls.slLowError = IsMaskBitSet(flags, FLG_SLLOWERRR_BIT);
			ls.slHighError = IsMaskBitSet(flags, FLG_SLHIGHERRR_BIT);
			ls.expired = IsMaskBitSet(flags, FLG_SLEXP_BIT);

			return ls;
		}

		/// <summary>
		/// Get current log state information from the tag. 
		/// </summary>
		/// <exception cref="ApplicationException">Thrown when tag responded with an error or the tag's response length was invalid.</exception>
		/// <exception cref="NurApiException">Exception is thrown when communication error occured with the tag or module.</exception>
        public LogStateInfo LogState
		{			
            get
            {
                return LogStateExchange(0, false);
            }
		}
	}
}
