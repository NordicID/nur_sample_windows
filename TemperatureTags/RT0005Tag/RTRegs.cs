using System;
using System.Collections.Generic;
using System.Text;

namespace CAENRT0005
{
    public class RTRegs
    {
		/// <summary>
        /// Tag's control register.
        /// </summary>
        public const uint CONTROL = 0x0A;

        /// <summary>
        /// First sample's delay time.
        /// </summary>
        public const uint SAMPLING_DELAY = 0x0B;

        /// <summary>
        /// Init date low. Date format is UTC.
        /// </summary>
        public const uint INIT_DATE_L = 0x0C;

        /// <summary>
        /// Init date high. Date format is UTC.
        /// </summary>
        public const uint INIT_DATE_H = 0x0D;

        /// <summary>
        /// Estimated Time of Arrival low. Unit is seconds.
        /// </summary>
        public const uint ETA_REG_L = 0x0E;

        /// <summary>
        /// Estimated Time of Arrival high.
        /// </summary>
        public const uint ETA_REG_H = 0x0F;

        /// <summary>
        /// The BIN enableregister. Each bit corresponds to a BIN.
        /// </summary>
        public const uint BIN_ENABLE = 0x10;

        /// <summary>
        /// The BIN sample store enable. Each bit corresponds to a BIN.
        /// </summary>
        public const uint BIN_ENA_SAMPLE_STORE = 0x11;

        /// <summary>
        /// The BIN time stamp store enable. Each bit corresponds to a BIN.
        /// </summary>
        public const uint BIN_ENA_TIME_STORE = 0x12;
        
        /// <summary>
        /// The BIN high limit registers' base address.
        /// </summary>
        public const uint BIN_HLIMIT_BASE = 0x13;

        /// <summary>
        /// Number of BIN high limit registers.
        /// </summary>
        public const uint BIN_NR_HLIMITS = 16;

        /// <summary>
        /// Last BIN high limit register.
        /// </summary>
        public const uint BIN_HLIMIT_LAST = (BIN_NR_HLIMITS - 1);

        /// <summary>
        /// The BIN sample times registers' base address.
        /// </summary>
        public const uint BIN_SAMPLETIME_BASE = 0x23;

        /// <summary>
        /// The BIN thresholds register' base address .
        /// </summary>
        public const uint BIN_THRESHOLD_BASE = 0x33;

        /// <summary>
        /// The Mean Kinetic Temperature's activation energy in J/mol.
        /// Low part of 32-bit floating point value in IEEE-754 format.
        /// </summary>
        public const uint MKT_ACTV_ENERGY_L = 0x43;

        /// <summary>
        /// The MKT activation energy value's high part.
        /// </summary>
        public const uint MKT_ACTV_ENERGY_H = 0x44;

        /// <summary>
        /// 
        /// </summary>
        public const uint MKT_THRESHOLD_TEMP = 0x45;

        /// <summary>
        /// Shelf life reference temperature in Celsius.
        /// The notation is 8.5 fixed.
        /// </summary>
        public const uint SHL_REF_TEMP = 0x46;

        /// <summary>
        /// Arrhenius algorithm behaviour control low part.
        /// Format is 32-float IEEE-754.
        /// </summary>
        public const uint SHL_Q10_TEMP_L = 0x47;

        /// <summary>
        /// Arrhenius algorithm behaviour control high part.
        /// </summary>
        public const uint SHL_Q10_TEMP_H = 0x48;

        /// <summary>
        /// Shelf life reference time in hours.
        /// </summary>
        public const uint SHL_REF_TIME = 0x49;

        /// <summary>
        /// Shelf life alarm threshold in hours.
        /// </summary>
        public const uint SHL_THRESHOLD = 0x4A;

        /// <summary>
        /// the logger tag's status register.
        /// </summary>
        public const uint STATUS = 0x51;

        /// <summary>
        /// Mean Kinetic Temperature value current value in fixed 8.5 notation.
        /// </summary>
        public const uint MKT_VAL = 0x52;

        /// <summary>
        /// Shelf Life low register. Unit is hours.
        /// </summary>
        public const uint SHL_TIME_L = 0x53;

        /// <summary>
        /// Shelf Life high register. Unit is hours.
        /// </summary>
        public const uint SHL_TIME_H = 0x54;

        /// <summary>
        /// BIN alarm register. Each bit corresponds to a BIN.
        /// </summary>
        public const uint BIN_ALARM = 0x53;

        /// <summary>
        /// The BIN counter reagisters' base address.
        /// </summary>
        public const uint BIN_COUNTER_BASE = 0x56;

        /// <summary>
        /// Last temperature sample value.
        /// </summary>
		public const uint LAST_SAMPLE_VALUE = 0x66;

        /// <summary>
        /// Number of values currently stored.
        /// </summary>
		public const uint SAMPLES_NUM = 0x67;

        /// <summary>
        /// Shipping date low register. Time is in Unix format.
        /// </summary>
		public const uint SHIPPING_DATE_L = 0x68;

        /// <summary>
        /// Shipping date high register. Time is in Unix format.
        /// </summary>
		public const uint SHIPPING_DATE_H = 0x69;

        /// <summary>
        /// Stop date register's low part. Time is in Unix format.
        /// </summary>
		public const uint STOP_DATE_L = 0x6C;
        
        /// <summary>
        /// Stop date register's high part. Time is in Unix format.
        /// </summary>
		public const uint STOP_DATE_H = 0x6D;

        /// <summary>
        /// The user area's base address.
        /// </summary>
		public const uint USER_AREA_BASE = 0x6E;

        /// <summary>
        /// Number of available 16-bit user memory words.
        /// </summary>
		public const uint NR_USER_WORDS = 28;
    }
}

