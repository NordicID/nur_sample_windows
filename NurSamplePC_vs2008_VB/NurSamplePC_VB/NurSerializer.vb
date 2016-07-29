Imports System.Collections.Generic
Imports System.Text
Imports System.IO
Imports System.Xml.Serialization
Imports NurApiDotNet

Public Class NurSerializer
	Public Structure NurInfo
		Public NurApi As String
		Public NurApiDotNet As String
		Public mode As Char
		Public readerInfo As NurApi.ReaderInfo
		Public moduleVersions As NurApi.ModuleVersions
		Public FWINFO As String
		Public deviceCapabilites As NurApi.DeviceCapabilites
		Public moduleSetup As NurApi.ModuleSetup
		Public sensorConfig As NurApi.SensorConfig
		Public gpioEntry As NurApi.GpioEntry()
		Public gpioStatus As NurApi.GpioStatus()
		Public ethConfig As NurApi.EthConfig
		Public regionInfo As NurApi.RegionInfo()
		Public customHoptable As NurApi.CustomHoptable
		Public customHoptableEx As NurApi.CustomHoptableEx
		Public AntennaInfo As String()
	End Structure

    Private serNurInfo As NurInfo
    Private serializer As XmlSerializer

    ''' <summary>
    ''' Serializes this instance.
    ''' </summary>
    Public Sub Serialize(ByVal hNur As NurApi)
        serNurInfo = New NurInfo()
        Try
            serNurInfo.NurApi = hNur.GetFileVersion()
        Catch generatedExceptionName As NurApiException
        End Try
        Try
            serNurInfo.NurApiDotNet = NurUtils.NurApiDotNetVersion
        Catch generatedExceptionName As NurApiException
        End Try
        Try
            serNurInfo.mode = hNur.GetMode()
        Catch generatedExceptionName As NurApiException
        End Try
        Try
            serNurInfo.readerInfo = hNur.GetReaderInfo()
        Catch generatedExceptionName As NurApiException
        End Try
        Try
            serNurInfo.moduleVersions = hNur.GetVersions()
        Catch generatedExceptionName As NurApiException
        End Try
        Try
            serNurInfo.FWINFO = hNur.GetFWINFO()
        Catch generatedExceptionName As NurApiException
        End Try
        Try
            serNurInfo.deviceCapabilites = hNur.GetDeviceCaps()
        Catch generatedExceptionName As NurApiException
        End Try
        Try
            serNurInfo.moduleSetup = hNur.GetModuleSetup()
        Catch generatedExceptionName As NurApiException
        End Try
        Try
            serNurInfo.sensorConfig = hNur.GetSensorConfig()
        Catch generatedExceptionName As NurApiException
        End Try
        Try
            serNurInfo.gpioEntry = hNur.GetGPIOConfig()
        Catch generatedExceptionName As NurApiException
        End Try
        Try
            serNurInfo.gpioStatus = New NurApi.GpioStatus(serNurInfo.readerInfo.numGpio - 1) {}
            For i As Integer = 0 To serNurInfo.gpioStatus.Length - 1
                serNurInfo.gpioStatus(i) = hNur.GetGPIOStatus(i)
            Next
        Catch generatedExceptionName As NurApiException
        End Try
        Try
            serNurInfo.ethConfig = hNur.GetEthConfig()
        Catch generatedExceptionName As NurApiException
        End Try
        Try
            serNurInfo.regionInfo = New NurApi.RegionInfo(serNurInfo.readerInfo.numRegions - 1) {}
            For i As Integer = 0 To serNurInfo.readerInfo.numRegions - 1
                serNurInfo.regionInfo(i) = hNur.GetRegionInfo(i)
            Next
        Catch generatedExceptionName As NurApiException
        End Try
        Try
            serNurInfo.customHoptable = hNur.GetCustomHoptable()
        Catch generatedExceptionName As NurApiException
        End Try
        Try
            serNurInfo.customHoptableEx = hNur.GetCustomHoptableEx()
        Catch generatedExceptionName As NurApiException
        End Try
        Try
            serNurInfo.AntennaInfo = MeasureReflectedPowers(hNur)
        Catch generatedExceptionName As NurApiException
        End Try

        serializer = New XmlSerializer(GetType(NurInfo))

    End Sub

    ''' <summary>
    ''' Measures the reflected powers.
    ''' </summary>
    ''' <param name="hNur">The NurApi.</param>
    ''' <returns></returns>
    Private Function MeasureReflectedPowers(ByVal hNur As NurApi) As String()
        Dim antennaList As New List(Of String)()
        Try
            ' Measure Reflected Power
            Dim antenna As Integer = 0
            Dim mask As Integer = hNur.AntennaMask
            If mask > 0 Then
                Dim tmpSelectdeAntenna As Integer = hNur.SelectedAntenna
                While mask > 0
                    If (mask And 1) <> 0 Then
                        Try
                            ' Select Antenna
                            hNur.SelectedAntenna = antenna
                            ' Measure Reflected Power
                            Dim regionInfo As NurApi.RegionInfo = hNur.GetRegionInfo()
                            hNur.GetReflectedPower(regionInfo.baseFrequency)
                            ' FW bug fix
                            Dim rpInfo As NurApi.ReflectedPowerInfo = hNur.GetReflectedPower()
                            ' Calculate Reflected Power
                            Dim rf As Double = Math.Sqrt(CDbl(rpInfo.iPart * rpInfo.iPart + rpInfo.qPart * rpInfo.qPart))
                            rf /= CDbl(rpInfo.div)
                            rf = Math.Log10(rf) * 20.0
                            If [Double].IsInfinity(rf) Then
                                rf = -30
                            End If
                            If rf < 0 Then
                                antennaList.Add(String.Format("Antenna {0} = Reflected Power {1:0.0} dBm", antenna, rf))
                            Else
                                antennaList.Add(String.Format("Antenna {0} = Reflected Power {1:0.0} dBm. Make sure that the antenna is connected.", antenna, rf))
                            End If
                        Catch generatedExceptionName As NurApiException
                            antennaList.Add(String.Format("Antenna {0} = Could not measure the Reflected Power.", antenna))
                        End Try
                    End If
                    mask = mask >> 1
                    antenna += 1
                End While
                ' Restore SelectedAntenna
                hNur.SelectedAntenna = tmpSelectdeAntenna
            Else
                antennaList.Add("No eabled antennas!")
            End If
        Catch generatedExceptionName As NurApiException
        End Try
        Return antennaList.ToArray()
    End Function

    ''' <summary>
    ''' Saves to file.
    ''' </summary>
    ''' <param name="path">The path.</param>
    Public Sub SaveToFile(ByVal path As String)
        Dim textWriter As TextWriter = New StreamWriter(path)
        serializer.Serialize(textWriter, serNurInfo)
        textWriter.Close()
    End Sub

    ''' <summary>
    ''' Saves to stream.
    ''' </summary>
    ''' <param name="stream">The stream.</param>
    Public Sub SaveToStream(ByVal stream As Stream)
        serializer.Serialize(stream, serNurInfo)
    End Sub
End Class
