using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Ps.Iso.Viewer
{
	public partial class SaveIsoDialog : Form
	{
		private PsIso isoFile;

		public SaveIsoDialog(PsIso isoFile)
		{
			InitializeComponent();

			this.isoFile = isoFile;
		}

		private void btBrowse_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.DefaultExt = "iso";
			dlg.Filter = "файлы ISO|*.iso|Все файлы|*.*";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				tbPath.Text = dlg.FileName;
			}
		}

		private void btSave_Click(object sender, EventArgs e)
		{
			List<int> recNums;
			try
			{
				if (!string.IsNullOrEmpty(tbRecordNumbers.Text))
				{
					string[] strs = tbRecordNumbers.Text.Split(new char[] { ',' });
					recNums = new List<int>(strs.Length);
					for (int i = 0; i < strs.Length; i++)
					{
						int num = Convert.ToInt32(strs[i]) ;
						if ((num >= 0) && (num <= isoFile.nRecordCount))
						{
							recNums.Add(num);
						}
						else
						{
							throw new OverflowException();
						}
					}

					if (string.IsNullOrEmpty(tbPath.Text))
					{
						throw new Exception("Введите путь к файлу");
					}

					//создание файла
					StreamWriter newFile = new StreamWriter(
						new FileStream(tbPath.Text,
						  FileMode.Create),Encoding.GetEncoding(1251));
					if (rbSaveAllExceptSelected.Checked)
					{
						PsIso.SaveAllExceptSelected(isoFile, recNums, newFile);
					}
					else
					{
						PsIso.SaveSelected(isoFile, recNums, newFile);
					}
					newFile.Close();

					Close();
				}
				else
				{
					IsoFileForm.PrintError("Введите хотя бы один номер");
				}
			}
			catch (FormatException)
			{
				IsoFileForm.PrintError("Неверно введен номер");
			}
			catch (OverflowException)
			{
				IsoFileForm.PrintError("Номера должны быть в диапазоне от 0 до "
					+ isoFile.nRecordCount.ToString() + " включительно");
			}
			catch (Exception exception)
			{
				IsoFileForm.PrintError(exception.Message);
			}
		}

		private void btCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}