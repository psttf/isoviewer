using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Ps.Iso.Viewer {
  public class ContentDataGridView : DataGridView {
    public IEnumerable<DataGridViewRow> ContentRows {
      get
      {
        if (!AllowUserToAddRows) return Rows.OfType<DataGridViewRow>();
        return Rows.OfType<DataGridViewRow>().
          Where(row => row != Rows[Rows.Count - 1]);
      }
    }
  }
}
