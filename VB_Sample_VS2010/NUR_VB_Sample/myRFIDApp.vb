Imports NurApiDotNet

Public Class myRFIDApp

    Dim iNur As NurApi 'This is your handle to NUR RFID Reader. Use it inside try..catch structure

    Public Sub New(ByRef nur As NurApi)

        iNur = nur 'We receive NurApi handle reference from Form1
        InitializeComponent() ' This call is required by the designer.

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Private Sub LabelAntennaCount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelAntennaCount.Click
        Dim reader As NurApi.ReaderInfo

        'IMPORTANT
        'Most of NurAPI commands throws exception event if something goes wrong
        'Therefore, use alaways Try --> Catch structure for exception handling when calling NurApi commands

        Try
            reader = iNur.GetReaderInfo

            If reader.numAntennas > 1 Then
                LabelAntennaCount.Text = reader.numAntennas.ToString & " antennas found"
            Else
                LabelAntennaCount.Text = reader.numAntennas.ToString & " antenna found"
            End If

            LabelAntennaCount.ForeColor = Color.DarkBlue
        Catch ex As Exception
            LabelAntennaCount.Text = ex.Message
            LabelAntennaCount.ForeColor = Color.Red

        End Try
    End Sub
End Class
