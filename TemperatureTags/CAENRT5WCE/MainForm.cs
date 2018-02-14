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

namespace CAENRT5WCE
{
	public partial class MainForm : Form
	{
		NurApi hNur;
		private bool mBusy = false;
		private CAENRT0005.RT0005Tag mTag = null;
		public uint mPassword = 0;
		public bool mSecured = false;
		private Thread mScanThread = null;

		// Set to false to allow decimal in "x.yz" format instead of "x,yz".
		private bool mDecimalComma = true;

		// Sample download max progress value.
		private int mDownloadMaxVal = 0;
		// Sample download current progress.
		private int mDownloadCurPtr = 0;

		// Number of times to try.
		private const int SCAN_ROUNDS = 10;
		// Milliseconds.
		private const int SCANTIME = 500;
		// To interrupt the scanning thread
		private bool mInterrupted = false;

		private const int JOIN_TIME = (SCAN_ROUNDS * SCANTIME + 50);

		public delegate void ControlTextDelegate(Control c, string s);
		public ControlTextDelegate mControlText;

		public delegate void TagFoundDelegate();
		public TagFoundDelegate mTagFoundDelegate;
		
		public void _ControlText(Control c, string s)
		{
			c.Text = s;
		}

		public void ControlText(Control c, string s)
		{
			Invoke(mControlText, c, s);
		}

		void CenterWindow()
		{
			this.Location = new Point(
				Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2,
				Screen.PrimaryScreen.WorkingArea.Height / 2 - this.Height / 2);
		}


		public MainForm()
		{
			InitializeComponent();

			hNur = new NurApi(this);

			try
			{				
				hNur.ConnectedEvent += new EventHandler<NurApi.NurEventArgs>(hNur_ConnectedEvent);
				hNur.DisconnectedEvent += new EventHandler<NurApi.NurEventArgs>(hNur_DisconnectedEvent);
				hNur.ConnectIntegratedReader();				
			}
			catch (NurApiException e)
			{
				MessageBox.Show("Internal error, the reader is not found.\n\n" + e.Message);
				StatusText.Text = "No reader present";
			}

			mControlText = new ControlTextDelegate(_ControlText);
			mTagFoundDelegate = new TagFoundDelegate(ShowFoundTag);

			CenterWindow();
		}

		private bool WaitScanEnd()
		{
			if (mScanThread != null)
			{
				try
				{
					mScanThread.Join(JOIN_TIME);
				}
				catch
				{
					return false;
				}
			}
			return true;
		}

		void hNur_DisconnectedEvent(object sender, NurApi.NurEventArgs e)
		{
			EnableControls(false);
		}

		void hNur_ConnectedEvent(object sender, NurApi.NurEventArgs e)
		{
			EnableControls(true);
			TrySetDefaults();
			try
			{
				StatusText.Text = hNur.GetReaderInfo().GetVersionString();
			}
			catch { }
		}

		private void TrySetDefaults()
		{
			try
			{
				hNur.TxLevel = 5;
				hNur.RxDecoding = NurApi.RXDECODING_M4;
				hNur.LinkFrequency = 256000;
			}
			catch
			{
				/* ... */
			}
		}

		private void EnableControls(bool en)
		{
			ScanTagBtn.Enabled = en;
			ControlBtn.Enabled = en;
			StopBtn.Enabled = en;
			DnloadBtn.Enabled = en;
		}

