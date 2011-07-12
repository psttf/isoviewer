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
        Filename = dlg.FileName;
      }
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
      Filename = _isoFileForm.FileName;
    }

    internal void SetSaveExcept(IEnumerable<int> numbers) {
      rbSaveAllExceptSelected.Checked = true;
      tbRecordNumbers.Text = numbers.Aggregate("", (s, n) =>
        s + (n+1).ToString() + ", "
      );
    }

    public Func<string, Action<Action<int>>> SaveTask { get; private set; }

    private void btSave_Click(object sender, EventArgs e) {
      List<int> recNums;
      try {
        if (rbSaveAll.Checked) {
          SaveTask =
            filename => a => _isoFileForm.CurrentIsoFile.Save(filename, a);
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

          if (string.IsNullOrEmpty(Filename)) {
            throw new Exception("������� ���� � �����");
          }

          if (rbSaveAllExceptSelected.Checked)
            SaveTask = filename => a => _isoFileForm.CurrentIsoFile.
              SaveExcept(filename, recNums, a);
          else SaveTask = filename => a => _isoFileForm.CurrentIsoFile.
            SaveOnly(filename, recNums, a);
        } else {
          Helper.ReportError("������� ���� �� ���� �����");
        }
        DialogResult = DialogResult.OK;
      } catch (FormatException) {
        Helper.ReportError("������� ������ �����");
      } catch (OverflowException) {
        Helper.ReportError("������ ������ ���� � ��������� �� 1 �� "
          + _isoFileForm.CurrentIsoFile.Records.Count + " ������������");
      } catch (Exception exception) {
        Helper.ReportError(exception.Message);
      }
    }

    public string Filename {
      get { return tbPath.Text; }
      set { tbPath.Text = value; }
    }
  }
}