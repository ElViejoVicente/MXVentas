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
    public partial class frmCreditoAbonoMultiple : Telerik.WinControls.UI.RadForm
    {
        public frmCreditoAbonoMultiple(int pFolioVenta)
        {
            InitializeComponent();
            FolioVenta = pFolioVenta;
        }
        int FolioVenta = 0;
        double TotalDeuda = 0;
        int idCliente = 0;
        bool success = false;
        public Boolean Success { get { return success; } }
        private void frmCreditoAbonoMultiple_Load(object sender, EventArgs e)
        {
            try {
                
                ObtenNombreCliente(FolioVenta);
                InicializaPOS(frmLogin._USER_LOGIN);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                cboIdPOS.ValueMember = "ID_CAJA";
            }
            catch (Exception ex) { throw (ex); }
            finally { cnn.Close(); }
        }
        void ObtenNombreCliente(int pFolioVenta)
        {
            OleDbConnection cnnRead = new OleDbConnection(Class.clsMain.CnnStr);
            try
            {

                cnnRead.Open();
                OleDbCommand cmdRead = new OleDbCommand();
                cmdRead.Connection = cnnRead;
                //obtenemos nombre del cliente:

                cmdRead.CommandText = "SELECT C.NOMBRE,C.ID_CLIENTE FROM CAT_CLIENTE C, VENTA V WHERE V.ID_CLIENTE=C.ID_CLIENTE AND V.FOLIO=@FOLIO_VENTA";
                cmdRead.Parameters.Add("@FOLIO_VENTA", OleDbType.Integer).Value = pFolioVenta;
                OleDbDataReader drRead = cmdRead.ExecuteReader();
                if (drRead.Read())
                {
                    lblDatos.Text = string.Format("Id Cliente: {0}\nNombre: {1}", drRead["ID_CLIENTE"], drRead["NOMBRE"]);
                    idCliente = Convert.ToInt32(drRead["ID_CLIENTE"]);

                }
                drRead.Close();
                cmdRead.Parameters.Clear();

                //Recuperamos el saldo del cliente:
                cmdRead.CommandText = "spSALDO_CLIENTE";
                cmdRead.CommandType = CommandType.StoredProcedure;
                cmdRead.Parameters.Add("@ID_CLIENTE", OleDbType.Integer).Value = idCliente;
                drRead = cmdRead.ExecuteReader();
                while (drRead.Read())
                {
                    lblDatos.Text += "\nPor pagar: " + String.Format("{0:C}", drRead["TOTAL"]);
                    lblDatos.Text += "\nPagado: " + String.Format("{0:C}", drRead["PAGADO"]);
                    lblDatos.Text += "\nResto: " + String.Format("{0:C}", drRead["RESTO"]); ;
                    txtIMPORTE.Text = drRead["RESTO"].ToString();
                    TotalDeuda += Convert.ToDouble(drRead["RESTO"]);
                }
                drRead.Close();
                


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally { cnnRead.Close(); }
        }
        void txtIMPORTE_KeyPress(object sender, KeyPressEventArgs e)
        {
   
        }
        bool fnPagar(int prmID_CLIENTE, double prmIMPORTE)
        {
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
                while (varGASTADO < varIMPORTE)
                {
                    OleDbConnection cnnRead = new OleDbConnection(Class.clsMain.CnnStr);
                    cnnRead.Open();
                    OleDbCommand cmdRead = new OleDbCommand("spPENDIENTE_COBRO_CLIENTE_RESTO", cnnRead);
                    cmdRead.CommandType = CommandType.StoredProcedure;
                    cmdRead.Parameters.Add("prmID_CLIENTE", OleDbType.Integer).Value = prmID_CLIENTE;
                    OleDbDataReader drRead = cmdRead.ExecuteReader();
                    while (drRead.Read())
                    {
                        varFOLIO_VENTA = Convert.ToInt32(drRead["FOLIO_VENTA"]);
                        varPOR_GASTAR = Convert.ToDouble(drRead["RESTO"]);
                        if (varPOR_GASTAR > (varIMPORTE - varGASTADO))
                        {
                            varPOR_GASTAR = varIMPORTE - varGASTADO;
                        }
                        cmdPagar.Parameters.Clear();
                        cmdPagar.CommandText = "INSERT INTO PAGO_CREDITO(FOLIO_VENTA,CANTIDAD,USER_LOGIN)" +
                            " VALUES (@FOLIO_VENTA,@POR_GASTAR,@USER_LOGIN)";
                        cmdPagar.Parameters.Add("@FOLIO_VENTA", OleDbType.Integer).Value = varFOLIO_VENTA;
                        cmdPagar.Parameters.Add("@POR_PAGAR", OleDbType.Double).Value = varPOR_GASTAR;
                        cmdPagar.Parameters.Add("@USER_LOGIN", OleDbType.VarChar, 50).Value = frmLogin._USER_LOGIN;
                        cmdPagar.ExecuteNonQuery();
                        cmdPagar.Parameters.Clear();
                        cmdPagar.CommandText = "UPDATE CREDITO SET PAGADO=PAGADO+@POR_PAGAR WHERE FOLIO_VENTA=@FOLIO_VENTA";
                        cmdPagar.Parameters.Add("@POR_PAGAR", OleDbType.Double).Value = varPOR_GASTAR;
                        cmdPagar.Parameters.Add("@FOLIO_VENTA", OleDbType.Integer).Value = varFOLIO_VENTA;
                        cmdPagar.ExecuteNonQuery();
                        cmdPagar.Parameters.Clear();
                        //ACTUALIZAMOS LA TABLA DE MONTO INICIAL
                        cmdPagar.CommandText = "UPDATE SALE_START_AMOUNT SET SALE_DATE_END=@SALE_DATE_END WHERE ID_POS=pID_POS AND USER_LOGIN=pUSER_LOGIN";
                        cmdPagar.Parameters.Add("@SALE_DATE_END", OleDbType.Date).Value = DateTime.Now;
                        cmdPagar.Parameters.Add("pID_POS", OleDbType.SmallInt).Value = cboIdPOS.SelectedValue;
                        cmdPagar.Parameters.Add("pUSER_LOGIN", OleDbType.VarChar, 50).Value = frmLogin._USER_LOGIN;
                        cmdPagar.ExecuteNonQuery();
                        cmdPagar.Parameters.Clear();//limpiamos parametros
                        varGASTADO += varPOR_GASTAR;
                        if (varGASTADO >= varIMPORTE)
                        {
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
            finally
            {
                cnnPagar.Close();
                cnnPagar.Dispose();
                cmdPagar.Dispose();
                tranPagar.Dispose();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            success = false;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboIdPOS.Text == "")
                {
                    throw (new Exception("Seleccione una caja"));
                }
                if (txtIMPORTE.Text == "")
                {
                    txtIMPORTE.BackColor = Color.Yellow;
                    txtIMPORTE.Focus();
                    return;
                }
                if (Convert.ToDouble(txtIMPORTE.Text) <= TotalDeuda)
                {
                    success = fnPagar(idCliente, Convert.ToDouble(txtIMPORTE.Text));
                    if (success)
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("El importe a pagar es mayor a la deuda.\n" +
                               "No puede pagar mas de: " + TotalDeuda.ToString("C"),
                               "Información del sistema",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
