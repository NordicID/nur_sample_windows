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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NurApiDotNet;
using CAENRT0005;

namespace CAENRT5Test
{
	public partial class RTRegsForm : Form
	{
		NurApi hNur;
		RT0005Tag mTag;

		public RTRegsForm(NurApi hApi, RT0005Tag tag)
		{
			InitializeComponent();

			mTag = tag;
			hNur = hApi;

			hNur.DisconnectedEvent += new EventHandler<NurApi.NurEventArgs>(hNur_DisconnectedEvent);

			ReadRegs();
		}

		void hNur_DisconnectedEvent(object sender, NurApi.NurEventArgs e)
		{
			UpdateBtn.Enabled = false;
			Status.Text = "Connection lost!";
		}

		private void RTRegsForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			hNur.DisconnectedEvent -= hNur_DisconnectedEvent;
		}

		private void SetupGrid()
		{
			RegList.View = View.Details;
			RegList.GridLines = true;
			RegList.Items.Clear();
		}

		private void AddRegItem(uint addr, string regName, ushort regValue, string noteStr)
		{
			string []strArr = new string[]
				{
					RTConverters.HexUInt16((ushort)addr),
					regName,
					RTConverters.HexUInt16(regValue),
					regValue.ToString(),
					noteStr
				};
			RegList.Items.Add(new ListViewItem(strArr));
		}

		private void ErrorItem(uint addr, string regStr, string errorStr)
		{
			RegList.Items.Add(new ListViewItem(new string[] { RTConverters.HexUInt16((ushort)addr), regStr, "0", "0", errorStr }));
		}

		private string TryGetTempConversion(ushort temp)
		{
			try
			{
				return RTConverters.FixedToString(temp);
			}
			catch
			{				
			}

			return ("(invalid)");
		}

		private string StatusRegToString(ushort statusReg)
		{
			List<int> bitList = RTConverters.UInt16ToIntList(statusReg);
			string res = "";
			List<String> bitStrings = new List<string>();
			int tmp = statusReg;
			
			tmp &= ~RTConst.STAT_BATT_MASK;
			statusReg = (ushort)tmp;

			if (statusReg == 0)
				return ("(none)");
			
			bitList = RTConverters.UInt16ToIntList(statusReg);

			if (bitList.Contains(RTConst.STAT_MEMFULL_LSH))
				bitStrings.Add("mem full");

			if (bitList.Contains(RTConst.STAT_ETA_ALARM_LSH))
				bitStrings.Add("ETA alarm");

			if (bitList.Contains(RTConst.STAT_BIN_ALARM_LSH))
				bitStrings.Add("BIN alarm");

			if (bitList.Contains(RTConst.STAT_MKT_ALARM_LSH))
				bitStrings.Add("MKT alarm");

			if (bitList.Contains(RTConst.STAT_SHL_ALARM_LSH))
				bitStrings.Add("SHL alarm");

			int i = 0;
			int last = bitStrings.Count - 1;
			foreach (string s in bitStrings)
			{
				res += s;
				if (i < last)
					res += ", ";
			}

			return res;
		}

