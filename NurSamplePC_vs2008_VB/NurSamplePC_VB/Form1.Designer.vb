Partial Class Form1
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

	#Region "Windows Form Designer generated code"

	''' <summary>
	''' Required method for Designer support - do not modify
	''' the contents of this method with the code editor.
	''' </summary>
	Private Sub InitializeComponent()
		Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Form1))
		Me.tabControl1 = New System.Windows.Forms.TabControl()
		Me.connectionTab = New System.Windows.Forms.TabPage()
		Me.inventoryTab = New System.Windows.Forms.TabPage()
		Me.locatorTab = New System.Windows.Forms.TabPage()
		Me.writeTab = New System.Windows.Forms.TabPage()
		Me.settingsTab = New System.Windows.Forms.TabPage()
		Me.nxpTab = New System.Windows.Forms.TabPage()
		Me.sensorsTab = New System.Windows.Forms.TabPage()
		Me.logTab = New System.Windows.Forms.TabPage()
        Me.nurInfo = New Info()
        Me.nurInventory = New Inventory()
        Me.nurLocator = New Locator()
        Me.nurWriter = New Writer()
        Me.nurSettings = New Settings()
        Me.nurNxp = New NXP()
        Me.nurSensors = New Sensors()
        Me.nurLog = New Log()
        Me.nurConnection = New Connection()
		Me.tabControl1.SuspendLayout()
		Me.connectionTab.SuspendLayout()
		Me.inventoryTab.SuspendLayout()
		Me.locatorTab.SuspendLayout()
		Me.writeTab.SuspendLayout()
		Me.settingsTab.SuspendLayout()
		Me.nxpTab.SuspendLayout()
		Me.sensorsTab.SuspendLayout()
		Me.logTab.SuspendLayout()
		Me.SuspendLayout()
		' 
		' tabControl1
		' 
		Me.tabControl1.Controls.Add(Me.connectionTab)
		Me.tabControl1.Controls.Add(Me.inventoryTab)
		Me.tabControl1.Controls.Add(Me.locatorTab)
		Me.tabControl1.Controls.Add(Me.writeTab)
		Me.tabControl1.Controls.Add(Me.settingsTab)
		Me.tabControl1.Controls.Add(Me.nxpTab)
		Me.tabControl1.Controls.Add(Me.sensorsTab)
		Me.tabControl1.Controls.Add(Me.logTab)
		Me.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.tabControl1.Location = New System.Drawing.Point(0, 0)
		Me.tabControl1.Name = "tabControl1"
		Me.tabControl1.Padding = New System.Drawing.Point(6, 6)
		Me.tabControl1.SelectedIndex = 0
		Me.tabControl1.Size = New System.Drawing.Size(784, 562)
		Me.tabControl1.TabIndex = 0
		' 
		' connectionTab
		' 
		Me.connectionTab.Controls.Add(Me.nurConnection)
		Me.connectionTab.Controls.Add(Me.nurInfo)
		Me.connectionTab.Location = New System.Drawing.Point(4, 28)
		Me.connectionTab.Margin = New System.Windows.Forms.Padding(6)
		Me.connectionTab.Name = "connectionTab"
		Me.connectionTab.Size = New System.Drawing.Size(776, 530)
		Me.connectionTab.TabIndex = 0
		Me.connectionTab.Text = "Connection"
		Me.connectionTab.UseVisualStyleBackColor = True
		' 
		' inventoryTab
		' 
		Me.inventoryTab.Controls.Add(Me.nurInventory)
		Me.inventoryTab.Location = New System.Drawing.Point(4, 28)
		Me.inventoryTab.Name = "inventoryTab"
		Me.inventoryTab.Size = New System.Drawing.Size(776, 530)
		Me.inventoryTab.TabIndex = 1
		Me.inventoryTab.Text = "Inventory"
		Me.inventoryTab.UseVisualStyleBackColor = True
		' 
		' locatorTab
		' 
		Me.locatorTab.Controls.Add(Me.nurLocator)
		Me.locatorTab.Location = New System.Drawing.Point(4, 28)
		Me.locatorTab.Name = "locatorTab"
		Me.locatorTab.Size = New System.Drawing.Size(776, 530)
		Me.locatorTab.TabIndex = 2
		Me.locatorTab.Text = "Locator"
		Me.locatorTab.UseVisualStyleBackColor = True
		' 
		' writeTab
		' 
		Me.writeTab.Controls.Add(Me.nurWriter)
		Me.writeTab.Location = New System.Drawing.Point(4, 28)
		Me.writeTab.Name = "writeTab"
		Me.writeTab.Size = New System.Drawing.Size(776, 530)
		Me.writeTab.TabIndex = 3
		Me.writeTab.Text = "Writer"
		Me.writeTab.UseVisualStyleBackColor = True
		' 
		' settingsTab
		' 
		Me.settingsTab.Controls.Add(Me.nurSettings)
		Me.settingsTab.Location = New System.Drawing.Point(4, 28)
		Me.settingsTab.Name = "settingsTab"
		Me.settingsTab.Size = New System.Drawing.Size(776, 530)
		Me.settingsTab.TabIndex = 4
		Me.settingsTab.Text = "Settings"
		Me.settingsTab.UseVisualStyleBackColor = True
		' 
		' nxpTab
		' 
		Me.nxpTab.Controls.Add(Me.nurNxp)
		Me.nxpTab.Location = New System.Drawing.Point(4, 28)
		Me.nxpTab.Name = "nxpTab"
		Me.nxpTab.Size = New System.Drawing.Size(776, 530)
		Me.nxpTab.TabIndex = 5
		Me.nxpTab.Text = "NXP"
		Me.nxpTab.UseVisualStyleBackColor = True
		' 
		' sensorsTab
		' 
		Me.sensorsTab.Controls.Add(Me.nurSensors)
		Me.sensorsTab.Location = New System.Drawing.Point(4, 28)
		Me.sensorsTab.Name = "sensorsTab"
		Me.sensorsTab.Padding = New System.Windows.Forms.Padding(3)
		Me.sensorsTab.Size = New System.Drawing.Size(776, 530)
		Me.sensorsTab.TabIndex = 6
		Me.sensorsTab.Text = "Sensors"
		Me.sensorsTab.UseVisualStyleBackColor = True
		' 
		' logTab
		' 
		Me.logTab.Controls.Add(Me.nurLog)
		Me.logTab.Location = New System.Drawing.Point(4, 28)
		Me.logTab.Name = "logTab"
		Me.logTab.Size = New System.Drawing.Size(776, 530)
		Me.logTab.TabIndex = 7
		Me.logTab.Text = "Log"
		Me.logTab.UseVisualStyleBackColor = True
		' 
		' info1
		' 
		Me.nurInfo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.nurInfo.Location = New System.Drawing.Point(455, 3)
		Me.nurInfo.Name = "info1"
		Me.nurInfo.Size = New System.Drawing.Size(318, 522)
		Me.nurInfo.TabIndex = 4
		' 
		' inventory
		' 
		Me.nurInventory.Dock = System.Windows.Forms.DockStyle.Fill
		Me.nurInventory.Enabled = False
		Me.nurInventory.Location = New System.Drawing.Point(0, 0)
		Me.nurInventory.Name = "inventory"
		Me.nurInventory.Size = New System.Drawing.Size(776, 530)
		Me.nurInventory.TabIndex = 0
		' 
		' locator
		' 
		Me.nurLocator.Dock = System.Windows.Forms.DockStyle.Fill
		Me.nurLocator.Enabled = False
		Me.nurLocator.Location = New System.Drawing.Point(0, 0)
		Me.nurLocator.Name = "locator"
		Me.nurLocator.Size = New System.Drawing.Size(776, 530)
		Me.nurLocator.TabIndex = 0
		' 
		' writer
		' 
		Me.nurWriter.Dock = System.Windows.Forms.DockStyle.Fill
		Me.nurWriter.Enabled = False
		Me.nurWriter.Location = New System.Drawing.Point(0, 0)
		Me.nurWriter.Name = "writer"
		Me.nurWriter.Size = New System.Drawing.Size(776, 530)
		Me.nurWriter.TabIndex = 0
		' 
		' settings
		' 
		Me.nurSettings.Dock = System.Windows.Forms.DockStyle.Fill
		Me.nurSettings.Enabled = False
		Me.nurSettings.Location = New System.Drawing.Point(0, 0)
		Me.nurSettings.Name = "settings"
		Me.nurSettings.Size = New System.Drawing.Size(776, 530)
		Me.nurSettings.TabIndex = 0
		' 
		' nxp
		' 
		Me.nurNxp.Dock = System.Windows.Forms.DockStyle.Fill
		Me.nurNxp.Enabled = False
		Me.nurNxp.Location = New System.Drawing.Point(0, 0)
		Me.nurNxp.Name = "nxp"
		Me.nurNxp.Size = New System.Drawing.Size(776, 530)
		Me.nurNxp.TabIndex = 1
		' 
		' sensors
		' 
		Me.nurSensors.Dock = System.Windows.Forms.DockStyle.Fill
		Me.nurSensors.Enabled = False
		Me.nurSensors.Location = New System.Drawing.Point(3, 3)
		Me.nurSensors.Name = "sensors"
		Me.nurSensors.Size = New System.Drawing.Size(770, 524)
		Me.nurSensors.TabIndex = 0
		' 
		' log
		' 
		Me.nurLog.Dock = System.Windows.Forms.DockStyle.Fill
		Me.nurLog.Enabled = False
		Me.nurLog.Location = New System.Drawing.Point(0, 0)
		Me.nurLog.Name = "log"
		Me.nurLog.Size = New System.Drawing.Size(776, 530)
		Me.nurLog.TabIndex = 0
		' 
		' connection1
		' 
		Me.nurConnection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.nurConnection.AutoSize = True
		Me.nurConnection.Location = New System.Drawing.Point(8, 3)
		Me.nurConnection.Name = "connection1"
		Me.nurConnection.Size = New System.Drawing.Size(435, 519)
		Me.nurConnection.TabIndex = 5
		' 
		' Form1
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96F, 96F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.AutoScroll = True
		Me.ClientSize = New System.Drawing.Size(784, 562)
		Me.Controls.Add(Me.tabControl1)
		Me.Icon = DirectCast(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "Form1"
		Me.Text = "Form1"
		AddHandler Me.Load, New System.EventHandler(AddressOf Me.Form1_Load)
		AddHandler Me.FormClosing, New System.Windows.Forms.FormClosingEventHandler(AddressOf Me.Form1_Closing)
		Me.tabControl1.ResumeLayout(False)
		Me.connectionTab.ResumeLayout(False)
		Me.connectionTab.PerformLayout()
		Me.inventoryTab.ResumeLayout(False)
		Me.locatorTab.ResumeLayout(False)
		Me.writeTab.ResumeLayout(False)
		Me.settingsTab.ResumeLayout(False)
		Me.nxpTab.ResumeLayout(False)
		Me.sensorsTab.ResumeLayout(False)
		Me.logTab.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

	#End Region

	Private tabControl1 As System.Windows.Forms.TabControl
	Private inventoryTab As System.Windows.Forms.TabPage
	Private writeTab As System.Windows.Forms.TabPage
	Private connectionTab As System.Windows.Forms.TabPage
	Private locatorTab As System.Windows.Forms.TabPage
	Private nurLocator As Locator
	Private nurWriter As Writer
	Private nurInventory As Inventory
	Private settingsTab As System.Windows.Forms.TabPage
	Private nurSettings As Settings
	Private nxpTab As System.Windows.Forms.TabPage
	Private nurNxp As NXP
	Private sensorsTab As System.Windows.Forms.TabPage
	Private nurSensors As Sensors
	Private logTab As System.Windows.Forms.TabPage
	Private nurLog As Log
	Private nurInfo As Info
	Private nurConnection As Connection
End Class

