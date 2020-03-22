using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NurApiDotNet; //Need to use namespace of NurApiDotNet

namespace Inventory
{
    public partial class Form1 : Form
    {
        NurApi hNur = null;

        public Form1()
        {
            InitializeComponent();

            hNur = new NurApi(this); //Handle of NurApi

            //Add event handler for receiving connected and disconnected status
            hNur.ConnectedEvent += new EventHandler<NurApi.NurEventArgs>(hNur_ConnectedEvent);
            hNur.DisconnectedEvent += new EventHandler<NurApi.NurEventArgs>(hNur_DisconnectedEvent);

            //Tell to Nur that this class is the reveiver of notifications...
            hNur.SetNotificationReceiver(this);
            //Starts connecting to USB automatically. Keeps up connection until SetUsbAutoConnect(false) called.
            hNur.SetUsbAutoConnect(true);
        }

        //Connected event handler
        void hNur_ConnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            //Show NurApi Dll version in the form caption with connected status            
            this.Text = "NurAPI Dll Version: " + hNur.GetFileVersion() + " (Connected)";                    
        }

        //Disconnected event handler
        void hNur_DisconnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            //Show NurApi Dll version in the form caption with connected status            
            this.Text = "NurAPI Dll Version: " + hNur.GetFileVersion() + " (Disconnected)";
        }
    
        private void SimpleInventoryButton_Click(object sender, EventArgs e)
        {            
            //Performs simple inventory of tags using current rounds-, Q and session parameters            
            try
            {
                if (!hNur.IsConnected())
                {
                    listBox1.Items.Add("Not connected to reader");
                    return;
                }

                //Clear existing items from Listbox
                listBox1.Items.Clear(); 
                //Clear existing tags from NurModule memory
                hNur.ClearTags();
                NurApi.InventoryResponse response; //Information about inventory store here
                //Make Inventory..
                response=hNur.SimpleInventory();
                //Show information about inventory first
                listBox1.Items.Add("Number of tags found in this inventory: " + response.numTagsFound.ToString());
                listBox1.Items.Add("Total number of tags in module memory : " + response.numTagsMem.ToString());
                listBox1.Items.Add("Number of possible collisions or reception errors in this inventory: " + response.collisions.ToString());
                listBox1.Items.Add("Q used in this inventory: " + response.Q.ToString());
                listBox1.Items.Add("Number of full Q rounds done in this inventory: " + response.roundsDone.ToString());
                listBox1.Items.Add("-------------EPC----------------");
                //Read result to TagStorage object
                NurApi.TagStorage inv = hNur.FetchTags(true);
                //Show results in the ListBox (EPC code)               
                foreach (NurApi.Tag tag in inv)
                {
                    listBox1.Items.Add(tag.GetEpcString());
                }                
            }
            catch (Exception ex)
            {   //Something went wrong.(usually transport not connected) Show reason in the MessageBox.
                MessageBox.Show(ex.ToString(),"Exception");                
            }
        }
    }
}