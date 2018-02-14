namespace CAENRT5Test
{
	partial class RTRegsForm
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
			this.UpdateBtn = new System.Windows.Forms.Button();
			this.CloseBtn = new System.Windows.Forms.Button();
			this.RegList = new System.Windows.Forms.ListView();
			this.Status = new System.Windows.Forms.Label();
			this.NameHdr = new System.Windows.Forms.ColumnHeader();
			this.HexHdr = new System.Windows.Forms.ColumnHeader();
			this.DecHdr = new System.Windows.Forms.ColumnHeader();
			this.NoteHdr = new System.Windows.Forms.ColumnHeader();
			this.AddrHdr = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// UpdateBtn
			// 
			this.UpdateBtn.Location = new System.Drawing.Point(12, 287);
			this.UpdateBtn.Name = "UpdateBtn";
			this.UpdateBtn.Size = new System.Drawing.Size(80, 31);
			this.UpdateBtn.TabIndex = 0;
			this.UpdateBtn.Text = "Update";
			this.UpdateBtn.UseVisualStyleBackColor = true;
			this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
			// 
			// CloseBtn
			// 
			this.CloseBtn.Location = new System.Drawing.Point(487, 287);
			this.CloseBtn.Name = "CloseBtn";
			this.CloseBtn.Size = new System.Drawing.Size(80, 31);
			this.CloseBtn.TabIndex = 1;
			this.CloseBtn.Text = "Close";
			this.CloseBtn.UseVisualStyleBackColor = true;
			this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
			// 
			// RegList
			// 
			this.RegList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AddrHdr,
            this.NameHdr,
            this.HexHdr,
            this.DecHdr,
            this.NoteHdr});
			this.RegList.Location = new System.Drawing.Point(12, 12);
			this.RegList.Name = "RegList";
			this.RegList.Size = new System.Drawing.Size(564, 238);
			this.RegList.TabIndex = 2;
			this.RegList.UseCompatibleStateImageBehavior = false;
			this.RegList.View = System.Windows.Forms.View.Details;
			// 
			// Status
			// 
			this.Status.Location = new System.Drawing.Point(12, 259);
			this.Status.Name = "Status";
			this.Status.Size = new System.Drawing.Size(564, 23);
			this.Status.TabIndex = 3;
			this.Status.Text = "---";
			this.Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// NameHdr
			// 
			this.NameHdr.Text = "Register";
			this.NameHdr.Width = 150;
			// 
			// HexHdr
			// 
			this.HexHdr.Text = "Hex";
			// 
			// DecHdr
			// 
			this.DecHdr.Text = "Dec";
			// 
			// NoteHdr
			// 
			this.NoteHdr.Text = "Note";
			this.NoteHdr.Width = 139;
			// 
			// AddrHdr
			// 
			this.AddrHdr.Text = "Address";
			// 
			// RTRegsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(588, 330);
			this.ControlBox = false;
			this.Controls.Add(this.Status);
			this.Controls.Add(this.RegList);
			this.Controls.Add(this.CloseBtn);
			this.Controls.Add(this.UpdateBtn);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "RTRegsForm";
			this.Text = "RT0005 basic registers";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RTRegsForm_FormClosing);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button UpdateBtn;
		private System.Windows.Forms.Button CloseBtn;
		private System.Windows.Forms.ListView RegList;
		private System.Windows.Forms.Label Status;
		private System.Windows.Forms.ColumnHeader NameHdr;
		private System.Windows.Forms.ColumnHeader HexHdr;
		private System.Windows.Forms.ColumnHeader DecHdr;
		private System.Windows.Forms.ColumnHeader NoteHdr;
		private System.Windows.Forms.ColumnHeader AddrHdr;
	}
}