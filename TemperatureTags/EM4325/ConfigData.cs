using System;
using System.Collections.Generic;
using System.Text;

using NurApiDotNet;

namespace EM4325
{
	public partial class EM4325Tag : NurApi.Tag
	{
		// Simple setup.
		private const int SSD_TYPE_LSH = 12;
		private const int SSD_TYPE_BITS = 4;
		private const int SSD_TYPE_MASK = ((1 << SSD_TYPE_BITS) - 1);
		private const int SSD_SPAN_LSH = 9;
		private const int SSD_SPAN_BITS = 3;
		private const int SSD_SPAN_MASK = ((1 << SSD_SPAN_BITS) - 1);

		private const int SSD_ACC_LSH = 6;
		private const int SSD_ACC_BITS = 2;
		private const int SSD_ACC_MASK = ((1 << SSD_ACC_BITS) - 1);

		private const int SSD_REGIME_LSH = 3;
		private const int SSD_REGIME_BITS = 6;
		private const int SSD_REGIME_MASK = ((1 << SSD_REGIME_BITS) - 1);

		private const int SSD_HILIM_BITS = 3;
		private const int SSD_HILIM_MASK = ((1 << SSD_HILIM_BITS) - 1);

		private const int SSD_LOLIM_LSH = 13;
		private const int SSD_LOLIM_BITS = 3;
		private const int SSD_LOLIM_MASK = ((1 << SSD_LOLIM_BITS) - 1);

		private const int SSD_MONDELAY_LSH = 10;
		private const int SSD_MONDELAY_BITS = 3;
		private const int SSD_MONDELAY_MASK = ((1 << SSD_MONDELAY_BITS) - 1);

		private const int SSD_HIDELAY_LSH = 7;
		private const int SSD_HIDELAY_BITS = 3;
		private const int SSD_HIDELAY_MASK = ((1 << SSD_HIDELAY_BITS) - 1);

		private const int SSD_LODELAY_LSH = 4;
		private const int SSD_LODELAY_BITS = 3;
		private const int SSD_LODELAY_MASK = ((1 << SSD_LODELAY_BITS) - 1);

		private const int SSD_LOWBAT_BIT = 3;
		private const int SSD_TAMPER_BIT = 2;
		private const int SSD_HIALARM_BIT = 1;
		private const int SSD_LOWALARM_BIT = 0;

		// Custom setup.
		private const int CUST_UNDERCOUNT_LSH = 9;
		private const int CUST_UNDERCOUNT_BITS = 5;
		private const int CUST_UNDERCOUNT_MASK = ((1 << CUST_UNDERCOUNT_BITS) - 1);

		private const int CUST_TEMPTHRESH_BITS = 9;
		private const int CUST_TEMPTHRESH_MASK = ((1 << CUST_TEMPTHRESH_BITS) - 1);

		private const int CUST_TSREQUIRED_BIT = 14;		

		private const int CUST_OVERCOUNT_LSH = 9;
		private const int CUST_OVERCOUNT_BITS = 5;
		private const int CUST_OVERCOUNT_MASK = ((1 << CUST_OVERCOUNT_BITS) - 1);

		private const int CUST_DELAYUNITS_LSH = 14;
		private const int CUST_DELAYUNITS_BITS = 2;
		private const int CUST_DELAYUNITS_MASK = ((1 << CUST_DELAYUNITS_BITS) - 1);

		private const int CUST_DELAYVALUE_LSH = 8;
		private const int CUST_DELAYVALUE_BITS = 6;
		private const int CUST_DELAYVALUE_MASK = ((1 << CUST_DELAYVALUE_BITS) - 1);

		private const int CUST_INTVALUNITS_LSH = 6;
		private const int CUST_INTVALUNITS_BITS = 2;
		private const int CUST_INTVALUNITS_MASK = ((1 << CUST_INTVALUNITS_BITS) - 1);

		private const int CUST_INTERVAL_BITS = 6;
		private const int CUST_INTERVAL_MASK = ((1 << CUST_INTERVAL_BITS) - 1);

		private const int CTLW1_SIMPLE_BIT = 15;
		private const int CTLW1_RESET_EN_BIT = 14;
		private const int CTLW1HI_RESET_EN_BIT = 6;
		private const int SSD_TSREQUIRED_BIT = 13;


