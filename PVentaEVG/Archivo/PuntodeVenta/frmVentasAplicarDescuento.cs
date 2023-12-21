using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POSDLL; using POSDLL.Windows.Forms; using POSDLL.Security; using POSDLL.Reporting; using POSDLL.Ticket;
namespace POSApp.Forms
{
    public partial class frmVentasAplicarDescuento : Telerik.WinControls.UI.RadForm
    {
        public frmVentasAplicarDescuento(string prmUSER_LOGIN, int prmID_CAJA) {
            InitializeComponent();
            varUSER_LOGIN = prmUSER_LOGIN;
            varID_CAJA = prmID_CAJA;
        }
        string varUSER_LOGIN = "";
        int varID_CAJA = 0;
        public bool _Accion = false;
        private void frmVentasAplicarDescuento_Load(object sender, EventArgs e)
        {
            btnAceptar.MouseHover += new EventHandler(btnAceptar_MouseHover);
            btnCalcelar.MouseHover += new EventHandler(btnCalcelar_MouseHover);
            btnQuitar.MouseHover += new EventHandler(btnQuitar_MouseHover);
            lblMensaje.MouseHover += new EventHandler(lblMensaje_MouseHover);
            txtPORC_DESCUENTO.MouseHover += new EventHandler(txtPORC_DESCUENTO_MouseHover);
            txtPORC_DESCUENTO.KeyPress += new KeyPressEventHandler(txtPORC_DESCUENTO_KeyPress);
        }

        void txtPORC_DESCUENTO_KeyPress(object sender, KeyPressEventArgs e)
        {
   
        }

        void txtPORC_DESCUENTO_MouseHover(object sender, EventArgs e)
        {
            lblMensaje.Text = "Indique el porcentaje en un valor entrero de 1 a 100";
        }

        void lblMensaje_MouseHover(object sender, EventArgs e)
        {
            lblMensaje.Text = "Se recomienda aplicar el descuento cuando ya se hayan agregado todos los articulos a vender";
        }

        void btnQuitar_MouseHover(object sender, EventArgs e)
        {
            lblMensaje.Text = "Clic aqui para quitar el descuento";
        }

        void btnCalcelar_MouseHover(object sender, EventArgs e)
        {
            lblMensaje.Text = "Clic aqui para cerrar esta ventana sin aplicar descuento";
        }

        void btnAceptar_MouseHover(object sender, EventArgs e)
        {
            lblMensaje.Text = "Clic aqui para aplicar el descuento";
        }

        bool AplicarDescuento(string prmUSER_LOGIN,int prmID_CAJA, int prmPORCENTAJE)
        {
            try
            {
                OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand("UPDATE TEMP_VENTA SET DESCUENTO=(CANTIDAD*PRECIO)*(" + prmPORCENTAJE + "/100), DESCUENTO_MONEDA=((CANTIDAD*PRECIO)*(" + prmPORCENTAJE + "/100))/TIPO_CAMBIO WHERE ID_CAJA=" + prmID_CAJA + " AND USER_LOGIN='" + prmUSER_LOGIN + "'", cnn);
                cmd.ExecuteNonQuery();
                cnn.Close();
                cmd.Dispose();
                cnn.Dispose();
                MessageBox.Show("Se aplicó el " + prmPORCENTAJE.ToString() + "  % de descuento",
                    "Descuento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return (true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false);
            }
        }
        bool QuitarDescuento(string prmUSER_LOGIN, int prmID_CAJA)
        {
            try
            {
                OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand("UPDATE TEMP_VENTA SET DESCUENTO=0 WHERE ID_cAJA=" + prmID_CAJA + " AND USER_LOGIN='"+ prmUSER_LOGIN +"'", cnn);
                cmd.ExecuteNonQuery();
                cnn.Close();
                cmd.Dispose();
                cnn.Dispose();
                MessageBox.Show("Se quitó el descuento ",
                    "Descuento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return (true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("¿Desea realmente quitar el descuento?",
                "Descuento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                _Accion = QuitarDescuento(varUSER_LOGIN,varID_CAJA);
                if (_Accion)
                {
                    this.Close();
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPORC_DESCUENTO.Text != "")
                {
                    if ((Convert.ToDouble(txtPORC_DESCUENTO.Text) < 1) || (Convert.ToDouble(txtPORC_DESCUENTO.Text) > 100))
                    {
                        MessageBox.Show("El descuento debe ser entre 1 y 100 ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DialogResult res = MessageBox.Show("¿Desea realmente aplicar el " + txtPORC_DESCUENTO.Text + " % de descuento?",
                        "Descuento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        if (!frmLogin.PERMITIR_CANCELAR)
                        {
                            MessageBox.Show("Requiere permisos para aplicar el descuento. Consulte con su administrador", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        _Accion = AplicarDescuento(varUSER_LOGIN, varID_CAJA, Convert.ToInt32(txtPORC_DESCUENTO.Text));
                        if (_Accion)
                        {
                            this.Close();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnCalcelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
