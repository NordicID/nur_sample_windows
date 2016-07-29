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
    public partial class Writer : UserControl
    {
        NurApi hNur = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Writer"/> class.
        /// </summary>
        public Writer()
        {
            InitializeComponent();
            this.Enabled = false;
            targetBankCB.SelectedIndex = NurApi.BANK_EPC;
            memBankCB.SelectedIndex = NurApi.BANK_TID;
            securityCB.SelectedIndex = 0;
            secLockStateCB.SelectedIndex = 0;
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
        /// Handles the Click event of the refreshBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            // Clear Tag List
            writeTagListView.ClearTagList();
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
            writeTagListView.UpdateTagList(inventoriedTags);
        }

        /// <summary>
        /// Handles the SelectedTagChanged event of the writeTagListView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void writeTagListView_SelectedTagChanged(object sender, EventArgs e)
        {
            NurApi.Tag selectedTag = writeTagListView.SelectedTag;
            if (selectedTag != null)
            {
                SetTargetTag(NurApi.BANK_EPC, 32, selectedTag.epc);
            }
        }

        /// <summary>
        /// Handles the Click event of the pickUpButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void pickUpButton_Click(object sender, EventArgs e)
        {
            try
            {
                int usedTxLevel;
                NurApi.Tag strongestTag;
                int nurbeOfTags = NurUtils.SearchNearestTag(hNur, true, out strongestTag, out usedTxLevel);
                if (nurbeOfTags == 1)
                    SetTargetTag(NurApi.BANK_EPC, 32, strongestTag.epc);
            }
            catch (NurApiException ex)
            {
                MessageBox.Show(ex.Message, Program.appName, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// Sets the target tag.
        /// </summary>
        /// <param name="bank">The bank.</param>
        /// <param name="start">The start.</param>
        /// <param name="mask">The mask.</param>
        private void SetTargetTag(byte bank, uint start, byte[] mask)
        {
            if (mask == null)
                mask = new byte[0];

            // Fill Target
            targetBankCB.SelectedIndex = NurApi.BANK_EPC;
            targetStartUD.Value = 32;
            targetMaskTextBox.Text = NurApi.BinToHexString(mask);
            targetLengthUD.Value = mask.Length * 8;
            // Fill EPC
            newEpcTextBox.Text = targetMaskTextBox.Text;

            UpdateTargetTagControls();
        }

        /// <summary>
        /// Updates the target tag controls.
        /// </summary>
        private void UpdateTargetTagControls()
        {
            string target;
            if (targetLengthUD.Value > 0)
            {
                target = string.Format("{0}[{1}/{2}]{3}",
                    targetBankCB.Items[targetBankCB.SelectedIndex].ToString(),
                    targetStartUD.Value,
                    targetLengthUD.Value,
                    targetMaskTextBox.Text);
            }
            else
            {
                target = "Target is not set!";
            }

            targetEpcLabel.Text = target;
            targetMemLabel.Text = target;
            targetAccessLabel.Text = target;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the tabControl1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (writeTagListView.FocusedItem != null)
                writeTagListView.FocusedItem.Selected = false;
        }

        /// <summary>
        /// Handles the Click event of the writeNewEpcBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void writeNewEpcBtn_Click(object sender, EventArgs e)
        {
            string message = "New EPC written successfully!";
            int startTick = System.Environment.TickCount;
            MessageBoxIcon icon = MessageBoxIcon.None;
            try
            {
                // Write new EPC and set correct length
                uint passwd = uint.Parse(passwdTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                bool secured = usePasswdCheckBox.Checked;
                byte sBank = (byte)targetBankCB.SelectedIndex;
                uint sAddress = (uint)targetStartUD.Value;
                int sMaskBitLength = (int)targetLengthUD.Value;
                byte[] sMask = NurApi.HexStringToBin(targetMaskTextBox.Text);
                byte[] epcBuffer = NurApi.HexStringToBin(newEpcTextBox.Text);
                hNur.WriteEPC(passwd, secured, sBank, sAddress, sMaskBitLength, sMask, epcBuffer);
            }
            catch (NurApiException ex)
            {
                message = NurApiErrors.ErrorCodeToString(ex.error);
                icon = MessageBoxIcon.Hand;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                icon = MessageBoxIcon.Hand;
            }
            // Show result
            string title = string.Format("{0} {1} ms", Program.appName, System.Environment.TickCount - startTick);
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon, MessageBoxDefaultButton.Button1);

            // Refresh list
            refreshBtn_Click(this, EventArgs.Empty);
        }

        /// <summary>
        /// Handles the Click event of the readMemButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void readMemButton_Click(object sender, EventArgs e)
        {
            string message;
            int startTick = System.Environment.TickCount;
            MessageBoxIcon icon = MessageBoxIcon.None;
            try
            {
                // Read memory from Tag
                uint passwd = uint.Parse(passwdTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                bool secured = usePasswdCheckBox.Checked;
                byte sBank = (byte)targetBankCB.SelectedIndex;
                uint sAddress = (uint)targetStartUD.Value;
                int sMaskBitLength = (int)targetLengthUD.Value;
                byte[] sMask = NurApi.HexStringToBin(targetMaskTextBox.Text);
                byte rdBank = (byte)memBankCB.SelectedIndex;
                uint rdAddress = (uint)memStartUD.Value;
                byte rdByteCount = (byte)memLengthUD.Value;
                byte[] data;
                if (memUseReadBlockCheckBox.Checked)
                    data = NurRead.ReadBank(hNur, passwd, secured, sBank, sAddress, sMaskBitLength, sMask, rdBank, rdAddress, rdByteCount);
                else
                    data = hNur.ReadSingulatedTag(passwd, secured, sBank, sAddress, sMaskBitLength, sMask, rdBank, rdAddress, rdByteCount);
                memTextBox.Text = NurApi.BinToHexString(data);
                message = string.Format("{0} bytes read successfully \nin {1} ms.", data.Length, System.Environment.TickCount - startTick);
            }
            catch (NurApiException ex)
            {
                message = NurApiErrors.ErrorCodeToString(ex.error);
                icon = MessageBoxIcon.Hand;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                icon = MessageBoxIcon.Hand;
            }
            // Show result
            string title = string.Format("{0} {1} ms", Program.appName, System.Environment.TickCount - startTick);
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Handles the Click event of the writeMemButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.Exception">
        /// mission impossible
        /// or
        /// Invalid parameter
        /// </exception>
        private void writeMemButton_Click(object sender, EventArgs e)
        {
            string message = "Memory written successfully!";
            int startTick = System.Environment.TickCount;
            MessageBoxIcon icon = MessageBoxIcon.None;
            try
            {
                // Write Tag memory
                uint passwd = uint.Parse(passwdTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                bool secured = usePasswdCheckBox.Checked;
                byte sBank = (byte)targetBankCB.SelectedIndex;
                uint sAddress = (uint)targetStartUD.Value;
                int sMaskBitLength = (int)targetLengthUD.Value;
                byte[] sMask = NurApi.HexStringToBin(targetMaskTextBox.Text);
                byte wrBank = (Byte)memBankCB.SelectedIndex;
                uint wrAddress = (uint)memStartUD.Value;
                byte[] wrBuffer = NurApi.HexStringToBin(memTextBox.Text);
                hNur.WriteSingulatedTag(passwd, secured, sBank, sAddress, sMaskBitLength, sMask, wrBank, wrAddress, wrBuffer);
            }
            catch (NurApiException ex)
            {
                message = NurApiErrors.ErrorCodeToString(ex.error);
                icon = MessageBoxIcon.Hand;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                icon = MessageBoxIcon.Hand;
            }
            // Show result
            string title = string.Format("{0} {1} ms", Program.appName, System.Environment.TickCount - startTick);
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Handles the Click event of the setLockStateButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void setLockStateButton_Click(object sender, EventArgs e)
        {
            string message = "Lock state(s) set successfully!";
            int startTick = System.Environment.TickCount;
            MessageBoxIcon icon = MessageBoxIcon.None;
            try
            {
                // Write Tag memory
                uint passwd = uint.Parse(passwdTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                bool secured = usePasswdCheckBox.Checked;
                byte sBank = (byte)targetBankCB.SelectedIndex;
                uint sAddress = (uint)targetStartUD.Value;
                int sMaskBitLength = (int)targetLengthUD.Value;
                byte[] sMask = NurApi.HexStringToBin(targetMaskTextBox.Text);
                uint memoryMask = 0;
                if (lockUserCheckBox.Checked) memoryMask |= NurApi.LOCK_USERMEM;
                if (lockTicCheckBox.Checked) memoryMask |= NurApi.LOCK_TIDMEM;
                if (lockEpcCheckBox.Checked) memoryMask |= NurApi.LOCK_EPCMEM;
                if (lockAccessCheckBox.Checked) memoryMask |= NurApi.LOCK_ACCESSPWD;
                if (lockKillCheckBox.Checked) memoryMask |= NurApi.LOCK_KILLPWD;
                uint action = (uint)secLockStateCB.SelectedIndex;
                hNur.SetLock(passwd, sBank, sAddress, sMaskBitLength, sMask, memoryMask, action);
            }
            catch (NurApiException ex)
            {
                message = NurApiErrors.ErrorCodeToString(ex.error);
                icon = MessageBoxIcon.Hand;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                icon = MessageBoxIcon.Hand;
            }
            // Show result
            string title = string.Format("{0} {1} ms", Program.appName, System.Environment.TickCount - startTick);
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Handles the Click event of the readPasswordButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void readPasswordButton_Click(object sender, EventArgs e)
        {
            string message = "Password read successfully!";
            int startTick = System.Environment.TickCount;
            MessageBoxIcon icon = MessageBoxIcon.None;
            try
            {
                // Read memory from Tag
                uint passwd = uint.Parse(passwdTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                bool secured = usePasswdCheckBox.Checked;
                byte sBank = (byte)targetBankCB.SelectedIndex;
                uint sAddress = (uint)targetStartUD.Value;
                int sMaskBitLength = (int)targetLengthUD.Value;
                byte[] sMask = NurApi.HexStringToBin(targetMaskTextBox.Text);
                uint password;
                switch (securityCB.SelectedIndex)
                {
                    case 0:
                        // Kill
                        password = hNur.GetKillPassword(passwd, secured, sBank, sAddress, sMaskBitLength, sMask);
                        break;
                    case 1:
                        // Access
                        password = hNur.GetAccessPassword(passwd, secured, sBank, sAddress, sMaskBitLength, sMask);
                        break;
                    default:
                        throw new Exception("Invalid parameter");
                }
                if (BitConverter.IsLittleEndian)
                {
                    password = ReverseBytes(password);
                }
                byte[] pwdBytes = BitConverter.GetBytes(password);
                secPasswdTextBox.Text = NurApi.BinToHexString(pwdBytes);
            }
            catch (NurApiException ex)
            {
                message = NurApiErrors.ErrorCodeToString(ex.error);
                icon = MessageBoxIcon.Hand;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                icon = MessageBoxIcon.Hand;
            }
            // Show result
            string title = string.Format("{0} {1} ms", Program.appName, System.Environment.TickCount - startTick);
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// reverse byte order (32-bit)
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static UInt32 ReverseBytes(UInt32 value)
        {
            return (value & 0x000000FFU) << 24 | (value & 0x0000FF00U) << 8 |
                   (value & 0x00FF0000U) >> 8 | (value & 0xFF000000U) >> 24;
        }

        /// <summary>
        /// Handles the Click event of the writePasswordButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void writePasswordButton_Click(object sender, EventArgs e)
        {
            string message = "Password written successfully!";
            int startTick = System.Environment.TickCount;
            MessageBoxIcon icon = MessageBoxIcon.None;
            try
            {
                // Write password
                uint passwd = uint.Parse(passwdTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                bool secured = usePasswdCheckBox.Checked;
                byte sBank = (byte)targetBankCB.SelectedIndex;
                uint sAddress = (uint)targetStartUD.Value;
                int sMaskBitLength = (int)targetLengthUD.Value;
                byte[] sMask = NurApi.HexStringToBin(targetMaskTextBox.Text);
                uint newPasswd = uint.Parse(secPasswdTextBox.Text, System.Globalization.NumberStyles.HexNumber); ;
                switch (securityCB.SelectedIndex)
                {
                    case 0:
                        // Kill
                        hNur.SetKillPassword(passwd, secured, sBank, sAddress, sMaskBitLength, sMask, newPasswd);
                        break;
                    case 1:
                        // Access
                        hNur.SetAccessPassword(passwd, secured, sBank, sAddress, sMaskBitLength, sMask, newPasswd);
                        break;
                    default:
                        throw new Exception("Invalid parameter");
                }
            }
            catch (NurApiException ex)
            {
                message = NurApiErrors.ErrorCodeToString(ex.error);
                icon = MessageBoxIcon.Hand;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                icon = MessageBoxIcon.Hand;
            }
            // Show result
            string title = string.Format("{0} {1} ms", Program.appName, System.Environment.TickCount - startTick);
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Handles the Click event of the killButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void killButton_Click(object sender, EventArgs e)
        {
            string message = "Tag killed successfully!";
            int startTick = System.Environment.TickCount;
            MessageBoxIcon icon = MessageBoxIcon.None;
            try
            {
                // Kill Tag
                uint passwd = uint.Parse(secPasswdTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                byte sBank = (byte)targetBankCB.SelectedIndex;
                uint sAddress = (uint)targetStartUD.Value;
                int sMaskBitLength = (int)targetLengthUD.Value;
                byte[] sMask = NurApi.HexStringToBin(targetMaskTextBox.Text);
                uint newPasswd = uint.Parse(secPasswdTextBox.Text, System.Globalization.NumberStyles.HexNumber); ;
                hNur.KillTag(passwd, sBank, sAddress, sMaskBitLength, sMask);
            }
            catch (NurApiException ex)
            {
                message = NurApiErrors.ErrorCodeToString(ex.error);
                icon = MessageBoxIcon.Hand;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                icon = MessageBoxIcon.Hand;
            }
            // Show result
            string title = string.Format("{0} {1} ms", Program.appName, System.Environment.TickCount - startTick);
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Handles the CheckStateChanged event of the memUseReadBlockCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void memUseReadBlockCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            if (memUseReadBlockCheckBox.Checked)
                memLengthUD.Value = 0;
        }
    }
}