		/// <summary>
		/// Structure that represents the simple sensor configuration.
		/// </summary>
		public struct SSDConfig
		{
			/// <summary>
			/// Type bits' value as specified by the EM4325 specification.
			/// </summary>
			public int type;
			/// <summary>
			/// Span interpretation depends whether the temperature 
			/// span is set to 14 or 28.
			/// </summary>
			public int span;
			/// <summary>
			/// Accuracy value as specified by the EM4325 specification.
			/// Value is -acc to +acc.
			/// </summary>
			public float acc;
			/// <summary>
			/// Sampling regime as specified by the EM4325 specification.
			/// NOTE: value is 'float.NaN' if the field is RFU.
			/// </summary>
			public int regime;
			/// <summary>
			/// High in-range limit as specified by the EM4325 specification.
			/// </summary>			
			public int highLimit;
			/// <summary>
			/// Low in-range limit as specified by the EM4325 specification.
			/// </summary>			
			public int lowRange;
			/// <summary>
			/// Monitor delay as specified by the EM4325 specification.
			/// </summary>			
			public int monDelay;
			/// <summary>
			/// Number of consecutive samples for high alarm 
			/// as specified by the EM4325 specification.
			/// </summary>
			public int hiLimDelay;
			/// <summary>
			/// Number of consecutive samples for low alarm 
			/// as specified by the EM4325 specification.
			/// </summary>
			public int loLimDelay;
			/// <summary>
			/// True if low battery is '1'.
			/// </summary>
			public bool lowBatt;
			/// <summary>
			/// True if tamper alarm is '1'.
			/// </summary>
			public bool tampered;
			/// <summary>
			/// True if high alarm is '1'.
			/// </summary>
			public bool highAlarm;
			/// <summary>
			/// True if low alarm is '1'.
			/// </summary>
			public bool lowAlarm;

		}

		/// <summary>
		/// Structure representing the custom configuration data.
		/// </summary>
		public struct CustomConfig
		{
			/// <summary>
			/// Number of consecutive under temperature samples required for alarm.
			/// </summary>
			public int nrUnderTemp;
			/// <summary>
			/// Under temperature threshold.
			/// </summary>
			public float underTemp;
			/// <summary>
			/// Number of consecutive over temperature samples required for alarm.
			/// </summary>
			public int nrOverTemp;
			/// <summary>
			/// Over temperature limit.
			/// </summary>
			public float overTemp;
			/// <summary>
			/// The delay unit type.
			/// 0 = 1 second
			/// 1 = 1 minute
			/// 2 = 1 hour
			/// 3 = sampling interval
			/// </summary>
			public int delayUnits;
			/// <summary>
			/// The monitor delay value.
			/// </summary>
			public int delayValue;
			/// <summary>
			/// Sampling interval units
			/// 0 = 1 second
			/// 1 = 1 minute
			/// 2 = 1 hour
			/// 3 = 5 seconds
			/// </summary>
			public int intvalUnits;
			/// <summary>
			/// Sampling interval value.
			/// </summary>
			public int intvalValue;
		}

		/// <summary>
		/// Structure representing the configuration data; either simple or custom.
		/// </summary>
		public struct ConfigData
		{
			/// <summary>
			/// Whether the configuration is custom sensor (0, false) or simple sensor (1/true).
			/// </summary>
			public bool simpleSensor;
			/// <summary>
			/// If true then the reset alarms is enabled.
			/// </summary>
			public bool resetEn;
			/// <summary>
			/// If true then the time stamp is required for each sample.
			/// </summary>
			public bool tsRequired;
			/// <summary>
			/// Valid, if 'simple' is true. 
			/// </summary>
			public SSDConfig ssd;
			/// <summary>
			/// Valid, is 'simple' is false.
			/// </summary>
			public CustomConfig custom;
			/// <summary>
			/// Raw data bytes from the tag.
			/// </summary>
			public byte[] raw;
		}

		/// <summary>
		/// Retru nwhether a specific bit in an integer value is 0 or 1.
		/// </summary>
		/// <param name="iValue">Value to look at.</param>
		/// <param name="bit">Bit to test.</param>
		/// <returns>If bit is '1' ther eturn value is true.</returns>
		/// <exception cref="ApplicationException">Exception is thrown if the bit requested is less than 0 or greater than 31.</exception>
		public static bool BitToBool(int iValue, int bit)
		{
			if (bit<0 || bit > 31)
				throw new ApplicationException("BitToBool: invalid bit " + bit + ", range is 0...31.");
			return ((1 << bit) & iValue) != 0;
		}

