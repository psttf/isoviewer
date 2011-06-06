namespace Ps.Iso.Viewer
{
	partial class ErrorsListDialog
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorsListDialog));
      this.label1 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.dgvErrors = new System.Windows.Forms.DataGridView();
      this.colRecNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this._btSaveAllExceptInvalid = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.dgvErrors)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(265, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Во время поиска обнаружены следующие ошибки:";
      // 
      // button1
      // 
      this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.button1.Location = new System.Drawing.Point(303, 196);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 2;
      this.button1.Text = "Закрыть";
      this.button1.UseVisualStyleBackColor = true;
      // 
      // dgvErrors
      // 
      this.dgvErrors.AllowUserToAddRows = false;
      this.dgvErrors.AllowUserToDeleteRows = false;
      this.dgvErrors.AllowUserToOrderColumns = true;
      this.dgvErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgvErrors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvErrors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRecNum,
            this.colMessage});
      this.dgvErrors.Location = new System.Drawing.Point(15, 25);
      this.dgvErrors.Name = "dgvErrors";
      this.dgvErrors.ReadOnly = true;
      this.dgvErrors.RowHeadersVisible = false;
      this.dgvErrors.RowHeadersWidth = 4;
      this.dgvErrors.Size = new System.Drawing.Size(363, 165);
      this.dgvErrors.TabIndex = 4;
      // 
      // colRecNum
      // 
      this.colRecNum.FillWeight = 30.45685F;
      this.colRecNum.HeaderText = "Запись";
      this.colRecNum.Name = "colRecNum";
      this.colRecNum.ReadOnly = true;
      // 
      // colMessage
      // 
      this.colMessage.FillWeight = 169.5432F;
      this.colMessage.HeaderText = "Сообщение";
      this.colMessage.Name = "colMessage";
      this.colMessage.ReadOnly = true;
      // 
      // _btSaveAllExceptInvalid
      // 
      this._btSaveAllExceptInvalid.Location = new System.Drawing.Point(95, 197);
      this._btSaveAllExceptInvalid.Name = "_btSaveAllExceptInvalid";
      this._btSaveAllExceptInvalid.Size = new System.Drawing.Size(202, 23);
      this._btSaveAllExceptInvalid.TabIndex = 5;
      this._btSaveAllExceptInvalid.Text = "Сохранить все, кроме ошибочных";
      this._btSaveAllExceptInvalid.UseVisualStyleBackColor = true;
      this._btSaveAllExceptInvalid.Click += new System.EventHandler(this._btSaveAllExceptInvalid_Click);
      // 
      // ErrorsListDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(390, 231);
      this.Controls.Add(this._btSaveAllExceptInvalid);
      this.Controls.Add(this.dgvErrors);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.label1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "ErrorsListDialog";
      this.ShowInTaskbar = false;
      this.Text = "Список ошибок";
      ((System.ComponentModel.ISupportInitialize)(this.dgvErrors)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGridView dgvErrors;
		private System.Windows.Forms.DataGridViewTextBoxColumn colRecNum;
		private System.Windows.Forms.DataGridViewTextBoxColumn colMessage;
    private System.Windows.Forms.Button _btSaveAllExceptInvalid;
	}
}