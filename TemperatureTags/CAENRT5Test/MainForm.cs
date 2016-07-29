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
using System.Threading;

using System.IO;

using NurApiDotNet;
using CAENRT0005;

namespace CAENRT5Test
{
	public partial class MainForm : Form
	{
		NurApi hNur;
		bool mBusy = false;

		bool mSamplesPresent = false;
		private RTConst.SAMPLEDATA mCurSamples;

		private const bool TAG_INACTIVE = false;
		private const bool TAG_ACTIVE = true;
		private const bool GET_DELAYTIME = true;
		private const bool GET_SAMPLETIME = false;

		private const bool TAG_PRESENT = true;
		private const bool NO_TAG = false;
		private const bool LOGGING = true;
		private const bool NOT_LOGGING = false;

		private Thread mScanThread = null;

		private RT0005Tag mTag = null;

		private int mTryCount = 10;

		private bool mSecured = false;
		private uint mPassword = 0;

		private delegate void DownloadDelegate();
		private DownloadDelegate mDownload;
		private bool mAutoDownload = false;

		int mAntennasAvailable = 0;

		public MainForm()
		{
			InitializeComponent();

			ScanBtn.Enabled = false;
			AntennaBtn.Enabled = false;
			RefreshBtn.Enabled = false;

			DelaySel.SelectedIndex = 1;
			IntvalSel.SelectedIndex = 0;

			TxModSel.SelectedIndex = 0;
			GetSetupBtn.Enabled = false;
			SetSetupBtn.Enabled = false;

			CreateInvokers();

			hNur = new NurApi(this);

			hNur.ConnectedEvent += new EventHandler<NurApi.NurEventArgs>(OnModuleConnect);
			hNur.DisconnectedEvent += new EventHandler<NurApi.NurEventArgs>(OnModuleDisconnect);

			_SetControlText(ConnLabel, "Not connected");
			_SetControlColor(ConnLabel, RED, BLACK);
			_SetControlText(TagLabel, "No tag");
			_SetControlColor(TagLabel, RED, BLACK);

			ConnGrp.Text = "Connection (" + NurApi.FileVersion + ", " + hNur.GetFileVersion() + ")";

			StatesNotAvailable(false);

			mDownload = new DownloadDelegate(DownloadAndShow);

			hNur.SetUsbAutoConnect(true);
		}

		void mTag_ProgressEvent(object sender, RTProgressEvent e)
		{
			if (e.reset)
				ScanProgress.Value = 0;
			else if (e.step == false)
				_ProgressInit(ScanProgress, e.min, e.max, 1);
			else
				_ProgressStep(ScanProgress);
		}

		void OnModuleDisconnect(object sender, NurApi.NurEventArgs e)
		{
			CSVExpBtn.Enabled = false;
			HandleReaderDisconnect();
		}

		void OnModuleConnect(object sender, NurApi.NurEventArgs e)
		{
			mAutoDownload = AutoDlChk.Checked;
			mAntennasAvailable = 0;
			HandleReaderConnect();
		}

		void TrySetDefaults()
		{
			NurApi.ModuleSetup setup;

			try
			{
				setup = hNur.GetModuleSetup();
				setup.txLevel = 3;
				setup.rxDecoding = NurApi.RXDECODING_M4;
				setup.linkFreq = 256000;

				hNur.SetModuleSetup(NurApi.SETUP_LINKFREQ | NurApi.SETUP_RXDEC | NurApi.SETUP_TXLEVEL, ref setup);
			}
			catch 
			{ 
				/* ... */
			}
		}

		void TrySetSettings()
		{
			NurApi.ModuleSetup setup = new NurApi.ModuleSetup();

			setup.txLevel = TxLevelSel.SelectedIndex;
			setup.txModulation = TxModSel.SelectedIndex;
			try
			{
				hNur.SetModuleSetup(NurApi.SETUP_TXLEVEL | NurApi.SETUP_TXMOD, ref setup);
			}
			catch
			{
				/* ... */
			}
		}

