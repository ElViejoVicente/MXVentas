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
    public partial class frmRptInventarioFisico : Telerik.WinControls.UI.RadForm
    {
        private static frmRptInventarioFisico m_FormDefInstance;
        public static frmRptInventarioFisico DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmRptInventarioFisico();
                return m_FormDefInstance;
            }
            set { m_FormDefInstance = value; }
        }
        public frmRptInventarioFisico()
        {
            InitializeComponent();
        }
        static int varFOLIO = 0;
        private void frmRptInventarioFisico_Load(object sender, EventArgs e)
        {
            Inicializa();
        }
        private void Inicializa()
        {
            try
            {
                DataSet dsInicializa = new DataSet();
                OleDbConnection cnnInicializa = new OleDbConnection(Class.clsMain.CnnStr);
                cnnInicializa.Open();
                //MARCA
                OleDbDataAdapter daUsers = new OleDbDataAdapter("SELECT FECHA_REGISTRO,FOLIO_INVENTARIO_FISICO FROM INVENTARIO_FISICO ORDER BY FECHA_REGISTRO" +
                    "  ", cnnInicializa);
                dsInicializa.Clear(); 
                daUsers.Fill(dsInicializa, "INVENTARIO_FISICO");
                cboFOLIO_INVENTARIO_FISICO.DataSource = dsInicializa.Tables["INVENTARIO_FISICO"];
                cboFOLIO_INVENTARIO_FISICO.DisplayMember = "FECHA_REGISTRO";
                cboFOLIO_INVENTARIO_FISICO.ValueMember = "FOLIO_INVENTARIO_FISICO";
                daUsers.Dispose();
                if (dsInicializa.Tables["INVENTARIO_FISICO"].Rows.Count == 0) {
                    btnOK.Enabled = false;
                }
                cnnInicializa.Close();
                cnnInicializa.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void VerReporte(int prmFOLIO_INVENTARIO_FISICO, string prmComments)
        {
            try
            {

                string _fileName = AppSettings.GetValue("Config", "ReportsFolder", Application.StartupPath) + "\\rptInventarioFisico.rdlc";
                if (!File.Exists(_fileName))
                {
                    MessageBox.Show(String.Format("No se encuentra \n{0}\nRevise por favor", _fileName));
                    return;
                }
                //AHORA MOSTRAMOS EL REPORTE
                string varSQL_PADRE = "SELECT I.FOLIO_INVENTARIO_FISICO,I.FECHA_REGISTRO,U.NOMBRE +' '+ U.MATERNO + '' + U.MATERNO AS USUARIO "+
                    " FROM INVENTARIO_FISICO I, USERS U WHERE I.USER_LOGIN=U.USER_LOGIN ";
                //string varSQL_HIJOS = " SELECT CAT_PRODUCTO.ID_PRODUCTO, CAT_PRODUCTO.DESC_PRODUCTO, CAT_UNIDAD_MEDIDA.DESC_UNIDAD_MEDIDA, CAT_PRODUCTO_INGREDIENTES.CANTIDAD, CAT_PRODUCTO.PRECIO_COMPRA,(CAT_PRODUCTO_INGREDIENTES.CANTIDAD* CAT_PRODUCTO.PRECIO_COMPRA) AS TOTAL "+
                //" FROM (CAT_PRODUCTO INNER JOIN CAT_PRODUCTO_INGREDIENTES ON CAT_PRODUCTO.ID_PRODUCTO = CAT_PRODUCTO_INGREDIENTES.ID_PRODUCTO) INNER JOIN CAT_UNIDAD_MEDIDA ON CAT_PRODUCTO.ID_UNIDAD_MEDIDA = CAT_UNIDAD_MEDIDA.ID_UNIDAD_MEDIDA;";
                OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
                cnn.Open();
                DataSet dsReporte = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter(varSQL_PADRE, cnn);
                da.Fill(dsReporte, "dsINVENTARIO_FISICO");
                if (dsReporte.Tables["dsINVENTARIO_FISICO"].Rows.Count == 0)
                {
                    cnn.Close();
                    MessageBox.Show("No hay Datos ");
                    return;
                }

                Forms.frmReports frm = new Forms.frmReports();

                frm.rvDoc.LocalReport.DataSources.Clear();
                frm.rvDoc.LocalReport.Dispose();
                frm.rvDoc.Reset();
                frm.rvDoc.LocalReport.DataSources.Add(new ReportDataSource("dsINVENTARIO_FISICO", dsReporte.Tables["dsINVENTARIO_FISICO"]));
                frm.rvDoc.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
                frm.rvDoc.LocalReport.ReportPath = _fileName;
                
                frm.rvDoc.RefreshReport();
                frm.ShowDialog();
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Error loading report", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        static void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            //aqui llamamos los subreportes
            string _fileName = AppSettings.GetValue("Config", "ReportsFolder", Application.StartupPath) + "\\rptInventarioFisicoDetalle.rdlc";
            if (!File.Exists(_fileName))
            {
                MessageBox.Show(String.Format("No se encuentra \n{0}\nRevise por favor", _fileName));
                return;
            }
            //AHORA MOSTRAMOS EL REPORTE

            string varSQL_HIJOS = "SELECT CAT_PRODUCTO.ID_PRODUCTO, CAT_PRODUCTO.DESC_PRODUCTO, INVENTARIO_FISICO_DETALLE.CANTIDAD, "+
                "INVENTARIO_FISICO_DETALLE.CANTIDAD_ANTES, INVENTARIO_FISICO_DETALLE.PRECIO_COMPRA, INVENTARIO_FISICO_DETALLE.PRECIO_VENTA, INVENTARIO_FISICO_DETALLE.FOLIO_INVENTARIO_FISICO "+
                " FROM CAT_PRODUCTO INNER JOIN INVENTARIO_FISICO_DETALLE ON CAT_PRODUCTO.ID_PRODUCTO = INVENTARIO_FISICO_DETALLE.ID_PRODUCTO "+
                " where INVENTARIO_FISICO_DETALLE.FOLIO_INVENTARIO_FISICO="+ varFOLIO +"";
            OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
            cnn.Open();
            DataSet dsReporte = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(varSQL_HIJOS, cnn);
            da.Fill(dsReporte, "dsINVENTARIO_FISICO_DETALLE");
            if (dsReporte.Tables["dsINVENTARIO_FISICO_DETALLE"].Rows.Count == 0)
            {
                cnn.Close();
                MessageBox.Show("No hay Datos");
                return;
            }

            e.DataSources.Add(new ReportDataSource("dsINVENTARIO_FISICO_DETALLE", dsReporte.Tables["dsINVENTARIO_FISICO_DETALLE"]));

        } 

        private void btnOK_Click(object sender, EventArgs e)
        {
            varFOLIO = Convert.ToInt32(cboFOLIO_INVENTARIO_FISICO.SelectedValue);
            VerReporte(varFOLIO, "");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}