Partial Class NXP_ProductStatusFlag
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
		Me.targetEpcTextBox = New System.Windows.Forms.TextBox()
		Me.label1 = New System.Windows.Forms.Label()
		Me.label3 = New System.Windows.Forms.Label()
		Me.setBtn = New System.Windows.Forms.Button()
		Me.psfInventoryButton = New System.Windows.Forms.Button()
		Me.configurationLabel = New System.Windows.Forms.Label()
        Me.nxpTagListView = New NurTagListView()
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
		Me.refreshBtn.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.refreshBtn.Location = New System.Drawing.Point(127, 3)
		Me.refreshBtn.Name = "refreshBtn"
		Me.refreshBtn.Size = New System.Drawing.Size(110, 23)
		Me.refreshBtn.TabIndex = 21
		Me.refreshBtn.Text = "List Tags"
		AddHandler Me.refreshBtn.Click, New System.EventHandler(AddressOf Me.refreshBtn_Click)
		' 
		' targetEpcTextBox
		' 
		Me.targetEpcTextBox.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.targetEpcTextBox.Location = New System.Drawing.Point(3, 136)
		Me.targetEpcTextBox.Name = "targetEpcTextBox"
		Me.targetEpcTextBox.Size = New System.Drawing.Size(173, 23)
		Me.targetEpcTextBox.TabIndex = 19
		Me.targetEpcTextBox.Text = "Scan some tags for Tag list"
		' 
		' label1
		' 
		Me.label1.Location = New System.Drawing.Point(3, 6)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(110, 20)
		Me.label1.Text = "1) Select a Tag"
		' 
		' label3
		' 
		Me.label3.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.label3.Location = New System.Drawing.Point(3, 162)
		Me.label3.Name = "label3"
		Me.label3.Size = New System.Drawing.Size(234, 20)
		Me.label3.Text = "2) Toggle PSF bit, 3) Start Inventory"
		' 
		' setBtn
		' 
		Me.setBtn.Location = New System.Drawing.Point(3, 185)
		Me.setBtn.Name = "setBtn"
		Me.setBtn.Size = New System.Drawing.Size(110, 23)
		Me.setBtn.TabIndex = 28
		Me.setBtn.Text = "Toggle PSF"
		AddHandler Me.setBtn.Click, New System.EventHandler(AddressOf Me.setBtn_Click)
		' 
		' psfInventoryButton
		' 
		Me.psfInventoryButton.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.psfInventoryButton.Location = New System.Drawing.Point(127, 185)
		Me.psfInventoryButton.Name = "psfInventoryButton"
		Me.psfInventoryButton.Size = New System.Drawing.Size(110, 23)
		Me.psfInventoryButton.TabIndex = 33
		Me.psfInventoryButton.Text = "Start PSF stream"
		AddHandler Me.psfInventoryButton.Click, New System.EventHandler(AddressOf Me.psfInventoryButton_Click)
		' 
		' configurationLabel
		' 
		Me.configurationLabel.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.configurationLabel.Location = New System.Drawing.Point(182, 139)
		Me.configurationLabel.Name = "configurationLabel"
		Me.configurationLabel.Size = New System.Drawing.Size(55, 20)
		Me.configurationLabel.Text = "- - -"
		Me.configurationLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
		' 
		' nxpTagListView
		' 
		Me.nxpTagListView.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.nxpTagListView.Location = New System.Drawing.Point(3, 32)
		Me.nxpTagListView.Name = "nxpTagListView"
		Me.nxpTagListView.Size = New System.Drawing.Size(234, 98)
		Me.nxpTagListView.TabIndex = 22
		AddHandler Me.nxpTagListView.Click, New System.EventHandler(AddressOf Me.nxpTagListView_SelectedTagChanged)
		AddHandler Me.nxpTagListView.SelectedTagChanged, New System.EventHandler(AddressOf Me.nxpTagListView_SelectedTagChanged)
		' 
		' NXP_ProductStatusFlag
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96F, 96F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.Controls.Add(Me.configurationLabel)
		Me.Controls.Add(Me.psfInventoryButton)
		Me.Controls.Add(Me.setBtn)
		Me.Controls.Add(Me.label3)
		Me.Controls.Add(Me.nxpTagListView)
		Me.Controls.Add(Me.refreshBtn)
		Me.Controls.Add(Me.targetEpcTextBox)
		Me.Controls.Add(Me.label1)
		Me.Name = "NXP_ProductStatusFlag"
		Me.Size = New System.Drawing.Size(240, 320)
		Me.ResumeLayout(False)

	End Sub

	#End Region

	Private nxpTagListView As NurTagListView
	Private epcHeader As System.Windows.Forms.ColumnHeader
	Private rssiHeader As System.Windows.Forms.ColumnHeader
	Private refreshBtn As System.Windows.Forms.Button
	Private targetEpcTextBox As System.Windows.Forms.TextBox
	Private label1 As System.Windows.Forms.Label
	Private label3 As System.Windows.Forms.Label
	Private setBtn As System.Windows.Forms.Button
	Private psfInventoryButton As System.Windows.Forms.Button
	Private configurationLabel As System.Windows.Forms.Label
End Class
