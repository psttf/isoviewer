namespace Ps.Iso.Viewer
{
	partial class SaveIsoDialog
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
      this.label1 = new System.Windows.Forms.Label();
      this.tbPath = new System.Windows.Forms.TextBox();
      this.btBrowse = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label2 = new System.Windows.Forms.Label();
      this.tbRecordNumbers = new System.Windows.Forms.TextBox();
      this.rbSaveAllExceptSelected = new System.Windows.Forms.RadioButton();
      this.rbSaveOnlySelected = new System.Windows.Forms.RadioButton();
      this.btCancel = new System.Windows.Forms.Button();
      this.btSave = new System.Windows.Forms.Button();
      this.rbSaveAll = new System.Windows.Forms.RadioButton();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(34, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Путь:";
      // 
      // tbPath
      // 
      this.tbPath.Location = new System.Drawing.Point(53, 10);
      this.tbPath.Name = "tbPath";
      this.tbPath.Size = new System.Drawing.Size(292, 20);
      this.tbPath.TabIndex = 1;
      // 
      // btBrowse
      // 
      this.btBrowse.Location = new System.Drawing.Point(351, 8);
      this.btBrowse.Name = "btBrowse";
      this.btBrowse.Size = new System.Drawing.Size(75, 23);
      this.btBrowse.TabIndex = 2;
      this.btBrowse.Text = "Указать...";
      this.btBrowse.UseVisualStyleBackColor = true;
      this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.rbSaveAll);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.tbRecordNumbers);
      this.groupBox1.Controls.Add(this.rbSaveAllExceptSelected);
      this.groupBox1.Controls.Add(this.rbSaveOnlySelected);
      this.groupBox1.Location = new System.Drawing.Point(16, 37);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(410, 118);
      this.groupBox1.TabIndex = 3;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Сохранять";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(3, 94);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(95, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Номера записей:";
      // 
      // tbRecordNumbers
      // 
      this.tbRecordNumbers.Location = new System.Drawing.Point(104, 91);
      this.tbRecordNumbers.Name = "tbRecordNumbers";
      this.tbRecordNumbers.Size = new System.Drawing.Size(300, 20);
      this.tbRecordNumbers.TabIndex = 2;
      // 
      // rbSaveAllExceptSelected
      // 
      this.rbSaveAllExceptSelected.AutoSize = true;
      this.rbSaveAllExceptSelected.Location = new System.Drawing.Point(6, 42);
      this.rbSaveAllExceptSelected.Name = "rbSaveAllExceptSelected";
      this.rbSaveAllExceptSelected.Size = new System.Drawing.Size(159, 17);
      this.rbSaveAllExceptSelected.TabIndex = 1;
      this.rbSaveAllExceptSelected.Text = "все кроме перечисленных";
      this.rbSaveAllExceptSelected.UseVisualStyleBackColor = true;
      // 
      // rbSaveOnlySelected
      // 
      this.rbSaveOnlySelected.AutoSize = true;
      this.rbSaveOnlySelected.Location = new System.Drawing.Point(6, 65);
      this.rbSaveOnlySelected.Name = "rbSaveOnlySelected";
      this.rbSaveOnlySelected.Size = new System.Drawing.Size(142, 17);
      this.rbSaveOnlySelected.TabIndex = 0;
      this.rbSaveOnlySelected.Text = "только перечисленные";
      this.rbSaveOnlySelected.UseVisualStyleBackColor = true;
      // 
      // btCancel
      // 
      this.btCancel.Location = new System.Drawing.Point(351, 161);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new System.Drawing.Size(75, 23);
      this.btCancel.TabIndex = 4;
      this.btCancel.Text = "Отменить";
      this.btCancel.UseVisualStyleBackColor = true;
      this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
      // 
      // btSave
      // 
      this.btSave.Location = new System.Drawing.Point(270, 161);
      this.btSave.Name = "btSave";
      this.btSave.Size = new System.Drawing.Size(75, 23);
      this.btSave.TabIndex = 5;
      this.btSave.Text = "Сохранить";
      this.btSave.UseVisualStyleBackColor = true;
      this.btSave.Click += new System.EventHandler(this.btSave_Click);
      // 
      // rbSaveAll
      // 
      this.rbSaveAll.AutoSize = true;
      this.rbSaveAll.Checked = true;
      this.rbSaveAll.Location = new System.Drawing.Point(6, 19);
      this.rbSaveAll.Name = "rbSaveAll";
      this.rbSaveAll.Size = new System.Drawing.Size(82, 17);
      this.rbSaveAll.TabIndex = 4;
      this.rbSaveAll.TabStop = true;
      this.rbSaveAll.Text = "все записи";
      this.rbSaveAll.UseVisualStyleBackColor = true;
      // 
      // SaveIsoDialog
      // 
      this.AcceptButton = this.btSave;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(438, 195);
      this.Controls.Add(this.btSave);
      this.Controls.Add(this.btCancel);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.btBrowse);
      this.Controls.Add(this.tbPath);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "SaveIsoDialog";
      this.Text = "Сохранение ISO-файла";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbPath;
		private System.Windows.Forms.Button btBrowse;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbRecordNumbers;
		private System.Windows.Forms.RadioButton rbSaveAllExceptSelected;
		private System.Windows.Forms.RadioButton rbSaveOnlySelected;
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.Button btSave;
    private System.Windows.Forms.RadioButton rbSaveAll;
	}
}