namespace NurSample
{
    partial class NXP_EasAlarm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.accessPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.setBtn = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            this.alarmButton = new System.Windows.Forms.Button();
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
            this.refreshBtn.Location = new System.Drawing.Point(165, 1);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(72, 20);
            this.refreshBtn.TabIndex = 21;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // targetEpcTextBox
            // 
            this.targetEpcTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.targetEpcTextBox.Location = new System.Drawing.Point(3, 154);
            this.targetEpcTextBox.Name = "targetEpcTextBox";
            this.targetEpcTextBox.Size = new System.Drawing.Size(234, 23);
            this.targetEpcTextBox.TabIndex = 19;
            this.targetEpcTextBox.Text = "Scan some tags for Tag list";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 20);
            this.label2.Text = "2) Enter AccPwd (Hex)";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.Text = "1) Select Tag from List";
            // 
            // accessPasswordTextBox
            // 
            this.accessPasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.accessPasswordTextBox.Location = new System.Drawing.Point(165, 127);
            this.accessPasswordTextBox.Name = "accessPasswordTextBox";
            this.accessPasswordTextBox.Size = new System.Drawing.Size(72, 23);
            this.accessPasswordTextBox.TabIndex = 25;
            this.accessPasswordTextBox.Text = "acc password";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(3, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(234, 20);
            this.label3.Text = "3) Set / Reset NXP Read Protection";
            // 
            // setBtn
            // 
            this.setBtn.Location = new System.Drawing.Point(3, 203);
            this.setBtn.Name = "setBtn";
            this.setBtn.Size = new System.Drawing.Size(110, 23);
            this.setBtn.TabIndex = 28;
            this.setBtn.Text = "SET";
            this.setBtn.Click += new System.EventHandler(this.setBtn_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resetBtn.Location = new System.Drawing.Point(127, 203);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(110, 23);
            this.resetBtn.TabIndex = 29;
            this.resetBtn.Text = "RESET";
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // alarmButton
            // 
            this.alarmButton.Location = new System.Drawing.Point(49, 1);
            this.alarmButton.Name = "alarmButton";
            this.alarmButton.Size = new System.Drawing.Size(110, 20);
            this.alarmButton.TabIndex = 33;
            this.alarmButton.Text = "ALARM";
            this.alarmButton.Click += new System.EventHandler(this.alarmButton_Click);
            // 
            // nxpTagListView
            // 
            this.nxpTagListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nxpTagListView.Location = new System.Drawing.Point(3, 24);
            this.nxpTagListView.Name = "nxpTagListView";
            this.nxpTagListView.Size = new System.Drawing.Size(234, 98);
            this.nxpTagListView.TabIndex = 22;
            this.nxpTagListView.SelectedTagChanged += new System.EventHandler(this.nxpTagListView_SelectedTagChanged);
            // 
            // NXP_EasAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.alarmButton);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.setBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.accessPasswordTextBox);
            this.Controls.Add(this.nxpTagListView);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.targetEpcTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NXP_EasAlarm";
            this.Size = new System.Drawing.Size(240, 320);
            this.ResumeLayout(false);

        }

        #endregion

        private NurTagListView nxpTagListView;
        private System.Windows.Forms.ColumnHeader epcHeader;
        private System.Windows.Forms.ColumnHeader rssiHeader;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.TextBox targetEpcTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox accessPasswordTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button setBtn;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Button alarmButton;
    }
}
