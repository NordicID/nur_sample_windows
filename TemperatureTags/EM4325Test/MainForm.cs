using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NurApiDotNet;
using EM4325;

using RFIDHelpers;

namespace EM4325Test
{
	public partial class MainForm : Form
	{
		private NurApi hNur;
		EM4325Tag CurrentTag = null;
		List<EM4325Tag> AllTags;

		int disableEvents = 0;

		public MainForm()
		{
			InitializeComponent();

			hNur = new NurApi(this);

			AllTags = new List<EM4325Tag>();

			hNur.ConnectedEvent += new EventHandler<NurApi.NurEventArgs>(OnReaderConnect);
			hNur.DisconnectedEvent += new EventHandler<NurApi.NurEventArgs>(OnReaderDisconnect);
			hNur.LogEvent += new EventHandler<NurApi.LogEventArgs>(OnLogEvent);

			UserMemType.SelectedIndex = 2;

			AddLog("API ver: " + hNur.GetFileVersion() + ".");
		}

		private void EnableCtls(bool en)
		{
			UIDBtn.Enabled = en;
			GetTagsBtn.Enabled = en;
			SensorBtn.Enabled = en;
			BAPStatBtn.Enabled = en;
			GetUTCBtn.Enabled = en;
			GetTempBtn.Enabled = en;
			RstAlarmsBtn.Enabled = en;
			StopBtn.Enabled = en;
			BAPEnBtn.Enabled = en;
			BAPDisBtn.Enabled = en;
			TestTagBtn.Enabled = en;
			ResetToABtn.Enabled = en;
			ReadCfgBtn.Enabled = en;
			MakeSimpleBtn.Enabled = en;
			CustStartBtn.Enabled = en;
			SimpleStartBtn.Enabled = en;
			BtnReadUSer.Enabled = en;


			if (en == false)
			{
				TagListView.Items.Clear();
				TagLabel.Text = "---";
			}
		}

		void OnReaderConnect(object sender, NurApi.NurEventArgs e)
		{
			EnableCtls(true);
			UpdateReaderInformation();
			FillTxLevels();
			FillPhysAntListView();
			ModuleSetupToControls();
			UpdateLogSettings();
			AddLog("Connected to reader");

			if (AutoScanChk.Checked)
			{
				AddLog("Auto scan...");
				DoGetTags();
			}
		}

		void OnReaderDisconnect(object sender, NurApi.NurEventArgs e)
		{
			EnableCtls(false);
			AddLog("Disconnected.");
		}

		void OnLogEvent(object sender, NurApi.LogEventArgs e)
		{
			AddLog(e.message);
		}

		private void UpdateLogSettings()
		{
			int level = hNur.GetLogLevel();

			VerbChk.Checked = ((level & NurApi.LOG_VERBOSE) != 0);
			ULogChk.Checked = ((level & NurApi.LOG_USER) != 0);
			ErrLogChk.Checked = ((level & NurApi.LOG_ERROR) != 0);
		}

		private string[] ListMinutes()
		{
			List<string> lst = new List<string>();
			int i, min, step;
			string s = "";

			min = 5;
			step = 5;
			for (i = 0; i < 8; i++)
			{
				s = i + ": " + min + " minutes";
				lst.Add(s);
				min += step;
			}

			return lst.ToArray();
		}

		private string[] ListHours()
		{
			List<string> lst = new List<string>();
			int i, h, step;
			string s = "";

			h = 1;
			step = 1;
			for (i = 0; i < 8; i++)
			{
				s = i + ": " + h + " hour";
				if (h > 1)
					s += "s";
				lst.Add(s);
				h += step;
			}

			return lst.ToArray();
		}

		private void PopulateAccuracy(ComboBox cmb)
		{
			cmb.Items.Clear();
			cmb.DropDownStyle = ComboBoxStyle.DropDownList;

			cmb.Items.Add("-0.5...0.5 C");
			cmb.Items.Add("-1.0...1.0 C");
			cmb.Items.Add("-2.0...2.0 C");
		}

