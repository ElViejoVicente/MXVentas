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
    public partial class frmBuscarCliente : Telerik.WinControls.UI.RadForm
    {
        public frmBuscarCliente()
        {
            InitializeComponent();
        }
        public static int varID_CLIENTE=0;
        private void frmBuscarCliente_Load(object sender, EventArgs e)
        {
            Encabezados();
        }
        void txtNOMBRE_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    if (!(txtNOMBRE.Text == ""))
                    {
                        ReadData(Strings.SafeSqlLikeClauseLiteral(txtNOMBRE.Text));
                    }
                    break;
                case (char)Keys.Escape:
                    varID_CLIENTE = 0;
                    this.Close();
                    break;
            }
        }
        void Buscar() {

            ReadData(Strings.SafeSqlLikeClauseLiteral(txtNOMBRE.Text));
           
           
        }
        private void Encabezados()
        {
            lvBuscaCliente.View = View.Details;
            lvBuscaCliente.Columns.Add("Clave del cliente", 0, HorizontalAlignment.Left);
            lvBuscaCliente.Columns.Add("Nombre", 400, HorizontalAlignment.Left);            
        }
        private void ReadData(string prmNOMBRE)
        {
            //Este procedimiento lee los datos que se tranferirán y los mostrará en forma de
            //lista en el ListView
            try
            {
                //Si la conexion esta abierta la cerramos; en caso contrario, la abrimos
                OleDbConnection cnnReadData = new OleDbConnection(Class.clsMain.CnnStr);
                if (cnnReadData.State == ConnectionState.Open) cnnReadData.Close(); else cnnReadData.Open();
                int I = 0;
                OleDbCommand cmdReadData = new OleDbCommand("SELECT ID_CLIENTE,NOMBRE " +
                    " FROM CAT_CLIENTE WHERE NOMBRE like '%" + prmNOMBRE+ "%'", cnnReadData);
                OleDbDataReader drReadData;
                drReadData = cmdReadData.ExecuteReader();
                lvBuscaCliente.Items.Clear();
                while (drReadData.Read())
                {
                    lvBuscaCliente.Items.Add(drReadData["ID_CLIENTE"].ToString());
                    lvBuscaCliente.Items[I].SubItems.Add(drReadData["NOMBRE"].ToString());
                    I += 1;

                }
                lblInfo.Text = String.Format("Se encontraron {0} registro(s)", I);
                drReadData.Close();
                cmdReadData.Dispose();
                cnnReadData.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Cliente()
        {
            try
            {
                if (lvBuscaCliente.Items.Count != 0)
                {
                    varID_CLIENTE= Convert.ToInt32(lvBuscaCliente.SelectedItems[0].Text);
                }
                else
                {
                    varID_CLIENTE= 0;
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("You must select an element from the list. \nError Description: \n" + 
                    ex.Message, "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}