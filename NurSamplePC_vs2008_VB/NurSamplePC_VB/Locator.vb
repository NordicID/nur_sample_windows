Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms

Imports NurApiDotNet
'NurApi wrapper
Public Partial Class Locator
	Inherits UserControl
	''' <summary>
	''' The NurApi handle
	''' </summary>
	Private hNur As NurApi = Nothing

	''' <summary>
	''' Range of the signal
	''' </summary>
	Const NOSIGNAL As Integer = 0
	Const MAXSIGNAL As Integer = 100

	''' <summary>
	''' Locating parameters
	''' </summary>
	Const MAXTXPOWER As Integer = 0
	Const MINTXPOWER As Integer = 4
	Const PWRSLOWSTEPS As Integer = 1
	Const PWRFASTSTEPS As Integer = 2
	Const PWRDWNLEVEL As Integer = 70
	Const PWRUPDLEVEL As Integer = 40
	Const ZEROFILTER As Integer = 1

	''' <summary>
	''' Containen for signals
	''' </summary>
	Private locatingSignal As SignalStrength = Nothing

	''' <summary>
	''' Locator variables
	''' </summary>
	Shared IsRunning As Boolean = False
	Private keepLocating As Boolean = False

	Private Structure LocatorComboBoxItem
		Shared ReadOnly bankTexts As String() = {"PSWD:", "EPC:", "TID:", "USER:"}
		Public Bank As Integer
		Public Address As Integer
		Public Mask As String
		Public Name As String
		Public Overrides Function ToString() As String
			If Mask.Length > 0 Then
				Return String.Format("{0} [{1} {2}]", Name, bankTexts(Bank), Mask)
			End If
			Return Name
		End Function
		Public ReadOnly Property BankName() As String
			Get
				Return bankTexts(Bank)
			End Get
		End Property
		Public Sub New(bank__1 As Integer, address__2 As Integer, mask__3 As String, name__4 As String)
			Bank = bank__1
			Address = address__2
			Mask = mask__3
			Name = name__4
		End Sub
	End Structure

	Shared ReadOnly comboItems As LocatorComboBoxItem() = New LocatorComboBoxItem() {New LocatorComboBoxItem(NurApi.BANK_PASSWD, 0, "", "PASSWD MEM"), New LocatorComboBoxItem(NurApi.BANK_EPC, 32, "", "EPC CODE"), New LocatorComboBoxItem(NurApi.BANK_TID, 0, "", "TID MEM"), New LocatorComboBoxItem(NurApi.BANK_USER, 0, "", "USER MEM"), New LocatorComboBoxItem(NurApi.BANK_TID, 0, "E2001050", "Monza 1a"), New LocatorComboBoxItem(NurApi.BANK_TID, 0, "E2001093", "Monza 3"), _
		New LocatorComboBoxItem(NurApi.BANK_TID, 0, "E2801100", "Monza 4D"), New LocatorComboBoxItem(NurApi.BANK_TID, 0, "E2801104", "Monza 4U"), New LocatorComboBoxItem(NurApi.BANK_TID, 0, "E2801105", "Monza 4QT"), New LocatorComboBoxItem(NurApi.BANK_TID, 0, "E280110C", "Monza 4E"), New LocatorComboBoxItem(NurApi.BANK_TID, 0, "E2801130", "Monza 5"), New LocatorComboBoxItem(NurApi.BANK_TID, 0, "E2801160", "Monza R6"), _
		New LocatorComboBoxItem(NurApi.BANK_TID, 0, "E2003411", "Higgs-2"), New LocatorComboBoxItem(NurApi.BANK_TID, 0, "E2003412", "Higgs-3"), New LocatorComboBoxItem(NurApi.BANK_TID, 0, "E2003414", "Higgs-4"), New LocatorComboBoxItem(NurApi.BANK_TID, 0, "E2006003", "NXP G2XM"), New LocatorComboBoxItem(NurApi.BANK_TID, 0, "E2006004", "NXP G2XL"), New LocatorComboBoxItem(NurApi.BANK_TID, 0, "E2006806", "NXP G2iL"), _
		New LocatorComboBoxItem(NurApi.BANK_TID, 0, "E2006807", "NXP G2iL+"), New LocatorComboBoxItem(NurApi.BANK_TID, 0, "E2806810", "NXP UCODE 7"), New LocatorComboBoxItem(NurApi.BANK_TID, 0, "E280B040", "EMM EM4325")}

	Private selectedComboItem As LocatorComboBoxItem
	Private traceEPC As Byte() = Nothing

	''' <summary>
	''' Initializes a new instance of the <see cref="Locator" /> class.
	''' </summary>
	Public Sub New()
		InitializeComponent()
		Me.Enabled = False

		locatingSignal = New SignalStrength()
		locatingSignal.ZeroFilter = ZEROFILTER
		' Configure Locator bar
		locatorBar.Minimum = 0
		locatorBar.Maximum = MAXSIGNAL
		' Initialize ComboBox
		bankCombo.Items.Clear()
		For n As Integer = 0 To comboItems.Length - 1
			bankCombo.Items.Add(comboItems(n))
		Next
		bankCombo.SelectedIndex = 1
	End Sub

	''' <summary> 
	''' Clean up any resources being used.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(disposing As Boolean)
		StopLocating()
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
		Me.Enabled = True
	End Sub

	''' <summary>
	''' Handles the Click event of the refreshBtn control.
	''' </summary>
	''' <param name="sender">The source of the event.</param>
	''' <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
	Private Sub refreshBtn_Click(sender As Object, e As EventArgs)
		' Clear Tag List
		tagListView.ClearTagList()
		' Clear previously inventoried tags from memory
		hNur.ClearTags()
		' Perform simple inventory
		For i As Integer = 0 To 2
			hNur.SimpleInventory()
			' Fetch tags from module, including tag meta
			Dim inventoriedTags As NurApi.TagStorage = hNur.FetchTags(True)
			' Update Tag List
			tagListView.UpdateTagList(inventoriedTags)
		Next
	End Sub

	''' <summary>
	''' Handles the SelectedTagChanged event of the tagListView control.
	''' </summary>
	''' <param name="sender">The source of the event.</param>
	''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
	Private Sub tagListView_SelectedTagChanged(sender As Object, e As EventArgs)
		Dim selectedTag As NurApi.Tag = tagListView.SelectedTag
		If selectedTag IsNot Nothing Then
			Try
				If selectedComboItem.Mask.Length > 0 Then
					' Return Combo to EPC state
					bankCombo.SelectedIndex = 1
				End If

				If selectedComboItem.Bank = NurApi.BANK_EPC Then
					tagToLocate.Text = selectedTag.GetEpcString()
				Else
					Dim epcString As String = selectedTag.GetEpcString()
					Dim epcBytes As Byte() = NurApi.HexStringToBin(epcString)
					Dim bankBytes As Byte() = NurUtils.ReadBankByEpc(hNur, 0, False, epcBytes, CByte(selectedComboItem.Bank), CUInt(selectedComboItem.Address), _
						0, 0)
					tagToLocate.Text = NurApi.BinToHexString(bankBytes)
				End If
			Catch generatedExceptionName As Exception
				tagToLocate.Text = "Could not read the bank"
			End Try
		End If
	End Sub

	''' <summary>
	''' Handles the SelectedIndexChanged event of the bankCombo control.
	''' </summary>
	''' <param name="sender">The source of the event.</param>
	''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
	Private Sub bankCombo_SelectedIndexChanged(sender As Object, e As EventArgs)
		If bankCombo.SelectedIndex >= 0 Then
			selectedComboItem = CType(bankCombo.SelectedItem, LocatorComboBoxItem)
			If selectedComboItem.Mask.Length > 0 Then
				tagToLocate.Text = selectedComboItem.Mask
			End If
			bankLabel.Text = selectedComboItem.BankName
		End If
	End Sub

	''' <summary>
	''' Handles the TextChanged event of the tagToLocate control.
	''' </summary>
	''' <param name="sender">The source of the event.</param>
	''' <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
	Private Sub tagToLocate_TextChanged(sender As Object, e As EventArgs)
		Try
			traceEPC = NurApi.HexStringToBin(tagToLocate.Text)
			locateBtn.Enabled = True
		Catch generatedExceptionName As Exception
			' Stop Locator
			StopLocating()
			locateBtn.Enabled = False
			locateBtn.Text = "Locate"
			traceEPC = Nothing
		End Try
	End Sub

	''' <summary>
	''' Handles the Click event of the locateBtn control.
	''' </summary>
	''' <param name="sender">The source of the event.</param>
	''' <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
	Private Sub locateBtn_Click(sender As Object, e As EventArgs)
		If updateTimer.Enabled Then
			' Stop Locator
			StopLocating()
			locateBtn.Text = "Locate"
		Else
			' Start Locator
			locateBtn.Text = "Stop"
			StartLocating()
		End If
	End Sub

	Private updTxLevel As Integer = -1
	Private updScaledRSSI As Integer = -1
	Private updInTheField As Boolean = False
	''' <summary>
	''' Handles the Tick event of the updateTimer control.
	''' </summary>
	''' <param name="sender">The source of the event.</param>
	''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
	Private Sub updateTimer_Tick(sender As Object, e As EventArgs)
		Dim updateIndicators As Boolean = False
		Dim signal As SignalStrength.Signal = locatingSignal.GetSignal()
		Dim inTheField As Boolean = signal.scaledRssi > 0

		If updTxLevel <> signal.txLevelReal Then
			' Update new Tx Level
			updateIndicators = True
			txLevelTxt.Text = [String].Format("TX Level: {0}", NurCapabilities.I.ConvertToString(NurApi.SETUP_TXLEVEL, signal.txLevelReal))
			updTxLevel = signal.txLevelReal
		End If

		If updScaledRSSI <> signal.scaledRssi Then
			' Update new RSSI Level
			updateIndicators = True
			If signal.scaledRssi > NOSIGNAL Then
				rssiLevelTxt.Text = [String].Format("RSSI: {0}% {1}dBm", signal.scaledRssi, signal.rssi)
			Else
				rssiLevelTxt.Text = "RSSI: no signal"
			End If
			' Update indicators
			locatorBar.Value = signal.scaledRssi
			updScaledRSSI = signal.scaledRssi
		End If

		If updateIndicators Then
			updInTheField = inTheField
		End If

		If Not IsRunning Then
			updateTimer.Enabled = False
		End If
	End Sub

	''' <summary>
	''' Starts the locating.
	''' </summary>
	''' <returns>true if succeed</returns>
	Private Function StartLocating() As Boolean
		' Is EPC valid or Locator running
		If traceEPC Is Nothing Then
			Return False
		End If
		If IsRunning Then
			Return False
		End If
		' Initialize locator
		IsRunning = True
		keepLocating = True
		updTxLevel = -1
		updScaledRSSI = -1
		locatingSignal.NumberOfAntennas = hNur.GetReaderInfo().numAntennas
		' Start beeper and so on 
		updateTimer.Enabled = True
		' Create and start Locator thread
		Dim locateThread__1 As New Thread(AddressOf LocateThread)
		locateThread__1.IsBackground = True
		locateThread__1.Start()
		Return True
	End Function

	''' <summary>
	''' Stops the tag locator.
	''' </summary>
	''' <returns>true if succeed</returns>
	Private Function StopLocating() As Boolean
		' Is Locator running
		If Not IsRunning Then
			Return False
		End If
		' Stop Locator thread
		Dim killCounter As Integer = 20
		keepLocating = False
		While IsRunning AndAlso System.Math.Max(System.Threading.Interlocked.Decrement(killCounter),killCounter + 1) <> 0
			Thread.Sleep(50)
		End While
		Return killCounter <> 0
	End Function

	''' <summary>
	''' Tag Locator.
	''' </summary>
	Private Sub LocateThread()
		Dim originalTxLevel As Integer = 0
		Dim originalAntenna As Integer = 0
		Dim antenna As Integer = 0
		Dim lastTxLevel As Integer = -1
		' Get original settings
		Try
			originalTxLevel = hNur.TxLevel
			originalAntenna = hNur.SelectedAntenna
		Catch
		End Try

		' Locating loop
		While keepLocating
			Try
				' Select antenna
				hNur.SelectedAntenna = antenna
				' Set new txLevel if necessary 
				If lastTxLevel <> locatingSignal.signals(antenna).txLevelSuggestion Then
					' Set new TxLevel
					hNur.TxLevel = locatingSignal.signals(antenna).txLevelSuggestion
					' Read the TxLevel back, because the Reagion setting may change it
					lastTxLevel = InlineAssignHelper(locatingSignal.signals(antenna).txLevelReal, hNur.TxLevel)
				End If
				' Trace tag
				Dim tagdata As NurApi.TraceTagData
				tagdata = hNur.TraceTag(CByte(selectedComboItem.Bank), CUInt(selectedComboItem.Address), traceEPC.Length * 8, traceEPC, NurApi.TRACETAG_NO_EPC)
				' Set new level
				locatingSignal.SetSignal(antenna, tagdata.scaledRssi, tagdata.rssi, lastTxLevel)
			Catch generatedExceptionName As NurApiException
				' Program jumps here if TraceTag not found a tag
				locatingSignal.SetSignal(antenna, 0, -128, lastTxLevel)
			End Try

			' More antennas?
			If System.Threading.Interlocked.Increment(antenna) < locatingSignal.NumberOfAntennas Then
				Continue While
			Else
				antenna = 0
			End If

			' Get new txLevel
			For ant As Integer = 0 To locatingSignal.signals.Length - 1
				' Calc new TxLevel
				Dim newTxLevel As Integer = locatingSignal.signals(ant).txLevelReal
				If locatingSignal.signals(ant).scaledRssi >= MAXSIGNAL Then
					newTxLevel += PWRFASTSTEPS
				ElseIf locatingSignal.signals(ant).scaledRssi >= PWRDWNLEVEL Then
					newTxLevel += PWRSLOWSTEPS
				ElseIf locatingSignal.signals(ant).scaledRssi <= NOSIGNAL Then
					newTxLevel -= PWRFASTSTEPS
				ElseIf locatingSignal.signals(ant).scaledRssi <= PWRUPDLEVEL Then
					newTxLevel -= PWRSLOWSTEPS
				End If
				' Check the TxLevel
				If newTxLevel < MAXTXPOWER Then
					newTxLevel = MAXTXPOWER
				ElseIf newTxLevel > MINTXPOWER Then
					newTxLevel = MINTXPOWER
				End If
				' Set new TxLevel
				locatingSignal.signals(ant).txLevelSuggestion = newTxLevel
			Next
		End While
		' Restore original settings
		Try
			hNur.TxLevel = originalTxLevel
			hNur.SelectedAntenna = originalAntenna
		Catch
		End Try
		IsRunning = False
	End Sub
	Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
		target = value
		Return value
	End Function
