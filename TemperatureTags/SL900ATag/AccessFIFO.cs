using System;
using System.Collections.Generic;
using System.Text;

using NurApiDotNet;

namespace SL900A
{
	public partial class SL900ATag : NurApi.Tag
	{
		private const byte CMD_ACCESSFIFO = 0xAF;
		private const int SUBCMD_BITS = 8;

		private const uint SUBCMD_READ = (1 << 7);
		private const uint SUBCMD_WRITE = (5 << 5);
		private const uint SUBCMD_STATUS = (6 << 5);

		private const int REG_FIFOBUSY_BIT = 7;
		private const int REG_DATAREADY_BIT = 6;
		private const int REG_NODATA_BIT = 5;
		private const int REG_RFIDDATA_BIT = 4;

		private const int FIFO_COUNT_BITS = 4;
		private const uint FIFO_COUNT_MASK_VAL = ((1 << FIFO_COUNT_BITS) - 1);

		private const int MIN_FIFO_BYTES = 1;
		private const int MAX_FIFO_BYTES = 8;
		
		private object AccessFIFOExchange(uint password, bool secured, uint subCommand, uint byteCount, byte []wrData)
		{
			List<BitEntry> entries = new List<BitEntry>();

			NurApi.CustomExchangeParams xch;
			NurApi.CustomExchangeResponse resp;
			int respLen;
			uint tmpVal;

			BitBuffer bb;

			if (subCommand == SUBCMD_READ)
			{
				tmpVal = subCommand | (byteCount & FIFO_COUNT_MASK_VAL);
				entries.Add(BuildEntry(ADD_PARAMETER, tmpVal, 8));
			}
			else if (subCommand == SUBCMD_WRITE)
			{
				tmpVal = subCommand | (uint)(((wrData.Length & FIFO_COUNT_MASK_VAL)));
				entries.Add(BuildEntry(ADD_PARAMETER, tmpVal, 8));				
				foreach (byte dataByte in wrData)
					entries.Add(BuildEntry(ADD_PARAMETER, dataByte, 8));
			}
			else
			{
				entries.Add(BuildEntry(ADD_PARAMETER, SUBCMD_STATUS, 8));
			}

			bb = BuildCommand(CMD_ACCESSFIFO, entries);

			/* No length, ready to receive possible error. */
			xch = BuildDefault(bb, 0, false, false);

			resp = hApi.CustomExchangeSingulated(password, secured, NurApi.BANK_EPC, 32, epc.Length * 8, epc, xch);
			respLen = resp.tagBytes.Length;

			if (resp.error != NurApiErrors.NUR_NO_ERROR)
			{
				if (respLen >= MIN_ERROR_RESP_LENGTH)
					InterpretedException("Access FIFO", resp);
				DoException("Access FIFO", resp);
			}

			if (subCommand == SUBCMD_READ)
			{
				byte[] retBytes = new byte[respLen];
				System.Array.Copy(resp.tagBytes, retBytes, respLen);
				return retBytes;
			}
			else if (subCommand == SUBCMD_WRITE)
				return wrData.Length;
			
			/* FIFO status. */
			FIFOStatusReg status = new FIFOStatusReg();
			tmpVal = resp.tagBytes[0];
			status.busy = IsMaskBitSet(tmpVal, REG_FIFOBUSY_BIT);
			status.byteCount = tmpVal & FIFO_COUNT_MASK_VAL;
			status.dataReady = IsMaskBitSet(tmpVal, REG_DATAREADY_BIT);
			status.fromRFID = IsMaskBitSet(tmpVal, REG_RFIDDATA_BIT);
			status.noData = IsMaskBitSet(tmpVal, REG_NODATA_BIT);

			return status;
		}

		private void VerifyLength(string pref, int byteCount)
		{
			if (byteCount < MIN_FIFO_BYTES || byteCount > MAX_FIFO_BYTES)
				throw new ApplicationException(pref + ", invalid length: " + byteCount + " (" + MIN_FIFO_BYTES + "..." + MAX_FIFO_BYTES + ").");
		}

		/// <summary>
		/// FIFO register attribute.
		/// </summary>
		/// <exception cref="NurApiException">Exception is thrown when communication error occured with the tag or module.</exception>
		/// <exception cref="ApplicationException">Exception is thrown if tag responded with an error.</exception>
		/// <remarks>
		/// <see cref="FIFOStatusReg"/>
		/// </remarks>
		public FIFOStatusReg FIFOStatus
		{
			get
			{
				return (FIFOStatusReg)AccessFIFOExchange(0, false, SUBCMD_STATUS, 0, null);
			}
		}

		/// <summary>
		/// Read number of bytes from FIFO.
		/// The allowed byte count is 1...8.
		/// </summary>
		/// <param name="byteCount"></param>
		/// <returns>When successful, the return value is a byte array representing the read FIFO data.</returns>
		/// <exception cref="NurApiException">Exception is thrown when communication error occured with the tag or module.</exception>
		/// <exception cref="ApplicationException">Exception is thrown if tag responded with an error or the length was invalid.</exception>
		public byte[] ReadFIFO(int byteCount)
		{
			VerifyLength("ReadFIFO", byteCount);

			return (byte[])AccessFIFOExchange(0, false, SUBCMD_READ, (uint)byteCount, null);
		}

		/// <summary>
		/// Write number of bytes to FIFO
		/// The allowed byte count is 1...8.
		/// </summary>
		/// <param name="wrData">Data to write.</param>
		/// <returns>When successful, the return value is the length of the written byte array.</returns>
		/// <exception cref="NullReferenceException">Exception is thrown if the <paramref name="wrData"/> is null.</exception>
		/// <exception cref="NurApiException">Exception is thrown when communication error occured with the tag or module.</exception>
		/// <exception cref="ApplicationException">Exception is thrown if tag responded with an error or the length was invalid.</exception>
		public int WriteFIFO(byte[] wrData)
		{
			if (wrData == null)
				throw new NullReferenceException("WriteFIFO: parameter is null.");
			
			VerifyLength("WriteFIFO", wrData.Length);

			return (int)AccessFIFOExchange(0, false, SUBCMD_WRITE, 0, wrData);
		}
	}
}
