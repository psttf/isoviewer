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
    private ToolBarButton _btnOpenIsoFile;
    private ToolBarButton _btnOpenLogFile;
    private ImageList _imageList1;
    private MenuItem _miOpenIso;
    private OpenFileDialog _openIsoFileDlg;
    private OpenFileDialog _openLogFileDlg;
    private MenuItem _menuExit;
    private MenuItem _menuItem4;
    private MenuItem _miShowOpenIsoFileButton;
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
      var settings = new Settings();
      if (settings.MainFormLeft > 0) {
        Left = settings.MainFormLeft;
      } else {
        StartPosition = FormStartPosition.WindowsDefaultBounds;
      }
      if (settings.MainFormTop > 0) {
        Top = settings.MainFormTop;
      } else {
        StartPosition = FormStartPosition.WindowsDefaultBounds;
      }
      if (settings.MainFormHeight > 0) {
        Height = settings.MainFormHeight;
      } else {
        StartPosition = FormStartPosition.WindowsDefaultBounds;
      }
      if (settings.MainFormWidth > 0) {
        Width = settings.MainFormWidth;
      } else {
        StartPosition = FormStartPosition.WindowsDefaultBounds;
      }

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
      this._openIsoFileDlg = new OpenFileDialog();
      this._mainMenu1 = new MainMenu(this.components);
      this._menuItem1 = new MenuItem();
      this._miOpenIso = new MenuItem();
      this._menuItem7 = new MenuItem();
      this._menuExit = new MenuItem();
      this._menuItem4 = new MenuItem();
      this._miShowOpenIsoFileButton = new MenuItem();
      this._menuItem2 = new MenuItem();
      this._miAbout = new MenuItem();
      this._tbOpenIsoFile = new ToolBar();
      this._btnOpenIsoFile = new ToolBarButton();
      this._btnOpenLogFile = new ToolBarButton();
      this._imageList1 = new ImageList(this.components);
      this._openLogFileDlg = new OpenFileDialog();
      this.SuspendLayout();
      // 
      // openIsoFileDlg
      // 
      this._openIsoFileDlg.DefaultExt = "iso";
      this._openIsoFileDlg.Filter = "файлы ISO|*.iso|Все файлы|*.*";
      this._openIsoFileDlg.ReadOnlyChecked = true;
      this._openIsoFileDlg.Title = "Открытие файла";
      // 
      // mainMenu1
      // 
      this._mainMenu1.MenuItems.AddRange(new MenuItem[] {
            this._menuItem1,
            this._menuItem4,
            this._menuItem2});
      // 
      // menuItem1
      // 
      this._menuItem1.Index = 0;
      this._menuItem1.MenuItems.AddRange(new MenuItem[] {
            this._miOpenIso,
            this._menuItem7,
            this._menuExit});
      this._menuItem1.MergeType = MenuMerge.MergeItems;
      this._menuItem1.Text = "Файл";
      // 
      // miOpenIso
      // 
      this._miOpenIso.Index = 0;
      this._miOpenIso.Text = "Открыть ISO-файл...";
      this._miOpenIso.Click += new System.EventHandler(this.miOpenIso_Click);
      // 
      // menuItem7
      // 
      this._menuItem7.Index = 1;
      this._menuItem7.MergeOrder = 2;
      this._menuItem7.Text = "-";
      // 
      // menuExit
      // 
      this._menuExit.Index = 2;
      this._menuExit.MergeOrder = 3;
      this._menuExit.Text = "Выход";
      this._menuExit.Click += new System.EventHandler(this.menuExit_Click);
      // 
      // menuItem4
      // 
      this._menuItem4.Index = 1;
      this._menuItem4.MenuItems.AddRange(new MenuItem[] {
            this._miShowOpenIsoFileButton});
      this._menuItem4.Text = "Вид";
      // 
      // miShowOpenIsoFileButton
      // 
      this._miShowOpenIsoFileButton.Index = 0;
      this._miShowOpenIsoFileButton.Text = "Кнопка \"Открыть ISO-файл\"";
      this._miShowOpenIsoFileButton.Click += new System.EventHandler(this.menuItem5_Click);
      // 
      // menuItem2
      // 
      this._menuItem2.Index = 2;
      this._menuItem2.MenuItems.AddRange(new MenuItem[] {
            this._miAbout});
      this._menuItem2.Text = "Справка";
      // 
      // miAbout
      // 
      this._miAbout.Index = 0;
      this._miAbout.Text = "О программе";
      this._miAbout.Click += new System.EventHandler(this.miAbout_Click);
      // 
      // tbOpenIsoFile
      // 
      this._tbOpenIsoFile.Appearance = ToolBarAppearance.Flat;
      this._tbOpenIsoFile.Buttons.AddRange(new ToolBarButton[] {
            this._btnOpenIsoFile,
            this._btnOpenLogFile});
      this._tbOpenIsoFile.DropDownArrows = true;
      this._tbOpenIsoFile.ImageList = this._imageList1;
      this._tbOpenIsoFile.Location = new System.Drawing.Point(0, 0);
      this._tbOpenIsoFile.Name = "_tbOpenIsoFile";
      this._tbOpenIsoFile.ShowToolTips = true;
      this._tbOpenIsoFile.Size = new System.Drawing.Size(694, 28);
      this._tbOpenIsoFile.TabIndex = 1;
      this._tbOpenIsoFile.TextAlign = ToolBarTextAlign.Right;
      this._tbOpenIsoFile.Visible = false;
      this._tbOpenIsoFile.ButtonClick += new ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
      // 
      // btnOpenIsoFile
      // 
      this._btnOpenIsoFile.ImageIndex = 0;
      this._btnOpenIsoFile.Name = "btnOpenIsoFile";
      this._btnOpenIsoFile.Tag = "OpenIsoFile";
      this._btnOpenIsoFile.Text = "Открыть ISO-файл";
      // 
      // btnOpenLogFile
      // 
      this._btnOpenLogFile.ImageIndex = 1;
      this._btnOpenLogFile.Name = "btnOpenLogFile";
      this._btnOpenLogFile.Tag = "OpenLogFile";
      this._btnOpenLogFile.Visible = false;
      // 
      // imageList1
      // 
      this._imageList1.ImageStream = ((ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
      this._imageList1.TransparentColor = System.Drawing.Color.Transparent;
      this._imageList1.Images.SetKeyName(0, "fileopen.png");
      this._imageList1.Images.SetKeyName(1, "");
      // 
      // openLogFileDlg
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
      this.StartPosition = FormStartPosition.Manual;
      this.Text = "Просмотр ISO-файлов";
      this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
      this.FormClosing += new FormClosingEventHandler(this.MainForm_FormClosing);
      this.ResumeLayout(false);
      this.PerformLayout();

    }
    #endregion

    private void miOpenIso_Click(object sender, EventArgs e) {
      OpenIsoFile();
    }

    private void OpenIsoFile() {
      if (_openIsoFileDlg.ShowDialog() == DialogResult.OK) {
        new IsoFileForm(_openIsoFileDlg.FileName, this).Show();
      }
    }

    private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e) {
      if ((string)e.Button.Tag == "OpenIsoFile") {
        OpenIsoFile();
      }
    }

    private void menuExit_Click(object sender, EventArgs e) {
      Close();
    }

    private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
      foreach (Form form in MdiChildren) {
        form.Close();
      }
    }

    private void menuItem5_Click(object sender, EventArgs e) {
      if (_miShowOpenIsoFileButton.Checked) {
        _miShowOpenIsoFileButton.Checked = false;
        _tbOpenIsoFile.Visible = false;
      } else {
        _miShowOpenIsoFileButton.Checked = true;
        _tbOpenIsoFile.Visible = true;
      }
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
      var settings = new Settings {
        MainFormHeight = Height,
        MainFormWidth = Width,
        MainFormTop = Top,
        MainFormLeft = Left
      };
      settings.Save();
    }

    private void miAbout_Click(object sender, EventArgs e) {
      new AboutDialog().ShowDialog();
    }
  }
}