End Class

Class SignalStrength
	Public Structure Signal
		Public rssi As Integer
		Public scaledRssi As Integer
		Public noSigCnt As Integer
		Public txLevelReal As Integer
		Public txLevelSuggestion As Integer
	End Structure

	Public signals As Signal() = New Signal(0) {}

	Public Property NumberOfAntennas() As Integer
		Get
			Return signals.Length
		End Get
		Set
			signals = New Signal(value - 1) {}
			For ant As Integer = 0 To signals.Length - 1
				signals(ant).scaledRssi = 0
				signals(ant).rssi = 0
				signals(ant).noSigCnt = 0
				signals(ant).txLevelReal = 0
				signals(ant).txLevelSuggestion = 0
			Next
		End Set
	End Property

	Public ZeroFilter As Integer = 0

	Public Sub SetSignal(antenna As Integer, scaledRssi As Integer, rssi As Integer, txlevel As Integer)
		signals(antenna).txLevelReal = txlevel
		If scaledRssi <= 0 Then
			If System.Threading.Interlocked.Increment(signals(antenna).noSigCnt) > ZeroFilter Then
				signals(antenna).scaledRssi = scaledRssi
				signals(antenna).rssi = rssi
			End If
		Else
			signals(antenna).noSigCnt = 0
			signals(antenna).scaledRssi = scaledRssi
			signals(antenna).rssi = rssi
		End If
	End Sub

	Public Function GetSignal() As Signal
		Dim maxSignal As Integer = 0
		Dim antenna As Integer = 0
		For ant As Integer = 0 To signals.Length - 1
			If maxSignal < signals(ant).scaledRssi Then
				antenna = ant
			End If
		Next
		Return signals(antenna)
	End Function
End Class
