namespace EM4325Test
{
	partial class MainForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.AutoConnChk = new System.Windows.Forms.CheckBox();
			this.ULogChk = new System.Windows.Forms.CheckBox();
			this.VerbChk = new System.Windows.Forms.CheckBox();
			this.QuitBtn = new System.Windows.Forms.Button();
			this.ClearBtn = new System.Windows.Forms.Button();
			this.Log = new System.Windows.Forms.ListBox();
			this.UIDBtn = new System.Windows.Forms.Button();
			this.GetTagsBtn = new System.Windows.Forms.Button();
			this.AppTabs = new System.Windows.Forms.TabControl();
			this.ReaderTab = new System.Windows.Forms.TabPage();
			this.InvRoundsSel = new System.Windows.Forms.ComboBox();
			this.physAntListView = new System.Windows.Forms.ListView();
			this.columnHeader_Antenna = new System.Windows.Forms.ColumnHeader();
			this.InvTargetSel = new System.Windows.Forms.ComboBox();
			this.InvSessionSel = new System.Windows.Forms.ComboBox();
			this.InvQSel = new System.Windows.Forms.ComboBox();
			this.ModulationSel = new System.Windows.Forms.ComboBox();
			this.TxLevelSel = new System.Windows.Forms.ComboBox();
			this.EMTab = new System.Windows.Forms.TabPage();
			this.AppReadChk = new System.Windows.Forms.CheckBox();
			this.UserMemType = new System.Windows.Forms.ComboBox();
			this.BtnReadUSer = new System.Windows.Forms.Button();
			this.MakeSimpleBtn = new System.Windows.Forms.Button();
			this.BAPDisBtn = new System.Windows.Forms.Button();
			this.BAPEnBtn = new System.Windows.Forms.Button();
			this.GetUTCBtn = new System.Windows.Forms.Button();
			this.BAPStatBtn = new System.Windows.Forms.Button();
			this.tabSensor = new System.Windows.Forms.TabPage();
			this.UidWithSensor = new System.Windows.Forms.CheckBox();
			this.ReadCfgBtn = new System.Windows.Forms.Button();
			this.RstAlarmsBtn = new System.Windows.Forms.Button();
			this.GetTempBtn = new System.Windows.Forms.Button();
			this.SensorBtn = new System.Windows.Forms.Button();
			this.BlockCfgChk = new System.Windows.Forms.CheckBox();
			this.StopBtn = new System.Windows.Forms.Button();
			this.CustStartBtn = new System.Windows.Forms.Button();
			this.SimpleStartBtn = new System.Windows.Forms.Button();
			this.ResetToABtn = new System.Windows.Forms.Button();
			this.TagLabel = new System.Windows.Forms.Label();
			this.ErrLogChk = new System.Windows.Forms.CheckBox();
			this.AutoScanChk = new System.Windows.Forms.CheckBox();
			this.TestTagBtn = new System.Windows.Forms.Button();
			this.TargetResetChk = new System.Windows.Forms.CheckBox();
			this.TagListView = new System.Windows.Forms.ListView();
			this.columnHeader_EPC = new System.Windows.Forms.ColumnHeader();
			this.columnHeader_RSSI = new System.Windows.Forms.ColumnHeader();
			this.columnHeader_AntID = new System.Windows.Forms.ColumnHeader();
			this.AppTabs.SuspendLayout();
			this.ReaderTab.SuspendLayout();
			this.EMTab.SuspendLayout();
			this.tabSensor.SuspendLayout();
			this.SuspendLayout();
			// 
			// AutoConnChk
			// 
			this.AutoConnChk.AutoSize = true;
			this.AutoConnChk.Location = new System.Drawing.Point(384, 593);
			this.AutoConnChk.Name = "AutoConnChk";
			this.AutoConnChk.Size = new System.Drawing.Size(111, 17);
			this.AutoConnChk.TabIndex = 0;
			this.AutoConnChk.Text = "USB autoconnect";
			this.AutoConnChk.UseVisualStyleBackColor = true;
			this.AutoConnChk.Click += new System.EventHandler(this.AutoConnChk_Click);
			// 
			// ULogChk
			// 
			this.ULogChk.AutoSize = true;
			this.ULogChk.Location = new System.Drawing.Point(100, 593);
			this.ULogChk.Name = "ULogChk";
			this.ULogChk.Size = new System.Drawing.Size(65, 17);
			this.ULogChk.TabIndex = 1;
			this.ULogChk.Text = "User log";
			this.ULogChk.UseVisualStyleBackColor = true;
			this.ULogChk.Click += new System.EventHandler(this.ULogChk_Click);
			// 
			// VerbChk
			// 
			this.VerbChk.AutoSize = true;
			this.VerbChk.Location = new System.Drawing.Point(12, 593);
			this.VerbChk.Name = "VerbChk";
			this.VerbChk.Size = new System.Drawing.Size(82, 17);
			this.VerbChk.TabIndex = 2;
			this.VerbChk.Text = "Verbose log";
			this.VerbChk.UseVisualStyleBackColor = true;
			this.VerbChk.Click += new System.EventHandler(this.VerbChk_Click);
			// 
			// QuitBtn
			// 
			this.QuitBtn.Location = new System.Drawing.Point(581, 588);
			this.QuitBtn.Name = "QuitBtn";
			this.QuitBtn.Size = new System.Drawing.Size(74, 27);
			this.QuitBtn.TabIndex = 3;
			this.QuitBtn.Text = "Quit";
			this.QuitBtn.UseVisualStyleBackColor = true;
			this.QuitBtn.Click += new System.EventHandler(this.QuitBtn_Click);
			// 
			// ClearBtn
			// 
			this.ClearBtn.Location = new System.Drawing.Point(501, 588);
			this.ClearBtn.Name = "ClearBtn";
			this.ClearBtn.Size = new System.Drawing.Size(74, 27);
			this.ClearBtn.TabIndex = 5;
			this.ClearBtn.Text = "Clear";
			this.ClearBtn.UseVisualStyleBackColor = true;
			this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
			// 
			// Log
			// 
			this.Log.FormattingEnabled = true;
			this.Log.Location = new System.Drawing.Point(12, 255);
			this.Log.Name = "Log";
			this.Log.Size = new System.Drawing.Size(643, 316);
			this.Log.TabIndex = 6;
			// 
			// UIDBtn
			// 
			this.UIDBtn.Enabled = false;
			this.UIDBtn.Location = new System.Drawing.Point(187, 6);
			this.UIDBtn.Name = "UIDBtn";
			this.UIDBtn.Size = new System.Drawing.Size(86, 27);
			this.UIDBtn.TabIndex = 7;
			this.UIDBtn.Text = "Get UID";
			this.UIDBtn.UseVisualStyleBackColor = true;
			this.UIDBtn.Click += new System.EventHandler(this.UIDBtn_Click);
			// 
			// GetTagsBtn
			// 
			this.GetTagsBtn.Enabled = false;
			this.GetTagsBtn.Location = new System.Drawing.Point(287, 136);
			this.GetTagsBtn.Name = "GetTagsBtn";
			this.GetTagsBtn.Size = new System.Drawing.Size(342, 27);
			this.GetTagsBtn.TabIndex = 8;
			this.GetTagsBtn.Text = "List tags";
			this.GetTagsBtn.UseVisualStyleBackColor = true;
			this.GetTagsBtn.Click += new System.EventHandler(this.GetTagsBtn_Click);
			// 
			// AppTabs
			// 
			this.AppTabs.Controls.Add(this.ReaderTab);
			this.AppTabs.Controls.Add(this.EMTab);
			this.AppTabs.Controls.Add(this.tabSensor);
			this.AppTabs.Location = new System.Drawing.Point(12, 12);
			this.AppTabs.Name = "AppTabs";
			this.AppTabs.SelectedIndex = 0;
			this.AppTabs.Size = new System.Drawing.Size(643, 199);
			this.AppTabs.TabIndex = 10;
			// 
			// ReaderTab
			// 
			this.ReaderTab.Controls.Add(this.TagListView);
			this.ReaderTab.Controls.Add(this.InvRoundsSel);
			this.ReaderTab.Controls.Add(this.physAntListView);
			this.ReaderTab.Controls.Add(this.InvTargetSel);
			this.ReaderTab.Controls.Add(this.InvSessionSel);
			this.ReaderTab.Controls.Add(this.InvQSel);
			this.ReaderTab.Controls.Add(this.ModulationSel);
			this.ReaderTab.Controls.Add(this.TxLevelSel);
			this.ReaderTab.Controls.Add(this.GetTagsBtn);
			this.ReaderTab.Location = new System.Drawing.Point(4, 22);
			this.ReaderTab.Name = "ReaderTab";
			this.ReaderTab.Padding = new System.Windows.Forms.Padding(3);
			this.ReaderTab.Size = new System.Drawing.Size(635, 173);
			this.ReaderTab.TabIndex = 0;
			this.ReaderTab.Text = "Reader";
			this.ReaderTab.UseVisualStyleBackColor = true;
			this.ReaderTab.Enter += new System.EventHandler(this.ReaderTab_Enter);
			// 
			// InvRoundsSel
			// 
			this.InvRoundsSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.InvRoundsSel.FormattingEnabled = true;
			this.InvRoundsSel.Items.AddRange(new object[] {
            "Rounds 0 - (Auto)",
            "Rounds 1",
            "Rounds 2",
            "Rounds 3",
            "Rounds 4",
            "Rounds 5",
            "Rounds 6",
            "Rounds 7",
            "Rounds 8",
            "Rounds 9",
            "Rounds 10"});
			this.InvRoundsSel.Location = new System.Drawing.Point(6, 87);
			this.InvRoundsSel.Name = "InvRoundsSel";
			this.InvRoundsSel.Size = new System.Drawing.Size(124, 21);
			this.InvRoundsSel.TabIndex = 22;
			this.InvRoundsSel.SelectedIndexChanged += new System.EventHandler(this.ModuleSetup_SelectedIndexChanged);
			// 
			// physAntListView
			// 
			this.physAntListView.CheckBoxes = true;
			this.physAntListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_Antenna});
			this.physAntListView.Location = new System.Drawing.Point(136, 6);
			this.physAntListView.Name = "physAntListView";
			this.physAntListView.Size = new System.Drawing.Size(145, 156);
			this.physAntListView.TabIndex = 21;
			this.physAntListView.UseCompatibleStateImageBehavior = false;
			this.physAntListView.View = System.Windows.Forms.View.Details;
			this.physAntListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.physAntListView_ItemChecked);
			// 
			// columnHeader_Antenna
			// 
			this.columnHeader_Antenna.Text = "Enabled Antennas";
			this.columnHeader_Antenna.Width = 141;
			// 
			// InvTargetSel
			// 
			this.InvTargetSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.InvTargetSel.FormattingEnabled = true;
			this.InvTargetSel.Items.AddRange(new object[] {
            "Target A",
            "Target B",
            "Dual Target"});
			this.InvTargetSel.Location = new System.Drawing.Point(6, 141);
			this.InvTargetSel.Name = "InvTargetSel";
			this.InvTargetSel.Size = new System.Drawing.Size(124, 21);
			this.InvTargetSel.TabIndex = 20;
			this.InvTargetSel.SelectedIndexChanged += new System.EventHandler(this.ModuleSetup_SelectedIndexChanged);
			// 
			// InvSessionSel
			// 
			this.InvSessionSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.InvSessionSel.FormattingEnabled = true;
			this.InvSessionSel.Items.AddRange(new object[] {
            "Session 0",
            "Session 1",
            "Session 2",
            "Session 3"});
			this.InvSessionSel.Location = new System.Drawing.Point(6, 114);
			this.InvSessionSel.MaxDropDownItems = 100;
			this.InvSessionSel.Name = "InvSessionSel";
			this.InvSessionSel.Size = new System.Drawing.Size(124, 21);
			this.InvSessionSel.TabIndex = 19;
			this.InvSessionSel.SelectedIndexChanged += new System.EventHandler(this.ModuleSetup_SelectedIndexChanged);
			// 
			// InvQSel
			// 
			this.InvQSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.InvQSel.FormattingEnabled = true;
			this.InvQSel.Items.AddRange(new object[] {
            "Q 0 - (Auto)",
            "Q 1",
            "Q 2",
            "Q 3",
            "Q 4",
            "Q 5",
            "Q 6",
            "Q 7",
            "Q 8",
            "Q 9",
            "Q 10",
            "Q 11",
            "Q 12",
            "Q 13",
            "Q 14",
            "Q 15"});
			this.InvQSel.Location = new System.Drawing.Point(6, 60);
			this.InvQSel.Name = "InvQSel";
			this.InvQSel.Size = new System.Drawing.Size(124, 21);
			this.InvQSel.TabIndex = 17;
			this.InvQSel.SelectedIndexChanged += new System.EventHandler(this.ModuleSetup_SelectedIndexChanged);
			// 
			// ModulationSel
			// 
			this.ModulationSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ModulationSel.FormattingEnabled = true;
			this.ModulationSel.Items.AddRange(new object[] {
            "ASK modulation",
            "PR-ASK modulation"});
			this.ModulationSel.Location = new System.Drawing.Point(6, 33);
			this.ModulationSel.Name = "ModulationSel";
			this.ModulationSel.Size = new System.Drawing.Size(124, 21);
			this.ModulationSel.TabIndex = 15;
			this.ModulationSel.SelectedIndexChanged += new System.EventHandler(this.ModuleSetup_SelectedIndexChanged);
			// 
			// TxLevelSel
			// 
			this.TxLevelSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.TxLevelSel.FormattingEnabled = true;
			this.TxLevelSel.Location = new System.Drawing.Point(6, 6);
			this.TxLevelSel.Name = "TxLevelSel";
			this.TxLevelSel.Size = new System.Drawing.Size(124, 21);
			this.TxLevelSel.TabIndex = 10;
			this.TxLevelSel.SelectedIndexChanged += new System.EventHandler(this.ModuleSetup_SelectedIndexChanged);
			// 
			// EMTab
			// 
			this.EMTab.Controls.Add(this.AppReadChk);
			this.EMTab.Controls.Add(this.UserMemType);
			this.EMTab.Controls.Add(this.BtnReadUSer);
			this.EMTab.Controls.Add(this.MakeSimpleBtn);
			this.EMTab.Controls.Add(this.BAPDisBtn);
			this.EMTab.Controls.Add(this.BAPEnBtn);
			this.EMTab.Controls.Add(this.GetUTCBtn);
			this.EMTab.Controls.Add(this.BAPStatBtn);
			this.EMTab.Controls.Add(this.UIDBtn);
			this.EMTab.Location = new System.Drawing.Point(4, 22);
			this.EMTab.Name = "EMTab";
			this.EMTab.Padding = new System.Windows.Forms.Padding(3);
			this.EMTab.Size = new System.Drawing.Size(635, 173);
			this.EMTab.TabIndex = 1;
			this.EMTab.Text = "EM4325";
			this.EMTab.UseVisualStyleBackColor = true;
			// 
			// AppReadChk
			// 
			this.AppReadChk.AutoSize = true;
			this.AppReadChk.Location = new System.Drawing.Point(279, 146);
			this.AppReadChk.Name = "AppReadChk";
			this.AppReadChk.Size = new System.Drawing.Size(129, 17);
			this.AppReadChk.TabIndex = 21;
			this.AppReadChk.Text = "Read from application";
			this.AppReadChk.UseVisualStyleBackColor = true;
			// 
			// UserMemType
			// 
			this.UserMemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.UserMemType.FormattingEnabled = true;
			this.UserMemType.Items.AddRange(new object[] {
            "Read as bytes",
            "Read as unsigned 16-bit",
            "Read as unsigned 32-bit"});
			this.UserMemType.Location = new System.Drawing.Point(95, 144);
			this.UserMemType.Name = "UserMemType";
			this.UserMemType.Size = new System.Drawing.Size(166, 21);
			this.UserMemType.TabIndex = 20;
			// 
			// BtnReadUSer
			// 
			this.BtnReadUSer.Enabled = false;
			this.BtnReadUSer.Location = new System.Drawing.Point(6, 140);
			this.BtnReadUSer.Name = "BtnReadUSer";
			this.BtnReadUSer.Size = new System.Drawing.Size(86, 27);
			this.BtnReadUSer.TabIndex = 19;
			this.BtnReadUSer.Text = "Read user";
			this.BtnReadUSer.UseVisualStyleBackColor = true;
			this.BtnReadUSer.Click += new System.EventHandler(this.BtnReadUSer_Click);
			// 
			// MakeSimpleBtn
			// 
			this.MakeSimpleBtn.Enabled = false;
			this.MakeSimpleBtn.Location = new System.Drawing.Point(406, 6);
			this.MakeSimpleBtn.Name = "MakeSimpleBtn";
			this.MakeSimpleBtn.Size = new System.Drawing.Size(113, 27);
			this.MakeSimpleBtn.TabIndex = 18;
			this.MakeSimpleBtn.Text = "Make simple sensor";
			this.MakeSimpleBtn.UseVisualStyleBackColor = true;
			this.MakeSimpleBtn.Click += new System.EventHandler(this.MakeSimpleBtn_Click);
			// 
			// BAPDisBtn
			// 
			this.BAPDisBtn.Enabled = false;
			this.BAPDisBtn.Location = new System.Drawing.Point(543, 39);
			this.BAPDisBtn.Name = "BAPDisBtn";
			this.BAPDisBtn.Size = new System.Drawing.Size(86, 27);
			this.BAPDisBtn.TabIndex = 15;
			this.BAPDisBtn.Text = "Turn BA off";
			this.BAPDisBtn.UseVisualStyleBackColor = true;
			this.BAPDisBtn.Click += new System.EventHandler(this.BAPDisBtn_Click);
			// 
			// BAPEnBtn
			// 
			this.BAPEnBtn.Enabled = false;
			this.BAPEnBtn.Location = new System.Drawing.Point(543, 6);
			this.BAPEnBtn.Name = "BAPEnBtn";
			this.BAPEnBtn.Size = new System.Drawing.Size(86, 27);
			this.BAPEnBtn.TabIndex = 14;
			this.BAPEnBtn.Text = "Turn BA on";
			this.BAPEnBtn.UseVisualStyleBackColor = true;
			this.BAPEnBtn.Click += new System.EventHandler(this.BAPEnBtn_Click);
			// 
			// GetUTCBtn
			// 
			this.GetUTCBtn.Enabled = false;
			this.GetUTCBtn.Location = new System.Drawing.Point(95, 6);
			this.GetUTCBtn.Name = "GetUTCBtn";
			this.GetUTCBtn.Size = new System.Drawing.Size(86, 27);
			this.GetUTCBtn.TabIndex = 10;
			this.GetUTCBtn.Text = "Get UTC";
			this.GetUTCBtn.UseVisualStyleBackColor = true;
			this.GetUTCBtn.Click += new System.EventHandler(this.GetUTCBtn_Click);
			// 
			// BAPStatBtn
			// 
			this.BAPStatBtn.Enabled = false;
			this.BAPStatBtn.Location = new System.Drawing.Point(3, 6);
			this.BAPStatBtn.Name = "BAPStatBtn";
			this.BAPStatBtn.Size = new System.Drawing.Size(86, 27);
			this.BAPStatBtn.TabIndex = 9;
			this.BAPStatBtn.Text = "BAP status";
			this.BAPStatBtn.UseVisualStyleBackColor = true;
			this.BAPStatBtn.Click += new System.EventHandler(this.BAPStatBtn_Click);
			// 
			// tabSensor
			// 
			this.tabSensor.Controls.Add(this.UidWithSensor);
			this.tabSensor.Controls.Add(this.ReadCfgBtn);
			this.tabSensor.Controls.Add(this.RstAlarmsBtn);
			this.tabSensor.Controls.Add(this.GetTempBtn);
			this.tabSensor.Controls.Add(this.SensorBtn);
			this.tabSensor.Controls.Add(this.BlockCfgChk);
			this.tabSensor.Controls.Add(this.StopBtn);
			this.tabSensor.Controls.Add(this.CustStartBtn);
			this.tabSensor.Controls.Add(this.SimpleStartBtn);
			this.tabSensor.Location = new System.Drawing.Point(4, 22);
			this.tabSensor.Name = "tabSensor";
			this.tabSensor.Size = new System.Drawing.Size(635, 173);
			this.tabSensor.TabIndex = 2;
			this.tabSensor.Text = "Sensor";
			this.tabSensor.UseVisualStyleBackColor = true;
			// 
			// UidWithSensor
			// 
			this.UidWithSensor.AutoSize = true;
			this.UidWithSensor.Location = new System.Drawing.Point(199, 12);
			this.UidWithSensor.Name = "UidWithSensor";
			this.UidWithSensor.Size = new System.Drawing.Size(145, 17);
			this.UidWithSensor.TabIndex = 25;
			this.UidWithSensor.Text = "Get UID with sensor data";
			this.UidWithSensor.UseVisualStyleBackColor = true;
			// 
			// ReadCfgBtn
			// 
			this.ReadCfgBtn.Enabled = false;
			this.ReadCfgBtn.Location = new System.Drawing.Point(6, 137);
			this.ReadCfgBtn.Name = "ReadCfgBtn";
			this.ReadCfgBtn.Size = new System.Drawing.Size(138, 27);
			this.ReadCfgBtn.TabIndex = 24;
			this.ReadCfgBtn.Text = "Read configuration";
			this.ReadCfgBtn.UseVisualStyleBackColor = true;
			this.ReadCfgBtn.Click += new System.EventHandler(this.ReadCfgBtn_Click);
			// 
			// RstAlarmsBtn
			// 
			this.RstAlarmsBtn.Enabled = false;
			this.RstAlarmsBtn.Location = new System.Drawing.Point(6, 6);
			this.RstAlarmsBtn.Name = "RstAlarmsBtn";
			this.RstAlarmsBtn.Size = new System.Drawing.Size(86, 27);
			this.RstAlarmsBtn.TabIndex = 23;
			this.RstAlarmsBtn.Text = "Reset alarms";
			this.RstAlarmsBtn.UseVisualStyleBackColor = true;
			this.RstAlarmsBtn.Click += new System.EventHandler(this.RstAlarmsBtn_Click);
			// 
			// GetTempBtn
			// 
			this.GetTempBtn.Enabled = false;
			this.GetTempBtn.Location = new System.Drawing.Point(6, 39);
			this.GetTempBtn.Name = "GetTempBtn";
			this.GetTempBtn.Size = new System.Drawing.Size(86, 27);
			this.GetTempBtn.TabIndex = 22;
			this.GetTempBtn.Text = "Temperature";
			this.GetTempBtn.UseVisualStyleBackColor = true;
			this.GetTempBtn.Click += new System.EventHandler(this.GetTempBtn_Click);
			// 
			// SensorBtn
			// 
			this.SensorBtn.Enabled = false;
			this.SensorBtn.Location = new System.Drawing.Point(98, 6);
			this.SensorBtn.Name = "SensorBtn";
			this.SensorBtn.Size = new System.Drawing.Size(86, 27);
			this.SensorBtn.TabIndex = 21;
			this.SensorBtn.Text = "Get sensor";
			this.SensorBtn.UseVisualStyleBackColor = true;
			this.SensorBtn.Click += new System.EventHandler(this.SensorBtn_Click);
			// 
			// BlockCfgChk
			// 
			this.BlockCfgChk.AutoSize = true;
			this.BlockCfgChk.Location = new System.Drawing.Point(318, 137);
			this.BlockCfgChk.Name = "BlockCfgChk";
			this.BlockCfgChk.Size = new System.Drawing.Size(148, 17);
			this.BlockCfgChk.TabIndex = 20;
			this.BlockCfgChk.Text = "Configure with BlockWrite";
			this.BlockCfgChk.UseVisualStyleBackColor = true;
			// 
			// StopBtn
			// 
			this.StopBtn.Enabled = false;
			this.StopBtn.Location = new System.Drawing.Point(485, 13);
			this.StopBtn.Name = "StopBtn";
			this.StopBtn.Size = new System.Drawing.Size(138, 27);
			this.StopBtn.TabIndex = 19;
			this.StopBtn.Text = "Stop all";
			this.StopBtn.UseVisualStyleBackColor = true;
			this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
			// 
			// CustStartBtn
			// 
			this.CustStartBtn.Enabled = false;
			this.CustStartBtn.Location = new System.Drawing.Point(485, 90);
			this.CustStartBtn.Name = "CustStartBtn";
			this.CustStartBtn.Size = new System.Drawing.Size(138, 27);
			this.CustStartBtn.TabIndex = 18;
			this.CustStartBtn.Text = "Start custom";
			this.CustStartBtn.UseVisualStyleBackColor = true;
			this.CustStartBtn.Click += new System.EventHandler(this.CustStartBtn_Click);
			// 
			// SimpleStartBtn
			// 
			this.SimpleStartBtn.Enabled = false;
			this.SimpleStartBtn.Location = new System.Drawing.Point(485, 132);
			this.SimpleStartBtn.Name = "SimpleStartBtn";
			this.SimpleStartBtn.Size = new System.Drawing.Size(138, 27);
			this.SimpleStartBtn.TabIndex = 17;
			this.SimpleStartBtn.Text = "Start simple";
			this.SimpleStartBtn.UseVisualStyleBackColor = true;
			// 
			// ResetToABtn
			// 
			this.ResetToABtn.Enabled = false;
			this.ResetToABtn.Location = new System.Drawing.Point(114, 222);
			this.ResetToABtn.Name = "ResetToABtn";
			this.ResetToABtn.Size = new System.Drawing.Size(90, 27);
			this.ResetToABtn.TabIndex = 16;
			this.ResetToABtn.Text = "Reset to A";
			this.ResetToABtn.UseVisualStyleBackColor = true;
			this.ResetToABtn.Click += new System.EventHandler(this.ResetToABtn_Click);
			// 
			// TagLabel
			// 
			this.TagLabel.Location = new System.Drawing.Point(433, 223);
			this.TagLabel.Name = "TagLabel";
			this.TagLabel.Size = new System.Drawing.Size(222, 23);
			this.TagLabel.TabIndex = 10;
			this.TagLabel.Text = "---";
			this.TagLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ErrLogChk
			// 
			this.ErrLogChk.AutoSize = true;
			this.ErrLogChk.Location = new System.Drawing.Point(171, 593);
			this.ErrLogChk.Name = "ErrLogChk";
			this.ErrLogChk.Size = new System.Drawing.Size(65, 17);
			this.ErrLogChk.TabIndex = 11;
			this.ErrLogChk.Text = "Error log";
			this.ErrLogChk.UseVisualStyleBackColor = true;
			this.ErrLogChk.Click += new System.EventHandler(this.ErrLogChk_Click);
			// 
			// AutoScanChk
			// 
			this.AutoScanChk.AutoSize = true;
			this.AutoScanChk.Checked = true;
			this.AutoScanChk.CheckState = System.Windows.Forms.CheckState.Checked;
			this.AutoScanChk.Location = new System.Drawing.Point(289, 593);
			this.AutoScanChk.Name = "AutoScanChk";
			this.AutoScanChk.Size = new System.Drawing.Size(74, 17);
			this.AutoScanChk.TabIndex = 12;
			this.AutoScanChk.Text = "Auto scan";
			this.AutoScanChk.UseVisualStyleBackColor = true;
			// 
			// TestTagBtn
			// 
			this.TestTagBtn.Enabled = false;
			this.TestTagBtn.Location = new System.Drawing.Point(12, 222);
			this.TestTagBtn.Name = "TestTagBtn";
			this.TestTagBtn.Size = new System.Drawing.Size(96, 27);
			this.TestTagBtn.TabIndex = 15;
			this.TestTagBtn.Text = "Test read";
			this.TestTagBtn.UseVisualStyleBackColor = true;
			this.TestTagBtn.Click += new System.EventHandler(this.TestTagBtn_Click);
			// 
			// TargetResetChk
			// 
			this.TargetResetChk.AutoSize = true;
			this.TargetResetChk.Location = new System.Drawing.Point(221, 227);
			this.TargetResetChk.Name = "TargetResetChk";
			this.TargetResetChk.Size = new System.Drawing.Size(129, 17);
			this.TargetResetChk.TabIndex = 21;
			this.TargetResetChk.Text = "Automatic target reset";
			this.TargetResetChk.UseVisualStyleBackColor = true;
			this.TargetResetChk.Click += new System.EventHandler(this.TargetResetChk_Click);
			// 
			// TagListView
			// 
			this.TagListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_EPC,
            this.columnHeader_RSSI,
            this.columnHeader_AntID});
			this.TagListView.FullRowSelect = true;
			this.TagListView.Location = new System.Drawing.Point(287, 6);
			this.TagListView.Name = "TagListView";
			this.TagListView.Size = new System.Drawing.Size(342, 124);
			this.TagListView.TabIndex = 23;
			this.TagListView.UseCompatibleStateImageBehavior = false;
			this.TagListView.View = System.Windows.Forms.View.Details;
			this.TagListView.SelectedIndexChanged += new System.EventHandler(this.TagListView_SelectedIndexChanged);
			// 
			// columnHeader_EPC
			// 
			this.columnHeader_EPC.Text = "EPC";
			// 
			// columnHeader_RSSI
			// 
			this.columnHeader_RSSI.Text = "RSSI";
			// 
			// columnHeader_AntID
			// 
			this.columnHeader_AntID.Text = "Antenna";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(667, 625);
			this.ControlBox = false;
			this.Controls.Add(this.TargetResetChk);
			this.Controls.Add(this.TestTagBtn);
			this.Controls.Add(this.AutoScanChk);
			this.Controls.Add(this.ErrLogChk);
			this.Controls.Add(this.TagLabel);
			this.Controls.Add(this.ResetToABtn);
			this.Controls.Add(this.AppTabs);
			this.Controls.Add(this.Log);
			this.Controls.Add(this.ClearBtn);
			this.Controls.Add(this.QuitBtn);
			this.Controls.Add(this.VerbChk);
			this.Controls.Add(this.ULogChk);
			this.Controls.Add(this.AutoConnChk);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "MainForm";
			this.Text = "EM4325 Test";
			this.AppTabs.ResumeLayout(false);
			this.ReaderTab.ResumeLayout(false);
			this.EMTab.ResumeLayout(false);
			this.EMTab.PerformLayout();
			this.tabSensor.ResumeLayout(false);
			this.tabSensor.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox AutoConnChk;
		private System.Windows.Forms.CheckBox ULogChk;
		private System.Windows.Forms.CheckBox VerbChk;
		private System.Windows.Forms.Button QuitBtn;
		private System.Windows.Forms.Button ClearBtn;
		private System.Windows.Forms.ListBox Log;
		private System.Windows.Forms.Button UIDBtn;
		private System.Windows.Forms.Button GetTagsBtn;
		private System.Windows.Forms.TabControl AppTabs;
		private System.Windows.Forms.TabPage ReaderTab;
		private System.Windows.Forms.TabPage EMTab;
		private System.Windows.Forms.Label TagLabel;
		private System.Windows.Forms.ComboBox TxLevelSel;
		private System.Windows.Forms.CheckBox ErrLogChk;
		private System.Windows.Forms.Button BAPStatBtn;
		private System.Windows.Forms.Button GetUTCBtn;
		private System.Windows.Forms.CheckBox AutoScanChk;
		private System.Windows.Forms.Button BAPDisBtn;
		private System.Windows.Forms.Button BAPEnBtn;
		private System.Windows.Forms.Button TestTagBtn;
		private System.Windows.Forms.ComboBox ModulationSel;
		private System.Windows.Forms.Button ResetToABtn;
		private System.Windows.Forms.ComboBox InvQSel;
		private System.Windows.Forms.ComboBox InvSessionSel;
		private System.Windows.Forms.ComboBox InvTargetSel;
		private System.Windows.Forms.Button MakeSimpleBtn;
		private System.Windows.Forms.TabPage tabSensor;
		private System.Windows.Forms.Button StopBtn;
		private System.Windows.Forms.Button CustStartBtn;
		private System.Windows.Forms.Button SimpleStartBtn;
		private System.Windows.Forms.CheckBox BlockCfgChk;
		private System.Windows.Forms.Button ReadCfgBtn;
		private System.Windows.Forms.Button RstAlarmsBtn;
		private System.Windows.Forms.Button GetTempBtn;
		private System.Windows.Forms.Button SensorBtn;
		private System.Windows.Forms.CheckBox UidWithSensor;
		private System.Windows.Forms.Button BtnReadUSer;
		private System.Windows.Forms.ComboBox UserMemType;
		private System.Windows.Forms.CheckBox AppReadChk;
		private System.Windows.Forms.CheckBox TargetResetChk;
		private System.Windows.Forms.ListView physAntListView;
		private System.Windows.Forms.ColumnHeader columnHeader_Antenna;
		private System.Windows.Forms.ComboBox InvRoundsSel;
		private System.Windows.Forms.ListView TagListView;
		private System.Windows.Forms.ColumnHeader columnHeader_EPC;
		private System.Windows.Forms.ColumnHeader columnHeader_RSSI;
		private System.Windows.Forms.ColumnHeader columnHeader_AntID;
	}
}

