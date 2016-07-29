using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using NurApiDotNet;

namespace InventorySample
{
    public partial class Form1 : Form
    {
        // NurApi object
        private NurApi nur;

        // Flag for inventory stream
        bool streaming = false;

        // Tag storage to keep track of unique tags
        NurApi.TagStorage tagStorage = new NurApi.TagStorage();

        public Form1()
        {
            InitializeComponent();
            
            try
            {
                // Create NurApi object
                nur = new NurApi(this);

                // This gets called when module is connected
                nur.ConnectedEvent += new EventHandler<NurApi.NurEventArgs>(nur_ConnectedEvent);

                // This gets called when module is disconnected
                nur.DisconnectedEvent += new EventHandler<NurApi.NurEventArgs>(nur_DisconnectedEvent);

                // This gets called when new tags arrives
                nur.InventoryStreamEvent += new EventHandler<NurApi.InventoryStreamEventArgs>(nur_InventoryStreamEvent);

                // Connect to integrated reader
                nur.ConnectIntegratedReader();
            }
            catch (Exception ex)
            {
                // Api init failed or module not found
                MessageBox.Show("Init failed, error: " + ex.ToString(), "Error");
                Application.Exit();
            }
        }

        // This gets called when module is disconnected
        void nur_DisconnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            MessageBox.Show("Module disconnected, application will exit now", "Disconnected");
            Application.Exit();
        }

        // This gets called when module is connected
        void nur_ConnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            // Connected, display module info
            NurApi.ReaderInfo ri = nur.GetReaderInfo();
            lstbox.Items.Add(ri.name + " connected");
            lstbox.Items.Add("Version: " + ri.GetVersionString());
        }

        // This gets called when new tags arrives
        void nur_InventoryStreamEvent(object sender, NurApi.InventoryStreamEventArgs e)
        {
            AddTagsToList(nur.GetTagStorage());

            if (e.data.stopped && streaming)
            {
                // Restart streaming
                try
                {
                    nur.StartInventoryStream();
                }
                catch { } // Ignore error..
            }
        }

        // Set UI State
        private void SetUIState(bool scanning)
        {
            // Change buttons enabled state
            btn_scan.Enabled = !scanning;
            if (!streaming)
            {
                btn_scan_stream.Enabled = !scanning;
            }
            else
            {
                btn_scan_stream.Enabled = true;                
            }

            // Make sure UI is updated
            Application.DoEvents();
        }

        // Add all unique tags from srcStorage to application own tag storage
        private void AddTagsToList(NurApi.TagStorage srcStorage)
        {
            foreach (NurApi.Tag tag in srcStorage)
            {
                // Copy to application tag storage
                if (tagStorage.AddTag(tag))
                {
                    // Only add to list, if tag was new unique tag
                    lstbox.Items.Add(tag.GetEpcString());
                }
            }
        }

        private void Clear()
        {
            // Clear listbox items
            lstbox.Items.Clear();

            // Clear tag storage
            tagStorage.Clear();
        }

        // Single inventory button click
        private void btn_scan_Click(object sender, EventArgs e)
        {
            // Clear list & tag storage
            Clear();

            // Change UI state to scanning
            SetUIState(true);

            try
            {
                // Clear NurApi/Module tag storage
                nur.ClearTags();

                // Execute simple inventory
                NurApi.InventoryResponse ir = nur.Inventory();

                if (ir.numTagsMem > 0)
                {
                    // Add all tags to list
                    AddTagsToList(nur.FetchTags());
                }
                else
                {
                    // No tags found..
                    lstbox.Items.Add("No tags found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Inventory error: " + ex.ToString(), "Error");
            }

            // Change UI state to normal
            SetUIState(false);
        }

        // Inventory Stream button
        private void btn_scan_stream_Click(object sender, EventArgs e)
        {
            if (!streaming)
            {
                // Stream not running, start
                try
                {
                    // Clear list & tag storage
                    Clear();

                    nur.StartInventoryStream();
                    btn_scan_stream.Text = "Stop";
                    streaming = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not start stream: " + ex.ToString(), "Error");
                }
            }
            else
            {
                // Stream is running, stop
                try
                {
                    nur.StopInventoryStream();
                    btn_scan_stream.Text = "Inventory Stream";
                    streaming = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not stop stream: " + ex.ToString(), "Error");
                }
            }

            // Change UI state
            SetUIState(streaming);
        }
        
    }
}