		private void PopulateLimit(ComboBox cmb, bool lowLim, bool t28)
		{
			int i, step, current;
			cmb.Items.Clear();
			cmb.DropDownStyle = ComboBoxStyle.DropDownList;

			step = t28 ? 2 : 1;

			if (lowLim)
				step *= -1;

			current = step;
			cmb.Items.Add("None.");
			for (i = 1; i < 8; i++)
			{
				cmb.Items.Add("Center " + ((lowLim == false) ? "+" : "") + current);
				current += step;
			}
		}

		private void PopulateMonDelay(ComboBox cmb, bool lowLim)
		{
			int i;
			cmb.Items.Clear();
			cmb.DropDownStyle = ComboBoxStyle.DropDownList;

			cmb.Items.Add("None.");
			for (i = 1; i < 8; i++)
			{
				cmb.Items.Add("Rate x " + i);
			}
		}

		private void AddLog(string s)
		{
			Log.Items.Add(s);
			Log.SelectedIndex = Log.Items.Count - 1;
		}

		private void ClearBtn_Click(object sender, EventArgs e)
		{
			Log.Items.Clear();
		}

		private void AutoConnChk_Click(object sender, EventArgs e)
		{
			hNur.SetUsbAutoConnect(AutoConnChk.Checked);
		}

		private void LogLevel(int l, bool set)
		{
			int level;

			level = hNur.GetLogLevel();
			if (set)
				level |= l;
			else
				level &= ~l;
			hNur.SetLogLevel(level);
		}

		private void ULogChk_Click(object sender, EventArgs e)
		{
			LogLevel(NurApi.LOG_USER, ULogChk.Checked);
		}

		private void VerbChk_Click(object sender, EventArgs e)
		{
			LogLevel(NurApi.LOG_VERBOSE, VerbChk.Checked);
		}

		private void ErrLogChk_Click(object sender, EventArgs e)
		{
			LogLevel(NurApi.LOG_ERROR, ErrLogChk.Checked);
		}

		private void UIDBtn_Click(object sender, EventArgs e)
		{
			DoGetUID();
		}

		private void GetTagsBtn_Click(object sender, EventArgs e)
		{
			DoGetTags();
		}

		private void DoGetUID()
		{
			EM4325Tag.UIDResponse theUid;

			if (hNur.IsConnected() && CurrentTag != null)
			{
				try
				{
					AddLog("Trying to get UID from " + NurApi.BinToHexString(CurrentTag.mEPC) + ".");
					theUid = CurrentTag.UID;
					ShowUID(theUid);
				}
				catch (Exception ex)
				{
					AddLog("UID error: " + ex.Message + ".");
				}
			}
		}

		private void DoGetSensor()
		{
			EM4325Tag.SensorData sd = new EM4325Tag.SensorData();
			bool ok = false;

			if (hNur.IsConnected() && CurrentTag != null)
			{
				try
				{
					AddLog("Getting sensor data from " + NurApi.BinToHexString(CurrentTag.mEPC) + ".");
					sd = CurrentTag.GetSensorData(UidWithSensor.Checked, true);
					ok = true;

					if (CurrentTag.lastSdResp != null)
					{
						AddLog("SD response:");
						AddLog(NurApi.BinToHexString(CurrentTag.lastSdResp));
					}
				}
				catch (Exception ex)
				{
					AddLog("Sensor data error: " + ex.Message + ".");
				}

				if (ok)
				{
					if (UidWithSensor.Checked)
					{
						try
						{
							ShowUID(sd.uid);
						}
						catch (Exception e)
						{
							AddLog("UID dump error: " + e.Message);
						}
					}

					try
					{
						ShowSensorData(sd);
					}
					catch (Exception e)
					{
						AddLog("Sensor data dump error: " + e.Message);
					}
				}
			}
		}

		private void DoGetTemperature()
		{
			if (TagReady)
			{
				try
				{
					AddLog("Temperature: " + CurrentTag.Temperature.ToString("F2"));
				}
				catch (Exception ex)
				{
					AddLog("Temperature error: " + ex.Message);
				}
			}
		}

