using System;
using System.Collections.Generic;
using System.Threading;

namespace NurSample
{
    class BeeperInventory : IDisposable
    {
        int beepRate = 0;
        bool beepOnce = true;
        bool beeperRunning = false;
        Beeper beeper = new Beeper();
        Thread hBeeperThread = null;
        AutoResetEvent beepEvent = new AutoResetEvent(false);

        public BeeperInventory()
        {
            // Start Beeper thread
            beepRate = 0;
            beeperRunning = true;
            hBeeperThread = new Thread(new ThreadStart(delegate()
            {
                while (beeperRunning)
                {
                    if (beepRate > 0)
                    {
                        if (beepOnce)
                            beepRate = 0;
                        else
                            beepRate--;
                        beeper.Hz = 2093;
                        beeper.Beep(50, false);
                        Thread.Sleep(60);
                        continue;
                    }
                    beepEvent.WaitOne();
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

        public void Beep(int beeps)
        {
            beepRate = beeps;
            beepEvent.Set();
        }

        public void Start()
        {
            beepOnce = false;
            beepEvent.Set();
        }

        public void Stop()
        {
            beepOnce = true;
            beepEvent.Set();
        }
    }
}
