using System;
using System.Collections.Generic;
using System.Text;

namespace NurApiDotNet
{
    public class NurFwInfoParser
    {
        // Examples:
        // <FWINFO>MODULE=NUR-05W;TYPE=LOADER;VER=1.9-A;DATE=Sep 18 2013 12:30:39</FWINFO>
        // <FWINFO>MODULE=NUR-05WL2;TYPE=APP;VER=4.2-A;DATE=Oct 29 2013 08:10:40</FWINFO>
        // <FWINFO>MODULE=NUR-05WL2;TYPE=APP;VER=4.2-F;DATE=Nov 11 2013 08:43:57;SPECIALBUILD=STANDALONE1</FWINFO>

        private readonly string BEGINTAG = "<FWINFO>";
        private readonly string ENDTAG = "</FWINFO>";
        private string fwinfo = string.Empty;
        public Dictionary<string, string> keypairs = new Dictionary<string, string>();

        public NurFwInfoParser()
        {
        }

        public NurFwInfoParser(string fwinfo)
        {
            FWINFO = fwinfo;
        }

        public string FWINFO
        {
            get { return fwinfo; }
            set
            {
                fwinfo = value;
                keypairs.Clear();
                string info = fwinfo.Replace(BEGINTAG, "");
                info = info.Replace(ENDTAG, "");
                string[] keyValues = info.Split(new char[] { ';' });
                foreach (string keyValue in keyValues)
                {
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        string[] pair = keyValue.Split(new char[] { '=' });
                        keypairs.Add(pair[0], pair[1]);
                    }
                }
            }
        }

        public string LoadFwInfoFromFile(string filename)
        {
            FWINFO = string.Empty;
            byte[] fileBytes = System.IO.File.ReadAllBytes(filename);
            byte[] pattern = Encoding.ASCII.GetBytes(BEGINTAG);
            int begin = IndexOfBytes(fileBytes, pattern, 0, fileBytes.Length);
            if (begin > -1)
            {
                pattern = Encoding.ASCII.GetBytes(ENDTAG);
                int end = IndexOfBytes(fileBytes, pattern, begin, fileBytes.Length - begin);
                FWINFO = Encoding.ASCII.GetString(fileBytes, begin, (end - begin) + pattern.Length);
                return FWINFO;
            }
            return string.Empty;
        }

        public string GetValue(string key)
        {
            string val;
            if (keypairs.TryGetValue(key, out val))
            {
                return val;
            }
            return string.Empty;
        }

        public bool Compare(NurFwInfoParser fwInfoParser)
        {
            try
            {
                foreach (KeyValuePair<string, string> entry in keypairs)
                {
                    if (!fwInfoParser.keypairs[entry.Key].Equals(entry.Value))
                        return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private int IndexOfBytes(byte[] array, byte[] pattern, int startIndex, int count)
        {
            if (array == null || array.Length == 0 || pattern == null || pattern.Length == 0 || count == 0)
            {
                return -1;
            }
            int i = startIndex;
            int endIndex = count > 0 ? Math.Min(startIndex + count, array.Length) : array.Length;
            int fidx = 0;
            int lastFidx = 0;

            while (i < endIndex)
            {
                lastFidx = fidx;
                fidx = (array[i] == pattern[fidx]) ? ++fidx : 0;
                if (fidx == pattern.Length)
                {
                    return i - fidx + 1;
                }
                if (lastFidx > 0 && fidx == 0)
                {
                    i = i - lastFidx;
                    lastFidx = 0;
                }
                i++;
            }
            return -1;
        }
    }
}
