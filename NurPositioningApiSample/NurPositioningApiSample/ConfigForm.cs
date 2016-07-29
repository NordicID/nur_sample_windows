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
    public partial class ConfigForm : Form
    {
        NurApi mApi;
        public ConfigForm(NurApi hNur, ConfigTracking conf)
        {
            InitializeComponent();
            mApi = hNur;
            enabledBeamConfig1.Config(mApi);
            propertyGrid1.SelectedObject = conf;


            checklist_events.Items.Add("TTEV_VISIBILITY", true);
            checklist_events.Items.Add("TTEV_ANTENNA", false);
            checklist_events.Items.Add("TTEV_RSSI", false);
            checklist_events.Items.Add("TTEV_POSITION", true);
            checklist_events.Items.Add("TTEV_SECTOR", true);
            checklist_events.Items.Add("TTEV_SCAN", false);
            checklist_events.Items.Add("TTEV_INOUT", false);

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
            enabledBeamConfig1.Config(mApi);
        }
    }
}
