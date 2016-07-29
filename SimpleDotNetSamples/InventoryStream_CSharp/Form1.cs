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

                // Set window title
                this.Text = "NurAPI Dll Version: " + hNur.GetFileVersion() + " (Disconnected)";

                // Add event handler for receiving connected and disconnected status
                hNur.ConnectedEvent += new EventHandler<NurApi.NurEventArgs>(hNur_ConnectedEvent);
                hNur.DisconnectedEvent += new EventHandler<NurApi.NurEventArgs>(hNur_DisconnectedEvent);

                // Add inventory stream event, event is called when there's tags available
                hNur.InventoryStreamEvent += new EventHandler<NurApi.InventoryStreamEventArgs>(hNur_InventoryStreamReady);

                // Starts connecting to USB automatically. Keeps up connection until SetUsbAutoConnect(false) called.
                hNur.SetUsbAutoConnect(true);
            } 
            catch (Exception ex)
            {
                // Handle error
                MessageBox.Show("Could not initialize NurApi, error: " + ex.ToString(), "Error");
                Application.Exit();
            }
        }

        // Connected event handler
        void hNur_ConnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            // Show NurApi Dll version in the form caption with connected status            
            this.Text = "NurAPI Dll Version: " + hNur.GetFileVersion() + " (Connected)";
        }

        // Disconnected event handler
        void hNur_DisconnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            // Show NurApi Dll version in the form caption with connected status            
            this.Text = "NurAPI Dll Version: " + hNur.GetFileVersion() + " (Disconnected)";
        }

        // Inventory stream event, this is called when there's tags available in NurApi tag storage
        void hNur_InventoryStreamReady(object sender, NurApi.InventoryStreamEventArgs e)
        {
            try
            {                
                // Copy tags from NurApi internal tag storage to application tag storage
                foreach (NurApi.Tag tag in hNur.GetTagStorage())
                {
                    if (tags.AddTag(tag))
                    {
                        // New unique tag added
                        listBox1.Items.Add(tag.GetEpcString());
                    }
                }

                // Clear NurApi internal tag storage
                hNur.ClearTags();

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
    }
}