using System;
using System.Threading;
using System.Xml;
using System.IO;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Ps.Iso;
using Ps.Win.Controls;

namespace Ps.Iso.Viewer
{
	/// <summary>
	/// Summary description for IsoFileForm.
	/// </summary>
	public class IsoFileForm : System.Windows.Forms.Form
	{
		private IContainer components;

		private string filename;
		private IsoFile isoFile;
		private SplitContainer splitContainer1;
		private Panel panel3;
		private TextBox tbQuery;
		private Panel panel5;
		private Label label3;
		private Button btFind;
		private Label label2;
		private TextBox tbCurRecNum;
		private Button btJump;
		private Button btPrev;
		private Button btNext;
		private Panel panel1;
		private Label label1;
		private Label lblRecordCount;
		private Panel panel7;
		private Panel panel6;
		private ListView lvSearchResults;
		private ColumnHeader colResultRecNum;
		private ColumnHeader colResultKeys;
		private Label label4;

		private List<SearchResult> SearchResults;
		private List<int> HighlightedFields;
		private MainMenu mainMenu1;
		private MenuItem menuItem1;
		private MenuItem miSave;
		private Button btnFirst;
		private Button btnLast;
		private Button btnEdit;
		private MenuItem miCheckFile;
		private IsoRecordGrid gridFields;
		private Panel panel2;
		private TextBox tbSearchKey;
		private Label label5;
		private MenuItem miShowScheme;
    private MenuItem miSaveAsRdf;

		/// <summary>
		/// Номер текущей записи
		/// </summary>
		private int RecordNumber;