		void TryGetSettingsAndInfo()
		{
			NurApi.ModuleSetup setup;
			NurApi.DeviceCapabilites dc;

			mAntennasAvailable = 0;
			setup.txLevel = TxLevelSel.SelectedIndex;
			setup.txModulation = TxModSel.SelectedIndex;

			try
			{
				setup = hNur.GetModuleSetup(NurApi.SETUP_TXLEVEL | NurApi.SETUP_TXMOD);
				TxLevelSel.SelectedIndex = setup.txLevel;
				TxModSel.SelectedIndex = setup.txModulation;
			}
			catch
			{
				/* ... */
			}

			try
			{
				dc = hNur.GetDeviceCaps();
				mAntennasAvailable = dc.maxAnt;
			}
			catch
			{
				/* ... */
			}
		}

		void TryGetAPIInfo()
		{
			string capt = "CAEN RT0005 test";
			try
			{
				capt += (" (API: " + hNur.GetFileVersion() + ", .NET API: " + NurApi.FileVersion + ")");
			}
			catch
			{

			}

			this.Text = capt;
		}

		void ClearTxLevels()
		{
			TxLevelSel.Items.Clear();
			TxLevelSel.Enabled = false;			
		}

		void PopulateTxLevel(ComboBox cmb)
		{
			bool oneWattDevice = false;
			string s = "";
			double i, power, value, powerTop;
			string strFirst = oneWattDevice ? "0: 1W" : "0: 500mW";

			try
			{
				NurApi.DeviceCapabilites dc;
				dc = hNur.GetDeviceCaps();

				if (dc.maxTxmW > 500)
					oneWattDevice = true;
			}
			catch { }
			
			powerTop = oneWattDevice ? 30 : 27;

			cmb.DropDownStyle = ComboBoxStyle.DropDownList;
			cmb.Items.Clear();

			for (i = 0; i <= 19; i += 1.0)
			{
				if (i == 0)
				{
					cmb.Items.Add(strFirst);
				}
				else
				{
					power = (powerTop - i) / 10;
					value = Math.Round(Math.Pow(10, power));

					s = ((int)i).ToString() + ": " + value.ToString() + " mW";
					cmb.Items.Add(s);
				}
			}
			cmb.SelectedIndex = 0;
			TxLevelSel.Enabled = true;
		}

		private void TryGetTagState()
		{
			if (!mBusy)
			{
				mBusy = true;
				int tmp;
				bool logging;
				bool savedAsync = mAsyncUpdate;
				
				logging = false;

				HandleBinStateGroup(true, false, false);

				try
				{
					logging = mTag.Logging;
					HandleBinStateGroup(true, true, logging);					
				}
				catch (Exception e)
				{
					SetControlColor(LoggingLabel, RED, BLACK);
					if (e is NurApiException)
						SetControlText(LoggingLabel, "Logging: error " + ((NurApiException)e).error);
					else
						SetControlText(LoggingLabel, "Logging: error");

				}

				try
				{
					tmp = mTag.SampleCount;
					SetControlColor(SamplesLabel, GREEN, BLACK);
					SetControlText(SamplesLabel, "Samples: " + tmp);
				}
				catch (Exception e)
				{
					SetControlColor(SamplesLabel, RED, BLACK);
					if (e is NurApiException)
						SetControlText(SamplesLabel, "Samples: error " + ((NurApiException)e).error);
					else
						SetControlText(SamplesLabel, "Samples: error");
				}

				try
				{
					tmp = mTag.SamplingDelay;
					SetControlColor(DelayLabel, GREEN, BLACK);
					SetControlText(DelayLabel, GetTimeStrFromSec("Delay", tmp));
				}
				catch (Exception e)
				{
					if (e is NurApiException)
						SetControlText(DelayLabel, "Delay: error " + ((NurApiException)e).error);
					else
						SetControlText(DelayLabel, "Delay: error");
				}

				try
				{
					tmp = mTag.BINSampleTime[0];
					SetControlColor(IntvalLabel, GREEN, BLACK);
					SetControlText(IntvalLabel, GetTimeStrFromSec("Interval", tmp));
				}
				catch (Exception e)
				{
					if (e is NurApiException)
						SetControlText(IntvalLabel, "Interval: error " + ((NurApiException)e).error);
					else
						SetControlText(IntvalLabel, "Interval: error");
				}

				try
				{
					if (mTag.Alarms)
						SetControlColor(ViewRegsBtn, RED, BLACK);
					else
						SetControlColor(ViewRegsBtn, CTLCOLOR, BLACK);
				}
				catch
				{
					SetControlColor(ViewRegsBtn, CTLCOLOR, BLACK);
				}

				ControlEnable(RefreshBtn, true);
				ControlEnable(DnLoadBtn, true);
				
				mBusy = false;

				HandleLogSetupGroup(hNur.IsConnected(), logging);
			}
			else
				throw new RTException("Internal error getting state; busy.");
		}

