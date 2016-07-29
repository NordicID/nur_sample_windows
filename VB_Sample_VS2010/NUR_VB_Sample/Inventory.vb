Imports NurApiDotNet

Public Class Inventory

    Dim tags As NurApi.TagStorage   'Fetching tag data to here when available
    Dim periodicRunning As Boolean 'True if Periodic Inventory running
    Dim iNur As NurApi          'This is your handle to NUR RFID Reader. Use it inside try..catch structure


    Public Sub New(ByRef nur As NurApi)

        iNur = nur 'We receive NurApi handle reference from Form1

        ' This call is required by the designer.
        InitializeComponent()
        AddHandler iNur.InventoryStreamEvent, AddressOf InventoryStreamEventHandler

        iNur.SetNotificationReceiver(Me)
        periodicRunning = False


    End Sub

    Sub InventoryStreamEventHandler(ByVal sender As System.Object, ByVal e As NurApi.InventoryStreamEventArgs)

        tags = iNur.GetTagStorage()
        ShowTags()
        If e.data.stopped Then
            'Start again if stopped
            iNur.StartInventoryStream()
        End If


    End Sub

    Private Sub ShowTags()

        Dim tag As NurApi.Tag
        Dim i As ListViewItem
        Dim cnt As Integer

        For Each tag In tags

            If IsFree(tag.GetEpcString) Then
                cnt = TagList.Items.Count
                i = TagList.Items.Add(cnt.ToString)
                i.ImageIndex = 0
                i.SubItems.Add(tag.GetEpcString())
                i.SubItems.Add(tag.pc.ToString)
                i.SubItems.Add(tag.timestamp.ToString)
                i.SubItems.Add(tag.rssi.ToString)
                i.Tag = tag.GetEpcString()
                i.EnsureVisible()

            End If
        Next
        If periodicRunning Then
            Form1.ToolStripStatus2.Text = "Periodic inventory... (" & TagList.Items.Count & " tags found)"
        Else
            Form1.ToolStripStatus2.Text = "Single inventory (" & TagList.Items.Count & " tags found)"
        End If
        Form1.ToolStripStatus2.ForeColor = Color.DarkBlue

    End Sub

    'If tag EPC already in Listview, return false
    Private Function IsFree(ByRef tag As String) As Boolean
        Dim i As ListViewItem
        For Each i In TagList.Items
            If i.Tag = tag Then
                Return False
            End If
        Next
        Return True

    End Function


    Private Sub ButtonClearList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearList.Click
        TagList.Items.Clear()
        Try
            iNur.ClearTags()
        Catch ex As Exception
            Form1.ToolStripStatus2.Text = ex.Message
            Form1.ToolStripStatus2.ForeColor = Color.Red
        End Try
    End Sub

    Private Sub PeriodicReadAction()

        If periodicRunning Then

            periodicRunning = False
            ButtonSingleRead.Enabled = True
            ButtonPeriodicRead.Text = "Periodic Read"
            Form1.ToolStripStatus2.Text = ""

            Try
                iNur.StopInventoryStream()
            Catch ex As Exception
                Form1.ToolStripStatus2.Text = ex.Message
                Form1.ToolStripStatus2.ForeColor = Color.Red
            End Try

        Else 'Start periodic inventory.
            periodicRunning = True
            ButtonSingleRead.Enabled = False
            ButtonPeriodicRead.Text = "Stop periodic read"
            Form1.ToolStripStatus2.Text = "Periodic inventory..."
            Form1.ToolStripStatus2.ForeColor = Color.DarkBlue
            TagList.Items.Clear()
            Try
                iNur.ClearTags()
                iNur.StartInventoryStream()
            Catch ex As Exception
                Form1.ToolStripStatus2.Text = ex.Message
                Form1.ToolStripStatus2.ForeColor = Color.Red
                periodicRunning = False
            End Try
        End If
    End Sub

    Private Sub ButtonPeriodicRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPeriodicRead.Click
        PeriodicReadAction()
    End Sub

    Private Sub ButtonSingleRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSingleRead.Click
        'Making single inventory round
        If iNur.IsConnected Then
            Try
                TagList.Items.Clear()
                Form1.ToolStripStatus2.Text = "Single inventory..."
                Form1.ToolStripStatus2.ForeColor = Color.DarkBlue
                iNur.ClearTags()
                iNur.SimpleInventory()
                tags = iNur.FetchTags(True)
                ShowTags()

            Catch ex As Exception

                Form1.ToolStripStatus2.Text = ex.Message
                Form1.ToolStripStatus2.ForeColor = Color.Red

            End Try

        End If
    End Sub

End Class
