'=======================================================================================
'
'    Hand Held Scan & Trigger -button utils for Nordic ID devices
'    like a Morphic and Merlin.
'
'=======================================================================================

Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports NordicId

NotInheritable Class HHScanButton
    Private Sub New()
    End Sub
    Public Enum SCANMODE As Integer
        UNKNOWN = -1
        NONE = 0
        BARCODE = 1
        RFID = 2
    End Enum

    ''' <summary>
    ''' Configures the SCAN -button from keaboard and
    ''' Merlin's pistol grip TRIGGER -button.
    ''' </summary>
    Public Shared Sub ConfigureScanButtons(ByVal keyCode As Keys)
        Try
            ' Configure SCAN -button from keaboard
            Dim hKeyb As New MHLDriver("Keyboard")
            If hKeyb.IsOpen() Then
                ' Save current keyboard map
                hKeyb.SaveProfile("NurSample")
                ' Ensure that "Scan" button is mapped correctly
                hKeyb.SetDword("SpecialKey.Scan.All.VK", CUInt(keyCode))
                ' Reload map
                hKeyb.SetDword("Keyboard.Reload", 1)
            End If
            ' Ignore if not existing
        Catch
        End Try

        Try
            ' Configure TRIGGER -button from Merlins pistol grip
            Dim hTrigger As New MHLDriver("TriggerButton")
            If hTrigger.IsOpen() Then
                ' Save the current Trigger -button map
                hTrigger.SaveProfile("NurSample")
                ' Ensure that "Trigger" button is mapped correctly
                hTrigger.SetDword("Trigger.VirtualKey", CUInt(keyCode))
            End If
            ' Ignore if not existing
        Catch
        End Try
    End Sub

    ''' <summary>
    ''' Restore the SCAN -button from keaboard and
    ''' Merlin's pistol grip TRIGGER -button
    ''' </summary>
    Public Shared Sub RestoreScanButtons()
        Try
            ' Restore SCAN -button from keaboard
            Dim hKeyb As New MHLDriver("Keyboard")
            If hKeyb.IsOpen() Then
                ' Restore saved profile and close driver
                hKeyb.LoadProfile("NurSample")
                ' Reload map
                hKeyb.SetDword("Keyboard.Reload", 1)
            End If
            ' Ignore if not existing
        Catch
        End Try

        Try
            ' Restore TRIGGER -button from Merlins pistol grip
            Dim hTrigger As New MHLDriver("TriggerButton")
            If hTrigger.IsOpen() Then
                ' Restore saved profile and close driver
                hTrigger.LoadProfile("NurSample")
            End If
            ' Ignore if not existing
        Catch
        End Try
    End Sub

    ''' <summary>
    ''' Gets or sets the scan button mode.
    ''' 0 = No operation
    ''' 1 = Scanner.ScanAsync
    ''' 2 = RFID.ScanAsync
    ''' </summary>
    ''' <value>
    ''' The scan button mode.
    ''' </value>
    ''' <exception cref="System.ApplicationException">Invalid ScanMode</exception>
    Public Shared Property ScanButtonMode() As SCANMODE
        Get
            Dim hKeyb As New MHLDriver("Keyboard")
            If hKeyb.IsOpen() Then
                Return CType(hKeyb.GetDword("Keyboard.ScanMode"), SCANMODE)
            Else
                Return SCANMODE.UNKNOWN
            End If
        End Get
        Set(ByVal value As SCANMODE)
            Dim hKeyb As New MHLDriver("Keyboard")
            If hKeyb.IsOpen() Then
                ' Set ScanMode 0 = No operation
                ' Set ScanMode 1 = Scanner.ScanAsync
                ' Set ScanMode 2 = RFID.ScanAsync
                hKeyb.SetDword("Keyboard.ScanMode", CUInt(Value))
            End If
        End Set
    End Property

    ''' <summary>
    ''' Barcode / RFID scanned.
    ''' </summary>
    ''' <param name="scanResult">The scan result.</param>
    Private Shared Sub DummyResultDelegate(ByVal scanResult As String)
    End Sub

    ''' <summary>
    ''' Registered hotkey clicked
    ''' </summary>
    ''' <param name="vk">The vk.</param>
    Private Shared Sub DummyHotkeyHandler(ByVal vk As Integer)
        ' Make sure it's NordicId.VK.SCAN
        If vk = CInt(NordicId.VK.SCAN) Then
        End If
    End Sub
End Class
