using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NurApiDotNet;
using SL900A;

namespace SL900ATest
{
	public partial class MainForm : Form
	{
		private const int IND_LEVEL_OK = 0;
		private const int IND_LEVEL_INACT = 1;
		private const int IND_LEVEL_FAIL = 2;
		private const int IND_LEVEL_N_A = 3;

		private void PopulateTxLevel()
		{
			double power;
			double value;
			int index = 0;

			for (double i = 0; i <= 19; i++, index++)
			{
				if (index == 0)
					TxLevelSel.Items.Add("0: 500mW");
				else
				{
					power = (27 - i) / 10;
					value = Math.Round(Math.Pow(10, power));
					TxLevelSel.Items.Add(index + ": " + value.ToString() + "mW");
				}
			}

			TxLevelSel.SelectedIndex = 0;
		}

		private void SetupToControls()
		{
			// TX
			TxLevelSel.SelectedIndex = mSetup.txLevel;
			ModulationSel.SelectedIndex = mSetup.txModulation;
			
			// RX
			LFSel.SelectedIndex = LfToIndex(mSetup.linkFreq);
			MillerSel.SelectedIndex = mSetup.rxDecoding;

			// Other
			QEdit.Text = mSetup.inventoryQ.ToString();
			SessionSel.SelectedIndex = mSetup.inventorySession;
			TargetSel.SelectedIndex = mSetup.inventoryTarget;

		}

		private bool ParseInt(ref int result, string txt, int min, int max)
		{
			int val = min-1;
			try
			{
				val = System.Convert.ToInt32(txt);
				result = val;
			}
			catch { return false; }

			return (val >= min && val <= max);

		}

		private bool ControlsToSetup(ref NurApi.ModuleSetup setup, ref int setupFlags)
		{
			int flags = 0;

			if (!ParseInt(ref setup.inventoryQ, QEdit.Text, 0, 15))
			{
				AddLog("Q parameter parse error.");
				return false;
			}

			// TX
			setup.txLevel = TxLevelSel.SelectedIndex;
			flags |= NurApi.SETUP_TXLEVEL;
			setup.txModulation = ModulationSel.SelectedIndex;
			flags |= NurApi.SETUP_TXMOD;

			// RX
			setup.linkFreq = IndexToLf(LFSel.SelectedIndex);
			flags |= NurApi.SETUP_LINKFREQ;
			setup.rxDecoding = MillerSel.SelectedIndex;
			flags |= NurApi.SETUP_RXDEC;

			// Other			
			setup.inventorySession = SessionSel.SelectedIndex;
			flags |= NurApi.SETUP_INVSESSION;
			setup.inventoryTarget = TargetSel.SelectedIndex;
			flags |= NurApi.SETUP_INVTARGET;

			setupFlags = flags;
			return true;
		}

		private int LfToIndex(int lf)
		{
			switch (lf)
			{
				case 160000: return 0;
				case 256000: return 1;
				case 320000: return 2;
				default: break;
			}

			throw new ApplicationException("LfToIndex: invalid link frequency " + lf + ".");
		}

		private int IndexToLf(int index)
		{
			switch (index)
			{
				case 0: return 160000;
				case 1: return 256000;
				case 2: return 320000;
				default: break;
			}

			throw new ApplicationException("IndexToLf: invalid index " + index + ".");
		}

		private string ConversionToString(uint sensor, uint adValue)
		{
			string s = "";
			switch (sensor)
			{
				case SL900ATag.TEMP_SENS_TYPE:
					// Note: default values are used here (in mV).
					s = string.Format("TEMP: {0:#0.00} C ", SL900ATag.TemperatureConversion(0.0, 310.0, adValue));
				break;
			}

			s += "0x" + adValue.ToString("X4") + " (" + adValue + ")";
			return s;
		}

		private bool BuildInitData(ref SL900ATag.InitData iData)
		{
			int appWords, delayTime, brokenWord;
			int maxAppwords = (1 << 9) - 1;
			int maxDelayTime = (1 << 12) - 1;
			int maxBrokenWord = ((1 << 3) - 1);
			
			appWords = -1;
			delayTime = -1;
			brokenWord = -1;

			if (!ParseInt(ref appWords, WordCountEdit.Text, 1, maxAppwords) ||
				!ParseInt(ref delayTime, DelayTimeEdit.Text, 0, maxDelayTime) ||
				!ParseInt(ref brokenWord, BrokenWordEdit.Text, 0, maxBrokenWord))
			{
				AddLog("Init data error(s).");
				AddLog("Application data words' range is 1..." + maxAppwords + ", value = " + appWords + ".");
				AddLog("Delay time range is 0..." + maxDelayTime + ", value = " + maxDelayTime + ".");
				AddLog("Broken word ptr range is 0..." + maxBrokenWord + ", value = " + maxBrokenWord + ".");
				return false;
			}

			
			iData.appWordCount = (uint)appWords;
			iData.brokenWordPtr = (uint)brokenWord;
            iData.delayTime = (uint)delayTime;
			iData.dmExtSwitch = (DelayModeSel.SelectedIndex == 1);
			iData.enIrqTimer = IrqTimerChk.Checked;

			return true;
		}

		private void CopyLog()
		{
			
			if (LogList.Items.Count > 0)
			{
				string copied = "";
				int row = 0;
				for (row = 0; row < LogList.Items.Count; row++)
					copied += (LogList.Items[row].SubItems[1].Text + "\n");
				
				Clipboard.SetText(copied);
				InfoLog("Log copied to clipboard.");
			}
		}

		private int FormToIndex(SL900ATag.LoggingForm form)
		{
			switch (form)
			{
				case SL900ATag.LoggingForm.AllOut: return 1;
				case SL900ATag.LoggingForm.Crossing: return 2;
				case SL900ATag.LoggingForm.IRQ1: return 3;
				case SL900ATag.LoggingForm.IRQ2: return 4;
				case SL900ATag.LoggingForm.BothIRQs: return 5;
				default: break;
			}

			// case SL900ATag.LoggingForm.Dense
			return 0;
		}

		private SL900ATag.LoggingForm IndexToForm(int index)
		{
			switch (index)
			{
				case 1: return SL900ATag.LoggingForm.AllOut;
				case 2: return SL900ATag.LoggingForm.Crossing;
				case 3: return SL900ATag.LoggingForm.IRQ1;
				case 4: return SL900ATag.LoggingForm.IRQ2;
				case 5: return SL900ATag.LoggingForm.BothIRQs;
				default: break;
			}

			//case 0:
			return SL900ATag.LoggingForm.Dense;
		}

		private void SetIndicator(Label lbl, string text, int level)
		{
			Color theColor;

			if (level == IND_LEVEL_OK)
				theColor = Color.Green;
			else if (level == IND_LEVEL_FAIL)
				theColor = Color.Red;
			else if (level == IND_LEVEL_INACT)
				theColor = Color.Yellow;	// No error but inactive.
			else
				theColor = SystemColors.Control;

			lbl.BackColor = theColor;
			lbl.Text = text;
		}

		private void SetNAIndicator(Label lbl)
		{
			SetIndicator(lbl, "N/A", IND_LEVEL_N_A);
		}

		private void SetErrorIndicator(Label lbl)
		{
			SetIndicator(lbl, "ERROR", IND_LEVEL_FAIL);
		}

		private void SetOKIndicator(Label lbl)
		{
			SetIndicator(lbl, "OK", IND_LEVEL_OK);
		}

		private void SetInactIndicator(Label lbl)
		{
			SetIndicator(lbl, "---", IND_LEVEL_INACT);
		}
	}
}
