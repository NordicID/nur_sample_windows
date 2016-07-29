Imports System.Collections.Generic
Imports System.Text
Imports System.IO

Class LogToFile
    Private logStreamWriter As StreamWriter = Nothing

    ''' <summary>
    ''' Starts the log.
    ''' </summary>
    ''' <param name="filename">The filename.</param>
    ''' <param name="mode">The mode (0 = Create new always, 1 = Append, 2 = Replace).</param>
    Public Sub StartLog(ByVal filename As String, ByVal mode As Integer)
        Select Case mode
            Case 1
                logStreamWriter = File.AppendText(filename)
                Return
            Case 2
                logStreamWriter = File.CreateText(filename)
                Return
            Case 0
                logStreamWriter = File.CreateText(NextAvailableFilename(filename))
                Return
        End Select
    End Sub

    Public Sub WriteLog(ByVal log As String)
        Try
            logStreamWriter.WriteLine(log)
        Catch generatedExceptionName As Exception
        End Try
    End Sub

    Public Sub StopLog()
        Try
            logStreamWriter.Close()
        Catch generatedExceptionName As Exception
        End Try
    End Sub

    Private Shared numberPattern As String = " ({0})"

    ''' <summary>
    ''' Nexts the available filename.
    ''' </summary>
    ''' <param name="path__1">The path__1.</param>
    ''' <returns></returns>
    Public Shared Function NextAvailableFilename(ByVal path__1 As String) As String
        ' Short-cut if already available
        If Not File.Exists(path__1) Then
            Return path__1
        End If

        ' If path has extension then insert the number pattern just before the extension and return next filename
        If Path.HasExtension(path__1) Then
            Return GetNextFilename(path__1.Insert(path__1.LastIndexOf(Path.GetExtension(path__1)), numberPattern))
        End If

        ' Otherwise just append the pattern to the path and return next filename
        Return GetNextFilename(path__1 & numberPattern)
    End Function

    ''' <summary>
    ''' Gets the next filename.
    ''' </summary>
    ''' <param name="pattern">The pattern.</param>
    ''' <returns></returns>
    ''' <exception cref="System.ArgumentException">The pattern must include an index place-holder;pattern</exception>
    Private Shared Function GetNextFilename(ByVal pattern As String) As String
        Dim tmp As String = String.Format(pattern, 1)
        If tmp = pattern Then
            Throw New ArgumentException("The pattern must include an index place-holder", "pattern")
        End If

        If Not File.Exists(tmp) Then
            Return tmp
        End If
        ' short-circuit if no matches
        Dim min As Integer = 1, max As Integer = 2
        ' min is inclusive, max is exclusive/untested
        While File.Exists(String.Format(pattern, max))
            min = max
            max *= 2
        End While

        While max <> min + 1
            Dim pivot As Integer = (max + min) / 2
            If File.Exists(String.Format(pattern, pivot)) Then
                min = pivot
            Else
                max = pivot
            End If
        End While

        Return String.Format(pattern, max)
    End Function
End Class
