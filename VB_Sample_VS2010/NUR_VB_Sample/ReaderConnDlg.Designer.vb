<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReaderConnDlg
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.RadioTCPIP = New System.Windows.Forms.RadioButton()
        Me.EditIP = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EditPort = New System.Windows.Forms.TextBox()
        Me.RadioCOM = New System.Windows.Forms.RadioButton()
        Me.ComboCOM = New System.Windows.Forms.ComboBox()
        Me.RadioUSBAutoConnect = New System.Windows.Forms.RadioButton()
        Me.ButConnect = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBaudrate = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'RadioTCPIP
        '
        Me.RadioTCPIP.AutoSize = True
        Me.RadioTCPIP.Location = New System.Drawing.Point(8, 70)
        Me.RadioTCPIP.Name = "RadioTCPIP"
        Me.RadioTCPIP.Size = New System.Drawing.Size(87, 17)
        Me.RadioTCPIP.TabIndex = 1
        Me.RadioTCPIP.Text = "TCP/IP host:"
        Me.RadioTCPIP.UseVisualStyleBackColor = True
        '
        'EditIP
        '
        Me.EditIP.Location = New System.Drawing.Point(99, 69)
        Me.EditIP.Name = "EditIP"
        Me.EditIP.Size = New System.Drawing.Size(100, 20)
        Me.EditIP.TabIndex = 2
        Me.EditIP.Text = "127.0.0.1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(203, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Port:"
        '
        'EditPort
        '
        Me.EditPort.Location = New System.Drawing.Point(237, 69)
        Me.EditPort.Name = "EditPort"
        Me.EditPort.Size = New System.Drawing.Size(39, 20)
        Me.EditPort.TabIndex = 4
        Me.EditPort.Text = "2007"
        '
        'RadioCOM
        '
        Me.RadioCOM.AutoSize = True
        Me.RadioCOM.Location = New System.Drawing.Point(7, 41)
        Me.RadioCOM.Name = "RadioCOM"
        Me.RadioCOM.Size = New System.Drawing.Size(73, 17)
        Me.RadioCOM.TabIndex = 5
        Me.RadioCOM.Text = "COM port:"
        Me.RadioCOM.UseVisualStyleBackColor = True
        '
        'ComboCOM
        '
        Me.ComboCOM.FormattingEnabled = True
        Me.ComboCOM.Location = New System.Drawing.Point(98, 42)
        Me.ComboCOM.Name = "ComboCOM"
        Me.ComboCOM.Size = New System.Drawing.Size(178, 21)
        Me.ComboCOM.TabIndex = 7
        '
        'RadioUSBAutoConnect
        '
        Me.RadioUSBAutoConnect.AutoSize = True
        Me.RadioUSBAutoConnect.Checked = True
        Me.RadioUSBAutoConnect.Location = New System.Drawing.Point(7, 12)
        Me.RadioUSBAutoConnect.Name = "RadioUSBAutoConnect"
        Me.RadioUSBAutoConnect.Size = New System.Drawing.Size(115, 17)
        Me.RadioUSBAutoConnect.TabIndex = 6
        Me.RadioUSBAutoConnect.TabStop = True
        Me.RadioUSBAutoConnect.Text = "USB Auto Connect"
        Me.RadioUSBAutoConnect.UseVisualStyleBackColor = True
        '
        'ButConnect
        '
        Me.ButConnect.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ButConnect.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButConnect.Location = New System.Drawing.Point(7, 117)
        Me.ButConnect.Name = "ButConnect"
        Me.ButConnect.Size = New System.Drawing.Size(99, 23)
        Me.ButConnect.TabIndex = 8
        Me.ButConnect.Text = "Connect"
        Me.ButConnect.UseVisualStyleBackColor = True
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(338, 117)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(282, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Baudrate:"
        '
        'ComboBaudrate
        '
        Me.ComboBaudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBaudrate.FormattingEnabled = True
        Me.ComboBaudrate.Items.AddRange(New Object() {"38400", "115200"})
        Me.ComboBaudrate.Location = New System.Drawing.Point(335, 42)
        Me.ComboBaudrate.Name = "ComboBaudrate"
        Me.ComboBaudrate.Size = New System.Drawing.Size(70, 21)
        Me.ComboBaudrate.TabIndex = 10
        '
        'ReaderConnDlg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(414, 149)
        Me.Controls.Add(Me.ComboBaudrate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.ButConnect)
        Me.Controls.Add(Me.EditPort)
        Me.Controls.Add(Me.RadioTCPIP)
        Me.Controls.Add(Me.ComboCOM)
        Me.Controls.Add(Me.EditIP)
        Me.Controls.Add(Me.RadioCOM)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RadioUSBAutoConnect)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReaderConnDlg"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "RFID Reader Connection"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RadioTCPIP As System.Windows.Forms.RadioButton
    Friend WithEvents EditIP As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents EditPort As System.Windows.Forms.TextBox
    Friend WithEvents RadioCOM As System.Windows.Forms.RadioButton
    Friend WithEvents ComboCOM As System.Windows.Forms.ComboBox
    Friend WithEvents RadioUSBAutoConnect As System.Windows.Forms.RadioButton
    Friend WithEvents ButConnect As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBaudrate As System.Windows.Forms.ComboBox

End Class
