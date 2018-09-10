using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using NurApiDotNet; //NurApi wrapper

namespace NurSample
{
    public partial class AntennaTuner : UserControl
    {
        NurApi hNur = null;

        public AntennaTuner()
        {
            InitializeComponent();
        }

        private void NurTune_Load(object sender, EventArgs e)
        {

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
                hNur.TuneEvent += new EventHandler<NurApi.TuneEventArgs>(hNur_TuneEvent);

                // Update the status of the connection
                if (hNur.IsConnected())
                    hNur_ConnectedEvent(hNur, null);
                else
                    hNur_DisconnectedEvent(hNur, null);
            }
            catch (NurApiException ex)
            {
                MessageBox.Show(ex.ToString(), Program.appName);
            }
        }

        void hNur_TuneEvent(object sender, NurApi.TuneEventArgs e)
        {
            AddMessage(string.Format("TuneEvent Ant{0}: {1} dBm",
                e.data.antenna, (decimal)e.data.reflPower_dBm/1000));
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
            NurApi hNur = sender as NurApi;
            try
            {
                this.Enabled = NurCapabilities.I.DeviceCaps.tune;
                if (NurCapabilities.I.DeviceCaps.tune == false)
                    AddMessage("Not available with this module!!!");
            }
            catch (NurApiException)
            {
                this.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the Click event of the measureReflegtedPowerButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void measureReflegtedPowerButton_Click(object sender, EventArgs e)
        {
            AddMessage("*** Measure Reflected Powers *** ");
            MeasureReflectedPowers();
        }

        /// <summary>
        /// Handles the Click event of the tuneButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tuneButton_Click(object sender, EventArgs e)
        {
            AddMessage("*** Measure Reflected Powers *** ");
            MeasureReflectedPowers();
            AddMessage("*** Tune Antennas *** ");
            AddMessage("Please wait...");
            TuneAntennas();
            AddMessage("*** Measure Reflected Powers *** ");
            MeasureReflectedPowers();
        }

        private void restoreFactoryTuningsButtons_Click(object sender, EventArgs e)
        {
            AddMessage("*** Measure Reflected Powers *** ");
            MeasureReflectedPowers();
            AddMessage("*** Restore Factory Tuning *** ");
            RestoreTuning();
            AddMessage("*** Measure Reflected Powers *** ");
            MeasureReflectedPowers();
        }


        /// <summary>
        /// Tunes the antennas.
        /// </summary>
        private void TuneAntennas()
        {
            try
            {
                bool tuneEventsEnabled = hNur.EnableTuneEvents;
                if (tuneEventsEnabled)
                    hNur.EnableTuneEvents = false;
                List<int> enabledAntennas = hNur.EnabledAntennas;
                foreach (int antenna in enabledAntennas)
                {
                    try
                    {
                        int duration = System.Environment.TickCount;
                        int []reply = hNur.TuneAntenna(antenna, true, true);
                        duration = System.Environment.TickCount - duration;
                        ShowResults(antenna, reply, duration);
                    }
                    catch (NurApiException ex)
                    {
                        AddMessage("Error " + ex.error + ". ");
                    }
                }                    
                AddMessage("Done");
                
                if (tuneEventsEnabled)
                    hNur.EnableTuneEvents = true;
            }
            catch (NurApiException ex)
            {
                AddMessage("NurApiException " + ex.error);
            }
        }

        private void ShowResults(int antenna, int[] tuneResp, int duration)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("Ant{0}, ", antenna));
            for (int i = 0; i < tuneResp.Length; i++)
            {
                sb.Append(string.Format("Bnd{0}={1}, ", i, ((float)tuneResp[i] / 1000.0).ToString()));
            }
            sb.Append(string.Format("{0} ms", duration));
            AddMessage(sb.ToString());
        }

        /// <summary>
        /// Measures the Reflected Powers from enabled antennas.
        /// </summary>
        void MeasureReflectedPowers()
        {
            try
            {
                bool tuneEventsEnabled = hNur.EnableTuneEvents;
                if (tuneEventsEnabled)
                    hNur.EnableTuneEvents = false;
                AddMessage("Region: " + hNur.GetRegionInfo().name);

                int tmpSelectdeAntenna = hNur.SelectedAntenna;
                List<int> enabledAntennas = hNur.EnabledAntennas;
                StringBuilder sb = new StringBuilder();
                foreach (int antenna in enabledAntennas)
                {
                    try
                    {
                        // Select Antenna
                        hNur.SelectedAntenna = antenna;
                        // Measure Reflected Power
                        double dBm = hNur.GetReflectedPowerValue(0);
                        sb.Append(string.Format("Ant{0}: {1:0.0} dBm, ", antenna, dBm));
                    }
                    catch (NurApiException)
                    {
                        sb.Append(string.Format("Ant{0}: ?.? dBm, ", antenna));
                    }
                }                
                sb.Replace(", ", "", sb.Length - 2, 2);
                AddMessage(sb.ToString());
                AddMessage("Done");

                // Restore SelectedAntenna
                hNur.SelectedAntenna = tmpSelectdeAntenna;

                if (tuneEventsEnabled)
                    hNur.EnableTuneEvents = true;
            }
            catch (NurApiException ex)
            {
                AddMessage("NurApiException " + ex.error);
            }
        }

        /// <summary>
        /// Tunes the antennas.
        /// </summary>
        private void RestoreTuning()
        {
            try
            {
                hNur.RestoreTuning(true);
                AddMessage("Done");
            }
            catch (NurApiException ex)
            {
                AddMessage("NurApiException " + ex.error);
            }
        }

        /// <summary>
        /// Adds message to listBox.
        /// </summary>
        /// <param name="message">The message.</param>
        void AddMessage(string message)
        {
            listBox1.Items.Add(message);
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            Application.DoEvents();
        }
    }
}
