using System;
using System.Collections.Generic;
using System.Text;


namespace NurSample
{
    class Beeper
    {
        // Reference counter
        static int ref_counter = 0;
        // Current volume and frequency
        static uint hz = 0;
        static uint volume = 0;

        public Beeper()
        {
            ref_counter++;
        }

        ~Beeper()
        {
            ref_counter--;
        }

        public uint Volume
        {
            get
            {
                return volume;
            }
            set
            {
                volume = value;
            }
        }

        public uint Hz
        {
            get
            {
                return hz;
            }
            set
            {
                hz = value;
            }
        }

        public void Beep(uint durration, bool sync)
        {
        }

        public void BeepSeq(string sequence)
        {
        }
    }
}
