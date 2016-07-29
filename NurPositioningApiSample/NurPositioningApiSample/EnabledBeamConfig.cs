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
using System.Windows.Forms;
using System.Runtime.InteropServices;
using NurApiDotNet;

namespace NurPositioningApiSample
{
   
    public partial class EnabledBeamConfig : UserControl
    {
        public const int BEAM_COUNT = 10;
        public const int FAR_BEAM_COUNT = 4;
        /// <summary>
        /// Physical beam position numbers in reader. Must match to BeamCoords
        /// </summary>
        public static int[] BeamNumbers = new int[BEAM_COUNT] {
            2, 1, 0, // BeamCoord [0-2]
            5, 4, 3, // BeamCoord [3-5]
            8, 7, 6,  // BeamCoord [6-8]
            9       // BeamCoord [9] far beam
        };

        public static int[] FarBeamNumbers = new int[FAR_BEAM_COUNT] {
            12,11,10,9
        };

        NurApi mApi;
        
        CheckBox[] mCheckboxes = new CheckBox[BEAM_COUNT];
        CheckBox[] mFarBeamCheckboxes = new CheckBox[FAR_BEAM_COUNT];

        private bool configuring = false;

        public EnabledBeamConfig()
        {
            InitializeComponent();

            if (mCheckboxes[0] == null)
            {
                for (int n = 0; n < mCheckboxes.Length - 1; n++)
                {
                    mCheckboxes[n] = new CheckBox();
                    mCheckboxes[n].AutoSize = true;
                    mCheckboxes[n].BackColor = Color.Transparent;
                    mCheckboxes[n].FlatStyle = FlatStyle.Flat;
                    mCheckboxes[n].Tag = BeamNumbers[n];
                    mCheckboxes[n].Text = ((int)mCheckboxes[n].Tag + 1).ToString();
                    mCheckboxes[n].Checked = false;
                    mCheckboxes[n].CheckedChanged += new EventHandler(GridAntennaSelector_CheckedChanged);
                    this.panel1.Controls.Add(mCheckboxes[n]);
                    Relayout();
                }
            }
            if (mFarBeamCheckboxes[0] == null)
            {
                for (int n = 0; n < mFarBeamCheckboxes.Length; n++)
                {
                    mFarBeamCheckboxes[n] = new CheckBox();
                    mFarBeamCheckboxes[n].AutoSize = true;
                    mFarBeamCheckboxes[n].BackColor = Color.Transparent;
                    mFarBeamCheckboxes[n].FlatStyle = FlatStyle.Flat;
                    mFarBeamCheckboxes[n].Tag = FarBeamNumbers[n];
                    mFarBeamCheckboxes[n].Text = ((int)mFarBeamCheckboxes[n].Tag + 1).ToString();
                    mFarBeamCheckboxes[n].Checked = false;
                    mFarBeamCheckboxes[n].CheckedChanged += new EventHandler(GridFarBeamAntennaSelector_CheckedChanged);
                    this.Controls.Add(mFarBeamCheckboxes[n]);
                    Relayout();

                }
            }
            panel1.Paint += panel1_Paint;
        }

  
        public void Config(NurApi hNur)
        {
            configuring = true;
            mApi = hNur;
            if (mApi != null && mApi.IsConnected())
            {
                for (int n = 0; n < mCheckboxes.Length - 1; n++)
                {
                    mCheckboxes[n].Checked = mApi.IsPhysicalAntennaEnabled("Beam" + mCheckboxes[n].Text);
                }
                try
                {
                    lbl_eb.Text = "Extra beams";
                    for (int n = 0; n < mFarBeamCheckboxes.Length; n++)
                    {
                        mFarBeamCheckboxes[n].Checked = mApi.IsPhysicalAntennaEnabled("Beam" + mFarBeamCheckboxes[n].Text);
                        mFarBeamCheckboxes[n].Enabled = true;
                    }
                }
                catch
                {
                    lbl_eb.Text = "Extra beams not available";
                    for (int n = 0; n < mFarBeamCheckboxes.Length; n++)
                    {
                        mFarBeamCheckboxes[n].Checked = false;
                        mFarBeamCheckboxes[n].Enabled = false;
                    }
                }
            }
            configuring = false;
        }
        void GridFarBeamAntennaSelector_CheckedChanged(object sender, EventArgs e)
        {
            bool enabled = false;

            string beam = "";
            if (!configuring)
            {
                for (int n = 0; n < mFarBeamCheckboxes.Length; n++)
                {
                    beam = "Beam" + mFarBeamCheckboxes[n].Text;
                    enabled = mApi.IsPhysicalAntennaEnabled(beam);
                    if (mFarBeamCheckboxes[n].Checked)
                    {
                        if (!enabled)
                            mApi.EnablePhysicalAntenna(beam);
                    }
                    else
                    {
                        if (enabled)
                            mApi.DisablePhysicalAntenna(beam);
                    }
                }
            }
        }
        void GridAntennaSelector_CheckedChanged(object sender, EventArgs e)
        {
            bool enabled = false;
            string beam = "";
            if (!configuring)
            {
                for (int n = 0; n < mCheckboxes.Length - 1; n++)
                {
                    beam = "Beam" + mCheckboxes[n].Text;
                    enabled = mApi.IsPhysicalAntennaEnabled(beam);
                    if (mCheckboxes[n].Checked)
                    {
                        if(!enabled)
                            mApi.EnablePhysicalAntenna(beam);
                    }
                    else
                    {
                        if(enabled)
                            mApi.DisablePhysicalAntenna(beam);
                    }
                }
            }
        }