		private void DoResetAlarms()
		{
			if (TagReady)
			{
				EM4325Tag.ConfigData cfg;
				try
				{
					cfg = CurrentTag.Configuration;
					AddLog("Can reset alarms: " + YesNo(cfg.resetEn));
					AddLog("Bytes: ");
					AddLog(NurApi.BinToHexString(cfg.raw));
				}
				catch (Exception e)
				{
					AddLog("Configuration read error: " + e.Message);
				}


				AddLog("Resetting alarms from " + CurrentTag.GetEpcString());
				if (CurrentTag.ResetAlarms())
					AddLog("Alarms are reset.");
				else
					AddLog("Resetting alarms failed.");

			}
		}

		private void ShowConfiguration(EM4325Tag.ConfigData cfg)
		{
			string[] cfgStrings;

			cfgStrings = EM4325Tag.ConfigToStrings(cfg);

			foreach (string s in cfgStrings)
				AddLog(s);
		}

		private void DoGetConfig()
		{
			if (TagReady)
			{
				EM4325Tag.ConfigData cfg;
				try
				{
					cfg = CurrentTag.Configuration;
					AddLog("Got configuration from " + CurrentTag.GetEpcString() + ".");
					ShowConfiguration(cfg);
				}
				catch (Exception e)
				{
					AddLog("Configuration read error: " + e.Message);
				}
			}
		}

		private void LogBytes(byte[] b)
		{
			int i, j;
			string s = "";

			j = 0;
			for (i = 0; i < b.Length; i++)
			{
				s += (b[i].ToString("X2") + " ");
				s += " ";
				if (j == 7)
					s += "  ";
				if (j == 15)
				{
					j = 0;
					AddLog(s);
					s = "";
				}
				else
					j++;
			}
			if (j != 0)
				AddLog(s);
		}

		private void LogWords(ushort[] w)
		{
			int i, j;
			string s = "";

			j = 0;
			for (i = 0; i < w.Length; i++)
			{
				s += ((w[i].ToString("X4")) + " ");
				if (j == 3)
					s += "  ";
				if (j == 7)
				{
					j = 0;
					AddLog(s);
					s = "";
				}
				else
					j++;
			}
			if (j != 0)
				AddLog(s);
		}

		private void LogDwords(uint[] dw)
		{
			int i, j;
			string s = "";

			j = 0;
			for (i = 0; i < dw.Length; i++)
			{
				s += (dw[i].ToString("X8") + " ");
				if (j == 1)
					s += "  ";
				if (j == 3)
				{
					j = 0;
					AddLog(s);
					s = "";
				}
				else
					j++;
			}
			if (j != 0)
				AddLog(s);
		}

		private void DoUserMemRead(int type)
		{
			bool app = AppReadChk.Checked;
			try
			{
				switch (type)
				{
					case 0:
						if (app)
							LogBytes(RFIDHelpers.RFIDHelpers.ReadBytes(hNur, CurrentTag.mEPC, NurApi.BANK_USER, 0, EM4325Tag.USERMEM_BYTE_SIZE / 2));
						else
							LogBytes(CurrentTag.ReadUserBytes());
						break;
					case 1:
						if (app)
							LogWords(RFIDHelpers.RFIDHelpers.ReadWords(hNur, CurrentTag.mEPC, NurApi.BANK_USER, 0, EM4325Tag.USERMEM_BYTE_SIZE / 4));
						else
							LogWords(CurrentTag.ReadUserUshort());
						break;
					case 2:
						if (app)
							LogDwords(RFIDHelpers.RFIDHelpers.ReadDwords(hNur, CurrentTag.mEPC, NurApi.BANK_USER, 0, EM4325Tag.USERMEM_BYTE_SIZE / 8));
						else
							LogDwords(CurrentTag.ReadUserUint());
						break;
					default: break;
				}
			}
			catch (NurApiException e)
			{
				AddLog("User memory read error: " + e.Message);
			}
		}

		private void MakeSimpleSensor()
		{
			if (TagReady)
			{
				try
				{
					AddLog("Forcing " + CurrentTag.GetEpcString() + " to simple sensor.");
					CurrentTag.ForceSimple();
					AddLog("Simple setting OK.");
				}
				catch (NurApiException e)
				{
					AddLog("Simple setting error: + " + e.Message);
				}
			}
		}

