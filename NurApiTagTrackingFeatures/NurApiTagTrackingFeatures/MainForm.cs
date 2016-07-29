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

using NurApiDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NurApiTagTrackingFeatures 
{
    public partial class MainForm : Form
    {
        NurApi mApi;
        bool mRunTT = false;

        //Internal tag tracking storage
        Dictionary<string, Dictionary<DateTime, NurApi.TagTrackingTag>> ttStorage = new Dictionary<string, Dictionary<DateTime, NurApi.TagTrackingTag>>();

        public MainForm()
        {
            InitializeComponent();

            // Read previous settings
            ethAddr.Text = Properties.Settings.Default.EthAddr1;
            ethPort.Value = Properties.Settings.Default.EthPort2;

            try
            {
                // Create nur api
                mApi = new NurApi(this);
                mApi.ConnectedEvent += mApi_ConnectedEvent;
                mApi.DisconnectedEvent += mApi_DisconnectedEvent;
                mApi.TagTrackingChangeEvent += hNur_TagTrackingChangeEvent;
                mApi.TagTrackingScanEvent += mApi_TagTrackingScanEvent;
                //mApi.SetLogLevel(NurApi.LOG_VERBOSE | NurApi.LOG_USER | NurApi.LOG_ERROR);
                mApi.SetLogToFile(false);
                ResizeAntennaView();

                // Not connected status
                SetInfo("Status", "Disconnected");
                startbutton.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        void mApi_TagTrackingScanEvent(object sender, NurApi.TagTrackingScanEventArgs e)
        {
            MoveInventoryIndicator(e.data.readSource);
        }

        // Set text in info listview
        void SetInfo(string key, string value)
        {
            for (int n = 0; n < listView1.Items.Count; n++)
            {
                if (listView1.Items[n].Text == key)
                {
                    if (value == null)
                    {
                        listView1.Items.RemoveAt(n);
                    }
                    else
                    {
                        listView1.Items[n].SubItems[1].Text = value;
                    }
                    return;
                }
            }

            ListViewItem lvi = new ListViewItem(new string[] { key, value });
            listView1.Items.Add(lvi);
        }

        // Reader disconnected
        void mApi_DisconnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            connectbutton.Text = "Connect";

            SetInfo("Status", "Disconnected");

            startbutton.Text = "Start Positioning";
            startbutton.Enabled = false;
        }

        // Reader connected
        void mApi_ConnectedEvent(object sender, NurApi.NurEventArgs e)
        {
             try
            {
                connectbutton.Text = "Disconnect";
                tagsPerAntennaControl1.Config(mApi);
       
                SetInfo("Status", "Connected");
                startbutton.Text = "Start Positioning";
                startbutton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connectbutton.Text = "Connect";
                SetInfo("Status", "Device not supported");
            }
        }

        // Move beam indicator to correct antenna position
        void MoveInventoryIndicator(int antId)
        {
            if (antId < 0 || antId >= tagsPerAntennaControl1.AntennaCount())
                return;

            tagsPerAntennaControl1.MoveIndicator(antId);
        }

        void UpdateTag(NurApi.TagTrackingTag tag)
        {
            string epc = NurApi.BinToHexString(tag.epc, tag.epcLen);
            DateTime n = DateTime.Now;
            Dictionary<DateTime, NurApi.TagTrackingTag> entries;
            if (!ttStorage.TryGetValue(epc, out entries))
            {
                entries = new Dictionary<DateTime, NurApi.TagTrackingTag>();
                ttStorage.Add(epc, entries);

                ListViewItem lvi = new ListViewItem(epc);
                lvi.Name = epc;
                lvi.Tag = entries;
                lvi.SubItems.Add("bob");
                lvi.SubItems.Add("smith");
                tagListView.Items.Add(lvi);
            }

            entries.Add(n, tag);

            if (tagListView.SelectedItems != null)
            {
                foreach (ListViewItem item in tagListView.SelectedItems)
                {
                    if (item.Name == epc)
                    {
                        AddEventListItem(n, tag);
                    }
                }
            }

            if (this.tagsPerAntennaControl1 != null)
                tagsPerAntennaControl1.UpdateTags(tag);
        }

        void hNur_TagTrackingChangeEvent(object sender, NurApi.TagTrackingChangeEventArgs e)
        {
            List<NurApi.TagTrackingTag> list = e.tags;
            foreach (NurApi.TagTrackingTag t in list)
            {
                UpdateTag(t);
            }    

            //Tracking stopped?
            if (e.data.stopped && mRunTT)
            {
                mApi.RestartTagTracking();
            }
        }

        private void KeepInCircle(ref NurApi.TagTrackingTag tag, float radius)
        {
            // Make sure 'pos' is kept inside given radius
            PointF pos = new PointF(tag.X, tag.Y);
            PointF center = new PointF(0.5f, 0.5f);
            PointF delta = new PointF(pos.X - center.X, pos.Y - center.Y);
            float vectorLen = (float)Math.Sqrt((delta.X * delta.X) + (delta.Y * delta.Y));
            if (vectorLen > radius)
            {
                float radians = (float)Math.Atan2((double)(pos.Y - center.Y), (double)(pos.X - center.X));
                tag.X = center.X + radius * (float)Math.Cos(radians);
                tag.Y = center.Y + radius * (float)Math.Sin(radians);
            }
        }

        void ResizeAntennaView()
        {
            Point loc = Point.Empty;
            Size size = tabPage2.Size;

            // Keep tagview panel size square
            if (size.Width < size.Height)
            {
                size.Height = size.Width;
                loc.Y = (int)(((float)(tabPage2.Height - size.Height)) / 2.0f);
            }
            else
            {
                size.Width = size.Height;
                loc.X = (int)(((float)(tabPage2.Width - size.Width)) / 2.0f);
            }

            tagsPerAntennaControl1.Location = loc;
            tagsPerAntennaControl1.Size = size;

            tagsPerAntennaControl1.Resize();
        }
        

        void GetSelectMask(ref byte[] mask, ref uint maskOff, ref ushort maskLen)
        {
            string dataStr = cfgTrack.ByteFilter;

            if (dataStr.Length == 0)
                dataStr = cfgTrack.ByteFilter;

            byte[] data = NurApi.HexStringToBin(dataStr);

            //mask = data;
            Array.Copy(data, mask, data.Length);
            maskLen = cfgTrack.SelectMaskBitLength;
            maskOff = cfgTrack.SelectAddress;
        }

        private void startbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!mApi.IsTagTrackingRunning()) {
                    if (cfgForm == null)
                        cfgForm = new ConfigForm(mApi, cfgTrack);

                    NurApi.TagTrackingConfig cfg = new NurApi.TagTrackingConfig()
                    {
                        flags = cfgForm.GetFlags(),
                        events = cfgForm.GetEvents(),
                        rssiDeltaFilter = (int)cfgTrack.RssiDeltaFilter, 
                        positionDeltaFilter = (float)cfgTrack.PositionDeltaFilter,
                        scanUntilNewTagsCount = (int)cfgTrack.ScanUntilNewTagsCount,
                        visibilityTimeout = (int)cfgTrack.VisibilityTimeout,
                        complexFilters = null 
                    };

                    cfg.selectMask = new byte[62];
                    GetSelectMask(ref cfg.selectMask, ref cfg.selectAddress, ref cfg.selectMaskBitLength);
                    //Do we have a filter available?
                    cfg.selectBank = cfgTrack.SelectBank;
                    mApi.ULog("StartTagTracking");
                    ClearTags();

                    mRunTT = true;

                    mApi.StartTagTracking(ref cfg);
                    startbutton.Text = "Stop Positioning";
                } else {
                    mRunTT = false;
                    mApi.StopTagTracking();
                    startbutton.Text = "Start Positioning";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }
        }
        
        private void ClearTags()
        {
            ttStorage.Clear();
            
            tagListView.Items.Clear();

            tagsPerAntennaControl1.ClearTags();

            eventhistoryListView.Items.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void searchEthButton_Click(object sender, EventArgs e)
        {
            // Open ethernet device search form
            EthSearchForm ethForm = new EthSearchForm(mApi);
            if (ethForm.ShowDialog() == DialogResult.OK)
            {
                ethAddr.Text = ethForm.ConnArgs.addr;
                ethPort.Value = ethForm.ConnArgs.port;
                
                if (mApi.IsConnected())
                    mApi.Disconnect();

                connectbutton_Click(null, null);                
            }
            ethForm.Dispose();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            // Resize antennaview
            ResizeAntennaView();
        }

        private void connectbutton_Click(object sender, EventArgs e)
        {
            // Connect/Disconnect
            try
            {
                if (mApi.IsConnected())
                    mApi.Disconnect();
                else
                {
                    mApi.ConnectSocket(ethAddr.Text, (int)ethPort.Value);

                    // Save settings
                    Properties.Settings.Default.EthAddr1 = ethAddr.Text;
                    Properties.Settings.Default.EthPort2 = (int)ethPort.Value;
                    Properties.Settings.Default.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
        private delegate void AddEventListItemDelegate(DateTime time, NurApi.TagTrackingTag tag);
        private void AddEventListItem(DateTime time, NurApi.TagTrackingTag tag)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new AddEventListItemDelegate(AddEventListItem), new object[] { time , tag });
                return;
            }
            ListViewItem item = new ListViewItem(new string[] {
                        time.ToLongTimeString(),
                        ChangedEventToString(tag.changedEvents),
                        tag.maxRssiAnt.ToString(),
                        tag.maxRssi.ToString(),
                        tag.visible.ToString(),
                        "X " +tag.X.ToString() + " Y" + tag.Y.ToString(),
                        tag.directionTTIO.ToString(),
                        tag.firstTTIOReadSource.ToString(),
                        tag.secondTTIOReadSource.ToString(),
                        }, -1);

            eventhistoryListView.Items.Add(item);
        }

        private void tagListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in tagListView.Items)
            {
                Dictionary<DateTime, NurApi.TagTrackingTag> ud = lvi.Tag as Dictionary<DateTime, NurApi.TagTrackingTag>;

                if (lvi.Selected)
                {
                    eventhistoryListView.Items.Clear();
                    foreach (KeyValuePair<DateTime, NurApi.TagTrackingTag> entry in ud)
                    {
                        AddEventListItem(entry.Key, entry.Value);
                    }
                }
            }
        }

        private string ChangedEventToString(int ev)
        {
            string ret = "";
            if ((ev & NurApi.TTEV_VISIBILITY) != 0)
                ret += "VISIBILITY ";
            if ((ev & NurApi.TTEV_ANTENNA) != 0)
                ret += "ANTENNA ";
            if ((ev & NurApi.TTEV_RSSI) != 0)
                ret += "RSSI ";
            if ((ev & NurApi.TTEV_POSITION) != 0)
                ret += "POSITION ";
            if ((ev & NurApi.TTEV_SECTOR) != 0)
                ret += "SECTOR ";
            if ((ev & NurApi.TTEV_INOUT) != 0)
                ret += " INOUT";

            return ret;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop all activity
            if (mApi.IsTagTrackingRunning())
                mApi.StopTagTracking();
            mApi.Dispose();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // USB autoconnect checkbox
            mApi.SetUsbAutoConnect(checkBox1.Checked);
            groupBox1.Enabled = !checkBox1.Checked;
        }

        private ConfigForm cfgForm = null;
        private ConfigTracking cfgTrack = new ConfigTracking();
        
        private void button1_Click(object sender, EventArgs e)
        {
            // Open config form
            if (cfgForm == null)
                cfgForm = new ConfigForm(mApi, cfgTrack);
    
            if (!cfgForm.Visible)
                cfgForm.Show(this);
            else
                cfgForm.BringToFront();
        }

        private void quitbutton_Click(object sender, EventArgs e)
        {
            // Quit
            this.Close();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Clear all
            tagListView.Items.Clear();
        }

        private void tabPage2_Resize(object sender, EventArgs e)
        {
            ResizeAntennaView();
        }

    }
}
