namespace Ps.Iso.Viewer
{
  partial class AboutDialog
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutDialog));
      this.lblTitleAndVersion = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.lblShapkin = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.lnkEmail = new System.Windows.Forms.LinkLabel();
      this.lnkToViniti = new System.Windows.Forms.LinkLabel();
      this.label1 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.llLGPLEn = new System.Windows.Forms.LinkLabel();
      this.llLGPLRu = new System.Windows.Forms.LinkLabel();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.lblKrutikov = new System.Windows.Forms.Label();
      this.lblYear = new System.Windows.Forms.Label();
      this.llISOViewer = new System.Windows.Forms.LinkLabel();
      this.SuspendLayout();
      // 
      // lblTitleAndVersion
      // 
      this.lblTitleAndVersion.AutoSize = true;
      this.lblTitleAndVersion.Location = new System.Drawing.Point(12, 9);
      this.lblTitleAndVersion.Name = "lblTitleAndVersion";
      this.lblTitleAndVersion.Size = new System.Drawing.Size(315, 13);
      this.lblTitleAndVersion.TabIndex = 0;
      this.lblTitleAndVersion.Text = "Программа просмотра файлов в формате ISO 2709, версия ";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 65);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(70, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "Разработка:";
      // 
      // lblShapkin
      // 
      this.lblShapkin.AutoSize = true;
      this.lblShapkin.Location = new System.Drawing.Point(89, 65);
      this.lblShapkin.Name = "lblShapkin";
      this.lblShapkin.Size = new System.Drawing.Size(193, 13);
      this.lblShapkin.TabIndex = 2;
      this.lblShapkin.Text = "Шапкин П. А.(                                     ),";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(12, 155);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(495, 39);
      this.label4.TabIndex = 3;
      this.label4.Text = resources.GetString("label4.Text");
      // 
      // button1
      // 
      this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.button1.Location = new System.Drawing.Point(434, 284);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 4;
      this.button1.Text = "Закрыть";
      this.button1.UseVisualStyleBackColor = true;
      // 
      // lnkEmail
      // 
      this.lnkEmail.AutoSize = true;
      this.lnkEmail.Location = new System.Drawing.Point(161, 65);
      this.lnkEmail.Name = "lnkEmail";
      this.lnkEmail.Size = new System.Drawing.Size(111, 13);
      this.lnkEmail.TabIndex = 5;
      this.lnkEmail.TabStop = true;
      this.lnkEmail.Text = "p.shapkin@gmail.com";
      this.lnkEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEmail_LinkClicked);
      // 
      // lnkToViniti
      // 
      this.lnkToViniti.AutoSize = true;
      this.lnkToViniti.Location = new System.Drawing.Point(89, 132);
      this.lnkToViniti.Name = "lnkToViniti";
      this.lnkToViniti.Size = new System.Drawing.Size(98, 13);
      this.lnkToViniti.TabIndex = 6;
      this.lnkToViniti.TabStop = true;
      this.lnkToViniti.Text = "http://www.viniti.ru";
      this.lnkToViniti.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkToViniti_LinkClicked);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(89, 119);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(343, 13);
      this.label1.TabIndex = 9;
      this.label1.Text = "Всероссийский институт научной и технической информации РАН";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 249);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(458, 13);
      this.label3.TabIndex = 10;
      this.label3.Text = "Данный программный продукт распространяется «КАК ЕСТЬ» без каких-либо гарантий";
      // 
      // llLGPLEn
      // 
      this.llLGPLEn.AutoSize = true;
      this.llLGPLEn.Location = new System.Drawing.Point(32, 204);
      this.llLGPLEn.Name = "llLGPLEn";
      this.llLGPLEn.Size = new System.Drawing.Size(197, 13);
      this.llLGPLEn.TabIndex = 11;
      this.llLGPLEn.TabStop = true;
      this.llLGPLEn.Text = "http://www.gnu.org/copyleft/lesser.html";
      this.llLGPLEn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
      // 
      // llLGPLRu
      // 
      this.llLGPLRu.AutoSize = true;
      this.llLGPLRu.Location = new System.Drawing.Point(32, 222);
      this.llLGPLRu.Name = "llLGPLRu";
      this.llLGPLRu.Size = new System.Drawing.Size(328, 13);
      this.llLGPLRu.TabIndex = 12;
      this.llLGPLRu.TabStop = true;
      this.llLGPLRu.Text = "http://ru.wikisource.org/wiki/GNU_Lesser_General_Public_License";
      this.llLGPLRu.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llLGPLRu_LinkClicked);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(235, 204);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(39, 13);
      this.label5.TabIndex = 13;
      this.label5.Text = "(англ.)";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(366, 222);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(33, 13);
      this.label6.TabIndex = 14;
      this.label6.Text = "(рус.)";
      // 
      // lblKrutikov
      // 
      this.lblKrutikov.AutoSize = true;
      this.lblKrutikov.Location = new System.Drawing.Point(89, 78);
      this.lblKrutikov.Name = "lblKrutikov";
      this.lblKrutikov.Size = new System.Drawing.Size(80, 13);
      this.lblKrutikov.TabIndex = 15;
      this.lblKrutikov.Text = "Крутиков Б. В.";
      // 
      // lblYear
      // 
      this.lblYear.AutoSize = true;
      this.lblYear.Location = new System.Drawing.Point(89, 100);
      this.lblYear.Name = "lblYear";
      this.lblYear.Size = new System.Drawing.Size(103, 13);
      this.lblYear.TabIndex = 16;
      this.lblYear.Text = "2007-{$currentYear}";
      // 
      // llISOViewer
      // 
      this.llISOViewer.AutoSize = true;
      this.llISOViewer.Location = new System.Drawing.Point(12, 32);
      this.llISOViewer.Name = "llISOViewer";
      this.llISOViewer.Size = new System.Drawing.Size(185, 13);
      this.llISOViewer.TabIndex = 17;
      this.llISOViewer.TabStop = true;
      this.llISOViewer.Text = "http://code.google.com/p/isoviewer/";
      this.llISOViewer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llISOViewer_LinkClicked);
      // 
      // AboutDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(521, 319);
      this.Controls.Add(this.llISOViewer);
      this.Controls.Add(this.lblYear);
      this.Controls.Add(this.lblKrutikov);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.llLGPLRu);
      this.Controls.Add(this.llLGPLEn);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.lnkToViniti);
      this.Controls.Add(this.lnkEmail);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.lblShapkin);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.lblTitleAndVersion);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "AboutDialog";
      this.Text = "О программе";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblTitleAndVersion;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label lblShapkin;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.LinkLabel lnkEmail;
    private System.Windows.Forms.LinkLabel lnkToViniti;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.LinkLabel llLGPLEn;
    private System.Windows.Forms.LinkLabel llLGPLRu;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label lblKrutikov;
    private System.Windows.Forms.Label lblYear;
    private System.Windows.Forms.LinkLabel llISOViewer;
  }
}