		private void StartCustomSensor()
		{
			if (TagReady)
			{
				bool ok = false;
				CustomConfigDlg dlg = null;
				EM4325Tag.ConfigData cfg = new EM4325Tag.ConfigData();

				try
				{
					cfg = CurrentTag.Configuration;
					ok = true;
				}
				catch (Exception e)
				{
					AddLog("Could not read current configuration.");
				}

				if (ok)
				{
					dlg = new CustomConfigDlg(cfg.custom);

					if (dlg.ShowDialog() == DialogResult.OK)
					{
						AddLog("Starting custom...");
					}
					else
						ok = false;
				}

				if (ok)
				{
					try
					{
						CurrentTag.StartCustom(dlg.Config, dlg.TimeStampRequired, dlg.ResetAlarmsEnabled, BlockCfgChk.Checked);
					}
					catch (Exception e)
					{
						AddLog("Custom start failed.");
						AddLog("Error: " + e.Message);
					}
				}
			}
		}

		private string StrSel(bool isTrue, string trueString, string falseString)
		{
			return isTrue ? trueString : falseString;
		}

		private void DoBAControl(bool on)
		{
			if (TagReady)
			{
				int phase = 0;
				try
				{
					if (!CurrentTag.BAPCtlEnabled)
					{
						CurrentTag.BAPCtlEnabled = true;
						AddLog("BA control setting to " + StrSel(on, "ON", "OFF") + " OK.");
					}
					phase++;
				}
				catch (Exception e)
				{
					AddLog("BA control enabling failed.");
					AddLog("Error: " + e.Message);
				}

				if (phase > 0)
				{
					try
					{
						CurrentTag.BAPModeEnabled = on;
						AddLog("BA setting to " + StrSel(on, "ON", "OFF") + " OK.");
					}
					catch (Exception e)
					{
						AddLog("BA setting to " + StrSel(on, "ON", "OFF") + " failed.");
						AddLog("Error: " + e.Message);
					}
				}
			}
		}

		private string HEX4(int iVal)
		{
			return "HEX: " + iVal.ToString("X4");
		}

		private void ShowUID(EM4325Tag.UIDResponse u)
		{
			AddLog("UID.allocClass = 0x" + u.allocClass.ToString("X2"));

			AddLog("Serial: " + u.serial + " (0x" + u.serial.ToString("X12") + ".");

			if (u.mdid != -1)
				AddLog("MDID = " + u.mdid + " (" + HEX4(u.mdid) + ").");
			else
				AddLog("MDID not available.");

			if (u.mid != -1)
				AddLog("MID = " + u.mid + " (" + HEX4(u.mid) + ").");
			else
				AddLog("MID not available.");

			if (u.modelNum != -1)
				AddLog("Model number = " + u.modelNum + " (" + HEX4(u.modelNum) + ").");
			else
				AddLog("Model number not available.");

			if (u.xtid != -1)
				AddLog("XTID = " + u.xtid);
			else
				AddLog("XTID not available.");

			if (u.xtidHdr != -1)
				AddLog("XTID header = " + u.xtidHdr + " (" + HEX4(u.xtidHdr) + ").");
			else
				AddLog("XTID header not available.");

			if (u.umSize != -1)
				AddLog("User memory size = " + u.umSize + ".");
			else
				AddLog("User memory size not available.");
		}

		private string Alarm(bool alarm, string other)
		{
			if (other == "")
				return alarm ? "ALARM" : "OK";
			return alarm ? "ALARM" : other;
		}

		private string YesNo(bool yes)
		{
			return yes ? "YES" : "NO";
		}

		private void ShowSensorData(EM4325Tag.SensorData sd)
		{
			AddLog("Sensor data = " + sd.data + ", 0x" + sd.data.ToString("X8"));
			AddLog("Bytes = " + NurApi.BinToHexString(sd.raw));

			AddLog("Last temperature: " + sd.temp.ToString("F2"));
			AddLog("Monitor enabled: " + YesNo(sd.enabled));
			AddLog("Simple sensor: " + YesNo(sd.isSimple));

			AddLog("Battery: " + Alarm(sd.battAlarm, ""));
			AddLog("AUX: " + Alarm(sd.battAlarm, ""));
			AddLog("Over temperature alarm: " + Alarm(sd.overTemp, "no"));
			AddLog("Under temperature alarm: " + Alarm(sd.underTemp, "no"));

			AddLog("Aborted measurements: " + sd.abortCount);
			AddLog("Under temperature count: " + sd.underCount);
			AddLog("Over temperature count: " + sd.overCount);

			AddLog("UTC = 0x" + sd.utc.ToString("X8"));
		}

