using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using NurApiDotNet; //Need to use namespace of NurApiDotNet

namespace PeriodicInventory_CSharp
{
    public partial class Form1 : Form
    {
        // NurApi object for general usage
        NurApi genNurApi;

        // NurApi objects for connected readers
        List<NurApi> nurApis = new List<NurApi>();

        public Form1()
        {
            InitializeComponent();

            genNurApi = new NurApi(this);
            genNurApi.DevInfoEvent += new EventHandler<NurApi.DevInfoEventArgs>(hNur_DevInfoEvent);

            UpdateAppTitle();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Discover devices from the network
            new Thread(delegate()
            {
                try
                {
                    // Run one Ethernet device discovery. The devices are received via device search
                    // event. This is a synchronoous (blocking) call and return when the one discovery
                    // operation is finished.
                    genNurApi.DiscoverDevices(2000);
                }
                catch (Exception)
                {
                }
            }).Start();

            // Connect to all reader that are found from the USB ports
            List<NurApi.UsbDevice> ports = NurApi.EnumerateUsbDevices();
            for (int i = 0; i < ports.Count; i++)
            {
                nurApis.Add(new NurApi(this));
                nurApis[i].ConnectedEvent += new EventHandler<NurApi.NurEventArgs>(hNur_ConnectedEvent);
                nurApis[i].DisconnectedEvent += new EventHandler<NurApi.NurEventArgs>(hNur_DisconnectedEvent);
                nurApis[i].InventoryStreamEvent += new EventHandler<NurApi.InventoryStreamEventArgs>(hNur_InventoryStreamReady);
                try
                {
                    nurApis[i].ConnectUsb(ports[i].devPath);
                }
                catch (NurApiException)
                {
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Disconnect all readers
            foreach (NurApi nurapi in nurApis)
            {
                try
                {
                    if (!nurapi.Disposed)
                    {
                        nurapi.Disconnect();
                        nurapi.Dispose();
                    }
                }
                catch (NurApiException)
                {
                }
            }
        }

        void hNur_DevInfoEvent(object sender, NurApi.DevInfoEventArgs e)
        {
            if (e.data.status == 0)
            {
                // Free device found from the network.
                // Create a new NurApi object for it and try to connect
                new Thread(delegate()
                {
                    try
                    {
                        NurApi newNurApi = new NurApi(this);
                        newNurApi.ConnectedEvent += new EventHandler<NurApi.NurEventArgs>(hNur_ConnectedEvent);
                        newNurApi.DisconnectedEvent += new EventHandler<NurApi.NurEventArgs>(hNur_DisconnectedEvent);
                        newNurApi.InventoryStreamEvent += new EventHandler<NurApi.InventoryStreamEventArgs>(hNur_InventoryStreamReady);
                        newNurApi.ConnectSocket(new System.Net.IPAddress(e.data.eth.ip).ToString(), e.data.eth.serverPort);
                        nurApis.Add(newNurApi);
                    }
                    catch (Exception)
                    {
                    }
                }).Start();
            }
        }

        // Connected event handler
        void hNur_ConnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            // Get NurApi object that generated the event
            NurApi hNur = sender as NurApi;

            SendMessage(string.Format("CONNECTED: {0}, {1}, {2}",
                hNur.GetReaderInfo().name,
                hNur.GetReaderInfo().altSerial,
                hNur.GetReaderInfo().GetVersionString()
                ));

            UpdateAppTitle();

            // Here is a proper place to configure reader on the fly if needed
            //hNur.TxLevel = 0;   // Set Tx power to max level

            // Start inventory stream
            hNur.StartInventoryStream();
        }

        // Disconnected event handler
        void hNur_DisconnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            // Get NurApi object that generated the event
            NurApi hNur = sender as NurApi;

            SendMessage("DISCONNECTED");

            // Releace user NURAPI object
            hNur.Dispose();
            nurApis.Remove(hNur);
        }

        // Inventory stream event, this is called when there's tags available in NurApi tag storage
        void hNur_InventoryStreamReady(object sender, NurApi.InventoryStreamEventArgs e)
        {
            // Get NurApi object that generated the event
            NurApi hNur = sender as NurApi;

            try
            {
                // Copy tags from NurApi internal tag storage to application tag storage
                NurApi.TagStorage intTagStorage = hNur.GetTagStorage();
                lock (intTagStorage)
                {
                    SendMessage(string.Format("Reader: {0}, Tags: {1}", hNur.GetReaderInfo().altSerial, intTagStorage.Count));
                    // Clear NurApi internal tag storage
                    hNur.ClearTags();
                }

                if (e.data.stopped)
                {
                    // Start streaming again if stopped
                    hNur.StartInventoryStream();
                }
            }
            catch (Exception ex)
            {
                // Handle error
                SendMessage(ex.Message);
            }
        }

        private void UpdateAppTitle()
        {
            int connectedDevices = 0;
            foreach (var nurapi in nurApis)
            {
                if (nurapi.IsConnected())
                    connectedDevices++;
            }
            // Show NurApi Dll version in the form caption with connected status
            this.Text = string.Format("NurApi: {0}/{1} - {2} connected devices",
                genNurApi.GetFileVersion(),
                System.Reflection.Assembly.LoadFrom("NurApiDotNet.dll").GetName().Version,
                connectedDevices);
        }

        void SendMessage(string message)
        {
            listBox1.Items.Add(string.Format("{0}, {1}",
                DateTime.Now.ToUniversalTime(), message));
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            Application.DoEvents();
        }
    }
}