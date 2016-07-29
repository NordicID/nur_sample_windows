Imports System.Windows.Forms
Imports NurApiDotNet

Public Class ReaderConnDlg

    Public comport(20) As Integer 'Storing COM port numbers here in to specified index from COM combobox

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

   
    Private Sub ButConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButConnect.Click
        Me.Close()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        RadioUSBAutoConnect.Checked = True

        EditIP.Enabled = False
        EditPort.Enabled = False
        RadioTCPIP.Checked = False
        RadioCOM.Checked = False
        ComboBaudrate.Enabled = False
        ComboCOM.Enabled = False

        ComboBaudrate.SelectedIndex = 1 'Set default baud rate as 115200


    End Sub

    Private Sub ReaderConnDlg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
    End Sub

    Private Sub RadioCOM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioCOM.Click
        'Update content of COM combobox
        Dim ind As Integer
        EditIP.Enabled = False
        EditPort.Enabled = False
        ComboBaudrate.Enabled = True
        ComboCOM.Enabled = True

        ComboCOM.Items.Clear()

        Dim ports As New List(Of NurApi.ComPort)
        ports = NurApi.EnumerateComPorts

        For Each port As NurApi.ComPort In ports
            ind = ComboCOM.Items.Add(port.friendlyName)
            comport(ind) = port.port 'real com port num to array address by index of combobox item
        Next

    End Sub

    Private Sub RadioTCPIP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioTCPIP.Click
        EditIP.Enabled = True
        EditPort.Enabled = True
        ComboBaudrate.Enabled = False
        ComboCOM.Enabled = False

    End Sub

    Private Sub RadioUSBAutoConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioUSBAutoConnect.Click
        EditIP.Enabled = False
        EditPort.Enabled = False
        ComboBaudrate.Enabled = False
        ComboCOM.Enabled = False
    End Sub
End Class
