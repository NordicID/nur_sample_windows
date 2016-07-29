Imports System.Collections.Generic
Imports System.Text

Namespace NurApiDotNet
	Public Class NurFwInfoParser
		' Examples:
		' <FWINFO>MODULE=NUR-05W;TYPE=LOADER;VER=1.9-A;DATE=Sep 18 2013 12:30:39</FWINFO>
		' <FWINFO>MODULE=NUR-05WL2;TYPE=APP;VER=4.2-A;DATE=Oct 29 2013 08:10:40</FWINFO>
		' <FWINFO>MODULE=NUR-05WL2;TYPE=APP;VER=4.2-F;DATE=Nov 11 2013 08:43:57;SPECIALBUILD=STANDALONE1</FWINFO>

		Private ReadOnly BEGINTAG As String = "<FWINFO>"
		Private ReadOnly ENDTAG As String = "</FWINFO>"
		Private m_fwinfo As String = String.Empty
		Public keypairs As New Dictionary(Of String, String)()

		Public Sub New()
		End Sub

		Public Sub New(fwinfo__1 As String)
			FWINFO = fwinfo__1
		End Sub

		Public Property FWINFO() As String
			Get
				Return m_fwinfo
			End Get
			Set
				m_fwinfo = value
				keypairs.Clear()
				Dim info As String = m_fwinfo.Replace(BEGINTAG, "")
				info = info.Replace(ENDTAG, "")
				Dim keyValues As String() = info.Split(New Char() {";"C})
				For Each keyValue As String In keyValues
					If Not String.IsNullOrEmpty(keyValue) Then
						Dim pair As String() = keyValue.Split(New Char() {"="C})
						keypairs.Add(pair(0), pair(1))
					End If
				Next
			End Set
		End Property

		Public Function LoadFwInfoFromFile(filename As String) As String
			FWINFO = String.Empty
			Dim fileBytes As Byte() = System.IO.File.ReadAllBytes(filename)
			Dim pattern As Byte() = Encoding.ASCII.GetBytes(BEGINTAG)
			Dim begin As Integer = IndexOfBytes(fileBytes, pattern, 0, fileBytes.Length)
			If begin > -1 Then
				pattern = Encoding.ASCII.GetBytes(ENDTAG)
				Dim [end] As Integer = IndexOfBytes(fileBytes, pattern, begin, fileBytes.Length - begin)
				FWINFO = Encoding.ASCII.GetString(fileBytes, begin, ([end] - begin) + pattern.Length)
				Return FWINFO
			End If
			Return String.Empty
		End Function

		Public Function GetValue(key As String) As String
			Dim val As String
			If keypairs.TryGetValue(key, val) Then
				Return val
			End If
			Return String.Empty
		End Function

		Public Function Compare(fwInfoParser As NurFwInfoParser) As Boolean
			Try
				For Each entry As KeyValuePair(Of String, String) In keypairs
					If Not fwInfoParser.keypairs(entry.Key).Equals(entry.Value) Then
						Return False
					End If
				Next
				Return True
			Catch generatedExceptionName As Exception
				Return False
			End Try
		End Function

		Private Function IndexOfBytes(array As Byte(), pattern As Byte(), startIndex As Integer, count As Integer) As Integer
			If array Is Nothing OrElse array.Length = 0 OrElse pattern Is Nothing OrElse pattern.Length = 0 OrElse count = 0 Then
				Return -1
			End If
			Dim i As Integer = startIndex
			Dim endIndex As Integer = If(count > 0, Math.Min(startIndex + count, array.Length), array.Length)
			Dim fidx As Integer = 0
			Dim lastFidx As Integer = 0

			While i < endIndex
				lastFidx = fidx
				fidx = If((array(i) = pattern(fidx)), System.Threading.Interlocked.Increment(fidx), 0)
				If fidx = pattern.Length Then
					Return i - fidx + 1
				End If
				If lastFidx > 0 AndAlso fidx = 0 Then
					i = i - lastFidx
					lastFidx = 0
				End If
				i += 1
			End While
			Return -1
		End Function
	End Class
End Namespace
