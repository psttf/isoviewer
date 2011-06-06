using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Ps.Iso.Viewer {
  /// <summary>
  /// Summary description for IsoFileForm.
  /// </summary>
  public class IsoFileForm : Form {
    private IContainer components;

    private readonly string _filename;
    private readonly IsoFile _isoFile;
    private SplitContainer _splitContainer1;
    private Panel _panel3;
    private TextBox _tbQuery;
    private Panel _panel5;
    private Label _label3;
    private Button _btFind;
    private Label _label2;
    private TextBox _tbCurRecNum;
    private Button _btJump;
    private Button _btPrev;
    private Button _btNext;
    private Panel _panel1;
    private Label _label1;
    private Label _lblRecordCount;
    private Panel _panel7;
    private Panel _panel6;
    private ListView _lvSearchResults;
    private ColumnHeader _colResultRecNum;
    private ColumnHeader _colResultKeys;
    private Label _label4;

    private List<SearchResult> _searchResults;
    private List<int> _highlightedFields;
    private MainMenu _mainMenu1;
    private MenuItem _menuItem1;
    private MenuItem _miSaveAs;
    private Button _btnFirst;
    private Button _btnLast;
    private MenuItem _miCheckFile;
    private IsoRecordGrid _gridFields;
    private Panel _panel2;
    private TextBox _tbSearchKey;
    private Label _label5;
    private MenuItem _miShowScheme;
    private MenuItem _miSaveAsRdf;
    private Button _btDelete;
    private Button _btInsertAfter;
    private Button _btInsertBefore;
    private ToolTip _toolTip;

    /// <summary>
    /// Номер текущей записи
    /// </summary>
    private int _currentRecordIndex;

    public IsoFileForm(string filename, Form parentForm) {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();

      //
      // constructor code after InitializeComponent call
      //
      _filename = filename;
      try {
        _isoFile = IsoFile.Load(_filename);
      } catch (Exception exception) {
        Helper.ReportError(exception.Message);
      }

      Text = filename;
      MdiParent = parentForm;

      Init();
    }

    public IsoFileForm(Form parentForm) {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();

      //
      // constructor code after InitializeComponent call
      //

      try {
        _isoFile = new IsoFile();
        _isoFile.Records.Add(new IsoRecord());
      } catch (Exception exception) {
        Helper.ReportError(exception.Message);
      }

      Init();

      Text = Global.IsoFileForm_IsoFileForm_NewFile;

      MdiParent = parentForm;
    }

    private void Init()
    {
      UnsavedChanges = false;
      Font = Properties.Settings.Default.Font;
      EditOnEnter = Properties.Settings.Default.EditOnEnter;

      _toolTip.SetToolTip(_btPrev, "Назад Ctrl+PgUp");
      _toolTip.SetToolTip(_btNext, "Назад Ctrl+PgDn");
      _toolTip.SetToolTip(_btnFirst, "Назад Ctrl+Home");
      _toolTip.SetToolTip(_btnLast, "Назад Ctrl+End");
    }

    public override sealed string Text {
      get { return base.Text; }
      set { base.Text = value; }
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing) {
      if (disposing) {
        if (components != null) {
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
    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      Ps.Iso.IsoRecord isoRecord1 = new Ps.Iso.IsoRecord();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IsoFileForm));
      this._splitContainer1 = new System.Windows.Forms.SplitContainer();
      this._gridFields = new Ps.Iso.Viewer.IsoRecordGrid();
      this._panel3 = new System.Windows.Forms.Panel();
      this._tbQuery = new System.Windows.Forms.TextBox();
      this._panel5 = new System.Windows.Forms.Panel();
      this._label3 = new System.Windows.Forms.Label();
      this._panel2 = new System.Windows.Forms.Panel();
      this._btFind = new System.Windows.Forms.Button();
      this._tbSearchKey = new System.Windows.Forms.TextBox();
      this._label5 = new System.Windows.Forms.Label();
      this._panel1 = new System.Windows.Forms.Panel();
      this._btDelete = new System.Windows.Forms.Button();
      this._btInsertAfter = new System.Windows.Forms.Button();
      this._btInsertBefore = new System.Windows.Forms.Button();
      this._btnFirst = new System.Windows.Forms.Button();
      this._btnLast = new System.Windows.Forms.Button();
      this._label2 = new System.Windows.Forms.Label();
      this._tbCurRecNum = new System.Windows.Forms.TextBox();
      this._label1 = new System.Windows.Forms.Label();
      this._btJump = new System.Windows.Forms.Button();
      this._lblRecordCount = new System.Windows.Forms.Label();
      this._btPrev = new System.Windows.Forms.Button();
      this._btNext = new System.Windows.Forms.Button();
      this._panel7 = new System.Windows.Forms.Panel();
      this._lvSearchResults = new System.Windows.Forms.ListView();
      this._colResultRecNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this._colResultKeys = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this._panel6 = new System.Windows.Forms.Panel();
      this._label4 = new System.Windows.Forms.Label();
      this._mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
      this._menuItem1 = new System.Windows.Forms.MenuItem();
      this._miCheckFile = new System.Windows.Forms.MenuItem();
      this._miShowScheme = new System.Windows.Forms.MenuItem();
      this._miSaveAs = new System.Windows.Forms.MenuItem();
      this._miSaveAsRdf = new System.Windows.Forms.MenuItem();
      this._toolTip = new System.Windows.Forms.ToolTip(this.components);
      ((System.ComponentModel.ISupportInitialize)(this._splitContainer1)).BeginInit();
      this._splitContainer1.Panel1.SuspendLayout();
      this._splitContainer1.Panel2.SuspendLayout();
      this._splitContainer1.SuspendLayout();
      this._panel3.SuspendLayout();
      this._panel5.SuspendLayout();
      this._panel2.SuspendLayout();
      this._panel1.SuspendLayout();
      this._panel7.SuspendLayout();
      this._panel6.SuspendLayout();
      this.SuspendLayout();
      // 
      // _splitContainer1
      // 
      this._splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this._splitContainer1.Location = new System.Drawing.Point(0, 0);
      this._splitContainer1.Name = "_splitContainer1";
      this._splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // _splitContainer1.Panel1
      // 
      this._splitContainer1.Panel1.Controls.Add(this._gridFields);
      this._splitContainer1.Panel1.Controls.Add(this._panel3);
      this._splitContainer1.Panel1.Controls.Add(this._panel1);
      // 
      // _splitContainer1.Panel2
      // 
      this._splitContainer1.Panel2.Controls.Add(this._panel7);
      this._splitContainer1.Panel2.Controls.Add(this._panel6);
      this._splitContainer1.Panel2Collapsed = true;
      this._splitContainer1.Size = new System.Drawing.Size(692, 40);
      this._splitContainer1.SplitterDistance = 25;
      this._splitContainer1.TabIndex = 0;
      // 
      // _gridFields
      // 
      this._gridFields.Dock = System.Windows.Forms.DockStyle.Fill;
      this._gridFields.EnableEdit = true;
      this._gridFields.Location = new System.Drawing.Point(0, 28);
      this._gridFields.Name = "_gridFields";
      this._gridFields.Record = isoRecord1;
      this._gridFields.Size = new System.Drawing.Size(692, 0);
      this._gridFields.TabIndex = 22;
      // 
      // _panel3
      // 
      this._panel3.Controls.Add(this._tbQuery);
      this._panel3.Controls.Add(this._panel5);
      this._panel3.Controls.Add(this._panel2);
      this._panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
      this._panel3.Location = new System.Drawing.Point(0, 24);
      this._panel3.Name = "_panel3";
      this._panel3.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
      this._panel3.Size = new System.Drawing.Size(692, 26);
      this._panel3.TabIndex = 20;
      // 
      // _tbQuery
      // 
      this._tbQuery.Dock = System.Windows.Forms.DockStyle.Fill;
      this._tbQuery.Location = new System.Drawing.Point(49, 3);
      this._tbQuery.Name = "_tbQuery";
      this._tbQuery.Size = new System.Drawing.Size(452, 20);
      this._tbQuery.TabIndex = 12;
      this._tbQuery.Enter += new System.EventHandler(this._tbQuery_Enter);
      // 
      // _panel5
      // 
      this._panel5.Controls.Add(this._label3);
      this._panel5.Dock = System.Windows.Forms.DockStyle.Left;
      this._panel5.Location = new System.Drawing.Point(3, 3);
      this._panel5.Name = "_panel5";
      this._panel5.Size = new System.Drawing.Size(46, 23);
      this._panel5.TabIndex = 14;
      // 
      // _label3
      // 
      this._label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this._label3.AutoSize = true;
      this._label3.Location = new System.Drawing.Point(1, 3);
      this._label3.Name = "_label3";
      this._label3.Size = new System.Drawing.Size(42, 13);
      this._label3.TabIndex = 11;
      this._label3.Text = "Поиск:";
      // 
      // _panel2
      // 
      this._panel2.Controls.Add(this._btFind);
      this._panel2.Controls.Add(this._tbSearchKey);
      this._panel2.Controls.Add(this._label5);
      this._panel2.Dock = System.Windows.Forms.DockStyle.Right;
      this._panel2.Location = new System.Drawing.Point(501, 3);
      this._panel2.Name = "_panel2";
      this._panel2.Size = new System.Drawing.Size(188, 23);
      this._panel2.TabIndex = 15;
      // 
      // _btFind
      // 
      this._btFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this._btFind.Location = new System.Drawing.Point(113, 0);
      this._btFind.Name = "_btFind";
      this._btFind.Size = new System.Drawing.Size(75, 20);
      this._btFind.TabIndex = 14;
      this._btFind.Text = "Найти";
      this._btFind.UseVisualStyleBackColor = true;
      this._btFind.Click += new System.EventHandler(this.btFind_Click);
      // 
      // _tbSearchKey
      // 
      this._tbSearchKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this._tbSearchKey.Location = new System.Drawing.Point(46, 0);
      this._tbSearchKey.Name = "_tbSearchKey";
      this._tbSearchKey.Size = new System.Drawing.Size(61, 20);
      this._tbSearchKey.TabIndex = 13;
      this._tbSearchKey.Enter += new System.EventHandler(this._tbSearchKey_Enter);
      // 
      // _label5
      // 
      this._label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this._label5.AutoSize = true;
      this._label5.Location = new System.Drawing.Point(4, 3);
      this._label5.Name = "_label5";
      this._label5.Size = new System.Drawing.Size(36, 13);
      this._label5.TabIndex = 14;
      this._label5.Text = "Поле:";
      // 
      // _panel1
      // 
      this._panel1.Controls.Add(this._btDelete);
      this._panel1.Controls.Add(this._btInsertAfter);
      this._panel1.Controls.Add(this._btInsertBefore);
      this._panel1.Controls.Add(this._btnFirst);
      this._panel1.Controls.Add(this._btnLast);
      this._panel1.Controls.Add(this._label2);
      this._panel1.Controls.Add(this._tbCurRecNum);
      this._panel1.Controls.Add(this._label1);
      this._panel1.Controls.Add(this._btJump);
      this._panel1.Controls.Add(this._lblRecordCount);
      this._panel1.Controls.Add(this._btPrev);
      this._panel1.Controls.Add(this._btNext);
      this._panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this._panel1.Location = new System.Drawing.Point(0, 0);
      this._panel1.Name = "_panel1";
      this._panel1.Size = new System.Drawing.Size(692, 28);
      this._panel1.TabIndex = 18;
      // 
      // _btDelete
      // 
      this._btDelete.Image = ((System.Drawing.Image)(resources.GetObject("_btDelete.Image")));
      this._btDelete.Location = new System.Drawing.Point(640, 4);
      this._btDelete.Name = "_btDelete";
      this._btDelete.Size = new System.Drawing.Size(30, 23);
      this._btDelete.TabIndex = 15;
      this._btDelete.UseVisualStyleBackColor = true;
      this._btDelete.Click += new System.EventHandler(this._btDelete_Click);
      // 
      // _btInsertAfter
      // 
      this._btInsertAfter.Image = ((System.Drawing.Image)(resources.GetObject("_btInsertAfter.Image")));
      this._btInsertAfter.Location = new System.Drawing.Point(593, 4);
      this._btInsertAfter.Name = "_btInsertAfter";
      this._btInsertAfter.Size = new System.Drawing.Size(30, 23);
      this._btInsertAfter.TabIndex = 14;
      this._btInsertAfter.UseVisualStyleBackColor = true;
      this._btInsertAfter.Click += new System.EventHandler(this._btInsertAfter_Click);
      // 
      // _btInsertBefore
      // 
      this._btInsertBefore.Image = ((System.Drawing.Image)(resources.GetObject("_btInsertBefore.Image")));
      this._btInsertBefore.Location = new System.Drawing.Point(557, 4);
      this._btInsertBefore.Name = "_btInsertBefore";
      this._btInsertBefore.Size = new System.Drawing.Size(30, 23);
      this._btInsertBefore.TabIndex = 13;
      this._btInsertBefore.UseVisualStyleBackColor = true;
      this._btInsertBefore.Click += new System.EventHandler(this._btInsertBefore_Click);
      // 
      // _btnFirst
      // 
      this._btnFirst.Image = ((System.Drawing.Image)(resources.GetObject("_btnFirst.Image")));
      this._btnFirst.Location = new System.Drawing.Point(403, 4);
      this._btnFirst.Name = "_btnFirst";
      this._btnFirst.Size = new System.Drawing.Size(30, 23);
      this._btnFirst.TabIndex = 12;
      this._btnFirst.UseVisualStyleBackColor = true;
      this._btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
      // 
      // _btnLast
      // 
      this._btnLast.Image = ((System.Drawing.Image)(resources.GetObject("_btnLast.Image")));
      this._btnLast.Location = new System.Drawing.Point(511, 4);
      this._btnLast.Name = "_btnLast";
      this._btnLast.Size = new System.Drawing.Size(30, 23);
      this._btnLast.TabIndex = 11;
      this._btnLast.UseVisualStyleBackColor = true;
      this._btnLast.Click += new System.EventHandler(this.btnLast_Click);
      // 
      // _label2
      // 
      this._label2.AutoSize = true;
      this._label2.Location = new System.Drawing.Point(157, 9);
      this._label2.Name = "_label2";
      this._label2.Size = new System.Drawing.Size(94, 13);
      this._label2.TabIndex = 6;
      this._label2.Text = "Текущая запись:";
      // 
      // _tbCurRecNum
      // 
      this._tbCurRecNum.Location = new System.Drawing.Point(257, 6);
      this._tbCurRecNum.Name = "_tbCurRecNum";
      this._tbCurRecNum.Size = new System.Drawing.Size(59, 20);
      this._tbCurRecNum.TabIndex = 7;
      this._tbCurRecNum.Text = "123456";
      this._tbCurRecNum.Enter += new System.EventHandler(this._tbCurRecNum_Enter);
      // 
      // _label1
      // 
      this._label1.Location = new System.Drawing.Point(3, 9);
      this._label1.Name = "_label1";
      this._label1.Size = new System.Drawing.Size(88, 23);
      this._label1.TabIndex = 3;
      this._label1.Text = "Число записей:";
      // 
      // _btJump
      // 
      this._btJump.Location = new System.Drawing.Point(322, 4);
      this._btJump.Name = "_btJump";
      this._btJump.Size = new System.Drawing.Size(75, 23);
      this._btJump.TabIndex = 8;
      this._btJump.Text = "Перейти";
      this._btJump.UseVisualStyleBackColor = true;
      this._btJump.Click += new System.EventHandler(this.btJump_Click);
      // 
      // _lblRecordCount
      // 
      this._lblRecordCount.Location = new System.Drawing.Point(94, 9);
      this._lblRecordCount.Name = "_lblRecordCount";
      this._lblRecordCount.Size = new System.Drawing.Size(57, 23);
      this._lblRecordCount.TabIndex = 4;
      this._lblRecordCount.Text = "123456";
      // 
      // _btPrev
      // 
      this._btPrev.Image = ((System.Drawing.Image)(resources.GetObject("_btPrev.Image")));
      this._btPrev.Location = new System.Drawing.Point(439, 4);
      this._btPrev.Name = "_btPrev";
      this._btPrev.Size = new System.Drawing.Size(30, 23);
      this._btPrev.TabIndex = 9;
      this._btPrev.UseVisualStyleBackColor = true;
      this._btPrev.Click += new System.EventHandler(this.btPrev_Click);
      // 
      // _btNext
      // 
      this._btNext.Image = ((System.Drawing.Image)(resources.GetObject("_btNext.Image")));
      this._btNext.Location = new System.Drawing.Point(475, 4);
      this._btNext.Name = "_btNext";
      this._btNext.Size = new System.Drawing.Size(30, 23);
      this._btNext.TabIndex = 10;
      this._btNext.UseVisualStyleBackColor = true;
      this._btNext.Click += new System.EventHandler(this.btNext_Click);
      // 
      // _panel7
      // 
      this._panel7.Controls.Add(this._lvSearchResults);
      this._panel7.Dock = System.Windows.Forms.DockStyle.Fill;
      this._panel7.Location = new System.Drawing.Point(0, 18);
      this._panel7.Name = "_panel7";
      this._panel7.Size = new System.Drawing.Size(150, 28);
      this._panel7.TabIndex = 2;
      // 
      // _lvSearchResults
      // 
      this._lvSearchResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._colResultRecNum,
            this._colResultKeys});
      this._lvSearchResults.Dock = System.Windows.Forms.DockStyle.Fill;
      this._lvSearchResults.FullRowSelect = true;
      this._lvSearchResults.Location = new System.Drawing.Point(0, 0);
      this._lvSearchResults.MultiSelect = false;
      this._lvSearchResults.Name = "_lvSearchResults";
      this._lvSearchResults.Size = new System.Drawing.Size(150, 28);
      this._lvSearchResults.TabIndex = 2;
      this._lvSearchResults.UseCompatibleStateImageBehavior = false;
      this._lvSearchResults.View = System.Windows.Forms.View.Details;
      this._lvSearchResults.ItemActivate += new System.EventHandler(this.lvSearchResults_ItemActivate);
      // 
      // _colResultRecNum
      // 
      this._colResultRecNum.Text = "Номер записи";
      this._colResultRecNum.Width = 89;
      // 
      // _colResultKeys
      // 
      this._colResultKeys.Text = "Поля";
      this._colResultKeys.Width = 443;
      // 
      // _panel6
      // 
      this._panel6.BackColor = System.Drawing.Color.Silver;
      this._panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this._panel6.Controls.Add(this._label4);
      this._panel6.Dock = System.Windows.Forms.DockStyle.Top;
      this._panel6.Location = new System.Drawing.Point(0, 0);
      this._panel6.Name = "_panel6";
      this._panel6.Size = new System.Drawing.Size(150, 18);
      this._panel6.TabIndex = 1;
      // 
      // _label4
      // 
      this._label4.AutoSize = true;
      this._label4.Location = new System.Drawing.Point(3, 0);
      this._label4.Name = "_label4";
      this._label4.Size = new System.Drawing.Size(106, 13);
      this._label4.TabIndex = 2;
      this._label4.Text = "Результаты поиска";
      // 
      // _mainMenu1
      // 
      this._mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItem1});
      // 
      // _menuItem1
      // 
      this._menuItem1.Index = 0;
      this._menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miCheckFile,
            this._miShowScheme,
            this._miSaveAs,
            this._miSaveAsRdf});
      this._menuItem1.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
      this._menuItem1.Text = "Файл";
      // 
      // _miCheckFile
      // 
      this._miCheckFile.Index = 0;
      this._miCheckFile.Text = "Проверить на ошибки...";
      this._miCheckFile.Click += new System.EventHandler(this.miCheckFile_Click);
      // 
      // _miShowScheme
      // 
      this._miShowScheme.Index = 1;
      this._miShowScheme.Text = "Просмотреть схему...";
      this._miShowScheme.Click += new System.EventHandler(this.miShowScheme_Click);
      // 
      // _miSaveAs
      // 
      this._miSaveAs.Index = 2;
      this._miSaveAs.MergeOrder = 1;
      this._miSaveAs.Text = "Сохранить как...";
      this._miSaveAs.Click += new System.EventHandler(this.miSaveAs_Click);
      // 
      // _miSaveAsRdf
      // 
      this._miSaveAsRdf.Index = 3;
      this._miSaveAsRdf.Text = "Сохранить в формате RDF...";
      this._miSaveAsRdf.Visible = false;
      // 
      // IsoFileForm
      // 
      this.AcceptButton = this._btJump;
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(692, 40);
      this.Controls.Add(this._splitContainer1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Menu = this._mainMenu1;
      this.Name = "IsoFileForm";
      this.Text = "ISO-файл";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IsoFileForm_FormClosing);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IsoFileForm_KeyDown);
      this._splitContainer1.Panel1.ResumeLayout(false);
      this._splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this._splitContainer1)).EndInit();
      this._splitContainer1.ResumeLayout(false);
      this._panel3.ResumeLayout(false);
      this._panel3.PerformLayout();
      this._panel5.ResumeLayout(false);
      this._panel5.PerformLayout();
      this._panel2.ResumeLayout(false);
      this._panel2.PerformLayout();
      this._panel1.ResumeLayout(false);
      this._panel1.PerformLayout();
      this._panel7.ResumeLayout(false);
      this._panel6.ResumeLayout(false);
      this._panel6.PerformLayout();
      this.ResumeLayout(false);

    }
    #endregion

    /// <summary>
    /// Должен использоваться при каждой смене текущей записи
    /// </summary>
    /// <param name="recNum">номер записи</param>
    private void GoToRecord(int recNum) {
      try {
        if (!RememberChanges()) return;

        var record = _isoFile.Records[recNum];
        _gridFields.Record = record;
        _gridFields.HighlightFields(_highlightedFields);

        _currentRecordIndex = recNum;
        _tbCurRecNum.Text = (_currentRecordIndex+1).ToString();
        _btNext.Enabled = _currentRecordIndex != _isoFile.Records.Count - 1;
        _btPrev.Enabled = _currentRecordIndex != 0;
      } catch (Exception exception) {
        Helper.ReportError(exception.Message);
      }
    }

    private bool RememberChanges() {
      if (!_gridFields.WasEdited) return true;
      try {
        _gridFields.Record.Validate();
        _isoFile.Records[_currentRecordIndex] = _gridFields.Record;
        UnsavedChanges = true;
        _gridFields.WasEdited = false;
        return true;
      } catch (EmptyFieldsException) {
        Helper.ReportError("Запись должна содержать хотя бы одно поле");
        _gridFields.EditNewRecord();
        return false;
      } catch (IsoRecordValidationFailedException e) {
        Helper.ReportError("Запись сожержит ошибки");
        foreach (var error in e.Errors)
          _gridFields.MarkFieldKey(error.FieldIndex, error.Type);
        return false;
      }
    }

    private void btNext_Click(object sender, EventArgs e) {
      GoToNext();
    }

    private void GoToNext() {
      if (_currentRecordIndex >= _isoFile.Records.Count - 1) return;
      _highlightedFields = null;
      GoToRecord(_currentRecordIndex + 1);
    }

    private void btPrev_Click(object sender, EventArgs e) {
      GoToPrevious();
    }

    private void GoToPrevious() {
      if (_currentRecordIndex > 0) {
        _highlightedFields = null;
        GoToRecord(_currentRecordIndex - 1);
      }
    }

    private void btJump_Click(object sender, EventArgs e) {
      try {
        var val = Convert.ToInt32(_tbCurRecNum.Text) - 1;
        int newRecNum;
        if (val < 0) {
          newRecNum = 0;
        } else if (val >= _isoFile.Records.Count) {
          newRecNum = _isoFile.Records.Count - 1;
        } else {
          newRecNum = val;
        }
        _highlightedFields = null;
        GoToRecord(newRecNum);
      } catch {
        Helper.ReportError("Введите число!");
      }
    }

    private void btFind_Click(object sender, EventArgs e) {
      if (_tbQuery.Text == null) return;
      _lvSearchResults.Items.Clear();
      List<Error> errors = null;
      var cff = new TaskProcessWindow(notifier =>
        _searchResults = _isoFile.Search(_tbQuery.Text,
          _tbSearchKey.Text, out errors, notifier),
        "Поиск...");
      cff.ShowDialog();
      if (errors.Count > 0) {
        var dlg = new ErrorsListDialog(errors, this);
        dlg.ShowDialog();
      }
      foreach (var result in _searchResults) {
        _lvSearchResults.Items.
          Add(new ListViewItem(new[] {result.RecordNumber.ToString(),
                                      result.FieldNumbers.Count.ToString()}));
      }
      _splitContainer1.Panel2Collapsed = false;
    }

    private void lvSearchResults_ItemActivate(object sender, EventArgs e) {
      _highlightedFields = _searchResults[_lvSearchResults.SelectedIndices[0]].
        FieldNumbers;
      GoToRecord(_searchResults[_lvSearchResults.SelectedIndices[0]].
        RecordNumber);
    }

    public new void Show() {
      try {
        UpdateRecordCount();
        _highlightedFields = null;
        GoToRecord(0);

        base.Show();
      } catch (Exception exception) {
        Helper.ReportError(exception.Message);
      }
    }

    private void UpdateRecordCount() {
      _lblRecordCount.Text = _isoFile.Records.Count.ToString();
    }

    private void miSaveAs_Click(object sender, EventArgs e) {
      _gridFields.gridFields.EndEdit();
      if (!RememberChanges()) return;
      new SaveIsoDialog(this).ShowDialog();
    }

    private void btnFirst_Click(object sender, EventArgs e) {
      GoToHome();
    }

    private void GoToHome() {
      GoToRecord(0);
    }

    private void btnLast_Click(object sender, EventArgs e) {
      GoToEnd();
    }

    private void GoToEnd() {
      GoToRecord(_isoFile.Records.Count - 1);
    }

    private void IsoFileForm_FormClosing(
      object sender, FormClosingEventArgs e
    ) {
      if (UnsavedChanges || _gridFields.WasEdited) if (MessageBox.Show(this,
        Global.IsoFileForm_IsoFileForm_FormClosing_UnsavedChanges,
          Global.IsoFileForm_IsoFileForm_FormClosing_Warning,
            MessageBoxButtons.YesNo) == DialogResult.No)
              e.Cancel = true;
      else {
        _isoFile.Dispose();
      } else {
        _isoFile.Dispose();
      }
    }

    private void miCheckFile_Click(object sender, EventArgs e) {
      IList<Error> errors = null;
      var cff = new TaskProcessWindow(a => errors = _isoFile.Check(a),
        "Проверка файла на ошибки");
      cff.ShowDialog();

      var dlg = new ErrorsListDialog(errors,this);
      dlg.ShowDialog();
    }

    private void miShowScheme_Click(object sender, EventArgs e) {
      var dlg = new SchemeDailog(_isoFile);
      dlg.Show();
    }

    private void IsoFileForm_KeyDown(object sender, KeyEventArgs e) {
      switch (e.KeyData) {
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

    private void _btInsertBefore_Click(object sender, EventArgs e)
    {
      InsertNewRecord(_currentRecordIndex);
    }

    private void _btInsertAfter_Click(object sender, EventArgs e) {
      InsertNewRecord(_currentRecordIndex + 1);
    }

    private void InsertNewRecord(int index) {
      _isoFile.Records.Insert(index, new IsoRecord());
      GoToRecord(index);
      _gridFields.EditNewRecord();
      UpdateRecordCount();
      UnsavedChanges = true;
    }

    private void _btDelete_Click(object sender, EventArgs e) {
      _isoFile.Records.RemoveAt(_currentRecordIndex);
      GoToRecord(_currentRecordIndex);
      UpdateRecordCount();
      UnsavedChanges = true;
    }

    public override sealed System.Drawing.Font Font {
      get { return base.Font; }
      set { _gridFields.Font = value; }
    }

    public bool EditOnEnter
    {
      set {
        _gridFields.gridFields.EditMode = value ?
          DataGridViewEditMode.EditOnEnter : DataGridViewEditMode.EditOnF2;
      }
    }

    public bool UnsavedChanges { get; set; }

    public IsoFile CurrentIsoFile { get { return _isoFile; } }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      switch (keyData)
      {
        case (Keys.Control | Keys.PageUp):
          GoToPrevious();
          return true;
        case (Keys.Control | Keys.PageDown):
          GoToNext();
          return true;
        case (Keys.Control | Keys.Home):
          GoToHome();
          return true;
        case (Keys.Control | Keys.End):
          GoToEnd();
          return true;
        default: return false;
      }
    }

    private void _tbCurRecNum_Enter(object sender, EventArgs e) {
      AcceptButton = _btJump;
    }

    private void _tbQuery_Enter(object sender, EventArgs e) {
      AcceptButton = _btFind;
    }

    private void _tbSearchKey_Enter(object sender, EventArgs e) {
      AcceptButton = _btFind;
    }

    //private void miSaveAsRdf_Click(object sender, EventArgs e)
    //{
    //  var dlg = new SaveFileDialog {DefaultExt = "rdf",
    //    Filter = Global.IsoFileForm_miSaveAsRdf_Click_Filename_Filter};
    //  switch (dlg.ShowDialog())
    //  {
    //    case DialogResult.OK:
    //      try
    //      {
    //        _isoFile.ToRdf(dlg.FileName);
    //      }
    //      catch(Exception ex)
    //      {
    //        MessageBox.Show(ex.Message, Global.IsoFileForm_PrintError_Error,
    //          MessageBoxButtons.OK, MessageBoxIcon.Error);
    //      }
    //  }
    //}
  }
}
