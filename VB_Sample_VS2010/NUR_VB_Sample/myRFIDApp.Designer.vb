<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class myRFIDApp
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LabelAntennaCount = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(189, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Develop your own RFID app UI here..."
        '
        'LabelAntennaCount
        '
        Me.LabelAntennaCount.AutoSize = True
        Me.LabelAntennaCount.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAntennaCount.Location = New System.Drawing.Point(23, 20)
        Me.LabelAntennaCount.Name = "LabelAntennaCount"
        Me.LabelAntennaCount.Size = New System.Drawing.Size(211, 20)
        Me.LabelAntennaCount.TabIndex = 1
        Me.LabelAntennaCount.Text = "Click me for counting antennas.."
        '
        'myRFIDApp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelAntennaCount)
        Me.Controls.Add(Me.Label1)
        Me.Name = "myRFIDApp"
        Me.Size = New System.Drawing.Size(388, 150)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LabelAntennaCount As System.Windows.Forms.Label

End Class
