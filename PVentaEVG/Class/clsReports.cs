using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using POSDLL; using POSDLL.Windows.Forms; using POSDLL.Security; using POSDLL.Reporting; using POSDLL.Ticket;
using Microsoft.Reporting.WinForms;
using System.Windows.Forms;

namespace POSApp.Class
{
    public class clsReports
    {
        static string subReportFileName = "";

        public String SubReportFileName {
            get { return subReportFileName; }
            set { subReportFileName = value; }
        }

        static string  subReportSQL="";

        public String SubReportSQL{
            get { return subReportSQL; }
            set { subReportSQL = value; }
        }
        
        static string  subReportDataSetName="";

        public String SubReportDataSetName {
            get { return subReportDataSetName; }
            set { subReportDataSetName = value; }
        }

        public void ImprimeReporte(string prmSQL, string prmReportComments, string prmReportName, string prmDataSetName)
        {
            try
            {
                string _FileName = AppSettings.GetValue("Config", "ReportsFolder", Application.StartupPath);
                
                _FileName += "\\"+ prmReportName +".rdlc";
                if (!File.Exists(_FileName))
                {
                    MessageBox.Show(String.Format("Arquivo não encontrado {0}\nRevise por favor.", _FileName),
                        "Informações do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                DataSet dsReporte = new DataSet(); //Datset para el reporte
                OleDbConnection cnnReporte = new OleDbConnection(Class.clsMain.CnnStr);
                cnnReporte.Open();
                dsReporte.Clear();//limpiamos el dataset
                OleDbDataAdapter daReporte =
                    new OleDbDataAdapter(prmSQL, cnnReporte);
                daReporte.Fill(dsReporte, prmDataSetName);
                daReporte.Dispose();
                cnnReporte.Dispose();
                //ya tenoemos la info en el DataSet, ahora cargamos el reporte

                if (dsReporte.Tables[prmDataSetName].Rows.Count == 0)
                {
                    cnnReporte.Close();
                    MessageBox.Show("Não há dados para mostrar.", "Informações do Sistema",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return;
                }
                Forms.frmReports frm = new Forms.frmReports();
                frm.rvDoc.LocalReport.DataSources.Clear();
                frm.rvDoc.LocalReport.Dispose();
                frm.rvDoc.Reset();
                frm.rvDoc.LocalReport.DataSources.Add(new ReportDataSource(prmDataSetName, dsReporte.Tables[prmDataSetName]));
                if (subReportFileName != "") {
                    frm.rvDoc.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
                }
                frm.rvDoc.LocalReport.ReportPath = _FileName;

                frm.rvDoc.LocalReport.EnableExternalImages = true;

                List<ReportParameter> param = new List<ReportParameter>();
               //comments
                    ReportParameter pReportComments = new ReportParameter();
                    pReportComments.Name = "ReportComments";
                    pReportComments.Values.Add(prmReportComments);
                    param.Add(pReportComments);
                frm.rvDoc.LocalReport.SetParameters(param);
                frm.rvDoc.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                //frm.rvDoc.RefreshReport();
                frm.ShowDialog();

                cnnReporte.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Loading Ticket Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        static void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            //aqui llamamos los subreportes
            string _fileName = AppSettings.GetValue("Config", "ReportsFolder", Application.StartupPath) + "\\" + subReportFileName;
            if (!File.Exists(_fileName))
            {
                MessageBox.Show(String.Format("Arquivo não encontrado {0}\nRevise por favor.", _fileName),
                        "Informações do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //AHORA MOSTRAMOS EL REPORTE

            string varSQL_HIJOS = subReportSQL;
            OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
            cnn.Open();
            DataSet dsReporte = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(varSQL_HIJOS, cnn);
            da.Fill(dsReporte, subReportDataSetName);
            if (dsReporte.Tables[subReportDataSetName].Rows.Count == 0)
            {
                cnn.Close();
                MessageBox.Show("Não há dados para mostrar.", "Informações do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            e.DataSources.Add(new ReportDataSource(subReportDataSetName, dsReporte.Tables[subReportDataSetName]));
            cnn.Close();
        } 
    }
}
