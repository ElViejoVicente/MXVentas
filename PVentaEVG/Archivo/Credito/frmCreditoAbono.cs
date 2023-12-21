using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POSDLL; using POSDLL.Windows.Forms; using POSDLL.Security; using POSDLL.Reporting; using POSDLL.Ticket;
namespace POSApp.Forms
{
    public partial class frmCreditoAbono : Telerik.WinControls.UI.RadForm
    {
        public frmCreditoAbono(int prmFolioCredito)
        {
            FolioCredito = prmFolioCredito;
            InitializeComponent();
            try
            {
                Inicializa(prmFolioCredito);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message,"Información del Sistema"); }
        }
        bool success = false;
        public Boolean Success { get { return success; } }
        double Saldo = 0;
        int FolioCredito = 0;
        private void frmCreditoAbono_Load(object sender, EventArgs e)
        {
            txtIMPORTE.KeyPress += new KeyPressEventHandler(txtIMPORTE_KeyPress);
            InicializaPOS(frmLogin._USER_LOGIN);
            if (Saldo == 0) { MessageBox.Show("El Credito ya está pagado", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information); this.Close(); }
            else { txtIMPORTE.Text = Saldo.ToString(); }
        }
        protected void InicializaPOS(string prmUserLogin)
        {
            OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
            try
            {
                cnn.Open();
                OleDbDataAdapter da = new OleDbDataAdapter();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT ID_CAJA,DESC_CAJA FROM vSALE_POS WHERE DISPONIBLE=FALSE AND USER_LOGIN=@USER_LOGIN";
                cmd.Parameters.Add("@USER_LOGIN", OleDbType.VarChar, 50).Value = prmUserLogin;
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "data");
                cboIdPOS.DataSource = ds.Tables["data"];
                cboIdPOS.DisplayMember = "DESC_CAJA";
                cboIdPOS.ValueMember = "ID_cAJA";
            }
            catch (Exception ex) { throw (ex); }
            finally { cnn.Close(); }
        }
        void txtIMPORTE_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
        protected void Inicializa(int prmFolioCredito) {
            OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
            try
            {
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT RESTO FROM vCREDITO WHERE FOLIO_VENTA=@FOLIO_VENTA";
                cmd.Parameters.Add("@FOLIO_VENTA", OleDbType.Integer).Value = prmFolioCredito;
                Saldo = Convert.ToDouble(cmd.ExecuteScalar());
                cmd.Parameters.Clear();
            }
            catch (Exception ex) { throw (ex); }
            finally { cnn.Close(); }
        }
        protected bool Abonar() {
            int IdAbono = 0;
            double Importe = Convert.ToDouble(txtIMPORTE.Text);
            int IdCliente = 0;
            OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
            OleDbTransaction myTran;
            cnn.Open();
            myTran = cnn.BeginTransaction();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;
                cmd.Transaction = myTran;

                if (Saldo < Importe) { throw (new Exception("Error, el importe es mayor que la deuda")); }

               
              
               
                //PAGO
                cmd.CommandText = "INSERT INTO PAGO_CREDITO (FOLIO_VENTA,CANTIDAD,USER_LOGIN,OBSERVACIONES) VALUES(@FOLIO_VENTA,@CANTIDAD,@USER_LOGIN,@OBSERVACIONES)";
                cmd.Parameters.Add("@FOLIO_VENTA", OleDbType.Integer).Value = FolioCredito;
                cmd.Parameters.Add("@CANTIDAD", OleDbType.Double).Value = Importe;
                cmd.Parameters.Add("@USER_LOGIN", OleDbType.VarChar, 50).Value = frmLogin._USER_LOGIN;
                cmd.Parameters.Add("@OBSERVACIONES", OleDbType.VarChar, 50).Value = "ABONO";
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                //obtenemos el Id
                cmd.CommandText = "SELECT @@IDENTITY";
                IdAbono = Convert.ToInt32(cmd.ExecuteScalar());
                //ACTUALIZAMOS EL SALDO
                cmd.CommandText = "UPDATE CREDITO SET PAGADO=PAGADO+@CANTIDAD WHERE FOLIO_VENTA=@FOLIO_VENTA";
                cmd.Parameters.Add("@CANTIDAD", OleDbType.Double).Value = Importe;
                cmd.Parameters.Add("@FOLIO_VENTA", OleDbType.Integer).Value = FolioCredito;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                //OBTENEMOS EL ID_CLIENTE
                cmd.CommandText = "SELECT ID_CLIENTE FROM VENTA WHERE FOLIO=@FOLIO_VENTA";
                cmd.Parameters.Add("@FOLIO_VENTA", OleDbType.Integer).Value = FolioCredito;
                IdCliente = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Parameters.Clear();
                //ACTUALIZAMOS LA FECHA DE PAGO DEL CLIENTE
                cmd.CommandText = "UPDATE CAT_CLIENTE SET FECHA_PAGO=NOW() WHERE ID_CLIENTE=@ID";
                cmd.Parameters.Add("@ID", OleDbType.Integer).Value = IdCliente;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                //ACTUALIZAMOS LA TABLA DE MONTO INICIAL
                cmd.CommandText = "UPDATE SALE_START_AMOUNT SET SALE_DATE_END=@SALE_DATE_END WHERE ID_POS=pID_POS AND USER_LOGIN=pUSER_LOGIN";
                cmd.Parameters.Add("@SALE_DATE_END", OleDbType.Date).Value = DateTime.Now;
                cmd.Parameters.Add("pID_POS", OleDbType.SmallInt).Value = cboIdPOS.SelectedValue;
                cmd.Parameters.Add("pUSER_LOGIN", OleDbType.VarChar, 50).Value = frmLogin._USER_LOGIN;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();//limpiamos parametros
                //imprimimos el ticket
                Class.clsCredito c = new Class.clsCredito();
                c.ImprimeTicketAbono(IdAbono, myTran, cnn);

                myTran.Commit();
                cmd.Dispose();

                cnn.Dispose();
              
                return (true);
            }
            catch (Exception ex)
            {

                myTran.Rollback();
                throw (ex);

            }
            finally { cnn.Close(); }
        }
        private void btnCANCEL_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboIdPOS.Text == "") {
                    throw(new Exception("Seleccione una caja"));
                }
                if (txtIMPORTE.Text == "") { txtIMPORTE.BackColor = Color.Yellow; return; }
                try { success = Abonar(); if (success) { this.Close(); } }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Información del Sistema"); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }
    }
}
