using System;
using System.Windows.Forms;

using Ps.Iso.Viewer.Properties;

namespace Ps.Iso.Viewer {
  /// <summary>
  /// Summary description for Form1.
  /// </summary>
  public class MainForm : Form {
    private MainMenu _mainMenu1;
    private MenuItem _menuItem1;
    private MenuItem _menuItem2;
    private MenuItem _miAbout;
    private MenuItem _menuItem7;
    private ToolBar _tbOpenIsoFile;
    private ImageList _imageList1;
    private MenuItem _miOpenIso;
    private OpenFileDialog _openIsoFileDlg;
    private OpenFileDialog _openLogFileDlg;
    private MenuItem _menuExit;
    private MenuItem _menuItem4;
    private MenuItem _miShowOpenIsoFileButton;
    private MenuItem _miSelectFont;
    private MenuItem _miEditOnEnter;
    private MenuItem _miNewFile;
    private ToolBarButton _btnOpenIsoFile;
    private System.ComponentModel.IContainer components;

    public MainForm() {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();

      Init(null);
    }

    public MainForm(string fileName) {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();

      //
      // constructor code after InitializeComponent call
      //
      Init(fileName);
    }

    private void Init(string fileName) {
      if (Settings.Default.BoundsSet) {
        // restore location and size of the form on the desktop
        DesktopBounds = Settings.Default.Bounds;
        // restore form's window state
        WindowState = Settings.Default.WindowState;
      } else {
        StartPosition = FormStartPosition.WindowsDefaultBounds;
      }
      Height -= 20;

      _miShowOpenIsoFileButton.Checked = Settings.Default.tbOpenIsoFile_Visible;
      _tbOpenIsoFile.Visible = Settings.Default.tbOpenIsoFile_Visible;
      _miEditOnEnter.Checked = Settings.Default.EditOnEnter;

      if (fileName != null) {
        new IsoFileForm(fileName, this).Show();
      }
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this._openIsoFileDlg = new System.Windows.Forms.OpenFileDialog();
      this._mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
      this._menuItem1 = new System.Windows.Forms.MenuItem();
      this._miNewFile = new System.Windows.Forms.MenuItem();
      this._miOpenIso = new System.Windows.Forms.MenuItem();
      this._menuItem7 = new System.Windows.Forms.MenuItem();
      this._menuExit = new System.Windows.Forms.MenuItem();
      this._menuItem4 = new System.Windows.Forms.MenuItem();
      this._miSelectFont = new System.Windows.Forms.MenuItem();
      this._miShowOpenIsoFileButton = new System.Windows.Forms.MenuItem();
      this._miEditOnEnter = new System.Windows.Forms.MenuItem();
      this._menuItem2 = new System.Windows.Forms.MenuItem();
      this._miAbout = new System.Windows.Forms.MenuItem();
      this._tbOpenIsoFile = new System.Windows.Forms.ToolBar();
      this._btnOpenIsoFile = new System.Windows.Forms.ToolBarButton();
      this._imageList1 = new System.Windows.Forms.ImageList(this.components);
      this._openLogFileDlg = new System.Windows.Forms.OpenFileDialog();
      this.SuspendLayout();
      // 
      // _openIsoFileDlg
      // 
      this._openIsoFileDlg.DefaultExt = "iso";
      this._openIsoFileDlg.Filter = "файлы ISO|*.iso|Все файлы|*.*";
      this._openIsoFileDlg.ReadOnlyChecked = true;
      this._openIsoFileDlg.Title = "Открытие файла";
      // 
      // _mainMenu1
      // 
      this._mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItem1,
            this._menuItem4,
            this._menuItem2});
      // 
      // _menuItem1
      // 
      this._menuItem1.Index = 0;
      this._menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miNewFile,
            this._miOpenIso,
            this._menuItem7,
            this._menuExit});
      this._menuItem1.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
      this._menuItem1.Text = "Файл";
      // 
      // _miNewFile
      // 
      this._miNewFile.Index = 0;
      this._miNewFile.Text = "Создать";
      this._miNewFile.Click += new System.EventHandler(this._miNewFile_Click);
      // 
      // _miOpenIso
      // 
      this._miOpenIso.Index = 1;
      this._miOpenIso.Text = "Открыть ISO-файл...";
      this._miOpenIso.Click += new System.EventHandler(this.miOpenIso_Click);
      // 
      // _menuItem7
      // 
      this._menuItem7.Index = 2;
      this._menuItem7.MergeOrder = 2;
      this._menuItem7.Text = "-";
      // 
      // _menuExit
      // 
      this._menuExit.Index = 3;
      this._menuExit.MergeOrder = 3;
      this._menuExit.Text = "Выход";
      this._menuExit.Click += new System.EventHandler(this.menuExit_Click);
      // 
      // _menuItem4
      // 
      this._menuItem4.Index = 1;
      this._menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miSelectFont,
            this._miShowOpenIsoFileButton,
            this._miEditOnEnter});
      this._menuItem4.Text = "Вид";
      // 
      // _miSelectFont
      // 
      this._miSelectFont.Index = 0;
      this._miSelectFont.Text = "Выбрать шрифт...";
      this._miSelectFont.Click += new System.EventHandler(this.miSelectFont_Click);
      // 
      // _miShowOpenIsoFileButton
      // 
      this._miShowOpenIsoFileButton.Index = 1;
      this._miShowOpenIsoFileButton.Text = "Кнопка \"Открыть ISO-файл\"";
      this._miShowOpenIsoFileButton.Click += new System.EventHandler(this._miShowOpenIsoFileButton_Click);
      // 
      // _miEditOnEnter
      // 
      this._miEditOnEnter.Checked = true;
      this._miEditOnEnter.Index = 2;
      this._miEditOnEnter.Text = "Быстрое редактирование";
      this._miEditOnEnter.Click += new System.EventHandler(this.miEditOnEnter_Click);
      // 
      // _menuItem2
      // 
      this._menuItem2.Index = 2;
      this._menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miAbout});
      this._menuItem2.Text = "Справка";
      // 
      // _miAbout
      // 
      this._miAbout.Index = 0;
      this._miAbout.Text = "О программе";
      this._miAbout.Click += new System.EventHandler(this.miAbout_Click);
      // 
      // _tbOpenIsoFile
      // 
      this._tbOpenIsoFile.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
      this._tbOpenIsoFile.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this._btnOpenIsoFile});
      this._tbOpenIsoFile.DropDownArrows = true;
      this._tbOpenIsoFile.ImageList = this._imageList1;
      this._tbOpenIsoFile.Location = new System.Drawing.Point(0, 0);
      this._tbOpenIsoFile.Name = "_tbOpenIsoFile";
      this._tbOpenIsoFile.ShowToolTips = true;
      this._tbOpenIsoFile.Size = new System.Drawing.Size(694, 28);
      this._tbOpenIsoFile.TabIndex = 1;
      this._tbOpenIsoFile.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
      this._tbOpenIsoFile.Visible = false;
      this._tbOpenIsoFile.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
      // 
      // _btnOpenIsoFile
      // 
      this._btnOpenIsoFile.ImageIndex = 0;
      this._btnOpenIsoFile.Name = "btnOpenIsoFile";
      this._btnOpenIsoFile.Tag = "OpenIsoFile";
      this._btnOpenIsoFile.Text = "Открыть ISO-файл";
      // 
      // _imageList1
      // 
      this._imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_imageList1.ImageStream")));
      this._imageList1.TransparentColor = System.Drawing.Color.Transparent;
      this._imageList1.Images.SetKeyName(0, "fileopen.png");
      this._imageList1.Images.SetKeyName(1, "");
      // 
      // _openLogFileDlg
      // 
      this._openLogFileDlg.DefaultExt = "iso";
      this._openLogFileDlg.Filter = "файлы ISO|*.iso|Все файлы|*.*";
      this._openLogFileDlg.ReadOnlyChecked = true;
      this._openLogFileDlg.Title = "Открытие файла";
      // 
      // MainForm
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(694, 372);
      this.Controls.Add(this._tbOpenIsoFile);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.IsMdiContainer = true;
      this.Menu = this._mainMenu1;
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "Просмотр ISO-файлов";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      this.ResumeLayout(false);
      this.PerformLayout();

    }
    #endregion

    private void miOpenIso_Click(object sender, EventArgs e) {
      OpenIsoFile();
    }

    private void OpenIsoFile() {
      if (Settings.Default.openIsoFileDlg_FilterIndex > 0)
        _openIsoFileDlg.FilterIndex =
          Settings.Default.openIsoFileDlg_FilterIndex;
      if (_openIsoFileDlg.ShowDialog() != DialogResult.OK) return;
      new IsoFileForm(_openIsoFileDlg.FileName, this).Show();
      Settings.Default.openIsoFileDlg_FilterIndex =
        _openIsoFileDlg.FilterIndex;
      Settings.Default.Save();
    }

    private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e) {
      if ((string)e.Button.Tag == "OpenIsoFile") {
        OpenIsoFile();
      }
    }

    private void menuExit_Click(object sender, EventArgs e) {
      Close();
    }

    private void _miShowOpenIsoFileButton_Click(object sender, EventArgs e) {
      if (_miShowOpenIsoFileButton.Checked) {
        _miShowOpenIsoFileButton.Checked = false;
        _tbOpenIsoFile.Visible = false;
      } else {
        _miShowOpenIsoFileButton.Checked = true;
        _tbOpenIsoFile.Visible = true;
      }
      Settings.Default.tbOpenIsoFile_Visible = _miShowOpenIsoFileButton.Checked;
      Settings.Default.Save();
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
      Settings.Default.Bounds = DesktopBounds;
      Settings.Default.WindowState = WindowState;
      // persist location ,size and window state of the form on the desktop
      Settings.Default.BoundsSet = true;
      Settings.Default.Save();
    }

    private void miAbout_Click(object sender, EventArgs e) {
      new AboutDialog().ShowDialog();
    }

    private void miSelectFont_Click(object sender, EventArgs e) {
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
      foreach (var form in MdiChildren) {
        form.Font = dlg.Font;
      }
    }

    private void miEditOnEnter_Click(object sender, EventArgs e) {
      _miEditOnEnter.Checked = !_miEditOnEnter.Checked;
      Settings.Default.EditOnEnter = _miEditOnEnter.Checked;

      foreach (IsoFileForm form in MdiChildren) {
        form.EditOnEnter = _miEditOnEnter.Checked;
      }
    }

    private void _miNewFile_Click(object sender, EventArgs e) {
      new IsoFileForm(this).Show();
    }
  }
}
