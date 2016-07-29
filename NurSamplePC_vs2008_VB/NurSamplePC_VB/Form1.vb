Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports NurApiDotNet
'Need to use namespace of NurApiDotNet
Public Partial Class Form1
	Inherits Form
	''' <summary>
	''' The NurApi handle
	''' </summary>
	Private hNur As NurApi = Nothing
	' Handle of NurApi
	''' <summary>
	''' Initializes a new instance of the <see cref="Form1" /> class.
	''' </summary>
	Public Sub New()
		InitializeComponent()
		Me.Text = String.Format("{0} v{1}", System.Reflection.Assembly.GetEntryAssembly().GetName().Name, System.Reflection.Assembly.GetEntryAssembly().GetName().Version)

		Try
			' Call NurApi constructor and give Form object for receive notifications
			' in same thread where this Control is running
			hNur = New NurApi(Me)
			'Handle of NurApi
			NurCapabilities.I.Nur = hNur
		Catch ex As Exception
			MessageBox.Show(ex.ToString(), Program.appName, MessageBoxButtons.OK, MessageBoxIcon.[Error])
			Me.Close()
			Return
		End Try

		' Set NurApi for UserControls
		nurLog.SetNurApi(hNur)
		nurInfo.SetNurApi(hNur)
		nurConnection.SetNurApi(hNur)
		nurInventory.SetNurApi(hNur)
		nurWriter.SetNurApi(hNur)
		nurLocator.SetNurApi(hNur)
		nurSettings.SetNurApi(hNur)
		nurNxp.SetNurApi(hNur)
		nurSensors.SetNurApi(hNur)
	End Sub

	''' <summary>
	''' Handles the Load event of the Form1 control.
	''' </summary>
	''' <param name="sender">The source of the event.</param>
	''' <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
	Private Sub Form1_Load(sender As Object, e As EventArgs)
	End Sub

	''' <summary>
	''' Handles the Closing event of the Form1 control.
	''' </summary>
	''' <param name="sender">The source of the event.</param>
	''' <param name="e">The <see cref="CancelEventArgs" /> instance containing the event data.</param>
	Private Sub Form1_Closing(sender As Object, e As CancelEventArgs)
		' Dispose Locator
		nurLocator.Dispose()
		' Dispose NurApi
		If hNur IsNot Nothing Then
			If hNur.IsConnected() Then
				hNur.Disconnect()
			End If
			hNur.Dispose()
		End If
	End Sub
End Class
