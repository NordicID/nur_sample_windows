namespace NurSample
{
    partial class AntennaTuner
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
            this.tuneAntennasButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.restoreFactoryTuningsButtons = new System.Windows.Forms.Button();
            this.measureReflegtedPowerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tuneAntennasButton
            // 
            this.tuneAntennasButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tuneAntennasButton.Location = new System.Drawing.Point(6, 271);
            this.tuneAntennasButton.Name = "tuneAntennasButton";
            this.tuneAntennasButton.Size = new System.Drawing.Size(100, 23);
            this.tuneAntennasButton.TabIndex = 0;
            this.tuneAntennasButton.Text = "Tune Antennas";
            this.tuneAntennasButton.Click += new System.EventHandler(this.tuneButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.Location = new System.Drawing.Point(6, 6);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(378, 226);
            this.listBox1.TabIndex = 1;
            // 
            // restoreFactoryTuningsButtons
            // 
            this.restoreFactoryTuningsButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.restoreFactoryTuningsButtons.Location = new System.Drawing.Point(112, 271);
            this.restoreFactoryTuningsButtons.Name = "restoreFactoryTuningsButtons";
            this.restoreFactoryTuningsButtons.Size = new System.Drawing.Size(272, 23);
            this.restoreFactoryTuningsButtons.TabIndex = 2;
            this.restoreFactoryTuningsButtons.Text = "Restore Tunings";
            this.restoreFactoryTuningsButtons.Click += new System.EventHandler(this.restoreFactoryTuningsButtons_Click);
            // 
            // measureReflegtedPowerButton
            // 
            this.measureReflegtedPowerButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.measureReflegtedPowerButton.Location = new System.Drawing.Point(6, 242);
            this.measureReflegtedPowerButton.Name = "measureReflegtedPowerButton";
            this.measureReflegtedPowerButton.Size = new System.Drawing.Size(378, 23);
            this.measureReflegtedPowerButton.TabIndex = 3;
            this.measureReflegtedPowerButton.Text = "Measure Reflected Powers";
            this.measureReflegtedPowerButton.Click += new System.EventHandler(this.measureReflegtedPowerButton_Click);
            // 
            // AntennaTuner
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.measureReflegtedPowerButton);
            this.Controls.Add(this.restoreFactoryTuningsButtons);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.tuneAntennasButton);
            this.Name = "AntennaTuner";
            this.Size = new System.Drawing.Size(389, 297);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button tuneAntennasButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button restoreFactoryTuningsButtons;
        private System.Windows.Forms.Button measureReflegtedPowerButton;
    }
}