        void Relayout()
        {
            float sectorW = (float)this.panel1.Width / 3.0f;
            float sectorH = (float)this.panel1.Height / 3.0f;

            float x = sectorW / 2.0f;
            float y = sectorH / 2.0f;
            for (int n = 0; n < mCheckboxes.Length - 1; n++)
            {
                if (mCheckboxes[n] == null)
                    break;
                mCheckboxes[n].Location = new Point((int)(x - mCheckboxes[n].Width / 2.0f), (int)(y - mCheckboxes[n].Height / 2.0f));
                x += sectorW;
                if (x > this.Width)
                {
                    x = sectorW / 2;
                    y += sectorH;
                }
            }
            sectorW = (float)this.panel1.Width / 4.0f;
            sectorH = (float)this.Height - this.panel1.Height;
            y = (sectorH / 2.0f) + this.panel1.Height;
            x = sectorW / 2.0f;
            for (int n = 0; n < mFarBeamCheckboxes.Length; n++)
            {
                if (mFarBeamCheckboxes[n] == null)
                    break;
                mFarBeamCheckboxes[n].Location = new Point((int)(x - mFarBeamCheckboxes[n].Width / 2.0f), (int)(y - mFarBeamCheckboxes[n].Height / 2.0f));
                x += sectorW;
                if (x > this.Width)
                {
                    x = sectorW / 2;
                    y += sectorH;
                }
            }
            lbl_eb.Location = new Point(0, panel1.Height);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            Relayout();
        }

        void panel1_Paint(object sender, PaintEventArgs e)
        {
            float sectorW = (float)this.panel1.Width / 3.0f;
            float sectorH = (float)this.panel1.Height / 3.0f;

            float x = sectorW;
            e.Graphics.DrawLine(Pens.DarkGray, new Point((int)x, 0), new Point((int)x, this.panel1.Height));
            x += sectorW;
            e.Graphics.DrawLine(Pens.DarkGray, new Point((int)x, 0), new Point((int)x, this.panel1.Height));

            float y = sectorH;
            e.Graphics.DrawLine(Pens.DarkGray, new Point(0, (int)y), new Point(this.panel1.Width, (int)y));
            y += sectorH;
            e.Graphics.DrawLine(Pens.DarkGray, new Point(0, (int)y), new Point(this.panel1.Width, (int)y));

            Rectangle r = this.panel1.ClientRectangle;
            r.Width--;
            r.Height--;
            e.Graphics.DrawRectangle(Pens.Black, r);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            float sectorW = (float)this.panel1.Width / 4.0f;
            float sectorH = (float)this.Height - this.panel1.Height;

            float x = sectorW;
            float y = this.panel1.Height;
            e.Graphics.DrawLine(Pens.DarkGray, new Point((int)x, (int)y), new Point((int)x, this.Height));
            x += sectorW;
            e.Graphics.DrawLine(Pens.DarkGray, new Point((int)x, (int)y), new Point((int)x, this.Height));
            x += sectorW;
            e.Graphics.DrawLine(Pens.DarkGray, new Point((int)x, (int)y), new Point((int)x, this.Height));

            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(new Point(0, this.panel1.Height), new Size(this.Width - 1, this.Height - this.panel1.Height -1)));
        }

        private void GridAntennaSelector_Click(object sender, EventArgs e)
        {

        }

        private void GridAntennaSelector_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                int gridx = (int)((float)e.X / (float)this.panel1.Width * 3.0f);
                int gridy = (int)((float)e.Y / (float)this.panel1.Height * 3.0f);
                int beamPos = gridy * 3 + gridx;
                if (beamPos < mCheckboxes.Length)
                {
                    if (mCheckboxes[beamPos] != null)
                        mCheckboxes[beamPos].Checked = !mCheckboxes[beamPos].Checked;
                }
            }
        }
    }
}
