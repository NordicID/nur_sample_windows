using System;
using System.Collections.Generic;
using System.Text;

using NurApiDotNet;

namespace SL900A
{
	public partial class SL900ATag : NurApi.Tag
	{
		private const byte CMD_GETSENSORVAL = 0xAD;
		private const int SENSOR_TYPE_BITS = 8;
		/* 16 + 16 for handle. */
		private const int SENSORVAL_RESP_LEN = 32;
		/* In bytes */
		private const int SENSORVAL_RESP_BYTES = 2;

		private const int SENSOR_AD_ERR_BIT = 15;
		private const int SENSOR_RANGE_LSH = 10;
		private const int SENSOR_RANGE_BITS = 5;
		private const uint SENSOR_RANGE_MASK_VAL = ((1 << SENSOR_RANGE_BITS) -1);

		private const int SENSOR_AD_BITS = 10;
		private const uint SENSOR_AD_VALMASK = ((1 << SENSOR_AD_BITS) - 1);

		/// <summary>
		/// Constant defining the temperature sensor value.
		/// </summary>
		public const uint TEMP_SENS_TYPE = 0;
		/// <summary>
		/// Constant defining the external sensor 1 value.
		/// </summary>
		public const uint EXT1_SENS_TYPE = 1;
		/// <summary>
		/// Constant defining the external sensor 2 value.
		/// </summary>
		public const uint EXT2_SENS_TYPE = 2;
		/// <summary>
		/// Constant defining the battery level sensor value.
		/// </summary>
		public const uint BATTVOLT_TYPE = 3;
		/// <summary>
		/// Constant defining the last valid sensor type value.
		/// </summary>
		public const uint MAX_SENS_TYPE = BATTVOLT_TYPE;

		private SensorValue SensorValueExchange(uint password, bool secured, uint sensorType)
		{
			return SensorValueExchange(password, secured, sensorType, false);
		}

		private SensorValue SensorValueExchange(uint password, bool secured, uint sensorType, bool noSelection)
		{
			NurApi hCurApi = hApi != null ? hApi : hLocalApi;

			SensorValue sv = new SensorValue();
			List<BitEntry> entries = new List<BitEntry>();
			NurApi.CustomExchangeParams xch;
			NurApi.CustomExchangeResponse resp;
			int respLen;
			uint tmpVal;
			int ticks;

			BitBuffer bb;

			if (hCurApi == null)
				throw new NurApiException("SensorValueExchange(): cannot find NurApi.");

			entries.Add(BuildEntry(ADD_PARAMETER, sensorType, SENSOR_TYPE_BITS));
			bb = BuildCommand(CMD_GETSENSORVAL, entries);

			/* 0 for possible error reception. */
			xch = BuildDefault(bb, 0, false, false);

			ticks = System.Environment.TickCount;
			if (noSelection)
				resp = hCurApi.CustomExchange(password, secured, xch);
			else
				resp = hApi.CustomExchangeSingulated(password, secured, NurApi.BANK_EPC, 32, epc.Length * 8, epc, xch);

			sv.time = System.Environment.TickCount - ticks;
			respLen = resp.tagBytes.Length;

			if (resp.error != NurApiErrors.NUR_NO_ERROR)
			{
				if (respLen >= MIN_ERROR_RESP_LENGTH)
					InterpretedException("Get sensor value", resp);
				DoException("Get sensor value", resp);
			}

			tmpVal = resp.tagBytes[0];
			tmpVal <<= 8;
			tmpVal |= resp.tagBytes[1];

			sv.adError = IsMaskBitSet(tmpVal, SENSOR_AD_ERR_BIT);
			sv.rangeOrLimit = ((tmpVal >> SENSOR_RANGE_LSH) & SENSOR_RANGE_MASK_VAL);
			sv.adValue = (tmpVal & SENSOR_AD_VALMASK);

			return sv;
		}

