using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Ps.Iso.Viewer
{
	public partial class IsoRecordGrid : UserControl
	{
		private List<string[]> fields = new List<string[]>();

		public List<string[]> Fields
		{
			get
			{
				if (gridFields != null && gridFields.Rows != null)
				{
					fields = new List<string[]>(gridFields.Rows.Count);
					for (int i = 0; i < gridFields.Rows.Count; i++)
					{
						fields.Add(new string[] {
							(string) gridFields.Rows[i].Cells["colKey"].Value,
							(string) gridFields.Rows[i].Cells["colValue"].Value});
					}
				}
				return fields;
			}
			set
			{
				fields = value;
			}
		}

		private List<int> highlightedFields = new List<int>();

		public List<int> HighlightedFields
		{
			set
			{
        highlightedFields = new List<int>();
        if (value != null) 
			    foreach (var x in value)
			    {
			      if (x < fields.Count) highlightedFields.Add(x);
			    }
			}
		}

		public bool enableEdit;

		public bool EnableEdit
		{
			get { return enableEdit; }
			set
			{
				enableEdit = value;
				gridFields.RowHeadersVisible = enableEdit;
				gridFields.Columns["colNumber"].Visible = !enableEdit;
				gridFields.AllowUserToAddRows = enableEdit;
				gridFields.AllowUserToDeleteRows = enableEdit;
			}
		}

		public IsoRecordGrid()
		{
			InitializeComponent();
		}

		public IsoRecordGrid(List<string[]> fields, List<int> highlightedFields)
		{
			InitializeComponent();
			this.fields = fields;
			this.highlightedFields = highlightedFields;
		}

		private void IsoRecordGrid_Load(object sender, EventArgs e)
		{
			FillGrid();
			gridFields.Show();
		}

		public void FillGrid()
		{
			if (gridFields != null && gridFields.Rows != null)
			{
				DataGridViewColumn sortColumn = gridFields.SortedColumn;
				SortOrder sortDirection = gridFields.SortOrder;
				gridFields.Rows.Clear();
				if (fields != null)
				{
					for (int i = 0; i < fields.Count; i++)
					{
						int newRowIndex = gridFields.Rows.Add(
							new object[] { i, fields[i][0], fields[i][1] });
						if (highlightedFields != null && highlightedFields.Contains(i))
						{
							gridFields.Rows[newRowIndex].DefaultCellStyle.BackColor
								= Color.LightSteelBlue;
						}
					}
					gridFields.ReadOnly = !enableEdit;
					if (highlightedFields != null && highlightedFields.Count > 0)
					{
					  gridFields.FirstDisplayedScrollingRowIndex = highlightedFields[0];
					}
				}

				if (sortColumn != null && sortDirection != SortOrder.None)
				{
					if (sortDirection == SortOrder.Ascending)
					{
						gridFields.Sort(sortColumn, ListSortDirection.Ascending);
					}
					else
					{
						gridFields.Sort(sortColumn, ListSortDirection.Descending);
					}
				}
			}
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

	}
}
