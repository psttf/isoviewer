//using System;
//using System.ComponentModel;
//using System.Text;
//using System.Windows.Forms;
//using System.IO;

//namespace Ps.Iso.Viewer {
//  [Obsolete]
//  public partial class EditRecordDialog : Form {
//    private readonly PsIso _isoFile;
//    private readonly int _recordNumber;

//    public EditRecordDialog() {
//      InitializeComponent();
//    }

//    /// <summary>
//    /// Текущей записью считается текущая запись переданного ISO-файла
//    /// </summary>
//    /// <param name="isoFile">ISO-файл</param>
//    public EditRecordDialog(PsIso isoFile) {
//      InitializeComponent();

//      _isoFile = isoFile;
//      _recordNumber = isoFile.nCurRecord;
//      gridFields.Fields = isoFile.GetCurRecordArrays();
//      gridFields.FillGrid();
//    }

//    /// <summary>
//    /// Текущей записью считается текущая запись переданного ISO-файла
//    /// </summary>
//    /// <param name="isoFile">ISO-файл</param>
//    /// <param name="sortedColumn">колонка, по которой производится
//    /// сортировка</param>
//    /// <param name="sortOrder">порядок сортировки</param>
//    public EditRecordDialog(PsIso isoFile, DataGridViewColumn sortedColumn,
//      SortOrder sortOrder)
//      : this(isoFile)
//    {
//      if (sortedColumn == null || sortOrder == SortOrder.None) return;
//      gridFields.gridFields.
//        Sort(sortedColumn, sortOrder == SortOrder.Ascending ?
//          ListSortDirection.Ascending : ListSortDirection.Descending);
//    }

//    public string GetIsoBuffer() {
//      var iso = new PsIso();
//      iso.Open("");
//      foreach (object[] field in gridFields.Fields.GetRange(0, gridFields.Fields.Count - 1)) {
//        iso.AddField((string)field[0], (string)field[1]);
//      }
//      var result = iso.sIsoBuffer;
//      iso.Close();
//      return result;
//    }

//    private void btnSaveOne_Click(object sender, EventArgs e)
//    {
//      var dlg = new SaveFileDialog {Filter = Global.IsoFileFilter};
//      switch (dlg.ShowDialog())
//      {
//        case DialogResult.OK:
//          try {
//            var newFile = new StreamWriter(
//              new FileStream(dlg.FileName,
//                             FileMode.Create), Encoding.GetEncoding(1251));
//            newFile.Write(GetIsoBuffer());
//            newFile.Close();
//            DialogResult = DialogResult.OK;
//          } catch (Exception exception) {
//            MessageBox.Show(exception.Message,
//                            Global.StrError,
//                            MessageBoxButtons.OK,
//                            MessageBoxIcon.Error);
//          }
//          break;
//      }
//    }

//    private void btnSaveAll_Click(object sender, EventArgs e) {
//      var dlg = new SaveFileDialog {Filter = Global.IsoFileFilter};
//      if (dlg.ShowDialog() == DialogResult.OK) {
//        //создание файла
//        try {
//          var newFile = new StreamWriter(
//            new FileStream(dlg.FileName,
//              FileMode.Create),
//            Encoding.GetEncoding(1251)
//          );
//          PsIso.SaveAllReplaceOne(_isoFile, _recordNumber, GetIsoBuffer(), newFile);
//          newFile.Close();
//          DialogResult = DialogResult.OK;
//        } catch (Exception exception) {
//          MessageBox.Show(exception.Message,
//            Global.StrError,
//            MessageBoxButtons.OK,
//            MessageBoxIcon.Error);
//        }
//      }
//    }
//  }
//}