		private string GetTimeStrFromSec(string pref, int timeVal)
		{
			int hh, mm, ss;

			if (timeVal == 0)
			{
				return pref + ": (none)";
			}

			hh = timeVal / 3600;
			mm = (timeVal % 3600) / 60;
			ss = timeVal % 60;

			if (pref != "")
				return pref + ": " + hh.ToString("D2") + ":" + mm.ToString("D2") + ":" + ss.ToString("D2");
			return hh.ToString("D2") + ":" + mm.ToString("D2") + ":" + ss.ToString("D2");
		}

		private void TempTagReady(bool present, byte []epc)
		{
			if (present)
			{
				ControlState(TagLabel, STATE_OK, "Tag: " + NurApi.BinToHexString(epc));
				TryGetTagState();

				if (mAutoDownload)
				{
					mBusy = false;
					BeginInvoke(mDownload);
					mAutoDownload = false;
				}
			}
			else
			{
				ControlState(TagLabel, STATE_NA, "No tag");				
			}
			//HandleTagScanGroup(hNur.IsConnected());
		}

		void FindThread()
		{
			int scanRound;
			bool possiblyFound;
			NurApi.TriggerReadData rd;
			byte[] epc;
			NurApi.Tag theTag; 
			byte[] testData;

			int startTime, execTime;

			startTime = 0;

			possiblyFound = false;
			mTag = null;

			execTime = 0;
			epc = null;

			mAsyncUpdate = false;			
			ControlState(TagLabel, STATE_RUN, "Scanning...");
			ControlEnable(ScanBtn, false);
			ControlEnable(AntennaBtn, false);			
			HandleBinStateGroup(true, NO_TAG, NOT_LOGGING);

			mAsyncUpdate = true;
			ProgressInit(ScanProgress, 0, mTryCount, 1);

			for (scanRound = 0; scanRound < mTryCount && !possiblyFound; scanRound++)
			{				
				ProgressStep(ScanProgress);
				try
				{
					startTime = System.Environment.TickCount;
					rd = hNur.ScanSingle(500);
					execTime = System.Environment.TickCount - startTime;					

					epc = new byte[rd.epcLen];
					System.Array.Copy(rd.epc, epc, rd.epcLen);

					ControlState(TagLabel, STATE_RUN, "Verify...");

					testData = hNur.ReadTagByEPC(mPassword, mSecured, epc, NurApi.BANK_PASSWD, RTConst.PASSWD_EXTRA_ADDR, RTConst.NR_PASSWD_EXTRA_BYTES);
					
					/* Guess that this is OK tag. */
					possiblyFound = (testData != null && testData.Length == RTConst.NR_PASSWD_EXTRA_BYTES);
					if (possiblyFound)
					{
						theTag = new NurApi.Tag();
						theTag.hApi = hNur;
						theTag.epc = new byte[rd.epcLen];
						System.Array.Copy(rd.epc, theTag.epc, rd.epcLen);
						
						theTag.antennaId = (byte)rd.antennaID;
						theTag.channel = 0;
						theTag.frequency = 0;	// Huh.

						mTag = new RT0005Tag(hNur, theTag);

						mTag.ProgressEvent += new EventHandler<RTProgressEvent>(mTag_ProgressEvent);						
					}
				}
				catch (Exception e)
				{
					if (e is NurApiException && ((NurApiException)e).error == NurApiErrors.NUR_ERROR_TR_NOT_CONNECTED)
						break;

					if (execTime < 500)
						System.Threading.Thread.Sleep(500 - execTime);

					ControlState(TagLabel, STATE_RUN, "Scanning...");
				}
			}

			while (scanRound < mTryCount)
			{
				scanRound++;
				ProgressStep(ScanProgress);
			}

			mBusy = false;

			ControlEnable(ScanBtn, hNur.IsConnected());
			ControlEnable(AntennaBtn, hNur.IsConnected());			

			ProgressInit(ScanProgress, 0, mTryCount, 1);

			mScanThread = null;			

			TempTagReady(possiblyFound, epc);
		}

