using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NurApiDotNet;

/*
Hello NUR is simple sample which connects to Sampo S1 reader via USB and acquire reader information and shows it in the ListBox.
------------------------------------------
Guidelines creating NurApiDotNet projects:
-Add reference to NurApiDotNet.dll
-Set target platform to x86
-NURAPI.dll must be in same folder than executable. Add it in your project and set property "Copy to Output directory" to "Copy always"
-Use NurApi commands inside Try...Catch structure. See NurApi documentation which methods throws exceptions.
*/

namespace HelloNUR_CSharp
{
    public partial class Form1 : Form
    {
        //This is handle to NUR RFID Reader. Use it always inside try..catch structure in case of exceptions.
        NurApi hNur;

        public Form1()
        {            
            InitializeComponent();

             hNur = new NurApi();//Nur Api handle

            //When NUR module connected via USB, this function finds it and connects automagically...
            hNur.SetUsbAutoConnect(true);
        
            NurApi.ReaderInfo readerInfo;
        
            try
            {   //GetReaderInfo from module
                readerInfo = hNur.GetReaderInfo();
                //Show results in Listbox
                listBox1.Items.Add("Name\t" + readerInfo.name);
                listBox1.Items.Add("Version\t" + readerInfo.GetVersionString());
                listBox1.Items.Add("HW Ver\t" + readerInfo.hwVersion);
                listBox1.Items.Add("FCC\t  " + readerInfo.fccId);
                listBox1.Items.Add("Serial\t" + readerInfo.serial);
                listBox1.Items.Add("SW Ver\t"  + readerInfo.swVerMajor + "." + readerInfo.swVerMinor);
            }
            catch (Exception ex) //Handle error by show error message in Listbox
            {
                listBox1.Items.Add("Error: GetReaderInfo:" + ex.Message);
            }        
        }       

    }
}