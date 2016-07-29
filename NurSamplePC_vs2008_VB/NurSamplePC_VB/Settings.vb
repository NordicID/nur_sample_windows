Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports System.Reflection

Imports NurApiDotNet
'NurApi wrapper
Public Partial Class Settings
	Inherits UserControl
	Private hNur As NurApi = Nothing
	Private disableEvents As Integer = 0

	Private Class ComboItem
		Public text As String
		Public value As Integer
		Public Sub New(text As String, value As Integer)
			Me.text = text
			Me.value = value
		End Sub
		Public Overrides Function ToString() As String
			Return text
		End Function
	End Class

	Public Sub New()
		InitializeComponent()
		Me.Enabled = False
	End Sub

	Public Sub SetNurApi(hNur As NurApi)
		Try
			Me.hNur = hNur

			' Set event handlers for NurApi
			AddHandler hNur.DisconnectedEvent, New EventHandler(Of NurApi.NurEventArgs)(AddressOf hNur_DisconnectedEvent)
			AddHandler hNur.ConnectedEvent, New EventHandler(Of NurApi.NurEventArgs)(AddressOf hNur_ConnectedEvent)

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
		disableEvents += 1
		Dim hNur As NurApi = TryCast(sender, NurApi)
		Me.Enabled = True
		Try
			FillNurComboBox(regionCombo, NurApi.SETUP_REGION, 0, NurCapabilities.I.ReaderInfo.numRegions - 1, True)
			FillNurComboBox(txLevelCombo, NurApi.SETUP_TXLEVEL, 0, NurCapabilities.I.DeviceCaps.txSteps - 1, True)
			FillNurComboBox(periodCombo, NurApi.SETUP_AUTOPERIOD, 0, NurApi.NUR_AUTOPER_50, True)
			FillNurComboBox(invEpcLenCombo, NurApi.SETUP_INVEPCLEN, 255, 255, True)
			FillNurComboBox(invEpcLenCombo, NurApi.SETUP_INVEPCLEN, 2, 62, False)
			UpdateSettingControls()
		Catch ex As Exception
			MessageBox.Show(ex.ToString(), Program.appName)
		End Try
		disableEvents -= 1
	End Sub

	Private Sub FillNurComboBox(comboBox As ComboBox, setupFlag As Integer, minValue As Integer, maxValue As Integer, clear As Boolean)
		' Fill ComboBox
		comboBox.BeginUpdate()
		If clear Then
			comboBox.Items.Clear()
		End If
		For value As Integer = minValue To maxValue
			Try
				Dim text As String = NurCapabilities.I.ConvertToString(setupFlag, value)
				comboBox.Items.Add(New ComboItem(text, value))
			Catch generatedExceptionName As Exception
			End Try
		Next
		comboBox.EndUpdate()
	End Sub

	Private Sub SelectNurComboBox(comboBox As ComboBox, value As Integer)
		Dim index As Integer = 0
		While index < comboBox.Items.Count
			Dim item As ComboItem = TryCast(comboBox.Items(index), ComboItem)
			If item.value = value Then
				comboBox.SelectedIndex = index
				Return
			End If
			index += 1
		End While
	End Sub

	Private Function GetNurComboBoxValue(comboBox As ComboBox) As Integer
		Dim item As ComboItem = TryCast(comboBox.SelectedItem, ComboItem)
		Return item.value
	End Function

	Private Sub UpdateAntennaControls(antennaMask As Integer, antennaSelection As Integer)
		' Fill Selected Antenna Combo and Enabled Antenna list
		Dim antSel As Integer = 0
		selectedAntenna.BeginUpdate()
		selectedAntenna.Items.Clear()
		For n As Integer = NurApi.ANTENNAID_AUTOSELECT To NurCapabilities.I.DeviceCaps.maxAnt - 1
			Dim antenna As String = NurCapabilities.I.ConvertToString(NurApi.SETUP_SELECTEDANTENNA, n)
			If (antennaMask And 1 << n) <> 0 OrElse n = NurApi.ANTENNAID_AUTOSELECT Then
				Dim index As Integer = selectedAntenna.Items.Add(New ComboItem(antenna, n))
				If n = antennaSelection Then
					antSel = index
				End If
			End If
		Next
		selectedAntenna.SelectedIndex = antSel
		selectedAntenna.EndUpdate()
	End Sub

	Private Sub UpdateSettingControls()
		disableEvents += 1
		Try
			' Get current settings
			Dim currenSetup As NurApi.ModuleSetup = hNur.GetModuleSetup()

			' Update Combo boxes
			regionCombo.SelectedIndex = currenSetup.regionId
			Select Case currenSetup.linkFreq
				Case 160000
					lfCombo.SelectedIndex = 0
					Exit Select
				Case 256000
					lfCombo.SelectedIndex = 1
					Exit Select
				Case 320000
					lfCombo.SelectedIndex = 2
					Exit Select
			End Select
			rxDecCombo.SelectedIndex = currenSetup.rxDecoding
			txModCombo.SelectedIndex = currenSetup.txModulation
			txLevelCombo.SelectedIndex = currenSetup.txLevel
			UpdateAntennaControls(currenSetup.antennaMask, currenSetup.selectedAntenna)

			qCombo.SelectedIndex = currenSetup.inventoryQ
			sessionCombo.SelectedIndex = currenSetup.inventorySession
			roundsCombo.SelectedIndex = currenSetup.inventoryRounds
			targetCombo.SelectedIndex = currenSetup.inventoryTarget
			periodCombo.SelectedIndex = currenSetup.periodSetup
			SelectNurComboBox(invEpcLenCombo, currenSetup.inventoryEpcLength)

			' Set Numeric UpDown boxs
			readRssiMin.Value = currenSetup.readRssiFilter.min
			readRssiMax.Value = currenSetup.readRssiFilter.max
			writeRssiMin.Value = currenSetup.writeRssiFilter.min
			writeRssiMax.Value = currenSetup.writeRssiFilter.max
			inventoryRssiMin.Value = currenSetup.inventoryRssiFilter.min
			inventoryRssiMax.Value = currenSetup.inventoryRssiFilter.max
		Catch ex As NurApiException
			MessageBox.Show(ex.ToString(), Program.appName)
			Me.Enabled = False
		End Try
		disableEvents -= 1
	End Sub

	Private Sub SettingsChanged(sender As Object, e As EventArgs)
		If disableEvents > 0 Then
			Return
		End If
		GetSettingsFromControls()
	End Sub

	Private Sub GetSettingsFromControls()
		Try
			' Get current settings
			Dim newSetup As NurApi.ModuleSetup = hNur.GetModuleSetup()

			' Get setting from Combo boxes
			newSetup.regionId = regionCombo.SelectedIndex
			Select Case lfCombo.SelectedIndex
				Case 0
					newSetup.linkFreq = 160000
					Exit Select
				Case 1
					newSetup.linkFreq = 256000
					Exit Select
				Case 2
					newSetup.linkFreq = 320000
					Exit Select
			End Select
			newSetup.rxDecoding = rxDecCombo.SelectedIndex
			newSetup.txModulation = txModCombo.SelectedIndex
			newSetup.txLevel = txLevelCombo.SelectedIndex

			'newSetup.antennaMask = 0;
			newSetup.selectedAntenna = GetNurComboBoxValue(selectedAntenna)

			newSetup.inventoryQ = qCombo.SelectedIndex
			newSetup.inventoryRounds = roundsCombo.SelectedIndex
			newSetup.inventorySession = sessionCombo.SelectedIndex
			newSetup.inventoryTarget = targetCombo.SelectedIndex
			newSetup.periodSetup = periodCombo.SelectedIndex
			newSetup.inventoryEpcLength = GetNurComboBoxValue(invEpcLenCombo)

			' Get settings from Numeric UpDown boxses
			newSetup.readRssiFilter.min = Convert.ToSByte(readRssiMin.Value)
			newSetup.readRssiFilter.max = Convert.ToSByte(readRssiMax.Value)
			newSetup.writeRssiFilter.min = Convert.ToSByte(writeRssiMin.Value)
			newSetup.writeRssiFilter.max = Convert.ToSByte(writeRssiMax.Value)
			newSetup.inventoryRssiFilter.min = Convert.ToSByte(inventoryRssiMin.Value)
			newSetup.inventoryRssiFilter.max = Convert.ToSByte(inventoryRssiMax.Value)

			' Set settings to NurApi
			hNur.SetModuleSetup(NurApi.SETUP_ALL, newSetup)
		Catch ex As NurApiException
			MessageBox.Show(ex.ToString(), Program.appName)
			UpdateSettingControls()
		End Try
	End Sub

	Private Sub storeSetupBtn_Click(sender As Object, e As EventArgs)
		hNur.StoreCurrentSetup()
	End Sub
End Class
