namespace NurSample
{
    partial class NurTagDataListView
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
            this.tagListView = new System.Windows.Forms.ListView();
            this.rssiHeader = new System.Windows.Forms.ColumnHeader();
            this.epcHeader = new System.Windows.Forms.ColumnHeader();
            this.dataHeader = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // tagListView
            // 
            this.tagListView.Columns.Add(this.rssiHeader);
            this.tagListView.Columns.Add(this.epcHeader);
            this.tagListView.Columns.Add(this.dataHeader);
            this.tagListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tagListView.FullRowSelect = true;
            this.tagListView.Location = new System.Drawing.Point(0, 0);
            this.tagListView.Name = "tagListView";
            this.tagListView.Size = new System.Drawing.Size(378, 261);
            this.tagListView.TabIndex = 22;
            this.tagListView.View = System.Windows.Forms.View.Details;
            this.tagListView.SelectedIndexChanged += new System.EventHandler(this.tagListView_SelectedIndexChanged);
            // 
            // rssiHeader
            // 
            this.rssiHeader.Text = "rssi";
            this.rssiHeader.Width = 25;
            // 
            // epcHeader
            // 
            this.epcHeader.Text = "EPC or DATA";
            this.epcHeader.Width = 140;
            // 
            // dataHeader
            // 
            this.dataHeader.Text = "DATA";
            this.dataHeader.Width = 150;
            // 
            // NurTagDataListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tagListView);
            this.Name = "NurTagDataListView";
            this.Size = new System.Drawing.Size(378, 261);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView tagListView;
        private System.Windows.Forms.ColumnHeader epcHeader;
        private System.Windows.Forms.ColumnHeader dataHeader;
        private System.Windows.Forms.ColumnHeader rssiHeader;
    }
}
