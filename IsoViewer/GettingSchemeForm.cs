using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ps.Iso.Viewer
{
	public partial class GettingSchemeForm : Ps.Win.Controls.ProgressWindow
	{
		private PsIso isoFile;
		public IsoFileScheme Result;

		public GettingSchemeForm()
		{
			Init();
		}

		public GettingSchemeForm(PsIso parIsoFile)
		{
			Init();
			this.isoFile = parIsoFile;
		}

		private void Init()
		{
			InitializeComponent();
			ProcessTitle = "Вычисление схемы";
			this.bwWorker.DoWork +=
				new System.ComponentModel.DoWorkEventHandler(
					this.bwWorker_DoWork);
			this.bwWorker.RunWorkerCompleted +=
				new System.ComponentModel.RunWorkerCompletedEventHandler(
					this.bwWorker_RunWorkerCompleted);
		}

		private void bwWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker worker;
			worker = (BackgroundWorker) sender;

			e.Result = isoFile.GetScheme(worker);
		}

		private void bwWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			Result = e.Result as IsoFileScheme;
			Close();
		}

		private void CheckFileForm_Shown(object sender, EventArgs e)
		{
			bwWorker.RunWorkerAsync();
		}
	}
}