		private void ScanTagThread()
		{
			int i;
			NurApi.TriggerReadData trg;
			bool tagFound = false;
			byte[] testData;
			NurApi.Tag tag;
			int epcLength = 0;
			byte[] epc = null;

			mTag = null;

			for (i = 0; i < SCAN_ROUNDS && !mInterrupted && !tagFound; i++)
			{
				tagFound = false;
				ControlText(StatusText, "Scan: " + (i+1).ToString() + " / " + SCAN_ROUNDS);
				try
				{
					trg = hNur.ScanSingle(SCANTIME);
					epcLength = trg.epcLen;
					epc = new byte[epcLength];
					System.Array.Copy(trg.epc, epc, epcLength);
					tagFound = true;
				}
				catch (NurApiException e)
				{
					if (e.error == NurApiErrors.NUR_ERROR_TR_NOT_CONNECTED)
					{
						mBusy = false;
						return;
					}
				}

				if (tagFound)
				{
					try
					{
						tag = new NurApi.Tag(hNur);
						tag.epc = new byte[epcLength];
						System.Array.Copy(epc, tag.epc, epcLength);

						testData = hNur.ReadTag(mPassword, mSecured, NurApi.BANK_PASSWD, RTConst.PASSWD_EXTRA_ADDR, RTConst.NR_PASSWD_EXTRA_BYTES);

						mTag = new RT0005Tag(hNur, tag);
						mBusy = false;
						mInterrupted = false;
						ControlText(StatusText, "Tag found, ready.");
						mBusy = false;
						BeginInvoke(mTagFoundDelegate);						
					}
					catch 
					{
						tagFound = false;
					}
				}
			}

			if (!tagFound)
				ControlText(StatusText, "No tag found.");

			mBusy = false;
			mInterrupted = false;
		}

		private void FindTag()
		{
			mBusy = true;
			mScanThread = new Thread(new ThreadStart(ScanTagThread));
			mScanThread.Start();
		}

		bool GetLogging(ref bool isLogging)
		{
			int retry = 3;

			while (retry > 0)
			{
				try
				{
					isLogging = mTag.Logging;
					return true;
				}
				catch
				{
					System.Threading.Thread.Sleep (50);
					retry--;
				}
			}

			return false;
		}

		bool GetRegister(uint reg, ref ushort regResult)
		{
			int retry = 3;

			while (retry > 0)
			{
				try
				{
					regResult = mTag.ReadShortReg(reg);
					return true;
				}
				catch
				{
					System.Threading.Thread.Sleep(50);
					retry--;
				}
			}

			return false;
		}