		private ConfigData AllocConfigData(bool simple)
		{
			ConfigData ret = new ConfigData();
			ret.simpleSensor = simple;
			return ret;
		}

		private void GetConfigWords(byte []resp, ref ushort w1, ref ushort w2, ref ushort w3)
		{			
			int srcPtr = 0;

			w1 = resp[srcPtr++];
			w1 <<= 8;
			w1 |= resp[srcPtr++];
			
			w2 = resp[srcPtr++];
			w2 <<= 8;
			w2 |= resp[srcPtr++];
			
			w3 = resp[srcPtr++];
			w3 <<= 8;
			w3 |= resp[srcPtr];
		}

		private void CopyResponse(ref ConfigData cfg, byte[] resp)
		{
			cfg.raw = new byte[resp.Length];
			System.Array.Copy(resp, cfg.raw, resp.Length);
		}

		private ConfigData InterpretCustomConfig(byte []resp)
		{
			ConfigData cfg = AllocConfigData(false);
			ushort w1 = 0;
			ushort w2 = 0;
			ushort w3 = 0;
			int tmp;
			int tempVal;

			GetConfigWords(resp, ref w1, ref w2, ref w3);

			CopyResponse(ref cfg, resp);
				
			// Word 1
			cfg.resetEn = BitToBool(w1, CTLW1_RESET_EN_BIT);

			cfg.custom = new CustomConfig();
			cfg.custom.nrUnderTemp = ((w1 >> CUST_UNDERCOUNT_LSH) & CUST_UNDERCOUNT_MASK);
			tmp = (w1 & CUST_TEMPTHRESH_MASK);

			tempVal = tmp;
			if ((tempVal & SD_SIGNBIT_LSH) != 0)
				tempVal *= -1;
			hNur.ULog("Interpret custom: under limit integer = " + tempVal + " -> " + ((float)tempVal / 4.0F).ToString("F2"));

			if ((tmp & (1 << SD_SIGNBIT_LSH)) != 0)
				tmp *= -1;

			cfg.custom.underTemp = (float)tmp;
			cfg.custom.underTemp /= 4.0F;

			// Word 2
			cfg.tsRequired = BitToBool(w2, CUST_TSREQUIRED_BIT);
			cfg.custom.nrOverTemp = ((w2 >> CUST_OVERCOUNT_LSH) & CUST_OVERCOUNT_MASK);
			tmp = (w2 & CUST_TEMPTHRESH_MASK);

			tempVal = tmp;
			if ((tempVal & SD_SIGNBIT_LSH) != 0)
				tempVal *= -1;
			hNur.ULog("Interpret custom: over limit integer = " + tempVal + " -> "  + ((float)tempVal / 4.0F).ToString("F2"));

			if ((tmp & (1 << SD_SIGNBIT_LSH)) != 0)
				tmp *= -1;
			cfg.custom.overTemp = (float)tmp;
			cfg.custom.overTemp /= 4.0F;

			// Word 3
			cfg.custom.delayUnits = ((w3 >> CUST_DELAYUNITS_LSH) & CUST_DELAYUNITS_MASK);
			cfg.custom.delayValue = ((w3 >> CUST_DELAYVALUE_LSH) & CUST_DELAYVALUE_MASK);
			cfg.custom.intvalUnits = ((w3 >> CUST_INTVALUNITS_LSH) & CUST_INTVALUNITS_MASK);
			cfg.custom.intvalValue = (w3 & CUST_INTERVAL_MASK);

			return cfg;
		}

