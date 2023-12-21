using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POSDLL; using POSDLL.Windows.Forms; using POSDLL.Security; using POSDLL.Reporting; using POSDLL.Ticket;
using Microsoft.Reporting.WinForms;
namespace POSApp.Forms
{
    public partial class frmRptCostoPorPlatillo : Telerik.WinControls.UI.RadForm
    {

        private static frmRptCostoPorPlatillo m_FormDefInstance;
        public static frmRptCostoPorPlatillo DefInstance
        {
            get
            {

                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmRptCostoPorPlatillo();
                return m_FormDefInstance;
            }
            set { m_FormDefInstance = value; }
        }
        public frmRptCostoPorPlatillo()
        {
            InitializeComponent();
        }
        static string varID_PRODUCTO = "";
        private void frmRptCostoPorPlatillo_Load(object sender, EventArgs e)
        {
            txtDESC_PRODUCTO.KeyPress += new KeyPressEventHandler(txtDESC_PRODUCTO_KeyPress);
            lvRpt.DoubleClick += new EventHandler(lvRpt_DoubleClick);
            Encabezados();
            ORDENAR();
        }

        void lvRpt_DoubleClick(object sender, EventArgs e)
        {
            //aqui se manda imprimir el reporte
            if (lvRpt.SelectedItems.Count != 0) {
                varID_PRODUCTO = lvRpt.SelectedItems[0].Text;
                VerReporte(varID_PRODUCTO, "");
            }
        }

