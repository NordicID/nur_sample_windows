Imports System.Collections.Generic
Imports System.Text

Imports NurApiDotNet

Class NurUtils
    Const RETRIES As Integer = 4
    Const MAX_TX_LEVEL As Integer = 0
    Const MIN_TX_LEVEL As Integer = 19

    ''' <summary>
    ''' Searches the stronges (the highest RSSI) tag.
    ''' </summary>
    ''' <param name="hNur">The NurApi header.</param>
    ''' <param name="autoTxLevel">if set to <c>true</c> [use auto tx level].</param>
    ''' <param name="tag">reference for the nearest tag</param>
    ''' <param name="usedTxLevel">reference for the used TxLevel.</param>
    ''' <returns>
    ''' The number of found tags.
    ''' </returns>
    Public Shared Function SearchNearestTag(ByVal hNur As NurApi, ByVal autoTxLevel As Boolean, ByRef tag As NurApi.Tag, ByRef usedTxLevel As Integer) As Integer
        ' Set the used TxLevel
        usedTxLevel = hNur.TxLevel
        ' Clear previously inventoried tags from memory
        hNur.ClearTags()
        Dim inventoriedTags As NurApi.TagStorage = Nothing

        If autoTxLevel Then
            ' Backup TX Level
            Dim backupTxLevel As Integer = hNur.TxLevel
            ' Search Tags with auto TX Level
            For tx As Integer = MIN_TX_LEVEL To MAX_TX_LEVEL Step -1
                ' Set TX Level
                hNur.TxLevel = tx
                ' Set the used TxLevel
                usedTxLevel = tx
                ' Perform simple inventory
                Dim ir As NurApi.InventoryResponse = hNur.SimpleInventory()
                ' Did we find any Tag
                If ir.numTagsMem > 0 Then
                    ' Yes we did
                    Exit For
                End If
            Next
            ' Fetch tags from module, including tag meta
            inventoriedTags = hNur.FetchTags(True)
            ' Restore TX Level
            hNur.TxLevel = backupTxLevel
        Else
            ' Search Tags with fixed TX Level
            For i As Integer = 0 To RETRIES - 1
                ' Perform simple inventory
                Dim ir As NurApi.InventoryResponse = hNur.SimpleInventory()
                ' Did we find any Tag
                If ir.numTagsMem > 0 Then
                    ' Yes we did
                    Exit For
                End If
            Next
            ' Fetch tags from module, including tag meta
            inventoriedTags = hNur.FetchTags(True)
        End If

        ' Search stongest Tag
        tag = Nothing
        Dim maxRssi As Integer = -128
        For i As Integer = 0 To inventoriedTags.Count - 1
            If maxRssi < inventoriedTags(i).rssi Then
                maxRssi = inventoriedTags(i).rssi
                tag = inventoriedTags(i)
            End If
        Next

        ' Return number of found tags
        Return inventoriedTags.Count
    End Function

    Public Shared Function ReadAccessPasswordByEPC(ByVal hNur As NurApi, ByVal passwd As UInteger, ByVal secured As Boolean, ByVal epc As Byte()) As UInteger
        Dim pwd As UInteger = 0
        Dim tempException As NurApiException = Nothing

        ' READ ACCESS PWD
        For i As Integer = 0 To RETRIES - 1
            ' Try to read Access pwd with given password
            Try
                pwd = hNur.GetAccessPasswordByEPC(passwd, secured, epc)
                tempException = Nothing
                Exit For
            Catch ex As NurApiException
                tempException = ex
            End Try
            ' Previous attempt failed so try to read Access pwd without password
            If secured Then
                Try
                    pwd = hNur.GetAccessPasswordByEPC(0, False, epc)
                    tempException = Nothing
                    Exit For
                Catch ex As NurApiException
                    tempException = ex
                End Try
            End If
        Next
        If tempException IsNot Nothing Then
            Throw tempException
        End If

        Return pwd
    End Function

    Public Shared Function ReadKillPasswordByEPC(ByVal hNur As NurApi, ByVal passwd As UInteger, ByVal secured As Boolean, ByVal epc As Byte()) As UInteger
        Dim pwd As UInteger = 0
        Dim tempException As NurApiException = Nothing

        ' READ KILL PWD
        For i As Integer = 0 To RETRIES - 1
            ' Try to read Kill pwd with given password
            Try
                pwd = hNur.GetKillPasswordByEPC(passwd, secured, epc)
                tempException = Nothing
                Exit For
            Catch ex As NurApiException
                tempException = ex
            End Try
            ' Previous attempt failed so try to read Kill pwd without password
            If secured Then
                Try
                    pwd = hNur.GetKillPasswordByEPC(0, False, epc)
                    tempException = Nothing
                    Exit For
                Catch ex As NurApiException
                    tempException = ex
                End Try
            End If
        Next
        If tempException IsNot Nothing Then
            Throw tempException
        End If

        Return pwd
    End Function

    ''' <summary>
    ''' Return version number of NurApiDotNet.dll
    ''' </summary>
    Public Shared ReadOnly Property NurApiDotNetVersion() As String
        Get
            Try
                Dim assembly As System.Reflection.Assembly = System.Reflection.Assembly.LoadFrom("NurApiDotNetWCE.dll")
                Return assembly.GetName().Version.ToString()
            Catch generatedExceptionName As Exception
                Return "unknown"
            End Try
        End Get
    End Property
End Class
