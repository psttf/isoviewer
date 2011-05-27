using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ps.Iso.Viewer
{
	public partial class SchemeDailog : Form
	{
		private PsIso isoFile;
		
		public SchemeDailog()
		{
			InitializeComponent();
		}

		public SchemeDailog(PsIso isoFile)
		{
			InitializeComponent();

			this.isoFile = isoFile;

      IsoFileScheme scheme;
      TaskProcessWindow gsd =
        new TaskProcessWindow(a => scheme = isoFile.GetScheme(a),
          "Вычисление схемы");
			gsd.ShowDialog();

			if (scheme.Count > 0)
			{
				foreach (IsoFileField field in scheme)
				{
					string strIsMultivalued = "нет";
					if (field.IsMultiValued)
					{
						strIsMultivalued = "да";
					}
					dgvFields.Rows.Add(new object[] {field.Name,
							strIsMultivalued,
							field.Size});
				}
			}
			else
			{
				dgvFields.Rows.Add(new string[] {"",
					"Файл пуст или не содержит корректных записей"});
			}
		}

		private void dgvFields_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex >= 0 && e.RowIndex >= 0
				&& ((string) dgvFields.Rows[e.RowIndex].Cells[1].Value) == "да")
			{
				string strRecNums =	isoFile.GetMultivaluedRecordsString(
						(string) dgvFields.Rows[e.RowIndex].Cells[0].Value);
				new TextBoxMessageBox("Данное поле является многозначным в следующих записях: "
					+ strRecNums).Show();
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

	}
}