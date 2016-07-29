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
    public partial class Inventory : UserControl
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

        /// <summary>
        /// The inventory read supported
        /// </summary>
        bool inventoryReadSupported = false;

        /// <summary>
        /// The unofficial TID inventory supported
        /// </summary>
        bool unofficialTidInventorySupported = false;

        /// <summary>
        /// The inventory filters
        /// </summary>
        List<NurApi.InventoryExFilter> filters = new List<NurApi.InventoryExFilter>();

        /// <summary>
        /// The filter index
        /// </summary>
        int filterIndex = 0;

        /// <summary>
        /// The start tick
        /// </summary>
        int startTick = 0;
        /// <summary>
        /// The total reads
        /// </summary>
        int totalReads = 0;

        /// <summary>
        /// The last unique tick
        /// </summary>
        int uniqueTick = 0;
        /// <summary>
        /// The unique tags
        /// </summary>
        int uniqueTags = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Inventory" /> class.
        /// </summary>
        public Inventory()
        {
            InitializeComponent();
            this.Enabled = false;
            InitializInventoryRead();
            InitializLogToFile();
            ShowFilter(filterIndex);
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (beeperInventory != null))
            {
                beeperInventory.Dispose();
            }
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
                hNur.DisconnectedEvent += new EventHandler<NurApi.NurEventArgs>(hNur_DisconnectedEvent);
                hNur.ConnectedEvent += new EventHandler<NurApi.NurEventArgs>(hNur_ConnectedEvent);
                hNur.InventoryStreamEvent += new EventHandler<NurApi.InventoryStreamEventArgs>(hNur_InventoryStreamEvent);
                hNur.InventoryExEvent += new EventHandler<NurApi.InventoryStreamEventArgs>(hNur_InventoryStreamEvent);

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
            InitializInventoryRead();
            this.Enabled = true;
        }

        /// <summary>
        /// Handles the InventoryStreamEvent event of the NUR module.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="NurApi.InventoryStreamEventArgs" /> instance containing the event data.</param>
        private void hNur_InventoryStreamEvent(object sender, NurApi.InventoryStreamEventArgs e)
        {
            try
            {
                NurApi hNur = sender as NurApi;

                if (e.data.tagsAdded > 0)
                {
                    totalReads += e.data.tagsAdded;
                    NurApi.TagStorage inventoriedTags = hNur.GetTagStorage();
                    int numberOfNewTag = tagListBox.UpdateTagList(inventoriedTags);
                    beeperInventory.Beep(numberOfNewTag);
                    WriteLogToFile(inventoriedTags);
                    UpdateStatistics(inventoriedTags);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Program.appName);
            }

            // Restart if stopped by TimeLimit
            if (e.data.stopped && continueInventory)
            {
                StartInventory(hNur);
            }

            //Keepd device alive
            HHUtils.KeepDeviceAlive();
        }

        /// <summary>
        /// Updates the statistics.
        /// </summary>
        private void UpdateStatistics(NurApi.TagStorage tagStorage)
        {
            if (tagStorage != null)
            {
                int ticksNow = System.Environment.TickCount;
                int elapsed = ticksNow - startTick;
                totalLabel.Text = "Total reads in " + (elapsed/1000).ToString() + " sec";
                totalReadsLabel.Text = "  " + totalReads.ToString() + " reads";
                totalAverageLabel.Text = "  " + ((totalReads * 1000) / elapsed).ToString() + " reads/sec";

                if (uniqueTags != tagStorage.Count)
                {
                    uniqueTick = ticksNow;
                    uniqueTags = tagStorage.Count;
                    int uniqueElapsed = uniqueTick - startTick;
                    uniqueLabel.Text = "Unique tags in " + (uniqueElapsed / 1000).ToString() + " sec";
                    tagsFoundLabel.Text = string.Format("{0} Tags", uniqueTags);
                    uniqueTagsLabel.Text = "  " + uniqueTags.ToString() + " unique tags";
                    uniqueAverageLabel.Text = "  " + ((uniqueTags * 1000) / uniqueElapsed).ToString() + " unique tags/sec";
                }
            }
            else
            {
                tagsFoundLabel.Text = "- - -";
                totalReadsLabel.Text = "- - -";
                totalAverageLabel.Text = "- - -";
                uniqueTagsLabel.Text = "- - -";
                uniqueAverageLabel.Text = "- - -";

                totalReads = 0;
                uniqueTags = 0;
                startTick = System.Environment.TickCount;
                uniqueTick = startTick;
            }
        }

        /// <summary>
        /// Handles the Click event of the startStopInventoryBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        public void startStopInventoryBtn_Click(object sender, EventArgs e)
        {
            if (hNur.IsInventoryStreamRunning() || hNur.IsInventoryExRunning())
            {
                // Stop inventory
                StopInventory();
                // Stop inventory beeper
                beeperInventory.Stop();
                // Update START button
                startStopInventoryBtn.Text = "Start Inventory";
                startStopInventoryBtn2.Text = startStopInventoryBtn.Text;
                // Stop Log To file
                StopLogToFile();
            }
            else
            {
                // Init statistics
                UpdateStatistics(null);
                // Clear NurApi TagStorage memory from tags 
                hNur.ClearTags();
                // Clear tagListBox from tags
                tagListBox.ClearTagList();
                // Update START button
                startStopInventoryBtn.Text = "Stop Inventory";
                startStopInventoryBtn2.Text = startStopInventoryBtn.Text;
                // Start Log to file if enabled
                StartLogToFile();
                // Start inventory beeper
                beeperInventory.Start();
                // Configure and start inventory
                ConfigureInventory(hNur);
                StartInventory(hNur);
            }
        }

        private void ConfigureInventory(NurApi hNur)
        {
            if (inventoryReadSupported)
            {
                try
                {
                    // Configure the inventory settings.
                    // This may fail if the feature is not supported
                    switch (invTypeComboBox.SelectedIndex)
                    {
                        case 0:
                        default:
                            // INVENTORY ONLY
                            // Disable Inventory read control
                            hNur.InventoryReadCtl = false;
                            break;
                        case 1:
                            // INVENTORY + DATA
                            // NOTE: this call does not start the inventory + read; it tells the module
                            // that the following inventory stream is done with a inventory + read.
                            hNur.InventoryRead(true,
                                NurApi.NUR_IR_EPCDATA,
                                (uint)dataBankComboBox.SelectedIndex,
                                (uint)dataStartUpDown.Value,
                                (uint)dataLengthUpDown.Value);
                            break;
                        case 2:
                            // DATA ONLY
                            // NOTE: this call does not start the data read; it tells the module
                            // that the following inventory stream is done with a read.
                            hNur.InventoryRead(true,
                                NurApi.NUR_IR_DATAONLY,
                                (uint)dataBankComboBox.SelectedIndex,
                                (uint)dataStartUpDown.Value,
                                (uint)dataLengthUpDown.Value);
                            break;
                    }
                }
                catch (NurApiException)
                {
                    // It seems that the InventoryRead is not supported
                    // Try unofficial TID inventory
                    inventoryReadSupported = false;
                    InitializeUnofficialTidInventory();
                }
            }

            if (unofficialTidInventorySupported)
            {
                try
                {
                    // Configure the unofficial feature inventory inventory settings.
                    // This may fail if the feature is not supported
                    switch (invTypeComboBox.SelectedIndex)
                    {
                        case 0:
                        default:
                            // INVENTORY ONLY
                            // Disable unofficial TID inventory
                            hNur.OpFlags = hNur.OpFlags & ~(1 << 2);
                            break;
                        case 1:
                            // TID INVENTORY
                            // Enable unofficial TID inventory feature where
                            // the inventory stream returns fixed length (4 words)
                            // TID instead of EPC.
                            hNur.OpFlags = hNur.OpFlags | (1 << 2);
                            break;
                    }
                }
                catch (NurApiException)
                {
                    // It seems that the unofficial TID Inventory is not supported
                    unofficialTidInventorySupported = false;
                }
            }
        }

        private void StartInventory(NurApi hNur)
        {
            // Restart the inventory stream if necessary
            continueInventory = true;

            // Start Inventory Stream
            try
            {
                if (filters.Count > 0)
                {
                    // Start InventoryEx Stream
                    NurApi.InventoryExParams ip = new NurApi.InventoryExParams();
                    ip.inventorySelState = NurApi.SELSTATE_SL;
                    ip.inventoryTarget = hNur.InventoryTarget;
                    ip.Q = hNur.InventoryQ;
                    ip.rounds = hNur.InventoryRounds;
                    ip.session = hNur.InventorySession;
                    ip.transitTime = 0;

                    NurApi.InventoryExFilter[] filt = filters.ToArray();
                    hNur.StartInventoryEx(ref ip, filt);
                }
                else
                {
                    // Start Inventory Stream without filtering
                    hNur.StartInventoryStream();
                }
            }
            catch (NurApiException ex)
            {
                MessageBox.Show(ex.ToString(), Program.appName);
            }
        }

        /// <summary>
        /// Stops the inventory.
        /// </summary>
        private void StopInventory()
        {
            // Do not restart the inventory stream 
            continueInventory = false;
            /// Force stop all NUR module running continuous functions.
            hNur.StopContinuous();
            if (inventoryReadSupported)
            {
                // Disable Inventory read control
                hNur.InventoryReadCtl = false;
            }
            if (unofficialTidInventorySupported)
            {
                // Disable unofficial TID inventory
                hNur.OpFlags = hNur.OpFlags & ~(1 << 2);
            }
        }

        /// <summary>
        /// Initializs the inventory read.
        /// </summary>
        private void InitializInventoryRead()
        {
            inventoryReadSupported = true;
            invTypeComboBox.Items.Clear();
            invTypeComboBox.Items.Add("Inventory only");
            invTypeComboBox.Items.Add("Inv. + data");
            invTypeComboBox.Items.Add("Data only");
            invTypeComboBox.SelectedIndex = 0;
            dataBankComboBox.SelectedIndex = NurApi.BANK_TID;
            dataStartUpDown.Value = 0;
            dataLengthUpDown.Value = 4;
            UpdtaeInvnetoryControls();
        }

        /// <summary>
        /// Initializes the unofficial TID inventory.
        /// </summary>
        private void InitializeUnofficialTidInventory()
        {
            unofficialTidInventorySupported = true;
            invTypeComboBox.Items.Clear();
            invTypeComboBox.Items.Add("EPC Inventory");
            invTypeComboBox.Items.Add("TID Inventory");
            invTypeComboBox.SelectedIndex = 0;
            dataBankComboBox.SelectedIndex = NurApi.BANK_TID;
            dataStartUpDown.Value = 0;
            dataLengthUpDown.Value = 4;
            UpdtaeInvnetoryControls();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the invTypeComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void invTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdtaeInvnetoryControls();
        }

        /// <summary>
        /// Updtaes the invnetory controls.
        /// </summary>
        private void UpdtaeInvnetoryControls()
        {
            bool enable = false;
            if (inventoryReadSupported)
                enable = invTypeComboBox.SelectedIndex > 0;
            dataBankLabel.Enabled = enable;
            dataBankComboBox.Enabled = enable;
            dataStartLabel.Enabled = enable;
            dataStartUpDown.Enabled = enable;
            dataLengthLabel.Enabled = enable;
            dataLengthUpDown.Enabled = enable;
            invTypeComboBox.Enabled = inventoryReadSupported || unofficialTidInventorySupported;
        }

        /// <summary>
        /// The log to file
        /// </summary>
        int logToFileTagCounter = 0;
        int logToFileFormat = 0;
        bool logToFileEnabled = false;
        string logToFileSeparator = ",";
        LogToFile logToFile = new LogToFile();

        /// <summary>
        /// Initializs the log to file.
        /// </summary>
        private void InitializLogToFile()
        {
            logInvEnabledComboBox.Checked = logToFileEnabled;
            logInvActionComboBox.SelectedIndex = 0;
            logInvFormatComboBox.SelectedIndex = 0;
            logInvSeparatorTextBox.Text = logToFileSeparator;
        }

        /// <summary>
        /// Starts the log to file if enabled.
        /// </summary>
        private void StartLogToFile()
        {
            if (logToFileEnabled)
            {
                logToFileTagCounter = 0;
                logToFile.StartLog(logInvFileNameTextBox.Text, logInvActionComboBox.SelectedIndex);
            }
        }

        /// <summary>
        /// Stops the log to file.
        /// </summary>
        private void StopLogToFile()
        {
            logToFile.StopLog();
        }

        /// <summary>
        /// Writes the log to file.
        /// </summary>
        /// <param name="tagStorage">The tag storage.</param>
        private void WriteLogToFile(NurApi.TagStorage tagStorage)
        {
            if (logToFileEnabled)
            {
                for (; logToFileTagCounter < tagStorage.Count; logToFileTagCounter++)
                {
                    switch (logToFileFormat)
                    {
                        case 0:
                            // EPC
                            logToFile.WriteLog(tagStorage[logToFileTagCounter].GetEpcString());
                            break;
                        case 1:
                            // EPC, DATA
                            logToFile.WriteLog(
                               string.Format("{0}{1}{2}",
                               tagStorage[logToFileTagCounter].GetEpcString(),
                               logToFileSeparator,
                               tagStorage[logToFileTagCounter].irData != null ?
                                   NurApi.BinToHexString(tagStorage[logToFileTagCounter].irData) :
                                   ""));
                            break;
                        case 2:
                            // Date&Time, EPC, RSSI
                            logToFile.WriteLog(
                               string.Format("{0}{1}{2}{3}{4}",
                               DateTime.Now.ToString(),
                               logToFileSeparator,
                               tagStorage[logToFileTagCounter].GetEpcString(),
                               logToFileSeparator,
                               tagStorage[logToFileTagCounter].rssi.ToString()));
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the logInvBrowseBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void logInvBrowseBtn_Click(object sender, EventArgs e)
        {
            saveLogDialog.FileName = logInvFileNameTextBox.Text;
            if (saveLogDialog.ShowDialog() == DialogResult.OK)
            {
                logInvFileNameTextBox.Text = saveLogDialog.FileName;
            }
        }

        /// <summary>
        /// Handles the CheckStateChanged event of the logInvEnabledComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void logInvEnabledComboBox_CheckStateChanged(object sender, EventArgs e)
        {
            logToFileEnabled = logInvEnabledComboBox.Checked;
            logInvFileNameTextBox.Enabled = logToFileEnabled;
            logInvActionComboBox.Enabled = logToFileEnabled;
            logInvFormatComboBox.Enabled = logToFileEnabled;
            logInvSeparatorTextBox.Enabled = logToFileEnabled;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the logInvFormatComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void logInvFormatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            logToFileFormat = logInvFormatComboBox.SelectedIndex;
        }

        /// <summary>
        /// Handles the TextChanged event of the textBox1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void logInvSeparatorTextBox_TextChanged(object sender, EventArgs e)
        {
            logToFileSeparator = logInvSeparatorTextBox.Text;
        }

        private void tagListBox_SelectedTagChanged(object sender, EventArgs e)
        {
            NurApi.Tag tag = tagListBox.SelectedTag;
            if (tag != null)
            {
                InitFilter(tag.GetEpcString());
            }
        }

        private void readTag_Button_Click(object sender, EventArgs e)
        {
            NurApi.Tag tag = null;
            int usedTxLevel;
            if (NurUtils.SearchNearestTag(hNur, true, out tag, out usedTxLevel) > 0)
            {
                InitFilter(tag.GetEpcString());
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                filters.Remove(filters[filterIndex]);
            }
            catch (Exception)
            {
            }
            ShowFilter(filterIndex);
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddFilter();
            ShowFilter(filters.Count - 1);
        }

        private void InitFilter(string mask)
        {
            bank_combo.SelectedIndex = NurApi.BANK_EPC;
            address_UpDown.Value = 4 * 8; // (CRC + PC) * 8 bits
            mask_textBox.Text = mask;
            length_UpDown.Value = mask.Length * 4;
            action_combo.SelectedIndex = NurApi.FACTION_0;
            target_combo.SelectedIndex = NurApi.SESSION_SL;
            filterCntLabel.Text = string.Format("---/{0}", filters.Count);
        }

        private void AddFilter()
        {
            NurApi.InventoryExFilter filt = new NurApi.InventoryExFilter();
            byte[] mask = NurApi.HexStringToBin(mask_textBox.Text);
            filt.action = (byte)action_combo.SelectedIndex;
            filt.address = (uint)address_UpDown.Value;
            filt.bank = (byte)bank_combo.SelectedIndex;
            filt.maskBitLength = (int)length_UpDown.Value;
            filt.maskData = new byte[NurApi.MAX_SELMASK];
            Buffer.BlockCopy(mask, 0, filt.maskData, 0, mask.Length);
            filt.target = (byte)target_combo.SelectedIndex;
            filters.Add(filt);
        }

        private void ShowFilter(int index)
        {
            if (index >= filters.Count)
                index = filters.Count - 1;
            if (index < 0)
                index = 0;
            else if (index > filters.Count - 1)
                index = filters.Count - 1;
            filterIndex = index;

            if (filters.Count > 0)
            {
                bank_combo.SelectedIndex = filters[index].bank;
                address_UpDown.Value = filters[index].address;
                mask_textBox.Text = NurApi.BinToHexString(filters[index].maskData, (filters[index].maskBitLength + 7) / 8);
                length_UpDown.Value = filters[index].maskBitLength;
                action_combo.SelectedIndex = filters[index].action;
                target_combo.SelectedIndex = filters[index].target;
                filterCntLabel.Text = string.Format("{0}/{1}", index + 1, filters.Count);
            }
            else
            {
                index = 0;
                InitFilter("");
                filterCntLabel.Text = "not set";
            }
        }

        private void decIndex_Click(object sender, EventArgs e)
        {
            filterIndex--;
            ShowFilter(filterIndex);
        }

        private void incIndex_Click(object sender, EventArgs e)
        {
            filterIndex++;
            ShowFilter(filterIndex);
        }
    }
}
