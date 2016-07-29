Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms

Imports NurApiDotNet
'NurApi wrapper
Partial Public Class Inventory
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

    ''' <summary>
    ''' The inventory read supported
    ''' </summary>
    Private inventoryReadSupported As Boolean = False

    ''' <summary>
    ''' The unofficial TID inventory supported
    ''' </summary>
    Private unofficialTidInventorySupported As Boolean = False

    ''' <summary>
    ''' The inventory filters
    ''' </summary>
    Private filters As New List(Of NurApi.InventoryExFilter)()

    ''' <summary>
    ''' The filter index
    ''' </summary>
    Private filterIndex As Integer = 0

    ''' <summary>
    ''' The start tick
    ''' </summary>
    Private startTick As Integer = 0
    ''' <summary>
    ''' The total reads
    ''' </summary>
    Private totalReads As Integer = 0

    ''' <summary>
    ''' The last unique tick
    ''' </summary>
    Private uniqueTick As Integer = 0
    ''' <summary>
    ''' The unique tags
    ''' </summary>
    Private uniqueTags As Integer = 0

    ''' <summary>
    ''' Initializes a new instance of the <see cref="Inventory" /> class.
    ''' </summary>
    Public Sub New()
        InitializeComponent()
        Me.Enabled = False
        InitializInventoryRead()
        InitializLogToFile()
        ShowFilter(filterIndex)
    End Sub

    ''' <summary> 
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (beeperInventory IsNot Nothing) Then
            beeperInventory.Dispose()
        End If
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    ''' <summary>
    ''' Sets the NurApi.
    ''' </summary>
    ''' <param name="hNur">The handle of NurApi.</param>
    Public Sub SetNurApi(ByVal hNur As NurApi)
        Try
            Me.hNur = hNur

            ' Set event handlers for NurApi
            AddHandler hNur.DisconnectedEvent, New EventHandler(Of NurApi.NurEventArgs)(AddressOf hNur_DisconnectedEvent)
            AddHandler hNur.ConnectedEvent, New EventHandler(Of NurApi.NurEventArgs)(AddressOf hNur_ConnectedEvent)
            AddHandler hNur.InventoryStreamEvent, New EventHandler(Of NurApi.InventoryStreamEventArgs)(AddressOf hNur_InventoryStreamEvent)
            AddHandler hNur.InventoryExEvent, New EventHandler(Of NurApi.InventoryStreamEventArgs)(AddressOf hNur_InventoryStreamEvent)

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
        InitializInventoryRead()
        Me.Enabled = True
    End Sub

    ''' <summary>
    ''' Handles the InventoryStreamEvent event of the NUR module.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="NurApi.InventoryStreamEventArgs" /> instance containing the event data.</param>
    Private Sub hNur_InventoryStreamEvent(ByVal sender As Object, ByVal e As NurApi.InventoryStreamEventArgs)
        Try
            Dim hNur As NurApi = TryCast(sender, NurApi)

            If e.data.tagsAdded > 0 Then
                totalReads += e.data.tagsAdded
                Dim inventoriedTags As NurApi.TagStorage = hNur.GetTagStorage()
                Dim numberOfNewTag As Integer = tagListBox.UpdateTagList(inventoriedTags)
                beeperInventory.Beep(numberOfNewTag)
                WriteLogToFile(inventoriedTags)
                UpdateStatistics(inventoriedTags)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), Program.appName)
        End Try

        ' Restart if stopped by TimeLimit
        If e.data.stopped AndAlso continueInventory Then
            StartInventory(hNur)
        End If

        'Keepd device alive
        HHUtils.KeepDeviceAlive()
    End Sub

    ''' <summary>
    ''' Updates the statistics.
    ''' </summary>
    Private Sub UpdateStatistics(ByVal tagStorage As NurApi.TagStorage)
        If tagStorage IsNot Nothing Then
            Dim ticksNow As Integer = System.Environment.TickCount
            Dim elapsed As Integer = ticksNow - startTick
            totalLabel.Text = "Total reads in " + CInt(elapsed / 1000).ToString() + " sec"
            totalReadsLabel.Text = "  " + totalReads.ToString() + " reads"
            totalAverageLabel.Text = "  " + CInt((totalReads * 1000) / elapsed).ToString() + " reads/sec"

            If uniqueTags <> tagStorage.Count Then
                uniqueTick = ticksNow
                uniqueTags = tagStorage.Count
                Dim uniqueElapsed As Integer = uniqueTick - startTick
                uniqueLabel.Text = "Unique tags in " + CInt(uniqueElapsed / 1000).ToString() + " sec"
                tagsFoundLabel.Text = String.Format("{0} Tags", uniqueTags)
                uniqueTagsLabel.Text = "  " + uniqueTags.ToString() + " unique tags"
                uniqueAverageLabel.Text = "  " + CInt((uniqueTags * 1000) / uniqueElapsed).ToString() + " unique tags/sec"
            End If
        Else
            tagsFoundLabel.Text = "- - -"
            totalReadsLabel.Text = "- - -"
            totalAverageLabel.Text = "- - -"
            uniqueTagsLabel.Text = "- - -"
            uniqueAverageLabel.Text = "- - -"

            totalReads = 0
            uniqueTags = 0
            startTick = System.Environment.TickCount
            uniqueTick = startTick
        End If
    End Sub

    ''' <summary>
    ''' Handles the Click event of the startStopInventoryBtn control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    Public Sub startStopInventoryBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
        If hNur.IsInventoryStreamRunning() OrElse hNur.IsInventoryExRunning() Then
            ' Stop inventory
            StopInventory()
            ' Stop inventory beeper
            beeperInventory.[Stop]()
            ' Update START button
            startStopInventoryBtn.Text = "Start Inventory"
            startStopInventoryBtn2.Text = startStopInventoryBtn.Text
            ' Stop Log To file
            StopLogToFile()
        Else
            ' Init statistics
            UpdateStatistics(Nothing)
            ' Clear NurApi TagStorage memory from tags 
            hNur.ClearTags()
            ' Clear tagListBox from tags
            tagListBox.ClearTagList()
            ' Update START button
            startStopInventoryBtn.Text = "Stop Inventory"
            startStopInventoryBtn2.Text = startStopInventoryBtn.Text
            ' Start Log to file if enabled
            StartLogToFile()
            ' Start inventory beeper
            beeperInventory.Start()
            ' Configure and start inventory
            ConfigureInventory(hNur)
            StartInventory(hNur)
        End If
    End Sub

    Private Sub ConfigureInventory(ByVal hNur As NurApi)
        If inventoryReadSupported Then
            Try
                ' Configure the inventory settings.
                ' This may fail if the feature is not supported
                Select Case invTypeComboBox.SelectedIndex
                    Case 0
                        ' INVENTORY ONLY
                        ' Disable Inventory read control
                        hNur.InventoryReadCtl = False
                        Exit Select
                    Case 1
                        ' INVENTORY + DATA
                        ' NOTE: this call does not start the inventory + read; it tells the module
                        ' that the following inventory stream is done with a inventory + read.
                        hNur.InventoryRead(True, NurApi.NUR_IR_EPCDATA, CUInt(dataBankComboBox.SelectedIndex), CUInt(dataStartUpDown.Value), CUInt(dataLengthUpDown.Value))
                        Exit Select
                    Case 2
                        ' DATA ONLY
                        ' NOTE: this call does not start the data read; it tells the module
                        ' that the following inventory stream is done with a read.
                        hNur.InventoryRead(True, NurApi.NUR_IR_DATAONLY, CUInt(dataBankComboBox.SelectedIndex), CUInt(dataStartUpDown.Value), CUInt(dataLengthUpDown.Value))
                        Exit Select
                End Select
            Catch generatedExceptionName As NurApiException
                ' It seems that the InventoryRead is not supported
                ' Try unofficial TID inventory
                inventoryReadSupported = False
                InitializeUnofficialTidInventory()
            End Try
        End If

        If unofficialTidInventorySupported Then
            Try
                ' Configure the unofficial feature inventory inventory settings.
                ' This may fail if the feature is not supported
                Select Case invTypeComboBox.SelectedIndex
                    Case 0
                        ' INVENTORY ONLY
                        ' Disable unofficial TID inventory
                        hNur.OpFlags = hNur.OpFlags And Not (1 << 2)
                        Exit Select
                    Case 1
                        ' TID INVENTORY
                        ' Enable unofficial TID inventory feature where
                        ' the inventory stream returns fixed length (4 words)
                        ' TID instead of EPC.
                        hNur.OpFlags = hNur.OpFlags Or (1 << 2)
                        Exit Select
                End Select
            Catch generatedExceptionName As NurApiException
                ' It seems that the unofficial TID Inventory is not supported
                unofficialTidInventorySupported = False
            End Try
        End If
    End Sub

    Private Sub StartInventory(ByVal hNur As NurApi)
        ' Restart the inventory stream if necessary
        continueInventory = True

        ' Start Inventory Stream
        Try
            If filters.Count > 0 Then
                ' Start InventoryEx Stream
                Dim ip As New NurApi.InventoryExParams()
                ip.inventorySelState = NurApi.SELSTATE_SL
                ip.inventoryTarget = hNur.InventoryTarget
                ip.Q = hNur.InventoryQ
                ip.rounds = hNur.InventoryRounds
                ip.session = hNur.InventorySession
                ip.transitTime = 0

                Dim filt As NurApi.InventoryExFilter() = filters.ToArray()
                hNur.StartInventoryEx(ip, filt)
            Else
                ' Start Inventory Stream without filtering
                hNur.StartInventoryStream()
            End If
        Catch ex As NurApiException
            MessageBox.Show(ex.ToString(), Program.appName)
        End Try
    End Sub

    ''' <summary>
    ''' Stops the inventory.
    ''' </summary>
    Private Sub StopInventory()
        ' Do not restart the inventory stream 
        continueInventory = False
        ' Force stop all NUR module running continuous functions.
        hNur.StopContinuous()
        If inventoryReadSupported Then
            ' Disable Inventory read control
            hNur.InventoryReadCtl = False
        End If
        If unofficialTidInventorySupported Then
            ' Disable unofficial TID inventory
            hNur.OpFlags = hNur.OpFlags And Not (1 << 2)
        End If
    End Sub

    ''' <summary>
    ''' Initializs the inventory read.
    ''' </summary>
    Private Sub InitializInventoryRead()
        inventoryReadSupported = True
        invTypeComboBox.Items.Clear()
        invTypeComboBox.Items.Add("Inventory only")
        invTypeComboBox.Items.Add("Inv. + data")
        invTypeComboBox.Items.Add("Data only")
        invTypeComboBox.SelectedIndex = 0
        dataBankComboBox.SelectedIndex = NurApi.BANK_TID
        dataStartUpDown.Value = 0
        dataLengthUpDown.Value = 4
        UpdtaeInvnetoryControls()
    End Sub

    ''' <summary>
    ''' Initializes the unofficial TID inventory.
    ''' </summary>
    Private Sub InitializeUnofficialTidInventory()
        unofficialTidInventorySupported = True
        invTypeComboBox.Items.Clear()
        invTypeComboBox.Items.Add("EPC Inventory")
        invTypeComboBox.Items.Add("TID Inventory")
        invTypeComboBox.SelectedIndex = 0
        dataBankComboBox.SelectedIndex = NurApi.BANK_TID
        dataStartUpDown.Value = 0
        dataLengthUpDown.Value = 4
        UpdtaeInvnetoryControls()
    End Sub

    ''' <summary>
    ''' Handles the SelectedIndexChanged event of the invTypeComboBox control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub invTypeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        UpdtaeInvnetoryControls()
    End Sub

    ''' <summary>
    ''' Updtaes the invnetory controls.
    ''' </summary>
    Private Sub UpdtaeInvnetoryControls()
        Dim enable As Boolean = False
        If inventoryReadSupported Then
            enable = invTypeComboBox.SelectedIndex > 0
        End If
        dataBankLabel.Enabled = enable
        dataBankComboBox.Enabled = enable
        dataStartLabel.Enabled = enable
        dataStartUpDown.Enabled = enable
        dataLengthLabel.Enabled = enable
        dataLengthUpDown.Enabled = enable
        invTypeComboBox.Enabled = inventoryReadSupported OrElse unofficialTidInventorySupported
    End Sub

    ''' <summary>
    ''' The log to file
    ''' </summary>
    Private logToFileTagCounter As Integer = 0
    Private logToFileFormat As Integer = 0
    Private logToFileEnabled As Boolean = False
    Private logToFileSeparator As String = ","
    Private logToFile As New LogToFile()

    ''' <summary>
    ''' Initializs the log to file.
    ''' </summary>
    Private Sub InitializLogToFile()
        logInvEnabledComboBox.Checked = logToFileEnabled
        logInvActionComboBox.SelectedIndex = 0
        logInvFormatComboBox.SelectedIndex = 0
        logInvSeparatorTextBox.Text = logToFileSeparator
    End Sub

    ''' <summary>
    ''' Starts the log to file if enabled.
    ''' </summary>
    Private Sub StartLogToFile()
        If logToFileEnabled Then
            logToFileTagCounter = 0
            logToFile.StartLog(logInvFileNameTextBox.Text, logInvActionComboBox.SelectedIndex)
        End If
    End Sub

    ''' <summary>
    ''' Stops the log to file.
    ''' </summary>
    Private Sub StopLogToFile()
        logToFile.StopLog()
    End Sub

    ''' <summary>
    ''' Writes the log to file.
    ''' </summary>
    ''' <param name="tagStorage">The tag storage.</param>
    Private Sub WriteLogToFile(ByVal tagStorage As NurApi.TagStorage)
        If logToFileEnabled Then
            While logToFileTagCounter < tagStorage.Count
                Select Case logToFileFormat
                    Case 0
                        ' EPC
                        logToFile.WriteLog(tagStorage(logToFileTagCounter).GetEpcString())
                        Exit Select
                    Case 1
                        ' EPC, DATA
                        logToFile.WriteLog(String.Format("{0}{1}{2}", tagStorage(logToFileTagCounter).GetEpcString(), logToFileSeparator, If(tagStorage(logToFileTagCounter).irData IsNot Nothing, NurApi.BinToHexString(tagStorage(logToFileTagCounter).irData), "")))
                        Exit Select
                    Case 2
                        ' Date&Time, EPC, RSSI
                        logToFile.WriteLog(String.Format("{0}{1}{2}{3}{4}", DateTime.Now.ToString(), logToFileSeparator, tagStorage(logToFileTagCounter).GetEpcString(), logToFileSeparator, tagStorage(logToFileTagCounter).rssi.ToString()))
                        Exit Select
                End Select
                logToFileTagCounter += 1
            End While
        End If
    End Sub

    ''' <summary>
    ''' Handles the Click event of the logInvBrowseBtn control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub logInvBrowseBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
        saveLogDialog.FileName = logInvFileNameTextBox.Text
        If saveLogDialog.ShowDialog() = DialogResult.OK Then
            logInvFileNameTextBox.Text = saveLogDialog.FileName
        End If
    End Sub

    ''' <summary>
    ''' Handles the CheckStateChanged event of the logInvEnabledComboBox control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub logInvEnabledComboBox_CheckStateChanged(ByVal sender As Object, ByVal e As EventArgs)
        logToFileEnabled = logInvEnabledComboBox.Checked
        logInvFileNameTextBox.Enabled = logToFileEnabled
        logInvActionComboBox.Enabled = logToFileEnabled
        logInvFormatComboBox.Enabled = logToFileEnabled
        logInvSeparatorTextBox.Enabled = logToFileEnabled
    End Sub

    ''' <summary>
    ''' Handles the SelectedIndexChanged event of the logInvFormatComboBox control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub logInvFormatComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        logToFileFormat = logInvFormatComboBox.SelectedIndex
    End Sub

    ''' <summary>
    ''' Handles the TextChanged event of the textBox1 control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    Private Sub logInvSeparatorTextBox_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        logToFileSeparator = logInvSeparatorTextBox.Text
    End Sub

    Private Sub tagListBox_SelectedTagChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim tag As NurApi.Tag = tagListBox.SelectedTag
        If tag IsNot Nothing Then
            InitFilter(tag.GetEpcString())
        End If
    End Sub

    Private Sub readTag_Button_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim tag As NurApi.Tag = Nothing
        Dim usedTxLevel As Integer
        If NurUtils.SearchNearestTag(hNur, True, tag, usedTxLevel) > 0 Then
            InitFilter(tag.GetEpcString())
        End If
    End Sub

    Private Sub deleteBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            filters.Remove(filters(filterIndex))
        Catch generatedExceptionName As Exception
        End Try
        ShowFilter(filterIndex)
    End Sub

    Private Sub addBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
        AddFilter()
        ShowFilter(filters.Count - 1)
    End Sub

    Private Sub InitFilter(ByVal mask As String)
        bank_combo.SelectedIndex = NurApi.BANK_EPC
        address_UpDown.Value = 4 * 8
        ' (CRC + PC) * 8 bits
        mask_textBox.Text = mask
        length_UpDown.Value = mask.Length * 4
        action_combo.SelectedIndex = NurApi.FACTION_0
        target_combo.SelectedIndex = NurApi.SESSION_SL
        filterCntLabel.Text = String.Format("---/{0}", filters.Count)
    End Sub

    Private Sub AddFilter()
        Dim filt As New NurApi.InventoryExFilter()
        Dim mask As Byte() = NurApi.HexStringToBin(mask_textBox.Text)
        filt.action = CByte(action_combo.SelectedIndex)
        filt.address = CUInt(address_UpDown.Value)
        filt.bank = CByte(bank_combo.SelectedIndex)
        filt.maskBitLength = CInt(length_UpDown.Value)
        filt.maskData = New Byte(NurApi.MAX_SELMASK - 1) {}
        Buffer.BlockCopy(mask, 0, filt.maskData, 0, mask.Length)
        filt.target = CByte(target_combo.SelectedIndex)
        filters.Add(filt)
    End Sub

    Private Sub ShowFilter(ByVal index As Integer)
        If index >= filters.Count Then
            index = filters.Count - 1
        End If
        If index < 0 Then
            index = 0
        ElseIf index > filters.Count - 1 Then
            index = filters.Count - 1
        End If
        filterIndex = index

        If filters.Count > 0 Then
            bank_combo.SelectedIndex = filters(index).bank
            address_UpDown.Value = filters(index).address
            mask_textBox.Text = NurApi.BinToHexString(filters(index).maskData, CInt((filters(index).maskBitLength + 7) / 8))
            length_UpDown.Value = filters(index).maskBitLength
            action_combo.SelectedIndex = filters(index).action
            target_combo.SelectedIndex = filters(index).target
            filterCntLabel.Text = String.Format("{0}/{1}", index + 1, filters.Count)
        Else
            index = 0
            InitFilter("")
            filterCntLabel.Text = "not set"
        End If
    End Sub

    Private Sub decIndex_Click(ByVal sender As Object, ByVal e As EventArgs)
        filterIndex -= 1
        ShowFilter(filterIndex)
    End Sub

    Private Sub incIndex_Click(ByVal sender As Object, ByVal e As EventArgs)
        filterIndex += 1
        ShowFilter(filterIndex)
    End Sub
End Class
