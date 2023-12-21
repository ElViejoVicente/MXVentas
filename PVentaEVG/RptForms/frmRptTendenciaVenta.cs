using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSDLL; using POSDLL.Windows.Forms; using POSDLL.Security; using POSDLL.Reporting; using POSDLL.Ticket;
using Microsoft.Reporting.WinForms;
using System.IO;
namespace POSApp.Forms
{
    public partial class frmRptTendenciaVenta : Telerik.WinControls.UI.RadForm
    {
        private static frmRptTendenciaVenta m_FormDefInstance;
        public static frmRptTendenciaVenta DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmRptTendenciaVenta();
                return m_FormDefInstance;
            }
            set { m_FormDefInstance = value; }
        }
        public frmRptTendenciaVenta()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string varComments = "Ventas entre "+ dtpFECHA_INI.Value.ToLongDateString() + " y " + dtpFECHA_FIN.Value.ToLongDateString();
            VerReporte(ISODates.MSAccessDateINI(dtpFECHA_INI.Value),
                ISODates.MSAccessDateFIN(dtpFECHA_FIN.Value), varComments);
        }
  
        public static void VerReporte(string prmFECHA_INI, string prmFECHA_FIN, string prmComments)
        {
            try
            {

                string _fileName = AppSettings.GetValue("Config", "ReportsFolder", Application.StartupPath) + "\\rptTendenciaVenta.rdlc";
                if (!File.Exists(_fileName))
                {
                    MessageBox.Show(String.Format("No se encuentra \n{0}\nRevise por favor", _fileName));
                    return;
                }
                //AHORA MOSTRAMOS EL REPORTE
                string varSQL_PADRE = "SELECT * FROM  [V_TENDENCIA_VENTA] " +
                    " WHERE FECHA BETWEEN  #" + prmFECHA_INI + "# AND #" + prmFECHA_FIN + "#";
                
                OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
                cnn.Open();
                DataSet dsReporte = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter(varSQL_PADRE, cnn);
                da.Fill(dsReporte, "dsTENDENCIA_VENTA");
                if (dsReporte.Tables["dsTENDENCIA_VENTA"].Rows.Count == 0)
                {
                    cnn.Close();
                    MessageBox.Show("No hay Datos");
                    return;
                }

                Forms.frmReports frm = new Forms.frmReports();

                frm.rvDoc.LocalReport.DataSources.Clear();
                frm.rvDoc.LocalReport.Dispose();
                frm.rvDoc.Reset();
                frm.rvDoc.LocalReport.DataSources.Add(new ReportDataSource("dsTENDENCIA_VENTA", dsReporte.Tables["dsTENDENCIA_VENTA"]));
                
                frm.rvDoc.LocalReport.ReportPath = _fileName;
                ////parametros
                List<ReportParameter> param = new List<ReportParameter>();
                ReportParameter pComments = new ReportParameter();
                pComments.Name = "prmComments";
                pComments.Values.Add(prmComments);
                param.Add(pComments);                
                //agregamos los parametros a la coleccion
                frm.rvDoc.LocalReport.SetParameters(param);
                frm.rvDoc.RefreshReport();
                frm.ShowDialog();
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Error loading report", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void frmRptTendenciaVenta_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}