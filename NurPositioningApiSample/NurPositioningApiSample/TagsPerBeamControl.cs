using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NurApiDotNet;

namespace NurPositioningApiSample
{
    public partial class TagsPerBeamControl : UserControl
    {
        ListBox[] epcBoxes = new ListBox[EnabledBeamConfig.BEAM_COUNT];

        public TagsPerBeamControl()
        {
            InitializeComponent();

            //Create listbox for each sector
            if (epcBoxes[0] == null)
            {
                int sectorW = this.Width / 3;
                int sectorH = this.Height / 4;
                for (int n = 0; n < epcBoxes.Length; n++)
                {
                    epcBoxes[n] = new ListBox();
                    epcBoxes[n].Size = new System.Drawing.Size(sectorW - 2, sectorH - 1);
                    epcBoxes[n].Tag = EnabledBeamConfig.BeamNumbers[n];
                    epcBoxes[n].Items.Add("Beam" + ((int)epcBoxes[n].Tag + 1).ToString());
                    epcBoxes[n].Font = new Font(epcBoxes[n].Font.FontFamily, 8);
                    this.Controls.Add(epcBoxes[n]);
                    Relayout();
                }
            }
        }

        public void Resize()
        {
            if (epcBoxes[0] != null)
            {
                int sectorW = this.Width / 3;
                int sectorH = this.Height / 4;
                for (int n = 0; n < epcBoxes.Length; n++)
                {
                    epcBoxes[n].Size = new System.Drawing.Size(sectorW - 2, sectorH - 1);
                    Relayout();
                }

            }
        }

        public void Remove(NurApi.TagTrackingTag tag)
        {
            string epc = NurApi.BinToHexString(tag.epc, tag.epcLen);
            for (int n = 0; n < epcBoxes.Length; n++)
            {
                if (epcBoxes[n].Items.Contains(epc))
                {
                    epcBoxes[n].Items.RemoveAt(epcBoxes[n].Items.IndexOf(epc));
                }
            }
        }

        public void UpdateTags(NurApi.TagTrackingTag tag)
        {
            string epc = NurApi.BinToHexString(tag.epc, tag.epcLen);
            int sector = 0;
            if (tag.visible == 1)
            {
                for (int n = 0; n < epcBoxes.Length; n++)
                {
                    sector = ((int)epcBoxes[n].Tag + 1);
                    if (sector == tag.sector && !epcBoxes[n].Items.Contains(epc))
                    {
                        epcBoxes[n].Items.Add(epc);
                    }
                    else if (sector != tag.sector && epcBoxes[n].Items.Contains(epc))
                    {
                        epcBoxes[n].Items.RemoveAt(epcBoxes[n].Items.IndexOf(epc));
                    }
                }
            }
        }

        public void ClearTags()
        {
            for (int n = 0; n < epcBoxes.Length; n++)
            {
                epcBoxes[n].Items.Clear();
            }
        }

        void Relayout()
        {
            float sectorW = (float)this.Width / 3.0f;
            float sectorH = (float)this.Height / 4.0f;

            float x = sectorW / 2.0f;
            float y = sectorH / 2.0f;
            for (int n = 0; n < epcBoxes.Length; n++)
            {
                if (epcBoxes[n] == null)
                    break;
                epcBoxes[n].Location = new Point((int)(x - epcBoxes[n].Width / 2.0f), (int)(y - epcBoxes[n].Height / 2.0f));
                
                //Far beam box
                if (n == (epcBoxes.Length - 1) && x == (sectorW / 2))
                {
                    epcBoxes[n].Width = this.Width - 4;
                }
                
                x += sectorW;
                if (x > this.Width)
                {
                    x = sectorW / 2;
                    y += sectorH;
                }
            }
            
        }
    }
}
