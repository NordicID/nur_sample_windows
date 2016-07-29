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
    public partial class NXP_ProductStatusFlag : UserControl
    {
        /// <summary>
        /// The NurApi handle
        /// </summary>
        NurApi hNur = null;

        /// <summary>
        /// The inventory beeper
        /// </summary>
        BeeperInventory beeperInventory = new BeeperInventory();

        /// <summary>
        /// The continue inventory
        /// </summary>
        bool continueInventory = false;

        public NXP_ProductStatusFlag()
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
                hNur.InventoryStreamEvent += new EventHandler<NurApi.InventoryStreamEventArgs>(hNur_InventoryStreamEvent);

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
            this.Enabled = true;
        }

        /// <summary>
        /// Handles the InventoryStreamEvent event of the hNur control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="NurApi.InventoryStreamEventArgs"/> instance containing the event data.</param>
        void hNur_InventoryStreamEvent(object sender, NurApi.InventoryStreamEventArgs e)
        {
            try
            {
                NurApi hNur = sender as NurApi;

                if (e.data.tagsAdded > 0)
                {
                    NurApi.TagStorage inventoriedTags = hNur.GetTagStorage();
                    int numberOfNewTag = nxpTagListView.UpdateTagList(inventoriedTags);
                    //beeperInventory.Beep(numberOfNewTag);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Program.appName);
            }

            // Restart if stopped by TimeLimit
            if (e.data.stopped && continueInventory)
            {
                StartPsfInventory();
            }

            //Keepd device alive
            HHUtils.KeepDeviceAlive();
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
                // Fill TargerTag fied
                targetEpcTextBox.Text = NurApi.BinToHexString(targetEPC);
                try
                {
                    // Read NXP configuration word
                    byte[] confWord = hNur.ReadSingulatedTag(0, false, NurApi.BANK_EPC, 32, selectedTag.epc, NurApi.BANK_EPC, 0x200 / 16, 2);
                    configurationLabel.Text = "0x" + NurApi.BinToHexString(confWord);
                }
                catch (NurApiException)
                {
                    configurationLabel.Text = "???";
                }
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
                byte[] epc = NurApi.HexStringToBin(targetEpcTextBox.Text);
                // Seems to be valid
                setBtn.Enabled = true;
            }
            catch (Exception)
            {
                setBtn.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the Click event of the setBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void setBtn_Click(object sender, EventArgs e)
        {
            // Get Target EPC from TextBox
            byte[] targetEPC = NurApi.HexStringToBin(targetEpcTextBox.Text);

            // Set NXP PSF
        SET_NXP_PSF:
            try
            {
                hNur.WriteTagByEPC(0, false, targetEPC, NurApi.BANK_EPC, 0x200 / 16, new byte[] { 0x00, 0x01 });
                MessageBox.Show("PSF set successfully", "WriteSingulatedTag");
            }
            catch (NurApiException ex)
            {
                DialogResult dr = MessageBox.Show(ex.Message, "NurApiException",
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Retry)
                    goto SET_NXP_PSF;
            }
            // Update PSF information
            nxpTagListView_SelectedTagChanged(sender, e);
        }

        /// <summary>
        /// Handles the Click event of the psfInventoryButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void psfInventoryButton_Click(object sender, EventArgs e)
        {
            if (hNur.IsInventoryStreamRunning())
            {
                continueInventory = false;
                StopPsfInventory();
                psfInventoryButton.Text = "Start PSF inventory";
            }
            else
            {
                // Clear Tag List
                nxpTagListView.ClearTagList();
                // Clear previously inventoried tags from memory
                hNur.ClearTags();

                continueInventory = true;
                psfInventoryButton.Text = "Stop PSF inventory";
                StartPsfInventory();
            }
        }

        /// <summary>
        /// Starts the PSF inventory.
        /// </summary>
        private void StartPsfInventory()
        {
            try
            {
                // Start InventorySelectStream for searching 
                hNur.StartInventorySelectStream(
                    hNur.InventoryRounds,
                    hNur.InventoryQ,
                    hNur.InventorySession,
                    false,
                    NurApi.BANK_EPC,
                    0x20f,
                    1,
                    new byte[] { 0x80 });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Program.appName);
            }
        }

        /// <summary>
        /// Stops the PSF inventory.
        /// </summary>
        private void StopPsfInventory()
        {
            try
            {
                // Stop InventorySelectStream for searching 
                hNur.StopInventoryStream();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Program.appName);
            }
        }
    }
}
