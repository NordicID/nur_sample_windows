namespace NurSample
{
    partial class Connection
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
            this.connectionTLP = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.conStatusDesc = new System.Windows.Forms.Label();
            this.socketPortNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.serialCombo = new System.Windows.Forms.ComboBox();
            this.usbCombo = new System.Windows.Forms.ComboBox();
            this.useTcpipPort = new System.Windows.Forms.Label();
            this.useTcpipHost = new System.Windows.Forms.Label();
            this.useSocketRadioBox = new System.Windows.Forms.RadioButton();
            this.useSerialDevice = new System.Windows.Forms.Label();
            this.useSerialRadioBox = new System.Windows.Forms.RadioButton();
            this.useUsbRadioBox = new System.Windows.Forms.RadioButton();
            this.useUsbDevice = new System.Windows.Forms.Label();
            this.useUsbAutoDesc = new System.Windows.Forms.Label();
            this.conTitle = new System.Windows.Forms.Label();
            this.connectBtn = new System.Windows.Forms.Button();
            this.conStatus = new System.Windows.Forms.Label();
            this.socketAddressTextBox = new System.Windows.Forms.TextBox();
            this.useUsbAutoRadioBox = new System.Windows.Forms.RadioButton();
            this.useLatestRadioBox = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.connectionTLP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.socketPortNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // connectionTLP
            // 
            this.connectionTLP.AutoSize = true;
            this.connectionTLP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.connectionTLP.ColumnCount = 4;
            this.connectionTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.connectionTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.connectionTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.connectionTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 171F));
            this.connectionTLP.Controls.Add(this.label1, 2, 1);
            this.connectionTLP.Controls.Add(this.conStatusDesc, 0, 8);
            this.connectionTLP.Controls.Add(this.socketPortNumericUpDown, 2, 6);
            this.connectionTLP.Controls.Add(this.serialCombo, 2, 4);
            this.connectionTLP.Controls.Add(this.usbCombo, 2, 3);
            this.connectionTLP.Controls.Add(this.useTcpipPort, 1, 6);
            this.connectionTLP.Controls.Add(this.useTcpipHost, 1, 5);
            this.connectionTLP.Controls.Add(this.useSocketRadioBox, 0, 5);
            this.connectionTLP.Controls.Add(this.useSerialDevice, 1, 4);
            this.connectionTLP.Controls.Add(this.useSerialRadioBox, 0, 4);
            this.connectionTLP.Controls.Add(this.useUsbRadioBox, 0, 3);
            this.connectionTLP.Controls.Add(this.useUsbDevice, 1, 3);
            this.connectionTLP.Controls.Add(this.useUsbAutoDesc, 2, 2);
            this.connectionTLP.Controls.Add(this.conTitle, 0, 0);
            this.connectionTLP.Controls.Add(this.connectBtn, 2, 9);
            this.connectionTLP.Controls.Add(this.conStatus, 0, 7);
            this.connectionTLP.Controls.Add(this.socketAddressTextBox, 2, 5);
            this.connectionTLP.Controls.Add(this.useUsbAutoRadioBox, 0, 2);
            this.connectionTLP.Controls.Add(this.useLatestRadioBox, 0, 1);
            this.connectionTLP.Controls.Add(this.label2, 3, 5);
            this.connectionTLP.Controls.Add(this.label3, 3, 6);
            this.connectionTLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectionTLP.Location = new System.Drawing.Point(0, 0);
            this.connectionTLP.Margin = new System.Windows.Forms.Padding(0);
            this.connectionTLP.Name = "connectionTLP";
            this.connectionTLP.Padding = new System.Windows.Forms.Padding(10);
            this.connectionTLP.RowCount = 11;
            this.connectionTLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.connectionTLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.connectionTLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.connectionTLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.connectionTLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.connectionTLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.connectionTLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.connectionTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.connectionTLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.connectionTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.connectionTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.connectionTLP.Size = new System.Drawing.Size(435, 340);
            this.connectionTLP.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.connectionTLP.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(132, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "Connect using the most recent connection";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // conStatusDesc
            // 
            this.conStatusDesc.AutoSize = true;
            this.connectionTLP.SetColumnSpan(this.conStatusDesc, 3);
            this.conStatusDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conStatusDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conStatusDesc.Location = new System.Drawing.Point(10, 240);
            this.conStatusDesc.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.conStatusDesc.Name = "conStatusDesc";
            this.conStatusDesc.Size = new System.Drawing.Size(244, 20);
            this.conStatusDesc.TabIndex = 22;
            this.conStatusDesc.Text = "conStatusDesc";
            this.conStatusDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // socketPortNumericUpDown
            // 
            this.socketPortNumericUpDown.Location = new System.Drawing.Point(132, 187);
            this.socketPortNumericUpDown.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.socketPortNumericUpDown.Name = "socketPortNumericUpDown";
            this.socketPortNumericUpDown.Size = new System.Drawing.Size(119, 20);
            this.socketPortNumericUpDown.TabIndex = 8;
            this.socketPortNumericUpDown.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // serialCombo
            // 
            this.connectionTLP.SetColumnSpan(this.serialCombo, 2);
            this.serialCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serialCombo.FormattingEnabled = true;
            this.serialCombo.Location = new System.Drawing.Point(132, 128);
            this.serialCombo.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.serialCombo.Name = "serialCombo";
            this.serialCombo.Size = new System.Drawing.Size(244, 21);
            this.serialCombo.TabIndex = 5;
            this.serialCombo.Click += new System.EventHandler(this.serialCombo_Click);
            // 
            // usbCombo
            // 
            this.connectionTLP.SetColumnSpan(this.usbCombo, 2);
            this.usbCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.usbCombo.FormattingEnabled = true;
            this.usbCombo.Location = new System.Drawing.Point(132, 95);
            this.usbCombo.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.usbCombo.Name = "usbCombo";
            this.usbCombo.Size = new System.Drawing.Size(244, 21);
            this.usbCombo.TabIndex = 3;
            this.usbCombo.Click += new System.EventHandler(this.usbCombo_Click);
            // 
            // useTcpipPort
            // 
            this.useTcpipPort.AutoSize = true;
            this.useTcpipPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.useTcpipPort.Location = new System.Drawing.Point(80, 184);
            this.useTcpipPort.Name = "useTcpipPort";
            this.useTcpipPort.Size = new System.Drawing.Size(46, 26);
            this.useTcpipPort.TabIndex = 10;
            this.useTcpipPort.Text = "Port:";
            this.useTcpipPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // useTcpipHost
            // 
            this.useTcpipHost.AutoSize = true;
            this.useTcpipHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.useTcpipHost.Location = new System.Drawing.Point(80, 161);
            this.useTcpipHost.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.useTcpipHost.Name = "useTcpipHost";
            this.useTcpipHost.Size = new System.Drawing.Size(46, 20);
            this.useTcpipHost.TabIndex = 4;
            this.useTcpipHost.Text = "Host:";
            this.useTcpipHost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // useSocketRadioBox
            // 
            this.useSocketRadioBox.AutoSize = true;
            this.useSocketRadioBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.useSocketRadioBox.Location = new System.Drawing.Point(13, 161);
            this.useSocketRadioBox.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.useSocketRadioBox.Name = "useSocketRadioBox";
            this.useSocketRadioBox.Size = new System.Drawing.Size(61, 20);
            this.useSocketRadioBox.TabIndex = 6;
            this.useSocketRadioBox.Text = "TCP/IP";
            this.useSocketRadioBox.UseVisualStyleBackColor = true;
            this.useSocketRadioBox.CheckedChanged += new System.EventHandler(this.updateControls_CheckedChanged);
            // 
            // useSerialDevice
            // 
            this.useSerialDevice.AutoSize = true;
            this.useSerialDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.useSerialDevice.Location = new System.Drawing.Point(80, 128);
            this.useSerialDevice.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.useSerialDevice.Name = "useSerialDevice";
            this.useSerialDevice.Size = new System.Drawing.Size(46, 21);
            this.useSerialDevice.TabIndex = 5;
            this.useSerialDevice.Text = "Serial:";
            this.useSerialDevice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // useSerialRadioBox
            // 
            this.useSerialRadioBox.AutoSize = true;
            this.useSerialRadioBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.useSerialRadioBox.Location = new System.Drawing.Point(13, 128);
            this.useSerialRadioBox.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.useSerialRadioBox.Name = "useSerialRadioBox";
            this.useSerialRadioBox.Size = new System.Drawing.Size(61, 21);
            this.useSerialRadioBox.TabIndex = 4;
            this.useSerialRadioBox.Text = "Serial";
            this.useSerialRadioBox.UseVisualStyleBackColor = true;
            this.useSerialRadioBox.CheckedChanged += new System.EventHandler(this.updateControls_CheckedChanged);
            // 
            // useUsbRadioBox
            // 
            this.useUsbRadioBox.AutoSize = true;
            this.useUsbRadioBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.useUsbRadioBox.Location = new System.Drawing.Point(13, 95);
            this.useUsbRadioBox.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.useUsbRadioBox.Name = "useUsbRadioBox";
            this.useUsbRadioBox.Size = new System.Drawing.Size(61, 21);
            this.useUsbRadioBox.TabIndex = 2;
            this.useUsbRadioBox.Text = "USB";
            this.useUsbRadioBox.UseVisualStyleBackColor = true;
            this.useUsbRadioBox.CheckedChanged += new System.EventHandler(this.updateControls_CheckedChanged);
            // 
            // useUsbDevice
            // 
            this.useUsbDevice.AutoSize = true;
            this.useUsbDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.useUsbDevice.Location = new System.Drawing.Point(80, 95);
            this.useUsbDevice.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.useUsbDevice.Name = "useUsbDevice";
            this.useUsbDevice.Size = new System.Drawing.Size(46, 21);
            this.useUsbDevice.TabIndex = 3;
            this.useUsbDevice.Text = "Device:";
            this.useUsbDevice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // useUsbAutoDesc
            // 
            this.useUsbAutoDesc.AutoSize = true;
            this.connectionTLP.SetColumnSpan(this.useUsbAutoDesc, 2);
            this.useUsbAutoDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.useUsbAutoDesc.Location = new System.Drawing.Point(132, 66);
            this.useUsbAutoDesc.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.useUsbAutoDesc.Name = "useUsbAutoDesc";
            this.useUsbAutoDesc.Size = new System.Drawing.Size(290, 17);
            this.useUsbAutoDesc.TabIndex = 18;
            this.useUsbAutoDesc.Text = "Connects automatically via USB connection";
            this.useUsbAutoDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // conTitle
            // 
            this.conTitle.AutoSize = true;
            this.connectionTLP.SetColumnSpan(this.conTitle, 3);
            this.conTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conTitle.Location = new System.Drawing.Point(10, 10);
            this.conTitle.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.conTitle.Name = "conTitle";
            this.conTitle.Size = new System.Drawing.Size(244, 13);
            this.conTitle.TabIndex = 23;
            this.conTitle.Text = "Connection method";
            this.conTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // connectBtn
            // 
            this.connectionTLP.SetColumnSpan(this.connectBtn, 2);
            this.connectBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectBtn.Location = new System.Drawing.Point(132, 273);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(290, 54);
            this.connectBtn.TabIndex = 9;
            this.connectBtn.Text = "CONNECT";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // conStatus
            // 
            this.conStatus.AutoSize = true;
            this.connectionTLP.SetColumnSpan(this.conStatus, 3);
            this.conStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conStatus.Location = new System.Drawing.Point(10, 210);
            this.conStatus.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.conStatus.Name = "conStatus";
            this.conStatus.Size = new System.Drawing.Size(244, 25);
            this.conStatus.TabIndex = 25;
            this.conStatus.Text = "Connection status";
            this.conStatus.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // socketAddressTextBox
            // 
            this.socketAddressTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.socketAddressTextBox.Location = new System.Drawing.Point(132, 161);
            this.socketAddressTextBox.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.socketAddressTextBox.Name = "socketAddressTextBox";
            this.socketAddressTextBox.Size = new System.Drawing.Size(119, 20);
            this.socketAddressTextBox.TabIndex = 7;
            // 
            // useUsbAutoRadioBox
            // 
            this.useUsbAutoRadioBox.AutoSize = true;
            this.connectionTLP.SetColumnSpan(this.useUsbAutoRadioBox, 2);
            this.useUsbAutoRadioBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.useUsbAutoRadioBox.Location = new System.Drawing.Point(13, 66);
            this.useUsbAutoRadioBox.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.useUsbAutoRadioBox.Name = "useUsbAutoRadioBox";
            this.useUsbAutoRadioBox.Size = new System.Drawing.Size(113, 17);
            this.useUsbAutoRadioBox.TabIndex = 1;
            this.useUsbAutoRadioBox.Text = "USB auto connect";
            this.useUsbAutoRadioBox.UseVisualStyleBackColor = true;
            this.useUsbAutoRadioBox.CheckedChanged += new System.EventHandler(this.updateControls_CheckedChanged);
            // 
            // useLatestRadioBox
            // 
            this.useLatestRadioBox.AutoSize = true;
            this.connectionTLP.SetColumnSpan(this.useLatestRadioBox, 2);
            this.useLatestRadioBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.useLatestRadioBox.Location = new System.Drawing.Point(13, 37);
            this.useLatestRadioBox.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.useLatestRadioBox.Name = "useLatestRadioBox";
            this.useLatestRadioBox.Size = new System.Drawing.Size(113, 17);
            this.useLatestRadioBox.TabIndex = 0;
            this.useLatestRadioBox.Text = "Latest Connection";
            this.useLatestRadioBox.UseVisualStyleBackColor = true;
            this.useLatestRadioBox.CheckedChanged += new System.EventHandler(this.updateControls_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(257, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 32);
            this.label2.TabIndex = 27;
            this.label2.Text = "(IP address or name)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(257, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 26);
            this.label3.TabIndex = 28;
            this.label3.Text = "(default: 4333 )";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Connection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.connectionTLP);
            this.Name = "Connection";
            this.Size = new System.Drawing.Size(435, 340);
            this.Load += new System.EventHandler(this.Connection_Load);
            this.connectionTLP.ResumeLayout(false);
            this.connectionTLP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.socketPortNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel connectionTLP;
        private System.Windows.Forms.Label conStatusDesc;
        private System.Windows.Forms.NumericUpDown socketPortNumericUpDown;
        private System.Windows.Forms.ComboBox serialCombo;
        private System.Windows.Forms.ComboBox usbCombo;
        private System.Windows.Forms.Label useTcpipPort;
        private System.Windows.Forms.Label useTcpipHost;
        private System.Windows.Forms.RadioButton useSocketRadioBox;
        private System.Windows.Forms.Label useSerialDevice;
        private System.Windows.Forms.RadioButton useSerialRadioBox;
        private System.Windows.Forms.RadioButton useUsbRadioBox;
        private System.Windows.Forms.Label useUsbDevice;
        private System.Windows.Forms.Label useUsbAutoDesc;
        private System.Windows.Forms.Label conTitle;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Label conStatus;
        private System.Windows.Forms.TextBox socketAddressTextBox;
        private System.Windows.Forms.RadioButton useUsbAutoRadioBox;
        private System.Windows.Forms.RadioButton useLatestRadioBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

    }
}
