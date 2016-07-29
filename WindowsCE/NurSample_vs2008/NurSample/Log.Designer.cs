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
            this.logDataCheckBox = new System.Windows.Forms.CheckBox();
            this.logErrorCheckBox = new System.Windows.Forms.CheckBox();
            this.logUserCheckBox = new System.Windows.Forms.CheckBox();
            this.logVerboseCheckBox = new System.Windows.Forms.CheckBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.logToFileButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.logListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // logDataCheckBox
            // 
            this.logDataCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.logDataCheckBox.Location = new System.Drawing.Point(109, 261);
            this.logDataCheckBox.Name = "logDataCheckBox";
            this.logDataCheckBox.Size = new System.Drawing.Size(100, 17);
            this.logDataCheckBox.TabIndex = 1;
            this.logDataCheckBox.Text = "DATA";
            this.logDataCheckBox.CheckStateChanged += new System.EventHandler(this.logDataCheckBox_CheckedChanged);
            // 
            // logErrorCheckBox
            // 
            this.logErrorCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.logErrorCheckBox.Location = new System.Drawing.Point(3, 261);
            this.logErrorCheckBox.Name = "logErrorCheckBox";
            this.logErrorCheckBox.Size = new System.Drawing.Size(100, 17);
            this.logErrorCheckBox.TabIndex = 2;
            this.logErrorCheckBox.Text = "ERROR";
            this.logErrorCheckBox.CheckStateChanged += new System.EventHandler(this.logErrorCheckBox_CheckedChanged);
            // 
            // logUserCheckBox
            // 
            this.logUserCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.logUserCheckBox.Location = new System.Drawing.Point(109, 238);
            this.logUserCheckBox.Name = "logUserCheckBox";
            this.logUserCheckBox.Size = new System.Drawing.Size(100, 17);
            this.logUserCheckBox.TabIndex = 3;
            this.logUserCheckBox.Text = "USER";
            this.logUserCheckBox.CheckStateChanged += new System.EventHandler(this.logUserCheckBox_CheckedChanged);
            // 
            // logVerboseCheckBox
            // 
            this.logVerboseCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.logVerboseCheckBox.Location = new System.Drawing.Point(3, 238);
            this.logVerboseCheckBox.Name = "logVerboseCheckBox";
            this.logVerboseCheckBox.Size = new System.Drawing.Size(100, 17);
            this.logVerboseCheckBox.TabIndex = 4;
            this.logVerboseCheckBox.Text = "VERBOSE";
            this.logVerboseCheckBox.CheckStateChanged += new System.EventHandler(this.logVerboseCheckBox_CheckedChanged);
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clearButton.Location = new System.Drawing.Point(3, 284);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(55, 23);
            this.clearButton.TabIndex = 5;
            this.clearButton.Text = "Clear";
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.Location = new System.Drawing.Point(64, 284);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(55, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Save";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // logToFileButton
            // 
            this.logToFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.logToFileButton.Location = new System.Drawing.Point(125, 284);
            this.logToFileButton.Name = "logToFileButton";
            this.logToFileButton.Size = new System.Drawing.Size(281, 23);
            this.logToFileButton.TabIndex = 7;
            this.logToFileButton.Text = "Log To File";
            this.logToFileButton.Click += new System.EventHandler(this.logToFileButton_Click);
            // 
            // logListBox
            // 
            this.logListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.logListBox.Location = new System.Drawing.Point(3, 3);
            this.logListBox.Name = "logListBox";
            this.logListBox.Size = new System.Drawing.Size(403, 226);
            this.logListBox.TabIndex = 8;
            // 
            // Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.logListBox);
            this.Controls.Add(this.logVerboseCheckBox);
            this.Controls.Add(this.logErrorCheckBox);
            this.Controls.Add(this.logUserCheckBox);
            this.Controls.Add(this.logDataCheckBox);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.logToFileButton);
            this.Name = "Log";
            this.Size = new System.Drawing.Size(409, 310);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox logDataCheckBox;
        private System.Windows.Forms.CheckBox logErrorCheckBox;
        private System.Windows.Forms.CheckBox logUserCheckBox;
        private System.Windows.Forms.CheckBox logVerboseCheckBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button logToFileButton;
        private System.Windows.Forms.ListBox logListBox;


    }
}
