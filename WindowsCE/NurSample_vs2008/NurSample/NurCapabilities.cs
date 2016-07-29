using System;
using System.Collections.Generic;
using System.Text;

using NurApiDotNet; //NurApi wrapper

namespace NurSample
{
    /// <summary>
    /// NurCapabilities class
    /// </summary>
    public sealed class NurCapabilities
    {
        const string NA = "N/A";

        public struct NurCapabilityItem
        {
            public int SetupFlag;
            public int Value;
            public string Text;
            public override string ToString()
            {
                return Text;
            }
            public NurCapabilityItem(int setupFlag, int value, string text)
            {
                SetupFlag = setupFlag;
                Text = text;
                Value = value;
            }
        }

        /// <summary>
        /// The Handle of NurApi
        /// </summary>
        NurApi hNur = null;

        /// <summary>
        /// The local reader info
        /// </summary>
        NurApi.ReaderInfo readerInfo;

        /// <summary>
        /// The current Device Capabilites
        /// </summary>
        NurApi.DeviceCapabilites devCaps;

        /// <summary>
        /// Allocate ourselves.
        /// We have a private constructor, so no one else can.
        /// </summary>
        static readonly NurCapabilities instance = new NurCapabilities();

        /// <summary>
        /// Access NurCapabilities.Instance to get the singleton object.
        /// Then call methods on that instance.
        /// </summary>
        public static NurCapabilities I
        {
            get { return instance; }
        }

        /// <summary>
        /// This is a private constructor, meaning no outsiders have access.
        /// </summary>
        private NurCapabilities()
        {
            // Initialize members here.
        }

        /// <summary>
        /// Gets or sets the nur.
        /// </summary>
        /// <value>
        /// The nur.
        /// </value>
        public NurApi Nur
        {
            get { return hNur; }
            set
            {
                if (hNur != null)
                {
                    hNur.ConnectedEvent -= hNur_ConnectedEvent;
                    hNur.DisconnectedEvent -= hNur_DisconnectedEvent;
                }
                this.hNur = value;
                if (hNur != null)
                {
                    hNur.ConnectedEvent += new EventHandler<NurApi.NurEventArgs>(hNur_ConnectedEvent);
                    hNur.DisconnectedEvent += new EventHandler<NurApi.NurEventArgs>(hNur_DisconnectedEvent);
                    hNur_ConnectedEvent(hNur, null);
                }
            }
        }

        /// <summary>
        /// Handles the ConnectedEvent event of the hNur control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="NurApi.NurEventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        void hNur_ConnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            if (hNur != null && hNur.IsConnected())
            {
                try
                {
                    // Get the ReaderInfo
                    readerInfo = hNur.GetReaderInfo();
                }
                catch (NurApiException)
                {
                    // Firmware may be too old so use the defaults
                    readerInfo.name = NA;
                }

                try
                {
                    // Get the Device Capabilites
                    devCaps = hNur.GetDeviceCaps();
                    if (devCaps.txAttnStep == 3)
                        throw new Exception("Firmware may be too old so use the defaults");
                }
                catch (Exception)
                {
                    // Firmware may be too old so use the defaults
                    devCaps.maxTxmW = 500;
                    devCaps.maxTxdBm = 27;
                    devCaps.txAttnStep = 1;
                    devCaps.txSteps = 20;
                    devCaps.maxAnt = 4;
                }
            }
        }

        /// <summary>
        /// Handles the DisconnectedEvent event of the hNur control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="NurApi.NurEventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        void hNur_DisconnectedEvent(object sender, NurApi.NurEventArgs e)
        {
        }

        /// <summary>
        /// Gets the reader info.
        /// </summary>
        /// <value>
        /// The reader info.
        /// </value>
        public NurApi.ReaderInfo ReaderInfo { get { return readerInfo; } }

        /// <summary>
        /// Gets the device capabilites.
        /// </summary>
        /// <value>
        /// The device capabilites.
        /// </value>
        public NurApi.DeviceCapabilites DeviceCaps { get { return devCaps; } }

