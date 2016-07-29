Partial Class Connection
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
		Me.connectionTLP = New System.Windows.Forms.TableLayoutPanel()
		Me.label1 = New System.Windows.Forms.Label()
		Me.conStatusDesc = New System.Windows.Forms.Label()
		Me.tcpipPort = New System.Windows.Forms.NumericUpDown()
		Me.serialCombo = New System.Windows.Forms.ComboBox()
		Me.usbCombo = New System.Windows.Forms.ComboBox()
		Me.useTcpipPort = New System.Windows.Forms.Label()
		Me.useTcpipHost = New System.Windows.Forms.Label()
		Me.useTcpipRadioBox = New System.Windows.Forms.RadioButton()
		Me.useSerialDevice = New System.Windows.Forms.Label()
		Me.useSerialRadioBox = New System.Windows.Forms.RadioButton()
		Me.useUsbRadioBox = New System.Windows.Forms.RadioButton()
		Me.useUsbDevice = New System.Windows.Forms.Label()
		Me.useUsbAutoDesc = New System.Windows.Forms.Label()
		Me.conTitle = New System.Windows.Forms.Label()
		Me.connectBtn = New System.Windows.Forms.Button()
		Me.conStatus = New System.Windows.Forms.Label()
		Me.tcpipAddr = New System.Windows.Forms.TextBox()
		Me.useUsbAutoRadioBox = New System.Windows.Forms.RadioButton()
		Me.useLatestRadioBox = New System.Windows.Forms.RadioButton()
		Me.connectionTLP.SuspendLayout()
		DirectCast(Me.tcpipPort, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		' 
		' connectionTLP
		' 
		Me.connectionTLP.AutoSize = True
		Me.connectionTLP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.connectionTLP.ColumnCount = 4
		Me.connectionTLP.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
		Me.connectionTLP.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
		Me.connectionTLP.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F))
		Me.connectionTLP.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 171F))
		Me.connectionTLP.Controls.Add(Me.label1, 2, 1)
		Me.connectionTLP.Controls.Add(Me.conStatusDesc, 0, 8)
		Me.connectionTLP.Controls.Add(Me.tcpipPort, 2, 6)
		Me.connectionTLP.Controls.Add(Me.serialCombo, 2, 4)
		Me.connectionTLP.Controls.Add(Me.usbCombo, 2, 3)
		Me.connectionTLP.Controls.Add(Me.useTcpipPort, 1, 6)
		Me.connectionTLP.Controls.Add(Me.useTcpipHost, 1, 5)
		Me.connectionTLP.Controls.Add(Me.useTcpipRadioBox, 0, 5)
		Me.connectionTLP.Controls.Add(Me.useSerialDevice, 1, 4)
		Me.connectionTLP.Controls.Add(Me.useSerialRadioBox, 0, 4)
		Me.connectionTLP.Controls.Add(Me.useUsbRadioBox, 0, 3)
		Me.connectionTLP.Controls.Add(Me.useUsbDevice, 1, 3)
		Me.connectionTLP.Controls.Add(Me.useUsbAutoDesc, 2, 2)
		Me.connectionTLP.Controls.Add(Me.conTitle, 0, 0)
		Me.connectionTLP.Controls.Add(Me.connectBtn, 2, 9)
		Me.connectionTLP.Controls.Add(Me.conStatus, 0, 7)
		Me.connectionTLP.Controls.Add(Me.tcpipAddr, 2, 5)
		Me.connectionTLP.Controls.Add(Me.useUsbAutoRadioBox, 0, 2)
		Me.connectionTLP.Controls.Add(Me.useLatestRadioBox, 0, 1)
		Me.connectionTLP.Dock = System.Windows.Forms.DockStyle.Fill
		Me.connectionTLP.Location = New System.Drawing.Point(0, 0)
		Me.connectionTLP.Margin = New System.Windows.Forms.Padding(0)
		Me.connectionTLP.Name = "connectionTLP"
		Me.connectionTLP.Padding = New System.Windows.Forms.Padding(10)
		Me.connectionTLP.RowCount = 11
		Me.connectionTLP.RowStyles.Add(New System.Windows.Forms.RowStyle())
		Me.connectionTLP.RowStyles.Add(New System.Windows.Forms.RowStyle())
		Me.connectionTLP.RowStyles.Add(New System.Windows.Forms.RowStyle())
		Me.connectionTLP.RowStyles.Add(New System.Windows.Forms.RowStyle())
		Me.connectionTLP.RowStyles.Add(New System.Windows.Forms.RowStyle())
		Me.connectionTLP.RowStyles.Add(New System.Windows.Forms.RowStyle())
		Me.connectionTLP.RowStyles.Add(New System.Windows.Forms.RowStyle())
		Me.connectionTLP.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F))
		Me.connectionTLP.RowStyles.Add(New System.Windows.Forms.RowStyle())
		Me.connectionTLP.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F))
		Me.connectionTLP.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F))
		Me.connectionTLP.Size = New System.Drawing.Size(435, 340)
		Me.connectionTLP.TabIndex = 14
		' 
		' label1
		' 
		Me.label1.AutoSize = True
		Me.connectionTLP.SetColumnSpan(Me.label1, 2)
		Me.label1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.label1.Location = New System.Drawing.Point(132, 37)
		Me.label1.Margin = New System.Windows.Forms.Padding(3, 9, 3, 3)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(290, 17)
		Me.label1.TabIndex = 26
		Me.label1.Text = "Connect using the most recent connection"
		Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		' 
		' conStatusDesc
		' 
		Me.conStatusDesc.AutoSize = True
		Me.connectionTLP.SetColumnSpan(Me.conStatusDesc, 3)
		Me.conStatusDesc.Dock = System.Windows.Forms.DockStyle.Fill
		Me.conStatusDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CByte(0))
		Me.conStatusDesc.Location = New System.Drawing.Point(10, 240)
		Me.conStatusDesc.Margin = New System.Windows.Forms.Padding(0, 0, 0, 10)
		Me.conStatusDesc.Name = "conStatusDesc"
		Me.conStatusDesc.Size = New System.Drawing.Size(244, 20)
		Me.conStatusDesc.TabIndex = 22
		Me.conStatusDesc.Text = "conStatusDesc"
		Me.conStatusDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		' 
		' tcpipPort
		' 
		Me.tcpipPort.Location = New System.Drawing.Point(132, 187)
		Me.tcpipPort.Maximum = New Decimal(New Integer() {60000, 0, 0, 0})
		Me.tcpipPort.Name = "tcpipPort"
		Me.tcpipPort.Size = New System.Drawing.Size(119, 20)
		Me.tcpipPort.TabIndex = 8
		Me.tcpipPort.Value = New Decimal(New Integer() {10000, 0, 0, 0})
		' 
		' serialCombo
		' 
		Me.connectionTLP.SetColumnSpan(Me.serialCombo, 2)
		Me.serialCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.serialCombo.FormattingEnabled = True
		Me.serialCombo.Location = New System.Drawing.Point(132, 128)
		Me.serialCombo.Margin = New System.Windows.Forms.Padding(3, 9, 3, 3)
		Me.serialCombo.Name = "serialCombo"
		Me.serialCombo.Size = New System.Drawing.Size(244, 21)
		Me.serialCombo.TabIndex = 5
		AddHandler Me.serialCombo.Click, New System.EventHandler(AddressOf Me.serialCombo_Click)
		' 
		' usbCombo
		' 
		Me.connectionTLP.SetColumnSpan(Me.usbCombo, 2)
		Me.usbCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.usbCombo.FormattingEnabled = True
		Me.usbCombo.Location = New System.Drawing.Point(132, 95)
		Me.usbCombo.Margin = New System.Windows.Forms.Padding(3, 9, 3, 3)
		Me.usbCombo.Name = "usbCombo"
		Me.usbCombo.Size = New System.Drawing.Size(244, 21)
		Me.usbCombo.TabIndex = 3
		AddHandler Me.usbCombo.Click, New System.EventHandler(AddressOf Me.usbCombo_Click)
		' 
		' useTcpipPort
		' 
		Me.useTcpipPort.AutoSize = True
		Me.useTcpipPort.Dock = System.Windows.Forms.DockStyle.Fill
		Me.useTcpipPort.Location = New System.Drawing.Point(80, 184)
		Me.useTcpipPort.Name = "useTcpipPort"
		Me.useTcpipPort.Size = New System.Drawing.Size(46, 26)
		Me.useTcpipPort.TabIndex = 10
		Me.useTcpipPort.Text = "Port:"
		Me.useTcpipPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		' 
		' useTcpipHost
		' 
		Me.useTcpipHost.AutoSize = True
		Me.useTcpipHost.Dock = System.Windows.Forms.DockStyle.Fill
		Me.useTcpipHost.Location = New System.Drawing.Point(80, 161)
		Me.useTcpipHost.Margin = New System.Windows.Forms.Padding(3, 9, 3, 3)
		Me.useTcpipHost.Name = "useTcpipHost"
		Me.useTcpipHost.Size = New System.Drawing.Size(46, 20)
		Me.useTcpipHost.TabIndex = 4
		Me.useTcpipHost.Text = "Host:"
		Me.useTcpipHost.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		' 
		' useTcpipRadioBox
		' 
		Me.useTcpipRadioBox.AutoSize = True
		Me.useTcpipRadioBox.Dock = System.Windows.Forms.DockStyle.Fill
		Me.useTcpipRadioBox.Location = New System.Drawing.Point(13, 161)
		Me.useTcpipRadioBox.Margin = New System.Windows.Forms.Padding(3, 9, 3, 3)
		Me.useTcpipRadioBox.Name = "useTcpipRadioBox"
		Me.useTcpipRadioBox.Size = New System.Drawing.Size(61, 20)
		Me.useTcpipRadioBox.TabIndex = 6
		Me.useTcpipRadioBox.Text = "TCP/IP"
		Me.useTcpipRadioBox.UseVisualStyleBackColor = True
		AddHandler Me.useTcpipRadioBox.CheckedChanged, New System.EventHandler(AddressOf Me.updateControls_CheckedChanged)
		' 
		' useSerialDevice
		' 
		Me.useSerialDevice.AutoSize = True
		Me.useSerialDevice.Dock = System.Windows.Forms.DockStyle.Fill
		Me.useSerialDevice.Location = New System.Drawing.Point(80, 128)
		Me.useSerialDevice.Margin = New System.Windows.Forms.Padding(3, 9, 3, 3)
		Me.useSerialDevice.Name = "useSerialDevice"
		Me.useSerialDevice.Size = New System.Drawing.Size(46, 21)
		Me.useSerialDevice.TabIndex = 5
		Me.useSerialDevice.Text = "Serial:"
		Me.useSerialDevice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		' 
		' useSerialRadioBox
		' 
		Me.useSerialRadioBox.AutoSize = True
		Me.useSerialRadioBox.Dock = System.Windows.Forms.DockStyle.Fill
		Me.useSerialRadioBox.Location = New System.Drawing.Point(13, 128)
		Me.useSerialRadioBox.Margin = New System.Windows.Forms.Padding(3, 9, 3, 3)
		Me.useSerialRadioBox.Name = "useSerialRadioBox"
		Me.useSerialRadioBox.Size = New System.Drawing.Size(61, 21)
		Me.useSerialRadioBox.TabIndex = 4
		Me.useSerialRadioBox.Text = "Serial"
		Me.useSerialRadioBox.UseVisualStyleBackColor = True
		AddHandler Me.useSerialRadioBox.CheckedChanged, New System.EventHandler(AddressOf Me.updateControls_CheckedChanged)
		' 
		' useUsbRadioBox
		' 
		Me.useUsbRadioBox.AutoSize = True
		Me.useUsbRadioBox.Dock = System.Windows.Forms.DockStyle.Fill
		Me.useUsbRadioBox.Location = New System.Drawing.Point(13, 95)
		Me.useUsbRadioBox.Margin = New System.Windows.Forms.Padding(3, 9, 3, 3)
		Me.useUsbRadioBox.Name = "useUsbRadioBox"
		Me.useUsbRadioBox.Size = New System.Drawing.Size(61, 21)
		Me.useUsbRadioBox.TabIndex = 2
		Me.useUsbRadioBox.Text = "USB"
		Me.useUsbRadioBox.UseVisualStyleBackColor = True
		AddHandler Me.useUsbRadioBox.CheckedChanged, New System.EventHandler(AddressOf Me.updateControls_CheckedChanged)
		' 
		' useUsbDevice
		' 
		Me.useUsbDevice.AutoSize = True
		Me.useUsbDevice.Dock = System.Windows.Forms.DockStyle.Fill
		Me.useUsbDevice.Location = New System.Drawing.Point(80, 95)
		Me.useUsbDevice.Margin = New System.Windows.Forms.Padding(3, 9, 3, 3)
		Me.useUsbDevice.Name = "useUsbDevice"
		Me.useUsbDevice.Size = New System.Drawing.Size(46, 21)
		Me.useUsbDevice.TabIndex = 3
		Me.useUsbDevice.Text = "Device:"
		Me.useUsbDevice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		' 
		' useUsbAutoDesc
		' 
		Me.useUsbAutoDesc.AutoSize = True
		Me.connectionTLP.SetColumnSpan(Me.useUsbAutoDesc, 2)
		Me.useUsbAutoDesc.Dock = System.Windows.Forms.DockStyle.Fill
		Me.useUsbAutoDesc.Location = New System.Drawing.Point(132, 66)
		Me.useUsbAutoDesc.Margin = New System.Windows.Forms.Padding(3, 9, 3, 3)
		Me.useUsbAutoDesc.Name = "useUsbAutoDesc"
		Me.useUsbAutoDesc.Size = New System.Drawing.Size(290, 17)
		Me.useUsbAutoDesc.TabIndex = 18
		Me.useUsbAutoDesc.Text = "Connects automatically via USB connection"
		Me.useUsbAutoDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		' 
		' conTitle
		' 
		Me.conTitle.AutoSize = True
		Me.connectionTLP.SetColumnSpan(Me.conTitle, 3)
		Me.conTitle.Dock = System.Windows.Forms.DockStyle.Fill
		Me.conTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CByte(0))
		Me.conTitle.Location = New System.Drawing.Point(10, 10)
		Me.conTitle.Margin = New System.Windows.Forms.Padding(0, 0, 0, 5)
		Me.conTitle.Name = "conTitle"
		Me.conTitle.Size = New System.Drawing.Size(244, 13)
		Me.conTitle.TabIndex = 23
		Me.conTitle.Text = "Connection method"
		Me.conTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft
		' 
		' connectBtn
		' 
		Me.connectionTLP.SetColumnSpan(Me.connectBtn, 2)
		Me.connectBtn.Dock = System.Windows.Forms.DockStyle.Fill
		Me.connectBtn.Location = New System.Drawing.Point(132, 273)
		Me.connectBtn.Name = "connectBtn"
		Me.connectBtn.Size = New System.Drawing.Size(290, 54)
		Me.connectBtn.TabIndex = 9
		Me.connectBtn.Text = "CONNECT"
		Me.connectBtn.UseVisualStyleBackColor = True
		AddHandler Me.connectBtn.Click, New System.EventHandler(AddressOf Me.connectBtn_Click)
		' 
		' conStatus
		' 
		Me.conStatus.AutoSize = True
		Me.connectionTLP.SetColumnSpan(Me.conStatus, 3)
		Me.conStatus.Dock = System.Windows.Forms.DockStyle.Fill
		Me.conStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CByte(0))
		Me.conStatus.Location = New System.Drawing.Point(10, 210)
		Me.conStatus.Margin = New System.Windows.Forms.Padding(0, 0, 0, 5)
		Me.conStatus.Name = "conStatus"
		Me.conStatus.Size = New System.Drawing.Size(244, 25)
		Me.conStatus.TabIndex = 25
		Me.conStatus.Text = "Connection status"
		Me.conStatus.TextAlign = System.Drawing.ContentAlignment.BottomLeft
		' 
		' tcpipAddr
		' 
		Me.tcpipAddr.Dock = System.Windows.Forms.DockStyle.Fill
		Me.tcpipAddr.Location = New System.Drawing.Point(132, 161)
		Me.tcpipAddr.Margin = New System.Windows.Forms.Padding(3, 9, 3, 3)
		Me.tcpipAddr.Name = "tcpipAddr"
		Me.tcpipAddr.Size = New System.Drawing.Size(119, 20)
		Me.tcpipAddr.TabIndex = 7
		' 
		' useUsbAutoRadioBox
		' 
		Me.useUsbAutoRadioBox.AutoSize = True
		Me.connectionTLP.SetColumnSpan(Me.useUsbAutoRadioBox, 2)
		Me.useUsbAutoRadioBox.Dock = System.Windows.Forms.DockStyle.Fill
		Me.useUsbAutoRadioBox.Location = New System.Drawing.Point(13, 66)
		Me.useUsbAutoRadioBox.Margin = New System.Windows.Forms.Padding(3, 9, 3, 3)
		Me.useUsbAutoRadioBox.Name = "useUsbAutoRadioBox"
		Me.useUsbAutoRadioBox.Size = New System.Drawing.Size(113, 17)
		Me.useUsbAutoRadioBox.TabIndex = 1
		Me.useUsbAutoRadioBox.Text = "USB auto connect"
		Me.useUsbAutoRadioBox.UseVisualStyleBackColor = True
		AddHandler Me.useUsbAutoRadioBox.CheckedChanged, New System.EventHandler(AddressOf Me.updateControls_CheckedChanged)
		' 
		' useLatestRadioBox
		' 
		Me.useLatestRadioBox.AutoSize = True
		Me.connectionTLP.SetColumnSpan(Me.useLatestRadioBox, 2)
		Me.useLatestRadioBox.Dock = System.Windows.Forms.DockStyle.Fill
		Me.useLatestRadioBox.Location = New System.Drawing.Point(13, 37)
		Me.useLatestRadioBox.Margin = New System.Windows.Forms.Padding(3, 9, 3, 3)
		Me.useLatestRadioBox.Name = "useLatestRadioBox"
		Me.useLatestRadioBox.Size = New System.Drawing.Size(113, 17)
		Me.useLatestRadioBox.TabIndex = 0
		Me.useLatestRadioBox.Text = "Latest Connection"
		Me.useLatestRadioBox.UseVisualStyleBackColor = True
		AddHandler Me.useLatestRadioBox.CheckedChanged, New System.EventHandler(AddressOf Me.updateControls_CheckedChanged)
		' 
		' Connection
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoSize = True
		Me.Controls.Add(Me.connectionTLP)
		Me.Name = "Connection"
		Me.Size = New System.Drawing.Size(435, 340)
		AddHandler Me.Load, New System.EventHandler(AddressOf Me.Connection_Load)
		Me.connectionTLP.ResumeLayout(False)
		Me.connectionTLP.PerformLayout()
		DirectCast(Me.tcpipPort, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	#End Region

	Private connectionTLP As System.Windows.Forms.TableLayoutPanel
	Private conStatusDesc As System.Windows.Forms.Label
	Private tcpipPort As System.Windows.Forms.NumericUpDown
	Private serialCombo As System.Windows.Forms.ComboBox
	Private usbCombo As System.Windows.Forms.ComboBox
	Private useTcpipPort As System.Windows.Forms.Label
	Private useTcpipHost As System.Windows.Forms.Label
	Private useTcpipRadioBox As System.Windows.Forms.RadioButton
	Private useSerialDevice As System.Windows.Forms.Label
	Private useSerialRadioBox As System.Windows.Forms.RadioButton
	Private useUsbRadioBox As System.Windows.Forms.RadioButton
	Private useUsbDevice As System.Windows.Forms.Label
	Private useUsbAutoDesc As System.Windows.Forms.Label
	Private conTitle As System.Windows.Forms.Label
	Private connectBtn As System.Windows.Forms.Button
	Private conStatus As System.Windows.Forms.Label
	Private tcpipAddr As System.Windows.Forms.TextBox
	Private useUsbAutoRadioBox As System.Windows.Forms.RadioButton
	Private useLatestRadioBox As System.Windows.Forms.RadioButton
	Private label1 As System.Windows.Forms.Label

End Class
