namespace NurTagTrackingGate
{
    partial class Form1
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
            this.quitbutton = new System.Windows.Forms.Button();
            this.clearbutton = new System.Windows.Forms.Button();
            this.startbutton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ethAddr = new System.Windows.Forms.TextBox();
            this.connectbutton = new System.Windows.Forms.Button();
            this.ethPort = new System.Windows.Forms.NumericUpDown();
            this.searchEthButton = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tagListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listIN = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listOUT = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.eventhistoryListView = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbl_incnt = new System.Windows.Forms.Label();
            this.lbl_outcnt = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ethPort)).BeginInit();
            this.SuspendLayout();
            // 
            // quitbutton
            // 
            this.quitbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.quitbutton.Location = new System.Drawing.Point(957, 569);
            this.quitbutton.Name = "quitbutton";
            this.quitbutton.Size = new System.Drawing.Size(107, 23);
            this.quitbutton.TabIndex = 15;
            this.quitbutton.Text = "Quit";
            this.quitbutton.UseVisualStyleBackColor = true;
            this.quitbutton.Click += new System.EventHandler(this.quitbutton_Click);
            // 
            // clearbutton
            // 
            this.clearbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearbutton.Location = new System.Drawing.Point(957, 540);
            this.clearbutton.Name = "clearbutton";
            this.clearbutton.Size = new System.Drawing.Size(107, 23);
            this.clearbutton.TabIndex = 14;
            this.clearbutton.Text = "Config";
            this.clearbutton.UseVisualStyleBackColor = true;
            this.clearbutton.Click += new System.EventHandler(this.clearbutton_Click);
            // 
            // startbutton
            // 
            this.startbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.startbutton.Location = new System.Drawing.Point(957, 511);
            this.startbutton.Name = "startbutton";
            this.startbutton.Size = new System.Drawing.Size(107, 23);
            this.startbutton.TabIndex = 13;
            this.startbutton.Text = "Start Positioning";
            this.startbutton.UseVisualStyleBackColor = true;
            this.startbutton.Click += new System.EventHandler(this.startbutton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Location = new System.Drawing.Point(415, 502);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 17;
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
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ethAddr);
            this.groupBox1.Controls.Add(this.connectbutton);
            this.groupBox1.Controls.Add(this.ethPort);
            this.groupBox1.Controls.Add(this.searchEthButton);
            this.groupBox1.Location = new System.Drawing.Point(9, 502);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 100);
            this.groupBox1.TabIndex = 16;
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
            // ethAddr
            // 
            this.ethAddr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ethAddr.Location = new System.Drawing.Point(22, 47);
            this.ethAddr.Name = "ethAddr";
            this.ethAddr.Size = new System.Drawing.Size(122, 20);
            this.ethAddr.TabIndex = 3;
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
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.Location = new System.Drawing.Point(9, 384);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(235, 112);
            this.listView1.TabIndex = 18;
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
            // tagListView
            // 
            this.tagListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tagListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tagListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.tagListView.Location = new System.Drawing.Point(9, 12);
            this.tagListView.MultiSelect = false;
            this.tagListView.Name = "tagListView";
            this.tagListView.Size = new System.Drawing.Size(235, 366);
            this.tagListView.TabIndex = 19;
            this.tagListView.UseCompatibleStateImageBehavior = false;
            this.tagListView.View = System.Windows.Forms.View.Details;
            this.tagListView.SelectedIndexChanged += new System.EventHandler(this.tagListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "All seen tags";
            this.columnHeader1.Width = 200;
            // 
            // listIN
            // 
            this.listIN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listIN.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader12});
            this.listIN.Location = new System.Drawing.Point(250, 12);
            this.listIN.MultiSelect = false;
            this.listIN.Name = "listIN";
            this.listIN.Size = new System.Drawing.Size(191, 442);
            this.listIN.TabIndex = 20;
            this.listIN.UseCompatibleStateImageBehavior = false;
            this.listIN.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tags IN";
            this.columnHeader4.Width = 148;
            // 
            // listOUT
            // 
            this.listOUT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listOUT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listOUT.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader14});
            this.listOUT.Location = new System.Drawing.Point(444, 12);
            this.listOUT.MultiSelect = false;
            this.listOUT.Name = "listOUT";
            this.listOUT.Size = new System.Drawing.Size(192, 442);
            this.listOUT.TabIndex = 21;
            this.listOUT.UseCompatibleStateImageBehavior = false;
            this.listOUT.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Tags OUT";
            this.columnHeader5.Width = 146;
            // 
            // eventhistoryListView
            // 
            this.eventhistoryListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eventhistoryListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eventhistoryListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader16,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.eventhistoryListView.Location = new System.Drawing.Point(642, 12);
            this.eventhistoryListView.Name = "eventhistoryListView";
            this.eventhistoryListView.Size = new System.Drawing.Size(428, 484);
            this.eventhistoryListView.TabIndex = 22;
            this.eventhistoryListView.UseCompatibleStateImageBehavior = false;
            this.eventhistoryListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Time";
            this.columnHeader6.Width = 93;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Changed events";
            this.columnHeader7.Width = 93;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Ant1";
            this.columnHeader8.Width = 37;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Ant2";
            this.columnHeader9.Width = 44;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Direction";
            this.columnHeader10.Width = 59;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Count";
            this.columnHeader12.Width = 42;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Count";
            this.columnHeader14.Width = 44;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Visibility";
            this.columnHeader11.Width = 48;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "curAnt";
            this.columnHeader16.Width = 50;
            // 
            // lbl_incnt
            // 
            this.lbl_incnt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_incnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_incnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_incnt.Location = new System.Drawing.Point(250, 457);
            this.lbl_incnt.Name = "lbl_incnt";
            this.lbl_incnt.Size = new System.Drawing.Size(192, 39);
            this.lbl_incnt.TabIndex = 23;
            this.lbl_incnt.Text = "0";
            this.lbl_incnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_outcnt
            // 
            this.lbl_outcnt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_outcnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_outcnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbl_outcnt.Location = new System.Drawing.Point(444, 457);
            this.lbl_outcnt.Name = "lbl_outcnt";
            this.lbl_outcnt.Size = new System.Drawing.Size(192, 39);
            this.lbl_outcnt.TabIndex = 24;
            this.lbl_outcnt.Text = "0";
            this.lbl_outcnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 614);
            this.Controls.Add(this.lbl_outcnt);
            this.Controls.Add(this.lbl_incnt);
            this.Controls.Add(this.eventhistoryListView);
            this.Controls.Add(this.listOUT);
            this.Controls.Add(this.listIN);
            this.Controls.Add(this.tagListView);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.quitbutton);
            this.Controls.Add(this.clearbutton);
            this.Controls.Add(this.startbutton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ethPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button quitbutton;
        private System.Windows.Forms.Button clearbutton;
        private System.Windows.Forms.Button startbutton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ethAddr;
        private System.Windows.Forms.Button connectbutton;
        private System.Windows.Forms.NumericUpDown ethPort;
        private System.Windows.Forms.Button searchEthButton;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView tagListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView listIN;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView listOUT;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ListView eventhistoryListView;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.Label lbl_incnt;
        private System.Windows.Forms.Label lbl_outcnt;
    }
}

