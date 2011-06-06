using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Ps.Iso.Viewer
{
	public partial class ErrorsListDialog : Form
	{
	  private readonly IList<Error> _errors;
	  private readonly IsoFileForm _isoFileForm;

		public ErrorsListDialog(IList<Error> errors, IsoFileForm isoFileForm)
		{
			InitializeComponent();

			if (errors.Count > 0)
			{
				foreach (var error in errors)
				{
					dgvErrors.Rows.Add(new[] {(error.RecordNumber+1).ToString(),
							error.Message});
				}
			}
			else
			{
				dgvErrors.Rows.Add(new[] {"",
					"Ошибок не обнаружено"});
			}
		  _errors = errors;
		  _isoFileForm = isoFileForm;
		}

    private void _btSaveAllExceptInvalid_Click(object sender, EventArgs e) {
      var dlg = new SaveIsoDialog(_isoFileForm);
      dlg.SetSaveExcept(_errors.Select(error => error.RecordNumber));
      dlg.ShowDialog();
      Close();
    }

	}
}