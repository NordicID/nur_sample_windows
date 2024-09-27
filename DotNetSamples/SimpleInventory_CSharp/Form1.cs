using NurApiDotNet;
using System.Diagnostics;

namespace SimpleInventory_CSharp
{
    public partial class Form1 : Form
    {
        // NurApi instance for communicating with the RFID reader
        NurApi nur;

        public Form1()
        {
            InitializeComponent();
            nur = new NurApi();

            try
            {
                // Subscribe to connection status events to monitor changes in reader connection state
                nur.ConnectionStatusEvent += Nurapi_ConnectionStatusEvent;
            }
            catch (NurApiException ex)
            {
                // Log error message if the NurApi initialization fails
                Debug.WriteLine($"NurApi connection failed: {ex.NurErrorMessage}");
            }

            // Initialize USB transport support and enable automatic USB connection handling
            NordicID.NurApi.USBTransport.Support.Init();
            nur.SetUsbAutoConnect(true);

            // Set the text of button1 to indicate its functionality
            button1.Text = "Simple Inventory";
        }

        // Event handler for monitoring changes in NurApi connection status
        private void Nurapi_ConnectionStatusEvent(object? sender, NurTransportStatus e)
        {
            if (e == NurTransportStatus.Connected)
            {
                try
                {
                    // Get reader information from the connected module
                    NurApi.ReaderInfo readerInfo = nur.GetReaderInfo();

                    // Safely update the UI elements from a different thread using BeginInvoke
                    this.BeginInvoke(new MethodInvoker(() =>
                    {
                        // Update the form title with reader information
                        this.Text = $"NurAPI Dll Version: {NurApi.FileVersion}, {readerInfo.name}, {readerInfo.serial}";

                        // Clear previous messages from the ListBox
                        listBox1.Items.Clear();

                        // Indicate that the reader is connected
                        listBox1.Items.Add("Connected");
                    }));
                }
                catch (Exception ex)
                {
                    // Display error message in the ListBox if fetching reader information fails
                    this.BeginInvoke(new MethodInvoker(() =>
                    {
                        listBox1.Items.Add($"Error: GetReaderInfo: {ex.Message}");
                    }));
                }
            }
            else if (e == NurTransportStatus.Connecting)
            {
                // Update the ListBox to show "Connecting" status message
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add("Connecting");
                }));
            }
            else if (e == NurTransportStatus.Disconnected)
            {
                // Update the ListBox to show "Device disconnected" status message
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add("Device disconnected");
                    // Update the form title to indicate that the reader is disconnected
                    this.Text = $"NurAPI Dll Version: {NurApi.FileVersion} (Disconnected)";
                }));
            }
        }

        // Event handler for button1 click, performing a simple inventory of RFID tags
        private void button1_Click(object sender, EventArgs e)
        {
            // Perform a simple inventory of tags using current reader parameters            
            try
            {
                // Check if the reader is connected before performing inventory
                if (!nur.IsConnected())
                {
                    listBox1.Items.Add("Not connected to reader");
                    return;
                }

                // Clear the ListBox for new inventory results
                listBox1.Items.Clear();

                // Clear any previously stored tags in the reader's memory
                nur.ClearTags();
                NurApi.InventoryResponse response; // Store information about the inventory here

                // Perform the inventory operation
                response = nur.Inventory();

                // Display inventory statistics in the ListBox
                listBox1.Items.Add("Number of tags found in this inventory: " + response.numTagsFound.ToString());
                listBox1.Items.Add("Total number of tags in module memory : " + response.numTagsMem.ToString());
                listBox1.Items.Add("Number of possible collisions or reception errors in this inventory: " + response.collisions.ToString());
                listBox1.Items.Add("Q used in this inventory: " + response.Q.ToString());
                listBox1.Items.Add("Number of full Q rounds done in this inventory: " + response.roundsDone.ToString());
                listBox1.Items.Add("-------------EPC----------------");

                // Retrieve and display the tags found in the inventory
                NurApi.TagStorage inv = nur.FetchTags(true);

                // Loop through the found tags and display EPC's in the ListBox
                foreach (NurApi.Tag tag in inv)
                {
                    listBox1.Items.Add(tag.GetEpcString());
                }
            }
            catch (Exception ex)
            {
                // Show a message box with the exception details if any error occurs
                MessageBox.Show(ex.ToString(), "Exception");
            }
        }
    }
}
