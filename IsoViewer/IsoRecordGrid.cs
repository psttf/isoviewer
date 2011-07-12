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
	  public bool WasEdited { get; set; }

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
        fields.AddRange(
          from DataGridViewRow row in gridFields.ContentRows
          orderby GetFieldIndex(row)
          select new IsoRecordField((string)row.Cells[ColKeyId].Value,
            (string)row.Cells["colValue"].Value)
        );
        return new IsoRecord(fields);
      }
      set {
        if (gridFields == null) return;
        gridFields.Rows.Clear();
        var sortColumn = gridFields.SortedColumn;
        gridFields.AutoGenerateColumns = false;
        var sortDirection = gridFields.SortOrder;
        for (var i = 0; i < value.Fields.Count; i++) {
          var field = value.Fields[i];
          gridFields.Rows.Add(new object[] {i+1, field.Name, field.Value});
        }

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

		private bool _enableEdit;
	  private const string ColKeyId = "colKey";
	  public const string ColNumberId = "colNumber";

		public bool EnableEdit
		{
			get { return _enableEdit; }
			set
			{
				_enableEdit = value;
				gridFields.RowHeadersVisible = _enableEdit;
				gridFields.AllowUserToAddRows = _enableEdit;
				gridFields.AllowUserToDeleteRows = _enableEdit;
			}
		}

		private void IsoRecordGrid_Load(object sender, EventArgs e)
		{
			gridFields.Show();
		}

		private void gridFields_SortCompare(
      object sender,
			DataGridViewSortCompareEventArgs e
    ) {
			// Try to sort based on the cells in the current column.
			e.SortResult = Comparer.Default.Compare(e.CellValue1, e.CellValue2);

			// If the cells are equal, sort based on the colNumber column.
			if (e.SortResult == 0 && e.Column.Name != ColNumberId)
			{
				e.SortResult = GetFieldIndex(gridFields.Rows[e.RowIndex1])
          - GetFieldIndex(gridFields.Rows[e.RowIndex2]);
			}
			e.Handled = true;
		}

    private void gridFields_CellValueChanged(
      object sender,
      DataGridViewCellEventArgs e
    ) {
      if (e.ColumnIndex == colKey.Index || e.ColumnIndex == colValue.Index)
        WasEdited = true;
    }

    private void gridFields_DefaultValuesNeeded(
      object sender,
      DataGridViewRowEventArgs e
    ) {
      SetFieldIndex(e.Row, gridFields.ContentRows.Count() + 1);
    }

    private void gridFields_UserDeletedRow(
      object sender,
      DataGridViewRowEventArgs e
    ) {
      var deletedIndex = GetFieldIndex(e.Row);
      foreach (var row in
        gridFields.Rows.Cast<DataGridViewRow>().
        Where(row =>
          row != gridFields.ContentRows &&
            GetFieldIndex(row) > deletedIndex
        )
      ) {
        SetFieldIndex(row, GetFieldIndex(row) - 1);
      }
    }

// ReSharper disable PossibleNullReferenceException
	  int ColNumberIndex { get { return gridFields.Columns[ColNumberId].Index; } }
// ReSharper restore PossibleNullReferenceException

    public int GetFieldIndex(DataGridViewRow r) {
      return (int)r.Cells[ColNumberIndex].Value;
    }

    public void SetFieldIndex(DataGridViewRow r, int value) {
      r.Cells[ColNumberIndex].Value = value;
    }

    internal void EditNewRecord() { BeginEditKey(gridFields.Rows[0]); }

	  internal void EditFieldKey(int index) {
      BeginEditKey(gridFields.Rows.OfType<DataGridViewRow>().
        First(r => GetFieldIndex(r) == index));
    }

    private void BeginEditKey(DataGridViewRow row) {
      gridFields.CurrentCell = row.Cells[ColKeyId];
      gridFields.BeginEdit(true);
      WasEdited = true;
    }

    public void MarkFieldKey(
      int fieldIndex, IsoRecordValidationErrorType errorType
    ) {
      for (var i=0; i<gridFields.ContentRows.Count(); i++) {
        var row = gridFields.ContentRows.ElementAt(i);
        if (GetFieldIndex(row) == fieldIndex)
          MarkKeyCell(i,errorType);
      }
	  }

    private void gridFields_CellValidating(
      object sender, DataGridViewCellValidatingEventArgs e
    ) {
      var column = gridFields.Columns[e.ColumnIndex];
      if (column.Name != ColKeyId) return;
      var errorType = IsoRecord.ValidateFieldName((string) e.FormattedValue);
      if (!errorType.HasValue)
        gridFields.Rows[e.RowIndex].Cells[ColKeyId].ErrorText = null;
      if (errorType != null) MarkKeyCell(e.RowIndex, errorType.Value);
    }

    private void MarkKeyCell(
      int rowIndex, IsoRecordValidationErrorType errorType
    ) {
      string message;
      switch (errorType) {
        case IsoRecordValidationErrorType.EmptyFieldName:
          message = "Название поля не должно быть пустым";
          break;
        case IsoRecordValidationErrorType.WrongFieldName:
          message = "Название поля должно состоять из трех цифр";
          break;
        default:
          message = "Неверный формат имени поля";
          break;
      }
      gridFields.Rows[rowIndex].Cells[ColKeyId].ErrorText = message;
    }

    private void gridFields_CellClick(
      object sender, DataGridViewCellEventArgs e
    ) {
      // Ignore clicks that are not on button cells. 
      if (e.RowIndex < 0 || e.ColumnIndex != colExpand.Index) return;
      var cell = gridFields[colValue.Name, e.RowIndex];
      var dlg = new EditValueDialog((string) cell.Value) {Font = Font};
      if (dlg.ShowDialog() == DialogResult.OK) cell.Value = dlg.Value;
    }

    private void gridFields_CellMouseEnter(
      object sender, DataGridViewCellEventArgs e
    ) {
      if (e.RowIndex < 0 || e.ColumnIndex != colExpand.Index) return;
      gridFields[colExpand.Index, e.RowIndex] =
        new DataGridViewButtonCell { Value = "+" };
    }

    private void gridFields_CellMouseLeave(object sender, DataGridViewCellEventArgs e) {
      if (e.RowIndex < 0 || e.ColumnIndex != colExpand.Index) return;
      gridFields[colExpand.Index, e.RowIndex] =
        new DataGridViewTextBoxCell();
    }
	}
}
