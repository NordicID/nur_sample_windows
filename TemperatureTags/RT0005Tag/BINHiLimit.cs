using System;
using System.Collections.Generic;
using System.Text;

/* Import of the NurApi. */
using NurApiDotNet;

namespace CAENRT0005
{
    public class BINHLIMIT : BINARRAY
    {
		/// <summary>
		/// Constructor that uses the RT0005Tag.
		/// </summary>
		/// <param name="tag">RT0005 tag being used.</param>
		/// <remarks>This constructor is used within the RT0005Tag class. There should not be a need to use this elsewhere.</remarks>
		public BINHLIMIT(RT0005Tag tag) 
            : base(tag)
        {
            mBaseAddress = RTRegs.BIN_HLIMIT_BASE;
			mExceptionMsg = "BIN: invalid high level index.";
        }

		/// <summary>
		/// Indexing of the BIN high limits.
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
