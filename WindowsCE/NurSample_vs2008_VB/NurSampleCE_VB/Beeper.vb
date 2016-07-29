Imports System.Collections.Generic
Imports System.Text

Imports NordicId

Class Beeper
    ' RTTTL example
    'public string KnightRider = "KnightRider:d=4,o=5,b=125:16e,16p,16f,16e,16e,16p,16e,16e,16f,16e,16e,16e,16d#,16e,16e,16e,16e,16p,16f,16e,16e,16p,16f,16e,16f,16e,16e,16e,16d#,16e,16e,16e,16d,16p,16e,16d,16d,16p,16e,16d,16e,16d,16d,16d,16c,16d,16d,16d,16d,16p,16e,16d,16d,16p,16e,16d,16e,16d,16d,16d,16c,16d,16d,16d";

    ' Handle of Beeper driver
    Shared hBeeper As New MHLDriver()
    ' Reference counter
    Shared ref_counter As Integer = 0
    ' Current volume and frequency
    Shared m_hz As UInteger = 0
    Shared m_volume As UInteger = 0

    Public Sub New()
        If ref_counter = 0 AndAlso hBeeper IsNot Nothing Then
            Try
                hBeeper.Open("Beeper")
                Me.Volume = 10
                m_hz = Me.Hz
            Catch generatedExceptionName As Exception
            End Try
        End If
        ref_counter += 1
    End Sub

    Protected Overrides Sub Finalize()
        Try
            ref_counter -= 1
            If ref_counter = 0 AndAlso hBeeper IsNot Nothing Then
                Try
                    hBeeper.Close()
                Catch generatedExceptionName As Exception
                End Try
            End If
        Finally
            MyBase.Finalize()
        End Try
    End Sub

    Public Property Volume() As UInteger
        Get
            If Not hBeeper.IsOpen() Then
                Return 0
            End If

            Return hBeeper.GetDword("Beeper.Volume")
        End Get
        Set(ByVal value As UInteger)
            If Not hBeeper.IsOpen() Then
                Return
            End If

            If Value <> m_volume Then
                m_volume = Value
                hBeeper.SetDword("Beeper.Volume", Value)
            End If
        End Set
    End Property

    Public Property Hz() As UInteger
        Get
            If Not hBeeper.IsOpen() Then
                Return 0
            End If

            Return hBeeper.GetDword("Beeper.Hz")
        End Get
        Set(ByVal value As UInteger)
            If Not hBeeper.IsOpen() Then
                Return
            End If

            If Value <> m_hz Then
                m_hz = Value
                hBeeper.SetDword("Beeper.Hz", Value)
            End If
        End Set
    End Property

    Public Sub Beep(ByVal durration As UInteger, ByVal sync As Boolean)
        If Not hBeeper.IsOpen() Then
            Return
        End If

        If sync Then
            hBeeper.SetDword("Beeper.SyncBeep", durration)
        Else
            hBeeper.SetDword("Beeper.Beep", durration)
        End If
    End Sub

    Public Sub BeepSeq(ByVal sequence As String)
        If Not hBeeper.IsOpen() Then
            Return
        End If

        hBeeper.SetString("Beeper.BeepSeq", sequence)
    End Sub

    Public Sub PlayRtttlFile(ByVal fileName As String, ByVal sync As Boolean)
        If Not hBeeper.IsOpen() Then
            Return
        End If

        If sync Then
            hBeeper.SetString("Beeper.RTTTL.PlayFileSync", fileName)
        Else
            hBeeper.SetString("Beeper.RTTTL.PlayFile", fileName)
        End If
    End Sub

    Public Sub PlayRtttlBuffer(ByVal rttlBuffer As String, ByVal sync As Boolean)
        If Not hBeeper.IsOpen() Then
            Return
        End If

        If sync Then
            hBeeper.SetString("Beeper.RTTTL.PlayBufferSync", rttlBuffer)
        Else
            hBeeper.SetString("Beeper.RTTTL.PlayBuffer", rttlBuffer)
        End If
    End Sub
End Class
