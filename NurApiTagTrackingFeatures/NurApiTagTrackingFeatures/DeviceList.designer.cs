namespace NurApiTagTrackingFeatures 
{
    partial class DeviceList
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
            this.components = new System.ComponentModel.Container();
            this.deviceView = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.port = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addrType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mac = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.altSerial = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ethVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nurAppVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textFilterData = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.comboFilterOp = new System.Windows.Forms.ComboBox();
            this.label44 = new System.Windows.Forms.Label();
            this.comboFilterType = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.connectBtn = new System.Windows.Forms.Button();
            this.beepBtn = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // deviceView
            // 
            this.deviceView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.ip,
            this.port,
            this.addrType,
            this.mode,
            this.status,
            this.mac,
            this.altSerial,
            this.ethVersion,
            this.nurAppVersion});
            this.tableLayoutPanel1.SetColumnSpan(this.deviceView, 4);
            this.deviceView.ContextMenuStrip = this.contextMenuStrip1;
            this.deviceView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deviceView.FullRowSelect = true;
            this.deviceView.GridLines = true;
            this.deviceView.HideSelection = false;
            this.deviceView.Location = new System.Drawing.Point(3, 92);
            this.deviceView.MultiSelect = false;
            this.deviceView.Name = "deviceView";
            this.deviceView.Size = new System.Drawing.Size(960, 152);
            this.deviceView.TabIndex = 0;
            this.deviceView.UseCompatibleStateImageBehavior = false;
            this.deviceView.View = System.Windows.Forms.View.Details;
            this.deviceView.SelectedIndexChanged += new System.EventHandler(this.deviceView_SelectedIndexChanged);
            this.deviceView.DoubleClick += new System.EventHandler(this.connectBtn_Click);
            // 
            // name
            // 
            this.name.Text = "Name";
            // 
            // ip
            // 
            this.ip.Text = "IP";
            // 
            // port
            // 
            this.port.Text = "Port";
            // 
            // addrType
            // 
            this.addrType.Text = "Addr Type";
            // 
            // mode
            // 
            this.mode.Text = "Mode";
            // 
            // status
            // 
            this.status.Text = "Status";
            // 
            // mac
            // 
            this.mac.Text = "MAC";
            // 
            // altSerial
            // 
            this.altSerial.Text = "Alt-Serial";
            // 
            // ethVersion
            // 
            this.ethVersion.Text = "EthApp Version";
            // 
            // nurAppVersion
            // 
            this.nurAppVersion.Text = "App Version";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshListToolStripMenuItem,
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem,
            this.beepToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(132, 92);
            // 
            // refreshListToolStripMenuItem
            // 
            this.refreshListToolStripMenuItem.Name = "refreshListToolStripMenuItem";
            this.refreshListToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.refreshListToolStripMenuItem.Text = "Refresh List";
            this.refreshListToolStripMenuItem.Click += new System.EventHandler(this.refreshListToolStripMenuItem_Click);
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // beepToolStripMenuItem
            // 
            this.beepToolStripMenuItem.Name = "beepToolStripMenuItem";
            this.beepToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.beepToolStripMenuItem.Text = "Beep";
            this.beepToolStripMenuItem.Click += new System.EventHandler(this.beepToolStripMenuItem_Click);
            // 
            // textFilterData
            // 
            this.textFilterData.Location = new System.Drawing.Point(412, 65);
            this.textFilterData.MaxLength = 16;
            this.textFilterData.Name = "textFilterData";
            this.textFilterData.Size = new System.Drawing.Size(134, 20);
            this.textFilterData.TabIndex = 60;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(412, 49);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(53, 13);
            this.label46.TabIndex = 59;
            this.label46.Text = "Filter data";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(285, 49);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(76, 13);
            this.label45.TabIndex = 58;
            this.label45.Text = "Filter operation";
            // 
            // comboFilterOp
            // 
            this.comboFilterOp.FormattingEnabled = true;
            this.comboFilterOp.Items.AddRange(new object[] {
            "Equal \t(=)",
            "Higher\t(>)",
            "Lower\t(<)"});
            this.comboFilterOp.Location = new System.Drawing.Point(285, 65);
            this.comboFilterOp.Name = "comboFilterOp";
            this.comboFilterOp.Size = new System.Drawing.Size(121, 21);
            this.comboFilterOp.TabIndex = 57;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(3, 49);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(52, 13);
            this.label44.TabIndex = 56;
            this.label44.Text = "Filter type";
            // 
            // comboFilterType
            // 
            this.comboFilterType.FormattingEnabled = true;
            this.comboFilterType.Items.AddRange(new object[] {
            "No filter",
            "MAC address (like: 0021ad0a0007)",
            "IP address (x.x.x.x)",
            "Version (numeric without decimal)",
            "Server Port (numeric)",
            "Address type (0=DHCP 1=Static)",
            "Mode (0=Server 1=Client)",
            "NUR version (numeric without decimal like: \'25\' = 2.5)",
            "Status (0=Disconnected 1=Connected)",
            "Name (Get devices where part of filter data string matches with device name)"});
            this.comboFilterType.Location = new System.Drawing.Point(3, 65);
            this.comboFilterType.Name = "comboFilterType";
            this.comboFilterType.Size = new System.Drawing.Size(276, 21);
            this.comboFilterType.TabIndex = 55;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textFilterData, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.deviceView, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label45, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboFilterOp, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label46, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboFilterType, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label44, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(966, 247);
            this.tableLayoutPanel1.TabIndex = 61;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 4);
            this.flowLayoutPanel1.Controls.Add(this.refreshBtn);
            this.flowLayoutPanel1.Controls.Add(this.connectBtn);
            this.flowLayoutPanel1.Controls.Add(this.beepBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(966, 29);
            this.flowLayoutPanel1.TabIndex = 61;
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(3, 3);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(75, 23);
            this.refreshBtn.TabIndex = 0;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // connectBtn
            // 
            this.connectBtn.Enabled = false;
            this.connectBtn.Location = new System.Drawing.Point(84, 3);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(75, 23);
            this.connectBtn.TabIndex = 1;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // beepBtn
            // 
            this.beepBtn.Location = new System.Drawing.Point(165, 3);
            this.beepBtn.Name = "beepBtn";
            this.beepBtn.Size = new System.Drawing.Size(75, 23);
            this.beepBtn.TabIndex = 2;
            this.beepBtn.Text = "Beep";
            this.beepBtn.UseVisualStyleBackColor = true;
            this.beepBtn.Click += new System.EventHandler(this.beepToolStripMenuItem_Click);
            // 
            // DeviceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DeviceList";
            this.Size = new System.Drawing.Size(966, 247);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView deviceView;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader ip;
        private System.Windows.Forms.ColumnHeader mac;
        private System.Windows.Forms.ColumnHeader ethVersion;
        private System.Windows.Forms.ColumnHeader nurAppVersion;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beepToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textFilterData;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.ComboBox comboFilterOp;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.ComboBox comboFilterType;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Button beepBtn;
        private System.Windows.Forms.ColumnHeader addrType;
        private System.Windows.Forms.ColumnHeader mode;
        private System.Windows.Forms.ColumnHeader status;
        private System.Windows.Forms.ColumnHeader port;
        private System.Windows.Forms.ColumnHeader altSerial;
    }
}
