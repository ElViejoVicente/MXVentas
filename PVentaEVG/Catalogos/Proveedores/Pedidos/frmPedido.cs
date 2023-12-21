using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POSApp.Forms
{
    public partial class frmPedido : Telerik.WinControls.UI.RadForm
    {
        private static frmPedido m_FormDefInstance;
        public static frmPedido DefInstance
        {
            get
            {

                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmPedido();
                return m_FormDefInstance;
            }
            set { m_FormDefInstance = value; }
        }
        public frmPedido()
        {
            InitializeComponent();
        }
        Class.clsPedido pedido = new Class.clsPedido();
        private void frmPedido_Load(object sender, EventArgs e)
        {
             try
            {
                pedido.ListItems(lvPedido, frmLogin._USER_LOGIN);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnSearchProvider_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaProveedor myForm = new frmBuscaProveedor();
                myForm.StartPosition = FormStartPosition.CenterScreen;
                myForm.ShowDialog();
                if (myForm.varID_PROVEEDOR != "")
                {
                    txtID_PROVEEDOR.Text = myForm.varID_PROVEEDOR;
                    

                }
                myForm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaProducto myForm = new frmBuscaProducto();
                myForm.StartPosition = FormStartPosition.CenterScreen;
                myForm.ShowDialog();
                if (myForm.producto.ID_PRODUCTO != "")
                {
                    txtID_PRODUCTO.Text = myForm.producto.ID_PRODUCTO;
                    
                    txtCANTIDAD.Focus();
                }
                else
                {
                    txtID_PRODUCTO.Text = "";
                   
                }
                myForm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtID_PRODUCTO.Text = "";
            }
        }

        private void chkIVA_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIVA.Checked)
            {
                txtIMPUESTO.Enabled = true;
                txtIMPUESTO.Text = "0.16";
            }
            else
            {
                txtIMPUESTO.Enabled = false;
                txtIMPUESTO.Text = "0";
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try {

                if (pedido.AddItemTmp(txtID_PRODUCTO.Text, Convert.ToDouble(txtCANTIDAD.Text),
                    Convert.ToDouble(txtPRECIO.Text), Convert.ToDouble(txtIMPUESTO.Text), frmLogin._USER_LOGIN)) {
                        pedido.ListItems(lvPedido,frmLogin._USER_LOGIN);
                        txtID_PRODUCTO.Text = "";
                        txtCANTIDAD.Text = "";
                        txtPRECIO.Text = "";
                        txtID_PRODUCTO.Focus();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                int folio = pedido.Save(txtID_PROVEEDOR.Text,  frmLogin._USER_LOGIN, "");
                MessageBox.Show(String.Format("Pedido registrada correctamente\nFolio: {0}", folio),
                    "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
