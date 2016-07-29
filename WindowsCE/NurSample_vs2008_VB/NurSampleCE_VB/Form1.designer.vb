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
		Me.tabControl1 = New System.Windows.Forms.TabControl()
		Me.infoTab = New System.Windows.Forms.TabPage()
        Me.nurInfo = New Info()
		Me.inventoryTab = New System.Windows.Forms.TabPage()
        Me.nurInventory = New Inventory()
		Me.locatorTab = New System.Windows.Forms.TabPage()
        Me.nurLocator = New Locator()
		Me.writeTab = New System.Windows.Forms.TabPage()
        Me.nurWriter = New Writer()
		Me.settingsTab = New System.Windows.Forms.TabPage()
        Me.nurSettings = New Settings()
		Me.nxpTab = New System.Windows.Forms.TabPage()
        Me.nurNxp = New NXP()
		Me.logTab = New System.Windows.Forms.TabPage()
        Me.nurLog = New Log()
		Me.tabControl1.SuspendLayout()
		Me.infoTab.SuspendLayout()
		Me.inventoryTab.SuspendLayout()
		Me.locatorTab.SuspendLayout()
		Me.writeTab.SuspendLayout()
		Me.settingsTab.SuspendLayout()
		Me.nxpTab.SuspendLayout()
		Me.logTab.SuspendLayout()
		Me.SuspendLayout()
		' 
		' tabControl1
		' 
		Me.tabControl1.Controls.Add(Me.infoTab)
		Me.tabControl1.Controls.Add(Me.inventoryTab)
		Me.tabControl1.Controls.Add(Me.locatorTab)
		Me.tabControl1.Controls.Add(Me.writeTab)
		Me.tabControl1.Controls.Add(Me.settingsTab)
		Me.tabControl1.Controls.Add(Me.nxpTab)
		Me.tabControl1.Controls.Add(Me.logTab)
		Me.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.tabControl1.Location = New System.Drawing.Point(0, 0)
		Me.tabControl1.Name = "tabControl1"
		Me.tabControl1.SelectedIndex = 0
		Me.tabControl1.Size = New System.Drawing.Size(638, 455)
		Me.tabControl1.TabIndex = 0
		' 
		' infoTab
		' 
		Me.infoTab.Controls.Add(Me.nurInfo)
		Me.infoTab.Location = New System.Drawing.Point(4, 25)
		Me.infoTab.Name = "infoTab"
		Me.infoTab.Size = New System.Drawing.Size(630, 426)
		Me.infoTab.Text = "Info"
		' 
		' nurInfo
		' 
		Me.nurInfo.Dock = System.Windows.Forms.DockStyle.Fill
		Me.nurInfo.Location = New System.Drawing.Point(0, 0)
		Me.nurInfo.Name = "nurInfo"
		Me.nurInfo.Size = New System.Drawing.Size(630, 426)
		Me.nurInfo.TabIndex = 0
		' 
		' inventoryTab
		' 
		Me.inventoryTab.Controls.Add(Me.nurInventory)
		Me.inventoryTab.Location = New System.Drawing.Point(4, 25)
		Me.inventoryTab.Name = "inventoryTab"
		Me.inventoryTab.Size = New System.Drawing.Size(630, 426)
		Me.inventoryTab.Text = "Inventory"
		' 
		' nurInventory
		' 
		Me.nurInventory.Dock = System.Windows.Forms.DockStyle.Fill
		Me.nurInventory.Location = New System.Drawing.Point(0, 0)
		Me.nurInventory.Name = "nurInventory"
		Me.nurInventory.Size = New System.Drawing.Size(630, 426)
		Me.nurInventory.TabIndex = 0
		' 
		' locatorTab
		' 
		Me.locatorTab.Controls.Add(Me.nurLocator)
		Me.locatorTab.Location = New System.Drawing.Point(4, 25)
		Me.locatorTab.Name = "locatorTab"
		Me.locatorTab.Size = New System.Drawing.Size(630, 426)
		Me.locatorTab.Text = "Locator"
		' 
		' nurLocator
		' 
		Me.nurLocator.Dock = System.Windows.Forms.DockStyle.Fill
		Me.nurLocator.Location = New System.Drawing.Point(0, 0)
		Me.nurLocator.Name = "nurLocator"
		Me.nurLocator.Size = New System.Drawing.Size(630, 426)
		Me.nurLocator.TabIndex = 0
		' 
		' writeTab
		' 
		Me.writeTab.Controls.Add(Me.nurWriter)
		Me.writeTab.Location = New System.Drawing.Point(4, 25)
		Me.writeTab.Name = "writeTab"
		Me.writeTab.Size = New System.Drawing.Size(630, 426)
		Me.writeTab.Text = "Writer"
		' 
		' nurWriter
		' 
		Me.nurWriter.Dock = System.Windows.Forms.DockStyle.Fill
		Me.nurWriter.Location = New System.Drawing.Point(0, 0)
		Me.nurWriter.Name = "nurWriter"
		Me.nurWriter.Size = New System.Drawing.Size(630, 426)
		Me.nurWriter.TabIndex = 0
		' 
		' settingsTab
		' 
		Me.settingsTab.Controls.Add(Me.nurSettings)
		Me.settingsTab.Location = New System.Drawing.Point(4, 25)
		Me.settingsTab.Name = "settingsTab"
		Me.settingsTab.Size = New System.Drawing.Size(630, 426)
		Me.settingsTab.Text = "Settings"
		' 
		' nurSettings
		' 
		Me.nurSettings.Dock = System.Windows.Forms.DockStyle.Fill
		Me.nurSettings.Location = New System.Drawing.Point(0, 0)
		Me.nurSettings.Name = "nurSettings"
		Me.nurSettings.Size = New System.Drawing.Size(630, 426)
		Me.nurSettings.TabIndex = 0
		' 
		' nxpTab
		' 
		Me.nxpTab.Controls.Add(Me.nurNxp)
		Me.nxpTab.Location = New System.Drawing.Point(4, 25)
		Me.nxpTab.Name = "nxpTab"
		Me.nxpTab.Size = New System.Drawing.Size(630, 426)
		Me.nxpTab.Text = "NXP"
		' 
		' nurNxp
		' 
		Me.nurNxp.Dock = System.Windows.Forms.DockStyle.Fill
		Me.nurNxp.Location = New System.Drawing.Point(0, 0)
		Me.nurNxp.Name = "nurNxp"
		Me.nurNxp.Size = New System.Drawing.Size(630, 426)
		Me.nurNxp.TabIndex = 1
		' 
		' logTab
		' 
		Me.logTab.Controls.Add(Me.nurLog)
		Me.logTab.Location = New System.Drawing.Point(4, 25)
		Me.logTab.Name = "logTab"
		Me.logTab.Size = New System.Drawing.Size(630, 426)
		Me.logTab.Text = "Log"
		' 
		' nurLog
		' 
		Me.nurLog.Dock = System.Windows.Forms.DockStyle.Fill
		Me.nurLog.Location = New System.Drawing.Point(0, 0)
		Me.nurLog.Name = "nurLog"
		Me.nurLog.Size = New System.Drawing.Size(630, 426)
		Me.nurLog.TabIndex = 0
		' 
		' Form1
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96F, 96F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.AutoScroll = True
		Me.ClientSize = New System.Drawing.Size(638, 455)
		Me.Controls.Add(Me.tabControl1)
		Me.KeyPreview = True
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "Form1"
		Me.Text = "NurApi C# Sample"
		Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        AddHandler Me.Load, New System.EventHandler(AddressOf Me.Form1_Load)
        AddHandler Me.Closing, New System.ComponentModel.CancelEventHandler(AddressOf Me.Form1_Closing)
        AddHandler Me.KeyDown, New System.Windows.Forms.KeyEventHandler(AddressOf Me.Form1_KeyDown)
		Me.tabControl1.ResumeLayout(False)
		Me.infoTab.ResumeLayout(False)
		Me.inventoryTab.ResumeLayout(False)
		Me.locatorTab.ResumeLayout(False)
		Me.writeTab.ResumeLayout(False)
		Me.settingsTab.ResumeLayout(False)
		Me.nxpTab.ResumeLayout(False)
		Me.logTab.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

	#End Region

	Private tabControl1 As System.Windows.Forms.TabControl
	Private inventoryTab As System.Windows.Forms.TabPage
	Private writeTab As System.Windows.Forms.TabPage
	Private infoTab As System.Windows.Forms.TabPage
	Private locatorTab As System.Windows.Forms.TabPage
	Private nurLocator As Locator
	Private nurWriter As Writer
	Private nurInventory As Inventory
	Private settingsTab As System.Windows.Forms.TabPage
	Private nurSettings As Settings
	Private nxpTab As System.Windows.Forms.TabPage
	Private nurNxp As NXP
	Private logTab As System.Windows.Forms.TabPage
	Private nurLog As Log
	Private nurInfo As Info
End Class