		private ConfigData InterpretSimpleSetup(byte[] resp)
		{
			ConfigData cfg = AllocConfigData(true);
			ushort w1 = 0;
			ushort ssdHi = 0;
			ushort ssdLo = 0;
			
			GetConfigWords(resp, ref w1, ref ssdHi, ref ssdLo);
			CopyResponse(ref cfg, resp);

			// Word 1			
			cfg.resetEn = BitToBool(w1, CTLW1_RESET_EN_BIT);
			cfg.tsRequired = BitToBool(w1, SSD_TSREQUIRED_BIT);
			// Rest in W1 is RFU for simple sensor.

			cfg.ssd = new SSDConfig();
			// SSD.MSW
			cfg.ssd.type = ((ssdHi >> SSD_TYPE_LSH) & SSD_TYPE_MASK);
			cfg.ssd.span = ((ssdHi >> SSD_SPAN_LSH) & SSD_SPAN_MASK);

			switch (((ssdHi >> SSD_ACC_LSH) & SSD_ACC_MASK))
			{
				case 0: cfg.ssd.acc = 0.5F; break;
				case 1: cfg.ssd.acc = 1.0F; break;
				case 2: cfg.ssd.acc = 2.0F; break;
				default: cfg.ssd.acc = float.NaN; break;
			}


			cfg.ssd.regime = ((ssdHi >> SSD_REGIME_LSH) & SSD_REGIME_MASK);
			cfg.ssd.highLimit = (ssdHi & SSD_HILIM_MASK);
			
			// SSD.LSW
			cfg.ssd.lowRange = ((ssdLo >> SSD_LOLIM_LSH) & SSD_LOLIM_MASK);
			cfg.ssd.monDelay = ((ssdLo >> SSD_MONDELAY_LSH) & SSD_MONDELAY_MASK);
			cfg.ssd.hiLimDelay = ((ssdLo >> SSD_HIDELAY_LSH) & SSD_HIDELAY_MASK);
			cfg.ssd.loLimDelay = ((ssdLo >> SSD_LODELAY_LSH) & SSD_LODELAY_MASK);
			cfg.ssd.lowBatt = BitToBool(ssdLo, SSD_LOWBAT_BIT);
			cfg.ssd.tampered = BitToBool(ssdLo, SSD_TAMPER_BIT);
			cfg.ssd.highAlarm = BitToBool(ssdLo, SSD_HIALARM_BIT);
			cfg.ssd.lowAlarm = BitToBool(ssdLo, SSD_LOWALARM_BIT);

			return cfg;
		}

		/// <summary>
		/// Read configuration from the tag and interpret.
		/// </summary>
		/// <returns>Interpreted configuration data.</returns>		
		public ConfigData GetConfigData()
		{
			byte []resp;

			ResetToA();
			resp = ReadTag(mPassword, mSecured, NurApi.BANK_USER, ADDR_CTLWORD_1, 3 * 2);

			// 3 words, 3 x 2 bytes.
			if (resp.Length == 6)
			{				
				// Test whether the configuration is custom or simple.
				if ((resp[0] & 0x80) == 0)
					return InterpretCustomConfig(resp);
			}
			else
				throw new ApplicationException("GetConfigData: invalid response length of " + resp.Length + " bytes, expecting 6.");

			return InterpretSimpleSetup(resp);
		}

		private byte[] BuildSimpleConfig(ConfigData cfg)
		{
			byte[] byteData = new byte[6];
			ushort w1 = 0;
			ushort ssdHi = 0;
			ushort ssdLo = 0;
			ushort tmp;

			// Word 1			
			w1 |= (1 << CTLW1_SIMPLE_BIT);
			if (cfg.resetEn)
				w1 |= (1 << CTLW1_RESET_EN_BIT);
			if (cfg.tsRequired)
				w1 |= (1 << SSD_TSREQUIRED_BIT);
			// Rest is RFU

			// SSD.MSW
			ssdHi |= (ushort)((cfg.ssd.type & SSD_TYPE_MASK) << SSD_TYPE_LSH);
			ssdHi |= (ushort)((cfg.ssd.span & SSD_SPAN_MASK) << SSD_SPAN_LSH);

			if (cfg.ssd.acc <= 0.5F)
				tmp = 0;
			else if (cfg.ssd.acc <= 1.0F)
				tmp = 1;
			else 
				tmp = 2;

			ssdHi |= (ushort)((tmp & SSD_ACC_MASK) << SSD_ACC_LSH);

			ssdHi |= (ushort)((cfg.ssd.regime & SSD_REGIME_MASK) << SSD_REGIME_LSH);
			ssdHi |= (ushort)(cfg.ssd.highLimit & SSD_HILIM_MASK);

			// SSD.LSW
			ssdLo |= (ushort)((cfg.ssd.lowRange & SSD_LOLIM_MASK) << SSD_LOLIM_LSH);
			ssdLo |= (ushort)((cfg.ssd.monDelay & SSD_MONDELAY_MASK) << SSD_MONDELAY_LSH);
			ssdLo |= (ushort)((cfg.ssd.monDelay & SSD_HIDELAY_MASK) << SSD_HIDELAY_LSH);
			ssdLo |= (ushort)((cfg.ssd.monDelay & SSD_LODELAY_MASK) << SSD_LODELAY_LSH);		

			if (cfg.ssd.lowBatt)
				ssdLo |= (1 << SSD_LOWBAT_BIT);			
			if (cfg.ssd.tampered)
				ssdLo |= (1 << SSD_TAMPER_BIT);
			if (cfg.ssd.highAlarm)
				ssdLo |= (1 << SSD_HIALARM_BIT);
			if (cfg.ssd.lowAlarm)
				ssdLo |= (1 << SSD_LOWALARM_BIT);

			byteData[0] = (byte)(w1 << 8);
			byteData[1] = (byte)(w1 & 0xFF);
			byteData[2] = (byte)(ssdHi << 8);
			byteData[3] = (byte)(ssdHi & 0xFF);
			byteData[4] = (byte)(ssdLo << 8);
			byteData[5] = (byte)(ssdLo & 0xFF);

			return byteData;
		}