		void FindTag()
		{
			if (!mBusy)
			{
				mBusy = true;
				ThreadStart thStart;

				mSamplesPresent = false;
				mCurSamples.values = null;

				thStart = new ThreadStart(FindThread);
				mScanThread = new Thread(thStart);

				mScanThread.Start();
			}
			
		}

		private void QuitBtn_Click(object sender, EventArgs e)
		{
			if (!mBusy)
				Close();
		}

		private void StartBtn_Click(object sender, EventArgs e)
		{
			mAutoDownload = AutoDlChk.Checked;
			FindTag();
		}

		private void RefreshBtn_Click(object sender, EventArgs e)
		{
			if (!mBusy && mTag != null)
			{
				TryGetTagState();
			}
		}

		void HandleReaderConnect()
		{
			ControlEnable(GetSetupBtn, true);
			ControlEnable(SetSetupBtn, true);
			ControlEnable(ScanBtn, true);
			ControlEnable(AntennaBtn, true);
			ControlEnable(RefreshBtn, false);

			SetControlText(ConnLabel, "Connected");
			SetControlColor(ConnLabel, GREEN, BLACK);

			PopulateTxLevel(TxLevelSel);

			TrySetDefaults();
			TryGetSettingsAndInfo();
			TryGetAPIInfo();

			if (AutoFindChk.Checked)
			{
				FindTag();
			}
			else
				HandleBinStateGroup(true, false, false);
		}

		void HandleReaderDisconnect()
		{
			mSamplesPresent = false;
			mCurSamples.values = null;

			ControlEnable(GetSetupBtn, false);
			ControlEnable(SetSetupBtn, false);
			ControlEnable(ScanBtn, false);
			ControlEnable(AntennaBtn, false);			
			ControlEnable(RefreshBtn, false);

			SetControlText(ConnLabel, "Not connected");
			SetControlColor(ConnLabel, RED, BLACK);
			SetControlText(TagLabel, "No tag");
			SetControlColor(TagLabel, RED, BLACK);

			HandleTagScanGroup(false);
			HandleBinStateGroup(false, false, false);
			HandleLogSetupGroup(false, false);
			HandleLogSampleGroup(false, false);

			ClearTxLevels();

			if (mBusy)
			{
				try
				{
					mScanThread.Join(1000);
				}
				catch
				{
					/* ... */
				}
			}
		}

		private void HandleTagScanGroup(bool connected)
		{
			ControlEnable(ScanBtn, connected);
			ControlEnable(AntennaBtn, connected);			
		}

