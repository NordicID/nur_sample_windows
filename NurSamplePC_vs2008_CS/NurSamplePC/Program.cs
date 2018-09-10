using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NurSample
{
    static class Program
    {
        /// <summary>
        // Return name of application
        /// </summary>
        public static string appName
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().GetName().Name.ToString();
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Program.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}