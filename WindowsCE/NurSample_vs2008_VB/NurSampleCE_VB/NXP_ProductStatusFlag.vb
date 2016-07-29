Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms

Imports NurApiDotNet
'NurApi wrapper
Partial Public Class NXP_ProductStatusFlag
    Inherits UserControl
    ''' <summary>
    ''' The NurApi handle
    ''' </summary>
    Private hNur As NurApi = Nothing

    ''' <summary>
    ''' The inventory beeper
    ''' </summary>
    Private beeperInventory As New BeeperInventory()

    ''' <summary>
    ''' The continue inventory
    ''' </summary>
    Private continueInventory As Boolean = False

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
            AddHandler hNur.InventoryStreamEvent, New EventHandler(Of NurApi.InventoryStreamEventArgs)(AddressOf hNur_InventoryStreamEvent)

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
    ''' Handles the InventoryStreamEvent event of the hNur control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="NurApi.InventoryStreamEventArgs"/> instance containing the event data.</param>
    Private Sub hNur_InventoryStreamEvent(ByVal sender As Object, ByVal e As NurApi.InventoryStreamEventArgs)
        Try
            Dim hNur As NurApi = TryCast(sender, NurApi)

            If e.data.tagsAdded > 0 Then
                Dim inventoriedTags As NurApi.TagStorage = hNur.GetTagStorage()
                'beeperInventory.Beep(numberOfNewTag);
                Dim numberOfNewTag As Integer = nxpTagListView.UpdateTagList(inventoriedTags)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), Program.appName)
        End Try

        ' Restart if stopped by TimeLimit
        If e.data.stopped AndAlso continueInventory Then
            StartPsfInventory()
        End If

        'Keepd device alive
        HHUtils.KeepDeviceAlive()
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
            ' Fill TargerTag fied
            targetEpcTextBox.Text = NurApi.BinToHexString(targetEPC)
            Try
                ' Read NXP configuration word
                Dim confWord As Byte() = hNur.ReadSingulatedTag(0, False, NurApi.BANK_EPC, 32, selectedTag.epc, NurApi.BANK_EPC, _
                 &H200 / 16, 2)
                configurationLabel.Text = Convert.ToString("0x") & NurApi.BinToHexString(confWord)
            Catch generatedExceptionName As NurApiException
                configurationLabel.Text = "???"
            End Try
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
            Dim epc As Byte() = NurApi.HexStringToBin(targetEpcTextBox.Text)
            ' Seems to be valid
            setBtn.Enabled = True
        Catch generatedExceptionName As Exception
            setBtn.Enabled = False
        End Try
    End Sub

    ''' <summary>
    ''' Handles the Click event of the setBtn control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    Private Sub setBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Get Target EPC from TextBox
        Dim targetEPC As Byte() = NurApi.HexStringToBin(targetEpcTextBox.Text)
SET_NXP_PSF:

        ' Set NXP PSF
        Try
            hNur.WriteTagByEPC(0, False, targetEPC, NurApi.BANK_EPC, &H200 / 16, New Byte() {&H0, &H1})
            MessageBox.Show("PSF set successfully", "WriteSingulatedTag")
        Catch ex As NurApiException
            Dim dr As DialogResult = MessageBox.Show(ex.Message, "NurApiException", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            If dr = DialogResult.Retry Then
                GoTo SET_NXP_PSF
            End If
        End Try
        ' Update PSF information
        nxpTagListView_SelectedTagChanged(sender, e)
    End Sub

    ''' <summary>
    ''' Handles the Click event of the psfInventoryButton control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub psfInventoryButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        If hNur.IsInventoryStreamRunning() Then
            continueInventory = False
            StopPsfInventory()
            psfInventoryButton.Text = "Start PSF inventory"
        Else
            ' Clear Tag List
            nxpTagListView.ClearTagList()
            ' Clear previously inventoried tags from memory
            hNur.ClearTags()

            continueInventory = True
            psfInventoryButton.Text = "Stop PSF inventory"
            StartPsfInventory()
        End If
    End Sub

    ''' <summary>
    ''' Starts the PSF inventory.
    ''' </summary>
    Private Sub StartPsfInventory()
        Try
            ' Start InventorySelectStream for searching 
            hNur.StartInventorySelectStream(hNur.InventoryRounds, hNur.InventoryQ, hNur.InventorySession, False, NurApi.BANK_EPC, &H20F, _
             1, New Byte() {&H80})
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), Program.appName)
        End Try
    End Sub

    ''' <summary>
    ''' Stops the PSF inventory.
    ''' </summary>
    Private Sub StopPsfInventory()
        Try
            ' Stop InventorySelectStream for searching 
            hNur.StopInventoryStream()
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), Program.appName)
        End Try
    End Sub
End Class
