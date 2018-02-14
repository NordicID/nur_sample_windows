namespace CAENRT5WCE
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.MainMenu mainMenu1;

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
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.QuitBtn = new System.Windows.Forms.Button();
			this.ScanTagBtn = new System.Windows.Forms.Button();
			this.ControlBtn = new System.Windows.Forms.Button();
			this.StopBtn = new System.Windows.Forms.Button();
			this.DnloadBtn = new System.Windows.Forms.Button();
			this.StatusText = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// QuitBtn
			// 
			this.QuitBtn.Location = new System.Drawing.Point(16, 201);
			this.QuitBtn.Name = "QuitBtn";
			this.QuitBtn.Size = new System.Drawing.Size(168, 32);
			this.QuitBtn.TabIndex = 0;
			this.QuitBtn.Text = "Quit";
			this.QuitBtn.Click += new System.EventHandler(this.QuitBtn_Click);
			// 
			// ScanTagBtn
			// 
			this.ScanTagBtn.Location = new System.Drawing.Point(16, 14);
			this.ScanTagBtn.Name = "ScanTagBtn";
			this.ScanTagBtn.Size = new System.Drawing.Size(168, 32);
			this.ScanTagBtn.TabIndex = 1;
			this.ScanTagBtn.Text = "View tag status";
			this.ScanTagBtn.Click += new System.EventHandler(this.StatusBtn_Click);
			// 
			// ControlBtn
			// 
			this.ControlBtn.Location = new System.Drawing.Point(16, 52);
			this.ControlBtn.Name = "ControlBtn";
			this.ControlBtn.Size = new System.Drawing.Size(168, 32);
			this.ControlBtn.TabIndex = 2;
			this.ControlBtn.Text = "Start simple log";
			this.ControlBtn.Click += new System.EventHandler(this.ControlBtn_Click);
			// 
			// StopBtn
			// 
			this.StopBtn.Location = new System.Drawing.Point(16, 90);
			this.StopBtn.Name = "StopBtn";
			this.StopBtn.Size = new System.Drawing.Size(168, 32);
			this.StopBtn.TabIndex = 3;
			this.StopBtn.Text = "Stop all";
			this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
			// 
			// DnloadBtn
			// 
			this.DnloadBtn.Location = new System.Drawing.Point(16, 128);
			this.DnloadBtn.Name = "DnloadBtn";
			this.DnloadBtn.Size = new System.Drawing.Size(168, 32);
			this.DnloadBtn.TabIndex = 4;
			this.DnloadBtn.Text = "Download && save";
			this.DnloadBtn.Click += new System.EventHandler(this.DnloadBtn_Click);
			// 
			// StatusText
			// 
			this.StatusText.Location = new System.Drawing.Point(16, 163);
			this.StatusText.Name = "StatusText";
			this.StatusText.Size = new System.Drawing.Size(168, 35);
			this.StatusText.Text = "Ready";
			this.StatusText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(199, 242);
			this.ControlBox = false;
			this.Controls.Add(this.StatusText);
			this.Controls.Add(this.DnloadBtn);
			this.Controls.Add(this.StopBtn);
			this.Controls.Add(this.ControlBtn);
			this.Controls.Add(this.ScanTagBtn);
			this.Controls.Add(this.QuitBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.Text = "CAEN RT0005";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button QuitBtn;
		private System.Windows.Forms.Button ScanTagBtn;
		private System.Windows.Forms.Button ControlBtn;
		private System.Windows.Forms.Button StopBtn;
		private System.Windows.Forms.Button DnloadBtn;
		private System.Windows.Forms.Label StatusText;
	}
}

