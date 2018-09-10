using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace NurSample
{
    class Utils
    {
        /// <summary>
        /// Converts UInt64 to big endia bytes.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static byte[] ConvertToBigEndiaBytes(UInt64 value)
        {
            if (BitConverter.IsLittleEndian)
            {
                value = ReverseBytes(value);
            }
            return BitConverter.GetBytes(value);
        }

        /// <summary>
        /// Converts UInt32 to big endia bytes.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static byte[] ConvertToBigEndiaBytes(UInt32 value)
        {
            if (BitConverter.IsLittleEndian)
            {
                value = ReverseBytes(value);
            }
            return BitConverter.GetBytes(value);
        }

        /// <summary>
        /// Converts UInt16 to big endia bytes.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static byte[] ConvertToBigEndiaBytes(UInt16 value)
        {
            if (BitConverter.IsLittleEndian)
            {
                value = ReverseBytes(value);
            }
            return BitConverter.GetBytes(value);
        }

        /// <summary>
        /// Converts the big endia bytes to system endia.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static UInt64 ConvertBigEndiaToSystemEndia(byte[] value)
        {
            switch (value.Length)
            {
                case 1:
                    return value[0];
                case 2:
                    UInt16 ret16 = BitConverter.ToUInt16(value, 0);
                    if (BitConverter.IsLittleEndian)
                    {
                        return ReverseBytes(ret16);
                    }
                    return ret16;
                case 4:
                    UInt32 ret32 = BitConverter.ToUInt32(value, 0);
                    if (BitConverter.IsLittleEndian)
                    {
                        return ReverseBytes(ret32);
                    }
                    return ret32;
                default:
                    UInt64 ret64 = BitConverter.ToUInt64(value, 0);
                    if (BitConverter.IsLittleEndian)
                    {
                        return ReverseBytes(ret64);
                    }
                    return ret64;
            }
        }

        /// <summary>
        /// Converts the big endia to system endia.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static UInt64 ConvertBigEndiaToSystemEndia(UInt64 value)
        {
            if (BitConverter.IsLittleEndian)
            {
                return ReverseBytes(value);
            }
            return value;
        }

        /// <summary>
        /// Converts the big endia to system endia.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static UInt32 ConvertBigEndiaToSystemEndia(UInt32 value)
        {
            if (BitConverter.IsLittleEndian)
            {
                return ReverseBytes(value);
            }
            return value;
        }

        /// <summary>
        /// Converts the big endia to system endia.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static UInt16 ConvertBigEndiaToSystemEndia(UInt16 value)
        {
            if (BitConverter.IsLittleEndian)
            {
                return ReverseBytes(value);
            }
            return value;
        }

        /// <summary>
        /// Reverses byte order (16-bit)
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static UInt16 ReverseBytes(UInt16 value)
        {
            return (UInt16)((value & 0xFFU) << 8 | (value & 0xFF00U) >> 8);
        }

        /// <summary>
        /// Reverses byte order (32-bit)
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static UInt32 ReverseBytes(UInt32 value)
        {
            return (value & 0x000000FFU) << 24 | (value & 0x0000FF00U) << 8 |
                   (value & 0x00FF0000U) >> 8 | (value & 0xFF000000U) >> 24;
        }

        /// <summary>
        /// Reverses byte order (64-bit)
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static UInt64 ReverseBytes(UInt64 value)
        {
            return (value & 0x00000000000000FFUL) << 56 | (value & 0x000000000000FF00UL) << 40 |
                   (value & 0x0000000000FF0000UL) << 24 | (value & 0x00000000FF000000UL) << 8 |
                   (value & 0x000000FF00000000UL) >> 8 | (value & 0x0000FF0000000000UL) >> 24 |
                   (value & 0x00FF000000000000UL) >> 40 | (value & 0xFF00000000000000UL) >> 56;
        }

        /// <summary>
        /// Shifts the left.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="bitcount">The bitcount.</param>
        /// <returns></returns>
        public static byte[] ShiftLeft(byte[] value, int bitcount)
        {
            byte[] temp = new byte[value.Length];
            if (bitcount >= 8)
            {
                Array.Copy(value, bitcount / 8, temp, 0, temp.Length - (bitcount / 8));
            }
            else
            {
                Array.Copy(value, temp, temp.Length);
            }
            if (bitcount % 8 != 0)
            {
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i] <<= bitcount % 8;
                    if (i < temp.Length - 1)
                    {
                        temp[i] |= (byte)(temp[i + 1] >> 8 - bitcount % 8);
                    }
                }
            }
            return temp;
        }
    }
}
