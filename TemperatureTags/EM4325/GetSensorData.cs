using System;
using System.Collections.Generic;
using System.Text;

using NurApiDotNet;

namespace EM4325
{
	public partial class EM4325Tag : NurApi.Tag
	{
		/// <summary>
		/// Gen2 read command value.
		/// </summary>
		public const uint GEN2_READCMD = 0xC2;
		/// <summary>
		/// Gen2 write command value.
		/// </summary>
		public const uint GEN2_WRITECMD = 0xC3;

		// 32 bits for sensor data + 32 bits for UTC.
		private const int SENSORBYTES_NO_UID = 8;
		private const int SD_BATTALARM_BIT = 15;
		private const int SD_AUXALARM_BIT = 14;
		private const int SD_OVERALARM_BIT = 13;
		private const int SD_UNDERALARM_BIT = 12;
		private const int SD_P3_LSH = 11;
		private const int SD_MONENABLED_BIT = 10;
		private const int SD_SIMPLE_BIT = 9;

		private const int SD_SIGNBIT_LSH = 8;
		private const int SD_ABORTCNT_LSH = 10;
		private const int SD_ABORTCNT_BITS = 6;
		private const int SD_ABORTCNT_MASK = ((1 << SD_ABORTCNT_BITS) - 1);

		private const int SD_UNDERCNT_LSH = 5;
		private const int SD_UNDERCNT_BITS = 5;
		private const int SD_UNDERCNT_MASK = ((1 << SD_UNDERCNT_BITS) - 1);

		private const int SD_OVERCNT_BITS = 5;
		private const int SD_OVERCNT_MASK = ((1 << SD_OVERCNT_BITS) - 1);

		private static bool CheckSensorRespLen(int len, bool uid)
		{
			if (!uid)
				return (len == SENSORBYTES_NO_UID);

			if (((len & 1) != 0) || len < (SENSORBYTES_NO_UID + RESPLEN_ALLOC_E0))
				return false;

			len -= SENSORBYTES_NO_UID;

			return (len == RESPLEN_ALLOC_E0 || len == RESPLEN_ALLOC_E2 || len == RESPLEN_ALLOC_E3);
		}

		public byte[] lastSdResp = null;

