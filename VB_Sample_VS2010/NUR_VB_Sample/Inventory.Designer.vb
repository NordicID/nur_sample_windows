<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inventory
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inventory))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ButtonClearList = New System.Windows.Forms.Button()
        Me.ButtonPeriodicRead = New System.Windows.Forms.Button()
        Me.ButtonSingleRead = New System.Windows.Forms.Button()
        Me.TagList = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ButtonClearList)
        Me.Panel1.Controls.Add(Me.ButtonPeriodicRead)
        Me.Panel1.Controls.Add(Me.ButtonSingleRead)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(508, 72)
        Me.Panel1.TabIndex = 0
        '
        'ButtonClearList
        '
        Me.ButtonClearList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonClearList.Location = New System.Drawing.Point(409, 41)
        Me.ButtonClearList.Name = "ButtonClearList"
        Me.ButtonClearList.Size = New System.Drawing.Size(96, 23)
        Me.ButtonClearList.TabIndex = 6
        Me.ButtonClearList.Text = "Clear"
        Me.ButtonClearList.UseVisualStyleBackColor = True
        '
        'ButtonPeriodicRead
        '
        Me.ButtonPeriodicRead.Location = New System.Drawing.Point(12, 41)
        Me.ButtonPeriodicRead.Name = "ButtonPeriodicRead"
        Me.ButtonPeriodicRead.Size = New System.Drawing.Size(108, 23)
        Me.ButtonPeriodicRead.TabIndex = 5
        Me.ButtonPeriodicRead.Text = "Periodic Read"
        Me.ButtonPeriodicRead.UseVisualStyleBackColor = True
        '
        'ButtonSingleRead
        '
        Me.ButtonSingleRead.Location = New System.Drawing.Point(12, 12)
        Me.ButtonSingleRead.Name = "ButtonSingleRead"
        Me.ButtonSingleRead.Size = New System.Drawing.Size(108, 23)
        Me.ButtonSingleRead.TabIndex = 4
        Me.ButtonSingleRead.Text = "Single Read"
        Me.ButtonSingleRead.UseVisualStyleBackColor = True
        '
        'TagList
        '
        Me.TagList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.TagList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TagList.FullRowSelect = True
        Me.TagList.Location = New System.Drawing.Point(0, 72)
        Me.TagList.Name = "TagList"
        Me.TagList.Size = New System.Drawing.Size(508, 326)
        Me.TagList.SmallImageList = Me.ImageList1
        Me.TagList.TabIndex = 1
        Me.TagList.UseCompatibleStateImageBehavior = False
        Me.TagList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Tag"
        Me.ColumnHeader1.Width = 40
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "EPC"
        Me.ColumnHeader2.Width = 170
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "PC"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Timestamp"
        Me.ColumnHeader4.Width = 70
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "RSSI"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "smallTagOrange.png")
        '
        'Inventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TagList)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Inventory"
        Me.Size = New System.Drawing.Size(508, 398)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonPeriodicRead As System.Windows.Forms.Button
    Friend WithEvents ButtonSingleRead As System.Windows.Forms.Button
    Friend WithEvents ButtonClearList As System.Windows.Forms.Button
    Friend WithEvents TagList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList

End Class
