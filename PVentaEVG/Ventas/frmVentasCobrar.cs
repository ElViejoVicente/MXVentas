using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSDLL;
using POSDLL.Windows.Forms;
using POSDLL.Security;
using POSDLL.Reporting;
using POSDLL.Ticket;
namespace POSApp.Forms
{
    public partial class frmVentasCobrar : Telerik.WinControls.UI.RadForm
    {
        Class.clsVentas _clsVentas = new Class.clsVentas();
        int varFolio = 0;
        public int FOLIO_VENTA { get { return varFolio; } }
        double varTotal = 0;
        string varUSER_LOGIN;
        int varID_CAJA = 0;
        int varID_CLIENTE = 0;
        //variables del cliente ==>
        string varRFC;
        string varCURP;
        string varNOMBRE;
        string varDOMICILIO;
        string varID_ESTADO;
        string varID_MUNICIPIO;
        string varID_LOCALIDAD;
        string varCP;
        string varTELEFONO;
        string varEMAIL;
        string varTIPO_CLIENTE;
        double varLimiteDeCredito = 0;
        Boolean varPermitirCredito = false;
        //<==termina variables de cliente
        private string varId_moneda = "";
        private int varId_tipoCambiodia = 0;
        private Double varTipo_Cambio = 0;
        public static bool _Accion = false;
        //Para manipular el ini 
        //Para encryptar strings       
        public frmVentasCobrar(string prmUSER_LOGIN, int prmID_CAJA, int prmID_CLIENTE, string prmRFC, string prmCURP, string prmNOMBRE, string prmDOMICILIO,
        string prmID_ESTADO, string prmID_MUNICIPIO, string prmID_LOCALIDAD, string prmCP,
            string prmTELEFONO, string prmEMAIL, string prmTIPO_CLIENTE, double prmLimiteDeCredito,  string prmId_moneda ,
         int prmId_tipoCambiodia, Double prmTipo_Cambio )
        {
            InitializeComponent();
            varFolio = 0;
            varUSER_LOGIN = prmUSER_LOGIN;
            varID_CAJA = prmID_CAJA;
            varID_CLIENTE = prmID_CLIENTE;
            varRFC = prmRFC;
            varCURP = prmCURP;
            varNOMBRE = prmNOMBRE;
            varDOMICILIO = prmDOMICILIO;
            varID_ESTADO = prmID_ESTADO;
            varID_MUNICIPIO = prmID_MUNICIPIO;
            varID_LOCALIDAD = prmID_LOCALIDAD;
            varCP = prmCP;
            varTELEFONO = prmTELEFONO;
            varEMAIL = prmEMAIL;
            varTIPO_CLIENTE = prmTIPO_CLIENTE;
            varLimiteDeCredito = prmLimiteDeCredito;
            varPermitirCredito = frmLogin.PERMITIR_CANCELAR;
            varId_moneda = prmId_moneda;
            varId_tipoCambiodia = prmId_tipoCambiodia;
            varTipo_Cambio = prmTipo_Cambio;
        }
        private void frmCobrar_Load(object sender, EventArgs e)
        {
            dtpFECHA_OPERACION.Value = DateTime.Now;

            try
            {
                txtEfectivo.Focus();

                cboTIPO_PAGO.SelectionChangeCommitted += new EventHandler(cboTIPO_PAGO_SelectionChangeCommitted);
                chkCREDITO.CheckedChanged += new EventHandler(chkCREDITO_CheckedChanged);
                cboTIPO_PAGO.SelectedIndex = 0;
                varTotal = fnCalculaPago(varUSER_LOGIN, varID_CAJA);
                txtTotal.Text = String.Format("{0:C}", varTotal);
                txtEfectivo.Text = String.Format("{0:N}", varTotal);
                txtPago.Text = String.Format("{0:N}", 0);
                btnOk.Enabled = true;
                txtCambio.Text = String.Format("{0:C}", 0);
                if (varPermitirCredito)
                {
                    if (varTotal <= varLimiteDeCredito)
                    {
                        chkCREDITO.Visible = true; //chkCREDITO.Checked = true;
                    }
                    else
                    {
                        chkCREDITO.Visible = false;
                    }
                }
                else
                {
                    chkCREDITO.Visible = false;
                }
                txtPago.Focus();
            }
            catch (Exception ex)
            {
                txtCambio.Text = ex.Message;
            }
        }

