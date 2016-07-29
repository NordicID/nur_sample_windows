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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace CAENRT5Test
{
	public partial class MainForm : Form
	{
		private bool mAsyncUpdate = false;

		private Color RED = Color.Red;
		private Color YELLOW = Color.Yellow;
		private Color GREEN = Color.Green;
		private Color BLACK = Color.Black;
		private Color CTLCOLOR = SystemColors.Control;

		/* Green; OK. */
		private const int STATE_OK = 0;
		/* Yellow; running/ongoing/waiting. */
		private const int STATE_RUN = 1;
		/* Red; not available/error. */
		private const int STATE_NA = 2;

		public delegate void ControlTextDelegate(Control ctl, string s);
		public delegate void ControlColorDelegate(Control ctl, Color back, Color front);
		public delegate void ControlEnableDelegate(Control c, bool en);
		
		public delegate void ControlStateDelegate(Control ctl, int state, string s);

		public delegate void ProgressInitDelegate(ProgressBar pb, int min, int max, int step);
		public delegate void ProgressStepDelegate(ProgressBar pb);

		private ControlTextDelegate mSetControlText;
		private ControlColorDelegate mSetControlColor;
		private ControlEnableDelegate mControlEnable;

		private ControlStateDelegate mControlState;

		private ProgressInitDelegate mProgInit;
		private ProgressStepDelegate mProgStep;

		void _ControlState(Control ctl, int state, string s)
		{
			Color c = RED;
			
			if (state == STATE_OK)
				c = GREEN;
			else if (state == STATE_RUN)
				c = YELLOW;

			ctl.BackColor = c;
			ctl.ForeColor = BLACK;
			if (s != "")
				ctl.Text = s;
		}

		void _ControlEnable(Control ctl, bool en)
		{
			ctl.Enabled = en;
		}

		void _ControlText(Control ctl, string s)
		{
			ctl.Text = s;
		}

		void _SetControlText(Control ctl, string s)
		{
			ctl.Text = s;
		}

		void _SetControlColor(Control ctl, Color back, Color front)
		{
			ctl.BackColor = back;
			ctl.ForeColor = front;
		}

		void _ProgressInit(ProgressBar pb, int min, int max, int step)
		{
			pb.Value = 0;
			pb.Minimum = min;
			pb.Maximum = max;
			pb.Step = step;
		}

		void _ProgressStep(ProgressBar pb)
		{
			pb.PerformStep();
		}

		public void SetControlText(Control ctl, string s)
		{
			if (mAsyncUpdate)
				BeginInvoke(mSetControlText, ctl, s);
			else
				Invoke(mSetControlText, ctl, s);
		}

		public void SetControlColor(Control ctl, Color back, Color front)
		{
			if (mAsyncUpdate)
				BeginInvoke(mSetControlColor, ctl, back, front);
			else
				Invoke(mSetControlColor, ctl, back, front);
		}

		public void ControlEnable(Control ctl, bool en)
		{
			if (mAsyncUpdate)
				BeginInvoke(mControlEnable, ctl, en);
			else
				Invoke(mControlEnable, ctl, en);
		}

		public void ControlText(Control ctl, string s)
		{
			if (mAsyncUpdate)
				BeginInvoke(mSetControlText, ctl, s);
			else
				Invoke(mSetControlText, ctl, s);
		}

		public void ControlState(Control ctl, int state, string s)
		{
			if (mAsyncUpdate)
				BeginInvoke(mControlState, ctl, state, s);
			else
				Invoke(mControlState, ctl, state, s);
		}

		void ProgressInit(ProgressBar pb, int min, int max, int step)
		{
			if (mAsyncUpdate)
				BeginInvoke(mProgInit, pb, min, max, step);
			else
				Invoke(mProgInit, pb, min, max, step);
		}

		void ProgressStep(ProgressBar pb)
		{
			if (mAsyncUpdate)
				BeginInvoke(mProgStep, pb);
			else
				Invoke(mProgStep, pb);
		}

		private void CreateInvokers()
		{
			mSetControlText = new ControlTextDelegate(_SetControlText);
			mSetControlColor = new ControlColorDelegate(_SetControlColor);
			mControlEnable = new ControlEnableDelegate(_ControlEnable);
			mControlState = new ControlStateDelegate(_ControlState);

			mProgInit = new ProgressInitDelegate(_ProgressInit);
			mProgStep = new ProgressStepDelegate(_ProgressStep);
		}
	}
}
