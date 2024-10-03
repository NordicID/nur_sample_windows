using NurApiDotNet;
using System.Diagnostics;
using System.Windows.Forms;

namespace InventoryStreamMultipleReaders_CSharp
{
    public partial class Form1 : Form
    {
        List<NurApi> nurApis = new List<NurApi>();

        private readonly NurDeviceDiscoveryCallback deviceDiscoveryCallback;

        public Form1()
        {
            InitializeComponent();

            // Initialize USB transport support
            NordicID.NurApi.USBTransport.Support.Init();

            // Initialize the device discovery callback
            deviceDiscoveryCallback = new NurDeviceDiscoveryCallback((sender, args) =>
            {
                Debug.WriteLine($"Found a device with the following connection URI: {args.Uri}");

                // Create a new NurApi instance for each found device
                NurApi newNurApi = new NurApi();

                // Connection status event for all NurApi instances
                newNurApi.ConnectionStatusEvent += nur_ConnectionStatusEvent;
                newNurApi.InventoryStreamEvent += nur_InventoryStreamReady;

                try
                {
                    // Connect to the found device using the URI
                    newNurApi.Connect(args.Uri);
                    SendMessage($"Successfully connected to device at {args.Uri}");
                    nurApis.Add(newNurApi);
                }
                catch (NurApiException ex)
                {
                    SendMessage($"Failed to connect to device: {ex.Message}");
                }
            });

            // Clear the listbox if it contains data
            if (listBox1.Items.Count != 0)
                listBox1.Items.Clear();

            // Update application title to show initial state
            UpdateAppTitle();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Start device discovery for USB devices
            NurDeviceDiscovery.Start(deviceDiscoveryCallback, new string[] { "usb" });
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Properly disconnect and clean up NurApi objects if necessary
            foreach (var nurapi in nurApis)
            {
                try
                {
                    if (nurapi.IsConnected())
                    {
                        nurapi.Disconnect();
                    }
                    nurapi.Dispose();
                }
                catch (NurApiException ex)
                {
                    Debug.WriteLine($"Error while disconnecting: {ex.Message}");
                }
            }
        }

        private void nur_ConnectionStatusEvent(object? sender, NurTransportStatus e)
        {
            /* It's better to define NurApi at the method level rather than at the class level.
             * This ensures that each event (like ConnectionStatusEvent and InventoryStreamEvent)
             * handles the correct NurApi instance, preventing conflicts or overwriting issues when
             * multiple devices trigger events simultaneously.
            */

            NurApi? nur = sender as NurApi;

            // Check if null before using the 'nur' object
            if (nur == null)
            {
                return;
            }

            if (e == NurTransportStatus.Connected)
            {
                // Device connected
                Debug.WriteLine($"Connected to reader {nur.Info.name}");
                SendMessage($"CONNECTED: {nur.GetReaderInfo().name}, {nur.GetReaderInfo().altSerial}, {nur.GetReaderInfo().GetVersionString()}");

                // Start the inventory stream
                nur.StartInventoryStream();
                UpdateAppTitle();
            }
            else if (e == NurTransportStatus.Connecting)
            {
                // Device connecting
                SendMessage("Connecting to reader...");
            }
            else if (e == NurTransportStatus.Disconnected)
            {
                // Device disconnected
                SendMessage("Disconnected from reader");
                UpdateAppTitle();
            }
        }

        // Inventory stream event, called when there are tags available in NurApi tag storage
        void nur_InventoryStreamReady(object? sender, NurApi.InventoryStreamEventArgs e)
        {
            NurApi? nur = sender as NurApi;

            // Check if null before using the 'nur' object
            if (nur == null)
            {
                return;
            }

            try
            {
                // Copy tags from NurApi internal tag storage to application tag storage
                NurApi.TagStorage intTagStorage = nur.GetTagStorage();
                lock (intTagStorage)
                {
                    SendMessage(string.Format("Reader: {0}, Tags: {1}", nur.GetReaderInfo().altSerial, intTagStorage.Count));
                    // Clear NurApi internal tag storage
                    nur.ClearTags();
                }

                if (e.data.stopped)
                {
                    // Start streaming again if stopped
                    nur.StartInventoryStream();
                }
            }
            catch (Exception ex)
            {
                // Handle error
                SendMessage(ex.Message);
            }
        }

        private void SendMessage(string message)
        {
            // Check if the form's handle is created before updating the UI.
            if (IsHandleCreated)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    // Add the message with a timestamp to the ListBox and scroll to the latest entry.
                    listBox1.Items.Add($"{DateTime.Now.ToUniversalTime()}: {message}");
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    Application.DoEvents();
                }));
            }
            else
            {
                // Optionally handle the case when the handle is not created
                Debug.WriteLine("Window handle not created. Unable to send message.");
            }
        }

        private void UpdateAppTitle()
        {
            // Prevents updating the form before it's fully initialized or after it's disposed.
            if (IsHandleCreated)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    int connectedDevices = 0;

                    // Count how many devices are currently connected
                    foreach (var nurapi in nurApis)
                    {
                        if (nurapi.IsConnected())
                            connectedDevices++;
                    }

                    // Update the Form title version and number and connected devices
                    this.Text = $"NurApi: {NurApi.FileVersion} - {connectedDevices} connected devices";
                }));
            }
            else
            {
                Debug.WriteLine("Window handle not created. Unable to update title.");
            }
        }
    }
}