        void chkCREDITO_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCREDITO.Checked) { txtEfectivo.Text = "0"; }
            else { txtEfectivo.Text = varTotal.ToString("N"); }
            CalculaCambio();
        }

        void cboTIPO_PAGO_SelectionChangeCommitted(object sender, EventArgs e)
        {
//            NINGUNO
//CHEQUE
//TRANS. ELECTRONICA
//TARJETA CREDITO
//TARJETA DEBITO
            if (cboTIPO_PAGO.Text == "TARJETA CREDITO" || cboTIPO_PAGO.Text == "TARJETA DEBITO")
            {
                txtNO_AUTORIZACION.Enabled = true;
                txtDigitos.Enabled = true;
            }
            else if (cboTIPO_PAGO.Text == "TRANS. ELECTRONICA")
            {
                txtNO_AUTORIZACION.Enabled = false;
                txtDigitos.Enabled = true;
                }
            else
            {
                txtNO_AUTORIZACION.Text = "";
                txtNO_AUTORIZACION.Enabled = false;
                txtDigitos.Text = "";
                txtDigitos.Enabled = false;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Cobrar();
        }
        void Cobrar()
        {
            try
            {
                if ((cboTIPO_PAGO.Text == "T. CRED/DEB") && (txtNO_AUTORIZACION.Text == ""))
                {
                    MessageBox.Show("El No de autorización no debe estar vacío",
                        "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if ((txtEfectivo.Text != ""))
                {
                    //Imprmmir el ticket
                    //GenerateTicket(varFolio);
                    varFolio = _clsVentas.RealizaVenta(varUSER_LOGIN, varID_CAJA, varID_CLIENTE,
                        dtpFECHA_OPERACION.Value, varRFC, varCP, varNOMBRE, varDOMICILIO, varID_ESTADO,
                        varID_MUNICIPIO, varID_LOCALIDAD, varCP, varTELEFONO, varEMAIL, varTIPO_CLIENTE,
                        Strings.SafeSqlLikeClauseLiteral(txtOBSERVACIONES.Text), 0,//cboTIPO_PAGO.SelectedValue.ToString(),
                        cboTIPO_PAGO.Text, Convert.ToDouble(txtPago.Text), varId_tipoCambiodia, varId_moneda,
                        varTipo_Cambio, Strings.SafeSqlLikeClauseLiteral(txtNO_AUTORIZACION.Text),
                        txtDigitos.Text.Trim(), chkCREDITO.Checked, Convert.ToDouble(txtEfectivo.Text), varTotal);
                    if (varFolio != 0)
                    {
                        _Accion = true;
                        this.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Error en los datos\nDebe introducir el monto en efectivo e indicar un folio de factura distinto de cero\nSI NO DESEA FACTURAR, DEJE EN BLANCO (VACÍO) EL FOLIO DE LA FACTURA.",
                        "Faltan datos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Información del Sistema");

            }
        }
        void txtEfectivo_KeyPress(object sender,
            System.Windows.Forms.KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                Cobrar();
            }
        }
        void txtEfectivo_TextChanged(object sender, System.EventArgs e)
        {

            CalculaCambio();
        }
        void CalculaCambio()
        {
            try
            {
                btnOk.Enabled = true;

                if (txtEfectivo.Text == "") { btnOk.Enabled = false; }
                else
                {
                    double varCambio = 0;
                    double varEfectivo = 0;
                    double varPago = 0;
                    varEfectivo = Convert.ToDouble(txtEfectivo.Text.Trim());
                    varPago = Convert.ToDouble(txtPago.Text.Trim());
                    varCambio = (varEfectivo + varPago) - varTotal;
                    //txtPago.Text = String.Format("{0:N}", varPago);
                    //txtEfectivo.Text = String.Format("{0:N}", varEfectivo);
                    txtCambio.Text = String.Format("{0:C}", varCambio);
                    if (!chkCREDITO.Checked)
                    {
                        if (varCambio >= 0)
                        {
                            btnOk.Enabled = true;
                        }
                        else
                        {
                            btnOk.Enabled = false;
                        }
                    }
                    else { if (txtEfectivo.Text == "0") { btnOk.Enabled = true; } }
                }
            }
            catch (Exception ex)
            {
                txtCambio.Text = ex.Message;

                btnOk.Enabled = false;
            }
        }
        /// <summary>
        /// Imprime el ticket de compra
        /// </summary>
        /// <param name="prmFolioTicket">Folio del ticket</param>

        private double fnCalculaPago(string prmUSER_LOGIN, int prmID_CAJA)
        {
            try
            {
                OleDbConnection _cnnCalculaPago = new OleDbConnection(Class.clsMain.CnnStr);
                _cnnCalculaPago.Open();
                OleDbCommand _cmdCalculaPago =
                    new OleDbCommand("SELECT sum(TOTAL_MONEDA + TOTIMPUESTO_MONEDA) " +
                    " FROM TEMP_VENTA WHERE USER_LOGIN='" + prmUSER_LOGIN + "' AND ID_CAJA= " + prmID_CAJA + "", _cnnCalculaPago);
                double _return = Convert.ToDouble(_cmdCalculaPago.ExecuteScalar());
                _cnnCalculaPago.Close();
                _cnnCalculaPago.Dispose();
                _cmdCalculaPago.Dispose();
                return (_return);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "fnCalculaPago");
                return (0);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _Accion = false;
            this.Close();
        }

        private void lblDatosCliente_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("==DATOS DEL CLIENTE==\n\n" +
            "NOMBRE: " + varNOMBRE +
            "\nRFC: " + varRFC +
            "\nCURP: " + varCURP +
            "\nDOMICILIO: " + varDOMICILIO +
            "\nCP: " + varCP +
            "\nTELEFONO: " + varTELEFONO +
            "\nESTADO: " + varID_ESTADO +
            "\nMUNICIPIO: " + varID_MUNICIPIO +
            "\nLOCALIDAD:" + varID_LOCALIDAD +
            "\nEMAIL: " + varEMAIL +
            "\nTIPO DE CLIENTE: " + varTIPO_CLIENTE,
                "DATOS DEL CLIENTE", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private string fnFOLIO_FACTURA_NEXT()
        {
            try
            {
                OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
                cnn.Open();
                string ret = "";

                OleDbCommand cmd = new OleDbCommand("SELECT TOP 1 FOLIO_FACTURA FROM FACTURA_CONTROL ORDER BY FECHA_FACTURA DESC ", cnn);
                ret = cmd.ExecuteScalar().ToString();
                cnn.Close();
                cmd.Dispose();
                cnn.Dispose();
                //generamos el folio

                ret = Convert.ToString(Convert.ToInt32(ret) + 1);
                return (ret);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return ("");
            }
        }

        private void txtEfectivo_Leave(object sender, EventArgs e)
        {
            if (txtEfectivo.Text=="")
            {
                txtEfectivo.Text = "0.00";
            }

            if (txtPago.Text=="")
            {
                txtPago.Text = "0.00";
            }

            
            double varEfectivo = 0;
            double varPago = 0;
            varEfectivo = Convert.ToDouble(txtEfectivo.Text.Trim());
            varPago = Convert.ToDouble(txtPago.Text.Trim());
           
            txtPago.Text = String.Format("{0:N}", varPago);
            txtEfectivo.Text = String.Format("{0:N}", varEfectivo);
        }


    }
}