		/// <summary>
		/// Get sensor data.
		/// </summary>
		/// <param name="getUID">If true then the tag is instructed to backscatter the UID as a part of the response.</param>
		/// <param name="getNew">If true then a new sample is requested. Otherwise the tag is instructed to backscatter the last sample.</param>
		/// <returns>Interpreted sensor data: <see cref="SensorData"/>.</returns>
		/// <exception cref="NurApiException">Exception is thrown with module or tag communication error.</exception>
		/// <exception cref="IndexOutOfRangeException">Exception is thrown if the response array indexing is out of range.</exception>
		/// <exception cref="ApplicationException">Is thrown with an invalid response (length or allocation class).</exception>
		public SensorData GetSensorData(bool getUID, bool getNew)
		{
			SensorData sd = new SensorData();
			NurApi.CustomExchangeParams xch;
			NurApi.CustomExchangeResponse resp;

			int respLen;
			ushort rxLen;
			int txLen;
			bool okLength = false;

			sd.hasUid = false;

			if (getUID == false)
				rxLen = SENSORBYTES_NO_UID * 8 + 16;	// Response + handle.
			else
				rxLen = 0;	// Length of UID is now knwon; defined by allocation class.

			xch = BuildDefault(rxLen, getNew, STRIP_HANDLE);
			// GetNew -> asWrite: new sample requires longer response time.
			if (getNew)
				xch.rxTimeout = mWriteTimeout;
			else
				xch.rxTimeout = mReadTimeout;

			txLen = 0;
			txLen = NurApi.BitBufferAddValue(xch.bitBuffer, CMD_GET_SENSORDATA, PROPRIETARY_BITS, txLen);
			txLen = NurApi.BitBufferAddValue(xch.bitBuffer, (uint)(getUID ? 1 : 0), 1, txLen);
			txLen = NurApi.BitBufferAddValue(xch.bitBuffer, (uint)(getNew ? 1 : 0), 1, txLen);
			xch.txLen = (ushort)txLen;

			lastSdResp = null;

			hNur.VLog("EPC[1]:" + base.GetEpcString());
			hNur.VLog("EPC[2]:" + NurApi.BinToHexString(mEPC));
			
			ResetToA();
			
			resp = hNur.CustomExchangeByEPC(mPassword, mSecured, mEPC, xch);
			respLen = resp.tagBytes.Length;

			if (respLen > 0)
			{
				lastSdResp = new byte[respLen];
				System.Array.Copy(resp.tagBytes, lastSdResp, respLen);
			}

			respLen = AdjustUIDResponseLength(respLen, resp.error);
			okLength = CheckSensorRespLen(respLen, getUID);

			if (resp.error == NurApiErrors.NUR_NO_ERROR && okLength)
			{
				byte[] uBytes;
				int temp;
				ushort dMsw, dLsw;

				if (getUID)
				{
					sd.uid = InterpretUIDResponse(hNur, resp.tagBytes, respLen - SENSORBYTES_NO_UID);
					sd.hasUid = true;
				}

				uBytes = new byte[4];
				System.Array.Copy(resp.tagBytes, respLen - SENSORBYTES_NO_UID, uBytes, 0, 4);
				System.Array.Reverse(uBytes);
				sd.data = BitConverter.ToUInt32(uBytes, 0);

				temp = (int)(sd.data);
				dMsw = (ushort)((temp >> 16) & 0xFFFF);
				dLsw = (ushort)(temp & 0xFFFF);

				temp >>= 16;
				// Negative ?
				temp &= ((1 << 9) - 1);
				if ((temp & (1 << SD_SIGNBIT_LSH)) != 0)
					temp *= -1;

				sd.temp = (float)temp;
				sd.temp /= 4.0F;

				sd.battAlarm = BitToBool(dMsw, SD_BATTALARM_BIT);
				sd.auxAlarm = BitToBool(dMsw, SD_AUXALARM_BIT);
				sd.overTemp = BitToBool(dMsw, SD_OVERALARM_BIT);
				sd.underTemp = BitToBool(dMsw, SD_UNDERALARM_BIT);
				sd.p3level = ((dMsw >> SD_P3_LSH) & 1);
				sd.enabled = BitToBool(dMsw, SD_MONENABLED_BIT);
				sd.isSimple = BitToBool(dMsw, SD_SIMPLE_BIT);

				sd.abortCount = ((dLsw >> SD_ABORTCNT_LSH) & SD_ABORTCNT_MASK);
				sd.underCount = ((dLsw >> SD_UNDERCNT_LSH) & SD_UNDERCNT_MASK);
				sd.overCount = (dLsw & SD_OVERCNT_MASK);

				System.Array.Copy(resp.tagBytes, respLen - SENSORBYTES_NO_UID + 4, uBytes, 0, 4);
				System.Array.Reverse(uBytes);
				sd.utc = BitConverter.ToUInt32(uBytes, 0);

				sd.raw = new byte[SENSORBYTES_NO_UID];
				System.Array.Copy(resp.tagBytes, respLen - SENSORBYTES_NO_UID, sd.raw, 0, SENSORBYTES_NO_UID);

				return sd;
			}
			else
			{
				if (resp.error == NurApiErrors.NUR_NO_ERROR && !okLength)
					throw new ApplicationException("GetSensorData(): ok respone but length (" + respLen + " bytes) is invalid.");
			}

			return sd;
		}

		/// <summary>
		/// Simple read of the last sample without including the UID.
		/// </summary>
		/// <returns>Interpreted sensor data (last): <see cref="SensorData"/>.</returns>
		/// <exception cref="NurApiException">Exception is thrown with module or tag communication error.</exception>
		/// <exception cref="IndexOutOfRangeException">Exception is thrown if the response array indexing is out of range.</exception>
		/// <exception cref="ApplicationException">Is thrown with an invalid response (length or allocation class).</exception>
		public SensorData GetLastSample()
		{
			return GetSensorData(false, false);
		}

		/// <summary>
		/// Simple read of a new sample without including the UID.
		/// </summary>
		/// <returns>Interpreted sensor data (new): <see cref="SensorData"/>.</returns>
		/// <exception cref="NurApiException">Exception is thrown with module or tag communication error.</exception>
		/// <exception cref="IndexOutOfRangeException">Exception is thrown if the response array indexing is out of range.</exception>
		/// <exception cref="ApplicationException">Is thrown with an invalid response (length or allocation class).</exception>
		public SensorData GetNewSample()
		{
			return GetSensorData(false, false);
		}

		/// <summary>
		/// Simple read of the last sample value only; no UTC or UID.
		/// </summary>
		/// <returns>An unsigned integer representing the tag bacskcattered last sample value.</returns>
		/// <exception cref="NurApiException">Exception is thrown with module or tag communication error.</exception>
		/// <exception cref="IndexOutOfRangeException">Exception is thrown if the response array indexing is out of range.</exception>
		/// <exception cref="ApplicationException">Is thrown with an invalid response (length or allocation class).</exception>
		public uint GetLastSampleValue()
		{
			return GetLastSample().data;
		}

