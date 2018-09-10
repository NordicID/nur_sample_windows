using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using NurApiDotNet; //NurApi wrapper

namespace NurSample
{
    public partial class Settings : UserControl
    {
        NurApi hNur = null;
        int disableEvents = 0;

        class ComboItem
        {
            public string text;
            public int value;
            public ComboItem(string text, int value) { this.text = text; this.value = value; }
            public override string ToString() { return text; }
        }

        public Settings()
        {
            InitializeComponent();
            this.Enabled = false;
        }

        public void SetNurApi(NurApi hNur)
        {
            try
            {
                this.hNur = hNur;

                // Set NurApi for UserControls
                nurTune.SetNurApi(hNur);

                // Set event handlers for NurApi
                hNur.DisconnectedEvent += new EventHandler<NurApi.NurEventArgs>(hNur_DisconnectedEvent);
                hNur.ConnectedEvent += new EventHandler<NurApi.NurEventArgs>(hNur_ConnectedEvent);

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
            disableEvents++;
            NurApi hNur = sender as NurApi;
            this.Enabled = true;
            try
            {
                FillNurComboBox(regionCombo, NurApi.SETUP_REGION, 0, NurCapabilities.I.ReaderInfo.numRegions - 1, true);
                FillNurComboBox(txLevelCombo, NurApi.SETUP_TXLEVEL, 0, NurCapabilities.I.DeviceCaps.txSteps - 1, true);
                FillNurComboBox(periodCombo, NurApi.SETUP_AUTOPERIOD, 0, NurApi.NUR_AUTOPER_50, true);
                FillNurComboBox(invEpcLenCombo, NurApi.SETUP_INVEPCLEN, 255, 255, true);
                FillNurComboBox(invEpcLenCombo, NurApi.SETUP_INVEPCLEN, 2, 62, false);
                UpdateSettingControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Program.appName);
            }
            disableEvents--;
        }

        private void FillNurComboBox(ComboBox comboBox, int setupFlag, int minValue, int maxValue, bool clear)
        {
            // Fill ComboBox
            comboBox.BeginUpdate();
            if (clear)
                comboBox.Items.Clear();
            for (int value = minValue; value <= maxValue; value++)
            {
                try
                {
                    string text = NurCapabilities.I.ConvertToString(setupFlag, value);
                    comboBox.Items.Add(new ComboItem(text, value));
                }
                catch (Exception) { }
            }
            comboBox.EndUpdate();
        }

        private void SelectNurComboBox(ComboBox comboBox, int value)
        {
            int index = 0;
            for (; index < comboBox.Items.Count; index++)
            {
                ComboItem item = comboBox.Items[index] as ComboItem;
                if (item.value == value)
                {
                    comboBox.SelectedIndex = index;
                    return;
                }
            }
        }

        private int GetNurComboBoxValue(ComboBox comboBox)
        {
            ComboItem item = comboBox.SelectedItem as ComboItem;
            return item.value;
        }

        private void UpdateAntennaControls(int antennaSelection)
        {
            // Fill Selected Antenna Combo and Enabled Antenna list
            int antSel = 0;
            selectedAntenna.BeginUpdate();
            selectedAntenna.Items.Clear();
            selectedAntenna.Items.Add(new ComboItem("Auto Antenna", NurApi.ANTENNAID_AUTOSELECT));
            foreach (int antId in hNur.EnabledAntennas)
            {
                string antenna = hNur.NurAntennaIdToPhysicalAntenna(antId);                    
                int index = selectedAntenna.Items.Add(new ComboItem(antenna, antId));
                if (antId == antennaSelection)
                    antSel = index;
            }
            selectedAntenna.SelectedIndex = antSel;
            selectedAntenna.EndUpdate();
        }

