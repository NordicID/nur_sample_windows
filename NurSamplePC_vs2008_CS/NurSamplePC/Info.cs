using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using NurApiDotNet;

namespace NurSample
{
    public partial class Info : UserControl
    {
        NurApi hNur = null;

        public Info()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the NurApi.
        /// </summary>
        /// <param name="hNur">The handle of NurApi.</param>
        public void SetNurApi(NurApi hNur)
        {
            try
            {
                this.hNur = hNur;
                // Set event handlers for NurApi
                hNur.DisconnectedEvent += new EventHandler<NurApi.NurEventArgs>(hNur_DisconnectedEvent);
                hNur.ConnectedEvent += new EventHandler<NurApi.NurEventArgs>(hNur_ConnectedEvent);

                // Update the status of the connection
                if (hNur.IsConnected())
                    hNur_ConnectedEvent(hNur, null);
                else
                    hNur_DisconnectedEvent(hNur, null);
            }
            catch (NurApiException ex)
            {
                MessageBox.Show(ex.ToString(), Program.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the DisconnectedEvent event of the NUR module.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="NurApi.NurEventArgs" /> instance containing the event data.</param>
        private void hNur_DisconnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            NurApi hNur = sender as NurApi;
            UpdateInfo(hNur);
        }

        /// <summary>
        /// Handles the ConnectedEvent event of the NUR module.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="NurApi.NurEventArgs" /> instance containing the event data.</param>
        private void hNur_ConnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            NurApi hNur = sender as NurApi;
            UpdateInfo(hNur);
        }

        /// <summary>
        /// Updates the info.
        /// </summary>
        /// <param name="hNur">The NUR module handler.</param>
        private void UpdateInfo(NurApi hNur)
        {
            bool outdated = false;

            treeView1.Nodes.Clear();

            TreeNode node;
            TreeNode dllNode = treeView1.Nodes.Add("DLL Versions");
            try
            {
                string fileVersion = hNur.GetFileVersion();
                dllNode.Nodes.Add("NurApi.dll - " + fileVersion);
                dllNode.Nodes.Add("NurApiDotNet.dll - " + NurUtils.NurApiDotNetVersion);
            }
            catch (NurApiException ex)
            {
                AddExceptionNode(dllNode, ex, true);
            }

            if (hNur.IsConnected())
            {
                TreeNode fwinfoNode = treeView1.Nodes.Add("FWINFO (parsed string)");
                TreeNode structsNode = treeView1.Nodes.Add("Module settings (structs)");

                try
                {
                    NurApi.ReaderInfo readerInfo = hNur.GetReaderInfo();
                    tabPage1.Text = "Reader: " + readerInfo.name + ", "+ readerInfo.GetVersionString();
                    DumpObject(structsNode, readerInfo, null);
                }
                catch (NurApiException ex)
                {
                    AddExceptionNode(structsNode, ex, false);
                }

                try
                {
                    DumpObject(structsNode, GetVersions(hNur), null);
                    //DumpObject(structsNode, hNur.GetVersions(), null);
                }
                catch (NurApiException ex)
                {
                    AddExceptionNode(structsNode, ex, false);
                }

                try
                {
                    NurFwInfoParser fwinfo = new NurFwInfoParser(hNur.GetFWINFO());
                    foreach (KeyValuePair<string, string> entry in fwinfo.keypairs)
                    {
                        fwinfoNode.Nodes.Add(entry.Key + " = " + entry.Value);
                    }
                }
                catch (NurApiException ex)
                {
                    AddExceptionNode(fwinfoNode, ex, false);
                    fwinfoNode.Expand();
                    outdated = true;
                }

                try
                {
                    DumpObject(structsNode, hNur.GetDeviceCaps(), null);
                }
                catch (NurApiException ex)
                {
                    AddExceptionNode(structsNode, ex, false);
                }

                try
                {
                    DumpObject(structsNode, hNur.GetEthConfig(), null);
                }
                catch (NurApiException ex)
                {
                    AddExceptionNode(structsNode, ex, false);
                }

                try
                {
                    DumpObject(structsNode, hNur.GetModuleSetup(), null);
                }
                catch (NurApiException ex)
                {
                    AddExceptionNode(structsNode, ex, false);
                }

                try
                {
                    DumpObject(structsNode, hNur.GetSensorConfig(), null);
                }
                catch (NurApiException ex)
                {
                    AddExceptionNode(structsNode, ex, false);
                }

                TreeNode regNode = treeView1.Nodes.Add("Regions");
                int numRegions = 0;
                try
                {
                    NurApi.ReaderInfo readerInfo = hNur.GetReaderInfo();
                    // Dump region infos
                    for (int i = 0; i < readerInfo.numRegions; i++)
                    {
                        NurApi.RegionInfo ri = hNur.GetRegionInfo(i);
                        DumpObject(regNode, ri, string.Format("{0}: {1}", i, ri.name));
                        numRegions++;
                    }
                    // Dump CustomHoptable
                    try
                    {
                        NurApi.CustomHoptableEx customHoptableEx = hNur.GetCustomHoptableEx();
                        DumpObject(regNode, customHoptableEx, string.Format("{0}: {1}", NurApi.REGIONID_CUSTOM, "customHoptableEx"));
                        numRegions++;
                    }
                    catch (NurApiException ex)
                    {
                        try
                        {
                            AddExceptionNode(regNode, ex, false);
                            NurApi.CustomHoptable customHoptable = hNur.GetCustomHoptable();
                            DumpObject(regNode, customHoptable, string.Format("{0}: {1}", NurApi.REGIONID_CUSTOM, "customHoptable"));
                            numRegions++;
                        }
                        catch (NurApiException ex2)
                        {
                            AddExceptionNode(regNode, ex2, false);
                        }
                    }
                }
                catch (NurApiException ex)
                {
                    AddExceptionNode(structsNode, ex, true);
                }
                regNode.Text = string.Format("{0} ({1} pcs)", regNode.Text, numRegions);

                TreeNode antNode = treeView1.Nodes.Add("Antennas");
                try
                {
                    antNode.Nodes.Add("Selected - " + (hNur.SelectedAntenna == -1 ? "Auto" : hNur.SelectedAntenna.ToString()));
                    antNode.Nodes.Add("Enabled - " + GetEnabledAntennas());
                    node = antNode.Nodes.Add("Reflected Powers");
                    if (MeasureReflectedPowers(hNur, node))
                    {
                        antNode.Expand();
                    }
                }
                catch (NurApiException)
                {
                    node = antNode.Nodes.Add("Can't get antenna settings");
                    node.ForeColor = System.Drawing.Color.Red;
                    node.Expand();
                }
                structsNode.Expand();
            }
            else
            {
                tabPage1.Text = "No Connection";
            }

            if (outdated)
            {
                node = treeView1.Nodes.Add("The NUR modules firmware might be outdated. Please check for updates.");
                node.ForeColor = System.Drawing.Color.Red;
                node.Nodes.Add("E-mail: support@nordicid.com");
                node.Expand();
            }
        }

        /// <summary>
        /// Dumps the object.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="value">The object.</param>
        private void DumpObject(TreeNode node, object value, string title)
        {
            Type type = value.GetType();
            FieldInfo[] fi = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
            if (fi.Length > 0)
            {
                TreeNode thisnode = node.Nodes.Add(string.IsNullOrEmpty(title) ? type.Name : title);
                foreach (FieldInfo info in fi)
                {
                    if (info.FieldType.IsNested)
                    {
                        DumpObject(thisnode.Nodes.Add(info.Name), info.GetValue(value), null);
                    }
                    else if (info.FieldType.IsArray)
                    {
                        Array arr = (Array)info.GetValue(value);
                        TreeNode subnode = thisnode.Nodes.Add(string.Format("{0}[{1}]", info.Name, arr.Length));
                        for (int i = 0; i < arr.Length; i++)
                        {
                            object o = arr.GetValue(i);
                            DumpObject(subnode, o, null);
                        }
                    }
                    else
                    {
                        thisnode.Nodes.Add(info.Name + " = " + info.GetValue(value));
                    }
                }
            }
            else
            {
                node.Nodes.Add(value.ToString());
            }
        }

        private void AddExceptionNode(TreeNode node, NurApiException ex, bool colorize)
        {
            TreeNode newnode;
            if (ex.error == NurApiErrors.NUR_ERROR_INVALID_COMMAND)
                newnode = node.Nodes.Add(ex.TargetSite.ToString() + " - NOT SUPPORTED");
            else
                newnode = node.Nodes.Add(ex.Message);
            if (colorize)
            {
                newnode.ForeColor = System.Drawing.Color.Red;
                node.Expand();
            }
        }

        private string TxLevel2mW(int txLevel, double max_dBm)
        {
            int mW = (int)Math.Round(Math.Pow(10, (max_dBm - txLevel) / 10));
            return mW.ToString() + " mW";
        }

        private string GetEnabledAntennas()
        {
            StringBuilder sb = new StringBuilder();
            foreach (int index in hNur.EnabledAntennas)
            {
                if (sb.Length > 0)
                    sb.Append(", ");
                sb.Append(index.ToString());
            }
            return sb.ToString();
        }

        [DllImport("NurApi.dll", CharSet = CharSet.Unicode, SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        public static extern int NurApiGetVersions(IntPtr hApi, ref byte pMode, StringBuilder primary, StringBuilder secondary);

        /// <summary>
        /// Returns the current mode, primary and secondary version information.
        /// The NurApiDotNet.dll version 1.6.1 (and older) have a bug in
        /// NurApi.GetVersions method. This workaround fix the issue.
        /// </summary>
        public NurApi.ModuleVersions GetVersions(NurApi hNur)
        {
            int error;
            byte modeByte = 0;

            NurApi.ModuleVersions ver = new NurApi.ModuleVersions();
            ver.mode = 'Z';

            StringBuilder prim = new StringBuilder(100);
            StringBuilder sec = new StringBuilder(100);

            error = NurApiGetVersions(hNur.GetHandle(), ref modeByte, prim, sec);

            if (error != 0)
            {
                throw new NurApiException("GetVersions", error);
            }

            ver.mode = (char)modeByte;
            ver.primaryVersion = prim.ToString();
            ver.secondaryVersion = sec.ToString();

            return ver;
        }

        /// <summary>
        /// Measures the Reflected Powers from enabled antennas.
        /// </summary>
        /// <param name="hNur">The NUR module handler.</param>
        /// <param name="node">The TreeView node.</param>
        /// <returns>True is Poor Antenna Found</returns>
        bool MeasureReflectedPowers(NurApi hNur, TreeNode node)
        {
            // Measure Reflected Power
            bool poorAntennaFound = true;
            int tmpSelectdeAntenna = hNur.SelectedAntenna;
            bool tuneEventsEnabled = hNur.EnableTuneEvents;
            if (tuneEventsEnabled)
                hNur.EnableTuneEvents = false;

            foreach (int antenna in hNur.EnabledAntennas)
            {
                try
                {
                    // Select Antenna
                    hNur.SelectedAntenna = antenna;
                    // Measure Reflected Power
                    double dBm = hNur.GetReflectedPowerValue(0);
                    if (dBm < 0)
                    {
                        node.Nodes.Add(string.Format("Antenna {0}: Reflected Power {1:0.0} dBm", antenna, dBm));
                    }
                    else
                    {
                        TreeNode newNode = node.Nodes.Add(
                            string.Format("Antenna {0}: Reflected Power {1:0.0} dBm. Make sure that the antenna is connected.", antenna, dBm));
                        newNode.ForeColor = System.Drawing.Color.Red;
                        node.Expand();
                        poorAntennaFound = true;
                    }
                }
                catch (NurApiException)
                {
                    TreeNode newNode = node.Nodes.Add(
                        string.Format("Antenna {0}: Could not measure the Reflected Power.", antenna));
                    newNode.ForeColor = System.Drawing.Color.Red;
                    node.Expand();
                    poorAntennaFound = true;
                }
            }
            // Restore SelectedAntenna
            hNur.SelectedAntenna = tmpSelectdeAntenna;
            if (tuneEventsEnabled)
                hNur.EnableTuneEvents = true;
            return poorAntennaFound;
        }

        /// <summary>
        /// Refresh information.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void refreshButton_Click(object sender, EventArgs e)
        {
            UpdateInfo(hNur);
        }

        private void saveToXml_Button_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                NurSerializer nurSerializer = new NurSerializer();
                nurSerializer.Serialize(hNur);
                nurSerializer.SaveToFile(saveFileDialog1.FileName);
            }
        }
    }
}
