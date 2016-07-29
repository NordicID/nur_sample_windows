namespace MultiClientTest
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
            this.components = new System.ComponentModel.Container();
            this.logList = new System.Windows.Forms.ListBox();
            this.textPortEdit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelNurApiVer = new System.Windows.Forms.Label();
            this.labelDotNetVer = new System.Windows.Forms.Label();
            this.buttonStopServer = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textMaxClients = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.buttonDisconnectAll = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.textBoxWait = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labelRounds = new System.Windows.Forms.Label();
            this.labelRoundCount = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBoxDoParenLogs = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // logList
            // 
            this.logList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logList.FormattingEnabled = true;
            this.logList.Location = new System.Drawing.Point(0, 409);
            this.logList.Name = "logList";
            this.logList.Size = new System.Drawing.Size(1018, 212);
            this.logList.TabIndex = 0;
            // 
            // textPortEdit
            // 
            this.textPortEdit.Location = new System.Drawing.Point(48, 10);
            this.textPortEdit.Name = "textPortEdit";
            this.textPortEdit.Size = new System.Drawing.Size(65, 20);
            this.textPortEdit.TabIndex = 1;
            this.textPortEdit.Text = "1333";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Port:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(128, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Start Server";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(673, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "NurApi.Dll Version:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(673, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "NurApiDotNet.Dll Version:";
            // 
            // labelNurApiVer
            // 
            this.labelNurApiVer.AutoSize = true;
            this.labelNurApiVer.Location = new System.Drawing.Point(816, 13);
            this.labelNurApiVer.Name = "labelNurApiVer";
            this.labelNurApiVer.Size = new System.Drawing.Size(22, 13);
            this.labelNurApiVer.TabIndex = 6;
            this.labelNurApiVer.Text = "1.1";
            // 
            // labelDotNetVer
            // 
            this.labelDotNetVer.AutoSize = true;
            this.labelDotNetVer.Location = new System.Drawing.Point(816, 36);
            this.labelDotNetVer.Name = "labelDotNetVer";
            this.labelDotNetVer.Size = new System.Drawing.Size(22, 13);
            this.labelDotNetVer.TabIndex = 7;
            this.labelDotNetVer.Text = "1.1";
            // 
            // buttonStopServer
            // 
            this.buttonStopServer.Location = new System.Drawing.Point(128, 38);
            this.buttonStopServer.Name = "buttonStopServer";
            this.buttonStopServer.Size = new System.Drawing.Size(75, 23);
            this.buttonStopServer.TabIndex = 8;
            this.buttonStopServer.Text = "Stop Server";
            this.buttonStopServer.UseVisualStyleBackColor = true;
            this.buttonStopServer.Click += new System.EventHandler(this.buttonStopServer_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "max Clients:";
            // 
            // textMaxClients
            // 
            this.textMaxClients.Location = new System.Drawing.Point(82, 38);
            this.textMaxClients.Name = "textMaxClients";
            this.textMaxClients.Size = new System.Drawing.Size(31, 20);
            this.textMaxClients.TabIndex = 9;
            this.textMaxClients.Text = "0";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(6, 24);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(60, 23);
            this.buttonStart.TabIndex = 11;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Connected Clients:";
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(0, 173);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1018, 236);
            this.listView1.TabIndex = 14;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // buttonDisconnectAll
            // 
            this.buttonDisconnectAll.Location = new System.Drawing.Point(128, 75);
            this.buttonDisconnectAll.Name = "buttonDisconnectAll";
            this.buttonDisconnectAll.Size = new System.Drawing.Size(109, 23);
            this.buttonDisconnectAll.TabIndex = 15;
            this.buttonDisconnectAll.Text = "DisconnectAll";
            this.buttonDisconnectAll.UseVisualStyleBackColor = true;
            this.buttonDisconnectAll.Click += new System.EventHandler(this.buttonDisconnectAll_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.textBoxWait);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.labelRounds);
            this.groupBox1.Controls.Add(this.labelRoundCount);
            this.groupBox1.Controls.Add(this.buttonStart);
            this.groupBox1.Location = new System.Drawing.Point(254, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 138);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inventory";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(98, 33);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(236, 17);
            this.radioButton2.TabIndex = 23;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "InventoryStreamThread. All reader same time";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(98, 9);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(211, 17);
            this.radioButton1.TabIndex = 22;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "SimpleInventory. One reader at the time";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // textBoxWait
            // 
            this.textBoxWait.Location = new System.Drawing.Point(154, 65);
            this.textBoxWait.Name = "textBoxWait";
            this.textBoxWait.Size = new System.Drawing.Size(58, 20);
            this.textBoxWait.TabIndex = 18;
            this.textBoxWait.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Wait between rounds (msec)";
            // 
            // labelRounds
            // 
            this.labelRounds.AutoSize = true;
            this.labelRounds.Location = new System.Drawing.Point(55, 99);
            this.labelRounds.Name = "labelRounds";
            this.labelRounds.Size = new System.Drawing.Size(13, 13);
            this.labelRounds.TabIndex = 19;
            this.labelRounds.Text = "0";
            // 
            // labelRoundCount
            // 
            this.labelRoundCount.AutoSize = true;
            this.labelRoundCount.Location = new System.Drawing.Point(6, 99);
            this.labelRoundCount.Name = "labelRoundCount";
            this.labelRoundCount.Size = new System.Drawing.Size(47, 13);
            this.labelRoundCount.TabIndex = 18;
            this.labelRoundCount.Text = "Rounds:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // checkBoxDoParenLogs
            // 
            this.checkBoxDoParenLogs.AutoSize = true;
            this.checkBoxDoParenLogs.Location = new System.Drawing.Point(16, 106);
            this.checkBoxDoParenLogs.Name = "checkBoxDoParenLogs";
            this.checkBoxDoParenLogs.Size = new System.Drawing.Size(95, 17);
            this.checkBoxDoParenLogs.TabIndex = 19;
            this.checkBoxDoParenLogs.Text = "Do parent logs";
            this.checkBoxDoParenLogs.UseVisualStyleBackColor = true;
            this.checkBoxDoParenLogs.CheckedChanged += new System.EventHandler(this.checkBoxDoParenLogs_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 621);
            this.Controls.Add(this.checkBoxDoParenLogs);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonDisconnectAll);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textMaxClients);
            this.Controls.Add(this.buttonStopServer);
            this.Controls.Add(this.labelDotNetVer);
            this.Controls.Add(this.labelNurApiVer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textPortEdit);
            this.Controls.Add(this.logList);
            this.Name = "Form1";
            this.Text = "Multi Client Test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox logList;
        private System.Windows.Forms.TextBox textPortEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelNurApiVer;
        private System.Windows.Forms.Label labelDotNetVer;
        private System.Windows.Forms.Button buttonStopServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textMaxClients;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button buttonDisconnectAll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelRounds;
        private System.Windows.Forms.Label labelRoundCount;
        private System.Windows.Forms.TextBox textBoxWait;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBoxDoParenLogs;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}

