using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using NurApiDotNet; //NurApi wrapper

namespace NurSample
{
    public partial class Sensors : UserControl
    {
        /// <summary>
        /// The NurApi handle
        /// </summary>
        NurApi hNur = null;

        /// <summary>
        /// The disable controls events
        /// </summary>
        bool disableEvents = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="Inventory" /> class.
        /// </summary>
        public Sensors()
        {
            InitializeComponent();
            this.Enabled = false;
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
                hNur.DisconnectedEvent += new EventHandler<NurApi.NurEventArgs>(hNur_DisconnectedEvent);
                hNur.ConnectedEvent += new EventHandler<NurApi.NurEventArgs>(hNur_ConnectedEvent);
                hNur.InventoryStreamEvent += new EventHandler<NurApi.InventoryStreamEventArgs>(hNur_InventoryStreamEvent);
                hNur.TriggerReadEvent += new EventHandler<NurApi.TriggerReadEventArgs>(hNur_TriggerReadEvent);
                hNur.IOChangeEvent += new EventHandler<NurApi.IOChangeEventArgs>(hNur_IOChangeEvent);

                // Update the status of the connection
                if (hNur.IsConnected())
                    hNur_ConnectedEvent(hNur, null);
                else
                    hNur_DisconnectedEvent(hNur, null);
            }
            catch (NurApiException ex)
            {
                MessageBox.Show(ex.ToString(), Program.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.Enabled = false;
        }

        /// <summary>
        /// Handles the ConnectedEvent event of the NUR module.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="NurApi.NurEventArgs" /> instance containing the event data.</param>
        private void hNur_ConnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            disableEvents = true;
            NurApi hNur = sender as NurApi;
            try
            {
                if (hNur.GetReaderInfo().numSensors > 0)
                {
                    UpdateSensorControls();
                    this.Enabled = true;
                }
            }
            catch (NurApiException ex)
            {
                MessageBox.Show(ex.ToString(), Program.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Enabled = false;
            }
            disableEvents = false;
        }

        void hNur_IOChangeEvent(object sender, NurApi.IOChangeEventArgs e)
        {
            NurApi hNur = sender as NurApi;
            string eventString = string.Format("{0:N0}: IOChange: {1} #{2}, {3}",
                e.timestamp,
                e.data.sensor ? "Sensor" : "GPIO",
                e.data.source,
                e.data.dir == 0 ? "High to low" : "Low to high"
                );
            AddToEventList(eventString);
        }

        void hNur_InventoryStreamEvent(object sender, NurApi.InventoryStreamEventArgs e)
        {
            NurApi hNur = sender as NurApi;
            string eventString = string.Format("{0:N0}: InvStream: Tags {1}, Rounds {2}, Q {3}",
                e.timestamp,
                e.data.tagsAdded,
                e.data.roundsDone,
                e.data.Q
                );
            AddToEventList(eventString);
        }

        void hNur_TriggerReadEvent(object sender, NurApi.TriggerReadEventArgs e)
        {
            NurApi hNur = sender as NurApi;
            if (e.data.rssi > -127)
            {
                // Tag found
                byte[] epc = new byte[e.data.epcLen];
                Array.Copy(e.data.epc, epc, e.data.epcLen);

                string eventString = string.Format("{0:N0}: TrigRead: {1} #{2}, Ant #{3}, {4} ({6} Bytes), RSSI {5}%",
                    e.timestamp,
                    e.data.sensor ? "Sensor" : "GPIO",
                    e.data.source,
                    e.data.antennaID,
                    NurApi.BinToHexString(epc),
                    e.data.scaledRssi,
                    e.data.epcLen
                    );
                AddToEventList(eventString);
            }
            else
            {
                // Tag not be found
                string eventString = string.Format("{0:N0}: TrigRead: TAG NOT BE FOUND",
                    e.timestamp);
                AddToEventList(eventString);
            }
        }

        private void UpdateSensorControls()
        {
            NurApi.SensorConfig sensorConfig = hNur.GetSensorConfig();

            if (sensorConfig.tapEnabled == true &&
                sensorConfig.tapAction > NurApi.GPIO_ACT_NONE &&
                sensorConfig.tapAction <= NurApi.GPIO_ACT_INVENTORY)
                tapSensorCombo.SelectedIndex = sensorConfig.tapAction;
            else
                tapSensorCombo.SelectedIndex = 0;

            if (sensorConfig.lightEnabled == true &&
                sensorConfig.lightAction > NurApi.GPIO_ACT_NONE &&
                sensorConfig.lightAction <= NurApi.GPIO_ACT_INVENTORY)
                lightSensorCombo.SelectedIndex = sensorConfig.lightAction;
            else
                lightSensorCombo.SelectedIndex = 0;

            invTO.Value = hNur.InventoryTriggerTimeout;
            ssTO.Value = hNur.ScanSingleTriggerTimeout;
        }

        private void sensorControl_Changed(object sender, EventArgs e)
        {
            if (disableEvents)
                return;

            try
            {
                NurApi.SensorConfig sensorConfig = hNur.GetSensorConfig();

                sensorConfig.tapAction = tapSensorCombo.SelectedIndex;
                sensorConfig.tapEnabled = tapSensorCombo.SelectedIndex > 0;

                sensorConfig.lightAction = lightSensorCombo.SelectedIndex;
                sensorConfig.lightEnabled = lightSensorCombo.SelectedIndex > 0;

                hNur.SetSensorConfig(ref sensorConfig);

                hNur.InventoryTriggerTimeout = (int)invTO.Value;
                hNur.ScanSingleTriggerTimeout = (int)ssTO.Value;
            }
            catch (NurApiException ex)
            {
                MessageBox.Show(ex.ToString(), Program.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Enabled = false;
            }
        }

        private void AddToEventList(string msg)
        {
            eventsList.Items.Add(msg);
            eventsList.SelectedIndex = eventsList.Items.Count - 1;
        }
    }
}
