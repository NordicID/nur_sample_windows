Partial Class Writer
	''' <summary> 
	''' Required designer variable.
	''' </summary>
	Private components As System.ComponentModel.IContainer = Nothing

	''' <summary> 
	''' Clean up any resources being used.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(disposing As Boolean)
		If disposing AndAlso (components IsNot Nothing) Then
			components.Dispose()
		End If
		MyBase.Dispose(disposing)
	End Sub

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
		Me.tabControl1 = New System.Windows.Forms.TabControl()
		Me.tagsTab = New System.Windows.Forms.TabPage()
        Me.writeTagListView = New NurTagListView()
		Me.targetTab = New System.Windows.Forms.TabPage()
		Me.pickUpButton = New System.Windows.Forms.Button()
		Me.passwdTextBox = New System.Windows.Forms.TextBox()
		Me.targetMaskTextBox = New System.Windows.Forms.TextBox()
		Me.usePasswdCheckBox = New System.Windows.Forms.CheckBox()
		Me.label4 = New System.Windows.Forms.Label()
		Me.targetLengthUD = New System.Windows.Forms.NumericUpDown()
		Me.targetStartUD = New System.Windows.Forms.NumericUpDown()
		Me.lengthLabel = New System.Windows.Forms.Label()
		Me.label5 = New System.Windows.Forms.Label()
		Me.label6 = New System.Windows.Forms.Label()
		Me.targetBankCB = New System.Windows.Forms.ComboBox()
		Me.epcTab = New System.Windows.Forms.TabPage()
		Me.writeNewEpcBtn = New System.Windows.Forms.Button()
		Me.newEpcTextBox = New System.Windows.Forms.TextBox()
		Me.targetEpcLabel = New System.Windows.Forms.Label()
		Me.label7 = New System.Windows.Forms.Label()
		Me.enterNewEpcLabel = New System.Windows.Forms.Label()
		Me.memTab = New System.Windows.Forms.TabPage()
		Me.memUseReadBlockCheckBox = New System.Windows.Forms.CheckBox()
		Me.writeMemButton = New System.Windows.Forms.Button()
		Me.readMemButton = New System.Windows.Forms.Button()
		Me.memTextBox = New System.Windows.Forms.TextBox()
		Me.targetMemLabel = New System.Windows.Forms.Label()
		Me.label10 = New System.Windows.Forms.Label()
		Me.label2 = New System.Windows.Forms.Label()
		Me.memLengthUD = New System.Windows.Forms.NumericUpDown()
		Me.memStartUD = New System.Windows.Forms.NumericUpDown()
		Me.label3 = New System.Windows.Forms.Label()
		Me.label8 = New System.Windows.Forms.Label()
		Me.label9 = New System.Windows.Forms.Label()
		Me.memBankCB = New System.Windows.Forms.ComboBox()
		Me.lockTab = New System.Windows.Forms.TabPage()
		Me.lockKillCheckBox = New System.Windows.Forms.CheckBox()
		Me.lockAccessCheckBox = New System.Windows.Forms.CheckBox()
		Me.lockEpcCheckBox = New System.Windows.Forms.CheckBox()
		Me.lockTicCheckBox = New System.Windows.Forms.CheckBox()
		Me.lockUserCheckBox = New System.Windows.Forms.CheckBox()
		Me.setLockStateButton = New System.Windows.Forms.Button()
		Me.label15 = New System.Windows.Forms.Label()
		Me.label14 = New System.Windows.Forms.Label()
		Me.secLockStateCB = New System.Windows.Forms.ComboBox()
		Me.securityTab = New System.Windows.Forms.TabPage()
		Me.killButton = New System.Windows.Forms.Button()
		Me.writePasswordButton = New System.Windows.Forms.Button()
		Me.readPasswordButton = New System.Windows.Forms.Button()
		Me.secPasswdTextBox = New System.Windows.Forms.TextBox()
		Me.label11 = New System.Windows.Forms.Label()
		Me.securityCB = New System.Windows.Forms.ComboBox()
		Me.targetAccessLabel = New System.Windows.Forms.Label()
		Me.label12 = New System.Windows.Forms.Label()
		Me.label13 = New System.Windows.Forms.Label()
		Me.tabControl1.SuspendLayout()
		Me.tagsTab.SuspendLayout()
		Me.targetTab.SuspendLayout()
		Me.epcTab.SuspendLayout()
		Me.memTab.SuspendLayout()
		Me.lockTab.SuspendLayout()
		Me.securityTab.SuspendLayout()
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
		Me.rssiHeader.Width = 60
		' 
		' refreshBtn
		' 
		Me.refreshBtn.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.refreshBtn.Location = New System.Drawing.Point(3, 248)
		Me.refreshBtn.Name = "refreshBtn"
		Me.refreshBtn.Size = New System.Drawing.Size(226, 40)
		Me.refreshBtn.TabIndex = 21
		Me.refreshBtn.Text = "Refresh list"
		AddHandler Me.refreshBtn.Click, New System.EventHandler(AddressOf Me.refreshBtn_Click)
		' 
		' label1
		' 
		Me.label1.Location = New System.Drawing.Point(3, 7)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(157, 20)
		Me.label1.Text = "Select the target Tag"
		' 
		' tabControl1
		' 
		Me.tabControl1.Controls.Add(Me.tagsTab)
		Me.tabControl1.Controls.Add(Me.targetTab)
		Me.tabControl1.Controls.Add(Me.epcTab)
		Me.tabControl1.Controls.Add(Me.memTab)
		Me.tabControl1.Controls.Add(Me.lockTab)
		Me.tabControl1.Controls.Add(Me.securityTab)
		Me.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.tabControl1.Location = New System.Drawing.Point(0, 0)
		Me.tabControl1.Name = "tabControl1"
		Me.tabControl1.SelectedIndex = 0
		Me.tabControl1.Size = New System.Drawing.Size(240, 320)
		Me.tabControl1.TabIndex = 25
		AddHandler Me.tabControl1.SelectedIndexChanged, New System.EventHandler(AddressOf Me.tabControl1_SelectedIndexChanged)
		' 
		' tagsTab
		' 
		Me.tagsTab.Controls.Add(Me.label1)
		Me.tagsTab.Controls.Add(Me.writeTagListView)
		Me.tagsTab.Controls.Add(Me.refreshBtn)
		Me.tagsTab.Location = New System.Drawing.Point(4, 25)
		Me.tagsTab.Name = "tagsTab"
		Me.tagsTab.Size = New System.Drawing.Size(232, 291)
		Me.tagsTab.Text = "Tags"
		' 
		' writeTagListView
		' 
		Me.writeTagListView.Anchor = DirectCast((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.writeTagListView.Location = New System.Drawing.Point(3, 30)
		Me.writeTagListView.Name = "writeTagListView"
		Me.writeTagListView.Size = New System.Drawing.Size(226, 212)
		Me.writeTagListView.TabIndex = 22
		AddHandler Me.writeTagListView.SelectedTagChanged, New System.EventHandler(AddressOf Me.writeTagListView_SelectedTagChanged)
		' 
		' targetTab
		' 
		Me.targetTab.Controls.Add(Me.pickUpButton)
		Me.targetTab.Controls.Add(Me.passwdTextBox)
		Me.targetTab.Controls.Add(Me.targetMaskTextBox)
		Me.targetTab.Controls.Add(Me.usePasswdCheckBox)
		Me.targetTab.Controls.Add(Me.label4)
		Me.targetTab.Controls.Add(Me.targetLengthUD)
		Me.targetTab.Controls.Add(Me.targetStartUD)
		Me.targetTab.Controls.Add(Me.lengthLabel)
		Me.targetTab.Controls.Add(Me.label5)
		Me.targetTab.Controls.Add(Me.label6)
		Me.targetTab.Controls.Add(Me.targetBankCB)
		Me.targetTab.Location = New System.Drawing.Point(4, 25)
		Me.targetTab.Name = "targetTab"
		Me.targetTab.Size = New System.Drawing.Size(232, 291)
		Me.targetTab.Text = "Target"
		' 
		' pickUpButton
		' 
		Me.pickUpButton.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.pickUpButton.Location = New System.Drawing.Point(3, 171)
		Me.pickUpButton.Name = "pickUpButton"
		Me.pickUpButton.Size = New System.Drawing.Size(226, 40)
		Me.pickUpButton.TabIndex = 23
		Me.pickUpButton.Text = "Pick up the strongest Tag"
		AddHandler Me.pickUpButton.Click, New System.EventHandler(AddressOf Me.pickUpButton_Click)
		' 
		' passwdTextBox
		' 
		Me.passwdTextBox.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.passwdTextBox.Location = New System.Drawing.Point(3, 136)
		Me.passwdTextBox.MaxLength = 8
		Me.passwdTextBox.Name = "passwdTextBox"
		Me.passwdTextBox.Size = New System.Drawing.Size(226, 23)
		Me.passwdTextBox.TabIndex = 18
		Me.passwdTextBox.Text = "00000000"
		' 
		' targetMaskTextBox
		' 
		Me.targetMaskTextBox.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.targetMaskTextBox.Location = New System.Drawing.Point(3, 78)
		Me.targetMaskTextBox.MaxLength = 1024
		Me.targetMaskTextBox.Name = "targetMaskTextBox"
		Me.targetMaskTextBox.Size = New System.Drawing.Size(226, 23)
		Me.targetMaskTextBox.TabIndex = 17
		' 
		' usePasswdCheckBox
		' 
		Me.usePasswdCheckBox.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.usePasswdCheckBox.Location = New System.Drawing.Point(3, 110)
		Me.usePasswdCheckBox.Name = "usePasswdCheckBox"
		Me.usePasswdCheckBox.Size = New System.Drawing.Size(226, 20)
		Me.usePasswdCheckBox.TabIndex = 12
		Me.usePasswdCheckBox.Text = "Use access password"
		' 
		' label4
		' 
		Me.label4.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.label4.Location = New System.Drawing.Point(3, 55)
		Me.label4.Name = "label4"
		Me.label4.Size = New System.Drawing.Size(226, 20)
		Me.label4.Text = "Mask [HEX]"
		' 
		' targetLengthUD
		' 
		Me.targetLengthUD.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.targetLengthUD.Location = New System.Drawing.Point(157, 26)
		Me.targetLengthUD.Maximum = New Decimal(New Integer() {512, 0, 0, 0})
		Me.targetLengthUD.Name = "targetLengthUD"
		Me.targetLengthUD.Size = New System.Drawing.Size(72, 24)
		Me.targetLengthUD.TabIndex = 11
		' 
		' targetStartUD
		' 
		Me.targetStartUD.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.targetStartUD.Location = New System.Drawing.Point(81, 26)
		Me.targetStartUD.Maximum = New Decimal(New Integer() {512, 0, 0, 0})
		Me.targetStartUD.Name = "targetStartUD"
		Me.targetStartUD.Size = New System.Drawing.Size(70, 24)
		Me.targetStartUD.TabIndex = 10
		Me.targetStartUD.Value = New Decimal(New Integer() {32, 0, 0, 0})
		' 
		' lengthLabel
		' 
		Me.lengthLabel.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lengthLabel.Location = New System.Drawing.Point(159, 6)
		Me.lengthLabel.Name = "lengthLabel"
		Me.lengthLabel.Size = New System.Drawing.Size(72, 20)
		Me.lengthLabel.Text = "Length [b]"
		' 
		' label5
		' 
		Me.label5.Location = New System.Drawing.Point(81, 6)
		Me.label5.Name = "label5"
		Me.label5.Size = New System.Drawing.Size(70, 20)
		Me.label5.Text = "Start [b]"
		' 
		' label6
		' 
		Me.label6.Location = New System.Drawing.Point(3, 6)
		Me.label6.Name = "label6"
		Me.label6.Size = New System.Drawing.Size(72, 20)
		Me.label6.Text = "Bank"
		' 
		' targetBankCB
		' 
		Me.targetBankCB.Items.Add("Reserved")
		Me.targetBankCB.Items.Add("EPC")
		Me.targetBankCB.Items.Add("TID")
		Me.targetBankCB.Items.Add("User")
		Me.targetBankCB.Location = New System.Drawing.Point(3, 26)
		Me.targetBankCB.Name = "targetBankCB"
		Me.targetBankCB.Size = New System.Drawing.Size(72, 23)
		Me.targetBankCB.TabIndex = 9
		' 
		' epcTab
		' 
		Me.epcTab.Controls.Add(Me.writeNewEpcBtn)
		Me.epcTab.Controls.Add(Me.newEpcTextBox)
		Me.epcTab.Controls.Add(Me.targetEpcLabel)
		Me.epcTab.Controls.Add(Me.label7)
		Me.epcTab.Controls.Add(Me.enterNewEpcLabel)
		Me.epcTab.Location = New System.Drawing.Point(4, 25)
		Me.epcTab.Name = "epcTab"
		Me.epcTab.Size = New System.Drawing.Size(232, 291)
		Me.epcTab.Text = "EPC"
		' 
		' writeNewEpcBtn
		' 
		Me.writeNewEpcBtn.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.writeNewEpcBtn.Location = New System.Drawing.Point(3, 98)
		Me.writeNewEpcBtn.Name = "writeNewEpcBtn"
		Me.writeNewEpcBtn.Size = New System.Drawing.Size(226, 30)
		Me.writeNewEpcBtn.TabIndex = 25
		Me.writeNewEpcBtn.Text = "Write EPC"
		AddHandler Me.writeNewEpcBtn.Click, New System.EventHandler(AddressOf Me.writeNewEpcBtn_Click)
		' 
		' newEpcTextBox
		' 
		Me.newEpcTextBox.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.newEpcTextBox.Location = New System.Drawing.Point(3, 69)
		Me.newEpcTextBox.Name = "newEpcTextBox"
		Me.newEpcTextBox.Size = New System.Drawing.Size(226, 23)
		Me.newEpcTextBox.TabIndex = 18
		' 
		' targetEpcLabel
		' 
		Me.targetEpcLabel.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.targetEpcLabel.Font = New System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold)
		Me.targetEpcLabel.Location = New System.Drawing.Point(3, 26)
		Me.targetEpcLabel.Name = "targetEpcLabel"
		Me.targetEpcLabel.Size = New System.Drawing.Size(633, 20)
		Me.targetEpcLabel.Text = "targetEpcLabel"
		' 
		' label7
		' 
		Me.label7.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.label7.Location = New System.Drawing.Point(3, 6)
		Me.label7.Name = "label7"
		Me.label7.Size = New System.Drawing.Size(226, 20)
		Me.label7.Text = "Target Tag"
		' 
		' enterNewEpcLabel
		' 
		Me.enterNewEpcLabel.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.enterNewEpcLabel.Location = New System.Drawing.Point(3, 46)
		Me.enterNewEpcLabel.Name = "enterNewEpcLabel"
		Me.enterNewEpcLabel.Size = New System.Drawing.Size(226, 20)
		Me.enterNewEpcLabel.Text = "New EPC"
		' 
		' memTab
		' 
		Me.memTab.Controls.Add(Me.memUseReadBlockCheckBox)
		Me.memTab.Controls.Add(Me.writeMemButton)
		Me.memTab.Controls.Add(Me.readMemButton)
		Me.memTab.Controls.Add(Me.memTextBox)
		Me.memTab.Controls.Add(Me.targetMemLabel)
		Me.memTab.Controls.Add(Me.label10)
		Me.memTab.Controls.Add(Me.label2)
		Me.memTab.Controls.Add(Me.memLengthUD)
		Me.memTab.Controls.Add(Me.memStartUD)
		Me.memTab.Controls.Add(Me.label3)
		Me.memTab.Controls.Add(Me.label8)
		Me.memTab.Controls.Add(Me.label9)
		Me.memTab.Controls.Add(Me.memBankCB)
		Me.memTab.Location = New System.Drawing.Point(4, 25)
		Me.memTab.Name = "memTab"
		Me.memTab.Size = New System.Drawing.Size(232, 291)
		Me.memTab.Text = "Mem"
		' 
		' memUseReadBlockCheckBox
		' 
		Me.memUseReadBlockCheckBox.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.memUseReadBlockCheckBox.Location = New System.Drawing.Point(4, 96)
		Me.memUseReadBlockCheckBox.Name = "memUseReadBlockCheckBox"
		Me.memUseReadBlockCheckBox.Size = New System.Drawing.Size(225, 20)
		Me.memUseReadBlockCheckBox.TabIndex = 34
		Me.memUseReadBlockCheckBox.Text = "Use ReadBlock method"
		AddHandler Me.memUseReadBlockCheckBox.CheckStateChanged, New System.EventHandler(AddressOf Me.memUseReadBlockCheckBox_CheckStateChanged)
		' 
		' writeMemButton
		' 
		Me.writeMemButton.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.writeMemButton.Location = New System.Drawing.Point(120, 171)
		Me.writeMemButton.Name = "writeMemButton"
		Me.writeMemButton.Size = New System.Drawing.Size(110, 30)
		Me.writeMemButton.TabIndex = 27
		Me.writeMemButton.Text = "Write MEM"
		AddHandler Me.writeMemButton.Click, New System.EventHandler(AddressOf Me.writeMemButton_Click)
		' 
		' readMemButton
		' 
		Me.readMemButton.Location = New System.Drawing.Point(4, 171)
		Me.readMemButton.Name = "readMemButton"
		Me.readMemButton.Size = New System.Drawing.Size(110, 30)
		Me.readMemButton.TabIndex = 26
		Me.readMemButton.Text = "Read MEM"
		AddHandler Me.readMemButton.Click, New System.EventHandler(AddressOf Me.readMemButton_Click)
		' 
		' memTextBox
		' 
		Me.memTextBox.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.memTextBox.Location = New System.Drawing.Point(4, 142)
		Me.memTextBox.Name = "memTextBox"
		Me.memTextBox.Size = New System.Drawing.Size(226, 23)
		Me.memTextBox.TabIndex = 23
		' 
		' targetMemLabel
		' 
		Me.targetMemLabel.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.targetMemLabel.Font = New System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold)
		Me.targetMemLabel.Location = New System.Drawing.Point(3, 26)
		Me.targetMemLabel.Name = "targetMemLabel"
		Me.targetMemLabel.Size = New System.Drawing.Size(633, 20)
		Me.targetMemLabel.Text = "targetMemLabel"
		' 
		' label10
		' 
		Me.label10.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.label10.Location = New System.Drawing.Point(3, 6)
		Me.label10.Name = "label10"
		Me.label10.Size = New System.Drawing.Size(226, 20)
		Me.label10.Text = "Target Tag"
		' 
		' label2
		' 
		Me.label2.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.label2.Location = New System.Drawing.Point(4, 119)
		Me.label2.Name = "label2"
		Me.label2.Size = New System.Drawing.Size(229, 20)
		Me.label2.Text = "Data [HEX]"
		' 
		' memLengthUD
		' 
		Me.memLengthUD.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.memLengthUD.Increment = New Decimal(New Integer() {2, 0, 0, 0})
		Me.memLengthUD.Location = New System.Drawing.Point(157, 66)
		Me.memLengthUD.Maximum = New Decimal(New Integer() {512, 0, 0, 0})
		Me.memLengthUD.Name = "memLengthUD"
		Me.memLengthUD.Size = New System.Drawing.Size(72, 24)
		Me.memLengthUD.TabIndex = 14
		Me.memLengthUD.Value = New Decimal(New Integer() {8, 0, 0, 0})
		' 
		' memStartUD
		' 
		Me.memStartUD.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.memStartUD.Location = New System.Drawing.Point(81, 66)
		Me.memStartUD.Maximum = New Decimal(New Integer() {512, 0, 0, 0})
		Me.memStartUD.Name = "memStartUD"
		Me.memStartUD.Size = New System.Drawing.Size(70, 24)
		Me.memStartUD.TabIndex = 13
		' 
		' label3
		' 
		Me.label3.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.label3.Location = New System.Drawing.Point(159, 46)
		Me.label3.Name = "label3"
		Me.label3.Size = New System.Drawing.Size(70, 20)
		Me.label3.Text = "Length [B]"
		' 
		' label8
		' 
		Me.label8.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.label8.Location = New System.Drawing.Point(81, 46)
		Me.label8.Name = "label8"
		Me.label8.Size = New System.Drawing.Size(70, 20)
		Me.label8.Text = "Start [W]"
		' 
		' label9
		' 
		Me.label9.Location = New System.Drawing.Point(3, 46)
		Me.label9.Name = "label9"
		Me.label9.Size = New System.Drawing.Size(72, 20)
		Me.label9.Text = "Bank"
		' 
		' memBankCB
		' 
		Me.memBankCB.Items.Add("Reserved")
		Me.memBankCB.Items.Add("EPC")
		Me.memBankCB.Items.Add("TID")
		Me.memBankCB.Items.Add("User")
		Me.memBankCB.Location = New System.Drawing.Point(3, 66)
		Me.memBankCB.Name = "memBankCB"
		Me.memBankCB.Size = New System.Drawing.Size(72, 23)
		Me.memBankCB.TabIndex = 12
		' 
		' lockTab
		' 
		Me.lockTab.Controls.Add(Me.lockKillCheckBox)
		Me.lockTab.Controls.Add(Me.lockAccessCheckBox)
		Me.lockTab.Controls.Add(Me.lockEpcCheckBox)
		Me.lockTab.Controls.Add(Me.lockTicCheckBox)
		Me.lockTab.Controls.Add(Me.lockUserCheckBox)
		Me.lockTab.Controls.Add(Me.setLockStateButton)
		Me.lockTab.Controls.Add(Me.label15)
		Me.lockTab.Controls.Add(Me.label14)
		Me.lockTab.Controls.Add(Me.secLockStateCB)
		Me.lockTab.Location = New System.Drawing.Point(4, 25)
		Me.lockTab.Name = "lockTab"
		Me.lockTab.Size = New System.Drawing.Size(232, 291)
		Me.lockTab.Text = "Locks"
		' 
		' lockKillCheckBox
		' 
		Me.lockKillCheckBox.Location = New System.Drawing.Point(3, 55)
		Me.lockKillCheckBox.Name = "lockKillCheckBox"
		Me.lockKillCheckBox.Size = New System.Drawing.Size(100, 20)
		Me.lockKillCheckBox.TabIndex = 53
		Me.lockKillCheckBox.Text = "KILLPWD"
		' 
		' lockAccessCheckBox
		' 
		Me.lockAccessCheckBox.Location = New System.Drawing.Point(109, 55)
		Me.lockAccessCheckBox.Name = "lockAccessCheckBox"
		Me.lockAccessCheckBox.Size = New System.Drawing.Size(100, 20)
		Me.lockAccessCheckBox.TabIndex = 52
		Me.lockAccessCheckBox.Text = "ACCESSPWD"
		' 
		' lockEpcCheckBox
		' 
		Me.lockEpcCheckBox.Location = New System.Drawing.Point(3, 29)
		Me.lockEpcCheckBox.Name = "lockEpcCheckBox"
		Me.lockEpcCheckBox.Size = New System.Drawing.Size(100, 20)
		Me.lockEpcCheckBox.TabIndex = 51
		Me.lockEpcCheckBox.Text = "EPC MEM"
		' 
		' lockTicCheckBox
		' 
		Me.lockTicCheckBox.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lockTicCheckBox.Location = New System.Drawing.Point(3, 81)
		Me.lockTicCheckBox.Name = "lockTicCheckBox"
		Me.lockTicCheckBox.Size = New System.Drawing.Size(226, 20)
		Me.lockTicCheckBox.TabIndex = 50
		Me.lockTicCheckBox.Text = "TID MEM (probably locked)"
		' 
		' lockUserCheckBox
		' 
		Me.lockUserCheckBox.Location = New System.Drawing.Point(109, 29)
		Me.lockUserCheckBox.Name = "lockUserCheckBox"
		Me.lockUserCheckBox.Size = New System.Drawing.Size(100, 20)
		Me.lockUserCheckBox.TabIndex = 49
		Me.lockUserCheckBox.Text = "USER MEM"
		' 
		' setLockStateButton
		' 
		Me.setLockStateButton.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.setLockStateButton.Location = New System.Drawing.Point(3, 168)
		Me.setLockStateButton.Name = "setLockStateButton"
		Me.setLockStateButton.Size = New System.Drawing.Size(226, 30)
		Me.setLockStateButton.TabIndex = 48
		Me.setLockStateButton.Text = "Set Lock State"
		AddHandler Me.setLockStateButton.Click, New System.EventHandler(AddressOf Me.setLockStateButton_Click)
		' 
		' label15
		' 
		Me.label15.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.label15.Location = New System.Drawing.Point(3, 110)
		Me.label15.Name = "label15"
		Me.label15.Size = New System.Drawing.Size(226, 20)
		Me.label15.Text = "Lock state"
		' 
		' label14
		' 
		Me.label14.Location = New System.Drawing.Point(3, 6)
		Me.label14.Name = "label14"
		Me.label14.Size = New System.Drawing.Size(226, 20)
		Me.label14.Text = "Target flags"
		' 
		' secLockStateCB
		' 
		Me.secLockStateCB.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.secLockStateCB.Items.Add("Open")
		Me.secLockStateCB.Items.Add("Permanently Writeable")
		Me.secLockStateCB.Items.Add("Secured")
		Me.secLockStateCB.Items.Add("Permanently Locked")
		Me.secLockStateCB.Location = New System.Drawing.Point(3, 133)
		Me.secLockStateCB.Name = "secLockStateCB"
		Me.secLockStateCB.Size = New System.Drawing.Size(226, 23)
		Me.secLockStateCB.TabIndex = 47
		' 
		' securityTab
		' 
		Me.securityTab.Controls.Add(Me.killButton)
		Me.securityTab.Controls.Add(Me.writePasswordButton)
		Me.securityTab.Controls.Add(Me.readPasswordButton)
		Me.securityTab.Controls.Add(Me.secPasswdTextBox)
		Me.securityTab.Controls.Add(Me.label11)
		Me.securityTab.Controls.Add(Me.securityCB)
		Me.securityTab.Controls.Add(Me.targetAccessLabel)
		Me.securityTab.Controls.Add(Me.label12)
		Me.securityTab.Controls.Add(Me.label13)
		Me.securityTab.Location = New System.Drawing.Point(4, 25)
		Me.securityTab.Name = "securityTab"
		Me.securityTab.Size = New System.Drawing.Size(232, 291)
		Me.securityTab.Text = "Security"
		' 
		' killButton
		' 
		Me.killButton.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.killButton.Location = New System.Drawing.Point(3, 140)
		Me.killButton.Name = "killButton"
		Me.killButton.Size = New System.Drawing.Size(226, 33)
		Me.killButton.TabIndex = 51
		Me.killButton.Text = "Kill the target Tag"
		AddHandler Me.killButton.Click, New System.EventHandler(AddressOf Me.killButton_Click)
		' 
		' writePasswordButton
		' 
		Me.writePasswordButton.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.writePasswordButton.Location = New System.Drawing.Point(119, 98)
		Me.writePasswordButton.Name = "writePasswordButton"
		Me.writePasswordButton.Size = New System.Drawing.Size(110, 30)
		Me.writePasswordButton.TabIndex = 29
		Me.writePasswordButton.Text = "Write Password"
		AddHandler Me.writePasswordButton.Click, New System.EventHandler(AddressOf Me.writePasswordButton_Click)
		' 
		' readPasswordButton
		' 
		Me.readPasswordButton.Location = New System.Drawing.Point(3, 98)
		Me.readPasswordButton.Name = "readPasswordButton"
		Me.readPasswordButton.Size = New System.Drawing.Size(110, 30)
		Me.readPasswordButton.TabIndex = 28
		Me.readPasswordButton.Text = "Read Password"
		AddHandler Me.readPasswordButton.Click, New System.EventHandler(AddressOf Me.readPasswordButton_Click)
		' 
		' secPasswdTextBox
		' 
		Me.secPasswdTextBox.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.secPasswdTextBox.Location = New System.Drawing.Point(86, 69)
		Me.secPasswdTextBox.MaxLength = 8
		Me.secPasswdTextBox.Name = "secPasswdTextBox"
		Me.secPasswdTextBox.Size = New System.Drawing.Size(143, 23)
		Me.secPasswdTextBox.TabIndex = 17
		Me.secPasswdTextBox.Text = "00000000"
		' 
		' label11
		' 
		Me.label11.Location = New System.Drawing.Point(3, 46)
		Me.label11.Name = "label11"
		Me.label11.Size = New System.Drawing.Size(77, 20)
		Me.label11.Text = "Security"
		' 
		' securityCB
		' 
		Me.securityCB.Items.Add("Kill")
		Me.securityCB.Items.Add("Access")
		Me.securityCB.Location = New System.Drawing.Point(3, 69)
		Me.securityCB.Name = "securityCB"
		Me.securityCB.Size = New System.Drawing.Size(77, 23)
		Me.securityCB.TabIndex = 9
		' 
		' targetAccessLabel
		' 
		Me.targetAccessLabel.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.targetAccessLabel.Font = New System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold)
		Me.targetAccessLabel.Location = New System.Drawing.Point(3, 26)
		Me.targetAccessLabel.Name = "targetAccessLabel"
		Me.targetAccessLabel.Size = New System.Drawing.Size(633, 20)
		Me.targetAccessLabel.Text = "targetAccessLabel"
		' 
		' label12
		' 
		Me.label12.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.label12.Location = New System.Drawing.Point(3, 6)
		Me.label12.Name = "label12"
		Me.label12.Size = New System.Drawing.Size(226, 20)
		Me.label12.Text = "Target Tag"
		' 
		' label13
		' 
		Me.label13.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.label13.Location = New System.Drawing.Point(86, 46)
		Me.label13.Name = "label13"
		Me.label13.Size = New System.Drawing.Size(146, 20)
		Me.label13.Text = "Password [HEX]"
		' 
		' Writer
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96F, 96F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.Controls.Add(Me.tabControl1)
		Me.Name = "Writer"
		Me.Size = New System.Drawing.Size(240, 320)
		Me.tabControl1.ResumeLayout(False)
		Me.tagsTab.ResumeLayout(False)
		Me.targetTab.ResumeLayout(False)
		Me.epcTab.ResumeLayout(False)
		Me.memTab.ResumeLayout(False)
		Me.lockTab.ResumeLayout(False)
		Me.securityTab.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

	#End Region

	Private writeTagListView As NurTagListView
	Private epcHeader As System.Windows.Forms.ColumnHeader
	Private rssiHeader As System.Windows.Forms.ColumnHeader
	Private refreshBtn As System.Windows.Forms.Button
	Private label1 As System.Windows.Forms.Label
	Private tabControl1 As System.Windows.Forms.TabControl
	Private tagsTab As System.Windows.Forms.TabPage
	Private targetTab As System.Windows.Forms.TabPage
	Private targetMaskTextBox As System.Windows.Forms.TextBox
	Private usePasswdCheckBox As System.Windows.Forms.CheckBox
	Private label4 As System.Windows.Forms.Label
	Private targetLengthUD As System.Windows.Forms.NumericUpDown
	Private targetStartUD As System.Windows.Forms.NumericUpDown
	Private lengthLabel As System.Windows.Forms.Label
	Private label5 As System.Windows.Forms.Label
	Private label6 As System.Windows.Forms.Label
	Private targetBankCB As System.Windows.Forms.ComboBox
	Private passwdTextBox As System.Windows.Forms.TextBox
	Private memTab As System.Windows.Forms.TabPage
	Private epcTab As System.Windows.Forms.TabPage
	Private targetEpcLabel As System.Windows.Forms.Label
	Private label7 As System.Windows.Forms.Label
	Private enterNewEpcLabel As System.Windows.Forms.Label
	Private newEpcTextBox As System.Windows.Forms.TextBox
	Private writeNewEpcBtn As System.Windows.Forms.Button
	Private targetMemLabel As System.Windows.Forms.Label
	Private label10 As System.Windows.Forms.Label
	Private label2 As System.Windows.Forms.Label
	Private memLengthUD As System.Windows.Forms.NumericUpDown
	Private memStartUD As System.Windows.Forms.NumericUpDown
	Private label3 As System.Windows.Forms.Label
	Private label8 As System.Windows.Forms.Label
	Private label9 As System.Windows.Forms.Label
	Private memBankCB As System.Windows.Forms.ComboBox
	Private writeMemButton As System.Windows.Forms.Button
	Private readMemButton As System.Windows.Forms.Button
	Private memTextBox As System.Windows.Forms.TextBox
	Private securityTab As System.Windows.Forms.TabPage
	Private secPasswdTextBox As System.Windows.Forms.TextBox
	Private label11 As System.Windows.Forms.Label
	Private securityCB As System.Windows.Forms.ComboBox
	Private targetAccessLabel As System.Windows.Forms.Label
	Private label12 As System.Windows.Forms.Label
	Private label13 As System.Windows.Forms.Label
	Private writePasswordButton As System.Windows.Forms.Button
	Private readPasswordButton As System.Windows.Forms.Button
	Private lockTab As System.Windows.Forms.TabPage
	Private lockKillCheckBox As System.Windows.Forms.CheckBox
	Private lockAccessCheckBox As System.Windows.Forms.CheckBox
	Private lockEpcCheckBox As System.Windows.Forms.CheckBox
	Private lockTicCheckBox As System.Windows.Forms.CheckBox
	Private lockUserCheckBox As System.Windows.Forms.CheckBox
	Private setLockStateButton As System.Windows.Forms.Button
	Private label15 As System.Windows.Forms.Label
	Private label14 As System.Windows.Forms.Label
	Private secLockStateCB As System.Windows.Forms.ComboBox
	Private killButton As System.Windows.Forms.Button
	Private pickUpButton As System.Windows.Forms.Button
	Private memUseReadBlockCheckBox As System.Windows.Forms.CheckBox
End Class
