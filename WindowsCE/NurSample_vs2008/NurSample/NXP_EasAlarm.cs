using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using NurApiDotNet; //NurApi wrapper

namespace NurSample
{
    public partial class NXP_EasAlarm : UserControl
    {
        NurApi hNur = null;

        public NXP_EasAlarm()
        {
            InitializeComponent();
            UpdateButtons();
            this.Enabled = false;
        }

        /// <summary>
        /// Sets the hadle of nur API.
        /// </summary>
        /// <param name="hNur">Handle of NurApi.</param>
        public void SetNurApi(NurApi hNur)
        {
            try
            {
                this.hNur = hNur;

                // Set event handlers for NurApi
                hNur.DisconnectedEvent += new EventHandler<NurApi.NurEventArgs>(hNur_DisconnectedEvent);
                hNur.ConnectedEvent += new EventHandler<NurApi.NurEventArgs>(hNur_ConnectedEvent);
                hNur.NXPAlarmStreamEvent += new EventHandler<NurApi.NXPAlarmStreamEventArgs>(hNur_NXPAlarmStreamEvent);

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
        /// Handles the NXPAlarmStreamEvent event of the hNur control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="NurApi.NXPAlarmStreamEventArgs"/> instance containing the event data.</param>
        void hNur_NXPAlarmStreamEvent(object sender, NurApi.NXPAlarmStreamEventArgs e)
        {
            try
            {
                NurApi hNur = sender as NurApi;

                if (e.data.armed)
                {
                    NurApi.TagStorage inventoriedTags = hNur.GetTagStorage();
                    int numberOfNewTag = nxpTagListView.UpdateTagList(inventoriedTags);
                    //tagsFoundLabel.Text = string.Format("{0} Tags", inventoriedTags.Count);
                    //beeperInventory.Beep(numberOfNewTag);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Program.appName);
            }

            // Restart if stopped by TimeLimit
            //if (e.data.stopped && continueInventory)
            //{
            //    hNur.StartInventoryStream();
            //}

            //Keepd device alive
            HHUtils.KeepDeviceAlive();
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
            this.Enabled = true;
        }

        /// <summary>
        /// Handles the Click event of the refreshBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            // Clear Tag List
            nxpTagListView.ClearTagList();
            // Clear previously inventoried tags from memory
            hNur.ClearTags();
            // Perform simple inventory
            for (int i = 0; i < 3; i++)
            {
                hNur.SimpleInventory();
            }
            // Fetch tags from module, including tag meta
            NurApi.TagStorage inventoriedTags = hNur.FetchTags(true);
            // Update Tag List
            nxpTagListView.UpdateTagList(inventoriedTags);
        }

        /// <summary>
        /// Handles the SelectedTagChanged event of the nxpTagListView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void nxpTagListView_SelectedTagChanged(object sender, EventArgs e)
        {
            // Update tag list
            NurApi.Tag selectedTag = nxpTagListView.SelectedTag;
            if (selectedTag != null)
            {
                // Get EPC from selection
                byte[] targetEPC = selectedTag.epc;
                try
                {
                    // Get Access password from selected tag
                    uint accessPassword = hNur.GetAccessPassword(0, false, NurApi.BANK_EPC, 32, targetEPC.Length * 8, targetEPC);
                    // Fill Access password fied
                    byte[] accPwdBytes = Utils.ConvertToBigEndiaBytes(accessPassword);
                    accessPasswordTextBox.Text = NurApi.BinToHexString(accPwdBytes);
                }
                catch (Exception)
                {
                    accessPasswordTextBox.Text = "unknown";
                }
                // Fill TargerTag fied
                targetEpcTextBox.Text = NurApi.BinToHexString(targetEPC);
            }

            // Update button(s)
            UpdateButtons();
        }

        /// <summary>
        /// Updates the buttons.
        /// </summary>
        private void UpdateButtons()
        {
            try
            {
                // Test access password
                byte[] access = NurApi.HexStringToBin(accessPasswordTextBox.Text);
                // Test access password
                byte[] epc = NurApi.HexStringToBin(targetEpcTextBox.Text);
                // Seems to be valid
                setBtn.Enabled = true;
                resetBtn.Enabled = true;
            }
            catch (Exception)
            {
                setBtn.Enabled = false;
                resetBtn.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the Click event of the setBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void setBtn_Click(object sender, EventArgs e)
        {
            // Get Access password from TextBox
            byte[] accPwdBytes = NurApi.HexStringToBin(accessPasswordTextBox.Text);
            uint accPwdUInt = (uint)Utils.ConvertBigEndiaToSystemEndia(accPwdBytes);
            // Get Target EPC from TextBox
            byte[] targetEPC = NurApi.HexStringToBin(targetEpcTextBox.Text);

            // Set Access Password
        SET_ACCESS_PASSWORD:
            try
            {
                hNur.SetAccessPasswordByEPC(0, false, targetEPC, accPwdUInt);
            }
            catch (NurApiException ex)
            {
                DialogResult dr = MessageBox.Show(ex.Message, "NurApiException",
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Retry)
                    goto SET_ACCESS_PASSWORD;
            }

            // Set Read Protection
        SET_NXP_READ_PROTECTION:
            try
            {
                hNur.NXPSetEAS(accPwdUInt, NurApi.BANK_EPC, 32, targetEPC.Length * 8, targetEPC);
                MessageBox.Show("EAS set successfully", "NXPSetEAS");
            }
            catch (NurApiException ex)
            {
                DialogResult dr = MessageBox.Show(ex.Message, "NurApiException",
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Retry)
                    goto SET_NXP_READ_PROTECTION;
            }
        }

        /// <summary>
        /// Handles the Click event of the resetBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void resetBtn_Click(object sender, EventArgs e)
        {
            // Get Access password from TextBox
            byte[] accPwdBytes = NurApi.HexStringToBin(accessPasswordTextBox.Text);
            uint accPwdUInt = (uint)Utils.ConvertBigEndiaToSystemEndia(accPwdBytes);
            // Get Target EPC from TextBox
            byte[] targetEPC = NurApi.HexStringToBin(targetEpcTextBox.Text);

            // Reset Read Protection
        RESET_NXP_READ_PROTECTION:
            try
            {
                hNur.NXPResetEAS(accPwdUInt, NurApi.BANK_EPC, 32, targetEPC.Length * 8, targetEPC);
                MessageBox.Show("EAS reset successfully", "NXPResetEAS");
            }
            catch (NurApiException ex)
            {
                DialogResult dr = MessageBox.Show(ex.Message, "NurApiException",
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Retry)
                    goto RESET_NXP_READ_PROTECTION;
            }
        }

        private void alarmButton_Click(object sender, EventArgs e)
        {
            if (hNur.IsNXPAlarmStreamRunning())
            {
                hNur.NXPStopAlarmStream();
                alarmButton.Text = "Start ALARM";
            }
            else
            {
                alarmButton.Text = "Stop ALARM";
                hNur.NXPStartAlarmStream();
            }
        }
    }
}
