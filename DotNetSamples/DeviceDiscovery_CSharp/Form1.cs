using NurApiDotNet;
using System.Diagnostics;
using System.Web;

namespace DeviceDiscovery_CSharp
{
    public partial class Form1 : Form
    {
        NurApi? nur;
        private readonly NurDeviceDiscoveryCallback deviceDiscoveryCallback;

        public Form1()
        {
            InitializeComponent();
            nur = new NurApi();

            // Initialize columns for the ListView
            InitializeListView();

            if (nur.IsConnected())
                button1.Text = "Disconnect";
            else
                button1.Text = "Connect";

            try
            {
                // Event handler to monitor connection status
                nur.ConnectionStatusEvent += Nurapi_ConnectionStatusEvent;
            }
            catch (NurApiException ex)
            {
                // Log an error if NurApi if initialization fails
                Debug.WriteLine($"NurApi connection failed: {ex.NurErrorMessage}");
            }

            // Define the device discovery callback
            deviceDiscoveryCallback = new NurDeviceDiscoveryCallback((sender, args) =>
            {
                // Parse the URI from device information (hostname, IP, connection type)
                string uri = args.Uri.ToString();
                string hostname = "";
                string ipAddress = args.Uri.Host;
                string conntype = "";

                // Parse query parameters from the URI
                var queryParameters = HttpUtility.ParseQueryString(args.Uri.Query);
                hostname = queryParameters["hostname"] ?? "Unknown";
                conntype = queryParameters["conntype"] ?? "-";

                // Use Invoke to ensure UI updates happen on the main thread
                Invoke(new Action(() =>
                {
                    // Find existing item in the ListView (matching by IP address)
                    ListViewItem? existingItem = null;

                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (item.SubItems[0].Text == ipAddress)
                        {
                            existingItem = item;
                            break;
                        }
                    }

                    if (args.Visible) // Device online
                    {
                        if (existingItem != null)
                        {
                            // Update the existing item if the device is already in the list
                            existingItem.SubItems[1].Text = hostname;
                            existingItem.SubItems[2].Text = conntype;
                        }
                        else
                        {
                            // Add a new device if it's not already in the list
                            ListViewItem newItem = new ListViewItem(new[] { ipAddress, hostname, conntype });
                            listView1.Items.Add(newItem);
                        }
                    }
                    else // Device offline
                    {
                        // Remove the device from the list
                        if (existingItem != null)
                        {
                            listView1.Items.Remove(existingItem);
                        }
                    }
                }));

                Debug.WriteLine($"Found a device with the following URI: {uri}");
            });
        }

        // Initialize ListView columns
        private void InitializeListView()
        {
            listView1.Columns.Add("IP Address", 150);
            listView1.Columns.Add("Hostname", 150);
            listView1.Columns.Add("Interface", 100);
            listView1.View = View.Details;
        }

        // Event handler for NurApi connection status
        private void Nurapi_ConnectionStatusEvent(object? sender, NurTransportStatus e)
        {
            if (nur == null) return;

            if (e == NurTransportStatus.Connected)
            {
                try
                {
                    // Get connected reader information
                    NurApi.ReaderInfo readerInfo = nur.GetReaderInfo();

                    // Update the form title and button text
                    this.BeginInvoke(new MethodInvoker(() =>
                    {
                        this.Text = $"NurAPI Dll Version: {NurApi.FileVersion}, {readerInfo.name}, {readerInfo.altSerial}";
                        button1.Text = "Disconnect";
                    }));
                }
                catch (Exception ex)
                {
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
                    button1.Text = "Connecting";
                }));
            }
            else if (e == NurTransportStatus.Disconnected)
            {
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    this.Text = $"NurAPI Dll Version: {NurApi.FileVersion} (Disconnected)";
                    button1.Text = "Connect";
                    Debug.WriteLine("Device disconnected");
                }));
            }
        }

        // Event handler for connection button click
        private void button1_Click(object sender, EventArgs e)
        {
            // If device not selected
            if (listView1.SelectedItems.Count == 0)
            {
                // If the reader is connected but device not selected, only disconnect
                if (nur != null && nur.IsConnected())
                {
                    nur.Disconnect();
                    button1.Text = "Connect";
                }
                else
                {
                    // If the reader is not connected and no device is selected, show a message
                    MessageBox.Show("Please select a device from the list.");
                }
                return;
            }

            // Get the selected device's IP address
            string selectedIpAddress = listView1.SelectedItems[0].SubItems[0].Text;

            // If the reader is connected, disconnect and then connect to the selected device
            if (nur != null && nur.IsConnected())
            {
                nur.Disconnect();
                button1.Text = "Connect";

                // Try to connect to the selected device
                try
                {
                    nur.Connect(new Uri($"tcp://{selectedIpAddress}"));
                    button1.Text = "Disconnect";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Connection failed: {ex.Message}");
                }
            }
            else
            {
                // If the reader is not connected, connect to the selected device
                try
                {
                    nur?.Connect(new Uri($"tcp://{selectedIpAddress}"));
                    button1.Text = "Disconnect";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Connection failed: {ex.Message}");
                }
            }
            listView1.SelectedItems.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Device Discovery sample";
            NurDeviceDiscovery.Start(deviceDiscoveryCallback);  // Start device discovery
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (nur != null && nur.IsConnected())
                nur.Disconnect();
        }
    }
}
