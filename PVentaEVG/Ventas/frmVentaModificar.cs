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
    public partial class frmVentaModificar : Telerik.WinControls.UI.RadForm
    {
        public frmVentaModificar()
        {
            InitializeComponent();
        }
        double varMAX_DESCUENTO = 0;
        double varTOTAL = 0;
        public frmVentaModificar(string prmUSER_LOGIN,int prmID_CAJA,string prmID_PRODUCTO)
        {
            InitializeComponent();
            txtPRECIO.KeyPress += new KeyPressEventHandler(txtPRECIO_KeyPress);
            varID_CAJA = prmID_CAJA;
            varID_PRODUCTO = prmID_PRODUCTO;
            varUSER_LOGIN = prmUSER_LOGIN; 
        }

        void txtPRECIO_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        private string varID_PRODUCTO;
        private int varID_CAJA;
        private string varUSER_LOGIN;
        public static bool _Accion = false;
        private decimal PRECIO_VENTA = 0;
        private void frmModificaVenta_Load(object sender, EventArgs e)
        {
            txtPRECIO.Enabled = frmLogin._CATALOGOS;
            LoadSale(varUSER_LOGIN, varID_CAJA, varID_PRODUCTO);
            txtMAX_DESCUENTO.Text = String.Format("{0:C}",varMAX_DESCUENTO);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
        void LoadSale(string prmUSER_LOGIN, int prmID_CAJA, string prmID_PRODUCTO) {
            try
            {
                OleDbConnection cnnLoadSale = new OleDbConnection(Class.clsMain.CnnStr);
                string varSQL = "SELECT ID_PRODUCTO,DESC_PRODUCTO,CANTIDAD,PRECIO,IMPUESTO,TOTAL,DESCUENTO" +
                    " FROM vTEMP_VENTAS WHERE USER_LOGIN = '" + prmUSER_LOGIN + "" +
                "' AND ID_CAJA = " + prmID_CAJA + " and ID_PRODUCTO = '" + prmID_PRODUCTO +"'";
                OleDbCommand cmdLoadSale = new OleDbCommand(varSQL, cnnLoadSale);
                OleDbDataReader drLoadSale;
                if (cnnLoadSale.State == ConnectionState.Open)
                    cnnLoadSale.Close();
                cnnLoadSale.Open();
                drLoadSale = cmdLoadSale.ExecuteReader();
                drLoadSale.Read();

                txtID_PRODUCTO.Text = drLoadSale["ID_PRODUCTO"].ToString();
                txtDESC_PRODUCTO.Text = drLoadSale["DESC_PRODUCTO"].ToString();
                txtCANTIDAD.Text = drLoadSale["CANTIDAD"].ToString();
                txtNVA_CANTIDAD.Text = drLoadSale["CANTIDAD"].ToString();
                txtPRECIO.Text =  drLoadSale["PRECIO"].ToString();
                PRECIO_VENTA = Convert.ToDecimal(drLoadSale["PRECIO"]);
                txtTOTAL.Text = String.Format("{0:C}", drLoadSale["TOTAL"]);
                varTOTAL = Convert.ToDouble(drLoadSale["TOTAL"]);
                txtDESCUENTO.Text = drLoadSale["DESCUENTO"].ToString();
                drLoadSale.Close();
                cmdLoadSale.CommandText = "SELECT DESCUENTO " +
                    " FROM CAT_PRODUCTO WHERE ID_PRODUCTO ='"+ prmID_PRODUCTO +"'";                
                varMAX_DESCUENTO = (Convert.ToDouble(cmdLoadSale.ExecuteScalar())/100) * varTOTAL;
                cmdLoadSale.Dispose();
                cnnLoadSale.Close();
                cnnLoadSale.Dispose();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool Update(string prmUSER_LOGIN, int prmID_CAJA, string prmID_PRODUCTO, 
            double prmCANTIDAD,double prmDESCUENTO,double prmPRECIO_VENTA)
        {
            //Para agregar Nuevo
            string varSQL = "";
            if (prmCANTIDAD == 0)
            {
                varSQL = "DELETE FROM TEMP_VENTA WHERE USER_LOGIN = '" + prmUSER_LOGIN + "'" +
                " AND ID_CAJA = " + prmID_CAJA + " and ID_PRODUCTO = '" + prmID_PRODUCTO + "'";
            }
            else {
                varSQL = "UPDATE TEMP_VENTA SET CANTIDAD = " + prmCANTIDAD + 
                    ",DESCUENTO="+ prmDESCUENTO +",PRECIO="+ prmPRECIO_VENTA +" "+
                    " WHERE USER_LOGIN = '" + prmUSER_LOGIN + "'" +
                    " AND ID_CAJA = " + prmID_CAJA + " and ID_PRODUCTO = '" + prmID_PRODUCTO + "'";
            }
            try
            {
                OleDbConnection cnnUpdate = new OleDbConnection(Class.clsMain.CnnStr);
                if (cnnUpdate.State == ConnectionState.Open)
                    cnnUpdate.Close();
                cnnUpdate.Open();
                OleDbCommand cmdUpdate = new OleDbCommand(varSQL, cnnUpdate);
                cmdUpdate.ExecuteNonQuery();
                _Accion = true;
                cmdUpdate.Dispose();
                cnnUpdate.Close();
                cnnUpdate.Dispose();
                return (true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return (false);
            }
        }
        void Grabar()
        {
            try
            {
                if ((txtNVA_CANTIDAD.Text != "") && (txtDESCUENTO.Text != ""))
                {
                    //descuento
                    if (Convert.ToDouble(txtDESCUENTO.Text) > varMAX_DESCUENTO)
                    {
                        if (!frmLogin.PERMITIR_CANCELAR)
                        {
                            MessageBox.Show("Requiere permisos para aplicar descuentos. Consulte con su administrador",
                                "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    } 
                    //cantidad
                    if (Convert.ToDouble(txtCANTIDAD.Text) > Convert.ToDouble(txtNVA_CANTIDAD.Text)) {
                        if (!frmLogin.PERMITIR_CANCELAR)
                        {
                            MessageBox.Show("Requiere permisos para modificar la cantidad. Consulte con su administrador",
                                "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    //precio venta
                    if (Convert.ToDecimal(txtPRECIO.Text) <  PRECIO_VENTA) {
                        if (!frmLogin.PERMITIR_CANCELAR)
                        {
                            MessageBox.Show("Requiere permisos para modificar el precio de venta. Consulte con su administrador",
                                "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    if (Update(varUSER_LOGIN, varID_CAJA, varID_PRODUCTO,
                        Convert.ToDouble(txtNVA_CANTIDAD.Text),
                        Convert.ToDouble(txtDESCUENTO.Text),
                        Convert.ToDouble(txtPRECIO.Text)))
                    {
                        this.Close();
                    }
                    
                    
                    else
                    {
                        MessageBox.Show("El descuento máximo permitido es de " +
                            String.Format("{0:C}", varMAX_DESCUENTO),
                            "Información del Sistema", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        txtDESCUENTO.BackColor = Color.Yellow;
                        txtDESCUENTO.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Introduce nueva cantidad",
                        "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Grabar();
        } 
    }
}