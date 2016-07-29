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

        Public Sub New(ByVal fwinfo__1 As String)
            FWINFO = fwinfo__1
        End Sub

        Public Property FWINFO() As String
            Get
                Return m_fwinfo
            End Get
            Set(ByVal value As String)
                m_fwinfo = Value
                keypairs.Clear()
                Dim info As String = m_fwinfo.Replace(BEGINTAG, "")
                info = info.Replace(ENDTAG, "")
                Dim keyValues As String() = info.Split(New Char() {";"c})
                For Each keyValue As String In keyValues
                    If Not String.IsNullOrEmpty(keyValue) Then
                        Dim pair As String() = keyValue.Split(New Char() {"="c})
                        keypairs.Add(pair(0), pair(1))
                    End If
                Next
            End Set
        End Property

        Public Function GetValue(ByVal key As String) As String
            Dim val As String = ""
            If keypairs.TryGetValue(key, val) Then
                Return val
            End If
            Return String.Empty
        End Function

        Public Function Compare(ByVal fwInfoParser As NurFwInfoParser) As Boolean
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
    End Class
End Namespace
