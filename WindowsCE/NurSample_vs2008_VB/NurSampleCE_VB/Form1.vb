Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports NordicId
Imports NurApiDotNet
'Need to use namespace of NurApiDotNet
Partial Public Class Form1
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
        Fullscreen.Init()
        Fullscreen.SetFullScreen(True)
        Me.Text = String.Format("{0} v{1}", System.Reflection.Assembly.GetExecutingAssembly().GetName().Name, System.Reflection.Assembly.GetExecutingAssembly().GetName().Version)
        Me.WindowState = FormWindowState.Maximized

        Try
            ' Call NurApi constructor and give Form object for receive notifications
            ' in same thread where this Control is running
            hNur = New NurApi(Me)
            'Handle of NurApi
            'hNur.SetLogLevel(NurApi.LOG_ALL & ~NurApi.LOG_DATA);
            NurCapabilities.I.Nur = hNur
        Catch ex As Exception
            MessageBox.Show(ex.Message, Program.appName)
            Me.Close()
            Return
        End Try

        ' Set NurApi for UserControls
        nurLog.SetNurApi(hNur)
        nurInfo.SetNurApi(hNur)
        nurInventory.SetNurApi(hNur)
        nurWriter.SetNurApi(hNur)
        nurLocator.SetNurApi(hNur)
        nurSettings.SetNurApi(hNur)
        nurNxp.SetNurApi(hNur)

        Try
            ' Configure Scan & Trigger -buttons
            HHScanButton.ConfigureScanButtons(DirectCast(NordicId.VK.SCAN, Keys))
            HHScanButton.ScanButtonMode = HHScanButton.SCANMODE.NONE

        Catch generatedExceptionName As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Handles the Load event of the Form1 control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
        ' Connect Nur -module
        hNur.ConnectIntegratedReader()
    End Sub

    ''' <summary>
    ''' Handles the Closing event of the Form1 control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="CancelEventArgs" /> instance containing the event data.</param>
    Private Sub Form1_Closing(ByVal sender As Object, ByVal e As CancelEventArgs)
        ' Restore Scan & Trigger -button configurations
        HHScanButton.RestoreScanButtons()

        ' Stop locationg thread if running
        nurLocator.StopLocating()

        ' Dispose NurApi
        If hNur IsNot Nothing Then
            If hNur.IsConnected() Then
                hNur.Disconnect()
            End If
            hNur.Dispose()
        End If
        Fullscreen.SetFullScreen(False)
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        ' Make sure that this.KeyPreview is turned on.
        Select Case e.KeyCode
            Case DirectCast(NordicId.VK.SCAN, Keys)
                ' Jump to inventory -tab and start / stop inventory
                tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(inventoryTab)
                nurInventory.startStopInventoryBtn_Click(Me, EventArgs.Empty)
                e.Handled = True
                Exit Select
        End Select
    End Sub
End Class