		private void ShowFoundTag()
		{
			if (mTag != null)
			{
				bool bLogging = false;
				bool bLoggingRead = false;
				ushort wInterval = 0;
				bool bIsInterval = false;

				ushort wSampleCount = 0;
				bool bIsSampleCount = false;

				string strInterval = "";
				string msg = "";

				bLoggingRead = GetLogging(ref bLogging);
				bIsInterval = GetRegister(RTRegs.BIN_SAMPLETIME_BASE, ref wInterval);
				bIsSampleCount = GetRegister(RTRegs.SAMPLES_NUM, ref wSampleCount);

				msg = "Tag status:\nLogging: ";
				if (!bLoggingRead)
					msg += "N/A";
				else if (bLogging)
					msg += "YES";
				else
					msg += "NO";

				msg += "\n";

				msg += "Interval: ";
				if (bIsInterval)
					msg += strInterval;
				else
					msg += "N/A";
				msg += "\n";

				msg += "Samples: ";
				if (bIsSampleCount)
					msg += wSampleCount.ToString();
				else
					msg += "N/A";
				msg += "\n";

				mBusy = false;

				MessageBox.Show(msg);
			}

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

		private void StatusBtn_Click(object sender, EventArgs e)
		{
			if (mBusy == false)
			{
				mBusy = true;
				FindTag();
			}
		}

		private void QuitBtn_Click(object sender, EventArgs e)
		{
			if (!mBusy)
			{
				try
				{
					hNur.Disconnect();
				}
				catch { }

				Close();
			}
		}

		private void DoDownload()
		{
			int execTime;
			StreamWriter wr;
			int i;
			bool ok;
			int nSamples;

			string fname = "\\RT0005log_";
			DateTime dt = DateTime.Now;
			fname += dt.Hour.ToString("D2");
			fname += dt.Minute.ToString("D2");
			fname += dt.Second.ToString("D2");
			fname += ".csv";

			try
			{
				wr = new StreamWriter(fname, false);
			}
			catch
			{
				MessageBox.Show("Could not create:\n\n" + fname);
				mBusy = false;
				return;
			}

			ok = false;
			nSamples = 0;
			execTime = 0;

			try
			{
				RTConst.SAMPLEDATA samples;
				string decString = "";

				ControlText(StatusText, "Downloading...");
				
				mTag.ProgressEvent += new EventHandler<RTProgressEvent>(mTag_ProgressEvent);
				execTime = System.Environment.TickCount;

				samples = mTag.GetSamples();
				execTime = System.Environment.TickCount - execTime;

				nSamples = samples.values.Length;

				i = 0;				
				foreach (double d in samples.values)
				{
					decString = string.Format("{0:0.00}", d);
					if (mDecimalComma)
						decString = decString.Replace('.', ',');
					else
						decString = decString.Replace(',', '.');
					wr.WriteLine(i.ToString() + ";" + decString);
					i++;
				}
				ok = true;

			}
			catch (Exception e)
			{
				MessageBox.Show("Sample download error:\n\n" + e.Message);
			}

			wr.Close();

			if (ok)
			{
				string timeStr = "";
				timeStr = "\n\nAppr. duration " + string.Format("{0}.{1:D3}", execTime / 1000, execTime % 1000) + " seconds";

				MessageBox.Show(nSamples.ToString() + " samples were written to\n" + fname + timeStr);
			}

			mBusy = false;
			ControlText(StatusText, "Ready");
		}

		private void DnloadBtn_Click(object sender, EventArgs e)
		{
			if (!mBusy)
			{
				if (mTag == null)
				{
					MessageBox.Show("No tag has been scanned.");
				}
				else
				{
					mBusy = true;
					/* Thread is able to give feedback about the progress. */
					(new Thread(new ThreadStart(DoDownload))).Start();
				}
			}
		}

		void mTag_ProgressEvent(object sender, RTProgressEvent e)
		{
			if (!e.reset && !e.step)
			{
				// Init.
				mDownloadCurPtr = 0;
				mDownloadMaxVal = e.max;
				return;
			}

			if (e.reset)
			{
				mDownloadCurPtr = 0;
				ControlText(StatusText, "Start...");
			}
			else
			{
				ControlText(StatusText, "Read " + mDownloadCurPtr + " / " + mDownloadMaxVal);
				mDownloadCurPtr++;
			}
		}

		private void StopBtn_Click(object sender, EventArgs e)
		{
			bool ok = false;
			string msg = "";
			if (!mBusy)
			{
				if (mTag != null)
				{
					mBusy = true;

					try
					{
						mTag.Logging = false;
						ok = true;
					}
					catch (Exception ex)
					{
						msg = ex.Message;
					}

					mBusy = false;
					if (!ok)
						MessageBox.Show("Error when stopping log activity:\n" + msg);
					else
						StatusText.Text = "Logging was stopped.";
				}
			}
		}

		private void TryStartSimpleLog()
		{
			RTConst.LOGINTERVAL startDelay = RTConst.LOGINTERVAL.INT_1MIN;
			RTConst.LOGINTERVAL sampleInterval = RTConst.LOGINTERVAL.INT_1MIN;

			try
			{
				mTag.StartSimpleLog(startDelay, sampleInterval);
				MessageBox.Show("Logging will start in one minute and will sample every minute until stopped. No alarms are enabled.");
			}
			catch (Exception e)
			{
				MessageBox.Show("Error during log start.\n\nMessage:\n\n", e.Message);
			}
		}

		private void ControlBtn_Click(object sender, EventArgs e)
		{
			if (mBusy)
				return;

			MessageBoxButtons yesNo = MessageBoxButtons.YesNo;
			MessageBoxIcon icon = MessageBoxIcon.Question;
			MessageBoxDefaultButton defBtn = MessageBoxDefaultButton.Button1;
			DialogResult dr;

			dr = MessageBox.Show("This will reset the tag.\n\nSelect YES to continue.", "Are you sure?", yesNo, icon, defBtn);

			if (dr != DialogResult.Yes)
				return;

			if (mTag == null)
			{
				MessageBox.Show("No tag scanned.\nUse \"" + ScanTagBtn.Text + "\" first.");
				return;
			}

			mBusy = true;

			TryStartSimpleLog();

			mBusy = false;

		}
	}
}