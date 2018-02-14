using System;
using System.Collections.Generic;
using System.Text;

namespace CAENRT0005
{
    public class RTConverters
    {
        /// <summary>
        /// Convert an unsigned short (word) value into big-endian bytes.
        /// </summary>
        /// <param name="word">The unsigned short value (16-bit word) to convert.</param>
        /// <returns>The converted 2-byte array in big-endian.</returns>
        public static byte[] UInt16ToBytes(ushort word)
        {
            byte[] ret = BitConverter.GetBytes(word);
            Array.Reverse(ret);

            return ret;
        }

        /// <summary>
        /// Convert a 2-byte array to a little-endian unsigned short (word).
        /// </summary>
        /// <param name="b">The 2-byte array representing an unsigned short value in big-endian format.</param>
        /// <returns>The converted word value in little-endian.</returns>
		/// <remarks>The array length is not checked, it is expected to be 2 bytes long.</remarks>
		/// <exception cref="ArgumentNullException">If the given array was null.</exception>
		/// <exception cref="ArgumentOutOfRangeException">Array is less than 2 bytes long</exception>
        public static ushort BytesToUInt16(byte[] b)
        {
			ushort wValue = 0;
			wValue = b[0];
			wValue <<= 8;
			wValue |= b[1];
			return wValue;
        }

		public static ushort BytesToUInt16(byte[] b, int offset)
		{
			ushort wValue = 0;
			wValue = b[offset];
			wValue <<= 8;
			wValue |= b[offset + 1];
			return wValue;
		}

		/// <summary>
		/// Convert an unsigned int (dword, 32-bit) value into big-endian bytes.
		/// </summary>
		/// <param name="dword">32-bit unsigned integer to convert.</param>
		/// <returns>Byte array that represents the given parameter bytes in big-endian format.</returns>
		public static byte[] UInt32ToBytes(uint dword)
		{
			byte[] ret = BitConverter.GetBytes(dword);
			Array.Reverse(ret);
			return ret;
		}

		/// <summary>
		/// Convert a 4-byte array to an unsigned integer (32-bit) value.
		/// </summary>
		/// <param name="b">The 4-byte array representing an unsigned short value in big-endian format.</param>
		/// <returns>An unsigned 32-bit integer in little-endian format.</returns>
		/// <remarks>The array length is not checked, it is expected to be 4 bytes long.</remarks>
		/// <exception cref="ArgumentNullException">If the given array was null.</exception>
		public static uint BytesToUInt32(byte[] b)
		{
			Array.Reverse(b);
			return BitConverter.ToUInt32(b, 0);
		}

		private static double FixedConversion(ushort fixedVal)
		{
			double d = 0.0;

			d = fixedVal;

			if (fixedVal >= 0 && fixedVal <= RTConst.FIXED_70LIM)
				d /= RTConst.TEMP_DIV;
			else
				d = ((d - RTConst.NEG_CONST) / RTConst.TEMP_DIV);

			return d;
		}

