using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace POSDLL.Utilities
{
	public class ExportListView
	{
		private bool success = false;

		public bool Success
		{
			get
			{
				bool flag = this.success;
				return flag;
			}
		}

		public ExportListView()
		{
		}

		public bool ExportToCSV(ListView myList, string pName)
		{
			bool flag;
			try
			{
				string[] str = new string[] { pName, "_", null, null, null, null, null, null };
				int year = DateTime.Now.Year;
				str[2] = year.ToString();
				year = DateTime.Now.Month;
				str[3] = year.ToString();
				year = DateTime.Now.Day;
				str[4] = year.ToString();
				year = DateTime.Now.Hour;
				str[5] = year.ToString();
				year = DateTime.Now.Minute;
				str[6] = year.ToString();
				year = DateTime.Now.Second;
				str[7] = year.ToString();
				string _FileName = string.Concat(str);
				SaveFileDialog saveFileDialog1 = new SaveFileDialog();
				saveFileDialog1.Filter = "CSV files (*.csv)|*.csv";
				saveFileDialog1.FileName = _FileName;
				saveFileDialog1.Title = "Export to Excel";
				StringBuilder sb = new StringBuilder();
				foreach (ColumnHeader ch in myList.Columns)
				{
					sb.Append(string.Concat(ch.Text, ","));
				}
				sb.AppendLine();
				foreach (ListViewItem lvi in myList.Items)
				{
					foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
					{
						if (!(lvs.Text.Trim() == string.Empty))
						{
							sb.Append(string.Concat(lvs.Text, ","));
						}
						else
						{
							sb.Append(" ,");
						}
					}
					sb.AppendLine();
				}
				if (saveFileDialog1.ShowDialog() == DialogResult.OK)
				{
					StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
					sw.Write(sb.ToString());
					sw.Close();
				}
				flag = true;
			}
			catch (Exception exception)
			{
				throw exception;
			}
			return flag;
		}

		public bool ExportToExcel(ListView lv, string pName)
		{
			int col;
			bool flag;
			try
			{
				string[] str = new string[] { pName, "_", null, null, null, null, null, null };
				int year = DateTime.Now.Year;
				str[2] = year.ToString();
				year = DateTime.Now.Month;
				str[3] = year.ToString();
				year = DateTime.Now.Day;
				str[4] = year.ToString();
				year = DateTime.Now.Hour;
				str[5] = year.ToString();
				year = DateTime.Now.Minute;
				str[6] = year.ToString();
				year = DateTime.Now.Second;
				str[7] = year.ToString();
				string _FileName = string.Concat(str);
				SaveFileDialog saveFileDialog1 = new SaveFileDialog();
				saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";
				saveFileDialog1.FileName = _FileName;
				saveFileDialog1.Title = "Export to Excel";
				string[] st = new string[lv.Columns.Count];
				if (saveFileDialog1.ShowDialog() == DialogResult.OK)
				{
					StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false);
					sw.AutoFlush = true;
					for (col = 0; col < lv.Columns.Count; col++)
					{
						sw.Write(string.Concat("\t", lv.Columns[col].Text.ToString()));
					}
					int rowIndex = 1;
					int row = 0;
					string st1 = "";
					for (row = 0; row < lv.Items.Count; row++)
					{
						if (rowIndex <= lv.Items.Count)
						{
							rowIndex++;
							st1 = "\n";
						}
						for (col = 0; col < lv.Columns.Count; col++)
						{
							st1 = string.Concat(st1, "\t", lv.Items[row].SubItems[col].Text.ToString());
						}
						sw.Write(st1);
					}
					sw.Close();
				}
				if ((new FileInfo(saveFileDialog1.FileName)).Exists)
				{
					this.success = true;
				}
				flag = true;
			}
			catch (Exception exception)
			{
				throw exception;
			}
			return flag;
		}
	}
}