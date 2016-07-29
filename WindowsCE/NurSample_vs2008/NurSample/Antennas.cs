using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

using NurApiDotNet; //NurApi wrapper

namespace NurSample
{
    public partial class Antennas : UserControl
    {
        NurApi hNur = null;
        int disableEvents = 0;
        bool isAutoTuneSupported = true;

        class SelectedAntenna
        {
            public int Value;
            public string Text;
            public SelectedAntenna(int value, string text) { Value = value; Text = text; }
            public override string ToString() { return Text; }
        }

        public Antennas()
        {
            InitializeComponent();
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
                isAutoTuneSupported = true;
                this.Enabled = true;
                CreateListOfPhysicalAntennas();
                UpdateAntennaSelection();
                UpdateAntennaTuneSettings();
            }
            catch (NurApiException)
            {
                this.Enabled = false;
            }
        }

        private void refreshPhysicalAntennasButton_Click(object sender, EventArgs e)
        {
            CreateListOfPhysicalAntennas();
            UpdateAntennaSelection();
            UpdateAntennaTuneSettings();
        }

        private void CreateListOfPhysicalAntennas()
        {
            disableEvents++;
            try
            {
                // Clear list
                physicalAntennasListView.Items.Clear();

                // Get list of physical antennas
                List<string> availablePhysicalAntennas = hNur.AvailablePhysicalAntennas;

                // Add antennas to ListView
                for (int i = 0; i < availablePhysicalAntennas.Count; i++)
                {
                    string antenna = availablePhysicalAntennas[i];
                    int antennaID = hNur.NurPhysicalAntennaToAntennaId(antenna);
                    bool enabled = hNur.IsPhysicalAntennaEnabled(antenna);
                    
                    // Add a new ListViewItem to the list
                    ListViewItem item = new ListViewItem(antennaID.ToString());
                    item.SubItems.Add(antenna);
                    item.SubItems.Add(enabled.ToString());
                    item.SubItems.Add("");
                    item.Checked = enabled;
                    item.Tag = antennaID;
                    physicalAntennasListView.Items.Add(item);
                }
            }
            catch (NurApiException ex)
            {
                MessageBox.Show(ex.ToString(), Program.appName);
            }
            Application.DoEvents();
            disableEvents--;
        }

        private void UpdateAntennaSelection()
        {
            disableEvents++;
            try
            {
                // Get list of physical antennas
                List<string> enabledPhysicalAntennas = hNur.EnabledPhysicalAntennas;
                // Add enabled antennas to ComboBox
                selectedAntennaComboBox.Items.Clear();
                selectedAntennaComboBox.Items.Add(new SelectedAntenna(NurApi.ANTENNAID_AUTOSELECT, "Auto Select"));
                for (int i = 0; i < enabledPhysicalAntennas.Count; i++)
                {
                    string antenna = enabledPhysicalAntennas[i];
                    int antennaID = hNur.NurPhysicalAntennaToAntennaId(antenna);
                    selectedAntennaComboBox.Items.Add(new SelectedAntenna(antennaID, antenna));
                }
                // Select Selected Antenna
                int selectedAntenna = hNur.SelectedAntenna;
                for (int i = 0; i < selectedAntennaComboBox.Items.Count; i++)
                {
                    SelectedAntenna item = selectedAntennaComboBox.Items[i] as SelectedAntenna;
                    if (item.Value == selectedAntenna)
                    {
                        selectedAntennaComboBox.SelectedIndex = i;
                        break;
                    }
                }
            }
            catch (NurApiException ex)
            {
                MessageBox.Show(ex.ToString(), Program.appName);
            }
            disableEvents--;
        }

        private void physicalAntennasListView_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (disableEvents > 0)
                return;

            try
            {
                ListView clb = sender as ListView;
                int antennaID = (int)physicalAntennasListView.Items[e.Index].Tag;
                uint antennaMask = (uint)(1 << antennaID);
                uint enableMask = (uint)((e.NewValue == CheckState.Checked) ? (1 << antennaID) : 0);
                if ((hNur.AntennaMaskEx & antennaMask) != enableMask)
                {
                    bool enabled = (e.NewValue == CheckState.Checked);
                    if (enabled)
                        hNur.AntennaMaskEx |= antennaMask;
                    else
                        hNur.AntennaMaskEx &= ~antennaMask;

                    physicalAntennasListView.Items[e.Index].SubItems[2].Text = enabled.ToString();                    
                }
            }
            catch (NurApiException ex)
            {
                MessageBox.Show(ex.ToString(), Program.appName);
                e.NewValue = e.CurrentValue;
            }

