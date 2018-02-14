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
