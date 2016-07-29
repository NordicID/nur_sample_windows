using System;
using System.Collections.Generic;
using System.Text;

using NordicId;

namespace NurSample
{
    class Beeper
    {
        // RTTTL example
        //public string KnightRider = "KnightRider:d=4,o=5,b=125:16e,16p,16f,16e,16e,16p,16e,16e,16f,16e,16e,16e,16d#,16e,16e,16e,16e,16p,16f,16e,16e,16p,16f,16e,16f,16e,16e,16e,16d#,16e,16e,16e,16d,16p,16e,16d,16d,16p,16e,16d,16e,16d,16d,16d,16c,16d,16d,16d,16d,16p,16e,16d,16d,16p,16e,16d,16e,16d,16d,16d,16c,16d,16d,16d";

        // Handle of Beeper driver
        static MHLDriver hBeeper = new MHLDriver();
        // Reference counter
        static int ref_counter = 0;
        // Current volume and frequency
        static uint hz = 0;
        static uint volume = 0;

        public Beeper()
        {
            if (ref_counter == 0 && hBeeper != null)
            {
                try
                {
                    hBeeper.Open("Beeper");
                    this.Volume = 10;
                    hz = this.Hz;
                }
                catch (Exception)
                {
                }
            }
            ref_counter++;
        }

        ~Beeper()
        {
            ref_counter--;
            if (ref_counter == 0 && hBeeper != null)
            {
                try
                {
                    hBeeper.Close();
                }
                catch (Exception)
                {
                }
            }
        }

        public uint Volume
        {
            get
            {
                if (!hBeeper.IsOpen())
                    return 0;

                return hBeeper.GetDword("Beeper.Volume");
            }
            set
            {
                if (!hBeeper.IsOpen())
                    return;

                if (value != volume)
                {
                    volume = value;
                    hBeeper.SetDword("Beeper.Volume", value);
                }
            }
        }

        public uint Hz
        {
            get
            {
                if (!hBeeper.IsOpen())
                    return 0;

                return hBeeper.GetDword("Beeper.Hz");
            }
            set
            {
                if (!hBeeper.IsOpen())
                    return;

                if (value != hz)
                {
                    hz = value;
                    hBeeper.SetDword("Beeper.Hz", value);
                }
            }
        }

        public void Beep(uint durration, bool sync)
        {
            if (!hBeeper.IsOpen())
                return;

            if (sync)
                hBeeper.SetDword("Beeper.SyncBeep", durration);
            else
                hBeeper.SetDword("Beeper.Beep", durration);
        }

        public void BeepSeq(string sequence)
        {
            if (!hBeeper.IsOpen())
                return;

            hBeeper.SetString("Beeper.BeepSeq", sequence);
        }

        public void PlayRtttlFile(string fileName, bool sync)
        {
            if (!hBeeper.IsOpen())
                return;

            if (sync)
                hBeeper.SetString("Beeper.RTTTL.PlayFileSync", fileName);
            else
                hBeeper.SetString("Beeper.RTTTL.PlayFile", fileName);
        }

        public void PlayRtttlBuffer(string rttlBuffer, bool sync)
        {
            if (!hBeeper.IsOpen())
                return;

            if (sync)
                hBeeper.SetString("Beeper.RTTTL.PlayBufferSync", rttlBuffer);
            else
                hBeeper.SetString("Beeper.RTTTL.PlayBuffer", rttlBuffer);
        }
    }
}