		private void ReadRegs()
		{
			SetupGrid();
			ushort[] regs;
			uint curAddr;
			string tmp = "";

			curAddr = RTRegs.CONTROL;
			try
			{				
				regs = mTag.ReadMultipleRegs(curAddr, 2);
				tmp = "";
				if ((regs[0] & (RTConst.CTL_LOGEN_MASK | RTConst.CTL_DLYEN_MASK)) != 0)
				{
					tmp = "Enabled: ";
					if ((regs[0] & RTConst.CTL_LOGEN_MASK) != 0)
						tmp += "logging";

					if ((regs[0] & RTConst.CTL_DLYEN_MASK) != 0)
					{
						if ((regs[0] & RTConst.CTL_LOGEN_MASK) != 0)
							tmp += ", ";
						tmp += "start delay";
					}
				}
				else
					tmp = "Logging not enabled";

				AddRegItem(curAddr++, "Control", regs[0], tmp);
				AddRegItem(curAddr, "Sampling delay", regs[1], "Seconds");
			}
			catch (Exception e)
			{
				ErrorItem(curAddr++, "Control enable", e.Message);
				ErrorItem(curAddr, "Sampling delay", e.Message);
			}

			curAddr = RTRegs.BIN_ENABLE;
			try
			{				
				regs = mTag.ReadMultipleRegs(curAddr, 3);
				AddRegItem(curAddr++, "BIN enable", regs[0], "Enabled: " + RTConverters.IntListToString(RTConverters.UInt16ToIntList(regs[0])));
				AddRegItem(curAddr++, "BIN sample store", regs[1], "Enabled: " + RTConverters.IntListToString(RTConverters.UInt16ToIntList(regs[1])));
				AddRegItem(curAddr, "BIN timestamp store", regs[2], "Enabled: " + RTConverters.IntListToString(RTConverters.UInt16ToIntList(regs[2])));
			}
			catch (Exception e)
			{
				ErrorItem(curAddr++, "BIN enable", e.Message);
				ErrorItem(curAddr++, "BIN sample store", e.Message);
				ErrorItem(curAddr, "BIN timestamp store", e.Message);
			}

			curAddr = RTRegs.SAMPLES_NUM;
			try
			{
				regs = mTag.ReadMultipleRegs(curAddr, 1);
				AddRegItem(curAddr, "Sample count", regs[0], "");
			}
			catch (Exception e)
			{
				ErrorItem(curAddr, "Sample count", e.Message);
			}

			curAddr = RTRegs.BIN_SAMPLETIME_BASE;
			try
			{
				regs = mTag.ReadMultipleRegs(curAddr, 1);
				AddRegItem(curAddr, "Sample time[0]", regs[0], "Seconds");
			}
			catch (Exception e)
			{
				ErrorItem(curAddr, "Sample time[0]", e.Message);
			}

			curAddr = RTRegs.BIN_THRESHOLD_BASE;
			try
			{				
				regs = mTag.ReadMultipleRegs(curAddr, 1);
				AddRegItem(curAddr, "BIN threshold[0]", regs[0], "Celsius: " + TryGetTempConversion(regs[0]));
			}
			catch (Exception e)
			{
				ErrorItem(curAddr, "BIN threshold[0]", e.Message);
			}

			curAddr = RTRegs.BIN_HLIMIT_BASE;
			try
			{
				regs = mTag.ReadMultipleRegs(curAddr, 1);
				AddRegItem(curAddr, "BIN high limit[0]", regs[0], "Celsius: " + TryGetTempConversion(regs[0]));
			}
			catch (Exception e)
			{
				ErrorItem(curAddr, "BIN high limit[0]", e.Message);
			}

			curAddr = RTRegs.BIN_ALARM;
			try
			{
				regs = mTag.ReadMultipleRegs(curAddr, 1);
				AddRegItem(curAddr, "BIN alarms", regs[0], "Set: " + RTConverters.IntListToString(RTConverters.UInt16ToIntList(regs[0])));
			}
			catch (Exception e)
			{
				ErrorItem(curAddr, "BIN alarms", e.Message);
			}

			curAddr = RTRegs.STATUS;
			try
			{
				ushort batt;
				regs = mTag.ReadMultipleRegs(curAddr, 1);
				batt = (ushort)(regs[0] & RTConst.STAT_BATT_MASK);
				//AddRegItem(curAddr, "Status", regs[0], "Set: " + RTConverters.IntListToString(RTConverters.UInt16ToIntList(regs[0])));
				AddRegItem(curAddr, "Status", regs[0], "Set: " + StatusRegToString(regs[0]));
				AddRegItem(curAddr, "STAT: battery", batt, "Level = " + batt.ToString());
			}
			catch (Exception e)
			{
				ErrorItem(curAddr, "Status", e.Message);
			}
		}

		private void CloseBtn_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void UpdateBtn_Click(object sender, EventArgs e)
		{
			ReadRegs();			
		}
	}
}
