using NurApiDotNet;
using System.Diagnostics;

namespace HelloNUR_CSharp
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
                // Subscribe to connection status events
                nur.ConnectionStatusEvent += Nurapi_ConnectionStatusEvent;
            }
            catch (NurApiException ex)
            {
                // Log error if the NurApi initialization fails
                Debug.WriteLine($"NurApi connection failed: {ex.NurErrorMessage}");
            }

            // Initialize USB transport support and enable automatic USB connection
            NordicID.NurApi.USBTransport.Support.Init();
            nur.SetUsbAutoConnect(true);
        }

        // Event handler for NurApi connection status changes
        private void Nurapi_ConnectionStatusEvent(object? sender, NurTransportStatus e)
        {
            if (e == NurTransportStatus.Connected)
            {
                try
                {
                    // Get reader information from the module
                    NurApi.ReaderInfo readerInfo = nur.GetReaderInfo();

                    // Update the ListBox with reader information using BeginInvoke for thread safety
                    this.BeginInvoke(new MethodInvoker(() =>
                    {
                        // Clear previous messages from the ListBox
                        listBox1.Items.Clear();

                        // Display reader information in the ListBox
                        listBox1.Items.Add($"Name\t{readerInfo.name}");
                        listBox1.Items.Add($"Version\t{readerInfo.GetVersionString()}");
                        listBox1.Items.Add($"HW Ver\t{readerInfo.hwVersion}");
                        listBox1.Items.Add($"FCC\t  {readerInfo.fccId}");
                        listBox1.Items.Add($"Serial\t{readerInfo.serial}");
                        listBox1.Items.Add($"SW Ver\t{readerInfo.swVerMajor}.{readerInfo.swVerMinor}");
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
                // Update ListBox to show "Connecting" message
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add("Connecting");
                }));
            }
            else if (e == NurTransportStatus.Disconnected)
            {
                // Update ListBox to show "Device disconnected" message
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add("Device disconnected");
                }));
            }
        }
    }
}
