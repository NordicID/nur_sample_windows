using System;

using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;
using System.Windows;

using NurApiDotNet;

namespace RFIDHelpers
{
	public partial class RFIDHelpers
	{
		private static ushort []BytesToWords(byte []b)
		{
			ushort []ret;
			ushort us;
			int i, j;

			ret = new ushort[b.Length / 2];
			j = 0;
			for (i = 0; i < b.Length; )
			{
				us = b[i++];
				us <<= 8;
				us |= b[i++];
				ret[j++] = us;
			}

			return ret;
		}

		private static uint[] BytesToDwords(byte[] b)
		{
			uint[] ret;
			int i, j;
			byte[] uiBytes;

			uiBytes = new byte[4];
			ret = new uint[b.Length / 4];
			j = 0;

			for (i = 0; i < b.Length; i += 4)
			{
				System.Array.Copy(b, i, uiBytes, 0, 4);
				System.Array.Reverse(uiBytes);
				ret[j++] = BitConverter.ToUInt32(uiBytes, 0);
			}

			return ret;
		}

		public static byte[] ReadBytes(NurApi hApi, byte[] epc, byte bank, uint addr, int byteLength)
		{
			hApi.ULog("Read bytes:");
			hApi.ULog("EPC = " + NurApi.BinToHexString(epc));
			hApi.ULog("SelBank / SelAddr / SelLen / = " + string.Format("{0} / {1} / {2}", NurApi.BANK_EPC, 32, epc.Length * 8));
			hApi.ULog("Bank = " + bank + ", addr = 0, byteSize = " + byteLength);

			return hApi.ReadSingulatedTag(0, false, NurApi.BANK_EPC, 32, epc.Length * 8, epc, bank, addr, byteLength);
		}

		public static ushort[] ReadWords(NurApi hApi, byte[] epc, byte bank, uint addr, int wordLength)
		{
			byte[] rdData;

			rdData = ReadBytes(hApi, epc, bank, addr, wordLength * 2);

			return BytesToWords(rdData);
		}

		public static uint[] ReadDwords(NurApi hApi, byte[] epc, byte bank, uint addr, int dwLength)
		{
			byte[] rdData;

			rdData = ReadBytes(hApi, epc, bank, addr, dwLength * 4);

			return BytesToDwords(rdData);
		}
	}
}
