using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NurApiDotNet;

namespace NurTagTrackingGate
{
    public partial class Form1 : Form
    {
        private ConfigForm cfgForm = null;
        private NurApi mApi = new NurApi();
        private ConfigTracking cfgTrack = new ConfigTracking();
        private bool mRunTT = false;

        //Internal tag tracking storage
        Dictionary<string, Dictionary<DateTime, NurApi.TagTrackingTag>> ttStorage = new Dictionary<string, Dictionary<DateTime, NurApi.TagTrackingTag>>();

        /// <summary>
        /// This sample code demonstrates how to use the NurApiTagTracking-features as a GateReader. The feature operates so that 
        /// When the tag moves from one of the inAntennas to outAntennas or vice versa and then the tag moves out of the RF-field,
        /// TagTracking will report a TTEV_INOUT event for the tag informing that the tag has moved from in to out or from out to in.
        /// The tag data contains also the antennaIds where the tag was seen first and last.
        /// </summary>
        public Form1()
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
                mApi.SetLogToFile(false);
                //ResizeAntennaView();

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

        private void hNur_TagTrackingChangeEvent(object sender, NurApi.TagTrackingChangeEventArgs e)
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
        
        private void UpdateTag(NurApi.TagTrackingTag tag)
        {
            string epc = NurApi.BinToHexString(tag.epc, tag.epcLen);
            DateTime n = DateTime.Now;
            Dictionary<DateTime, NurApi.TagTrackingTag> entries;
            if (!ttStorage.TryGetValue(epc, out entries))
            {
                // not seen, add to our internal storage
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

            //Tag moved from in to out or out to in
            if ((tag.changedEvents & NurApi.TTEV_INOUT) != 0)
            {
                ListViewItem item = new ListViewItem(new string[] {
                        epc,
                        "1" }, -1);
                item.Name = epc;

                if ((tag.directionTTIO & NurApi.TTIO_DIRECTION_INTOOUT) != 0)
                {
                    //Add it to out-list, otherwise just increment the count
                    if (!listOUT.Items.ContainsKey(epc))
                        listOUT.Items.Add(item);
                    else
                    {
                        int cnt = Convert.ToInt32(listOUT.Items[epc].SubItems[1].Text) + 1;
                        listOUT.Items[epc].SubItems[1] = new ListViewItem.ListViewSubItem(listOUT.Items[epc], cnt.ToString());
                    }
                }
                else if ((tag.directionTTIO & NurApi.TTIO_DIRECTION_OUTTOIN) != 0)
                {
                    //Add it to in-list, otherwise just increment the count
                    if (!listIN.Items.ContainsKey(epc))
                        listIN.Items.Add(item);
                    else
                    {
                        int cnt = Convert.ToInt32(listIN.Items[epc].SubItems[1].Text) + 1;
                        listIN.Items[epc].SubItems[1] = new ListViewItem.ListViewSubItem(listIN.Items[epc], cnt.ToString());
                    }
                }

                lbl_incnt.Text = listIN.Items.Count.ToString();
                lbl_outcnt.Text = listOUT.Items.Count.ToString();
            }

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
        }

        private void AddEventListItem(DateTime time, NurApi.TagTrackingTag tag)
        {
            ListViewItem item = new ListViewItem(new string[] {
                        time.ToLongTimeString(),
                        ChangedEventToString(tag.changedEvents),
                        tag.maxRssiAnt != -1 ? mApi.NurAntennaIdToPhysicalAntenna(tag.maxRssiAnt) : tag.maxRssiAnt.ToString(), 
                        tag.firstTTIOReadSource != -1 ? mApi.NurAntennaIdToPhysicalAntenna(tag.firstTTIOReadSource) : tag.firstTTIOReadSource.ToString(),
                        tag.secondTTIOReadSource != -1 ? mApi.NurAntennaIdToPhysicalAntenna(tag.secondTTIOReadSource) : tag.secondTTIOReadSource.ToString(),
                        TagDirectionToString(tag.directionTTIO),
                        tag.visible.ToString(),
                         }, -1);

            eventhistoryListView.Items.Add(item);
        }
        private string TagDirectionToString(int ttioDir)
        {
            string ret = "NONE";
            if ((ttioDir & NurApi.TTIO_DIRECTION_INTOOUT) != 0)
            {
                ret = "INTOUT";
            }
            else if ((ttioDir & NurApi.TTIO_DIRECTION_OUTTOIN) != 0)
            {
                ret = "OUTTOIN";
            }
            return ret;
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
            if ((ev & NurApi.TTEV_SCAN) != 0)
                ret += "SCAN ";
            if ((ev & NurApi.TTEV_INOUT) != 0)
                ret += "INOUT ";

            return ret;
        }

        

        // Reader disconnected
        void mApi_DisconnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            connectbutton.Text = "Connect";

            SetInfo("Status", "Disconnected");

            startbutton.Text = "Start Gate";
            startbutton.Enabled = false;
        }

