using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NordicId;
using NurApiDotNet; //Need to use namespace of NurApiDotNet

namespace NurSample
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// The NurApi handle
        /// </summary>
        NurApi hNur = null;                 // Handle of NurApi

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1" /> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            Fullscreen.Init();
            Fullscreen.SetFullScreen(true);
            this.Text = string.Format("{0} v{1}",
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Name,
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);
            this.WindowState = FormWindowState.Maximized;

            try
            {
                // Call NurApi constructor and give Form object for receive notifications
                // in same thread where this Control is running
                hNur = new NurApi(this); //Handle of NurApi
                //hNur.SetLogLevel(NurApi.LOG_ALL & ~NurApi.LOG_DATA);
                NurCapabilities.I.Nur = hNur;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Program.appName);
                this.Close();
                return;
            }

            // Set NurApi for UserControls
            nurLog.SetNurApi(hNur);
            nurInfo.SetNurApi(hNur);
            nurInventory.SetNurApi(hNur);
            nurAntennas.SetNurApi(hNur);
            nurWriter.SetNurApi(hNur);
            nurLocator.SetNurApi(hNur);
            nurSettings.SetNurApi(hNur);
            nurNxp.SetNurApi(hNur);

            try
            {
                // Configure Scan & Trigger -buttons
                HHScanButton.ConfigureScanButtons((Keys)NordicId.VK.SCAN);
                HHScanButton.ScanButtonMode = HHScanButton.SCANMODE.NONE;
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Handles the Load event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Connect Nur -module
            hNur.ConnectIntegratedReader();
        }

        /// <summary>
        /// Handles the Closing event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CancelEventArgs" /> instance containing the event data.</param>
        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            // Restore Scan & Trigger -button configurations
            HHScanButton.RestoreScanButtons();

            // Stop locationg thread if running
            nurLocator.StopLocating();

            // Dispose NurApi
            if (hNur != null)
            {
                if (hNur.IsConnected())
                    hNur.Disconnect();
                hNur.Dispose();
            }
            Fullscreen.SetFullScreen(false);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Make sure that this.KeyPreview is turned on.
            switch (e.KeyCode)
            {
                case (Keys)NordicId.VK.SCAN:
                    // Jump to inventory -tab and start / stop inventory
                    tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(inventoryTab);
                    nurInventory.startStopInventoryBtn_Click(this, EventArgs.Empty);
                    e.Handled = true;
                    break;
            }
        }
    }
}