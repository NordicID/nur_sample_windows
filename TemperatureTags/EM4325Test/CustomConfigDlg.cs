using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NurApiDotNet;
using EM4325;

namespace EM4325Test
{
	public partial class CustomConfigDlg : Form
	{
		private bool okConfig = false;
		private EM4325Tag.CustomConfig theConfig;

		private const int MIN_TEMP_COUNT = 1;
		private const int MAX_TEMP_COUNT = 31;
		private const int MIN_TIME_UNITS = 1;
		private const int MAX_TIME_UNITS = 63;
		private const float MIN_TEMPERATURE = -64.0F;
		private const float MAX_TEMPERATURE = 63.75F;

		public CustomConfigDlg(EM4325Tag.CustomConfig curCfg)
		{
			InitializeComponent();
			theConfig = curCfg;
			PopulateControls(curCfg);
			CheckSetup(false);
		}

		public EM4325Tag.CustomConfig Config
		{
			get
			{

				if (okConfig)
					return theConfig;

				throw new ApplicationException("SimpleConfigDlg.GetConfig(): configuration is not valid.");
			}
			set
			{
				theConfig = value;
			}
		}

		public bool TimeStampRequired
		{
			get { return StampChk.Checked; }
			set { StampChk.Checked = value; }
		}

		public bool ResetAlarmsEnabled
		{
			get { return ResetAlarmsChk.Checked; }
			set { ResetAlarmsChk.Checked = value; }
		}

		private void PopulateControls(EM4325Tag.CustomConfig curCfg)
		{
			DelayUnitSel.SelectedIndex = curCfg.delayUnits;
			DelayCountEdit.Text = curCfg.delayValue.ToString();
			IntvalUnitSel.SelectedIndex = curCfg.intvalUnits;
			IntvalCountEdit.Text = curCfg.intvalValue.ToString();
			OverCountEdit.Text = curCfg.nrOverTemp.ToString();
			OverThreshEdit.Text = curCfg.overTemp.ToString("F2");
			UnderCountEdit.Text = curCfg.nrUnderTemp.ToString();
			UnderThreshEdit.Text = curCfg.underTemp.ToString("F2");
		}

		private bool GetInteger(string text, ref int res, int loLim, int hiLim)
		{
			int tmp;
			try
			{
				tmp = System.Convert.ToInt32(text);
			}
			catch { return false; }

			res = tmp;

			return (tmp >= loLim && tmp <= hiLim);
		}

		private bool GetFloat(string text, ref float res, float fLo, float fHi)
		{
			float tmp;
			try
			{
				tmp = System.Convert.ToSingle(text);
			}
			catch { return false; }

			res = tmp;

			return (tmp >= fLo && tmp <= fHi);
		}

		private bool CheckSetup(bool store)
		{
			int errCount = 0;
			List<string> errStrings = new List<string>();

			int underCount = 0;
			float underThresh = 0.0F;
			int overCount = 0;
			float overThresh = 0.0F;
			int startDelayUnit = 0;
			int delayCount = 0;
			int intervalUnit = 0;
			int intvalCount = 0;

			okConfig = false;

			if (!GetInteger(UnderCountEdit.Text, ref underCount, MIN_TEMP_COUNT, MAX_TEMP_COUNT))
			{
				errCount++;
				errStrings.Add(" - under temperature count error: val = \"" + UnderThreshEdit.Text + "\", range = " + MIN_TEMP_COUNT + " ..." + MAX_TEMP_COUNT + "\n");
			}

			if (!GetFloat(UnderThreshEdit.Text, ref underThresh, MIN_TEMPERATURE, MAX_TEMPERATURE))
			{
				errCount++;
				errStrings.Add(" - under temperature threshold error: val=\"" + UnderThreshEdit.Text + "\", range = " + MIN_TEMPERATURE.ToString("F2") + "..." + MAX_TEMPERATURE.ToString("F2") + "\n");
			}

			if (!GetInteger(OverCountEdit.Text, ref overCount, MIN_TEMP_COUNT, MAX_TEMP_COUNT))
			{
				errCount++;
				errStrings.Add(" - over temperature count error: val = \"" + OverThreshEdit.Text + "\", range = " + MIN_TEMP_COUNT + " ..." + MAX_TEMP_COUNT + "\n");
			}

			if (!GetFloat(OverThreshEdit.Text, ref overThresh, MIN_TEMPERATURE, MAX_TEMPERATURE))
			{
				errCount++;
				errStrings.Add(" - over temperature threshold error: val=\"" + OverThreshEdit.Text + "\", range = " + MIN_TEMPERATURE.ToString("F2") + "..." + MAX_TEMPERATURE.ToString("F2") + "\n");
			}

			startDelayUnit = DelayUnitSel.SelectedIndex;
			intervalUnit =  IntvalUnitSel.SelectedIndex;

			if (!GetInteger(DelayCountEdit.Text, ref delayCount, MIN_TIME_UNITS, MAX_TIME_UNITS))
			{
				errCount++;
				errStrings.Add(" - delay count error: val = \"" + DelayCountEdit.Text + "\", range = " + MIN_TIME_UNITS + " ..." + MAX_TIME_UNITS + "\n");
			}

			if (!GetInteger(IntvalCountEdit.Text, ref intvalCount, MIN_TIME_UNITS, MAX_TIME_UNITS))
			{
				errCount++;
				errStrings.Add(" - delay count error: val = \"" + IntvalCountEdit.Text + "\", range = " + MIN_TIME_UNITS + " ..." + MAX_TIME_UNITS + "\n");
			}

			if (errCount == 0 && (underThresh >= overThresh))
			{
				errCount++;
				errStrings.Add(" - under threshold needs to be less than over temperature threshold, under = " + underThresh.ToString("F2") + ", over = " + overThresh.ToString("F2"));
			}

			if (store && (errCount > 0))
			{
				string[] strArr = null;
				string msg = "";
				strArr = errStrings.ToArray();
				
				msg = "Following errors (" + errCount + ") were detected:\n\n";

				foreach (string s in strArr)
					msg += s;

				MessageBox.Show(msg, "Parameteter errors");
			}

			if (errCount == 0 && store)
			{
				theConfig.delayUnits = startDelayUnit;
				theConfig.delayValue = delayCount;
				theConfig.intvalUnits = intervalUnit;
				theConfig.intvalValue = intvalCount;
				theConfig.nrOverTemp = overCount;
				theConfig.nrUnderTemp = underCount;
				theConfig.overTemp = overThresh;
				theConfig.underTemp = underThresh;
				okConfig = true;
				return true;
			}

			return false;
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
			if (CheckSetup(true))
			{
				this.DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void CencelBtn_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
