using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NurSample
{
    class LogToFile
    {
        StreamWriter logStreamWriter = null;

        /// <summary>
        /// Starts the log.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="mode">The mode (0 = Create new always, 1 = Append, 2 = Replace).</param>
        public void StartLog(string filename, int mode)
        {
            switch (mode)
            {
                case 1:
                    logStreamWriter = File.AppendText(filename);
                    return;
                case 2:
                    logStreamWriter = File.CreateText(filename);
                    return;
                case 0:
                default:
                    logStreamWriter = File.CreateText(NextAvailableFilename(filename));
                    return;
            }
        }

        public void WriteLog(string log)
        {
            try
            {
                logStreamWriter.WriteLine(log);
            }
            catch (Exception)
            {
            }
        }

        public void StopLog()
        {
            try
            {
                logStreamWriter.Close();
            }
            catch (Exception)
            {
            }
        }

        private static string numberPattern = " ({0})";

        /// <summary>
        /// Nexts the available filename.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static string NextAvailableFilename(string path)
        {
            // Short-cut if already available
            if (!File.Exists(path))
                return path;

            // If path has extension then insert the number pattern just before the extension and return next filename
            if (Path.HasExtension(path))
                return GetNextFilename(path.Insert(path.LastIndexOf(Path.GetExtension(path)), numberPattern));

            // Otherwise just append the pattern to the path and return next filename
            return GetNextFilename(path + numberPattern);
        }

        /// <summary>
        /// Gets the next filename.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">The pattern must include an index place-holder;pattern</exception>
        private static string GetNextFilename(string pattern)
        {
            string tmp = string.Format(pattern, 1);
            if (tmp == pattern)
                throw new ArgumentException("The pattern must include an index place-holder", "pattern");

            if (!File.Exists(tmp))
                return tmp; // short-circuit if no matches

            int min = 1, max = 2; // min is inclusive, max is exclusive/untested

            while (File.Exists(string.Format(pattern, max)))
            {
                min = max;
                max *= 2;
            }

            while (max != min + 1)
            {
                int pivot = (max + min) / 2;
                if (File.Exists(string.Format(pattern, pivot)))
                    min = pivot;
                else
                    max = pivot;
            }

            return string.Format(pattern, max);
        }
    }
}
