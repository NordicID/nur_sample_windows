using System;
using System.Collections.Generic;
using System.Text;

using NurApiDotNet;

namespace SL900A
{
	public partial class SL900ATag : NurApi.Tag
	{
		private const byte CMD_SET_SHELFLIFE = 0xAB;
		private const int SL_BLOCK0_VALUELEN = 32;	/* Bits. */
		private const int SL_BLOCK1_VALUELEN = 32;	/* Bits. */
		private const ushort SHELF_LIFE_RESPLEN = 16;	/* Handle only. */

		private void ShelfLifeExchange(uint password, bool secured, uint block1, uint block2)
		{
			BitBuffer bb;
			NurApi.CustomExchangeParams xch;
			List<BitEntry> entries = new List<BitEntry>();
			NurApi.CustomExchangeResponse resp;
			int respLen;

			/* Values composed as defined by the SL900A specification. */
			entries.Add(BuildEntry(ADD_PARAMETER, block1, SL_BLOCK0_VALUELEN));
			entries.Add(BuildEntry(ADD_PARAMETER, block2, SL_BLOCK1_VALUELEN));

			bb = BuildCommand(CMD_SET_SHELFLIFE, entries);
			xch = BuildDefault(bb, 0, false, false);

			resp = hApi.CustomExchangeSingulated(password, secured, NurApi.BANK_EPC, 32, epc.Length * 8, epc, xch);

			respLen = resp.tagBytes.Length;

			if (resp.error != NurApiErrors.NUR_NO_ERROR)
			{
				if (respLen >= MIN_ERROR_RESP_LENGTH)
					InterpretedException("Set shelf life", resp);
				DoException("Set shelf life", resp);
			}
		}

		/// <summary>
		/// Structure represeting the shelf life parameters.
		/// </summary>
		public struct ShelfLifeParam
		{
			/* Shelf life block 0: */
			/// <summary>
			/// Activation energy.
			/// </summary>
			public uint actEnergy;
			/// <summary>
			/// Normal temperature.
			/// </summary>
			public uint normTemp;
			/// <summary>
			/// Minimum temperature for product.
			/// </summary>
			public uint minTemp;
			/// <summary>
			/// Maximum temperature for product.
			/// </summary>
			public uint maxTemp;

			/* Shelf life block 1: */
			/// <summary>
			/// Shelf life algorithm enabled / not.
			/// </summary>
			public bool slAlgEn;

			/// <summary>
			/// Negative shelf life enabled / not.
			/// </summary>
			public bool negSlEn;

			/// <summary>
			/// Shelf life sensor ID.
			/// </summary>
			public uint slSensId;

			/// <summary>
			/// Initial temperature for the shelf life.
			/// </summary>
			public uint initTemp;

			/// <summary>
			/// Initial shelf life value.
			/// </summary>
			public uint initLife;

			/// <summary>
			/// 24-bit value for the current shelf life.
			/// </summary>
			public uint curShelfLife;
		}

		/// <summary>
		/// Compose two 32-bit unsigned integer parameters from the shelf life specification.
		/// </summary>
		/// <param name="slp">The shelf life parameters, <see cref="ShelfLifeParam"/>.</param>.
		/// <returns>An 32-bit unsigned integer array representing the tag required air parameters.</returns>
		/// <exception cref="ApplicationException">Thrown when tag responded with an error or the tag's response length was invalid.</exception>
		/// <exception cref="NurApiException">Exception is thrown when communication error occured with the tag or module.</exception>
		public uint []ComposeShelfLifeParams(ShelfLifeParam slp)
		{
			uint []ret = new uint[] { 0, 0 };
			uint tmp;
			tmp = slp.maxTemp & 0xFF;
			tmp <<= 8;
			tmp |= slp.minTemp & 0xFF;
			tmp <<= 8;
			tmp |= slp.normTemp & 0xFF;
			tmp <<= 8;
			tmp |= slp.actEnergy & 0xFF;
			
			ret[0] = tmp;

			tmp = slp.initLife & SL_INITLIFE_MASKVAL;
			tmp <<= SL_INITTEMP_BITS;

			tmp |= (slp.initTemp & SL_INITTEMP_MASKVAL);
			tmp <<= SL_SENSID_LSH;

			tmp |= (slp.slSensId & SL_SENSID_MASKVAL);
			
			/* One-bit params. */
			tmp <<= 1;
			tmp |= (uint)(slp.negSlEn ? 1 : 0);
			tmp <<= 1;
			tmp |= (uint)(slp.slAlgEn ? 1 : 0);
			tmp <<= 2;	// RFU bits

			ret[1] = tmp;

			return ret;
		}

		/// <summary>
		/// Get the shelf life paraeter from the log state information.
		/// Used in getting the <see cref="ShelfLife"/>.
		/// </summary>
		/// <param name="lsi">The log state information from the tag.</param>
		/// <returns>Extracted shelf life parameter, <see cref="ShelfLifeParam"/>.</returns>
		/// <exception cref="ApplicationException">Exception thrown when the log state does not contain the shelf life information.</exception>
		public ShelfLifeParam ExtractShelfLifeResp(LogStateInfo lsi)
		{
			if (!lsi.hasShelfLife)
				throw new ApplicationException("ExtractShelfLifeReponse: no shelf life present.");

			ShelfLifeParam slp = new ShelfLifeParam();
			
			slp.actEnergy = lsi.shelfLife.actEnergy;
			slp.curShelfLife = lsi.shelfLife.curShelfLife;
			slp.initLife = lsi.shelfLife.initLife;
			slp.initTemp = lsi.shelfLife.initTemp;
			slp.maxTemp = lsi.shelfLife.maxTemp;
			slp.minTemp = lsi.shelfLife.minTemp;
			slp.negSlEn = lsi.shelfLife.negSlEn;
			slp.normTemp = lsi.shelfLife.normTemp;
			slp.slAlgEn = lsi.shelfLife.slAlgEn;
			slp.slSensId = lsi.shelfLife.slSensId;

			return slp;
		}
		
		/// <summary>
		/// The ShelfLife attribute.
		/// </summary>
		/// <exception cref="ApplicationException">Thrown when tag responded with an error or the tag's response length was invalid.</exception>
		/// <exception cref="NurApiException">Exception is thrown when communication error occured with the tag or module.</exception>
		public ShelfLifeParam ShelfLife
		{
			set
			{
				uint[] blocks = ComposeShelfLifeParams(value);
				ShelfLifeExchange(0, false, blocks[0], blocks[1]);
			}
			get
			{
				return ExtractShelfLifeResp(LogState);
			}
		}
	}
}
