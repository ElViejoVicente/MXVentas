using System;
using System.Drawing;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using POSDLL; using POSDLL.Windows.Forms; using POSDLL.Security; using POSDLL.Reporting; using POSDLL.Ticket;
namespace POSApp.Forms
{
    public partial class frmVentasPOS : Telerik.WinControls.UI.RadForm
    {
        public frmVentasPOS()
        {
            InitializeComponent();
        }
        int idPOS = 0;
        /// <summary>
        /// Obtiene el Id de la Caja
        /// </summary>
        public Int32 IdPOS
        {
            get { return idPOS; }
        }
        private void frmSalePOS_Load(object sender, EventArgs e)
        {
            txtStartAmount.KeyPress += new KeyPressEventHandler(txtStartAmount_KeyPress);
            txtUserName.Text = frmLogin._NOMBRE + " " + frmLogin._PATERNO + " " + frmLogin._MATERNO;
            Initialize();
        }

        void txtStartAmount_KeyPress(object sender, KeyPressEventArgs e)
        {

        
        }
        /// <summary>
        /// Mostrar el listado de cajas disponibles
        /// </summary>
        void Initialize()
        {
            OleDbConnection cnnIni = new OleDbConnection(Class.clsMain.CnnStr);
            try
            {
                cnnIni.Open();
                //LLENAMOS EL 
                DataSet dsCaja = new DataSet("dsCaja");
                OleDbCommand cmdCaja = new OleDbCommand();
                cmdCaja.CommandText = "SELECT ID_CAJA, DESC_CAJA FROM CAT_CAJA WHERE [DISPONIBLE]=TRUE ";
                cmdCaja.Connection = cnnIni;
                OleDbDataAdapter daCaja = new OleDbDataAdapter(cmdCaja);
                daCaja.Fill(dsCaja, "cat_pos");
                //LLENAMOS EL COMBO 
                cboIdPOS.DataSource = dsCaja.Tables["cat_pos"];
                cboIdPOS.DisplayMember = "DESC_CAJA";
                cboIdPOS.ValueMember = "ID_CAJA";
                if (cboIdPOS.Items.Count == 0)
                {
                    btnOk.Enabled = false;
                }
                cnnIni.Dispose();
                daCaja.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cnnIni.Close();
            }
        }
        /// <summary>
        /// Abrir Caja
        /// </summary>
        /// <param name="prmIdPOS">Id de la caja</param>
        /// <param name="prmUserLogin">Usuario</param>
        /// <param name="prmStartAmount">Monto inicial</param>
        /// <param name="prmDateSale">Fecha de la venta</param>
        /// <returns></returns>
        bool OpenPOS(int prmIdPOS, string prmUserLogin, double prmStartAmount, DateTime prmDateSale)
        {
            OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
            try
            {
                cnn.Open();
                OleDbTransaction tran = cnn.BeginTransaction();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Transaction = tran;
                cmd.Connection = cnn;
                try
                {
                    cmd.CommandText = "UPDATE CAT_cAJA SET DISPONIBLE=FALSE WHERE ID_CAJA=@ID_POS";
                    //parametros
                    //actualizamos la caja
                    cmd.Parameters.Add("@ID_POS", OleDbType.Integer).Value = prmIdPOS;
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    //insertamos el monto inicial
                    cmd.CommandText = "INSERT INTO SALE_START_AMOUNT (ID_POS,SALE_DATE,START_AMOUNT,USER_LOGIN,SALE_DATE_END) VALUES (@ID_POS,@SALE_DATE,@START_AMOUNT,@USER_LOGIN,NOW())";
                    cmd.Parameters.Add("@ID_POS", OleDbType.Integer).Value = prmIdPOS;
                    cmd.Parameters.Add("@SALE_DATE", OleDbType.Date).Value = prmDateSale;
                    cmd.Parameters.Add("@START_AMOUNT", OleDbType.Double).Value = prmStartAmount;
                    cmd.Parameters.Add("@USER_LOGIN", OleDbType.VarChar,50).Value = frmLogin._USER_LOGIN;
                    cmd.ExecuteNonQuery();
                    idPOS = prmIdPOS;
                    //confirmar transaccion
                    tran.Commit();
                    return (true);
                }
                catch (OleDbException ex1) {
                    tran.Rollback();
                    MessageBox.Show(ex1.Message, "Información del Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return (false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false);
            }
            finally
            {
                cnn.Close();
            }
        }

        private void btnCANCEL_Click(object sender, EventArgs e)
        {
            idPOS = 0;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //validations
            if (txtStartAmount.Text == "")
            {
                txtStartAmount.BackColor = Color.Yellow;
                txtStartAmount.Focus();
                return;
            }
            if (OpenPOS(Convert.ToInt32(cboIdPOS.SelectedValue),
                frmLogin._USER_LOGIN,
                Convert.ToDouble(txtStartAmount.Text),
                DateTime.Now))
            {
                this.Close();
            }
        }
    }
}
