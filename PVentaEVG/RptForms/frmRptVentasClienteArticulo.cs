using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSDLL; using POSDLL.Windows.Forms; using POSDLL.Security; using POSDLL.Reporting; using POSDLL.Ticket;
using Microsoft.Reporting.WinForms;
namespace POSApp.Forms
{
    public partial class frmRptVentasClienteArticulo : Telerik.WinControls.UI.RadForm
    {
        private static frmRptVentasClienteArticulo m_FormDefInstance;
        public static frmRptVentasClienteArticulo DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmRptVentasClienteArticulo();
                return m_FormDefInstance;
            }
            set { m_FormDefInstance = value; }
        }
        public frmRptVentasClienteArticulo()
        {
            InitializeComponent();
        }
        string varCLIENTE = "";
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtID_CLIENTE.Text == "") {
                MessageBox.Show("Falta el cliente");
                return;
            }
            string varComments = "Ventas entre " + dtpFECHA_INI.Value.ToLongDateString() + " y " + dtpFECHA_FIN.Value.ToLongDateString();
            ImprimeReporte(Convert.ToInt32(txtID_CLIENTE.Text),ISODates.MSAccessDateINI(dtpFECHA_INI.Value),
                ISODates.MSAccessDateFIN(dtpFECHA_FIN.Value), varComments,varCLIENTE);
        }
        //("EXECUTE spVENTAS_CLIENTE_ARTICULO " +
        //            "  #" + prmFECHA_INI + "#, #" + prmFECHA_FIN + "#"
        public void ImprimeReporte(int prmID_CLIENTE,string prmFECHA_INI, string prmFECHA_FIN, string prmFechas,string prmNombreCliente)
        {
            try
            {
                string varSQL = "";
                string _FileName = AppSettings.GetValue("Config", "ReportsFolder", Application.StartupPath);
                _FileName += "\\rptVentasCteArt.rdlc";
                if (!File.Exists(_FileName))
                {
                    MessageBox.Show(String.Format("No se encuentra el archivo {0}\nRevise por favor.", _FileName), "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                varSQL = "EXECUTE spVENTAS_CLIENTE_ARTICULO "+ prmID_CLIENTE +"," +
                    "  #" + prmFECHA_INI + "#, #" + prmFECHA_FIN + "#";
               
                DataSet dsReporte = new DataSet(); //Datset para el reporte
                OleDbConnection cnnReporte = new OleDbConnection(Class.clsMain.CnnStr);
                cnnReporte.Open();
                dsReporte.Clear();//limpiamos el dataset
                OleDbDataAdapter daReporte =
                    new OleDbDataAdapter(varSQL, cnnReporte);
                daReporte.Fill(dsReporte, "dsRptVentasCteArt");//llenamos el DataSet con la info de la FACTURA
                daReporte.Dispose();

                cnnReporte.Dispose();
                //ya tenoemos la info en el DataSet, ahora cargamos el reporte

                if (dsReporte.Tables["dsRptVentasCteArt"].Rows.Count == 0)
                {
                    cnnReporte.Close();
                    MessageBox.Show("No hay datos para mostrar.", "Información del sistema");
                    return;
                }

                Forms.frmReports frm = new Forms.frmReports();

                frm.rvDoc.LocalReport.DataSources.Clear();
                frm.rvDoc.LocalReport.Dispose();
                frm.rvDoc.Reset();
                frm.rvDoc.LocalReport.DataSources.Add(new ReportDataSource("dsRptVentasCteArt", dsReporte.Tables["dsRptVentasCteArt"]));
                frm.rvDoc.LocalReport.ReportPath = _FileName;
                //parametros
                List<ReportParameter> param = new List<ReportParameter>();
                ReportParameter pNombreC = new ReportParameter();
                pNombreC.Name = "prmNombreCliente";
                pNombreC.Values.Add(prmNombreCliente);
                param.Add(pNombreC);
                ReportParameter pFechas = new ReportParameter();
                pFechas.Name = "prmFechas";
                pFechas.Values.Add(prmFechas);
                param.Add(pFechas);
                frm.rvDoc.LocalReport.SetParameters(param);
                frm.rvDoc.RefreshReport();
                frm.ShowDialog();

                cnnReporte.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loading Ticket Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRptVentasClienteArticulo_Load(object sender, EventArgs e)
        {
            txtID_CLIENTE.LostFocus += new EventHandler(txtID_CLIENTE_LostFocus);
        }

        void txtID_CLIENTE_LostFocus(object sender, EventArgs e)
        {
            varCLIENTE = clsCliente.fnBuscaNombreCliente(frmBuscarCliente.varID_CLIENTE);
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            BuscaCliente();
        }
        void BuscaCliente()
        {
            try
            {
                frmBuscarCliente myForm = new frmBuscarCliente();
                myForm.StartPosition = FormStartPosition.CenterScreen;
                myForm.ShowDialog();
                if (!(frmBuscarCliente.varID_CLIENTE == 0))
                {
                    txtID_CLIENTE.Text = frmBuscarCliente.varID_CLIENTE.ToString();
                    varCLIENTE = clsCliente.fnBuscaNombreCliente(frmBuscarCliente.varID_CLIENTE);
                    txtID_CLIENTE.Focus();
                }
                myForm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnBuscaCliente",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtID_CLIENTE.Text = "";
            }
        }
    }
}