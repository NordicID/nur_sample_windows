using System;
using System.Collections.Generic;
using System.Text;

using NurApiDotNet;

namespace EM4325
{
	public partial class EM4325Tag : NurApi.Tag
	{
		private string CheckConfiguration(CustomConfig cfg)
		{
			string ret = "";

			if (cfg.delayValue == 0 || cfg.intvalValue == 0)
				ret += "- delay or interval error\n";

			if (cfg.underTemp < EM4325Tag.MIN_TEMP_THRESH || 
				cfg.underTemp > EM4325Tag.MAX_TEMP_THRESH || 
				cfg.overTemp < EM4325Tag.MIN_TEMP_THRESH || 
				cfg.overTemp > EM4325Tag.MAX_TEMP_THRESH)
				ret += "- temperature error(s)\n";

			if (cfg.underTemp > cfg.overTemp)
				ret += "- invalid order\n";

			return ret;
		}

		private const float MULCONST = 4.0F;

		ushort[] CustomConfigWords(CustomConfig cfg, bool timeStamp, bool enReset)
		{
			ushort []words = new ushort[3];
			short sTmp;
			ushort uTmp;

			sTmp = (short)(cfg.underTemp * MULCONST);
			hNur.ULog(".underTemp = " + cfg.underTemp.ToString("F2") + ", xMULCONST = " + (cfg.underTemp * MULCONST).ToString("F2") + ", short = " + sTmp + ", 0x" + (sTmp & ((1 << 9) - 1)).ToString("X4") + ".");
			sTmp &= ((1 << 9) - 1);
			uTmp = (ushort)(cfg.nrUnderTemp & ((1 << 5) - 1));
			uTmp <<= 9;
			uTmp |= (ushort)sTmp;
			if (enReset)
				uTmp |= (1 << 14);
			
			words[0] = uTmp;

			sTmp = (short)(cfg.overTemp * MULCONST);
			hNur.ULog(".overTemp = " + cfg.overTemp.ToString("F2") + ", xMULCONST = " + (cfg.overTemp * MULCONST).ToString("F2") + ", short = " + sTmp + ", 0x" + (sTmp & ((1 << 9) - 1)).ToString("X4") + ".");
			sTmp &= ((1 << 9) - 1);
			uTmp = (ushort)(cfg.nrOverTemp & ((1 << 5) - 1));
			uTmp <<= 9;
			uTmp |= (ushort)sTmp;
			if (timeStamp)
				uTmp |= (1 << 14);

			words[1] = uTmp;

			hNur.ULog("Delay settings: units = " + cfg.delayUnits + ", value = " + cfg.delayValue + ".");
			hNur.ULog("Interval settings: units = " + cfg.intvalUnits + ", value = " + cfg.intvalValue + ".");

			uTmp = (ushort)(cfg.delayUnits & ((1 << 2) - 1));
			uTmp <<= 6;
			uTmp |= (ushort)(cfg.delayValue & ((1 << 6) - 1));
			uTmp <<= 2;
			uTmp |= (ushort)(cfg.intvalUnits & ((1 << 2) - 1));
			uTmp <<= 6;
			uTmp |= (ushort)(cfg.intvalValue & ((1 << 6) - 1));

			words[2] = uTmp;

			return words;
		}

		public void StartCustom(CustomConfig cfg, bool timeStamp, bool enReset, bool block)
		{
			string eMsg = "";
			byte[] wrData = new byte[6];

			eMsg = CheckConfiguration(cfg);

			if (eMsg != "")
				throw new ApplicationException("StartCustom() error + \n" + eMsg);

			ushort []ctlWords;

			ctlWords = CustomConfigWords(cfg, timeStamp, enReset);

			wrData[0] = (byte)(ctlWords[0] >> 8);
			wrData[1] = (byte)(ctlWords[0] & 0xFF);
			wrData[2] = (byte)(ctlWords[1] >> 8);
			wrData[3] = (byte)(ctlWords[1] & 0xFF);
			wrData[4] = (byte)(ctlWords[2] >> 8);
			wrData[5] = (byte)(ctlWords[2] & 0xFF);

			if (block)
			{
				if (mSecured)
					BlockWrite(mPassword, NurApi.BANK_USER, ADDR_CTLWORD_1, wrData, 3);
				else
					BlockWrite(NurApi.BANK_USER, ADDR_CTLWORD_1, wrData, 3);
			}
			else
			{
				ResetToA();
				WriteTag(mPassword, mSecured, NurApi.BANK_USER, ADDR_CTLWORD_1, wrData);
			}
		}
	}
}