		private void HandleBinStateGroup(bool connected, bool tagPresent, bool isLogging)
		{
			SetControlColor(ViewRegsBtn, CTLCOLOR, BLACK);
			if (!connected || !tagPresent)
			{				
				ControlEnable(RefreshBtn, false);
				ControlEnable(ViewRegsBtn, false);				

				ControlState(LoggingLabel, STATE_NA, "Logging N/A");
				ControlState(SamplesLabel, STATE_NA, "Samples N/A");
				ControlState(DelayLabel, STATE_NA, "Delay N/A");
				ControlState(IntvalLabel, STATE_NA, "Interval N/A");
			}
			else 
			{
				int state = isLogging ? STATE_RUN : STATE_OK;
				ControlEnable(RefreshBtn, true);
				ControlEnable(ViewRegsBtn, true);

				ControlState(LoggingLabel, state, isLogging ? "Logging" : "Not logging");
				ControlState(SamplesLabel, state, "");
				ControlState(DelayLabel, state, "");
				ControlState(IntvalLabel, state, "");
			}
		}

		private void HandleLogSetupGroup(bool isConnected, bool isLogging)
		{
			if (!isConnected)
			{
				ControlEnable(LogCtlBtn, false);
				ControlText(LogCtlBtn, "Start logging");
			}
			else
			{
				ControlEnable(LogCtlBtn, true);
				if (isLogging)
					ControlText(LogCtlBtn, "Stop logging");
				else
					ControlText(LogCtlBtn, "Start logging");

			}
		}

		private void HandleLogSampleGroup(bool connected, bool isLogging)
		{
			ControlEnable(DnLoadBtn, connected);
		}

		void StatesNotAvailable(bool async)
		{
			if (async)
			{
				ControlState(ConnLabel, STATE_NA, "");
				ControlState(TagLabel, STATE_NA, "");
				ControlState(LoggingLabel, STATE_NA, "");
				ControlState(SamplesLabel, STATE_NA, "");
				ControlState(DelayLabel, STATE_NA, "");
				ControlState(IntvalLabel, STATE_NA, "");
			}
			else
			{
				_ControlState(ConnLabel, STATE_NA, "");
				_ControlState(TagLabel, STATE_NA, "");
				_ControlState(LoggingLabel, STATE_NA, "");
				_ControlState(SamplesLabel, STATE_NA, "");
				_ControlState(DelayLabel, STATE_NA, "");
				_ControlState(IntvalLabel, STATE_NA, "");
			}
		}

		private void LogCtlBtn_Click(object sender, EventArgs e)
		{
			ControlLogging();
		}

		private RTConst.LOGINTERVAL GetTimeSel(bool delay)
		{
			int sel;

			if (delay)
				sel = DelaySel.SelectedIndex;
			else
				sel = IntvalSel.SelectedIndex + 1;

			switch (sel)
			{
				case 0: return RTConst.LOGINTERVAL.INT_NONE;
				case 1: return RTConst.LOGINTERVAL.INT_1MIN;
				case 2: return RTConst.LOGINTERVAL.INT_2MIN;
				case 3: return RTConst.LOGINTERVAL.INT_5MIN;
				case 4: return RTConst.LOGINTERVAL.INT_15MIN;
				case 5: return RTConst.LOGINTERVAL.INT_30MIN;
				default: break;

			}

			return RTConst.LOGINTERVAL.INT_1HR;
		}

