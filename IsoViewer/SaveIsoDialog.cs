using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Ps.Iso.Viewer {
  public partial class SaveIsoDialog : Form {
    private readonly IsoFile _isoFile;

    public SaveIsoDialog(IsoFile isoFile) {
      InitializeComponent();

      _isoFile = isoFile;
    }

    private void btBrowse_Click(object sender, EventArgs e) {
      var dlg = new SaveFileDialog {
        DefaultExt = "iso",
        Filter = Global.IsoFileFilter
      };
      if (dlg.ShowDialog() == DialogResult.OK) {
        tbPath.Text = dlg.FileName;
      }
    }

    private void btSave_Click(object sender, EventArgs e) {
      List<int> recNums;
      try {
        Action<Action<int>> task;
        if (rbSaveAll.Checked) {
          task = a => _isoFile.Save(tbPath.Text, a);
          SaveAndClose(task);
        } else if (!string.IsNullOrEmpty(tbRecordNumbers.Text)) {
          var strs = tbRecordNumbers.Text.Split(new[] { ',' });
          recNums = new List<int>(strs.Length);
          foreach (var num in strs.Select(t => Convert.ToInt32(t))) {
            if ((num >= 0) && (num <= _isoFile.Records.Count)) {
              recNums.Add(num);
            } else {
              throw new OverflowException();
            }
          }

          if (string.IsNullOrEmpty(tbPath.Text)) {
            throw new Exception("Введите путь к файлу");
          }

          if (rbSaveAllExceptSelected.Checked)
            task = a => _isoFile.SaveExcept(tbPath.Text, recNums, a);
          else task = a => _isoFile.SaveOnly(tbPath.Text, recNums, a);
          SaveAndClose(task);
        } else {
          Helper.ReportError("Введите хотя бы один номер");
        }
      } catch (FormatException) {
        Helper.ReportError("Неверно введен номер");
      } catch (OverflowException) {
        Helper.ReportError("Номера должны быть в диапазоне от 0 до "
          + _isoFile.Records.Count + " включительно");
      } catch (Exception exception) {
        Helper.ReportError(exception.Message);
      }
    }

    private void SaveAndClose(Action<Action<int>> task) {
      new TaskProcessWindow(task, "Сохранение").ShowDialog();
      Close();
    }

    private void btCancel_Click(object sender, EventArgs e) {
      Close();
    }

    private void rbSaveAllExceptSelected_CheckedChanged(
      object sender,
      EventArgs e
    ) {
      UpdateTbRecordNumbersEnabled();
    }

    private void UpdateTbRecordNumbersEnabled()
    {
      tbRecordNumbers.Enabled = !rbSaveAll.Checked;
    }

    private void rbSaveAll_CheckedChanged(object sender, EventArgs e) {
      UpdateTbRecordNumbersEnabled();
    }

    private void rbSaveOnlySelected_CheckedChanged(object sender, EventArgs e) {
      UpdateTbRecordNumbersEnabled();
    }

    private void SaveIsoDialog_Shown(object sender, EventArgs e) {
      UpdateTbRecordNumbersEnabled();
    }
  }
}