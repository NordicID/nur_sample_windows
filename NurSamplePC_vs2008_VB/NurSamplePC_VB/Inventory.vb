Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms

Imports NurApiDotNet
'NurApi wrapper
Public Partial Class Inventory
	Inherits UserControl
	''' <summary>
	''' The NurApi handle
	''' </summary>
	Private hNur As NurApi = Nothing

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
	''' Initializes a new instance of the <see cref="Inventory" /> class.
	''' </summary>
	Public Sub New()
		InitializeComponent()
		Me.Enabled = False
		InitializInventoryRead()
	End Sub

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

	''' <summary>
	''' Sets the NurApi.
	''' </summary>
	''' <param name="hNur">The handle of NurApi.</param>
	Public Sub SetNurApi(hNur As NurApi)
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
	Private Sub hNur_DisconnectedEvent(sender As Object, e As NurApi.NurEventArgs)
		Dim hNur As NurApi = TryCast(sender, NurApi)
		Me.Enabled = False
	End Sub

	''' <summary>
	''' Handles the ConnectedEvent event of the NUR module.
	''' </summary>
	''' <param name="sender">The source of the event.</param>
	''' <param name="e">The <see cref="NurApi.NurEventArgs" /> instance containing the event data.</param>
	Private Sub hNur_ConnectedEvent(sender As Object, e As NurApi.NurEventArgs)
		Dim hNur As NurApi = TryCast(sender, NurApi)
		InitializInventoryRead()
		Me.Enabled = True
	End Sub

	''' <summary>
	''' Handles the InventoryStreamEvent event of the NUR module.
	''' </summary>
	''' <param name="sender">The source of the event.</param>
	''' <param name="e">The <see cref="NurApi.InventoryStreamEventArgs" /> instance containing the event data.</param>
	Private Sub hNur_InventoryStreamEvent(sender As Object, e As NurApi.InventoryStreamEventArgs)
		Try
			Dim hNur As NurApi = TryCast(sender, NurApi)

			If e.data.tagsAdded > 0 Then
				Dim inventoriedTags As NurApi.TagStorage = hNur.GetTagStorage()
				Dim numberOfNewTag As Integer = tagListBox.UpdateTagList(inventoriedTags)
				tagsFoundLabel.Text = String.Format("{0} Tags", inventoriedTags.Count)
			End If
		Catch ex As Exception
			MessageBox.Show(ex.ToString(), Program.appName)
		End Try

		' Restart if stopped by TimeLimit
		If e.data.stopped AndAlso continueInventory Then
			hNur.StartInventoryStream()
		End If
	End Sub

	''' <summary>
	''' Handles the Click event of the startStopInventoryBtn control.
	''' </summary>
	''' <param name="sender">The source of the event.</param>
	''' <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
	Private Sub startStopInventoryBtn_Click(sender As Object, e As EventArgs)
		If hNur.IsInventoryStreamRunning() Then
			' Stop inventory
			StopInventory()
			' Update START button
			startStopInventoryBtn.Text = "Start Inventory"
		Else
			' Clear NurApi TagStorage memory from tags 
			hNur.ClearTags()
			' Clear tagListBox from tags
			tagListBox.ClearTagList()
			' Update START button
			startStopInventoryBtn.Text = "Stop Inventory"
			' Configure and start inventory
			StartInventory()
		End If
	End Sub

	Private Sub StartInventory()
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
						hNur.InventoryRead(True, NurApi.NUR_IR_EPCDATA, CUInt(dataBankComboBox.SelectedIndex), CUInt(Math.Truncate(dataStartUpDown.Value)), CUInt(Math.Truncate(dataLengthUpDown.Value)))
						Exit Select
					Case 2
						' DATA ONLY
						' NOTE: this call does not start the data read; it tells the module
						' that the following inventory stream is done with a read.
						hNur.InventoryRead(True, NurApi.NUR_IR_DATAONLY, CUInt(dataBankComboBox.SelectedIndex), CUInt(Math.Truncate(dataStartUpDown.Value)), CUInt(Math.Truncate(dataLengthUpDown.Value)))
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

		' Restart the inventory stream if necessary
		continueInventory = True

		' Start Inventory Stream
		hNur.StartInventoryStream()
	End Sub

	''' <summary>
	''' Stops the inventory.
	''' </summary>
	Private Sub StopInventory()
		' Do not restart the inventory stream 
		continueInventory = False
		''' Force stop all NUR module running continuous functions.
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
	Private Sub invTypeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs)
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
End Class
