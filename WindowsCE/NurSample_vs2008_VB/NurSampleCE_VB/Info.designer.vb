Partial Class Info
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
		Me.treeView1 = New System.Windows.Forms.TreeView()
		Me.label1 = New System.Windows.Forms.Label()
		Me.refreshButton = New System.Windows.Forms.Button()
		Me.saveToXml_Button = New System.Windows.Forms.Button()
		Me.saveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
		Me.SuspendLayout()
		' 
		' treeView1
		' 
		Me.treeView1.Anchor = DirectCast((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.treeView1.Location = New System.Drawing.Point(0, 30)
		Me.treeView1.Name = "treeView1"
		Me.treeView1.Size = New System.Drawing.Size(230, 228)
		Me.treeView1.TabIndex = 0
		' 
		' label1
		' 
		Me.label1.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.label1.Font = New System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold)
		Me.label1.Location = New System.Drawing.Point(3, 7)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(198, 20)
		Me.label1.Text = "label1"
		' 
		' refreshButton
		' 
		Me.refreshButton.Location = New System.Drawing.Point(207, 5)
		Me.refreshButton.Name = "refreshButton"
		Me.refreshButton.Size = New System.Drawing.Size(20, 20)
		Me.refreshButton.TabIndex = 3
		Me.refreshButton.Text = "R"
        AddHandler Me.refreshButton.Click, New System.EventHandler(AddressOf Me.refreshButton_Click)
		' 
		' saveToXml_Button
		' 
		Me.saveToXml_Button.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.saveToXml_Button.Location = New System.Drawing.Point(3, 264)
		Me.saveToXml_Button.Name = "saveToXml_Button"
		Me.saveToXml_Button.Size = New System.Drawing.Size(224, 20)
		Me.saveToXml_Button.TabIndex = 5
		Me.saveToXml_Button.Text = "Save to XML file"
        AddHandler Me.saveToXml_Button.Click, New System.EventHandler(AddressOf Me.saveToXml_Button_Click)
		' 
		' saveFileDialog1
		' 
		Me.saveFileDialog1.Filter = "XML Files (*.xml)|*.xml"
		' 
		' Info
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96F, 96F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.Controls.Add(Me.saveToXml_Button)
		Me.Controls.Add(Me.refreshButton)
		Me.Controls.Add(Me.label1)
		Me.Controls.Add(Me.treeView1)
		Me.Name = "Info"
		Me.Size = New System.Drawing.Size(230, 287)
		Me.ResumeLayout(False)

	End Sub

	#End Region

	Private treeView1 As System.Windows.Forms.TreeView
	Private label1 As System.Windows.Forms.Label
	Private refreshButton As System.Windows.Forms.Button
	Private saveToXml_Button As System.Windows.Forms.Button
	Private saveFileDialog1 As System.Windows.Forms.SaveFileDialog

End Class
