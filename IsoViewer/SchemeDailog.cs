using System;
using System.Linq;
using System.Windows.Forms;

namespace Ps.Iso.Viewer {
  public partial class SchemeDailog : Form {
    private readonly IsoFile _isoFile;

    public SchemeDailog() {
      InitializeComponent();
    }

    public SchemeDailog(IsoFile isoFile) {
      InitializeComponent();

      _isoFile = isoFile;

      IsoFileScheme scheme = null;
      var gsd = new TaskProcessWindow(a => scheme = isoFile.GetScheme(a),
          "Вычисление схемы");
      gsd.ShowDialog();

      if (scheme.Count > 0) {
        foreach (var field in scheme) {
          var strIsMultivalued = "нет";
          if (field.IsMultiValued) {
            strIsMultivalued = "да";
          }
          dgvFields.Rows.Add(new object[] {field.Name,
							strIsMultivalued,
							field.Size});
        }
      } else {
        dgvFields.Rows.Add(new[] {"",
					"Файл пуст или не содержит корректных записей"});
      }
    }

    private void dgvFields_CellDoubleClick(
      object sender, DataGridViewCellEventArgs e
    ) {
      if (e.ColumnIndex < 0 || e.RowIndex < 0 ||
        ((string)dgvFields.Rows[e.RowIndex].Cells[1].Value) != "да") return;
      var strRecNums = _isoFile.Records.Multivalued(
        (string)dgvFields.Rows[e.RowIndex].Cells[0].Value).
          Aggregate("", (s, i) => s + ", " + i);
      new TextBoxMessageBox(
        "Данное поле является многозначным в следующих записях: " + strRecNums
      ).Show();
    }

    private void btnClose_Click(object sender, EventArgs e) {
      Close();
    }

  }
}