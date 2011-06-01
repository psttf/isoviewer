using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Ps.Iso.Viewer {
  /// <summary>
  /// display a datagrid with row numbers
  /// </summary>
  public class NumberedDataGridView : DataGridView {
    /// <summary>
    /// draw the row number on the header cell, auto adjust the column width
    /// to fit the row number
    /// </summary>
    /// <param name="e"></param>
    protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e) {
      base.OnRowPostPaint(e);

      // get the row number in leading zero format, 
      //  where the width of the number = the width of the maximum number
      var rowNumWidth = RowCount.ToString().Length;
      var rowNumber = new StringBuilder(rowNumWidth);
      rowNumber.Append(e.RowIndex + 1);
      while (rowNumber.Length < rowNumWidth)
        rowNumber.Insert(0, "0");

      // get the size of the row number string
      var sz = e.Graphics.MeasureString(rowNumber.ToString(), Font);

      // adjust the width of the column that contains the row header cells 
      if (RowHeadersWidth < (int)(sz.Width + 20))
        RowHeadersWidth = (int)(sz.Width + 20);

      // draw the row number
      e.Graphics.DrawString(
          rowNumber.ToString(),
          Font,
          SystemBrushes.ControlText,
          e.RowBounds.Location.X + 15,
          e.RowBounds.Location.Y + ((e.RowBounds.Height - sz.Height) / 2));
    }

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
