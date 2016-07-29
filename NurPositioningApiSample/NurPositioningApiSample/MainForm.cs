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

namespace NurPositioningApiSample
{
    public partial class MainForm : Form
    {
        NurApi mApi;
        bool mRunTT = false;
        // Tag userdata holder
        class TagUserData
        {
            public NurApi.TagTrackingTag tag;
            public Control tagViewCtl;
            public ListViewItem lvItem;
        }
        public MainForm()
        {
            InitializeComponent();

            // Read previous settings
            ethAddr.Text = Properties.Settings.Default.EthAddr;
            ethPort.Value = Properties.Settings.Default.EthPort;

            try
            {
                // Create nur api
                mApi = new NurApi(this);
                mApi.ConnectedEvent += mApi_ConnectedEvent;
                mApi.DisconnectedEvent += mApi_DisconnectedEvent;
                mApi.TagTrackingChangeEvent += hNur_TagTrackingChangeEvent;
                mApi.TagTrackingScanEvent += mApi_TagTrackingScanEvent;
                mApi.SetLogLevel(NurApi.LOG_VERBOSE | NurApi.LOG_ERROR );
                mApi.LogEvent += mApi_LogEvent;
                ResizeTagView();
                ResizeSectorView();

                // Not connected status
                SetInfo("Status", "Disconnected");
                label1.Visible = false;
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
            LogString("TT Scan event readSource " + e.data.readSource.ToString() + " started " + e.data.started.ToString());
            MoveInventoryIndicator(e.data.readSource);
        }

        void mApi_LogEvent(object sender, NurApi.LogEventArgs e)
        {
            LogString(e.message);
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
            label1.Visible = false;

            startbutton.Text = "Start Positioning";
            startbutton.Enabled = false;
        }

        // Reader connected
        void mApi_ConnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            connectbutton.Text = "Disconnect";

            // Make sure reader supports beam antenna configuration
            if (mApi.GetDeviceCaps().beamAntenna)
            {
                SetInfo("Status", "Connected");
                startbutton.Text = "Start Positioning";
                startbutton.Enabled = true;
            }
            else
            {
                SetInfo("Status", "Device not supported");
                startbutton.Enabled = false;
            }
        }

        // Move beam indicator to correct beam position
        void MoveInventoryIndicator(int n)
        {
            if (n < 0 || n >= EnabledBeamConfig.BeamNumbers.Length)
                return;

            int beampos = EnabledBeamConfig.BeamNumbers[n];
            int bx = beampos % 3;
            int by = beampos / 3;

            float rw = tagviewpanel.Width / 3.0f;
            float rh = tagviewpanel.Height / 3.0f;

            Point loc = new Point((int)(bx * rw), (int)(by * rh));
            loc.Offset(2, 2);

            label1.Location = loc;
            label1.Text = "Beam" + (n + 1);
            if (!label1.Visible)
                label1.Visible = true;
        }
        void RemoveMissingTag(NurApi.TagTrackingTag tag)
        { 
            string epc = NurApi.BinToHexString(tag.epc, tag.epcLen);
            TagUserData ud = null;
            if (ttStorage.TryGetValue(epc, out ud))
            {
                if(ud != null)
                    tagviewpanel.Controls.Remove(ud.tagViewCtl);

                ttStorage.Remove(epc);
            }

            if (this.tagsPerBeamControl1 != null)
                tagsPerBeamControl1.Remove(tag);
        }

        void UpdateTagPos(NurApi.TagTrackingTag tag)
        {
            string epc = NurApi.BinToHexString(tag.epc, tag.epcLen);
            TagUserData ud = null;
            //Have we seen this epc already?
            if (!ttStorage.TryGetValue(epc, out ud))
            {
                // New tag, create tag control            
                Label ctl = new Label();
                ctl.Size = new Size(10, 10);
                ctl.BackColor = Color.Black;
                ctl.BringToFront();

                // Make it round
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddEllipse(0, 0, ctl.Width, ctl.Height);
                ctl.Region = new Region(path);

                // Add to tagview
               
                tagviewpanel.Controls.Add(ctl);

                // Add to tag listview
                ListViewItem lvi = new ListViewItem(epc);
                lvi.Name = epc;
                lvi.SubItems.Add("bob");
                lvi.SubItems.Add("smith");

                if (!tagListView.Items.ContainsKey(epc))
                {
                    tagListView.Items.Add(lvi);
                }
                else
                {
                    lvi = tagListView.Items[epc];                
                }

                // Userdata holder
                ud = new TagUserData()
                {
                    tag = tag,
                    tagViewCtl = ctl,
                    lvItem = lvi
                };

                // Set userdata references
                lvi.Tag = ud;
                ctl.Tag = ud;
                //e.tag.UserData = ud;
                ttStorage.Add(epc, ud);
                
                //hNur.ULog("Add " + epc);
            }
            else
            {
                ttStorage[epc].tag = tag;
                //hNur.ULog("Update " + epc);
            }

            ud.lvItem.SubItems[1].Text = tag.maxRssi.ToString();
            ud.lvItem.SubItems[2].Text = tag.sector.ToString();

            SetControlTagViewPosition(ud.tagViewCtl);

            if (this.tagsPerBeamControl1 != null)
                tagsPerBeamControl1.UpdateTags(tag);
        }

