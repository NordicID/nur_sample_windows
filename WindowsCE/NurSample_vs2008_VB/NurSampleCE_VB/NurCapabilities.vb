Imports System.Collections.Generic
Imports System.Text

Imports NurApiDotNet
'NurApi wrapper
''' <summary>
''' NurCapabilities class
''' </summary>
Public NotInheritable Class NurCapabilities
    Const NA As String = "N/A"

    Public Structure NurCapabilityItem
        Public SetupFlag As Integer
        Public Value As Integer
        Public Text As String
        Public Overrides Function ToString() As String
            Return Text
        End Function
        Public Sub New(ByVal setupFlag__1 As Integer, ByVal value__2 As Integer, ByVal text__3 As String)
            SetupFlag = setupFlag__1
            Text = text__3
            Value = value__2
        End Sub
    End Structure

    ''' <summary>
    ''' The Handle of NurApi
    ''' </summary>
    Private hNur As NurApi = Nothing

    ''' <summary>
    ''' The local reader info
    ''' </summary>
    Private m_readerInfo As NurApi.ReaderInfo

    ''' <summary>
    ''' The current Device Capabilites
    ''' </summary>
    Private devCaps As NurApi.DeviceCapabilites

    ''' <summary>
    ''' Allocate ourselves.
    ''' We have a private constructor, so no one else can.
    ''' </summary>
    Shared ReadOnly instance As New NurCapabilities()

    ''' <summary>
    ''' Access NurCapabilities.Instance to get the singleton object.
    ''' Then call methods on that instance.
    ''' </summary>
    Public Shared ReadOnly Property I() As NurCapabilities
        Get
            Return instance
        End Get
    End Property

    ''' <summary>
    ''' This is a private constructor, meaning no outsiders have access.
    ''' </summary>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' Gets or sets the nur.
    ''' </summary>
    ''' <value>
    ''' The nur.
    ''' </value>
    Public Property Nur() As NurApi
        Get
            Return hNur
        End Get
        Set(ByVal value As NurApi)
            If hNur IsNot Nothing Then
                RemoveHandler hNur.ConnectedEvent, AddressOf hNur_ConnectedEvent
                RemoveHandler hNur.DisconnectedEvent, AddressOf hNur_DisconnectedEvent
            End If
            Me.hNur = Value
            If hNur IsNot Nothing Then
                AddHandler hNur.ConnectedEvent, New EventHandler(Of NurApi.NurEventArgs)(AddressOf hNur_ConnectedEvent)
                AddHandler hNur.DisconnectedEvent, New EventHandler(Of NurApi.NurEventArgs)(AddressOf hNur_DisconnectedEvent)
                hNur_ConnectedEvent(hNur, Nothing)
            End If
        End Set
    End Property

    ''' <summary>
    ''' Handles the ConnectedEvent event of the hNur control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="NurApi.NurEventArgs"/> instance containing the event data.</param>
    ''' <exception cref="System.NotImplementedException"></exception>
    Private Sub hNur_ConnectedEvent(ByVal sender As Object, ByVal e As NurApi.NurEventArgs)
        If hNur IsNot Nothing AndAlso hNur.IsConnected() Then
            Try
                ' Get the ReaderInfo
                m_readerInfo = hNur.GetReaderInfo()
            Catch generatedExceptionName As NurApiException
                ' Firmware may be too old so use the defaults
                m_readerInfo.name = NA
            End Try

            Try
                ' Get the Device Capabilites
                devCaps = hNur.GetDeviceCaps()
                If devCaps.txAttnStep = 3 Then
                    Throw New Exception("Firmware may be too old so use the defaults")
                End If
            Catch generatedExceptionName As Exception
                ' Firmware may be too old so use the defaults
                devCaps.maxTxmW = 500
                devCaps.maxTxdBm = 27
                devCaps.txAttnStep = 1
                devCaps.txSteps = 20
                devCaps.maxAnt = 4
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Handles the DisconnectedEvent event of the hNur control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="NurApi.NurEventArgs"/> instance containing the event data.</param>
    ''' <exception cref="System.NotImplementedException"></exception>
    Private Sub hNur_DisconnectedEvent(ByVal sender As Object, ByVal e As NurApi.NurEventArgs)
    End Sub

    ''' <summary>
    ''' Gets the reader info.
    ''' </summary>
    ''' <value>
    ''' The reader info.
    ''' </value>
    Public ReadOnly Property ReaderInfo() As NurApi.ReaderInfo
        Get
            Return m_readerInfo
        End Get
    End Property

    ''' <summary>
    ''' Gets the device capabilites.
    ''' </summary>
    ''' <value>
    ''' The device capabilites.
    ''' </value>
    Public ReadOnly Property DeviceCaps() As NurApi.DeviceCapabilites
        Get
            Return devCaps
        End Get
    End Property

    ''' <summary>
    ''' The Nur Capability items
    ''' </summary>
    ReadOnly nurItems As NurCapabilityItem() = New NurCapabilityItem() {New NurCapabilityItem(NurApi.SETUP_TXMOD, NurApi.TXMODULATION_ASK, "ASK"), New NurCapabilityItem(NurApi.SETUP_TXMOD, NurApi.TXMODULATION_PRASK, "PR-ASK"), New NurCapabilityItem(NurApi.SETUP_RXDEC, NurApi.RXDECODING_FM0, "FM-0"), New NurCapabilityItem(NurApi.SETUP_RXDEC, NurApi.RXDECODING_M2, "Miller-2"), New NurCapabilityItem(NurApi.SETUP_RXDEC, NurApi.RXDECODING_M4, "Miller-4"), New NurCapabilityItem(NurApi.SETUP_RXDEC, NurApi.RXDECODING_M8, "Miller-8"), _
     New NurCapabilityItem(NurApi.SETUP_SELECTEDANTENNA, NurApi.ANTENNAID_AUTOSELECT, "Auto Antenna"), New NurCapabilityItem(NurApi.SETUP_SELECTEDANTENNA, NurApi.ANTENNAID_1, "Antenna 1"), New NurCapabilityItem(NurApi.SETUP_SELECTEDANTENNA, NurApi.ANTENNAID_2, "Antenna 2"), New NurCapabilityItem(NurApi.SETUP_SELECTEDANTENNA, NurApi.ANTENNAID_3, "Antenna 3"), New NurCapabilityItem(NurApi.SETUP_SELECTEDANTENNA, NurApi.ANTENNAID_4, "Antenna 4"), New NurCapabilityItem(NurApi.SETUP_AUTOPERIOD, NurApi.NUR_AUTOPER_OFF, "Disabled"), _
     New NurCapabilityItem(NurApi.SETUP_AUTOPERIOD, NurApi.NUR_AUTOPER_25, "Max 1000 ms off"), New NurCapabilityItem(NurApi.SETUP_AUTOPERIOD, NurApi.NUR_AUTOPER_33, "Max 500 ms off"), New NurCapabilityItem(NurApi.SETUP_AUTOPERIOD, NurApi.NUR_AUTOPER_50, "Max 100 ms off")}

    Public Function ConvertToString(ByVal setupFlag As Integer, ByVal value As Integer) As String
        Select Case setupFlag
            Case NurApi.SETUP_INVQ, NurApi.SETUP_INVROUNDS
                If value = 0 Then
                    Return "Auto"
                End If
                Return value.ToString()

            Case NurApi.SETUP_INVEPCLEN
                If value = 255 Then
                    Return "Accept all"
                End If
                If value >= 2 AndAlso value <= 62 AndAlso value Mod 2 = 0 Then
                    Return String.Format("{0} bits, {1} bytes", value * 8, value)
                End If
                Throw New ArgumentException()

            Case NurApi.SETUP_LINKFREQ
                Return (value / 1000).ToString() + " kHz"

            Case NurApi.SETUP_REGION
                Return hNur.GetRegionInfo(value).name

            Case NurApi.SETUP_TXLEVEL
                If value = 0 Then
                    Return devCaps.maxTxmW.ToString() + " mW"
                Else
                    Dim dBm As Integer = devCaps.maxTxdBm - (value * devCaps.txAttnStep)
                    Dim mW As Integer = CInt(Math.Round(Math.Pow(10, CDbl(dBm) / 10)))
                    Return mW.ToString() + " mW"
                End If
            Case Else

                For n As Integer = 0 To nurItems.Length - 1
                    If nurItems(n).SetupFlag = setupFlag AndAlso nurItems(n).Value = value Then
                        Return nurItems(n).Text
                    End If
                Next
                Exit Select
        End Select
        Return value.ToString() + ": UNKNOWN VALUE"
    End Function
End Class
