using System;
using System.Collections.Generic;
using System.Threading;

namespace NurSample
{
    class BeeperLocator : IDisposable
    {
        int maxLevel = 100;
        int beeperRate = 0;
        bool beeperStopped = true;
        bool beeperRunning = false;
        Beeper beeper = new Beeper();
        Thread hBeeperThread = null;
        ManualResetEvent beepEvent = new ManualResetEvent(false);

        public BeeperLocator()
        {
            // Start Beeper thread
            beeperRate = 0;
            beeperRunning = true;
            hBeeperThread = new Thread(new ThreadStart(delegate()
            {
                while (beeperRunning)
                {
                    beepEvent.Reset();
                    if (beeperStopped)
                    {
                        // State: Stopped
                        beepEvent.WaitOne();
                    }
                    else
                    {
                        // State: Locating
                        if (beeperRate > 0)
                        {
                            // Tag in the range
                            beeper.Hz = 1568;
                            if (beeperRate >= 100)
                            {
                                beeper.Beep(100, false);
                            }
                            else
                            {
                                beeper.Beep(50, false);
                                beepEvent.WaitOne(250 - beeperRate, false);
                            }
                        }
                        else
                        {
                            // No tag in the range
                            beeper.Hz = 1046;
                            beeper.Beep(50, false);
                            beepEvent.WaitOne(2000, false);
                        }
                    }
                }
                hBeeperThread = null;
            }));
            hBeeperThread.IsBackground = true;
            hBeeperThread.Priority = ThreadPriority.BelowNormal;
            hBeeperThread.Start();
        }

        public void Dispose()
        {
            // Stop and Exit Beeper thread
            beeperRunning = false;
            beepEvent.Set();
        }

        public void Beep(int level, bool force)
        {
            beeperRate = (level * 100) / maxLevel;
            if (force)
                beepEvent.Set();
        }

        public int MaxLevel
        {
            get { return maxLevel; }
            set { maxLevel = value; }
        }

        public void Start()
        {
            beeperStopped = false;
            beepEvent.Set();
        }

        public void Stop()
        {
            beeperStopped = true;
            beepEvent.Set();
        }
    }
}
