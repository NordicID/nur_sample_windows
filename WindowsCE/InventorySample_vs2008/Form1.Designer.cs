namespace InventorySample
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
            this.btn_scan = new System.Windows.Forms.Button();
            this.lstbox = new System.Windows.Forms.ListBox();
            this.btn_scan_stream = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_scan
            // 
            this.btn_scan.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btn_scan.Location = new System.Drawing.Point(3, 235);
            this.btn_scan.Name = "btn_scan";
            this.btn_scan.Size = new System.Drawing.Size(110, 31);
            this.btn_scan.TabIndex = 0;
            this.btn_scan.Text = "Single Inventory";
            this.btn_scan.Click += new System.EventHandler(this.btn_scan_Click);
            // 
            // lstbox
            // 
            this.lstbox.Location = new System.Drawing.Point(3, 3);
            this.lstbox.Name = "lstbox";
            this.lstbox.Size = new System.Drawing.Size(231, 226);
            this.lstbox.TabIndex = 1;
            // 
            // btn_scan_stream
            // 
            this.btn_scan_stream.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btn_scan_stream.Location = new System.Drawing.Point(124, 235);
            this.btn_scan_stream.Name = "btn_scan_stream";
            this.btn_scan_stream.Size = new System.Drawing.Size(110, 31);
            this.btn_scan_stream.TabIndex = 2;
            this.btn_scan_stream.Text = "Inventory Stream";
            this.btn_scan_stream.Click += new System.EventHandler(this.btn_scan_stream_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 269);
            this.Controls.Add(this.btn_scan_stream);
            this.Controls.Add(this.lstbox);
            this.Controls.Add(this.btn_scan);
            this.Name = "Form1";
            this.Text = "Inventory Sample";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_scan;
        private System.Windows.Forms.ListBox lstbox;
        private System.Windows.Forms.Button btn_scan_stream;
    }
}

