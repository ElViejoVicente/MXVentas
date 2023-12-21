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
    public partial class frmProveedoresLista : Telerik.WinControls.UI.RadForm
    {
        //controlamos q solo se abra una vez
        private static frmProveedoresLista m_FormDefInstance;
        public static frmProveedoresLista DefInstance
        {
            get
            {

                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmProveedoresLista();
                return m_FormDefInstance;
            }
            set { m_FormDefInstance = value; }
        }
        public frmProveedoresLista()
        {
            InitializeComponent();
        }

        private void frmCatProveedores_Load(object sender, EventArgs e)
        {
            lvCatProveedor.DoubleClick += new EventHandler(lvCatProveedor_DoubleClick);
            Encabezados();
            ORDENAR();
        }

        void lvCatProveedor_DoubleClick(object sender, EventArgs e)
        {
            Editar();
        }
        void txtNOMBRE_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ORDENAR();
            }

        }

        void cboORDER_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            ORDENAR();
        }

        void cboORDENAR_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            ORDENAR();
        }
        void Encabezados()
        {
            lvCatProveedor.View = View.Details;
            lvCatProveedor.Columns.Add("Clave", 100, HorizontalAlignment.Left);
            lvCatProveedor.Columns.Add("RFC", 100, HorizontalAlignment.Left);
            lvCatProveedor.Columns.Add("Nombre del proveedor", 290, HorizontalAlignment.Left);
        }
        private void ReadData(string prmORDERBY, string prmNOMBRE)
        {
            try
            {

                string varSQL_NOMBRE = "";
                if (prmNOMBRE == "")
                {
                    varSQL_NOMBRE = "";
                }
                else
                {
                    varSQL_NOMBRE = " WHERE DESC_PROVEEDOR LIKE '%" + prmNOMBRE + "%' ";
                }
                string varSQL = "SELECT ID_PROVEEDOR,RFC,DESC_PROVEEDOR " +
                    " FROM CAT_PROVEEDOR " + varSQL_NOMBRE +
                    " ORDER BY " + prmORDERBY + " ";
                //Si la conexion esta abierta la cerramos; en caso contrario, la abrimos
                OleDbConnection cnnReadData = new OleDbConnection(Class.clsMain.CnnStr);
                cnnReadData.Open();
                OleDbDataReader drReadData;
                OleDbCommand cmdReadData = new OleDbCommand(varSQL, cnnReadData);
                drReadData = cmdReadData.ExecuteReader();
                btnEdit.Visible = false;
                int I = 0;
                lvCatProveedor.Items.Clear();
                while (drReadData.Read())
                {
                    //Aqui mostramos los datos
                    btnEdit.Visible = true;
                    lvCatProveedor.Items.Add(drReadData["ID_PROVEEDOR"].ToString());
                    lvCatProveedor.Items[I].SubItems.Add(drReadData["RFC"].ToString());
                    lvCatProveedor.Items[I].SubItems.Add(drReadData["DESC_PROVEEDOR"].ToString());
                    I += 1;
                }
                lblInfo.Text = string.Format("Se encontraron {0} registro(s)", I);

                cnnReadData.Close();
                cnnReadData.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ORDENAR()
        {
            try
            {
                if (cboORDENAR.Text != "")
                {
                    ReadData(fnGetOrder(cboORDENAR.Text) + " " +
                        fnGetAscOrder(cboORDER.Text),
                        Strings.SafeSqlLikeClauseLiteral(txtNOMBRE.Text));
                }
                else
                {
                    ReadData(" ID_PROVEEDOR ASC ", Strings.SafeSqlLikeClauseLiteral(txtNOMBRE.Text));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void Nuevo()
        {
            frmProveedor _frmProveedor = new frmProveedor();
            _frmProveedor.StartPosition = FormStartPosition.CenterScreen;
            _frmProveedor.ShowDialog();
            ORDENAR();
        }
        void Editar()
        {
            try
            {
                if (lvCatProveedor.SelectedItems.Count != 0)
                {
                    Forms.frmProveedor _frmProveedor = new frmProveedor(lvCatProveedor.SelectedItems[0].Text);
                    _frmProveedor.StartPosition = FormStartPosition.CenterScreen;
                    _frmProveedor.Text = "Edit";
                    _frmProveedor.ShowDialog();
                    ORDENAR();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }
        string fnGetOrder(string prmCAMPO)
        {
            string retorno = "";
            switch (prmCAMPO)
            {
                case "CLAVE DEL PROVEEDOR":
                    //
                    retorno = "ID_PROVEEDOR";
                    break;
                case "RFC":
                    //
                    retorno = "RFC";
                    break;
                case "NOMBRE DEL PROVEEDOR":
                    //
                    retorno = "DESC_PROVEEDOR";
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
                case "Ascendent":
                    //
                    retorno = " ASC ";
                    break;
                case "Descendent":
                    //
                    retorno = " DESC ";
                    break;
                default:
                    retorno = " ASC ";
                    break;
            }
            return (retorno);
        }

       

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Imprimir();
        }
        void Imprimir() {
            lvCatProveedor.Title = "Lista de proveedores";
            lvCatProveedor.FitToPage = true;
            lvCatProveedor.PrintPreview();
        }

        private void c_mnuNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void c_mnuEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void c_mnuImprimir_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ORDENAR();
        }
       

        private void btnExportar_Click(object sender, EventArgs e)
        {
            POSDLL.Utilities.ExportListView exportar = new POSDLL.Utilities.ExportListView();
            exportar.ExportToExcel(lvCatProveedor, "ListadoDeProveedores");
        }
    }
}