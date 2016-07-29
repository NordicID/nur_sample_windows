Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms

Class Utils
    ''' <summary>
    ''' Converts UInt64 to big endia bytes.
    ''' </summary>
    ''' <param name="value">The value.</param>
    ''' <returns></returns>
    Public Shared Function ConvertToBigEndiaBytes(ByVal value As UInt64) As Byte()
        If BitConverter.IsLittleEndian Then
            value = ReverseBytes(value)
        End If
        Return BitConverter.GetBytes(value)
    End Function

    ''' <summary>
    ''' Converts UInt32 to big endia bytes.
    ''' </summary>
    ''' <param name="value">The value.</param>
    ''' <returns></returns>
    Public Shared Function ConvertToBigEndiaBytes(ByVal value As UInt32) As Byte()
        If BitConverter.IsLittleEndian Then
            value = ReverseBytes(value)
        End If
        Return BitConverter.GetBytes(value)
    End Function

    ''' <summary>
    ''' Converts UInt16 to big endia bytes.
    ''' </summary>
    ''' <param name="value">The value.</param>
    ''' <returns></returns>
    Public Shared Function ConvertToBigEndiaBytes(ByVal value As UInt16) As Byte()
        If BitConverter.IsLittleEndian Then
            value = ReverseBytes(value)
        End If
        Return BitConverter.GetBytes(value)
    End Function

    ''' <summary>
    ''' Converts the big endia bytes to system endia.
    ''' </summary>
    ''' <param name="value">The value.</param>
    ''' <returns></returns>
    Public Shared Function ConvertBigEndiaToSystemEndia(ByVal value As Byte()) As UInt64
        Select Case value.Length
            Case 1
                Return value(0)
            Case 2
                Dim ret16 As UInt16 = BitConverter.ToUInt16(value, 0)
                If BitConverter.IsLittleEndian Then
                    Return ReverseBytes(ret16)
                End If
                Return ret16
            Case 4
                Dim ret32 As UInt32 = BitConverter.ToUInt32(value, 0)
                If BitConverter.IsLittleEndian Then
                    Return ReverseBytes(ret32)
                End If
                Return ret32
            Case Else
                Dim ret64 As UInt64 = BitConverter.ToUInt64(value, 0)
                If BitConverter.IsLittleEndian Then
                    Return ReverseBytes(ret64)
                End If
                Return ret64
        End Select
    End Function

    ''' <summary>
    ''' Converts the big endia to system endia.
    ''' </summary>
    ''' <param name="value">The value.</param>
    ''' <returns></returns>
    Public Shared Function ConvertBigEndiaToSystemEndia(ByVal value As UInt64) As UInt64
        If BitConverter.IsLittleEndian Then
            Return ReverseBytes(value)
        End If
        Return value
    End Function

    ''' <summary>
    ''' Converts the big endia to system endia.
    ''' </summary>
    ''' <param name="value">The value.</param>
    ''' <returns></returns>
    Public Shared Function ConvertBigEndiaToSystemEndia(ByVal value As UInt32) As UInt32
        If BitConverter.IsLittleEndian Then
            Return ReverseBytes(value)
        End If
        Return value
    End Function

    ''' <summary>
    ''' Converts the big endia to system endia.
    ''' </summary>
    ''' <param name="value">The value.</param>
    ''' <returns></returns>
    Public Shared Function ConvertBigEndiaToSystemEndia(ByVal value As UInt16) As UInt16
        If BitConverter.IsLittleEndian Then
            Return ReverseBytes(value)
        End If
        Return value
    End Function

    ''' <summary>
    ''' Reverses byte order (16-bit)
    ''' </summary>
    ''' <param name="value">The value.</param>
    ''' <returns></returns>
    Public Shared Function ReverseBytes(ByVal value As UInt16) As UInt16
        Return CType((value And &HFFUI) << 8 Or (value And &HFF00UI) >> 8, UInt16)
    End Function

    ''' <summary>
    ''' Reverses byte order (32-bit)
    ''' </summary>
    ''' <param name="value">The value.</param>
    ''' <returns></returns>
    Public Shared Function ReverseBytes(ByVal value As UInt32) As UInt32
        Return (value And &HFFUI) << 24 Or (value And &HFF00UI) << 8 Or (value And &HFF0000UI) >> 8 Or (value And &HFF000000UI) >> 24
    End Function

    ''' <summary>
    ''' Reverses byte order (64-bit)
    ''' </summary>
    ''' <param name="value">The value.</param>
    ''' <returns></returns>
    Public Shared Function ReverseBytes(ByVal value As UInt64) As UInt64
        Return (value And &HFFUL) << 56 Or (value And &HFF00UL) << 40 Or (value And &HFF0000UL) << 24 Or (value And &HFF000000UL) << 8 Or (value And &HFF00000000UL) >> 8 Or (value And &HFF0000000000UL) >> 24 Or (value And &HFF000000000000UL) >> 40 Or (value And &HFF00000000000000UL) >> 56
    End Function

    ''' <summary>
    ''' Shifts the left.
    ''' </summary>
    ''' <param name="value">The value.</param>
    ''' <param name="bitcount">The bitcount.</param>
    ''' <returns></returns>
    Public Shared Function ShiftLeft(ByVal value As Byte(), ByVal bitcount As Integer) As Byte()
        Dim temp As Byte() = New Byte(value.Length - 1) {}
        If bitcount >= 8 Then
            Array.Copy(value, bitcount / 8, temp, 0, temp.Length - (bitcount / 8))
        Else
            Array.Copy(value, temp, temp.Length)
        End If
        If bitcount Mod 8 <> 0 Then
            For i As Integer = 0 To temp.Length - 1
                temp(i) <<= bitcount Mod 8
                If i < temp.Length - 1 Then
                    temp(i) = temp(i) Or CByte(temp(i + 1) >> 8 - bitcount Mod 8)
                End If
            Next
        End If
        Return temp
    End Function
End Class
