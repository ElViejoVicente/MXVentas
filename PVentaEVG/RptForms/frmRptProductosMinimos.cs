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
    public partial class frmRptProductosMinimos : Telerik.WinControls.UI.RadForm
    {
        private static frmRptProductosMinimos m_FormDefInstance;
        public static frmRptProductosMinimos DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmRptProductosMinimos();
                return m_FormDefInstance;
            }
            set { m_FormDefInstance = value; }
        }
        public frmRptProductosMinimos()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListaProductosMinimos_Load(object sender, EventArgs e)
        {
            Inicializa();
            Encabezados();        
           
        }
        private void Inicializa()
        {
            try
            {
                DataSet dsInicializa = new DataSet();
                OleDbConnection cnnInicializa = new OleDbConnection(Class.clsMain.CnnStr);
                cnnInicializa.Open();
                //MARCA
                OleDbDataAdapter daCol = new OleDbDataAdapter("SELECT * FROM COLUMNAS WHERE CLASIFICACION='BUSCA_PRODUCTO'", cnnInicializa);
                dsInicializa.Clear();
                daCol.Fill(dsInicializa, "COLUMNAS");
                cboCOLMUNAS.DataSource = dsInicializa.Tables["COLUMNAS"];
                cboCOLMUNAS.DisplayMember = "DESC_COLUMNA";
                cboCOLMUNAS.ValueMember = "COLUMNA";
                daCol.Dispose();


                cnnInicializa.Close();
                cnnInicializa.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void Encabezados()
        {
            lvCatProducto.Clear();
            lvCatProducto.View = View.Details;
            lvCatProducto.Columns.Add("Clave", 50, HorizontalAlignment.Left);
            lvCatProducto.Columns.Add("Nombre del artículo", 100, HorizontalAlignment.Left);
            lvCatProducto.Columns.Add("Marca", 100, HorizontalAlignment.Left);
            lvCatProducto.Columns.Add("Grupo", 100, HorizontalAlignment.Left);
            lvCatProducto.Columns.Add("Exist", 100, HorizontalAlignment.Right);
            lvCatProducto.Columns.Add("Min", 100, HorizontalAlignment.Right);
            lvCatProducto.Columns.Add("Diferencia", 70, HorizontalAlignment.Right);
        }
        private void ORDENAR()
        {
            try
            {
                if (cboORDENAR.Text != "")
                {
                    ReadData(fnGetOrder(cboORDENAR.Text) + " " +
                        fnGetAscOrder(cboORDER.Text),
                        Strings.SafeSqlLikeClauseLiteral(txtDESC_PRODUCTO.Text),
                        cboCOLMUNAS.SelectedValue.ToString(), fnGetOrder(cboORDENAR2.Text));
                }
                else
                {
                    ReadData(" ID_PRODUCTO ASC ", Strings.SafeSqlLikeClauseLiteral(txtDESC_PRODUCTO.Text),
                        cboCOLMUNAS.SelectedValue.ToString(), "DESC_PRODUCTO");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                case "PRESENTACION":
                    //
                    retorno = "DESC_PRESENTACION";
                    break;
                case "SUSTANCIA ACTIVA":
                    //
                    retorno = "SUST_ACTIVA";
                    break;
                case "Grupo":
                    //
                    retorno = "DESC_GRUPO";
                    break;
                case "Indicación":
                    //
                    retorno = "INDICACION";
                    break;
                default:
                    retorno = "ID_PRODUCTO";
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
        void ReadData(string prmORDERBY, string prmDESC_PRODUCTO, string prmCOLUMNA, string prmORDERBY2)
        {
            try
            {


                OleDbConnection cnnReadData = new OleDbConnection(Class.clsMain.CnnStr);
                string varSQL = "SELECT P.ID_PRODUCTO, " +
                    " P.DESC_PRODUCTO," +
                    " M.DESC_MARCA," +
                    " P.EXISTENCIA, P.CANT_MIN," +
                    " P.IMPUESTO,G.DESC_GRUPO, " +
                    " (P.EXISTENCIA-P.CANT_MIN) AS DIFERENCIA" +
                    " FROM  CAT_PRODUCTO P,CAT_MARCA M,CAT_GRUPO G " +
                    " WHERE P.ID_MARCA = M.ID_MARCA  AND " + prmCOLUMNA + " like '%" + prmDESC_PRODUCTO + "%' " +
                    " AND G.ID_GRUPO = P.ID_GRUPO AND EXISTENCIA <= CANT_MIN " +
                    "" +
                    " ORDER BY " + prmORDERBY + "," + prmORDERBY2;
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
                    lvCatProducto.Items[I].SubItems.Add(String.Format("{0:N}", drReadData["CANT_MIN"]));
                    lvCatProducto.Items[I].SubItems.Add(String.Format("{0:N}", drReadData["DIFERENCIA"]));
             
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

        private void mnuPrintAll_Click(object sender, EventArgs e)
        {
            
        }

        private void mnuPrintSelected_Click(object sender, EventArgs e)
        {
           
        }
        


        private void btnExport_Click(object sender, EventArgs e)
        {
            POSDLL.Utilities.ExportListView exportar = new POSDLL.Utilities.ExportListView();
            exportar.ExportToExcel(lvCatProducto, "ListaProductosMinimos");
        }

        private void cboORDENAR_SelectedIndexChanged(object sender, EventArgs e)
        {
            ORDENAR();
        }

        private void cboORDER_SelectedIndexChanged(object sender, EventArgs e)
        {
            ORDENAR();
        }

        private void cboORDENAR2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ORDENAR();
        }

        private void barCatProducto_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            lvCatProducto.FitToPage = true;
            lvCatProducto.Title = "Artículos con existencia crítica a la fecha: " + DateTime.Now.ToLongDateString(); ;
            lvCatProducto.PrintPreview();
        }
    }
}