		private void ResetToA()
		{
			int i;
			for (i = 0; i < 2; i++)
			{
				try { hNur.ResetToTarget(0, true); }
				catch (NurApiException e)
				{
					int error = e.error;
					AddLog("Reset target error: " + error + ".");
					if (error == NurApiErrors.NUR_ERROR_TRANSPORT || error == NurApiErrors.NUR_ERROR_TR_TIMEOUT)
						break;
				}
			}
		}

		private void DoTestTag()
		{
			if (!TagReady)
			{
				AddLog("No tag to test.");
				return;
			}

			byte[] testData;
			uint[] pointers;

			int phase = 0;

			try
			{
				testData = CurrentTag.ReadTag(0, false, NurApi.BANK_USER, EM4325Tag.ADDR_CTLWORD_1, 6);
				AddLog("Control word data: " + NurApi.BinToHexString(testData));
				phase++;

				pointers = ReadUint32(hNur, CurrentTag.mEPC, NurApi.BANK_USER, 0xED, 2);

				AddLog("Pointer[0] = 0x" + pointers[0].ToString("X8") + ".");
				AddLog("Pointer[1] = 0x" + pointers[1].ToString("X8") + ".");

				//AddLog("SSD pointer = 0x" + pointers[0].ToString("X8") + ".");
				//AddLog("UTC pointer = 0x" + pointers[1].ToString("X8") + ".");

			}
			catch (Exception e)
			{
				if (phase == 0)
					AddLog("Test read error: " + e.Message);
				else if (phase == 1)
				{
					AddLog("Error reading SSD & UTC pointers.");
					AddLog("Error: " + e.Message);
				}
			}
		}

		private ulong[] ReadUint64(NurApi hNur, byte[] epc, byte bank, uint start, int n)
		{
			byte[] rdData;
			byte[] ulBytes = new byte[8];
			int i;
			List<ulong> lst = new List<ulong>();

			rdData = hNur.ReadTagByEPC(0, false, epc, bank, start, n * 8);
			for (i = 0; i < rdData.Length; i += 8)
			{
				System.Array.Copy(rdData, i, ulBytes, 0, 8);
				System.Array.Reverse(ulBytes);
				lst.Add(BitConverter.ToUInt64(ulBytes, 0));
			}

			return lst.ToArray();
		}


		private uint[] ReadUint32(NurApi hNur, byte[] epc, byte bank, uint start, int n)
		{
			byte[] rdData;
			byte[] uiBytes = new byte[4];
			int i;
			List<uint> lst = new List<uint>();

			rdData = hNur.ReadTagByEPC(0, false, epc, bank, start, n * 4);
			for (i = 0; i < rdData.Length; i += 4)
			{
				System.Array.Copy(rdData, i, uiBytes, 0, 4);
				System.Array.Reverse(uiBytes);
				lst.Add(BitConverter.ToUInt32(uiBytes, 0));
			}

			return lst.ToArray();
		}

		private ushort[] ReadUint16(NurApi hNur, byte[] epc, byte bank, uint start, int n)
		{
			byte[] rdData;
			byte[] usBytes = new byte[2];
			int i;
			List<ushort> lst = new List<ushort>();

			rdData = hNur.ReadTagByEPC(0, false, epc, bank, start, n * 2);
			for (i = 0; i < rdData.Length; i += 2)
			{
				System.Array.Copy(rdData, i, usBytes, 0, 2);
				System.Array.Reverse(usBytes);
				lst.Add(BitConverter.ToUInt16(usBytes, 0));
			}

			return lst.ToArray();
		}

		private ulong ReadULong64(NurApi hNur, byte[] epc, byte bank, uint addr)
		{
			byte[] rdData;
			rdData = hNur.ReadTagByEPC(0, false, epc, bank, addr, 8);
			System.Array.Reverse(rdData);
			return BitConverter.ToUInt64(rdData, 0);
		}

