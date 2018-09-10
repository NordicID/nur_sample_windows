using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
            this.Text = string.Format("{0} v{1}",
                System.Reflection.Assembly.GetEntryAssembly().GetName().Name,
                System.Reflection.Assembly.GetEntryAssembly().GetName().Version);
            
            try
            {
                // Call NurApi constructor and give Form object for receive notifications
                // in same thread where this Control is running
                hNur = new NurApi(this); //Handle of NurApi
                NurCapabilities.I.Nur = hNur;
                // Set event handlers for NurApi
                hNur.DisconnectedEvent += new EventHandler<NurApi.NurEventArgs>(hNur_DisconnectedEvent);
                hNur.ConnectedEvent += new EventHandler<NurApi.NurEventArgs>(hNur_ConnectedEvent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Program.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Set NurApi for UserControls
            nurLog.SetNurApi(hNur);
            nurInfo.SetNurApi(hNur);
            nurConnection.SetNurApi(hNur);
            nurInventory.SetNurApi(hNur);
            nurAntennas.SetNurApi(hNur);
            nurWriter.SetNurApi(hNur);
            nurLocator.SetNurApi(hNur);
            nurSettings.SetNurApi(hNur);
            nurNxp.SetNurApi(hNur);
            nurSensors.SetNurApi(hNur);
        }

        /// <summary>
        /// Handles the Load event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handles the Closing event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CancelEventArgs" /> instance containing the event data.</param>
        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            // Stop locationg thread if running
            nurLocator.StopLocating();

            // Dispose NurApi
            if (hNur != null)
            {
                if (hNur.IsConnected())
                    hNur.Disconnect();
                hNur.Dispose();
            }
        }

        /// <summary>
        /// Handles the DisconnectedEvent event of the NUR module.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="NurApi.NurEventArgs" /> instance containing the event data.</param>
        private void hNur_DisconnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            NurApi hNur = sender as NurApi;
            this.Text = string.Format("{0} {1} ({2}/{3})",
                System.Reflection.Assembly.GetEntryAssembly().GetName().Name,
                System.Reflection.Assembly.GetEntryAssembly().GetName().Version,
                hNur.GetFileVersion(),
                NurUtils.NurApiDotNetVersion);
        }

        /// <summary>
        /// Handles the ConnectedEvent event of the NUR module.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="NurApi.NurEventArgs" /> instance containing the event data.</param>
        private void hNur_ConnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            NurApi hNur = sender as NurApi;
            this.Text = string.Format("{0} App:{1} Net:{2} Dll:{3} Fw:{4}",
                System.Reflection.Assembly.GetEntryAssembly().GetName().Name,
                System.Reflection.Assembly.GetEntryAssembly().GetName().Version,
                NurUtils.NurApiDotNetVersion,
                hNur.GetFileVersion(),
                hNur.GetReaderInfo().GetVersionString());
        }
    }
}