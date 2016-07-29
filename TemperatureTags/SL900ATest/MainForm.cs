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
using SL900A;


namespace SL900ATest
{
	public partial class MainForm : Form
	{
		NurApi hNur;
		SL900ATag currentTag = null;
		long startTime;
		List<NurApi.ComPort> mSerialPorts;
		NurApi.ReaderInfo mReaderInfo;
		NurApi.ModuleSetup mSetup;
		List<SL900ATag> AllTags;

		private const bool CONNECTED = true;
		private const bool NOT_CONNECTED = false;

		public MainForm()
		{
			InitializeComponent();

			hNur = new NurApi(this);
			InitControls();

			hNur.ConnectedEvent += new EventHandler<NurApi.NurEventArgs>(OnModuleConnect);			
			hNur.DisconnectedEvent += new EventHandler<NurApi.NurEventArgs>(OnModuleDisconnect);
			hNur.LogEvent += new EventHandler<NurApi.LogEventArgs>(OnLogEvent);

			startTime = GetTickCount();

			ListSerialDevices();
			AllTags = new List<SL900ATag>();

			APILabel.Text = "API: "  + hNur.GetFileVersion();
			NETAPILabel.Text = ".NET API: " + NurApi.FileVersion;

			EnableOpControls(NOT_CONNECTED);
		}

		void OnModuleConnect(object sender, NurApi.NurEventArgs e)
		{
			AddLog("Device connected.");
			TryUpdateReaderInfo();
			TryUpdateSetup();
			currentTag = null;
			EnableByTagPresence();
			EnableOpControls(CONNECTED);
			ConnectBtn.Text = "Disconnect";
		}

		void OnModuleDisconnect(object sender, NurApi.NurEventArgs e)
		{
			AddLog("Device discconnected.");
			TagList.Items.Clear();
			SelectedTag.Text = "Selected:";
			currentTag = null;
			EnableByTagPresence();
			EnableOpControls(NOT_CONNECTED);
			UsbAutoChk.Checked = false;
			ConnectBtn.Text = "Connect";

			UsbAutoChk.Checked = false;
		}

		void OnLogEvent(object sender, NurApi.LogEventArgs e)
		{
			AddLog(e.message);
		}

		private long GetTickCount()
		{
			return DateTime.Now.Ticks / 10000;
		}

		private long ElapsedTicks()
		{
			return (DateTime.Now.Ticks / 10000) - startTime;
		}

		private void AddLog(string text)
		{
			long t = ElapsedTicks();

			LogList.Items.Add(new ListViewItem(new string[] { t.ToString(), text }));
		}

		private void InfoLog(string text)
		{
			LogList.Items.Add(new ListViewItem(new string[] { "INFO", text }));
		}

		private void InitControls()
		{
			EnableByTagPresence();
			SensorSelect.SelectedIndex = 0;
			BdrSelect.SelectedIndex = 0;
			DelayModeSel.SelectedIndex = 0;
			FormSel.SelectedIndex = 0;

			// TX
			ModulationSel.SelectedIndex = NurApi.TXMODULATION_PRASK;

			// RX
			LFSel.SelectedIndex = 1;		// 256k
			MillerSel.SelectedIndex = 2;	// M-4

			// Other
			QEdit.Text = "3";
			SessionSel.SelectedIndex = 0;	
			TargetSel.SelectedIndex = NurApi.INVTARGET_A;

			PopulateTxLevel();
		}

		private void TryUpdateReaderInfo()
		{
			try
			{
				BdrSelect.SelectedIndex = hNur.BaudRate;
			}
			catch { }

			try
			{
				mReaderInfo = hNur.GetReaderInfo();
				AddLog("Device: " + mReaderInfo.name);
			}
			catch (NurApiException e)
			{
				AddLog("Update reader information failed, error: " + e.error + ".");
				AddLog("Message: " + e.Message);
			}
		}

		private void TryUpdateSetup()
		{
			try
			{
				mSetup = hNur.GetModuleSetup();
				SetupToControls();
			}
			catch (NurApiException e)
			{
				AddLog("Module setup update failed, error: " + e.error + ".");
				AddLog("Message: " + e.Message);
			}
		}

		private void EnableOpControls(bool connected)
		{
			PingBtn.Enabled = connected;
			BeepBtn.Enabled = connected;
			InvButton.Enabled = connected;
			RefreshBtn.Enabled = connected;
			ApplyBtn.Enabled = connected;
			SaveBtn.Enabled = connected;
		}

