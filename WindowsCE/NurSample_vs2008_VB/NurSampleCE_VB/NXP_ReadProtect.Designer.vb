Partial Class NXP_ReadProtect
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
		Me.nxpTagListView = New NurTagListView()
		Me.epcHeader = New System.Windows.Forms.ColumnHeader()
		Me.rssiHeader = New System.Windows.Forms.ColumnHeader()
		Me.refreshBtn = New System.Windows.Forms.Button()
		Me.targetEpcTextBox = New System.Windows.Forms.TextBox()
		Me.label2 = New System.Windows.Forms.Label()
		Me.label1 = New System.Windows.Forms.Label()
		Me.accessPasswordTextBox = New System.Windows.Forms.TextBox()
		Me.label3 = New System.Windows.Forms.Label()
		Me.setBtn = New System.Windows.Forms.Button()
		Me.resetBtn = New System.Windows.Forms.Button()
		Me.SuspendLayout()
		' 
		' nxpTagListView
		' 
		Me.nxpTagListView.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.nxpTagListView.Location = New System.Drawing.Point(3, 24)
		Me.nxpTagListView.Name = "nxpTagListView"
		Me.nxpTagListView.Size = New System.Drawing.Size(234, 98)
		Me.nxpTagListView.TabIndex = 22
		AddHandler Me.nxpTagListView.SelectedTagChanged, New System.EventHandler(AddressOf Me.nxpTagListView_SelectedTagChanged)
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
		Me.refreshBtn.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.refreshBtn.Location = New System.Drawing.Point(165, 1)
		Me.refreshBtn.Name = "refreshBtn"
		Me.refreshBtn.Size = New System.Drawing.Size(72, 20)
		Me.refreshBtn.TabIndex = 21
		Me.refreshBtn.Text = "Refresh"
		AddHandler Me.refreshBtn.Click, New System.EventHandler(AddressOf Me.refreshBtn_Click)
		' 
		' targetEpcTextBox
		' 
		Me.targetEpcTextBox.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.targetEpcTextBox.Location = New System.Drawing.Point(3, 154)
		Me.targetEpcTextBox.Name = "targetEpcTextBox"
		Me.targetEpcTextBox.Size = New System.Drawing.Size(234, 23)
		Me.targetEpcTextBox.TabIndex = 19
		Me.targetEpcTextBox.Text = "Scan some tags for Tag list"
		' 
		' label2
		' 
		Me.label2.Location = New System.Drawing.Point(3, 128)
		Me.label2.Name = "label2"
		Me.label2.Size = New System.Drawing.Size(156, 20)
		Me.label2.Text = "2) Enter AccPwd (Hex)"
		' 
		' label1
		' 
		Me.label1.Location = New System.Drawing.Point(3, 1)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(224, 20)
		Me.label1.Text = "1) Select Tag from List"
		' 
		' accessPasswordTextBox
		' 
		Me.accessPasswordTextBox.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.accessPasswordTextBox.Location = New System.Drawing.Point(165, 127)
		Me.accessPasswordTextBox.Name = "accessPasswordTextBox"
		Me.accessPasswordTextBox.Size = New System.Drawing.Size(72, 23)
		Me.accessPasswordTextBox.TabIndex = 25
		Me.accessPasswordTextBox.Text = "acc password"
		' 
		' label3
		' 
		Me.label3.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.label3.Location = New System.Drawing.Point(3, 180)
		Me.label3.Name = "label3"
		Me.label3.Size = New System.Drawing.Size(234, 20)
		Me.label3.Text = "3) Set / Reset NXP Read Protection"
		' 
		' setBtn
		' 
		Me.setBtn.Location = New System.Drawing.Point(3, 203)
		Me.setBtn.Name = "setBtn"
		Me.setBtn.Size = New System.Drawing.Size(110, 23)
		Me.setBtn.TabIndex = 28
		Me.setBtn.Text = "SET"
		AddHandler Me.setBtn.Click, New System.EventHandler(AddressOf Me.setBtn_Click)
		' 
		' resetBtn
		' 
		Me.resetBtn.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.resetBtn.Location = New System.Drawing.Point(127, 203)
		Me.resetBtn.Name = "resetBtn"
		Me.resetBtn.Size = New System.Drawing.Size(110, 23)
		Me.resetBtn.TabIndex = 29
		Me.resetBtn.Text = "RESET"
		AddHandler Me.resetBtn.Click, New System.EventHandler(AddressOf Me.resetBtn_Click)
		' 
		' NXP_ReadProtect
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96F, 96F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.Controls.Add(Me.resetBtn)
		Me.Controls.Add(Me.setBtn)
		Me.Controls.Add(Me.label3)
		Me.Controls.Add(Me.accessPasswordTextBox)
		Me.Controls.Add(Me.nxpTagListView)
		Me.Controls.Add(Me.refreshBtn)
		Me.Controls.Add(Me.targetEpcTextBox)
		Me.Controls.Add(Me.label2)
		Me.Controls.Add(Me.label1)
		Me.Name = "NXP_ReadProtect"
		Me.Size = New System.Drawing.Size(240, 320)
		Me.ResumeLayout(False)

	End Sub

	#End Region

	Private nxpTagListView As NurTagListView
	Private epcHeader As System.Windows.Forms.ColumnHeader
	Private rssiHeader As System.Windows.Forms.ColumnHeader
	Private refreshBtn As System.Windows.Forms.Button
	Private targetEpcTextBox As System.Windows.Forms.TextBox
	Private label2 As System.Windows.Forms.Label
	Private label1 As System.Windows.Forms.Label
	Private accessPasswordTextBox As System.Windows.Forms.TextBox
	Private label3 As System.Windows.Forms.Label
	Private setBtn As System.Windows.Forms.Button
	Private resetBtn As System.Windows.Forms.Button
End Class
