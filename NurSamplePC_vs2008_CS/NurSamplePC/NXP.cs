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
    public partial class NXP : UserControl
    {
        public NXP()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the hadle of nur API.
        /// </summary>
        /// <param name="hNur">Handle of NurApi.</param>
        public void SetNurApi(NurApi hNur)
        {
            this.Enabled = true;
            nxpProductStatusFlag.SetNurApi(hNur);
            nxpEasAlarm.SetNurApi(hNur);
            nxpReadProtect.SetNurApi(hNur);
        }
    }
}
