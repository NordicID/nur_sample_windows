Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms

Imports NurApiDotNet
'NurApi wrapper
Public Partial Class NurTagListView
	Inherits UserControl
	''' <summary>
	'     TagItem contains additional information about the tag
	'     like ListViewItem.
	''' </summary>
	Public Class TagItem
		Public Tag As NurApi.Tag
		Public TagViewItem As ListViewItem
		Public Sub New(tag As NurApi.Tag)
			Me.Tag = tag
			Me.TagViewItem = New ListViewItem(New String() {tag.rssi.ToString(), tag.GetEpcString()})
			Me.TagViewItem.Tag = Me
		End Sub
		Public Overrides Function ToString() As String
			Return Tag.GetEpcString()
		End Function
	End Class

	''' <summary>
	''' Initializes a new instance of the <see cref="NurTagListView"/> class.
	''' </summary>
	Public Sub New()
		InitializeComponent()
	End Sub

	''' <summary>
	''' Occurs when selected Tag changed.
	''' </summary>
	Public Event SelectedTagChanged As EventHandler

	''' <summary>
	''' Gets the selected tag.
	''' </summary>
	''' <value>
	''' The selected tag.
	''' </value>
	Public ReadOnly Property SelectedTag() As NurApi.Tag
		Get
			If tagListView.SelectedIndices.Count > 0 Then
				Dim tagItem As TagItem = TryCast(tagListView.Items(tagListView.SelectedIndices(0)).Tag, TagItem)
				Return tagItem.Tag
			End If
			Return Nothing
		End Get
	End Property

	''' <summary>
	''' Gets the focused item.
	''' </summary>
	''' <value>
	'  A System.Windows.Forms.ListViewItem that represents the item that has focus,
	'  or null if no item has the focus in the System.Windows.Forms.ListView.
	''' </value>
	Public ReadOnly Property FocusedItem() As ListViewItem
		Get
			Return tagListView.FocusedItem
		End Get
	End Property

	''' <summary>
	''' Clears the tag list.
	''' </summary>
	Public Sub ClearTagList()
		tagListView.Items.Clear()
	End Sub

	''' <summary>
	''' Updates the tag list.
	''' </summary>
	''' <param name="inventoriedTags">The inventoried tags.</param>
	''' <returns>The number of new tags</returns>
	Public Function UpdateTagList(inventoriedTags As NurApi.TagStorage) As Integer
		Dim numberOfNewTags As Integer = inventoriedTags.Count - tagListView.Items.Count
		If inventoriedTags.Count > tagListView.Items.Count Then
			' Update ListBox
			tagListView.BeginUpdate()
			For i As Integer = tagListView.Items.Count To inventoriedTags.Count - 1
				Dim tagItem As New TagItem(inventoriedTags(i))
				tagListView.Items.Add(tagItem.TagViewItem)
			Next
			tagListView.EndUpdate()
		End If
		Return numberOfNewTags
	End Function

	Private Sub tagListView_SelectedIndexChanged(sender As Object, e As EventArgs)
		RaiseEvent SelectedTagChanged(Me, e)
	End Sub
End Class
