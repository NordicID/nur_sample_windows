namespace NurSample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.connectionTab = new System.Windows.Forms.TabPage();
            this.nurConnection = new NurSample.Connection();
            this.nurInfo = new NurSample.Info();
            this.inventoryTab = new System.Windows.Forms.TabPage();
            this.nurInventory = new NurSample.Inventory();
            this.locatorTab = new System.Windows.Forms.TabPage();
            this.nurLocator = new NurSample.Locator();
            this.writeTab = new System.Windows.Forms.TabPage();
            this.nurWriter = new NurSample.Writer();
            this.settingsTab = new System.Windows.Forms.TabPage();
            this.nurSettings = new NurSample.Settings();
            this.nxpTab = new System.Windows.Forms.TabPage();
            this.nurNxp = new NurSample.NXP();
            this.sensorsTab = new System.Windows.Forms.TabPage();
            this.nurSensors = new NurSample.Sensors();
            this.logTab = new System.Windows.Forms.TabPage();
            this.nurLog = new NurSample.Log();
            this.antennasTab = new System.Windows.Forms.TabPage();
            this.nurAntennas = new NurSample.Antennas();
            this.tabControl1.SuspendLayout();
            this.connectionTab.SuspendLayout();
            this.inventoryTab.SuspendLayout();
            this.locatorTab.SuspendLayout();
            this.writeTab.SuspendLayout();
            this.settingsTab.SuspendLayout();
            this.nxpTab.SuspendLayout();
            this.sensorsTab.SuspendLayout();
            this.logTab.SuspendLayout();
            this.antennasTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.connectionTab);
            this.tabControl1.Controls.Add(this.inventoryTab);
            this.tabControl1.Controls.Add(this.antennasTab);
            this.tabControl1.Controls.Add(this.locatorTab);
            this.tabControl1.Controls.Add(this.writeTab);
            this.tabControl1.Controls.Add(this.settingsTab);
            this.tabControl1.Controls.Add(this.nxpTab);
            this.tabControl1.Controls.Add(this.sensorsTab);
            this.tabControl1.Controls.Add(this.logTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(6, 6);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 562);
            this.tabControl1.TabIndex = 0;
            // 
            // connectionTab
            // 
            this.connectionTab.Controls.Add(this.nurConnection);
            this.connectionTab.Controls.Add(this.nurInfo);
            this.connectionTab.Location = new System.Drawing.Point(4, 28);
            this.connectionTab.Margin = new System.Windows.Forms.Padding(6);
            this.connectionTab.Name = "connectionTab";
            this.connectionTab.Size = new System.Drawing.Size(776, 530);
            this.connectionTab.TabIndex = 0;
            this.connectionTab.Text = "Connection";
            this.connectionTab.UseVisualStyleBackColor = true;
            // 
            // nurConnection
            // 
            this.nurConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.nurConnection.AutoSize = true;
            this.nurConnection.Location = new System.Drawing.Point(8, 3);
            this.nurConnection.Name = "nurConnection";
            this.nurConnection.Size = new System.Drawing.Size(435, 519);
            this.nurConnection.TabIndex = 5;
            // 
            // nurInfo
            // 
            this.nurInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nurInfo.Location = new System.Drawing.Point(455, 3);
            this.nurInfo.Name = "nurInfo";
            this.nurInfo.Size = new System.Drawing.Size(318, 522);
            this.nurInfo.TabIndex = 4;
            // 
            // inventoryTab
            // 
            this.inventoryTab.Controls.Add(this.nurInventory);
            this.inventoryTab.Location = new System.Drawing.Point(4, 28);
            this.inventoryTab.Name = "inventoryTab";
            this.inventoryTab.Size = new System.Drawing.Size(776, 530);
            this.inventoryTab.TabIndex = 1;
            this.inventoryTab.Text = "Inventory";
            this.inventoryTab.UseVisualStyleBackColor = true;
            // 
            // nurInventory
            // 
            this.nurInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nurInventory.Enabled = false;
            this.nurInventory.Location = new System.Drawing.Point(0, 0);
            this.nurInventory.Name = "nurInventory";
            this.nurInventory.Size = new System.Drawing.Size(776, 530);
            this.nurInventory.TabIndex = 0;
            // 
            // locatorTab
            // 
            this.locatorTab.Controls.Add(this.nurLocator);
            this.locatorTab.Location = new System.Drawing.Point(4, 28);
            this.locatorTab.Name = "locatorTab";
            this.locatorTab.Size = new System.Drawing.Size(776, 530);
            this.locatorTab.TabIndex = 2;
            this.locatorTab.Text = "Locator";
            this.locatorTab.UseVisualStyleBackColor = true;
            // 
            // nurLocator
            // 
            this.nurLocator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nurLocator.Enabled = false;
            this.nurLocator.Location = new System.Drawing.Point(0, 0);
            this.nurLocator.Name = "nurLocator";
            this.nurLocator.Size = new System.Drawing.Size(776, 530);
            this.nurLocator.TabIndex = 0;
            // 
            // writeTab
            // 
            this.writeTab.Controls.Add(this.nurWriter);
            this.writeTab.Location = new System.Drawing.Point(4, 28);
            this.writeTab.Name = "writeTab";
            this.writeTab.Size = new System.Drawing.Size(776, 530);
            this.writeTab.TabIndex = 3;
            this.writeTab.Text = "Writer";
            this.writeTab.UseVisualStyleBackColor = true;
            // 
            // nurWriter
            // 
            this.nurWriter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nurWriter.Enabled = false;
            this.nurWriter.Location = new System.Drawing.Point(0, 0);
            this.nurWriter.Name = "nurWriter";
            this.nurWriter.Size = new System.Drawing.Size(776, 530);
            this.nurWriter.TabIndex = 0;
            // 
            // settingsTab
            // 
            this.settingsTab.Controls.Add(this.nurSettings);
            this.settingsTab.Location = new System.Drawing.Point(4, 28);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.Size = new System.Drawing.Size(776, 530);
            this.settingsTab.TabIndex = 4;
            this.settingsTab.Text = "Settings";
            this.settingsTab.UseVisualStyleBackColor = true;
            // 
            // nurSettings
            // 
            this.nurSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nurSettings.Enabled = false;
            this.nurSettings.Location = new System.Drawing.Point(0, 0);
            this.nurSettings.Name = "nurSettings";
            this.nurSettings.Size = new System.Drawing.Size(776, 530);
            this.nurSettings.TabIndex = 0;
            // 
            // nxpTab
            // 
            this.nxpTab.Controls.Add(this.nurNxp);
            this.nxpTab.Location = new System.Drawing.Point(4, 28);
            this.nxpTab.Name = "nxpTab";
            this.nxpTab.Size = new System.Drawing.Size(776, 530);
            this.nxpTab.TabIndex = 5;
            this.nxpTab.Text = "NXP";
            this.nxpTab.UseVisualStyleBackColor = true;
            // 
            // nurNxp
            // 
            this.nurNxp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nurNxp.Enabled = false;
            this.nurNxp.Location = new System.Drawing.Point(0, 0);
            this.nurNxp.Name = "nurNxp";
            this.nurNxp.Size = new System.Drawing.Size(776, 530);
            this.nurNxp.TabIndex = 1;
            // 
            // sensorsTab
            // 
            this.sensorsTab.Controls.Add(this.nurSensors);
            this.sensorsTab.Location = new System.Drawing.Point(4, 28);
            this.sensorsTab.Name = "sensorsTab";
            this.sensorsTab.Padding = new System.Windows.Forms.Padding(3);
            this.sensorsTab.Size = new System.Drawing.Size(776, 530);
            this.sensorsTab.TabIndex = 6;
            this.sensorsTab.Text = "Sensors";
            this.sensorsTab.UseVisualStyleBackColor = true;
            // 
            // nurSensors
            // 
            this.nurSensors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nurSensors.Enabled = false;
            this.nurSensors.Location = new System.Drawing.Point(3, 3);
            this.nurSensors.Name = "nurSensors";
            this.nurSensors.Size = new System.Drawing.Size(770, 524);
            this.nurSensors.TabIndex = 0;
            // 
            // logTab
            // 
            this.logTab.Controls.Add(this.nurLog);
            this.logTab.Location = new System.Drawing.Point(4, 28);
            this.logTab.Name = "logTab";
            this.logTab.Size = new System.Drawing.Size(776, 530);
            this.logTab.TabIndex = 7;
            this.logTab.Text = "Log";
            this.logTab.UseVisualStyleBackColor = true;
            // 
            // nurLog
            // 
            this.nurLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nurLog.Enabled = false;
            this.nurLog.Location = new System.Drawing.Point(0, 0);
            this.nurLog.Name = "nurLog";
            this.nurLog.Size = new System.Drawing.Size(776, 530);
            this.nurLog.TabIndex = 0;
            // 
            // antennasTab
            // 
            this.antennasTab.Controls.Add(this.nurAntennas);
            this.antennasTab.Location = new System.Drawing.Point(4, 28);
            this.antennasTab.Name = "antennasTab";
            this.antennasTab.Size = new System.Drawing.Size(776, 530);
            this.antennasTab.TabIndex = 8;
            this.antennasTab.Text = "Antennas";
            this.antennasTab.UseVisualStyleBackColor = true;
            // 
            // sensors1
            // 
            this.nurAntennas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nurAntennas.Enabled = false;
            this.nurAntennas.Location = new System.Drawing.Point(0, 0);
            this.nurAntennas.Name = "sensors1";
            this.nurAntennas.Size = new System.Drawing.Size(776, 530);
            this.nurAntennas.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
            this.tabControl1.ResumeLayout(false);
            this.connectionTab.ResumeLayout(false);
            this.connectionTab.PerformLayout();
            this.inventoryTab.ResumeLayout(false);
            this.locatorTab.ResumeLayout(false);
            this.writeTab.ResumeLayout(false);
            this.settingsTab.ResumeLayout(false);
            this.nxpTab.ResumeLayout(false);
            this.sensorsTab.ResumeLayout(false);
            this.logTab.ResumeLayout(false);
            this.antennasTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage inventoryTab;
        private System.Windows.Forms.TabPage writeTab;
        private System.Windows.Forms.TabPage connectionTab;
        private System.Windows.Forms.TabPage locatorTab;
        private Locator nurLocator;
        private Writer nurWriter;
        private Inventory nurInventory;
        private System.Windows.Forms.TabPage settingsTab;
        private Settings nurSettings;
        private System.Windows.Forms.TabPage nxpTab;
        private NXP nurNxp;
        private System.Windows.Forms.TabPage sensorsTab;
        private Sensors nurSensors;
        private System.Windows.Forms.TabPage logTab;
        private Log nurLog;
        private Info nurInfo;
        private Connection nurConnection;
        private System.Windows.Forms.TabPage antennasTab;
        private Antennas nurAntennas;
    }
}

