using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections;
using Ps.Iso.Viewer.Properties;

namespace Ps.Iso.Viewer
{
	public partial class IsoRecordGrid : UserControl {
	  public bool WasEdited { get; set; }

    public IsoRecordGrid() {
      InitializeComponent();
      Init();
    }

	  public IsoRecordGrid(IsoRecord record, List<int> highlightedFields) {
      InitializeComponent();
      Record = record;
      HighlightFields(highlightedFields);
      Init();
    }

    private void Init() {
      var columnName = Settings.Default.gridFields_SortedColumn_Name;
      var col = gridFields.Columns[columnName];
      if (col == null)
        throw new Exception(string.Format("Cannot sort on column '{0}' (taken" +
          " from app settings): such a column does not exist", columnName));
      gridFields.Sort(col, Settings.Default.gridFields_SortDirection);
      WasEdited = false;
    }

    public IsoRecord Record {
      get {
        var fields = new List<IsoRecordField>(gridFields.Rows.Count);
        fields.AddRange(
          from DataGridViewRow row in gridFields.ContentRows
          orderby GetFieldIndex(row)
          select new IsoRecordField((string)row.Cells[colKey.Index].Value,
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

		  var rowsToHighlight = gridFields.ContentRows.
        Where(row => fieldNumbers.Contains(GetFieldIndex(row)));
		  foreach (var row in rowsToHighlight)
		    row.DefaultCellStyle.BackColor = Color.LightSteelBlue;

      if (rowsToHighlight.Count() > 0)
        gridFields.FirstDisplayedScrollingRowIndex =
          rowsToHighlight.First().Index;
    }

		private bool _enableEdit;

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
			if (e.SortResult == 0 && e.Column != colNumber)
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
      SetFieldIndex(e.Row, gridFields.ContentRows.Count());
    }

    private void gridFields_UserDeletedRow(
      object sender,
      DataGridViewRowEventArgs e
    ) {
      var deletedIndex = GetFieldIndex(e.Row);
      foreach (var row in
        gridFields.Rows.Cast<DataGridViewRow>().
          Where(row =>
            row.Cells[ColNumberIndex].Value != null &&
              GetFieldIndex(row) > deletedIndex
          )
      ) {
        SetFieldIndex(row, GetFieldIndex(row) - 1);
      }
      WasEdited = true;
    }

// ReSharper disable PossibleNullReferenceException
	  int ColNumberIndex { get { return colNumber.Index; } }
// ReSharper restore PossibleNullReferenceException

    public int GetFieldIndex(DataGridViewRow r) {
      return (int)r.Cells[ColNumberIndex].Value - 1;
    }

    public void SetFieldIndex(DataGridViewRow r, int value) {
      r.Cells[ColNumberIndex].Value = value + 1;
    }

    internal void EditNewRecord() { BeginEditKey(gridFields.Rows[0]); }

	  internal void EditFieldKey(int index) {
      BeginEditKey(gridFields.Rows.OfType<DataGridViewRow>().
        First(r => GetFieldIndex(r) == index));
    }

    private void BeginEditKey(DataGridViewRow row) {
      gridFields.CurrentCell = row.Cells[colKey.Index];
      gridFields.BeginEdit(true);

      // иначе при создании новой записи она не считаетс€ отредактированной
      // и ее можно оставить пустой
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
      if (column != colKey) return;
      var errorType = IsoRecord.ValidateFieldName((string) e.FormattedValue);
      if (!errorType.HasValue)
        gridFields.Rows[e.RowIndex].Cells[colKey.Index].ErrorText = null;
      if (errorType != null) MarkKeyCell(e.RowIndex, errorType.Value);
    }

    private void MarkKeyCell(
      int rowIndex, IsoRecordValidationErrorType errorType
    ) {
      string message;
      switch (errorType) {
        case IsoRecordValidationErrorType.EmptyFieldName:
          message = "Ќазвание пол€ не должно быть пустым";
          break;
        case IsoRecordValidationErrorType.WrongFieldName:
          message = "Ќазвание пол€ должно состо€ть из трех цифр";
          break;
        default:
          message = "Ќеверный формат имени пол€";
          break;
      }
      gridFields.Rows[rowIndex].Cells[colKey.Index].ErrorText = message;
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
      if (NotExpandableCell(e)) return;
      gridFields[colExpand.Index, e.RowIndex] =
        new DataGridViewButtonCell { Value = "+" };
    }

	  private void gridFields_CellMouseLeave(
      object sender, DataGridViewCellEventArgs e
    ) {
      if (NotExpandableCell(e)) return;
      gridFields[colExpand.Index, e.RowIndex] =
        new DataGridViewTextBoxCell();
    }

    private bool NotExpandableCell(DataGridViewCellEventArgs e) {
      return e.RowIndex < 0 || e.ColumnIndex == colNumber.Index ||
             e.ColumnIndex == colKey.Index;
    }
  }
}
