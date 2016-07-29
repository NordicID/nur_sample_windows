Imports System.Collections.Generic
Imports System.Threading

Class BeeperLocator
    Implements IDisposable
    Private m_maxLevel As Integer = 100
    Private beeperRate As Integer = 0
    Private beeperStopped As Boolean = True
    Private beeperRunning As Boolean = False
    Private beeper As New Beeper()
    Private hBeeperThread As Thread = Nothing
    Private beepEvent As New ManualResetEvent(False)

    Public Sub New()
        ' Start Beeper thread
        beeperRate = 0
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

    Public Sub Beep(ByVal level As Integer, ByVal force As Boolean)
        beeperRate = (level * 100) / m_maxLevel
        If force Then
            beepEvent.[Set]()
        End If
    End Sub

    Public Property MaxLevel() As Integer
        Get
            Return m_maxLevel
        End Get
        Set(ByVal value As Integer)
            m_maxLevel = value
        End Set
    End Property

    Public Sub Start()
        beeperStopped = False
        beepEvent.[Set]()
    End Sub

    Public Sub [Stop]()
        beeperStopped = True
        beepEvent.[Set]()
    End Sub

    Private Sub BeeperThread()
        While beeperRunning
            beepEvent.Reset()
            If beeperStopped Then
                ' State: Stopped
                beepEvent.WaitOne()
            Else
                ' State: Locating
                If beeperRate > 0 Then
                    ' Tag in the range
                    beeper.Hz = 1568
                    If beeperRate >= 100 Then
                        beeper.Beep(100, False)
                    Else
                        beeper.Beep(50, False)
                        beepEvent.WaitOne(250 - beeperRate, False)
                    End If
                Else
                    ' No tag in the range
                    beeper.Hz = 1046
                    beeper.Beep(50, False)
                    beepEvent.WaitOne(2000, False)
                End If
            End If
        End While
        hBeeperThread = Nothing
    End Sub
End Class