		/// <summary>
		/// Structure representing a sensor value as defined by
		/// the SL900A specification.
		/// </summary>
		public struct SensorValue
		{
			/// <summary>
			/// Indicates A/D conversion error.
			/// </summary>
			public bool adError;
			/// <summary>
			/// The range/limit value as defined by
			/// the SL900A specification.
			/// </summary>
			public uint rangeOrLimit;
			/// <summary>
			/// A/D conversion value.
			/// </summary>
			public uint adValue;
			/// <summary>
			/// Approximate time in milliseconds that the command exchange took.
			/// </summary>
			public int time;
		}

		/// <summary>
		/// Get temperature sensor value with command 0xAD.
		/// </summary>
		/// <exception cref="ApplicationException">Thrown when tag responded with an error or the tag's response length was invalid.</exception>
		/// <exception cref="NurApiException">Exception is thrown when communication error occured with the tag or module.</exception>
		public SensorValue TempSensorValue
		{
			get
			{
				return SensorValueExchange(0, false, TEMP_SENS_TYPE);
			}
		}

		/// <summary>
		/// Get external sensor 1 sensor value with command 0xAD.
		/// </summary>
		/// <exception cref="ApplicationException">Thrown when tag responded with an error or the tag's response length was invalid.</exception>
		/// <exception cref="NurApiException">Exception is thrown when communication error occured with the tag or module.</exception>
		public SensorValue Ext1SensorValue
		{
			get
			{
				return SensorValueExchange(0, false, EXT1_SENS_TYPE);
			}
		}

		/// <summary>
		/// Get external sensor 2 sensor value with command 0xAD.
		/// </summary>
		/// <exception cref="ApplicationException">Thrown when tag responded with an error or the tag's response length was invalid.</exception>
		/// <exception cref="NurApiException">Exception is thrown when communication error occured with the tag or module.</exception>
		public SensorValue Ext2SensorValue
		{
			get
			{
				return SensorValueExchange(0, false, EXT2_SENS_TYPE);
			}
		}

		/// <summary>
		/// Battery voltage sensor value with command 0xAD.
		/// </summary>
		/// <exception cref="ApplicationException">Thrown when tag responded with an error or the tag's response length was invalid.</exception>
		/// <exception cref="NurApiException">Exception is thrown when communication error occured with the tag or module.</exception>
		public SensorValue BattVoltValue
		{
			get
			{
				return SensorValueExchange(0, false, BATTVOLT_TYPE);
			}
		}

		/// <summary>
		/// Read specific sensor.
		/// </summary>
		/// <param name="sensor">Sensor to read.</param>
		/// <returns>Sensor value structure, see <see cref="SensorValue"/>.</returns>
		/// <exception cref="ApplicationException">Throw "value too big" exception if sensor value is greater than <see cref="MAX_SENS_TYPE"/>.</exception>
		/// <remarks>Other exceptions are as with reading e.g. <see cref="BattVoltValue"/>.</remarks>
		public SensorValue ReadSensor(uint sensor)
		{
			if (sensor > MAX_SENS_TYPE)
				throw new ApplicationException("ReadSensor(): sensor value " + sensor + " is too big.");
			return SensorValueExchange(0, false, sensor);
		}

		/// <summary>
		/// Read specific sensor without using the EPC singulation.
		/// </summary>
		/// <param name="sensor">Sensor to read.</param>
		/// <returns>Sensor value structure, see <see cref="SensorValue"/>.</returns>
		/// <exception cref="ApplicationException">Throw "value too big" exception if sensor value is greater than <see cref="MAX_SENS_TYPE"/>.</exception>
		/// <remarks>Other exceptions are as with reading e.g. <see cref="BattVoltValue"/>.</remarks>		
		public SensorValue ReadSensorUnselected(uint sensor)
		{
			if (sensor > MAX_SENS_TYPE)
				throw new ApplicationException("ReadSensorUnselected(): sensor value " + sensor + " is too big.");
			return SensorValueExchange(0, false, sensor, true);
		}
	}
}