		private uint ReadUint32(NurApi hNur, byte[] epc, byte bank, uint addr)
		{
			byte[] rdData;
			rdData = hNur.ReadTagByEPC(0, false, epc, bank, addr, 4);
			System.Array.Reverse(rdData);
			return BitConverter.ToUInt32(rdData, 0);
		}

		private ushort ReadUint16(NurApi hNur, byte[] epc, byte bank, uint addr)
		{
			byte[] rdData;
			rdData = hNur.ReadTagByEPC(0, false, epc, bank, addr, 2);
			System.Array.Reverse(rdData);
			return BitConverter.ToUInt16(rdData, 0);
		}

		private void DoGetTags()
		{
			if (!hNur.IsConnected())
			{
				AddLog("Connection required.");
				return;
			}

			CurrentTag = null;
			AllTags.Clear();
			TagListView.Items.Clear();
			TagLabel.Text = "---";

			try
			{
				ResetToA();

				hNur.ClearTagsEx();



				NurApi.InventoryExParams invParam;
				NurApi.InventoryExFilter[] invFilters;

				// Disable EPC+DATA mode 
				hNur.InventoryReadCtl = false;
				// Configure InventoryExParams for Temperature read
				invParam.inventorySelState = NurApi.SELSTATE_SL;
				invParam.inventoryTarget = NurApi.INVTARGET_A;
				invParam.Q = hNur.InventoryQ;
				invParam.rounds = hNur.InventoryRounds;
				invParam.session = NurApi.SESSION_S0;
				invParam.transitTime = 0; // Disable
				// Configure InventoryExFilter
				invFilters = new NurApi.InventoryExFilter[1];
				invFilters[0].action = NurApi.FACTION_0;
				invFilters[0].address = 0;
				invFilters[0].bank = NurApi.BANK_TID;
				invFilters[0].maskData = new byte[] { 0xE2, 0x80, 0xB0, 0x40 };
				invFilters[0].maskBitLength = (invFilters[0].maskData.Length * 8) - 4;
				invFilters[0].target = NurApi.SESSION_SL;
				invFilters[0].truncate = false;
				// Read
				NurApi.InventoryResponse resp = hNur.InventoryEx(ref invParam, invFilters);
				// Fetch tags from the module
				NurApi.TagStorage tagStorage = hNur.FetchTags(true);

				for (int i = 0; i < tagStorage.Count; i++)
				{
					NurApi.Tag tag = tagStorage[i];
					AllTags.Add(new EM4325Tag(tag));
					ListViewItem lvi = new ListViewItem(tag.GetEpcString());
					lvi.SubItems.Add(tag.rssi.ToString());
					lvi.SubItems.Add(tag.antennaId.ToString());
					TagListView.Items.Add(lvi);
				}
				columnHeader_EPC.Width = -2;
				columnHeader_RSSI.Width = -2;
				columnHeader_AntID.Width = -2;
			}
			catch (Exception ex)
			{
				AddLog("Inventory error.");
				AddLog("Message: " + ex.Message);
			}
		}

		private void QuitBtn_Click(object sender, EventArgs e)
		{
			if (hNur.IsConnected())
			{
				try { hNur.Disconnect(); }
				catch { }
			}

			Close();
		}

		private void TagListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (TagListView.SelectedItems.Count > 0)
			{
				CurrentTag = AllTags[TagListView.SelectedItems[0].Index];
				CurrentTag.UseTargetReset = TargetResetChk.Checked;
				TagLabel.Text = NurApi.BinToHexString(CurrentTag.mEPC);
			}
			else
			{
				CurrentTag = null;
				TagLabel.Text = "---";
			}
		}

