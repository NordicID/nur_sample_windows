using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

using NurApiDotNet; //NurApi wrapper

namespace NurSample
{
    public partial class Log : UserControl
    {
        /// <summary>
        /// The NurApi handle
        /// </summary>
        NurApi hNur = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Inventory" /> class.
        /// </summary>
        public Log()
        {
            InitializeComponent();
            this.Enabled = false;
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Sets the NurApi.
        /// </summary>
        /// <param name="hNur">The handle of NurApi.</param>
        public void SetNurApi(NurApi hNur)
        {
            try
            {
                this.hNur = hNur;
                // Set event handlers for NurApi
                hNur.LogEvent += new EventHandler<NurApi.LogEventArgs>(hNur_LogEvent);
                // Update CheckBoxes
                int mask = hNur.GetLogLevel();
                logVerboseCheckBox.Checked = (mask & NurApi.LOG_VERBOSE) != 0;
                logErrorCheckBox.Checked = (mask & NurApi.LOG_ERROR) != 0;
                logUserCheckBox.Checked = (mask & NurApi.LOG_USER) != 0;
                logDataCheckBox.Checked = (mask & NurApi.LOG_DATA) != 0;
                // Enable controls
                this.Enabled = true;
            }
            catch (NurApiException ex)
            {
                MessageBox.Show(ex.ToString(), Program.appName);
            }
        }

        void hNur_LogEvent(object sender, NurApi.LogEventArgs e)
        {
            NurApi hNur = sender as NurApi;
            logListBox.Items.Add(string.Format("{0,8}: {1}", e.timestamp, e.message));
            while (logListBox.Items.Count > 500)
            {
                logListBox.Items.RemoveAt(0);
            }
            //logListBox.SelectedIndex = logListBox.Items.Count - 1;
        }

        private void logVerboseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            int mask = hNur.GetLogLevel();
            if (logVerboseCheckBox.Checked)
            {
                mask |= NurApi.LOG_VERBOSE;
            }
            else
            {
                mask &= ~NurApi.LOG_VERBOSE;
            }
            hNur.SetLogLevel(mask);
        }

        private void logErrorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            int mask = hNur.GetLogLevel();
            if (logErrorCheckBox.Checked)
            {
                mask |= NurApi.LOG_ERROR;
            }
            else
            {
                mask &= ~NurApi.LOG_ERROR;
            }
            hNur.SetLogLevel(mask);
        }

        private void logUserCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            int mask = hNur.GetLogLevel();
            if (logUserCheckBox.Checked)
            {
                mask |= NurApi.LOG_USER;
            }
            else
            {
                mask &= ~NurApi.LOG_USER;
            }
            hNur.SetLogLevel(mask);
        }

        private void logDataCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            int mask = hNur.GetLogLevel();
            if (logDataCheckBox.Checked)
            {
                mask |= NurApi.LOG_DATA;
            }
            else
            {
                mask &= ~NurApi.LOG_DATA;
            }
            hNur.SetLogLevel(mask);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            logListBox.Items.Clear();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    for (int r = 0; r < logListBox.Items.Count; r++)
                    {
                        sw.WriteLine(logListBox.Items[r].ToString());
                    }
                    sw.Flush();
                }
            }
        }

        private void logToFileButton_Click(object sender, EventArgs e)
        {
            if (hNur.GetLogToFile() == false)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    hNur.SetLogFilePath(saveFileDialog1.FileName);
                    hNur.SetLogToFile(true);
                    logToFileButton.Text = "Stop logging into file";
                }
            }
            else
            {
                hNur.SetLogToFile(false);
                logToFileButton.Text = "Log to file";
            }
        }
    }
}