		/// <summary>
        /// Return the fixed format value as a double value.
        /// </summary>
        /// <param name="fixedVal">The temperature value in the fixed 8.5 format.</param>
        /// <returns>The double representation of the converted value.</returns>
        /// <exception cref="FormatException">Exception can be thrown if the parameter is invalid.</exception>
        public static double FixedToDouble(ushort fixedVal)
        {
            double dVal = 0.0;

            dVal = fixedVal;

            if ((fixedVal & RTConst.US_TEMP_VALID_MASK) != 0)
                throw new FormatException("RT0005::FixedToDouble: invalid value");

			dVal = FixedConversion(fixedVal);

			if (dVal < RTConst.MIN_TEMP || dVal > RTConst.MAX_TEMP)
				throw new FormatException("RT0005::FixedToDouble: result is out of range");

            return dVal;
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dValue"></param>
		/// <returns></returns>
		public static ushort DoubleToFixed(double dValue)
		{
			ushort fixedVal = 0;

			if (dValue < RTConst.MIN_TEMP && dValue > RTConst.MAX_TEMP)
				throw new FormatException("RT0005::DoubleToFixed: value is out of range");

			if (dValue >= 0.0)
				fixedVal = (ushort)(dValue * RTConst.TEMP_DIV);
			else
				fixedVal = (ushort)(RTConst.NEG_CONST + RTConst.TEMP_DIV * dValue);

			if ((fixedVal & RTConst.US_TEMP_VALID_MASK) != 0)
				throw new FormatException("RT0005::DoubleToFixed: result is invalid");

			return fixedVal;
		}

        /// <summary>
        /// Return the fixed format value as a string.
        /// </summary>
        /// <param name="fixedVal">The temperature value in the fixed 8.5 format.</param>
        /// <returns>The string representation of the converted value.</returns>
        /// <exception cref="FormatException">Exception can be thrown from the <seealso cref="FixedToDouble"/>.</exception>
        public static string FixedToString(ushort fixedVal)
        {
            return string.Format("{0:0.00}", FixedToDouble(fixedVal));
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="intVal"></param>
		/// <returns></returns>
		public static ushort IntervalToUIn16(RTConst.LOGINTERVAL intVal)
		{
			switch (intVal)
			{
				case RTConst.LOGINTERVAL.INT_1MIN: return 60;
				case RTConst.LOGINTERVAL.INT_2MIN: return (2 * 60);
				case RTConst.LOGINTERVAL.INT_5MIN: return (5 * 60);
				case RTConst.LOGINTERVAL.INT_10MIN: return (10 * 60);
				case RTConst.LOGINTERVAL.INT_15MIN: return (15 * 60);
				case RTConst.LOGINTERVAL.INT_30MIN: return (30 * 60);
				case RTConst.LOGINTERVAL.INT_1HR: return (60 * 60);
			}

			return 0;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="wValue"></param>
		/// <returns></returns>
		public static List<int> UInt16ToIntList(ushort wValue)
		{
			ushort mask;
			int i;
			List<int> ret = new List<int>();

			mask = 1;
			for (i = 0; i < 16; i++)
			{
				if ((mask & wValue) != 0)
					ret.Add(i);
				mask <<= 1;
			}

			return ret;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="setBits"></param>
		/// <returns></returns>
		public static ushort IntListToUInt16(List<int> setBits)
		{
			ushort wValue;
			
			if (setBits.Count == 0)
				return 0;
			if (setBits.Count > 16)
				throw new RTException("IntListToUInt16: too many values");

			wValue = 0;
			foreach (int iValue in setBits)
			{
				if (iValue < 0 || iValue > 15)
					throw new RTException("IntListToUInt16: bit value " + iValue + " is out of range 0...15.");
				wValue |= (ushort)(1 << iValue);
			}

			return wValue;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="src"></param>
		/// <returns></returns>
		public static ushort []BytesToUInt16Arr(byte []src)
		{
			int offset;
			List <ushort> tmp = new List<ushort>();

			for (offset = 0; offset < src.Length; offset += 2)
				tmp.Add(BytesToUInt16(src, offset));

			return tmp.ToArray();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="usValue"></param>
		/// <returns></returns>
		public static string HexUInt16(ushort usValue)
		{
			return "0x" + usValue.ToString("X4");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="uiValue"></param>
		/// <returns></returns>
		public static string HexUInt32(uint uiValue)
		{
			return "0x" + uiValue.ToString("X8");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="theList"></param>
		/// <returns></returns>
		public static string IntListToString(List<int> theList)
		{
			int i = 0;
			int n;
			string s = "";

			if (theList == null)
				return "(null)";
			
			n = theList.Count;
			if (n == 0)
				return "none";

			foreach (int iVal in theList)
			{
				s += iVal.ToString();
				if (n != 1 && i != (n - 1))
					s += ", ";
				i++;
			}

			return s;
		}

		public static double FindMinTemp(double[] dValues)
		{
			double dMin = Int16.MaxValue;

			foreach (double d in dValues)
			{
				if (dMin > d)
					dMin = d;
			}

			return dMin;
		}

		public static double FindMaxTemp(double[] dValues)
		{
			double dMax = Int16.MinValue;

			foreach (double d in dValues)
			{
				if (dMax < d)
					dMax = d;
			}

			return dMax;
		}
    }
}
