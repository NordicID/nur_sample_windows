Imports NurApiDotNet

'Hello NUR is simple sample which connects to Sampo S1 reader via USB and acquire reader information and shows it in the ListBox.
'------------------------------------------
'Guidelines creating NurApiDotNet projects:
'-Add reference to NurApiDotNet.dll
'-Set target platform to x86
'-NURAPI.dll must be in same folder than executable. Add it in your project and set property "Copy to Output directory" to "Copy always"
'-Use NurApi commands inside Try...Catch structure. See NurApi documentation which methods throws exceptions.

Public Class Form1
    'This is handle to NUR RFID Reader. Use it always inside try..catch structure in case of exceptions.
    Dim hNur As NurApi

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        hNur = New NurApi()             'Nur Api handle

        'When NUR module connected via USB, this function finds it and connects automagically...
        hNur.SetUsbAutoConnect(True)

        Dim readerInfo As NurApi.ReaderInfo
        Try 'GetReaderInfo from module
            readerInfo = hNur.GetReaderInfo()
            'Show results in Listbox
            ListBox1.Items.Add("Name" & vbTab & readerInfo.name)
            ListBox1.Items.Add("Version" & vbTab & readerInfo.GetVersionString)
            ListBox1.Items.Add("HW Ver" & vbTab & readerInfo.hwVersion)
            ListBox1.Items.Add("FCC   " & vbTab & readerInfo.fccId)
            ListBox1.Items.Add("Serial" & vbTab & readerInfo.serial)
            ListBox1.Items.Add("SW Ver" & vbTab & readerInfo.swVerMajor & "." & readerInfo.swVerMinor)

        Catch ex As Exception 'Handle error by show error message in Listbox
            ListBox1.Items.Add("Error: GetReaderInfo:" & ex.Message)
        End Try
    End Sub
End Class
