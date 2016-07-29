Imports System.Drawing
Imports System.Collections
Imports System.Windows.Forms
Imports System.Data
Imports System.Threading
Imports System.Runtime.InteropServices

Imports NordicId

' The following example illustrates how to make a full screen application in C#.
' Call Init() and SetFullScreen(true) at startup
' and SetFullScreen(false) before closing the application.
Public NotInheritable Class Fullscreen
    Private Sub New()
    End Sub
    Public Structure RECT
        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer
    End Structure

    Public Const SPI_SETWORKAREA As Integer = 47
    Public Const SPI_GETWORKAREA As Integer = 48
    Public Const SPIF_UPDATEINIFILE As Integer = &H1

    <DllImport("coredll.dll")> _
    Public Shared Function SystemParametersInfo(ByVal uiAction As Integer, ByVal uiParam As Integer, ByRef pvParam As RECT, ByVal fWinIni As Integer) As Integer
    End Function

    <DllImport("coredll.dll")> _
    Public Shared Function SetRect(ByRef lprc As RECT, ByVal xLeft As Integer, ByVal yTop As Integer, ByVal xRight As Integer, ByVal yBottom As Integer) As Integer
    End Function

    <DllImport("coredll.dll")> _
    Public Shared Function MoveWindow(ByVal hWnd As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal bRepaint As Integer) As Integer
    End Function

    <DllImport("coredll.dll")> _
    Public Shared Function GetWindowRect(ByVal hWnd As IntPtr, ByRef lpRect As RECT) As Integer
    End Function

    <DllImport("coredll.dll")> _
    Private Shared Function GetSystemMetrics(ByVal smIndex As Integer) As Integer
    End Function

    Private Shared hWndTaskBar As UInteger = 0
    Private Shared rtDesktop As RECT
    Private Shared rtNewDesktop As RECT
    Private Shared rtTaskBar As RECT

    Public Shared Function Init() As Integer
        If (SystemParametersInfo(SPI_GETWORKAREA, 0, rtDesktop, 0) = 1) Then
            ' Successful obtain the system working area(Desktop)
            SetRect(rtNewDesktop, 0, 0, 240, 320)
        End If

        ' Find the Taskbar window handle
        hWndTaskBar = WIN32.FindWindow("HHTaskBar", Nothing)
        'Checking...
        If hWndTaskBar <> 0 Then
            'Get the original Input panel windowsize
            GetWindowRect(hWndTaskBar, rtTaskBar)
        End If
        Return 1
    End Function

    Public Shared Function SetFullScreen(ByVal mode As Boolean) As Integer
        If mode = True Then
            ' Update windows working area size
            SystemParametersInfo(SPI_SETWORKAREA, 0, rtNewDesktop, SPIF_UPDATEINIFILE)

            ' Hide the TaskBar
            If hWndTaskBar <> 0 Then
                MoveWindow(hWndTaskBar, 0, rtNewDesktop.bottom, (rtTaskBar.right - rtTaskBar.left), (rtTaskBar.bottom - rtTaskBar.top), 0)
            End If
        Else
            ' Update windows working area size
            SystemParametersInfo(SPI_SETWORKAREA, 0, rtDesktop, SPIF_UPDATEINIFILE)

            ' Restore theTaskBar
            If hWndTaskBar <> 0 Then
                MoveWindow(hWndTaskBar, rtTaskBar.left, rtTaskBar.top, (rtTaskBar.right - rtTaskBar.left), (rtTaskBar.bottom - rtTaskBar.top), 0)
            End If
        End If

        Return 1
    End Function
End Class
