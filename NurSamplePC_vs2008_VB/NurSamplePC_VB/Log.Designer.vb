Partial Class Log
	''' <summary> 
	''' Required designer variable.
	''' </summary>
	Private components As System.ComponentModel.IContainer = Nothing

	#Region "Component Designer generated code"

	''' <summary> 
	''' Required method for Designer support - do not modify 
	''' the contents of this method with the code editor.
	''' </summary>
	Private Sub InitializeComponent()
		Me.logListBox = New System.Windows.Forms.ListBox()
		Me.logDataCheckBox = New System.Windows.Forms.CheckBox()
		Me.logErrorCheckBox = New System.Windows.Forms.CheckBox()
		Me.logUserCheckBox = New System.Windows.Forms.CheckBox()
		Me.logVerboseCheckBox = New System.Windows.Forms.CheckBox()
		Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
		Me.flowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
		Me.clearButton = New System.Windows.Forms.Button()
		Me.saveButton = New System.Windows.Forms.Button()
		Me.logToFileButton = New System.Windows.Forms.Button()
		Me.saveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
		Me.tableLayoutPanel1.SuspendLayout()
		Me.flowLayoutPanel1.SuspendLayout()
		Me.SuspendLayout()
		' 
		' logListBox
		' 
		Me.logListBox.Dock = System.Windows.Forms.DockStyle.Fill
		Me.logListBox.FormattingEnabled = True
		Me.logListBox.Location = New System.Drawing.Point(3, 3)
		Me.logListBox.Name = "logListBox"
		Me.logListBox.Size = New System.Drawing.Size(403, 238)
		Me.logListBox.TabIndex = 0
		' 
		' logDataCheckBox
		' 
		Me.logDataCheckBox.AutoSize = True
		Me.logDataCheckBox.Location = New System.Drawing.Point(303, 3)
		Me.logDataCheckBox.Name = "logDataCheckBox"
		Me.logDataCheckBox.Size = New System.Drawing.Size(83, 17)
		Me.logDataCheckBox.TabIndex = 1
		Me.logDataCheckBox.Text = "LOG_DATA"
		Me.logDataCheckBox.UseVisualStyleBackColor = True
		AddHandler Me.logDataCheckBox.CheckedChanged, New System.EventHandler(AddressOf Me.logDataCheckBox_CheckedChanged)
		' 
		' logErrorCheckBox
		' 
		Me.logErrorCheckBox.AutoSize = True
		Me.logErrorCheckBox.Location = New System.Drawing.Point(114, 3)
		Me.logErrorCheckBox.Name = "logErrorCheckBox"
		Me.logErrorCheckBox.Size = New System.Drawing.Size(93, 17)
		Me.logErrorCheckBox.TabIndex = 2
		Me.logErrorCheckBox.Text = "LOG_ERROR"
		Me.logErrorCheckBox.UseVisualStyleBackColor = True
		AddHandler Me.logErrorCheckBox.CheckedChanged, New System.EventHandler(AddressOf Me.logErrorCheckBox_CheckedChanged)
		' 
		' logUserCheckBox
		' 
		Me.logUserCheckBox.AutoSize = True
		Me.logUserCheckBox.Location = New System.Drawing.Point(213, 3)
		Me.logUserCheckBox.Name = "logUserCheckBox"
		Me.logUserCheckBox.Size = New System.Drawing.Size(84, 17)
		Me.logUserCheckBox.TabIndex = 3
		Me.logUserCheckBox.Text = "LOG_USER"
		Me.logUserCheckBox.UseVisualStyleBackColor = True
		AddHandler Me.logUserCheckBox.CheckedChanged, New System.EventHandler(AddressOf Me.logUserCheckBox_CheckedChanged)
		' 
		' logVerboseCheckBox
		' 
		Me.logVerboseCheckBox.AutoSize = True
		Me.logVerboseCheckBox.Location = New System.Drawing.Point(3, 3)
		Me.logVerboseCheckBox.Name = "logVerboseCheckBox"
		Me.logVerboseCheckBox.Size = New System.Drawing.Size(105, 17)
		Me.logVerboseCheckBox.TabIndex = 4
		Me.logVerboseCheckBox.Text = "LOG_VERBOSE"
		Me.logVerboseCheckBox.UseVisualStyleBackColor = True
		AddHandler Me.logVerboseCheckBox.CheckedChanged, New System.EventHandler(AddressOf Me.logVerboseCheckBox_CheckedChanged)
		' 
		' tableLayoutPanel1
		' 
		Me.tableLayoutPanel1.ColumnCount = 1
		Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F))
		Me.tableLayoutPanel1.Controls.Add(Me.logListBox, 0, 0)
		Me.tableLayoutPanel1.Controls.Add(Me.flowLayoutPanel1, 0, 1)
		Me.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.tableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
		Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
		Me.tableLayoutPanel1.RowCount = 2
		Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F))
		Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
		Me.tableLayoutPanel1.Size = New System.Drawing.Size(409, 310)
		Me.tableLayoutPanel1.TabIndex = 5
		' 
		' flowLayoutPanel1
		' 
		Me.flowLayoutPanel1.AutoSize = True
		Me.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.flowLayoutPanel1.Controls.Add(Me.logVerboseCheckBox)
		Me.flowLayoutPanel1.Controls.Add(Me.logErrorCheckBox)
		Me.flowLayoutPanel1.Controls.Add(Me.logUserCheckBox)
		Me.flowLayoutPanel1.Controls.Add(Me.logDataCheckBox)
		Me.flowLayoutPanel1.Controls.Add(Me.clearButton)
		Me.flowLayoutPanel1.Controls.Add(Me.saveButton)
		Me.flowLayoutPanel1.Controls.Add(Me.logToFileButton)
		Me.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.flowLayoutPanel1.Location = New System.Drawing.Point(3, 255)
		Me.flowLayoutPanel1.Name = "flowLayoutPanel1"
		Me.flowLayoutPanel1.Size = New System.Drawing.Size(403, 52)
		Me.flowLayoutPanel1.TabIndex = 1
		' 
		' clearButton
		' 
		Me.clearButton.Location = New System.Drawing.Point(3, 26)
		Me.clearButton.Name = "clearButton"
		Me.clearButton.Size = New System.Drawing.Size(75, 23)
		Me.clearButton.TabIndex = 5
		Me.clearButton.Text = "Clear"
		Me.clearButton.UseVisualStyleBackColor = True
		AddHandler Me.clearButton.Click, New System.EventHandler(AddressOf Me.clearButton_Click)
		' 
		' saveButton
		' 
		Me.saveButton.Location = New System.Drawing.Point(84, 26)
		Me.saveButton.Name = "saveButton"
		Me.saveButton.Size = New System.Drawing.Size(75, 23)
		Me.saveButton.TabIndex = 6
		Me.saveButton.Text = "Save"
		Me.saveButton.UseVisualStyleBackColor = True
		AddHandler Me.saveButton.Click, New System.EventHandler(AddressOf Me.saveButton_Click)
		' 
		' logToFileButton
		' 
		Me.logToFileButton.Location = New System.Drawing.Point(165, 26)
		Me.logToFileButton.Name = "logToFileButton"
		Me.logToFileButton.Size = New System.Drawing.Size(150, 23)
		Me.logToFileButton.TabIndex = 7
		Me.logToFileButton.Text = "Log To File"
		Me.logToFileButton.UseVisualStyleBackColor = True
		AddHandler Me.logToFileButton.Click, New System.EventHandler(AddressOf Me.logToFileButton_Click)
		' 
		' Log
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96F, 96F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.Controls.Add(Me.tableLayoutPanel1)
		Me.Name = "Log"
		Me.Size = New System.Drawing.Size(409, 310)
		Me.tableLayoutPanel1.ResumeLayout(False)
		Me.tableLayoutPanel1.PerformLayout()
		Me.flowLayoutPanel1.ResumeLayout(False)
		Me.flowLayoutPanel1.PerformLayout()
		Me.ResumeLayout(False)

	End Sub

	#End Region

	Private logListBox As System.Windows.Forms.ListBox
	Private logDataCheckBox As System.Windows.Forms.CheckBox
	Private logErrorCheckBox As System.Windows.Forms.CheckBox
	Private logUserCheckBox As System.Windows.Forms.CheckBox
	Private logVerboseCheckBox As System.Windows.Forms.CheckBox
	Private tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Private flowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
	Private clearButton As System.Windows.Forms.Button
	Private saveButton As System.Windows.Forms.Button
	Private saveFileDialog1 As System.Windows.Forms.SaveFileDialog
	Private logToFileButton As System.Windows.Forms.Button


End Class
