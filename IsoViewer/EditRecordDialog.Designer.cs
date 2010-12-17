namespace Ps.Iso.Viewer
{
	partial class EditRecordDialog
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditRecordDialog));
      this.btnSaveOne = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnSaveAll = new System.Windows.Forms.Button();
      this.gridFields = new Ps.Iso.Viewer.IsoRecordGrid();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnSaveOne
      // 
      this.btnSaveOne.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSaveOne.Location = new System.Drawing.Point(53, 6);
      this.btnSaveOne.Name = "btnSaveOne";
      this.btnSaveOne.Size = new System.Drawing.Size(165, 23);
      this.btnSaveOne.TabIndex = 1;
      this.btnSaveOne.Text = "Сохранить запись отдельно";
      this.btnSaveOne.UseVisualStyleBackColor = true;
      this.btnSaveOne.Click += new System.EventHandler(this.btnSaveOne_Click);
      // 
      // button1
      // 
      this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.button1.Location = new System.Drawing.Point(388, 6);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 2;
      this.button1.Text = "Отменить";
      this.button1.UseVisualStyleBackColor = true;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnSaveAll);
      this.panel1.Controls.Add(this.btnSaveOne);
      this.panel1.Controls.Add(this.button1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 240);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(475, 41);
      this.panel1.TabIndex = 24;
      // 
      // btnSaveAll
      // 
      this.btnSaveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSaveAll.Location = new System.Drawing.Point(224, 6);
      this.btnSaveAll.Name = "btnSaveAll";
      this.btnSaveAll.Size = new System.Drawing.Size(158, 23);
      this.btnSaveAll.TabIndex = 3;
      this.btnSaveAll.Text = "Сохранить файл целиком";
      this.btnSaveAll.UseVisualStyleBackColor = true;
      this.btnSaveAll.Click += new System.EventHandler(this.btnSaveAll_Click);
      // 
      // gridFields
      // 
      this.gridFields.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridFields.EnableEdit = true;
      this.gridFields.Fields = ((System.Collections.Generic.List<string[]>)(resources.GetObject("gridFields.Fields")));
      this.gridFields.Location = new System.Drawing.Point(0, 0);
      this.gridFields.Margin = new System.Windows.Forms.Padding(13);
      this.gridFields.Name = "gridFields";
      this.gridFields.Padding = new System.Windows.Forms.Padding(12, 12, 12, 0);
      this.gridFields.Size = new System.Drawing.Size(475, 240);
      this.gridFields.TabIndex = 23;
      // 
      // EditRecordDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(475, 281);
      this.Controls.Add(this.gridFields);
      this.Controls.Add(this.panel1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MinimumSize = new System.Drawing.Size(440, 28);
      this.Name = "EditRecordDialog";
      this.ShowInTaskbar = false;
      this.Text = "Редактирование записи";
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnSaveOne;
		private System.Windows.Forms.Button button1;
		public IsoRecordGrid gridFields;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnSaveAll;
	}
}