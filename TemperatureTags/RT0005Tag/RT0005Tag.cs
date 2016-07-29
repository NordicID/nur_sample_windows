/* 
  Copyright © 2014- Nordic ID 
  NORDIC ID DEMO SOFTWARE DISCLAIMER

  You are about to use Nordic ID Demo Software ("Software"). 
  It is explicitly stated that Nordic ID does not give any kind of warranties, 
  expressed or implied, for this Software. Software is provided "as is" and with 
  all faults. Under no circumstances is Nordic ID liable for any direct, special, 
  incidental or indirect damages or for any economic consequential damages to you 
  or to any third party.

  The use of this software indicates your complete and unconditional understanding 
  of the terms of this disclaimer. 
  
  IF YOU DO NOT AGREE OF THE TERMS OF THIS DISCLAIMER, DO NOT USE THE SOFTWARE.  
*/

using System;
using System.Collections.Generic;
using System.Text;

/* Import of the NurApi. */
using NurApiDotNet;

namespace CAENRT0005
{
    public partial class RT0005Tag : NurApi.Tag
    {
		public event EventHandler<RTProgressEvent> ProgressEvent = null;

		private uint mPassword = 0;
		private bool mSecured = false;
		private int mLastError = NurApiErrors.NUR_SUCCESS;
		
		/// <summary>
		/// A read & clear integer that can be used to read out the last error.
		/// </summary>
		public int LastError
		{
			get
			{
				int rc = mLastError;
				mLastError = NurApiErrors.NUR_SUCCESS;
				return rc;
			}
		}

		/// <summary>
		/// Password if used.
		/// </summary>
		public uint Password
		{
			set { mPassword = value; }
			get { return mPassword; }
		}

		/// <summary>
		/// Whether to use the password or not.
		/// </summary>
		public bool Secured
		{
			set { mSecured = value; }
			get { return mSecured; }
		}

		/// <summary>
		/// Current sample count.
		/// </summary>
		/// <exception cref="NurApiException">This exception is thrown when the underlying physical read fails.</exception>
		public ushort SampleCount
		{
			get
			{
				return ReadShortReg(RTRegs.SAMPLES_NUM);
			}
		}

		/// <summary>
		/// Set / get logging state.
		/// </summary>
		/// <remarks>
		/// <para>When written, this boolean physically tries to change the logging bit's state in the tag's control register on / '1' (true) or off / '0' (false).</para>
		/// <para>When read, this boolean returns the logging bit's state read from the tag.</para>
		/// </remarks>
		/// <exception cref="NurApiException">This exception is thrown when the underlying physical read or write fails.</exception>
		public bool Logging
		{
			get
			{
				ushort wReg;
				wReg = ReadShortReg(RTRegs.CONTROL);
				return (wReg & RTConst.CTL_LOGEN_MASK) != 0;
			}

			set
			{
				bool doSet = false;
				ushort wReg;
				wReg = ReadShortReg(RTRegs.CONTROL);

				if (value)
				{
					if ((wReg & RTConst.CTL_LOGEN_MASK) == 0)
						doSet = true;
				}
				else
				{
					if ((wReg & RTConst.CTL_LOGEN_MASK) != 0)
						doSet = true;
				}

				if (doSet)
				{
					// Toggle if so.
					wReg ^= RTConst.CTL_LOGEN_MASK;
					WriteShortReg(RTRegs.CONTROL, wReg);

					if (value != Logging)
					{
						// Fail.
						throw new RTException("Could not change the logging state.");
					}
				}					
			}
		}

		/// <summary>
		/// Set or gets the sampling start delay from the tag. The unit is seconds and zero means that it is not used (=immediate start).
		/// </summary>
		/// <exception cref="NurApiException">This exception is thrown when the underlying physical read or write fails.</exception>
		public ushort SamplingDelay
		{
			get
			{
				return ReadShortReg(RTRegs.SAMPLING_DELAY);
			}
			set
			{
				WriteShortReg(RTRegs.SAMPLING_DELAY, value);
			}
		}

		/// <summary>
		/// Get or set the 16-bit control register's contents.
		/// </summary>
		/// <exception cref="NurApiException">This exception is thrown when the underlying physical read or write fails.</exception>
		public ushort ControlRegister
		{
			set
			{
				WriteShortReg(RTRegs.CONTROL, value);
			}
			get
			{
				return ReadShortReg(RTRegs.CONTROL);
			}
		}
        
        /// <summary>
        /// BIN high limit array.
        /// </summary>
        public readonly BINHLIMIT BINLimit;

