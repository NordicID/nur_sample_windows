/*=======================================================================================

    Hand Held Utils for Nordic ID devices like Morphic and Merlin

=======================================================================================*/
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using NordicId;

namespace NurSample
{
    static class HHUtils
    {
        static private int lastKeepAliveTick = 0;
        static private IntPtr userActivityEvent = IntPtr.Zero;

        /// <summary>
        /// Keeps the device alive.
        /// </summary>
        static public void KeepDeviceAlive()
        {
            // Prevent unnecessary CPU load
            int tick = Environment.TickCount;
            if (tick - lastKeepAliveTick < 5000)
                return;
            lastKeepAliveTick = tick;

            // Create ActivityEvent if not exist
            if (userActivityEvent == IntPtr.Zero)
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey("System\\GWE"))
                {
                    object value = key.GetValue("ActivityEvent");
                    key.Close();
                    if (value == null) return;
                    string activityEventName = (string)value;
                    userActivityEvent = WIN32.CreateEvent(IntPtr.Zero, false, false, activityEventName);
                }
            }

            // Signal user activity to the GWE and Backlight driver
            if (userActivityEvent != IntPtr.Zero)
                WIN32.SetEvent(userActivityEvent);
        }
    }
}