        // Reader connected
        void mApi_ConnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            try
            {
                connectbutton.Text = "Disconnect";

                SetInfo("Status", "Connected");
                startbutton.Text = "Start Gate";
                startbutton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connectbutton.Text = "Connect";
                SetInfo("Status", "Device not supported");
            }
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

        private void clearbutton_Click(object sender, EventArgs e)
        {
            // Open config form
            if (cfgForm == null)
                cfgForm = new ConfigForm(mApi, cfgTrack);

            if (!cfgForm.Visible)
                cfgForm.Show(this);
            else
                cfgForm.BringToFront();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // USB autoconnect checkbox
            mApi.SetUsbAutoConnect(checkBox1.Checked);
            groupBox1.Enabled = !checkBox1.Checked;
        }

        private void quitbutton_Click(object sender, EventArgs e)
        {
            // Quit
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop all activity
            if (mApi.IsTagTrackingRunning())
                mApi.StopTagTracking();
            mApi.Dispose();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            // Resize antennaview
            //ResizeAntennaView();
        }

        private void GetSelectMask(ref byte[] mask, ref uint maskOff, ref ushort maskLen)
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

        private void ClearTags()
        {
            ttStorage.Clear();
            listIN.Items.Clear();
            listOUT.Items.Clear();
            tagListView.Items.Clear();

            eventhistoryListView.Items.Clear();
        }

        private void startbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!mApi.IsTagTrackingRunning())
                {
                    if (cfgForm == null)
                        cfgForm = new ConfigForm(mApi, cfgTrack);

                    NurApi.TagTrackingConfig cfg = new NurApi.TagTrackingConfig()
                    {
                        flags = cfgForm.GetFlags(), //TTEV_FULLROUNDREPORT by default
                        events = cfgForm.GetEvents(), //TTEV_VISIBILITY, TTEV_ANTENNA and TTEV_INOUT by default
                        rssiDeltaFilter = (int)cfgTrack.RssiDeltaFilter,
                        positionDeltaFilter = (float)cfgTrack.PositionDeltaFilter,
                        scanUntilNewTagsCount = (int)cfgTrack.ScanUntilNewTagsCount,
                        visibilityTimeout = (int)cfgTrack.VisibilityTimeout,
                        complexFilters = null
                    };

                    cfg.selectMask = new byte[62];
                    GetSelectMask(ref cfg.selectMask, ref cfg.selectAddress, ref cfg.selectMaskBitLength);
                    
                    cfg.selectBank = cfgTrack.SelectBank;

                    // Get the physical antenna mask for the antennas we want to use as the In-antennas
                    cfg.inAntennaMask = mApi.GetPhysicalAntennaMask(cfgForm.GetInAntennas());
                    // Get the physical antenna mask for the antennas we want to use as the Out-antennas
                    cfg.outAntennaMask = mApi.GetPhysicalAntennaMask(cfgForm.GetOutAntennas());

                    mApi.ULog("StartTagTracking");
                    ClearTags();
                    
                    mRunTT = true;

                    mApi.StartTagTracking(ref cfg);
                    startbutton.Text = "Stop Positioning";

                    lbl_outcnt.Text = "0";
                    lbl_incnt.Text = "0";
                }
                else
                {
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
    }
}
