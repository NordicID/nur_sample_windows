'=======================================================================================
'
'    Hand Held Utils for Nordic ID devices like Morphic and Merlin
'
'=======================================================================================

Imports System.Collections.Generic
Imports System.Text
Imports Microsoft.Win32
Imports NordicId

NotInheritable Class HHUtils
    Private Sub New()
    End Sub
    Private Shared lastKeepAliveTick As Integer = 0
    Private Shared userActivityEvent As IntPtr = IntPtr.Zero

    ''' <summary>
    ''' Keeps the device alive.
    ''' </summary>
    Public Shared Sub KeepDeviceAlive()
        ' Prevent unnecessary CPU load
        Dim tick As Integer = Environment.TickCount
        If tick - lastKeepAliveTick < 5000 Then
            Return
        End If
        lastKeepAliveTick = tick

        ' Create ActivityEvent if not exist
        If userActivityEvent = IntPtr.Zero Then
            Using key As RegistryKey = Registry.LocalMachine.OpenSubKey("System\GWE")
                Dim value As Object = key.GetValue("ActivityEvent")
                key.Close()
                If value Is Nothing Then
                    Return
                End If
                Dim activityEventName As String = DirectCast(value, String)
                userActivityEvent = WIN32.CreateEvent(IntPtr.Zero, False, False, activityEventName)
            End Using
        End If

        ' Signal user activity to the GWE and Backlight driver
        If userActivityEvent <> IntPtr.Zero Then
            WIN32.SetEvent(userActivityEvent)
        End If
    End Sub
End Class
