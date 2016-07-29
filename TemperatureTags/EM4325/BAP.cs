using System;
using System.Collections.Generic;
using System.Text;

using NurApiDotNet;

namespace EM4325
{
	public partial class EM4325Tag : NurApi.Tag
	{
		/// <summary>
		/// Set BAP on/off.
		/// </summary>
		/// <param name="on">Set on if true.</param>
		public void SetBAP(bool on)
		{
			byte []wrData = new byte[2] { 0, 0 };
			if (on)
				wrData[1] = 1;
			ResetToA();
			WriteTag(mPassword, mSecured, NurApi.BANK_USER, ADDR_BAP_MODE, wrData);
		}

		/// <summary>
		/// Return current state of the BAP enable.
		/// </summary>
		/// <returns>True if the BAP omde is enabled.</returns>
		public bool GetBAP()
		{
			byte[] rdBytes;

			ResetToA();
			rdBytes = ReadTag(mPassword, mSecured, NurApi.BANK_USER, ADDR_BAP_MODE, 2);
			return ((rdBytes[1] & 1) != 0);
		}

		private byte[] GetBattWord(bool w2)
		{
			uint address = w2 ? ADDR_BATT_MGMT_WORD_2 : ADDR_BATT_MGMT_WORD_1;

			ResetToA();
			return ReadTag(mPassword, mSecured, NurApi.BANK_USER, address, 2);
		}

		private void EnableBAPControl()
		{
			byte[] battWord2;
			battWord2 = GetBattWord(true);

			// Byte 1, bit 0.
			if ((battWord2[1] & 1) == 0)
			{
				hNur.ULog("Setting BAP control bit to '1'.");
				battWord2[1] |= 1;
				ResetToA();
				WriteTag(mPassword, mSecured, NurApi.BANK_USER, ADDR_BATT_MGMT_WORD_2, battWord2);
				hNur.ULog("EnableBAPControl(): OK.");
			}
			else
				hNur.ULog("EnableBAPCtl: BAP control bit is already '1'.");
		}

		private void DisableBAPControl()
		{
			byte[] battWord2;
			battWord2 = GetBattWord(true);

			// Byte 1, bit 0.
			if ((battWord2[1] & 1) != 0)
			{
				hNur.ULog("Setting BAP control bit to '0'.");
				battWord2[1] &= 0xFE;
				ResetToA();
				WriteTag(mPassword, mSecured, NurApi.BANK_USER, ADDR_BATT_MGMT_WORD_2, battWord2);
				hNur.ULog("DisableBAPControl(): OK.");
			}
			else
				hNur.ULog("DisableBAPCtl: BAP control bit is already '0'.");
		}

		private bool GetBAPControl()
		{
			byte[] battWord2;
			battWord2 = GetBattWord(true);
			return ((battWord2[1] & 1) != 0);
		}

		/// <summary>
		/// Enable/disable BAP mode control or get control enable state.
		/// </summary>
		public bool BAPCtlEnabled
		{
			set
			{
				if (value)
					EnableBAPControl();
				else
					DisableBAPControl();
			}
			get { return GetBAPControl(); }
		}

		/// <summary>
		/// Get BAP mode, set BAP mode on/off.
		/// </summary>
		public bool BAPModeEnabled
		{
			get { return GetBAP(); }
			set { SetBAP(value); }
		}
	}
}
