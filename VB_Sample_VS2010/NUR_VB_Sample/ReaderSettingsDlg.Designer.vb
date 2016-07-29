<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReaderSettingsDlg
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ComboRegion = New System.Windows.Forms.ComboBox()
        Me.ComboLinkFrequency = New System.Windows.Forms.ComboBox()
        Me.ComboTxLevel = New System.Windows.Forms.ComboBox()
        Me.ComboTxModulation = New System.Windows.Forms.ComboBox()
        Me.ComboRxDecoding = New System.Windows.Forms.ComboBox()
        Me.ComboQ = New System.Windows.Forms.ComboBox()
        Me.ComboRounds = New System.Windows.Forms.ComboBox()
        Me.ComboSession = New System.Windows.Forms.ComboBox()
        Me.ButtonLoad = New System.Windows.Forms.Button()
        Me.ButtonSave = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(350, 293)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(170, 33)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(78, 27)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(88, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(78, 27)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Region"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(171, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Link Frequency (Hz)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Tx Modulation"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(330, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 15)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Tx Level"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(171, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 15)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Rx Decoding"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(330, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(16, 15)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Q"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 15)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Rounds"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(171, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 15)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Session"
        '
        'ComboRegion
        '
        Me.ComboRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboRegion.FormattingEnabled = True
        Me.ComboRegion.Items.AddRange(New Object() {"Europe", "FCC (North-America) ", "PRC (China) ", "Malaysia ", "Brazil ", "Australia ", "New Zealand", "Japan 250 mW LBT", "Japan 500 mW DRM", "Korea LBT", "India", "Russia", "Vietnam", "Singapore", "Thailand", "Philippines"})
        Me.ComboRegion.Location = New System.Drawing.Point(18, 53)
        Me.ComboRegion.Name = "ComboRegion"
        Me.ComboRegion.Size = New System.Drawing.Size(136, 23)
        Me.ComboRegion.TabIndex = 9
        '
        'ComboLinkFrequency
        '
        Me.ComboLinkFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboLinkFrequency.FormattingEnabled = True
        Me.ComboLinkFrequency.Items.AddRange(New Object() {"160000", "256000", "320000"})
        Me.ComboLinkFrequency.Location = New System.Drawing.Point(175, 53)
        Me.ComboLinkFrequency.Name = "ComboLinkFrequency"
        Me.ComboLinkFrequency.Size = New System.Drawing.Size(136, 23)
        Me.ComboLinkFrequency.TabIndex = 10
        '
        'ComboTxLevel
        '
        Me.ComboTxLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboTxLevel.FormattingEnabled = True
        Me.ComboTxLevel.Items.AddRange(New Object() {"27 dBm, 500mW ", "26 dBm, 398mW ", "25 dBm, 316mW ", "24 dBm, 251mW ", "23 dBm, 200mW ", "22 dBm, 158mW ", "21 dBm, 126mW ", "20 dBm, 100mW ", "19 dBm, 79mW ", "18 dBm, 63mW ", "17 dBm, 50mW ", "16 dBm, 40mW ", "15 dBm, 32mW ", "14 dBm, 25mW ", "13 dBm, 20mW ", "12 dBm, 16mW ", "11 dBm, 13mW ", "10 dBm, 10mW ", "9 dBm, 8mW ", "8 dBm, 6mW"})
        Me.ComboTxLevel.Location = New System.Drawing.Point(333, 53)
        Me.ComboTxLevel.Name = "ComboTxLevel"
        Me.ComboTxLevel.Size = New System.Drawing.Size(136, 23)
        Me.ComboTxLevel.TabIndex = 11
        '
        'ComboTxModulation
        '
        Me.ComboTxModulation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboTxModulation.FormattingEnabled = True
        Me.ComboTxModulation.Items.AddRange(New Object() {"ASK ", "PR-ASK "})
        Me.ComboTxModulation.Location = New System.Drawing.Point(18, 108)
        Me.ComboTxModulation.Name = "ComboTxModulation"
        Me.ComboTxModulation.Size = New System.Drawing.Size(136, 23)
        Me.ComboTxModulation.TabIndex = 12
        '
        'ComboRxDecoding
        '
        Me.ComboRxDecoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboRxDecoding.FormattingEnabled = True
        Me.ComboRxDecoding.Items.AddRange(New Object() {"FM-0", "Miller-2", "Miller-4", "Miller-8"})
        Me.ComboRxDecoding.Location = New System.Drawing.Point(175, 108)
        Me.ComboRxDecoding.Name = "ComboRxDecoding"
        Me.ComboRxDecoding.Size = New System.Drawing.Size(136, 23)
        Me.ComboRxDecoding.TabIndex = 13
        '
        'ComboQ
        '
        Me.ComboQ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboQ.FormattingEnabled = True
        Me.ComboQ.Items.AddRange(New Object() {"AUTO", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15"})
        Me.ComboQ.Location = New System.Drawing.Point(333, 45)
        Me.ComboQ.Name = "ComboQ"
        Me.ComboQ.Size = New System.Drawing.Size(136, 23)
        Me.ComboQ.TabIndex = 14
        '
        'ComboRounds
        '
        Me.ComboRounds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboRounds.FormattingEnabled = True
        Me.ComboRounds.Items.AddRange(New Object() {"AUTO", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.ComboRounds.Location = New System.Drawing.Point(18, 45)
        Me.ComboRounds.Name = "ComboRounds"
        Me.ComboRounds.Size = New System.Drawing.Size(136, 23)
        Me.ComboRounds.TabIndex = 15
        '
        'ComboSession
        '
        Me.ComboSession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboSession.FormattingEnabled = True
        Me.ComboSession.Items.AddRange(New Object() {"0", "1", "2", "3"})
        Me.ComboSession.Location = New System.Drawing.Point(175, 45)
        Me.ComboSession.Name = "ComboSession"
        Me.ComboSession.Size = New System.Drawing.Size(136, 23)
        Me.ComboSession.TabIndex = 16
        '
        'ButtonLoad
        '
        Me.ButtonLoad.Location = New System.Drawing.Point(17, 294)
        Me.ButtonLoad.Name = "ButtonLoad"
        Me.ButtonLoad.Size = New System.Drawing.Size(117, 27)
        Me.ButtonLoad.TabIndex = 17
        Me.ButtonLoad.Text = "Load settings..."
        Me.ButtonLoad.UseVisualStyleBackColor = True
        '
        'ButtonSave
        '
        Me.ButtonSave.Location = New System.Drawing.Point(191, 294)
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(117, 27)
        Me.ButtonSave.TabIndex = 18
        Me.ButtonSave.Text = "Save settings..."
        Me.ButtonSave.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Info
        Me.GroupBox2.Controls.Add(Me.ComboQ)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.ComboSession)
        Me.GroupBox2.Controls.Add(Me.ComboRounds)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 173)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(572, 91)
        Me.GroupBox2.TabIndex = 24
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Inventory settings"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.GroupBox3.Controls.Add(Me.ComboLinkFrequency)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.ComboRxDecoding)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.ComboTxModulation)
        Me.GroupBox3.Controls.Add(Me.ComboRegion)
        Me.GroupBox3.Controls.Add(Me.ComboTxLevel)
        Me.GroupBox3.Location = New System.Drawing.Point(17, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(572, 155)
        Me.GroupBox3.TabIndex = 25
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Module settings"
        '
        'ReaderSettingsDlg
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(607, 338)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ButtonSave)
        Me.Controls.Add(Me.ButtonLoad)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReaderSettingsDlg"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ComboRegion As System.Windows.Forms.ComboBox
    Friend WithEvents ComboLinkFrequency As System.Windows.Forms.ComboBox
    Friend WithEvents ComboTxLevel As System.Windows.Forms.ComboBox
    Friend WithEvents ComboTxModulation As System.Windows.Forms.ComboBox
    Friend WithEvents ComboRxDecoding As System.Windows.Forms.ComboBox
    Friend WithEvents ComboQ As System.Windows.Forms.ComboBox
    Friend WithEvents ComboRounds As System.Windows.Forms.ComboBox
    Friend WithEvents ComboSession As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonLoad As System.Windows.Forms.Button
    Friend WithEvents ButtonSave As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox

End Class
