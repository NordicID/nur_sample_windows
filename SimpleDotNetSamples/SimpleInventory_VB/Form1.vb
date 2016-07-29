Imports NurApiDotNet

Public Class Form1

    Dim hNur As NurApi

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        hNur = New NurApi()             'Nur Api handle

        AddHandler hNur.ConnectedEvent, AddressOf Connected
        AddHandler hNur.DisconnectedEvent, AddressOf Disconnected

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

    Private Sub SimpleInventoryButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleInventoryButton.Click
        'Performs simple inventory of tags using current rounds-, Q and session parameters            
        Try
            'Clear existing items from Listbox
            ListBox1.Items.Clear()
            'Clear existing tags from NurModule memory
            hNur.ClearTags()
            Dim response As NurApi.InventoryResponse  'Information about inventory store here
            'Make Inventory..
            response = hNur.SimpleInventory()
            'It's also possible to use Inventory methods specifying Round,Q and session values.
            'response = hNur.Inventory(0, 0, 0)
            'Refer NurDotNet documentation and Implementation guide for details.
            'Show information about inventory first
            ListBox1.Items.Add("Number of tags found in this inventory: " + response.numTagsFound.ToString())
            ListBox1.Items.Add("Total number of tags in module memory : " + response.numTagsMem.ToString())
            ListBox1.Items.Add("Number of possible collisions or reception errors in this inventory: " + response.collisions.ToString())
            ListBox1.Items.Add("Q used in this inventory: " + response.Q.ToString())
            ListBox1.Items.Add("Number of full Q rounds done in this inventory: " + response.roundsDone.ToString())
            ListBox1.Items.Add("-------------EPC----------------")
            'Read result to TagStorage object
            Dim inv As NurApi.TagStorage = hNur.FetchTags(True)
            'Show results in the ListBox (EPC code)   
            Dim tag As NurApi.Tag
            For Each tag In inv
                ListBox1.Items.Add(tag.GetEpcString())
            Next

        Catch ex As Exception
            'Something went wrong.(usually transport not connected) Show reason in the MessageBox.
            MessageBox.Show(ex.ToString(), "Exception")
        End Try

    End Sub

End Class
