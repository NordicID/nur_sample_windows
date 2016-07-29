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
    public partial class BINARRAY
    {
        private RT0005Tag mTag;
        protected uint mBaseAddress = 0;
		protected string mExceptionMsg = "";

		/// <summary>
		/// Basic constructor.
		/// </summary>
		/// <param name="tag">"this" i.e RT0005Tag given as a parameter; uses the register reads and writes.</param>
		public BINARRAY(RT0005Tag tag)
        {
            mTag = tag;
        }

        protected void RangeCheck(int index)
        {
            if (index < 0 || index > RTConst.LAST_BIN)
				throw new IndexOutOfRangeException(mExceptionMsg);
        }

        protected void WordWrite(int index, ushort wordValue)
        {		
            RangeCheck(index);
			mTag.WriteShortReg((uint)(mBaseAddress + index), wordValue);
        }

        protected ushort WordRead(int index)
        {
            RangeCheck(index);
			return mTag.ReadShortReg((uint)(mBaseAddress + index));
        }
    }
}
