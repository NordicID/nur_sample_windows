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
		Me.components = New System.ComponentModel.Container()
		Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Info))
		Me.tabControl1 = New System.Windows.Forms.TabControl()
		Me.tabPage1 = New System.Windows.Forms.TabPage()
		Me.saveInfoToXml_Button = New System.Windows.Forms.Button()
		Me.treeView1 = New System.Windows.Forms.TreeView()
		Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
		Me.saveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
		Me.tabControl1.SuspendLayout()
		Me.tabPage1.SuspendLayout()
		Me.SuspendLayout()
		' 
		' tabControl1
		' 
		Me.tabControl1.Controls.Add(Me.tabPage1)
		Me.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.tabControl1.ImageList = Me.imageList1
		Me.tabControl1.Location = New System.Drawing.Point(0, 0)
		Me.tabControl1.Name = "tabControl1"
		Me.tabControl1.SelectedIndex = 0
		Me.tabControl1.Size = New System.Drawing.Size(340, 332)
		Me.tabControl1.TabIndex = 5
		AddHandler Me.tabControl1.Click, New System.EventHandler(AddressOf Me.tabControl1_Click)
		' 
		' tabPage1
		' 
		Me.tabPage1.Controls.Add(Me.saveInfoToXml_Button)
		Me.tabPage1.Controls.Add(Me.treeView1)
		Me.tabPage1.ImageIndex = 0
		Me.tabPage1.Location = New System.Drawing.Point(4, 23)
		Me.tabPage1.Name = "tabPage1"
		Me.tabPage1.Padding = New System.Windows.Forms.Padding(3)
		Me.tabPage1.Size = New System.Drawing.Size(332, 305)
		Me.tabPage1.TabIndex = 0
		Me.tabPage1.Text = "tabPage1"
		Me.tabPage1.UseVisualStyleBackColor = True
		' 
		' saveInfoToXml_Button
		' 
		Me.saveInfoToXml_Button.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.saveInfoToXml_Button.Location = New System.Drawing.Point(3, 279)
		Me.saveInfoToXml_Button.Name = "saveInfoToXml_Button"
		Me.saveInfoToXml_Button.Size = New System.Drawing.Size(326, 23)
		Me.saveInfoToXml_Button.TabIndex = 6
		Me.saveInfoToXml_Button.Text = "Save info to XML"
		Me.saveInfoToXml_Button.UseVisualStyleBackColor = True
		AddHandler Me.saveInfoToXml_Button.Click, New System.EventHandler(AddressOf Me.saveInfoToXml_Button_Click)
		' 
		' treeView1
		' 
		Me.treeView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.treeView1.Location = New System.Drawing.Point(3, 3)
		Me.treeView1.Name = "treeView1"
		Me.treeView1.Size = New System.Drawing.Size(326, 270)
		Me.treeView1.TabIndex = 5
		' 
		' imageList1
		' 
		Me.imageList1.ImageStream = DirectCast(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
		Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
		Me.imageList1.Images.SetKeyName(0, "Refresh-icon.png")
		' 
		' saveFileDialog1
		' 
		Me.saveFileDialog1.Filter = "XML Files (*.xml)|*.xml"
		' 
		' Info
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.tabControl1)
		Me.Name = "Info"
		Me.Size = New System.Drawing.Size(340, 332)
		Me.tabControl1.ResumeLayout(False)
		Me.tabPage1.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

	#End Region

	Private tabControl1 As System.Windows.Forms.TabControl
	Private tabPage1 As System.Windows.Forms.TabPage
	Private treeView1 As System.Windows.Forms.TreeView
	Private imageList1 As System.Windows.Forms.ImageList
	Private saveInfoToXml_Button As System.Windows.Forms.Button
	Private saveFileDialog1 As System.Windows.Forms.SaveFileDialog

End Class
