using System;
using System.Collections.Generic;
using System.Text;

using NurApiDotNet;

namespace EM4325
{
	public partial class EM4325Tag : NurApi.Tag
	{
		/// <summary>
		/// Write UTC.
		/// </summary>
		/// <param name="utcValue">UTC value as an unsigned 32-bit integer.</param>
		/// <exception cref="NurApiException">Exception is thrown upon tag or reader communication error.</exception>		
		public void SetUTC(uint utcValue)
		{
			byte[] wrData;
			

			wrData = BitConverter.GetBytes(utcValue);
			System.Array.Reverse(wrData);

			if (mSecured)
				BlockWrite(mPassword, NurApi.BANK_USER, ADDR_UTC_MSW, wrData, 2);
			else
				BlockWrite(NurApi.BANK_USER, ADDR_UTC_MSW, wrData, 2);
		}

		/// <summary>
		/// Read UTC.
		/// </summary>
		/// <returns>32-bit unsigned integer representing the UTC value.</returns>
		/// <exception cref="NurApiException">Exception is thrown upon tag or reader communication error.</exception>		
		public uint GetUTC()
		{
			uint utcValue = 0;

			byte[] rdData;

			ResetToA();
			rdData = ReadTag(mPassword, mSecured, NurApi.BANK_USER, ADDR_UTC_MSW, 4);

			System.Array.Reverse(rdData);
			utcValue = BitConverter.ToUInt32(rdData, 0);

			return utcValue;
		}

		/// <summary>
		/// Return the UTC as an unsigned 32-bit integer.
		/// </summary>
		public uint UTC
		{
			get { return GetUTC(); }
			set { SetUTC(value); }
		}
	}
}
