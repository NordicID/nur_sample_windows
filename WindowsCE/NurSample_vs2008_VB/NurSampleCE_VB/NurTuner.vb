Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.InteropServices

Imports NurApiDotNet
'NurApi wrapper
NotInheritable Class NurTuner
    Private Sub New()
    End Sub
    Const SZ_DEF_USERTUNE As Integer = 28
    Const SZ_TUNEREQUEST As Integer = 12

    Public Enum TYPE As UInteger
        FAST = 0
        MEDIUM = 1
        WIDE = 2
    End Enum

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure TuneResult
        Public I As Integer
        Public Q As Integer
        Public dBm As Double
        Public antenna As UInteger
        Public band As UInteger

        Public ReadOnly Property Frequency() As UInteger
            Get
                Return 850 + (band * 20)
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return String.Format("{0:0.00} dBm", dBm)
            'return string.Format("I = {0}, Q = {1}, dBm = {2:0.00}", I, Q, dBm);
        End Function
    End Structure

    Private Shared Function ExtractTuneResults(ByVal src As Byte()) As TuneResult()
        Dim antenna As UInteger = BitConverter.ToUInt32(src, 0)
        Dim ret As TuneResult() = New TuneResult((src.Length - 16) / SZ_TUNEREQUEST - 1) {}
        Dim i As Integer, idBm As Integer

        Dim ptReply As UInteger = 0
        i = 16
        While i < src.Length
            ret(ptReply).I = BitConverter.ToInt32(src, i)
            ret(ptReply).Q = BitConverter.ToInt32(src, i + 4)
            idBm = BitConverter.ToInt32(src, i + 8)
            ret(ptReply).dBm = CDbl(idBm) / 1000.0
            ret(ptReply).antenna = antenna
            ret(ptReply).band = ptReply
            ptReply += 1
            i += SZ_TUNEREQUEST
        End While
        Return ret
    End Function

    Private Shared Function ExtractSingleTuneResult(ByVal src As Byte()) As TuneResult()
        Dim antenna As UInteger = BitConverter.ToUInt32(src, 0)
        Dim band As UInteger = BitConverter.ToUInt32(src, 4)
        Dim idBm As Integer
        Dim ret As TuneResult() = New TuneResult(0) {}
        ret(0).I = BitConverter.ToInt32(src, 8)
        ret(0).Q = BitConverter.ToInt32(src, 12)
        idBm = BitConverter.ToInt32(src, 16)
        ret(0).dBm = CDbl(idBm) / 1000.0
        ret(0).antenna = antenna
        ret(0).band = band
        Return ret
    End Function

    Private Shared Function BuildTune(ByVal type As TYPE, ByVal antenna As Integer, ByVal band As Integer, ByVal goodEnough As Integer, ByVal save As Boolean) As Byte()
        Dim cmd As Byte()
        Dim valarr As Byte() = New Byte(3) {}
        Dim userCode As Byte() = New Byte() {0, 0, 0, 0, 0, 0, _
         0, 0}

        cmd = New Byte(SZ_DEF_USERTUNE - 1) {}

        ' Type 

        System.Array.Copy(BitConverter.GetBytes(CUInt(type)), 0, cmd, 0, 4)
        ' Antenna 

        System.Array.Copy(BitConverter.GetBytes(antenna), 0, cmd, 4, 4)
        ' Band 0...5 

        System.Array.Copy(BitConverter.GetBytes(band), 0, cmd, 8, 4)
        ' Save? 

        System.Array.Copy(BitConverter.GetBytes(CInt(If(save, 1, 0))), 0, cmd, 12, 4)
        ' When to quit 

        System.Array.Copy(BitConverter.GetBytes(goodEnough), 0, cmd, 16, 4)
        System.Array.Copy(userCode, 0, cmd, 20, userCode.Length)

        Return cmd
    End Function

    ''' <summary>
    ''' Tunes the specified antenna.
    ''' </summary>
    ''' <param name="hNur">The hNur.</param>
    ''' <param name="type">The tune type.</param>
    ''' <param name="antenna">The antenna.</param>
    ''' <param name="band">The band.</param>
    ''' <param name="goodEnough">The good enough.</param>
    ''' <param name="save">if set to <c>true</c> [save].</param>
    ''' <returns></returns>
    Public Shared Function Tune(ByVal hNur As NurApi, ByVal type As TYPE, ByVal antenna As Integer, ByVal band As Integer, ByVal goodEnough As Integer, ByVal save As Boolean) As TuneResult()
        Dim backupCommTimeout As UInteger = hNur.CommTimeout
        hNur.CommTimeout = 15

        Dim cmd As Byte() = BuildTune(type, antenna, band, -50, True)
        Dim resp As Byte() = hNur.CustomCmd(&H66, cmd)
        Dim respIQ As TuneResult()
        If band < 0 Then
            respIQ = ExtractTuneResults(resp)
        Else
            respIQ = ExtractSingleTuneResult(resp)
        End If

        hNur.CommTimeout = backupCommTimeout
        Return respIQ
    End Function
End Class