		private void EnableByTagPresence()
		{
			bool en = (currentTag != null);

			BattReadBtn.Enabled = en;
			SensorReadBtn.Enabled = en;
			UnSelReadBtn.Enabled = en;

			ReadSetupBtn.Enabled = en;
			InitSeqBtn.Enabled = en;
			
			LMUpdateBtn.Enabled = en;
		}

		private void DoBatteryRead()
		{
			int ll = hNur.GetLogLevel();
			hNur.SetLogLevel(0);

			if (currentTag != null)
			{
				string type = "(N/A)";
				string volt = "(N/A)";
				BattTypeText.Text = type;
				BattVoltText.Text = volt;

				try
				{
					SL900ATag.BatteryInfo battInfo = currentTag.Battery;
					if (battInfo.present && !battInfo.adError)
					{
						volt = string.Format("{0:#0.00}", SL900ATag.VoltageConversion(battInfo));
						type = battInfo.is3V ? "3.3V" : "1.5V";
						AddLog("Battery read OK.");
					}
					else if (!battInfo.present)
						AddLog("Battery not in place.");
					else
					{
						type = "A/D error";
						volt = "A/D error";
					}

					BattTypeText.Text = type;
					BattVoltText.Text = volt;

				}
				catch (Exception e)
				{
					AddLog("Error: " + e.Message);
					string[] more = currentTag.LastToStrings();
					foreach (string s in more)
						InfoLog(s);
				}
			}
			hNur.SetLogLevel(ll);
		}

		private void DoSensorRead()
		{
			int ticks = 0;
			if (currentTag != null)
			{
				SensorValueText.Text = "N/A";
				try
				{
					SL900ATag.SensorValue sensorVal;
					string s = "";
					uint sensor = (uint)SensorSelect.SelectedIndex;
					ticks = System.Environment.TickCount;
					sensorVal = currentTag.ReadSensor(sensor);
					ticks = System.Environment.TickCount - ticks;

					if (sensorVal.adError)
						s = "A/D error";
					else
						//s = "0x" + sensorVal.adValue.ToString("X4") + " (" + sensorVal.adValue + ")";
						s = ConversionToString(sensor, sensorVal.adValue);

					SensorValueText.Text = s;
					AddLog("Total excution time: " + ticks + " ms.");
					AddLog("Command exchange time: " + sensorVal.time + " ms.");

				}
				catch (Exception ex)
				{
					AddLog("Sensor read error.");
					InfoLog("Message: " + ex.Message);
				}
			}
		}

		private void DoSensorReadUnselected()
		{
			int ticks = 0;
			if (hNur != null && hNur.IsConnected())
			{
				SensorValueText.Text = "N/A";
				try
				{
					SL900ATag.SensorValue sensorVal;
					string s = "";
					uint sensor = (uint)SensorSelect.SelectedIndex;
					
					ticks = System.Environment.TickCount;
					sensorVal = (new SL900ATag(hNur)).ReadSensorUnselected(sensor);					
					ticks = System.Environment.TickCount - ticks;

					if (sensorVal.adError)
						s = "A/D error";
					else
						s = ConversionToString(sensor, sensorVal.adValue);

					SensorValueText.Text = s;
					AddLog("Total excution time: " + ticks + " ms.");
					AddLog("Command exchange time: " + sensorVal.time + " ms.");

				}
				catch (Exception ex)
				{
					AddLog("Sensor read error.");
					InfoLog("Message: " + ex.Message);
				}
			}
			else
				AddLog("No connection.");
		}

		private void DoInitSequence()
		{
			if (currentTag != null)
			{
				SL900ATag.InitData iData = new SL900ATag.InitData();

				if (BuildInitData(ref iData))
				{
					try
					{
						currentTag.Initialize = iData;
						AddLog("Initialization data is written.");
					}
					catch (Exception ex)
					{
						AddLog("Initialize error.");
						InfoLog("Message: " + ex.Message);
					}
				}
				else
					AddLog("Parameter error(s).");
			}
		}

