using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NurApiDotNet;

namespace NurApiTagTrackingFeatures 
{
    public partial class TagsPerAntennaControl : UserControl
    {
        ListBox[] epcBoxes = null;
        Label[] antennaName = null;
        NurApi mApi = null;
        public TagsPerAntennaControl()
        {
            InitializeComponent();
        }

        public int AntennaCount()
        { 
            if(epcBoxes == null)
                return 0;

            return epcBoxes.Length;
        }

        public void MoveIndicator(int antId)
        {
            for (int i = 0; i < antennaName.Length; i++)
            {
                if (antId == (int)antennaName[i].Tag)
                {
                    antennaName[i].Font = new Font(antennaName[i].Font.FontFamily, antennaName[i].Font.Size, FontStyle.Bold);
                }
                else
                {
                    antennaName[i].Font = new Font(antennaName[i].Font.FontFamily, antennaName[i].Font.Size, FontStyle.Regular);
                }
            }
        }

        public void Config(NurApi hNur)
        {
            mApi = hNur;
            if (mApi != null && mApi.IsConnected())
            {
                this.Controls.Clear();

                epcBoxes = new ListBox[mApi.AvailablePhysicalAntennas.Count];
                antennaName = new Label[mApi.AvailablePhysicalAntennas.Count];
                int n = 0;
                //Create listbox for each sector
                foreach (string physAnt in mApi.AvailablePhysicalAntennas)
                {
                    int sectorW = 0;
                    int sectorH = 0;
                    if (mApi.AvailablePhysicalAntennas.Count > 3 && (mApi.AvailablePhysicalAntennas.Count - 3) >= 3)
                    {
                        if (mApi.AvailablePhysicalAntennas.Count != ((mApi.AvailablePhysicalAntennas.Count / 3) * 3))
                        {
                            sectorW = this.Width / (mApi.AvailablePhysicalAntennas.Count / 3);
                            sectorH = (this.Height / 4) - 2;
                        }
                        else
                        {
                            sectorW = this.Width / (mApi.AvailablePhysicalAntennas.Count / 3);
                            sectorH = this.Height / 3;
                        }
                    }
                    else
                    {
                        sectorW = this.Width / (mApi.AvailablePhysicalAntennas.Count);
                        sectorH = this.Height;
                    }


                    antennaName[n] = new Label();
                    antennaName[n].Tag = mApi.NurPhysicalAntennaToAntennaId(physAnt);
                    antennaName[n].Text = physAnt;
                    antennaName[n].Font = new Font(antennaName[n].Font.FontFamily, 8);
                    antennaName[n].Size = new System.Drawing.Size(sectorW - 2, antennaName[n].Size.Height);

                    epcBoxes[n] = new ListBox();
                    epcBoxes[n].Size = new System.Drawing.Size(sectorW - 2, sectorH - antennaName[n].Size.Height);
                    epcBoxes[n].Tag = mApi.NurPhysicalAntennaToAntennaId(physAnt);
                    epcBoxes[n].Font = new Font(epcBoxes[n].Font.FontFamily, 8);

                    this.Controls.Add(epcBoxes[n]);
                    this.Controls.Add(antennaName[n]);
                    Relayout();
                    n++;
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
                    sector = ((int)epcBoxes[n].Tag);
                    //we don't want to hide tags here which are not yet actually missing(i.e. by visibility change)
                    if (tag.maxRssiAnt != -1)
                    {
                        if (sector == tag.maxRssiAnt && !epcBoxes[n].Items.Contains(epc))
                        {
                            epcBoxes[n].Items.Add(epc);
                        }
                        else if (sector != tag.maxRssiAnt && epcBoxes[n].Items.Contains(epc))
                        {
                            epcBoxes[n].Items.RemoveAt(epcBoxes[n].Items.IndexOf(epc));
                        }
                    }
                }
            }
            else
            {
                Remove(tag);
            }
        }

        public void ClearTags()
        {
            for (int n = 0; n < epcBoxes.Length; n++)
            {
                epcBoxes[n].Items.Clear();
            }
        }
        
        public void Resize()
        {
            if (epcBoxes != null && epcBoxes[0] != null)
            {
                int sectorW = 0;
                int sectorH = 0;
                if (mApi.AvailablePhysicalAntennas.Count > 3 && (mApi.AvailablePhysicalAntennas.Count - 3) >= 3)
                {
                    if (mApi.AvailablePhysicalAntennas.Count != ((mApi.AvailablePhysicalAntennas.Count / 3) * 3))
                    {
                        sectorW = this.Width / (mApi.AvailablePhysicalAntennas.Count / 3);
                        sectorH = (this.Height / 4) - 2;
                    }
                    else
                    {
                        sectorW = this.Width / (mApi.AvailablePhysicalAntennas.Count / 3);
                        sectorH = this.Height / 3;
                    }
                }
                else
                {
                    sectorW = this.Width / (mApi.AvailablePhysicalAntennas.Count);
                    sectorH = this.Height;
                }
                        
                for (int n = 0; n < epcBoxes.Length; n++)
                {
                    antennaName[n].Size = new System.Drawing.Size(sectorW - 2, antennaName[n].Size.Height);
                    epcBoxes[n].Size = new System.Drawing.Size(sectorW - 2, sectorH - antennaName[n].Size.Height);
                    Relayout();
                }
            }
        }

        void Relayout()
        {
            float sectorW = 0;
            float sectorH = 0;
            if (mApi.AvailablePhysicalAntennas.Count > 3 && (mApi.AvailablePhysicalAntennas.Count - 3) >= 3)
            {
                if (mApi.AvailablePhysicalAntennas.Count != ((mApi.AvailablePhysicalAntennas.Count / 3) * 3))
                {
                    sectorW = this.Width / (mApi.AvailablePhysicalAntennas.Count / 3);
                    sectorH = (this.Height / 4) - 2;
                }
                else
                {
                    sectorW = this.Width / (mApi.AvailablePhysicalAntennas.Count / 3);
                    sectorH = this.Height / 3;
                }
            }
            else
            {
                sectorW = this.Width / (mApi.AvailablePhysicalAntennas.Count);
                sectorH = this.Height;
            }
                        

            float x = sectorW / 2.0f;
            float y = sectorH / 2.0f;
            int row = 1;
            for (int n = 0; n < epcBoxes.Length; n++)
            {
                if (epcBoxes[n] == null)
                    break;
                epcBoxes[n].Location = new Point((int)(x - epcBoxes[n].Width / 2.0f), (int)(y - epcBoxes[n].Height / 2.0f) + (antennaName[n].Height));
                antennaName[n].Location = new Point(epcBoxes[n].Location.X, epcBoxes[n].Location.Y - antennaName[n].Height);
                x += sectorW;
                if (x > this.Width)
                {
                    x = sectorW / 2;
                    y += sectorH;
                    row++;
                }
            }
        }
    }
}
