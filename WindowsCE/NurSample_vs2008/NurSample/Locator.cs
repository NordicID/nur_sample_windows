using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using NurApiDotNet; //NurApi wrapper

namespace NurSample
{
    public partial class Locator : UserControl
    {
        /// <summary>
        /// The NurApi handle
        /// </summary>
        NurApi hNur = null;

        /// <summary>
        /// The locator beeper
        /// </summary>
        BeeperLocator beeperLocator = new BeeperLocator();

        /// <summary>
        /// Range of the signal
        /// </summary>
        const int NOSIGNAL = 0;
        const int MAXSIGNAL = 100;

        /// <summary>
        /// Locating parameters
        /// </summary>
        const int MAXTXPOWER = 0;
        const int MINTXPOWER = 4;
        const int PWRSLOWSTEPS = 1;
        const int PWRFASTSTEPS = 2;
        const int PWRDWNLEVEL = 70;
        const int PWRUPDLEVEL = 40;
        const int ZEROFILTER = 1;

        /// <summary>
        /// Containen for signals
        /// </summary>
        SignalStrength locatingSignal = null;

        /// <summary>
        /// Locator variables
        /// </summary>
        static bool IsRunning = false;
        bool keepLocating = false;

        private struct LocatorFilter
        {
            readonly static string[] bankTexts = { "PSWD:", "EPC:", "TID:", "USER:" };
            public int Bank;
            public int Address;
            public int Length;
            public byte[] Mask;
            public string Name;
            public bool GenerateName;
            public override string ToString()
            {
                if (GenerateName)
                    return string.Format("{0} [{1} 0x{2}, {3}/{4}]", Name, bankTexts[Bank], NurApi.BinToHexString(Mask), Address, Length);
                return Name;
            }
            public string BankName { get { return bankTexts[Bank]; } }
            public LocatorFilter(int bank, int address, string mask, string name)
            {
                Bank = bank;
                Address = address;
                Length = mask.Length * 4;
                if (mask.Length % 2 != 0)
                    mask += "0";
                Mask = NurApi.HexStringToBin(mask);
                Name = name;
                GenerateName = true;
            }
            public LocatorFilter(int bank, int address, string mask, string name, bool generateName)
            {
                Bank = bank;
                Address = address;
                Length = mask.Length * 4;
                if (mask.Length % 2 != 0)
                    mask += "0";
                Mask = NurApi.HexStringToBin(mask);
                Name = name;
                GenerateName = generateName;
            }
            public LocatorFilter(int bank, int address, string mask, bool trim, string name, bool generateName)
            {
                Bank = bank;
                Address = address;
                Length = mask.Length * 4;
                if (mask.Length % 2 != 0)
                    mask += "0";
                Mask = NurApi.HexStringToBin(mask);
                if (trim)
                {
                    Mask = Utils.ShiftLeft(Mask, address % 8);
                    Length -= address % 8;
                }
                Name = name;
                GenerateName = generateName;
            }
            public LocatorFilter(int bank, int address, int length, string mask, string name)
            {
                Bank = bank;
                Address = address;
                Length = length;
                if (mask.Length % 2 != 0)
                    mask += "0";
                Mask = NurApi.HexStringToBin(mask);
                Name = name;
                GenerateName = true;
            }
        }