        private void UpdateSettingControls()
        {
            disableEvents++;
            try
            {
                // Get current settings
                NurApi.ModuleSetup currenSetup = hNur.GetModuleSetup();

                // Update Combo boxes
                regionCombo.SelectedIndex = currenSetup.regionId;
                switch (currenSetup.linkFreq)
                {
                    case 160000:
                        lfCombo.SelectedIndex = 0;
                        break;
                    case 256000:
                        lfCombo.SelectedIndex = 1;
                        break;
                    case 320000:
                        lfCombo.SelectedIndex = 2;
                        break;
                }
                rxDecCombo.SelectedIndex = currenSetup.rxDecoding;
                txModCombo.SelectedIndex = currenSetup.txModulation;
                txLevelCombo.SelectedIndex = currenSetup.txLevel;
                rxSensitivity_ComboBox.SelectedIndex = currenSetup.rxSensitivity;

                UpdateAntennaControls(currenSetup.selectedAntenna);
                switch (currenSetup.autotune.mode)
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
                autoTuneTreshold_UpDown.Value = currenSetup.autotune.threshold_dBm;
                enTuneEvents_CheckBox.Checked = hNur.EnableTuneEvents;

                qCombo.SelectedIndex = currenSetup.inventoryQ;
                sessionCombo.SelectedIndex = currenSetup.inventorySession;
                roundsCombo.SelectedIndex = currenSetup.inventoryRounds;
                targetCombo.SelectedIndex = currenSetup.inventoryTarget;
                periodCombo.SelectedIndex = currenSetup.periodSetup;
                SelectNurComboBox(invEpcLenCombo, currenSetup.inventoryEpcLength);

                // Set Numeric UpDown boxs
                readRssiMin.Value = currenSetup.readRssiFilter.min;
                readRssiMax.Value = currenSetup.readRssiFilter.max;
                writeRssiMin.Value = currenSetup.writeRssiFilter.min;
                writeRssiMax.Value = currenSetup.writeRssiFilter.max;
                inventoryRssiMin.Value = currenSetup.inventoryRssiFilter.min;
                inventoryRssiMax.Value = currenSetup.inventoryRssiFilter.max;
            }
            catch (NurApiException ex)
            {
                MessageBox.Show(ex.ToString(), Program.appName);
                this.Enabled = false;
            }
            disableEvents--;
        }

        private void SettingsChanged(object sender, EventArgs e)
        {
            if (disableEvents > 0)
                return;
            GetSettingsFromControls();
        }

        private void GetSettingsFromControls()
        {
            try
            {
                // Get current settings
                NurApi.ModuleSetup newSetup = hNur.GetModuleSetup();

                // Get setting from Combo boxes
                newSetup.regionId = regionCombo.SelectedIndex;
                switch (lfCombo.SelectedIndex)
                {
                    case 0:
                        newSetup.linkFreq = 160000;
                        break;
                    case 1:
                        newSetup.linkFreq = 256000;
                        break;
                    case 2:
                        newSetup.linkFreq = 320000;
                        break;
                }
                newSetup.rxDecoding = rxDecCombo.SelectedIndex;
                newSetup.txModulation = txModCombo.SelectedIndex;
                newSetup.txLevel = txLevelCombo.SelectedIndex;
                newSetup.rxSensitivity = rxSensitivity_ComboBox.SelectedIndex;

                newSetup.selectedAntenna = GetNurComboBoxValue(selectedAntenna);
                switch (autoTune_ComboBox.SelectedIndex)
                {
                    case 1:
                        newSetup.autotune.mode = NurApi.AUTOTUNE_MODE_ENABLE;
                        break;
                    case 2:
                        newSetup.autotune.mode = NurApi.AUTOTUNE_MODE_ENABLE | NurApi.AUTOTUNE_MODE_THRESHOLD_ENABLE;
                        break;
                    case 0:
                    default:
                        newSetup.autotune.mode = 0;
                        break;
                }
                newSetup.autotune.threshold_dBm = (sbyte)autoTuneTreshold_UpDown.Value;
                newSetup.opFlags = enTuneEvents_CheckBox.Checked ?
                    newSetup.opFlags | (uint)NurApi.OPFLAGS_EN_TUNEEVENTS :
                    newSetup.opFlags & ~(uint)NurApi.OPFLAGS_EN_TUNEEVENTS;

                newSetup.inventoryQ = qCombo.SelectedIndex;
                newSetup.inventoryRounds = roundsCombo.SelectedIndex;
                newSetup.inventorySession = sessionCombo.SelectedIndex;
                newSetup.inventoryTarget = targetCombo.SelectedIndex;
                newSetup.periodSetup = periodCombo.SelectedIndex;
                newSetup.inventoryEpcLength = GetNurComboBoxValue(invEpcLenCombo);

                // Get settings from Numeric UpDown boxses
                newSetup.readRssiFilter.min = Convert.ToSByte(readRssiMin.Value);
                newSetup.readRssiFilter.max = Convert.ToSByte(readRssiMax.Value);
                newSetup.writeRssiFilter.min = Convert.ToSByte(writeRssiMin.Value);
                newSetup.writeRssiFilter.max = Convert.ToSByte(writeRssiMax.Value);
                newSetup.inventoryRssiFilter.min = Convert.ToSByte(inventoryRssiMin.Value);
                newSetup.inventoryRssiFilter.max = Convert.ToSByte(inventoryRssiMax.Value);

                // Set settings to NurApi
                hNur.SetModuleSetup(NurApi.SETUP_ALL, ref newSetup);
            }
            catch (NurApiException ex)
            {
                MessageBox.Show(ex.ToString(), Program.appName);
                UpdateSettingControls();
            }
        }

        private void storeSetupBtn_Click(object sender, EventArgs e)
        {
            hNur.StoreCurrentSetup();
        }
    }
}
