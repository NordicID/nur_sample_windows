using System;
using System.Collections.Generic;
using System.Text;

using NurApiDotNet;

namespace NurPositioningApiSample
{
    class EthHelper
    {
        public static string IpToString(byte[] ip)
        {
            if (ip == null)
                return System.Net.IPAddress.None.ToString();
            System.Net.IPAddress ipAddress = new System.Net.IPAddress(ip);
            return ipAddress.ToString();
        }

        public static string MacToString(byte[] mac)
        {
            return string.Format("{0:x2}-{1:x2}-{2:x2}-{3:x2}-{4:x2}-{5:x2}",
                mac[0], mac[1], mac[2], mac[3], mac[4], mac[5]);
        }

        public static string EthAddrTypeToString(NurApi.EthConfig eth)
        {
            if (eth.addrType > 0)
                return "Static";
            else
                return "DHCP";
        }

        public static string EthHostModeToString(NurApi.EthConfig eth)
        {
            if (eth.hostmode > 0)
                return "Client";
            else
                return "Server";
        }

        public static string EthHostModeToString(NurApi.DevInfoData devInfoData)
        {
            if (devInfoData.status > 0)
                return "Connected";
            else
                return "Disconnected";
        }
    }
}
