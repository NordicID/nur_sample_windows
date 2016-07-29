using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Runtime.InteropServices;

using NordicId;

namespace NurSample
{
    // The following example illustrates how to make a full screen application in C#.
    // Call Init() and SetFullScreen(true) at startup
    // and SetFullScreen(false) before closing the application.
    static public class Fullscreen
    {
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        public const int SPI_SETWORKAREA = 47;
        public const int SPI_GETWORKAREA = 48;
        public const int SPIF_UPDATEINIFILE = 0x01;

        [DllImport("coredll.dll")]
        public static extern int SystemParametersInfo(int uiAction, int uiParam, ref RECT pvParam, int fWinIni);

        [DllImport("coredll.dll")]
        public static extern int SetRect(ref RECT lprc, int xLeft, int yTop, int xRight, int yBottom);

        [DllImport("coredll.dll")]
        public static extern int MoveWindow(uint hWnd, int X, int Y, int nWidth, int nHeight, int bRepaint);

        [DllImport("coredll.dll")]
        public static extern int GetWindowRect(uint hWnd, ref RECT lpRect);

        [DllImport("coredll.dll")]
        static extern int GetSystemMetrics(int smIndex);

        static private uint hWndTaskBar = 0;
        static private RECT rtDesktop;
        static private RECT rtNewDesktop;
        static private RECT rtTaskBar;

        static public int Init()
        {
            if ((SystemParametersInfo(SPI_GETWORKAREA, 0, ref rtDesktop, 0) == 1))
            {
                // Successful obtain the system working area(Desktop)
                SetRect(ref rtNewDesktop, 0, 0, 240, 320);
            }

            // Find the Taskbar window handle
            hWndTaskBar = WIN32.FindWindow("HHTaskBar", null);
            //Checking...
            if (hWndTaskBar != 0)
            {
                //Get the original Input panel windowsize
                GetWindowRect(hWndTaskBar, ref rtTaskBar);
            }
            return 1;
        }

        static public int SetFullScreen(bool mode)
        {
            if (mode == true)
            {
                // Update windows working area size
                SystemParametersInfo(SPI_SETWORKAREA, 0, ref rtNewDesktop, SPIF_UPDATEINIFILE);

                // Hide the TaskBar
                if (hWndTaskBar != 0)
                {
                    MoveWindow(hWndTaskBar, 0, rtNewDesktop.bottom, (rtTaskBar.right - rtTaskBar.left), (rtTaskBar.bottom - rtTaskBar.top), 0);
                }
            }
            else
            {
                // Update windows working area size
                SystemParametersInfo(SPI_SETWORKAREA, 0, ref rtDesktop, SPIF_UPDATEINIFILE);

                // Restore theTaskBar
                if (hWndTaskBar != 0)
                {
                    MoveWindow(hWndTaskBar, rtTaskBar.left, rtTaskBar.top, (rtTaskBar.right - rtTaskBar.left), (rtTaskBar.bottom - rtTaskBar.top), 0);
                }
            }

            return 1;
        }
    }
}