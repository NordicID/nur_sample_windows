using NurApiDotNet;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace InventoryStream_CSharp
{
    public partial class Form1 : Form
    {
        // NurApi instance for RFID communication
        private NurApi nur;

        /*
         * "Local TagStorage serves as a cache, allowing efficient management of tag data between the reader and the UI. It prevents duplicate entries and facilitates seamless updates to existing tags."
         */

        // Local tag storage for RFID tags read by the application
        private NurApi.TagStorage tags = new NurApi.TagStorage();

        // Indicates whether the inventory stream is currently running
        private bool running = false;

        public Form1()
        {
            InitializeComponent();
            nur = new NurApi();

            // InventoryStreamEvent to handle incoming tag data during inventory
            nur.InventoryStreamEvent += new EventHandler<NurApi.InventoryStreamEventArgs>(nur_InventoryStreamReady);

            try
            {
                // Connection status events to monitor changes in reader connection state
                nur.ConnectionStatusEvent += Nurapi_ConnectionStatusEvent;
            }
            catch (NurApiException ex)
            {
                // Log an error message if the NurApi initialization fails
                Debug.WriteLine($"NurApi connection failed: {ex.NurErrorMessage}");
            }

            // Initialize USB transport support and enable automatic USB connection handling
            NordicID.NurApi.USBTransport.Support.Init();
            nur.SetUsbAutoConnect(true);

            // Initialize ListView with columns for EPC, RSSI, and Timestamp
            listView1.View = View.Details;
            listView1.GridLines = true;

            // Add columns to ListView
            listView1.Columns.Add("EPC", 225);
            listView1.Columns.Add("Found RSSI", 100);
            listView1.Columns.Add("Timestamp", 140);

            // Set the initial text of the button to indicate starting the inventory stream
            button1.Text = "Start Inventory Stream";
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

                    // Update the UI elements from a different thread using BeginInvoke
                    this.BeginInvoke(new MethodInvoker(() =>
                    {
                        this.Text = $"NurAPI Dll Version: {NurApi.FileVersion}, {readerInfo.name}, {readerInfo.serial}";
                    }));
                }
                catch (Exception ex)
                {
                    // Log error message if fetching reader information fails
                    this.BeginInvoke(new MethodInvoker(() =>
                    {
                        Debug.WriteLine($"Error: GetReaderInfo: {ex.Message}");
                    }));
                }
            }
            else if (e == NurTransportStatus.Connecting)
            {
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    Debug.WriteLine("Connecting...");
                }));
            }
            else if (e == NurTransportStatus.Disconnected)
            {
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    this.Text = $"NurAPI Dll Version: {NurApi.FileVersion} (Disconnected)";
                    button1.Text = "Start Inventory Stream";
                    Debug.WriteLine("Device disconnected");
                }));
            }
        }

        // Start or stop the inventory stream
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the reader is connected before starting the inventory stream
                if (!nur.IsConnected())
                {
                    Debug.WriteLine("Reader not connected...");
                    return;
                }

                if (!running)
                {
                    // Start the inventory stream if it's not running
                    listView1.Items.Clear();
                    nur.ClearTags(); // Clear the reader's internal tag memory
                    tags.Clear();    // Clear the application's local tag storage
                    running = true;
                    nur.StartInventoryStream();
                    Debug.WriteLine("Inventory stream started running...");
                    button1.Text = "Stop";
                }
                else
                {
                    // Stop the inventory stream if running
                    nur.InventoryReadCtl = false;
                    nur.StopInventoryStream();
                    Debug.WriteLine("Inventory stream stopped...");
                    running = false;
                    button1.Text = "Start Inventory Stream";
                }
            }
            catch (Exception ex)
            {
                // Show an error message if something goes wrong
                MessageBox.Show(ex.ToString(), "Error");
                running = false;
                button1.Text = "Start Inventory Stream";  // Reset button text on error
            }
        }

        // Event handler that is called when the inventory stream data is ready
        private void nur_InventoryStreamReady(object? sender, NurApi.InventoryStreamEventArgs e)
        {
            try
            {
                // Check if the inventory stream has stopped unexpectedly and should be restarted
                if (e.data.stopped && running)
                {
                    nur.StartInventoryStream();  // Restart the inventory stream
                }

                this.BeginInvoke(new MethodInvoker(() =>
                {
                    // Get the internal tag storage from the NurApi
                    NurApi.TagStorage intTagStorage = nur.GetTagStorage();

                    // Lock the internal tag storage to ensure thread safety
                    lock (intTagStorage)
                    {
                        for (int i = 0; i < intTagStorage.Count; i++)
                        {
                            NurApi.Tag tag;

                            // Add new tags to the tag storage
                            if (tags.AddTag(intTagStorage[i], out tag))
                            {
                                // Create a new ListViewItem with EPC, RSSI, and timestamp
                                ListViewItem listViewItem = new ListViewItem(tag.GetEpcString());
                                listViewItem.SubItems.Add(tag.rssi.ToString());
                                listViewItem.SubItems.Add(DateTime.Now.ToString());

                                // Add the item to the ListView
                                listView1.Items.Add(listViewItem);

                                // Store a reference to the ListViewItem in the tag's UserData
                                tag.UserData = listViewItem;
                            }
                            else
                            {
                                // Update the ListViewItems with new data
                                ListViewItem listViewItem = tag.UserData as ListViewItem ?? new ListViewItem("Default");

                                if (listViewItem != null)
                                {
                                    listViewItem.SubItems[0].Text = tag.GetEpcString();
                                    listViewItem.SubItems[1].Text = tag.rssi.ToString();
                                    listViewItem.SubItems[2].Text = DateTime.Now.ToString();
                                }
                            }
                        }

                        // Clear the internal tag storage after processing
                        nur.ClearTags();
                    }
                }));
            }
            catch (Exception ex)
            {
                // Log the exception in the ListView
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    listView1.Items.Add(new ListViewItem(ex.Message));
                }));
            }
        }

        // Handle form closing event to ensure inventory stream stops and resources are cleaned up
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (running)
            {
                // Stop the inventory stream if it's running
                nur.StopInventoryStream();

                // Clear tag storages and reset button text
                nur.ClearTags();
                tags.Clear();
                running = false;
                button1.Text = "Start Inventory stream";
            }
        }
    }
}