		/// <summary>
		/// Simple read of a new sample value only; no UTC or UID.
		/// </summary>
		/// <returns>An unsigned integer representing the tag bacskcattered new sample value.</returns>
		/// <exception cref="NurApiException">Exception is thrown with module or tag communication error.</exception>
		/// <exception cref="IndexOutOfRangeException">Exception is thrown if the response array indexing is out of range.</exception>
		/// <exception cref="ApplicationException">Is thrown with an invalid response (length or allocation class).</exception>
		public uint GetNewSampleValue()
		{
			return GetNewSample().data;
		}

		/// <summary>
		/// Attribyte used to read seonsor value from the tag.
		/// </summary>
		public SensorData Sensor
		{
			get { return GetSensorData(false, true); }
			set { }
		}

		/// <summary>
		/// Get a new sample and return the temperature value.
		/// </summary>
		public float Temperature
		{
			get { return Sensor.temp; }			
		}

		/// <summary>
		/// Get the sensor data by using standard read sequence.
		/// </summary>
		/// <param name="getNew">Whether to get new sample or last stored sample.</param>
		/// <returns>The temperature as a float (in Celsius) if successful.</returns>
		/// <remarks>
		/// <para>The return value is -100.0 if the first read exchange fails.</para>
		/// <para>The return value is -200.0 if the second read exchange fails.</para>
		/// </remarks>
		public float GetTempReading(bool getNew)
		{
			int txLenRead1 = 0;
			int txLenRead2 = 0;
			int respLen;
			float fTemp = -100.0F;

			NurApi.CustomExchangeParams xchRead1;
			NurApi.CustomExchangeResponse respRead1;
			NurApi.CustomExchangeParams xchRead2;
			NurApi.CustomExchangeResponse respRead2;

			xchRead1 = BuildDefault(32, false, false);
			xchRead2 = BuildDefault(32, true, false);
			xchRead1.rxTimeout = mReadTimeout;
			xchRead2.rxTimeout = mReadTimeout;

			// Read.
			txLenRead1 = NurApi.BitBufferAddValue(xchRead1.bitBuffer, GEN2_READCMD, 8, txLenRead1);
			// User mem
			txLenRead1 = NurApi.BitBufferAddValue(xchRead1.bitBuffer, (uint)NurApi.BANK_USER, 2, txLenRead1);
			// Register address
			txLenRead1 = NurApi.BitBufferAddEBV32(xchRead1.bitBuffer, ADDR_SENSORDATA_MSW, txLenRead1);
			// One word.
			txLenRead1 = NurApi.BitBufferAddValue(xchRead1.bitBuffer, 1, 8, txLenRead1);
			xchRead1.txLen = (ushort)txLenRead1;

			// Read.
			txLenRead2 = NurApi.BitBufferAddValue(xchRead2.bitBuffer, GEN2_READCMD, 8, txLenRead2);
			// User mem
			txLenRead2 = NurApi.BitBufferAddValue(xchRead2.bitBuffer, (uint)NurApi.BANK_USER, 2, txLenRead2);
			// Register address
			txLenRead2 = NurApi.BitBufferAddEBV32(xchRead2.bitBuffer, ADDR_SENSORDATA_MSW, txLenRead2);
			// One word.
			txLenRead2 = NurApi.BitBufferAddValue(xchRead2.bitBuffer, 1, 8, txLenRead2);
			xchRead2.appendHandle = 0;
			xchRead2.txLen = (ushort)txLenRead2;

			hNur.SetExtendedCarrier(true);

			try
			{
				respRead1 = hNur.CustomExchangeByEPC(0, false, mEPC, xchRead1);
			}
			catch
			{
				return fTemp;
			}
			
			respLen = respRead1.tagBytes.Length;

			if (respLen == 4)
			{
				short temp;
				fTemp = -200.0F;
				/* Give sampling time. */
				System.Threading.Thread.Sleep(20);

				// No re-selection if needed.
				// hNur.DisableCustomReselect();
				// Set these in case no-reselection.
				//xchRead2.bitBuffer[2] = respRead1.tagBytes[2];
				//xchRead2.bitBuffer[3] = respRead1.tagBytes[3];

				try
				{
					respRead2 = hNur.CustomExchangeByEPC(0, false, mEPC, xchRead2);
				}
				catch
				{
					return fTemp;
				}

				temp = BitConverter.ToInt16(respRead2.tagBytes, 0);

				// Negative ?
				temp &= ((1 << 9) - 1);
				if ((temp & (1 << SD_SIGNBIT_LSH)) != 0)
					temp *= -1;

				fTemp = (float)temp;
				fTemp /= 4.0F;
			}

			return fTemp;
		}
	}
}
