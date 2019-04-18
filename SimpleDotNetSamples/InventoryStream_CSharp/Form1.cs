using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NurApiDotNet; //Need to use namespace of NurApiDotNet

namespace PeriodicInventory_CSharp
{
    public partial class Form1 : Form
    {
        // NurApi object
        NurApi hNur = null;

        // Flag to indicate inventory stream is running
        Boolean running = false;

        // This tag storage contains all unique inventoried tags
        NurApi.TagStorage tags = new NurApi.TagStorage();

        public Form1()
        {
            InitializeComponent();

            try
            {
                // Create NurApi instance with this form as notification receiver.
                // This will make all events to be called in UI thread context
                hNur = new NurApi(this);

                // Add event handler for receiving connected and disconnected status
                hNur.ConnectedEvent += new EventHandler<NurApi.NurEventArgs>(hNur_ConnectedEvent);
                hNur.DisconnectedEvent += new EventHandler<NurApi.NurEventArgs>(hNur_DisconnectedEvent);

                // Add inventory stream event, event is called when there's tags available
                hNur.InventoryStreamEvent += new EventHandler<NurApi.InventoryStreamEventArgs>(hNur_InventoryStreamReady);

                // Set window title
                UpdateAppTitle();
            }
            catch (Exception ex)
            {
                // Handle error
                MessageBox.Show("Could not initialize NurApi, error: " + ex.ToString(), "Error");
                Application.Exit();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Starts connecting to USB automatically. Keeps up connection until SetUsbAutoConnect(false) called.
            hNur.SetUsbAutoConnect(true);
        }

        // Connected event handler
        void hNur_ConnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            // Set window title
            UpdateAppTitle();

            // Here is a proper place to configure reader on the fly if needed
            hNur.TxLevel = 0;   // Set Tx power to max level
        }

        // Disconnected event handler
        void hNur_DisconnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            // Set window title
            UpdateAppTitle();
        }

        // Inventory stream event, this is called when there's tags available in NurApi tag storage
        void hNur_InventoryStreamReady(object sender, NurApi.InventoryStreamEventArgs e)
        {
            try
            {
                // Copy tags from NurApi internal tag storage to application tag storage
                NurApi.TagStorage intTagStorage = hNur.GetTagStorage();
                lock (intTagStorage)
                {
                    for (int i = 0; i < intTagStorage.Count; i++)
                    {
                        NurApi.Tag tag;
                        if (tags.AddTag(intTagStorage[i], out tag))
                        {
                            // Add new unique tag added
                            int index = listBox1.Items.Add(string.Format("EPC: {0}, ANT: {1}, RSSI: {2}",
                                tag.GetEpcString(), tag.antennaId, tag.rssi));
                            tag.userData = index;
                        }
                        else
                        {
                            // Update current tag
                            int index = (int)tag.userData;
                            listBox1.Items[index] = string.Format("EPC: {0}, ANT: {1}, RSSI: {2}",
                                tag.GetEpcString(), tag.antennaId, tag.rssi);
                        }
                    }
                    // Clear NurApi internal tag storage
                    hNur.ClearTags();
                }

                if (e.data.stopped && running)
                {
                    // Start streaming again if stopped
                    hNur.StartInventoryStream();
                }
            }
            catch (Exception ex)
            {
                // Handle error
                listBox1.Items.Add(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // This button toggles inventory stream on/off
            try
            {
                if (!hNur.IsConnected())
                {
                    MessageBox.Show("Not connected to reader", "Error");
                    return;
                }

                if (!running)
                {
                    //Start
                    hNur.ClearTags();
                    hNur.StartInventoryStream();
                    button1.Text = "Stop";
                    running = true;
                }
                else
                {
                    //Stop
                    hNur.StopInventoryStream();
                    button1.Text = "Start";
                    running = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
                running = false;
                button1.Text = "Start";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Clear list box
            listBox1.Items.Clear();

            // Clear our application tag storage
            tags.Clear();
        }

        private void UpdateAppTitle()
        {
            // Show NurApi Dll version in the form caption with connected status
            if (hNur.IsConnected())
            {
                this.Text = string.Format("NurApi: {0}/{1} - Connected {2}",
                    hNur.GetFileVersion(),
                    System.Reflection.Assembly.LoadFrom("NurApiDotNet.dll").GetName().Version,
                    hNur.GetReaderInfo().name);
            }
            else
            {
                this.Text = string.Format("NurApi: {0}/{1} - Disconnected",
                    hNur.GetFileVersion(),
                    System.Reflection.Assembly.LoadFrom("NurApiDotNet.dll").GetName().Version);
            }
        }
    }
}