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
    public partial class frmClientesLista : Telerik.WinControls.UI.RadForm
    {
        //controlamos q solo se abra una vez
        private static frmClientesLista m_FormDefInstance;
        public static frmClientesLista DefInstance
        {
            get
            {

                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmClientesLista();
                return m_FormDefInstance;
            }
            set { m_FormDefInstance = value; }
        }
        public frmClientesLista()
        {
            InitializeComponent();
        }

        private void frmCatClientes_Load(object sender, EventArgs e)
        {
            Encabezados();
            ORDENAR();
        }
        void txtNOMBRE_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {
                ORDENAR();
            }
        }
        void cboORDENAR_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            ORDENAR();
        }

        void cboORDER_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            ORDENAR();
        }
        void lvCatCliente_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {
                Editar();
            }
        }

        void lvCatCliente_DoubleClick(object sender, System.EventArgs e)
        {
            Editar();
        }
        void Encabezados()
        {
            lvCatCliente.View = View.Details;
            lvCatCliente.Columns.Add("Clave", 100, HorizontalAlignment.Left);
            lvCatCliente.Columns.Add("RFC", 100, HorizontalAlignment.Left);
            lvCatCliente.Columns.Add("Nombre del cliente", 290, HorizontalAlignment.Left);
            lvCatCliente.Columns.Add("TIPO", 100, HorizontalAlignment.Left);
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
                    varSQL_NOMBRE = " WHERE NOMBRE LIKE '%" + prmNOMBRE + "%' ";
                }
                string varSQL = "SELECT ID_CLIENTE,RFC,NOMBRE,TIPO_CLIENTE" +
                    " " +
                    " FROM CAT_CLIENTE " +
                    "  " + varSQL_NOMBRE +
                    " ORDER BY " + prmORDERBY + "";
                //Si la conexion esta abierta la cerramos; en caso contrario, la abrimos
                OleDbConnection cnnReadData = new OleDbConnection(Class.clsMain.CnnStr);
                cnnReadData.Open();
                OleDbDataReader drReadData;
                OleDbCommand cmdReadData = new OleDbCommand(varSQL, cnnReadData);
                drReadData = cmdReadData.ExecuteReader();
                btnEdit.Visible = false;
                int I = 0;
                string _tipo = "";
                lvCatCliente.Items.Clear();
                while (drReadData.Read()) { 
                    //Aqui mostramos los datos
                    btnEdit.Visible = true;
                    lvCatCliente.Items.Add(drReadData["ID_CLIENTE"].ToString());
                    lvCatCliente.Items[I].SubItems.Add(drReadData["RFC"].ToString());
                    lvCatCliente.Items[I].SubItems.Add(drReadData["NOMBRE"].ToString());
                    _tipo = drReadData["TIPO_CLIENTE"].ToString().Replace("{PRECIO_VENTA2}", "").Replace("{PRECIO_VENTA}", "");
                    lvCatCliente.Items[I].SubItems.Add(_tipo);  
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
                    ReadData("ID_CLIENTE ASC", Strings.SafeSqlLikeClauseLiteral(txtNOMBRE.Text));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        string fnGetOrder(string prmCAMPO) {
            string retorno = "";
            switch (prmCAMPO) { 
                case "ID Cliente":
                    //
                    retorno="ID_CLIENTE";
                    break;
                case "RFC":
                    //
                    retorno="RFC";
                    break;
                case "Nombre":
                    //
                    retorno="NOMBRE";
                    break;
                case "Tipo":
                    //
                    retorno = "TIPO_CLIENTE";
                    break;
                default:
                    retorno="ID_CLIENTE";
                    break;
            }
            return (retorno);
        }
        string fnGetAscOrder(string prmCAMPO)
        {
            string retorno = "";
            switch (prmCAMPO)
            {
                case "ASCENDENTE":
                    //
                    retorno = "ASC";
                    break;
                case "DESCENDENTE":
                    //
                    retorno = "DESC";
                    break;                
                default:
                    retorno = "ASC";
                    break;
            }
            return (retorno);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Editar();
        }
        void Nuevo() {
            frmCliente _frmCliente = new frmCliente();
            _frmCliente.StartPosition = FormStartPosition.CenterScreen;
            _frmCliente.ShowDialog();
            if (frmCliente._Accion)
            {
                ORDENAR();
            }
        }
        void EstadoCuenta()
        {
            try
            {
                if (lvCatCliente.Items.Count != 0)
                {
                    Class.clsVentas.ViewCountStatus(Convert.ToInt32(lvCatCliente.SelectedItems[0].Text));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }
        void Editar()
        {
            try
            {
                if (lvCatCliente.SelectedItems.Count != 0)
                {
                    Forms.frmCliente _frmCliente = new frmCliente(Convert.ToInt32(lvCatCliente.SelectedItems[0].Text));
                    _frmCliente.StartPosition = FormStartPosition.CenterScreen;
                    _frmCliente.Text = "Edit";
                    _frmCliente.ShowDialog();
                    if (frmCliente._Accion)
                    {
                        ORDENAR();
                    }
                }
                else {
                    MessageBox.Show("Seleccione un cliente de la lista", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        


     
        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void mnuAddNew_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

     
        private void c_mnuPrintList_Click(object sender, EventArgs e)
        {
            printList();
        }
        void printList() {
            lvCatCliente.Title = "Lista de clientes";
            lvCatCliente.FitToPage = true;
            lvCatCliente.PrintPreview();
        }

        private void mnuPrintList_Click(object sender, EventArgs e)
        {
            printList();
        }



        private void btnExportar_Click(object sender, EventArgs e)
        {
            POSDLL.Utilities.ExportListView exportar = new POSDLL.Utilities.ExportListView();
            exportar.ExportToExcel(lvCatCliente, "ListaDeClientes");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            printList();
        }
       
       
    }
}