		void ControlLogging()
		{
			RTConst.LOGINTERVAL delay;
			RTConst.LOGINTERVAL intVal;
			bool isLogging = false;

			
			if (!mBusy)
			{				
				mBusy = true;

				try
				{
					isLogging = mTag.Logging;
				}
				catch (Exception e)
				{
					MessageBox.Show("Internal error: cannot get current logging state.\n\n" + e.Message);
					mBusy = false;
					return;
				}

				if (isLogging)
				{
					try
					{						
						mTag.Logging = false;
						mBusy = false;
						TryGetTagState();
						return;
					}
					catch (Exception e)
					{
						MessageBox.Show("Internal error: logging stop failed!\n\n" + e.Message);
						mBusy = false;						
						return;
					}
				}


				/* int yy, mm, dd, hh, min, ss;
				yy = DateTime.Now.Year;
				mm = DateTime.Now.Month;
				dd = DateTime.Now.Day;
				hh = DateTime.Now.Hour;
				min = DateTime.Now.Minute;
				ss = DateTime.Now.Second;
				int iTemp;

				//DateTime dt = new DateTime(yy, mm, dd, hh, min, ss, DateTimeKind.Utc);
				//DateTime dt = new DateTime(yy, mm, dd, hh, min, ss);
				DateTime firstTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
				TimeSpan span = DateTime.Now - firstTime;

				iTemp = (int)span.TotalSeconds;
				
				MessageBox.Show("UTC val: " + iTemp); */
				
				delay = GetTimeSel(GET_DELAYTIME);
				intVal = GetTimeSel(GET_SAMPLETIME);

				try
				{
					mTag.StartSimpleLog(delay, intVal);
				}
				catch (Exception e)
				{
					if (e is NurApiException)
					{
						MessageBox.Show("API exception:\n\n" + e.Message);
					}
					else if (e is RTException)
					{
						MessageBox.Show("RT0005 exception:\n\n" + e.Message);
					}
					else
					{
						MessageBox.Show("Unexpected exception:\n\n" + e.Message);
					}
				}

				mBusy = false;
				
				TryGetTagState();
			}
			else
				throw new RTException("Internal error upon log start; busy!");
		}

		private void ViewRegsBtn_Click(object sender, EventArgs e)
		{
			if (!mBusy && hNur.IsConnected() && mTag != null)
			{
				mBusy = true;
				(new RTRegsForm(hNur, mTag)).ShowDialog();
				mBusy = false;
			}
		}

		private void ReadProgressInit(int min, int max)
		{
			ProgressInit(ScanProgress, min, max, 1);
		}

		private void ReadProgressStep()
		{
			ProgressStep(ScanProgress);
		}

