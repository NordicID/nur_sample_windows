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

using NurApiDotNet;

namespace SL900A
{
	public partial class SL900ATag : NurApi.Tag
	{
		private const byte CMD_OPENAREA = 0xAE;

		private void OpenAreaExchange(uint accessPwd, bool secured, PasswordLevel pwdLevel, uint password)
		{
			BitBuffer bb;
			NurApi.CustomExchangeParams xch;
			NurApi.CustomExchangeResponse resp;
			int respLen;

			List<BitEntry> entries = new List<BitEntry>();

			/* Values composed as defined by the SL900A specification. */
			entries.Add(BuildEntry(ADD_PARAMETER, PwdLevelToUint(pwdLevel), PWD_LEVELBITS));
			entries.Add(BuildEntry(ADD_PARAMETER, password, PASSWORDBITS));

			bb = BuildCommand(CMD_OPENAREA, entries);
			/* Zero length; get possible error. */
			xch = BuildDefault(bb, 0, false, false);

			resp = hApi.CustomExchangeSingulated(password, secured, NurApi.BANK_EPC, 32, epc.Length * 8, epc, xch);
			respLen = resp.tagBytes.Length;
			if (resp.error != NurApiErrors.NUR_NO_ERROR)
			{
				if (respLen >= MIN_ERROR_RESP_LENGTH)
					InterpretedException("Open area", resp);
				DoException("Open area", resp);
			}
		}

		/// <summary>
		/// the password level enumeration.
		/// </summary>
		public enum PasswordLevel
		{
			/// <summary>
			/// System area level.
			/// </summary>
			System,
			/// <summary>
			/// Application area level.
			/// </summary>
			Application,
			/// <summary>
			/// Measurement area level.
			/// </summary>
			Measurement
		}

		/// <summary>
		/// Convert a password level enumeration to a 32-bit unsigned integer.
		/// </summary>
		/// <param name="level">Password level as defined by <see cref="PasswordLevel"/>.</param>
		/// <returns>32-bit unsigned integer represeting the password level parameter to the tag.</returns>
		public uint PwdLevelToUint(PasswordLevel level)
		{
			switch (level)
			{
				case PasswordLevel.System: return PWD_LEVEL_SYSTEM;
				case PasswordLevel.Application: return PWD_LEVEL_APP;
				default: break;
			}

			/* Measurement level. */
			return PWD_LEVEL_MEAS;
		}

		/// <summary>
		/// Return password level corresponding to the given 32-bit unsigned integer representation of the level.
		/// </summary>
		/// <param name="level">The password level represented by a 32-bit unsigned integer.</param>
		/// <returns>The password level as defined by <see cref="PasswordLevel"/>.</returns>
		/// <exception cref="ApplicationException">Exception is thrown when the value is less than <see cref="PWD_LEVEL_SYSTEM"/> 
		/// or bigger than <see cref="PWD_LEVEL_MEAS"/>
		/// </exception>
		public PasswordLevel UintToPwdLevel(uint level)
		{
			switch (level)
			{
				case PWD_LEVEL_SYSTEM: return PasswordLevel.System;
				case PWD_LEVEL_APP: return PasswordLevel.Application;
				case PWD_LEVEL_MEAS: return PasswordLevel.Measurement;
				default: break;
			}

			throw 
				new ApplicationException("UintToPwdLevel: invalid value " + level + " for conversion.");
		}

		/// <summary>
		/// Open the system area with the given password.
		/// </summary>
		/// <param name="password">Password used to open the system area.</param>
		/// <exception cref="ApplicationException">Thrown when tag responded with an error or the tag's response length was invalid.</exception>
		/// <exception cref="NurApiException">Exception is thrown when communication error occured with the tag or module.</exception>
		public void OpenSysArea(uint password)
		{
			OpenAreaExchange(0, false, PasswordLevel.System, password);
		}

		/// <summary>
		/// Open the system area with the given password constructed from the lower 16-bit and higher 16-bit part of the password.
		/// </summary>
		/// <param name="pwdLo">Lower 16 bits of the password.</param>
		/// <param name="pwdHi">Higher 16 bits of the password.</param>
		/// <exception cref="ApplicationException">Thrown when tag responded with an error or the tag's response length was invalid.</exception>
		/// <exception cref="NurApiException">Exception is thrown when communication error occured with the tag or module.</exception>
		public void OpenSysArea(ushort pwdLo, ushort pwdHi)
		{			
			uint password;
			password = pwdHi;
			password <<= 16;
			password |= pwdLo;
			OpenAreaExchange(0, false, PasswordLevel.System, password);
		}

		/// <summary>
		/// Open the application area with the given password.
		/// </summary>
		/// <param name="password">Password used to open the system area.</param>
		/// <exception cref="ApplicationException">Thrown when tag responded with an error or the tag's response length was invalid.</exception>
		/// <exception cref="NurApiException">Exception is thrown when communication error occured with the tag or module.</exception>
		public void OpenAppArea(uint password)
		{
			OpenAreaExchange(0, false, PasswordLevel.Application, password);
		}

		/// <summary>
		/// Open the application area with the given password constructed from the lower 16-bit and higher 16-bit part of the password.
		/// </summary>
		/// <param name="pwdLo">Lower 16 bits of the password.</param>
		/// <param name="pwdHi">Higher 16 bits of the password.</param>
		/// <exception cref="ApplicationException">Thrown when tag responded with an error or the tag's response length was invalid.</exception>
		/// <exception cref="NurApiException">Exception is thrown when communication error occured with the tag or module.</exception>
		public void OpenAppArea(ushort pwdHi, ushort pwdLo)
		{
			uint password;
			password = pwdHi;
			password <<= 16;
			password |= pwdLo;
			OpenAreaExchange(0, false, PasswordLevel.Application, password);
		}

		/// <summary>
		/// Open the measurement area with the given password.
		/// </summary>
		/// <param name="password">Password used to open the system area.</param>
		/// <exception cref="ApplicationException">Thrown when tag responded with an error or the tag's response length was invalid.</exception>
		/// <exception cref="NurApiException">Exception is thrown when communication error occured with the tag or module.</exception>
		public void OpenMeasArea(uint password)
		{
			OpenAreaExchange(0, false, PasswordLevel.Measurement, password);
		}

		/// <summary>
		/// Open the measurement area with the given password constructed from the lower 16-bit and higher 16-bit part of the password.
		/// </summary>
		/// <param name="pwdLo">Lower 16 bits of the password.</param>
		/// <param name="pwdHi">Higher 16 bits of the password.</param>
		/// <exception cref="ApplicationException">Thrown when tag responded with an error or the tag's response length was invalid.</exception>
		/// <exception cref="NurApiException">Exception is thrown when communication error occured with the tag or module.</exception>
		public void OpenMeasArea(ushort pwdHi, ushort pwdLo)
		{
			uint password;
			password = pwdHi;
			password <<= 16;
			password |= pwdLo;
			OpenAreaExchange(0, false, PasswordLevel.Measurement, password);
		}
	}
}
