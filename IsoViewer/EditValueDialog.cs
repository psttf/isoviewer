using System.Windows.Forms;

namespace Ps.Iso.Viewer
{
  internal class EditValueDialog : Form
  {
    private TextBox _tbValue;
    private Button _btOK;
    private Button _btCancel;
  
    public EditValueDialog(string value) {
      InitializeComponent();
      Value = value;
    }

    public string Value {
      get { return _tbValue.Text; }
      set { _tbValue.Text = value; }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
      switch (keyData) {
        case (Keys.Control | Keys.Enter):
          return true;
        default: return false;
      }
    }

    #region Windows Form Designer generated code
    private void InitializeComponent() {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditValueDialog));
      this._tbValue = new System.Windows.Forms.TextBox();
      this._btOK = new System.Windows.Forms.Button();
      this._btCancel = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // _tbValue
      // 
      this._tbValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._tbValue.Location = new System.Drawing.Point(13, 13);
      this._tbValue.Multiline = true;
      this._tbValue.Name = "_tbValue";
      this._tbValue.Size = new System.Drawing.Size(448, 233);
      this._tbValue.TabIndex = 0;
      // 
      // _btOK
      // 
      this._btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this._btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this._btOK.Location = new System.Drawing.Point(305, 252);
      this._btOK.Name = "_btOK";
      this._btOK.Size = new System.Drawing.Size(75, 23);
      this._btOK.TabIndex = 1;
      this._btOK.Text = global::Ps.Iso.Viewer.Global.EditValueDialog_InitializeComponent_OK;
      this._btOK.UseVisualStyleBackColor = true;
      // 
      // _btCancel
      // 
      this._btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this._btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this._btCancel.Location = new System.Drawing.Point(386, 252);
      this._btCancel.Name = "_btCancel";
      this._btCancel.Size = new System.Drawing.Size(75, 23);
      this._btCancel.TabIndex = 2;
      this._btCancel.Text = global::Ps.Iso.Viewer.Global.EditValueDialog_InitializeComponent_btCancel;
      this._btCancel.UseVisualStyleBackColor = true;
      // 
      // EditValueDialog
      // 
      this.AcceptButton = this._btOK;
      this.CancelButton = this._btCancel;
      this.ClientSize = new System.Drawing.Size(473, 287);
      this.Controls.Add(this._btCancel);
      this.Controls.Add(this._btOK);
      this.Controls.Add(this._tbValue);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "EditValueDialog";
      this.Text = "Редактирование поля";
      this.ResumeLayout(false);
      this.PerformLayout();

    }
    #endregion
  }
}