		private void DoMeasSetupUpdate()
		{
			if (currentTag != null)
			{
				SL900ATag.MeasurementSetup setup;

				try
				{
					setup = currentTag.Setup;

					ExtLowEdit.Text = setup.limits.extLower.ToString();
					LowEdit.Text = setup.limits.lower.ToString();
					HighEdit.Text = setup.limits.upper.ToString();
					ExtHighEdit.Text = setup.limits.extUpper.ToString();
					FormSel.SelectedIndex = FormToIndex(setup.form);

					IrqTimerChk.Checked = setup.irqTimerEn;
					DelayModeSel.SelectedIndex = setup.delayModeExt ? 1 : 0;
					DelayTimeEdit.Text = setup.delayTime.ToString();
					WordCountEdit.Text = setup.appDataWords.ToString();
					BrokenWordEdit.Text = setup.brokenWordPtr.ToString();

					IntervalEdit.Text = setup.interval.ToString();
					TempSensChk.Checked = setup.tempSensEn;
					RollChk.Checked = setup.roll;

					Ext1Chk.Checked = setup.ext1En;
					Ext2Chk.Checked = setup.ext2En;

				}
				catch (Exception ex)
				{
					AddLog("Get setup error.");
					InfoLog("Message: " + ex.Message);
				}
			}
		}

		private void DoLogStateUpdate()
		{
			ResetLogStateTab();
			if (currentTag != null)
			{
				InfoLog("Logging mode update.");

				SL900ATag.LogStateInfo lsi;

				try
				{
					lsi = currentTag.LogState;
					PopulateLogState(lsi);
				}
				catch (Exception ex)
				{
					AddLog("Log state update error.");
					InfoLog("Error: " + ex.Message);
				}
			}
		}

		private void PopulateLogState(SL900ATag.LogStateInfo lsi)
		{
			if (lsi.actLogging)
				SetIndicator(LogActInd, "YES", IND_LEVEL_OK);
			else
				SetIndicator(LogActInd, "NO", IND_LEVEL_INACT);
			if (lsi.sysActive)
				SetIndicator(SysActLabel, "YES", IND_LEVEL_OK);
			else
				SetIndicator(SysActLabel, "NO", IND_LEVEL_INACT);

			CurAddrText.Text = "0x" + lsi.addrPtr.ToString("X4") + "(" + lsi.addrPtr + ")";
			NrMeasText.Text = lsi.nrOfMeas.ToString();

			if (lsi.adError)
				SetErrorIndicator(ADErrInd);
			else
				SetIndicator(ADErrInd, "NO", IND_LEVEL_OK);

			if (lsi.battLow)
				SetIndicator(BattLowInd, "YES", IND_LEVEL_FAIL);
			else
				SetIndicator(BattLowInd, "NO", IND_LEVEL_OK);

			if (lsi.full)
				SetIndicator(LogFullInd, "YES", IND_LEVEL_FAIL);
			else 
				SetIndicator(LogFullInd, "NO", lsi.actLogging ? IND_LEVEL_OK : IND_LEVEL_INACT);

			ELowText.Text = lsi.eLowCnt.ToString();
			LowText.Text = lsi.lowCnt.ToString();
			EHighText.Text = lsi.eUprCnt.ToString();
			HighText.Text = lsi.uprCnt.ToString();
			ReplText.Text = lsi.nrOfRepl.ToString();

			if (lsi.overWritten)
				SetIndicator(OverWrittenInd, "YES", IND_LEVEL_FAIL);
			else
				SetIndicator(OverWrittenInd, "NO", lsi.actLogging ? IND_LEVEL_OK : IND_LEVEL_INACT);

			if (lsi.hasShelfLife)
			{
				PopulateShelfLifeGroup(lsi.shelfLife, lsi.expired, lsi.actLogging);
				SetIndicator(SLHighErrInd, (lsi.slHighError ? "YES" : "NO"), lsi.slHighError ? IND_LEVEL_FAIL : IND_LEVEL_OK);
				SetIndicator(SLLowErrInd, (lsi.slLowError ? "YES" : "NO"), lsi.slLowError ? IND_LEVEL_FAIL : IND_LEVEL_OK);
			}
			else
				ResetShelLifeGroup();
		}

