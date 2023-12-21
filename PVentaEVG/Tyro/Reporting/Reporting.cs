using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using POSDLL.Reporting.Forms;

namespace POSDLL.Reporting
{
	public class Reporting
	{
		private static string subReportFileName;

		private static string subReportSQL;

		private static string subReportDataSetName;

		private string reportTitle = "";

		private string reportComments = "";

		private static string cnnStr;

		private string reportWindowTitle = "Reporte";

		private string sql = "";

		private string reportFileName = "";

		private string reportDataSetName = "";

		public string CnnStr
		{
			get
			{
				string str = POSDLL.Reporting.Reporting.cnnStr;
				return str;
			}
			set
			{
				POSDLL.Reporting.Reporting.cnnStr = value;
			}
		}

		public string ReportComments
		{
			get
			{
				string str = this.reportComments;
				return str;
			}
			set
			{
				this.reportComments = value;
			}
		}

		public string ReportDataSetName
		{
			get
			{
				string str = this.reportDataSetName;
				return str;
			}
			set
			{
				this.reportDataSetName = value;
			}
		}

		public string ReportFileName
		{
			get
			{
				string str = this.reportFileName;
				return str;
			}
			set
			{
				this.reportFileName = value;
			}
		}

		public string ReportTitle
		{
			get
			{
				string str = this.reportTitle;
				return str;
			}
			set
			{
				this.reportTitle = value;
			}
		}

		public string ReportWindowTitle
		{
			get
			{
				string str = this.reportWindowTitle;
				return str;
			}
			set
			{
				this.reportWindowTitle = value;
			}
		}

		public string SQL
		{
			get
			{
				string str = this.sql;
				return str;
			}
			set
			{
				this.sql = value;
			}
		}

		public string SubReportDataSetName
		{
			get
			{
				string str = POSDLL.Reporting.Reporting.subReportDataSetName;
				return str;
			}
			set
			{
				POSDLL.Reporting.Reporting.subReportDataSetName = value;
			}
		}

		public string SubReportFileName
		{
			get
			{
				string str = POSDLL.Reporting.Reporting.subReportFileName;
				return str;
			}
			set
			{
				POSDLL.Reporting.Reporting.subReportFileName = value;
			}
		}

		public string SubReportSQL
		{
			get
			{
				string str = POSDLL.Reporting.Reporting.subReportSQL;
				return str;
			}
			set
			{
				POSDLL.Reporting.Reporting.subReportSQL = value;
			}
		}

		static Reporting()
		{
			POSDLL.Reporting.Reporting.subReportFileName = "";
			POSDLL.Reporting.Reporting.subReportSQL = "";
			POSDLL.Reporting.Reporting.subReportDataSetName = "";
			POSDLL.Reporting.Reporting.cnnStr = "";
		}

		public Reporting()
		{
		}

		private static void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
		{
			OleDbConnection oleDbConnection = new OleDbConnection(POSDLL.Reporting.Reporting.cnnStr);
			string str = POSDLL.Reporting.Reporting.subReportSQL;
			try
			{
				try
				{
					oleDbConnection.Open();
					if (!File.Exists(POSDLL.Reporting.Reporting.subReportFileName))
					{
						throw new Exception(string.Format("No se encontró el archivo: {0}\nRevise por favor.", POSDLL.Reporting.Reporting.subReportFileName));
					}
					DataSet dataSet = new DataSet();
					OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(str, oleDbConnection);
					oleDbDataAdapter.Fill(dataSet, POSDLL.Reporting.Reporting.subReportDataSetName);
					e.DataSources.Add(new ReportDataSource(POSDLL.Reporting.Reporting.subReportDataSetName, dataSet.Tables[POSDLL.Reporting.Reporting.subReportDataSetName]));
				}
				catch (Exception exception)
				{
					throw exception;
				}
			}
			finally
			{
				oleDbConnection.Close();
			}
		}

		public void PrintPreview(string SQL, string ReportFileName, string ReportDataSetName)
		{
			this.sql = SQL;
			this.reportFileName = ReportFileName;
			this.reportDataSetName = ReportDataSetName;
			this.PrintPreview();
		}

		public void PrintPreview()
		{
			try
			{
				if (File.Exists(this.reportFileName))
				{
					DataSet dataSet = new DataSet();
					OleDbConnection oleDbConnection = new OleDbConnection(POSDLL.Reporting.Reporting.cnnStr);
					oleDbConnection.Open();
					dataSet.Clear();
					OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(this.sql, oleDbConnection);
					oleDbDataAdapter.Fill(dataSet, this.reportDataSetName);
					oleDbDataAdapter.Dispose();
					oleDbConnection.Dispose();
					if (dataSet.Tables[this.reportDataSetName].Rows.Count != 0)
					{
						frmReports frmReport = new frmReports();
						frmReport.Text = this.reportWindowTitle;
						frmReport.rvDoc.LocalReport.DataSources.Clear();
						frmReport.rvDoc.LocalReport.Dispose();
						frmReport.rvDoc.Reset();
						frmReport.rvDoc.LocalReport.DataSources.Add(new ReportDataSource(this.reportDataSetName, dataSet.Tables[this.reportDataSetName]));
						if (POSDLL.Reporting.Reporting.subReportFileName != "")
						{
							frmReport.rvDoc.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(POSDLL.Reporting.Reporting.LocalReport_SubreportProcessing);
						}
						frmReport.rvDoc.LocalReport.ReportPath = this.reportFileName;
						frmReport.rvDoc.LocalReport.EnableExternalImages = true;
						List<ReportParameter> reportParameters = new List<ReportParameter>();
						ReportParameter reportParameter = new ReportParameter();
						reportParameter.Name = "ReportComments";
						reportParameter.Values.Add(this.reportComments);
						reportParameters.Add(reportParameter);
						ReportParameter reportParameter1 = new ReportParameter();
						reportParameter1.Name = "ReportTitle";
						reportParameter1.Values.Add(this.reportTitle);
						reportParameters.Add(reportParameter1);
						frmReport.rvDoc.LocalReport.SetParameters(reportParameters);
						frmReport.rvDoc.SetDisplayMode(DisplayMode.PrintLayout);
						frmReport.ShowDialog();
						oleDbConnection.Close();
					}
					else
					{
						oleDbConnection.Close();
						MessageBox.Show("No hay datos para mostrar.", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
				}
				else
				{
					MessageBox.Show(string.Format("No se encontró el archivo {0}\nRevise por favor.", this.reportFileName), "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(string.Concat(exception.Message, "\n", exception.StackTrace), "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		public void SetSubReport(string SubReportSQL, string SubReportFileName, string SubReportDataSetName)
		{
			POSDLL.Reporting.Reporting.subReportSQL = SubReportSQL;
			POSDLL.Reporting.Reporting.subReportFileName = SubReportFileName;
			POSDLL.Reporting.Reporting.subReportDataSetName = SubReportDataSetName;
		}
	}
}