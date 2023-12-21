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
    public partial class frmCreditoPago : Telerik.WinControls.UI.RadForm
    {
        public frmCreditoPago(int prmTicket)
        {
            InitializeComponent();
            Inicializa(prmTicket);
        }
        int varID_CLIENTE = 0;
        double varTOTAL_DEUDA = 0;
        public bool _Accion = false;
        private void frmCreditoPago_Load(object sender, EventArgs e)
        {
            txtIMPORTE.KeyPress += new KeyPressEventHandler(txtIMPORTE_KeyPress);
            Encabezados();
            ObtenNombreCliente(varID_CLIENTE);
            ReadData(varID_CLIENTE);
        }
        protected void Inicializa(int prmFolioTicket) {
            OleDbConnection cnnRead = new OleDbConnection(Class.clsMain.CnnStr);
            try
            {

                cnnRead.Open();
                OleDbCommand cmdRead = new OleDbCommand();
                cmdRead.Connection = cnnRead;

                //Recuperamos el saldo del cliente:
                cmdRead.CommandText = "SELECT ID_CLIENTE FROM VENTA WHERE FOLIO=@ID";
                cmdRead.Parameters.Add("@ID", OleDbType.Integer).Value = prmFolioTicket;
                varID_CLIENTE = Convert.ToInt32(cmdRead.ExecuteScalar());

               


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally { cnnRead.Close(); }
        }
        void Encabezados() {
            lvPagos.View = View.Details;
            lvPagos.Columns.Add("Ticket", 50, HorizontalAlignment.Left);
            lvPagos.Columns.Add("Total", 70, HorizontalAlignment.Right);
            lvPagos.Columns.Add("Pagado", 70, HorizontalAlignment.Right);
            lvPagos.Columns.Add("Resto", 70, HorizontalAlignment.Right);
        }
        void ReadData(int prmID_CLIENTE) {
            OleDbConnection cnnRead = new OleDbConnection(Class.clsMain.CnnStr);
            try
            {

                cnnRead.Open();
                OleDbCommand cmdRead = new OleDbCommand();
                cmdRead.Connection = cnnRead;

                //Recuperamos el saldo del cliente:
                cmdRead.CommandText = "spPENDIENTE_COBRO_CLIENTE";
                cmdRead.CommandType = CommandType.StoredProcedure;
                cmdRead.Parameters.Add("@id", OleDbType.Integer).Value = prmID_CLIENTE;
                OleDbDataReader drRead = cmdRead.ExecuteReader();
                int I = 0;
                lvPagos.Items.Clear();
                while (drRead.Read())
                {
                    lvPagos.Items.Add(drRead["FOLIO_VENTA"].ToString());
                    lvPagos.Items[I].SubItems.Add(String.Format("{0:C}", drRead["TOTAL"]));
                    lvPagos.Items[I].SubItems.Add(String.Format("{0:C}", drRead["PAGADO"]));
                    lvPagos.Items[I].SubItems.Add(String.Format("{0:C}", drRead["RESTO"]));
                    I += 1;
                }
                drRead.Close();
                cnnRead.Close();
                cmdRead.Dispose();
                cmdRead.Dispose();


            }
            catch (Exception ex)
            {
                lblNombreCliente.Text += "\nReadData" + ex.Message;
            }
            finally { cnnRead.Close(); }
        }
        void ObtenNombreCliente(int prmID_CLIENTE) {
            OleDbConnection cnnRead = new OleDbConnection(Class.clsMain.CnnStr);
            try
            {

                cnnRead.Open();
                OleDbCommand cmdRead = new OleDbCommand();
                cmdRead.Connection = cnnRead;
                //obtenemos nombre del cliente:
                cmdRead.CommandText = "SELECT NOMBRE FROM CAT_CLIENTE WHERE ID_CLIENTE=" + prmID_CLIENTE + "";
                lblNombreCliente.Text = "Cliente: " + cmdRead.ExecuteScalar().ToString();
                //Recuperamos el saldo del cliente:
                cmdRead.CommandText = "spSALDO_CLIENTE";
                cmdRead.Parameters.Add("prmID_CLIENTE", OleDbType.Integer).Value = prmID_CLIENTE;
                cmdRead.CommandType = CommandType.StoredProcedure;
                OleDbDataReader drRead = cmdRead.ExecuteReader();
                while (drRead.Read())
                {
                    lblNombreCliente.Text += "\nPor pagar: " + String.Format("{0:C}", drRead["TOTAL"]);
                    lblNombreCliente.Text += "\nPagado: " + String.Format("{0:C}", drRead["PAGADO"]);
                    lblNombreCliente.Text += "\nResto: " + String.Format("{0:C}", drRead["RESTO"]); ;
                    txtIMPORTE.Text = drRead["RESTO"].ToString();
                    varTOTAL_DEUDA += Convert.ToDouble(drRead["RESTO"]);
                }
                drRead.Close();

            }
            catch (Exception ex)
            {
                lblNombreCliente.Text += "ObtenNombreCliente" + ex.Message;
            }
            finally { cnnRead.Close(); }
        }
        void txtIMPORTE_KeyPress(object sender, KeyPressEventArgs e)
        {

     
        }
        bool fnPagar(int prmID_CLIENTE, double prmIMPORTE) {
            OleDbConnection cnnPagar = new OleDbConnection(Class.clsMain.CnnStr);
            cnnPagar.Open();
            OleDbTransaction tranPagar = cnnPagar.BeginTransaction();
            OleDbCommand cmdPagar = new OleDbCommand();
            cmdPagar.Connection = cnnPagar;
            cmdPagar.Transaction = tranPagar;
            double varIMPORTE = prmIMPORTE;
            double varGASTADO = 0;
            double varPOR_GASTAR = 0;
            int varFOLIO_VENTA = 0;
            try
            {
                //comenzamos la transacción
                while (varGASTADO < varIMPORTE) {
                    OleDbConnection cnnRead= new OleDbConnection(Class.clsMain.CnnStr);
                    cnnRead.Open();
                    OleDbCommand cmdRead = 
                        new OleDbCommand("EXECUTE spPENDIENTE_COBRO_CLIENTE_RESTO " + prmID_CLIENTE + "", cnnRead);
                    OleDbDataReader drRead = cmdRead.ExecuteReader();
                    while (drRead.Read()) {
                        varFOLIO_VENTA = Convert.ToInt32(drRead["FOLIO_VENTA"]);
                        varPOR_GASTAR = Convert.ToDouble(drRead["RESTO"]);
                        if (varPOR_GASTAR > (varIMPORTE - varGASTADO)) {
                            varPOR_GASTAR = varIMPORTE - varGASTADO;
                        }
                        cmdPagar.CommandText = "INSERT INTO PAGO_CREDITO(FOLIO_VENTA,CANTIDAD,USER_LOGIN)" +
                            "VALUES ("+ varFOLIO_VENTA +","+ varPOR_GASTAR +",'"+ frmLogin._USER_LOGIN +"')";
                        cmdPagar.ExecuteNonQuery();
                        varGASTADO += varPOR_GASTAR;
                        if (varGASTADO >= varIMPORTE) {
                            break;
                        }
                    }
                    drRead.Close();
                    cnnRead.Close();
                    cnnRead.Dispose();
                    cmdRead.Dispose();
                }
                tranPagar.Commit();
                return (true);
            }
            catch (Exception ex)
            {
                tranPagar.Rollback();
                MessageBox.Show(ex.Message, "Información del sistema - fnPagar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false);
                
            }
            finally {
                cnnPagar.Close();
                cnnPagar.Dispose();
                cmdPagar.Dispose();
                tranPagar.Dispose();
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (txtIMPORTE.Text != "") {
                if (Convert.ToDouble(txtIMPORTE.Text) <= varTOTAL_DEUDA)
                {
                    if (fnPagar(varID_CLIENTE, Convert.ToDouble(txtIMPORTE.Text)))
                    {
                        ObtenNombreCliente(varID_CLIENTE);
                        ReadData(varID_CLIENTE);
                    }
                }
                else {
                    MessageBox.Show("El importe a pagar es mayor a la deuda.\n" +
                        "No puede pagar mas de: " + varTOTAL_DEUDA.ToString("c"),
                        "Información del sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void lblNombreCliente_Click(object sender, EventArgs e)
        {

        }
    }
}