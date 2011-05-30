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
          "���������� �����");
      gsd.ShowDialog();

      if (scheme.Count > 0) {
        foreach (var field in scheme) {
          var strIsMultivalued = "���";
          if (field.IsMultiValued) {
            strIsMultivalued = "��";
          }
          dgvFields.Rows.Add(new object[] {field.Name,
							strIsMultivalued,
							field.Size});
        }
      } else {
        dgvFields.Rows.Add(new[] {"",
					"���� ���� ��� �� �������� ���������� �������"});
      }
    }

    private void dgvFields_CellDoubleClick(
      object sender, DataGridViewCellEventArgs e
    ) {
      if (e.ColumnIndex < 0 || e.RowIndex < 0 ||
        ((string)dgvFields.Rows[e.RowIndex].Cells[1].Value) != "��") return;
      var strRecNums = _isoFile.Records.Multivalued(
        (string)dgvFields.Rows[e.RowIndex].Cells[0].Value).
          Aggregate("", (s, i) => s + ", " + i);
      new TextBoxMessageBox(
        "������ ���� �������� ������������ � ��������� �������: " + strRecNums
      ).Show();
    }

    private void btnClose_Click(object sender, EventArgs e) {
      Close();
    }

  }
}