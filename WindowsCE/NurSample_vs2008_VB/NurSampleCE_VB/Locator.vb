Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms

Imports NurApiDotNet
'NurApi wrapper
Partial Public Class Locator
    Inherits UserControl
    ''' <summary>
    ''' The NurApi handle
    ''' </summary>
    Private hNur As NurApi = Nothing

    ''' <summary>
    ''' The locator beeper
    ''' </summary>
    Private beeperLocator As New BeeperLocator()

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

    Private Structure LocatorFilter
        Shared ReadOnly bankTexts As String() = {"PSWD:", "EPC:", "TID:", "USER:"}
        Public Bank As Integer
        Public Address As Integer
        Public Length As Integer
        Public Mask As Byte()
        Public Name As String
        Public GenerateName As Boolean
        Public Overrides Function ToString() As String
            If GenerateName Then
                Return String.Format("{0} [{1} 0x{2}, {3}/{4}]", Name, bankTexts(Bank), NurApi.BinToHexString(Mask), Address, Length)
            End If
            Return Name
        End Function
        Public ReadOnly Property BankName() As String
            Get
                Return bankTexts(Bank)
            End Get
        End Property
        Public Sub New(ByVal bank__1 As Integer, ByVal address__2 As Integer, ByVal mask__3 As String, ByVal name__4 As String)
            Bank = bank__1
            Address = address__2
            Length = mask__3.Length * 4
            If mask__3.Length Mod 2 <> 0 Then
                mask__3 += "0"
            End If
            Mask = NurApi.HexStringToBin(mask__3)
            Name = name__4
            GenerateName = True
        End Sub
        Public Sub New(ByVal bank__1 As Integer, ByVal address__2 As Integer, ByVal mask__3 As String, ByVal name__4 As String, ByVal generateName__5 As Boolean)
            Bank = bank__1
            Address = address__2
            Length = mask__3.Length * 4
            If mask__3.Length Mod 2 <> 0 Then
                mask__3 += "0"
            End If
            Mask = NurApi.HexStringToBin(mask__3)
            Name = name__4
            GenerateName = generateName__5
        End Sub
        Public Sub New(ByVal bank__1 As Integer, ByVal address__2 As Integer, ByVal mask__3 As String, ByVal trim As Boolean, ByVal name__4 As String, ByVal generateName__5 As Boolean)
            Bank = bank__1
            Address = address__2
            Length = mask__3.Length * 4
            If mask__3.Length Mod 2 <> 0 Then
                mask__3 += "0"
            End If
            Mask = NurApi.HexStringToBin(mask__3)
            If trim Then
                Mask = Utils.ShiftLeft(Mask, address__2 Mod 8)
                Length -= address__2 Mod 8
            End If
            Name = name__4
            GenerateName = generateName__5
        End Sub
        Public Sub New(ByVal bank__1 As Integer, ByVal address__2 As Integer, ByVal length__3 As Integer, ByVal mask__4 As String, ByVal name__5 As String)
            Bank = bank__1
            Address = address__2
            Length = length__3
            If mask__4.Length Mod 2 <> 0 Then
                mask__4 += "0"
            End If
            Mask = NurApi.HexStringToBin(mask__4)
            Name = name__5
            GenerateName = True
        End Sub
    End Structure

    Shared ReadOnly comboItems As LocatorFilter() = New LocatorFilter() {New LocatorFilter(NurApi.BANK_PASSWD, 0, "", "Reserved MEM", False), New LocatorFilter(NurApi.BANK_EPC, 32, "", "EPC CODE", False), New LocatorFilter(NurApi.BANK_TID, 0, "", "TID MEM", False), New LocatorFilter(NurApi.BANK_USER, 0, "", "User MEM", False), New LocatorFilter(NurApi.BANK_TID, 9, "003", True, "Alien Technology", False), New LocatorFilter(NurApi.BANK_TID, 0, "E2003411", " Higgs-2"), _
     New LocatorFilter(NurApi.BANK_TID, 0, "E2003412", " Higgs-3"), New LocatorFilter(NurApi.BANK_TID, 0, "E2003414", " Higgs-4"), New LocatorFilter(NurApi.BANK_TID, 9, "005", True, "Atmel", False), New LocatorFilter(NurApi.BANK_TID, 9, "012", True, "CAEN RFID srl", False), New LocatorFilter(NurApi.BANK_TID, 9, "018", True, "Ceitec S.A.", False), New LocatorFilter(NurApi.BANK_TID, 9, "01F", True, "Chipus Microelectronics", False), _
     New LocatorFilter(NurApi.BANK_TID, 9, "019", True, "CPA Wernher von Braun", False), New LocatorFilter(NurApi.BANK_TID, 9, "00B", True, "EM Microelectronics", False), New LocatorFilter(NurApi.BANK_TID, 0, "E280B040", " EM4325"), New LocatorFilter(NurApi.BANK_TID, 9, "008", True, "EP Microelectronics", False), New LocatorFilter(NurApi.BANK_TID, 9, "014", True, "Federal Electric Corp.", False), New LocatorFilter(NurApi.BANK_TID, 9, "010", True, "Fujitsu", False), _
     New LocatorFilter(NurApi.BANK_TID, 9, "023", True, "Gate Elektronik", False), New LocatorFilter(NurApi.BANK_TID, 9, "001", True, "Impinj", False), New LocatorFilter(NurApi.BANK_TID, 0, "E2001050", " Monza 1a"), New LocatorFilter(NurApi.BANK_TID, 0, "E2001093", " Monza 3"), New LocatorFilter(NurApi.BANK_TID, 0, "E2801100", " Monza 4D"), New LocatorFilter(NurApi.BANK_TID, 0, "E2801104", " Monza 4U"), _
     New LocatorFilter(NurApi.BANK_TID, 0, "E2801105", " Monza 4QT"), New LocatorFilter(NurApi.BANK_TID, 0, "E280110C", " Monza 4E"), New LocatorFilter(NurApi.BANK_TID, 0, "E2801130", " Monza 5"), New LocatorFilter(NurApi.BANK_TID, 0, "E2801160", " Monza R6"), New LocatorFilter(NurApi.BANK_TID, 9, "004", True, "Intelleflex", False), New LocatorFilter(NurApi.BANK_TID, 9, "01C", True, "Invengo", False), _
     New LocatorFilter(NurApi.BANK_TID, 9, "01D", True, "Kiloway", False), New LocatorFilter(NurApi.BANK_TID, 9, "01E", True, "Longjing Microelectronics Co. Ltd.", False), New LocatorFilter(NurApi.BANK_TID, 9, "011", True, "LSIS", False), New LocatorFilter(NurApi.BANK_TID, 9, "021", True, "Maintag", False), New LocatorFilter(NurApi.BANK_TID, 9, "009", True, "Motorola (formerly Symbol Technologies)", False), New LocatorFilter(NurApi.BANK_TID, 9, "00D", True, "Mstar", False), _
     New LocatorFilter(NurApi.BANK_TID, 9, "01B", True, "Nationz", False), New LocatorFilter(NurApi.BANK_TID, 9, "006", True, "NXP Semiconductors", False), New LocatorFilter(NurApi.BANK_TID, 0, "E2006003", " G2XM"), New LocatorFilter(NurApi.BANK_TID, 0, "E2006004", " G2XL"), New LocatorFilter(NurApi.BANK_TID, 0, "E2006806", " G2iL"), New LocatorFilter(NurApi.BANK_TID, 0, "E2006807", " G2iL+"), _
     New LocatorFilter(NurApi.BANK_TID, 0, "E2806810", " UCODE 7"), New LocatorFilter(NurApi.BANK_EPC, &H20F, 1, "80", " PSF bit"), New LocatorFilter(NurApi.BANK_TID, 9, "015", True, "ON Semiconductor", False), New LocatorFilter(NurApi.BANK_TID, 9, "020", True, "ORIDAO", False), New LocatorFilter(NurApi.BANK_TID, 9, "013", True, "Productivity Engineering Gesellschaft fuer IC Design mbH", False), New LocatorFilter(NurApi.BANK_TID, 9, "00F", True, "Quanray Electronics", False), _
     New LocatorFilter(NurApi.BANK_TID, 9, "016", True, "Ramtron", False), New LocatorFilter(NurApi.BANK_TID, 9, "00C", True, "Renesas Technology Corp.", False), New LocatorFilter(NurApi.BANK_TID, 9, "024", True, "RFMicron, Inc.", False), New LocatorFilter(NurApi.BANK_TID, 9, "025", True, "RST-Invent LLC", False), New LocatorFilter(NurApi.BANK_TID, 9, "00A", True, "Sentech Snd Bhd", False), New LocatorFilter(NurApi.BANK_TID, 9, "007", True, "ST Microelectronics", False), _
     New LocatorFilter(NurApi.BANK_TID, 9, "017", True, "Tego", False), New LocatorFilter(NurApi.BANK_TID, 9, "002", True, "Texas Instruments", False), New LocatorFilter(NurApi.BANK_TID, 9, "01A", True, "TransCore", False), New LocatorFilter(NurApi.BANK_TID, 9, "00E", True, "Tyco International", False), New LocatorFilter(NurApi.BANK_TID, 9, "022", True, "Yangzhou Daoyuan Microelectronics Co. Ltd", False)}

    Private selectedComboItem As LocatorFilter
    Private locatorTarget As New LocatorFilter()

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
        ' Configure beeper
        beeperLocator.MaxLevel = MAXSIGNAL
        ' Initialize ComboBox
        bankCB.SelectedIndex = NurApi.BANK_EPC
        presetListBox.Items.Clear()
        For n As Integer = 0 To comboItems.Length - 1
            presetListBox.Items.Add(comboItems(n))
        Next
        presetListBox.SelectedIndex = 1
    End Sub

    ''' <summary> 
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        StopLocating()
        If disposing AndAlso (beeperLocator IsNot Nothing) Then
            beeperLocator.Dispose()
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
    ''' Handles the Click event of the refreshBtn control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    Private Sub refreshBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
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
    Private Sub tagListView_SelectedTagChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim selectedTag As NurApi.Tag = tagListView.SelectedTag
        If selectedTag IsNot Nothing Then
            ' Unselect preset list.
            presetListBox.SelectedIndex = -1
            ' Set EPC to target.
            bankCB.SelectedIndex = NurApi.BANK_EPC
            startUD.Value = 32
            tagToLocate.Text = selectedTag.GetEpcString()
            lengthUD.Value = tagToLocate.Text.Length * 4
        End If
    End Sub

    ''' <summary>
    ''' Handles the SelectedIndexChanged event of the bankCombo control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub presetListBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        If presetListBox.SelectedIndex >= 0 Then
            selectedComboItem = CType(presetListBox.SelectedItem, LocatorFilter)
            bankCB.SelectedIndex = selectedComboItem.Bank
            startUD.Value = selectedComboItem.Address
            lengthUD.Value = selectedComboItem.Length
            tagToLocate.Text = NurApi.BinToHexString(selectedComboItem.Mask)
        End If
    End Sub

    ''' <summary>
    ''' Handles the Click event of the locateBtn control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    Private Sub locateBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
        If updateTimer.Enabled Then
            ' Stop Locator
            StopLocating()
            locateBtn.Text = "Locate"
        Else
            ' Start Locator
            tabControl1.SelectedIndex = 2
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
    Private Sub updateTimer_Tick(ByVal sender As Object, ByVal e As EventArgs)
        'Keepd device alive
        HHUtils.KeepDeviceAlive()
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
            ' Update indicators
            beeperLocator.Beep(signal.scaledRssi, inTheField <> updInTheField)
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
        ' Set a new target
        locatorTarget.Bank = bankCB.SelectedIndex
        locatorTarget.Address = CInt(startUD.Value)
        locatorTarget.Length = CInt(lengthUD.Value)
        locatorTarget.Mask = NurApi.HexStringToBin(tagToLocate.Text)
        ' Is Locator running
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
        beeperLocator.Start()
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
    Public Function StopLocating() As Boolean
        ' Is Locator running
        If Not IsRunning Then
            Return False
        End If
        ' Stop beeper and so on 
        beeperLocator.[Stop]()
        ' Stop Locator thread
        Dim killCounter As Integer = 20
        keepLocating = False
        While IsRunning AndAlso System.Math.Max(System.Threading.Interlocked.Decrement(killCounter), killCounter + 1) <> 0
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
                tagdata = hNur.TraceTag(CByte(locatorTarget.Bank), CUInt(locatorTarget.Address), CInt(locatorTarget.Length), locatorTarget.Mask, NurApi.TRACETAG_NO_EPC)
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
    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
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
        Set(ByVal value As Integer)
            signals = New Signal(Value - 1) {}
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

    Public Sub SetSignal(ByVal antenna As Integer, ByVal scaledRssi As Integer, ByVal rssi As Integer, ByVal txlevel As Integer)
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
