using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Ps.Iso.Viewer.Properties;

namespace Ps.Iso.Viewer {
  /// <summary>
  /// Summary description for IsoFileForm.
  /// </summary>
  public partial class IsoFileForm : IsoFileFormBase {

    private List<SearchResult> _searchResults;
    private List<int> _highlightedFields;

    private ToolStripMenuItem _miCheckFile;
    private ToolStripMenuItem _miShowScheme;
    private ToolStripMenuItem _miSaveAs;
    private ToolStripMenuItem _miSave;
    //private ToolStripMenuItem _miSaveAsRdf;

    #region from MainForm
    private ToolStripMenuItem _miHelp;
    private ToolStripMenuItem _miAbout;
    private ToolStripMenuItem _menuExit;
    private ToolStripMenuItem _viewMenuItem;
    private ToolStripMenuItem _miSelectFont;
    private ToolStripMenuItem _miEditOnEnter;
    
    // кнопка "Открыть ISO-файл":
    //private ImageList _imageList1;
    //private ToolStripMenuItem _miShowOpenIsoFileButton;
    //private ToolBar _tbOpenIsoFile;
    //private ToolBarButton _btnOpenIsoFile;

    #endregion

    /// <summary>
    /// Номер текущей записи (нумерация с 0)
    /// </summary>
    private int _currentRecordIndex;

    public IsoFileForm() {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();

      //
      // constructor code after InitializeComponent call
      //

      Init();
    }

    private void Init()
    {
      if (Settings.Default.BoundsSet) {
        // restore location and size of the form on the desktop
        DesktopBounds = Settings.Default.Bounds;
        // restore form's window state
        WindowState = Settings.Default.WindowState;
      } else {
        StartPosition = FormStartPosition.WindowsDefaultBounds;
      }
      Height -= 20;

      UnsavedChanges = false;
      Font = Settings.Default.Font;
      EditOnEnter = Settings.Default.EditOnEnter;

      _toolTip.SetToolTip(_btJump, "Перейти к записи с указанным номером");

      _toolTip.SetToolTip(_btPrev, "Предыдущая запись Ctrl+PgUp");
      _toolTip.SetToolTip(_btNext, "Следующая запись Ctrl+PgDn");
      _toolTip.SetToolTip(_btnFirst, "Первая запись Ctrl+Home");
      _toolTip.SetToolTip(_btnLast, "Последняя запись Ctrl+End");

      _toolTip.SetToolTip(_btInsertBefore, "Вставить запись перед текущей");
      _toolTip.SetToolTip(_btInsertAfter, "Вставить запись после текущей");
      _toolTip.SetToolTip(_btDelete, "Удалить запись");

      _miCheckFile = new ToolStripMenuItem();
      _miShowScheme = new ToolStripMenuItem();
      _miSave = new ToolStripMenuItem();
      _miSaveAs = new ToolStripMenuItem();
      //_miSaveAsRdf = new ToolStripMenuItem();

      _menuExit = new ToolStripMenuItem();
      _viewMenuItem = new ToolStripMenuItem();
      _miSelectFont = new ToolStripMenuItem();
      //_miShowOpenIsoFileButton = new ToolStripMenuItem();
      _miEditOnEnter = new ToolStripMenuItem();
      _miHelp = new ToolStripMenuItem();
      _miAbout = new ToolStripMenuItem();
      //_tbOpenIsoFile = new ToolBar();
      //_btnOpenIsoFile = new ToolBarButton();
      //_imageList1 = new ImageList(components);
  
      SuspendLayout();

      //_miShowOpenIsoFileButton.Checked = Settings.Default.tbOpenIsoFile_Visible;
      //_tbOpenIsoFile.Visible = Settings.Default.tbOpenIsoFile_Visible;
      _miEditOnEnter.Checked = Settings.Default.EditOnEnter;

      fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
        _miCheckFile, _miShowScheme, _miSave, _miSaveAs,
        //_miSaveAsRdf,
        new ToolStripSeparator(),
        _menuExit
      });
      // 
      // _miCheckFile
      // 
      _miCheckFile.MergeIndex = 0;
      _miCheckFile.Text = Global.IsoFileForm__miCheckFile_Text;
      _miCheckFile.Click += miCheckFile_Click;
      // 
      // _miShowScheme
      // 
      _miShowScheme.MergeIndex = 1;
      _miShowScheme.Text = Global.IsoFileForm_Init_miShowScheme_Text;
      _miShowScheme.Click += miShowScheme_Click;
      // 
      // _miSave
      // 
      _miSave.MergeIndex = 2;
      _miSave.Text = Global.IsoFileForm_Init_miSave_Text;
      _miSave.Click += miSave_Click;
      // 
      // _miSaveAs
      // 
      _miSaveAs.MergeIndex = 3;
      _miSaveAs.Text = Global.IsoFileForm_Init_miSaveAs_Text;
      _miSaveAs.Click += miSaveAs_Click;
      // 
      // _miSaveAsRdf
      // 
      //_miSaveAsRdf.MergeIndex = 3;
      //_miSaveAsRdf.Text = Global.IsoFileForm_Init_miSaveAsRdf_Text;
      //_miSaveAsRdf.Visible = false;