        private void LogString(string s)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate { LogString(s); }));
                return;
            }
            DateTime now = DateTime.Now;
            listbox_events.Items.Add(String.Format("{0:H:mm:ss}", now) 
                + "\t" + s );
        }

        private void LogEvent(NurApi.TagTrackingChangeEventArgs e)
        { 
            DateTime now = DateTime.Now;
            listbox_events.Items.Add(String.Format("{0:H:mm:ss}", now) 
                + "\tchangedEventMask" + e.data.changedEventMask.ToString()
                + "\treadSource " + e.data.readSource.ToString()
                + "\tstopped " + e.data.stopped.ToString()
                + "\tchangedCount " + e.data.changedCount.ToString());

            if ((e.data.changedEventMask & NurApi.TTEV_INOUT) != 0)
            {
                listbox_events.Items.Add(String.Format("{0:H:mm:ss}", now)
                    + "\t TTEV_INOUT");
                foreach (NurApi.TagTrackingTag tag in e.tags)
                {
                    if ((tag.changedEvents & NurApi.TTEV_INOUT) != 0)
                    {
                        listbox_events.Items.Add(String.Format("{0:H:mm:ss}", now)
                            + "\t"+NurApi.BinToHexString(tag.epc, tag.epcLen)
                            + "\t TTEV_INOUT"
                            + "\t direction " + tag.directionTTIO.ToString()
                            + "\t first " + tag.firstTTIOReadSource.ToString()
                            + "\t second " + tag.secondTTIOReadSource.ToString()
                            + "\t visibility " + tag.visible.ToString());
                    }
                }
            }

            listbox_events.SelectedIndex = listbox_events.Items.Count - 1;
        }

        void hNur_TagTrackingChangeEvent(object sender, NurApi.TagTrackingChangeEventArgs e)
        {
            LogEvent(e);
            uint tagSeen = 0;
            List<NurApi.TagTrackingTag> list = e.tags;
            foreach (NurApi.TagTrackingTag t in list)
            {
                tagSeen = 0;

                // Sum the seen count for each antenna
                for (int i = 0; i < t.seenCnt.Length; i++)
                {
                    tagSeen += t.seenCnt[i];
                }

                // If it's less, don't update the tags position
                if (tagSeen >= cfgTrack.SeenCount)
                {
                    //Position changed
                    //if ((t.changedEvents & NurApi.TTEV_POSITION) != 0)
                    {
                        UpdateTagPos(t);
                    }
                }
                //Visibility changed
                if ((t.changedEvents & NurApi.TTEV_VISIBILITY) != 0)
                {
                    //Tag is no longer visible, remove it from our view
                    if (t.visible == 0)
                        RemoveMissingTag(t);
                }
            }

            //Tracking stopped?
            if (e.data.stopped && mRunTT)
            {
                mApi.RestartTagTracking();
            }
        }

        void SetControlTagViewPosition(Control c)
        {
            // Make sure control represents tag in view
            TagUserData ud = c.Tag as TagUserData;
            if (ud == null)
                return;

            if (ud.tag.visible == 0)
            {
                if (c.Visible)
                {
                    // Set listviewitem color and hide control
                    ud.lvItem.ForeColor = Color.Red;
                    c.Visible = false;
                }
                return;
            }

            // If control was hidden, show again
            if (!c.Visible)
            {
                ud.lvItem.ForeColor = Color.Black;
                c.Visible = true;
            }

            double amount = (double)ud.tag.maxScaledRssi * .01;
            //amount += .2;
            //if (amount > 1) amount = 1;
            c.BackColor = Blend(Color.DarkGreen, Color.LightGray, amount);

            // Scale normalized position to tagview position
            Point loc = Point.Empty;
            
            // Position information not available, just fix the position to the center of the sector
            if ((cfgForm.GetEvents() & NurApi.TTEV_POSITION) == 0)
            {
                int level = 0;
                if (ud.tag.sector >= 1 && ud.tag.sector <= 3)
                {
                    level = 0;
                }
                else if (ud.tag.sector >= 4 && ud.tag.sector <= 6)
                {
                    level = 1;
                }
                else if (ud.tag.sector >= 7 && ud.tag.sector <= 9)
                {
                    level = 2;
                }
                loc.X = ((4 - (ud.tag.sector - (3 * level))) * (tagviewpanel.Width / 3)) - ((tagviewpanel.Width / 3) / 2);
                loc.Y = ((tagviewpanel.Height / 3) * (level + 1)) - ((tagviewpanel.Height / 3) / 2);
            }
            else
            {
                loc.X = (int)((float)tagviewpanel.Width * ud.tag.X);
                loc.Y = (int)((float)tagviewpanel.Height * ud.tag.Y);
            }

            // Adjust to center point of control
            loc.X -= c.Width / 2;
            loc.Y -= c.Height / 2;

            // Move
            if (loc != c.Location)
                c.Location = loc;
        }

        public static Color Blend(Color color, Color backColor, double amount)
        {
            byte r = (byte)((color.R * amount) + backColor.R * (1 - amount));
            byte g = (byte)((color.G * amount) + backColor.G * (1 - amount));
            byte b = (byte)((color.B * amount) + backColor.B * (1 - amount));
            return Color.FromArgb(r, g, b);
        }
        void ResizeSectorView()
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

            tagsPerBeamControl1.Location = loc;
            tagsPerBeamControl1.Size = size;

            tagsPerBeamControl1.Resize();
        }
        void ResizeTagView()
        {
            Point loc = Point.Empty;
            Size size = tabPage1.Size;

            // Keep tagview panel size square
            if (size.Width < size.Height)
            {
                size.Height = size.Width;
                loc.Y = (int)(((float)(tabPage1.Height - size.Height)) / 2.0f);
            }
            else
            {
                size.Width = size.Height;
                loc.X = (int)(((float)(tabPage1.Width - size.Width)) / 2.0f);
            }

            tagviewpanel.Location = loc;
            tagviewpanel.Size = size;

            // Reposition tags
            foreach (Control c in tagviewpanel.Controls)
            {
                SetControlTagViewPosition(c);
            }
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

        static public uint PhysBeamToAntennaMask(int a)
        {
            int beamAnt = (a * 2);
            int ret = (3 << beamAnt);
            return (uint)ret;
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

                    //cfg.selectMask = new byte[62];
                    cfg.selectMask = new byte[62];
                    GetSelectMask(ref cfg.selectMask, ref cfg.selectAddress, ref cfg.selectMaskBitLength);

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
                label1.Visible = mApi.IsTagTrackingRunning();
                
            }
        }
        
        //Internal tag tracking storage
        Dictionary<string, TagUserData> ttStorage = new Dictionary<string, TagUserData>();

        private void ClearTags()
        {
            ttStorage.Clear();
            // Remove all tags in tagview
            for (int n = tagviewpanel.Controls.Count - 1; n >= 0; n--)
            {
                if (tagviewpanel.Controls[n].Tag is TagUserData)
                {
                    tagviewpanel.Controls.RemoveAt(n);
                }
            }
            tagListView.Items.Clear();

            tagsPerBeamControl1.ClearTags();
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
            // Resize tagview
            ResizeTagView();
            ResizeSectorView();
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
                    Properties.Settings.Default.EthAddr = ethAddr.Text;
                    Properties.Settings.Default.EthPort = (int)ethPort.Value;
                    Properties.Settings.Default.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void tagListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set selected tag(s) color to red
            foreach (ListViewItem lvi in tagListView.Items)
            {
                TagUserData ud = lvi.Tag as TagUserData;

                if (lvi.Selected)
                {
                    ud.tagViewCtl.BackColor = Color.DarkRed;
                    ud.tagViewCtl.BringToFront();
                }
                else
                {
                    ud.tagViewCtl.BackColor = Color.DarkGray;
                }
            }
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

            //pApi.Storage.Clear();

            // Remove all tags in tagview
            for (int n = tagviewpanel.Controls.Count - 1; n >= 0; n--)
            {
                if (tagviewpanel.Controls[n].Tag is TagUserData)
                {
                    tagviewpanel.Controls.RemoveAt(n);
                }
            }
        }

        private void tabPage2_Resize(object sender, EventArgs e)
        {
            ResizeSectorView();
        }

        private void tabPage1_Resize(object sender, EventArgs e)
        {
            ResizeTagView();
        }
    }
}
