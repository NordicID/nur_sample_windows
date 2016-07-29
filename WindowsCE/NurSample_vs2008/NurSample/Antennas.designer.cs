namespace NurSample
{
    partial class Antennas
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
            this.physicalAntennasTab = new System.Windows.Forms.TabPage();
            this.physicalAntennasLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.selectedAntennaComboBox = new System.Windows.Forms.ComboBox();
            this.refreshPhysicalAntennasButton = new System.Windows.Forms.Button();
            this.physicalAntennasListView = new System.Windows.Forms.ListView();
            this.idColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.antennaColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.enabledColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.rfpColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.tuneTab = new System.Windows.Forms.TabPage();
            this.enTuneEvents_Label = new System.Windows.Forms.Label();
            this.enTuneEvents_CheckBox = new System.Windows.Forms.CheckBox();
            this.autoTuneTreshold_Label = new System.Windows.Forms.Label();
            this.autoTuneTreshold_UpDown = new System.Windows.Forms.NumericUpDown();
            this.autoTune_Label = new System.Windows.Forms.Label();
            this.autoTune_ComboBox = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.physicalAntennasTab.SuspendLayout();
            this.tuneTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.physicalAntennasTab);
            this.tabControl1.Controls.Add(this.tuneTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(389, 297);
            this.tabControl1.TabIndex = 0;
            // 
            // physicalAntennasTab
            // 
            this.physicalAntennasTab.Controls.Add(this.physicalAntennasLabel);
            this.physicalAntennasTab.Controls.Add(this.label2);
            this.physicalAntennasTab.Controls.Add(this.selectedAntennaComboBox);
            this.physicalAntennasTab.Controls.Add(this.refreshPhysicalAntennasButton);
            this.physicalAntennasTab.Controls.Add(this.physicalAntennasListView);
            this.physicalAntennasTab.Location = new System.Drawing.Point(4, 25);
            this.physicalAntennasTab.Name = "physicalAntennasTab";
            this.physicalAntennasTab.Size = new System.Drawing.Size(381, 268);
            this.physicalAntennasTab.Text = "Physical Antennas";
            // 
            // physicalAntennasLabel
            // 
            this.physicalAntennasLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.physicalAntennasLabel.Location = new System.Drawing.Point(3, 58);
            this.physicalAntennasLabel.Name = "physicalAntennasLabel";
            this.physicalAntennasLabel.Size = new System.Drawing.Size(375, 20);
            this.physicalAntennasLabel.Text = "Physical Antennas";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(375, 20);
            this.label2.Text = "Selected Antanne";
            // 
            // selectedAntennaComboBox
            // 
            this.selectedAntennaComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedAntennaComboBox.Location = new System.Drawing.Point(3, 26);
            this.selectedAntennaComboBox.Name = "selectedAntennaComboBox";
            this.selectedAntennaComboBox.Size = new System.Drawing.Size(375, 23);
            this.selectedAntennaComboBox.TabIndex = 11;
            this.selectedAntennaComboBox.SelectedIndexChanged += new System.EventHandler(this.selectedAntennaComboBox_SelectedIndexChanged);
            // 
            // refreshPhysicalAntennasButton
            // 
            this.refreshPhysicalAntennasButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshPhysicalAntennasButton.Location = new System.Drawing.Point(3, 242);
            this.refreshPhysicalAntennasButton.Name = "refreshPhysicalAntennasButton";
            this.refreshPhysicalAntennasButton.Size = new System.Drawing.Size(375, 23);
            this.refreshPhysicalAntennasButton.TabIndex = 10;
            this.refreshPhysicalAntennasButton.Text = "Refresh List";
            this.refreshPhysicalAntennasButton.Click += new System.EventHandler(this.refreshPhysicalAntennasButton_Click);
            // 
            // physicalAntennasListView
            // 
            this.physicalAntennasListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.physicalAntennasListView.CheckBoxes = true;
            this.physicalAntennasListView.Columns.Add(this.idColumnHeader);
            this.physicalAntennasListView.Columns.Add(this.antennaColumnHeader);
            this.physicalAntennasListView.Columns.Add(this.enabledColumnHeader);
            this.physicalAntennasListView.Columns.Add(this.rfpColumnHeader);
            this.physicalAntennasListView.FullRowSelect = true;
            this.physicalAntennasListView.Location = new System.Drawing.Point(3, 81);
            this.physicalAntennasListView.Name = "physicalAntennasListView";
            this.physicalAntennasListView.Size = new System.Drawing.Size(375, 155);
            this.physicalAntennasListView.TabIndex = 9;
            this.physicalAntennasListView.View = System.Windows.Forms.View.Details;
            this.physicalAntennasListView.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.physicalAntennasListView_ItemCheck);
            // 
            // idColumnHeader
            // 
            this.idColumnHeader.Text = "#";
            this.idColumnHeader.Width = 30;
            // 
            // antennaColumnHeader
            // 
            this.antennaColumnHeader.Text = "Antenna";
            this.antennaColumnHeader.Width = 60;
            // 
            // enabledColumnHeader
            // 
            this.enabledColumnHeader.Text = "Enabled";
            this.enabledColumnHeader.Width = 60;
            // 
            // rfpColumnHeader
            // 
            this.rfpColumnHeader.Text = "Reflected power";
            this.rfpColumnHeader.Width = 60;
            // 
            // tuneTab
            // 
            this.tuneTab.Controls.Add(this.enTuneEvents_Label);
            this.tuneTab.Controls.Add(this.enTuneEvents_CheckBox);
            this.tuneTab.Controls.Add(this.autoTuneTreshold_Label);
            this.tuneTab.Controls.Add(this.autoTuneTreshold_UpDown);
            this.tuneTab.Controls.Add(this.autoTune_Label);
            this.tuneTab.Controls.Add(this.autoTune_ComboBox);
            this.tuneTab.Location = new System.Drawing.Point(4, 25);
            this.tuneTab.Name = "tuneTab";
            this.tuneTab.Size = new System.Drawing.Size(381, 268);
            this.tuneTab.Text = "Antena Tuning";
            // 
            // enTuneEvents_Label
            // 
            this.enTuneEvents_Label.Location = new System.Drawing.Point(3, 62);
            this.enTuneEvents_Label.Name = "enTuneEvents_Label";
            this.enTuneEvents_Label.Size = new System.Drawing.Size(100, 20);
            this.enTuneEvents_Label.Text = "Tune Events";
            this.enTuneEvents_Label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // enTuneEvents_CheckBox
            // 
            this.enTuneEvents_CheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.enTuneEvents_CheckBox.Location = new System.Drawing.Point(109, 59);
            this.enTuneEvents_CheckBox.Name = "enTuneEvents_CheckBox";
            this.enTuneEvents_CheckBox.Size = new System.Drawing.Size(269, 20);
            this.enTuneEvents_CheckBox.TabIndex = 40;
            this.enTuneEvents_CheckBox.Text = "Enable";
            this.enTuneEvents_CheckBox.CheckStateChanged += new System.EventHandler(this.enTuneEvents_CheckBox_CheckedChanged);
            // 
            // autoTuneTreshold_Label
            // 
            this.autoTuneTreshold_Label.Location = new System.Drawing.Point(3, 35);
            this.autoTuneTreshold_Label.Name = "autoTuneTreshold_Label";
            this.autoTuneTreshold_Label.Size = new System.Drawing.Size(100, 20);
            this.autoTuneTreshold_Label.Text = "Threshold";
            this.autoTuneTreshold_Label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // autoTuneTreshold_UpDown
            // 
            this.autoTuneTreshold_UpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.autoTuneTreshold_UpDown.Location = new System.Drawing.Point(109, 33);
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
            this.autoTuneTreshold_UpDown.Size = new System.Drawing.Size(269, 24);
            this.autoTuneTreshold_UpDown.TabIndex = 39;
            this.autoTuneTreshold_UpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.autoTuneTreshold_UpDown.ValueChanged += new System.EventHandler(this.autoTuneTreshold_UpDown_ValueChanged);
            // 
            // autoTune_Label
            // 
            this.autoTune_Label.Location = new System.Drawing.Point(3, 9);
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
            this.autoTune_ComboBox.Location = new System.Drawing.Point(109, 6);
            this.autoTune_ComboBox.Name = "autoTune_ComboBox";
            this.autoTune_ComboBox.Size = new System.Drawing.Size(269, 23);
            this.autoTune_ComboBox.TabIndex = 38;
            this.autoTune_ComboBox.SelectedIndexChanged += new System.EventHandler(this.autoTune_ComboBox_SelectedIndexChanged);
            // 
            // Antennas
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.tabControl1);
            this.Name = "Antennas";
            this.Size = new System.Drawing.Size(389, 297);
            this.tabControl1.ResumeLayout(false);
            this.physicalAntennasTab.ResumeLayout(false);
            this.tuneTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage physicalAntennasTab;
        private System.Windows.Forms.TabPage tuneTab;
        private System.Windows.Forms.ComboBox selectedAntennaComboBox;
        private System.Windows.Forms.Button refreshPhysicalAntennasButton;
        private System.Windows.Forms.ListView physicalAntennasListView;
        private System.Windows.Forms.Label enTuneEvents_Label;
        private System.Windows.Forms.CheckBox enTuneEvents_CheckBox;
        private System.Windows.Forms.Label autoTuneTreshold_Label;
        private System.Windows.Forms.NumericUpDown autoTuneTreshold_UpDown;
        private System.Windows.Forms.Label autoTune_Label;
        private System.Windows.Forms.ComboBox autoTune_ComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label physicalAntennasLabel;
        private System.Windows.Forms.ColumnHeader idColumnHeader;
        private System.Windows.Forms.ColumnHeader antennaColumnHeader;
        private System.Windows.Forms.ColumnHeader enabledColumnHeader;
        private System.Windows.Forms.ColumnHeader rfpColumnHeader;

    }
}
