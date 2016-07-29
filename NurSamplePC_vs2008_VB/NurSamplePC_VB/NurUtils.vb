Imports System.Collections.Generic
Imports System.Text

Imports NurApiDotNet

Class NurUtils
	Const RETRIES As Integer = 4
	Const MAX_TX_LEVEL As Integer = 0
	Const MIN_TX_LEVEL As Integer = 19

	''' <summary>
	''' Searches the nearest tag.
	''' </summary>
	''' <param name="hNur">The NurApi header.</param>
	''' <param name="autoTxLevel">if set to <c>true</c> [use auto tx level].</param>
	''' <param name="tag">reference for the nearest tag</param>
	''' <param name="usedTxLevel">reference for the used TxLevel.</param>
	''' <returns>
	''' The number of found tags.
	''' </returns>
	Public Shared Function SearchNearestTag(hNur As NurApi, autoTxLevel As Boolean, ByRef tag As NurApi.Tag, ByRef usedTxLevel As Integer) As Integer
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
		Dim maxScaledRssi As Integer = 0
		For i As Integer = 0 To inventoriedTags.Count - 1
			If maxScaledRssi < inventoriedTags(i).scaledRssi Then
				tag = inventoriedTags(i)
			End If
		Next

		Return inventoriedTags.Count
	End Function

	''' <summary>
	''' Reads the bank by epc.
	''' </summary>
	''' <param name="hNur">The NurApi header.</param>
	''' <param name="passwd">The access passwd.</param>
	''' <param name="secured">if set to <c>true</c> [use password].</param>
	''' <param name="epc">The epc.</param>
	''' <param name="rdBank">The rdBank.</param>
	''' <param name="rdAddress">The rdAddress.</param>
	''' <param name="rdByteCount">The rdByte count.</param>
	''' <param name="bankSizeSuggestion">The bank size suggestion.</param>
	''' <returns></returns>
	Public Shared Function ReadBankByEpc(hNur As NurApi, passwd As UInteger, secured As Boolean, epc As Byte(), rdBank As Byte, rdAddress As UInteger, _
		rdByteCount As Integer, bankSizeSuggestion As Integer) As Byte()
		Const  MAXLENGTH As Integer = 2048
		Dim tempException As NurApiException = Nothing

		Dim rdNumOfBytes As Integer = bankSizeSuggestion
		Dim byteList As New List(Of Byte)()

		' Set default rdNumOfBytes of bank (if not suggested)
		If bankSizeSuggestion = 0 Then
			Select Case rdBank
				Case CByte(NurApi.BANK_PASSWD)
					rdNumOfBytes = 8
					Exit Select
				Case CByte(NurApi.BANK_EPC)
					rdNumOfBytes = 12
					Exit Select
				Case CByte(NurApi.BANK_TID)
					rdNumOfBytes = 4
					Exit Select
				Case CByte(NurApi.BANK_USER)
					rdNumOfBytes = 16
					Exit Select
			End Select
		End If
		' Set the exact rdNumOfBytes if specified
		If rdByteCount > 0 Then
			rdNumOfBytes = rdByteCount - byteList.Count
		End If

		' Read Tag
		Dim retryCnt As Integer = 0
		Do
			Try
				Dim bytes As Byte() = Nothing
				bytes = hNur.ReadTagByEPC(passwd, secured, epc, rdBank, rdAddress, rdNumOfBytes)
				byteList.AddRange(bytes)
				retryCnt = 0
			Catch ex As NurApiException
				tempException = ex

				If ex.[error] <> 4110 Then
					' Communication error? Try against!!!
					retryCnt += 1
                    Continue Do
				End If

				' Error was 4110 (NUR_ERROR_G2_TAG_MEM_OVERRUN)
				If rdNumOfBytes > 2 Then
					' Read rest of mem by word by word.
					rdNumOfBytes = 2
                    Continue Do
				Else
					' Reached the end of memory
					Exit Try
				End If
			End Try
			' Set new index
			rdAddress += CUInt(rdNumOfBytes) \ 2
		Loop While (rdAddress < MAXLENGTH) AndAlso Not (rdByteCount > 0 AndAlso byteList.Count >= rdByteCount) AndAlso (retryCnt < 3)

		If byteList.Count = 0 Then
			Throw tempException
		End If

		Return byteList.ToArray()
	End Function

	Public Shared Function ReadAccessPasswordByEPC(hNur As NurApi, passwd As UInteger, secured As Boolean, epc As Byte()) As UInteger
		Dim pwd As UInteger = 0
		Dim tempException As NurApiException = Nothing

		' READ ACCESS PWD
		For i As Integer = 0 To RETRIES - 1
			' Try to read Access pwd with given password
			Try
				pwd = hNur.GetAccessPasswordByEPC(passwd, secured, epc)
				tempException = Nothing
				Exit Try
			Catch ex As NurApiException
				tempException = ex
			End Try
			' Previous attempt failed so try to read Access pwd without password
			If secured Then
				Try
					pwd = hNur.GetAccessPasswordByEPC(0, False, epc)
					tempException = Nothing
					Exit Try
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

	Public Shared Function ReadKillPasswordByEPC(hNur As NurApi, passwd As UInteger, secured As Boolean, epc As Byte()) As UInteger
		Dim pwd As UInteger = 0
		Dim tempException As NurApiException = Nothing

		' READ KILL PWD
		For i As Integer = 0 To RETRIES - 1
			' Try to read Kill pwd with given password
			Try
				pwd = hNur.GetKillPasswordByEPC(passwd, secured, epc)
				tempException = Nothing
				Exit Try
			Catch ex As NurApiException
				tempException = ex
			End Try
			' Previous attempt failed so try to read Kill pwd without password
			If secured Then
				Try
					pwd = hNur.GetKillPasswordByEPC(0, False, epc)
					tempException = Nothing
					Exit Try
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
	' Return version number of NurApiDotNet.dll
	''' </summary>
	Public Shared ReadOnly Property NurApiDotNetVersion() As String
		Get
			Try
				Dim assembly As System.Reflection.Assembly = System.Reflection.Assembly.LoadFrom("NurApiDotNet.dll")
				Return assembly.GetName().Version.ToString()
			Catch generatedExceptionName As Exception
				Return "unknown"
			End Try
		End Get
	End Property
End Class