        /// <summary>
        /// BIN sample time array.
        /// </summary>
        public readonly BINSAMPLETIME BINSampleTime;

        /// <summary>
        /// BIN threshold array.
        /// </summary>
        public readonly BINTHRESHOLD BINThreshold;

		/// <summary>
		/// 
		/// </summary>
		public readonly BINCOUNTER BINCounter;

        /// <summary>
        /// Constructor that takes in NurApi and a NurApi.Tag object.
        /// </summary>
        /// <param name="hApi">A valid, connected NurApi object.</param>
        /// <param name="tag">A tag object that is either built by the application or received though an inventory.</param>
		/// <remarks><para>This constructor also creates the BIN arrays.</para></remarks>
		/// <remarks><para>BIN high limits: <seealso cref="BINHLIMIT"/></para></remarks>
		/// <remarks><para>BIN sample times: <seealso cref="BINSAMPLETIME"/></para></remarks>
		/// <remarks><para>BIN thresholds: <seealso cref="BINTHRESHOLD"/></para></remarks>
		/// <remarks><para>BIN counters: <seealso cref="BINCOUNTER"/></para></remarks>
		public RT0005Tag(NurApi hApi, NurApi.Tag tag)
			: base(tag)
        {
			base.hApi = hApi;

            BINLimit = new BINHLIMIT(this);            
            BINSampleTime = new BINSAMPLETIME(this);
            BINThreshold = new BINTHRESHOLD(this);
			BINCounter = new BINCOUNTER(this);
        }
        
        /// <summary>
        /// Try to check whther this tag avtually is RT0005 by reading 
        /// the extra bytes in the password memory.
        /// </summary>
        /// <param name="password">Passwored value if needed for the read.</param>
        /// <param name="secured">Whether to use the <paramref name="password"/> or not.</param>
        /// <returns>Return true if the reader was able to read the extra bytes.</returns>
        public bool Validate(uint password, bool secured)
        {            
            byte []extra;

			mLastError = NurApiErrors.NUR_SUCCESS;
			try
            {                
                // Read the extra memory from the password memory.
				extra = ReadTag(password, secured, NurApi.BANK_PASSWD, 4, RTConst.NR_PASSWD_EXTRA_BYTES);
                return true;
            }
            catch (NurApiException e)
            {
				mLastError = e.error;
            }

            return false;
        }

		/// <summary>
		/// Read a 16-bit register.
		/// </summary>
		/// <param name="rtReg">Register value to read, <seealso cref="RTRegs"/>.</param>
		/// <returns>This call returns the 16-bit value of the register.</returns>
		/// <remarks>NOTE: this result is internally converted to little-endian format; no need to re-convert.</remarks>
		/// <exception cref="NurApiException">
		/// <para>This exception is thrown when the underlying physical read fails.</para>
		/// <para>Exception can also be thrown if the tag reports an error e.g. "out of range"</para>
		/// </exception>
		public ushort ReadShortReg(uint rtReg)
		{
			RTConst.RegRangeCheck(rtReg, "ReadShortReg", RTConst.RW_16BIT);

			byte[] b;

			b = ReadTag(mPassword, mSecured, NurApi.BANK_USER, rtReg, 2);

			return RTConverters.BytesToUInt16(b);
		}

		/// <summary>
		/// Read multiple 16-bit registers at once.
		/// </summary>
		/// <param name="firstAddr">First register to read, <seealso cref="RTRegs"/>.</param>
		/// <param name="regCount">Number of registers to read.</param>
		/// <returns>An array of unsigned 16-bit register that were read.</returns>
		/// <remarks></remarks>
		/// <exception cref="NurApiException">This exception is thrown when the underlying physical read fails.</exception>
		/// <exception cref="RTException">
		/// <para>This exception is thrown when the number of registers is out of range, <seealso cref="RTConst.MIN_RD_COUNT"/>, <seealso cref="RTConst.MAX_RD_COUNT"/>.</para>
		/// </exception>
		/// <exception cref="RTException">
		/// <para>This exception is thrown if the total reading exceeds the last memory position, <seealso cref="RTConst.LOG_AREA_LAST"/></para>
		/// </exception>
		public ushort []ReadMultipleRegs(uint firstAddr, int regCount)
		{
			RTConst.RegRangeCheck(firstAddr, "ReadMultipleRegs", RTConst.RW_16BIT);
			RTConst.RegRangeCheck((uint)(firstAddr + regCount), "ReadMultipleRegs: read length is out of range.", RTConst.RW_16BIT);
			RTConst.RWCountCheck(regCount, "ReadMultipleRegs");

			byte []data;

			data = ReadTag(mPassword, mSecured, NurApi.BANK_USER, firstAddr, (regCount * 2));

			return RTConverters.BytesToUInt16Arr(data);
		}

