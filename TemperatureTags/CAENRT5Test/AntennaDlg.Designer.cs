namespace CAENRT5Test
{
	partial class AntennaDlg
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.AntSelView = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.SelAllBtn = new System.Windows.Forms.Button();
			this.ApplyStoreBtn = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.AntSelView);
			this.groupBox1.Location = new System.Drawing.Point(12, 42);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(317, 327);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Antennas";
			// 
			// AntSelView
			// 
			this.AntSelView.CheckBoxes = true;
			this.AntSelView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.AntSelView.FullRowSelect = true;
			this.AntSelView.GridLines = true;
			this.AntSelView.Location = new System.Drawing.Point(6, 19);
			this.AntSelView.Name = "AntSelView";
			this.AntSelView.Size = new System.Drawing.Size(305, 302);
			this.AntSelView.TabIndex = 0;
			this.AntSelView.UseCompatibleStateImageBehavior = false;
			this.AntSelView.View = System.Windows.Forms.View.Details;
			this.AntSelView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.AntSelView_ItemChecked);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "En";
			this.columnHeader1.Width = 30;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "#";
			this.columnHeader2.Width = 25;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Antenna";
			this.columnHeader3.Width = 250;
			// 
			// OKBtn
			// 
			this.OKBtn.Location = new System.Drawing.Point(235, 375);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(94, 33);
			this.OKBtn.TabIndex = 1;
			this.OKBtn.Text = "OK, apply";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Location = new System.Drawing.Point(12, 375);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(94, 33);
			this.CancelBtn.TabIndex = 2;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
			// 
			// SelAllBtn
			// 
			this.SelAllBtn.Location = new System.Drawing.Point(235, 5);
			this.SelAllBtn.Name = "SelAllBtn";
			this.SelAllBtn.Size = new System.Drawing.Size(94, 33);
			this.SelAllBtn.TabIndex = 3;
			this.SelAllBtn.Text = "Select all";
			this.SelAllBtn.UseVisualStyleBackColor = true;
			this.SelAllBtn.Click += new System.EventHandler(this.SelAllBtn_Click);
			// 
			// ApplyStoreBtn
			// 
			this.ApplyStoreBtn.Location = new System.Drawing.Point(112, 375);
			this.ApplyStoreBtn.Name = "ApplyStoreBtn";
			this.ApplyStoreBtn.Size = new System.Drawing.Size(117, 33);
			this.ApplyStoreBtn.TabIndex = 4;
			this.ApplyStoreBtn.Text = "Apply and store";
			this.ApplyStoreBtn.UseVisualStyleBackColor = true;
			this.ApplyStoreBtn.Click += new System.EventHandler(this.ApplyStoreBtn_Click);
			// 
			// AntennaDlg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(341, 420);
			this.ControlBox = false;
			this.Controls.Add(this.ApplyStoreBtn);
			this.Controls.Add(this.SelAllBtn);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AntennaDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select used antennas";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Button SelAllBtn;
		private System.Windows.Forms.ListView AntSelView;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.Button ApplyStoreBtn;
	}
}