		private void PopulateShelfLifeGroup(SL900ATag.ShelfLifeParam slp, bool expired, bool logging)
		{
			if (expired)
				SetIndicator(SLExpInd, "YES", IND_LEVEL_FAIL);
			else
				SetIndicator(SLExpInd, "NO", logging ? IND_LEVEL_OK : IND_LEVEL_INACT);

			SLCurLifeText.Text = slp.curShelfLife.ToString();
			SLInitLifeText.Text = slp.initLife.ToString();
			SLInitTempText.Text = slp.initTemp.ToString();
			SLMaxTempText.Text = slp.maxTemp.ToString();
			SLMinTempText.Text = slp.minTemp.ToString();
			SLNormTempText.Text = slp.normTemp.ToString();

			if (slp.negSlEn)
				SetIndicator(SLNegEnText, "YES", logging ? IND_LEVEL_OK : IND_LEVEL_INACT);
			else
				SetIndicator(SLNegEnText, "NO", logging ? IND_LEVEL_OK : IND_LEVEL_INACT);

			SetIndicator(SLAlgEnInd, (slp.slAlgEn ? "YES" : "NO"), logging ? IND_LEVEL_OK : IND_LEVEL_N_A);

			SLSensIdText.Text = slp.slSensId.ToString();
		}

		/* OK means that state is read, but no shelf life data is present. */
		private void ResetShelLifeGroup()
		{			
			SetNAIndicator(SLEnText);

			SetNAIndicator(SLExpInd);
			SetNAIndicator(SLNegEnText);
			SetNAIndicator(SLAlgEnInd);
			SetNAIndicator(SLLowErrInd);
			SetNAIndicator(SLHighErrInd);

			SetNAIndicator(SLCurLifeText);
			SetNAIndicator(SLInitLifeText);
			SetNAIndicator(SLInitTempText);
			SetNAIndicator(SLMaxTempText);
			SetNAIndicator(SLMinTempText);
			SetNAIndicator(SLNormTempText);
			SetNAIndicator(SLSensIdText);
		}

		private void ResetLogStateTab()
		{
			SetNAIndicator(SysActLabel);
			SetNAIndicator(LogActInd);
			SetNAIndicator(CurAddrText);
			SetNAIndicator(ADErrInd);
			SetNAIndicator(BattLowInd);
			SetNAIndicator(LogFullInd);

			SetNAIndicator(ELowText);
			SetNAIndicator(LowText);
			SetNAIndicator(EHighText);
			SetNAIndicator(HighText);
			SetNAIndicator(NrMeasText);
			SetNAIndicator(ReplText);
			SetNAIndicator(OverWrittenInd);

			ResetShelLifeGroup();
		}

		private void QuitBtn_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DoSensorRead();
		}

		private void BattReadBtn_Click(object sender, EventArgs e)
		{
			DoBatteryRead();
		}

		private void InitSeqBtn_Click(object sender, EventArgs e)
		{
			DoInitSequence();
		}

		private void ClearBtn_Click(object sender, EventArgs e)
		{
			LogList.Items.Clear();
		}

		private void UsbAutoChk_CheckedChanged(object sender, EventArgs e)
		{
			bool on = UsbAutoChk.Checked;
			hNur.SetUsbAutoConnect(on);
		}

		private void DisconnectBtn_Click(object sender, EventArgs e)
		{
			if (hNur.IsConnected())
			{
				hNur.Disconnect();
				if (UsbAutoChk.Checked)
					UsbAutoChk.Checked = false;
			}
		}

		private void ListSerialDevices()
		{
			mSerialPorts = NurApi.EnumerateComPorts();
			SerialList.Items.Clear();

			foreach (NurApi.ComPort com in mSerialPorts)
				SerialList.Items.Add(com.friendlyName);
		}

		private void SerialBtn_Click(object sender, EventArgs e)
		{

		}

