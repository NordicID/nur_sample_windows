using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using NurApiDotNet;

namespace NurSample
{
    public class NurSerializer
    {
        public struct NurInfo
        {
            public string NurApi;
            public string NurApiDotNet;
            public char mode;
            public NurApi.ReaderInfo readerInfo;
            public NurApi.ModuleVersions moduleVersions;
            public string FWINFO;
            public NurApi.DeviceCapabilites deviceCapabilites;
            public NurApi.ModuleSetup moduleSetup;
            public NurApi.SensorConfig sensorConfig;
            public NurApi.GpioEntry[] gpioEntry;
            public NurApi.GpioStatus[] gpioStatus;
            public NurApi.EthConfig ethConfig;
            public NurApi.RegionInfo[] regionInfo;
            public NurApi.CustomHoptable customHoptable;
            public NurApi.CustomHoptableEx customHoptableEx;
            public string[] AntennaInfo;
        }

        NurInfo nurInfo;
        XmlSerializer serializer;

        /// <summary>
        /// Serializes this instance.
        /// </summary>
        public void Serialize(NurApi hNur)
        {
            nurInfo = new NurInfo();
            try
            {
                nurInfo.NurApi = hNur.GetFileVersion();
            }
            catch (NurApiException) { }
            try
            {
                nurInfo.NurApiDotNet = NurUtils.NurApiDotNetVersion;
            }
            catch (NurApiException) { }
            try
            {
                nurInfo.mode = hNur.GetMode();
            }
            catch (NurApiException) { }
            try
            {
                nurInfo.readerInfo = hNur.GetReaderInfo();
            }
            catch (NurApiException) { }
            try
            {
                nurInfo.moduleVersions = hNur.GetVersions();
            }
            catch (NurApiException) { }
            try
            {
                nurInfo.FWINFO = hNur.GetFWINFO();
            }
            catch (NurApiException) { }
            try
            {
                nurInfo.deviceCapabilites = hNur.GetDeviceCaps();
            }
            catch (NurApiException) { }
            try
            {
                nurInfo.moduleSetup = hNur.GetModuleSetup();
            }
            catch (NurApiException) { }
            try
            {
                nurInfo.sensorConfig = hNur.GetSensorConfig();
            }
            catch (NurApiException) { }
            try
            {
                nurInfo.gpioEntry = hNur.GetGPIOConfig();
            }
            catch (NurApiException) { }
            try
            {
                nurInfo.gpioStatus = new NurApi.GpioStatus[nurInfo.readerInfo.numGpio];
                for (int i = 0; i < nurInfo.gpioStatus.Length; i++)
                {
                    nurInfo.gpioStatus[i] = hNur.GetGPIOStatus(i);
                }
            }
            catch (NurApiException) { }
            try
            {
                nurInfo.ethConfig = hNur.GetEthConfig();
            }
            catch (NurApiException) { }
            try
            {
                nurInfo.regionInfo = new NurApi.RegionInfo[nurInfo.readerInfo.numRegions];
                for (int i = 0; i < nurInfo.readerInfo.numRegions; i++)
                {
                    nurInfo.regionInfo[i] = hNur.GetRegionInfo(i);
                }
            }
            catch (NurApiException) { }
            try
            {
                nurInfo.customHoptable = hNur.GetCustomHoptable();
            }
            catch (NurApiException) { }
            try
            {
                nurInfo.customHoptableEx = hNur.GetCustomHoptableEx();
            }
            catch (NurApiException) { }
            try
            {
                nurInfo.AntennaInfo = MeasureReflectedPowers(hNur);
            }
            catch (NurApiException) { }

            serializer = new XmlSerializer(typeof(NurInfo));

        }

        /// <summary>
        /// Measures the reflected powers.
        /// </summary>
        /// <param name="hNur">The NurApi.</param>
        /// <returns></returns>
        string[] MeasureReflectedPowers(NurApi hNur)
        {
            List<string> antennaList = new List<string>();
            try
            {
                int tmpSelectdeAntenna = hNur.SelectedAntenna;
                uint tmpAntennaMaskEx = hNur.AntennaMaskEx;

                bool tuneEventsEnabled = hNur.EnableTuneEvents;
                if (tuneEventsEnabled)
                    hNur.EnableTuneEvents = false;

                // Measure Reflected Power
                foreach (string physicalAntenna in hNur.AvailablePhysicalAntennas)
                {
                    try
                    {
                        // Select Antenna
                        hNur.EnablePhysicalAntenna(physicalAntenna);
                        int antennaId = hNur.NurPhysicalAntennaToAntennaId(physicalAntenna);
                        hNur.SelectedAntenna = antennaId;
                        // Measure Reflected Power
                        double dBm = hNur.GetReflectedPowerValue(0);
                        if (dBm < 0)
                        {
                            antennaList.Add(string.Format("{0}:{1} = Reflected Power {2:0.0} dBm", antennaId, physicalAntenna, dBm));
                        }
                        else
                        {
                            antennaList.Add(string.Format("{0}:{1} = Reflected Power {2:0.0} dBm. This antenna may need service.", antennaId, physicalAntenna, dBm));
                        }
                    }
                    catch (NurApiException)
                    {
                        antennaList.Add(string.Format("{0} = Could not measure the Reflected Power.", physicalAntenna));
                    }
                }

                // Restore SelectedAntenna
                hNur.AntennaMaskEx = tmpAntennaMaskEx;
                hNur.SelectedAntenna = tmpSelectdeAntenna;
                if (tuneEventsEnabled)
                    hNur.EnableTuneEvents = true;
            }
            catch (NurApiException)
            {
            }
            return antennaList.ToArray();
        }

        /// <summary>
        /// Saves to file.
        /// </summary>
        /// <param name="path">The path.</param>
        public void SaveToFile(string path)
        {
            TextWriter textWriter = new StreamWriter(path);
            serializer.Serialize(textWriter, nurInfo);
            textWriter.Close();
        }

        /// <summary>
        /// Saves to stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        public void SaveToStream(Stream stream)
        {
            serializer.Serialize(stream, nurInfo);
        }
    }
}
