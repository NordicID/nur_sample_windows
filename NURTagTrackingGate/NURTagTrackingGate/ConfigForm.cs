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

namespace NurTagTrackingGate 
{
    public partial class ConfigForm : Form
    {
        NurApi mApi;
        bool mDisableCheckEvent = false;

        public ConfigForm(NurApi hNur, ConfigTracking conf)
        {
            InitializeComponent();
            mApi = hNur;
            
            propertyGrid1.SelectedObject = conf;

            // For the gate feature we would only need TTEV_INOUT, but add VISIBILITY and ANTENNA to demonstrate the changes
            checklist_events.Items.Add("TTEV_VISIBILITY", false);
            checklist_events.Items.Add("TTEV_ANTENNA", false);
            checklist_events.Items.Add("TTEV_RSSI", false);
            checklist_events.Items.Add("TTEV_POSITION", false);
            checklist_events.Items.Add("TTEV_SECTOR", false);
            checklist_events.Items.Add("TTEV_SCAN", false);
            checklist_events.Items.Add("TTEV_INOUT", true);

            checklist_flags.Items.Add("TTFL_FULLROUNDREPORT", true);
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

                    physAntennaGateIn.Items.Clear();
                    physAntennaGateOut.Items.Clear();

                    foreach (string physAnt in mApi.AvailablePhysicalAntennas)
                    {
                        physAntListView.Items.Add(new ListViewItem(physAnt));

                        ListViewItem inAnt = new ListViewItem(physAnt);
                        ListViewItem outAnt = new ListViewItem(physAnt);

                        if (Properties.Settings.Default.InAntennas.Contains(physAnt))
                            inAnt.Checked = true;
                        else
                            inAnt.Checked = false;
   
                        if (Properties.Settings.Default.OutAntennas.Contains(physAnt))
                            outAnt.Checked = true;
                        else
                            outAnt.Checked = false;

                        physAntennaGateIn.Items.Add(inAnt);
                        physAntennaGateOut.Items.Add(outAnt);
                    }
                    physAntListView.Enabled = true;
                    physAntennaGateIn.Enabled = true;
                    physAntennaGateOut.Enabled = true;
                }
                catch (Exception e)
                {
                    physAntListView.Items.Add(new ListViewItem(e.Message));
                    physAntListView.Enabled = false;
                    physAntennaGateIn.Enabled = false;
                    physAntennaGateOut.Enabled = false;
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

        public string GetInAntennas()
        {
            return Properties.Settings.Default.InAntennas;
        }

        public string GetOutAntennas()
        {
            return Properties.Settings.Default.OutAntennas;
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

        private void physAntennaGateIn_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (mDisableCheckEvent)
                return;

            Properties.Settings.Default.InAntennas = "";
            for (int n = 0; n < physAntennaGateIn.Items.Count; n++)
            {
                string physAnt = physAntennaGateIn.Items[n].Text;
                if (physAntennaGateIn.Items[n].Checked)
                {
                    if (Properties.Settings.Default.InAntennas.Length > 0)
                        Properties.Settings.Default.InAntennas += ",";
                    Properties.Settings.Default.InAntennas += physAnt;
                }
            }
            Properties.Settings.Default.Save();
        }

        private void physAntennaGateOut_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (mDisableCheckEvent)
                return;

            Properties.Settings.Default.OutAntennas = "";
            for (int n = 0; n < physAntennaGateOut.Items.Count; n++)
            {
                string physAnt = physAntennaGateOut.Items[n].Text;
                if (physAntennaGateOut.Items[n].Checked)
                {
                    if (Properties.Settings.Default.OutAntennas.Length > 0)
                        Properties.Settings.Default.OutAntennas += ",";
                    Properties.Settings.Default.OutAntennas += physAnt;
                }
            }
            Properties.Settings.Default.Save();
        }

    }
}
