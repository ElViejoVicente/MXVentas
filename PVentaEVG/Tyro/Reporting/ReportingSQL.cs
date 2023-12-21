using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using POSDLL.Reporting.Forms;

namespace POSDLL.Reporting
{
	public class ReportingSQL
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
				string str = ReportingSQL.cnnStr;
				return str;
			}
			set
			{
				ReportingSQL.cnnStr = value;
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
				string str = ReportingSQL.subReportDataSetName;
				return str;
			}
			set
			{
				ReportingSQL.subReportDataSetName = value;
			}
		}

		public string SubReportFileName
		{
			get
			{
				string str = ReportingSQL.subReportFileName;
				return str;
			}
			set
			{
				ReportingSQL.subReportFileName = value;
			}
		}

		public string SubReportSQL
		{
			get
			{
				string str = ReportingSQL.subReportSQL;
				return str;
			}
			set
			{
				ReportingSQL.subReportSQL = value;
			}
		}

		static ReportingSQL()
		{
			ReportingSQL.subReportFileName = "";
			ReportingSQL.subReportSQL = "";
			ReportingSQL.subReportDataSetName = "";
			ReportingSQL.cnnStr = "";
		}

		public ReportingSQL()
		{
		}

		private static void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
		{
			SqlConnection sqlConnection = new SqlConnection(ReportingSQL.cnnStr);
			string str = ReportingSQL.subReportSQL;
			try
			{
				try
				{
					sqlConnection.Open();
					if (!File.Exists(ReportingSQL.subReportFileName))
					{
						throw new Exception(string.Format("No se encontró el archivo: {0}\nRevise por favor.", ReportingSQL.subReportFileName));
					}
					DataSet dataSet = new DataSet();
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(str, sqlConnection);
					sqlDataAdapter.Fill(dataSet, ReportingSQL.subReportDataSetName);
					e.DataSources.Add(new ReportDataSource(ReportingSQL.subReportDataSetName, dataSet.Tables[ReportingSQL.subReportDataSetName]));
				}
				catch (Exception exception)
				{
					throw exception;
				}
			}
			finally
			{
				sqlConnection.Close();
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
					SqlConnection sqlConnection = new SqlConnection(ReportingSQL.cnnStr);
					sqlConnection.Open();
					dataSet.Clear();
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(this.sql, sqlConnection);
					sqlDataAdapter.Fill(dataSet, this.reportDataSetName);
					sqlDataAdapter.Dispose();
					sqlConnection.Dispose();
					if (dataSet.Tables[this.reportDataSetName].Rows.Count != 0)
					{
						frmReports frmReport = new frmReports();
						frmReport.Text = this.reportWindowTitle;
						frmReport.rvDoc.LocalReport.DataSources.Clear();
						frmReport.rvDoc.LocalReport.Dispose();
						frmReport.rvDoc.Reset();
						frmReport.rvDoc.LocalReport.DataSources.Add(new ReportDataSource(this.reportDataSetName, dataSet.Tables[this.reportDataSetName]));
						if (ReportingSQL.subReportFileName != "")
						{
							frmReport.rvDoc.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(ReportingSQL.LocalReport_SubreportProcessing);
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
						sqlConnection.Close();
					}
					else
					{
						sqlConnection.Close();
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
			ReportingSQL.subReportSQL = SubReportSQL;
			ReportingSQL.subReportFileName = SubReportFileName;
			ReportingSQL.subReportDataSetName = SubReportDataSetName;
		}
	}
}