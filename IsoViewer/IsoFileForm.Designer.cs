using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Ps.Win.Controls;

namespace Ps.Iso.Viewer {
  /// <summary>
  /// Summary description for IsoFileForm.
  /// </summary>
  partial class IsoFileForm {
    private IContainer components;

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
    private Button _btnFirst;
    private Button _btnLast;
    private IsoRecordGrid _gridFields;
    private Panel _panel2;
    private TextBox _tbSearchKey;
    private Label _label5;
    private Button _btDelete;
    private Button _btInsertAfter;
    private Button _btInsertBefore;
    private ToolTip _toolTip;

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
      this._splitContainer1.Location = new System.Drawing.Point(0, 25);
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
      this._splitContainer1.Size = new System.Drawing.Size(692, 371);
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
      this._gridFields.Size = new System.Drawing.Size(692, 317);
      this._gridFields.TabIndex = 22;
      this._gridFields.WasEdited = false;
      // 
      // _panel3
      // 
      this._panel3.Controls.Add(this._tbQuery);
      this._panel3.Controls.Add(this._panel5);
      this._panel3.Controls.Add(this._panel2);
      this._panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
      this._panel3.Location = new System.Drawing.Point(0, 345);
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
      // IsoFileForm
      // 
      this.AcceptButton = this._btJump;
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(692, 396);
      this.Controls.Add(this._splitContainer1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "IsoFileForm";
      this.Text = "ISO-файл";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IsoFileForm_FormClosing);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IsoFileForm_KeyDown);
      this.Controls.SetChildIndex(this._splitContainer1, 0);
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
      this.PerformLayout();

    }
    #endregion
  }
}
