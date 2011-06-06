using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Ps.Iso.Viewer {
  public partial class SaveIsoDialog : Form {
    private readonly IsoFileForm _isoFileForm;

    public SaveIsoDialog(IsoFileForm isoFileForm) {
      InitializeComponent();

      _isoFileForm = isoFileForm;
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
          task = a => _isoFileForm.CurrentIsoFile.Save(tbPath.Text, a);
          SaveAndClose(task);
        } else if (!string.IsNullOrEmpty(tbRecordNumbers.Text)) {
          var strs = tbRecordNumbers.Text.Split(new[] { ',' });
          recNums = new List<int>(strs.Length);
          foreach (
            var num in strs.Where(s => s.Trim() != "").
              Select(t => Convert.ToInt32(t) - 1)
          ) {
            if ((num >= 0) &&
              (num <= _isoFileForm.CurrentIsoFile.Records.Count)) {
                recNums.Add(num);
              } else {
                throw new OverflowException();
              }
          }

          if (string.IsNullOrEmpty(tbPath.Text)) {
            throw new Exception("Введите путь к файлу");
          }

          if (rbSaveAllExceptSelected.Checked)
            task = a => _isoFileForm.CurrentIsoFile.
              SaveExcept(tbPath.Text, recNums, a);
          else task = a => _isoFileForm.CurrentIsoFile.
            SaveOnly(tbPath.Text, recNums, a);
          SaveAndClose(task);
        } else {
          Helper.ReportError("Введите хотя бы один номер");
        }
      } catch (FormatException) {
        Helper.ReportError("Неверно введен номер");
      } catch (OverflowException) {
        Helper.ReportError("Номера должны быть в диапазоне от 1 до "
          + _isoFileForm.CurrentIsoFile.Records.Count + " включительно");
      } catch (Exception exception) {
        Helper.ReportError(exception.Message);
      }
    }

    private void SaveAndClose(Action<Action<int>> task) {
      new TaskProcessWindow(task, "Сохранение").ShowDialog();
      _isoFileForm.UnsavedChanges = false;
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

    internal void SetSaveExcept(IEnumerable<int> numbers) {
      rbSaveAllExceptSelected.Checked = true;
      tbRecordNumbers.Text = numbers.Aggregate("", (s, n) =>
        s + (n+1).ToString() + ", "
      );
    }
  }
}