		public IsoFileForm(string filename, Form ParentForm)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.filename = filename;
			this.Text = filename;
			MdiParent = ParentForm;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IsoFileForm));
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.panel3 = new System.Windows.Forms.Panel();
      this.tbQuery = new System.Windows.Forms.TextBox();
      this.panel5 = new System.Windows.Forms.Panel();
      this.label3 = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.btFind = new System.Windows.Forms.Button();
      this.tbSearchKey = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnEdit = new System.Windows.Forms.Button();
      this.btnFirst = new System.Windows.Forms.Button();
      this.btnLast = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.tbCurRecNum = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.btJump = new System.Windows.Forms.Button();
      this.lblRecordCount = new System.Windows.Forms.Label();
      this.btPrev = new System.Windows.Forms.Button();
      this.btNext = new System.Windows.Forms.Button();
      this.panel7 = new System.Windows.Forms.Panel();
      this.lvSearchResults = new System.Windows.Forms.ListView();
      this.colResultRecNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colResultKeys = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.panel6 = new System.Windows.Forms.Panel();
      this.label4 = new System.Windows.Forms.Label();
      this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
      this.menuItem1 = new System.Windows.Forms.MenuItem();
      this.miCheckFile = new System.Windows.Forms.MenuItem();
      this.miShowScheme = new System.Windows.Forms.MenuItem();
      this.miSave = new System.Windows.Forms.MenuItem();
      this.miSaveAsRdf = new System.Windows.Forms.MenuItem();
      this.gridFields = new Ps.Iso.Viewer.IsoRecordGrid();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.panel3.SuspendLayout();
      this.panel5.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel1.SuspendLayout();
      this.panel7.SuspendLayout();
      this.panel6.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.gridFields);
      this.splitContainer1.Panel1.Controls.Add(this.panel3);
      this.splitContainer1.Panel1.Controls.Add(this.panel1);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.panel7);
      this.splitContainer1.Panel2.Controls.Add(this.panel6);
      this.splitContainer1.Panel2Collapsed = true;
      this.splitContainer1.Size = new System.Drawing.Size(692, 61);
      this.splitContainer1.SplitterDistance = 57;
      this.splitContainer1.SplitterWidth = 5;
      this.splitContainer1.TabIndex = 0;
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.tbQuery);
      this.panel3.Controls.Add(this.panel5);
      this.panel3.Controls.Add(this.panel2);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel3.Location = new System.Drawing.Point(0, 35);
      this.panel3.Name = "panel3";
      this.panel3.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
      this.panel3.Size = new System.Drawing.Size(692, 26);
      this.panel3.TabIndex = 20;
      // 
      // tbQuery
      // 
      this.tbQuery.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tbQuery.Location = new System.Drawing.Point(49, 3);
      this.tbQuery.Name = "tbQuery";
      this.tbQuery.Size = new System.Drawing.Size(452, 20);
      this.tbQuery.TabIndex = 12;
      // 
      // panel5
      // 
      this.panel5.Controls.Add(this.label3);
      this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel5.Location = new System.Drawing.Point(3, 3);
      this.panel5.Name = "panel5";
      this.panel5.Size = new System.Drawing.Size(46, 23);
      this.panel5.TabIndex = 14;
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(1, 3);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(42, 13);
      this.label3.TabIndex = 11;
      this.label3.Text = "Поиск:";
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.btFind);
      this.panel2.Controls.Add(this.tbSearchKey);
      this.panel2.Controls.Add(this.label5);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
      this.panel2.Location = new System.Drawing.Point(501, 3);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(188, 23);
      this.panel2.TabIndex = 15;
      // 
      // btFind
      // 
      this.btFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btFind.Location = new System.Drawing.Point(113, 0);
      this.btFind.Name = "btFind";
      this.btFind.Size = new System.Drawing.Size(75, 20);
      this.btFind.TabIndex = 13;
      this.btFind.Text = "Найти";
      this.btFind.UseVisualStyleBackColor = true;
      this.btFind.Click += new System.EventHandler(this.btFind_Click);
      // 
      // tbSearchKey
      // 
      this.tbSearchKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.tbSearchKey.Location = new System.Drawing.Point(46, 0);
      this.tbSearchKey.Name = "tbSearchKey";
      this.tbSearchKey.Size = new System.Drawing.Size(61, 20);
      this.tbSearchKey.TabIndex = 15;
      // 
      // label5
      // 
      this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(4, 3);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(36, 13);
      this.label5.TabIndex = 14;
      this.label5.Text = "Поле:";
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnEdit);
      this.panel1.Controls.Add(this.btnFirst);
      this.panel1.Controls.Add(this.btnLast);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.tbCurRecNum);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.btJump);
      this.panel1.Controls.Add(this.lblRecordCount);
      this.panel1.Controls.Add(this.btPrev);
      this.panel1.Controls.Add(this.btNext);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(692, 28);
      this.panel1.TabIndex = 18;
      // 
      // btnEdit
      // 
      this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
      this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
      this.btnEdit.Location = new System.Drawing.Point(547, 4);
      this.btnEdit.Name = "btnEdit";
      this.btnEdit.Size = new System.Drawing.Size(133, 23);
      this.btnEdit.TabIndex = 13;
      this.btnEdit.Text = "Редактировать";
      this.btnEdit.UseVisualStyleBackColor = true;
      this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
      // 
      // btnFirst
      // 
      this.btnFirst.Image = ((System.Drawing.Image)(resources.GetObject("btnFirst.Image")));
      this.btnFirst.Location = new System.Drawing.Point(403, 4);
      this.btnFirst.Name = "btnFirst";
      this.btnFirst.Size = new System.Drawing.Size(30, 23);
      this.btnFirst.TabIndex = 12;
      this.btnFirst.UseVisualStyleBackColor = true;
      this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
      // 
      // btnLast
      // 
      this.btnLast.Image = ((System.Drawing.Image)(resources.GetObject("btnLast.Image")));
      this.btnLast.Location = new System.Drawing.Point(511, 4);
      this.btnLast.Name = "btnLast";
      this.btnLast.Size = new System.Drawing.Size(30, 23);
      this.btnLast.TabIndex = 11;
      this.btnLast.UseVisualStyleBackColor = true;
      this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(157, 9);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(94, 13);
      this.label2.TabIndex = 6;
      this.label2.Text = "Текущая запись:";
      // 
      // tbCurRecNum
      // 
      this.tbCurRecNum.Location = new System.Drawing.Point(257, 6);
      this.tbCurRecNum.Name = "tbCurRecNum";
      this.tbCurRecNum.Size = new System.Drawing.Size(59, 20);
      this.tbCurRecNum.TabIndex = 7;
      this.tbCurRecNum.Text = "123456";
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(3, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(88, 23);
      this.label1.TabIndex = 3;
      this.label1.Text = "Число записей:";
      // 
      // btJump
      // 
      this.btJump.Location = new System.Drawing.Point(322, 4);
      this.btJump.Name = "btJump";
      this.btJump.Size = new System.Drawing.Size(75, 23);
      this.btJump.TabIndex = 8;
      this.btJump.Text = "Перейти";
      this.btJump.UseVisualStyleBackColor = true;
      this.btJump.Click += new System.EventHandler(this.btJump_Click);
      // 
      // lblRecordCount
      // 
      this.lblRecordCount.Location = new System.Drawing.Point(94, 9);
      this.lblRecordCount.Name = "lblRecordCount";
      this.lblRecordCount.Size = new System.Drawing.Size(57, 23);
      this.lblRecordCount.TabIndex = 4;
      this.lblRecordCount.Text = "123456";
      // 
      // btPrev
      // 
      this.btPrev.Image = ((System.Drawing.Image)(resources.GetObject("btPrev.Image")));
      this.btPrev.Location = new System.Drawing.Point(439, 4);
      this.btPrev.Name = "btPrev";
      this.btPrev.Size = new System.Drawing.Size(30, 23);
      this.btPrev.TabIndex = 9;
      this.btPrev.UseVisualStyleBackColor = true;
      this.btPrev.Click += new System.EventHandler(this.btPrev_Click);
      // 
      // btNext
      // 
      this.btNext.Image = ((System.Drawing.Image)(resources.GetObject("btNext.Image")));
      this.btNext.Location = new System.Drawing.Point(475, 4);
      this.btNext.Name = "btNext";
      this.btNext.Size = new System.Drawing.Size(30, 23);
      this.btNext.TabIndex = 10;
      this.btNext.UseVisualStyleBackColor = true;
      this.btNext.Click += new System.EventHandler(this.btNext_Click);
      // 
      // panel7
      // 
      this.panel7.Controls.Add(this.lvSearchResults);
      this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel7.Location = new System.Drawing.Point(0, 18);
      this.panel7.Name = "panel7";
      this.panel7.Size = new System.Drawing.Size(150, 28);
      this.panel7.TabIndex = 2;
      // 
      // lvSearchResults
      // 
      this.lvSearchResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colResultRecNum,
            this.colResultKeys});
      this.lvSearchResults.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lvSearchResults.FullRowSelect = true;
      this.lvSearchResults.Location = new System.Drawing.Point(0, 0);
      this.lvSearchResults.MultiSelect = false;
      this.lvSearchResults.Name = "lvSearchResults";
      this.lvSearchResults.Size = new System.Drawing.Size(150, 28);
      this.lvSearchResults.TabIndex = 2;
      this.lvSearchResults.UseCompatibleStateImageBehavior = false;
      this.lvSearchResults.View = System.Windows.Forms.View.Details;
      this.lvSearchResults.ItemActivate += new System.EventHandler(this.lvSearchResults_ItemActivate);
      // 
      // colResultRecNum
      // 
      this.colResultRecNum.Text = "Номер записи";
      this.colResultRecNum.Width = 89;
      // 
      // colResultKeys
      // 
      this.colResultKeys.Text = "Поля";
      this.colResultKeys.Width = 443;
      // 
      // panel6
      // 
      this.panel6.BackColor = System.Drawing.Color.Silver;
      this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel6.Controls.Add(this.label4);
      this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel6.Location = new System.Drawing.Point(0, 0);
      this.panel6.Name = "panel6";
      this.panel6.Size = new System.Drawing.Size(150, 18);
      this.panel6.TabIndex = 1;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(3, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(106, 13);
      this.label4.TabIndex = 2;
      this.label4.Text = "Результаты поиска";
      // 
      // mainMenu1
      // 
      this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
      // 
      // menuItem1
      // 
      this.menuItem1.Index = 0;
      this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miCheckFile,
            this.miShowScheme,
            this.miSave,
            this.miSaveAsRdf});
      this.menuItem1.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
      this.menuItem1.Text = "Файл";
      // 
      // miCheckFile
      // 
      this.miCheckFile.Index = 0;
      this.miCheckFile.Text = "Проверить на ошибки...";
      this.miCheckFile.Click += new System.EventHandler(this.miCheckFile_Click);
      // 
      // miShowScheme
      // 
      this.miShowScheme.Index = 1;
      this.miShowScheme.Text = "Просмотреть схему...";
      this.miShowScheme.Click += new System.EventHandler(this.miShowScheme_Click);
      // 
      // miSave
      // 
      this.miSave.Index = 2;
      this.miSave.MergeOrder = 1;
      this.miSave.Text = "Сохранить...";
      this.miSave.Click += new System.EventHandler(this.miSave_Click);
      // 
      // miSaveAsRdf
      // 
      this.miSaveAsRdf.Index = 3;
      this.miSaveAsRdf.Text = "Сохранить в формате RDF...";
      this.miSaveAsRdf.Click += new System.EventHandler(this.miSaveAsRdf_Click);
      // 
      // gridFields
      // 
      this.gridFields.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridFields.EnableEdit = true;
      this.gridFields.Fields = ((System.Collections.Generic.List<string[]>)(resources.GetObject("gridFields.Fields")));
      this.gridFields.Location = new System.Drawing.Point(0, 28);
      this.gridFields.Name = "gridFields";
      this.gridFields.Size = new System.Drawing.Size(692, 7);
      this.gridFields.TabIndex = 22;
      // 
      // IsoFileForm
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(692, 61);
      this.Controls.Add(this.splitContainer1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Menu = this.mainMenu1;
      this.Name = "IsoFileForm";
      this.Text = "ISO-файл";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IsoFileForm_FormClosing);
      this.Load += new System.EventHandler(this.IsoFileForm_Load);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IsoFileForm_KeyDown);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.panel5.ResumeLayout(false);
      this.panel5.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel7.ResumeLayout(false);
      this.panel6.ResumeLayout(false);
      this.panel6.PerformLayout();
      this.ResumeLayout(false);

		}
		#endregion

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// Должен использоваться при каждой смене текущей записи
		/// </summary>
		/// <param name="recNum">номер записи</param>
		private void GoToRecord(int recNum)
		{
      try
      {
				isoFile.nCurRecord = recNum;
        gridFields.Fields = isoFile.GetCurRecordArrays();
        gridFields.HighlightedFields = HighlightedFields;
				gridFields.FillGrid();
				RecordNumber = recNum;
				tbCurRecNum.Text = (RecordNumber).ToString();
				btNext.Enabled = RecordNumber != isoFile.nRecordCount - 1;
				btPrev.Enabled = RecordNumber != 0;
      }
      catch (Exception exception)
      {
        PrintError(exception.Message);
      }
		}

		private void btNext_Click(object sender, EventArgs e)
		{
			GoToNext();
		}

		private void GoToNext()
		{
			if (RecordNumber < isoFile.nRecordCount - 1)
			{
				HighlightedFields = null;
				GoToRecord(RecordNumber + 1);
			}
		}

		private void btPrev_Click(object sender, EventArgs e)
		{
			GoToPrevious();
		}

		private void GoToPrevious()
		{
			if (RecordNumber > 0)
			{
				HighlightedFields = null;
				GoToRecord(RecordNumber - 1);
			}
		}

		private void btJump_Click(object sender, EventArgs e)
		{
			try
			{
				int val = Convert.ToInt32(tbCurRecNum.Text);
				int newRecNum;
				if (val < 0)
				{
					newRecNum = 0;
				}
				else if (val >= isoFile.nRecordCount)
				{
					newRecNum = isoFile.nRecordCount - 1;
				}
				else
				{
					newRecNum = val;
				}
				HighlightedFields = null;
				GoToRecord(newRecNum);
			}
			catch
			{
				PrintError("Введите число!");
			}
		}

		private void btFind_Click(object sender, EventArgs e)
		{
			if (tbQuery.Text != null)
			{
				lvSearchResults.Items.Clear();
				List<Error> errors;
				SearchResults = isoFile.SearchRecords(tbQuery.Text,
					tbSearchKey.Text,
					out errors);
				if (errors.Count > 0)
				{
					ErrorsListDialog dlg = new ErrorsListDialog(errors);
					dlg.ShowDialog();
				}
				foreach (SearchResult result in SearchResults)
				{
					lvSearchResults.Items.Add(new ListViewItem(new string[] {result.RecordNumber.ToString(),
					result.FieldNumbers.Count.ToString()}));
				}
				splitContainer1.Panel2Collapsed = false;
			}
		}

		private void lvSearchResults_ItemActivate(object sender, EventArgs e)
		{
			HighlightedFields = SearchResults[lvSearchResults.SelectedIndices[0]].FieldNumbers;
			GoToRecord(SearchResults[lvSearchResults.SelectedIndices[0]].RecordNumber);
		}

		private void IsoFileForm_Load(object sender, EventArgs e)
		{

		}

		public new void Show()
		{
			isoFile = new PsIso();
			try
			{
				isoFile.Open(filename);
				lblRecordCount.Text = isoFile.nRecordCount.ToString();

				HighlightedFields = null;
				GoToRecord(0);

				base.Show();
			}
			catch (Exception exception)
			{
				PrintError(exception.Message);
			}
		}

		public static void PrintError(string message)
		{
			MessageBox.Show(message,
				"Ошибка",
				MessageBoxButtons.OK,
				MessageBoxIcon.Error);
		}

		private void miSave_Click(object sender, EventArgs e)
		{
			new SaveIsoDialog(isoFile).Show();
		}

		private void btnFirst_Click(object sender, EventArgs e)
		{
			GoToHome();
		}

		private void GoToHome()
		{
			GoToRecord(0);
		}

		private void btnLast_Click(object sender, EventArgs e)
		{
			GoToEnd();
		}

		private void GoToEnd()
		{
			GoToRecord(isoFile.nRecordCount - 1);
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			isoFile.nCurRecord = RecordNumber;
      EditRecordDialog dlg = new EditRecordDialog(isoFile,
        gridFields.gridFields.SortedColumn, gridFields.gridFields.SortOrder);
			dlg.ShowDialog();
		}

		private void IsoFileForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			isoFile.Close();
		}

		private void miCheckFile_Click(object sender, EventArgs e)
		{
		  IList<Error> errors;
      TaskProcessWindow cff =
        new TaskProcessWindow(a => errors = isoFile.Check(a),
          "Проверка файла на ошибки");
      cff.ShowDialog();

      ErrorsListDialog dlg = new ErrorsListDialog(errors);
			dlg.ShowDialog();
		}

		private void miShowScheme_Click(object sender, EventArgs e)
		{
			SchemeDailog dlg = new SchemeDailog(isoFile);
			dlg.Show();
		}

		private void IsoFileForm_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyData)
			{
				case Keys.Left:
					GoToPrevious();
					break;

				case Keys.Right:
					GoToNext();
					break;

				case Keys.Home:
					GoToHome();
					break;

				case Keys.End:
					GoToEnd();
					break;
			}
    }

    private void miSaveAsRdf_Click(object sender, EventArgs e)
    {
      var dlg = new SaveFileDialog {DefaultExt = "rdf", Filter = "файлы RDF|*.rdf|Все файлы|*.*"};
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        try
        {
          isoFile.ToRdf(dlg.FileName);
        }
        catch(Exception ex)
        {
          MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

	}
}