            // Update Antenna selection 
            UpdateAntennaSelection();
        }

        private void selectedAntennaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (disableEvents > 0)
                return;

            try
            {
                ComboBox cb = sender as ComboBox;
                SelectedAntenna ant = cb.SelectedItem as SelectedAntenna;
                hNur.SelectedAntenna = ant.Value;
            }
            catch (NurApiException ex)
            {
                MessageBox.Show(ex.ToString(), Program.appName);
            }

            // Update Antenna conrols 
            UpdateAntennaSelection();
        }

        /// <summary>
        /// Handles the TuneEvent event of the hNur control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="NurApi.TuneEventArgs"/> instance containing the event data.</param>
        void hNur_TuneEvent(object sender, NurApi.TuneEventArgs e)
        {
            try
            {
                for (int i = 0; i < physicalAntennasListView.Items.Count; i++)
                {
                    int antennaID = (int)physicalAntennasListView.Items[i].Tag;
                    if (antennaID == e.data.antenna)
                    {
                        physicalAntennasListView.Items[i].SubItems[3].Text = string.Format(
                            "{0:0.0} dBm", (decimal)e.data.reflPower_dBm / 1000);
                        break;
                    }
                }
            }
            catch (NurApiException ex)
            {
                MessageBox.Show(ex.ToString(), Program.appName);
            }
        }

        /// <summary>
        /// Updates the antenna tune controls.
        /// </summary>
        private void UpdateAntennaTuneSettings()
        {
            disableEvents++;
            try
            {
                switch (hNur.Autotune.mode)
                {
                    case NurApi.AUTOTUNE_MODE_ENABLE:
                        autoTune_ComboBox.SelectedIndex = 1;
                        break;
                    case NurApi.AUTOTUNE_MODE_ENABLE | NurApi.AUTOTUNE_MODE_THRESHOLD_ENABLE:
                        autoTune_ComboBox.SelectedIndex = 2;
                        break;
                    case 0:
                    default:
                        autoTune_ComboBox.SelectedIndex = 0;
                        break;
                }
                autoTuneTreshold_UpDown.Value = hNur.Autotune.threshold_dBm;
                enTuneEvents_CheckBox.Checked = hNur.EnableTuneEvents;
            }
            catch (NurApiException)
            {
                // Not supported feature
                // Older NUR modules like a NUR05W does not support this feature
                isAutoTuneSupported = false;
            }
            // Enable / disable AutoTune controls
            // Older NUR modules like a NUR05W does not support this feature
            autoTune_Label.Enabled = isAutoTuneSupported;
            autoTune_ComboBox.Enabled = isAutoTuneSupported;
            autoTuneTreshold_Label.Enabled = isAutoTuneSupported;
            autoTuneTreshold_UpDown.Enabled = isAutoTuneSupported;
            enTuneEvents_Label.Enabled = isAutoTuneSupported;
            enTuneEvents_CheckBox.Enabled = isAutoTuneSupported;
            disableEvents--;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the autoTune_ComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void autoTune_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (disableEvents > 0)
                return;

            try
            {
                switch (autoTune_ComboBox.SelectedIndex)
                {
                    case 1:
                        hNur.AutotuneEnable = true;
                        hNur.AutotuneThresholdEnable = false;
                        break;
                    case 2:
                        hNur.AutotuneEnable = true;
                        hNur.AutotuneThresholdEnable = true;
                        break;
                    case 0:
                    default:
                        hNur.AutotuneEnable = false;
                        break;
                }
            }
            catch (NurApiException ex)
            {
                MessageBox.Show(ex.ToString(), Program.appName);
            }
            UpdateAntennaTuneSettings();
        }

        /// <summary>
        /// Handles the ValueChanged event of the autoTuneTreshold_UpDown control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void autoTuneTreshold_UpDown_ValueChanged(object sender, EventArgs e)
        {
            if (disableEvents > 0)
                return;

            try
            {
                hNur.AutotuneThreshold = (sbyte)autoTuneTreshold_UpDown.Value;
            }
            catch (NurApiException ex)
            {
                MessageBox.Show(ex.ToString(), Program.appName);
            }
            UpdateAntennaTuneSettings();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the enTuneEvents_CheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void enTuneEvents_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (disableEvents > 0)
                return;

            try
            {
                hNur.EnableTuneEvents = enTuneEvents_CheckBox.Checked;
            }
            catch (NurApiException ex)
            {
                MessageBox.Show(ex.ToString(), Program.appName);
            }
            UpdateAntennaTuneSettings();
        }
    }
}
