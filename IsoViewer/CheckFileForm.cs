using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Ps.Iso;

namespace Ps.Iso.Viewer
{
	public partial class CheckFileForm : Ps.Win.Controls.ProgressWindow
	{
		private PsIso isoFile;
		public IList<Error> Result;

		public CheckFileForm()
		{
			Init();
		}

		public CheckFileForm(PsIso parIsoFile)
		{
			Init();
			this.isoFile = parIsoFile;
		}

		private void Init()
		{
			InitializeComponent();
			ProcessTitle = "Проверка файла на ошибки";
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

			e.Result = isoFile.CheckFile(worker);
		}

		private void bwWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			Result = e.Result as IList<Error>;
			Close();
		}

		private void CheckFileForm_Shown(object sender, EventArgs e)
		{
			bwWorker.RunWorkerAsync();
		}
	}
}

