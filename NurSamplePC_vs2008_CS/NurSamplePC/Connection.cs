using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NurApiDotNet;

namespace NurSample
{
    public partial class Connection : UserControl
    {
        /// <summary>
        /// The NurApi handle
        /// </summary>
        NurApi hNur = null;

        bool disableEvents = false;

        class connectionComboItem
        {
            public string DevPath;
            public string Name;
            public int Port;
            public connectionComboItem(string devPath, string name, int port)
            {
                this.DevPath = devPath;
                this.Name = name;
                this.Port = port;
            }
            public override string ToString() { return Name; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Connection"/> class.
        /// </summary>
        public Connection()
        {
            InitializeComponent();
        }

        private void Connection_Load(object sender, EventArgs e)
        {
            socketAddressTextBox.Text = Properties.Settings.Default.connectionSocketAddress;
            socketPortNumericUpDown.Value = Properties.Settings.Default.connectionSocketPort;
            usbCombo_Click(this, EventArgs.Empty);
            serialCombo_Click(this, EventArgs.Empty);
            // Update RadioBoxes
            useUsbRadioBox.Checked = Properties.Settings.Default.connectionUsb;
            useUsbAutoRadioBox.Checked = Properties.Settings.Default.connectionUsbAuto;
            useSerialRadioBox.Checked = Properties.Settings.Default.connectionSerial;
            useSocketRadioBox.Checked = Properties.Settings.Default.connectionSocket;
        }

        /// <summary>
        /// Sets the NurApi.
        /// </summary>
        /// <param name="hNur">The handle of NurApi.</param>
        public void SetNurApi(NurApi hNur)
        {
            try
            {
                this.hNur = hNur;

                // Set event handlers for NurApi
                hNur.DisconnectedEvent += new EventHandler<NurApi.NurEventArgs>(hNur_DisconnectedEvent);
                hNur.ConnectedEvent += new EventHandler<NurApi.NurEventArgs>(hNur_ConnectedEvent);

                // Update the status of the connection
                if (hNur.IsConnected())
                    hNur_ConnectedEvent(hNur, null);
                else
                {
                    hNur_DisconnectedEvent(hNur, null);
                    conStatusDesc.Text = "No connection";
                }
            }
            catch (NurApiException ex)
            {
                MessageBox.Show(ex.ToString(), Program.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the DisconnectedEvent event of the NUR module.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="NurApi.NurEventArgs" /> instance containing the event data.</param>
        private void hNur_DisconnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            NurApi hNur = sender as NurApi;
            conStatusDesc.Text = "Disconnected";
            UpdateButtons();
        }

        /// <summary>
        /// Handles the ConnectedEvent event of the NUR module.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="NurApi.NurEventArgs" /> instance containing the event data.</param>
        private void hNur_ConnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            NurApi hNur = sender as NurApi;
            conStatusDesc.Text = "Connected";
            UpdateButtons();
            // Update default settings
            Properties.Settings.Default.connectionUsb = useUsbRadioBox.Checked;
            Properties.Settings.Default.connectionUsbAuto = useUsbAutoRadioBox.Checked;
            Properties.Settings.Default.connectionSerial = useSerialRadioBox.Checked;
            Properties.Settings.Default.connectionSocket = useSocketRadioBox.Checked;
            if (useSocketRadioBox.Checked)
            {
                Properties.Settings.Default.connectionSocketAddress = socketAddressTextBox.Text;
                Properties.Settings.Default.connectionSocketPort = (int)socketPortNumericUpDown.Value;
            }
            // Save default settings
            Properties.Settings.Default.Save();
        }

        private void updateControls_CheckedChanged(object sender, EventArgs e)
        {
            if (disableEvents)
                return;

            usbCombo.Enabled = useUsbRadioBox.Checked;
            serialCombo.Enabled = useSerialRadioBox.Checked;
            socketAddressTextBox.Enabled = useSocketRadioBox.Checked;
            socketPortNumericUpDown.Enabled = useSocketRadioBox.Checked;

            if (hNur != null && useUsbAutoRadioBox == sender)
            {
                hNur.SetUsbAutoConnect(useUsbAutoRadioBox.Checked);
            }

            UpdateButtons();
        }

        private void usbCombo_Click(object sender, EventArgs e)
        {
            if (hNur != null)
            {
                List<NurApi.UsbDevice> ports = NurApi.EnumerateUsbDevices();

                int currentSelection = usbCombo.SelectedIndex;
                usbCombo.Items.Clear();
                foreach (NurApi.UsbDevice dev in ports)
                {
                    usbCombo.Items.Add(new connectionComboItem(dev.devPath, dev.friendlyName, 0));
                }
                if (0 <= currentSelection && currentSelection < usbCombo.Items.Count)
                    usbCombo.SelectedIndex = currentSelection;
                else
                    usbCombo.SelectedIndex = usbCombo.Items.Count - 1;
            }
        }

        private void serialCombo_Click(object sender, EventArgs e)
        {
            if (hNur != null)
            {
                List<NurApi.ComPort> ports = NurApi.EnumerateComPorts();

                int currentSelection = serialCombo.SelectedIndex;
                serialCombo.Items.Clear();
                foreach (NurApi.ComPort port in ports)
                {
                    serialCombo.Items.Add(new connectionComboItem("", port.friendlyName, port.port));
                }
                if (0 <= currentSelection && currentSelection < serialCombo.Items.Count)
                    serialCombo.SelectedIndex = currentSelection;
                else
                    serialCombo.SelectedIndex = serialCombo.Items.Count - 1;
            }
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (hNur.IsConnected())
                {
                    hNur.Disconnect();
                }
                else
                {
                    if (useLatestRadioBox.Checked)
                    {
                        hNur.Connect();
                    }
                    else if (useUsbAutoRadioBox.Checked)
                    {
                        hNur.SetUsbAutoConnect(false);
                        hNur.SetUsbAutoConnect(true);
                    }
                    else if (useUsbRadioBox.Checked)
                    {
                        connectionComboItem comboItem = usbCombo.SelectedItem as connectionComboItem;
                        hNur.ConnectUsb(comboItem.DevPath);
                    }
                    else if (useSerialRadioBox.Checked)
                    {
                        connectionComboItem comboItem = serialCombo.SelectedItem as connectionComboItem;
                        hNur.ConnectSerialPort(comboItem.Port);
                    }
                    else if (useSocketRadioBox.Checked)
                    {
                        hNur.ConnectSocket(socketAddressTextBox.Text, (int)socketPortNumericUpDown.Value);
                    }
                }
            }
            catch (NurApiException ex)
            {
                MessageBox.Show(ex.ToString(), Program.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateButtons()
        {
            if (hNur == null)
                return;

            if (hNur.IsConnected())
            {
                connectBtn.Text = "DISCONNECT";
            }
            else
            {
                connectBtn.Text = "CONNECT";
            }
        }
    }
}