        void txtDESC_PRODUCTO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {
                ORDENAR();
            }
        }
        void Encabezados()
        {
            lvRpt.View = View.Details;
            lvRpt.Columns.Add("Clave", 50, HorizontalAlignment.Left);
            lvRpt.Columns.Add("Nombre del artículo", 250, HorizontalAlignment.Left);
            lvRpt.Columns.Add("Grupo", 100, HorizontalAlignment.Left);
            lvRpt.Columns.Add("Costo", 65, HorizontalAlignment.Right);
            lvRpt.Columns.Add("Prec. Venta", 80, HorizontalAlignment.Right);            
            lvRpt.Columns.Add("Utilidad", 80, HorizontalAlignment.Right);
            lvRpt.Columns.Add("%", 75, HorizontalAlignment.Right);
        }
        private void ORDENAR()
        {
            try
            {
                if (cboORDENAR.Text != "")
                {
                    ReadData(fnGetOrder(cboORDENAR.Text) + " " +
                        fnGetAscOrder(cboORDER.Text),
                        Strings.SafeSqlLikeClauseLiteral(txtDESC_PRODUCTO.Text));
                }
                else
                {
                    ReadData(" ID_PRODUCTO ASC ", Strings.SafeSqlLikeClauseLiteral(txtDESC_PRODUCTO.Text));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        public static void VerReporte(string prmID_PRODUCTO, string prmComments)
        {
            try
            {
                
                string _fileName = AppSettings.GetValue("Config", "ReportsFolder", Application.StartupPath) + "\\rptCostoPorPlatillo.rdlc";
                if (!File.Exists(_fileName))
                {
                    MessageBox.Show(String.Format("No se encuentra \n{0}\nRevise por favor", _fileName));
                    return;
                }
                //AHORA MOSTRAMOS EL REPORTE
                string varSQL_PADRE = "SELECT ID_PRODUCTO,DESC_PRODUCTO,PRECIO_VENTA,DETALLE.COSTO,PRECIO_VENTA-DETALLE.COSTO AS UTILIDAD "+
                " FROM CAT_PRODUCTO,(SELECT CAT_PRODUCTO_INGREDIENTES.ID_PRODUCTO_PADRE, SUM(CAT_PRODUCTO.PRECIO_COMPRA *CAT_PRODUCTO_INGREDIENTES.CANTIDAD) AS COSTO"+
                " FROM CAT_PRODUCTO INNER JOIN CAT_PRODUCTO_INGREDIENTES ON CAT_PRODUCTO.ID_PRODUCTO = CAT_PRODUCTO_INGREDIENTES.ID_PRODUCTO"+
                " GROUP BY CAT_PRODUCTO_INGREDIENTES.ID_PRODUCTO_PADRE) DETALLE"+
                " WHERE DETALLE.ID_PRODUCTO_PADRE=CAT_PRODUCTO.ID_PRODUCTO" +
                " AND CAT_PRODUCTO.ID_PRODUCTO='"+ prmID_PRODUCTO +"'";
                //string varSQL_HIJOS = " SELECT CAT_PRODUCTO.ID_PRODUCTO, CAT_PRODUCTO.DESC_PRODUCTO, CAT_UNIDAD_MEDIDA.DESC_UNIDAD_MEDIDA, CAT_PRODUCTO_INGREDIENTES.CANTIDAD, CAT_PRODUCTO.PRECIO_COMPRA,(CAT_PRODUCTO_INGREDIENTES.CANTIDAD* CAT_PRODUCTO.PRECIO_COMPRA) AS TOTAL "+
                //" FROM (CAT_PRODUCTO INNER JOIN CAT_PRODUCTO_INGREDIENTES ON CAT_PRODUCTO.ID_PRODUCTO = CAT_PRODUCTO_INGREDIENTES.ID_PRODUCTO) INNER JOIN CAT_UNIDAD_MEDIDA ON CAT_PRODUCTO.ID_UNIDAD_MEDIDA = CAT_UNIDAD_MEDIDA.ID_UNIDAD_MEDIDA;";
                OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
                cnn.Open();
                DataSet dsReporte = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter(varSQL_PADRE, cnn);
                da.Fill(dsReporte, "dsCAT_PRODUCTO");
                if (dsReporte.Tables["dsCAT_PRODUCTO"].Rows.Count == 0)
                {
                    cnn.Close();
                    MessageBox.Show("No hay Datos (El articulo no tiene ingredientes)");
                    return;
                }

                Forms.frmReports frm = new Forms.frmReports();

                frm.rvDoc.LocalReport.DataSources.Clear();
                frm.rvDoc.LocalReport.Dispose();
                frm.rvDoc.Reset();
                frm.rvDoc.LocalReport.DataSources.Add(new ReportDataSource("dsCAT_PRODUCTO", dsReporte.Tables["dsCAT_PRODUCTO"]));
                frm.rvDoc.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
                frm.rvDoc.LocalReport.ReportPath = _fileName;
                ////parametros
                //List<ReportParameter> param = new List<ReportParameter>();
                //OleDbCommand cmd = new OleDbCommand("SELECT * FROM vDOC_FACTURA WHERE FOLIO_FACTURA='" + prmFOLIO_FACTURA + "'", cnn);
                //OleDbDataReader dr = cmd.ExecuteReader();
                //if (dr.Read())
                //{
                //    ReportParameter pFOLIO_FACTURA = new ReportParameter();
                //    pFOLIO_FACTURA.Name = "prmFOLIO_FACTURA";
                //    pFOLIO_FACTURA.Values.Add(prmFOLIO_FACTURA);
                //    param.Add(pFOLIO_FACTURA);
                //    ReportParameter pOBSERVACIONES = new ReportParameter();
                //    pOBSERVACIONES.Name = "prmOBSERVACIONES";
                //    pOBSERVACIONES.Values.Add(dr["OBSERVACIONES"].ToString());
                //    param.Add(pOBSERVACIONES);
                //    ReportParameter pFECHAF_DIA = new ReportParameter();
                //    pFECHAF_DIA.Name = "prmFECHAF_DIA";
                //    pFECHAF_DIA.Values.Add(Convert.ToDateTime(dr["FECHA_FACTURA"]).Day.ToString());
                //    param.Add(pFECHAF_DIA);
                //    ReportParameter pFECHAF_MES = new ReportParameter();
                //    pFECHAF_MES.Name = "prmFECHAF_MES";
                //    pFECHAF_MES.Values.Add(ISODates.MesALetra(Convert.ToDateTime(dr["FECHA_FACTURA"]).Month));
                //    param.Add(pFECHAF_MES);
                //    ReportParameter pFECHAF_ANO = new ReportParameter();
                //    pFECHAF_ANO.Name = "prmFECHAF_ANO";
                //    pFECHAF_ANO.Values.Add(Convert.ToDateTime(dr["FECHA_FACTURA"]).Year.ToString());
                //    param.Add(pFECHAF_ANO);
                //    ReportParameter pCNOMBRE = new ReportParameter();
                //    pCNOMBRE.Name = "prmCNOMBRE";
                //    pCNOMBRE.Values.Add(dr["NOMBRE"].ToString());
                //    param.Add(pCNOMBRE);
                //    ReportParameter pCDIRECCION = new ReportParameter();
                //    pCDIRECCION.Name = "prmCDIRECCION";
                //    pCDIRECCION.Values.Add(dr["DOMICILIO"].ToString() + ", CP: " + dr["CP"].ToString());
                //    param.Add(pCDIRECCION);
                //    ReportParameter pCCIUDAD = new ReportParameter();
                //    pCCIUDAD.Name = "prmCCIUDAD";
                //    pCCIUDAD.Values.Add(dr["DESC_MUNICIPIO"].ToString() + ", " + dr["DESC_ESTADO"].ToString());
                //    param.Add(pCCIUDAD);
                //    ReportParameter pCRFC = new ReportParameter();
                //    pCRFC.Name = "prmCRFC";
                //    pCRFC.Values.Add("RFC: " + dr["RFC"].ToString());
                //    param.Add(pCRFC);
                //    ReportParameter pFCLETRA = new ReportParameter();
                //    pFCLETRA.Name = "prmFCLETRA";
                //    pFCLETRA.Values.Add(dr["CANT_LETRA"].ToString());
                //    param.Add(pFCLETRA);
                //    ReportParameter pFSUBTOTAL = new ReportParameter();
                //    pFSUBTOTAL.Name = "prmFSUBTOTAL";
                //    pFSUBTOTAL.Values.Add("245.00");
                //    param.Add(pFSUBTOTAL);
                //    ReportParameter pFIVA = new ReportParameter();
                //    pFIVA.Name = "prmFIVA";
                //    pFIVA.Values.Add("0.00");
                //    param.Add(pFIVA);
                //    ReportParameter pFTOTAL = new ReportParameter();
                //    pFTOTAL.Name = "prmFTOTAL";
                //    pFTOTAL.Values.Add("245.00");
                //    param.Add(pFTOTAL);
                //}
                //dr.Close();
                ////agregamos los parametros a la coleccion
                //frm.rvDoc.LocalReport.SetParameters(param);
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
            string _fileName = AppSettings.GetValue("Config", "ReportsFolder", Application.StartupPath) + "\\rptCostoPorPlatilloIngredientes.rdlc";
            if (!File.Exists(_fileName))
            {
                MessageBox.Show(String.Format("No se encuentra \n{0}\nRevise por favor", _fileName));
                return;
            }
            //AHORA MOSTRAMOS EL REPORTE
           
            string varSQL_HIJOS = " SELECT CAT_PRODUCTO.ID_PRODUCTO, CAT_PRODUCTO.DESC_PRODUCTO, CAT_UNIDAD_MEDIDA.DESC_UNIDAD_MEDIDA AS UNIDAD_MEDIDA, CAT_PRODUCTO_INGREDIENTES.CANTIDAD, CAT_PRODUCTO.PRECIO_COMPRA AS COSTO,(CAT_PRODUCTO_INGREDIENTES.CANTIDAD* CAT_PRODUCTO.PRECIO_COMPRA) AS TOTAL " +
            " FROM (CAT_PRODUCTO INNER JOIN CAT_PRODUCTO_INGREDIENTES ON CAT_PRODUCTO.ID_PRODUCTO = CAT_PRODUCTO_INGREDIENTES.ID_PRODUCTO) INNER JOIN CAT_UNIDAD_MEDIDA ON CAT_PRODUCTO.ID_UNIDAD_MEDIDA = CAT_UNIDAD_MEDIDA.ID_UNIDAD_MEDIDA "+
            " WHERE CAT_PRODUCTO_INGREDIENTES.ID_PRODUCTO_PADRE='" + varID_PRODUCTO + "'";
            OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
            cnn.Open();
            DataSet dsReporte = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(varSQL_HIJOS, cnn);
            da.Fill(dsReporte, "dsCAT_PRODUCTO_INGREDIENTES");
            if (dsReporte.Tables["dsCAT_PRODUCTO_INGREDIENTES"].Rows.Count == 0)
            {
                cnn.Close();
                MessageBox.Show("No hay Datos (El articulo no tiene ingredientes)");
                return;
            }
            
            e.DataSources.Add(new ReportDataSource("dsCAT_PRODUCTO_INGREDIENTES",dsReporte.Tables["dsCAT_PRODUCTO_INGREDIENTES"]));
 
        } 
        string fnGetOrder(string prmCAMPO)
        {
            string retorno = "";
            switch (prmCAMPO)
            {
                case "Clave":
                    //
                    retorno = "ID_PRODUCTO";
                    break;
                case "Nombre del Artículo":
                    //
                    retorno = "DESC_PRODUCTO";
                    break;
                case "Grupo":
                    //
                    retorno = "DESC_GRUPO";
                    break;
                default:
                    retorno = "";
                    break;
            }
            return (retorno);
        }
        string fnGetAscOrder(string prmCAMPO)
        {
            string retorno = "";
            switch (prmCAMPO)
            {
                case "Ascendente":
                    //
                    retorno = " ASC ";
                    break;
                case "Descendente":
                    //
                    retorno = " DESC ";
                    break;
                default:
                    retorno = " ASC ";
                    break;
            }
            return (retorno);
        }
        void ReadData(string prmORDERBY, string prmDESC_PRODUCTO)
        {
            try
            {
                string varSQL_DESC = "";
                if (prmDESC_PRODUCTO == "")
                {
                    varSQL_DESC = "";
                }
                else
                {
                    varSQL_DESC = " AND DESC_PRODUCTO LIKE '%" + prmDESC_PRODUCTO + "%' ";
                }

                OleDbConnection cnnReadData = new OleDbConnection(Class.clsMain.CnnStr);
                //string varSQL = "SELECT P.ID_PRODUCTO, " +
                //    " P.DESC_PRODUCTO," +
                //    " M.DESC_MARCA," +
                //    " P.EXISTENCIA, P.PRECIO_VENTA," +
                //    " P.IMPUESTO,G.DESC_GRUPO " +
                //    " " +
                //    " FROM  CAT_PRODUCTO P,CAT_MARCA M,CAT_GRUPO G " +
                //    " WHERE P.INGREDIENTES=true and P.ID_MARCA = M.ID_MARCA  AND G.ID_GRUPO = P.ID_GRUPO" + varSQL_DESC +
                //    " ORDER BY " + prmORDERBY;
                string varSQL = "SELECT ID_PRODUCTO,DESC_PRODUCTO,PRECIO_VENTA,DETALLE.COSTO,PRECIO_VENTA-DETALLE.COSTO AS UTILIDAD,G.DESC_GRUPO " +
                " FROM CAT_PRODUCTO,(SELECT CAT_PRODUCTO_INGREDIENTES.ID_PRODUCTO_PADRE, SUM(CAT_PRODUCTO.PRECIO_COMPRA *CAT_PRODUCTO_INGREDIENTES.CANTIDAD) AS COSTO" +
                " FROM CAT_PRODUCTO INNER JOIN CAT_PRODUCTO_INGREDIENTES ON CAT_PRODUCTO.ID_PRODUCTO = CAT_PRODUCTO_INGREDIENTES.ID_PRODUCTO" +
                " GROUP BY CAT_PRODUCTO_INGREDIENTES.ID_PRODUCTO_PADRE) DETALLE, CAT_GRUPO G" +
                " WHERE DETALLE.ID_PRODUCTO_PADRE=CAT_PRODUCTO.ID_PRODUCTO AND G.ID_GRUPO=CAT_PRODUCTO.ID_GRUPO " + varSQL_DESC +
                " ORDER BY " + prmORDERBY; 
                int I = 0;
                OleDbCommand cmdReadData = new OleDbCommand(varSQL, cnnReadData);
                OleDbDataReader drReadData;
                if (cnnReadData.State == ConnectionState.Open)
                    cnnReadData.Close();
                cnnReadData.Open();
                drReadData = cmdReadData.ExecuteReader();
                lvRpt.Items.Clear();
                while (drReadData.Read())
                {
                    lvRpt.Items.Add(drReadData["ID_PRODUCTO"].ToString());
                    lvRpt.Items[I].SubItems.Add(drReadData["DESC_PRODUCTO"].ToString());
                    lvRpt.Items[I].SubItems.Add(drReadData["DESC_GRUPO"].ToString());
                    lvRpt.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["COSTO"]));
                    lvRpt.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["PRECIO_VENTA"]));
                    lvRpt.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["UTILIDAD"]));
                   
                    double P1 = Convert.ToDouble(drReadData["PRECIO_VENTA"]) / 100;
                    double PCosto = Convert.ToDouble(drReadData["COSTO"]) / P1;
                    double Putilidad = Convert.ToDouble(drReadData["UTILIDAD"]) / P1;
                    lvRpt.Items[I].SubItems.Add(String.Format("{0:P}",Convert.ToDouble(drReadData["PRECIO_VENTA"]) / Convert.ToDouble(drReadData["COSTO"])));
                    I += 1;
                }
                lblInfo.Text = String.Format("Se encontraron {0} registro(s)", I);
                drReadData.Close();
                cmdReadData.Dispose();
                cnnReadData.Close();
                cnnReadData.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ORDENAR();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            POSDLL.Utilities.ExportListView exportar = new POSDLL.Utilities.ExportListView();
            exportar.ExportToExcel(lvRpt, "ArticulosConIngredientes");
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            lvRpt.Title = "Articulos que requieren ingredientes";
            lvRpt.FitToPage = true;
            lvRpt.PrintPreview();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