		private void UpdateReaderInformation()
		{
			try
			{
				NurApi.ReaderInfo readerInfo = hNur.GetReaderInfo();
				NurApi.DeviceCapabilites deviceCaps = hNur.GetDeviceCaps();

				AddLog(string.Format("Device: {0} - {1}",
					readerInfo.name,
					readerInfo.altSerial
					));

				if ((deviceCaps.secChipMajorVersion != 0 ||
					deviceCaps.secChipMinorVersion != 0) &&
					deviceCaps.secChipMinorVersion != 255)
				{
					AddLog(string.Format("Firmware: {0} / {1}.{2}.{3}.{4}",
						readerInfo.GetVersionString(),
						deviceCaps.secChipMajorVersion, deviceCaps.secChipMinorVersion,
						deviceCaps.secChipMaintenanceVersion, deviceCaps.secChipReleaseVersion));
				}
				else
				{
					AddLog("Firmware: " + readerInfo.GetVersionString());
				}
			}
			catch (NurApiException e)
			{
				AddLog("Update reader information failed, error: " + e.error + ".");
				AddLog("Message: " + e.Message);
			}
		}

		private void SensorBtn_Click(object sender, EventArgs e)
		{
			DoGetSensor();
		}

		private bool TagReady
		{
			get { return (hNur.IsConnected() && CurrentTag != null); }
		}

		private void GetBAPStatus()
		{
			if (TagReady)
			{
				bool en;
				try
				{
					en = CurrentTag.BAPModeEnabled;
					AddLog("BAP = " + (en ? "enabled" : "disabled") + ".");
				}
				catch (Exception e)
				{
					AddLog("Could not get BAP mode.");
					AddLog("Error: " + e.Message);
				}
			}
		}
		private void DoGetUTC()
		{
			if (TagReady)
			{
				uint utc;
				try
				{
					utc = CurrentTag.UTC;
					AddLog("UTC = " + utc + ", 0x" + utc.ToString("X8") + ".");
				}
				catch (Exception e)
				{
					AddLog("UTC error: " + e.Message);
				}
			}
		}

		private void BAPStatBtn_Click(object sender, EventArgs e)
		{
			GetBAPStatus();
		}

		private void GetUTCBtn_Click(object sender, EventArgs e)
		{
			DoGetUTC();
		}

		private void GetTempBtn_Click(object sender, EventArgs e)
		{
			DoGetTemperature();
		}

		private void RstAlarmsBtn_Click(object sender, EventArgs e)
		{
			DoResetAlarms();
		}

		private void StopBtn_Click(object sender, EventArgs e)
		{
			if (TagReady)
			{
				try
				{
					AddLog("Stopping " + CurrentTag.GetEpcString());
					CurrentTag.Stop();
					AddLog("STOP OK.");
				}
				catch (Exception ex)
				{
					AddLog("STOP error: " + ex.Message);
				}
			}
		}

		private void BAPEnBtn_Click(object sender, EventArgs e)
		{
			DoBAControl(true);
		}

		private void BAPDisBtn_Click(object sender, EventArgs e)
		{
			DoBAControl(false);
		}

		private void TestTagBtn_Click(object sender, EventArgs e)
		{
			DoTestTag();
		}

		private void ResetToABtn_Click(object sender, EventArgs e)
		{
			if (hNur.IsConnected())
			{
				ResetToA();
				AddLog("Ready with reset to 'A'.");
			}
		}

		private void ReaderTab_Enter(object sender, EventArgs e)
		{
			if (hNur.IsConnected())
				ModuleSetupToControls();
		}

		private void ReadCfgBtn_Click(object sender, EventArgs e)
		{
			DoGetConfig();
		}

		private void MakeSimpleBtn_Click(object sender, EventArgs e)
		{
			MakeSimpleSensor();
		}

		private void CustStartBtn_Click(object sender, EventArgs e)
		{
			StartCustomSensor();
		}

		private void BtnReadUSer_Click(object sender, EventArgs e)
		{
			if (TagReady)
			{
				DoUserMemRead(UserMemType.SelectedIndex);
			}
		}

		private void TargetResetChk_Click(object sender, EventArgs e)
		{
			if (TagReady)
				CurrentTag.UseTargetReset = TargetResetChk.Checked;
		}

