Partial Class NXP
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
		Me.tabPSF = New System.Windows.Forms.TabPage()
        Me.nxpProductStatusFlag = New NXP_ProductStatusFlag()
		Me.tabEAS = New System.Windows.Forms.TabPage()
        Me.nxpEasAlarm = New NXP_EasAlarm()
		Me.tabReadProtect = New System.Windows.Forms.TabPage()
        Me.nxpReadProtect = New NXP_ReadProtect()
		Me.tabControl1.SuspendLayout()
		Me.tabPSF.SuspendLayout()
		Me.tabEAS.SuspendLayout()
		Me.tabReadProtect.SuspendLayout()
		Me.SuspendLayout()
		' 
		' tabControl1
		' 
		Me.tabControl1.Controls.Add(Me.tabPSF)
		Me.tabControl1.Controls.Add(Me.tabEAS)
		Me.tabControl1.Controls.Add(Me.tabReadProtect)
		Me.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.tabControl1.Location = New System.Drawing.Point(0, 0)
		Me.tabControl1.Name = "tabControl1"
		Me.tabControl1.SelectedIndex = 0
		Me.tabControl1.Size = New System.Drawing.Size(240, 320)
		Me.tabControl1.TabIndex = 0
		' 
		' tabPSF
		' 
		Me.tabPSF.Controls.Add(Me.nxpProductStatusFlag)
		Me.tabPSF.Location = New System.Drawing.Point(4, 25)
		Me.tabPSF.Name = "tabPSF"
		Me.tabPSF.Size = New System.Drawing.Size(232, 291)
		Me.tabPSF.Text = "PSF"
		' 
		' nxpProductStatusFlag
		' 
		Me.nxpProductStatusFlag.Dock = System.Windows.Forms.DockStyle.Fill
		Me.nxpProductStatusFlag.Location = New System.Drawing.Point(0, 0)
		Me.nxpProductStatusFlag.Name = "nxpProductStatusFlag"
		Me.nxpProductStatusFlag.Size = New System.Drawing.Size(232, 291)
		Me.nxpProductStatusFlag.TabIndex = 0
		' 
		' tabEAS
		' 
		Me.tabEAS.Controls.Add(Me.nxpEasAlarm)
		Me.tabEAS.Location = New System.Drawing.Point(4, 25)
		Me.tabEAS.Name = "tabEAS"
		Me.tabEAS.Size = New System.Drawing.Size(232, 291)
		Me.tabEAS.Text = "EAS"
		' 
		' nxpEasAlarm
		' 
		Me.nxpEasAlarm.Dock = System.Windows.Forms.DockStyle.Fill
		Me.nxpEasAlarm.Location = New System.Drawing.Point(0, 0)
		Me.nxpEasAlarm.Name = "nxpEasAlarm"
		Me.nxpEasAlarm.Size = New System.Drawing.Size(232, 291)
		Me.nxpEasAlarm.TabIndex = 0
		' 
		' tabReadProtect
		' 
		Me.tabReadProtect.Controls.Add(Me.nxpReadProtect)
		Me.tabReadProtect.Location = New System.Drawing.Point(4, 25)
		Me.tabReadProtect.Name = "tabReadProtect"
		Me.tabReadProtect.Size = New System.Drawing.Size(232, 291)
		Me.tabReadProtect.Text = "ReadProtect"
		' 
		' nxpReadProtect
		' 
		Me.nxpReadProtect.Dock = System.Windows.Forms.DockStyle.Fill
		Me.nxpReadProtect.Location = New System.Drawing.Point(0, 0)
		Me.nxpReadProtect.Name = "nxpReadProtect"
		Me.nxpReadProtect.Size = New System.Drawing.Size(232, 291)
		Me.nxpReadProtect.TabIndex = 0
		' 
		' NXP
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96F, 96F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.Controls.Add(Me.tabControl1)
		Me.Name = "NXP"
		Me.Size = New System.Drawing.Size(240, 320)
		Me.tabControl1.ResumeLayout(False)
		Me.tabPSF.ResumeLayout(False)
		Me.tabEAS.ResumeLayout(False)
		Me.tabReadProtect.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

	#End Region

	Private tabControl1 As System.Windows.Forms.TabControl
	Private tabEAS As System.Windows.Forms.TabPage
	Private nxpEasAlarm As NXP_EasAlarm
	Private tabReadProtect As System.Windows.Forms.TabPage
	Private nxpReadProtect As NXP_ReadProtect
	Private tabPSF As System.Windows.Forms.TabPage
	Private nxpProductStatusFlag As NXP_ProductStatusFlag

End Class