		private void DownloadAndShow()
		{
			bool doRead = false;
			bool ok = false;

			if (!mBusy && hNur.IsConnected())
			{
				mBusy = true;
				ControlEnable(CSVExpBtn, false);
				if (mSamplesPresent && mCurSamples.values != null && mCurSamples.values.Length > 0)
				{
					if (MessageBox.Show("There are currently samples present.\nDo you want to read the samples again?", "Sample read",
						MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						doRead = true;
					}
				}
				else
					doRead = true;

				try
				{
					// Using antenna ID guarantees that the best antenna is used if there are several.
					if (doRead)
						mCurSamples = mTag.GetSamples(mTag.antennaId);

					ok = true;
					mSamplesPresent = true;

				}
				catch (Exception e)
				{
					string xMsg = "General ";

					if (e is NurApiException)
						xMsg = "API ";

					MessageBox.Show(xMsg + "error when reading samples:\n\n" + e.Message);
				}

				if (ok)
				{
					int i = 0;
					int endX;
					System.Windows.Forms.DataVisualization.Charting.DataPoint dp;
					System.Windows.Forms.DataVisualization.Charting.Series tempSeries = new System.Windows.Forms.DataVisualization.Charting.Series();					
					SampleChart.Series["Temperature"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
					SampleChart.Series["Temperature"].Points.Clear();
					SampleChart.Series["Temperature"].Color = RED;
					SampleChart.Series["Temperature"].BorderWidth = 3;
					SampleChart.Series["Temperature"].BorderColor = RED;
					
					//SampleChart.ChartAreas["TempArea"].AxisY.Minimum = RTConst.MIN_TEMP - 2;
					//SampleChart.ChartAreas["TempArea"].AxisY.Maximum = RTConst.MAX_TEMP + 2;
					SampleChart.ChartAreas["TempArea"].AxisY.Minimum = mCurSamples.min - 2;
					SampleChart.ChartAreas["TempArea"].AxisY.Maximum = mCurSamples.max + 2;

					SampleChart.ChartAreas["TempArea"].AxisX.Minimum = 0;
					
					endX = mCurSamples.values.Length;

					if ((endX % 100) != 0)
						endX = ((endX / 100) * 100) + 100;

					SampleChart.ChartAreas["TempArea"].AxisX.Maximum = endX;
					//SampleChart.ChartAreas["TempArea"].AxisX.Maximum = mCurSamples.values.Length;
					SampleChart.ChartAreas["TempArea"].AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.FixedCount;
					
					foreach (double d in mCurSamples.values)
					{
						dp = new System.Windows.Forms.DataVisualization.Charting.DataPoint(i++, d);
						SampleChart.Series["Temperature"].Points.Add(dp);
					}

					ControlEnable(CSVExpBtn, true);
				}

				mBusy = false;
			}

		}

		private void DnLoadBtn_Click(object sender, EventArgs eArgs)
		{
			DownloadAndShow();
		}

		private void CSVExpBtn_Click(object sender, EventArgs eArgs)
		{
			if (mSamplesPresent && mCurSamples.values != null && mCurSamples.values.Length > 0)
			{
				//List<string> strClipboard = new List<string>();
				string strClipboard = "";
				bool useTime = false;
				int i;
				int intValSec = 0;
				int curTimeSec = 0;
				SaveFileDialog dlg;
				StreamWriter wr;
				string fileName = "";
				string line = "";
				string dString = "";

				try
				{
					intValSec = mTag.BINSampleTime[0];
					curTimeSec = mTag.SamplingDelay;
					useTime = true;
				}
				catch
				{
					if (MessageBox.Show("Could not get the time values from the tag; OK to continue?", "Time not available", MessageBoxButtons.YesNo) == DialogResult.No)
						return;
				}

				dlg = new SaveFileDialog();
				dlg.Filter = "CSV-files|*.csv";

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fileName = dlg.FileName;

					try
					{
						wr = new StreamWriter(fileName, false);
					}
					catch (Exception e)
					{
						MessageBox.Show("File open/creation error:\n\n" + e.Message);
						return;
					}

					i = 0;

					if (useTime)
					{
						strClipboard += ("Time\tTemperature\n");
						wr.WriteLine("Time;Temperature");
					}
					else
					{
						strClipboard += ("Sample number\tTemperature\n");
						wr.WriteLine("Sample number;Temperature");
					}


					foreach (double d in mCurSamples.values)
					{
						dString = string.Format("{0:0.00}", d);
						if (useTime)
						{
							line = GetTimeStrFromSec("", curTimeSec);
							curTimeSec += intValSec;
						}
						else
						{
							line = i.ToString();
						}

						strClipboard += (line + "\t" + dString + "\n");
						line += (";" + dString);
						
						wr.WriteLine(line);
					}

					wr.Close();

					Clipboard.Clear();
					Clipboard.SetText(strClipboard);

					MessageBox.Show("Exported " + mCurSamples.values.Length + " samples to\n" + fileName + "\n\n" + "The CSV formatted data can be pasted also from the clipboard.");
				}
			}
			else
				MessageBox.Show("Export: nothing to export.");
		}

		private void AntennaBtn_Click(object sender, EventArgs e)
		{
			if (mBusy)
				return;

			if (mAntennasAvailable == 1)
				MessageBox.Show("Only one antenna available; no need to configure / select.");
			else
			{
				AntennaDlg dlg = new AntennaDlg(hNur);
				dlg.ShowDialog(this);
			}
		}
	}

	public class ScanEvent : EventArgs
	{

	}
}

