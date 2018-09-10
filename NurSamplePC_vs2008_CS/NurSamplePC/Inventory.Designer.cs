namespace NurSample
{
    partial class Inventory
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startStopInventoryBtn = new System.Windows.Forms.Button();
            this.tagsFoundLabel = new System.Windows.Forms.Label();
            this.invTypeComboBox = new System.Windows.Forms.ComboBox();
            this.invTypeLabel = new System.Windows.Forms.Label();
            this.dataBankLabel = new System.Windows.Forms.Label();
            this.dataBankComboBox = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tagsTab = new System.Windows.Forms.TabPage();
            this.filterTab = new System.Windows.Forms.TabPage();
            this.incIndex = new System.Windows.Forms.Button();
            this.decIndex = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.target_combo = new System.Windows.Forms.ComboBox();
            this.action_combo = new System.Windows.Forms.ComboBox();
            this.filterCntLabel = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.length_UpDown = new System.Windows.Forms.NumericUpDown();
            this.address_UpDown = new System.Windows.Forms.NumericUpDown();
            this.readTag_Button = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mask_textBox = new System.Windows.Forms.TextBox();
            this.bank_combo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.settingsTab = new System.Windows.Forms.TabPage();
            this.dataLengthUpDown = new System.Windows.Forms.NumericUpDown();
            this.dataStartUpDown = new System.Windows.Forms.NumericUpDown();
            this.dataLengthLabel = new System.Windows.Forms.Label();
            this.dataStartLabel = new System.Windows.Forms.Label();
            this.saveToFileTab = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.logInvSeparatorTextBox = new System.Windows.Forms.TextBox();
            this.logInvFormatComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.logActionLabel = new System.Windows.Forms.Label();
            this.logInvActionComboBox = new System.Windows.Forms.ComboBox();
            this.logInvEnabledComboBox = new System.Windows.Forms.CheckBox();
            this.logInvBrowseBtn = new System.Windows.Forms.Button();
            this.logInvFileNameTextBox = new System.Windows.Forms.TextBox();
            this.logFilenameLabel = new System.Windows.Forms.Label();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.saveLogDialog = new System.Windows.Forms.SaveFileDialog();
            this.statTab = new System.Windows.Forms.TabPage();
            this.totalLabel = new System.Windows.Forms.Label();
            this.totalReadsLabel = new System.Windows.Forms.Label();
            this.totalAverageLabel = new System.Windows.Forms.Label();
            this.uniqueLabel = new System.Windows.Forms.Label();
            this.uniqueTagsLabel = new System.Windows.Forms.Label();
            this.uniqueAverageLabel = new System.Windows.Forms.Label();
            this.tagListBox = new NurSample.NurTagDataListView();
            this.startStopInventoryBtn2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tagsTab.SuspendLayout();
            this.filterTab.SuspendLayout();
            this.settingsTab.SuspendLayout();
            this.saveToFileTab.SuspendLayout();
            this.statTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // startStopInventoryBtn
            // 
            this.startStopInventoryBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.startStopInventoryBtn.Location = new System.Drawing.Point(3, 248);
            this.startStopInventoryBtn.Name = "startStopInventoryBtn";
            this.startStopInventoryBtn.Size = new System.Drawing.Size(112, 40);
            this.startStopInventoryBtn.TabIndex = 16;
            this.startStopInventoryBtn.Text = "Start Inventory";
            this.startStopInventoryBtn.Click += new System.EventHandler(this.startStopInventoryBtn_Click);
            // 
            // tagsFoundLabel
            // 
            this.tagsFoundLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tagsFoundLabel.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.tagsFoundLabel.Location = new System.Drawing.Point(121, 256);
            this.tagsFoundLabel.Name = "tagsFoundLabel";
            this.tagsFoundLabel.Size = new System.Drawing.Size(108, 30);
            this.tagsFoundLabel.Text = "- - -";
            this.tagsFoundLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // invTypeComboBox
            // 
            this.invTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.invTypeComboBox.Items.Add("Inventory only");
            this.invTypeComboBox.Items.Add("Inv. + data");
            this.invTypeComboBox.Items.Add("Data only");
            this.invTypeComboBox.Location = new System.Drawing.Point(109, 4);
            this.invTypeComboBox.Name = "invTypeComboBox";
            this.invTypeComboBox.Size = new System.Drawing.Size(120, 23);
            this.invTypeComboBox.TabIndex = 21;
            this.invTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.invTypeComboBox_SelectedIndexChanged);
            // 
            // invTypeLabel
            // 
            this.invTypeLabel.Location = new System.Drawing.Point(3, 7);
            this.invTypeLabel.Name = "invTypeLabel";
            this.invTypeLabel.Size = new System.Drawing.Size(100, 20);
            this.invTypeLabel.Text = "Inv.Type";
            // 
            // dataBankLabel
            // 
            this.dataBankLabel.Location = new System.Drawing.Point(3, 36);
            this.dataBankLabel.Name = "dataBankLabel";
            this.dataBankLabel.Size = new System.Drawing.Size(100, 20);
            this.dataBankLabel.Text = "Data.Bank";
            // 
            // dataBankComboBox
            // 
            this.dataBankComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataBankComboBox.Items.Add("PWD");
            this.dataBankComboBox.Items.Add("EPC");
            this.dataBankComboBox.Items.Add("TID");
            this.dataBankComboBox.Items.Add("USER");
            this.dataBankComboBox.Location = new System.Drawing.Point(109, 33);
            this.dataBankComboBox.Name = "dataBankComboBox";
            this.dataBankComboBox.Size = new System.Drawing.Size(120, 23);
            this.dataBankComboBox.TabIndex = 42;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tagsTab);
            this.tabControl1.Controls.Add(this.filterTab);
            this.tabControl1.Controls.Add(this.settingsTab);
            this.tabControl1.Controls.Add(this.statTab);
            this.tabControl1.Controls.Add(this.saveToFileTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 320);
            this.tabControl1.TabIndex = 47;
            // 
            // tagsTab
            // 
            this.tagsTab.Controls.Add(this.startStopInventoryBtn);
            this.tagsTab.Controls.Add(this.tagListBox);
            this.tagsTab.Controls.Add(this.tagsFoundLabel);
            this.tagsTab.Location = new System.Drawing.Point(4, 25);
            this.tagsTab.Name = "tagsTab";
            this.tagsTab.Size = new System.Drawing.Size(232, 291);
            this.tagsTab.Text = "Tags";
            // 
            // filterTab
            // 
            this.filterTab.Controls.Add(this.incIndex);
            this.filterTab.Controls.Add(this.decIndex);
            this.filterTab.Controls.Add(this.label9);
            this.filterTab.Controls.Add(this.label8);
            this.filterTab.Controls.Add(this.target_combo);
            this.filterTab.Controls.Add(this.action_combo);
            this.filterTab.Controls.Add(this.filterCntLabel);
            this.filterTab.Controls.Add(this.addBtn);
            this.filterTab.Controls.Add(this.deleteBtn);
            this.filterTab.Controls.Add(this.length_UpDown);
            this.filterTab.Controls.Add(this.address_UpDown);
            this.filterTab.Controls.Add(this.readTag_Button);
            this.filterTab.Controls.Add(this.label6);
            this.filterTab.Controls.Add(this.label5);
            this.filterTab.Controls.Add(this.mask_textBox);
            this.filterTab.Controls.Add(this.bank_combo);
            this.filterTab.Controls.Add(this.label4);
            this.filterTab.Controls.Add(this.label3);
            this.filterTab.Controls.Add(this.label7);
            this.filterTab.Controls.Add(this.label10);
            this.filterTab.Location = new System.Drawing.Point(4, 25);
            this.filterTab.Name = "filterTab";
            this.filterTab.Size = new System.Drawing.Size(232, 291);
            this.filterTab.Text = "Filters";
            // 
            // incIndex
            // 
            this.incIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.incIndex.Location = new System.Drawing.Point(179, 3);
            this.incIndex.Name = "incIndex";
            this.incIndex.Size = new System.Drawing.Size(50, 20);
            this.incIndex.TabIndex = 48;
            this.incIndex.Text = ">>";
            this.incIndex.Click += new System.EventHandler(this.incIndex_Click);
            // 
            // decIndex
            // 
            this.decIndex.Location = new System.Drawing.Point(3, 3);
            this.decIndex.Name = "decIndex";
            this.decIndex.Size = new System.Drawing.Size(50, 20);
            this.decIndex.TabIndex = 47;
            this.decIndex.Text = "<<";
            this.decIndex.Click += new System.EventHandler(this.decIndex_Click);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(3, 178);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 20);
            this.label9.Text = "Target";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(3, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 20);
            this.label8.Text = "Action";
            // 
            // target_combo
            // 
            this.target_combo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.target_combo.Items.Add("SESSION_S0");
            this.target_combo.Items.Add("SESSION_S1");
            this.target_combo.Items.Add("SESSION_S2");
            this.target_combo.Items.Add("SESSION_S3");
            this.target_combo.Items.Add("SESSION_SL");
            this.target_combo.Location = new System.Drawing.Point(69, 175);
            this.target_combo.Name = "target_combo";
            this.target_combo.Size = new System.Drawing.Size(160, 23);
            this.target_combo.TabIndex = 46;
            // 
            // action_combo
            // 
            this.action_combo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.action_combo.Items.Add("ACTION_0");
            this.action_combo.Items.Add("ACTION_1");
            this.action_combo.Items.Add("ACTION_2");
            this.action_combo.Items.Add("ACTION_3");
            this.action_combo.Items.Add("ACTION_4");
            this.action_combo.Items.Add("ACTION_5");
            this.action_combo.Items.Add("ACTION_6");
            this.action_combo.Items.Add("ACTION_7");
            this.action_combo.Location = new System.Drawing.Point(69, 144);
            this.action_combo.Name = "action_combo";
            this.action_combo.Size = new System.Drawing.Size(160, 23);
            this.action_combo.TabIndex = 45;
            // 
            // filterCntLabel
            // 
            this.filterCntLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.filterCntLabel.Location = new System.Drawing.Point(59, 3);
            this.filterCntLabel.Name = "filterCntLabel";
            this.filterCntLabel.Size = new System.Drawing.Size(114, 20);
            this.filterCntLabel.Text = "filterCntLabel";
            this.filterCntLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // addBtn
            // 
            this.addBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.addBtn.Location = new System.Drawing.Point(84, 204);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(65, 20);
            this.addBtn.TabIndex = 44;
            this.addBtn.Text = "Add";
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteBtn.Location = new System.Drawing.Point(155, 204);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 20);
            this.deleteBtn.TabIndex = 43;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // length_UpDown
            // 
            this.length_UpDown.Location = new System.Drawing.Point(69, 114);
            this.length_UpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.length_UpDown.Name = "length_UpDown";
            this.length_UpDown.Size = new System.Drawing.Size(100, 24);
            this.length_UpDown.TabIndex = 41;
            // 
            // address_UpDown
            // 
            this.address_UpDown.Location = new System.Drawing.Point(69, 55);
            this.address_UpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.address_UpDown.Name = "address_UpDown";
            this.address_UpDown.Size = new System.Drawing.Size(100, 24);
            this.address_UpDown.TabIndex = 39;
            // 
            // readTag_Button
            // 
            this.readTag_Button.Location = new System.Drawing.Point(3, 204);
            this.readTag_Button.Name = "readTag_Button";
            this.readTag_Button.Size = new System.Drawing.Size(75, 20);
            this.readTag_Button.TabIndex = 42;
            this.readTag_Button.Text = "Read Tag";
            this.readTag_Button.Click += new System.EventHandler(this.readTag_Button_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(175, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 20);
            this.label6.Text = "bits";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(175, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.Text = "bits";
            // 
            // mask_textBox
            // 
            this.mask_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mask_textBox.HideSelection = false;
            this.mask_textBox.Location = new System.Drawing.Point(69, 85);
            this.mask_textBox.Name = "mask_textBox";
            this.mask_textBox.Size = new System.Drawing.Size(160, 23);
            this.mask_textBox.TabIndex = 40;
            // 
            // bank_combo
            // 
            this.bank_combo.Items.Add("0 - Password");
            this.bank_combo.Items.Add("1 - EPC");
            this.bank_combo.Items.Add("2 - TID");
            this.bank_combo.Items.Add("3 - USER");
            this.bank_combo.Location = new System.Drawing.Point(69, 26);
            this.bank_combo.Name = "bank_combo";
            this.bank_combo.Size = new System.Drawing.Size(100, 23);
            this.bank_combo.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.Text = "Length";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.Text = "Mask";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(3, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 20);
            this.label7.Text = "Address";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(3, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 20);
            this.label10.Text = "Bank";
            // 
            // settingsTab
            // 
            this.settingsTab.Controls.Add(this.dataLengthUpDown);
            this.settingsTab.Controls.Add(this.dataStartUpDown);
            this.settingsTab.Controls.Add(this.dataLengthLabel);
            this.settingsTab.Controls.Add(this.dataStartLabel);
            this.settingsTab.Controls.Add(this.dataBankLabel);
            this.settingsTab.Controls.Add(this.invTypeComboBox);
            this.settingsTab.Controls.Add(this.dataBankComboBox);
            this.settingsTab.Controls.Add(this.invTypeLabel);
            this.settingsTab.Location = new System.Drawing.Point(4, 25);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.Size = new System.Drawing.Size(232, 291);
            this.settingsTab.Text = "Settings";
            // 
            // dataLengthUpDown
            // 
            this.dataLengthUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataLengthUpDown.Location = new System.Drawing.Point(109, 92);
            this.dataLengthUpDown.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.dataLengthUpDown.Name = "dataLengthUpDown";
            this.dataLengthUpDown.Size = new System.Drawing.Size(120, 24);
            this.dataLengthUpDown.TabIndex = 50;
            this.dataLengthUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // dataStartUpDown
            // 
            this.dataStartUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataStartUpDown.Location = new System.Drawing.Point(109, 62);
            this.dataStartUpDown.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.dataStartUpDown.Name = "dataStartUpDown";
            this.dataStartUpDown.Size = new System.Drawing.Size(120, 24);
            this.dataStartUpDown.TabIndex = 49;
            // 
            // dataLengthLabel
            // 
            this.dataLengthLabel.Location = new System.Drawing.Point(3, 96);
            this.dataLengthLabel.Name = "dataLengthLabel";
            this.dataLengthLabel.Size = new System.Drawing.Size(100, 20);
            this.dataLengthLabel.Text = "Data.Length [W]";
            // 
            // dataStartLabel
            // 
            this.dataStartLabel.Location = new System.Drawing.Point(3, 66);
            this.dataStartLabel.Name = "dataStartLabel";
            this.dataStartLabel.Size = new System.Drawing.Size(100, 20);
            this.dataStartLabel.Text = "Data.Start [W]";
            // 
            // saveToFileTab
            // 
            this.saveToFileTab.Controls.Add(this.label2);
            this.saveToFileTab.Controls.Add(this.logInvSeparatorTextBox);
            this.saveToFileTab.Controls.Add(this.logInvFormatComboBox);
            this.saveToFileTab.Controls.Add(this.label1);
            this.saveToFileTab.Controls.Add(this.logActionLabel);
            this.saveToFileTab.Controls.Add(this.logInvActionComboBox);
            this.saveToFileTab.Controls.Add(this.logInvEnabledComboBox);
            this.saveToFileTab.Controls.Add(this.logInvBrowseBtn);
            this.saveToFileTab.Controls.Add(this.logInvFileNameTextBox);
            this.saveToFileTab.Controls.Add(this.logFilenameLabel);
            this.saveToFileTab.Location = new System.Drawing.Point(4, 25);
            this.saveToFileTab.Name = "saveToFileTab";
            this.saveToFileTab.Size = new System.Drawing.Size(232, 291);
            this.saveToFileTab.Text = "SaveToFile";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(159, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.Text = "Separator";
            // 
            // logInvSeparatorTextBox
            // 
            this.logInvSeparatorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.logInvSeparatorTextBox.Location = new System.Drawing.Point(159, 159);
            this.logInvSeparatorTextBox.Name = "logInvSeparatorTextBox";
            this.logInvSeparatorTextBox.Size = new System.Drawing.Size(70, 23);
            this.logInvSeparatorTextBox.TabIndex = 19;
            this.logInvSeparatorTextBox.Text = ",";
            this.logInvSeparatorTextBox.TextChanged += new System.EventHandler(this.logInvSeparatorTextBox_TextChanged);
            // 
            // logInvFormatComboBox
            // 
            this.logInvFormatComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.logInvFormatComboBox.DisplayMember = "30";
            this.logInvFormatComboBox.Items.Add("EPC or DATA");
            this.logInvFormatComboBox.Items.Add("EPC,DATA");
            this.logInvFormatComboBox.Items.Add("Date&Time,EPC,RSSI");
            this.logInvFormatComboBox.Location = new System.Drawing.Point(3, 159);
            this.logInvFormatComboBox.Name = "logInvFormatComboBox";
            this.logInvFormatComboBox.Size = new System.Drawing.Size(150, 23);
            this.logInvFormatComboBox.TabIndex = 15;
            this.logInvFormatComboBox.SelectedIndexChanged += new System.EventHandler(this.logInvFormatComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 20);
            this.label1.Text = "Log file format";
            // 
            // logActionLabel
            // 
            this.logActionLabel.Location = new System.Drawing.Point(3, 87);
            this.logActionLabel.Name = "logActionLabel";
            this.logActionLabel.Size = new System.Drawing.Size(220, 20);
            this.logActionLabel.Text = "Log file action";
            // 
            // logInvActionComboBox
            // 
            this.logInvActionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.logInvActionComboBox.DisplayMember = "30";
            this.logInvActionComboBox.Items.Add("Create new always");
            this.logInvActionComboBox.Items.Add("Append");
            this.logInvActionComboBox.Items.Add("Replace");
            this.logInvActionComboBox.Location = new System.Drawing.Point(3, 110);
            this.logInvActionComboBox.Name = "logInvActionComboBox";
            this.logInvActionComboBox.Size = new System.Drawing.Size(150, 23);
            this.logInvActionComboBox.TabIndex = 14;
            // 
            // logInvEnabledComboBox
            // 
            this.logInvEnabledComboBox.Checked = true;
            this.logInvEnabledComboBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.logInvEnabledComboBox.Location = new System.Drawing.Point(3, 9);
            this.logInvEnabledComboBox.Name = "logInvEnabledComboBox";
            this.logInvEnabledComboBox.Size = new System.Drawing.Size(220, 20);
            this.logInvEnabledComboBox.TabIndex = 11;
            this.logInvEnabledComboBox.Text = "Log Inventory results to File";
            this.logInvEnabledComboBox.CheckStateChanged += new System.EventHandler(this.logInvEnabledComboBox_CheckStateChanged);
            // 
            // logInvBrowseBtn
            // 
            this.logInvBrowseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.logInvBrowseBtn.Location = new System.Drawing.Point(159, 61);
            this.logInvBrowseBtn.Name = "logInvBrowseBtn";
            this.logInvBrowseBtn.Size = new System.Drawing.Size(70, 23);
            this.logInvBrowseBtn.TabIndex = 13;
            this.logInvBrowseBtn.Text = "Browse";
            this.logInvBrowseBtn.Click += new System.EventHandler(this.logInvBrowseBtn_Click);
            // 
            // logInvFileNameTextBox
            // 
            this.logInvFileNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.logInvFileNameTextBox.Location = new System.Drawing.Point(3, 61);
            this.logInvFileNameTextBox.Name = "logInvFileNameTextBox";
            this.logInvFileNameTextBox.Size = new System.Drawing.Size(150, 23);
            this.logInvFileNameTextBox.TabIndex = 12;
            this.logInvFileNameTextBox.Text = "\\NurSample_Inventory.csv";
            // 
            // logFilenameLabel
            // 
            this.logFilenameLabel.Location = new System.Drawing.Point(3, 38);
            this.logFilenameLabel.Name = "logFilenameLabel";
            this.logFilenameLabel.Size = new System.Drawing.Size(220, 20);
            this.logFilenameLabel.Text = "Log filename";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ColumnHeader";
            this.columnHeader1.Width = 60;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ColumnHeader";
            this.columnHeader2.Width = 60;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ColumnHeader";
            this.columnHeader3.Width = 60;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "ColumnHeader";
            this.columnHeader4.Width = 60;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "ColumnHeader";
            this.columnHeader5.Width = 60;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "ColumnHeader";
            this.columnHeader6.Width = 60;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "ColumnHeader";
            this.columnHeader7.Width = 60;
            // 
            // statTab
            // 
            this.statTab.Controls.Add(this.startStopInventoryBtn2);
            this.statTab.Controls.Add(this.uniqueAverageLabel);
            this.statTab.Controls.Add(this.uniqueTagsLabel);
            this.statTab.Controls.Add(this.uniqueLabel);
            this.statTab.Controls.Add(this.totalAverageLabel);
            this.statTab.Controls.Add(this.totalReadsLabel);
            this.statTab.Controls.Add(this.totalLabel);
            this.statTab.Location = new System.Drawing.Point(4, 25);
            this.statTab.Name = "statTab";
            this.statTab.Size = new System.Drawing.Size(232, 291);
            this.statTab.Text = "Statistics";
            // 
            // totalLabel
            // 
            this.totalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.totalLabel.Location = new System.Drawing.Point(3, 12);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(226, 20);
            this.totalLabel.Text = "Total";
            // 
            // totalReadsLabel
            // 
            this.totalReadsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.totalReadsLabel.Location = new System.Drawing.Point(3, 32);
            this.totalReadsLabel.Name = "totalReadsLabel";
            this.totalReadsLabel.Size = new System.Drawing.Size(226, 20);
            this.totalReadsLabel.Text = "Total reads";
            // 
            // totalAverageLabel
            // 
            this.totalAverageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.totalAverageLabel.Location = new System.Drawing.Point(3, 52);
            this.totalAverageLabel.Name = "totalAverageLabel";
            this.totalAverageLabel.Size = new System.Drawing.Size(226, 20);
            this.totalAverageLabel.Text = "Average reads";
            // 
            // uniqueLabel
            // 
            this.uniqueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uniqueLabel.Location = new System.Drawing.Point(3, 84);
            this.uniqueLabel.Name = "uniqueLabel";
            this.uniqueLabel.Size = new System.Drawing.Size(226, 20);
            this.uniqueLabel.Text = "Unique";
            // 
            // uniqueTagsLabel
            // 
            this.uniqueTagsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uniqueTagsLabel.Location = new System.Drawing.Point(3, 104);
            this.uniqueTagsLabel.Name = "uniqueTagsLabel";
            this.uniqueTagsLabel.Size = new System.Drawing.Size(226, 20);
            this.uniqueTagsLabel.Text = "Unique tags";
            // 
            // uniqueAverageLabel
            // 
            this.uniqueAverageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uniqueAverageLabel.Location = new System.Drawing.Point(3, 124);
            this.uniqueAverageLabel.Name = "uniqueAverageLabel";
            this.uniqueAverageLabel.Size = new System.Drawing.Size(226, 20);
            this.uniqueAverageLabel.Text = "Average tags";
            // 
            // tagListBox
            // 
            this.tagListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tagListBox.Location = new System.Drawing.Point(3, 3);
            this.tagListBox.Name = "tagListBox";
            this.tagListBox.Size = new System.Drawing.Size(226, 239);
            this.tagListBox.TabIndex = 15;
            this.tagListBox.SelectedTagChanged += new System.EventHandler(this.tagListBox_SelectedTagChanged);
            // 
            // startStopInventoryBtn2
            // 
            this.startStopInventoryBtn2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.startStopInventoryBtn2.Location = new System.Drawing.Point(3, 248);
            this.startStopInventoryBtn2.Name = "startStopInventoryBtn2";
            this.startStopInventoryBtn2.Size = new System.Drawing.Size(112, 40);
            this.startStopInventoryBtn2.TabIndex = 17;
            this.startStopInventoryBtn2.Text = "Start Inventory";
            this.startStopInventoryBtn2.Click += new System.EventHandler(this.startStopInventoryBtn_Click);
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl1);
            this.Name = "Inventory";
            this.Size = new System.Drawing.Size(240, 320);
            this.tabControl1.ResumeLayout(false);
            this.tagsTab.ResumeLayout(false);
            this.filterTab.ResumeLayout(false);
            this.settingsTab.ResumeLayout(false);
            this.saveToFileTab.ResumeLayout(false);
            this.statTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startStopInventoryBtn;
        private NurTagDataListView tagListBox;
        private System.Windows.Forms.Label tagsFoundLabel;
        private System.Windows.Forms.ComboBox invTypeComboBox;
        private System.Windows.Forms.Label invTypeLabel;
        private System.Windows.Forms.Label dataBankLabel;
        private System.Windows.Forms.ComboBox dataBankComboBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tagsTab;
        private System.Windows.Forms.TabPage settingsTab;
        private System.Windows.Forms.NumericUpDown dataLengthUpDown;
        private System.Windows.Forms.NumericUpDown dataStartUpDown;
        private System.Windows.Forms.Label dataLengthLabel;
        private System.Windows.Forms.Label dataStartLabel;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.TabPage saveToFileTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label logActionLabel;
        private System.Windows.Forms.ComboBox logInvActionComboBox;
        private System.Windows.Forms.CheckBox logInvEnabledComboBox;
        private System.Windows.Forms.Button logInvBrowseBtn;
        private System.Windows.Forms.TextBox logInvFileNameTextBox;
        private System.Windows.Forms.Label logFilenameLabel;
        private System.Windows.Forms.SaveFileDialog saveLogDialog;
        private System.Windows.Forms.ComboBox logInvFormatComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox logInvSeparatorTextBox;
        private System.Windows.Forms.TabPage filterTab;
        private System.Windows.Forms.Button incIndex;
        private System.Windows.Forms.Button decIndex;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox target_combo;
        private System.Windows.Forms.ComboBox action_combo;
        private System.Windows.Forms.Label filterCntLabel;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.NumericUpDown length_UpDown;
        private System.Windows.Forms.NumericUpDown address_UpDown;
        private System.Windows.Forms.Button readTag_Button;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox mask_textBox;
        private System.Windows.Forms.ComboBox bank_combo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage statTab;
        private System.Windows.Forms.Label totalAverageLabel;
        private System.Windows.Forms.Label totalReadsLabel;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label uniqueLabel;
        private System.Windows.Forms.Label uniqueAverageLabel;
        private System.Windows.Forms.Label uniqueTagsLabel;
        private System.Windows.Forms.Button startStopInventoryBtn2;
    }
}
