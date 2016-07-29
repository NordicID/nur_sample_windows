Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms

Imports NurApiDotNet
'NurApi wrapper
Public Partial Class Sensors
	Inherits UserControl
	''' <summary>
	''' The NurApi handle
	''' </summary>
	Private hNur As NurApi = Nothing

	''' <summary>
	''' The disable controls events
	''' </summary>
	Private disableEvents As Boolean = False

	''' <summary>
	''' Initializes a new instance of the <see cref="Inventory" /> class.
	''' </summary>
	Public Sub New()
		InitializeComponent()
		Me.Enabled = False
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
			AddHandler hNur.TriggerReadEvent, New EventHandler(Of NurApi.TriggerReadEventArgs)(AddressOf hNur_TriggerReadEvent)
			AddHandler hNur.IOChangeEvent, New EventHandler(Of NurApi.IOChangeEventArgs)(AddressOf hNur_IOChangeEvent)

			' Update the status of the connection
			If hNur.IsConnected() Then
				hNur_ConnectedEvent(hNur, Nothing)
			Else
				hNur_DisconnectedEvent(hNur, Nothing)
			End If
		Catch ex As NurApiException
			MessageBox.Show(ex.ToString(), Program.appName, MessageBoxButtons.OK, MessageBoxIcon.[Error])
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
		disableEvents = True
		Dim hNur As NurApi = TryCast(sender, NurApi)
		Try
			If hNur.GetReaderInfo().numSensors > 0 Then
				UpdateSensorControls()
				Me.Enabled = True
			End If
		Catch ex As NurApiException
			MessageBox.Show(ex.ToString(), Program.appName, MessageBoxButtons.OK, MessageBoxIcon.[Error])
			Me.Enabled = False
		End Try
		disableEvents = False
	End Sub

	Private Sub hNur_IOChangeEvent(sender As Object, e As NurApi.IOChangeEventArgs)
		Dim hNur As NurApi = TryCast(sender, NurApi)
		Dim eventString As String = String.Format("{0:N0}: IOChange: {1} #{2}, {3}", e.timestamp, If(e.data.sensor, "Sensor", "GPIO"), e.data.source, If(e.data.dir = 0, "High to low", "Low to high"))
		AddToEventList(eventString)
	End Sub

	Private Sub hNur_InventoryStreamEvent(sender As Object, e As NurApi.InventoryStreamEventArgs)
		Dim hNur As NurApi = TryCast(sender, NurApi)
		Dim eventString As String = String.Format("{0:N0}: InvStream: Tags {1}, Rounds {2}, Q {3}", e.timestamp, e.data.tagsAdded, e.data.roundsDone, e.data.Q)
		AddToEventList(eventString)
	End Sub

	Private Sub hNur_TriggerReadEvent(sender As Object, e As NurApi.TriggerReadEventArgs)
		Dim hNur As NurApi = TryCast(sender, NurApi)
		If e.data.rssi > -127 Then
			' Tag found
			Dim epc As Byte() = New Byte(e.data.epcLen - 1) {}
			Array.Copy(e.data.epc, epc, e.data.epcLen)

			Dim eventString As String = String.Format("{0:N0}: TrigRead: {1} #{2}, Ant #{3}, {4} ({6} Bytes), RSSI {5}%", e.timestamp, If(e.data.sensor, "Sensor", "GPIO"), e.data.source, e.data.antennaID, NurApi.BinToHexString(epc), _
				e.data.scaledRssi, e.data.epcLen)
			AddToEventList(eventString)
		Else
			' Tag not be found
			Dim eventString As String = String.Format("{0:N0}: TrigRead: TAG NOT BE FOUND", e.timestamp)
			AddToEventList(eventString)
		End If
	End Sub

	Private Sub UpdateSensorControls()
		Dim sensorConfig As NurApi.SensorConfig = hNur.GetSensorConfig()

		If sensorConfig.tapEnabled = True AndAlso sensorConfig.tapAction > NurApi.GPIO_ACT_NONE AndAlso sensorConfig.tapAction <= NurApi.GPIO_ACT_INVENTORY Then
			tapSensorCombo.SelectedIndex = sensorConfig.tapAction
		Else
			tapSensorCombo.SelectedIndex = 0
		End If

		If sensorConfig.lightEnabled = True AndAlso sensorConfig.lightAction > NurApi.GPIO_ACT_NONE AndAlso sensorConfig.lightAction <= NurApi.GPIO_ACT_INVENTORY Then
			lightSensorCombo.SelectedIndex = sensorConfig.lightAction
		Else
			lightSensorCombo.SelectedIndex = 0
		End If

		invTO.Value = hNur.InventoryTriggerTimeout
		ssTO.Value = hNur.ScanSingleTriggerTimeout
	End Sub

	Private Sub sensorControl_Changed(sender As Object, e As EventArgs)
		If disableEvents Then
			Return
		End If

		Try
			Dim sensorConfig As NurApi.SensorConfig = hNur.GetSensorConfig()

			sensorConfig.tapAction = tapSensorCombo.SelectedIndex
			sensorConfig.tapEnabled = tapSensorCombo.SelectedIndex > 0

			sensorConfig.lightAction = lightSensorCombo.SelectedIndex
			sensorConfig.lightEnabled = lightSensorCombo.SelectedIndex > 0

			hNur.SetSensorConfig(sensorConfig)

			hNur.InventoryTriggerTimeout = CInt(Math.Truncate(invTO.Value))
			hNur.ScanSingleTriggerTimeout = CInt(Math.Truncate(ssTO.Value))
		Catch ex As NurApiException
			MessageBox.Show(ex.ToString(), Program.appName, MessageBoxButtons.OK, MessageBoxIcon.[Error])
			Me.Enabled = False
		End Try
	End Sub

	Private Sub AddToEventList(msg As String)
		eventsList.Items.Add(msg)
		eventsList.SelectedIndex = eventsList.Items.Count - 1
	End Sub
End Class
