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
    public partial class frmCredito : Telerik.WinControls.UI.RadForm
    {
        Class.clsVentas _clsVentas = new Class.clsVentas();
        public frmCredito(int prmFOLIO_VENTA)
        {
            InitializeComponent();          
            varFOLIO_VENTA=prmFOLIO_VENTA;
        }        
        int varFOLIO_VENTA = 0;
        public static bool _Accion = false;
        private void frmCredito_Load(object sender, EventArgs e)
        {
            double varCantidad = _clsVentas.FnBuscaMontoTicket(varFOLIO_VENTA);
            txtCANTIDAD.Text = String.Format("{0:C}", varCantidad);
            txtCLIENTE.Text = _clsVentas.FnBuscaClienteTicket(varFOLIO_VENTA);       
        }
        private bool fnCREDITO(int prmFOLIO_VENTA,double prmINT_MENSUAL, double prmCANTIDAD, string prmUSER_LOGIN,double prmPRIMER_PAGO)
        {
            int RowCount = 0;
            int IdCliente = 0;
            double LimCredito = 0;
            bool Credito = false;
            double SaldoActual = 0;
            OleDbConnection cnnCREDITO = new OleDbConnection(Class.clsMain.CnnStr);
            OleDbTransaction myTran;
            cnnCREDITO.Open();
            myTran = cnnCREDITO.BeginTransaction();
            try
            {
                OleDbCommand cmdCREDITO = new OleDbCommand();
                cmdCREDITO.Connection = cnnCREDITO;
                cmdCREDITO.Transaction = myTran;
                //Validamos si existe la venta
                if (prmCANTIDAD<= prmPRIMER_PAGO) { throw (new Exception("Error, los datos no pueden considerarse como un crédito.\nLa cantidad a pagar es menor que el primer pago")); }
                cmdCREDITO.CommandText = "SELECT COUNT(*) FROM VENTA WHERE FOLIO=@FOLIO_VENTA";
                cmdCREDITO.Parameters.Add("@FOLIO_VENTA", OleDbType.Integer).Value = prmFOLIO_VENTA;
                RowCount = Convert.ToInt32(cmdCREDITO.ExecuteScalar());
                if (RowCount == 0) { throw(new Exception("El folio de la venta no existe"));}
                cmdCREDITO.Parameters.Clear();
                //obtenemos el ID del Cliente
                cmdCREDITO.CommandText = "SELECT ID_CLIENTE FROM VENTA WHERE FOLIO=@FOLIO_VENTA";
                cmdCREDITO.Parameters.Add("@FOLIO_VENTA", OleDbType.Integer).Value = prmFOLIO_VENTA;
                IdCliente = Convert.ToInt32(cmdCREDITO.ExecuteScalar());
                cmdCREDITO.Parameters.Clear();
                //Validamos si el cliente tiene Credito
                cmdCREDITO.CommandText = "SELECT CREDITO,LIM_CREDITO FROM CAT_CLIENTE WHERE ID_CLIENTE=@ID_CLIENTE";
                cmdCREDITO.Parameters.Add("@ID_CLIENTE", OleDbType.Integer).Value = IdCliente;
                OleDbDataReader dr = cmdCREDITO.ExecuteReader();
                if (dr.Read()) {
                    LimCredito = Convert.ToDouble(dr["LIM_CREDITO"]);
                    Credito = Convert.ToBoolean(dr["CREDITO"]);
                }
                dr.Close();
                cmdCREDITO.Parameters.Clear();
                if (!Credito) { throw (new Exception("El Cliente no tiene habilitado el Crédito")); }
                //Validamos si el cliente tiene suficiente Crédito
                //Primero obtenemos su saldo actual
                cmdCREDITO.CommandText = "spSALDO_CLIENTE";
                cmdCREDITO.CommandType = CommandType.StoredProcedure;
                cmdCREDITO.Parameters.Add("@ID_CLIENTE", OleDbType.Integer).Value = IdCliente;
                dr = cmdCREDITO.ExecuteReader();
                if (dr.Read())
                {
                    SaldoActual = Convert.ToDouble(dr["RESTO"]);
                }
                dr.Close();
                cmdCREDITO.CommandType = CommandType.Text;
                cmdCREDITO.Parameters.Clear();
                if (((SaldoActual + prmCANTIDAD) - prmPRIMER_PAGO) > LimCredito) { throw (new Exception(String.Format("El Cliente supera su límite crediticio\n\nLímite de Crédito: {0:C}\nSaldo Actual: {1:C}\nCrédito solicitado: {2:C}", LimCredito, SaldoActual, prmCANTIDAD - prmPRIMER_PAGO))); }
                //verificamos que el credito no se repita
                cmdCREDITO.CommandText = "SELECT COUNT(*) FROM CREDITO WHERE FOLIO_VENTA=@FOLIO_VENTA";
                cmdCREDITO.Parameters.Add("@FOLIO_VENTA", OleDbType.Integer).Value = prmFOLIO_VENTA;
                RowCount = Convert.ToInt32(cmdCREDITO.ExecuteScalar());
                if (RowCount != 0) { throw (new Exception("Ya se ha registrado éste credito. El ticket solo puede registrarse una vez")); }
                cmdCREDITO.Parameters.Clear();
                //INSERTAMOS EL CREDITO
                cmdCREDITO.CommandText = "INSERT INTO CREDITO (FOLIO_VENTA,INT_MENSUAL,CANTIDAD,USER_LOGIN,PAGADO) VALUES(@FOLIO_VENTA,@INT_MENSUAL,@CANTIDAD,@USER_LOGIN,@PAGADO)";
                cmdCREDITO.Parameters.Add("@FOLIO_VENTA", OleDbType.Integer).Value = prmFOLIO_VENTA;
                cmdCREDITO.Parameters.Add("@INT_MENSUAL", OleDbType.Double).Value = prmINT_MENSUAL;
                cmdCREDITO.Parameters.Add("@CANTIDAD", OleDbType.Double).Value = prmCANTIDAD;
                cmdCREDITO.Parameters.Add("@USER_LOGIN", OleDbType.VarChar,50).Value =  prmUSER_LOGIN;
                cmdCREDITO.Parameters.Add("@PAGADO", OleDbType.Double).Value = prmPRIMER_PAGO;
                cmdCREDITO.ExecuteNonQuery();
                cmdCREDITO.Parameters.Clear();
                //PAGO
                cmdCREDITO.CommandText = "INSERT INTO PAGO_CREDITO (FOLIO_VENTA,CANTIDAD,USER_LOGIN,OBSERVACIONES) VALUES(@FOLIO_VENTA,@CANTIDAD,@USER_LOGIN,@OBSERVACIONES)";
                cmdCREDITO.Parameters.Add("@FOLIO_VENTA", OleDbType.Integer).Value = prmFOLIO_VENTA;
                cmdCREDITO.Parameters.Add("@CANTIDAD", OleDbType.Double).Value = prmPRIMER_PAGO;
                cmdCREDITO.Parameters.Add("@USER_LOGIN", OleDbType.VarChar, 50).Value = prmUSER_LOGIN;
                cmdCREDITO.Parameters.Add("@OBSERVACIONES", OleDbType.VarChar, 50).Value = "PRIMER PAGO";
                cmdCREDITO.ExecuteNonQuery();
                //imprimimos el ticket
                Class.clsCredito c = new Class.clsCredito();
                c.ImprimeTicketCredito(prmFOLIO_VENTA, myTran, cnnCREDITO);

                myTran.Commit();
                cmdCREDITO.Dispose();
               
                cnnCREDITO.Dispose();
                _Accion = true;

                return (true);
            }
            catch (Exception ex)
            {

                myTran.Rollback();
                throw (ex);

            }
            finally { cnnCREDITO.Close(); }
        }
        void Grabar() {
            try
            {
                if (Validaciones())
                {
                    if (fnCREDITO(varFOLIO_VENTA, 0,
                        _clsVentas.FnBuscaMontoTicket(varFOLIO_VENTA),
                        frmLogin._USER_LOGIN, Convert.ToDouble(txtPAGO.Text)))
                    {
                        this.Close();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message,"Información del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error); }
        }
        bool Validaciones() {
            if (txtPAGO.Text != "")
            {
                return (true);

            }
            else {
                MessageBox.Show("Interés mensual y Pago son requeridos");
                return (false);
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        private void btnCANCEL_Click(object sender, EventArgs e)
        {
            _Accion = false;
            this.Close();
        }
    }
}