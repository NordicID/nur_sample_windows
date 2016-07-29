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
		Me.maskLabel = New System.Windows.Forms.Label()
		Me.lengthUD = New System.Windows.Forms.NumericUpDown()
		Me.startUD = New System.Windows.Forms.NumericUpDown()
		Me.bankCB = New System.Windows.Forms.ComboBox()
        Me.tagListView = New NurTagListView()
		Me.tabControl1 = New System.Windows.Forms.TabControl()
		Me.tabEasy = New System.Windows.Forms.TabPage()
		Me.easyLocateButton = New System.Windows.Forms.Button()
		Me.tabAdvanced = New System.Windows.Forms.TabPage()
		Me.advLocateButton = New System.Windows.Forms.Button()
		Me.pickTagButton = New System.Windows.Forms.Button()
		Me.presetListBox = New System.Windows.Forms.ListBox()
		Me.label2 = New System.Windows.Forms.Label()
		Me.lengthLabel = New System.Windows.Forms.Label()
		Me.startLabel = New System.Windows.Forms.Label()
		Me.bankLabel = New System.Windows.Forms.Label()
		Me.tabLocator = New System.Windows.Forms.TabPage()
		Me.tabControl1.SuspendLayout()
		Me.tabEasy.SuspendLayout()
		Me.tabAdvanced.SuspendLayout()
		Me.tabLocator.SuspendLayout()
		Me.SuspendLayout()
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
		Me.refreshBtn.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.refreshBtn.Location = New System.Drawing.Point(3, 257)
		Me.refreshBtn.Name = "refreshBtn"
		Me.refreshBtn.Size = New System.Drawing.Size(110, 30)
		Me.refreshBtn.TabIndex = 18
		Me.refreshBtn.Text = "Refresh List"
        AddHandler Me.refreshBtn.Click, New System.EventHandler(AddressOf Me.refreshBtn_Click)
		' 
		' label1
		' 
		Me.label1.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.label1.Location = New System.Drawing.Point(3, 3)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(226, 20)
		Me.label1.Text = "Select Tag to locate"
		' 
		' updateTimer
		' 
		AddHandler Me.updateTimer.Tick, New System.EventHandler(AddressOf Me.updateTimer_Tick)
		' 
		' locatorBar
		' 
		Me.locatorBar.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.locatorBar.Location = New System.Drawing.Point(3, 31)
		Me.locatorBar.Name = "locatorBar"
		Me.locatorBar.Size = New System.Drawing.Size(226, 20)
		' 
		' txLevelTxt
		' 
		Me.txLevelTxt.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.txLevelTxt.Location = New System.Drawing.Point(3, 214)
		Me.txLevelTxt.Name = "txLevelTxt"
		Me.txLevelTxt.Size = New System.Drawing.Size(226, 20)
		Me.txLevelTxt.Text = "txLevelTxt"
		' 
		' rssiLevelTxt
		' 
		Me.rssiLevelTxt.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.rssiLevelTxt.Location = New System.Drawing.Point(3, 234)
		Me.rssiLevelTxt.Name = "rssiLevelTxt"
		Me.rssiLevelTxt.Size = New System.Drawing.Size(226, 20)
		Me.rssiLevelTxt.Text = "rssiLevelTxt"
		' 
		' locateBtn
		' 
		Me.locateBtn.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.locateBtn.Location = New System.Drawing.Point(3, 257)
		Me.locateBtn.Name = "locateBtn"
		Me.locateBtn.Size = New System.Drawing.Size(226, 30)
		Me.locateBtn.TabIndex = 21
		Me.locateBtn.Text = "Locate"
		AddHandler Me.locateBtn.Click, New System.EventHandler(AddressOf Me.locateBtn_Click)
		' 
		' tagToLocate
		' 
		Me.tagToLocate.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.tagToLocate.Location = New System.Drawing.Point(3, 76)
		Me.tagToLocate.Name = "tagToLocate"
		Me.tagToLocate.Size = New System.Drawing.Size(226, 23)
		Me.tagToLocate.TabIndex = 22
		Me.tagToLocate.Text = "tagToLocate"
		' 
		' maskLabel
		' 
		Me.maskLabel.Location = New System.Drawing.Point(3, 53)
		Me.maskLabel.Name = "maskLabel"
		Me.maskLabel.Size = New System.Drawing.Size(226, 20)
		Me.maskLabel.Text = "Mask:"
		' 
		' lengthUD
		' 
		Me.lengthUD.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lengthUD.Location = New System.Drawing.Point(157, 26)
		Me.lengthUD.Maximum = New Decimal(New Integer() {65536, 0, 0, 0})
		Me.lengthUD.Name = "lengthUD"
		Me.lengthUD.Size = New System.Drawing.Size(72, 24)
		Me.lengthUD.TabIndex = 34
		' 
		' startUD
		' 
		Me.startUD.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.startUD.Location = New System.Drawing.Point(79, 26)
		Me.startUD.Maximum = New Decimal(New Integer() {65536, 0, 0, 0})
		Me.startUD.Name = "startUD"
		Me.startUD.Size = New System.Drawing.Size(72, 24)
		Me.startUD.TabIndex = 33
		Me.startUD.Value = New Decimal(New Integer() {32, 0, 0, 0})
		' 
		' bankCB
		' 
		Me.bankCB.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.bankCB.Items.Add("Reserved")
		Me.bankCB.Items.Add("EPC")
		Me.bankCB.Items.Add("TID")
		Me.bankCB.Items.Add("User")
		Me.bankCB.Location = New System.Drawing.Point(3, 27)
		Me.bankCB.Name = "bankCB"
		Me.bankCB.Size = New System.Drawing.Size(70, 23)
		Me.bankCB.TabIndex = 32
		' 
		' tagListView
		' 
		Me.tagListView.Anchor = DirectCast((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.tagListView.Location = New System.Drawing.Point(3, 26)
		Me.tagListView.Name = "tagListView"
		Me.tagListView.Size = New System.Drawing.Size(226, 226)
		Me.tagListView.TabIndex = 19
		AddHandler Me.tagListView.Click, New System.EventHandler(AddressOf Me.tagListView_SelectedTagChanged)
		AddHandler Me.tagListView.SelectedTagChanged, New System.EventHandler(AddressOf Me.tagListView_SelectedTagChanged)
		' 
		' tabControl1
		' 
		Me.tabControl1.Controls.Add(Me.tabEasy)
		Me.tabControl1.Controls.Add(Me.tabAdvanced)
		Me.tabControl1.Controls.Add(Me.tabLocator)
		Me.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.tabControl1.Location = New System.Drawing.Point(0, 0)
		Me.tabControl1.Name = "tabControl1"
		Me.tabControl1.SelectedIndex = 0
		Me.tabControl1.Size = New System.Drawing.Size(240, 320)
		Me.tabControl1.TabIndex = 40
		' 
		' tabEasy
		' 
		Me.tabEasy.Controls.Add(Me.easyLocateButton)
		Me.tabEasy.Controls.Add(Me.label1)
		Me.tabEasy.Controls.Add(Me.refreshBtn)
		Me.tabEasy.Controls.Add(Me.tagListView)
		Me.tabEasy.Location = New System.Drawing.Point(4, 25)
		Me.tabEasy.Name = "tabEasy"
		Me.tabEasy.Size = New System.Drawing.Size(232, 291)
		Me.tabEasy.Text = "Easy"
		' 
		' easyLocateButton
		' 
		Me.easyLocateButton.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.easyLocateButton.Location = New System.Drawing.Point(119, 257)
		Me.easyLocateButton.Name = "easyLocateButton"
		Me.easyLocateButton.Size = New System.Drawing.Size(110, 30)
		Me.easyLocateButton.TabIndex = 40
		Me.easyLocateButton.Text = "Locate"
		AddHandler Me.easyLocateButton.Click, New System.EventHandler(AddressOf Me.locateBtn_Click)
		' 
		' tabAdvanced
		' 
		Me.tabAdvanced.Controls.Add(Me.advLocateButton)
		Me.tabAdvanced.Controls.Add(Me.pickTagButton)
		Me.tabAdvanced.Controls.Add(Me.presetListBox)
		Me.tabAdvanced.Controls.Add(Me.label2)
		Me.tabAdvanced.Controls.Add(Me.lengthLabel)
		Me.tabAdvanced.Controls.Add(Me.maskLabel)
		Me.tabAdvanced.Controls.Add(Me.tagToLocate)
		Me.tabAdvanced.Controls.Add(Me.lengthUD)
		Me.tabAdvanced.Controls.Add(Me.startLabel)
		Me.tabAdvanced.Controls.Add(Me.startUD)
		Me.tabAdvanced.Controls.Add(Me.bankLabel)
		Me.tabAdvanced.Controls.Add(Me.bankCB)
		Me.tabAdvanced.Location = New System.Drawing.Point(4, 25)
		Me.tabAdvanced.Name = "tabAdvanced"
		Me.tabAdvanced.Size = New System.Drawing.Size(232, 291)
		Me.tabAdvanced.Text = "Advanced"
		' 
		' advLocateButton
		' 
		Me.advLocateButton.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.advLocateButton.Location = New System.Drawing.Point(119, 257)
		Me.advLocateButton.Name = "advLocateButton"
		Me.advLocateButton.Size = New System.Drawing.Size(110, 30)
		Me.advLocateButton.TabIndex = 42
		Me.advLocateButton.Text = "Locate"
		AddHandler Me.advLocateButton.Click, New System.EventHandler(AddressOf Me.locateBtn_Click)
		' 
		' pickTagButton
		' 
		Me.pickTagButton.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.pickTagButton.Location = New System.Drawing.Point(3, 257)
		Me.pickTagButton.Name = "pickTagButton"
		Me.pickTagButton.Size = New System.Drawing.Size(110, 30)
		Me.pickTagButton.TabIndex = 41
		Me.pickTagButton.Text = "Read Tag"
		' 
		' presetListBox
		' 
		Me.presetListBox.Anchor = DirectCast((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.presetListBox.Location = New System.Drawing.Point(3, 125)
		Me.presetListBox.Name = "presetListBox"
		Me.presetListBox.Size = New System.Drawing.Size(226, 130)
		Me.presetListBox.TabIndex = 38
		AddHandler Me.presetListBox.SelectedIndexChanged, New System.EventHandler(AddressOf Me.presetListBox_SelectedIndexChanged)
		' 
		' label2
		' 
		Me.label2.Location = New System.Drawing.Point(3, 102)
		Me.label2.Name = "label2"
		Me.label2.Size = New System.Drawing.Size(215, 20)
		Me.label2.Text = "Preset list:"
		' 
		' lengthLabel
		' 
		Me.lengthLabel.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lengthLabel.Location = New System.Drawing.Point(157, 3)
		Me.lengthLabel.Name = "lengthLabel"
		Me.lengthLabel.Size = New System.Drawing.Size(72, 20)
		Me.lengthLabel.Text = "Length [b]"
		' 
		' startLabel
		' 
		Me.startLabel.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.startLabel.Location = New System.Drawing.Point(79, 3)
		Me.startLabel.Name = "startLabel"
		Me.startLabel.Size = New System.Drawing.Size(72, 20)
		Me.startLabel.Text = "Start [b]"
		' 
		' bankLabel
		' 
		Me.bankLabel.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.bankLabel.Location = New System.Drawing.Point(3, 3)
		Me.bankLabel.Name = "bankLabel"
		Me.bankLabel.Size = New System.Drawing.Size(70, 20)
		Me.bankLabel.Text = "Bank"
		' 
		' tabLocator
		' 
		Me.tabLocator.Controls.Add(Me.txLevelTxt)
		Me.tabLocator.Controls.Add(Me.locatorBar)
		Me.tabLocator.Controls.Add(Me.locateBtn)
		Me.tabLocator.Controls.Add(Me.rssiLevelTxt)
		Me.tabLocator.Location = New System.Drawing.Point(4, 25)
		Me.tabLocator.Name = "tabLocator"
		Me.tabLocator.Size = New System.Drawing.Size(232, 291)
		Me.tabLocator.Text = "Locator"
		' 
		' Locator
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96F, 96F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.Controls.Add(Me.tabControl1)
		Me.Name = "Locator"
		Me.Size = New System.Drawing.Size(240, 320)
		Me.tabControl1.ResumeLayout(False)
		Me.tabEasy.ResumeLayout(False)
		Me.tabAdvanced.ResumeLayout(False)
		Me.tabLocator.ResumeLayout(False)
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
	Private maskLabel As System.Windows.Forms.Label
	Private lengthUD As System.Windows.Forms.NumericUpDown
	Private startUD As System.Windows.Forms.NumericUpDown
	Private bankCB As System.Windows.Forms.ComboBox
	Private tabControl1 As System.Windows.Forms.TabControl
	Private tabEasy As System.Windows.Forms.TabPage
	Private tabAdvanced As System.Windows.Forms.TabPage
	Private lengthLabel As System.Windows.Forms.Label
	Private startLabel As System.Windows.Forms.Label
	Private bankLabel As System.Windows.Forms.Label
	Private label2 As System.Windows.Forms.Label
	Private presetListBox As System.Windows.Forms.ListBox
	Private tabLocator As System.Windows.Forms.TabPage
	Private easyLocateButton As System.Windows.Forms.Button
	Private advLocateButton As System.Windows.Forms.Button
	Private pickTagButton As System.Windows.Forms.Button
End Class
