using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections;

namespace Ps.Iso.Viewer
{
	public partial class IsoRecordGrid : UserControl {
	  public bool WasEdited { get; private set; }

    public IsoRecordGrid() {
      InitializeComponent();
      WasEdited = false;
    }

    public IsoRecordGrid(IsoRecord record, List<int> highlightedFields) {
      InitializeComponent();
      Record = record;
      HighlightFields(highlightedFields);
      WasEdited = false;
    }

    public IsoRecord Record {
      get {
        var fields = new List<IsoRecordField>(gridFields.Rows.Count);
        fields.AddRange(from DataGridViewRow row in gridFields.Rows
          select new IsoRecordField((string)row.Cells["colKey"].Value,
            (string)row.Cells["colValue"].Value));
        return new IsoRecord(fields.GetRange(0,fields.Count - 1));
      }
      set {
        if (gridFields == null) return;
        gridFields.Rows.Clear();
        var sortColumn = gridFields.SortedColumn;
        gridFields.AutoGenerateColumns = false;
        var sortDirection = gridFields.SortOrder;
        foreach (var field in value.Fields)
          gridFields.Rows.Add(new[] {field.Name, field.Value});

        if (sortColumn != null && sortDirection != SortOrder.None)
          gridFields.Sort(sortColumn,
            sortDirection == SortOrder.Ascending ?
              ListSortDirection.Ascending : ListSortDirection.Descending);

        WasEdited = false;
      }
    }

		public void HighlightFields(List<int> fieldNumbers)
		{
      if (fieldNumbers == null) return;

		  foreach (
        var fieldNumber in fieldNumbers.
          Where(fieldNumber => fieldNumber < gridFields.Rows.Count)
      ) {
		    gridFields.Rows[fieldNumber].DefaultCellStyle.BackColor
		      = Color.LightSteelBlue;
		  }

      if (fieldNumbers.Count > 0)
        gridFields.FirstDisplayedScrollingRowIndex = fieldNumbers[0];
    }

// ReSharper disable InconsistentNaming
		public bool enableEdit;
// ReSharper restore InconsistentNaming

		public bool EnableEdit
		{
			get { return enableEdit; }
			set
			{
				enableEdit = value;
				gridFields.RowHeadersVisible = enableEdit;
				gridFields.AllowUserToAddRows = enableEdit;
				gridFields.AllowUserToDeleteRows = enableEdit;
			}
		}

		private void IsoRecordGrid_Load(object sender, EventArgs e)
		{
			gridFields.Show();
		}

		private void gridFields_SortCompare(object sender,
			DataGridViewSortCompareEventArgs e)
		{
			// Try to sort based on the cells in the current column.
			e.SortResult = Comparer.Default.Compare(e.CellValue1, e.CellValue2);

			// If the cells are equal, sort based on the colNumber column.
			if (e.SortResult == 0 && e.Column.Name != "colNumber")
			{
				e.SortResult = (int) gridFields.Rows[e.RowIndex1]
							.Cells["colNumber"].Value
					-	(int) gridFields.Rows[e.RowIndex2]
							.Cells["colNumber"].Value;
			}
			e.Handled = true;
		}

    private void gridFields_CellValueChanged(object sender,
      DataGridViewCellEventArgs e) {
      WasEdited = true;
    }
  }
}
