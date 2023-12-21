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
    public partial class frmCotizacion : Telerik.WinControls.UI.RadForm
    {
        private static frmCotizacion m_FormDefInstance;
        public static frmCotizacion DefInstance
        {
            get
            {

                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmCotizacion();
                return m_FormDefInstance;
            }
            set { m_FormDefInstance = value; }
        }
        public frmCotizacion()
        {
            InitializeComponent();
        }
        Class.clsCotizacion cotizar = new Class.clsCotizacion();
        private void frmCotizacion_Load(object sender, EventArgs e)
        {
            try
            {
                cotizar.ListItems(lvCotizacion, frmLogin._USER_LOGIN);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarCliente myForm = new frmBuscarCliente();
                myForm.StartPosition = FormStartPosition.CenterScreen;
                myForm.ShowDialog();
                if (!(frmBuscarCliente.varID_CLIENTE == 0))
                {
                    txtID_CLIENTE.Text = frmBuscarCliente.varID_CLIENTE.ToString();
                    
                }
                myForm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtID_CLIENTE.Text = "";
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
                    txtPRECIO.Text = myForm.producto.PRECIO_VENTA.ToString("N");
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
                MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtID_PRODUCTO.Text = "";
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try {

                if (cotizar.AddItemTmp(txtID_PRODUCTO.Text, Convert.ToDouble(txtCANTIDAD.Text),
                    Convert.ToDouble(txtPRECIO.Text), Convert.ToDouble(txtIMPUESTO.Text), frmLogin._USER_LOGIN)) {
                        cotizar.ListItems(lvCotizacion,frmLogin._USER_LOGIN);
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

                int folio = cotizar.Save(Convert.ToInt32(txtID_CLIENTE.Text),dtpFechaFin.Value,frmLogin._USER_LOGIN,"");
                MessageBox.Show(String.Format("Cotización registrada correctamente\nFolio: {0}", folio), 
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
