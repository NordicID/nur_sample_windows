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
	/// <summary>
	/// Class to implement progress events.
	/// </summary>
	public class RTProgressEvent : EventArgs
	{
		/// <summary>
		/// If true then override step, <see cref=""/> and reset the progress indicator.
		/// </summary>
		public bool reset;
		
		/// <summary>
		/// If true the perfomr a step on the previously initialized progress indicator.
		/// </summary>
		public bool step;

		/// <summary>
		/// Minimum value of the progress indicator.
		/// </summary>
		public int min;
		
		/// <summary>
		/// Maximum number of steps in the progress indicator.
		/// </summary>
		public int max;

		/// <summary>
		/// Default constructor.
		/// </summary>
		/// <param name="doStep">If true then the progress indicator should perform a step.</param>
		/// <param name="minVal">Minimum value for the progress indicator.</param>
		/// <param name="maxVal">Maximum number of steps for the progress indicator.</param>
		/// <remarks>If both the minimum and maximum are set to -1 then the reset is set to true thus causing the progress indicator to reset to its start value.</remarks>
		public RTProgressEvent(bool doStep, int minVal, int maxVal)
		{
			step = doStep;
			min = minVal;
			max = maxVal;
			if (min == -1 && max == -1)
				reset = true;
			else
				reset = false;
		}

	}
}
