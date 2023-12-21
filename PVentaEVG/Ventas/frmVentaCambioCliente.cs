using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace POSApp.Forms
{
    public partial class frmVentaCambioCliente : Telerik.WinControls.UI.RadForm
    {
        public frmVentaCambioCliente(int prmFOLIO_VENTA)
        {
            InitializeComponent();
            varFOLIO_VENTA = prmFOLIO_VENTA;
        }
        int varFOLIO_VENTA = 0;
        private void frmVentaCambioCliente_Load(object sender, EventArgs e)
        {
            ReadData(varFOLIO_VENTA);
        }
        void ReadData(int prmFOLIO_VENTA) {
            try {
                OleDbConnection cnnRead = new OleDbConnection(Class.clsMain.CnnStr);
                cnnRead.Open();
                OleDbCommand cmdRead = new OleDbCommand("SELECT ID_CLIENTE FROM VENTA WHERE FOLIO="+ prmFOLIO_VENTA +"", cnnRead);
                txtID_CLIENTE.Text = cmdRead.ExecuteScalar().ToString();
                cnnRead.Close();
                cnnRead.Dispose();
                cmdRead.Dispose();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        bool Update(int prmFOLIO_VENTA,int prmID_CLIENTE)
        {
            try
            {
                OleDbConnection cnnUpdate = new OleDbConnection(Class.clsMain.CnnStr);
                cnnUpdate.Open();
                OleDbCommand cmdUpdate = new OleDbCommand("UPDATE VENTA SET ID_CLIENTE="+ prmID_CLIENTE +"  WHERE FOLIO=" + prmFOLIO_VENTA + "", cnnUpdate);
                cmdUpdate.ExecuteNonQuery();
                cnnUpdate.Close();
                cnnUpdate.Dispose();
                cmdUpdate.Dispose();
                return (true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return (false);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            try { 
                if(Update(varFOLIO_VENTA,Convert.ToInt32(txtID_CLIENTE.Text))){
                    MessageBox.Show("Cambio de cliente satisfactorio","Información del sistema");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cambia cliente",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
        }
    }
}