/* 
  Copyright © 2014- Nordic ID 
  NORDIC ID DEMO SOFTWARE DISCLAIMER

  You are about to use Nordic ID Demo Software ("Software"). 
  It is explicitly stated that Nordic ID does not give any kind of warranties, 
  expressed or implied, for this Software. Software is provided "as is" and with 
  all faults. Under no circumstances is Nordic ID liable for any direct, special, 
  incidental or indirect damages or for any economic consequential damages to you 
  or to any third party.

  The use of this software indicates your complete and unconditional understanding 
  of the terms of this disclaimer. 
  
  IF YOU DO NOT AGREE OF THE TERMS OF THIS DISCLAIMER, DO NOT USE THE SOFTWARE.  
*/

namespace CAENRT5Test
{
	partial class MainForm
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.QuitBtn = new System.Windows.Forms.Button();
			this.ScanBtn = new System.Windows.Forms.Button();
			this.ConnGrp = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SetSetupBtn = new System.Windows.Forms.Button();
			this.GetSetupBtn = new System.Windows.Forms.Button();
			this.TxModSel = new System.Windows.Forms.ComboBox();
			this.TxLevelSel = new System.Windows.Forms.ComboBox();
			this.ConnLabel = new System.Windows.Forms.Label();
			this.RTGrp = new System.Windows.Forms.GroupBox();
			this.AutoFindChk = new System.Windows.Forms.CheckBox();
			this.TagLabel = new System.Windows.Forms.Label();
			this.ScanProgress = new System.Windows.Forms.ProgressBar();
			this.StateGrp = new System.Windows.Forms.GroupBox();
			this.ViewRegsBtn = new System.Windows.Forms.Button();
			this.RefreshBtn = new System.Windows.Forms.Button();
			this.IntvalLabel = new System.Windows.Forms.Label();
			this.DelayLabel = new System.Windows.Forms.Label();
			this.SamplesLabel = new System.Windows.Forms.Label();
			this.LoggingLabel = new System.Windows.Forms.Label();
			this.DnLoadBtn = new System.Windows.Forms.Button();
			this.SimpleGrp = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.IntvalSel = new System.Windows.Forms.ComboBox();
			this.DelaySel = new System.Windows.Forms.ComboBox();
			this.LogCtlBtn = new System.Windows.Forms.Button();
			this.SampleGrp = new System.Windows.Forms.GroupBox();
			this.AutoDlChk = new System.Windows.Forms.CheckBox();
			this.CSVExpBtn = new System.Windows.Forms.Button();
			this.SampleChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.AntennaBtn = new System.Windows.Forms.Button();
			this.ConnGrp.SuspendLayout();
			this.RTGrp.SuspendLayout();
			this.StateGrp.SuspendLayout();
			this.SimpleGrp.SuspendLayout();
			this.SampleGrp.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SampleChart)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// QuitBtn
			// 
			this.QuitBtn.Location = new System.Drawing.Point(898, 637);
			this.QuitBtn.Name = "QuitBtn";
			this.QuitBtn.Size = new System.Drawing.Size(87, 30);
			this.QuitBtn.TabIndex = 0;
			this.QuitBtn.Text = "Quit";
			this.QuitBtn.UseVisualStyleBackColor = true;
			this.QuitBtn.Click += new System.EventHandler(this.QuitBtn_Click);
			// 
			// ScanBtn
			// 
			this.ScanBtn.Enabled = false;
			this.ScanBtn.Location = new System.Drawing.Point(125, 76);
			this.ScanBtn.Name = "ScanBtn";
			this.ScanBtn.Size = new System.Drawing.Size(98, 30);
			this.ScanBtn.TabIndex = 2;
			this.ScanBtn.Text = "Scan tag";
			this.ScanBtn.UseVisualStyleBackColor = true;
			this.ScanBtn.Click += new System.EventHandler(this.StartBtn_Click);
			// 
			// ConnGrp
			// 
			this.ConnGrp.Controls.Add(this.label4);
			this.ConnGrp.Controls.Add(this.label3);
			this.ConnGrp.Controls.Add(this.SetSetupBtn);
			this.ConnGrp.Controls.Add(this.GetSetupBtn);
			this.ConnGrp.Controls.Add(this.TxModSel);
			this.ConnGrp.Controls.Add(this.TxLevelSel);
			this.ConnGrp.Controls.Add(this.ConnLabel);
			this.ConnGrp.Location = new System.Drawing.Point(12, 12);
			this.ConnGrp.Name = "ConnGrp";
			this.ConnGrp.Size = new System.Drawing.Size(239, 150);
			this.ConnGrp.TabIndex = 3;
			this.ConnGrp.TabStop = false;
			this.ConnGrp.Text = "Connection";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(22, 89);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(75, 13);
			this.label4.TabIndex = 18;
			this.label4.Text = "TX modulation";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(51, 59);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(46, 13);
			this.label3.TabIndex = 15;
			this.label3.Text = "TX level";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// SetSetupBtn
			// 
			this.SetSetupBtn.Enabled = false;
			this.SetSetupBtn.Location = new System.Drawing.Point(149, 111);
			this.SetSetupBtn.Name = "SetSetupBtn";
			this.SetSetupBtn.Size = new System.Drawing.Size(81, 27);
			this.SetSetupBtn.TabIndex = 17;
			this.SetSetupBtn.Text = "Set setup";
			this.SetSetupBtn.UseVisualStyleBackColor = true;
			// 
			// GetSetupBtn
			// 
			this.GetSetupBtn.Enabled = false;
			this.GetSetupBtn.Location = new System.Drawing.Point(13, 111);
			this.GetSetupBtn.Name = "GetSetupBtn";
			this.GetSetupBtn.Size = new System.Drawing.Size(81, 27);
			this.GetSetupBtn.TabIndex = 10;
			this.GetSetupBtn.Text = "Get setup";
			this.GetSetupBtn.UseVisualStyleBackColor = true;
			// 
			// TxModSel
			// 
			this.TxModSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.TxModSel.FormattingEnabled = true;
			this.TxModSel.Items.AddRange(new object[] {
            "TX modulation PR-ASK",
            "TX modulation ASK"});
			this.TxModSel.Location = new System.Drawing.Point(109, 85);
			this.TxModSel.Name = "TxModSel";
			this.TxModSel.Size = new System.Drawing.Size(121, 21);
			this.TxModSel.TabIndex = 16;
			// 
			// TxLevelSel
			// 
			this.TxLevelSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.TxLevelSel.FormattingEnabled = true;
			this.TxLevelSel.Items.AddRange(new object[] {
            "No delay",
            "1 minute",
            "5 minutes",
            "15 minutes",
            "30 minutes",
            "1 hour"});
			this.TxLevelSel.Location = new System.Drawing.Point(109, 55);
			this.TxLevelSel.Name = "TxLevelSel";
			this.TxLevelSel.Size = new System.Drawing.Size(121, 21);
			this.TxLevelSel.TabIndex = 15;
			// 
			// ConnLabel
			// 
			this.ConnLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ConnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ConnLabel.Location = new System.Drawing.Point(13, 21);
			this.ConnLabel.Name = "ConnLabel";
			this.ConnLabel.Size = new System.Drawing.Size(217, 27);
			this.ConnLabel.TabIndex = 0;
			this.ConnLabel.Text = "Not connected";
			this.ConnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// RTGrp
			// 
			this.RTGrp.Controls.Add(this.AntennaBtn);
			this.RTGrp.Controls.Add(this.AutoFindChk);
			this.RTGrp.Controls.Add(this.TagLabel);
			this.RTGrp.Controls.Add(this.ScanBtn);
			this.RTGrp.Location = new System.Drawing.Point(257, 12);
			this.RTGrp.Name = "RTGrp";
			this.RTGrp.Size = new System.Drawing.Size(235, 150);
			this.RTGrp.TabIndex = 4;
			this.RTGrp.TabStop = false;
			this.RTGrp.Text = "Tag";
			// 
			// AutoFindChk
			// 
			this.AutoFindChk.Location = new System.Drawing.Point(6, 112);
			this.AutoFindChk.Name = "AutoFindChk";
			this.AutoFindChk.Size = new System.Drawing.Size(217, 24);
			this.AutoFindChk.TabIndex = 2;
			this.AutoFindChk.Text = "Scan tag when connected";
			this.AutoFindChk.UseVisualStyleBackColor = true;
			// 
			// TagLabel
			// 
			this.TagLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TagLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TagLabel.Location = new System.Drawing.Point(6, 21);
			this.TagLabel.Name = "TagLabel";
			this.TagLabel.Size = new System.Drawing.Size(217, 27);
			this.TagLabel.TabIndex = 1;
			this.TagLabel.Text = "No tag";
			this.TagLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ScanProgress
			// 
			this.ScanProgress.Location = new System.Drawing.Point(8, 25);
			this.ScanProgress.Name = "ScanProgress";
			this.ScanProgress.Size = new System.Drawing.Size(459, 19);
			this.ScanProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.ScanProgress.TabIndex = 3;
			// 
			// StateGrp
			// 
			this.StateGrp.Controls.Add(this.ViewRegsBtn);
			this.StateGrp.Controls.Add(this.RefreshBtn);
			this.StateGrp.Controls.Add(this.IntvalLabel);
			this.StateGrp.Controls.Add(this.DelayLabel);
			this.StateGrp.Controls.Add(this.SamplesLabel);
			this.StateGrp.Controls.Add(this.LoggingLabel);
			this.StateGrp.Location = new System.Drawing.Point(507, 12);
			this.StateGrp.Name = "StateGrp";
			this.StateGrp.Size = new System.Drawing.Size(267, 150);
			this.StateGrp.TabIndex = 5;
			this.StateGrp.TabStop = false;
			this.StateGrp.Text = "Simple (BIN 0) state";
			// 
			// ViewRegsBtn
			// 
			this.ViewRegsBtn.Enabled = false;
			this.ViewRegsBtn.Location = new System.Drawing.Point(135, 60);
			this.ViewRegsBtn.Name = "ViewRegsBtn";
			this.ViewRegsBtn.Size = new System.Drawing.Size(123, 27);
			this.ViewRegsBtn.TabIndex = 9;
			this.ViewRegsBtn.Text = "Registers && alarms";
			this.ViewRegsBtn.UseVisualStyleBackColor = true;
			this.ViewRegsBtn.Click += new System.EventHandler(this.ViewRegsBtn_Click);
			// 
			// RefreshBtn
			// 
			this.RefreshBtn.Enabled = false;
			this.RefreshBtn.Location = new System.Drawing.Point(135, 98);
			this.RefreshBtn.Name = "RefreshBtn";
			this.RefreshBtn.Size = new System.Drawing.Size(123, 27);
			this.RefreshBtn.TabIndex = 8;
			this.RefreshBtn.Text = "Refresh";
			this.RefreshBtn.UseVisualStyleBackColor = true;
			this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
			// 
			// IntvalLabel
			// 
			this.IntvalLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.IntvalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IntvalLabel.Location = new System.Drawing.Point(135, 21);
			this.IntvalLabel.Name = "IntvalLabel";
			this.IntvalLabel.Size = new System.Drawing.Size(123, 27);
			this.IntvalLabel.TabIndex = 6;
			this.IntvalLabel.Text = "Interval N / A";
			this.IntvalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// DelayLabel
			// 
			this.DelayLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.DelayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DelayLabel.Location = new System.Drawing.Point(6, 98);
			this.DelayLabel.Name = "DelayLabel";
			this.DelayLabel.Size = new System.Drawing.Size(123, 27);
			this.DelayLabel.TabIndex = 5;
			this.DelayLabel.Text = "Delay N / A";
			this.DelayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// SamplesLabel
			// 
			this.SamplesLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.SamplesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SamplesLabel.Location = new System.Drawing.Point(6, 60);
			this.SamplesLabel.Name = "SamplesLabel";
			this.SamplesLabel.Size = new System.Drawing.Size(123, 27);
			this.SamplesLabel.TabIndex = 4;
			this.SamplesLabel.Text = "Samples N / A";
			this.SamplesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// LoggingLabel
			// 
			this.LoggingLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.LoggingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LoggingLabel.Location = new System.Drawing.Point(6, 21);
			this.LoggingLabel.Name = "LoggingLabel";
			this.LoggingLabel.Size = new System.Drawing.Size(123, 27);
			this.LoggingLabel.TabIndex = 3;
			this.LoggingLabel.Text = "Logging: N/A";
			this.LoggingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// DnLoadBtn
			// 
			this.DnLoadBtn.Enabled = false;
			this.DnLoadBtn.Location = new System.Drawing.Point(13, 19);
			this.DnLoadBtn.Name = "DnLoadBtn";
			this.DnLoadBtn.Size = new System.Drawing.Size(123, 27);
			this.DnLoadBtn.TabIndex = 9;
			this.DnLoadBtn.Text = "Download samples";
			this.DnLoadBtn.UseVisualStyleBackColor = true;
			this.DnLoadBtn.Click += new System.EventHandler(this.DnLoadBtn_Click);
			// 
			// SimpleGrp
			// 
			this.SimpleGrp.Controls.Add(this.label2);
			this.SimpleGrp.Controls.Add(this.label1);
			this.SimpleGrp.Controls.Add(this.IntvalSel);
			this.SimpleGrp.Controls.Add(this.DelaySel);
			this.SimpleGrp.Controls.Add(this.LogCtlBtn);
			this.SimpleGrp.Location = new System.Drawing.Point(780, 12);
			this.SimpleGrp.Name = "SimpleGrp";
			this.SimpleGrp.Size = new System.Drawing.Size(205, 150);
			this.SimpleGrp.TabIndex = 7;
			this.SimpleGrp.TabStop = false;
			this.SimpleGrp.Text = "Simple log setup";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(22, 63);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(42, 13);
			this.label2.TabIndex = 14;
			this.label2.Text = "Interval";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(30, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 13);
			this.label1.TabIndex = 13;
			this.label1.Text = "Delay";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// IntvalSel
			// 
			this.IntvalSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.IntvalSel.FormattingEnabled = true;
			this.IntvalSel.Items.AddRange(new object[] {
            "1 minute",
            "2 minutes",
            "5 minutes",
            "15 minutes",
            "30 minutes",
            "1 hour"});
			this.IntvalSel.Location = new System.Drawing.Point(71, 60);
			this.IntvalSel.Name = "IntvalSel";
			this.IntvalSel.Size = new System.Drawing.Size(121, 21);
			this.IntvalSel.TabIndex = 12;
			// 
			// DelaySel
			// 
			this.DelaySel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.DelaySel.FormattingEnabled = true;
			this.DelaySel.Items.AddRange(new object[] {
            "No delay",
            "1 minute",
            "2 minutes",
            "5 minutes",
            "15 minutes",
            "30 minutes",
            "1 hour"});
			this.DelaySel.Location = new System.Drawing.Point(71, 25);
			this.DelaySel.Name = "DelaySel";
			this.DelaySel.Size = new System.Drawing.Size(121, 21);
			this.DelaySel.TabIndex = 11;
			// 
			// LogCtlBtn
			// 
			this.LogCtlBtn.Enabled = false;
			this.LogCtlBtn.Location = new System.Drawing.Point(17, 98);
			this.LogCtlBtn.Name = "LogCtlBtn";
			this.LogCtlBtn.Size = new System.Drawing.Size(175, 27);
			this.LogCtlBtn.TabIndex = 10;
			this.LogCtlBtn.Text = "Setup && start";
			this.LogCtlBtn.UseVisualStyleBackColor = true;
			this.LogCtlBtn.Click += new System.EventHandler(this.LogCtlBtn_Click);
			// 
			// SampleGrp
			// 
			this.SampleGrp.Controls.Add(this.AutoDlChk);
			this.SampleGrp.Controls.Add(this.CSVExpBtn);
			this.SampleGrp.Controls.Add(this.DnLoadBtn);
			this.SampleGrp.Location = new System.Drawing.Point(12, 168);
			this.SampleGrp.Name = "SampleGrp";
			this.SampleGrp.Size = new System.Drawing.Size(480, 63);
			this.SampleGrp.TabIndex = 8;
			this.SampleGrp.TabStop = false;
			this.SampleGrp.Text = "Samples";
			// 
			// AutoDlChk
			// 
			this.AutoDlChk.Location = new System.Drawing.Point(281, 20);
			this.AutoDlChk.Name = "AutoDlChk";
			this.AutoDlChk.Size = new System.Drawing.Size(178, 24);
			this.AutoDlChk.TabIndex = 4;
			this.AutoDlChk.Text = "Automatic sample download";
			this.AutoDlChk.UseVisualStyleBackColor = true;
			// 
			// CSVExpBtn
			// 
			this.CSVExpBtn.Enabled = false;
			this.CSVExpBtn.Location = new System.Drawing.Point(149, 19);
			this.CSVExpBtn.Name = "CSVExpBtn";
			this.CSVExpBtn.Size = new System.Drawing.Size(123, 27);
			this.CSVExpBtn.TabIndex = 10;
			this.CSVExpBtn.Text = "Export to CSV";
			this.CSVExpBtn.UseVisualStyleBackColor = true;
			this.CSVExpBtn.Click += new System.EventHandler(this.CSVExpBtn_Click);
			// 
			// SampleChart
			// 
			chartArea2.Name = "TempArea";
			this.SampleChart.ChartAreas.Add(chartArea2);
			legend2.Name = "Legend1";
			this.SampleChart.Legends.Add(legend2);
			this.SampleChart.Location = new System.Drawing.Point(12, 237);
			this.SampleChart.Name = "SampleChart";
			series2.ChartArea = "TempArea";
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
			series2.Legend = "Legend1";
			series2.Name = "Temperature";
			this.SampleChart.Series.Add(series2);
			this.SampleChart.Size = new System.Drawing.Size(973, 385);
			this.SampleChart.TabIndex = 9;
			this.SampleChart.Text = "chart1";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.ScanProgress);
			this.groupBox1.Location = new System.Drawing.Point(505, 168);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(480, 63);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Progress";
			// 
			// AntennaBtn
			// 
			this.AntennaBtn.Enabled = false;
			this.AntennaBtn.Location = new System.Drawing.Point(6, 76);
			this.AntennaBtn.Name = "AntennaBtn";
			this.AntennaBtn.Size = new System.Drawing.Size(98, 30);
			this.AntennaBtn.TabIndex = 3;
			this.AntennaBtn.Text = "Antenna";
			this.AntennaBtn.UseVisualStyleBackColor = true;
			this.AntennaBtn.Click += new System.EventHandler(this.AntennaBtn_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1004, 679);
			this.ControlBox = false;
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.SampleChart);
			this.Controls.Add(this.SampleGrp);
			this.Controls.Add(this.SimpleGrp);
			this.Controls.Add(this.StateGrp);
			this.Controls.Add(this.RTGrp);
			this.Controls.Add(this.ConnGrp);
			this.Controls.Add(this.QuitBtn);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.Text = "CAEN RT0005 test";
			this.ConnGrp.ResumeLayout(false);
			this.ConnGrp.PerformLayout();
			this.RTGrp.ResumeLayout(false);
			this.StateGrp.ResumeLayout(false);
			this.SimpleGrp.ResumeLayout(false);
			this.SimpleGrp.PerformLayout();
			this.SampleGrp.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.SampleChart)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button QuitBtn;
		private System.Windows.Forms.Button ScanBtn;
		private System.Windows.Forms.GroupBox ConnGrp;
		private System.Windows.Forms.GroupBox RTGrp;
		private System.Windows.Forms.Label ConnLabel;
		private System.Windows.Forms.Label TagLabel;
		private System.Windows.Forms.CheckBox AutoFindChk;
		private System.Windows.Forms.GroupBox StateGrp;
		private System.Windows.Forms.Label LoggingLabel;
		private System.Windows.Forms.Label SamplesLabel;
		private System.Windows.Forms.Label DelayLabel;
		private System.Windows.Forms.Label IntvalLabel;
		private System.Windows.Forms.GroupBox SimpleGrp;
		private System.Windows.Forms.Button RefreshBtn;
		private System.Windows.Forms.ProgressBar ScanProgress;
		private System.Windows.Forms.Button DnLoadBtn;
		private System.Windows.Forms.Button LogCtlBtn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox IntvalSel;
		private System.Windows.Forms.ComboBox DelaySel;
		private System.Windows.Forms.ComboBox TxModSel;
		private System.Windows.Forms.ComboBox TxLevelSel;
		private System.Windows.Forms.Button SetSetupBtn;
		private System.Windows.Forms.Button GetSetupBtn;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox SampleGrp;
		private System.Windows.Forms.Button ViewRegsBtn;
		private System.Windows.Forms.Button CSVExpBtn;
		private System.Windows.Forms.DataVisualization.Charting.Chart SampleChart;
		private System.Windows.Forms.CheckBox AutoDlChk;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button AntennaBtn;
	}
}

