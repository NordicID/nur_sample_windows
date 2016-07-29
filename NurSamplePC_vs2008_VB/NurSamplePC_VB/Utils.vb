Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms

Class Utils
	''' <summary>
	''' Converts UInt64 to big endia bytes.
	''' </summary>
	''' <param name="value">The value.</param>
	''' <returns></returns>
	Public Shared Function ConvertToBigEndiaBytes(value As UInt64) As Byte()
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
	Public Shared Function ConvertToBigEndiaBytes(value As UInt32) As Byte()
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
	Public Shared Function ConvertToBigEndiaBytes(value As UInt16) As Byte()
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
	Public Shared Function ConvertBigEndiaToSystemEndia(value As Byte()) As UInt64
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
	Public Shared Function ConvertBigEndiaToSystemEndia(value As UInt64) As UInt64
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
	Public Shared Function ConvertBigEndiaToSystemEndia(value As UInt32) As UInt32
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
	Public Shared Function ConvertBigEndiaToSystemEndia(value As UInt16) As UInt16
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
	Public Shared Function ReverseBytes(value As UInt16) As UInt16
		Return CType((value And &HffUI) << 8 Or (value And &Hff00UI) >> 8, UInt16)
	End Function

	''' <summary>
	''' Reverses byte order (32-bit)
	''' </summary>
	''' <param name="value">The value.</param>
	''' <returns></returns>
	Public Shared Function ReverseBytes(value As UInt32) As UInt32
		Return (value And &HffUI) << 24 Or (value And &Hff00UI) << 8 Or (value And &Hff0000UI) >> 8 Or (value And &Hff000000UI) >> 24
	End Function

	''' <summary>
	''' Reverses byte order (64-bit)
	''' </summary>
	''' <param name="value">The value.</param>
	''' <returns></returns>
	Public Shared Function ReverseBytes(value As UInt64) As UInt64
		Return (value And &HffUL) << 56 Or (value And &Hff00UL) << 40 Or (value And &Hff0000UL) << 24 Or (value And &Hff000000UL) << 8 Or (value And &Hff00000000UL) >> 8 Or (value And &Hff0000000000UL) >> 24 Or (value And &Hff000000000000UL) >> 40 Or (value And &Hff00000000000000UL) >> 56
	End Function
End Class
