namespace NurSample
{
    partial class Sensors
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
            this.label9 = new System.Windows.Forms.Label();
            this.tapSensorCombo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lightSensorCombo = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.invTO = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.ssTO = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.eventsList = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.invTO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ssTO)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Tap sensor";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tapSensorCombo
            // 
            this.tapSensorCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tapSensorCombo.FormattingEnabled = true;
            this.tapSensorCombo.Items.AddRange(new object[] {
            "Disabled",
            "Enabled - Send notification",
            "Enabled - Scan tag",
            "Enabled - Inventory"});
            this.tapSensorCombo.Location = new System.Drawing.Point(6, 59);
            this.tapSensorCombo.Name = "tapSensorCombo";
            this.tapSensorCombo.Size = new System.Drawing.Size(200, 21);
            this.tapSensorCombo.TabIndex = 10;
            this.tapSensorCombo.SelectedIndexChanged += new System.EventHandler(this.sensorControl_Changed);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Light sensor";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lightSensorCombo
            // 
            this.lightSensorCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lightSensorCombo.FormattingEnabled = true;
            this.lightSensorCombo.Items.AddRange(new object[] {
            "Disabled",
            "Enabled - Send notification",
            "Enabled - Scan tag",
            "Enabled - Inventory"});
            this.lightSensorCombo.Location = new System.Drawing.Point(6, 17);
            this.lightSensorCombo.Name = "lightSensorCombo";
            this.lightSensorCombo.Size = new System.Drawing.Size(200, 21);
            this.lightSensorCombo.TabIndex = 11;
            this.lightSensorCombo.SelectedIndexChanged += new System.EventHandler(this.sensorControl_Changed);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 84);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(143, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "Triggered Inventory Timeout:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // invTO
            // 
            this.invTO.Location = new System.Drawing.Point(6, 101);
            this.invTO.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.invTO.Name = "invTO";
            this.invTO.Size = new System.Drawing.Size(61, 20);
            this.invTO.TabIndex = 23;
            this.invTO.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.invTO.ValueChanged += new System.EventHandler(this.sensorControl_Changed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "ms";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 125);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(142, 13);
            this.label14.TabIndex = 25;
            this.label14.Text = "Triggered Scan tag Timeout:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ssTO
            // 
            this.ssTO.Location = new System.Drawing.Point(6, 142);
            this.ssTO.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.ssTO.Name = "ssTO";
            this.ssTO.Size = new System.Drawing.Size(61, 20);
            this.ssTO.TabIndex = 26;
            this.ssTO.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.ssTO.ValueChanged += new System.EventHandler(this.sensorControl_Changed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "ms";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // eventsList
            // 
            this.eventsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.eventsList.FormattingEnabled = true;
            this.eventsList.IntegralHeight = false;
            this.eventsList.Location = new System.Drawing.Point(6, 184);
            this.eventsList.Name = "eventsList";
            this.eventsList.Size = new System.Drawing.Size(228, 120);
            this.eventsList.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Events";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Sensors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.eventsList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ssTO);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.invTO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tapSensorCombo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lightSensorCombo);
            this.Name = "Sensors";
            this.Size = new System.Drawing.Size(240, 310);
            ((System.ComponentModel.ISupportInitialize)(this.invTO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ssTO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox tapSensorCombo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox lightSensorCombo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown invTO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown ssTO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox eventsList;
        private System.Windows.Forms.Label label3;

    }
}
