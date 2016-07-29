Partial Class Sensors
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
		Me.label9 = New System.Windows.Forms.Label()
		Me.tapSensorCombo = New System.Windows.Forms.ComboBox()
		Me.label10 = New System.Windows.Forms.Label()
		Me.lightSensorCombo = New System.Windows.Forms.ComboBox()
		Me.label13 = New System.Windows.Forms.Label()
		Me.invTO = New System.Windows.Forms.NumericUpDown()
		Me.label1 = New System.Windows.Forms.Label()
		Me.label14 = New System.Windows.Forms.Label()
		Me.ssTO = New System.Windows.Forms.NumericUpDown()
		Me.label2 = New System.Windows.Forms.Label()
		Me.eventsList = New System.Windows.Forms.ListBox()
		Me.label3 = New System.Windows.Forms.Label()
		DirectCast(Me.invTO, System.ComponentModel.ISupportInitialize).BeginInit()
		DirectCast(Me.ssTO, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		' 
		' label9
		' 
		Me.label9.AutoSize = True
		Me.label9.Location = New System.Drawing.Point(3, 42)
		Me.label9.Name = "label9"
		Me.label9.Size = New System.Drawing.Size(60, 13)
		Me.label9.TabIndex = 12
		Me.label9.Text = "Tap sensor"
		Me.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		' 
		' tapSensorCombo
		' 
		Me.tapSensorCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.tapSensorCombo.FormattingEnabled = True
		Me.tapSensorCombo.Items.AddRange(New Object() {"Disabled", "Enabled - Send notification", "Enabled - Scan tag", "Enabled - Inventory"})
		Me.tapSensorCombo.Location = New System.Drawing.Point(6, 59)
		Me.tapSensorCombo.Name = "tapSensorCombo"
		Me.tapSensorCombo.Size = New System.Drawing.Size(200, 21)
		Me.tapSensorCombo.TabIndex = 10
		AddHandler Me.tapSensorCombo.SelectedIndexChanged, New System.EventHandler(AddressOf Me.sensorControl_Changed)
		' 
		' label10
		' 
		Me.label10.AutoSize = True
		Me.label10.Location = New System.Drawing.Point(3, 0)
		Me.label10.Name = "label10"
		Me.label10.Size = New System.Drawing.Size(64, 13)
		Me.label10.TabIndex = 13
		Me.label10.Text = "Light sensor"
		Me.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		' 
		' lightSensorCombo
		' 
		Me.lightSensorCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.lightSensorCombo.FormattingEnabled = True
		Me.lightSensorCombo.Items.AddRange(New Object() {"Disabled", "Enabled - Send notification", "Enabled - Scan tag", "Enabled - Inventory"})
		Me.lightSensorCombo.Location = New System.Drawing.Point(6, 17)
		Me.lightSensorCombo.Name = "lightSensorCombo"
		Me.lightSensorCombo.Size = New System.Drawing.Size(200, 21)
		Me.lightSensorCombo.TabIndex = 11
		AddHandler Me.lightSensorCombo.SelectedIndexChanged, New System.EventHandler(AddressOf Me.sensorControl_Changed)
		' 
		' label13
		' 
		Me.label13.AutoSize = True
		Me.label13.Location = New System.Drawing.Point(3, 84)
		Me.label13.Name = "label13"
		Me.label13.Size = New System.Drawing.Size(143, 13)
		Me.label13.TabIndex = 20
		Me.label13.Text = "Triggered Inventory Timeout:"
		Me.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		' 
		' invTO
		' 
		Me.invTO.Location = New System.Drawing.Point(6, 101)
		Me.invTO.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
		Me.invTO.Name = "invTO"
		Me.invTO.Size = New System.Drawing.Size(61, 20)
		Me.invTO.TabIndex = 23
		Me.invTO.Value = New Decimal(New Integer() {1000, 0, 0, 0})
		AddHandler Me.invTO.ValueChanged, New System.EventHandler(AddressOf Me.sensorControl_Changed)
		' 
		' label1
		' 
		Me.label1.AutoSize = True
		Me.label1.Location = New System.Drawing.Point(73, 144)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(20, 13)
		Me.label1.TabIndex = 24
		Me.label1.Text = "ms"
		Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		' 
		' label14
		' 
		Me.label14.AutoSize = True
		Me.label14.Location = New System.Drawing.Point(3, 125)
		Me.label14.Name = "label14"
		Me.label14.Size = New System.Drawing.Size(142, 13)
		Me.label14.TabIndex = 25
		Me.label14.Text = "Triggered Scan tag Timeout:"
		Me.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		' 
		' ssTO
		' 
		Me.ssTO.Location = New System.Drawing.Point(6, 142)
		Me.ssTO.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
		Me.ssTO.Name = "ssTO"
		Me.ssTO.Size = New System.Drawing.Size(61, 20)
		Me.ssTO.TabIndex = 26
		Me.ssTO.Value = New Decimal(New Integer() {500, 0, 0, 0})
		AddHandler Me.ssTO.ValueChanged, New System.EventHandler(AddressOf Me.sensorControl_Changed)
		' 
		' label2
		' 
		Me.label2.AutoSize = True
		Me.label2.Location = New System.Drawing.Point(73, 103)
		Me.label2.Name = "label2"
		Me.label2.Size = New System.Drawing.Size(20, 13)
		Me.label2.TabIndex = 27
		Me.label2.Text = "ms"
		Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		' 
		' eventsList
		' 
		Me.eventsList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.eventsList.FormattingEnabled = True
		Me.eventsList.IntegralHeight = False
		Me.eventsList.Location = New System.Drawing.Point(6, 184)
		Me.eventsList.Name = "eventsList"
		Me.eventsList.Size = New System.Drawing.Size(228, 120)
		Me.eventsList.TabIndex = 28
		' 
		' label3
		' 
		Me.label3.AutoSize = True
		Me.label3.Location = New System.Drawing.Point(3, 166)
		Me.label3.Name = "label3"
		Me.label3.Size = New System.Drawing.Size(40, 13)
		Me.label3.TabIndex = 29
		Me.label3.Text = "Events"
		Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		' 
		' Sensors
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96F, 96F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.Controls.Add(Me.label3)
		Me.Controls.Add(Me.eventsList)
		Me.Controls.Add(Me.label2)
		Me.Controls.Add(Me.ssTO)
		Me.Controls.Add(Me.label14)
		Me.Controls.Add(Me.invTO)
		Me.Controls.Add(Me.label1)
		Me.Controls.Add(Me.label13)
		Me.Controls.Add(Me.label9)
		Me.Controls.Add(Me.tapSensorCombo)
		Me.Controls.Add(Me.label10)
		Me.Controls.Add(Me.lightSensorCombo)
		Me.Name = "Sensors"
		Me.Size = New System.Drawing.Size(240, 310)
		DirectCast(Me.invTO, System.ComponentModel.ISupportInitialize).EndInit()
		DirectCast(Me.ssTO, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	#End Region

	Private label9 As System.Windows.Forms.Label
	Private tapSensorCombo As System.Windows.Forms.ComboBox
	Private label10 As System.Windows.Forms.Label
	Private lightSensorCombo As System.Windows.Forms.ComboBox
	Private label13 As System.Windows.Forms.Label
	Private invTO As System.Windows.Forms.NumericUpDown
	Private label1 As System.Windows.Forms.Label
	Private label14 As System.Windows.Forms.Label
	Private ssTO As System.Windows.Forms.NumericUpDown
	Private label2 As System.Windows.Forms.Label
	Private eventsList As System.Windows.Forms.ListBox
	Private label3 As System.Windows.Forms.Label

End Class