        /// <summary>
        /// The Nur Capability items
        /// </summary>
        readonly NurCapabilityItem[] nurItems = new NurCapabilityItem[] {
            new NurCapabilityItem(NurApi.SETUP_TXMOD, NurApi.TXMODULATION_ASK, "ASK"),
            new NurCapabilityItem(NurApi.SETUP_TXMOD, NurApi.TXMODULATION_PRASK, "PR-ASK"),
            new NurCapabilityItem(NurApi.SETUP_RXDEC, NurApi.RXDECODING_FM0, "FM-0"),
            new NurCapabilityItem(NurApi.SETUP_RXDEC, NurApi.RXDECODING_M2, "Miller-2"),
            new NurCapabilityItem(NurApi.SETUP_RXDEC, NurApi.RXDECODING_M4, "Miller-4"),
            new NurCapabilityItem(NurApi.SETUP_RXDEC, NurApi.RXDECODING_M8, "Miller-8"),
            new NurCapabilityItem(NurApi.SETUP_SELECTEDANTENNA, NurApi.ANTENNAID_AUTOSELECT, "Auto Antenna"),
            new NurCapabilityItem(NurApi.SETUP_SELECTEDANTENNA, NurApi.ANTENNAID_1, "Antenna 1"),
            new NurCapabilityItem(NurApi.SETUP_SELECTEDANTENNA, NurApi.ANTENNAID_2, "Antenna 2"),
            new NurCapabilityItem(NurApi.SETUP_SELECTEDANTENNA, NurApi.ANTENNAID_3, "Antenna 3"),
            new NurCapabilityItem(NurApi.SETUP_SELECTEDANTENNA, NurApi.ANTENNAID_4, "Antenna 4"),
            new NurCapabilityItem(NurApi.SETUP_AUTOPERIOD, NurApi.NUR_AUTOPER_OFF, "Disabled"),
            new NurCapabilityItem(NurApi.SETUP_AUTOPERIOD, NurApi.NUR_AUTOPER_25, "Max 1000 ms off"),
            new NurCapabilityItem(NurApi.SETUP_AUTOPERIOD, NurApi.NUR_AUTOPER_33, "Max 500 ms off"),
            new NurCapabilityItem(NurApi.SETUP_AUTOPERIOD, NurApi.NUR_AUTOPER_50, "Max 100 ms off"),
        };

        public string ConvertToString(int setupFlag, int value)
        {
            switch (setupFlag)
            {
                case NurApi.SETUP_INVQ:
                case NurApi.SETUP_INVROUNDS:
                    if (value == 0)
                        return "Auto";
                    return value.ToString();

                case NurApi.SETUP_INVEPCLEN:
                    if (value == 255)
                        return "Accept all";
                    if (value >= 2 && value <= 62 && value % 2 == 0)
                        return string.Format("{0} bits, {1} bytes", value * 8, value);
                    throw new ArgumentException();

                case NurApi.SETUP_LINKFREQ:
                    return (value / 1000).ToString() + " kHz";

                case NurApi.SETUP_REGION:
                    return hNur.GetRegionInfo(value).name;

                case NurApi.SETUP_TXLEVEL:
                    if (value == 0)
                    {
                        return devCaps.maxTxmW.ToString() + " mW";
                    }
                    else
                    {
                        int dBm = devCaps.maxTxdBm - (value * devCaps.txAttnStep);
                        int mW = (int)Math.Round(Math.Pow(10, (double)dBm / 10));
                        return mW.ToString() + " mW";
                    }

                default:
                    for (int n = 0; n < nurItems.Length; n++)
                    {
                        if (nurItems[n].SetupFlag == setupFlag &&
                            nurItems[n].Value == value)
                        {
                            return nurItems[n].Text;
                        }
                    }
                    break;
            }
            return value.ToString() + ": UNKNOWN VALUE";
        }
    }
}