		private void BdrSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (hNur.IsConnected() && !UsbAutoChk.Checked)
			{
				try
				{
					hNur.BaudRate = BdrSelect.SelectedIndex;
				}
				catch (NurApiException ex)
				{
					AddLog("Baudrate failed, " + ex.Message);
				}
			}
		}

		private void ConnectBtn_Click(object sender, EventArgs e)
		{
			int index = SerialList.SelectedIndex;
			NurApi.ComPort comPort = null;

			if (hNur.IsConnected())
			{
				hNur.Disconnect();
				return;
			}

			if (index >= 0)
			{
				try
				{
					comPort = mSerialPorts[index];
				}
				catch
				{
					AddLog("Could not get serial port.");
				}

				try
				{
					hNur.ConnectSerialPort(comPort.port, BdrSelect.SelectedIndex);
				}
				catch (NurApiException ex)
				{
					AddLog("Could not connect to " + comPort.friendlyName);
					AddLog("Error: " + ex.Message);
				}
			}
			else
			{
				AddLog("Error: No port selected.");
			}
		}

		private void PingBtn_Click(object sender, EventArgs e)
		{
			if (hNur.IsConnected())
			{
				string s;
				
				try
				{
					s = hNur.Ping();
					AddLog("Ping: \"" + s + "\".");
				}
				catch (NurApiException ex)
				{
					AddLog("Ping error: " + ex.error);
					AddLog("Message: " + ex.Message);
				}
			}
		}

		private void BeepBtn_Click(object sender, EventArgs e)
		{
			if (hNur.IsConnected())
			{
				try
				{
					hNur.Beep();
					AddLog("Beep OK.");
				}
				catch (NurApiException ex)
				{
					AddLog("Beep error: " + ex.error);
					AddLog("Message: " + ex.Message);
				}
			}
		}

		private void RefreshBtn_Click(object sender, EventArgs e)
		{
			if (hNur.IsConnected())
				TryUpdateSetup();
		}

		private void SetSetup(bool store)
		{
			int flags = 0;
			NurApi.ModuleSetup setup = new NurApi.ModuleSetup();

			if (ControlsToSetup(ref setup, ref flags))
			{
				try
				{
					hNur.SetModuleSetup(flags, ref setup);
					AddLog("Setup is set.");
				}
				catch (Exception ex)
				{
					AddLog("Apply setup error.");
					AddLog(ex.Message);
				}

				if (store)
				{
					try
					{
						hNur.StoreCurrentSetup();
						AddLog("Setup is stored into the module.");
					}
					catch (Exception ex)
					{
						AddLog("Store setup error.");
						AddLog(ex.Message);
					}
				}
			}
			else
				AddLog("Parse error(s).");
		}

		private void ApplyBtn_Click(object sender, EventArgs e)
		{
			SetSetup(false);
		}

		private void SaveBtn_Click(object sender, EventArgs e)
		{
			SetSetup(true);
		}

		private void InvButton_Click(object sender, EventArgs e)
		{
			NurApi.TagStorage storage;
			NurApi.InventoryResponse resp;
			int i;

			currentTag = null;
			EnableByTagPresence();			

			AllTags.Clear();
			TagList.Items.Clear();
			SelectedTag.Text = "Selected: ";

			try
			{
				hNur.ClearIdBuffer();
				resp = hNur.Inventory();

				storage = hNur.FetchTags(true);
				
				for (i = 0; i < resp.numTagsFound; i++)
				{
					AllTags.Add(new SL900ATag(storage[i]));
					TagList.Items.Add(storage[i].GetEpcString());
				}
			}
			catch (Exception ex)
			{
				AddLog("Inventory error.");
				AddLog("Message: " + ex.Message);
			}

		}

		private void TagList_SelectedIndexChanged(object sender, EventArgs e)
		{
			int index = TagList.SelectedIndex;

			if (index >= 0 && index < AllTags.Count)
			{
				currentTag = AllTags[index];
				SelectedTag.Text = "Selected: " + currentTag.GetEpcString();
			}
			else
			{
				currentTag = null;
			}
			EnableByTagPresence();
		}

		private void VerbChk_CheckedChanged(object sender, EventArgs e)
		{
			bool en = VerbChk.Checked;
			int level;

			level = hNur.GetLogLevel();
			if (en)
				level |= NurApi.LOG_VERBOSE;
			else
				level &= ~NurApi.LOG_VERBOSE;
			
			hNur.SetLogLevel(level);
			InfoLog("Verbose log " + (en ? "enabled." : "disabled."));
		}

		private void CopyBtn_Click(object sender, EventArgs e)
		{
			CopyLog();
		}

		private void ReadSetupBtn_Click(object sender, EventArgs e)
		{
			DoMeasSetupUpdate();
		}

		private void LMUpdateBtn_Click(object sender, EventArgs e)
		{
			DoLogStateUpdate();
		}

		private void tabLogState_Enter(object sender, EventArgs e)
		{
			if (currentTag == null)
			{
				InfoLog("No tag: reset.");
				ResetLogStateTab();
			}
			else
				DoLogStateUpdate();
		}

		private void tabSetup_Enter(object sender, EventArgs e)
		{
			DoMeasSetupUpdate();
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			DoSensorReadUnselected();
		}
	}
}
