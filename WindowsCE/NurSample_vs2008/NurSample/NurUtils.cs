using System;
using System.Collections.Generic;
using System.Text;

using NurApiDotNet;

namespace NurSample
{
    class NurUtils
    {
        const int RETRIES = 4;
        const int MAX_TX_LEVEL = 0;
        const int MIN_TX_LEVEL = 19;

        /// <summary>
        /// Searches the stronges (the highest RSSI) tag.
        /// </summary>
        /// <param name="hNur">The NurApi header.</param>
        /// <param name="autoTxLevel">if set to <c>true</c> [use auto tx level].</param>
        /// <param name="tag">reference for the nearest tag</param>
        /// <param name="usedTxLevel">reference for the used TxLevel.</param>
        /// <returns>
        /// The number of found tags.
        /// </returns>
        public static int SearchNearestTag(NurApi hNur, bool autoTxLevel, out NurApi.Tag tag, out int usedTxLevel)
        {
            // Set the used TxLevel
            usedTxLevel = hNur.TxLevel;
            // Clear previously inventoried tags from memory
            hNur.ClearTags();
            NurApi.TagStorage inventoriedTags = null;

            if (autoTxLevel)
            {
                // Backup TX Level
                int backupTxLevel = hNur.TxLevel;
                // Search Tags with auto TX Level
                for (int tx = MIN_TX_LEVEL; tx >= MAX_TX_LEVEL; tx--)
                {
                    // Set TX Level
                    hNur.TxLevel = tx;
                    // Set the used TxLevel
                    usedTxLevel = tx;
                    // Perform simple inventory
                    NurApi.InventoryResponse ir = hNur.SimpleInventory();
                    // Did we find any Tag
                    if (ir.numTagsMem > 0)
                        // Yes we did
                        break;
                }
                // Fetch tags from module, including tag meta
                inventoriedTags = hNur.FetchTags(true);
                // Restore TX Level
                hNur.TxLevel = backupTxLevel;
            }
            else
            {
                // Search Tags with fixed TX Level
                for (int i = 0; i < RETRIES; i++)
                {
                    // Perform simple inventory
                    NurApi.InventoryResponse ir = hNur.SimpleInventory();
                    // Did we find any Tag
                    if (ir.numTagsMem > 0)
                        // Yes we did
                        break;
                }
                // Fetch tags from module, including tag meta
                inventoriedTags = hNur.FetchTags(true);
            }

            // Search stongest Tag
            tag = null;
            int maxRssi = -128;
            for (int i = 0; i < inventoriedTags.Count; i++)
            {
                if (maxRssi < inventoriedTags[i].rssi)
                {
                    maxRssi = inventoriedTags[i].rssi;
                    tag = inventoriedTags[i];
                }
            }

            // Return number of found tags
            return inventoriedTags.Count;
        }

        static public uint ReadAccessPasswordByEPC(NurApi hNur, uint passwd, bool secured, byte[] epc)
        {
            uint pwd = 0;
            NurApiException tempException = null;

            // READ ACCESS PWD
            for (int i = 0; i < RETRIES; i++)
            {
                // Try to read Access pwd with given password
                try
                {
                    pwd = hNur.GetAccessPasswordByEPC(passwd, secured, epc);
                    tempException = null;
                    break;
                }
                catch (NurApiException ex)
                {
                    tempException = ex;
                }
                // Previous attempt failed so try to read Access pwd without password
                if (secured)
                {
                    try
                    {
                        pwd = hNur.GetAccessPasswordByEPC(0, false, epc);
                        tempException = null;
                        break;
                    }
                    catch (NurApiException ex)
                    {
                        tempException = ex;
                    }
                }
            }
            if (tempException != null)
                throw tempException;

            return pwd;
        }

        static public uint ReadKillPasswordByEPC(NurApi hNur, uint passwd, bool secured, byte[] epc)
        {
            uint pwd = 0;
            NurApiException tempException = null;

            // READ KILL PWD
            for (int i = 0; i < RETRIES; i++)
            {
                // Try to read Kill pwd with given password
                try
                {
                    pwd = hNur.GetKillPasswordByEPC(passwd, secured, epc);
                    tempException = null;
                    break;
                }
                catch (NurApiException ex)
                {
                    tempException = ex;
                }
                // Previous attempt failed so try to read Kill pwd without password
                if (secured)
                {
                    try
                    {
                        pwd = hNur.GetKillPasswordByEPC(0, false, epc);
                        tempException = null;
                        break;
                    }
                    catch (NurApiException ex)
                    {
                        tempException = ex;
                    }
                }
            }
            if (tempException != null)
                throw tempException;

            return pwd;
        }

        /// <summary>
        // Return version number of NurApiDotNet.dll
        /// </summary>
        public static string NurApiDotNetVersion
        {
            get
            {
                try
                {
                    System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom("NurApiDotNetWCE.dll");
                    return assembly.GetName().Version.ToString();
                }
                catch (Exception)
                {
                    return "unknown";
                }
            }
        }
    }
}
