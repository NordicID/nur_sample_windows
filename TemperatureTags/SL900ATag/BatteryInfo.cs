using System;
using System.Collections.Generic;
using System.Text;

using NurApiDotNet;

namespace SL900A
{
	public partial class SL900ATag : NurApi.Tag
	{
		private const byte CMD_GET_BATTLEVEL = 0xAA;
		/* Successful response length in bytes including handle length. */
		private const ushort BATTINFO_OK_BYTE_LEN = 4;
		private const int BL_RETRIGGER_LEN = 8;
		private const int BL_ADERR_BIT = 15;
		private const int BL_3VOLT_BIT = 14;
		private const int BL_LEVEL_BITS = 10;
		private const uint BL_LEVEL_MASKVAL = (1 << BL_LEVEL_BITS) - 1;

		/// <summary>
		/// Battery level / information structure.
		/// </summary>
		public struct BatteryInfo
		{
			/// <summary>
			/// If this is set to false then the battery query responded with an error 
			/// stating that the bvattery is not present.
			/// </summary>
			public bool present;
			/// <summary>
			/// A/D conversion error / not.
			/// </summary>
			public bool adError;
			/// <summary>
			/// If true then the battery is 3V, otherwise 1.5V.
			/// </summary>
			public bool is3V;
			/// <summary>
			/// 10-bit value for the battery level.
			/// </summary>
			public uint level;
		}

		private BatteryInfo BatteryInformationExchange(uint password, bool secured, bool reTrigger)
		{
			List<BitEntry> entries = new List<BitEntry>();

			BatteryInfo bi = new BatteryInfo();
			BitBuffer bb;
			NurApi.CustomExchangeParams xch;
			NurApi.CustomExchangeResponse resp;
			int respLen;
			uint tmpVal;

			entries.Add(BuildEntry(ADD_PARAMETER, (uint)(reTrigger ? 1 : 0), BL_RETRIGGER_LEN));

			/* Build the command. */
			bb = BuildCommand(CMD_GET_BATTLEVEL, entries);

			/* 
			 * No response length as the battery may not be in place
			 *  -> error respones.
			 */
			xch = BuildDefault(bb, 0, false, false);

			resp = hApi.CustomExchangeSingulated(password, secured, NurApi.BANK_EPC, 32, epc.Length * 8, epc, xch);
			respLen = resp.tagBytes.Length;

			if (resp.error != NurApiErrors.NUR_NO_ERROR || respLen != BATTINFO_OK_BYTE_LEN)
			{
				if (respLen == MIN_ERROR_RESP_LENGTH && resp.tagBytes[0] == ERR_BATTERY)
				{
					hApi.ULog("BattInfo: battery not in place.");
					bi.level = 0;
					bi.adError = true;
					bi.is3V = false;
					bi.present = false;
					return bi;
				}

				hApi.ULog("BattInfoError, len = " + respLen + ".");
				if (respLen >= MIN_ERROR_RESP_LENGTH)
					InterpretedException("Battery info", resp);
				DoException("Battery info", resp);
			}

			bi.present = true;

			hApi.ULog("BattInfo: no error.");

			/* 16 bits */
			tmpVal = resp.tagBytes[0];
			tmpVal <<= 8;
			tmpVal |= resp.tagBytes[1];

			bi.adError = IsMaskBitSet(tmpVal, BL_ADERR_BIT);
			bi.is3V = IsMaskBitSet(tmpVal, BL_3VOLT_BIT);
			bi.level = (tmpVal & BL_LEVEL_MASKVAL);

			return bi;
		}
		
        /// <summary>
        /// The battery information, <see cref="BatteryInfo"/>.
        /// </summary>
        /// <exception cref="NurApiException">Thrown when communication error with module or tag error.</exception>
        public BatteryInfo Battery
		{
			get
            {
                return BatteryInformationExchange(0, false, true);
            }
		}
		
		/// <summary>
		/// Return the 10-bit value for battery level as specified by the SL900A specification.
		/// </summary>
		/// <exception cref="ApplicationException">Throw this exception when A/D error is detected, invalid response or the battery is not in place.</exception>
		/// <exception cref="NurApiException">Thrown when communication error with module or tag error.</exception>
		public uint BatteryLevel
		{
			get 
			{
				BatteryInfo bi = BatteryInformationExchange(0, false, true);
				if (bi.adError)
					throw new ApplicationException("SL900ATag.BatteryLevel: A/D conversion error!");
				return bi.level;
			}
		}

		/// <summary>
		/// Return battery voltage value if battery is present.
		/// </summary>
		/// <remarks>
		/// If the return value is -1.0 then it means that no battery was detected.
		/// If the return value is -2.0 then it means that there was an A/D conversion error.
		/// </remarks>
		/// <exception cref="ApplicationException">Exception is thrown upon unexpected communication error(s).</exception>
		public double BattVoltage
		{
			get
			{
				BatteryInfo bi = BatteryInformationExchange(0, false, true);
				double offset, voltage, proportion;

				if (bi.present && !bi.adError)
				{
					proportion = (double)bi.level;
					proportion /= (double)BL_LEVEL_MASKVAL;

					if (bi.is3V)
					{
						voltage = 1.65;
						offset = 1.69;
					}
					else
					{
						voltage = 0.85;
						offset = 0.873;
					}

					voltage *= proportion;
					voltage += offset;

					return voltage;
				}
				else if (!bi.present)
					return -1.0;		// Means "no battery."
				else if (bi.adError)
					return -2.0;	// Means A/D error.

				throw new ApplicationException("BattVoltage: unknown error.");
			}
		}

		/// <summary>
		/// Get the voltage conversion from the read battery information.
		/// </summary>
		/// <param name="battInfo">Recently read battery information, <see cref="BatteryInfo"/>.</param>
		/// <returns>Interpreted voltage value.</returns>
		/// <remarks>
		/// If the return value is -1.0 then it means that no battery was detected.
		/// If the return value is -2.0 then it means that there was an A/D conversion error.
		/// </remarks>
		public static double VoltageConversion(BatteryInfo battInfo)
		{
			if (battInfo.present && !battInfo.adError)
			{
				double offset, voltage, proportion;

				proportion = (double)battInfo.level;
				proportion /= (double)BL_LEVEL_MASKVAL;

				if (battInfo.is3V)
				{
					voltage = 1.65;
					offset = 1.69;
				}
				else
				{
					voltage = 0.85;
					offset = 0.873;
				}

				voltage *= proportion;
				voltage += offset;

				return voltage;
			}

			if (!battInfo.present)
				return -1.0;		// Means "no battery."
			
			return -2.0;		// Means A/D error.			
		}		
	}
}
