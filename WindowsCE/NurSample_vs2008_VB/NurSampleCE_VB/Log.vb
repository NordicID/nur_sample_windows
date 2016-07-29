Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports System.IO

Imports NurApiDotNet
'NurApi wrapper
Partial Public Class Log
    Inherits UserControl
    ''' <summary>
    ''' The NurApi handle
    ''' </summary>
    Private hNur As NurApi = Nothing

    ''' <summary>
    ''' Initializes a new instance of the <see cref="Inventory" /> class.
    ''' </summary>
    Public Sub New()
        InitializeComponent()
        Me.Enabled = False
    End Sub

    ''' <summary> 
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    ''' <summary>
    ''' Sets the NurApi.
    ''' </summary>
    ''' <param name="hNur">The handle of NurApi.</param>
    Public Sub SetNurApi(ByVal hNur As NurApi)
        Try
            Me.hNur = hNur
            ' Set event handlers for NurApi
            AddHandler hNur.LogEvent, New EventHandler(Of NurApi.LogEventArgs)(AddressOf hNur_LogEvent)
            ' Update CheckBoxes
            Dim mask As Integer = hNur.GetLogLevel()
            logVerboseCheckBox.Checked = (mask And NurApi.LOG_VERBOSE) <> 0
            logErrorCheckBox.Checked = (mask And NurApi.LOG_ERROR) <> 0
            logUserCheckBox.Checked = (mask And NurApi.LOG_USER) <> 0
            logDataCheckBox.Checked = (mask And NurApi.LOG_DATA) <> 0
            ' Enable controls
            Me.Enabled = True
        Catch ex As NurApiException
            MessageBox.Show(ex.ToString(), Program.appName)
        End Try
    End Sub

    Private Sub hNur_LogEvent(ByVal sender As Object, ByVal e As NurApi.LogEventArgs)
        Dim hNur As NurApi = TryCast(sender, NurApi)
        logListBox.Items.Add(String.Format("{0,8}: {1}", e.timestamp, e.message))
        While logListBox.Items.Count > 500
            logListBox.Items.RemoveAt(0)
        End While
        'logListBox.SelectedIndex = logListBox.Items.Count - 1;
    End Sub

    Private Sub logVerboseCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim mask As Integer = hNur.GetLogLevel()
        If logVerboseCheckBox.Checked Then
            mask = mask Or NurApi.LOG_VERBOSE
        Else
            mask = mask And Not NurApi.LOG_VERBOSE
        End If
        hNur.SetLogLevel(mask)
    End Sub

    Private Sub logErrorCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim mask As Integer = hNur.GetLogLevel()
        If logErrorCheckBox.Checked Then
            mask = mask Or NurApi.LOG_ERROR
        Else
            mask = mask And Not NurApi.LOG_ERROR
        End If
        hNur.SetLogLevel(mask)
    End Sub

    Private Sub logUserCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim mask As Integer = hNur.GetLogLevel()
        If logUserCheckBox.Checked Then
            mask = mask Or NurApi.LOG_USER
        Else
            mask = mask And Not NurApi.LOG_USER
        End If
        hNur.SetLogLevel(mask)
    End Sub

    Private Sub logDataCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim mask As Integer = hNur.GetLogLevel()
        If logDataCheckBox.Checked Then
            mask = mask Or NurApi.LOG_DATA
        Else
            mask = mask And Not NurApi.LOG_DATA
        End If
        hNur.SetLogLevel(mask)
    End Sub

    Private Sub clearButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        logListBox.Items.Clear()
    End Sub

    Private Sub saveButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            Using sw As New StreamWriter(saveFileDialog1.FileName)
                For r As Integer = 0 To logListBox.Items.Count - 1
                    sw.WriteLine(logListBox.Items(r).ToString())
                Next
                sw.Flush()
            End Using
        End If
    End Sub

    Private Sub logToFileButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        If hNur.GetLogToFile() = False Then
            If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                hNur.SetLogFilePath(saveFileDialog1.FileName)
                hNur.SetLogToFile(True)
                logToFileButton.Text = "Stop logging into file"
            End If
        Else
            hNur.SetLogToFile(False)
            logToFileButton.Text = "Log to file"
        End If
    End Sub
End Class