        readonly static LocatorFilter[] comboItems = new LocatorFilter[] {
            new LocatorFilter(NurApi.BANK_PASSWD, 0,  "", "Reserved MEM", false),
            new LocatorFilter(NurApi.BANK_EPC,    32, "", "EPC CODE", false),
            new LocatorFilter(NurApi.BANK_TID,    0,  "", "TID MEM", false),
            new LocatorFilter(NurApi.BANK_USER,   0,  "", "User MEM", false),
            new LocatorFilter(NurApi.BANK_TID, 9, "003", true, "Alien Technology", false),
            new LocatorFilter(NurApi.BANK_TID, 0, "E2003411", " Higgs-2"),
            new LocatorFilter(NurApi.BANK_TID, 0, "E2003412", " Higgs-3"),
            new LocatorFilter(NurApi.BANK_TID, 0, "E2003414", " Higgs-4"),
            new LocatorFilter(NurApi.BANK_TID, 9, "005", true, "Atmel", false),
            new LocatorFilter(NurApi.BANK_TID, 9, "012", true, "CAEN RFID srl", false),
            new LocatorFilter(NurApi.BANK_TID, 9, "018", true, "Ceitec S.A.", false),
            new LocatorFilter(NurApi.BANK_TID, 9, "01F", true, "Chipus Microelectronics", false),
            new LocatorFilter(NurApi.BANK_TID, 9, "019", true, "CPA Wernher von Braun", false),
            new LocatorFilter(NurApi.BANK_TID, 9, "00B", true, "EM Microelectronics", false),
            new LocatorFilter(NurApi.BANK_TID, 0, "E280B040", " EM4325"),
            new LocatorFilter(NurApi.BANK_TID, 9, "008", true, "EP Microelectronics", false),
            new LocatorFilter(NurApi.BANK_TID, 9, "014", true, "Federal Electric Corp.", false),
            new LocatorFilter(NurApi.BANK_TID, 9, "010", true, "Fujitsu", false),
            new LocatorFilter(NurApi.BANK_TID, 9, "023", true, "Gate Elektronik", false),
            new LocatorFilter(NurApi.BANK_TID, 9, "001", true, "Impinj", false),
            new LocatorFilter(NurApi.BANK_TID, 0, "E2001050", " Monza 1a"),
            new LocatorFilter(NurApi.BANK_TID, 0, "E2001093", " Monza 3"),
            new LocatorFilter(NurApi.BANK_TID, 0, "E2801100", " Monza 4D"),
            new LocatorFilter(NurApi.BANK_TID, 0, "E2801104", " Monza 4U"),
            new LocatorFilter(NurApi.BANK_TID, 0, "E2801105", " Monza 4QT"),
            new LocatorFilter(NurApi.BANK_TID, 0, "E280110C", " Monza 4E"),
            new LocatorFilter(NurApi.BANK_TID, 0, "E2801130", " Monza 5"),
            new LocatorFilter(NurApi.BANK_TID, 0, "E2801160", " Monza R6"),
            new LocatorFilter(NurApi.BANK_TID, 9, "004", true, "Intelleflex", false),
            new LocatorFilter(NurApi.BANK_TID, 9, "01C", true, "Invengo", false),
            new LocatorFilter(NurApi.BANK_TID, 9, "01D", true, "Kiloway", false),
            new LocatorFilter(NurApi.BANK_TID, 9, "01E", true, "Longjing Microelectronics Co. Ltd.", false),
            new LocatorFilter(NurApi.BANK_TID, 9, "011", true, "LSIS", false),
            new LocatorFilter(NurApi.BANK_TID, 9, "021", true, "Maintag", false),
            new LocatorFilter(NurApi.BANK_TID, 9, "009", true, "Motorola (formerly Symbol Technologies)", false),
            new LocatorFilter(NurApi.BANK_TID, 9, "00D", true, "Mstar", false),
            new LocatorFilter(NurApi.BANK_TID, 9, "01B", true, "Nationz", false),
            new LocatorFilter(NurApi.BANK_TID, 9, "006", true, "NXP Semiconductors", false),
            new LocatorFilter(NurApi.BANK_TID, 0, "E2006003", " G2XM"),
            new LocatorFilter(NurApi.BANK_TID, 0, "E2006004", " G2XL"),
            new LocatorFilter(NurApi.BANK_TID, 0, "E2006806", " G2iL"),
            new LocatorFilter(NurApi.BANK_TID, 0, "E2006807", " G2iL+"),
            new LocatorFilter(NurApi.BANK_TID, 0, "E2806810", " UCODE 7"),
            new LocatorFilter(NurApi.BANK_EPC, 0x20F, 1, "80"," PSF bit"),
            new LocatorFilter(NurApi.BANK_TID, 9, "015", true, "ON Semiconductor", false),
            new LocatorFilter(NurApi.BANK_TID, 9, "020", true, "ORIDAO", false),
            new LocatorFilter(NurApi.BANK_TID, 9, "013", true, "Productivity Engineering Gesellschaft fuer IC Design mbH", false),
            new LocatorFilter(NurApi.BANK_TID, 9, "00F", true, "Quanray Electronics", false),
            new LocatorFilter(NurApi.BANK_TID, 9, "016", true, "Ramtron", false),
            new LocatorFilter(NurApi.BANK_TID, 9, "00C", true, "Renesas Technology Corp.", false),
            new LocatorFilter(NurApi.BANK_TID, 9, "024", true, "RFMicron, Inc.", false),
            new LocatorFilter(NurApi.BANK_TID, 9, "025", true, "RST-Invent LLC", false),
            new LocatorFilter(NurApi.BANK_TID, 9, "00A", true, "Sentech Snd Bhd", false),
            new LocatorFilter(NurApi.BANK_TID, 9, "007", true, "ST Microelectronics", false),
            new LocatorFilter(NurApi.BANK_TID, 9, "017", true, "Tego", false),
            new LocatorFilter(NurApi.BANK_TID, 9, "002", true, "Texas Instruments", false),
            new LocatorFilter(NurApi.BANK_TID, 9, "01A", true, "TransCore", false),
            new LocatorFilter(NurApi.BANK_TID, 9, "00E", true, "Tyco International", false),
            new LocatorFilter(NurApi.BANK_TID, 9, "022", true, "Yangzhou Daoyuan Microelectronics Co. Ltd", false),
        };

