Imports System.Collections.Generic
Imports System.Threading

Class BeeperInventory
    Implements IDisposable
    Private beepRate As Integer = 0
    Private beepOnce As Boolean = True
    Private beeperRunning As Boolean = False
    Private beeper As New Beeper()
    Private hBeeperThread As Thread = Nothing
    Private beepEvent As New AutoResetEvent(False)

    Public Sub New()
        ' Start Beeper thread
        beepRate = 0
        beeperRunning = True
        hBeeperThread = New Thread(AddressOf BeeperThread)
        hBeeperThread.IsBackground = True
        hBeeperThread.Priority = ThreadPriority.BelowNormal
        hBeeperThread.Start()
    End Sub

    Public Sub Dispose() Implements System.IDisposable.Dispose
        ' Stop and Exit Beeper thread
        beeperRunning = False
        beepEvent.[Set]()
    End Sub

    Public Sub Beep(ByVal beeps As Integer)
        beepRate = beeps
        beepEvent.[Set]()
    End Sub

    Public Sub Start()
        beepOnce = False
        beepEvent.[Set]()
    End Sub

    Public Sub [Stop]()
        beepOnce = True
        beepEvent.[Set]()
    End Sub

    Private Sub BeeperThread()
        While beeperRunning
            If beepRate > 0 Then
                If beepOnce Then
                    beepRate = 0
                Else
                    beepRate -= 1
                End If
                beeper.Hz = 2093
                beeper.Beep(50, False)
                Thread.Sleep(60)
                Continue While
            End If
            beepEvent.WaitOne()
        End While
        hBeeperThread = Nothing
    End Sub
End Class
