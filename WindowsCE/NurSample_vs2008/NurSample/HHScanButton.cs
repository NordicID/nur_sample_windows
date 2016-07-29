/*=======================================================================================

    Hand Held Scan & Trigger -button utils for Nordic ID devices
    like a Morphic and Merlin.

=======================================================================================*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using NordicId;

namespace NurSample
{
    static class HHScanButton
    {
        public enum SCANMODE : int
        {
            UNKNOWN = -1,
            NONE = 0,
            BARCODE = 1,
            RFID = 2
        }

        /// Configures the SCAN -button from keaboard and
        /// Merlin's pistol grip TRIGGER -button.
        /// </summary>
        static public void ConfigureScanButtons(Keys keyCode)
        {
            try
            {
                // Configure SCAN -button from keaboard
                MHLDriver hKeyb = new MHLDriver("Keyboard");
                if (hKeyb.IsOpen())
                {
                    // Save current keyboard map
                    hKeyb.SaveProfile("NurSample");
                    // Ensure that "Scan" button is mapped correctly
                    hKeyb.SetDword("SpecialKey.Scan.All.VK", (uint)keyCode);
                    // Reload map
                    hKeyb.SetDword("Keyboard.Reload", 1);
                }
            }
            catch
            {
                // Ignore if not existing
            }

            try
            {
                // Configure TRIGGER -button from Merlins pistol grip
                MHLDriver hTrigger = new MHLDriver("TriggerButton");
                if (hTrigger.IsOpen())
                {
                    // Save the current Trigger -button map
                    hTrigger.SaveProfile("NurSample");
                    // Ensure that "Trigger" button is mapped correctly
                    hTrigger.SetDword("Trigger.VirtualKey", (uint)keyCode);
                }
            }
            catch
            {
                // Ignore if not existing
            }
        }

        /// Restore the SCAN -button from keaboard and
        /// Merlin's pistol grip TRIGGER -button
        /// </summary>
        static public void RestoreScanButtons()
        {
            try
            {
                // Restore SCAN -button from keaboard
                MHLDriver hKeyb = new MHLDriver("Keyboard");
                if (hKeyb.IsOpen())
                {
                    // Restore saved profile and close driver
                    hKeyb.LoadProfile("NurSample");
                    // Reload map
                    hKeyb.SetDword("Keyboard.Reload", 1);
                }
            }
            catch
            {
                // Ignore if not existing
            }

            try
            {
                // Restore TRIGGER -button from Merlins pistol grip
                MHLDriver hTrigger = new MHLDriver("TriggerButton");
                if (hTrigger.IsOpen())
                {
                    // Restore saved profile and close driver
                    hTrigger.LoadProfile("NurSample");
                }
            }
            catch
            {
                // Ignore if not existing
            }
        }

        /// <summary>
        /// Gets or sets the scan button mode.
        /// 0 = No operation
        /// 1 = Scanner.ScanAsync
        /// 2 = RFID.ScanAsync
        /// </summary>
        /// <value>
        /// The scan button mode.
        /// </value>
        /// <exception cref="System.ApplicationException">Invalid ScanMode</exception>
        static public SCANMODE ScanButtonMode
        {
            get
            {
                MHLDriver hKeyb = new MHLDriver("Keyboard");
                if (hKeyb.IsOpen())
                {
                    return (SCANMODE)hKeyb.GetDword("Keyboard.ScanMode");
                }
                else
                {
                    return SCANMODE.UNKNOWN;
                }
            }
            set
            {
                MHLDriver hKeyb = new MHLDriver("Keyboard");
                if (hKeyb.IsOpen())
                {
                    // Set ScanMode 0 = No operation
                    // Set ScanMode 1 = Scanner.ScanAsync
                    // Set ScanMode 2 = RFID.ScanAsync
                    hKeyb.SetDword("Keyboard.ScanMode", (uint)value);
                }
            }
        }

        /// <summary>
        /// Barcode / RFID scanned.
        /// </summary>
        /// <param name="scanResult">The scan result.</param>
        static void DummyResultDelegate(string scanResult)
        {
        }

        /// <summary>
        /// Registered hotkey clicked
        /// </summary>
        /// <param name="vk">The vk.</param>
        static void DummyHotkeyHandler(int vk)
        {
            // Make sure it's NordicId.VK.SCAN
            if (vk == (int)NordicId.VK.SCAN)
            {
            }
        }
    }
}
