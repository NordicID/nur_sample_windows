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
		Me.logDataCheckBox = New System.Windows.Forms.CheckBox()
		Me.logErrorCheckBox = New System.Windows.Forms.CheckBox()
		Me.logUserCheckBox = New System.Windows.Forms.CheckBox()
		Me.logVerboseCheckBox = New System.Windows.Forms.CheckBox()
		Me.clearButton = New System.Windows.Forms.Button()
		Me.saveButton = New System.Windows.Forms.Button()
		Me.logToFileButton = New System.Windows.Forms.Button()
		Me.saveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
		Me.logListBox = New System.Windows.Forms.ListBox()
		Me.SuspendLayout()
		' 
		' logDataCheckBox
		' 
		Me.logDataCheckBox.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.logDataCheckBox.Location = New System.Drawing.Point(109, 261)
		Me.logDataCheckBox.Name = "logDataCheckBox"
		Me.logDataCheckBox.Size = New System.Drawing.Size(100, 17)
		Me.logDataCheckBox.TabIndex = 1
		Me.logDataCheckBox.Text = "DATA"
        AddHandler Me.logDataCheckBox.CheckStateChanged, New System.EventHandler(AddressOf Me.logDataCheckBox_CheckedChanged)
		' 
		' logErrorCheckBox
		' 
		Me.logErrorCheckBox.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.logErrorCheckBox.Location = New System.Drawing.Point(3, 261)
		Me.logErrorCheckBox.Name = "logErrorCheckBox"
		Me.logErrorCheckBox.Size = New System.Drawing.Size(100, 17)
		Me.logErrorCheckBox.TabIndex = 2
		Me.logErrorCheckBox.Text = "ERROR"
        AddHandler Me.logErrorCheckBox.CheckStateChanged, New System.EventHandler(AddressOf Me.logErrorCheckBox_CheckedChanged)
		' 
		' logUserCheckBox
		' 
		Me.logUserCheckBox.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.logUserCheckBox.Location = New System.Drawing.Point(109, 238)
		Me.logUserCheckBox.Name = "logUserCheckBox"
		Me.logUserCheckBox.Size = New System.Drawing.Size(100, 17)
		Me.logUserCheckBox.TabIndex = 3
		Me.logUserCheckBox.Text = "USER"
        AddHandler Me.logUserCheckBox.CheckStateChanged, New System.EventHandler(AddressOf Me.logUserCheckBox_CheckedChanged)
		' 
		' logVerboseCheckBox
		' 
		Me.logVerboseCheckBox.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.logVerboseCheckBox.Location = New System.Drawing.Point(3, 238)
		Me.logVerboseCheckBox.Name = "logVerboseCheckBox"
		Me.logVerboseCheckBox.Size = New System.Drawing.Size(100, 17)
		Me.logVerboseCheckBox.TabIndex = 4
		Me.logVerboseCheckBox.Text = "VERBOSE"
        AddHandler Me.logVerboseCheckBox.CheckStateChanged, New System.EventHandler(AddressOf Me.logVerboseCheckBox_CheckedChanged)
		' 
		' clearButton
		' 
		Me.clearButton.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.clearButton.Location = New System.Drawing.Point(3, 284)
		Me.clearButton.Name = "clearButton"
		Me.clearButton.Size = New System.Drawing.Size(55, 23)
		Me.clearButton.TabIndex = 5
		Me.clearButton.Text = "Clear"
        AddHandler Me.clearButton.Click, New System.EventHandler(AddressOf Me.clearButton_Click)
		' 
		' saveButton
		' 
		Me.saveButton.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.saveButton.Location = New System.Drawing.Point(64, 284)
		Me.saveButton.Name = "saveButton"
		Me.saveButton.Size = New System.Drawing.Size(55, 23)
		Me.saveButton.TabIndex = 6
		Me.saveButton.Text = "Save"
        AddHandler Me.saveButton.Click, New System.EventHandler(AddressOf Me.saveButton_Click)
		' 
		' logToFileButton
		' 
		Me.logToFileButton.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.logToFileButton.Location = New System.Drawing.Point(125, 284)
		Me.logToFileButton.Name = "logToFileButton"
		Me.logToFileButton.Size = New System.Drawing.Size(281, 23)
		Me.logToFileButton.TabIndex = 7
		Me.logToFileButton.Text = "Log To File"
        AddHandler Me.logToFileButton.Click, New System.EventHandler(AddressOf Me.logToFileButton_Click)
		' 
		' logListBox
		' 
		Me.logListBox.Anchor = DirectCast((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.logListBox.Location = New System.Drawing.Point(3, 3)
		Me.logListBox.Name = "logListBox"
		Me.logListBox.Size = New System.Drawing.Size(403, 226)
		Me.logListBox.TabIndex = 8
		' 
		' Log
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96F, 96F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.Controls.Add(Me.logListBox)
		Me.Controls.Add(Me.logVerboseCheckBox)
		Me.Controls.Add(Me.logErrorCheckBox)
		Me.Controls.Add(Me.logUserCheckBox)
		Me.Controls.Add(Me.logDataCheckBox)
		Me.Controls.Add(Me.clearButton)
		Me.Controls.Add(Me.saveButton)
		Me.Controls.Add(Me.logToFileButton)
		Me.Name = "Log"
		Me.Size = New System.Drawing.Size(409, 310)
		Me.ResumeLayout(False)

	End Sub

	#End Region

	Private logDataCheckBox As System.Windows.Forms.CheckBox
	Private logErrorCheckBox As System.Windows.Forms.CheckBox
	Private logUserCheckBox As System.Windows.Forms.CheckBox
	Private logVerboseCheckBox As System.Windows.Forms.CheckBox
	Private clearButton As System.Windows.Forms.Button
	Private saveButton As System.Windows.Forms.Button
	Private saveFileDialog1 As System.Windows.Forms.SaveFileDialog
	Private logToFileButton As System.Windows.Forms.Button
	Private logListBox As System.Windows.Forms.ListBox


End Class