		private void FillTxLevels()
		{
			disableEvents++;

			TxLevelSel.Items.Clear();
			try
			{
				NurApi.DeviceCapabilites deviceCaps = hNur.GetDeviceCaps();
				for (int txLevel = 0; txLevel < deviceCaps.txSteps; txLevel++)
				{
					int dBm = deviceCaps.maxTxdBm - (txLevel * deviceCaps.txAttnStep);
					int mW = 0;
					if (txLevel == 0)
						mW = deviceCaps.maxTxmW;
					else
						mW = (int)Math.Round(Math.Pow(10, (double)dBm / 10));
					TxLevelSel.Items.Add(string.Format("{0} dBm / {1} mW", dBm, mW));
				}
				TxLevelSel.Enabled = true;
				TxLevelSel.SelectedIndex = hNur.TxLevel;
			}
			catch (Exception e)
			{
				TxLevelSel.Items.Add(e.Message);
				TxLevelSel.Enabled = false;
			}

			// Set all per antenna TX levels to follow the main TX level
			int[] antennaPower = hNur.AntennaPower;
			for (int i = 0; i < antennaPower.Length; i++)
				antennaPower[i] = -1;
			int[] antennaPowerEx = hNur.AntennaPowerEx;
			for (int i = 0; i < antennaPowerEx.Length; i++)
				antennaPowerEx[i] = -1;

			disableEvents--;
		}

		private void physAntListView_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			if (disableEvents > 0)
				return;

			try
			{
				string physAnt = e.Item.Text;
				if (e.Item.Checked)
				{
					hNur.EnablePhysicalAntenna(physAnt);
				}
				else
				{
					hNur.DisablePhysicalAntenna(physAnt);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			UpdatePhysAntListView();
		}

		void FillPhysAntListView()
		{
			disableEvents++;
			try
			{
				physAntListView.Items.Clear();
				physAntListView.Items.Add(new ListViewItem("ALL"));
				foreach (string physAnt in hNur.AvailablePhysicalAntennas)
				{
					physAntListView.Items.Add(new ListViewItem(physAnt));
				}
				//columnHeader_Antenna.Width = -2;
				physAntListView.Enabled = true;
			}
			catch (Exception e)
			{
				physAntListView.Items.Add(new ListViewItem(e.Message));
				physAntListView.Enabled = false;
			}
			disableEvents--;
			UpdatePhysAntListView();
		}

		private void UpdatePhysAntListView()
		{
			if (physAntListView.Enabled)
			{
				try
				{
					for (int n = 0; n < physAntListView.Items.Count; n++)
					{
						string physAnt = physAntListView.Items[n].Text;
						if (hNur.IsPhysicalAntennaEnabled(physAnt))
						{
							physAntListView.Items[n].Checked = true;
						}
						else
						{
							physAntListView.Items[n].Checked = false;
						}
					}
					hNur.SelectedAntenna = NurApi.ANTENNAID_AUTOSELECT;
				}
				catch (Exception ex)
				{
					if (hNur.GetMode() == 'A')
						MessageBox.Show(ex.Message);
				}
			}
		}

		private void ModuleSetup_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (disableEvents > 0)
				return;

			try
			{
				if (sender == TxLevelSel)
					hNur.TxLevel = TxLevelSel.SelectedIndex;
				else if (sender == ModulationSel)
					hNur.TxModulation = ModulationSel.SelectedIndex;
				else if (sender == InvQSel)
					hNur.InventoryQ = InvQSel.SelectedIndex;
				else if (sender == InvRoundsSel)
					hNur.InventoryRounds = InvRoundsSel.SelectedIndex;
				else if (sender == InvSessionSel)
					hNur.InventorySession = InvSessionSel.SelectedIndex;
				else if (sender == InvTargetSel)
					hNur.InventoryTarget = InvTargetSel.SelectedIndex;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			UpdatePhysAntListView();
		}

		private void ModuleSetupToControls()
		{
			disableEvents++;
			// TX
			TxLevelSel.SelectedIndex = hNur.TxLevel;
			ModulationSel.SelectedIndex = hNur.TxModulation;

			// Inventory
			InvQSel.SelectedIndex = hNur.InventoryQ;
			InvRoundsSel.SelectedIndex = hNur.InventoryRounds;
			InvSessionSel.SelectedIndex = hNur.InventorySession;
			InvTargetSel.SelectedIndex = hNur.InventoryTarget;
			disableEvents--;
		}
	}
}
