namespace EM4325Test
{
	partial class CustomConfigDlg
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
			this.UnderCountEdit = new System.Windows.Forms.TextBox();
			this.UnderThreshEdit = new System.Windows.Forms.TextBox();
			this.DelayCountEdit = new System.Windows.Forms.TextBox();
			this.ResetAlarmsChk = new System.Windows.Forms.CheckBox();
			this.StampChk = new System.Windows.Forms.CheckBox();
			this.grpUnder = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.grpTiming = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.DelayUnitSel = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.OverCountEdit = new System.Windows.Forms.TextBox();
			this.OverThreshEdit = new System.Windows.Forms.TextBox();
			this.grpInterval = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.IntvalUnitSel = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.IntvalCountEdit = new System.Windows.Forms.TextBox();
			this.grpOther = new System.Windows.Forms.GroupBox();
			this.CencelBtn = new System.Windows.Forms.Button();
			this.OKBtn = new System.Windows.Forms.Button();
			this.grpUnder.SuspendLayout();
			this.grpTiming.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.grpInterval.SuspendLayout();
			this.grpOther.SuspendLayout();
			this.SuspendLayout();
			// 
			// UnderCountEdit
			// 
			this.UnderCountEdit.Location = new System.Drawing.Point(157, 25);
			this.UnderCountEdit.Name = "UnderCountEdit";
			this.UnderCountEdit.Size = new System.Drawing.Size(81, 20);
			this.UnderCountEdit.TabIndex = 1;
			// 
			// UnderThreshEdit
			// 
			this.UnderThreshEdit.Location = new System.Drawing.Point(157, 51);
			this.UnderThreshEdit.Name = "UnderThreshEdit";
			this.UnderThreshEdit.Size = new System.Drawing.Size(81, 20);
			this.UnderThreshEdit.TabIndex = 2;
			// 
			// DelayCountEdit
			// 
			this.DelayCountEdit.Location = new System.Drawing.Point(157, 52);
			this.DelayCountEdit.Name = "DelayCountEdit";
			this.DelayCountEdit.Size = new System.Drawing.Size(81, 20);
			this.DelayCountEdit.TabIndex = 6;
			// 
			// ResetAlarmsChk
			// 
			this.ResetAlarmsChk.AutoSize = true;
			this.ResetAlarmsChk.Location = new System.Drawing.Point(33, 28);
			this.ResetAlarmsChk.Name = "ResetAlarmsChk";
			this.ResetAlarmsChk.Size = new System.Drawing.Size(118, 17);
			this.ResetAlarmsChk.TabIndex = 8;
			this.ResetAlarmsChk.Text = "Enable reset alarms";
			this.ResetAlarmsChk.UseVisualStyleBackColor = true;
			// 
			// StampChk
			// 
			this.StampChk.AutoSize = true;
			this.StampChk.Enabled = false;
			this.StampChk.Location = new System.Drawing.Point(309, 28);
			this.StampChk.Name = "StampChk";
			this.StampChk.Size = new System.Drawing.Size(121, 17);
			this.StampChk.TabIndex = 9;
			this.StampChk.Text = "Time stamp required";
			this.StampChk.UseVisualStyleBackColor = true;
			// 
			// grpUnder
			// 
			this.grpUnder.Controls.Add(this.label4);
			this.grpUnder.Controls.Add(this.label3);
			this.grpUnder.Controls.Add(this.UnderCountEdit);
			this.grpUnder.Controls.Add(this.UnderThreshEdit);
			this.grpUnder.Location = new System.Drawing.Point(13, 15);
			this.grpUnder.Name = "grpUnder";
			this.grpUnder.Size = new System.Drawing.Size(244, 94);
			this.grpUnder.TabIndex = 10;
			this.grpUnder.TabStop = false;
			this.grpUnder.Text = "Under temperature";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(22, 54);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(129, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "Threshold (-64.00...63.75)";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(4, 28);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(147, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Nr of samples till alarm (1...31)";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// grpTiming
			// 
			this.grpTiming.Controls.Add(this.label2);
			this.grpTiming.Controls.Add(this.DelayUnitSel);
			this.grpTiming.Controls.Add(this.label1);
			this.grpTiming.Controls.Add(this.DelayCountEdit);
			this.grpTiming.Location = new System.Drawing.Point(13, 115);
			this.grpTiming.Name = "grpTiming";
			this.grpTiming.Size = new System.Drawing.Size(244, 92);
			this.grpTiming.TabIndex = 12;
			this.grpTiming.TabStop = false;
			this.grpTiming.Text = "Delay timing setup";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(47, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Unit setup";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// DelayUnitSel
			// 
			this.DelayUnitSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.DelayUnitSel.FormattingEnabled = true;
			this.DelayUnitSel.Items.AddRange(new object[] {
            "00: 1 second",
            "01: 1 minute",
            "10: 1 hour",
            "11: 1 sampling interval"});
			this.DelayUnitSel.Location = new System.Drawing.Point(108, 19);
			this.DelayUnitSel.Name = "DelayUnitSel";
			this.DelayUnitSel.Size = new System.Drawing.Size(130, 21);
			this.DelayUnitSel.TabIndex = 8;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(26, 55);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(117, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Number of units (1...63)";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.OverCountEdit);
			this.groupBox1.Controls.Add(this.OverThreshEdit);
			this.groupBox1.Location = new System.Drawing.Point(263, 15);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(244, 94);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Under temperature";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(22, 54);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(129, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Threshold (-64.00...63.75)";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(4, 28);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(147, 13);
			this.label6.TabIndex = 9;
			this.label6.Text = "Nr of samples till alarm (1...31)";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// OverCountEdit
			// 
			this.OverCountEdit.Location = new System.Drawing.Point(157, 25);
			this.OverCountEdit.Name = "OverCountEdit";
			this.OverCountEdit.Size = new System.Drawing.Size(81, 20);
			this.OverCountEdit.TabIndex = 1;
			// 
			// OverThreshEdit
			// 
			this.OverThreshEdit.Location = new System.Drawing.Point(157, 51);
			this.OverThreshEdit.Name = "OverThreshEdit";
			this.OverThreshEdit.Size = new System.Drawing.Size(81, 20);
			this.OverThreshEdit.TabIndex = 3;
			// 
			// grpInterval
			// 
			this.grpInterval.Controls.Add(this.label7);
			this.grpInterval.Controls.Add(this.IntvalUnitSel);
			this.grpInterval.Controls.Add(this.label8);
			this.grpInterval.Controls.Add(this.IntvalCountEdit);
			this.grpInterval.Location = new System.Drawing.Point(263, 115);
			this.grpInterval.Name = "grpInterval";
			this.grpInterval.Size = new System.Drawing.Size(244, 92);
			this.grpInterval.TabIndex = 13;
			this.grpInterval.TabStop = false;
			this.grpInterval.Text = "Interval setup";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(47, 22);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(55, 13);
			this.label7.TabIndex = 9;
			this.label7.Text = "Unit setup";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// IntvalUnitSel
			// 
			this.IntvalUnitSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.IntvalUnitSel.FormattingEnabled = true;
			this.IntvalUnitSel.Items.AddRange(new object[] {
            "00: 1 second",
            "01: 1 minute",
            "10: 1 hour",
            "11: 5 minutes"});
			this.IntvalUnitSel.Location = new System.Drawing.Point(108, 19);
			this.IntvalUnitSel.Name = "IntvalUnitSel";
			this.IntvalUnitSel.Size = new System.Drawing.Size(130, 21);
			this.IntvalUnitSel.TabIndex = 8;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(26, 55);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(117, 13);
			this.label8.TabIndex = 7;
			this.label8.Text = "Number of units (1...63)";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// IntvalCountEdit
			// 
			this.IntvalCountEdit.Location = new System.Drawing.Point(157, 52);
			this.IntvalCountEdit.Name = "IntvalCountEdit";
			this.IntvalCountEdit.Size = new System.Drawing.Size(81, 20);
			this.IntvalCountEdit.TabIndex = 6;
			// 
			// grpOther
			// 
			this.grpOther.Controls.Add(this.ResetAlarmsChk);
			this.grpOther.Controls.Add(this.StampChk);
			this.grpOther.Location = new System.Drawing.Point(13, 213);
			this.grpOther.Name = "grpOther";
			this.grpOther.Size = new System.Drawing.Size(494, 65);
			this.grpOther.TabIndex = 14;
			this.grpOther.TabStop = false;
			this.grpOther.Text = "Other";
			// 
			// CencelBtn
			// 
			this.CencelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CencelBtn.Location = new System.Drawing.Point(13, 287);
			this.CencelBtn.Name = "CencelBtn";
			this.CencelBtn.Size = new System.Drawing.Size(92, 30);
			this.CencelBtn.TabIndex = 15;
			this.CencelBtn.Text = "Cancel";
			this.CencelBtn.UseVisualStyleBackColor = true;
			this.CencelBtn.Click += new System.EventHandler(this.CencelBtn_Click);
			// 
			// OKBtn
			// 
			this.OKBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OKBtn.Location = new System.Drawing.Point(415, 287);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(92, 30);
			this.OKBtn.TabIndex = 16;
			this.OKBtn.Text = "Start";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CustomConfigDlg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(520, 328);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.CencelBtn);
			this.Controls.Add(this.grpOther);
			this.Controls.Add(this.grpInterval);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.grpTiming);
			this.Controls.Add(this.grpUnder);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "CustomConfigDlg";
			this.Text = "SimpleConfigDlg";
			this.grpUnder.ResumeLayout(false);
			this.grpUnder.PerformLayout();
			this.grpTiming.ResumeLayout(false);
			this.grpTiming.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.grpInterval.ResumeLayout(false);
			this.grpInterval.PerformLayout();
			this.grpOther.ResumeLayout(false);
			this.grpOther.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox UnderCountEdit;
		private System.Windows.Forms.TextBox UnderThreshEdit;
		private System.Windows.Forms.TextBox DelayCountEdit;
		private System.Windows.Forms.CheckBox ResetAlarmsChk;
		private System.Windows.Forms.CheckBox StampChk;
		private System.Windows.Forms.GroupBox grpUnder;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox grpTiming;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox DelayUnitSel;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox OverCountEdit;
		private System.Windows.Forms.TextBox OverThreshEdit;
		private System.Windows.Forms.GroupBox grpInterval;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox IntvalUnitSel;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox IntvalCountEdit;
		private System.Windows.Forms.GroupBox grpOther;
		private System.Windows.Forms.Button CencelBtn;
		private System.Windows.Forms.Button OKBtn;
	}
}