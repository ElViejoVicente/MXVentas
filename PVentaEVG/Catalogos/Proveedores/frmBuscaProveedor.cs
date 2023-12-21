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
    public partial class frmBuscaProveedor : Telerik.WinControls.UI.RadForm
    {
        public frmBuscaProveedor()
        {
            InitializeComponent();
        }
        public string varID_PROVEEDOR="";
        private void frmBuscaProveedor_Load(object sender, EventArgs e)
        {
            Encabezados();
        }
        private void Encabezados()
        {
            lvBuscaProveedor.View = View.Details;
            lvBuscaProveedor.Columns.Add("Clave de proveedor", 0, HorizontalAlignment.Left);
            lvBuscaProveedor.Columns.Add("Nombre", 400, HorizontalAlignment.Left);
            lvBuscaProveedor.Columns.Add("Contacto", 75, HorizontalAlignment.Left);
            lvBuscaProveedor.Columns.Add("Ciudad", 75, HorizontalAlignment.Left);
            lvBuscaProveedor.Columns.Add("CP", 100, HorizontalAlignment.Left);
            lvBuscaProveedor.Columns.Add("Dirección", 100, HorizontalAlignment.Left);
        }
        void lvBuscaProveedor_DoubleClick(object sender, System.EventArgs e)
        {

            Proveedor();
        }

        void lvBuscaProveedor_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    Proveedor();
                    break;
                case (char)Keys.Escape:
                    varID_PROVEEDOR = "";
                    this.Close();
                    break;
            }   
        }

        void txtDESC_PROVEEDOR_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                if (!(txtDESC_PROVEEDOR.Text == ""))
                {
                    ReadData(Strings.SafeSqlLikeClauseLiteral(txtDESC_PROVEEDOR.Text));
                }
                break;
                case  (char)Keys.Escape:
                    varID_PROVEEDOR = "";
                    this.Close();
                    break;
            }
            
        }        
        private void Proveedor()
        {
            try
            {
                if (lvBuscaProveedor.Items.Count != 0)
                {
                    varID_PROVEEDOR = lvBuscaProveedor.SelectedItems[0].Text;                    
                }
                else
                {
                    varID_PROVEEDOR = "";
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("You must select an element from the list. \nError Description: \n" + ex.Message, "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void ReadData(string prmDESC_PROVEEDOR)
        {
            //Este procedimiento lee los datos que se tranferirán y los mostrará en forma de
            //lista en el ListView
            try
            {
                //Si la conexion esta abierta la cerramos; en caso contrario, la abrimos
               OleDbConnection cnnReadData = new OleDbConnection(Class.clsMain.CnnStr);
                if (cnnReadData.State == ConnectionState.Open) cnnReadData.Close(); else cnnReadData.Open();
                int I = 0;
                OleDbCommand cmdReadData = new OleDbCommand("SELECT ID_PROVEEDOR,DESC_PROVEEDOR,ATENCION,CIUDAD,CP,DIRECCION " +
                    " FROM CAT_PROVEEDOR WHERE DESC_PROVEEDOR like '%" + prmDESC_PROVEEDOR + "%'", cnnReadData);
                OleDbDataReader drReadData;
                drReadData = cmdReadData.ExecuteReader();
                lvBuscaProveedor.Items.Clear();
                while (drReadData.Read())
                {
                    lvBuscaProveedor.Items.Add(drReadData[0].ToString());
                    lvBuscaProveedor.Items[I].SubItems.Add(drReadData[1].ToString());
                    lvBuscaProveedor.Items[I].SubItems.Add(drReadData[2].ToString());
                    lvBuscaProveedor.Items[I].SubItems.Add(drReadData[3].ToString());
                    lvBuscaProveedor.Items[I].SubItems.Add(drReadData[4].ToString());
                    lvBuscaProveedor.Items[I].SubItems.Add(drReadData[5].ToString());
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ReadData(Strings.SafeSqlLikeClauseLiteral(txtDESC_PROVEEDOR.Text));
        }
        
    }
}