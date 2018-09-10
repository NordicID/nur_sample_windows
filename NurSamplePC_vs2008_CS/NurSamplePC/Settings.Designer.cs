namespace NurSample
{
    partial class Settings
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.rfTab = new System.Windows.Forms.TabPage();
            this.rxSensitivityLabel = new System.Windows.Forms.Label();
            this.rxSensitivity_ComboBox = new System.Windows.Forms.ComboBox();
            this.txlevelLabel = new System.Windows.Forms.Label();
            this.txLevelCombo = new System.Windows.Forms.ComboBox();
            this.txmodLabel = new System.Windows.Forms.Label();
            this.rxdecLabel = new System.Windows.Forms.Label();
            this.lfLabel = new System.Windows.Forms.Label();
            this.regionLabel = new System.Windows.Forms.Label();
            this.txModCombo = new System.Windows.Forms.ComboBox();
            this.rxDecCombo = new System.Windows.Forms.ComboBox();
            this.lfCombo = new System.Windows.Forms.ComboBox();
            this.regionCombo = new System.Windows.Forms.ComboBox();
            this.antennaTab = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.enTuneEvents_CheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.autoTuneTreshold_UpDown = new System.Windows.Forms.NumericUpDown();
            this.autoTune_Label = new System.Windows.Forms.Label();
            this.autoTune_ComboBox = new System.Windows.Forms.ComboBox();
            this.antennaLabel = new System.Windows.Forms.Label();
            this.selectedAntenna = new System.Windows.Forms.ComboBox();
            this.invTab = new System.Windows.Forms.TabPage();
            this.invEpcLenCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.periodCombo = new System.Windows.Forms.ComboBox();
            this.epcLenLabel = new System.Windows.Forms.Label();
            this.targetLabel = new System.Windows.Forms.Label();
            this.targetCombo = new System.Windows.Forms.ComboBox();
            this.roundsCombo = new System.Windows.Forms.ComboBox();
            this.sessionCombo = new System.Windows.Forms.ComboBox();
            this.qCombo = new System.Windows.Forms.ComboBox();
            this.roundsLabel = new System.Windows.Forms.Label();
            this.sessionLabel = new System.Windows.Forms.Label();
            this.qLabel = new System.Windows.Forms.Label();
            this.filtTab = new System.Windows.Forms.TabPage();
            this.filtGuide = new System.Windows.Forms.Label();
            this.maxFiltLabel = new System.Windows.Forms.Label();
            this.minFiltLabel = new System.Windows.Forms.Label();
            this.inventoryRssiMax = new System.Windows.Forms.NumericUpDown();
            this.writeRssiMax = new System.Windows.Forms.NumericUpDown();
            this.readRssiMax = new System.Windows.Forms.NumericUpDown();
            this.inventoryRssiMin = new System.Windows.Forms.NumericUpDown();
            this.writeRssiMin = new System.Windows.Forms.NumericUpDown();
            this.invFiltLabel = new System.Windows.Forms.Label();
            this.writeFiltLabel = new System.Windows.Forms.Label();
            this.readRssiMin = new System.Windows.Forms.NumericUpDown();
            this.readFiltLabel = new System.Windows.Forms.Label();
            this.rssiFiltLabel = new System.Windows.Forms.Label();
            this.miscTab = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.storeSetupBtn = new System.Windows.Forms.Button();
            this.antennaTuneTab = new System.Windows.Forms.TabPage();
            this.nurTune = new NurSample.AntennaTuner();
            this.tabControl1.SuspendLayout();
            this.rfTab.SuspendLayout();
            this.antennaTab.SuspendLayout();
            this.invTab.SuspendLayout();
            this.filtTab.SuspendLayout();
            this.miscTab.SuspendLayout();
            this.antennaTuneTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.rfTab);
            this.tabControl1.Controls.Add(this.antennaTab);
            this.tabControl1.Controls.Add(this.invTab);
            this.tabControl1.Controls.Add(this.filtTab);
            this.tabControl1.Controls.Add(this.miscTab);
            this.tabControl1.Controls.Add(this.antennaTuneTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 320);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // rfTab
            // 
            this.rfTab.Controls.Add(this.rxSensitivityLabel);
            this.rfTab.Controls.Add(this.rxSensitivity_ComboBox);
            this.rfTab.Controls.Add(this.txlevelLabel);
            this.rfTab.Controls.Add(this.txLevelCombo);
            this.rfTab.Controls.Add(this.txmodLabel);
            this.rfTab.Controls.Add(this.rxdecLabel);
            this.rfTab.Controls.Add(this.lfLabel);
            this.rfTab.Controls.Add(this.regionLabel);
            this.rfTab.Controls.Add(this.txModCombo);
            this.rfTab.Controls.Add(this.rxDecCombo);
            this.rfTab.Controls.Add(this.lfCombo);
            this.rfTab.Controls.Add(this.regionCombo);
            this.rfTab.Location = new System.Drawing.Point(4, 25);
            this.rfTab.Name = "rfTab";
            this.rfTab.Size = new System.Drawing.Size(232, 291);
            this.rfTab.Text = "Radio";
            // 
            // rxSensitivityLabel
            // 
            this.rxSensitivityLabel.Location = new System.Drawing.Point(3, 152);
            this.rxSensitivityLabel.Name = "rxSensitivityLabel";
            this.rxSensitivityLabel.Size = new System.Drawing.Size(100, 20);
            this.rxSensitivityLabel.Text = "RX Sensitivity";
            this.rxSensitivityLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // rxSensitivity_ComboBox
            // 
            this.rxSensitivity_ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rxSensitivity_ComboBox.Items.Add("LOW");
            this.rxSensitivity_ComboBox.Items.Add("NOMINAL");
            this.rxSensitivity_ComboBox.Items.Add("HIGH");
            this.rxSensitivity_ComboBox.Location = new System.Drawing.Point(109, 152);
            this.rxSensitivity_ComboBox.Name = "rxSensitivity_ComboBox";
            this.rxSensitivity_ComboBox.Size = new System.Drawing.Size(120, 23);
            this.rxSensitivity_ComboBox.TabIndex = 17;
            this.rxSensitivity_ComboBox.SelectedIndexChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // txlevelLabel
            // 
            this.txlevelLabel.Location = new System.Drawing.Point(3, 65);
            this.txlevelLabel.Name = "txlevelLabel";
            this.txlevelLabel.Size = new System.Drawing.Size(100, 20);
            this.txlevelLabel.Text = "TX Level";
            this.txlevelLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txLevelCombo
            // 
            this.txLevelCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txLevelCombo.Items.Add("500 mW");
            this.txLevelCombo.Items.Add("398 mW");
            this.txLevelCombo.Items.Add("316 mW");
            this.txLevelCombo.Items.Add("251 mW");
            this.txLevelCombo.Items.Add("200 mW");
            this.txLevelCombo.Items.Add("158 mW");
            this.txLevelCombo.Items.Add("126 mW");
            this.txLevelCombo.Items.Add("100 mW");
            this.txLevelCombo.Items.Add("79 mW");
            this.txLevelCombo.Items.Add("63 mW");
            this.txLevelCombo.Items.Add("50 mW");
            this.txLevelCombo.Items.Add("40 mW");
            this.txLevelCombo.Items.Add("32 mW");
            this.txLevelCombo.Items.Add("25 mW");
            this.txLevelCombo.Items.Add("20 mW");
            this.txLevelCombo.Items.Add("16 mW");
            this.txLevelCombo.Items.Add("13 mW");
            this.txLevelCombo.Items.Add("10 mW");
            this.txLevelCombo.Items.Add("8 mW");
            this.txLevelCombo.Location = new System.Drawing.Point(109, 65);
            this.txLevelCombo.Name = "txLevelCombo";
            this.txLevelCombo.Size = new System.Drawing.Size(120, 23);
            this.txLevelCombo.TabIndex = 14;
            this.txLevelCombo.SelectedIndexChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // txmodLabel
            // 
            this.txmodLabel.Location = new System.Drawing.Point(3, 94);
            this.txmodLabel.Name = "txmodLabel";
            this.txmodLabel.Size = new System.Drawing.Size(100, 20);
            this.txmodLabel.Text = "TX Modulation";
            this.txmodLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // rxdecLabel
            // 
            this.rxdecLabel.Location = new System.Drawing.Point(3, 123);
            this.rxdecLabel.Name = "rxdecLabel";
            this.rxdecLabel.Size = new System.Drawing.Size(100, 20);
            this.rxdecLabel.Text = "RX Decoding";
            this.rxdecLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lfLabel
            // 
            this.lfLabel.Location = new System.Drawing.Point(3, 39);
            this.lfLabel.Name = "lfLabel";
            this.lfLabel.Size = new System.Drawing.Size(100, 20);
            this.lfLabel.Text = "Link Frequency";
            this.lfLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // regionLabel
            // 
            this.regionLabel.Location = new System.Drawing.Point(3, 10);
            this.regionLabel.Name = "regionLabel";
            this.regionLabel.Size = new System.Drawing.Size(100, 20);
            this.regionLabel.Text = "Region";
            this.regionLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txModCombo
            // 
            this.txModCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txModCombo.Items.Add("ASK");
            this.txModCombo.Items.Add("PR-ASK");
            this.txModCombo.Location = new System.Drawing.Point(109, 94);
            this.txModCombo.Name = "txModCombo";
            this.txModCombo.Size = new System.Drawing.Size(120, 23);
            this.txModCombo.TabIndex = 15;
            this.txModCombo.SelectedIndexChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // rxDecCombo
            // 
            this.rxDecCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rxDecCombo.Items.Add("FM-0");
            this.rxDecCombo.Items.Add("Miller-2");
            this.rxDecCombo.Items.Add("Miller-4");
            this.rxDecCombo.Items.Add("Miller-8");
            this.rxDecCombo.Location = new System.Drawing.Point(109, 123);
            this.rxDecCombo.Name = "rxDecCombo";
            this.rxDecCombo.Size = new System.Drawing.Size(120, 23);
            this.rxDecCombo.TabIndex = 16;
            this.rxDecCombo.SelectedIndexChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // lfCombo
            // 
            this.lfCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lfCombo.Items.Add("160 Khz");
            this.lfCombo.Items.Add("256 Khz");
            this.lfCombo.Items.Add("320 Khz");
            this.lfCombo.Location = new System.Drawing.Point(109, 36);
            this.lfCombo.Name = "lfCombo";
            this.lfCombo.Size = new System.Drawing.Size(120, 23);
            this.lfCombo.TabIndex = 13;
            this.lfCombo.SelectedIndexChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // regionCombo
            // 
            this.regionCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.regionCombo.Items.Add("0 - Europe");
            this.regionCombo.Items.Add("1 - North-America");
            this.regionCombo.Items.Add("2 - People\'s Republic of China, upper band");
            this.regionCombo.Items.Add("3 - Malaysia");
            this.regionCombo.Items.Add("4 - Brazil");
            this.regionCombo.Items.Add("5 - Australia");
            this.regionCombo.Items.Add("6 - New Zealand");
            this.regionCombo.Location = new System.Drawing.Point(109, 7);
            this.regionCombo.Name = "regionCombo";
            this.regionCombo.Size = new System.Drawing.Size(120, 23);
            this.regionCombo.TabIndex = 11;
            this.regionCombo.SelectedIndexChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // antennaTab
            // 
            this.antennaTab.Controls.Add(this.label4);
            this.antennaTab.Controls.Add(this.enTuneEvents_CheckBox);
            this.antennaTab.Controls.Add(this.label3);
            this.antennaTab.Controls.Add(this.autoTuneTreshold_UpDown);
            this.antennaTab.Controls.Add(this.autoTune_Label);
            this.antennaTab.Controls.Add(this.autoTune_ComboBox);
            this.antennaTab.Controls.Add(this.antennaLabel);
            this.antennaTab.Controls.Add(this.selectedAntenna);
            this.antennaTab.Location = new System.Drawing.Point(4, 25);
            this.antennaTab.Name = "antennaTab";
            this.antennaTab.Size = new System.Drawing.Size(232, 291);
            this.antennaTab.Text = "Antenna";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.Text = "Tune Events";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // enTuneEvents_CheckBox
            // 
            this.enTuneEvents_CheckBox.Location = new System.Drawing.Point(109, 110);
            this.enTuneEvents_CheckBox.Name = "enTuneEvents_CheckBox";
            this.enTuneEvents_CheckBox.Size = new System.Drawing.Size(120, 20);
            this.enTuneEvents_CheckBox.TabIndex = 28;
            this.enTuneEvents_CheckBox.Text = "Enable";
            this.enTuneEvents_CheckBox.CheckStateChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.Text = "Threshold";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // autoTuneTreshold_UpDown
            // 
            this.autoTuneTreshold_UpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.autoTuneTreshold_UpDown.Location = new System.Drawing.Point(109, 80);
            this.autoTuneTreshold_UpDown.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.autoTuneTreshold_UpDown.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            -2147483648});
            this.autoTuneTreshold_UpDown.Name = "autoTuneTreshold_UpDown";
            this.autoTuneTreshold_UpDown.Size = new System.Drawing.Size(120, 24);
            this.autoTuneTreshold_UpDown.TabIndex = 23;
            this.autoTuneTreshold_UpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.autoTuneTreshold_UpDown.ValueChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // autoTune_Label
            // 
            this.autoTune_Label.Location = new System.Drawing.Point(3, 54);
            this.autoTune_Label.Name = "autoTune_Label";
            this.autoTune_Label.Size = new System.Drawing.Size(100, 20);
            this.autoTune_Label.Text = "Autotune";
            this.autoTune_Label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // autoTune_ComboBox
            // 
            this.autoTune_ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.autoTune_ComboBox.Items.Add("Disabled");
            this.autoTune_ComboBox.Items.Add("Enable");
            this.autoTune_ComboBox.Items.Add("Enable with treshold");
            this.autoTune_ComboBox.Location = new System.Drawing.Point(109, 51);
            this.autoTune_ComboBox.Name = "autoTune_ComboBox";
            this.autoTune_ComboBox.Size = new System.Drawing.Size(120, 23);
            this.autoTune_ComboBox.TabIndex = 21;
            this.autoTune_ComboBox.SelectedIndexChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // antennaLabel
            // 
            this.antennaLabel.Location = new System.Drawing.Point(3, 13);
            this.antennaLabel.Name = "antennaLabel";
            this.antennaLabel.Size = new System.Drawing.Size(100, 20);
            this.antennaLabel.Text = "Antenna";
            this.antennaLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // selectedAntenna
            // 
            this.selectedAntenna.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedAntenna.Location = new System.Drawing.Point(109, 10);
            this.selectedAntenna.Name = "selectedAntenna";
            this.selectedAntenna.Size = new System.Drawing.Size(120, 23);
            this.selectedAntenna.TabIndex = 19;
            this.selectedAntenna.SelectedIndexChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // invTab
            // 
            this.invTab.Controls.Add(this.invEpcLenCombo);
            this.invTab.Controls.Add(this.label2);
            this.invTab.Controls.Add(this.periodCombo);
            this.invTab.Controls.Add(this.epcLenLabel);
            this.invTab.Controls.Add(this.targetLabel);
            this.invTab.Controls.Add(this.targetCombo);
            this.invTab.Controls.Add(this.roundsCombo);
            this.invTab.Controls.Add(this.sessionCombo);
            this.invTab.Controls.Add(this.qCombo);
            this.invTab.Controls.Add(this.roundsLabel);
            this.invTab.Controls.Add(this.sessionLabel);
            this.invTab.Controls.Add(this.qLabel);
            this.invTab.Location = new System.Drawing.Point(4, 25);
            this.invTab.Name = "invTab";
            this.invTab.Size = new System.Drawing.Size(232, 291);
            this.invTab.Text = "Inventory";
            // 
            // invEpcLenCombo
            // 
            this.invEpcLenCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.invEpcLenCombo.Items.Add("A");
            this.invEpcLenCombo.Items.Add("B");
            this.invEpcLenCombo.Items.Add("Auto Switch");
            this.invEpcLenCombo.Location = new System.Drawing.Point(109, 154);
            this.invEpcLenCombo.Name = "invEpcLenCombo";
            this.invEpcLenCombo.Size = new System.Drawing.Size(120, 23);
            this.invEpcLenCombo.TabIndex = 44;
            this.invEpcLenCombo.SelectedIndexChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "Power saving";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // periodCombo
            // 
            this.periodCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.periodCombo.Items.Add("A");
            this.periodCombo.Items.Add("B");
            this.periodCombo.Items.Add("Auto Switch");
            this.periodCombo.Location = new System.Drawing.Point(109, 125);
            this.periodCombo.Name = "periodCombo";
            this.periodCombo.Size = new System.Drawing.Size(120, 23);
            this.periodCombo.TabIndex = 42;
            this.periodCombo.SelectedIndexChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // epcLenLabel
            // 
            this.epcLenLabel.Location = new System.Drawing.Point(3, 157);
            this.epcLenLabel.Name = "epcLenLabel";
            this.epcLenLabel.Size = new System.Drawing.Size(100, 20);
            this.epcLenLabel.Text = "EPC Length";
            this.epcLenLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // targetLabel
            // 
            this.targetLabel.Location = new System.Drawing.Point(3, 99);
            this.targetLabel.Name = "targetLabel";
            this.targetLabel.Size = new System.Drawing.Size(100, 20);
            this.targetLabel.Text = "Target";
            this.targetLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // targetCombo
            // 
            this.targetCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.targetCombo.Items.Add("A");
            this.targetCombo.Items.Add("B");
            this.targetCombo.Items.Add("Auto Switch");
            this.targetCombo.Location = new System.Drawing.Point(109, 96);
            this.targetCombo.Name = "targetCombo";
            this.targetCombo.Size = new System.Drawing.Size(120, 23);
            this.targetCombo.TabIndex = 35;
            this.targetCombo.SelectedIndexChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // roundsCombo
            // 
            this.roundsCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.roundsCombo.Items.Add("AUTO");
            this.roundsCombo.Items.Add("1");
            this.roundsCombo.Items.Add("2");
            this.roundsCombo.Items.Add("3");
            this.roundsCombo.Items.Add("4");
            this.roundsCombo.Items.Add("5");
            this.roundsCombo.Items.Add("6");
            this.roundsCombo.Items.Add("7");
            this.roundsCombo.Items.Add("8");
            this.roundsCombo.Items.Add("9");
            this.roundsCombo.Items.Add("10");
            this.roundsCombo.Location = new System.Drawing.Point(109, 38);
            this.roundsCombo.Name = "roundsCombo";
            this.roundsCombo.Size = new System.Drawing.Size(120, 23);
            this.roundsCombo.TabIndex = 32;
            this.roundsCombo.SelectedIndexChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // sessionCombo
            // 
            this.sessionCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sessionCombo.Items.Add("0");
            this.sessionCombo.Items.Add("1");
            this.sessionCombo.Items.Add("2");
            this.sessionCombo.Items.Add("3");
            this.sessionCombo.Location = new System.Drawing.Point(109, 9);
            this.sessionCombo.Name = "sessionCombo";
            this.sessionCombo.Size = new System.Drawing.Size(120, 23);
            this.sessionCombo.TabIndex = 30;
            this.sessionCombo.SelectedIndexChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // qCombo
            // 
            this.qCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.qCombo.Items.Add("AUTO");
            this.qCombo.Items.Add("1");
            this.qCombo.Items.Add("2");
            this.qCombo.Items.Add("3");
            this.qCombo.Items.Add("4");
            this.qCombo.Items.Add("5");
            this.qCombo.Items.Add("6");
            this.qCombo.Items.Add("7");
            this.qCombo.Items.Add("8");
            this.qCombo.Items.Add("9");
            this.qCombo.Items.Add("10");
            this.qCombo.Items.Add("11");
            this.qCombo.Items.Add("12");
            this.qCombo.Items.Add("13");
            this.qCombo.Items.Add("14");
            this.qCombo.Items.Add("15");
            this.qCombo.Location = new System.Drawing.Point(109, 67);
            this.qCombo.Name = "qCombo";
            this.qCombo.Size = new System.Drawing.Size(120, 23);
            this.qCombo.TabIndex = 34;
            this.qCombo.SelectedIndexChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // roundsLabel
            // 
            this.roundsLabel.Location = new System.Drawing.Point(3, 41);
            this.roundsLabel.Name = "roundsLabel";
            this.roundsLabel.Size = new System.Drawing.Size(100, 20);
            this.roundsLabel.Text = "Rounds";
            this.roundsLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // sessionLabel
            // 
            this.sessionLabel.Location = new System.Drawing.Point(3, 12);
            this.sessionLabel.Name = "sessionLabel";
            this.sessionLabel.Size = new System.Drawing.Size(100, 20);
            this.sessionLabel.Text = "Session";
            this.sessionLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // qLabel
            // 
            this.qLabel.Location = new System.Drawing.Point(3, 70);
            this.qLabel.Name = "qLabel";
            this.qLabel.Size = new System.Drawing.Size(100, 20);
            this.qLabel.Text = "Q";
            this.qLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // filtTab
            // 
            this.filtTab.Controls.Add(this.filtGuide);
            this.filtTab.Controls.Add(this.maxFiltLabel);
            this.filtTab.Controls.Add(this.minFiltLabel);
            this.filtTab.Controls.Add(this.inventoryRssiMax);
            this.filtTab.Controls.Add(this.writeRssiMax);
            this.filtTab.Controls.Add(this.readRssiMax);
            this.filtTab.Controls.Add(this.inventoryRssiMin);
            this.filtTab.Controls.Add(this.writeRssiMin);
            this.filtTab.Controls.Add(this.invFiltLabel);
            this.filtTab.Controls.Add(this.writeFiltLabel);
            this.filtTab.Controls.Add(this.readRssiMin);
            this.filtTab.Controls.Add(this.readFiltLabel);
            this.filtTab.Controls.Add(this.rssiFiltLabel);
            this.filtTab.Location = new System.Drawing.Point(4, 25);
            this.filtTab.Name = "filtTab";
            this.filtTab.Size = new System.Drawing.Size(232, 291);
            this.filtTab.Text = "Filter";
            // 
            // filtGuide
            // 
            this.filtGuide.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.filtGuide.Location = new System.Drawing.Point(3, 140);
            this.filtGuide.Name = "filtGuide";
            this.filtGuide.Size = new System.Drawing.Size(226, 151);
            this.filtGuide.Text = "Use 0 to disable filtering. Typical RSSI range is between -80 and -40 dB.";
            // 
            // maxFiltLabel
            // 
            this.maxFiltLabel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.maxFiltLabel.Location = new System.Drawing.Point(147, 9);
            this.maxFiltLabel.Name = "maxFiltLabel";
            this.maxFiltLabel.Size = new System.Drawing.Size(60, 20);
            this.maxFiltLabel.Text = "MAX";
            this.maxFiltLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // minFiltLabel
            // 
            this.minFiltLabel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.minFiltLabel.Location = new System.Drawing.Point(81, 9);
            this.minFiltLabel.Name = "minFiltLabel";
            this.minFiltLabel.Size = new System.Drawing.Size(60, 20);
            this.minFiltLabel.Text = "MIN";
            this.minFiltLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // inventoryRssiMax
            // 
            this.inventoryRssiMax.Location = new System.Drawing.Point(147, 106);
            this.inventoryRssiMax.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.inventoryRssiMax.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
            this.inventoryRssiMax.Name = "inventoryRssiMax";
            this.inventoryRssiMax.Size = new System.Drawing.Size(60, 24);
            this.inventoryRssiMax.TabIndex = 38;
            this.inventoryRssiMax.ValueChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // writeRssiMax
            // 
            this.writeRssiMax.Location = new System.Drawing.Point(147, 69);
            this.writeRssiMax.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.writeRssiMax.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
            this.writeRssiMax.Name = "writeRssiMax";
            this.writeRssiMax.Size = new System.Drawing.Size(60, 24);
            this.writeRssiMax.TabIndex = 37;
            this.writeRssiMax.ValueChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // readRssiMax
            // 
            this.readRssiMax.Location = new System.Drawing.Point(147, 32);
            this.readRssiMax.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.readRssiMax.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
            this.readRssiMax.Name = "readRssiMax";
            this.readRssiMax.Size = new System.Drawing.Size(60, 24);
            this.readRssiMax.TabIndex = 36;
            this.readRssiMax.ValueChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // inventoryRssiMin
            // 
            this.inventoryRssiMin.Location = new System.Drawing.Point(81, 106);
            this.inventoryRssiMin.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.inventoryRssiMin.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
            this.inventoryRssiMin.Name = "inventoryRssiMin";
            this.inventoryRssiMin.Size = new System.Drawing.Size(60, 24);
            this.inventoryRssiMin.TabIndex = 35;
            this.inventoryRssiMin.ValueChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // writeRssiMin
            // 
            this.writeRssiMin.Location = new System.Drawing.Point(81, 69);
            this.writeRssiMin.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.writeRssiMin.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
            this.writeRssiMin.Name = "writeRssiMin";
            this.writeRssiMin.Size = new System.Drawing.Size(60, 24);
            this.writeRssiMin.TabIndex = 34;
            this.writeRssiMin.ValueChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // invFiltLabel
            // 
            this.invFiltLabel.Location = new System.Drawing.Point(3, 110);
            this.invFiltLabel.Name = "invFiltLabel";
            this.invFiltLabel.Size = new System.Drawing.Size(72, 20);
            this.invFiltLabel.Text = "Inventory";
            this.invFiltLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // writeFiltLabel
            // 
            this.writeFiltLabel.Location = new System.Drawing.Point(3, 73);
            this.writeFiltLabel.Name = "writeFiltLabel";
            this.writeFiltLabel.Size = new System.Drawing.Size(72, 20);
            this.writeFiltLabel.Text = "Write";
            this.writeFiltLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // readRssiMin
            // 
            this.readRssiMin.Location = new System.Drawing.Point(81, 32);
            this.readRssiMin.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.readRssiMin.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
            this.readRssiMin.Name = "readRssiMin";
            this.readRssiMin.Size = new System.Drawing.Size(60, 24);
            this.readRssiMin.TabIndex = 33;
            this.readRssiMin.ValueChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // readFiltLabel
            // 
            this.readFiltLabel.Location = new System.Drawing.Point(3, 36);
            this.readFiltLabel.Name = "readFiltLabel";
            this.readFiltLabel.Size = new System.Drawing.Size(72, 20);
            this.readFiltLabel.Text = "Read";
            this.readFiltLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // rssiFiltLabel
            // 
            this.rssiFiltLabel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.rssiFiltLabel.Location = new System.Drawing.Point(3, 9);
            this.rssiFiltLabel.Name = "rssiFiltLabel";
            this.rssiFiltLabel.Size = new System.Drawing.Size(91, 20);
            this.rssiFiltLabel.Text = "RSSI Filter";
            // 
            // miscTab
            // 
            this.miscTab.Controls.Add(this.label1);
            this.miscTab.Controls.Add(this.storeSetupBtn);
            this.miscTab.Location = new System.Drawing.Point(4, 25);
            this.miscTab.Name = "miscTab";
            this.miscTab.Size = new System.Drawing.Size(232, 291);
            this.miscTab.Text = "Misc";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 54);
            this.label1.Text = "Store current module full setup, exluding baudrate, to module\'s non-volatile memo" +
                "ry. ";
            // 
            // storeSetupBtn
            // 
            this.storeSetupBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.storeSetupBtn.Location = new System.Drawing.Point(3, 57);
            this.storeSetupBtn.Name = "storeSetupBtn";
            this.storeSetupBtn.Size = new System.Drawing.Size(225, 20);
            this.storeSetupBtn.TabIndex = 0;
            this.storeSetupBtn.Text = "Store Setup";
            this.storeSetupBtn.Click += new System.EventHandler(this.storeSetupBtn_Click);
            // 
            // antennaTuneTab
            // 
            this.antennaTuneTab.Controls.Add(this.nurTune);
            this.antennaTuneTab.Location = new System.Drawing.Point(4, 25);
            this.antennaTuneTab.Name = "antennaTuneTab";
            this.antennaTuneTab.Size = new System.Drawing.Size(232, 291);
            this.antennaTuneTab.Text = "Antenna Tune";
            // 
            // nurTune
            // 
            this.nurTune.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nurTune.Location = new System.Drawing.Point(0, 0);
            this.nurTune.Name = "nurTune";
            this.nurTune.Size = new System.Drawing.Size(232, 291);
            this.nurTune.TabIndex = 0;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl1);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(240, 320);
            this.tabControl1.ResumeLayout(false);
            this.rfTab.ResumeLayout(false);
            this.antennaTab.ResumeLayout(false);
            this.invTab.ResumeLayout(false);
            this.filtTab.ResumeLayout(false);
            this.miscTab.ResumeLayout(false);
            this.antennaTuneTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage rfTab;
        private System.Windows.Forms.TabPage invTab;
        private System.Windows.Forms.Label rxSensitivityLabel;
        private System.Windows.Forms.ComboBox rxSensitivity_ComboBox;
        private System.Windows.Forms.Label txlevelLabel;
        private System.Windows.Forms.ComboBox txLevelCombo;
        private System.Windows.Forms.Label txmodLabel;
        private System.Windows.Forms.Label rxdecLabel;
        private System.Windows.Forms.Label lfLabel;
        private System.Windows.Forms.Label regionLabel;
        private System.Windows.Forms.ComboBox txModCombo;
        private System.Windows.Forms.ComboBox rxDecCombo;
        private System.Windows.Forms.ComboBox lfCombo;
        private System.Windows.Forms.ComboBox regionCombo;
        private System.Windows.Forms.Label epcLenLabel;
        private System.Windows.Forms.Label targetLabel;
        private System.Windows.Forms.ComboBox targetCombo;
        private System.Windows.Forms.ComboBox roundsCombo;
        private System.Windows.Forms.ComboBox sessionCombo;
        private System.Windows.Forms.ComboBox qCombo;
        private System.Windows.Forms.Label roundsLabel;
        private System.Windows.Forms.Label sessionLabel;
        private System.Windows.Forms.Label qLabel;
        private System.Windows.Forms.TabPage filtTab;
        private System.Windows.Forms.Label filtGuide;
        private System.Windows.Forms.Label maxFiltLabel;
        private System.Windows.Forms.Label minFiltLabel;
        private System.Windows.Forms.NumericUpDown inventoryRssiMax;
        private System.Windows.Forms.NumericUpDown writeRssiMax;
        private System.Windows.Forms.NumericUpDown readRssiMax;
        private System.Windows.Forms.NumericUpDown inventoryRssiMin;
        private System.Windows.Forms.NumericUpDown writeRssiMin;
        private System.Windows.Forms.Label invFiltLabel;
        private System.Windows.Forms.Label writeFiltLabel;
        private System.Windows.Forms.NumericUpDown readRssiMin;
        private System.Windows.Forms.Label readFiltLabel;
        private System.Windows.Forms.Label rssiFiltLabel;
        private System.Windows.Forms.TabPage miscTab;
        private System.Windows.Forms.Button storeSetupBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox periodCombo;
        private System.Windows.Forms.ComboBox invEpcLenCombo;
        private System.Windows.Forms.TabPage antennaTuneTab;
        private AntennaTuner nurTune;
        private System.Windows.Forms.TabPage antennaTab;
        private System.Windows.Forms.Label autoTune_Label;
        private System.Windows.Forms.ComboBox autoTune_ComboBox;
        private System.Windows.Forms.Label antennaLabel;
        private System.Windows.Forms.ComboBox selectedAntenna;
        private System.Windows.Forms.NumericUpDown autoTuneTreshold_UpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox enTuneEvents_CheckBox;
        private System.Windows.Forms.Label label3;
    }
}
