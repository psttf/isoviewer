using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ps.Iso.Viewer
{
	public partial class ErrorsListDialog : Form
	{
		public ErrorsListDialog(IList<Error> errors)
		{
			InitializeComponent();

			if (errors.Count > 0)
			{
				foreach (Error error in errors)
				{
					dgvErrors.Rows.Add(new string[] {error.RecordNumber.ToString(),
							error.Message});
				}
			}
			else
			{
				dgvErrors.Rows.Add(new string[] {"",
					"Ошибок не обнаружено"});
			}
		}

	}
}