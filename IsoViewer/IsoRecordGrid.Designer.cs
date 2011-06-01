namespace Ps.Iso.Viewer
{
	partial class IsoRecordGrid
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      this.gridFields = new Ps.Iso.Viewer.NumberedDataGridView();
      this.colNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
      ((System.ComponentModel.ISupportInitialize)(this.gridFields)).BeginInit();
      this.SuspendLayout();
      // 
      // gridFields
      // 
      this.gridFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.gridFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumber,
            this.colKey,
            this.colValue});
      this.gridFields.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridFields.Location = new System.Drawing.Point(0, 0);
      this.gridFields.Name = "gridFields";
      this.gridFields.RowHeadersVisible = false;
      this.gridFields.Size = new System.Drawing.Size(150, 150);
      this.gridFields.TabIndex = 22;
      this.gridFields.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridFields_CellValueChanged);
      this.gridFields.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.gridFields_DefaultValuesNeeded);
      this.gridFields.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.gridFields_SortCompare);
      this.gridFields.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.gridFields_UserDeletedRow);
      // 
      // colNumber
      // 
      this.colNumber.HeaderText = "№";
      this.colNumber.Name = "colNumber";
      this.colNumber.ReadOnly = true;
      this.colNumber.Width = 30;
      // 
      // colKey
      // 
      this.colKey.DataPropertyName = "Name";
      this.colKey.HeaderText = "Ключ";
      this.colKey.Name = "colKey";
      this.colKey.Width = 54;
      // 
      // colValue
      // 
      this.colValue.DataPropertyName = "Value";
      this.colValue.HeaderText = "Значение";
      this.colValue.Name = "colValue";
      this.colValue.Width = 700;
      // 
      // IsoRecordGrid
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.gridFields);
      this.Name = "IsoRecordGrid";
      this.Load += new System.EventHandler(this.IsoRecordGrid_Load);
      ((System.ComponentModel.ISupportInitialize)(this.gridFields)).EndInit();
      this.ResumeLayout(false);

		}

		#endregion

    public NumberedDataGridView gridFields;
    private System.Windows.Forms.DataGridViewTextBoxColumn colNumber;
    private System.Windows.Forms.DataGridViewTextBoxColumn colKey;
    private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
	}
}