      // 
      // _openIsoFileDlg
      // 
      openFileDialog.DefaultExt = "iso";
      openFileDialog.Filter =
        Global.IsoFileForm_Init_файлы_ISO_openFileDialog_Filter;
      openFileDialog.ReadOnlyChecked = true;
      openFileDialog.Title = Global.IsoFileForm_Init_openFileDialog_Title;
      // 
      // _mainMenu1
      // 
      mainMenuStrip.Items.AddRange(new ToolStripItem[] {_viewMenuItem,_miHelp});
      // 
      // _menuItem7
      // 
      //this._menuItem7.Index = 2;
      //this._menuItem7.MergeOrder = 2;
      //this._menuItem7.Text = "-";
      // 
      // _menuExit
      // 
      _menuExit.MergeIndex = 3;
      _menuExit.Text = Global.IsoFileForm_Init_menuExit_Text;
      _menuExit.Click += menuExit_Click;
      // 
      // _viewMenuItem
      // 
      _viewMenuItem.MergeIndex = 1;
      _viewMenuItem.DropDown.Items.AddRange(new[] {
            _miSelectFont,
            //_miShowOpenIsoFileButton,
            _miEditOnEnter});
      _viewMenuItem.Text = Global.IsoFileForm_Init_viewMenuItem_Text;
      // 
      // _miSelectFont
      // 
      _miSelectFont.MergeIndex = 0;
      _miSelectFont.Text = Global.IsoFileForm_Init_miSelectFont_Text;
      _miSelectFont.Click += miSelectFont_Click;
      //// 
      //// _miShowOpenIsoFileButton
      //// 
      //_miShowOpenIsoFileButton.MergeIndex = 1;
      //_miShowOpenIsoFileButton.Text =
      //  Global.IsoFileForm_Init_Кнопка_miShowOpenIsoFileButton_Text;
      //_miShowOpenIsoFileButton.Click += _miShowOpenIsoFileButton_Click;
      // 
      // _miEditOnEnter
      // 
      _miEditOnEnter.Checked = true;
      _miEditOnEnter.MergeIndex = 2;
      _miEditOnEnter.Text = Global.IsoFileForm_Init_miEditOnEnter_Text;
      _miEditOnEnter.Click += miEditOnEnter_Click;
      // 
      // _miHelp
      // 
      _miHelp.MergeIndex = 2;
      _miHelp.DropDown.Items.AddRange(new[] {_miAbout});
      _miHelp.Text = Global.IsoFileForm_Init_miHelp_Text;
      // 
      // _miAbout
      // 
      _miAbout.MergeIndex = 0;
      _miAbout.Text = Global.IsoFileForm_Init_miAbout_Text;
      _miAbout.Click += miAbout_Click;
      //// 
      //// _tbOpenIsoFile
      //// 
      //_tbOpenIsoFile.Appearance = ToolBarAppearance.Flat;
      //_tbOpenIsoFile.Buttons.AddRange(new[] {_btnOpenIsoFile});
      //_tbOpenIsoFile.DropDownArrows = true;
      //_tbOpenIsoFile.ImageList = _imageList1;
      //_tbOpenIsoFile.Location = new System.Drawing.Point(0, 0);
      //_tbOpenIsoFile.Name = "_tbOpenIsoFile";
      //_tbOpenIsoFile.ShowToolTips = true;
      //_tbOpenIsoFile.Size = new System.Drawing.Size(694, 28);
      //_tbOpenIsoFile.TabIndex = 1;
      //_tbOpenIsoFile.TextAlign = ToolBarTextAlign.Right;
      //_tbOpenIsoFile.Visible = false;
      //_tbOpenIsoFile.ButtonClick += toolBar1_ButtonClick;
      //// 
      //// btnOpenIsoFile
      //// 
      //_btnOpenIsoFile.ImageIndex = 0;
      //_btnOpenIsoFile.Name = "btnOpenIsoFile";
      //_btnOpenIsoFile.Tag = "OpenIsoFile";
      //_btnOpenIsoFile.Text = Global.IsoFileForm_Init_btnOpenIsoFile_Text;
      //// 
      //// _imageList1
      //// 
      //_imageList1.ImageStream =
      // ((ImageListStreamer)(resources.GetObject("_imageList1.ImageStream")));
      //this._imageList1.TransparentColor = System.Drawing.Color.Transparent;
      //this._imageList1.Images.SetKeyName(0, "fileopen.png");
      //this._imageList1.Images.SetKeyName(1, "");
      // 
      // MainForm
      // 
      ResumeLayout(false);
      PerformLayout();
    }

    private void InitializeFormData()
    {
      try {
        UpdateRecordCount();
        _highlightedFields = null;
        RememberChangesAndGoToRecord(0);
      } catch (Exception exception) {
        Helper.ReportError(exception.Message);
      }
      UnsavedChanges = false;
    }

    /// <summary>
    /// Должен использоваться при каждой смене текущей записи
    /// </summary>
    /// <param name="recNum">номер записи</param>
    private void GoToRecord(int recNum) {
      try {
        var record = CurrentIsoFile.Records[recNum];
        _gridFields.Record = record;
        _gridFields.HighlightFields(_highlightedFields);

        _currentRecordIndex = recNum;
        _tbCurRecNum.Text = (_currentRecordIndex + 1).ToString();
        _btNext.Enabled = _currentRecordIndex != CurrentIsoFile.Records.Count - 1;
        _btPrev.Enabled = _currentRecordIndex != 0;
      } catch (Exception exception) {
        Helper.ReportError(exception.Message);
      }
    }

    private void RememberChangesAndGoToRecord(int recNum) {
      if (!RememberChanges()) return;
      GoToRecord(recNum);
    }

    /// <summary>
    /// Сохраняет изменения в текущей записи. Если запись содержит ошибки,
    /// выводит соответствующие сообщения
    /// </summary>
    /// <returns>true, если запись сохранена,
    /// false -- в обратном случае</returns>
    private bool RememberChanges() {
      if (!_gridFields.WasEdited) return true;
      try {
        _gridFields.Record.Validate();
        CurrentIsoFile.Records[_currentRecordIndex] = _gridFields.Record;
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
      if (_currentRecordIndex >= CurrentIsoFile.Records.Count - 1) return;
      _highlightedFields = null;
      RememberChangesAndGoToRecord(_currentRecordIndex + 1);
    }

    private void btPrev_Click(object sender, EventArgs e) {
      GoToPrevious();
    }

    private void GoToPrevious() {
      if (_currentRecordIndex <= 0) return;
      _highlightedFields = null;
      RememberChangesAndGoToRecord(_currentRecordIndex - 1);
    }

    private void btJump_Click(object sender, EventArgs e) {
      try {
        var val = Convert.ToInt32(_tbCurRecNum.Text) - 1;
        int newRecNum;
        if (val < 0) {
          newRecNum = 0;
        } else if (val >= CurrentIsoFile.Records.Count) {
          newRecNum = CurrentIsoFile.Records.Count - 1;
        } else {
          newRecNum = val;
        }
        _highlightedFields = null;
        RememberChangesAndGoToRecord(newRecNum);
      } catch {
        Helper.ReportError("Введите число!");
      }
    }

    private void btFind_Click(object sender, EventArgs e) {
      if (_tbQuery.Text == null) return;
      _lvSearchResults.Items.Clear();
      List<Error> errors = null;
      var cff = new TaskProcessWindow(notifier =>
        _searchResults = CurrentIsoFile.Search(_tbQuery.Text,
          _tbSearchKey.Text, out errors, notifier),
        "Поиск...");
      cff.ShowDialog();
      if (errors.Count > 0) {
        var dlg = new ErrorsListDialog(errors, this);
        dlg.ShowDialog();
      }
      foreach (var result in _searchResults) {
        _lvSearchResults.Items.
          Add(new ListViewItem(new[] {(result.RecordNumber + 1).ToString(),
                                      result.FieldNumbers.Count.ToString()}));
      }
      _splitContainer1.Panel2Collapsed = false;
    }

    private void lvSearchResults_ItemActivate(object sender, EventArgs e) {
      _highlightedFields = _searchResults[_lvSearchResults.SelectedIndices[0]].
        FieldNumbers;
      RememberChangesAndGoToRecord(_searchResults[_lvSearchResults.SelectedIndices[0]].
        RecordNumber);
    }

    private void UpdateRecordCount() {
      var cnt = CurrentIsoFile.Records.Count;
      _lblRecordCount.Text = cnt.ToString();
      _btDelete.Enabled = cnt > 1;
    }

    private bool EndEditAndRememberChanges() {
      _gridFields.gridFields.EndEdit();
      return RememberChanges();
    }

    private void miSaveAs_Click(object sender, EventArgs e) {
      if (!EndEditAndRememberChanges()) return;

      var saveIsoDialog = new SaveIsoDialog(this);
      if (saveIsoDialog.ShowDialog() != DialogResult.OK) return;

      ExecuteSaveTask(saveIsoDialog.SaveMethod,
        saveIsoDialog.RecordNumbers, saveIsoDialog.Filename);
    }

    private void miSave_Click(object sender, EventArgs e) {
      if (FileIsNew) miSaveAs_Click(sender, e);
      else
      {
        if (!EndEditAndRememberChanges()) return;
        ExecuteSaveTask(SaveMethod.All, null, FileName);
      }
    }

    private void ExecuteSaveTask(
      SaveMethod saveMethod,
      IList<int> recordNumbers,
      string filename
    ) {
      var oldCurrentRecordIndex = _currentRecordIndex;
      var oldRowIndex = _gridFields.gridFields.CurrentCell.RowIndex;
      var oldColumn = _gridFields.gridFields.CurrentCell.OwningColumn.Name;
      var newCurrentRecordIndex = -1;
      Action<Action<int>> action = null;
      switch (saveMethod) {
        case SaveMethod.All:
          action = a => CurrentIsoFile.Save(filename, a);
          newCurrentRecordIndex = oldCurrentRecordIndex;
          break;
        case SaveMethod.Except:
          action = a => CurrentIsoFile.SaveExcept(filename, recordNumbers, a);
          newCurrentRecordIndex = oldCurrentRecordIndex -
            recordNumbers.Where(n => n <= oldCurrentRecordIndex).Count();
          break;
        case SaveMethod.Only:
          action = a => CurrentIsoFile.SaveOnly(filename, recordNumbers, a);
          newCurrentRecordIndex =
            recordNumbers.Contains(oldCurrentRecordIndex) ?
              recordNumbers.Where(n => n < oldCurrentRecordIndex).Count() : 0;
          break;
      } 
      new TaskProcessWindow(action, "Сохранение").ShowDialog();
      CurrentIsoFile.Dispose();
      OpenFile(filename);
      GoToRecord(newCurrentRecordIndex);
      _gridFields.gridFields.CurrentCell =
        _gridFields.gridFields[oldColumn, oldRowIndex];
    }

    private void btnFirst_Click(object sender, EventArgs e) {
      GoToHome();
    }

    private void GoToHome() {
      RememberChangesAndGoToRecord(0);
    }

    private void btnLast_Click(object sender, EventArgs e) {
      GoToEnd();
    }

    private void GoToEnd() {
      RememberChangesAndGoToRecord(CurrentIsoFile.Records.Count - 1);
    }

    private void IsoFileForm_FormClosing(
      object sender, FormClosingEventArgs e
    ) {
      Settings.Default.gridFields_SortedColumn_Name =
        _gridFields.gridFields.SortedColumn.Name;
      Settings.Default.gridFields_SortDirection = _gridFields.gridFields.
        SortOrder.ToSortDirection();
      Settings.Default.Save();
      if (UnsavedChanges || _gridFields.WasEdited) if (MessageBox.Show(this,
        Global.IsoFileForm_IsoFileForm_FormClosing_UnsavedChanges,
          Global.IsoFileForm_IsoFileForm_FormClosing_Warning,
            MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.No)
              e.Cancel = true;
      else {
        CurrentIsoFile.Dispose();
      } else {
        CurrentIsoFile.Dispose();
      }
      MainForm_FormClosing();
    }

    private void miCheckFile_Click(object sender, EventArgs e) {
      IList<Error> errors = null;
      var cff = new TaskProcessWindow(a => errors = CurrentIsoFile.Check(a),
        "Проверка файла на ошибки");
      cff.ShowDialog();

      var dlg = new ErrorsListDialog(errors,this);
      dlg.ShowDialog();
    }

    private void miShowScheme_Click(object sender, EventArgs e) {
      var dlg = new SchemeDailog(CurrentIsoFile);
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
      InsertNewRecordAt(_currentRecordIndex);
    }

    private void _btInsertAfter_Click(object sender, EventArgs e) {
      InsertNewRecordAt(_currentRecordIndex + 1);
    }

    private void InsertNewRecordAt(int index) {
      if (!RememberChanges()) return;
      CurrentIsoFile.Records.Insert(index, new IsoRecord());
      GoToRecord(index);
      _gridFields.EditNewRecord();
      UpdateRecordCount();
      UnsavedChanges = true;
    }

    private void _btDelete_Click(object sender, EventArgs e) {
      CurrentIsoFile.Records.RemoveAt(_currentRecordIndex);
      if (_currentRecordIndex > 0) RememberChangesAndGoToRecord(_currentRecordIndex - 1);
      else RememberChangesAndGoToRecord(_currentRecordIndex);
      UpdateRecordCount();
      UnsavedChanges = true;
    }

    public override sealed Font Font {
      get { return base.Font; }
      set {
        _gridFields.Font = value;
      }
    }

    public bool EditOnEnter
    {
      set {
        _gridFields.gridFields.EditMode = value ?
          DataGridViewEditMode.EditOnEnter : DataGridViewEditMode.EditOnF2;
      }
    }

    public bool UnsavedChanges { get; set; }

    public IsoFile CurrentIsoFile { get; private set; }

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

    public override void ProcessOpenedFile(string filename) {
      try {
        CurrentIsoFile = IsoFile.Load(FileName);
      } catch (Exception exception) {
        Helper.ReportError(exception.Message);
      }

      InitializeFormData();
    }

    public override void InitNewFile() {
      try {
        CurrentIsoFile = new IsoFile();
        CurrentIsoFile.Records.Add(new IsoRecord());
      } catch (Exception exception) {
        Helper.ReportError(exception.Message);
      }
      InitializeFormData();
      _gridFields.EditNewRecord();
    }

    #region from MainForm

    private void menuExit_Click(object sender, EventArgs e) {
      Close();
    }

    private static void miSelectFont_Click(object sender, EventArgs e) {
      var dlg = new FontDialog {
        AllowVerticalFonts = false,
        ShowColor = false,
        ShowApply = false,
        ShowEffects = false,
        ShowHelp = false,
        Font = Settings.Default.Font
      };
      dlg.ShowDialog();
      Settings.Default.Font = dlg.Font;
      Settings.Default.Save();
      foreach (IsoFileForm form in IvApplication.CurrentApplication.OpenForms) {
        form.Font = dlg.Font;
      }
    }

    //private void _miShowOpenIsoFileButton_Click(object sender, EventArgs e) {
    //  if (_miShowOpenIsoFileButton.Checked) {
    //    _miShowOpenIsoFileButton.Checked = false;
    //    _tbOpenIsoFile.Visible = false;
    //  } else {
    //    _miShowOpenIsoFileButton.Checked = true;
    //    _tbOpenIsoFile.Visible = true;
    //  }
    //  Settings.Default.tbOpenIsoFile_Visible = _miShowOpenIsoFileButton.Checked;
    //  Settings.Default.Save();
    //}

    private void miEditOnEnter_Click(object sender, EventArgs e) {
      _miEditOnEnter.Checked = !_miEditOnEnter.Checked;
      Settings.Default.EditOnEnter = _miEditOnEnter.Checked;

      foreach (IsoFileForm form in MdiChildren) {
        form.EditOnEnter = _miEditOnEnter.Checked;
      }
    }

    private static void miAbout_Click(object sender, EventArgs e) {
      new AboutDialog().ShowDialog();
    }

    //private void toolBar1_ButtonClick(object sender,
    // ToolBarButtonClickEventArgs e) {
    //  if ((string)e.Button.Tag == "OpenIsoFile") {
    //    OpenIsoFile();
    //  }
    //}

    private void MainForm_FormClosing() {
      Settings.Default.Bounds = DesktopBounds;
      Settings.Default.WindowState = WindowState;
      // persist location ,size and window state of the form on the desktop
      Settings.Default.BoundsSet = true;
      Settings.Default.Save();
    }
   
    #endregion
  }

  public enum SaveMethod { All, Except, Only }
}