        LocatorFilter selectedComboItem;
        LocatorFilter locatorTarget = new LocatorFilter();

        /// <summary>
        /// Initializes a new instance of the <see cref="Locator" /> class.
        /// </summary>
        public Locator()
        {
            InitializeComponent();
            this.Enabled = false;

            locatingSignal = new SignalStrength();
            locatingSignal.ZeroFilter = ZEROFILTER;
            // Configure Locator bar
            locatorBar.Minimum = 0;
            locatorBar.Maximum = MAXSIGNAL;
            // Configure beeper
            beeperLocator.MaxLevel = MAXSIGNAL;
            // Initialize ComboBox
            bankCB.SelectedIndex = NurApi.BANK_EPC;
            presetListBox.Items.Clear();
            for (int n = 0; n < comboItems.Length; n++)
                presetListBox.Items.Add(comboItems[n]);
            presetListBox.SelectedIndex = 1;
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            StopLocating();
            if (disposing && (beeperLocator != null))
            {
                beeperLocator.Dispose();
            }
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
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
                    hNur_DisconnectedEvent(hNur, null);
            }
            catch (NurApiException ex)
            {
                MessageBox.Show(ex.ToString(), Program.appName);
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
            this.Enabled = false;
        }

        /// <summary>
        /// Handles the ConnectedEvent event of the NUR module.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="NurApi.NurEventArgs" /> instance containing the event data.</param>
        private void hNur_ConnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            NurApi hNur = sender as NurApi;
            this.Enabled = true;
        }

