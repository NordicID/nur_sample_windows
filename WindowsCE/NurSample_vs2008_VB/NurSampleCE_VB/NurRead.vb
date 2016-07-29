'=======================================================================================
'
'    Smart ReadBank method that reads the entire memory till the end or a fixed part
'    of it.
'
'=======================================================================================

Imports System.Collections.Generic
Imports System.Text
Imports System.IO
Imports System.Xml.Serialization

Imports NurApiDotNet

Namespace NurSample
    NotInheritable Class NurRead
        Private Sub New()
        End Sub
        Const RETRIES As Integer = 4
        Shared bChancelReading As Boolean = False

        Shared ReadOnly generalPurposeBSS As Integer() = New Integer() {8, 12, 4, 2}

        ''' <summary>
        ''' Reads the part of the memory or whole bank.
        ''' </summary>
        ''' <param name="hNur">The hNur handler.</param>
        ''' <param name="passwd">The access password.</param>
        ''' <param name="secured">Use password if set to <c>true</c>.</param>
        ''' <param name="sBank">The singulation bank.</param>
        ''' <param name="sAddress">The singulation address (bits).</param>
        ''' <param name="sMaskBitLength">Length of the singulation mask (bits).</param>
        ''' <param name="sMask">The singulation mask.</param>
        ''' <param name="rdBank">The read bank.</param>
        ''' <param name="rdAddress">The read address (words).</param>
        ''' <param name="rdByteCount">The rd byte count (bytes).</param>
        ''' <returns></returns>
        Public Shared Function ReadBank(ByVal hNur As NurApi, ByVal passwd As UInteger, ByVal secured As Boolean, ByVal sBank As Byte, ByVal sAddress As UInteger, ByVal sMaskBitLength As Integer, _
         ByVal sMask As Byte(), ByVal rdBank As Byte, ByVal rdAddress As UInteger, ByVal rdByteCount As Integer) As Byte()
            Dim t1 As Integer = System.Environment.TickCount
            Dim rdNumOfBytes As Integer = 0
            Dim rdMaxNumOfBytes As Integer = 100
            Dim bankSizeSuggestion As Integer = 0
            Dim outOfMemory As Integer = Int32.MaxValue
            Dim tagIdentifier As Byte() = Nothing

            If rdByteCount = 0 Then
                ' Get general purpose bank size suggestion
                bankSizeSuggestion = generalPurposeBSS(rdBank)
                rdNumOfBytes = CInt(bankSizeSuggestion)
            Else
                ' Read fixed number of bytes
                rdNumOfBytes = rdByteCount
            End If

            Dim tempException As NurApiException = Nothing
            Dim byteList As New List(Of Byte)()

            ' Read Tag
            Dim retryCnt As Integer = 0
            bChancelReading = False
            Do
                ' Chancel reading if requested
                If bChancelReading Then
                    Exit Do
                End If

                ' Are we reached the fixed number of bytes (rdByteCount > 0)
                If rdByteCount > 0 AndAlso byteList.Count >= rdByteCount Then
                    Exit Do
                End If

                ' First check the error / retry counter
                If retryCnt > RETRIES Then
                    Exit Do
                End If

                ' Calculate some usefull values
                Dim startAddress As Integer = CInt(rdAddress) * 2
                Dim suggestedBytesLeft As Integer = bankSizeSuggestion - startAddress
                Dim outOfMemoryLeft As Integer = outOfMemory - startAddress
                Dim lastReadAddress As Integer = rdNumOfBytes + startAddress

                ' rdNumOfBytes = suggested size
                If suggestedBytesLeft < rdNumOfBytes AndAlso startAddress < bankSizeSuggestion Then
                    rdNumOfBytes = CInt(suggestedBytesLeft)
                End If

                ' Make sure that the rdNumOfBytes < than latest outOfMemory
                If outOfMemoryLeft - 4 <= rdNumOfBytes Then
                    rdNumOfBytes = CInt(outOfMemoryLeft) - 4
                End If

                ' Make sure that the rdNumOfBytes is not bigget than latest known MaxNumOfBytes
                If rdNumOfBytes > rdMaxNumOfBytes Then
                    rdNumOfBytes = rdMaxNumOfBytes
                End If

                ' Last but not least, make sure that we read at least one word
                If rdNumOfBytes < 2 Then
                    rdNumOfBytes = 2
                End If

                ' Make sure thet we don't read more than requested rdByteCount
                If rdByteCount > 0 AndAlso byteList.Count + rdNumOfBytes > rdByteCount Then
                    rdNumOfBytes = rdByteCount - byteList.Count
                End If

                Try
                    ' Read the content of the memory bank
                    Dim bytes As Byte() = Nothing
                    'RFID_Demo.Debug.WriteToFile(string.Format("Read addr:{0}, Bytes:{1}", rdAddress*2, rdNumOfBytes));
                    bytes = hNur.ReadSingulatedTag(passwd, secured, sBank, sAddress, sMaskBitLength, sMask, _
                     rdBank, rdAddress, rdNumOfBytes)
                    byteList.AddRange(bytes)
                    tempException = Nothing
                    retryCnt = 0
                Catch ex As NurApiException
                    'RFID_Demo.Debug.WriteToFile(string.Format("NurApiException {0}: {1}", ex.error, NurApiErrors.ErrorCodeToString(ex.error)));
                    tempException = ex
                    If ex.[error] = NurApiErrors.NUR_ERROR_G2_TAG_MEM_OVERRUN Then
                        ' Out of memory!!!
                        retryCnt = 0
                        outOfMemory = (CInt(rdAddress) * 2) + rdNumOfBytes
                        If rdNumOfBytes > 2 Then
                            ' Read rest of mem by word by word.
                            rdNumOfBytes = 2
                            Continue Do
                        End If
                        ' The end of memory reached. Stop reading and clear the exception. 
                        tempException = Nothing
                        Exit Do
                    ElseIf ex.[error] = NurApiErrors.NUR_ERROR_G2_READ Then
                        ' This may occur if we try to read too much or the connection is too weak
                        If rdNumOfBytes = rdMaxNumOfBytes Then
                            rdMaxNumOfBytes -= 4
                        End If
                        Continue Do
                    End If

                    ' Some other error occurred
                    System.Diagnostics.Debug.WriteLine(String.Format("Error {0}, {2}: {1}", ex.[error], NurApiErrors.ErrorCodeToString(ex.[error]), rdNumOfBytes))
                    retryCnt += 1
                    Continue Do
                End Try

                ' Move word address to forward.
                rdAddress += CUInt(rdNumOfBytes) / 2

                ' If the suggested end of the memory is reached try to read only the next word
                If bankSizeSuggestion = rdAddress * 2 Then
                    rdNumOfBytes = 2
                End If

                ' Try increase the reading speed if there is mode memory than suggested.
                If bankSizeSuggestion < rdAddress * 2 Then
                    rdNumOfBytes *= 2
                End If
            Loop While True

            ' throw exception if exist 
            If tempException IsNot Nothing Then
                Throw tempException
            End If

            System.Diagnostics.Debug.WriteLine(System.Environment.TickCount - t1)
            Return byteList.ToArray()
        End Function

        ''' <summary>
        ''' Chancels the reading.
        ''' </summary>
        Public Shared Sub ChancelReading()
            bChancelReading = True
        End Sub
    End Class
End Namespace
