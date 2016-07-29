Partial Class Inventory
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
		Me.startStopInventoryBtn = New System.Windows.Forms.Button()
		Me.tagsFoundLabel = New System.Windows.Forms.Label()
		Me.invTypeComboBox = New System.Windows.Forms.ComboBox()
		Me.invTypeLabel = New System.Windows.Forms.Label()
		Me.dataBankLabel = New System.Windows.Forms.Label()
		Me.dataBankComboBox = New System.Windows.Forms.ComboBox()
		Me.tabControl1 = New System.Windows.Forms.TabControl()
		Me.tagsTab = New System.Windows.Forms.TabPage()
		Me.filterTab = New System.Windows.Forms.TabPage()
		Me.incIndex = New System.Windows.Forms.Button()
		Me.decIndex = New System.Windows.Forms.Button()
		Me.label9 = New System.Windows.Forms.Label()
		Me.label8 = New System.Windows.Forms.Label()
		Me.target_combo = New System.Windows.Forms.ComboBox()
		Me.action_combo = New System.Windows.Forms.ComboBox()
		Me.filterCntLabel = New System.Windows.Forms.Label()
		Me.addBtn = New System.Windows.Forms.Button()
		Me.deleteBtn = New System.Windows.Forms.Button()
		Me.length_UpDown = New System.Windows.Forms.NumericUpDown()
		Me.address_UpDown = New System.Windows.Forms.NumericUpDown()
		Me.readTag_Button = New System.Windows.Forms.Button()
		Me.label6 = New System.Windows.Forms.Label()
		Me.label5 = New System.Windows.Forms.Label()
		Me.mask_textBox = New System.Windows.Forms.TextBox()
		Me.bank_combo = New System.Windows.Forms.ComboBox()
		Me.label4 = New System.Windows.Forms.Label()
		Me.label3 = New System.Windows.Forms.Label()
		Me.label7 = New System.Windows.Forms.Label()
		Me.label10 = New System.Windows.Forms.Label()
		Me.settingsTab = New System.Windows.Forms.TabPage()
		Me.dataLengthUpDown = New System.Windows.Forms.NumericUpDown()
		Me.dataStartUpDown = New System.Windows.Forms.NumericUpDown()
		Me.dataLengthLabel = New System.Windows.Forms.Label()
		Me.dataStartLabel = New System.Windows.Forms.Label()
		Me.saveToFileTab = New System.Windows.Forms.TabPage()
		Me.label2 = New System.Windows.Forms.Label()
		Me.logInvSeparatorTextBox = New System.Windows.Forms.TextBox()
		Me.logInvFormatComboBox = New System.Windows.Forms.ComboBox()
		Me.label1 = New System.Windows.Forms.Label()
		Me.logActionLabel = New System.Windows.Forms.Label()
		Me.logInvActionComboBox = New System.Windows.Forms.ComboBox()
		Me.logInvEnabledComboBox = New System.Windows.Forms.CheckBox()
		Me.logInvBrowseBtn = New System.Windows.Forms.Button()
		Me.logInvFileNameTextBox = New System.Windows.Forms.TextBox()
		Me.logFilenameLabel = New System.Windows.Forms.Label()
		Me.columnHeader1 = New System.Windows.Forms.ColumnHeader()
		Me.columnHeader2 = New System.Windows.Forms.ColumnHeader()
		Me.columnHeader3 = New System.Windows.Forms.ColumnHeader()
		Me.columnHeader4 = New System.Windows.Forms.ColumnHeader()
		Me.columnHeader5 = New System.Windows.Forms.ColumnHeader()
		Me.columnHeader6 = New System.Windows.Forms.ColumnHeader()
		Me.columnHeader7 = New System.Windows.Forms.ColumnHeader()
		Me.saveLogDialog = New System.Windows.Forms.SaveFileDialog()
		Me.statTab = New System.Windows.Forms.TabPage()
		Me.totalLabel = New System.Windows.Forms.Label()
		Me.totalReadsLabel = New System.Windows.Forms.Label()
		Me.totalAverageLabel = New System.Windows.Forms.Label()
		Me.uniqueLabel = New System.Windows.Forms.Label()
		Me.uniqueTagsLabel = New System.Windows.Forms.Label()
		Me.uniqueAverageLabel = New System.Windows.Forms.Label()
        Me.tagListBox = New NurTagDataListView()
		Me.startStopInventoryBtn2 = New System.Windows.Forms.Button()
		Me.tabControl1.SuspendLayout()
		Me.tagsTab.SuspendLayout()
		Me.filterTab.SuspendLayout()
		Me.settingsTab.SuspendLayout()
		Me.saveToFileTab.SuspendLayout()
		Me.statTab.SuspendLayout()
		Me.SuspendLayout()
		' 
		' startStopInventoryBtn
		' 
		Me.startStopInventoryBtn.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.startStopInventoryBtn.Location = New System.Drawing.Point(3, 248)
		Me.startStopInventoryBtn.Name = "startStopInventoryBtn"
		Me.startStopInventoryBtn.Size = New System.Drawing.Size(112, 40)
		Me.startStopInventoryBtn.TabIndex = 16
		Me.startStopInventoryBtn.Text = "Start Inventory"
        AddHandler Me.startStopInventoryBtn.Click, New System.EventHandler(AddressOf Me.startStopInventoryBtn_Click)
		' 
		' tagsFoundLabel
		' 
		Me.tagsFoundLabel.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.tagsFoundLabel.Font = New System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold)
		Me.tagsFoundLabel.Location = New System.Drawing.Point(121, 256)
		Me.tagsFoundLabel.Name = "tagsFoundLabel"
		Me.tagsFoundLabel.Size = New System.Drawing.Size(108, 30)
		Me.tagsFoundLabel.Text = "- - -"
		Me.tagsFoundLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
		' 
		' invTypeComboBox
		' 
		Me.invTypeComboBox.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.invTypeComboBox.Items.Add("Inventory only")
		Me.invTypeComboBox.Items.Add("Inv. + data")
		Me.invTypeComboBox.Items.Add("Data only")
		Me.invTypeComboBox.Location = New System.Drawing.Point(109, 4)
		Me.invTypeComboBox.Name = "invTypeComboBox"
		Me.invTypeComboBox.Size = New System.Drawing.Size(120, 23)
		Me.invTypeComboBox.TabIndex = 21
        AddHandler Me.invTypeComboBox.SelectedIndexChanged, New System.EventHandler(AddressOf Me.invTypeComboBox_SelectedIndexChanged)
		' 
		' invTypeLabel
		' 
		Me.invTypeLabel.Location = New System.Drawing.Point(3, 7)
		Me.invTypeLabel.Name = "invTypeLabel"
		Me.invTypeLabel.Size = New System.Drawing.Size(100, 20)
		Me.invTypeLabel.Text = "Inv.Type"
		' 
		' dataBankLabel
		' 
		Me.dataBankLabel.Location = New System.Drawing.Point(3, 36)
		Me.dataBankLabel.Name = "dataBankLabel"
		Me.dataBankLabel.Size = New System.Drawing.Size(100, 20)
		Me.dataBankLabel.Text = "Data.Bank"
		' 
		' dataBankComboBox
		' 
		Me.dataBankComboBox.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.dataBankComboBox.Items.Add("PWD")
		Me.dataBankComboBox.Items.Add("EPC")
		Me.dataBankComboBox.Items.Add("TID")
		Me.dataBankComboBox.Items.Add("USER")
		Me.dataBankComboBox.Location = New System.Drawing.Point(109, 33)
		Me.dataBankComboBox.Name = "dataBankComboBox"
		Me.dataBankComboBox.Size = New System.Drawing.Size(120, 23)
		Me.dataBankComboBox.TabIndex = 42
		' 
		' tabControl1
		' 
		Me.tabControl1.Controls.Add(Me.tagsTab)
		Me.tabControl1.Controls.Add(Me.filterTab)
		Me.tabControl1.Controls.Add(Me.settingsTab)
		Me.tabControl1.Controls.Add(Me.statTab)
		Me.tabControl1.Controls.Add(Me.saveToFileTab)
		Me.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.tabControl1.Location = New System.Drawing.Point(0, 0)
		Me.tabControl1.Name = "tabControl1"
		Me.tabControl1.SelectedIndex = 0
		Me.tabControl1.Size = New System.Drawing.Size(240, 320)
		Me.tabControl1.TabIndex = 47
		' 
		' tagsTab
		' 
		Me.tagsTab.Controls.Add(Me.startStopInventoryBtn)
		Me.tagsTab.Controls.Add(Me.tagListBox)
		Me.tagsTab.Controls.Add(Me.tagsFoundLabel)
		Me.tagsTab.Location = New System.Drawing.Point(4, 25)
		Me.tagsTab.Name = "tagsTab"
		Me.tagsTab.Size = New System.Drawing.Size(232, 291)
		Me.tagsTab.Text = "Tags"
		' 
		' filterTab
		' 
		Me.filterTab.Controls.Add(Me.incIndex)
		Me.filterTab.Controls.Add(Me.decIndex)
		Me.filterTab.Controls.Add(Me.label9)
		Me.filterTab.Controls.Add(Me.label8)
		Me.filterTab.Controls.Add(Me.target_combo)
		Me.filterTab.Controls.Add(Me.action_combo)
		Me.filterTab.Controls.Add(Me.filterCntLabel)
		Me.filterTab.Controls.Add(Me.addBtn)
		Me.filterTab.Controls.Add(Me.deleteBtn)
		Me.filterTab.Controls.Add(Me.length_UpDown)
		Me.filterTab.Controls.Add(Me.address_UpDown)
		Me.filterTab.Controls.Add(Me.readTag_Button)
		Me.filterTab.Controls.Add(Me.label6)
		Me.filterTab.Controls.Add(Me.label5)
		Me.filterTab.Controls.Add(Me.mask_textBox)
		Me.filterTab.Controls.Add(Me.bank_combo)
		Me.filterTab.Controls.Add(Me.label4)
		Me.filterTab.Controls.Add(Me.label3)
		Me.filterTab.Controls.Add(Me.label7)
		Me.filterTab.Controls.Add(Me.label10)
		Me.filterTab.Location = New System.Drawing.Point(4, 25)
		Me.filterTab.Name = "filterTab"
		Me.filterTab.Size = New System.Drawing.Size(232, 291)
		Me.filterTab.Text = "Filters"
		' 
		' incIndex
		' 
		Me.incIndex.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.incIndex.Location = New System.Drawing.Point(179, 3)
		Me.incIndex.Name = "incIndex"
		Me.incIndex.Size = New System.Drawing.Size(50, 20)
		Me.incIndex.TabIndex = 48
		Me.incIndex.Text = ">>"
        AddHandler Me.incIndex.Click, New System.EventHandler(AddressOf Me.incIndex_Click)
		' 
		' decIndex
		' 
		Me.decIndex.Location = New System.Drawing.Point(3, 3)
		Me.decIndex.Name = "decIndex"
		Me.decIndex.Size = New System.Drawing.Size(50, 20)
		Me.decIndex.TabIndex = 47
		Me.decIndex.Text = "<<"
        AddHandler Me.decIndex.Click, New System.EventHandler(AddressOf Me.decIndex_Click)
		' 
		' label9
		' 
		Me.label9.Location = New System.Drawing.Point(3, 178)
		Me.label9.Name = "label9"
		Me.label9.Size = New System.Drawing.Size(60, 20)
		Me.label9.Text = "Target"
		' 
		' label8
		' 
		Me.label8.Location = New System.Drawing.Point(3, 147)
		Me.label8.Name = "label8"
		Me.label8.Size = New System.Drawing.Size(60, 20)
		Me.label8.Text = "Action"
		' 
		' target_combo
		' 
		Me.target_combo.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.target_combo.Items.Add("SESSION_S0")
		Me.target_combo.Items.Add("SESSION_S1")
		Me.target_combo.Items.Add("SESSION_S2")
		Me.target_combo.Items.Add("SESSION_S3")
		Me.target_combo.Items.Add("SESSION_SL")
		Me.target_combo.Location = New System.Drawing.Point(69, 175)
		Me.target_combo.Name = "target_combo"
		Me.target_combo.Size = New System.Drawing.Size(160, 23)
		Me.target_combo.TabIndex = 46
		' 
		' action_combo
		' 
		Me.action_combo.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.action_combo.Items.Add("ACTION_0")
		Me.action_combo.Items.Add("ACTION_1")
		Me.action_combo.Items.Add("ACTION_2")
		Me.action_combo.Items.Add("ACTION_3")
		Me.action_combo.Items.Add("ACTION_4")
		Me.action_combo.Items.Add("ACTION_5")
		Me.action_combo.Items.Add("ACTION_6")
		Me.action_combo.Items.Add("ACTION_7")
		Me.action_combo.Location = New System.Drawing.Point(69, 144)
		Me.action_combo.Name = "action_combo"
		Me.action_combo.Size = New System.Drawing.Size(160, 23)
		Me.action_combo.TabIndex = 45
		' 
		' filterCntLabel
		' 
		Me.filterCntLabel.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.filterCntLabel.Location = New System.Drawing.Point(59, 3)
		Me.filterCntLabel.Name = "filterCntLabel"
		Me.filterCntLabel.Size = New System.Drawing.Size(114, 20)
		Me.filterCntLabel.Text = "filterCntLabel"
		Me.filterCntLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
		' 
		' addBtn
		' 
		Me.addBtn.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.addBtn.Location = New System.Drawing.Point(84, 204)
		Me.addBtn.Name = "addBtn"
		Me.addBtn.Size = New System.Drawing.Size(65, 20)
		Me.addBtn.TabIndex = 44
		Me.addBtn.Text = "Add"
        AddHandler Me.addBtn.Click, New System.EventHandler(AddressOf Me.addBtn_Click)
		' 
		' deleteBtn
		' 
		Me.deleteBtn.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.deleteBtn.Location = New System.Drawing.Point(155, 204)
		Me.deleteBtn.Name = "deleteBtn"
		Me.deleteBtn.Size = New System.Drawing.Size(75, 20)
		Me.deleteBtn.TabIndex = 43
		Me.deleteBtn.Text = "Delete"
        AddHandler Me.deleteBtn.Click, New System.EventHandler(AddressOf Me.deleteBtn_Click)
		' 
		' length_UpDown
		' 
		Me.length_UpDown.Location = New System.Drawing.Point(69, 114)
		Me.length_UpDown.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
		Me.length_UpDown.Name = "length_UpDown"
		Me.length_UpDown.Size = New System.Drawing.Size(100, 24)
		Me.length_UpDown.TabIndex = 41
		' 
		' address_UpDown
		' 
		Me.address_UpDown.Location = New System.Drawing.Point(69, 55)
		Me.address_UpDown.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
		Me.address_UpDown.Name = "address_UpDown"
		Me.address_UpDown.Size = New System.Drawing.Size(100, 24)
		Me.address_UpDown.TabIndex = 39
		' 
		' readTag_Button
		' 
		Me.readTag_Button.Location = New System.Drawing.Point(3, 204)
		Me.readTag_Button.Name = "readTag_Button"
		Me.readTag_Button.Size = New System.Drawing.Size(75, 20)
		Me.readTag_Button.TabIndex = 42
		Me.readTag_Button.Text = "Read Tag"
        AddHandler Me.readTag_Button.Click, New System.EventHandler(AddressOf Me.readTag_Button_Click)
		' 
		' label6
		' 
		Me.label6.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.label6.Location = New System.Drawing.Point(175, 118)
		Me.label6.Name = "label6"
		Me.label6.Size = New System.Drawing.Size(54, 20)
		Me.label6.Text = "bits"
		' 
		' label5
		' 
		Me.label5.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.label5.Location = New System.Drawing.Point(175, 59)
		Me.label5.Name = "label5"
		Me.label5.Size = New System.Drawing.Size(54, 20)
		Me.label5.Text = "bits"
		' 
		' mask_textBox
		' 
		Me.mask_textBox.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.mask_textBox.HideSelection = False
		Me.mask_textBox.Location = New System.Drawing.Point(69, 85)
		Me.mask_textBox.Name = "mask_textBox"
		Me.mask_textBox.Size = New System.Drawing.Size(160, 23)
		Me.mask_textBox.TabIndex = 40
		' 
		' bank_combo
		' 
		Me.bank_combo.Items.Add("0 - Password")
		Me.bank_combo.Items.Add("1 - EPC")
		Me.bank_combo.Items.Add("2 - TID")
		Me.bank_combo.Items.Add("3 - USER")
		Me.bank_combo.Location = New System.Drawing.Point(69, 26)
		Me.bank_combo.Name = "bank_combo"
		Me.bank_combo.Size = New System.Drawing.Size(100, 23)
		Me.bank_combo.TabIndex = 38
		' 
		' label4
		' 
		Me.label4.Location = New System.Drawing.Point(3, 118)
		Me.label4.Name = "label4"
		Me.label4.Size = New System.Drawing.Size(60, 20)
		Me.label4.Text = "Length"
		' 
		' label3
		' 
		Me.label3.Location = New System.Drawing.Point(3, 88)
		Me.label3.Name = "label3"
		Me.label3.Size = New System.Drawing.Size(60, 20)
		Me.label3.Text = "Mask"
		' 
		' label7
		' 
		Me.label7.Location = New System.Drawing.Point(3, 59)
		Me.label7.Name = "label7"
		Me.label7.Size = New System.Drawing.Size(60, 20)
		Me.label7.Text = "Address"
		' 
		' label10
		' 
		Me.label10.Location = New System.Drawing.Point(3, 29)
		Me.label10.Name = "label10"
		Me.label10.Size = New System.Drawing.Size(60, 20)
		Me.label10.Text = "Bank"
		' 
		' settingsTab
		' 
		Me.settingsTab.Controls.Add(Me.dataLengthUpDown)
		Me.settingsTab.Controls.Add(Me.dataStartUpDown)
		Me.settingsTab.Controls.Add(Me.dataLengthLabel)
		Me.settingsTab.Controls.Add(Me.dataStartLabel)
		Me.settingsTab.Controls.Add(Me.dataBankLabel)
		Me.settingsTab.Controls.Add(Me.invTypeComboBox)
		Me.settingsTab.Controls.Add(Me.dataBankComboBox)
		Me.settingsTab.Controls.Add(Me.invTypeLabel)
		Me.settingsTab.Location = New System.Drawing.Point(4, 25)
		Me.settingsTab.Name = "settingsTab"
		Me.settingsTab.Size = New System.Drawing.Size(232, 291)
		Me.settingsTab.Text = "Settings"
		' 
		' dataLengthUpDown
		' 
		Me.dataLengthUpDown.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.dataLengthUpDown.Location = New System.Drawing.Point(109, 92)
		Me.dataLengthUpDown.Maximum = New Decimal(New Integer() {512, 0, 0, 0})
		Me.dataLengthUpDown.Name = "dataLengthUpDown"
		Me.dataLengthUpDown.Size = New System.Drawing.Size(120, 24)
		Me.dataLengthUpDown.TabIndex = 50
		Me.dataLengthUpDown.Value = New Decimal(New Integer() {4, 0, 0, 0})
		' 
		' dataStartUpDown
		' 
		Me.dataStartUpDown.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.dataStartUpDown.Location = New System.Drawing.Point(109, 62)
		Me.dataStartUpDown.Maximum = New Decimal(New Integer() {512, 0, 0, 0})
		Me.dataStartUpDown.Name = "dataStartUpDown"
		Me.dataStartUpDown.Size = New System.Drawing.Size(120, 24)
		Me.dataStartUpDown.TabIndex = 49
		' 
		' dataLengthLabel
		' 
		Me.dataLengthLabel.Location = New System.Drawing.Point(3, 96)
		Me.dataLengthLabel.Name = "dataLengthLabel"
		Me.dataLengthLabel.Size = New System.Drawing.Size(100, 20)
		Me.dataLengthLabel.Text = "Data.Length [W]"
		' 
		' dataStartLabel
		' 
		Me.dataStartLabel.Location = New System.Drawing.Point(3, 66)
		Me.dataStartLabel.Name = "dataStartLabel"
		Me.dataStartLabel.Size = New System.Drawing.Size(100, 20)
		Me.dataStartLabel.Text = "Data.Start [W]"
		' 
		' saveToFileTab
		' 
		Me.saveToFileTab.Controls.Add(Me.label2)
		Me.saveToFileTab.Controls.Add(Me.logInvSeparatorTextBox)
		Me.saveToFileTab.Controls.Add(Me.logInvFormatComboBox)
		Me.saveToFileTab.Controls.Add(Me.label1)
		Me.saveToFileTab.Controls.Add(Me.logActionLabel)
		Me.saveToFileTab.Controls.Add(Me.logInvActionComboBox)
		Me.saveToFileTab.Controls.Add(Me.logInvEnabledComboBox)
		Me.saveToFileTab.Controls.Add(Me.logInvBrowseBtn)
		Me.saveToFileTab.Controls.Add(Me.logInvFileNameTextBox)
		Me.saveToFileTab.Controls.Add(Me.logFilenameLabel)
		Me.saveToFileTab.Location = New System.Drawing.Point(4, 25)
		Me.saveToFileTab.Name = "saveToFileTab"
		Me.saveToFileTab.Size = New System.Drawing.Size(232, 291)
		Me.saveToFileTab.Text = "SaveToFile"
		' 
		' label2
		' 
		Me.label2.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.label2.Location = New System.Drawing.Point(159, 135)
		Me.label2.Name = "label2"
		Me.label2.Size = New System.Drawing.Size(70, 20)
		Me.label2.Text = "Separator"
		' 
		' logInvSeparatorTextBox
		' 
		Me.logInvSeparatorTextBox.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.logInvSeparatorTextBox.Location = New System.Drawing.Point(159, 159)
		Me.logInvSeparatorTextBox.Name = "logInvSeparatorTextBox"
		Me.logInvSeparatorTextBox.Size = New System.Drawing.Size(70, 23)
		Me.logInvSeparatorTextBox.TabIndex = 19
		Me.logInvSeparatorTextBox.Text = ","
        AddHandler Me.logInvSeparatorTextBox.TextChanged, New System.EventHandler(AddressOf Me.logInvSeparatorTextBox_TextChanged)
		' 
		' logInvFormatComboBox
		' 
		Me.logInvFormatComboBox.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.logInvFormatComboBox.DisplayMember = "30"
		Me.logInvFormatComboBox.Items.Add("EPC or DATA")
		Me.logInvFormatComboBox.Items.Add("EPC,DATA")
		Me.logInvFormatComboBox.Items.Add("Date&Time,EPC,RSSI")
		Me.logInvFormatComboBox.Location = New System.Drawing.Point(3, 159)
		Me.logInvFormatComboBox.Name = "logInvFormatComboBox"
		Me.logInvFormatComboBox.Size = New System.Drawing.Size(150, 23)
		Me.logInvFormatComboBox.TabIndex = 15
        AddHandler Me.logInvFormatComboBox.SelectedIndexChanged, New System.EventHandler(AddressOf Me.logInvFormatComboBox_SelectedIndexChanged)
		' 
		' label1
		' 
		Me.label1.Location = New System.Drawing.Point(3, 136)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(150, 20)
		Me.label1.Text = "Log file format"
		' 
		' logActionLabel
		' 
		Me.logActionLabel.Location = New System.Drawing.Point(3, 87)
		Me.logActionLabel.Name = "logActionLabel"
		Me.logActionLabel.Size = New System.Drawing.Size(220, 20)
		Me.logActionLabel.Text = "Log file action"
		' 
		' logInvActionComboBox
		' 
		Me.logInvActionComboBox.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.logInvActionComboBox.DisplayMember = "30"
		Me.logInvActionComboBox.Items.Add("Create new always")
		Me.logInvActionComboBox.Items.Add("Append")
		Me.logInvActionComboBox.Items.Add("Replace")
		Me.logInvActionComboBox.Location = New System.Drawing.Point(3, 110)
		Me.logInvActionComboBox.Name = "logInvActionComboBox"
		Me.logInvActionComboBox.Size = New System.Drawing.Size(150, 23)
		Me.logInvActionComboBox.TabIndex = 14
		' 
		' logInvEnabledComboBox
		' 
		Me.logInvEnabledComboBox.Checked = True
		Me.logInvEnabledComboBox.CheckState = System.Windows.Forms.CheckState.Checked
		Me.logInvEnabledComboBox.Location = New System.Drawing.Point(3, 9)
		Me.logInvEnabledComboBox.Name = "logInvEnabledComboBox"
		Me.logInvEnabledComboBox.Size = New System.Drawing.Size(220, 20)
		Me.logInvEnabledComboBox.TabIndex = 11
		Me.logInvEnabledComboBox.Text = "Log Inventory results to File"
        AddHandler Me.logInvEnabledComboBox.CheckStateChanged, New System.EventHandler(AddressOf Me.logInvEnabledComboBox_CheckStateChanged)
		' 
		' logInvBrowseBtn
		' 
		Me.logInvBrowseBtn.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.logInvBrowseBtn.Location = New System.Drawing.Point(159, 61)
		Me.logInvBrowseBtn.Name = "logInvBrowseBtn"
		Me.logInvBrowseBtn.Size = New System.Drawing.Size(70, 23)
		Me.logInvBrowseBtn.TabIndex = 13
		Me.logInvBrowseBtn.Text = "Browse"
        AddHandler Me.logInvBrowseBtn.Click, New System.EventHandler(AddressOf Me.logInvBrowseBtn_Click)
		' 
		' logInvFileNameTextBox
		' 
		Me.logInvFileNameTextBox.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.logInvFileNameTextBox.Location = New System.Drawing.Point(3, 61)
		Me.logInvFileNameTextBox.Name = "logInvFileNameTextBox"
		Me.logInvFileNameTextBox.Size = New System.Drawing.Size(150, 23)
		Me.logInvFileNameTextBox.TabIndex = 12
		Me.logInvFileNameTextBox.Text = "\NurSample_Inventory.csv"
		' 
		' logFilenameLabel
		' 
		Me.logFilenameLabel.Location = New System.Drawing.Point(3, 38)
		Me.logFilenameLabel.Name = "logFilenameLabel"
		Me.logFilenameLabel.Size = New System.Drawing.Size(220, 20)
		Me.logFilenameLabel.Text = "Log filename"
		' 
		' columnHeader1
		' 
		Me.columnHeader1.Text = "ColumnHeader"
		Me.columnHeader1.Width = 60
		' 
		' columnHeader2
		' 
		Me.columnHeader2.Text = "ColumnHeader"
		Me.columnHeader2.Width = 60
		' 
		' columnHeader3
		' 
		Me.columnHeader3.Text = "ColumnHeader"
		Me.columnHeader3.Width = 60
		' 
		' columnHeader4
		' 
		Me.columnHeader4.Text = "ColumnHeader"
		Me.columnHeader4.Width = 60
		' 
		' columnHeader5
		' 
		Me.columnHeader5.Text = "ColumnHeader"
		Me.columnHeader5.Width = 60
		' 
		' columnHeader6
		' 
		Me.columnHeader6.Text = "ColumnHeader"
		Me.columnHeader6.Width = 60
		' 
		' columnHeader7
		' 
		Me.columnHeader7.Text = "ColumnHeader"
		Me.columnHeader7.Width = 60
		' 
		' statTab
		' 
		Me.statTab.Controls.Add(Me.startStopInventoryBtn2)
		Me.statTab.Controls.Add(Me.uniqueAverageLabel)
		Me.statTab.Controls.Add(Me.uniqueTagsLabel)
		Me.statTab.Controls.Add(Me.uniqueLabel)
		Me.statTab.Controls.Add(Me.totalAverageLabel)
		Me.statTab.Controls.Add(Me.totalReadsLabel)
		Me.statTab.Controls.Add(Me.totalLabel)
		Me.statTab.Location = New System.Drawing.Point(4, 25)
		Me.statTab.Name = "statTab"
		Me.statTab.Size = New System.Drawing.Size(232, 291)
		Me.statTab.Text = "Statistics"
		' 
		' totalLabel
		' 
		Me.totalLabel.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.totalLabel.Location = New System.Drawing.Point(3, 12)
		Me.totalLabel.Name = "totalLabel"
		Me.totalLabel.Size = New System.Drawing.Size(226, 20)
		Me.totalLabel.Text = "Total"
		' 
		' totalReadsLabel
		' 
		Me.totalReadsLabel.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.totalReadsLabel.Location = New System.Drawing.Point(3, 32)
		Me.totalReadsLabel.Name = "totalReadsLabel"
		Me.totalReadsLabel.Size = New System.Drawing.Size(226, 20)
		Me.totalReadsLabel.Text = "Total reads"
		' 
		' totalAverageLabel
		' 
		Me.totalAverageLabel.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.totalAverageLabel.Location = New System.Drawing.Point(3, 52)
		Me.totalAverageLabel.Name = "totalAverageLabel"
		Me.totalAverageLabel.Size = New System.Drawing.Size(226, 20)
		Me.totalAverageLabel.Text = "Average reads"
		' 
		' uniqueLabel
		' 
		Me.uniqueLabel.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.uniqueLabel.Location = New System.Drawing.Point(3, 84)
		Me.uniqueLabel.Name = "uniqueLabel"
		Me.uniqueLabel.Size = New System.Drawing.Size(226, 20)
		Me.uniqueLabel.Text = "Unique"
		' 
		' uniqueTagsLabel
		' 
		Me.uniqueTagsLabel.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.uniqueTagsLabel.Location = New System.Drawing.Point(3, 104)
		Me.uniqueTagsLabel.Name = "uniqueTagsLabel"
		Me.uniqueTagsLabel.Size = New System.Drawing.Size(226, 20)
		Me.uniqueTagsLabel.Text = "Unique tags"
		' 
		' uniqueAverageLabel
		' 
		Me.uniqueAverageLabel.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.uniqueAverageLabel.Location = New System.Drawing.Point(3, 124)
		Me.uniqueAverageLabel.Name = "uniqueAverageLabel"
		Me.uniqueAverageLabel.Size = New System.Drawing.Size(226, 20)
		Me.uniqueAverageLabel.Text = "Average tags"
		' 
		' tagListBox
		' 
		Me.tagListBox.Anchor = DirectCast((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.tagListBox.Location = New System.Drawing.Point(3, 3)
		Me.tagListBox.Name = "tagListBox"
		Me.tagListBox.Size = New System.Drawing.Size(226, 239)
		Me.tagListBox.TabIndex = 15
		AddHandler Me.tagListBox.SelectedTagChanged, New System.EventHandler(AddressOf Me.tagListBox_SelectedTagChanged)
		' 
		' startStopInventoryBtn2
		' 
		Me.startStopInventoryBtn2.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.startStopInventoryBtn2.Location = New System.Drawing.Point(3, 248)
		Me.startStopInventoryBtn2.Name = "startStopInventoryBtn2"
		Me.startStopInventoryBtn2.Size = New System.Drawing.Size(112, 40)
		Me.startStopInventoryBtn2.TabIndex = 17
		Me.startStopInventoryBtn2.Text = "Start Inventory"
        AddHandler Me.startStopInventoryBtn2.Click, New System.EventHandler(AddressOf Me.startStopInventoryBtn_Click)
		' 
		' Inventory
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96F, 96F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.Controls.Add(Me.tabControl1)
		Me.Name = "Inventory"
		Me.Size = New System.Drawing.Size(240, 320)
		Me.tabControl1.ResumeLayout(False)
		Me.tagsTab.ResumeLayout(False)
		Me.filterTab.ResumeLayout(False)
		Me.settingsTab.ResumeLayout(False)
		Me.saveToFileTab.ResumeLayout(False)
		Me.statTab.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

	#End Region

	Private startStopInventoryBtn As System.Windows.Forms.Button
	Private tagListBox As NurTagDataListView
	Private tagsFoundLabel As System.Windows.Forms.Label
	Private invTypeComboBox As System.Windows.Forms.ComboBox
	Private invTypeLabel As System.Windows.Forms.Label
	Private dataBankLabel As System.Windows.Forms.Label
	Private dataBankComboBox As System.Windows.Forms.ComboBox
	Private tabControl1 As System.Windows.Forms.TabControl
	Private tagsTab As System.Windows.Forms.TabPage
	Private settingsTab As System.Windows.Forms.TabPage
	Private dataLengthUpDown As System.Windows.Forms.NumericUpDown
	Private dataStartUpDown As System.Windows.Forms.NumericUpDown
	Private dataLengthLabel As System.Windows.Forms.Label
	Private dataStartLabel As System.Windows.Forms.Label
	Private columnHeader1 As System.Windows.Forms.ColumnHeader
	Private columnHeader2 As System.Windows.Forms.ColumnHeader
	Private columnHeader3 As System.Windows.Forms.ColumnHeader
	Private columnHeader4 As System.Windows.Forms.ColumnHeader
	Private columnHeader5 As System.Windows.Forms.ColumnHeader
	Private columnHeader6 As System.Windows.Forms.ColumnHeader
	Private columnHeader7 As System.Windows.Forms.ColumnHeader
	Private saveToFileTab As System.Windows.Forms.TabPage
	Private label1 As System.Windows.Forms.Label
	Private logActionLabel As System.Windows.Forms.Label
	Private logInvActionComboBox As System.Windows.Forms.ComboBox
	Private logInvEnabledComboBox As System.Windows.Forms.CheckBox
	Private logInvBrowseBtn As System.Windows.Forms.Button
	Private logInvFileNameTextBox As System.Windows.Forms.TextBox
	Private logFilenameLabel As System.Windows.Forms.Label
	Private saveLogDialog As System.Windows.Forms.SaveFileDialog
	Private logInvFormatComboBox As System.Windows.Forms.ComboBox
	Private label2 As System.Windows.Forms.Label
	Private logInvSeparatorTextBox As System.Windows.Forms.TextBox
	Private filterTab As System.Windows.Forms.TabPage
	Private incIndex As System.Windows.Forms.Button
	Private decIndex As System.Windows.Forms.Button
	Private label9 As System.Windows.Forms.Label
	Private label8 As System.Windows.Forms.Label
	Private target_combo As System.Windows.Forms.ComboBox
	Private action_combo As System.Windows.Forms.ComboBox
	Private filterCntLabel As System.Windows.Forms.Label
	Private addBtn As System.Windows.Forms.Button
	Private deleteBtn As System.Windows.Forms.Button
	Private length_UpDown As System.Windows.Forms.NumericUpDown
	Private address_UpDown As System.Windows.Forms.NumericUpDown
	Private readTag_Button As System.Windows.Forms.Button
	Private label6 As System.Windows.Forms.Label
	Private label5 As System.Windows.Forms.Label
	Private mask_textBox As System.Windows.Forms.TextBox
	Private bank_combo As System.Windows.Forms.ComboBox
	Private label4 As System.Windows.Forms.Label
	Private label3 As System.Windows.Forms.Label
	Private label7 As System.Windows.Forms.Label
	Private label10 As System.Windows.Forms.Label
	Private statTab As System.Windows.Forms.TabPage
	Private totalAverageLabel As System.Windows.Forms.Label
	Private totalReadsLabel As System.Windows.Forms.Label
	Private totalLabel As System.Windows.Forms.Label
	Private uniqueLabel As System.Windows.Forms.Label
	Private uniqueAverageLabel As System.Windows.Forms.Label
	Private uniqueTagsLabel As System.Windows.Forms.Label
	Private startStopInventoryBtn2 As System.Windows.Forms.Button
End Class
