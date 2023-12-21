using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSDLL; using POSDLL.Windows.Forms; using POSDLL.Security; using POSDLL.Reporting; using POSDLL.Ticket;
namespace POSApp.Forms
{
    public partial class frmRptArticulosSinCodigo : Telerik.WinControls.UI.RadForm
    {
        private static frmRptArticulosSinCodigo m_FormDefInstance;
        public static frmRptArticulosSinCodigo DefInstance
        {
            get
            {

                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmRptArticulosSinCodigo();
                return m_FormDefInstance;
            }
            set { m_FormDefInstance = value; }
        }
        public frmRptArticulosSinCodigo()
        {
            InitializeComponent();
        }

        private void frmRptArticulosSinCodigo_Load(object sender, EventArgs e)
        {
            Encabezados();
            ORDENAR();
        }
        void Encabezados()
        {
            lvCatProducto.View = View.Details;
            lvCatProducto.Columns.Add("Clave", 50, HorizontalAlignment.Left);
            lvCatProducto.Columns.Add("Nombre del artículo", 100, HorizontalAlignment.Left);
            lvCatProducto.Columns.Add("Marca", 100, HorizontalAlignment.Left);
            lvCatProducto.Columns.Add("Grupo", 100, HorizontalAlignment.Left);

            lvCatProducto.Columns.Add("Exist", 100, HorizontalAlignment.Right);
            lvCatProducto.Columns.Add("Prec. Venta", 100, HorizontalAlignment.Right);
            lvCatProducto.Columns.Add("IVA", 70, HorizontalAlignment.Right);
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
        public void ImprimeReporte(string prmID_PRODUCTO, string prmComments, int prmReporte)
        {
            try
            {
                string varSQL = "";
                if (prmID_PRODUCTO == "")
                {
                    //toosd
                    varSQL = "SELECT '*' + ID_PRODUCTO + '*'  as ID_PRODUCTO,PRECIO_VENTA,DESC_PRODUCTO " +
                        " FROM CAT_PRODUCTO where  C_BARRAS=true order by DESC_PRODUCTO";
                }
                else
                {
                    //solo uno
                    varSQL = "SELECT '*' + ID_PRODUCTO + '*'  as ID_PRODUCTO,PRECIO_VENTA,DESC_PRODUCTO " +
                        " FROM CAT_PRODUCTO WHERE ID_PRODUCTO = '" + prmID_PRODUCTO + "' and C_BARRAS=true order by DESC_PRODUCTO";
                }
                DataSet dsReporte = new DataSet(); //Datset para el reporte
                OleDbConnection cnnReporte = new OleDbConnection(Class.clsMain.CnnStr);
                if (cnnReporte.State == ConnectionState.Open)
                    cnnReporte.Close();
                cnnReporte.Open();
                dsReporte.Clear();//limpiamos el dataset
                OleDbDataAdapter daReporte =
                    new OleDbDataAdapter(varSQL, cnnReporte);
                daReporte.Fill(dsReporte, "CAT_PRODUCTO");//llenamos el DataSet con la info de la FACTURA

                //destruimos los objetos utilizados
                if (cnnReporte.State == ConnectionState.Open)
                    cnnReporte.Close();
                daReporte.Dispose();

                cnnReporte.Dispose();
                //ya tenoemos la info en el DataSet, ahora cargamos el reporte
                //Reports.rptArticulosSinCodigo _Reporte = new Reports.rptArticulosSinCodigo();
                

                //_Reporte.SummaryInfo.ReportTitle = "Artículos sin código de barras";
                //_Reporte.SummaryInfo.ReportComments = prmComments;
                //_Reporte.SetDataSource(dsReporte);
                //_Reporte.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;

                //Forms.frmReports _frmReportes = new frmReports();
                //_frmReportes.crvReportes.DisplayGroupTree = false;
                //_frmReportes.crvReportes.ReportSource = _Reporte;
                //_frmReportes.StartPosition = FormStartPosition.CenterScreen;
                //_frmReportes.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loading Ticket Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                case "Marca":
                    //
                    retorno = "DESC_MARCA";
                    break;
                case "Presentación":
                    //
                    retorno = "DESC_PRESENTACION";
                    break;
                case "Sustancia Activa":
                    //
                    retorno = "SUST_ACTIVA";
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
                string varSQL = "SELECT P.ID_PRODUCTO, " +
                    " P.DESC_PRODUCTO," +
                    " M.DESC_MARCA," +
                    " P.EXISTENCIA, P.PRECIO_VENTA," +
                    " P.IMPUESTO,G.DESC_GRUPO " +
                    " " +
                    " FROM  CAT_PRODUCTO P,CAT_MARCA M,CAT_GRUPO G " +
                    " WHERE P.C_BARRAS=true and P.ID_MARCA = M.ID_MARCA  AND G.ID_GRUPO = P.ID_GRUPO" + varSQL_DESC +
                    " ORDER BY " + prmORDERBY;
                int I = 0;
                OleDbCommand cmdReadData = new OleDbCommand(varSQL, cnnReadData);
                OleDbDataReader drReadData;
                if (cnnReadData.State == ConnectionState.Open)
                    cnnReadData.Close();
                cnnReadData.Open();
                drReadData = cmdReadData.ExecuteReader();
                lvCatProducto.Items.Clear();
                while (drReadData.Read())
                {
                    lvCatProducto.Items.Add(drReadData["ID_PRODUCTO"].ToString());
                    lvCatProducto.Items[I].SubItems.Add(drReadData["DESC_PRODUCTO"].ToString());
                    lvCatProducto.Items[I].SubItems.Add(drReadData["DESC_MARCA"].ToString());
                    lvCatProducto.Items[I].SubItems.Add(drReadData["DESC_GRUPO"].ToString());

                    lvCatProducto.Items[I].SubItems.Add(String.Format("{0:N}", drReadData["EXISTENCIA"]));
                    lvCatProducto.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["PRECIO_VENTA"]));
                    lvCatProducto.Items[I].SubItems.Add(String.Format("{0:P}", drReadData["IMPUESTO"]));
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

        private void cboORDENAR_SelectedIndexChanged(object sender, EventArgs e)
        {
            ORDENAR();
        }

        private void cboORDER_SelectedIndexChanged(object sender, EventArgs e)
        {
            ORDENAR();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ////ImprimeReporte("", "", 0);
            //lvCatProducto.Title = "Articulos sin código de barras";
            //lvCatProducto.FitToPage = true;
            //lvCatProducto.PrintPreview();

            if (lvCatProducto.Items.Count != 0) {
                Class.clsReports report = new Class.clsReports();
                report.ImprimeReporte("SELECT '*' + ID_PRODUCTO + '*'  as ID_PRODUCTO,DESC_PRODUCTO " +
                        " FROM CAT_PRODUCTO WHERE C_BARRAS=true order by DESC_PRODUCTO", "Comments",
                        "rptProductosCBarras", "rptProductos");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            POSDLL.Utilities.ExportListView exportar = new POSDLL.Utilities.ExportListView();
            exportar.ExportToExcel(lvCatProducto, "ArticulosSinCodigoDeBarras");
        }
    }
}