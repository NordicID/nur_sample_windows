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

namespace CAENRT0005
{
    public class BINSAMPLETIME : BINARRAY
    {
		/// <summary>
		/// Constructor that uses the RT0005Tag.
		/// </summary>
		/// <param name="tag">RT0005 tag being used.</param>
		/// <remarks>This constructor is used within the RT0005Tag class. There should not be a need to use this elsewhere.</remarks>
		public BINSAMPLETIME(RT0005Tag tag)
            : base(tag)
        {
            mBaseAddress = RTRegs.BIN_SAMPLETIME_BASE;
			mExceptionMsg = "BIN: invalid sample time index.";
        }

		/// <summary>
		/// Indexing of the BIN sample times.
		/// </summary>
		/// <param name="index">Index is 0...15, <seealso cref="RTConst.LAST_BIN"/>.</param>
		/// <returns>The register value at given index.</returns>
		/// <remarks><para><seealso cref="RTConst.NR_BINS"/></para></remarks>
		/// <remarks><para><seealso cref="RTConst.LAST_BIN"/></para></remarks>
		/// <exception cref="IndexOutOfRangeException">Exception is thrown when the index is out of range as in usual array indexing.</exception>
		/// <exception cref="NurApiException">Exception is thrown when the underlying physical operation (read or write) fails.</exception>        
		public ushort this[int index]
        {            
            get
            {
                return WordRead(index);				
            }
            set            
            {
                WordWrite(index, value);
            }
        }
    }
}