        /// <summary>
        /// Handles the Click event of the refreshBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            // Clear Tag List
            tagListView.ClearTagList();
            // Clear previously inventoried tags from memory
            hNur.ClearTags();
            // Perform simple inventory
            for (int i = 0; i < 3; i++)
            {
                hNur.SimpleInventory();
                // Fetch tags from module, including tag meta
                NurApi.TagStorage inventoriedTags = hNur.FetchTags(true);
                // Update Tag List
                tagListView.UpdateTagList(inventoriedTags);
            }
        }

        /// <summary>
        /// Handles the SelectedTagChanged event of the tagListView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tagListView_SelectedTagChanged(object sender, EventArgs e)
        {
            NurApi.Tag selectedTag = tagListView.SelectedTag;
            if (selectedTag != null)
            {
                // Unselect preset list.
                presetListBox.SelectedIndex = -1;
                // Set EPC to target.
                bankCB.SelectedIndex = NurApi.BANK_EPC;
                startUD.Value = 32;
                tagToLocate.Text = selectedTag.GetEpcString();
                lengthUD.Value = tagToLocate.Text.Length * 4;
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the bankCombo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void presetListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (presetListBox.SelectedIndex >= 0)
            {
                selectedComboItem = (LocatorFilter)presetListBox.SelectedItem;
                bankCB.SelectedIndex = selectedComboItem.Bank;
                startUD.Value = selectedComboItem.Address;
                lengthUD.Value = selectedComboItem.Length;
                tagToLocate.Text = NurApi.BinToHexString(selectedComboItem.Mask);
            }
        }

        /// <summary>
        /// Handles the Click event of the locateBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void locateBtn_Click(object sender, EventArgs e)
        {
            if (updateTimer.Enabled)
            {
                // Stop Locator
                StopLocating();
                locateBtn.Text = "Locate";
            }
            else
            {
                // Start Locator
                tabControl1.SelectedIndex = 2;
                locateBtn.Text = "Stop";
                StartLocating();
            }
        }

        int updTxLevel = -1;
        int updScaledRSSI = -1;
        bool updInTheField = false;
        /// <summary>
        /// Handles the Tick event of the updateTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void updateTimer_Tick(object sender, EventArgs e)
        {
            //Keepd device alive
            HHUtils.KeepDeviceAlive();
            bool updateIndicators = false;
            SignalStrength.Signal signal = locatingSignal.GetSignal();
            bool inTheField = signal.scaledRssi > 0;

            if (updTxLevel != signal.txLevelReal)
            {
                // Update new Tx Level
                updateIndicators = true;
                txLevelTxt.Text = String.Format("TX Level: {0}",
                    NurCapabilities.I.ConvertToString(NurApi.SETUP_TXLEVEL, signal.txLevelReal));
                updTxLevel = signal.txLevelReal;
            }

            if (updScaledRSSI != signal.scaledRssi)
            {
                // Update new RSSI Level
                updateIndicators = true;
                if (signal.scaledRssi > NOSIGNAL)
                    rssiLevelTxt.Text = String.Format("RSSI: {0}% {1}dBm", signal.scaledRssi, signal.rssi);
                else
                    rssiLevelTxt.Text = "RSSI: no signal";
                // Update indicators
                locatorBar.Value = signal.scaledRssi;
                updScaledRSSI = signal.scaledRssi;
            }

            if (updateIndicators)
            {
                // Update indicators
                beeperLocator.Beep(signal.scaledRssi, inTheField != updInTheField);
                updInTheField = inTheField;
            }

            if (!IsRunning)
            {
                updateTimer.Enabled = false;
            }
        }

        /// <summary>
        /// Starts the locating.
        /// </summary>
        /// <returns>true if succeed</returns>
        private bool StartLocating()
        {
            // Set a new target
            locatorTarget.Bank = bankCB.SelectedIndex;
            locatorTarget.Address = (int)startUD.Value;
            locatorTarget.Length = (int)lengthUD.Value;
            locatorTarget.Mask = NurApi.HexStringToBin(tagToLocate.Text);
            // Is Locator running
            if (IsRunning) return false;
            // Initialize locator
            IsRunning = true;
            keepLocating = true;
            updTxLevel = -1;
            updScaledRSSI = -1;
            locatingSignal.NumberOfAntennas = hNur.GetReaderInfo().numAntennas;
            // Start beeper and so on 
            updateTimer.Enabled = true;
            beeperLocator.Start();
            // Create and start Locator thread
            Thread locateThread = new Thread(LocateThread);
            locateThread.IsBackground = true;
            locateThread.Start();
            return true;
        }

        /// <summary>
        /// Stops the tag locator.
        /// </summary>
        /// <returns>true if succeed</returns>
        public bool StopLocating()
        {
            // Is Locator running
            if (!IsRunning) return false;
            // Stop beeper and so on 
            beeperLocator.Stop();
            // Stop Locator thread
            int killCounter = 20;
            keepLocating = false;
            while (IsRunning && killCounter-- != 0)
            {
                Thread.Sleep(50);
            }
            return killCounter != 0;
        }

        /// <summary>
        /// Tag Locator.
        /// </summary>
        private void LocateThread()
        {
            int originalTxLevel = 0;
            int originalAntenna = 0;
            int antenna = 0;
            int lastTxLevel = -1;
            // Get original settings
            try
            {
                originalTxLevel = hNur.TxLevel;
                originalAntenna = hNur.SelectedAntenna;
            }
            catch { }

            // Locating loop
            while (keepLocating)
            {
                try
                {
                    // Select antenna
                    hNur.SelectedAntenna = antenna;
                    // Set new txLevel if necessary 
                    if (lastTxLevel != locatingSignal.signals[antenna].txLevelSuggestion)
                    {
                        // Set new TxLevel
                        hNur.TxLevel = locatingSignal.signals[antenna].txLevelSuggestion;
                        // Read the TxLevel back, because the Reagion setting may change it
                        lastTxLevel = locatingSignal.signals[antenna].txLevelReal = hNur.TxLevel;
                    }
                    // Trace tag
                    NurApi.TraceTagData tagdata;
                    tagdata = hNur.TraceTag((byte)locatorTarget.Bank, (uint)locatorTarget.Address, (int)locatorTarget.Length, locatorTarget.Mask, NurApi.TRACETAG_NO_EPC);
                    // Set new level
                    locatingSignal.SetSignal(antenna, tagdata.scaledRssi, tagdata.rssi, lastTxLevel);
                }
                catch (NurApiException)
                {
                    // Program jumps here if TraceTag not found a tag
                    locatingSignal.SetSignal(antenna, 0, -128, lastTxLevel);
                }

                // More antennas?
                if (++antenna < locatingSignal.NumberOfAntennas)
                    continue;
                else
                    antenna = 0;

                // Get new txLevel
                for (int ant = 0; ant < locatingSignal.signals.Length; ant++)
                {
                    // Calc new TxLevel
                    int newTxLevel = locatingSignal.signals[ant].txLevelReal;
                    if (locatingSignal.signals[ant].scaledRssi >= MAXSIGNAL)
                        newTxLevel += PWRFASTSTEPS;
                    else if (locatingSignal.signals[ant].scaledRssi >= PWRDWNLEVEL)
                        newTxLevel += PWRSLOWSTEPS;
                    else if (locatingSignal.signals[ant].scaledRssi <= NOSIGNAL)
                        newTxLevel -= PWRFASTSTEPS;
                    else if (locatingSignal.signals[ant].scaledRssi <= PWRUPDLEVEL)
                        newTxLevel -= PWRSLOWSTEPS;
                    // Check the TxLevel
                    if (newTxLevel < MAXTXPOWER)
                        newTxLevel = MAXTXPOWER;
                    else if (newTxLevel > MINTXPOWER)
                        newTxLevel = MINTXPOWER;
                    // Set new TxLevel
                    locatingSignal.signals[ant].txLevelSuggestion = newTxLevel;
                }
            }
            // Restore original settings
            try
            {
                hNur.TxLevel = originalTxLevel;
                hNur.SelectedAntenna = originalAntenna;
            }
            catch { }
            IsRunning = false;
        }
    }

    class SignalStrength
    {
        public struct Signal
        {
            public int rssi;
            public int scaledRssi;
            public int noSigCnt;
            public int txLevelReal;
            public int txLevelSuggestion;
        }

        public Signal[] signals = new Signal[1];

        public int NumberOfAntennas
        {
            get { return signals.Length; }
            set
            {
                signals = new Signal[value];
                for (int ant = 0; ant < signals.Length; ant++)
                {
                    signals[ant].scaledRssi = 0;
                    signals[ant].rssi = 0;
                    signals[ant].noSigCnt = 0;
                    signals[ant].txLevelReal = 0;
                    signals[ant].txLevelSuggestion = 0;
                }
            }
        }

        public int ZeroFilter = 0;

        public void SetSignal(int antenna, int scaledRssi, int rssi, int txlevel)
        {
            signals[antenna].txLevelReal = txlevel;
            if (scaledRssi <= 0)
            {
                if (++signals[antenna].noSigCnt > ZeroFilter)
                {
                    signals[antenna].scaledRssi = scaledRssi;
                    signals[antenna].rssi = rssi;
                }
            }
            else
            {
                signals[antenna].noSigCnt = 0;
                signals[antenna].scaledRssi = scaledRssi;
                signals[antenna].rssi = rssi;
            }
        }

        public Signal GetSignal()
        {
            int maxSignal = 0;
            int antenna = 0;
            for (int ant = 0; ant < signals.Length; ant++)
            {
                if (maxSignal < signals[ant].scaledRssi)
                    antenna = ant;
            }
            return signals[antenna];
        }
    }
}
