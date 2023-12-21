using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using POSApp.Forms;
using POSDLL;

namespace POSApp.Administrar.AjustesInventario 
{
    public partial class frmAjuste : Telerik.WinControls.UI.RadForm
    {
        public frmAjuste(int prmFOLIO_AJUSTE)
        {
            InitializeComponent();
            varFOLIO_AJUSTE = prmFOLIO_AJUSTE;
        }
        int varFOLIO_AJUSTE = 0;
        private void frmAjuste_Load(object sender, EventArgs e)
        {
            txtIdProducto.KeyPress += new KeyPressEventHandler(txtIdProducto_KeyPress);
            Inicializa();
        }

        void txtIdProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {
                BuscarProducto2();
            }
        }
       
        private void txtCANTIDAD_AJUSTE_KeyPress(object sender, KeyPressEventArgs e) { 
   
        }
        private void btnCANCEL_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Inicializa()
        {
            try
            {
                DataSet dsInicializa = new DataSet();
                OleDbConnection cnnInicializa = new OleDbConnection(Class.clsMain.CnnStr);
                cnnInicializa.Open();
                //MARCA
                OleDbDataAdapter daCol = new OleDbDataAdapter("SELECT * FROM CAT_TIPO_AJUSTE", cnnInicializa);
                dsInicializa.Clear();
                daCol.Fill(dsInicializa, "TIPO_AJUSTE");
                cboID_TIPO_AJUSTE.DataSource = dsInicializa.Tables["TIPO_AJUSTE"];
                cboID_TIPO_AJUSTE.DisplayMember = "DESC_TIPO_AJUSTE";
                cboID_TIPO_AJUSTE.ValueMember = "ID_TIPO_AJUSTE";
                daCol.Dispose();


                cnnInicializa.Close();
                cnnInicializa.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void BuscaProducto()
        {
            try
            {               
              
                frmBuscaProducto myForm = new frmBuscaProducto();
                myForm.StartPosition = FormStartPosition.CenterScreen;
                myForm.ShowDialog();
                if (!(myForm.producto.ID_PRODUCTO == ""))
                {
                    lblIdProducto.Text = String.Format("Id: {0}\nNombre: {1}\nExistencia: {2:N}", myForm.producto.ID_PRODUCTO, myForm.producto.DESC_PRODUCTO, myForm.producto.EXISTENCIA);
                    lblIdProducto.Tag = myForm.producto.ID_PRODUCTO;
                    txtIdProducto.Text = "";
                    txtCANTIDAD_AJUSTE.Focus();
                }
                myForm.Dispose();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnBuscaProducto",  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void BuscarProducto2()
        {
            try
            {
                if(txtIdProducto.Text==""){throw(new Exception("Falta el id del producto"));}
                Class.clsProducto producto = new Class.clsProducto();
                producto.Buscar(txtIdProducto.Text);
                lblIdProducto.Text = String.Format("Id: {0}\nNombre: {1}\nExistencia: {2:N}", producto.ID_PRODUCTO, producto.DESC_PRODUCTO, producto.EXISTENCIA);
                lblIdProducto.Tag = producto.ID_PRODUCTO;
                txtCANTIDAD_AJUSTE.Focus();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error); txtIdProducto.Text = ""; }
        }
        private void btnBuscaProducto_Click(object sender, EventArgs e)
        {
            BuscaProducto();
        }
        bool TransactionAjuste(string prmFECHA_AJUSTE,string prmID_PRODUCTO,
            double prmCANTIDAD_AJUSTE,string prmOBSERVACIONES,int prmID_TIPO_AJUSTE,string prmUSER_LOGIN)
        {
            //variables a utilizar en esta transaccion          
            string varMensajeFinal = "";
            double varCANTIDAD_ANTES = 0;
            double varCANTIDAD_DESPUES = 0;
            double varPRECIO_COMPRA = 0;
            double varPRECIO_VENTA= 0;
            //
            //este procedimiento graba toda la infortmación de la factura.
            OleDbConnection myConnection = new OleDbConnection(Class.clsMain.CnnStr);
            myConnection.Open();
            // Start a local transaction.
            OleDbTransaction myTrans = myConnection.BeginTransaction();
            // Enlist the command in the current transaction.
            //OleDbCommand myCommand = myConnection.CreateCommand();
            OleDbCommand myCommand = new OleDbCommand();
            myCommand.Connection = myConnection;
            myCommand.Transaction = myTrans;          
            try
            {
                //poner aqui todo el código que deseemos que se ejecute el la transacción
                ////
                myCommand.CommandText = "SELECT EXISTENCIA FROM CAT_PRODUCTO WHERE ID_PRODUCTO = '"+ prmID_PRODUCTO +"'";
                varCANTIDAD_ANTES = Convert.ToDouble(myCommand.ExecuteScalar());
                varCANTIDAD_DESPUES = varCANTIDAD_ANTES + prmCANTIDAD_AJUSTE;
                //obtenemos el precio de compra:
                myCommand.CommandText = "SELECT PRECIO_COMPRA FROM CAT_PRODUCTO WHERE ID_PRODUCTO = '"+ prmID_PRODUCTO +"'";
                varPRECIO_COMPRA = Convert.ToDouble(myCommand.ExecuteScalar());
                //obtenemos el precio de venta
                myCommand.CommandText = "SELECT PRECIO_VENTA FROM CAT_PRODUCTO WHERE ID_PRODUCTO = '" + prmID_PRODUCTO + "'";
                varPRECIO_VENTA = Convert.ToDouble(myCommand.ExecuteScalar());

                myCommand.CommandText = "INSERT INTO AJUSTES_INVENTARIO(FECHA_AJUSTE,ID_PRODUCTO,"+
                    "CANTIDAD_AJUSTE,CANTIDAD_ANTES,CANTIDAD_DESPUES,OBSERVACIONES,USER_LOGIN,ID_TIPO_AJUSTE,PRECIO_COMPRA,PRECIO_VENTA)" +
                    "VALUES(#"+ prmFECHA_AJUSTE +"#,'"+ prmID_PRODUCTO +"',"+ prmCANTIDAD_AJUSTE +","+ varCANTIDAD_ANTES +","+
                    " "+ varCANTIDAD_DESPUES +",'"+ prmOBSERVACIONES +"','"+ prmUSER_LOGIN +"',"+ prmID_TIPO_AJUSTE +","+ varPRECIO_COMPRA +","+ varPRECIO_VENTA +" )";
                myCommand.ExecuteNonQuery();
               
                ////
                myCommand.CommandText = "UPDATE CAT_PRODUCTO SET "+
                    " EXISTENCIA = EXISTENCIA + "+ prmCANTIDAD_AJUSTE +" " +
                    " WHERE ID_PRODUCTO = '"+ prmID_PRODUCTO +"'";
                myCommand.ExecuteNonQuery();
                myTrans.Commit();
                varMensajeFinal = "Transaccion satisfactoria.";
                MessageBox.Show(varMensajeFinal, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


                return (true);
            }
            catch (Exception e)
            {
                try
                {
                    MessageBox.Show(e.Message);
                    myTrans.Rollback();
                    return (false);
                }
                catch (OleDbException ex)
                {
                    if (myTrans.Connection != null)
                    {
                        MessageBox.Show("Error type " + ex.GetType().ToString() +
                            " was found during undoing transaction");
                        return (false);
                    }
                }
                MessageBox.Show(e.Message, "Error-TransactionAjuste", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false);
            }
            finally
            {
                myConnection.Close();              
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblIdProducto.Tag == null) { 
                    throw(new Exception ("Debe especificar un producto"));
                }
                if (txtCANTIDAD_AJUSTE.Text=="")
                {
                    throw (new Exception("Debe indicar la cantidad"));
                }
                if (TransactionAjuste(ISODates.MSAccessDateINI(dtpFECHA_AJUSTE.Value),
                   Strings.SafeSqlLikeClauseLiteral(lblIdProducto.Tag.ToString()),
                   Convert.ToDouble(txtCANTIDAD_AJUSTE.Text),
                   Strings.SafeSqlLikeClauseLiteral(txtOBSERVACIONES.Text),
                   Convert.ToInt32(cboID_TIPO_AJUSTE.SelectedValue), frmLogin._USER_LOGIN))
                {
                    this.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }
    }
}