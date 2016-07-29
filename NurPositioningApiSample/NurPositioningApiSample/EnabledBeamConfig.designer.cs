namespace NurPositioningApiSample
{
    partial class EnabledBeamConfig
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_eb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackgroundImage = global::NurPositioningApiSample.Properties.Resources.BeamFlowerSmall;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(259, 249);
            this.panel1.TabIndex = 0;
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GridAntennaSelector_MouseClick);
            // 
            // lbl_eb
            // 
            this.lbl_eb.AutoSize = true;
            this.lbl_eb.BackColor = System.Drawing.Color.Transparent;
            this.lbl_eb.Location = new System.Drawing.Point(3, 252);
            this.lbl_eb.Name = "lbl_eb";
            this.lbl_eb.Size = new System.Drawing.Size(62, 13);
            this.lbl_eb.TabIndex = 1;
            this.lbl_eb.Text = "Extrabeams";
            // 
            // EnabledBeamConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lbl_eb);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "EnabledBeamConfig";
            this.Size = new System.Drawing.Size(259, 319);
            this.Click += new System.EventHandler(this.GridAntennaSelector_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_eb;


    }
}
