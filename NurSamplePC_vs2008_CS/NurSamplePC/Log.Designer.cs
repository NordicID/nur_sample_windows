namespace NurSample
{
    partial class Log
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.logListBox = new System.Windows.Forms.ListBox();
            this.logDataCheckBox = new System.Windows.Forms.CheckBox();
            this.logErrorCheckBox = new System.Windows.Forms.CheckBox();
            this.logUserCheckBox = new System.Windows.Forms.CheckBox();
            this.logVerboseCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.clearButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.logToFileButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // logListBox
            // 
            this.logListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logListBox.FormattingEnabled = true;
            this.logListBox.Location = new System.Drawing.Point(3, 3);
            this.logListBox.Name = "logListBox";
            this.logListBox.Size = new System.Drawing.Size(403, 238);
            this.logListBox.TabIndex = 0;
            // 
            // logDataCheckBox
            // 
            this.logDataCheckBox.AutoSize = true;
            this.logDataCheckBox.Location = new System.Drawing.Point(303, 3);
            this.logDataCheckBox.Name = "logDataCheckBox";
            this.logDataCheckBox.Size = new System.Drawing.Size(83, 17);
            this.logDataCheckBox.TabIndex = 1;
            this.logDataCheckBox.Text = "LOG_DATA";
            this.logDataCheckBox.UseVisualStyleBackColor = true;
            this.logDataCheckBox.CheckedChanged += new System.EventHandler(this.logDataCheckBox_CheckedChanged);
            // 
            // logErrorCheckBox
            // 
            this.logErrorCheckBox.AutoSize = true;
            this.logErrorCheckBox.Location = new System.Drawing.Point(114, 3);
            this.logErrorCheckBox.Name = "logErrorCheckBox";
            this.logErrorCheckBox.Size = new System.Drawing.Size(93, 17);
            this.logErrorCheckBox.TabIndex = 2;
            this.logErrorCheckBox.Text = "LOG_ERROR";
            this.logErrorCheckBox.UseVisualStyleBackColor = true;
            this.logErrorCheckBox.CheckedChanged += new System.EventHandler(this.logErrorCheckBox_CheckedChanged);
            // 
            // logUserCheckBox
            // 
            this.logUserCheckBox.AutoSize = true;
            this.logUserCheckBox.Location = new System.Drawing.Point(213, 3);
            this.logUserCheckBox.Name = "logUserCheckBox";
            this.logUserCheckBox.Size = new System.Drawing.Size(84, 17);
            this.logUserCheckBox.TabIndex = 3;
            this.logUserCheckBox.Text = "LOG_USER";
            this.logUserCheckBox.UseVisualStyleBackColor = true;
            this.logUserCheckBox.CheckedChanged += new System.EventHandler(this.logUserCheckBox_CheckedChanged);
            // 
            // logVerboseCheckBox
            // 
            this.logVerboseCheckBox.AutoSize = true;
            this.logVerboseCheckBox.Location = new System.Drawing.Point(3, 3);
            this.logVerboseCheckBox.Name = "logVerboseCheckBox";
            this.logVerboseCheckBox.Size = new System.Drawing.Size(105, 17);
            this.logVerboseCheckBox.TabIndex = 4;
            this.logVerboseCheckBox.Text = "LOG_VERBOSE";
            this.logVerboseCheckBox.UseVisualStyleBackColor = true;
            this.logVerboseCheckBox.CheckedChanged += new System.EventHandler(this.logVerboseCheckBox_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.logListBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(409, 310);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.logVerboseCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.logErrorCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.logUserCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.logDataCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.clearButton);
            this.flowLayoutPanel1.Controls.Add(this.saveButton);
            this.flowLayoutPanel1.Controls.Add(this.logToFileButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 255);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(403, 52);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(3, 26);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 5;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(84, 26);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // logToFileButton
            // 
            this.logToFileButton.Location = new System.Drawing.Point(165, 26);
            this.logToFileButton.Name = "logToFileButton";
            this.logToFileButton.Size = new System.Drawing.Size(150, 23);
            this.logToFileButton.TabIndex = 7;
            this.logToFileButton.Text = "Log To File";
            this.logToFileButton.UseVisualStyleBackColor = true;
            this.logToFileButton.Click += new System.EventHandler(this.logToFileButton_Click);
            // 
            // Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Log";
            this.Size = new System.Drawing.Size(409, 310);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox logListBox;
        private System.Windows.Forms.CheckBox logDataCheckBox;
        private System.Windows.Forms.CheckBox logErrorCheckBox;
        private System.Windows.Forms.CheckBox logUserCheckBox;
        private System.Windows.Forms.CheckBox logVerboseCheckBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button logToFileButton;


    }
}
