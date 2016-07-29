namespace NurSample
{
    partial class Writer
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
            this.epcHeader = new System.Windows.Forms.ColumnHeader();
            this.rssiHeader = new System.Windows.Forms.ColumnHeader();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tagsTab = new System.Windows.Forms.TabPage();
            this.writeTagListView = new NurSample.NurTagListView();
            this.targetTab = new System.Windows.Forms.TabPage();
            this.pickUpButton = new System.Windows.Forms.Button();
            this.passwdTextBox = new System.Windows.Forms.TextBox();
            this.targetMaskTextBox = new System.Windows.Forms.TextBox();
            this.usePasswdCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.targetLengthUD = new System.Windows.Forms.NumericUpDown();
            this.targetStartUD = new System.Windows.Forms.NumericUpDown();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.targetBankCB = new System.Windows.Forms.ComboBox();
            this.epcTab = new System.Windows.Forms.TabPage();
            this.writeNewEpcBtn = new System.Windows.Forms.Button();
            this.newEpcTextBox = new System.Windows.Forms.TextBox();
            this.targetEpcLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.enterNewEpcLabel = new System.Windows.Forms.Label();
            this.memTab = new System.Windows.Forms.TabPage();
            this.memUseReadBlockCheckBox = new System.Windows.Forms.CheckBox();
            this.writeMemButton = new System.Windows.Forms.Button();
            this.readMemButton = new System.Windows.Forms.Button();
            this.memTextBox = new System.Windows.Forms.TextBox();
            this.targetMemLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.memLengthUD = new System.Windows.Forms.NumericUpDown();
            this.memStartUD = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.memBankCB = new System.Windows.Forms.ComboBox();
            this.lockTab = new System.Windows.Forms.TabPage();
            this.lockKillCheckBox = new System.Windows.Forms.CheckBox();
            this.lockAccessCheckBox = new System.Windows.Forms.CheckBox();
            this.lockEpcCheckBox = new System.Windows.Forms.CheckBox();
            this.lockTicCheckBox = new System.Windows.Forms.CheckBox();
            this.lockUserCheckBox = new System.Windows.Forms.CheckBox();
            this.setLockStateButton = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.secLockStateCB = new System.Windows.Forms.ComboBox();
            this.securityTab = new System.Windows.Forms.TabPage();
            this.killButton = new System.Windows.Forms.Button();
            this.writePasswordButton = new System.Windows.Forms.Button();
            this.readPasswordButton = new System.Windows.Forms.Button();
            this.secPasswdTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.securityCB = new System.Windows.Forms.ComboBox();
            this.targetAccessLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tagsTab.SuspendLayout();
            this.targetTab.SuspendLayout();
            this.epcTab.SuspendLayout();
            this.memTab.SuspendLayout();
            this.lockTab.SuspendLayout();
            this.securityTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // epcHeader
            // 
            this.epcHeader.Text = "EPC";
            this.epcHeader.Width = 160;
            // 
            // rssiHeader
            // 
            this.rssiHeader.Text = "RSSI";
            this.rssiHeader.Width = 60;
            // 
            // refreshBtn
            // 
            this.refreshBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshBtn.Location = new System.Drawing.Point(3, 248);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(226, 40);
            this.refreshBtn.TabIndex = 21;
            this.refreshBtn.Text = "Refresh list";
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.Text = "Select the target Tag";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tagsTab);
            this.tabControl1.Controls.Add(this.targetTab);
            this.tabControl1.Controls.Add(this.epcTab);
            this.tabControl1.Controls.Add(this.memTab);
            this.tabControl1.Controls.Add(this.lockTab);
            this.tabControl1.Controls.Add(this.securityTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 320);
            this.tabControl1.TabIndex = 25;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tagsTab
            // 
            this.tagsTab.Controls.Add(this.label1);
            this.tagsTab.Controls.Add(this.writeTagListView);
            this.tagsTab.Controls.Add(this.refreshBtn);
            this.tagsTab.Location = new System.Drawing.Point(4, 25);
            this.tagsTab.Name = "tagsTab";
            this.tagsTab.Size = new System.Drawing.Size(232, 291);
            this.tagsTab.Text = "Tags";
            // 
            // writeTagListView
            // 
            this.writeTagListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.writeTagListView.Location = new System.Drawing.Point(3, 30);
            this.writeTagListView.Name = "writeTagListView";
            this.writeTagListView.Size = new System.Drawing.Size(226, 212);
            this.writeTagListView.TabIndex = 22;
            this.writeTagListView.SelectedTagChanged += new System.EventHandler(this.writeTagListView_SelectedTagChanged);
            // 
            // targetTab
            // 
            this.targetTab.Controls.Add(this.pickUpButton);
            this.targetTab.Controls.Add(this.passwdTextBox);
            this.targetTab.Controls.Add(this.targetMaskTextBox);
            this.targetTab.Controls.Add(this.usePasswdCheckBox);
            this.targetTab.Controls.Add(this.label4);
            this.targetTab.Controls.Add(this.targetLengthUD);
            this.targetTab.Controls.Add(this.targetStartUD);
            this.targetTab.Controls.Add(this.lengthLabel);
            this.targetTab.Controls.Add(this.label5);
            this.targetTab.Controls.Add(this.label6);
            this.targetTab.Controls.Add(this.targetBankCB);
            this.targetTab.Location = new System.Drawing.Point(4, 25);
            this.targetTab.Name = "targetTab";
            this.targetTab.Size = new System.Drawing.Size(232, 291);
            this.targetTab.Text = "Target";
            // 
            // pickUpButton
            // 
            this.pickUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pickUpButton.Location = new System.Drawing.Point(3, 171);
            this.pickUpButton.Name = "pickUpButton";
            this.pickUpButton.Size = new System.Drawing.Size(226, 40);
            this.pickUpButton.TabIndex = 23;
            this.pickUpButton.Text = "Pick up the strongest Tag";
            this.pickUpButton.Click += new System.EventHandler(this.pickUpButton_Click);
            // 
            // passwdTextBox
            // 
            this.passwdTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.passwdTextBox.Location = new System.Drawing.Point(3, 136);
            this.passwdTextBox.MaxLength = 8;
            this.passwdTextBox.Name = "passwdTextBox";
            this.passwdTextBox.Size = new System.Drawing.Size(226, 23);
            this.passwdTextBox.TabIndex = 18;
            this.passwdTextBox.Text = "00000000";
            // 
            // targetMaskTextBox
            // 
            this.targetMaskTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.targetMaskTextBox.Location = new System.Drawing.Point(3, 78);
            this.targetMaskTextBox.MaxLength = 1024;
            this.targetMaskTextBox.Name = "targetMaskTextBox";
            this.targetMaskTextBox.Size = new System.Drawing.Size(226, 23);
            this.targetMaskTextBox.TabIndex = 17;
            // 
            // usePasswdCheckBox
            // 
            this.usePasswdCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.usePasswdCheckBox.Location = new System.Drawing.Point(3, 110);
            this.usePasswdCheckBox.Name = "usePasswdCheckBox";
            this.usePasswdCheckBox.Size = new System.Drawing.Size(226, 20);
            this.usePasswdCheckBox.TabIndex = 12;
            this.usePasswdCheckBox.Text = "Use access password";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(3, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(226, 20);
            this.label4.Text = "Mask [HEX]";
            // 
            // targetLengthUD
            // 
            this.targetLengthUD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.targetLengthUD.Location = new System.Drawing.Point(157, 26);
            this.targetLengthUD.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.targetLengthUD.Name = "targetLengthUD";
            this.targetLengthUD.Size = new System.Drawing.Size(72, 24);
            this.targetLengthUD.TabIndex = 11;
            // 
            // targetStartUD
            // 
            this.targetStartUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.targetStartUD.Location = new System.Drawing.Point(81, 26);
            this.targetStartUD.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.targetStartUD.Name = "targetStartUD";
            this.targetStartUD.Size = new System.Drawing.Size(70, 24);
            this.targetStartUD.TabIndex = 10;
            this.targetStartUD.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // lengthLabel
            // 
            this.lengthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lengthLabel.Location = new System.Drawing.Point(159, 6);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(72, 20);
            this.lengthLabel.Text = "Length [b]";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(81, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.Text = "Start [b]";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 20);
            this.label6.Text = "Bank";
            // 
            // targetBankCB
            // 
            this.targetBankCB.Items.Add("Reserved");
            this.targetBankCB.Items.Add("EPC");
            this.targetBankCB.Items.Add("TID");
            this.targetBankCB.Items.Add("User");
            this.targetBankCB.Location = new System.Drawing.Point(3, 26);
            this.targetBankCB.Name = "targetBankCB";
            this.targetBankCB.Size = new System.Drawing.Size(72, 23);
            this.targetBankCB.TabIndex = 9;
            // 
            // epcTab
            // 
            this.epcTab.Controls.Add(this.writeNewEpcBtn);
            this.epcTab.Controls.Add(this.newEpcTextBox);
            this.epcTab.Controls.Add(this.targetEpcLabel);
            this.epcTab.Controls.Add(this.label7);
            this.epcTab.Controls.Add(this.enterNewEpcLabel);
            this.epcTab.Location = new System.Drawing.Point(4, 25);
            this.epcTab.Name = "epcTab";
            this.epcTab.Size = new System.Drawing.Size(232, 291);
            this.epcTab.Text = "EPC";
            // 
            // writeNewEpcBtn
            // 
            this.writeNewEpcBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.writeNewEpcBtn.Location = new System.Drawing.Point(3, 98);
            this.writeNewEpcBtn.Name = "writeNewEpcBtn";
            this.writeNewEpcBtn.Size = new System.Drawing.Size(226, 30);
            this.writeNewEpcBtn.TabIndex = 25;
            this.writeNewEpcBtn.Text = "Write EPC";
            this.writeNewEpcBtn.Click += new System.EventHandler(this.writeNewEpcBtn_Click);
            // 
            // newEpcTextBox
            // 
            this.newEpcTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.newEpcTextBox.Location = new System.Drawing.Point(3, 69);
            this.newEpcTextBox.Name = "newEpcTextBox";
            this.newEpcTextBox.Size = new System.Drawing.Size(226, 23);
            this.newEpcTextBox.TabIndex = 18;
            // 
            // targetEpcLabel
            // 
            this.targetEpcLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.targetEpcLabel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.targetEpcLabel.Location = new System.Drawing.Point(3, 26);
            this.targetEpcLabel.Name = "targetEpcLabel";
            this.targetEpcLabel.Size = new System.Drawing.Size(633, 20);
            this.targetEpcLabel.Text = "targetEpcLabel";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(3, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(226, 20);
            this.label7.Text = "Target Tag";
            // 
            // enterNewEpcLabel
            // 
            this.enterNewEpcLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.enterNewEpcLabel.Location = new System.Drawing.Point(3, 46);
            this.enterNewEpcLabel.Name = "enterNewEpcLabel";
            this.enterNewEpcLabel.Size = new System.Drawing.Size(226, 20);
            this.enterNewEpcLabel.Text = "New EPC";
            // 
            // memTab
            // 
            this.memTab.Controls.Add(this.memUseReadBlockCheckBox);
            this.memTab.Controls.Add(this.writeMemButton);
            this.memTab.Controls.Add(this.readMemButton);
            this.memTab.Controls.Add(this.memTextBox);
            this.memTab.Controls.Add(this.targetMemLabel);
            this.memTab.Controls.Add(this.label10);
            this.memTab.Controls.Add(this.label2);
            this.memTab.Controls.Add(this.memLengthUD);
            this.memTab.Controls.Add(this.memStartUD);
            this.memTab.Controls.Add(this.label3);
            this.memTab.Controls.Add(this.label8);
            this.memTab.Controls.Add(this.label9);
            this.memTab.Controls.Add(this.memBankCB);
            this.memTab.Location = new System.Drawing.Point(4, 25);
            this.memTab.Name = "memTab";
            this.memTab.Size = new System.Drawing.Size(232, 291);
            this.memTab.Text = "Mem";
            // 
            // memUseReadBlockCheckBox
            // 
            this.memUseReadBlockCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memUseReadBlockCheckBox.Location = new System.Drawing.Point(4, 96);
            this.memUseReadBlockCheckBox.Name = "memUseReadBlockCheckBox";
            this.memUseReadBlockCheckBox.Size = new System.Drawing.Size(225, 20);
            this.memUseReadBlockCheckBox.TabIndex = 34;
            this.memUseReadBlockCheckBox.Text = "Use ReadBlock method";
            this.memUseReadBlockCheckBox.CheckStateChanged += new System.EventHandler(this.memUseReadBlockCheckBox_CheckStateChanged);
            // 
            // writeMemButton
            // 
            this.writeMemButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.writeMemButton.Location = new System.Drawing.Point(120, 171);
            this.writeMemButton.Name = "writeMemButton";
            this.writeMemButton.Size = new System.Drawing.Size(110, 30);
            this.writeMemButton.TabIndex = 27;
            this.writeMemButton.Text = "Write MEM";
            this.writeMemButton.Click += new System.EventHandler(this.writeMemButton_Click);
            // 
            // readMemButton
            // 
            this.readMemButton.Location = new System.Drawing.Point(4, 171);
            this.readMemButton.Name = "readMemButton";
            this.readMemButton.Size = new System.Drawing.Size(110, 30);
            this.readMemButton.TabIndex = 26;
            this.readMemButton.Text = "Read MEM";
            this.readMemButton.Click += new System.EventHandler(this.readMemButton_Click);
            // 
            // memTextBox
            // 
            this.memTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memTextBox.Location = new System.Drawing.Point(4, 142);
            this.memTextBox.Name = "memTextBox";
            this.memTextBox.Size = new System.Drawing.Size(226, 23);
            this.memTextBox.TabIndex = 23;
            // 
            // targetMemLabel
            // 
            this.targetMemLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.targetMemLabel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.targetMemLabel.Location = new System.Drawing.Point(3, 26);
            this.targetMemLabel.Name = "targetMemLabel";
            this.targetMemLabel.Size = new System.Drawing.Size(633, 20);
            this.targetMemLabel.Text = "targetMemLabel";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.Location = new System.Drawing.Point(3, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(226, 20);
            this.label10.Text = "Target Tag";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(4, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 20);
            this.label2.Text = "Data [HEX]";
            // 
            // memLengthUD
            // 
            this.memLengthUD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.memLengthUD.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.memLengthUD.Location = new System.Drawing.Point(157, 66);
            this.memLengthUD.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.memLengthUD.Name = "memLengthUD";
            this.memLengthUD.Size = new System.Drawing.Size(72, 24);
            this.memLengthUD.TabIndex = 14;
            this.memLengthUD.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // memStartUD
            // 
            this.memStartUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memStartUD.Location = new System.Drawing.Point(81, 66);
            this.memStartUD.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.memStartUD.Name = "memStartUD";
            this.memStartUD.Size = new System.Drawing.Size(70, 24);
            this.memStartUD.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(159, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.Text = "Length [B]";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Location = new System.Drawing.Point(81, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 20);
            this.label8.Text = "Start [W]";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(3, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 20);
            this.label9.Text = "Bank";
            // 
            // memBankCB
            // 
            this.memBankCB.Items.Add("Reserved");
            this.memBankCB.Items.Add("EPC");
            this.memBankCB.Items.Add("TID");
            this.memBankCB.Items.Add("User");
            this.memBankCB.Location = new System.Drawing.Point(3, 66);
            this.memBankCB.Name = "memBankCB";
            this.memBankCB.Size = new System.Drawing.Size(72, 23);
            this.memBankCB.TabIndex = 12;
            // 
            // lockTab
            // 
            this.lockTab.Controls.Add(this.lockKillCheckBox);
            this.lockTab.Controls.Add(this.lockAccessCheckBox);
            this.lockTab.Controls.Add(this.lockEpcCheckBox);
            this.lockTab.Controls.Add(this.lockTicCheckBox);
            this.lockTab.Controls.Add(this.lockUserCheckBox);
            this.lockTab.Controls.Add(this.setLockStateButton);
            this.lockTab.Controls.Add(this.label15);
            this.lockTab.Controls.Add(this.label14);
            this.lockTab.Controls.Add(this.secLockStateCB);
            this.lockTab.Location = new System.Drawing.Point(4, 25);
            this.lockTab.Name = "lockTab";
            this.lockTab.Size = new System.Drawing.Size(232, 291);
            this.lockTab.Text = "Locks";
            // 
            // lockKillCheckBox
            // 
            this.lockKillCheckBox.Location = new System.Drawing.Point(3, 55);
            this.lockKillCheckBox.Name = "lockKillCheckBox";
            this.lockKillCheckBox.Size = new System.Drawing.Size(100, 20);
            this.lockKillCheckBox.TabIndex = 53;
            this.lockKillCheckBox.Text = "KILLPWD";
            // 
            // lockAccessCheckBox
            // 
            this.lockAccessCheckBox.Location = new System.Drawing.Point(109, 55);
            this.lockAccessCheckBox.Name = "lockAccessCheckBox";
            this.lockAccessCheckBox.Size = new System.Drawing.Size(100, 20);
            this.lockAccessCheckBox.TabIndex = 52;
            this.lockAccessCheckBox.Text = "ACCESSPWD";
            // 
            // lockEpcCheckBox
            // 
            this.lockEpcCheckBox.Location = new System.Drawing.Point(3, 29);
            this.lockEpcCheckBox.Name = "lockEpcCheckBox";
            this.lockEpcCheckBox.Size = new System.Drawing.Size(100, 20);
            this.lockEpcCheckBox.TabIndex = 51;
            this.lockEpcCheckBox.Text = "EPC MEM";
            // 
            // lockTicCheckBox
            // 
            this.lockTicCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lockTicCheckBox.Location = new System.Drawing.Point(3, 81);
            this.lockTicCheckBox.Name = "lockTicCheckBox";
            this.lockTicCheckBox.Size = new System.Drawing.Size(226, 20);
            this.lockTicCheckBox.TabIndex = 50;
            this.lockTicCheckBox.Text = "TID MEM (probably locked)";
            // 
            // lockUserCheckBox
            // 
            this.lockUserCheckBox.Location = new System.Drawing.Point(109, 29);
            this.lockUserCheckBox.Name = "lockUserCheckBox";
            this.lockUserCheckBox.Size = new System.Drawing.Size(100, 20);
            this.lockUserCheckBox.TabIndex = 49;
            this.lockUserCheckBox.Text = "USER MEM";
            // 
            // setLockStateButton
            // 
            this.setLockStateButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.setLockStateButton.Location = new System.Drawing.Point(3, 168);
            this.setLockStateButton.Name = "setLockStateButton";
            this.setLockStateButton.Size = new System.Drawing.Size(226, 30);
            this.setLockStateButton.TabIndex = 48;
            this.setLockStateButton.Text = "Set Lock State";
            this.setLockStateButton.Click += new System.EventHandler(this.setLockStateButton_Click);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.Location = new System.Drawing.Point(3, 110);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(226, 20);
            this.label15.Text = "Lock state";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(3, 6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(226, 20);
            this.label14.Text = "Target flags";
            // 
            // secLockStateCB
            // 
            this.secLockStateCB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.secLockStateCB.Items.Add("Open");
            this.secLockStateCB.Items.Add("Permanently Writeable");
            this.secLockStateCB.Items.Add("Secured");
            this.secLockStateCB.Items.Add("Permanently Locked");
            this.secLockStateCB.Location = new System.Drawing.Point(3, 133);
            this.secLockStateCB.Name = "secLockStateCB";
            this.secLockStateCB.Size = new System.Drawing.Size(226, 23);
            this.secLockStateCB.TabIndex = 47;
            // 
            // securityTab
            // 
            this.securityTab.Controls.Add(this.killButton);
            this.securityTab.Controls.Add(this.writePasswordButton);
            this.securityTab.Controls.Add(this.readPasswordButton);
            this.securityTab.Controls.Add(this.secPasswdTextBox);
            this.securityTab.Controls.Add(this.label11);
            this.securityTab.Controls.Add(this.securityCB);
            this.securityTab.Controls.Add(this.targetAccessLabel);
            this.securityTab.Controls.Add(this.label12);
            this.securityTab.Controls.Add(this.label13);
            this.securityTab.Location = new System.Drawing.Point(4, 25);
            this.securityTab.Name = "securityTab";
            this.securityTab.Size = new System.Drawing.Size(232, 291);
            this.securityTab.Text = "Security";
            // 
            // killButton
            // 
            this.killButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.killButton.Location = new System.Drawing.Point(3, 140);
            this.killButton.Name = "killButton";
            this.killButton.Size = new System.Drawing.Size(226, 33);
            this.killButton.TabIndex = 51;
            this.killButton.Text = "Kill the target Tag";
            this.killButton.Click += new System.EventHandler(this.killButton_Click);
            // 
            // writePasswordButton
            // 
            this.writePasswordButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.writePasswordButton.Location = new System.Drawing.Point(119, 98);
            this.writePasswordButton.Name = "writePasswordButton";
            this.writePasswordButton.Size = new System.Drawing.Size(110, 30);
            this.writePasswordButton.TabIndex = 29;
            this.writePasswordButton.Text = "Write Password";
            this.writePasswordButton.Click += new System.EventHandler(this.writePasswordButton_Click);
            // 
            // readPasswordButton
            // 
            this.readPasswordButton.Location = new System.Drawing.Point(3, 98);
            this.readPasswordButton.Name = "readPasswordButton";
            this.readPasswordButton.Size = new System.Drawing.Size(110, 30);
            this.readPasswordButton.TabIndex = 28;
            this.readPasswordButton.Text = "Read Password";
            this.readPasswordButton.Click += new System.EventHandler(this.readPasswordButton_Click);
            // 
            // secPasswdTextBox
            // 
            this.secPasswdTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.secPasswdTextBox.Location = new System.Drawing.Point(86, 69);
            this.secPasswdTextBox.MaxLength = 8;
            this.secPasswdTextBox.Name = "secPasswdTextBox";
            this.secPasswdTextBox.Size = new System.Drawing.Size(143, 23);
            this.secPasswdTextBox.TabIndex = 17;
            this.secPasswdTextBox.Text = "00000000";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(3, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 20);
            this.label11.Text = "Security";
            // 
            // securityCB
            // 
            this.securityCB.Items.Add("Kill");
            this.securityCB.Items.Add("Access");
            this.securityCB.Location = new System.Drawing.Point(3, 69);
            this.securityCB.Name = "securityCB";
            this.securityCB.Size = new System.Drawing.Size(77, 23);
            this.securityCB.TabIndex = 9;
            // 
            // targetAccessLabel
            // 
            this.targetAccessLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.targetAccessLabel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.targetAccessLabel.Location = new System.Drawing.Point(3, 26);
            this.targetAccessLabel.Name = "targetAccessLabel";
            this.targetAccessLabel.Size = new System.Drawing.Size(633, 20);
            this.targetAccessLabel.Text = "targetAccessLabel";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.Location = new System.Drawing.Point(3, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(226, 20);
            this.label12.Text = "Target Tag";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.Location = new System.Drawing.Point(86, 46);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(146, 20);
            this.label13.Text = "Password [HEX]";
            // 
            // Writer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl1);
            this.Name = "Writer";
            this.Size = new System.Drawing.Size(240, 320);
            this.tabControl1.ResumeLayout(false);
            this.tagsTab.ResumeLayout(false);
            this.targetTab.ResumeLayout(false);
            this.epcTab.ResumeLayout(false);
            this.memTab.ResumeLayout(false);
            this.lockTab.ResumeLayout(false);
            this.securityTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private NurTagListView writeTagListView;
        private System.Windows.Forms.ColumnHeader epcHeader;
        private System.Windows.Forms.ColumnHeader rssiHeader;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tagsTab;
        private System.Windows.Forms.TabPage targetTab;
        private System.Windows.Forms.TextBox targetMaskTextBox;
        private System.Windows.Forms.CheckBox usePasswdCheckBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown targetLengthUD;
        private System.Windows.Forms.NumericUpDown targetStartUD;
        private System.Windows.Forms.Label lengthLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox targetBankCB;
        private System.Windows.Forms.TextBox passwdTextBox;
        private System.Windows.Forms.TabPage memTab;
        private System.Windows.Forms.TabPage epcTab;
        private System.Windows.Forms.Label targetEpcLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label enterNewEpcLabel;
        private System.Windows.Forms.TextBox newEpcTextBox;
        private System.Windows.Forms.Button writeNewEpcBtn;
        private System.Windows.Forms.Label targetMemLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown memLengthUD;
        private System.Windows.Forms.NumericUpDown memStartUD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox memBankCB;
        private System.Windows.Forms.Button writeMemButton;
        private System.Windows.Forms.Button readMemButton;
        private System.Windows.Forms.TextBox memTextBox;
        private System.Windows.Forms.TabPage securityTab;
        private System.Windows.Forms.TextBox secPasswdTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox securityCB;
        private System.Windows.Forms.Label targetAccessLabel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button writePasswordButton;
        private System.Windows.Forms.Button readPasswordButton;
        private System.Windows.Forms.TabPage lockTab;
        private System.Windows.Forms.CheckBox lockKillCheckBox;
        private System.Windows.Forms.CheckBox lockAccessCheckBox;
        private System.Windows.Forms.CheckBox lockEpcCheckBox;
        private System.Windows.Forms.CheckBox lockTicCheckBox;
        private System.Windows.Forms.CheckBox lockUserCheckBox;
        private System.Windows.Forms.Button setLockStateButton;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox secLockStateCB;
        private System.Windows.Forms.Button killButton;
        private System.Windows.Forms.Button pickUpButton;
        private System.Windows.Forms.CheckBox memUseReadBlockCheckBox;
    }
}