		private byte[] BuildCustomConfig(ConfigData cfg)
		{
			byte[] byteData = new byte[6];
			ushort w1 = 0;
			ushort w2 = 0;
			ushort w3 = 0;
			ushort tmp;

			w1 |= (1 << CTLW1_RESET_EN_BIT);

			
			w1 |= (ushort)((cfg.custom.nrUnderTemp & CUST_UNDERCOUNT_MASK) << CUST_UNDERCOUNT_LSH);

			tmp = (ushort)(cfg.custom.underTemp / 0.25F);
			w1 |= (ushort)(tmp & CUST_TEMPTHRESH_MASK);

			// Word 2
			if (cfg.tsRequired)
				w2 |= (1 << CUST_TSREQUIRED_BIT);

			w2 |= (ushort)((cfg.custom.nrOverTemp & CUST_OVERCOUNT_MASK) << CUST_OVERCOUNT_LSH);

			tmp = (ushort)(cfg.custom.overTemp / 0.25F);
			w2 |= (ushort)(tmp & CUST_TEMPTHRESH_MASK);

			// Word 3
			w3 |= (ushort)((cfg.custom.delayUnits & CUST_DELAYUNITS_MASK) << CUST_DELAYUNITS_LSH);
			w3 |= (ushort)((cfg.custom.delayValue & CUST_DELAYVALUE_MASK) << CUST_DELAYVALUE_LSH);
			w3 |= (ushort)((cfg.custom.intvalUnits & CUST_INTVALUNITS_MASK) << CUST_INTVALUNITS_LSH);
			w3 |= (ushort)((cfg.custom.intvalValue & CUST_INTERVAL_MASK) << CUST_INTVALUNITS_LSH);

			byteData[0] = (byte)(w1 << 8);
			byteData[1] = (byte)(w1 & 0xFF);
			byteData[2] = (byte)(w2 << 8);
			byteData[3] = (byte)(w2 & 0xFF);
			byteData[4] = (byte)(w3 << 8);
			byteData[5] = (byte)(w3 & 0xFF);

			return byteData;
		}

		/// <summary>
		/// Set sensor configuration data.
		/// </summary>
		/// <param name="cfg">Configuration to set.</param>
		/// <param name="simple">If true then the command is composed as a simple setup.</param>
		/// <param name="useBlockWrite">If false then a normal word-by-word write is used, otherwise G2 BlockWrite is used.</param>
		public void SetConfigData(ConfigData cfg, bool simple, bool useBlockWrite)
		{
			byte[] wrData;
			if (simple)
				wrData = BuildSimpleConfig(cfg);
			else
				wrData = BuildCustomConfig(cfg);

			if (useBlockWrite)
			{
				if (mSecured)
					BlockWrite(mPassword, NurApi.BANK_USER, ADDR_CTLWORD_1, wrData, 3);
				else
					BlockWrite(NurApi.BANK_USER, ADDR_CTLWORD_1, wrData, 3);
			}
			else
			{
				ResetToA();
				WriteTag(mPassword, mSecured, NurApi.BANK_USER, ADDR_CTLWORD_1, wrData);
			}
		}

		/// <summary>
		/// Attribute used to read the configuration from the tag.
		/// </summary>
		public ConfigData Configuration
		{
			get { return GetConfigData(); }
			set { }
		}
	}
}
