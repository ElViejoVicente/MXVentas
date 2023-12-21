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
    public partial class frmEntrada : Telerik.WinControls.UI.RadForm
    {
        public frmEntrada() {
     
            //
            // Cuando se agregará una nueva factura
            InitializeComponent();
            varFOLIO = 0;
            this.Text = "Nueva entrada";
        }
        double varGranTotalGasto = 0;
        bool Importe = false;
        public frmEntrada(int prmFolio)
        {
            //
            // cuando se consulta el contenido de una factura			
            InitializeComponent();
            varFOLIO = prmFolio;
            this.Text = "Consultar entrada " + prmFolio.ToString();
            btnSave.Visible = false;
            btnAddProduct.Visible = false;
            btnCancel.Text = "Cerrar";
            txtFOLIO_FACTURA.ReadOnly = true;
            btnSearchProvider.Visible = false;
            dtpFECHA_FACTURA.Enabled = false;
            txtObservaciones.ReadOnly = true;
            mnuModificar.Enabled = false;
            mnuEliminar.Enabled = false;
            btnSearchProduct.Visible = false;
        }
       
        
        int varFOLIO = 0;
    
       
        private void frmEntrada_Load(object sender, EventArgs e)
        {
           
            txtIMPORTE.KeyPress += new KeyPressEventHandler(txtIMPORTE_KeyPress);
            txtIMPORTE.TextChanged += new EventHandler(txtIMPORTE_TextChanged);
            txtIMPORTE.GotFocus += new EventHandler(txtIMPORTE_GotFocus);
            txtPORC_AUMENTO.KeyPress += new KeyPressEventHandler(txtPORC_AUMENTO_KeyPress);
            txtPRECIO.KeyPress += new KeyPressEventHandler(txtPRECIO_KeyPress);
            txtPRECIO.TextChanged += new EventHandler(txtPRECIO_TextChanged);
            txtPRECIO.GotFocus += new EventHandler(txtPRECIO_GotFocus);
            txtCANTIDAD.KeyPress += new KeyPressEventHandler(txtCANTIDAD_KeyPress);
            txtPRECIO_VENTA.KeyPress += new KeyPressEventHandler(txtPRECIO_VENTA_KeyPress);
            txtPRECIO_VENTA2.KeyPress += new KeyPressEventHandler(txtPRECIO_VENTA2_KeyPress);
            txtPRECIO_VENTA3.KeyPress += new KeyPressEventHandler(txtPRECIO_VENTA3_KeyPress);
            txtID_PRODUCTO.KeyPress += new KeyPressEventHandler(txtID_PRODUCTO_KeyPress);
            txtIMPUESTO.KeyPress += new KeyPressEventHandler(txtIMPUESTO_KeyPress);
            Encabezados();
            if (varFOLIO == 0)
            {
                ReadData(frmLogin._USER_LOGIN,  Strings.SafeSqlLikeClauseLiteral(txtFOLIO_FACTURA.Text));
            }
            else
            {
                ReadData(varFOLIO);
               
            }
        }

        void txtIMPUESTO_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13) {
                btnAddProduct.Focus();
            }
        }

        void txtID_PRODUCTO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {
                BuscarProducto();
            }
        }
        void BuscarProducto() { 
            try {
                Class.clsProducto producto = new Class.clsProducto();
                producto.Buscar(txtID_PRODUCTO.Text);
                //txtID_PRODUCTO.Text = producto.ID_PRODUCTO;
                txtPrecioVenta.Text = producto.PRECIO_VENTA.ToString();
                txtPRECIO_VENTA.Text = producto.PRECIO_VENTA.ToString();
                txtPrecioVenta2.Text = producto.PRECIO_VENTA2.ToString();
                txtPRECIO_VENTA2.Text = producto.PRECIO_VENTA2.ToString();
                txtPrecioVenta3.Text = producto.PRECIO_VENTA3.ToString();
                txtPRECIO_VENTA3.Text = producto.PRECIO_VENTA3.ToString();
                txtPrecioAnt.Text = producto.PRECIO_COMPRA.ToString();
                lblDescripcionProducto.Text = producto.DESC_PRODUCTO;
                txtCANTIDAD.Focus();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message,"Información del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error); }
        }
        void txtPRECIO_GotFocus(object sender, EventArgs e)
        {
            Importe = false;
        }

        void txtIMPORTE_GotFocus(object sender, EventArgs e)
        {
            Importe = true;
        }

        void txtPRECIO_TextChanged(object sender, EventArgs e)
        {
            if (!Importe)
            {
                try
                {
                    if (txtCANTIDAD.Text == "") { txtCANTIDAD.BackColor = Color.Yellow; return; }
                    else { txtCANTIDAD.BackColor = Color.White; }
                    if (txtPRECIO.Text != "")
                    {
                        txtIMPORTE.Text = String.Format("{0:N}",
                            Convert.ToDouble(txtPRECIO.Text) * Convert.ToDouble(txtCANTIDAD.Text));
                    }
                    else {
                        txtIMPORTE.Text = "";
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        void txtIMPORTE_TextChanged(object sender, EventArgs e)
        {
            if (Importe)
            {
                try
                {
                    if (txtCANTIDAD.Text == "") { txtCANTIDAD.BackColor = Color.Yellow; return; }
                    else { txtCANTIDAD.BackColor = Color.White; }
                    if (txtIMPORTE.Text != "")
                    {
                        txtPRECIO.Text = String.Format("{0:N}",
                            Convert.ToDouble(txtIMPORTE.Text) / Convert.ToDouble(txtCANTIDAD.Text));
                    }
                    else {
                        txtPRECIO.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        void txtIMPORTE_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (e.KeyChar == 13) {
                txtPRECIO.Focus();
            }
        }

        void txtPRECIO_VENTA3_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        void txtPRECIO_VENTA2_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        void txtPRECIO_VENTA_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        void txtCANTIDAD_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (e.KeyChar == 13) {
                txtIMPORTE.Focus();
            }
        }

        void txtPRECIO_KeyPress(object sender, KeyPressEventArgs e)
        {
          
            if (e.KeyChar == 13) {
                if (chkIVA.Checked) { txtIMPUESTO.Focus(); }
                else { btnAddProduct.Focus(); }
            }
        }

        void txtPORC_AUMENTO_KeyPress(object sender, KeyPressEventArgs e)
        {
         
        }
        void frmEntrada_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !RemoveTemp();
        }
        private void Encabezados()
        {
            lvDetalleEntrada.View = View.Details;
            lvDetalleEntrada.Columns.Add("Id", 0, HorizontalAlignment.Left);
            lvDetalleEntrada.Columns.Add("No", 45, HorizontalAlignment.Left);
            lvDetalleEntrada.Columns.Add("Artículo", 0, HorizontalAlignment.Left);
            lvDetalleEntrada.Columns.Add("Descripción", 200, HorizontalAlignment.Left);
            lvDetalleEntrada.Columns.Add("P.Compra", 100, HorizontalAlignment.Right);
            lvDetalleEntrada.Columns.Add("P.Venta", 100, HorizontalAlignment.Right);
            lvDetalleEntrada.Columns.Add("P.Trab", 100, HorizontalAlignment.Right);
            lvDetalleEntrada.Columns.Add("P.May", 100, HorizontalAlignment.Right);
            lvDetalleEntrada.Columns.Add("Cant", 75, HorizontalAlignment.Right);
            lvDetalleEntrada.Columns.Add("Prec", 75, HorizontalAlignment.Right);
            lvDetalleEntrada.Columns.Add("IVA", 75, HorizontalAlignment.Right);
            lvDetalleEntrada.Columns.Add("Total", 75, HorizontalAlignment.Right);

        }
      
        bool TransactionEntrada(string prmUSER_LOGIN, string prmFOLIO_FACTURA, 
            string prmID_PROVEEDOR, string prmOBSERVACIONES, string prmFECHA_FACTURA, double prmPORC_AUMENTO_PRECIOS)
        {
            //variables a utilizar en esta transaccion

            string varID_PRODUCTO = "";
            double varCANTIDAD = 0.0;
            double varPRECIO = 0.0;
            double varIMPUESTO = 0.0;
            string varMensajeFinal = "";
            double varPrecioVenta1 = 0;
            double varPrecioVenta2 = 0;
            double varPrecioVenta3 = 0;
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
            //obtenemos el folio
            int varFOLIO = 0;
            
            try
            {
                //poner aqui todo el código que deseemos que se ejecute el la transacción
                ////
                myCommand.CommandText = "INSERT INTO ENTRADA (FOLIO_FACTURA,ID_PROVEEDOR,USER_LOGIN) VALUES('" + prmFOLIO_FACTURA + "','" + prmID_PROVEEDOR + "','" + prmUSER_LOGIN + "')";
                myCommand.ExecuteNonQuery();
                //OPTENEMOS EL FOLIO
                myCommand.CommandText = "SELECT @@IDENTITY";
                varFOLIO = Convert.ToInt32(myCommand.ExecuteScalar());
                OleDbConnection cnnReadTemp = new OleDbConnection(Class.clsMain.CnnStr);
                cnnReadTemp.Open();
                int I = 0;

                OleDbCommand cmdReadTemp = new OleDbCommand();
                cmdReadTemp.CommandText = "SELECT ID_PRODUCTO,CANTIDAD,PRECIO,IMPUESTO,PRECIO_VENTA,PRECIO_VENTA2,PRECIO_VENTA3 " +
                    "FROM TEMP_ENTRADA WHERE USER_LOGIN = '" + prmUSER_LOGIN + "' " +
                    " AND FOLIO_FACTURA = '" + prmFOLIO_FACTURA + "'" +
                    " ORDER BY FECHAHORA";
                cmdReadTemp.Connection = cnnReadTemp;
                OleDbDataReader drReadTemp;
                drReadTemp = cmdReadTemp.ExecuteReader();
                while (drReadTemp.Read())
                {
                    varID_PRODUCTO = drReadTemp["ID_PRODUCTO"].ToString(); //ASIGNAMOS EL PRODUCTO
                    varCANTIDAD = Convert.ToDouble(drReadTemp["CANTIDAD"]); //ASIGNAMOS LA CANTIDAD
                    varPRECIO = Convert.ToDouble(drReadTemp["PRECIO"]);//ASIGNAMOS EL PRECIO
                    varIMPUESTO = Convert.ToDouble(drReadTemp["IMPUESTO"]); //ASIGNAMOS EL IMPUESTO
                    double varPRECIO_COMPRA_IVA = Convert.ToDouble(varPRECIO + (varPRECIO * varIMPUESTO));
                    varPrecioVenta1 = Convert.ToDouble(drReadTemp["PRECIO_VENTA"]);
                    varPrecioVenta2 = Convert.ToDouble(drReadTemp["PRECIO_VENTA2"]);
                    varPrecioVenta3 = Convert.ToDouble(drReadTemp["PRECIO_VENTA3"]); 
                    //double varPRECIO_COMPRA_IVA = varPRECIO;
                    myCommand.CommandText = "INSERT INTO ENTRADA_DETALLE (FOLIO_ENTRADA,ID_PRODUCTO,CANTIDAD,PRECIO_COMPRA,IMPUESTO,ORDEN) "+
                        " VALUES(" + varFOLIO + ",'" + varID_PRODUCTO + "'," + varCANTIDAD + "," + varPRECIO + "," + varIMPUESTO + "," + I + ")";
                    myCommand.ExecuteNonQuery();
                    //ACTUALIZAMOS EL PRODUCTO
                    myCommand.CommandText = "UPDATE CAT_PRODUCTO " +
                        " SET EXISTENCIA = EXISTENCIA + " + varCANTIDAD + ","+
                        " PRECIO_COMPRA=" + varPRECIO_COMPRA_IVA + ", " +
                        " PRECIO_VENTA=" + varPrecioVenta1 + "," +
                        " PRECIO_VENTA2=" + varPrecioVenta2 + "," +
                        " PRECIO_VENTA3=" + varPrecioVenta3 + "" +
                        " WHERE ID_PRODUCTO = '" + varID_PRODUCTO + "'";
                    myCommand.ExecuteNonQuery();
                    if (prmPORC_AUMENTO_PRECIOS != 0)
                    {
                        myCommand.CommandText = "UPDATE CAT_PRODUCTO " +
                            " SET PRECIO_VENTA = (" + varPRECIO + " * (1 + (" + prmPORC_AUMENTO_PRECIOS + "/100)) ) " +
                            " WHERE ID_PRODUCTO = '" + varID_PRODUCTO + "'";
                        myCommand.ExecuteNonQuery();
                    }
                    I += 1;
                    //MessageBox.Show(I.ToString());

                }
                drReadTemp.Close();
                cmdReadTemp.Dispose();
                cnnReadTemp.Close();
                cnnReadTemp.Dispose();
                ////
               
                myCommand.CommandText = "UPDATE ENTRADA SET FECHA_REGISTRO = now(),"+
                    " FECHA_FACTURA=#" + prmFECHA_FACTURA + "#,"+
                    "OBSERVACIONES ='" + prmOBSERVACIONES + "' WHERE FOLIO_ENTRADA =" + varFOLIO + "";
                myCommand.ExecuteNonQuery();
                //VACIAMOS LA TABLA TEMPORAL
                myCommand.CommandText = "DELETE FROM TEMP_ENTRADA WHERE USER_LOGIN = '" + prmUSER_LOGIN + "' " +
                    " AND FOLIO_FACTURA = '" + prmFOLIO_FACTURA + "'";
                myCommand.ExecuteNonQuery();
                myTrans.Commit();
                varMensajeFinal = "Entrada Registrada correctamente.\nSe agregaron " + Convert.ToString(I) + " registro(s).\n\nFolio asignado por el sistema: " + varFOLIO.ToString();
                MessageBox.Show(varMensajeFinal, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lvDetalleEntrada.Items.Clear();
                //ReadData(frmLogin._USER_LOGIN, txtFOLIO_FACTURA.Text);
                
                myConnection.Close();
                return (true);
            }
            catch (Exception e)
            {
                
                    myTrans.Rollback();

                    throw e;
            }
           
        }
        public void ImprimeFacturaEntrada(int prmFOLIO_FACTURA)
        {
            try
            {
                DataSet dsReporte = new DataSet(); //Datset para el reporte
                OleDbConnection cnnReporte = new OleDbConnection(Class.clsMain.CnnStr);
                if (cnnReporte.State == ConnectionState.Open)
                    cnnReporte.Close();
                cnnReporte.Open();
                dsReporte.Clear();//limpiamos el dataset
                OleDbDataAdapter daReporte = new OleDbDataAdapter("SELECT * FROM [v_FACTURA_ENTRADA] WHERE FOLIO_ENTRADA =" + prmFOLIO_FACTURA + "", cnnReporte);
                daReporte.Fill(dsReporte, "sp_FACTURA");//llenamos el DataSet con la info de la FACTURA
                OleDbDataAdapter daSubReporte = new OleDbDataAdapter("SELECT * FROM [v_FACTURA_ENTRADA_DETALLE] WHERE FOLIO_ENTRADA= " + prmFOLIO_FACTURA + "", cnnReporte);
                daSubReporte.Fill(dsReporte, "sp_DETALLE_FACTURA]");//llenamos el DataSet con la info del DETALLE_FACTURA
                //destruimos los objetos utilizados
                if (cnnReporte.State == ConnectionState.Open)
                    cnnReporte.Close();
                daReporte.Dispose();
                daSubReporte.Dispose();
                cnnReporte.Dispose();
                //ya tenoemos la info en el DataSet, ahora cargamos el reporte

                //Reports.rptFactura mi_rptFactura = new Reports.rptFactura();
                //mi_rptFactura.SummaryInfo.ReportTitle = "Entrada";
                //mi_rptFactura.SetDataSource(dsReporte);
                //mi_rptFactura.OpenSubreport("rptDetalleFactura").SetDataSource(dsReporte.Tables["sp_DETALLE_FACTURA]"]);
                //Forms.frmReports mi_frmReportes = new frmReports();
                //mi_frmReportes.crvReportes.DisplayGroupTree = false;
                //mi_frmReportes.crvReportes.ReportSource = mi_rptFactura;
                //mi_frmReportes.StartPosition = FormStartPosition.CenterScreen;
                //mi_frmReportes.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Delete(string prmUSER_LOGIN, string prmFOLIO_FACTURA)
        {
            //Para modificar el registro
            string varSQL = "DELETE FROM TEMP_ENTRADA  WHERE USER_LOGIN='" + prmUSER_LOGIN + "' AND FOLIO_FACTURA='" + prmFOLIO_FACTURA + "'";
            OleDbConnection cnnDelete = new OleDbConnection(Class.clsMain.CnnStr);
            try
            {
                cnnDelete.Open();
                OleDbCommand cmdDelete = new OleDbCommand(varSQL, cnnDelete);
                cmdDelete.ExecuteNonQuery();
                cmdDelete.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { cnnDelete.Close(); }
        }
        private void ReadData(string prmUSER_LOGIN, string prmFOLIO_FACTURA)
        {
            //Este procedimiento lee los datos que se tranferirán y los mostrará en forma de
            //lista en el ListView
            double varTotal = 0;
            double varGranTotal = 0;
            double varIVA = 0;
            try
            {
                //Si la conexion esta abierta la cerramos; en caso contrario, la abrimos
                OleDbConnection cnnReadData = new OleDbConnection(Class.clsMain.CnnStr);
                if (cnnReadData.State == ConnectionState.Open) cnnReadData.Close(); else cnnReadData.Open();
                int I = 0;
                OleDbCommand cmdReadData = new OleDbCommand();
                cmdReadData.Connection = cnnReadData;
                cmdReadData.CommandText = "SELECT TEMP_ENTRADA.ID_TEMP_ENTRADA, TEMP_ENTRADA.ID_PRODUCTO, "+
                    " CAT_PRODUCTO.DESC_PRODUCTO, TEMP_ENTRADA.CANTIDAD, TEMP_ENTRADA.PRECIO, TEMP_ENTRADA.IMPUESTO,"+
                    " TEMP_ENTRADA.FOLIO_FACTURA, TEMP_ENTRADA.USER_LOGIN, CAT_PRODUCTO.PRECIO_COMPRA,"+
                    " TEMP_ENTRADA.PRECIO_VENTA,TEMP_ENTRADA.PRECIO_VENTA2,TEMP_ENTRADA.PRECIO_VENTA3 " +
                        " FROM CAT_PRODUCTO INNER JOIN TEMP_ENTRADA ON CAT_PRODUCTO.ID_PRODUCTO = TEMP_ENTRADA.ID_PRODUCTO"+
                         " WHERE TEMP_ENTRADA.USER_LOGIN = '" + prmUSER_LOGIN + "' AND TEMP_ENTRADA.FOLIO_FACTURA ='" + prmFOLIO_FACTURA + "'";
                OleDbDataReader drReadData;
                drReadData = cmdReadData.ExecuteReader();
                lvDetalleEntrada.Items.Clear();
                while (drReadData.Read())
                {
                    lvDetalleEntrada.Items.Add(drReadData["ID_TEMP_ENTRADA"].ToString());
                    lvDetalleEntrada.Items[I].SubItems.Add(String.Format("{0}", I + 1));
                    lvDetalleEntrada.Items[I].SubItems.Add(drReadData["ID_PRODUCTO"].ToString());
                    lvDetalleEntrada.Items[I].SubItems.Add(drReadData["DESC_PRODUCTO"].ToString());
                    lvDetalleEntrada.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["PRECIO_COMPRA"]));
                    lvDetalleEntrada.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["PRECIO_VENTA"]));
                    lvDetalleEntrada.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["PRECIO_VENTA2"]));
                    lvDetalleEntrada.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["PRECIO_VENTA3"]));
                    lvDetalleEntrada.Items[I].SubItems.Add(drReadData["CANTIDAD"].ToString());
                    lvDetalleEntrada.Items[I].SubItems.Add(String.Format("{0:C}",drReadData["PRECIO"]));
                    lvDetalleEntrada.Items[I].SubItems.Add(String.Format("{0:P}", drReadData["IMPUESTO"]));
                    varTotal = Convert.ToDouble(drReadData["CANTIDAD"]) * 
                        (Convert.ToDouble(drReadData["PRECIO"]));
                    varIVA += varTotal * Convert.ToDouble(drReadData["IMPUESTO"]);
                    varGranTotal += varTotal;
                    lvDetalleEntrada.Items[I].SubItems.Add(String.Format("{0:C}", varTotal));
                    I += 1;

                }
                //Agregamos un registro más
                if (I != 0)
                {
                    lvDetalleEntrada.Items.Add("");
                    lvDetalleEntrada.Items[I].SubItems.Add("");
                    lvDetalleEntrada.Items[I].SubItems.Add("");
                    lvDetalleEntrada.Items[I].SubItems.Add("");
                    lvDetalleEntrada.Items[I].SubItems.Add("");
                    lvDetalleEntrada.Items[I].SubItems.Add("");
                    lvDetalleEntrada.Items[I].SubItems.Add("");
                    lvDetalleEntrada.Items[I].SubItems.Add("");
                    lvDetalleEntrada.Items[I].SubItems.Add("");
                    lvDetalleEntrada.Items[I].SubItems.Add("IVA:");
                    lvDetalleEntrada.Items[I].SubItems.Add(String.Format("{0:C}",varIVA));
                    ///
                    lvDetalleEntrada.Items.Add("");
                    lvDetalleEntrada.Items[I + 1].SubItems.Add("");
                    lvDetalleEntrada.Items[I + 1].SubItems.Add("");
                    lvDetalleEntrada.Items[I + 1].SubItems.Add("");
                    lvDetalleEntrada.Items[I + 1].SubItems.Add("");
                    lvDetalleEntrada.Items[I + 1].SubItems.Add("");
                    lvDetalleEntrada.Items[I + 1].SubItems.Add("");
                    lvDetalleEntrada.Items[I + 1].SubItems.Add("");
                    lvDetalleEntrada.Items[I + 1].SubItems.Add("");
                    lvDetalleEntrada.Items[I + 1].SubItems.Add("Grand Total:");
                    lvDetalleEntrada.Items[I + 1].SubItems.Add(String.Format("{0:C}", varGranTotal + varIVA));
                    btnSave.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                }
                varGranTotalGasto = varGranTotal + varIVA;
                drReadData.Close();
                cmdReadData.Dispose();
                cnnReadData.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ReadData(int prmFOLIO_ENTRADA)
        {
            //Este procedimiento lee los datos que se tranferirán y los mostrará en forma de
            //lista en el ListView
            double varTotal = 0;
            double varGranTotal = 0;
            double varIVA = 0;
            try
            {
                //Si la conexion esta abierta la cerramos; en caso contrario, la abrimos
                OleDbConnection cnnReadData = new OleDbConnection(Class.clsMain.CnnStr);
                if (cnnReadData.State == ConnectionState.Open) cnnReadData.Close(); else cnnReadData.Open();
                OleDbCommand cmdReadData = new OleDbCommand();
                cmdReadData.Connection = cnnReadData;
                OleDbDataReader drReadData;

                // Recuperamos la info de la factura
                cmdReadData.CommandText = "SELECT FOLIO_FACTURA,ID_PROVEEDOR,FECHA_FACTURA, OBSERVACIONES FROM ENTRADA WHERE FOLIO_ENTRADA = " + prmFOLIO_ENTRADA + "";
                drReadData = cmdReadData.ExecuteReader();
                drReadData.Read();
                txtFOLIO_FACTURA.Text = drReadData["FOLIO_FACTURA"].ToString();
                txtID_PROVEEDOR.Text=  drReadData["ID_PROVEEDOR"].ToString();
                dtpFECHA_FACTURA.Value = Convert.ToDateTime(drReadData["FECHA_FACTURA"]);
                txtObservaciones.Text = drReadData["OBSERVACIONES"].ToString();
                drReadData.Close();
                string varSQL_DETALLE = "SELECT ID_ENTRADA_DETALLE,ENTRADA_DETALLE.ID_PRODUCTO, CAT_PRODUCTO.DESC_PRODUCTO,CAT_PRODUCTO.PRECIO_VENTA,ENTRADA_DETALLE.PRECIO_COMPRA, " +
                    " ENTRADA_DETALLE.CANTIDAD, ENTRADA_DETALLE.PRECIO_COMPRA, ENTRADA_DETALLE.IMPUESTO, "+
                    " ENTRADA_DETALLE.FOLIO_ENTRADA, CAT_PRODUCTO.SUST_ACTIVA, CAT_PRODUCTO.INDICACION, "+
                    " CAT_PRODUCTO.NOMBRES_CO, CAT_PRODUCTO.FORMULACION" +
                    " FROM CAT_PRODUCTO INNER JOIN ENTRADA_DETALLE ON CAT_PRODUCTO.ID_PRODUCTO = ENTRADA_DETALLE.ID_PRODUCTO " +
                    " WHERE ENTRADA_DETALLE.FOLIO_ENTRADA = " + prmFOLIO_ENTRADA + "";
                cmdReadData.CommandText = varSQL_DETALLE;
                int I = 0;
                drReadData = cmdReadData.ExecuteReader();
                lvDetalleEntrada.Items.Clear();
                /*
                 lvDetalleEntrada.View = View.Details;
            lvDetalleEntrada.Columns.Add("Id", 0, HorizontalAlignment.Left);
            lvDetalleEntrada.Columns.Add("No", 45, HorizontalAlignment.Left);
            lvDetalleEntrada.Columns.Add("Artículo", 0, HorizontalAlignment.Left);
            lvDetalleEntrada.Columns.Add("Descripción", 200, HorizontalAlignment.Left);
            lvDetalleEntrada.Columns.Add("P.Compra", 100, HorizontalAlignment.Right);
            lvDetalleEntrada.Columns.Add("P.Venta", 100, HorizontalAlignment.Right);
            lvDetalleEntrada.Columns.Add("P.Trab", 100, HorizontalAlignment.Right);
            lvDetalleEntrada.Columns.Add("P.May", 100, HorizontalAlignment.Right);
            lvDetalleEntrada.Columns.Add("Cant", 75, HorizontalAlignment.Right);
            lvDetalleEntrada.Columns.Add("Prec", 75, HorizontalAlignment.Right);
            lvDetalleEntrada.Columns.Add("IVA", 75, HorizontalAlignment.Right);
            lvDetalleEntrada.Columns.Add("Total", 75, HorizontalAlignment.Right);
                 */
                while (drReadData.Read())
                {
                    lvDetalleEntrada.Items.Add(drReadData["ID_ENTRADA_DETALLE"].ToString());
                    lvDetalleEntrada.Items[I].SubItems.Add(String.Format("{0}", I + 1));
                    lvDetalleEntrada.Items[I].SubItems.Add(drReadData["ID_PRODUCTO"].ToString());
                    lvDetalleEntrada.Items[I].SubItems.Add(drReadData["DESC_PRODUCTO"].ToString());
                    lvDetalleEntrada.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["PRECIO_COMPRA"]));
                    lvDetalleEntrada.Items[I].SubItems.Add(String.Format("{0:C}",drReadData["PRECIO_VENTA"]));
                    lvDetalleEntrada.Items[I].SubItems.Add(String.Format("{0:C}", ""));
                    lvDetalleEntrada.Items[I].SubItems.Add(String.Format("{0:C}", ""));

                    lvDetalleEntrada.Items[I].SubItems.Add(drReadData["CANTIDAD"].ToString());
                    lvDetalleEntrada.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["PRECIO_COMPRA"]));
                    lvDetalleEntrada.Items[I].SubItems.Add(String.Format("{0:P}",drReadData["IMPUESTO"]));
                    varTotal = Convert.ToDouble(drReadData["CANTIDAD"]) * 
                        (Convert.ToDouble(drReadData["PRECIO_COMPRA"]));
                    varGranTotal += varTotal;
                    varIVA += varTotal * Convert.ToDouble(drReadData["IMPUESTO"]);
                    lvDetalleEntrada.Items[I].SubItems.Add(String.Format("{0:C}", varTotal));
                    I += 1;

                }
                //Agregamos un registro más
                if (I != 0)
                {
                    lvDetalleEntrada.Items.Add("");
                    lvDetalleEntrada.Items[I].SubItems.Add("");
                    lvDetalleEntrada.Items[I].SubItems.Add("");
                    lvDetalleEntrada.Items[I].SubItems.Add("");
                    lvDetalleEntrada.Items[I].SubItems.Add("");
                    lvDetalleEntrada.Items[I].SubItems.Add("");
                    lvDetalleEntrada.Items[I].SubItems.Add("");
                    lvDetalleEntrada.Items[I].SubItems.Add("");
                    lvDetalleEntrada.Items[I].SubItems.Add("");
                    lvDetalleEntrada.Items[I].SubItems.Add("");
                    lvDetalleEntrada.Items[I].SubItems.Add("IVA:");
                    lvDetalleEntrada.Items[I].SubItems.Add(String.Format("{0:C}", varIVA));

                    //
                    lvDetalleEntrada.Items.Add("");
                    lvDetalleEntrada.Items[I+1].SubItems.Add("");
                    lvDetalleEntrada.Items[I + 1].SubItems.Add("");
                    lvDetalleEntrada.Items[I + 1].SubItems.Add("");
                    lvDetalleEntrada.Items[I + 1].SubItems.Add("");
                    lvDetalleEntrada.Items[I + 1].SubItems.Add("");
                    lvDetalleEntrada.Items[I + 1].SubItems.Add("");
                    lvDetalleEntrada.Items[I + 1].SubItems.Add("");
                    lvDetalleEntrada.Items[I+1].SubItems.Add("");
                    lvDetalleEntrada.Items[I+1].SubItems.Add("");
                    lvDetalleEntrada.Items[I+1].SubItems.Add("Gran Total:");
                    lvDetalleEntrada.Items[I+1].SubItems.Add(String.Format("{0:C}",varGranTotal + varIVA));

                }

                drReadData.Close();
                cmdReadData.Dispose();
                cnnReadData.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool RemoveTemp()
        {
            try
            {
                if (lvDetalleEntrada.Items.Count != 0)
                {
                    if (varFOLIO == 0)
                    {
                        DialogResult resp = new DialogResult();
                        resp = MessageBox.Show("Esta operación eliminará todos los registros que ya ha agregado.\n¿Desea Continuar?", "Información del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resp == DialogResult.Yes)
                        {
                            //eliminar todo lo temporal
                            Delete(frmLogin._USER_LOGIN,   Strings.SafeSqlLikeClauseLiteral(txtFOLIO_FACTURA.Text));
                            //para cerrar después de eliminar los registros
                            return (true);
                        }
                        else
                        {
                            //Para no eliminar los registros y no cerrar
                            return (false);
                        }
                    }
                    else
                    {
                        return (true);
                    }
                }
                else
                {
                    //Para cerrar la pantalla (no hay registros)
                    return (true);
                }
            }
            catch (Exception ex)
            {
                //Ocurrió un error,no cerramos la pantalla
                MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false);
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (txtID_PRODUCTO.Text == "") { return; }
            if (txtCANTIDAD.Text == "") { return; }
            if (txtPRECIO.Text == "") { return; }
            if (txtIMPUESTO.Text == "") { return; }
            if (txtPRECIO_VENTA.Text == "") { return; }
            if (txtPRECIO_VENTA2.Text == "") { return; }
            if (txtPRECIO_VENTA3.Text == "") { return; }
            
            try
            {
                if ((txtFOLIO_FACTURA.Text != "") && (txtID_PROVEEDOR.Text != ""))
                {


                    if (Validaciones())
                    {
                        if (AddNew(frmLogin._USER_LOGIN, txtFOLIO_FACTURA.Text,
                            Strings.SafeSqlLikeClauseLiteral(txtID_PRODUCTO.Text).ToString(),
                            Convert.ToDouble(txtCANTIDAD.Text), Convert.ToDouble(txtPRECIO.Text), 
                            Convert.ToDouble(txtIMPUESTO.Text),
                            Convert.ToDouble(txtPRECIO_VENTA.Text),
                            Convert.ToDouble(txtPRECIO_VENTA2.Text),
                            Convert.ToDouble(txtPRECIO_VENTA3.Text)))
                        {
                            lblDescripcionProducto.Text = "";
                            txtID_PRODUCTO.Text = "";
                            txtPrecioVenta.Text = "";
                            txtPRECIO_VENTA.Text = "";
                            txtPrecioVenta2.Text = "";
                            txtPRECIO_VENTA2.Text = "";
                            txtPrecioVenta3.Text = "";
                            txtPRECIO_VENTA3.Text = "";
                            txtIMPORTE.Text = "";
                            ReadData(frmLogin._USER_LOGIN, txtFOLIO_FACTURA.Text);
                            txtID_PRODUCTO.Text = "";
                            txtCANTIDAD.Text = "";
                            txtPRECIO.Text = "";
                            txtPrecioAnt.Text = "";
                            txtID_PRODUCTO.Focus();
                        }

                    }


                }
                else
                {
                    MessageBox.Show("Se requiere el folio de la factura y el proveedor.\nPor favor capture ambos datos.", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchProvider_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaProveedor myForm = new frmBuscaProveedor();
                myForm.StartPosition = FormStartPosition.CenterScreen;
                myForm.ShowDialog();
                if (myForm.varID_PROVEEDOR != "")
                {
                    txtID_PROVEEDOR.Text = myForm.varID_PROVEEDOR;
                    if (txtFOLIO_FACTURA.Text == "") { txtFOLIO_FACTURA.Focus(); }
                    else { txtID_PRODUCTO.Focus(); }
                   
                }
                myForm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtPORC_AUMENTO.Text == "") {
                    MessageBox.Show("Falta el porcentaje de aumento de los precios","Información del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return;
                }
                if (varFOLIO == 0)
                {
                    if (lvDetalleEntrada.Items.Count != 0)
                    {

                        if (TransactionEntrada(frmLogin._USER_LOGIN,
                            Strings.SafeSqlLikeClauseLiteral(txtFOLIO_FACTURA.Text),
                            txtID_PROVEEDOR.Text,
                            Strings.SafeSqlLikeClauseLiteral(txtObservaciones.Text),
                            ISODates.MSAccessDateINI(dtpFECHA_FACTURA.Value), Convert.ToDouble(txtPORC_AUMENTO.Text)))
                        {
                            if (chkGASTO.Checked)
                            {
                                frmGasto frm = new frmGasto(varGranTotalGasto);
                                frm.StartPosition = FormStartPosition.CenterScreen;
                                frm.ShowDialog();
                            }
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

   
        private void mnuModificar_Click(object sender, EventArgs e)
        {
            //modificar el regitro
            try
            {
                if ((txtFOLIO_FACTURA.Text.ToString() != "") && (txtID_PROVEEDOR.Text != ""))
                {
                    int varID = 0;
                    if (lvDetalleEntrada.SelectedItems.Count != 0)
                    {
                        varID =Convert.ToInt32(lvDetalleEntrada.SelectedItems[0].Text);
                        
                        frmEntradaTemp myForm = new frmEntradaTemp(varID);
                        myForm.StartPosition = FormStartPosition.CenterScreen;
                        myForm.ShowDialog();
                        ReadData(frmLogin._USER_LOGIN, 
                            Strings.SafeSqlLikeClauseLiteral(txtFOLIO_FACTURA.Text));
                        myForm.Dispose();
                        
                    }
                }
                else
                {
                    MessageBox.Show("Falta el folio de factura y/o el id de proveedor", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuEliminar_Click(object sender, EventArgs e)
        {
            //eliminar el registro
            try
            {
                if ((txtFOLIO_FACTURA.Text.ToString() != "") && (txtID_PROVEEDOR.Text != ""))
                {
                    int varID = 0;
                    if (lvDetalleEntrada.SelectedItems.Count != 0)
                    {
                        //preguntar si desea eliminar
                        varID =Convert.ToInt32(lvDetalleEntrada.SelectedItems[0].Text);
                       
                        DialogResult res = new DialogResult();
                        res = MessageBox.Show("Desea eliminar el registro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            DeleteTemp(varID);
                            ReadData(frmLogin._USER_LOGIN, Strings.SafeSqlLikeClauseLiteral(txtFOLIO_FACTURA.Text));
                        }
                        

                    }
                }
                else
                {
                    MessageBox.Show("Falta el folio de factura y/o el id de proveedor", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteTemp(int prmID_TEMP_ENTRADA)
        {
            //Para Eliminar
            string varSQL = "DELETE FROM TEMP_ENTRADA WHERE ID_TEMP_ENTRADA ="+ prmID_TEMP_ENTRADA +"";
            try
            {
                OleDbConnection cnnDeleteTemp = new OleDbConnection(Class.clsMain.CnnStr);
                if (cnnDeleteTemp.State == ConnectionState.Open)
                    cnnDeleteTemp.Close();
                cnnDeleteTemp.Open();
                OleDbCommand cmdDeleteTemp = new OleDbCommand(varSQL, cnnDeleteTemp);
                cmdDeleteTemp.ExecuteNonQuery();
                cmdDeleteTemp.Dispose();
                cnnDeleteTemp.Close();
                cnnDeleteTemp.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaProducto myForm = new frmBuscaProducto();
                myForm.StartPosition = FormStartPosition.CenterScreen;
                myForm.ShowDialog();
                if (myForm.producto.ID_PRODUCTO != "")
                {
                    txtID_PRODUCTO.Text = myForm.producto.ID_PRODUCTO;
                    txtPrecioVenta.Text = myForm.producto.PRECIO_VENTA.ToString();
                    txtPRECIO_VENTA.Text = myForm.producto.PRECIO_VENTA.ToString();
                    txtPrecioVenta2.Text = myForm.producto.PRECIO_VENTA2.ToString();
                    txtPRECIO_VENTA2.Text = myForm.producto.PRECIO_VENTA2.ToString();
                    txtPrecioVenta3.Text = myForm.producto.PRECIO_VENTA3.ToString();
                    txtPRECIO_VENTA3.Text = myForm.producto.PRECIO_VENTA3.ToString();
                    txtPrecioAnt.Text = myForm.producto.PRECIO_COMPRA.ToString();
                    lblDescripcionProducto.Text = myForm.producto.DESC_PRODUCTO;
                    txtCANTIDAD.Focus();
                }
                else {
                    txtID_PRODUCTO.Text = "";
                    txtPrecioVenta.Text = "";
                    txtPRECIO_VENTA.Text = "";
                    txtPrecioVenta2.Text = "";
                    txtPRECIO_VENTA2.Text = "";
                    txtPrecioVenta3.Text = "";
                    txtPRECIO_VENTA3.Text = "";
                    txtPrecioAnt.Text = "";
                    lblDescripcionProducto.Text = "";
                }
                myForm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtID_PRODUCTO.Text = "";
            }
        }

       //AGREGAR
        private bool Validaciones()
        {
            try
            {
                if (Convert.ToString(Strings.SafeSqlLikeClauseLiteral(txtID_PRODUCTO.Text)) == "" || Convert.ToString(txtCANTIDAD.Text) == "" | Convert.ToString(txtPRECIO.Text) == "" | Convert.ToString(txtIMPUESTO.Text) == "")
                {
                    //verificar que los campos no estén vacios
                    MessageBox.Show("Faltan datos", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return (false);
                }
                else
                {
                    if (fnBuscaProducto(Strings.SafeSqlLikeClauseLiteral(txtID_PRODUCTO.Text)))
                    {
                        if ((Convert.ToDouble(txtCANTIDAD.Text) == 0) || (Convert.ToDouble(txtPRECIO.Text) == 0))
                        {
                            MessageBox.Show("La cantidad y el precio no pueden ser cero (0)", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return (false);
                        }
                        else
                        {
                            return (true);
                        }
                    }
                    else
                    {
                        return (false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false);
            }
        }
        private bool fnBuscaProducto(string prmID_PRODUCTO)
        {

            try
            {
                if (prmID_PRODUCTO == "")
                {
                    MessageBox.Show("Falta el id de producto", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return (false);
                }
                else
                {
                    OleDbConnection cnnBuscaProducto = new OleDbConnection(Class.clsMain.CnnStr);
                    cnnBuscaProducto.Open();
                    string varSQL = "SELECT ID_PRODUCTO FROM CAT_PRODUCTO WHERE ID_PRODUCTO = '" + prmID_PRODUCTO + "'";
                    DataSet dsBuscaProducto = new DataSet("dsBuscaProducto");
                    dsBuscaProducto.Clear();
                    OleDbDataAdapter daBuscaProducto = new OleDbDataAdapter(varSQL, cnnBuscaProducto);
                    daBuscaProducto.Fill(dsBuscaProducto, "CAT_PRODUCTO");
                    if (dsBuscaProducto.Tables["CAT_PRODUCTO"].Rows.Count == 0)
                    {
                        //No existe
                        MessageBox.Show("Producto no encontrado", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        dsBuscaProducto.Clear();
                        dsBuscaProducto.Dispose();
                        daBuscaProducto.Dispose();
                        cnnBuscaProducto.Close();
                        cnnBuscaProducto.Dispose();
                        return (false);
                    }
                    else
                    {
                        //Si existe						
                        dsBuscaProducto.Clear();
                        dsBuscaProducto.Dispose();
                        daBuscaProducto.Dispose();
                        cnnBuscaProducto.Close();
                        cnnBuscaProducto.Dispose();
                        return (true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false);
            }
        }
        bool AddNew(string prmUSER_LOGIN, string prmFOLIO_FACTURA, string prmID_PRODUCTO, double prmCANTIDAD, double prmPRECIO, double prmIMPUESTO,
            double PrecioVenta1, double PrecioVenta2, double PrecioVenta3)
        {
            //Para agregar Nuevo
            try
            {
                OleDbConnection cnnAddNew = new OleDbConnection(Class.clsMain.CnnStr);
                cnnAddNew.Open();
                OleDbCommand cmdAddNew = new OleDbCommand();
                cmdAddNew.Connection = cnnAddNew;
                //VERIFICAMOS SI HAY DIPLICIDAD
                cmdAddNew.CommandText = "SELECT COUNT (ID_PRODUCTO) FROM TEMP_ENTRADA WHERE FOLIO_FACTURA='"+ prmFOLIO_FACTURA +"' AND USER_LOGIN='"+ prmUSER_LOGIN +"' AND ID_PRODUCTO='"+ prmID_PRODUCTO +"' " ;
                int cont = Convert.ToInt32(cmdAddNew.ExecuteScalar());
                if (cont == 0)
                {
                    //nuevo
                    cmdAddNew.CommandText = "INSERT INTO TEMP_ENTRADA (FOLIO_FACTURA,USER_LOGIN,ID_PRODUCTO,CANTIDAD,PRECIO,IMPUESTO, PRECIO_VENTA,PRECIO_VENTA2,PRECIO_VENTA3) " +
                "VALUES('" + prmFOLIO_FACTURA + "','" + prmUSER_LOGIN + "','" + prmID_PRODUCTO + "'," + prmCANTIDAD + "," + prmPRECIO + "," + prmIMPUESTO + "," + PrecioVenta1 + "," + PrecioVenta2 + "," + PrecioVenta3 + ")";
                }
                else { 
                    //editar
                    cmdAddNew.CommandText = "UPDATE TEMP_ENTRADA SET " +
                        " CANTIDAD = CANTIDAD + " + prmCANTIDAD + "," +
                        " PRECIO=" + prmPRECIO + "," +
                        " IMPUESTO=" + prmIMPUESTO + "," +
                        " PRECIO_VENTA=" + PrecioVenta1 + "," +
                        " PRECIO_VENTA2=" + PrecioVenta2 + "," +
                        " PRECIO_VENTA3=" + PrecioVenta3 + "" +
                        " WHERE FOLIO_FACTURA='" + prmFOLIO_FACTURA + "' AND USER_LOGIN='" + prmUSER_LOGIN + "' AND ID_PRODUCTO='" + prmID_PRODUCTO + "' ";

                }
                cmdAddNew.ExecuteNonQuery();
                cmdAddNew.Dispose();
                cnnAddNew.Close();
                cnnAddNew.Dispose();
                return (true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return (false);
            }
        }
        private void Update(string prmUSER_LOGIN, string prmFOLIO_FACTURA, string prmID_PRODUCTO, double prmCANTIDAD, double prmPRECIO, double prmIMPUESTO)
        {
            //Para agregar Nuevo
            string varSQL = "UPDATE TEMP_ENTRADA SET " +
                " FOLIO_FACTURA='" + prmFOLIO_FACTURA + "',USER_LOGIN='" + prmUSER_LOGIN + "',ID_PRODUCTO='" + prmID_PRODUCTO + "',CANTIDAD=" + prmCANTIDAD + ",PRECIO=" + prmPRECIO + ",IMPUESTO=" + prmIMPUESTO + " " +
                " WHERE USER_LOGIN='" + prmUSER_LOGIN + "' AND FOLIO_FACTURA='" + prmFOLIO_FACTURA + "' AND ID_PRODUCTO='" + prmID_PRODUCTO + "'";
            try
            {
                OleDbConnection cnnUpdate = new OleDbConnection(Class.clsMain.CnnStr);
                if (cnnUpdate.State == ConnectionState.Open)
                    cnnUpdate.Close();
                cnnUpdate.Open();
                OleDbCommand cmdUpdate = new OleDbCommand(varSQL, cnnUpdate);
                cmdUpdate.ExecuteNonQuery();
                cmdUpdate.Dispose();
                cnnUpdate.Close();
                cnnUpdate.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkIVA_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIVA.Checked)
            {
                txtIMPUESTO.Enabled = true;
                txtIMPUESTO.Text = "0.16";
            }
            else {
                txtIMPUESTO.Enabled = false;
                txtIMPUESTO.Text = "0";
            }
        }

        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            NewProduct();
        }
        protected void NewProduct() {
            try {
                frmProducto frm = new frmProducto("");
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
                if (frm.producto.Success) {
                    txtID_PRODUCTO.Text = frm.producto.ID_PRODUCTO;
                    txtPrecioVenta.Text = frm.producto.PRECIO_VENTA.ToString();
                    txtPRECIO_VENTA.Text = frm.producto.PRECIO_VENTA.ToString();
                    txtPrecioVenta2.Text = frm.producto.PRECIO_VENTA2.ToString();
                    txtPRECIO_VENTA2.Text = frm.producto.PRECIO_VENTA2.ToString();
                    txtPrecioVenta3.Text = frm.producto.PRECIO_VENTA3.ToString();
                    txtPRECIO_VENTA3.Text = frm.producto.PRECIO_VENTA3.ToString();
                    lblDescripcionProducto.Text = frm.producto.DESC_PRODUCTO;
                    txtCANTIDAD.Focus();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}