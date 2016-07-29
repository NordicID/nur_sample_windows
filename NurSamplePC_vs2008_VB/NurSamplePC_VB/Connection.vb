Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports NurApiDotNet

Public Partial Class Connection
	Inherits UserControl
	''' <summary>
	''' The NurApi handle
	''' </summary>
	Private hNur As NurApi = Nothing

	Private disableEvents As Boolean = False

	Private Class connectionComboItem
		Public DevPath As String
		Public Name As String
		Public Port As Integer
		Public Sub New(devPath As String, name As String, port As Integer)
			Me.DevPath = devPath
			Me.Name = name
			Me.Port = port
		End Sub
		Public Overrides Function ToString() As String
			Return Name
		End Function
	End Class

	''' <summary>
	''' Initializes a new instance of the <see cref="Connection"/> class.
	''' </summary>
	Public Sub New()
		InitializeComponent()
	End Sub

	Private Sub Connection_Load(sender As Object, e As EventArgs)
		usbCombo_Click(Me, EventArgs.Empty)
		serialCombo_Click(Me, EventArgs.Empty)
		'useLatestRadioBox.Checked = true;
		useUsbAutoRadioBox.Checked = True
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

			' Update the status of the connection
			If hNur.IsConnected() Then
				hNur_ConnectedEvent(hNur, Nothing)
			Else
				hNur_DisconnectedEvent(hNur, Nothing)
				conStatusDesc.Text = "No connection"
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
		conStatusDesc.Text = "Disconnected"
		UpdateButtons()
	End Sub

	''' <summary>
	''' Handles the ConnectedEvent event of the NUR module.
	''' </summary>
	''' <param name="sender">The source of the event.</param>
	''' <param name="e">The <see cref="NurApi.NurEventArgs" /> instance containing the event data.</param>
	Private Sub hNur_ConnectedEvent(sender As Object, e As NurApi.NurEventArgs)
		Dim hNur As NurApi = TryCast(sender, NurApi)
		conStatusDesc.Text = "Connected"
		UpdateButtons()
		Try
			Dim ethConfig As NurApi.EthConfig = hNur.GetEthConfig()
			tcpipAddr.Text = IpToString(ethConfig.ip)
			tcpipPort.Value = ethConfig.serverPort
				' Ignore this error
		Catch generatedExceptionName As NurApiException
		End Try
	End Sub

	Private Sub updateControls_CheckedChanged(sender As Object, e As EventArgs)
		If disableEvents Then
			Return
		End If

		usbCombo.Enabled = useUsbRadioBox.Checked
		serialCombo.Enabled = useSerialRadioBox.Checked
		tcpipAddr.Enabled = useTcpipRadioBox.Checked
		tcpipPort.Enabled = useTcpipRadioBox.Checked

		If hNur IsNot Nothing AndAlso useUsbAutoRadioBox Is sender Then
			hNur.SetUsbAutoConnect(useUsbAutoRadioBox.Checked)
		End If

		UpdateButtons()
	End Sub

	Private Sub usbCombo_Click(sender As Object, e As EventArgs)
		If hNur IsNot Nothing Then
			Dim ports As List(Of NurApi.UsbDevice) = NurApi.EnumerateUsbDevices()

			Dim currentSelection As Integer = usbCombo.SelectedIndex
			usbCombo.Items.Clear()
			For Each dev As NurApi.UsbDevice In ports
				usbCombo.Items.Add(New connectionComboItem(dev.devPath, dev.friendlyName, 0))
			Next
			If 0 <= currentSelection AndAlso currentSelection < usbCombo.Items.Count Then
				usbCombo.SelectedIndex = currentSelection
			Else
				usbCombo.SelectedIndex = usbCombo.Items.Count - 1
			End If
		End If
	End Sub

	Private Sub serialCombo_Click(sender As Object, e As EventArgs)
		If hNur IsNot Nothing Then
			Dim ports As List(Of NurApi.ComPort) = NurApi.EnumerateComPorts()

			Dim currentSelection As Integer = serialCombo.SelectedIndex
			serialCombo.Items.Clear()
			For Each port As NurApi.ComPort In ports
				serialCombo.Items.Add(New connectionComboItem("", port.friendlyName, port.port))
			Next
			If 0 <= currentSelection AndAlso currentSelection < serialCombo.Items.Count Then
				serialCombo.SelectedIndex = currentSelection
			Else
				serialCombo.SelectedIndex = serialCombo.Items.Count - 1
			End If
		End If
	End Sub

	Private Sub connectBtn_Click(sender As Object, e As EventArgs)
		Try
			If hNur.IsConnected() Then
				hNur.Disconnect()
			Else
				If useLatestRadioBox.Checked Then
					hNur.Connect()
				ElseIf useUsbAutoRadioBox.Checked Then
					hNur.SetUsbAutoConnect(False)
					hNur.SetUsbAutoConnect(True)
				ElseIf useUsbRadioBox.Checked Then
					Dim comboItem As connectionComboItem = TryCast(usbCombo.SelectedItem, connectionComboItem)
					hNur.ConnectUsb(comboItem.DevPath)
				ElseIf useSerialRadioBox.Checked Then
					Dim comboItem As connectionComboItem = TryCast(serialCombo.SelectedItem, connectionComboItem)
					hNur.ConnectSerialPort(comboItem.Port)
				ElseIf useTcpipRadioBox.Checked Then
					hNur.ConnectSocket(tcpipAddr.Text, CInt(Math.Truncate(tcpipPort.Value)))
				End If
			End If
		Catch ex As NurApiException
			MessageBox.Show(ex.ToString(), Program.appName, MessageBoxButtons.OK, MessageBoxIcon.[Error])
		End Try
	End Sub

	Private Shared Function IpToString(ip As Byte()) As String
		If ip Is Nothing Then
			Return System.Net.IPAddress.None.ToString()
		End If
		Dim ipAddress As New System.Net.IPAddress(ip)
		Return ipAddress.ToString()
	End Function

	Private Sub UpdateButtons()
		If hNur Is Nothing Then
			Return
		End If

		If hNur.IsConnected() Then
			connectBtn.Text = "DISCONNECT"
		Else
			connectBtn.Text = "CONNECT"
		End If
	End Sub
End Class
