namespace Ps.Iso.Viewer
{
	partial class SchemeDailog
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnClose = new System.Windows.Forms.Button();
			this.dgvFields = new System.Windows.Forms.DataGridView();
			this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colIsMultivalued = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize) (this.dgvFields)).BeginInit();
			this.SuspendLayout();
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnClose.Location = new System.Drawing.Point(382, 254);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "Закрыть";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// dgvFields
			// 
			this.dgvFields.AllowUserToAddRows = false;
			this.dgvFields.AllowUserToDeleteRows = false;
			this.dgvFields.AllowUserToResizeRows = false;
			this.dgvFields.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
									| System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvFields.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colIsMultivalued,
            this.colSize});
			this.dgvFields.Location = new System.Drawing.Point(13, 13);
			this.dgvFields.Name = "dgvFields";
			this.dgvFields.ReadOnly = true;
			this.dgvFields.RowHeadersVisible = false;
			this.dgvFields.Size = new System.Drawing.Size(444, 235);
			this.dgvFields.TabIndex = 1;
			this.dgvFields.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFields_CellDoubleClick);
			// 
			// colName
			// 
			this.colName.FillWeight = 76.14214F;
			this.colName.HeaderText = "Ключ";
			this.colName.Name = "colName";
			this.colName.ReadOnly = true;
			// 
			// colIsMultivalued
			// 
			this.colIsMultivalued.FillWeight = 120.6734F;
			this.colIsMultivalued.HeaderText = "Многозначное";
			this.colIsMultivalued.Name = "colIsMultivalued";
			this.colIsMultivalued.ReadOnly = true;
			// 
			// colSize
			// 
			this.colSize.FillWeight = 103.1845F;
			this.colSize.HeaderText = "Размер";
			this.colSize.Name = "colSize";
			this.colSize.ReadOnly = true;
			// 
			// SchemeDailog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(469, 289);
			this.Controls.Add(this.dgvFields);
			this.Controls.Add(this.btnClose);
			this.Name = "SchemeDailog";
			this.ShowInTaskbar = false;
			this.Text = "Схема";
			((System.ComponentModel.ISupportInitialize) (this.dgvFields)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.DataGridView dgvFields;
		private System.Windows.Forms.DataGridViewTextBoxColumn colName;
		private System.Windows.Forms.DataGridViewTextBoxColumn colIsMultivalued;
		private System.Windows.Forms.DataGridViewTextBoxColumn colSize;
	}
}