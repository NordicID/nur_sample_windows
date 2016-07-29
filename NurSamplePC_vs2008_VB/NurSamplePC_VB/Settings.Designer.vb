Partial Class Settings
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
		Me.tabControl1 = New System.Windows.Forms.TabControl()
		Me.rfTab = New System.Windows.Forms.TabPage()
		Me.antennaLabel = New System.Windows.Forms.Label()
		Me.selectedAntenna = New System.Windows.Forms.ComboBox()
		Me.txlevelLabel = New System.Windows.Forms.Label()
		Me.txLevelCombo = New System.Windows.Forms.ComboBox()
		Me.txmodLabel = New System.Windows.Forms.Label()
		Me.rxdecLabel = New System.Windows.Forms.Label()
		Me.lfLabel = New System.Windows.Forms.Label()
		Me.regionLabel = New System.Windows.Forms.Label()
		Me.txModCombo = New System.Windows.Forms.ComboBox()
		Me.rxDecCombo = New System.Windows.Forms.ComboBox()
		Me.lfCombo = New System.Windows.Forms.ComboBox()
		Me.regionCombo = New System.Windows.Forms.ComboBox()
		Me.invTab = New System.Windows.Forms.TabPage()
		Me.epcLenLabel = New System.Windows.Forms.Label()
		Me.targetLabel = New System.Windows.Forms.Label()
		Me.targetCombo = New System.Windows.Forms.ComboBox()
		Me.roundsCombo = New System.Windows.Forms.ComboBox()
		Me.sessionCombo = New System.Windows.Forms.ComboBox()
		Me.qCombo = New System.Windows.Forms.ComboBox()
		Me.roundsLabel = New System.Windows.Forms.Label()
		Me.sessionLabel = New System.Windows.Forms.Label()
		Me.qLabel = New System.Windows.Forms.Label()
		Me.filtTab = New System.Windows.Forms.TabPage()
		Me.filtGuide = New System.Windows.Forms.Label()
		Me.maxFiltLabel = New System.Windows.Forms.Label()
		Me.minFiltLabel = New System.Windows.Forms.Label()
		Me.inventoryRssiMax = New System.Windows.Forms.NumericUpDown()
		Me.writeRssiMax = New System.Windows.Forms.NumericUpDown()
		Me.readRssiMax = New System.Windows.Forms.NumericUpDown()
		Me.inventoryRssiMin = New System.Windows.Forms.NumericUpDown()
		Me.writeRssiMin = New System.Windows.Forms.NumericUpDown()
		Me.invFiltLabel = New System.Windows.Forms.Label()
		Me.writeFiltLabel = New System.Windows.Forms.Label()
		Me.readRssiMin = New System.Windows.Forms.NumericUpDown()
		Me.readFiltLabel = New System.Windows.Forms.Label()
		Me.rssiFiltLabel = New System.Windows.Forms.Label()
		Me.miscTab = New System.Windows.Forms.TabPage()
		Me.label1 = New System.Windows.Forms.Label()
		Me.storeSetupBtn = New System.Windows.Forms.Button()
		Me.label2 = New System.Windows.Forms.Label()
		Me.periodCombo = New System.Windows.Forms.ComboBox()
		Me.invEpcLenCombo = New System.Windows.Forms.ComboBox()
		Me.tabControl1.SuspendLayout()
		Me.rfTab.SuspendLayout()
		Me.invTab.SuspendLayout()
		Me.filtTab.SuspendLayout()
		Me.miscTab.SuspendLayout()
		Me.SuspendLayout()
		' 
		' tabControl1
		' 
		Me.tabControl1.Controls.Add(Me.rfTab)
		Me.tabControl1.Controls.Add(Me.invTab)
		Me.tabControl1.Controls.Add(Me.filtTab)
		Me.tabControl1.Controls.Add(Me.miscTab)
		Me.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.tabControl1.Location = New System.Drawing.Point(0, 0)
		Me.tabControl1.Name = "tabControl1"
		Me.tabControl1.SelectedIndex = 0
		Me.tabControl1.Size = New System.Drawing.Size(240, 320)
		Me.tabControl1.TabIndex = 0
		AddHandler Me.tabControl1.SelectedIndexChanged, New System.EventHandler(AddressOf Me.SettingsChanged)
		' 
		' rfTab
		' 
		Me.rfTab.Controls.Add(Me.antennaLabel)
		Me.rfTab.Controls.Add(Me.selectedAntenna)
		Me.rfTab.Controls.Add(Me.txlevelLabel)
		Me.rfTab.Controls.Add(Me.txLevelCombo)
		Me.rfTab.Controls.Add(Me.txmodLabel)
		Me.rfTab.Controls.Add(Me.rxdecLabel)
		Me.rfTab.Controls.Add(Me.lfLabel)
		Me.rfTab.Controls.Add(Me.regionLabel)
		Me.rfTab.Controls.Add(Me.txModCombo)
		Me.rfTab.Controls.Add(Me.rxDecCombo)
		Me.rfTab.Controls.Add(Me.lfCombo)
		Me.rfTab.Controls.Add(Me.regionCombo)
		Me.rfTab.Location = New System.Drawing.Point(4, 25)
		Me.rfTab.Name = "rfTab"
		Me.rfTab.Size = New System.Drawing.Size(232, 291)
		Me.rfTab.Text = "Radio"
		' 
		' antennaLabel
		' 
		Me.antennaLabel.Location = New System.Drawing.Point(3, 152)
		Me.antennaLabel.Name = "antennaLabel"
		Me.antennaLabel.Size = New System.Drawing.Size(100, 20)
		Me.antennaLabel.Text = "Antenna"
		Me.antennaLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
		' 
		' selectedAntenna
		' 
		Me.selectedAntenna.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.selectedAntenna.Location = New System.Drawing.Point(109, 152)
		Me.selectedAntenna.Name = "selectedAntenna"
		Me.selectedAntenna.Size = New System.Drawing.Size(120, 23)
		Me.selectedAntenna.TabIndex = 17
		AddHandler Me.selectedAntenna.SelectedIndexChanged, New System.EventHandler(AddressOf Me.SettingsChanged)
		' 
		' txlevelLabel
		' 
		Me.txlevelLabel.Location = New System.Drawing.Point(3, 65)
		Me.txlevelLabel.Name = "txlevelLabel"
		Me.txlevelLabel.Size = New System.Drawing.Size(100, 20)
		Me.txlevelLabel.Text = "TX Level"
		Me.txlevelLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
		' 
		' txLevelCombo
		' 
		Me.txLevelCombo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.txLevelCombo.Items.Add("500 mW")
		Me.txLevelCombo.Items.Add("398 mW")
		Me.txLevelCombo.Items.Add("316 mW")
		Me.txLevelCombo.Items.Add("251 mW")
		Me.txLevelCombo.Items.Add("200 mW")
		Me.txLevelCombo.Items.Add("158 mW")
		Me.txLevelCombo.Items.Add("126 mW")
		Me.txLevelCombo.Items.Add("100 mW")
		Me.txLevelCombo.Items.Add("79 mW")
		Me.txLevelCombo.Items.Add("63 mW")
		Me.txLevelCombo.Items.Add("50 mW")
		Me.txLevelCombo.Items.Add("40 mW")
		Me.txLevelCombo.Items.Add("32 mW")
		Me.txLevelCombo.Items.Add("25 mW")
		Me.txLevelCombo.Items.Add("20 mW")
		Me.txLevelCombo.Items.Add("16 mW")
		Me.txLevelCombo.Items.Add("13 mW")
		Me.txLevelCombo.Items.Add("10 mW")
		Me.txLevelCombo.Items.Add("8 mW")
		Me.txLevelCombo.Location = New System.Drawing.Point(109, 65)
		Me.txLevelCombo.Name = "txLevelCombo"
		Me.txLevelCombo.Size = New System.Drawing.Size(120, 23)
		Me.txLevelCombo.TabIndex = 14
		AddHandler Me.txLevelCombo.SelectedIndexChanged, New System.EventHandler(AddressOf Me.SettingsChanged)
		' 
		' txmodLabel
		' 
		Me.txmodLabel.Location = New System.Drawing.Point(3, 94)
		Me.txmodLabel.Name = "txmodLabel"
		Me.txmodLabel.Size = New System.Drawing.Size(100, 20)
		Me.txmodLabel.Text = "TX Modulation"
		Me.txmodLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
		' 
		' rxdecLabel
		' 
		Me.rxdecLabel.Location = New System.Drawing.Point(3, 123)
		Me.rxdecLabel.Name = "rxdecLabel"
		Me.rxdecLabel.Size = New System.Drawing.Size(100, 20)
		Me.rxdecLabel.Text = "RX Decoding"
		Me.rxdecLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
		' 
		' lfLabel
		' 
		Me.lfLabel.Location = New System.Drawing.Point(3, 39)
		Me.lfLabel.Name = "lfLabel"
		Me.lfLabel.Size = New System.Drawing.Size(100, 20)
		Me.lfLabel.Text = "Link Frequency"
		Me.lfLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
		' 
		' regionLabel
		' 
		Me.regionLabel.Location = New System.Drawing.Point(3, 10)
		Me.regionLabel.Name = "regionLabel"
		Me.regionLabel.Size = New System.Drawing.Size(100, 20)
		Me.regionLabel.Text = "Region"
		Me.regionLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
		' 
		' txModCombo
		' 
		Me.txModCombo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.txModCombo.Items.Add("ASK")
		Me.txModCombo.Items.Add("PR-ASK")
		Me.txModCombo.Location = New System.Drawing.Point(109, 94)
		Me.txModCombo.Name = "txModCombo"
		Me.txModCombo.Size = New System.Drawing.Size(120, 23)
		Me.txModCombo.TabIndex = 15
		AddHandler Me.txModCombo.SelectedIndexChanged, New System.EventHandler(AddressOf Me.SettingsChanged)
		' 
		' rxDecCombo
		' 
		Me.rxDecCombo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.rxDecCombo.Items.Add("FM-0")
		Me.rxDecCombo.Items.Add("Miller-2")
		Me.rxDecCombo.Items.Add("Miller-4")
		Me.rxDecCombo.Items.Add("Miller-8")
		Me.rxDecCombo.Location = New System.Drawing.Point(109, 123)
		Me.rxDecCombo.Name = "rxDecCombo"
		Me.rxDecCombo.Size = New System.Drawing.Size(120, 23)
		Me.rxDecCombo.TabIndex = 16
		AddHandler Me.rxDecCombo.SelectedIndexChanged, New System.EventHandler(AddressOf Me.SettingsChanged)
		' 
		' lfCombo
		' 
		Me.lfCombo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lfCombo.Items.Add("160 Khz")
		Me.lfCombo.Items.Add("256 Khz")
		Me.lfCombo.Items.Add("320 Khz")
		Me.lfCombo.Location = New System.Drawing.Point(109, 36)
		Me.lfCombo.Name = "lfCombo"
		Me.lfCombo.Size = New System.Drawing.Size(120, 23)
		Me.lfCombo.TabIndex = 13
		AddHandler Me.lfCombo.SelectedIndexChanged, New System.EventHandler(AddressOf Me.SettingsChanged)
		' 
		' regionCombo
		' 
		Me.regionCombo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.regionCombo.Items.Add("0 - Europe")
		Me.regionCombo.Items.Add("1 - North-America")
		Me.regionCombo.Items.Add("2 - People's Republic of China, upper band")
		Me.regionCombo.Items.Add("3 - Malaysia")
		Me.regionCombo.Items.Add("4 - Brazil")
		Me.regionCombo.Items.Add("5 - Australia")
		Me.regionCombo.Items.Add("6 - New Zealand")
		Me.regionCombo.Location = New System.Drawing.Point(109, 7)
		Me.regionCombo.Name = "regionCombo"
		Me.regionCombo.Size = New System.Drawing.Size(120, 23)
		Me.regionCombo.TabIndex = 11
		AddHandler Me.regionCombo.SelectedIndexChanged, New System.EventHandler(AddressOf Me.SettingsChanged)
		' 
		' invTab
		' 
		Me.invTab.Controls.Add(Me.invEpcLenCombo)
		Me.invTab.Controls.Add(Me.label2)
		Me.invTab.Controls.Add(Me.periodCombo)
		Me.invTab.Controls.Add(Me.epcLenLabel)
		Me.invTab.Controls.Add(Me.targetLabel)
		Me.invTab.Controls.Add(Me.targetCombo)
		Me.invTab.Controls.Add(Me.roundsCombo)
		Me.invTab.Controls.Add(Me.sessionCombo)
		Me.invTab.Controls.Add(Me.qCombo)
		Me.invTab.Controls.Add(Me.roundsLabel)
		Me.invTab.Controls.Add(Me.sessionLabel)
		Me.invTab.Controls.Add(Me.qLabel)
		Me.invTab.Location = New System.Drawing.Point(4, 25)
		Me.invTab.Name = "invTab"
		Me.invTab.Size = New System.Drawing.Size(232, 291)
		Me.invTab.Text = "Inventory"
		' 
		' epcLenLabel
		' 
		Me.epcLenLabel.Location = New System.Drawing.Point(3, 157)
		Me.epcLenLabel.Name = "epcLenLabel"
		Me.epcLenLabel.Size = New System.Drawing.Size(100, 20)
		Me.epcLenLabel.Text = "EPC Length"
		Me.epcLenLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
		' 
		' targetLabel
		' 
		Me.targetLabel.Location = New System.Drawing.Point(3, 99)
		Me.targetLabel.Name = "targetLabel"
		Me.targetLabel.Size = New System.Drawing.Size(100, 20)
		Me.targetLabel.Text = "Target"
		Me.targetLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
		' 
		' targetCombo
		' 
		Me.targetCombo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.targetCombo.Items.Add("A")
		Me.targetCombo.Items.Add("B")
		Me.targetCombo.Items.Add("Auto Switch")
		Me.targetCombo.Location = New System.Drawing.Point(109, 96)
		Me.targetCombo.Name = "targetCombo"
		Me.targetCombo.Size = New System.Drawing.Size(120, 23)
		Me.targetCombo.TabIndex = 35
		AddHandler Me.targetCombo.SelectedIndexChanged, New System.EventHandler(AddressOf Me.SettingsChanged)
		' 
		' roundsCombo
		' 
		Me.roundsCombo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.roundsCombo.Items.Add("AUTO")
		Me.roundsCombo.Items.Add("1")
		Me.roundsCombo.Items.Add("2")
		Me.roundsCombo.Items.Add("3")
		Me.roundsCombo.Items.Add("4")
		Me.roundsCombo.Items.Add("5")
		Me.roundsCombo.Items.Add("6")
		Me.roundsCombo.Items.Add("7")
		Me.roundsCombo.Items.Add("8")
		Me.roundsCombo.Items.Add("9")
		Me.roundsCombo.Items.Add("10")
		Me.roundsCombo.Location = New System.Drawing.Point(109, 38)
		Me.roundsCombo.Name = "roundsCombo"
		Me.roundsCombo.Size = New System.Drawing.Size(120, 23)
		Me.roundsCombo.TabIndex = 32
		AddHandler Me.roundsCombo.SelectedIndexChanged, New System.EventHandler(AddressOf Me.SettingsChanged)
		' 
		' sessionCombo
		' 
		Me.sessionCombo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.sessionCombo.Items.Add("0")
		Me.sessionCombo.Items.Add("1")
		Me.sessionCombo.Items.Add("2")
		Me.sessionCombo.Items.Add("3")
		Me.sessionCombo.Location = New System.Drawing.Point(109, 9)
		Me.sessionCombo.Name = "sessionCombo"
		Me.sessionCombo.Size = New System.Drawing.Size(120, 23)
		Me.sessionCombo.TabIndex = 30
		AddHandler Me.sessionCombo.SelectedIndexChanged, New System.EventHandler(AddressOf Me.SettingsChanged)
		' 
		' qCombo
		' 
		Me.qCombo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.qCombo.Items.Add("AUTO")
		Me.qCombo.Items.Add("1")
		Me.qCombo.Items.Add("2")
		Me.qCombo.Items.Add("3")
		Me.qCombo.Items.Add("4")
		Me.qCombo.Items.Add("5")
		Me.qCombo.Items.Add("6")
		Me.qCombo.Items.Add("7")
		Me.qCombo.Items.Add("8")
		Me.qCombo.Items.Add("9")
		Me.qCombo.Items.Add("10")
		Me.qCombo.Items.Add("11")
		Me.qCombo.Items.Add("12")
		Me.qCombo.Items.Add("13")
		Me.qCombo.Items.Add("14")
		Me.qCombo.Items.Add("15")
		Me.qCombo.Location = New System.Drawing.Point(109, 67)
		Me.qCombo.Name = "qCombo"
		Me.qCombo.Size = New System.Drawing.Size(120, 23)
		Me.qCombo.TabIndex = 34
		AddHandler Me.qCombo.SelectedIndexChanged, New System.EventHandler(AddressOf Me.SettingsChanged)
		' 
		' roundsLabel
		' 
		Me.roundsLabel.Location = New System.Drawing.Point(3, 41)
		Me.roundsLabel.Name = "roundsLabel"
		Me.roundsLabel.Size = New System.Drawing.Size(100, 20)
		Me.roundsLabel.Text = "Rounds"
		Me.roundsLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
		' 
		' sessionLabel
		' 
		Me.sessionLabel.Location = New System.Drawing.Point(3, 12)
		Me.sessionLabel.Name = "sessionLabel"
		Me.sessionLabel.Size = New System.Drawing.Size(100, 20)
		Me.sessionLabel.Text = "Session"
		Me.sessionLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
		' 
		' qLabel
		' 
		Me.qLabel.Location = New System.Drawing.Point(3, 70)
		Me.qLabel.Name = "qLabel"
		Me.qLabel.Size = New System.Drawing.Size(100, 20)
		Me.qLabel.Text = "Q"
		Me.qLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
		' 
		' filtTab
		' 
		Me.filtTab.Controls.Add(Me.filtGuide)
		Me.filtTab.Controls.Add(Me.maxFiltLabel)
		Me.filtTab.Controls.Add(Me.minFiltLabel)
		Me.filtTab.Controls.Add(Me.inventoryRssiMax)
		Me.filtTab.Controls.Add(Me.writeRssiMax)
		Me.filtTab.Controls.Add(Me.readRssiMax)
		Me.filtTab.Controls.Add(Me.inventoryRssiMin)
		Me.filtTab.Controls.Add(Me.writeRssiMin)
		Me.filtTab.Controls.Add(Me.invFiltLabel)
		Me.filtTab.Controls.Add(Me.writeFiltLabel)
		Me.filtTab.Controls.Add(Me.readRssiMin)
		Me.filtTab.Controls.Add(Me.readFiltLabel)
		Me.filtTab.Controls.Add(Me.rssiFiltLabel)
		Me.filtTab.Location = New System.Drawing.Point(4, 25)
		Me.filtTab.Name = "filtTab"
		Me.filtTab.Size = New System.Drawing.Size(232, 291)
		Me.filtTab.Text = "Filter"
		' 
		' filtGuide
		' 
		Me.filtGuide.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.filtGuide.Location = New System.Drawing.Point(3, 140)
		Me.filtGuide.Name = "filtGuide"
		Me.filtGuide.Size = New System.Drawing.Size(226, 151)
		Me.filtGuide.Text = "Use 0 to disable filtering. Typical RSSI range is between -80 and -40 dB."
		' 
		' maxFiltLabel
		' 
		Me.maxFiltLabel.Font = New System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold)
		Me.maxFiltLabel.Location = New System.Drawing.Point(147, 9)
		Me.maxFiltLabel.Name = "maxFiltLabel"
		Me.maxFiltLabel.Size = New System.Drawing.Size(60, 20)
		Me.maxFiltLabel.Text = "MAX"
		Me.maxFiltLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
		' 
		' minFiltLabel
		' 
		Me.minFiltLabel.Font = New System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold)
		Me.minFiltLabel.Location = New System.Drawing.Point(81, 9)
		Me.minFiltLabel.Name = "minFiltLabel"
		Me.minFiltLabel.Size = New System.Drawing.Size(60, 20)
		Me.minFiltLabel.Text = "MIN"
		Me.minFiltLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
		' 
		' inventoryRssiMax
		' 
		Me.inventoryRssiMax.Location = New System.Drawing.Point(147, 106)
		Me.inventoryRssiMax.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
		Me.inventoryRssiMax.Minimum = New Decimal(New Integer() {127, 0, 0, -2147483648})
		Me.inventoryRssiMax.Name = "inventoryRssiMax"
		Me.inventoryRssiMax.Size = New System.Drawing.Size(60, 24)
		Me.inventoryRssiMax.TabIndex = 38
		AddHandler Me.inventoryRssiMax.ValueChanged, New System.EventHandler(AddressOf Me.SettingsChanged)
		' 
		' writeRssiMax
		' 
		Me.writeRssiMax.Location = New System.Drawing.Point(147, 69)
		Me.writeRssiMax.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
		Me.writeRssiMax.Minimum = New Decimal(New Integer() {127, 0, 0, -2147483648})
		Me.writeRssiMax.Name = "writeRssiMax"
		Me.writeRssiMax.Size = New System.Drawing.Size(60, 24)
		Me.writeRssiMax.TabIndex = 37
		AddHandler Me.writeRssiMax.ValueChanged, New System.EventHandler(AddressOf Me.SettingsChanged)
		' 
		' readRssiMax
		' 
		Me.readRssiMax.Location = New System.Drawing.Point(147, 32)
		Me.readRssiMax.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
		Me.readRssiMax.Minimum = New Decimal(New Integer() {127, 0, 0, -2147483648})
		Me.readRssiMax.Name = "readRssiMax"
		Me.readRssiMax.Size = New System.Drawing.Size(60, 24)
		Me.readRssiMax.TabIndex = 36
		AddHandler Me.readRssiMax.ValueChanged, New System.EventHandler(AddressOf Me.SettingsChanged)
		' 
		' inventoryRssiMin
		' 
		Me.inventoryRssiMin.Location = New System.Drawing.Point(81, 106)
		Me.inventoryRssiMin.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
		Me.inventoryRssiMin.Minimum = New Decimal(New Integer() {127, 0, 0, -2147483648})
		Me.inventoryRssiMin.Name = "inventoryRssiMin"
		Me.inventoryRssiMin.Size = New System.Drawing.Size(60, 24)
		Me.inventoryRssiMin.TabIndex = 35
		AddHandler Me.inventoryRssiMin.ValueChanged, New System.EventHandler(AddressOf Me.SettingsChanged)
		' 
		' writeRssiMin
		' 
		Me.writeRssiMin.Location = New System.Drawing.Point(81, 69)
		Me.writeRssiMin.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
		Me.writeRssiMin.Minimum = New Decimal(New Integer() {127, 0, 0, -2147483648})
		Me.writeRssiMin.Name = "writeRssiMin"
		Me.writeRssiMin.Size = New System.Drawing.Size(60, 24)
		Me.writeRssiMin.TabIndex = 34
		AddHandler Me.writeRssiMin.ValueChanged, New System.EventHandler(AddressOf Me.SettingsChanged)
		' 
		' invFiltLabel
		' 
		Me.invFiltLabel.Location = New System.Drawing.Point(3, 110)
		Me.invFiltLabel.Name = "invFiltLabel"
		Me.invFiltLabel.Size = New System.Drawing.Size(72, 20)
		Me.invFiltLabel.Text = "Inventory"
		Me.invFiltLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
		' 
		' writeFiltLabel
		' 
		Me.writeFiltLabel.Location = New System.Drawing.Point(3, 73)
		Me.writeFiltLabel.Name = "writeFiltLabel"
		Me.writeFiltLabel.Size = New System.Drawing.Size(72, 20)
		Me.writeFiltLabel.Text = "Write"
		Me.writeFiltLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
		' 
		' readRssiMin
		' 
		Me.readRssiMin.Location = New System.Drawing.Point(81, 32)
		Me.readRssiMin.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
		Me.readRssiMin.Minimum = New Decimal(New Integer() {127, 0, 0, -2147483648})
		Me.readRssiMin.Name = "readRssiMin"
		Me.readRssiMin.Size = New System.Drawing.Size(60, 24)
		Me.readRssiMin.TabIndex = 33
		AddHandler Me.readRssiMin.ValueChanged, New System.EventHandler(AddressOf Me.SettingsChanged)
		' 
		' readFiltLabel
		' 
		Me.readFiltLabel.Location = New System.Drawing.Point(3, 36)
		Me.readFiltLabel.Name = "readFiltLabel"
		Me.readFiltLabel.Size = New System.Drawing.Size(72, 20)
		Me.readFiltLabel.Text = "Read"
		Me.readFiltLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
		' 
		' rssiFiltLabel
		' 
		Me.rssiFiltLabel.Font = New System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold)
		Me.rssiFiltLabel.Location = New System.Drawing.Point(3, 9)
		Me.rssiFiltLabel.Name = "rssiFiltLabel"
		Me.rssiFiltLabel.Size = New System.Drawing.Size(91, 20)
		Me.rssiFiltLabel.Text = "RSSI Filter"
		' 
		' miscTab
		' 
		Me.miscTab.Controls.Add(Me.label1)
		Me.miscTab.Controls.Add(Me.storeSetupBtn)
		Me.miscTab.Location = New System.Drawing.Point(4, 25)
		Me.miscTab.Name = "miscTab"
		Me.miscTab.Size = New System.Drawing.Size(232, 291)
		Me.miscTab.Text = "Misc"
		' 
		' label1
		' 
		Me.label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.label1.Location = New System.Drawing.Point(3, 0)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(230, 54)
		Me.label1.Text = "Store current module full setup, exluding baudrate, to module's non-volatile memo" & "ry. "
		' 
		' storeSetupBtn
		' 
		Me.storeSetupBtn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.storeSetupBtn.Location = New System.Drawing.Point(3, 57)
		Me.storeSetupBtn.Name = "storeSetupBtn"
		Me.storeSetupBtn.Size = New System.Drawing.Size(225, 20)
		Me.storeSetupBtn.TabIndex = 0
		Me.storeSetupBtn.Text = "Store Setup"
		AddHandler Me.storeSetupBtn.Click, New System.EventHandler(AddressOf Me.storeSetupBtn_Click)
		' 
		' label2
		' 
		Me.label2.Location = New System.Drawing.Point(3, 128)
		Me.label2.Name = "label2"
		Me.label2.Size = New System.Drawing.Size(100, 20)
		Me.label2.Text = "Power saving"
		Me.label2.TextAlign = System.Drawing.ContentAlignment.TopRight
		' 
		' periodCombo
		' 
		Me.periodCombo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.periodCombo.Items.Add("A")
		Me.periodCombo.Items.Add("B")
		Me.periodCombo.Items.Add("Auto Switch")
		Me.periodCombo.Location = New System.Drawing.Point(109, 125)
		Me.periodCombo.Name = "periodCombo"
		Me.periodCombo.Size = New System.Drawing.Size(120, 23)
		Me.periodCombo.TabIndex = 42
		AddHandler Me.periodCombo.SelectedIndexChanged, New System.EventHandler(AddressOf Me.SettingsChanged)
		' 
		' invEpcLenCombo
		' 
		Me.invEpcLenCombo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.invEpcLenCombo.Items.Add("A")
		Me.invEpcLenCombo.Items.Add("B")
		Me.invEpcLenCombo.Items.Add("Auto Switch")
		Me.invEpcLenCombo.Location = New System.Drawing.Point(109, 154)
		Me.invEpcLenCombo.Name = "invEpcLenCombo"
		Me.invEpcLenCombo.Size = New System.Drawing.Size(120, 23)
		Me.invEpcLenCombo.TabIndex = 44
		AddHandler Me.invEpcLenCombo.SelectedIndexChanged, New System.EventHandler(AddressOf Me.SettingsChanged)
		' 
		' Settings
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96F, 96F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.Controls.Add(Me.tabControl1)
		Me.Name = "Settings"
		Me.Size = New System.Drawing.Size(240, 320)
		Me.tabControl1.ResumeLayout(False)
		Me.rfTab.ResumeLayout(False)
		Me.invTab.ResumeLayout(False)
		Me.filtTab.ResumeLayout(False)
		Me.miscTab.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

	#End Region

	Private tabControl1 As System.Windows.Forms.TabControl
	Private rfTab As System.Windows.Forms.TabPage
	Private invTab As System.Windows.Forms.TabPage
	Private antennaLabel As System.Windows.Forms.Label
	Private selectedAntenna As System.Windows.Forms.ComboBox
	Private txlevelLabel As System.Windows.Forms.Label
	Private txLevelCombo As System.Windows.Forms.ComboBox
	Private txmodLabel As System.Windows.Forms.Label
	Private rxdecLabel As System.Windows.Forms.Label
	Private lfLabel As System.Windows.Forms.Label
	Private regionLabel As System.Windows.Forms.Label
	Private txModCombo As System.Windows.Forms.ComboBox
	Private rxDecCombo As System.Windows.Forms.ComboBox
	Private lfCombo As System.Windows.Forms.ComboBox
	Private regionCombo As System.Windows.Forms.ComboBox
	Private epcLenLabel As System.Windows.Forms.Label
	Private targetLabel As System.Windows.Forms.Label
	Private targetCombo As System.Windows.Forms.ComboBox
	Private roundsCombo As System.Windows.Forms.ComboBox
	Private sessionCombo As System.Windows.Forms.ComboBox
	Private qCombo As System.Windows.Forms.ComboBox
	Private roundsLabel As System.Windows.Forms.Label
	Private sessionLabel As System.Windows.Forms.Label
	Private qLabel As System.Windows.Forms.Label
	Private filtTab As System.Windows.Forms.TabPage
	Private filtGuide As System.Windows.Forms.Label
	Private maxFiltLabel As System.Windows.Forms.Label
	Private minFiltLabel As System.Windows.Forms.Label
	Private inventoryRssiMax As System.Windows.Forms.NumericUpDown
	Private writeRssiMax As System.Windows.Forms.NumericUpDown
	Private readRssiMax As System.Windows.Forms.NumericUpDown
	Private inventoryRssiMin As System.Windows.Forms.NumericUpDown
	Private writeRssiMin As System.Windows.Forms.NumericUpDown
	Private invFiltLabel As System.Windows.Forms.Label
	Private writeFiltLabel As System.Windows.Forms.Label
	Private readRssiMin As System.Windows.Forms.NumericUpDown
	Private readFiltLabel As System.Windows.Forms.Label
	Private rssiFiltLabel As System.Windows.Forms.Label
	Private miscTab As System.Windows.Forms.TabPage
	Private storeSetupBtn As System.Windows.Forms.Button
	Private label1 As System.Windows.Forms.Label
	Private label2 As System.Windows.Forms.Label
	Private periodCombo As System.Windows.Forms.ComboBox
	Private invEpcLenCombo As System.Windows.Forms.ComboBox
End Class
