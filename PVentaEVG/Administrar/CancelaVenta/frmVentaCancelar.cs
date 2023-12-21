using System;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using POSDLL;

namespace POSApp.Forms
{
    public partial class frmVentaCancelar : Telerik.WinControls.UI.RadForm
    {
        public frmVentaCancelar()
        {
            InitializeComponent();
        }
        private void frmCancelarVenta_Load(object sender, EventArgs e)
        {
            
        }
        private void btnBuscarTicket_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaTicket myForm = new frmBuscaTicket();
                myForm.StartPosition = FormStartPosition.CenterScreen;
                myForm.ShowDialog();
                if (frmBuscaTicket.varFOLIO_VENTA != 0)
                {
                    txtFOLIO_VENTA.Text = frmBuscaTicket.varFOLIO_VENTA.ToString();

                }
                myForm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (txtFOLIO_VENTA.Text != "")
            {
                Class.clsVentas _clsVentas = new Class.clsVentas();
                _clsVentas.ImprimeTicket(Convert.ToInt32(txtFOLIO_VENTA.Text), false);

                
            }
            else {
                MessageBox.Show("Debe indicar un folio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            CancelarVenta();
        }
        void CancelarVenta() {
            
            if (txtMotivoCancelacion.Text == "") {
                txtMotivoCancelacion.BackColor = Color.Yellow;
                return;
            }
            
            try
            {
                DialogResult _DialodResult = new DialogResult();
                _DialodResult = MessageBox.Show("¿Cancelar la venta?\nEsta operación no podrá deshacerse", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (_DialodResult == DialogResult.Yes)
                {
                    //aqui eliminar
                    if (CancelTicket(Convert.ToInt32(Strings.SafeSqlLikeClauseLiteral(txtFOLIO_VENTA.Text))))
                    {    //cerrar
                        MessageBox.Show("¡Operación realizada satisfactoriamente!\n"+
                        "Se ha cancelado la venta y las existencias han sido actualizadas", "Información del sistema");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool CancelTicket(int prmFolioVenta)
        {                
            string varSQL2 = "UPDATE VENTA_DETALLE SET " +
                " CANTIDAD=0,PRECIO_VENTA=0,EXISTENCIA_ANTES=0,EXISTENCIA_DESPUES=0,DESCUENTO=0" +
                " WHERE FOLIO ="+ prmFolioVenta +"" +
                "";
            string varSQL3 = "UPDATE VENTA SET " +
                " OBSERVACIONES ='"+ Strings.SafeSqlLikeClauseLiteral(txtMotivoCancelacion.Text) +"'+'CANCELED ' + '"+ DateTime.Now.ToLongDateString() +"'" +
                " WHERE FOLIO =" + prmFolioVenta + "" +
                "";
            string varSQL4 = "DELETE FROM PAGO_CREDITO WHERE FOLIO_VENTA=" + prmFolioVenta + "";//Eliminar los pagos de credito
            string varSQL5 = "DELETE FROM CREDITO WHERE FOLIO_VENTA=" + prmFolioVenta + "";//Eliminar los creditos
            OleDbConnection myConnection = new OleDbConnection(Class.clsMain.CnnStr);
            OleDbConnection cnnRead = new OleDbConnection(Class.clsMain.CnnStr);
            OleDbCommand cmdRead = new OleDbCommand(Class.clsMain.CnnStr);
            OleDbDataReader drRead;
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
                cmdRead.Connection = cnnRead;
                cnnRead.Open();
                ////validamos la factura
                //cmdRead.CommandText = "SELECT COUNT(*) FROM FACTURA_VENTA WHERE FOLIO_VENTA="+ prmFolioVenta +" AND CANCELAR=False";
                int contar = 0;// Convert.ToInt32(cmdRead.ExecuteScalar());
                //if (contar > 0) { 
                //    //rechazamos, por que hay una factura
                //    MessageBox.Show("No se puede cancelar la venta por que tiene una factura asociada.\n"+
                //        "Antes debe cancelar la factura", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    myTrans.Rollback();
                //    myConnection.Close();
                //    cnnRead.Close();
                //    return(false);
                //}
                //checamos si la venta fué facturada
                cmdRead.CommandText = "SELECT COUNT(*) FROM VENTA WHERE FOLIO="+prmFolioVenta +" AND STATUS ='F'";
                contar = Convert.ToInt32(cmdRead.ExecuteScalar());

                cmdRead.CommandText = "SELECT ID_PRODUCTO,CANTIDAD "+
                    " FROM VENTA_DETALLE WHERE FOLIO = " + prmFolioVenta + "";
                drRead = cmdRead.ExecuteReader();

              

                while(drRead.Read()){
                    double ExistenciaDespues = 0;
                    string varID_PRODUCTO = drRead["ID_PRODUCTO"].ToString();
                    double varCANTIDAD = Convert.ToDouble(drRead["CANTIDAD"]);
                    //obtener la existencia antes
                    myCommand.CommandText = "SELECT EXISTENCIA FROM CAT_PRODUCTO WHERE ID_PRODUCTO ='"+ varID_PRODUCTO +"'";                    
                    double varEXISTENCIA_ANTES =Convert.ToDouble(myCommand.ExecuteScalar());
                    myCommand.CommandText = "UPDATE CAT_PRODUCTO SET "+
                        " EXISTENCIA = EXISTENCIA + "+ varCANTIDAD +" "+
                        " WHERE ID_PRODUCTO ='"+ varID_PRODUCTO +"'";
                   ExistenciaDespues=varEXISTENCIA_ANTES + varCANTIDAD ;
                    myCommand.ExecuteNonQuery();
                    
                    myCommand.CommandText = "INSERT INTO AJUSTES_INVENTARIO(FECHA_AJUSTE,ID_PRODUCTO,CANTIDAD_AJUSTE,CANTIDAD_ANTES,CANTIDAD_DESPUES,OBSERVACIONES,USER_LOGIN,ID_TIPO_AJUSTE)" +
                        "VALUES(now(),'" + varID_PRODUCTO + "'," + varCANTIDAD + ","+ varEXISTENCIA_ANTES +","+ ExistenciaDespues+",'CANCELACION DEL TICKET: "+ prmFolioVenta.ToString() +"','" + frmLogin._USER_LOGIN + "',0 )";
                    myCommand.ExecuteNonQuery();
                    
                }
                drRead.Close();
                cmdRead.Dispose();
                cnnRead.Dispose();
                myCommand.CommandText = varSQL2;
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = varSQL3;
                myCommand.ExecuteNonQuery();

                //ABONOS
                myCommand.CommandText = varSQL4;
                myCommand.ExecuteNonQuery();
                //CREDITOS
                myCommand.CommandText = varSQL5;
                myCommand.ExecuteNonQuery();

                if (contar > 0) {
                    myCommand.CommandText = "UPDATE VENTA SET STATUS='FC' WHERE FOLIO=" + prmFolioVenta + "";
                    myCommand.ExecuteNonQuery();
                }
                myTrans.Commit();
                return (true);
            }
            catch (Exception e)
            {
                try
                {
                    myTrans.Rollback();
                }
                catch (OleDbException ex)
                {
                    if (myTrans.Connection != null)
                    {
                        MessageBox.Show("Error type " + ex.GetType().ToString() +
                            " was found during undoing transaction");
                    }
                }
                MessageBox.Show(e.Message, "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false);
            }
            finally
            {
                myConnection.Close();
                myCommand.Dispose();
                myConnection.Dispose();
            }
        }

       

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}