namespace NurSample
{
    partial class NXP
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
            this.tabPSF = new System.Windows.Forms.TabPage();
            this.nxpProductStatusFlag = new NurSample.NXP_ProductStatusFlag();
            this.tabEAS = new System.Windows.Forms.TabPage();
            this.nxpEasAlarm = new NurSample.NXP_EasAlarm();
            this.tabReadProtect = new System.Windows.Forms.TabPage();
            this.nxpReadProtect = new NurSample.NXP_ReadProtect();
            this.tabControl1.SuspendLayout();
            this.tabPSF.SuspendLayout();
            this.tabEAS.SuspendLayout();
            this.tabReadProtect.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPSF);
            this.tabControl1.Controls.Add(this.tabEAS);
            this.tabControl1.Controls.Add(this.tabReadProtect);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 320);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPSF
            // 
            this.tabPSF.Controls.Add(this.nxpProductStatusFlag);
            this.tabPSF.Location = new System.Drawing.Point(4, 25);
            this.tabPSF.Name = "tabPSF";
            this.tabPSF.Size = new System.Drawing.Size(232, 291);
            this.tabPSF.Text = "PSF";
            // 
            // nxpProductStatusFlag
            // 
            this.nxpProductStatusFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nxpProductStatusFlag.Location = new System.Drawing.Point(0, 0);
            this.nxpProductStatusFlag.Name = "nxpProductStatusFlag";
            this.nxpProductStatusFlag.Size = new System.Drawing.Size(232, 291);
            this.nxpProductStatusFlag.TabIndex = 0;
            // 
            // tabEAS
            // 
            this.tabEAS.Controls.Add(this.nxpEasAlarm);
            this.tabEAS.Location = new System.Drawing.Point(4, 25);
            this.tabEAS.Name = "tabEAS";
            this.tabEAS.Size = new System.Drawing.Size(232, 291);
            this.tabEAS.Text = "EAS";
            // 
            // nxpEasAlarm
            // 
            this.nxpEasAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nxpEasAlarm.Location = new System.Drawing.Point(0, 0);
            this.nxpEasAlarm.Name = "nxpEasAlarm";
            this.nxpEasAlarm.Size = new System.Drawing.Size(232, 291);
            this.nxpEasAlarm.TabIndex = 0;
            // 
            // tabReadProtect
            // 
            this.tabReadProtect.Controls.Add(this.nxpReadProtect);
            this.tabReadProtect.Location = new System.Drawing.Point(4, 25);
            this.tabReadProtect.Name = "tabReadProtect";
            this.tabReadProtect.Size = new System.Drawing.Size(232, 291);
            this.tabReadProtect.Text = "ReadProtect";
            // 
            // nxpReadProtect
            // 
            this.nxpReadProtect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nxpReadProtect.Location = new System.Drawing.Point(0, 0);
            this.nxpReadProtect.Name = "nxpReadProtect";
            this.nxpReadProtect.Size = new System.Drawing.Size(232, 291);
            this.nxpReadProtect.TabIndex = 0;
            // 
            // NXP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl1);
            this.Name = "NXP";
            this.Size = new System.Drawing.Size(240, 320);
            this.tabControl1.ResumeLayout(false);
            this.tabPSF.ResumeLayout(false);
            this.tabEAS.ResumeLayout(false);
            this.tabReadProtect.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabEAS;
        private NXP_EasAlarm nxpEasAlarm;
        private System.Windows.Forms.TabPage tabReadProtect;
        private NXP_ReadProtect nxpReadProtect;
        private System.Windows.Forms.TabPage tabPSF;
        private NXP_ProductStatusFlag nxpProductStatusFlag;

    }
}
