Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms

Imports NurApiDotNet
'NurApi wrapper
Partial Public Class NXP_EasAlarm
    Inherits UserControl
    Private hNur As NurApi = Nothing

    Public Sub New()
        InitializeComponent()
        UpdateButtons()
        Me.Enabled = False
    End Sub

    ''' <summary>
    ''' Sets the hadle of nur API.
    ''' </summary>
    ''' <param name="hNur">Handle of NurApi.</param>
    Public Sub SetNurApi(ByVal hNur As NurApi)
        Try
            Me.hNur = hNur

            ' Set event handlers for NurApi
            AddHandler hNur.DisconnectedEvent, New EventHandler(Of NurApi.NurEventArgs)(AddressOf hNur_DisconnectedEvent)
            AddHandler hNur.ConnectedEvent, New EventHandler(Of NurApi.NurEventArgs)(AddressOf hNur_ConnectedEvent)
            AddHandler hNur.NXPAlarmStreamEvent, New EventHandler(Of NurApi.NXPAlarmStreamEventArgs)(AddressOf hNur_NXPAlarmStreamEvent)

            ' Update the status of the connection
            If hNur.IsConnected() Then
                hNur_ConnectedEvent(hNur, Nothing)
            Else
                hNur_DisconnectedEvent(hNur, Nothing)
            End If
        Catch ex As NurApiException
            MessageBox.Show(ex.ToString(), Program.appName)
        End Try
    End Sub

    ''' <summary>
    ''' Handles the NXPAlarmStreamEvent event of the hNur control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="NurApi.NXPAlarmStreamEventArgs"/> instance containing the event data.</param>
    Private Sub hNur_NXPAlarmStreamEvent(ByVal sender As Object, ByVal e As NurApi.NXPAlarmStreamEventArgs)
        Try
            Dim hNur As NurApi = TryCast(sender, NurApi)

            If e.data.armed Then
                Dim inventoriedTags As NurApi.TagStorage = hNur.GetTagStorage()
                'tagsFoundLabel.Text = string.Format("{0} Tags", inventoriedTags.Count);
                'beeperInventory.Beep(numberOfNewTag);
                Dim numberOfNewTag As Integer = nxpTagListView.UpdateTagList(inventoriedTags)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), Program.appName)
        End Try

        ' Restart if stopped by TimeLimit
        'if (e.data.stopped && continueInventory)
        '{
        '    hNur.StartInventoryStream();
        '}

        'Keepd device alive
        HHUtils.KeepDeviceAlive()
    End Sub

    ''' <summary>
    ''' Handles the DisconnectedEvent event of the NUR module.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="NurApi.NurEventArgs" /> instance containing the event data.</param>
    Private Sub hNur_DisconnectedEvent(ByVal sender As Object, ByVal e As NurApi.NurEventArgs)
        Dim hNur As NurApi = TryCast(sender, NurApi)
        Me.Enabled = False
    End Sub

    ''' <summary>
    ''' Handles the ConnectedEvent event of the NUR module.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="NurApi.NurEventArgs" /> instance containing the event data.</param>
    Private Sub hNur_ConnectedEvent(ByVal sender As Object, ByVal e As NurApi.NurEventArgs)
        Dim hNur As NurApi = TryCast(sender, NurApi)
        Me.Enabled = True
    End Sub

    ''' <summary>
    ''' Handles the Click event of the refreshBtn control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    Private Sub refreshBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Clear Tag List
        nxpTagListView.ClearTagList()
        ' Clear previously inventoried tags from memory
        hNur.ClearTags()
        ' Perform simple inventory
        For i As Integer = 0 To 2
            hNur.SimpleInventory()
        Next
        ' Fetch tags from module, including tag meta
        Dim inventoriedTags As NurApi.TagStorage = hNur.FetchTags(True)
        ' Update Tag List
        nxpTagListView.UpdateTagList(inventoriedTags)
    End Sub

    ''' <summary>
    ''' Handles the SelectedTagChanged event of the nxpTagListView control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub nxpTagListView_SelectedTagChanged(ByVal sender As Object, ByVal e As EventArgs)
        ' Update tag list
        Dim selectedTag As NurApi.Tag = nxpTagListView.SelectedTag
        If selectedTag IsNot Nothing Then
            ' Get EPC from selection
            Dim targetEPC As Byte() = selectedTag.epc
            Try
                ' Get Access password from selected tag
                Dim accessPassword As UInteger = hNur.GetAccessPassword(0, False, NurApi.BANK_EPC, 32, targetEPC.Length * 8, targetEPC)
                ' Fill Access password fied
                Dim accPwdBytes As Byte() = Utils.ConvertToBigEndiaBytes(accessPassword)
                accessPasswordTextBox.Text = NurApi.BinToHexString(accPwdBytes)
            Catch generatedExceptionName As Exception
                accessPasswordTextBox.Text = "unknown"
            End Try
            ' Fill TargerTag fied
            targetEpcTextBox.Text = NurApi.BinToHexString(targetEPC)
        End If

        ' Update button(s)
        UpdateButtons()
    End Sub

    ''' <summary>
    ''' Updates the buttons.
    ''' </summary>
    Private Sub UpdateButtons()
        Try
            ' Test access password
            Dim access As Byte() = NurApi.HexStringToBin(accessPasswordTextBox.Text)
            ' Test access password
            Dim epc As Byte() = NurApi.HexStringToBin(targetEpcTextBox.Text)
            ' Seems to be valid
            setBtn.Enabled = True
            resetBtn.Enabled = True
        Catch generatedExceptionName As Exception
            setBtn.Enabled = False
            resetBtn.Enabled = False
        End Try
    End Sub

    ''' <summary>
    ''' Handles the Click event of the setBtn control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    Private Sub setBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Get Access password from TextBox
        Dim accPwdBytes As Byte() = NurApi.HexStringToBin(accessPasswordTextBox.Text)
        Dim accPwdUInt As UInteger = CUInt(Utils.ConvertBigEndiaToSystemEndia(accPwdBytes))
        ' Get Target EPC from TextBox
        Dim targetEPC As Byte() = NurApi.HexStringToBin(targetEpcTextBox.Text)
SET_ACCESS_PASSWORD:

        ' Set Access Password
        Try
            hNur.SetAccessPasswordByEPC(0, False, targetEPC, accPwdUInt)
        Catch ex As NurApiException
            Dim dr As DialogResult = MessageBox.Show(ex.Message, "NurApiException", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            If dr = DialogResult.Retry Then
                GoTo SET_ACCESS_PASSWORD
            End If
        End Try
SET_NXP_READ_PROTECTION:

        ' Set Read Protection
        Try
            hNur.NXPSetEAS(accPwdUInt, NurApi.BANK_EPC, 32, targetEPC.Length * 8, targetEPC)
            MessageBox.Show("EAS set successfully", "NXPSetEAS")
        Catch ex As NurApiException
            Dim dr As DialogResult = MessageBox.Show(ex.Message, "NurApiException", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            If dr = DialogResult.Retry Then
                GoTo SET_NXP_READ_PROTECTION
            End If
        End Try
    End Sub

    ''' <summary>
    ''' Handles the Click event of the resetBtn control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    Private Sub resetBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Get Access password from TextBox
        Dim accPwdBytes As Byte() = NurApi.HexStringToBin(accessPasswordTextBox.Text)
        Dim accPwdUInt As UInteger = CUInt(Utils.ConvertBigEndiaToSystemEndia(accPwdBytes))
        ' Get Target EPC from TextBox
        Dim targetEPC As Byte() = NurApi.HexStringToBin(targetEpcTextBox.Text)
RESET_NXP_READ_PROTECTION:

        ' Reset Read Protection
        Try
            hNur.NXPResetEAS(accPwdUInt, NurApi.BANK_EPC, 32, targetEPC.Length * 8, targetEPC)
            MessageBox.Show("EAS reset successfully", "NXPResetEAS")
        Catch ex As NurApiException
            Dim dr As DialogResult = MessageBox.Show(ex.Message, "NurApiException", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            If dr = DialogResult.Retry Then
                GoTo RESET_NXP_READ_PROTECTION
            End If
        End Try
    End Sub

    Private Sub alarmButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        If hNur.IsNXPAlarmStreamRunning() Then
            hNur.NXPStopAlarmStream()
            alarmButton.Text = "Start ALARM"
        Else
            alarmButton.Text = "Stop ALARM"
            hNur.NXPStartAlarmStream()
        End If
    End Sub
End Class
