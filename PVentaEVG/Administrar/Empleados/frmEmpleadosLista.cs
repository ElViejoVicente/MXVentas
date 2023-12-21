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
    public partial class frmEmpleadosLista : Telerik.WinControls.UI.RadForm
    {
        private static frmEmpleadosLista m_FormDefInstance;
        public static frmEmpleadosLista DefInstance
        {
            get
            {

                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmEmpleadosLista();
                return m_FormDefInstance;
            }
            set { m_FormDefInstance = value; }
        }
        public frmEmpleadosLista()
        {
            InitializeComponent();
        }

        private void frmCatEmpleados_Load(object sender, EventArgs e)
        {
            Encabezados();
            ORDENAR();
        }
        void cboORDENAR_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            ORDENAR();
        }

        void cboORDER_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            ORDENAR();
        }

        void txtNOMBRE_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ORDENAR();
            }
        }
        void lvCatEmpleado_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Editar();
            }
        }

        void lvCatEmpleado_DoubleClick(object sender, System.EventArgs e)
        {
            Editar();
        }
        void Encabezados()
        {
            lvCatEmpleado.View = View.Details;
            lvCatEmpleado.Columns.Add("Clave", 100, HorizontalAlignment.Left);        
            lvCatEmpleado.Columns.Add("Nombre del empleado", 300, HorizontalAlignment.Left);
            lvCatEmpleado.Columns.Add("Sexo", 150, HorizontalAlignment.Left);
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
                string varSQL = "SELECT ID_EMPLEADO,NOMBRE, DESC_SEXO" +
                    " " +
                    " FROM vCAT_EMPLEADO "  + varSQL_NOMBRE +
                    " ORDER BY " + prmORDERBY + "";
                //MessageBox.Show(varSQL);
                //Si la conexion esta abierta la cerramos; en caso contrario, la abrimos
                OleDbConnection cnnReadData = new OleDbConnection(Class.clsMain.CnnStr);
                cnnReadData.Open();
                OleDbDataReader drReadData;
                OleDbCommand cmdReadData = new OleDbCommand(varSQL, cnnReadData);
                drReadData = cmdReadData.ExecuteReader();
                btnEdit.Visible = false;
                int I = 0;
                lvCatEmpleado.Items.Clear();
                while (drReadData.Read())
                {
                    //Aqui mostramos los datos
                    btnEdit.Visible = true;
                    lvCatEmpleado.Items.Add(drReadData["ID_EMPLEADO"].ToString());                  
                    lvCatEmpleado.Items[I].SubItems.Add(drReadData["NOMBRE"].ToString());
                    lvCatEmpleado.Items[I].SubItems.Add(drReadData["DESC_SEXO"].ToString());
                    I += 1;
                }


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
                    ReadData("ID_EMPLEADO ASC ", Strings.SafeSqlLikeClauseLiteral(txtNOMBRE.Text));
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
                case "Employee ID":
                    //
                    retorno = "ID_EMPLEADO";
                    break;
                case "Gender":
                    //
                    retorno = "DESC_SEXO";
                    break;
                case "Name":
                    //
                    retorno = "NOMBRE";
                    break;
                default:
                    retorno = "ID_EMPLEADO";
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
                    retorno = "ASC";
                    break;
                case "Descendent":
                    //
                    retorno = "DESC";
                    break;
                default:
                    retorno = "ASC";
                    break;
            }
            return (retorno);
        }
        void Nuevo()
        {
            frmEmpleado _frmEmpelado = new frmEmpleado();
            _frmEmpelado.StartPosition = FormStartPosition.CenterScreen;
            _frmEmpelado.ShowDialog();
            if (frmEmpleado._Accion)
            {
                ORDENAR();
            }
        }
        void Editar()
        {
            try
            {
                if (lvCatEmpleado.SelectedItems.Count != 0)
                {
                    Forms.frmEmpleado _frmEmpleado = new frmEmpleado(Convert.ToString(lvCatEmpleado.SelectedItems[0].Text));
                    _frmEmpleado.StartPosition = FormStartPosition.CenterScreen;
                    _frmEmpleado.Text = "Edit";
                    _frmEmpleado.ShowDialog();
                    if (frmEmpleado._Accion)
                    {
                        ORDENAR();
                    }
                }
                else {
                    MessageBox.Show("Debe seleccionar un elemento de la lista", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        void Imprimir() {
            lvCatEmpleado.Title = "Lista de empleados";
            lvCatEmpleado.FitToPage = true;
            lvCatEmpleado.PrintPreview();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void editarElElementoSeleccionadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            POSDLL.Utilities.ExportListView exportar = new POSDLL.Utilities.ExportListView();
            exportar.ExportToExcel(lvCatEmpleado, "ListadoDeEmpleados");
        }
       
        
    }
}