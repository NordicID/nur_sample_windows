using System;
using System.Collections.Generic;
using System.Text;

using NurApiDotNet;

namespace EM4325
{
	public partial class EM4325Tag : NurApi.Tag
	{
		// Handle only.
		private const ushort RESET_ALARMS_RESPBITS = 16;
		
		/// <summary>
		/// ResetAlarms commands' implementation.
		/// </summary>
		/// <returns>Returns true if tag indicated a successful alarm reset, false otherwise.</returns>
		/// <exception cref="NurApiException">Exception is thrown with module or tag communication error.</exception>
		/// <remarks>
		/// Does not throw exception when tag replies with an error. 
		/// Use the API's logging event to capture more information.
		/// </remarks>
		public bool ResetAlarms()
		{
			NurApi.CustomExchangeParams xch;
			NurApi.CustomExchangeResponse resp;
			int respLen;
			int txLen = 0;

			xch = BuildDefault(RESET_ALARMS_RESPBITS, DO_AS_WRITE, NO_HANDLE_STRIP);
			txLen = NurApi.BitBufferAddValue(xch.bitBuffer, CMD_RESET_ALARMS, PROPRIETARY_BITS, txLen);
			// 4 bit fill.
			txLen = NurApi.BitBufferAddValue(xch.bitBuffer, 5, 4, txLen);

			xch.txLen = (ushort)txLen;
			xch.rxTimeout = mWriteTimeout;

			ResetToA();
			try
			{
				hNur.ULog("ResetAlarms: " + GetEpcString() + ".");
				
				resp = hNur.CustomExchangeByEPC(mPassword, mSecured, mEPC, xch);
				respLen = resp.tagBytes.Length;
				if (resp.error == NurApiErrors.NUR_NO_ERROR && respLen == 2)
					return true;

				hNur.ULog("ResetAlarms error: " + resp.error + ", response length = " + respLen + ".");
			}
			catch (NurApiException ex)
			{
				hNur.ULog("Could not reset alarms. Error = " + ex.error);
				hNur.ULog("ResetAlarms message: " + ex.Message);
			}

			return false;
		}

		private bool ResetAlarmsIsEnabled()
		{
			byte[] wData;
			ResetToA();
			wData = ReadTag(mPassword, mSecured, NurApi.BANK_USER, ADDR_CTLWORD_1, 2);

			return BitToBool(wData[0], CTLW1HI_RESET_EN_BIT);
		}

		/// <summary>
		/// Get whether this tag can reset alarms or not.
		/// </summary>
		public bool CanResetAlarms
		{
			get { return ResetAlarmsIsEnabled(); }
		}
	}
}
