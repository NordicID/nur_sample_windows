using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NurApiDotNet;

namespace CAENRT5Test
{
	public partial class AntennaDlg : Form
	{
		NurApi hNur;

		public AntennaDlg(NurApi api)
		{
			InitializeComponent();
			hNur = api;
			SettingsToControls();
			EnableOkApplyBySelections();
		}

		void SettingsToControls()
		{
			uint antennaMaskEx;
			string[] antennaNames;

			antennaMaskEx = hNur.AntennaMaskEx;
			antennaNames = hNur.AvailablePhysicalAntennas.ToArray();
			ListAntennas(antennaNames);
			MaskToSelections(antennaMaskEx);
		}

		void ListAntennas(string []theNames)
		{
			ListViewItem item;
			int number = 1;

			foreach (string antennaName in theNames)
			{
				item = new ListViewItem(new string[] { "", number.ToString(), antennaName });
				AntSelView.Items.Add(item);
			}
		}

		void MaskToSelections(uint antennaMaskEx)
		{
			uint localMask;
			int i;

			localMask = NurApi.ANTENNAMASK_1;
			for (i = 0; i < AntSelView.Items.Count; i++)
			{
				if ((localMask & antennaMaskEx) != 0)
					AntSelView.Items[i].Checked = true;
				localMask <<= 1;
			}
		}

		uint SelectionsToMask()
		{
			uint selectionMask = 0;
			uint localMask = NurApi.ANTENNAMASK_1;

			foreach (ListViewItem antennaItem in AntSelView.Items)
			{
				if (antennaItem.Checked)
					selectionMask |= localMask;
				localMask <<= 1;

			}

			return selectionMask;
		}

		void EnableOkApplyBySelections()
		{
			uint antennaMaskEx = SelectionsToMask();
			OKBtn.Enabled = (antennaMaskEx != 0);
		}

		private void EndDialog(DialogResult dialogResult)
		{
			DialogResult = dialogResult;
			Close();
		}
		
		private void CancelBtn_Click(object sender, EventArgs e)
		{
			EndDialog(DialogResult.Cancel);
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
			uint antennaMaskEx = SelectionsToMask();
			try
			{
				hNur.AntennaMaskEx = antennaMaskEx;
				EndDialog(DialogResult.OK);
			}
			catch (NurApiException ex)
			{
				MessageBox.Show("Error when applying the antenna mask 0x" + antennaMaskEx.ToString("X8") + ":\n" + ex.Message);
			}
		}

		private void SelAllBtn_Click(object sender, EventArgs e)
		{
			bool ok = true;

			if (AntSelView.Items.Count > 4)
			{
				// Area Reader / Multiport.
				string msg = "There are a lot of antennas available; selecting them all may cause the system to be unusable for the purpose.\nContinue anyway?";
				if (MessageBox.Show(msg, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
					ok = false;
			}

			if (ok)
			{
				int i;
				for (i = 0; i < AntSelView.Items.Count; i++)
					AntSelView.Items[i].Checked = true;
			}

			EnableOkApplyBySelections();
		}

		private void AntSelView_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			EnableOkApplyBySelections();
		}

		private void ApplyStoreBtn_Click(object sender, EventArgs e)
		{
			uint antennaMaskEx;

			antennaMaskEx = SelectionsToMask();

			try
			{
				hNur.AntennaMaskEx = antennaMaskEx;
				hNur.StoreCurrentSetup();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Antenna mask apply error:\n" + ex.Message);
			}
		}
	}
}
