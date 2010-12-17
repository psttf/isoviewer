using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Ps.Iso;

namespace Ps.Iso.Viewer
{
	public partial class EditRecordDialog : Form
	{
		private PsIso isoFile;
		private int RecordNumber;

		public EditRecordDialog()
		{
			InitializeComponent();
		}

		/// <summary>
		/// ������� ������� ��������� ������� ������ ����������� ISO-�����
		/// </summary>
		/// <param name="isoFile">ISO-����</param>
		public EditRecordDialog(PsIso isoFile)
		{
			InitializeComponent();

			this.isoFile = isoFile;
			this.RecordNumber = isoFile.nCurRecord;
			gridFields.Fields = isoFile.GetCurRecordArrays();
			gridFields.FillGrid();
		}

		public string GetIsoBuffer()
		{
			PsIso iso = new PsIso();
			iso.Open("");
      foreach (object[] field in gridFields.Fields.GetRange(0,gridFields.Fields.Count - 1))
			{
				iso.AddField((string) field[0], (string) field[1]);
			}
			string result = iso.sIsoBuffer;
			iso.Close();
			return result;
		}

		private void btnSaveOne_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "����� ISO|*.iso|��� �����|*.*";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				//�������� �����
				try
				{
					StreamWriter newFile = new StreamWriter(
						new FileStream(dlg.FileName,
						FileMode.Create), Encoding.GetEncoding(1251));
					newFile.Write(GetIsoBuffer());
					newFile.Close();
					DialogResult = DialogResult.OK;
				}
				catch (Exception exception)
				{
					MessageBox.Show(exception.Message,
						"������",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);
				}
			}
		}

		private void btnSaveAll_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
      dlg.Filter = "����� ISO|*.iso|��� �����|*.*";
      if (dlg.ShowDialog() == DialogResult.OK)
			{
				//�������� �����
				try
				{
					StreamWriter newFile = new StreamWriter(
            new FileStream(dlg.FileName,
						  FileMode.Create),
            Encoding.GetEncoding(1251)
          );
					PsIso.SaveAllReplaceOne(isoFile, RecordNumber, GetIsoBuffer(), newFile);
					newFile.Close();
					DialogResult = DialogResult.OK;
				}
				catch (Exception exception)
				{
					MessageBox.Show(exception.Message,
						"������",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);
				}
			}
		}
	}
}