		/// <summary>
		/// Write a single 16-bit register.
		/// </summary>
		/// <param name="rtReg">Register to write, <seealso cref="RTRegs"/>.</param>
		/// <param name="wValue">Value to write.</param>
		/// <remarks>
		/// <para>See also: <seealso cref="Secured"/>, <seealso cref="Password"/></para>
		/// <para>The data to write is internally converted to the tag's big-endian format so there is no need for additional conversions.</para>
		/// </remarks>
		/// <exception cref="NurApiException">
		/// <para>This exception is thrown when the underlying physical write fails.</para>
		/// <para>Exception can also be thrown if the tag reports an error e.g. "out of range"</para>
		/// </exception>
		public void WriteShortReg(uint rtReg, ushort wValue)
		{
			RTConst.RegRangeCheck(rtReg, "WriteShortReg", RTConst.RW_16BIT);

			byte[] b;

			b = RTConverters.UInt16ToBytes(wValue);

			WriteTag(mPassword, mSecured, NurApi.BANK_USER, rtReg, b);
		}

		/// <summary>
		/// Read a 32-bit register value.
		/// </summary>
		/// <param name="rtReg">Register pair's  (2 x 16-bit register) address</param>
		/// <returns>The 32-bit register value.</returns>
		/// <remarks>The result is in little-endian format so there is no need to do any additional conversions.</remarks>
		/// <exception cref="NurApiException">
		/// <para>This exception is thrown when the underlying physical read fails.</para>
		/// <para>Exception can also be thrown if the tag reports an error e.g. "out of range"</para>
		/// </exception>
		/// <exception cref="IndexOutOfRangeException">This exception is thrown if the read is out of the register address space.</exception>
		public uint ReadUInt32Reg(uint rtReg)
		{
			RTConst.RegRangeCheck(rtReg, "ReadUInt32Reg", RTConst.RW_32BIT);

			byte[] b;

			b = ReadTag(mPassword, mSecured, NurApi.BANK_USER, rtReg, 4);

			return RTConverters.BytesToUInt32(b);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public byte[] GetReservedExtra()
		{
			return ReadTag(mPassword, mSecured, NurApi.BANK_PASSWD, RTConst.PASSWD_EXTRA_ADDR, RTConst.NR_PASSWD_EXTRA_BYTES);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="offset"></param>
		/// <returns></returns>
		public ushort GetReservedExtra(uint offset)
		{
			byte []bData  = ReadTag(mPassword, mSecured, NurApi.BANK_PASSWD, RTConst.PASSWD_EXTRA_ADDR + offset, 2);
			return RTConverters.BytesToUInt16(bData);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="data"></param>
		public void SetReservedExtra(byte[] data)
		{
			WriteTag(mPassword, mSecured, NurApi.BANK_PASSWD, RTConst.PASSWD_EXTRA_ADDR, data);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="offset"></param>
		/// <param name="wData"></param>
		public void SetReservedExtra(uint offset, ushort wData)
		{
			byte[] bData = RTConverters.UInt16ToBytes(wData);
			WriteTag(mPassword, mSecured, NurApi.BANK_PASSWD, RTConst.PASSWD_EXTRA_ADDR + offset, bData);
		}

		private void ByteArrToUshort(byte[] src, ushort[] dest, int destOffset)
		{
			int i;
			for (i = 0; i < src.Length; i += 2)
				dest[destOffset++] = RTConverters.BytesToUInt16(src, i);

		}

		/// <summary>
		/// Helpers function to for tag sample data reading.
		/// Uses one retry.
		/// </summary>
		/// <param name="secured">Set to true if the password access is required.</param>
		/// <param name="password">Password to use in a secured access.</param>
		/// <param name="address">Bank to read from.</param>
		/// <param name="nWords">Number of 16-bit words to read.</param>
		/// <param name="readData">If the read is OK, the read data is stored here.</param>
		/// <returns></returns>
		private bool TryReadUserMem(bool secured, uint password, uint address, int nWords, out byte[] readData)
		{
			byte[] readResult;

			readData = new byte[2 * nWords];

			try
			{
				readResult = ReadTag(password, secured, NurApi.BANK_USER, address, nWords * 2);
				System.Array.Copy(readResult, readData, readResult.Length);
				return true;
			}
			catch  (NurApiException e)
			{
				if (e.error == NurApiErrors.NUR_ERROR_TR_NOT_CONNECTED ||
					e.error == NurApiErrors.NUR_ERROR_TR_TIMEOUT ||
					e.error == NurApiErrors.NUR_ERROR_G2_ACCESS ||
					e.error == NurApiErrors.NUR_ERROR_G2_TAG_MEM_LOCKED ||
					e.error == NurApiErrors.NUR_ERROR_G2_TAG_MEM_OVERRUN)
				{
					/* At least these error mean "not worth to try again". */
					return false;
				}
			}

			/* Retry. */
			try
			{
				readResult = ReadTag(password, secured, NurApi.BANK_USER, address, nWords * 2);
				System.Array.Copy(readResult, readData, readResult.Length);
				return true;
			}
			catch { /* Now there needs to be serious radio failure or interference to say the least.*/ }

			return false;
		}

		/// <summary>
		/// Read the raw sample data from the tag using specified antenna.
		/// </summary>
		/// <param name="fromAntenna">The antenna to use. Set to -1 to ignore antenna selection and let the reader make decisionabout the used antenna.</param>
		/// <returns>Retunr an array of 16-bit unsigned values representing the stored sample data.</returns>
		/// <exception cref="FormatException">Exception can be thrown is no samples are available.</exception>
		public ushort[] GetRawSamples(int fromAntenna)
		{
			int i, nrWholeBlocks, nRemBytes, nTotalReads;
			byte[] chunk;
			uint curAddress = RTConst.LOG_AREA_BASE;
			int nrSamples;
			int destPtr = 0;
			string exceptionMessage = string.Empty;
			bool readOk = true;

			ushort[] ret;

			if (fromAntenna >= 0)
			{
				try
				{
					hApi.SelectedAntenna = fromAntenna;
				}
				catch
				{
					/* Handle error if needed. May indicate incorrectly selected antenna. */
				}
			}
			nrSamples = SampleCount;

			if (nrSamples == 0)
				throw new FormatException("GetRawSamples: no samples to read!");

			nrWholeBlocks = nrSamples / RTConst.READ_CHUNK_WORDS;
			nTotalReads = nrWholeBlocks;

			// The remainder.
			nRemBytes = (nrSamples % RTConst.READ_CHUNK_WORDS) * 2;
			if (nRemBytes > 0)
				nTotalReads++;

			ret = new ushort[nrSamples];

			ReadProgressInit(0, nTotalReads);

			for (i = 0; readOk && i < nrWholeBlocks; i++)
			{
				if (TryReadUserMem(false, 0, curAddress, RTConst.READ_CHUNK_WORDS, out chunk))
				{
					ByteArrToUshort(chunk, ret, destPtr);
					// Add word address.
					curAddress += RTConst.READ_CHUNK_WORDS;
					destPtr += RTConst.READ_CHUNK_WORDS;

					ReadProgressStep();
				}
				else
				{
					readOk = false;
					exceptionMessage = "The sample data read failed at " + (i + 1) + " / " + nTotalReads + ".";
				}
			}

			if (readOk && nrWholeBlocks != nTotalReads)
			{
				if (TryReadUserMem(false, 0, curAddress, nRemBytes / 2, out chunk))
				{
					ByteArrToUshort(chunk, ret, destPtr);
					ReadProgressStep();
				}
				else
				{
					readOk = false;
					exceptionMessage = "The sample data read failed at last block.";
				}
			}

			ReadProgressReset();

			if (!readOk)
				throw new RTException(exceptionMessage);

			return ret;
		}

		/// <summary>
		/// Read the sample data from the tag.
		/// </summary>
		/// <returns></returns>
		public RTConst.SAMPLEDATA GetSamples()
		{
			return GetSamples(-1);
		}

		/// <summary>
		/// Read the sample data from the tag using specified antenna.
		/// </summary>
		/// <param name="fromAntenna">The antenna to use. If the value is -1 the the antenna selection is made by the module.</param>
		/// <returns>Return the sample data from the tag if available.</returns>
		/// <exception cref="FormatException">Exception can be thrown if there is no sample data available.</exception>
		public RTConst.SAMPLEDATA GetSamples(int fromAntenna)
		{
			ushort[] tmp;
			List<double> dTemp;

			RTConst.SAMPLEDATA ret;

			dTemp = new List<double>();
			tmp = GetRawSamples(fromAntenna);

			if (tmp == null || tmp.Length == 0)
				throw new FormatException("RT0005::GetAllSamples: no samples found");

			// The application needs to catch if invalid value is found...
			foreach (ushort w in tmp)
				dTemp.Add(RTConverters.FixedToDouble(w));

			ret = new RTConst.SAMPLEDATA();

			ret.values = dTemp.ToArray();

			ret.min = RTConverters.FindMinTemp(ret.values);
			ret.max = RTConverters.FindMaxTemp(ret.values);

			return ret;
		}


		/// <summary>
		/// 
		/// </summary>
		public void ResetAll()
		{
			ControlRegister |= RTConst.CTL_RESET_MASK;
		}

		/// <summary>
		/// 
		/// </summary>
		public void ResetStart()
		{
			ControlRegister |= (RTConst.CTL_RESET_MASK | RTConst.CTL_LOGEN_MASK);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="startDelay"></param>
		/// <param name="samplingInterval"></param>
		public void StartSimpleLog(RTConst.LOGINTERVAL startDelay, RTConst.LOGINTERVAL samplingInterval)
		{
			ushort wIntVal = 0;
			ushort wDelay = 0;

			List<int> enList = new List<int>();

			if (samplingInterval == RTConst.LOGINTERVAL.INT_NONE)
			{
				throw new RTException("StartSimpleLog: interval cannot be 0.");
			}

			wIntVal = RTConverters.IntervalToUIn16(samplingInterval);
			wDelay = RTConverters.IntervalToUIn16(startDelay);

			ResetAll();

			try
			{
				BINLimit[0] = RTConst.FIXED_70LIM;
				BINThreshold[0] = RTConst.FIXED_MINUS20LIM;
				BINSampleTime[0] = wIntVal;
			}
			catch
			{
				throw new RTException("StartSimpleLog: BIN setup failed.");				
			}

			enList.Add(0);

			try
			{
				BINEnable = enList;
				BINEnableSample = enList;
			}
			catch
			{
				throw new RTException("StartSimpleLog: BIN enable failed.");
			}

			/* Disable time stamp store */
			try
			{
				WriteShortReg(RTRegs.BIN_ENA_TIME_STORE, 0);
			}
			catch
			{
				throw new RTException("StartSimpleLog: timestamp store disable failed.");
			}

			try
			{
				/* Setup delay time */
				if (wDelay == 0)	// Disable ?
				{
					int dummy = RTConst.CTL_DLYEN_MASK;
					dummy = ~dummy;
					ControlRegister &= (ushort)(dummy);
				}
				else
					ControlRegister |= RTConst.CTL_DLYEN_MASK;
			}
			catch
			{
				throw new RTException("StartSimpleLog: start delay control failed.");
			}

			try
			{
				WriteShortReg(RTRegs.SAMPLING_DELAY, wDelay);
			}
			catch
			{
				throw new RTException("StartSimpleLog: writing sampling delay failed.");
			}

			/* Start logging. */
			try
			{
				ResetStart();
			}
			catch
			{
				throw new RTException("StartSimpleLog: reset + start failed.");
			}
		}

		private List<int> RegToIntList(uint rtReg)
		{
			ushort enValue;
			enValue = ReadShortReg(rtReg);
			return RTConverters.UInt16ToIntList(enValue);
		}

		private void IntListToReg(uint rtReg, List<int> setBits)
		{
			ushort wValue;
			wValue = RTConverters.IntListToUInt16(setBits);
			WriteShortReg(rtReg, wValue);
		}

		public List<int> BINEnable
		{
			get
			{
				return RegToIntList(RTRegs.BIN_ENABLE);
			}
			set
			{
				IntListToReg(RTRegs.BIN_ENABLE, value);
			}
		}

		public List<int> BINEnableSample
		{
			get
			{
				return RegToIntList(RTRegs.BIN_ENA_SAMPLE_STORE);
			}
			set
			{
				IntListToReg(RTRegs.BIN_ENA_SAMPLE_STORE, value);
			}
		}

		public List<int> BINAlarms()
		{
			return RegToIntList(RTRegs.BIN_ALARM);
		}

		public bool Alarms
		{
			get
			{
				return (ReadShortReg(RTRegs.STATUS) & RTConst.STAT_ALARM_MASK) != 0;
			}
		}


		private void ReadProgressInit(int min, int max)
		{
			if (ProgressEvent != null)
			{
				ProgressEvent(this, new RTProgressEvent(false, min, max));
			}
		}

		private void ReadProgressStep()
		{
			if (ProgressEvent != null)
			{
				ProgressEvent(this, new RTProgressEvent(true, 0, 0));
			}
		}

		private void ReadProgressReset()
		{
			if (ProgressEvent != null)
			{
				ProgressEvent(this, new RTProgressEvent(false, -1, -1));
			}
		}
	}
}
