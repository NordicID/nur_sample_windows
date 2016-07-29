namespace NurSample
{
    partial class Locator
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
            this.epcHeader = new System.Windows.Forms.ColumnHeader();
            this.rssiHeader = new System.Windows.Forms.ColumnHeader();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.updateTimer = new System.Windows.Forms.Timer();
            this.locatorBar = new System.Windows.Forms.ProgressBar();
            this.txLevelTxt = new System.Windows.Forms.Label();
            this.rssiLevelTxt = new System.Windows.Forms.Label();
            this.locateBtn = new System.Windows.Forms.Button();
            this.tagToLocate = new System.Windows.Forms.TextBox();
            this.maskLabel = new System.Windows.Forms.Label();
            this.lengthUD = new System.Windows.Forms.NumericUpDown();
            this.startUD = new System.Windows.Forms.NumericUpDown();
            this.bankCB = new System.Windows.Forms.ComboBox();
            this.tagListView = new NurSample.NurTagListView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabEasy = new System.Windows.Forms.TabPage();
            this.easyLocateButton = new System.Windows.Forms.Button();
            this.tabAdvanced = new System.Windows.Forms.TabPage();
            this.advLocateButton = new System.Windows.Forms.Button();
            this.pickTagButton = new System.Windows.Forms.Button();
            this.presetListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.startLabel = new System.Windows.Forms.Label();
            this.bankLabel = new System.Windows.Forms.Label();
            this.tabLocator = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabEasy.SuspendLayout();
            this.tabAdvanced.SuspendLayout();
            this.tabLocator.SuspendLayout();
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
            this.rssiHeader.Width = 50;
            // 
            // refreshBtn
            // 
            this.refreshBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.refreshBtn.Location = new System.Drawing.Point(3, 257);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(110, 30);
            this.refreshBtn.TabIndex = 18;
            this.refreshBtn.Text = "Refresh List";
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 20);
            this.label1.Text = "Select Tag to locate";
            // 
            // updateTimer
            // 
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // locatorBar
            // 
            this.locatorBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.locatorBar.Location = new System.Drawing.Point(3, 31);
            this.locatorBar.Name = "locatorBar";
            this.locatorBar.Size = new System.Drawing.Size(226, 20);
            // 
            // txLevelTxt
            // 
            this.txLevelTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txLevelTxt.Location = new System.Drawing.Point(3, 214);
            this.txLevelTxt.Name = "txLevelTxt";
            this.txLevelTxt.Size = new System.Drawing.Size(226, 20);
            this.txLevelTxt.Text = "txLevelTxt";
            // 
            // rssiLevelTxt
            // 
            this.rssiLevelTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rssiLevelTxt.Location = new System.Drawing.Point(3, 234);
            this.rssiLevelTxt.Name = "rssiLevelTxt";
            this.rssiLevelTxt.Size = new System.Drawing.Size(226, 20);
            this.rssiLevelTxt.Text = "rssiLevelTxt";
            // 
            // locateBtn
            // 
            this.locateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.locateBtn.Location = new System.Drawing.Point(3, 257);
            this.locateBtn.Name = "locateBtn";
            this.locateBtn.Size = new System.Drawing.Size(226, 30);
            this.locateBtn.TabIndex = 21;
            this.locateBtn.Text = "Locate";
            this.locateBtn.Click += new System.EventHandler(this.locateBtn_Click);
            // 
            // tagToLocate
            // 
            this.tagToLocate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tagToLocate.Location = new System.Drawing.Point(3, 76);
            this.tagToLocate.Name = "tagToLocate";
            this.tagToLocate.Size = new System.Drawing.Size(226, 23);
            this.tagToLocate.TabIndex = 22;
            this.tagToLocate.Text = "tagToLocate";
            // 
            // maskLabel
            // 
            this.maskLabel.Location = new System.Drawing.Point(3, 53);
            this.maskLabel.Name = "maskLabel";
            this.maskLabel.Size = new System.Drawing.Size(226, 20);
            this.maskLabel.Text = "Mask:";
            // 
            // lengthUD
            // 
            this.lengthUD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lengthUD.Location = new System.Drawing.Point(157, 26);
            this.lengthUD.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.lengthUD.Name = "lengthUD";
            this.lengthUD.Size = new System.Drawing.Size(72, 24);
            this.lengthUD.TabIndex = 34;
            // 
            // startUD
            // 
            this.startUD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startUD.Location = new System.Drawing.Point(79, 26);
            this.startUD.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.startUD.Name = "startUD";
            this.startUD.Size = new System.Drawing.Size(72, 24);
            this.startUD.TabIndex = 33;
            this.startUD.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // bankCB
            // 
            this.bankCB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bankCB.Items.Add("Reserved");
            this.bankCB.Items.Add("EPC");
            this.bankCB.Items.Add("TID");
            this.bankCB.Items.Add("User");
            this.bankCB.Location = new System.Drawing.Point(3, 27);
            this.bankCB.Name = "bankCB";
            this.bankCB.Size = new System.Drawing.Size(70, 23);
            this.bankCB.TabIndex = 32;
            // 
            // tagListView
            // 
            this.tagListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tagListView.Location = new System.Drawing.Point(3, 26);
            this.tagListView.Name = "tagListView";
            this.tagListView.Size = new System.Drawing.Size(226, 226);
            this.tagListView.TabIndex = 19;
            this.tagListView.Click += new System.EventHandler(this.tagListView_SelectedTagChanged);
            this.tagListView.SelectedTagChanged += new System.EventHandler(this.tagListView_SelectedTagChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabEasy);
            this.tabControl1.Controls.Add(this.tabAdvanced);
            this.tabControl1.Controls.Add(this.tabLocator);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 320);
            this.tabControl1.TabIndex = 40;
            // 
            // tabEasy
            // 
            this.tabEasy.Controls.Add(this.easyLocateButton);
            this.tabEasy.Controls.Add(this.label1);
            this.tabEasy.Controls.Add(this.refreshBtn);
            this.tabEasy.Controls.Add(this.tagListView);
            this.tabEasy.Location = new System.Drawing.Point(4, 25);
            this.tabEasy.Name = "tabEasy";
            this.tabEasy.Size = new System.Drawing.Size(232, 291);
            this.tabEasy.Text = "Easy";
            // 
            // easyLocateButton
            // 
            this.easyLocateButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.easyLocateButton.Location = new System.Drawing.Point(119, 257);
            this.easyLocateButton.Name = "easyLocateButton";
            this.easyLocateButton.Size = new System.Drawing.Size(110, 30);
            this.easyLocateButton.TabIndex = 40;
            this.easyLocateButton.Text = "Locate";
            this.easyLocateButton.Click += new System.EventHandler(this.locateBtn_Click);
            // 
            // tabAdvanced
            // 
            this.tabAdvanced.Controls.Add(this.advLocateButton);
            this.tabAdvanced.Controls.Add(this.pickTagButton);
            this.tabAdvanced.Controls.Add(this.presetListBox);
            this.tabAdvanced.Controls.Add(this.label2);
            this.tabAdvanced.Controls.Add(this.lengthLabel);
            this.tabAdvanced.Controls.Add(this.maskLabel);
            this.tabAdvanced.Controls.Add(this.tagToLocate);
            this.tabAdvanced.Controls.Add(this.lengthUD);
            this.tabAdvanced.Controls.Add(this.startLabel);
            this.tabAdvanced.Controls.Add(this.startUD);
            this.tabAdvanced.Controls.Add(this.bankLabel);
            this.tabAdvanced.Controls.Add(this.bankCB);
            this.tabAdvanced.Location = new System.Drawing.Point(4, 25);
            this.tabAdvanced.Name = "tabAdvanced";
            this.tabAdvanced.Size = new System.Drawing.Size(232, 291);
            this.tabAdvanced.Text = "Advanced";
            // 
            // advLocateButton
            // 
            this.advLocateButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.advLocateButton.Location = new System.Drawing.Point(119, 257);
            this.advLocateButton.Name = "advLocateButton";
            this.advLocateButton.Size = new System.Drawing.Size(110, 30);
            this.advLocateButton.TabIndex = 42;
            this.advLocateButton.Text = "Locate";
            this.advLocateButton.Click += new System.EventHandler(this.locateBtn_Click);
            // 
            // pickTagButton
            // 
            this.pickTagButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pickTagButton.Location = new System.Drawing.Point(3, 257);
            this.pickTagButton.Name = "pickTagButton";
            this.pickTagButton.Size = new System.Drawing.Size(110, 30);
            this.pickTagButton.TabIndex = 41;
            this.pickTagButton.Text = "Read Tag";
            // 
            // presetListBox
            // 
            this.presetListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.presetListBox.Location = new System.Drawing.Point(3, 125);
            this.presetListBox.Name = "presetListBox";
            this.presetListBox.Size = new System.Drawing.Size(226, 130);
            this.presetListBox.TabIndex = 38;
            this.presetListBox.SelectedIndexChanged += new System.EventHandler(this.presetListBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 20);
            this.label2.Text = "Preset list:";
            // 
            // lengthLabel
            // 
            this.lengthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lengthLabel.Location = new System.Drawing.Point(157, 3);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(72, 20);
            this.lengthLabel.Text = "Length [b]";
            // 
            // startLabel
            // 
            this.startLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startLabel.Location = new System.Drawing.Point(79, 3);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(72, 20);
            this.startLabel.Text = "Start [b]";
            // 
            // bankLabel
            // 
            this.bankLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bankLabel.Location = new System.Drawing.Point(3, 3);
            this.bankLabel.Name = "bankLabel";
            this.bankLabel.Size = new System.Drawing.Size(70, 20);
            this.bankLabel.Text = "Bank";
            // 
            // tabLocator
            // 
            this.tabLocator.Controls.Add(this.txLevelTxt);
            this.tabLocator.Controls.Add(this.locatorBar);
            this.tabLocator.Controls.Add(this.locateBtn);
            this.tabLocator.Controls.Add(this.rssiLevelTxt);
            this.tabLocator.Location = new System.Drawing.Point(4, 25);
            this.tabLocator.Name = "tabLocator";
            this.tabLocator.Size = new System.Drawing.Size(232, 291);
            this.tabLocator.Text = "Locator";
            // 
            // Locator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl1);
            this.Name = "Locator";
            this.Size = new System.Drawing.Size(240, 320);
            this.tabControl1.ResumeLayout(false);
            this.tabEasy.ResumeLayout(false);
            this.tabAdvanced.ResumeLayout(false);
            this.tabLocator.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private NurTagListView tagListView;
        private System.Windows.Forms.ColumnHeader epcHeader;
        private System.Windows.Forms.ColumnHeader rssiHeader;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.ProgressBar locatorBar;
        private System.Windows.Forms.Label txLevelTxt;
        private System.Windows.Forms.Label rssiLevelTxt;
        private System.Windows.Forms.Button locateBtn;
        private System.Windows.Forms.TextBox tagToLocate;
        private System.Windows.Forms.Label maskLabel;
        private System.Windows.Forms.NumericUpDown lengthUD;
        private System.Windows.Forms.NumericUpDown startUD;
        private System.Windows.Forms.ComboBox bankCB;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabEasy;
        private System.Windows.Forms.TabPage tabAdvanced;
        private System.Windows.Forms.Label lengthLabel;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.Label bankLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox presetListBox;
        private System.Windows.Forms.TabPage tabLocator;
        private System.Windows.Forms.Button easyLocateButton;
        private System.Windows.Forms.Button advLocateButton;
        private System.Windows.Forms.Button pickTagButton;
    }
}
