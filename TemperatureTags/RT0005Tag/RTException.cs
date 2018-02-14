using System;
using System.Collections.Generic;
using System.Text;

namespace CAENRT0005
{
	public class RTException : Exception
	{
		public RTException(string msg)
			: base(msg)
		{
		}
	}
}
