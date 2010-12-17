using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Ps.Iso.Viewer.Properties;

namespace Ps.Iso.Viewer
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem miAbout;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.ToolBar tbOpenIsoFile;
		private System.Windows.Forms.ToolBarButton btnOpenIsoFile;
		private System.Windows.Forms.ToolBarButton btnOpenLogFile;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.MenuItem miOpenIso;
		private System.Windows.Forms.OpenFileDialog openIsoFileDlg;
		private System.Windows.Forms.OpenFileDialog openLogFileDlg;
		private System.Windows.Forms.MenuItem menuExit;
		private MenuItem menuItem4;
		private MenuItem miShowOpenIsoFileButton;
		private System.ComponentModel.IContainer components;

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			Init(null);
		}

		public MainForm(string fileName)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			Init(fileName);
		}

		private void Init(string fileName)
		{
			Settings settings = new Settings();
			if (settings.MainFormLeft > 0)
			{
				Left = settings.MainFormLeft;
			}
			else
			{
				StartPosition = FormStartPosition.WindowsDefaultBounds;
			}
			if (settings.MainFormTop > 0)
			{
				Top = settings.MainFormTop;
			}
			else
			{
				StartPosition = FormStartPosition.WindowsDefaultBounds;
			}
			if (settings.MainFormHeight > 0)
			{
				Height = settings.MainFormHeight;
			}
			else
			{
				StartPosition = FormStartPosition.WindowsDefaultBounds;
			}
			if (settings.MainFormWidth > 0)
			{
				Width = settings.MainFormWidth;
			}
			else
			{
				StartPosition = FormStartPosition.WindowsDefaultBounds;
			}

			if (fileName != null)
			{
				new IsoFileForm(fileName, this).Show();
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.openIsoFileDlg = new System.Windows.Forms.OpenFileDialog();
      this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
      this.menuItem1 = new System.Windows.Forms.MenuItem();
      this.miOpenIso = new System.Windows.Forms.MenuItem();
      this.menuItem7 = new System.Windows.Forms.MenuItem();
      this.menuExit = new System.Windows.Forms.MenuItem();
      this.menuItem4 = new System.Windows.Forms.MenuItem();
      this.miShowOpenIsoFileButton = new System.Windows.Forms.MenuItem();
      this.menuItem2 = new System.Windows.Forms.MenuItem();
      this.miAbout = new System.Windows.Forms.MenuItem();
      this.tbOpenIsoFile = new System.Windows.Forms.ToolBar();
      this.btnOpenIsoFile = new System.Windows.Forms.ToolBarButton();
      this.btnOpenLogFile = new System.Windows.Forms.ToolBarButton();
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.openLogFileDlg = new System.Windows.Forms.OpenFileDialog();
      this.SuspendLayout();
      // 
      // openIsoFileDlg
      // 
      this.openIsoFileDlg.DefaultExt = "iso";
      this.openIsoFileDlg.Filter = "файлы ISO|*.iso|Все файлы|*.*";
      this.openIsoFileDlg.ReadOnlyChecked = true;
      this.openIsoFileDlg.Title = "Открытие файла";
      // 
      // mainMenu1
      // 
      this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem4,
            this.menuItem2});
      // 
      // menuItem1
      // 
      this.menuItem1.Index = 0;
      this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miOpenIso,
            this.menuItem7,
            this.menuExit});
      this.menuItem1.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
      this.menuItem1.Text = "Файл";
      // 
      // miOpenIso
      // 
      this.miOpenIso.Index = 0;
      this.miOpenIso.Text = "Открыть ISO-файл...";
      this.miOpenIso.Click += new System.EventHandler(this.miOpenIso_Click);
      // 
      // menuItem7
      // 
      this.menuItem7.Index = 1;
      this.menuItem7.MergeOrder = 2;
      this.menuItem7.Text = "-";
      // 
      // menuExit
      // 
      this.menuExit.Index = 2;
      this.menuExit.MergeOrder = 3;
      this.menuExit.Text = "Выход";
      this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
      // 
      // menuItem4
      // 
      this.menuItem4.Index = 1;
      this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miShowOpenIsoFileButton});
      this.menuItem4.Text = "Вид";
      // 
      // miShowOpenIsoFileButton
      // 
      this.miShowOpenIsoFileButton.Index = 0;
      this.miShowOpenIsoFileButton.Text = "Кнопка \"Открыть ISO-файл\"";
      this.miShowOpenIsoFileButton.Click += new System.EventHandler(this.menuItem5_Click);
      // 
      // menuItem2
      // 
      this.menuItem2.Index = 2;
      this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miAbout});
      this.menuItem2.Text = "Справка";
      // 
      // miAbout
      // 
      this.miAbout.Index = 0;
      this.miAbout.Text = "О программе";
      this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
      // 
      // tbOpenIsoFile
      // 
      this.tbOpenIsoFile.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
      this.tbOpenIsoFile.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.btnOpenIsoFile,
            this.btnOpenLogFile});
      this.tbOpenIsoFile.DropDownArrows = true;
      this.tbOpenIsoFile.ImageList = this.imageList1;
      this.tbOpenIsoFile.Location = new System.Drawing.Point(0, 0);
      this.tbOpenIsoFile.Name = "tbOpenIsoFile";
      this.tbOpenIsoFile.ShowToolTips = true;
      this.tbOpenIsoFile.Size = new System.Drawing.Size(694, 28);
      this.tbOpenIsoFile.TabIndex = 1;
      this.tbOpenIsoFile.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
      this.tbOpenIsoFile.Visible = false;
      this.tbOpenIsoFile.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
      // 
      // btnOpenIsoFile
      // 
      this.btnOpenIsoFile.ImageIndex = 0;
      this.btnOpenIsoFile.Name = "btnOpenIsoFile";
      this.btnOpenIsoFile.Tag = "OpenIsoFile";
      this.btnOpenIsoFile.Text = "Открыть ISO-файл";
      // 
      // btnOpenLogFile
      // 
      this.btnOpenLogFile.ImageIndex = 1;
      this.btnOpenLogFile.Name = "btnOpenLogFile";
      this.btnOpenLogFile.Tag = "OpenLogFile";
      this.btnOpenLogFile.Visible = false;
      // 
      // imageList1
      // 
      this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList1.Images.SetKeyName(0, "fileopen.png");
      this.imageList1.Images.SetKeyName(1, "");
      // 
      // openLogFileDlg
      // 
      this.openLogFileDlg.DefaultExt = "iso";
      this.openLogFileDlg.Filter = "файлы ISO|*.iso|Все файлы|*.*";
      this.openLogFileDlg.ReadOnlyChecked = true;
      this.openLogFileDlg.Title = "Открытие файла";
      // 
      // MainForm
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(694, 372);
      this.Controls.Add(this.tbOpenIsoFile);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.IsMdiContainer = true;
      this.Menu = this.mainMenu1;
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "Просмотр ISO-файлов";
      this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      this.ResumeLayout(false);
      this.PerformLayout();

		}
		#endregion

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{}

		private void miOpenIso_Click(object sender, System.EventArgs e)
		{
			OpenIsoFile();
		}

		private void OpenIsoFile()
		{
			// TODO: создавать здесь новый диалог
			if (openIsoFileDlg.ShowDialog() == DialogResult.OK)
			{
				new IsoFileForm(openIsoFileDlg.FileName, this).Show();
			}
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if ((string) e.Button.Tag == "OpenIsoFile")
			{
				OpenIsoFile();
			}
		}

		private void menuExit_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			foreach (Form form in MdiChildren)
			{
				form.Close();
			}
		}

		private void menuItem5_Click(object sender, EventArgs e)
		{
			if (miShowOpenIsoFileButton.Checked)
			{
				miShowOpenIsoFileButton.Checked = false;
				tbOpenIsoFile.Visible = false;
			}
			else
			{
				miShowOpenIsoFileButton.Checked = true;
				tbOpenIsoFile.Visible = true;
			}
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Settings settings = new Settings();
			settings.MainFormHeight = Height;
			settings.MainFormWidth = Width;
			settings.MainFormTop = Top;
			settings.MainFormLeft = Left;
			settings.Save();
		}

    private void miAbout_Click(object sender, EventArgs e)
    {
      new AboutDialog().ShowDialog();
    }
	}
}
