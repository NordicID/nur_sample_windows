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
    /// <summary>
    /// Wrapper class for NurApi.TagTrackingConfig which we can drop to PropertyGrid on ConfigForm
    /// </summary>
    [Serializable()]
    public class ConfigTracking
    {
        /// <summary>
        /// Constructor with some default values
        /// </summary>
        public ConfigTracking()
        {
            //set up some default values
            RssiDeltaFilter = 5;
            PositionDeltaFilter = (float)0.05;
            ScanUntilNewTagsCount = 5;
            VisibilityTimeout = 3000;
            SelectAddress = 32;
            SelectMaskBitLength = 0;
            ByteFilter = "";
            SelectBank = NurApi.BANK_EPC;
            SelectAddress = 32;
        }

        /// <summary>
        ///  When TTEV_RSSI is enabled, change event is generated when RSSI changes more than rssiDeltaFilter
        /// </summary>
        [Description("When TTEV_RSSI is enabled, change event is generated when RSSI changes more than rssiDeltaFilter")]
        public int RssiDeltaFilter
        {
            get;
            set;
        }

        /// <summary>
        /// When TTEV_POSITION is enabled, change event is generated when position changes more than positionDeltaFilter. Position is normalized 0.0-1.0 value.
        /// </summary>
        [Description("When TTEV_POSITION is enabled, change event is generated when position changes more than positionDeltaFilter. Position is normalized 0.0-1.0 value.")]
        public float PositionDeltaFilter
        {
            get;
            set;
        }
        /// <summary>
        /// Tag tracking continues inventory as long as there's more new tags found than scanUntilNewTagsCount
        /// </summary>
        [Description("Tag tracking continues inventory as long as there's more new tags found than scanUntilNewTagsCount")]
        public int ScanUntilNewTagsCount
        {
            get;
            set;
        }
        /// <summary>
        /// When TTEV_VISIBILITY is enabled, change event is generated when tag has been out of view more than visibilityTimeout milliseconds
        /// </summary>
        [Description("When TTEV_VISIBILITY is enabled, change event is generated when tag has been out of view more than visibilityTimeout milliseconds")]
        public int VisibilityTimeout
        {
            get;
            set;
        }

        /// <summary>
        ///  Singulation data address in bits.
        /// </summary>
        [Description("Singulation data address in bits.")]
        public uint SelectAddress
        {
            get;
            set;
        }
        /// <summary>
        /// Length of the mask data in bits.
        /// </summary>
        [Description("Length of the mask data in bits.")]
        public ushort SelectMaskBitLength
        {
            get;
            set;
        }

        /// <summary>
        /// Memory bank used for tag singulation. 1=NurApiDotNet.NurApi.BANK_EPC 2=NurApiDotNet.NurApi.BANK_TID 3=NurApiDotNet.NurApi.BANK_USER
        /// </summary>
        [Description("Memory bank used for tag singulation. 1=NurApiDotNet.NurApi.BANK_EPC 2=NurApiDotNet.NurApi.BANK_TID 3=NurApiDotNet.NurApi.BANK_USER")]
        public byte SelectBank
        {
            get;
            set;
        }

        // Internal member used by tracking controller
        internal byte[] byteFilterBytes = null;
        string mByteFilter = "";
        /// <summary>
        /// Hex string formatted filter (HEX string) used for tag filtering in tracking
        /// </summary>
        [Description("EPC select filter (HEX string) used for tag filtering in inventory controller")]
        public string ByteFilter
        {
            get { return mByteFilter; }
            set
            {
                mByteFilter = value;
                if (mByteFilter != "")
                {
                    try
                    {
                        byteFilterBytes = NurApi.HexStringToBin(mByteFilter);
                    }
                    catch
                    {
                        byteFilterBytes = null;
                    }
                }
                else
                {
                    byteFilterBytes = null;
                }
            }
        }
    }
}
