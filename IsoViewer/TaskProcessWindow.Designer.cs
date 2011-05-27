namespace Ps.Iso.Viewer
{
	partial class TaskProcessWindow
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
      this.pbProcessProgress = new System.Windows.Forms.ProgressBar();
      this.lblTitle = new System.Windows.Forms.Label();
      this.btnCancel = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // pbProcessProgress
      // 
      this.pbProcessProgress.Location = new System.Drawing.Point(12, 25);
      this.pbProcessProgress.Name = "pbProcessProgress";
      this.pbProcessProgress.Size = new System.Drawing.Size(352, 23);
      this.pbProcessProgress.TabIndex = 0;
      // 
      // lblTitle
      // 
      this.lblTitle.AutoSize = true;
      this.lblTitle.Location = new System.Drawing.Point(12, 9);
      this.lblTitle.Name = "lblTitle";
      this.lblTitle.Size = new System.Drawing.Size(35, 13);
      this.lblTitle.TabIndex = 1;
      this.lblTitle.Text = "label1";
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(288, 55);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 2;
      this.btnCancel.Text = "Отменить";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // TaskProcessWindow
      // 
      this.ClientSize = new System.Drawing.Size(377, 92);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.lblTitle);
      this.Controls.Add(this.pbProcessProgress);
      this.Name = "TaskProcessWindow";
      this.Shown += new System.EventHandler(this.Form_Shown);
      this.ResumeLayout(false);
      this.PerformLayout();

		}

		#endregion

    private System.Windows.Forms.ProgressBar pbProcessProgress;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Button btnCancel;
	}
}
