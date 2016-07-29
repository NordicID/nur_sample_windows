Partial Class Locator
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
		Me.tagListView = New NurTagListView()
		Me.epcHeader = New System.Windows.Forms.ColumnHeader()
		Me.rssiHeader = New System.Windows.Forms.ColumnHeader()
		Me.refreshBtn = New System.Windows.Forms.Button()
		Me.label1 = New System.Windows.Forms.Label()
		Me.updateTimer = New System.Windows.Forms.Timer()
		Me.locatorBar = New System.Windows.Forms.ProgressBar()
		Me.txLevelTxt = New System.Windows.Forms.Label()
		Me.rssiLevelTxt = New System.Windows.Forms.Label()
		Me.locateBtn = New System.Windows.Forms.Button()
		Me.tagToLocate = New System.Windows.Forms.TextBox()
		Me.bankCombo = New System.Windows.Forms.ComboBox()
		Me.bankLabel = New System.Windows.Forms.Label()
		Me.SuspendLayout()
		' 
		' tagListView
		' 
		Me.tagListView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.tagListView.Location = New System.Drawing.Point(3, 23)
		Me.tagListView.Name = "tagListView"
		Me.tagListView.Size = New System.Drawing.Size(234, 86)
		Me.tagListView.TabIndex = 19
		AddHandler Me.tagListView.SelectedTagChanged, New System.EventHandler(AddressOf Me.tagListView_SelectedTagChanged)
		' 
		' epcHeader
		' 
		Me.epcHeader.Text = "EPC"
		Me.epcHeader.Width = 160
		' 
		' rssiHeader
		' 
		Me.rssiHeader.Text = "RSSI"
		Me.rssiHeader.Width = 50
		' 
		' refreshBtn
		' 
		Me.refreshBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.refreshBtn.Location = New System.Drawing.Point(165, 0)
		Me.refreshBtn.Name = "refreshBtn"
		Me.refreshBtn.Size = New System.Drawing.Size(72, 20)
		Me.refreshBtn.TabIndex = 18
		Me.refreshBtn.Text = "Refresh"
		AddHandler Me.refreshBtn.Click, New System.EventHandler(AddressOf Me.refreshBtn_Click)
		' 
		' label1
		' 
		Me.label1.Location = New System.Drawing.Point(3, 0)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(224, 20)
		Me.label1.Text = "Select Tag from List"
		' 
		' updateTimer
		' 
		AddHandler Me.updateTimer.Tick, New System.EventHandler(AddressOf Me.updateTimer_Tick)
		' 
		' locatorBar
		' 
		Me.locatorBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.locatorBar.Location = New System.Drawing.Point(3, 173)
		Me.locatorBar.Name = "locatorBar"
		Me.locatorBar.Size = New System.Drawing.Size(234, 20)
		' 
		' txLevelTxt
		' 
		Me.txLevelTxt.Location = New System.Drawing.Point(3, 199)
		Me.txLevelTxt.Name = "txLevelTxt"
		Me.txLevelTxt.Size = New System.Drawing.Size(129, 20)
		Me.txLevelTxt.Text = "txLevelTxt"
		' 
		' rssiLevelTxt
		' 
		Me.rssiLevelTxt.Location = New System.Drawing.Point(3, 216)
		Me.rssiLevelTxt.Name = "rssiLevelTxt"
		Me.rssiLevelTxt.Size = New System.Drawing.Size(129, 20)
		Me.rssiLevelTxt.Text = "rssiLevelTxt"
		' 
		' locateBtn
		' 
		Me.locateBtn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.locateBtn.Location = New System.Drawing.Point(138, 199)
		Me.locateBtn.Name = "locateBtn"
		Me.locateBtn.Size = New System.Drawing.Size(99, 37)
		Me.locateBtn.TabIndex = 21
		Me.locateBtn.Text = "Locate"
		AddHandler Me.locateBtn.Click, New System.EventHandler(AddressOf Me.locateBtn_Click)
		' 
		' tagToLocate
		' 
		Me.tagToLocate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.tagToLocate.Location = New System.Drawing.Point(44, 144)
		Me.tagToLocate.Name = "tagToLocate"
		Me.tagToLocate.Size = New System.Drawing.Size(193, 23)
		Me.tagToLocate.TabIndex = 22
		Me.tagToLocate.Text = "tagToLocate"
		AddHandler Me.tagToLocate.TextChanged, New System.EventHandler(AddressOf Me.tagToLocate_TextChanged)
		' 
		' bankCombo
		' 
		Me.bankCombo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.bankCombo.Items.Add("PASSWD")
		Me.bankCombo.Items.Add("EPC")
		Me.bankCombo.Items.Add("TID")
		Me.bankCombo.Items.Add("USER")
		Me.bankCombo.Location = New System.Drawing.Point(3, 115)
		Me.bankCombo.Name = "bankCombo"
		Me.bankCombo.Size = New System.Drawing.Size(234, 23)
		Me.bankCombo.TabIndex = 27
		AddHandler Me.bankCombo.SelectedIndexChanged, New System.EventHandler(AddressOf Me.bankCombo_SelectedIndexChanged)
		' 
		' bankLabel
		' 
		Me.bankLabel.Location = New System.Drawing.Point(3, 147)
		Me.bankLabel.Name = "bankLabel"
		Me.bankLabel.Size = New System.Drawing.Size(40, 20)
		Me.bankLabel.Text = "BNK:"
		' 
		' Locator
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96F, 96F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.Controls.Add(Me.bankLabel)
		Me.Controls.Add(Me.bankCombo)
		Me.Controls.Add(Me.tagToLocate)
		Me.Controls.Add(Me.locateBtn)
		Me.Controls.Add(Me.rssiLevelTxt)
		Me.Controls.Add(Me.txLevelTxt)
		Me.Controls.Add(Me.locatorBar)
		Me.Controls.Add(Me.tagListView)
		Me.Controls.Add(Me.refreshBtn)
		Me.Controls.Add(Me.label1)
		Me.Name = "Locator"
		Me.Size = New System.Drawing.Size(240, 320)
		Me.ResumeLayout(False)

	End Sub

	#End Region

	Private tagListView As NurTagListView
	Private epcHeader As System.Windows.Forms.ColumnHeader
	Private rssiHeader As System.Windows.Forms.ColumnHeader
	Private refreshBtn As System.Windows.Forms.Button
	Private label1 As System.Windows.Forms.Label
	Private updateTimer As System.Windows.Forms.Timer
	Private locatorBar As System.Windows.Forms.ProgressBar
	Private txLevelTxt As System.Windows.Forms.Label
	Private rssiLevelTxt As System.Windows.Forms.Label
	Private locateBtn As System.Windows.Forms.Button
	Private tagToLocate As System.Windows.Forms.TextBox
	Private bankCombo As System.Windows.Forms.ComboBox
	Private bankLabel As System.Windows.Forms.Label
End Class
