#region License
/*
MIT License
Copyright © 2015 Nordic ID

All rights reserved.

Authors
 * Mikko Lähteenmäki

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion License

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using NurApiDotNet;

namespace NurTagTrackingGate 
{
    public partial class DeviceList : UserControl
    {
        NurApi mApi;

        public class DeviceArgs : EventArgs
        {
            public DeviceArgs(string addr, int port)
            {
                this.addr = addr;
                this.port = port;
            }
            public string addr;
            public int port;
        }
        public event EventHandler<DeviceArgs> ConnectToDevice;

        private Dictionary<string, NurApi.DevInfoData> devices = new Dictionary<string, NurApi.DevInfoData>();

        public NurApi Api
        {
            get { return mApi; }
            set 
            {
                if (mApi != null)
                {
                    mApi.ConnectedEvent -= OnConnectedEvent;
                    mApi.DisconnectedEvent -= OnDisconnectedEvent;
                    mApi.DevInfoEvent -= OnDevInfoEvent;
                }

                mApi = value;

                if (mApi != null)
                {
                    mApi.ConnectedEvent += new EventHandler<NurApi.NurEventArgs>(OnConnectedEvent);
                    mApi.DisconnectedEvent += new EventHandler<NurApi.NurEventArgs>(OnDisconnectedEvent);
                    mApi.DevInfoEvent += new EventHandler<NurApi.DevInfoEventArgs>(OnDevInfoEvent);
                }

                comboFilterType.SelectedIndex = 0;
            }
        }

        public DeviceList()
        {
            InitializeComponent();
        }

        public DeviceList(NurApi api)
        {
            InitializeComponent();

            this.Api = api;
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();

                mApi.ConnectedEvent -= new EventHandler<NurApi.NurEventArgs>(OnConnectedEvent);
                mApi.DisconnectedEvent -= new EventHandler<NurApi.NurEventArgs>(OnDisconnectedEvent);
                mApi.DevInfoEvent -= new EventHandler<NurApi.DevInfoEventArgs>(OnDevInfoEvent);

            }
            base.Dispose(disposing);
        }

        void OnDisconnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            RefreshList();
        }

        void OnConnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            RefreshList();
        }

        void OnDevInfoEvent(object sender, NurApi.DevInfoEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate { OnDevInfoEvent(sender, e); }));
                return;
            }

            string mac = EthHelper.MacToString(e.data.eth.mac);
            NurApi.DevInfoData did;
            if (devices.TryGetValue(mac, out did))
            {
                devices[mac] = e.data;
            }
            else
            {
                devices.Add(mac, e.data);
            }

            deviceView.SelectedItems.Clear();
            deviceView.Items.Clear();
            foreach (NurApi.DevInfoData device in devices.Values)
            {
                string nurVersion = string.Format("{0}.{1}{2}",
                    device.nurVer[0].ToString(),
                    device.nurVer[1].ToString(),
                    Convert.ToChar(device.nurVer[2]));

                ListViewItem item = new ListViewItem(
                    new string[]
                {
                    device.eth.title,
                    EthHelper.IpToString(device.eth.ip),
                    device.eth.serverPort.ToString(),
                    EthHelper.EthAddrTypeToString(device.eth),
                    EthHelper.EthHostModeToString(device.eth),
                    EthHelper.EthHostModeToString(device),
                    EthHelper.MacToString(device.eth.mac), 
                    new string(device.altSerial),
                    device.eth.version.ToString(),
                    nurVersion
                });

                item.Tag = device;
                deviceView.Items.Add(item);
            }

            deviceView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        public void RefreshList()
        {
            int ftype = comboFilterType.SelectedIndex;
            int fop = comboFilterOp.SelectedIndex;
            byte[] fdata = new byte[16];
            fdata = System.Text.Encoding.ASCII.GetBytes(textFilterData.Text);
            try
            {
                mApi.NurApiSendBroadcast(NurApi.BC_CMD_GET_DEV_INFO, ftype, fop, fdata, textFilterData.Text.Length, null, 0);
                //hNur.NurApiSendBroadcast(NurApi.BC_CMD_GET_DEV_INFO, NurApi.BC_FILTER_TYPE_NONE, 0, null, 0, null, 0);

                devices.Clear();
                deviceView.SelectedItems.Clear();
                deviceView.Items.Clear();
            }
            catch (Exception)
            {
            }
        }

        private void refreshListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = deviceView.SelectedItems[0];
                if (item != null)
                {
                    NurApi.DevInfoData data = (NurApi.DevInfoData)item.Tag;
                    if (IsServer(data))
                    {
                        if (ConnectToDevice != null)
                        {
                            connectBtn.Enabled = false;
                            ConnectToDevice(this, new DeviceArgs(EthHelper.IpToString(data.eth.ip), data.eth.serverPort));
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private bool IsServer(NurApi.DevInfoData data)
        {
            bool server = true;
            if (data.eth.hostmode > 0)
            {
                server = false;
                DialogResult dr = MessageBox.Show("Unable to connect device in client mode.\nDo you want to force server mode on?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    data.eth.transport = 1;    //Use Broadcast
                    data.eth.hostmode = 0;    //Use Server mode
                    mApi.SetEthConfig(ref data.eth);
                    server = true;
                }
            }
            return server;
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                mApi.Disconnect();
            }
            catch (Exception)
            {
            }
        }

        private void beepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (deviceView.SelectedItems.Count > 0)
                {
                    // Send BEEP broadcast to SELECTED device
                    ListViewItem item = deviceView.SelectedItems[0];
                    if (item != null)
                    {
                        NurApi.DevInfoData data = (NurApi.DevInfoData)item.Tag;

                        // Convert MAC address to ASCII HEX bytes
                        byte[] fdata = new byte[16];
                        string fstring = EthHelper.MacToString(data.eth.mac);
                        fstring = fstring.Replace("-", ""); // remove separators
                        fdata = System.Text.Encoding.ASCII.GetBytes(fstring);

                        // Create Beep buffer
                        byte[] beepBuf = new byte[2];
                        beepBuf[0] = (byte)60;  // BeepTime
                        beepBuf[1] = (byte)60;  // BeepDuty

                        // Send BEEP broadcast
                        mApi.NurApiSendBroadcast(
                            NurApi.BC_CMD_BEEP, NurApi.BC_FILTER_TYPE_MAC, NurApi.BC_FILTER_OP_EQUAL,
                            fdata, fstring.Length,
                            beepBuf, beepBuf.Length);
                    }
                }
                else
                {
                    // Send BEEP broadcast to ALL devices
                    // Create Beep buffer
                    byte[] beepBuf = new byte[2];
                    beepBuf[0] = (byte)60;  // BeepTime
                    beepBuf[1] = (byte)60;  // BeepDuty

                    // Send BEEP broadcast
                    mApi.NurApiSendBroadcast(
                        NurApi.BC_CMD_BEEP, NurApi.BC_FILTER_TYPE_NONE, 0, null, 0,
                        beepBuf, beepBuf.Length);
                }
            }
            catch (Exception)
            {
            }
        }

        public static bool ByteArraysEqual(byte[] b1, byte[] b2)
        {
            if (b1 == b2) return true;
            if (b1 == null || b2 == null) return false;
            if (b1.Length != b2.Length) return false;
            for (int i = 0; i < b1.Length; i++)
            {
                if (b1[i] != b2[i]) return false;
            }
            return true;
        }

        private void deviceView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (deviceView.SelectedItems.Count > 0)
                {
                    NurApi.DevInfoData data = (NurApi.DevInfoData)deviceView.SelectedItems[0].Tag;
                    connectToolStripMenuItem.Visible = data.status == 0;
                    disconnectToolStripMenuItem.Visible = data.status > 0;

                    if (data.status > 0)
                    {
                        if (mApi.IsConnected() && ByteArraysEqual(mApi.GetEthConfig().mac, data.eth.mac))
                        {
                            // Connected to this computer
                            connectBtn.Text = "Disconnect";
                            connectBtn.Enabled = true;

                            disconnectToolStripMenuItem.Enabled = true;
                        }
                        else
                        {
                            // Reserved
                            connectBtn.Text = "Connect";
                            connectBtn.Enabled = false;

                            disconnectToolStripMenuItem.Enabled = false;
                        }
                    }
                    else
                    {
                        // Free
                        connectBtn.Text = "Connect";
                        connectBtn.Enabled = true;

                        disconnectToolStripMenuItem.Enabled = false;
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString(), "Exception");
            }

            connectBtn.Text = "Connect";
            connectBtn.Enabled = false;

            connectToolStripMenuItem.Visible = false;
            disconnectToolStripMenuItem.Visible = false;
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            if (!connectBtn.Enabled)
                return;

            if (mApi.IsConnected())
                disconnectToolStripMenuItem_Click(sender, e);
            else
                connectToolStripMenuItem_Click(sender, e);
        }
    }
}
