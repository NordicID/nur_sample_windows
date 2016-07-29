Imports System.IO
Imports System.Net
Imports System.Text
Imports NurApiDotNet


Public Class Form1

    Public hNur As NurApi          'Global access to RFID reader
    Dim connDlg As ReaderConnDlg    'Reader Connection settings
    Dim settingsDlg As ReaderSettingsDlg 'Reader settings
    Dim statusText As String    'Status text displayed on statusbar
    Dim statusColor As Color    'Color of status text


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        hNur = New NurApi()
        'Some handler definition for Nur events
        AddHandler hNur.ConnectedEvent, AddressOf NurConnected
        AddHandler hNur.DisconnectedEvent, AddressOf NurDisconnected

        statusText = "Disconnected"
        statusColor = Color.OrangeRed
        Timer1.Enabled = True
        Me.Text = My.Application.Info.ProductName
        connDlg = New ReaderConnDlg
        settingsDlg = New ReaderSettingsDlg

        '======= APPLICATIONS ========================
        'Here we adding dynamically applications as UserControl like Inventory.vb in to our TabControl
        '-----------------------------------------------
        'Inventory.vb: 
        'Allows perform Single and periodic inventory.
        'Results to ListView
        'Attach Inventory user control to Tab 
        Dim inventoryTab As New TabPage("Inventory") 'Create new Tab
        Dim invCtrl As New Inventory(hNur) 'Pass reference of NurAPI handle
        inventoryTab.Controls.Add(invCtrl) 'Add User control "Inventory" to tab
        invCtrl.Dock = DockStyle.Fill
        TabControl1.TabPages.Add(inventoryTab)
        '-----------------------------------------------
        'myRFID.vb: 
        'Almost empty control for your developing purposes
        Dim myAppTab As New TabPage("myRFIDApp") 'Create new Tab
        Dim myRFIDCtrl As New myRFIDApp(hNur) 'Pass reference of NurAPI handle
        myAppTab.Controls.Add(myRFIDCtrl) 'Add User control "myRFIDApp" to tab
        myRFIDCtrl.Dock = DockStyle.Fill
        TabControl1.TabPages.Add(myAppTab)
        '-----------------------------------------------

        'Select Inventory tab first to view
        TabControl1.SelectTab(inventoryTab)

    End Sub
    Sub NurConnected(ByVal sender As System.Object, ByVal e As NurApi.NurEventArgs)
        statusText = "Connected"
        statusColor = Color.LightGreen

    End Sub
    Sub NurDisconnected(ByVal sender As System.Object, ByVal e As NurApi.NurEventArgs)
        statusText = "Disconnected"
        statusColor = Color.OrangeRed

    End Sub

    'Timer is used to show  status texts in statusbar like connection status information.
    'In Periodic inventory, here we start displaying tag data after fetching to global tagStore is complete.
    'This way we avoid "Cross-thread operation not valid" error if accessing UI components from other thread.

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel1.Text = statusText
        ToolStripStatusLabel1.BackColor = statusColor
        
        If hNur.IsConnected Then
            TabControl1.Enabled = True
        Else
            TabControl1.Enabled = False
        End If
    End Sub

   
    Private Sub ConnectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConnectToolStripMenuItem.Click

        If connDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Try
                hNur.SetUsbAutoConnect(False) 'Stop USB AutoConnecting...

                If hNur.IsConnected Then
                    hNur.Disconnect() 'Disconnect old connection if any
                End If
            Catch ex As Exception

            End Try

            statusText = "Connecting..."
            If connDlg.RadioTCPIP.Checked = True Then
                'TCP/IP connection
                Try 'connection func must be in Try Catch in case of conn fails...
                    hNur.ConnectSocket(connDlg.EditIP.Text, Val(connDlg.EditPort.Text))
                Catch ex As Exception
                    'Connection fail
                    statusText = ex.Message
                End Try
            ElseIf connDlg.RadioCOM.Checked = True Then
                'COM port connection
                If connDlg.ComboCOM.SelectedIndex <> -1 Then
                    Try
                        hNur.ConnectSerialPort(connDlg.comport(connDlg.ComboCOM.SelectedIndex()), Val(connDlg.ComboBaudrate.Text))
                    Catch ex As Exception
                        statusText = ex.Message
                    End Try
                End If
            ElseIf connDlg.RadioUSBAutoConnect.Checked = True Then
                hNur.SetUsbAutoConnect(True)
            End If

        End If
    End Sub

    Private Sub AboutHumTagToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutHumTagToolStripMenuItem.Click
        If hNur.IsConnected Then
            Dim readerInfo As NurApi.ReaderInfo
            Try
                readerInfo = hNur.GetReaderInfo()
                AboutDlg.ListBox1.Items.Clear()
                AboutDlg.ListBox1.Items.Add("Name" & vbTab & readerInfo.name)
                AboutDlg.ListBox1.Items.Add("Version" & vbTab & readerInfo.GetVersionString)
                AboutDlg.ListBox1.Items.Add("HW Ver" & vbTab & readerInfo.hwVersion)
                AboutDlg.ListBox1.Items.Add("FCC   " & vbTab & readerInfo.fccId)
                AboutDlg.ListBox1.Items.Add("Serial" & vbTab & readerInfo.serial)
                AboutDlg.ListBox1.Items.Add("SW Ver" & vbTab & readerInfo.swVerMajor & "." & readerInfo.swVerMinor)
            Catch ex As Exception
                ToolStripStatus2.Text = "Error: GetReaderInfo:" & ex.Message
                ToolStripStatus2.ForeColor = Color.Red
            End Try

        Else
            AboutDlg.ListBox1.Items.Clear()
            AboutDlg.ListBox1.Items.Add("Not Connected")
        End If
        AboutDlg.ShowDialog()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        'Hoping that all components can drive itself down properly
        Me.Close()
    End Sub

    Private Sub FileToolStripMenuItem_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileToolStripMenuItem.DropDownOpening
        If hNur.IsConnected Then
            ReaderSettingsMenuItem.Enabled = True
        Else
            ReaderSettingsMenuItem.Enabled = False
        End If
    End Sub

    Private Sub ReaderSettingsMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReaderSettingsMenuItem.Click

        If hNur.IsConnected Then
            If settingsDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
                'OK pressed so let's send new configs to reader
                Try
                    hNur.SetModuleSetup(NurApi.SETUP_ALL, settingsDlg.nurSettings)
                Catch ex As Exception
                    ToolStripStatus2.Text = ex.Message
                    ToolStripStatus2.ForeColor = Color.Red
                End Try

            End If
        End If
    End Sub
End Class
