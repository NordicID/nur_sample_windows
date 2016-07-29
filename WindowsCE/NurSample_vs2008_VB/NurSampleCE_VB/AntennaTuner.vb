Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

Imports NurApiDotNet
'NurApi wrapper
Partial Public Class AntennaTuner
    Inherits UserControl
    Private hNur As NurApi = Nothing

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub NurTune_Load(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    ''' <summary>
    ''' Sets the NurApi.
    ''' </summary>
    ''' <param name="hNur">The handle of NurApi.</param>
    Public Sub SetNurApi(ByVal hNur As NurApi)
        Try
            Me.hNur = hNur

            ' Set event handlers for NurApi
            AddHandler hNur.DisconnectedEvent, New EventHandler(Of NurApi.NurEventArgs)(AddressOf hNur_DisconnectedEvent)
            AddHandler hNur.ConnectedEvent, New EventHandler(Of NurApi.NurEventArgs)(AddressOf hNur_ConnectedEvent)

            ' Update the status of the connection
            If hNur.IsConnected() Then
                hNur_ConnectedEvent(hNur, Nothing)
            Else
                hNur_DisconnectedEvent(hNur, Nothing)
            End If
        Catch ex As NurApiException
            MessageBox.Show(ex.ToString(), Program.appName)
        End Try
    End Sub

    ''' <summary>
    ''' Handles the DisconnectedEvent event of the NUR module.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="NurApi.NurEventArgs" /> instance containing the event data.</param>
    Private Sub hNur_DisconnectedEvent(ByVal sender As Object, ByVal e As NurApi.NurEventArgs)
        Dim hNur As NurApi = TryCast(sender, NurApi)
        Me.Enabled = False
    End Sub

    ''' <summary>
    ''' Handles the ConnectedEvent event of the NUR module.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="NurApi.NurEventArgs" /> instance containing the event data.</param>
    Private Sub hNur_ConnectedEvent(ByVal sender As Object, ByVal e As NurApi.NurEventArgs)
        Dim hNur As NurApi = TryCast(sender, NurApi)
        Try
            Me.Enabled = NurCapabilities.I.DeviceCaps.tune
            If NurCapabilities.I.DeviceCaps.tune = False Then
                AddMessage("Not available with this module!!!")
            End If
        Catch generatedExceptionName As NurApiException
            Me.Enabled = False
        End Try
    End Sub

    ''' <summary>
    ''' Handles the Click event of the measureReflegtedPowerButton control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub measureReflegtedPowerButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        AddMessage("*** Measure Reflected Powers *** ")
        MeasureReflectedPowers()
    End Sub

    ''' <summary>
    ''' Handles the Click event of the tuneButton control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub tuneButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        AddMessage("*** Measure Reflected Powers *** ")
        MeasureReflectedPowers()
        AddMessage("*** Tune Antennas *** ")
        TuneAntennas()
        AddMessage("*** Measure Reflected Powers *** ")
        MeasureReflectedPowers()
    End Sub

    Private Sub restoreFactoryTuningsButtons_Click(ByVal sender As Object, ByVal e As EventArgs)
        AddMessage("*** Measure Reflected Powers *** ")
        MeasureReflectedPowers()
        AddMessage("*** Restore Factory Tuning *** ")
        RestoreTuning()
        AddMessage("*** Measure Reflected Powers *** ")
        MeasureReflectedPowers()
    End Sub


    ''' <summary>
    ''' Tunes the antennas.
    ''' </summary>
    Private Sub TuneAntennas()
        Try
            Dim antenna As Integer = 0
            Dim mask As Integer = hNur.AntennaMask
            If mask > 0 Then
                While mask > 0
                    If (mask And 1) <> 0 Then
                        For band As Integer = 0 To 5
                            Try
                                Dim duration As Integer = System.Environment.TickCount
                                Dim reply As NurTuner.TuneResult()
                                reply = NurTuner.Tune(hNur, NurTuner.TYPE.WIDE, antenna, band, -50, True)
                                duration = System.Environment.TickCount - duration
                                ShowResults(reply, duration)
                            Catch ex As NurApiException
                                AddMessage("Error " + ex.[error] + ". ")
                            End Try
                            HHUtils.KeepDeviceAlive()
                        Next
                        mask = mask >> 1
                        antenna += 1
                    End If
                End While
                AddMessage("Done")
            End If
        Catch ex As NurApiException
            AddMessage("NurApiException " + ex.[error])
        End Try
    End Sub

    Private Sub ShowResults(ByVal resp As NurTuner.TuneResult(), ByVal duration As Integer)
        Dim sb As New StringBuilder()
        sb.Append(String.Format("Ant{0}, ", resp(0).antenna))
        For i As Integer = 0 To resp.Length - 1
            sb.Append(String.Format("Bnd{0}={1}, ", resp(i).band, resp(i).ToString()))
        Next
        sb.Append(String.Format("{0} ms", duration))
        AddMessage(sb.ToString())
    End Sub

    ''' <summary>
    ''' Measures the Reflected Powers from enabled antennas.
    ''' </summary>
    Private Sub MeasureReflectedPowers()
        Try
            AddMessage(Convert.ToString("Region: ") & hNur.GetRegionInfo().name)

            ' Measure Reflected Power
            Dim antenna As Integer = 0
            Dim mask As Integer = hNur.AntennaMask
            Dim sb As New StringBuilder()
            If mask > 0 Then
                Dim tmpSelectdeAntenna As Integer = hNur.SelectedAntenna
                While mask > 0
                    If (mask And 1) <> 0 Then
                        Try
                            ' Select Antenna
                            hNur.SelectedAntenna = antenna
                            ' Measure Reflected Power
                            'NurApi.RegionInfo regionInfo = hNur.GetRegionInfo();
                            'hNur.GetReflectedPower(regionInfo.baseFrequency); // FW bug fix
                            Dim rpInfo As NurApi.ReflectedPowerInfo = hNur.GetReflectedPower()
                            ' Calculate Reflected Power
                            Dim rf As Double = Math.Sqrt(CDbl(rpInfo.iPart * rpInfo.iPart + rpInfo.qPart * rpInfo.qPart))
                            rf /= CDbl(rpInfo.div)
                            rf = Math.Log10(rf) * 20.0
                            If [Double].IsInfinity(rf) Then
                                rf = -30
                            End If
                            sb.Append(String.Format("Ant{0}: {1:0.0} dBm, ", antenna, rf))
                        Catch generatedExceptionName As NurApiException
                            sb.Append(String.Format("Ant{0}: ?.? dBm, ", antenna))
                        End Try
                    End If
                    mask = mask >> 1
                    antenna += 1
                End While
                ' Restore SelectedAntenna
                hNur.SelectedAntenna = tmpSelectdeAntenna
            Else
                sb.Append("No eabled antennas!")
            End If
            sb.Replace(", ", "", sb.Length - 2, 2)
            AddMessage(sb.ToString())
            AddMessage("Done")
        Catch ex As NurApiException
            AddMessage("NurApiException " + ex.[error])
        End Try
    End Sub

    ''' <summary>
    ''' Tunes the antennas.
    ''' </summary>
    Private Sub RestoreTuning()
        Try
            hNur.RestoreTuning(True)
            AddMessage("Done")
        Catch ex As NurApiException
            AddMessage("NurApiException " + ex.[error])
        End Try
    End Sub

    ''' <summary>
    ''' Adds message to listBox.
    ''' </summary>
    ''' <param name="message">The message.</param>
    Private Sub AddMessage(ByVal message As String)
        listBox1.Items.Add(message)
        listBox1.SelectedIndex = listBox1.Items.Count - 1
        Application.DoEvents()
    End Sub
End Class
