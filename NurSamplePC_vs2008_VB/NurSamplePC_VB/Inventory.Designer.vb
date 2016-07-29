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
		Me.settingsTab = New System.Windows.Forms.TabPage()
		Me.dataLengthUpDown = New System.Windows.Forms.NumericUpDown()
		Me.dataStartUpDown = New System.Windows.Forms.NumericUpDown()
		Me.dataLengthLabel = New System.Windows.Forms.Label()
		Me.dataStartLabel = New System.Windows.Forms.Label()
		Me.columnHeader1 = New System.Windows.Forms.ColumnHeader()
		Me.columnHeader2 = New System.Windows.Forms.ColumnHeader()
		Me.columnHeader3 = New System.Windows.Forms.ColumnHeader()
		Me.columnHeader4 = New System.Windows.Forms.ColumnHeader()
		Me.columnHeader5 = New System.Windows.Forms.ColumnHeader()
		Me.columnHeader6 = New System.Windows.Forms.ColumnHeader()
		Me.columnHeader7 = New System.Windows.Forms.ColumnHeader()
        Me.tagListBox = New NurTagDataListView()
		Me.tabControl1.SuspendLayout()
		Me.tagsTab.SuspendLayout()
		Me.settingsTab.SuspendLayout()
		Me.SuspendLayout()
		' 
		' startStopInventoryBtn
		' 
		Me.startStopInventoryBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.startStopInventoryBtn.Location = New System.Drawing.Point(3, 248)
		Me.startStopInventoryBtn.Name = "startStopInventoryBtn"
		Me.startStopInventoryBtn.Size = New System.Drawing.Size(112, 40)
		Me.startStopInventoryBtn.TabIndex = 16
		Me.startStopInventoryBtn.Text = "Start Inventory"
		AddHandler Me.startStopInventoryBtn.Click, New System.EventHandler(AddressOf Me.startStopInventoryBtn_Click)
		' 
		' tagsFoundLabel
		' 
		Me.tagsFoundLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.tagsFoundLabel.Font = New System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold)
		Me.tagsFoundLabel.Location = New System.Drawing.Point(121, 256)
		Me.tagsFoundLabel.Name = "tagsFoundLabel"
		Me.tagsFoundLabel.Size = New System.Drawing.Size(108, 30)
		Me.tagsFoundLabel.Text = "- - -"
		Me.tagsFoundLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
		' 
		' invTypeComboBox
		' 
		Me.invTypeComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
		Me.dataBankComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
		Me.tabControl1.Controls.Add(Me.settingsTab)
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
		Me.dataLengthUpDown.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.dataLengthUpDown.Location = New System.Drawing.Point(109, 92)
		Me.dataLengthUpDown.Maximum = New Decimal(New Integer() {512, 0, 0, 0})
		Me.dataLengthUpDown.Name = "dataLengthUpDown"
		Me.dataLengthUpDown.Size = New System.Drawing.Size(120, 24)
		Me.dataLengthUpDown.TabIndex = 50
		Me.dataLengthUpDown.Value = New Decimal(New Integer() {4, 0, 0, 0})
		' 
		' dataStartUpDown
		' 
		Me.dataStartUpDown.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
		' tagListBox
		' 
		Me.tagListBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.tagListBox.Location = New System.Drawing.Point(3, 3)
		Me.tagListBox.Name = "tagListBox"
		Me.tagListBox.Size = New System.Drawing.Size(226, 239)
		Me.tagListBox.TabIndex = 15
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
		Me.settingsTab.ResumeLayout(False)
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
End Class
