namespace NurSample
{
    partial class NXP_ProductStatusFlag
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
            this.targetEpcTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.setBtn = new System.Windows.Forms.Button();
            this.psfInventoryButton = new System.Windows.Forms.Button();
            this.configurationLabel = new System.Windows.Forms.Label();
            this.nxpTagListView = new NurSample.NurTagListView();
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
            this.refreshBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshBtn.Location = new System.Drawing.Point(127, 3);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(110, 23);
            this.refreshBtn.TabIndex = 21;
            this.refreshBtn.Text = "List Tags";
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // targetEpcTextBox
            // 
            this.targetEpcTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.targetEpcTextBox.Location = new System.Drawing.Point(3, 136);
            this.targetEpcTextBox.Name = "targetEpcTextBox";
            this.targetEpcTextBox.Size = new System.Drawing.Size(173, 23);
            this.targetEpcTextBox.TabIndex = 19;
            this.targetEpcTextBox.Text = "Scan some tags for Tag list";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.Text = "1) Select a Tag";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(3, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(234, 20);
            this.label3.Text = "2) Toggle PSF bit, 3) Start Inventory";
            // 
            // setBtn
            // 
            this.setBtn.Location = new System.Drawing.Point(3, 185);
            this.setBtn.Name = "setBtn";
            this.setBtn.Size = new System.Drawing.Size(110, 23);
            this.setBtn.TabIndex = 28;
            this.setBtn.Text = "Toggle PSF";
            this.setBtn.Click += new System.EventHandler(this.setBtn_Click);
            // 
            // psfInventoryButton
            // 
            this.psfInventoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.psfInventoryButton.Location = new System.Drawing.Point(127, 185);
            this.psfInventoryButton.Name = "psfInventoryButton";
            this.psfInventoryButton.Size = new System.Drawing.Size(110, 23);
            this.psfInventoryButton.TabIndex = 33;
            this.psfInventoryButton.Text = "Start PSF stream";
            this.psfInventoryButton.Click += new System.EventHandler(this.psfInventoryButton_Click);
            // 
            // configurationLabel
            // 
            this.configurationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.configurationLabel.Location = new System.Drawing.Point(182, 139);
            this.configurationLabel.Name = "configurationLabel";
            this.configurationLabel.Size = new System.Drawing.Size(55, 20);
            this.configurationLabel.Text = "- - -";
            this.configurationLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // nxpTagListView
            // 
            this.nxpTagListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nxpTagListView.Location = new System.Drawing.Point(3, 32);
            this.nxpTagListView.Name = "nxpTagListView";
            this.nxpTagListView.Size = new System.Drawing.Size(234, 98);
            this.nxpTagListView.TabIndex = 22;
            this.nxpTagListView.Click += new System.EventHandler(this.nxpTagListView_SelectedTagChanged);
            this.nxpTagListView.SelectedTagChanged += new System.EventHandler(this.nxpTagListView_SelectedTagChanged);
            // 
            // NXP_ProductStatusFlag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.configurationLabel);
            this.Controls.Add(this.psfInventoryButton);
            this.Controls.Add(this.setBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nxpTagListView);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.targetEpcTextBox);
            this.Controls.Add(this.label1);
            this.Name = "NXP_ProductStatusFlag";
            this.Size = new System.Drawing.Size(240, 320);
            this.ResumeLayout(false);

        }

        #endregion

        private NurTagListView nxpTagListView;
        private System.Windows.Forms.ColumnHeader epcHeader;
        private System.Windows.Forms.ColumnHeader rssiHeader;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.TextBox targetEpcTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button setBtn;
        private System.Windows.Forms.Button psfInventoryButton;
        private System.Windows.Forms.Label configurationLabel;
    }
}
