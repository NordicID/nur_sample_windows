Imports NurApiDotNet

Public Class Form1

    Dim hNur As NurApi
    Dim running As Boolean 'Flag to indicate stream inventory running
    Dim tags As New NurApi.TagStorage() 'This tag storage contains all unique inventoried tags


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        hNur = New NurApi()             'Nur Api handle

        AddHandler hNur.ConnectedEvent, AddressOf Connected
        AddHandler hNur.DisconnectedEvent, AddressOf Disconnected
        AddHandler hNur.InventoryStreamEvent, AddressOf InventoryStreamReady

        running = False

        'Tell to Nur that this class is the reveiver of notifications...
        hNur.SetNotificationReceiver(Me)
        'When NUR module connected via USB, this function finds it and connects automagically...
        hNur.SetUsbAutoConnect(True)

    End Sub

    Sub Connected(ByVal sender As System.Object, ByVal e As NurApi.NurEventArgs)
        'Show NurApi Dll version in the form caption with connected status            
        Me.Text = "NurAPI Dll Version: " & hNur.GetFileVersion() & " (Connected)"
    End Sub

    Sub Disconnected(ByVal sender As System.Object, ByVal e As NurApi.NurEventArgs)
        'Show NurApi Dll version in the form caption with disconnected status            
        Me.Text = "NurAPI Dll Version: " & hNur.GetFileVersion() & " (Disconnected)"
    End Sub
    Sub InventoryStreamReady(ByVal sender As System.Object, ByVal e As NurApi.InventoryStreamEventArgs)
        'Copy tags from NurApi internal tag storage to application tag storage
        'Let's read them using GetTagStorage and show tag EPC in the list box
        Dim tag As NurApi.Tag

        Try
            For Each tag In hNur.GetTagStorage()
                If tags.AddTag(tag) Then
                    'New unique tag added
                    ListBox1.Items.Add(tag.GetEpcString())
                End If
            Next
            'Clear NurApi internal tag storage
            hNur.ClearTags()

            If e.data.stopped Then
                'Start again if stopped
                hNur.StartInventoryStream()
            End If

        Catch ex As Exception
            'Error. Handle exception
            ListBox1.Items.Add(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'This button toggles inventory stream inventory on/off
        Try
            If running = False Then
                'Start
                hNur.ClearTags()
                hNur.StartInventoryStream()
                Button1.Text = "Stop"
                running = True
            Else
                'Stop
                hNur.StopInventoryStream()
                Button1.Text = "Start"
                running = False
            End If
        Catch ex As Exception
            'Error. Handle exception
            MessageBox.Show(ex.ToString(), "Exception")
            running = False
            Button1.Text = "Start"
        End Try
       
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Clear list box
        ListBox1.Items.Clear()
        'Clear our application tag storage
        tags.Clear()
    End Sub
End Class
