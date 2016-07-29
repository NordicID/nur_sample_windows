namespace NurPositioningApiSample
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
            this.components = new System.ComponentModel.Container();
            this.startbutton = new System.Windows.Forms.Button();
            this.searchEthButton = new System.Windows.Forms.Button();
            this.ethAddr = new System.Windows.Forms.TextBox();
            this.ethPort = new System.Windows.Forms.NumericUpDown();
            this.containerpanel = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tagviewpanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tagsPerBeamControl1 = new NurPositioningApiSample.TagsPerBeamControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listbox_events = new System.Windows.Forms.ListBox();
            this.connectbutton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tagListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clearbutton = new System.Windows.Forms.Button();
            this.quitbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ethPort)).BeginInit();
            this.containerpanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tagviewpanel.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // startbutton
            // 
            this.startbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.startbutton.Location = new System.Drawing.Point(619, 519);
            this.startbutton.Name = "startbutton";
            this.startbutton.Size = new System.Drawing.Size(107, 23);
            this.startbutton.TabIndex = 1;
            this.startbutton.Text = "Start Positioning";
            this.startbutton.UseVisualStyleBackColor = true;
            this.startbutton.Click += new System.EventHandler(this.startbutton_Click);
            // 
            // searchEthButton
            // 
            this.searchEthButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.searchEthButton.Location = new System.Drawing.Point(219, 44);
            this.searchEthButton.Name = "searchEthButton";
            this.searchEthButton.Size = new System.Drawing.Size(75, 23);
            this.searchEthButton.TabIndex = 2;
            this.searchEthButton.Text = "Search";
            this.searchEthButton.UseVisualStyleBackColor = true;
            this.searchEthButton.Click += new System.EventHandler(this.searchEthButton_Click);
            // 
            // ethAddr
            // 
            this.ethAddr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ethAddr.Location = new System.Drawing.Point(22, 47);
            this.ethAddr.Name = "ethAddr";
            this.ethAddr.Size = new System.Drawing.Size(122, 20);
            this.ethAddr.TabIndex = 3;
            // 
            // ethPort
            // 
            this.ethPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ethPort.Location = new System.Drawing.Point(150, 47);
            this.ethPort.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.ethPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ethPort.Name = "ethPort";
            this.ethPort.Size = new System.Drawing.Size(63, 20);
            this.ethPort.TabIndex = 4;
            this.ethPort.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // containerpanel
            // 
            this.containerpanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.containerpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.containerpanel.Controls.Add(this.tabControl1);
            this.containerpanel.Location = new System.Drawing.Point(253, 12);
            this.containerpanel.Name = "containerpanel";
            this.containerpanel.Size = new System.Drawing.Size(473, 491);
            this.containerpanel.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(471, 489);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tagviewpanel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(463, 463);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Radar";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Resize += new System.EventHandler(this.tabPage1_Resize);
            // 
            // tagviewpanel
            // 
            this.tagviewpanel.BackColor = System.Drawing.SystemColors.Window;
            this.tagviewpanel.BackgroundImage = global::NurPositioningApiSample.Properties.Resources.GridAntennaSectors;
            this.tagviewpanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tagviewpanel.Controls.Add(this.label1);
            this.tagviewpanel.Location = new System.Drawing.Point(6, 6);
            this.tagviewpanel.Name = "tagviewpanel";
            this.tagviewpanel.Size = new System.Drawing.Size(450, 450);
            this.tagviewpanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(192, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Active";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tagsPerBeamControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(463, 463);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tags per beam";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Resize += new System.EventHandler(this.tabPage2_Resize);
            // 
            // tagsPerBeamControl1
            // 
            this.tagsPerBeamControl1.Location = new System.Drawing.Point(3, 6);
            this.tagsPerBeamControl1.Name = "tagsPerBeamControl1";
            this.tagsPerBeamControl1.Size = new System.Drawing.Size(476, 458);
            this.tagsPerBeamControl1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listbox_events);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(463, 463);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Events";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listbox_events
            // 
            this.listbox_events.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listbox_events.FormattingEnabled = true;
            this.listbox_events.Location = new System.Drawing.Point(3, 3);
            this.listbox_events.Name = "listbox_events";
            this.listbox_events.Size = new System.Drawing.Size(457, 457);
            this.listbox_events.TabIndex = 0;
            // 
            // connectbutton
            // 
            this.connectbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.connectbutton.Location = new System.Drawing.Point(300, 44);
            this.connectbutton.Name = "connectbutton";
            this.connectbutton.Size = new System.Drawing.Size(75, 23);
            this.connectbutton.TabIndex = 6;
            this.connectbutton.Text = "Connect";
            this.connectbutton.UseVisualStyleBackColor = true;
            this.connectbutton.Click += new System.EventHandler(this.connectbutton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ethAddr);
            this.groupBox1.Controls.Add(this.connectbutton);
            this.groupBox1.Controls.Add(this.ethPort);
            this.groupBox1.Controls.Add(this.searchEthButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 509);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 100);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ethernet";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(147, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Address";
            // 
            // tagListView
            // 
            this.tagListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tagListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tagListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.tagListView.ContextMenuStrip = this.contextMenuStrip1;
            this.tagListView.Location = new System.Drawing.Point(12, 12);
            this.tagListView.Name = "tagListView";
            this.tagListView.Size = new System.Drawing.Size(235, 373);
            this.tagListView.TabIndex = 8;
            this.tagListView.UseCompatibleStateImageBehavior = false;
            this.tagListView.View = System.Windows.Forms.View.Details;
            this.tagListView.SelectedIndexChanged += new System.EventHandler(this.tagListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "EPC";
            this.columnHeader1.Width = 200;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(102, 26);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Location = new System.Drawing.Point(418, 509);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "USB";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(29, 48);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(136, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Use USB auto connect";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.Location = new System.Drawing.Point(12, 391);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(235, 112);
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "H1";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "H2";
            this.columnHeader3.Width = 150;
            // 
            // clearbutton
            // 
            this.clearbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearbutton.Location = new System.Drawing.Point(619, 548);
            this.clearbutton.Name = "clearbutton";
            this.clearbutton.Size = new System.Drawing.Size(107, 23);
            this.clearbutton.TabIndex = 11;
            this.clearbutton.Text = "Config";
            this.clearbutton.UseVisualStyleBackColor = true;
            this.clearbutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // quitbutton
            // 
            this.quitbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.quitbutton.Location = new System.Drawing.Point(619, 577);
            this.quitbutton.Name = "quitbutton";
            this.quitbutton.Size = new System.Drawing.Size(107, 23);
            this.quitbutton.TabIndex = 12;
            this.quitbutton.Text = "Quit";
            this.quitbutton.UseVisualStyleBackColor = true;
            this.quitbutton.Click += new System.EventHandler(this.quitbutton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 613);
            this.Controls.Add(this.quitbutton);
            this.Controls.Add(this.clearbutton);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tagListView);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.containerpanel);
            this.Controls.Add(this.startbutton);
            this.Name = "MainForm";
            this.Text = "NurPositioningApiSample";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.ethPort)).EndInit();
            this.containerpanel.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tagviewpanel.ResumeLayout(false);
            this.tagviewpanel.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startbutton;
        private System.Windows.Forms.Button searchEthButton;
        private System.Windows.Forms.TextBox ethAddr;
        private System.Windows.Forms.NumericUpDown ethPort;
        private System.Windows.Forms.Panel containerpanel;
        private System.Windows.Forms.Panel tagviewpanel;
        private System.Windows.Forms.Button connectbutton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView tagListView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearbutton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button quitbutton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private TagsPerBeamControl tagsPerBeamControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox listbox_events;
    }
}

