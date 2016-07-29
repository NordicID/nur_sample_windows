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
    public partial class ConfigForm : Form
    {
        NurApi mApi;
        bool mDisableCheckEvent = false;

        public class TTEV
        {
            uint val = 0;
            public TTEV(uint _val)
            {
                val = _val;
            }
            public override string ToString()
            {
                string ret = "";
                if ((val & NurApi.TTEV_VISIBILITY) != 0)
                    ret += " ";
                if ((val & NurApi.TTEV_ANTENNA) != 0)
                    ret += "ANTENNA ";
                if ((val & NurApi.TTEV_RSSI) != 0)
                    ret += "RSSI ";
                if ((val & NurApi.TTEV_POSITION) != 0)
                    ret += "POSITION ";
                if ((val & NurApi.TTEV_SECTOR) != 0)
                    ret += "SECTOR ";
                if ((val & NurApi.TTEV_SCAN) != 0)
                    ret += "SCAN ";
                if ((val & NurApi.TTEV_INOUT) != 0)
                    ret += "INOUT ";
                return ret;
            }
        }

        public ConfigForm(NurApi hNur, ConfigTracking conf)
        {
            InitializeComponent();
            mApi = hNur;
            
            propertyGrid1.SelectedObject = conf;

            checklist_events.Items.Add("TTEV_VISIBILITY", true);
            checklist_events.Items.Add("TTEV_ANTENNA", true);
            checklist_events.Items.Add("TTEV_RSSI", false);
            checklist_events.Items.Add("TTEV_POSITION", false);
            checklist_events.Items.Add("TTEV_SECTOR", false);
            checklist_events.Items.Add("TTEV_SCAN", false);
            checklist_events.Items.Add("TTEV_INOUT", false);

            checklist_flags.Items.Add("TTFL_FULLROUNDREPORT", false);
            checklist_flags.Items.Add("TTFL_USESIMPLEFILTER", false);
            checklist_flags.Items.Add("TTFL_USECOMPLEXFILTER", false);
        }

        public uint GetFlags()
        {
            uint ret = NurApi.TTFL_NONE;
            for (int i = 0; i < checklist_flags.Items.Count; i++)
            {
                if (checklist_flags.GetItemChecked(i))
                {
                    ret |= (uint)(1 << i);
                }
            }
            return ret;
        }

        public uint GetEvents()
        {
            uint ret = NurApi.TTEV_NONE;
            for (int i = 0; i < checklist_events.Items.Count; i++)
            {
                if (checklist_events.GetItemChecked(i))
                {
                    ret |= (uint)(1 << i);
                }
            }
            return ret;
        }

        private void ConfigForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void ConfigForm_VisibleChanged(object sender, EventArgs e)
        {
            Fill();
        }

        void Fill()
        {
            if (mApi != null && mApi.IsConnected())
            {
                mDisableCheckEvent = true;
                try
                {
                    physAntListView.Items.Clear();
                    physAntListView.Items.Add(new ListViewItem("ALL"));
                    foreach (string physAnt in mApi.AvailablePhysicalAntennas)
                    {
                        physAntListView.Items.Add(new ListViewItem(physAnt));
                    }
                    physAntListView.Enabled = true;
                }
                catch (Exception e)
                {
                    physAntListView.Items.Add(new ListViewItem(e.Message));
                    physAntListView.Enabled = false;
                }

                mDisableCheckEvent = false;

                UpdateListViews();
            }
        }

        void UpdateListViews()
        {
            mDisableCheckEvent = true;
            if (physAntListView.Enabled)
            {
                try
                {
                    for (int n = 0; n < physAntListView.Items.Count; n++)
                    {
                        string physAnt = physAntListView.Items[n].Text;
                        if (mApi.IsPhysicalAntennaEnabled(physAnt))
                        {
                            physAntListView.Items[n].Checked = true;
                        }
                        else
                        {
                            physAntListView.Items[n].Checked = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            mDisableCheckEvent = false;
        }

        private void physAntListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (mDisableCheckEvent)
                return;

            try
            {
                string physAnt = e.Item.Text;
                if (e.Item.Checked)
                {
                    mApi.EnablePhysicalAntenna(physAnt);
                }
                else
                {
                    mApi.DisablePhysicalAntenna(physAnt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            UpdateListViews();
        }

    }
}
