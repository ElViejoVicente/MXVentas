using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using POSDLL;
using POSDLL.Windows.Forms;
using POSDLL.Security;
using POSDLL.Reporting;
using POSDLL.Ticket;
using Microsoft.Reporting.WinForms;
namespace POSApp.Class
{
    class clsVentas
    {
        public static void Temp_Ventas(string prmUSER_LOGIN, int prmID_CAJA, string prmID_PRODUCTO, double prmCANTIDAD, string prmTIPO_CLIENTE, string prmId_Moneda, int prmId_TipoCambioDia, double prmTipo_Cambio)
        {
            //Para cargar la venta temporal
            int result = 0;
            OleDbConnection cnnTempVentas = new OleDbConnection(Class.clsMain.CnnStr);
            cnnTempVentas.Open();
            OleDbTransaction tran = cnnTempVentas.BeginTransaction();
            OleDbCommand cmdTempVentas = new OleDbCommand();
            cmdTempVentas.Connection = cnnTempVentas;
            cmdTempVentas.Transaction = tran;
            try
            {
                //declaración de variables
                bool varVENDER_SIN_EXISTENCIA = false;
                double varPRECIO_VENTA = 0;
                int varEXISTE = 0;
                double varEXISTENCIA = 0;
                int varUPDATE = 0;
                double varCANT_TEMP = 0;
                string varSQL = "";
                string precio_venta = "";
                double varPrecio = 0;
                double varPrecioMoneda = 0;
                double varDescuento = 0;
                double varDescuentoMoneda = 0;
                double varDescPct = 0;
                string varDescrProducto ="";
                double varTotal = 0;
                double varTotalmoneda = 0;
                double varImpuesto = 0;
                double varPrecioCompra = 0;

                bool HABILITAR_VENTA = true;
                switch (prmTIPO_CLIENTE)
                {
                    case "PP":
                        precio_venta = "PRECIO_VENTA";
                        break;
                    case "PT":
                        precio_venta = "PRECIO_VENTA2";
                        break;
                    case "PM":
                        precio_venta = "PRECIO_VENTA3";
                        break;
                    default:
                        precio_venta = "PRECIO_VENTA";
                        break;
                }

                //verificar si el articulo existe
                cmdTempVentas.CommandText = "SELECT COUNT(*) " +
                    " FROM CAT_PRODUCTO " +
                    " WHERE ID_PRODUCTO=@id and " + precio_venta + " > 0";
                cmdTempVentas.Parameters.Add("@id", OleDbType.VarChar, 50).Value = prmID_PRODUCTO;

                varEXISTE = Convert.ToInt32(cmdTempVentas.ExecuteScalar());
                cmdTempVentas.Parameters.Clear();

                if (varEXISTE == 0) { throw (new Exception("El articulo no existe o no tiene precio de venta")); }

                //obtener los datos del producto


                OleDbDataReader dr;

                cmdTempVentas.CommandText = "SELECT * FROM CAT_PRODUCTO WHERE ID_PRODUCTO=@id";
                cmdTempVentas.Parameters.Add("@id", OleDbType.VarChar, 50).Value = prmID_PRODUCTO;
                dr = cmdTempVentas.ExecuteReader();
                cmdTempVentas.Parameters.Clear();
                if (dr.Read())
                {
                    HABILITAR_VENTA = Convert.ToBoolean(dr["HABILITAR_VENTA"]);
                    varVENDER_SIN_EXISTENCIA = Convert.ToBoolean(dr["VENDER_SIN_EXISTENCIA"]);
                    varEXISTENCIA = Convert.ToDouble(dr["EXISTENCIA"]);
                    varPrecio = Convert.ToDouble(dr[precio_venta]);
                    varPrecioMoneda = Convert.ToDouble(dr[precio_venta]) / prmTipo_Cambio;
                    varDescPct = Convert.ToDouble(dr["DESCUENTO"]);
                    varDescuento = varPrecio *Convert.ToDouble(dr["DESCUENTO"])/100;
                    varDescuentoMoneda = varPrecioMoneda *(Convert.ToDouble(dr["DESCUENTO"])/100);
                    varDescrProducto = dr["DESC_PRODUCTO"].ToString();
                    varTotal = varPrecio - varDescuento;
                    varTotalmoneda = varPrecioMoneda- varDescuentoMoneda  ;
                    varImpuesto = Convert.ToDouble(dr["IMPUESTO"]);
                    varPrecioCompra = Convert.ToDouble(dr["PRECIO_COMPRA"]);
                }
                dr.Close();

                if (!HABILITAR_VENTA) { throw (new Exception("El producto no está habilitado para su venta")); }


                if (varEXISTE != 0)
                {
                    //si el articulo existe, se procede con lo siguiente
                    cmdTempVentas.CommandText = "SELECT COUNT(*) FROM TEMP_VENTA " +
                        " WHERE USER_LOGIN = @user_login" +
                        " AND ID_CAJA = @id_caja" +
                        " AND ID_PRODUCTO = @id";
                    cmdTempVentas.Parameters.Add("@user_login", OleDbType.VarChar, 50).Value = prmUSER_LOGIN;
                    cmdTempVentas.Parameters.Add("@id_caja", OleDbType.Integer).Value = prmID_CAJA;
                    cmdTempVentas.Parameters.Add("@id", OleDbType.VarChar, 50).Value = prmID_PRODUCTO;
                    varUPDATE = Convert.ToInt32(cmdTempVentas.ExecuteScalar());
                    cmdTempVentas.Parameters.Clear();


                    if (varUPDATE != 0)
                    {
                        //si es actualización
                        //obtenemos la cantidad temporal
                        cmdTempVentas.CommandText = "SELECT CANTIDAD FROM TEMP_VENTA" +
                            " WHERE " +
                        "  ID_PRODUCTO =@id";
                        cmdTempVentas.Parameters.Add("@id", OleDbType.VarChar, 50).Value = prmID_PRODUCTO;
                        varCANT_TEMP = Convert.ToDouble(cmdTempVentas.ExecuteScalar());
                        cmdTempVentas.Parameters.Clear();
                        //precio_venta
                       // cmdTempVentas.CommandText = "SELECT " + precio_venta + " FROM CAT_PRODUCTO" +
                       //    " WHERE " +
                       //"  ID_PRODUCTO = @id";
                       // cmdTempVentas.Parameters.Add("@id", OleDbType.VarChar, 50).Value = prmID_PRODUCTO;
                       // varPRECIO_VENTA = Convert.ToDouble(cmdTempVentas.ExecuteScalar());
                        cmdTempVentas.Parameters.Clear();
                        varSQL = "UPDATE TEMP_VENTA SET CANTIDAD = @cantidad," +
                                 "TOTIMPUESTO_MONEDA=@totImpuestoMoneda," +
                                 "TOTIMPUESTO=@totImpuesto ,DESCUENTO=@Descuento,DESCUENTO_MONEDA=@DescuentoMoneda," +
                                "TOTAL=@total,TOTAL_MONEDA=@totalmoneda "+
                                 
                        " WHERE USER_LOGIN = @user_login" +
                        " AND ID_CAJA = @id_caja" +
                        " AND ID_PRODUCTO = @id";
                        cmdTempVentas.Parameters.Add("@cantidad", OleDbType.Double).Value = varCANT_TEMP + prmCANTIDAD;
                        cmdTempVentas.Parameters.Add("@totImpuestoMoneda", OleDbType.Double).Value = (varCANT_TEMP + prmCANTIDAD) * varImpuesto * (varPrecioMoneda - varDescuentoMoneda);
                        cmdTempVentas.Parameters.Add("@totImpuesto", OleDbType.Double).Value = (varCANT_TEMP + prmCANTIDAD) * varImpuesto * (varPrecio - varDescuento);
                        cmdTempVentas.Parameters.Add("@Descuento", OleDbType.Double).Value = (varCANT_TEMP + prmCANTIDAD) * varDescuento;
                        cmdTempVentas.Parameters.Add("@DescuentoMoneda", OleDbType.Double).Value = (varCANT_TEMP + prmCANTIDAD) * varDescuentoMoneda;
                        cmdTempVentas.Parameters.Add("@total", OleDbType.Double).Value = (varCANT_TEMP + prmCANTIDAD) * varTotal;
                        cmdTempVentas.Parameters.Add("@totalmoneda", OleDbType.Double).Value = (varCANT_TEMP + prmCANTIDAD) * varTotalmoneda;
                        cmdTempVentas.Parameters.Add("@user_login", OleDbType.VarChar, 50).Value = prmUSER_LOGIN;
                        cmdTempVentas.Parameters.Add("@id_caja", OleDbType.Integer).Value = prmID_CAJA;
                        cmdTempVentas.Parameters.Add("@id", OleDbType.VarChar, 50).Value = prmID_PRODUCTO;
                      
                    }
                    else
                    {
                        varSQL = "INSERT INTO TEMP_VENTA ( USER_LOGIN, ID_CAJA, ID_PRODUCTO, CANTIDAD," +
                               "PRECIO, IMPUESTO, PRECIO_COMPRA," +
                               "TIPO_PRECIO,ID_MONEDA,ID_TIPOCAMBIODIA," +
                               "TIPO_CAMBIO, PRECIO_MONEDA,TOTIMPUESTO_MONEDA," +
                               "TOTIMPUESTO ,DESCUENTO,DESCUENTO_MONEDA," +
                                "TOTAL,TOTAL_MONEDA, DESCUENTO_PCT,DESC_PRODUCTO )" +
                        "Values( @user_login, @id_caja, @id, @cantidad " +
                        ", @precio, @impuesto, @preciocompra " +
                        ", @tipo_cliente , @Id_Moneda, @Id_TipoCambioDia " +
                        ", @Tipo_Cambio, @precioMoneda,@totImpuestoMoneda  " +
                        ", @totImpuesto, @Descuento , @DescuentoMoneda, @total, @totalmoneda, @DescuentoPCT,@DescrProducto)";
                        cmdTempVentas.Parameters.Add("@user_login", OleDbType.VarChar, 50).Value = prmUSER_LOGIN;
                        cmdTempVentas.Parameters.Add("@id_caja", OleDbType.Integer).Value = prmID_CAJA;
                        cmdTempVentas.Parameters.Add("@id", OleDbType.VarChar, 50).Value = prmID_PRODUCTO;
                        cmdTempVentas.Parameters.Add("@cantidad", OleDbType.Double).Value = prmCANTIDAD;
                        cmdTempVentas.Parameters.Add("@precio", OleDbType.Double).Value = varPrecio ;
                        cmdTempVentas.Parameters.Add("@impuesto", OleDbType.Double).Value = varImpuesto;
                        cmdTempVentas.Parameters.Add("@precioCompra", OleDbType.Double).Value = varPrecioCompra;
                        cmdTempVentas.Parameters.Add("@tipo_cliente", OleDbType.VarChar, 50).Value = prmTIPO_CLIENTE;
                        cmdTempVentas.Parameters.Add("@Id_Moneda", OleDbType.VarChar, 5).Value = prmId_Moneda;
                        cmdTempVentas.Parameters.Add("@Id_TipoCambioDia", OleDbType.Integer).Value = prmId_TipoCambioDia;
                        cmdTempVentas.Parameters.Add("@Tipo_Cambio", OleDbType.Double).Value = prmTipo_Cambio;
                        cmdTempVentas.Parameters.Add("@precioMoneda", OleDbType.Double).Value = varPrecioMoneda;
                        cmdTempVentas.Parameters.Add("@totImpuestoMoneda", OleDbType.Double).Value =prmCANTIDAD * varImpuesto * (varPrecioMoneda - varDescuentoMoneda );
                        cmdTempVentas.Parameters.Add("@totImpuesto", OleDbType.Double).Value =prmCANTIDAD * varImpuesto *(varPrecio - varDescuento);
                        cmdTempVentas.Parameters.Add("@Descuento", OleDbType.Double).Value =  prmCANTIDAD* varDescuento;
                        cmdTempVentas.Parameters.Add("@DescuentoMoneda", OleDbType.Double).Value = prmCANTIDAD*varDescuentoMoneda;
                        cmdTempVentas.Parameters.Add("@total", OleDbType.Double).Value = prmCANTIDAD * varTotal ;
                        cmdTempVentas.Parameters.Add("@totalmoneda", OleDbType.Double).Value = prmCANTIDAD * varTotalmoneda;
                        cmdTempVentas.Parameters.Add("@DescuentoPCT", OleDbType.Double).Value = varDescPct;
                        cmdTempVentas.Parameters.Add("@DescrProducto", OleDbType.VarChar,100).Value =varDescrProducto;
                        
                    }

                    if (!varVENDER_SIN_EXISTENCIA)
                    {

                        if (varEXISTENCIA >= (prmCANTIDAD + varCANT_TEMP))
                        {
                            // si la existencia + cantidad temporal es mayor que la cantidad a agregar
                            cmdTempVentas.CommandText = varSQL;
                            result = cmdTempVentas.ExecuteNonQuery();
                        }
                        else
                        {
                            MessageBox.Show("No hay existencias suficientes.\n" +
                                "Existencia: " + String.Format("{0:N}", varEXISTENCIA) +
                                "\nRequeridos: " + String.Format("{0:N}", prmCANTIDAD + varCANT_TEMP),
                                "Información del sistema", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        //se puede vender sin existencia
                        //MessageBox.Show(result.ToString());
                        cmdTempVentas.CommandText = varSQL;
                        cmdTempVentas.ExecuteNonQuery();
                    }
                }
                else
                {
                    MessageBox.Show("El artículo no existe o no tiene precio de venta", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                tran.Commit();
            }

            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show(ex.Message,
                    "TempSales");
            }
            finally
            {
                cnnTempVentas.Close();
                cnnTempVentas.Dispose();
                cmdTempVentas.Dispose();
            }
        }


        /// <summary>
        /// Realizar Venta de Mostrador
        /// </summary>
        /// <param name="prmUSER_LOGIN"></param>
        /// <param name="prmID_CAJA"></param>
        /// <param name="prmID_CLIENTE"></param>
        /// <param name="prmFECHA_OPERACION"></param>
        /// <param name="prmRFC"></param>
        /// <param name="prmCURP"></param>
        /// <param name="prmNOMBRE"></param>
        /// <param name="prmDOMICILIO"></param>
        /// <param name="prmID_ESTADO"></param>
        /// <param name="prmID_MUNICIPIO"></param>
        /// <param name="prmID_LOCALIDAD"></param>
        /// <param name="prmCP"></param>
        /// <param name="prmTELEFONO"></param>
        /// <param name="prmEMAIL"></param>
        /// <param name="prmTIPO_CLIENTE"></param>
        /// <param name="prmOBSERVACIONES"></param>
        /// <param name="prmId_tipo_Pago"></param>
        /// <param name="prmTIPO_PAGO"></param>
        /// <param name="prmPago"></param>
        /// <param name="prmIdTipoCambiodia"></param>
        /// <param name="idMoneda"></param>
        /// <param name="prmTipoCambio"></param>
        /// <param name="prmNO_AUTORIZACION"></param>
        /// <param name="prmCREDITO"></param>
        /// <param name="prmEFECTIVO"></param>
        /// <param name="prmTotal"></param>
        /// <param name="prmIdTipoPago"></param>
        /// <param name="prmFOLIO_FACTURA"></param>
        /// <returns></returns>
        public int RealizaVenta(string prmUSER_LOGIN, int prmID_CAJA, int prmID_CLIENTE, DateTime prmFECHA_OPERACION, string prmRFC,
            string prmCURP, string prmNOMBRE, string prmDOMICILIO, string prmID_ESTADO, string prmID_MUNICIPIO, string prmID_LOCALIDAD,
            string prmCP, string prmTELEFONO, string prmEMAIL, string prmTIPO_CLIENTE, string prmOBSERVACIONES, int prmId_tipo_Pago,
            string prmTIPO_PAGO, double prmPago, int prmId_TipoCambioDia, string prmId_Moneda, double prmTipo_Cambio, string prmNO_AUTORIZACION,
            string prmDigitosPago, bool prmCREDITO, double prmEFECTIVO, double prmTotal)
        {
            try
            {
                int varFolio = 0;
                double varTOTAL = 0;
                string varID_PRODUCTO = "";
                double varCantidad = 0;
                string varSQL_Insert = "";
                string varSQL_Update = "";
                
                /*MSalazar*/
               
                double varPrecioVenta = 0;
                double varPrecioVentaMoneda = 0;
                double varDescuento = 0;
                double varDescuentoMoneda = 0;
                double varDescPct = 0;
                string varDescrProducto = "";
                double varTotal = 0;
                double varTotalmoneda = 0;
                double varImpuesto = 0;
                double varPrecioCompra = 0;
                double varTOTImpuestoMoneda = 0;
                double varTOTImpuesto = 0;
                /*teremina declaración de variables*/
                OleDbConnection cnnRealizaVenta = new OleDbConnection(Class.clsMain.CnnStr);
                OleDbConnection cnnInsert = new OleDbConnection(Class.clsMain.CnnStr);
                cnnRealizaVenta.Open();
                cnnInsert.Open();
                OleDbTransaction myTrans = cnnInsert.BeginTransaction();
                try
                {

                    OleDbCommand cmdInsert = new OleDbCommand();
                    cmdInsert.Transaction = myTrans;
                    cmdInsert.Connection = cnnInsert;
                    //generamos el folio
                    //sin multi moneda 
                    cmdInsert.CommandText =
                      string.Format(@" INSERT INTO VENTA (USER_LOGIN,ID_CAJA,FECHA,ID_TIPO_PAGO,TIPO_PAGO,PAGO,PAGO_MONEDA, NO_AUTORIZACION,DIGITOS_PAGO,TOTAL,TOTAL_MONEDA,ID_MONEDA,EFECTIVO,EFECTIVO_MONEDA, COBRADO,COBRADO_MONEDA,ID_TIPOCAMBIODIA,TIPO_CAMBIO) 
                                    VALUES(@user_login,@id_caja,Now(), @id_tipo_Pago,@tipo_pago,@pago,@pago_moneda,@no_autorizacion,@digitos_pago,@total,@total_moneda,@id_moneda,@efectivo,@efectivo_moneda,@efectivo + @pago, @efectivo_moneda + @pago_moneda, @id_tipocambioDia, @tipoCambio)");
                    //con Multimoneda =
                    //cmdInsert.CommandText = "INSERT INTO VENTA (USER_LOGIN,ID_CAJA,FECHA,TIPO_PAGO,NO_AUTORIZACION,TOTAL,COBRADO,TOTAL_MONEDA,ID_MONEDA,COBRADO_MONEDA,ID_TIPOCAMBIODIA,TIPO_CAMBIO) " +
                    //" VALUES(@user_login,@id_caja,Now(),@tipo_pago,@no_autorizacion,@total,@efectivo,@total_moneda,@id_moneda,@efectivo_moneda,@id_tipocambioDia,@tipoCambio)";
                    cmdInsert.Parameters.Add("@user_login", OleDbType.VarChar, 50).Value = prmUSER_LOGIN;
                    cmdInsert.Parameters.Add("@id_caja", OleDbType.Integer).Value = prmID_CAJA;
                    cmdInsert.Parameters.Add("@id_tipo_Pago", OleDbType.Integer).Value = prmId_tipo_Pago;
                    cmdInsert.Parameters.Add("@tipo_pago", OleDbType.VarChar, 50).Value = prmTIPO_PAGO;
                    cmdInsert.Parameters.Add("@pago", OleDbType.Double).Value = prmPago * prmTipo_Cambio;
                    cmdInsert.Parameters.Add("@pago_moneda", OleDbType.Double).Value = (prmPago);
                    cmdInsert.Parameters.Add("@no_autorizacion", OleDbType.VarChar, 50).Value = prmNO_AUTORIZACION;
                    cmdInsert.Parameters.Add("@digitos_pago", OleDbType.VarChar, 4).Value = prmDigitosPago;
                    cmdInsert.Parameters.Add("@total", OleDbType.Double).Value = (prmTotal * prmTipo_Cambio);
                    cmdInsert.Parameters.Add("@total_moneda", OleDbType.Double).Value = prmTotal;
                    cmdInsert.Parameters.Add("@id_moneda", OleDbType.VarChar, 4).Value = prmId_Moneda;
                    cmdInsert.Parameters.Add("@efectivo", OleDbType.Double).Value = prmEFECTIVO * prmTipo_Cambio;
                    cmdInsert.Parameters.Add("@efectivo_moneda", OleDbType.Double).Value = (prmEFECTIVO);
                    cmdInsert.Parameters.Add("@id_tipocambioDia", OleDbType.Numeric).Value = prmId_TipoCambioDia;
                    cmdInsert.Parameters.Add("@tipoCambio", OleDbType.Double).Value = prmTipo_Cambio;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Parameters.Clear();
                    //obtenemos el folio
                    cmdInsert.CommandText = "SELECT @@IDENTITY";
                    varFolio = Convert.ToInt32(cmdInsert.ExecuteScalar());
                    #region inserta Datos Cliente
                    //insertamos o actualizamos el cliente
                    if (prmID_CLIENTE == 0)
                    {
                        //nuevo cliente
                        cmdInsert.CommandText = "INSERT INTO CAT_CLIENTE (NOMBRE,RFC,CURP,ID_ESTADO," +
                        " ID_MUNICIPIO,ID_LOCALIDAD,DOMICILIO,USER_LOGIN,CP,TELEFONO,EMAIL,TIPO_CLIENTE,FECHA_VENTA) " +
                        " VALUES(@nombre,@rfc,@curp,@id_estado, @id_municipio,@id_localidad,@domicilio,@user_login,@cp,@telefono,@email,@tipo_cliente,GETDATE())";
                        cmdInsert.Parameters.Add("@nombre", OleDbType.VarChar, 150).Value = prmNOMBRE;
                        cmdInsert.Parameters.Add("@rfc", OleDbType.VarChar, 50).Value = prmRFC;
                        cmdInsert.Parameters.Add("@curp", OleDbType.VarChar, 50).Value = prmCURP;
                        cmdInsert.Parameters.Add("@id_estado", OleDbType.VarChar, 50).Value = prmID_ESTADO;
                        cmdInsert.Parameters.Add("@id_municipio", OleDbType.VarChar, 50).Value = prmID_MUNICIPIO;
                        cmdInsert.Parameters.Add("@id_localidad", OleDbType.VarChar, 50).Value = prmID_LOCALIDAD;
                        cmdInsert.Parameters.Add("@domicilio", OleDbType.VarChar, 50).Value = prmDOMICILIO;
                        cmdInsert.Parameters.Add("@user_login", OleDbType.VarChar, 50).Value = prmUSER_LOGIN;
                        cmdInsert.Parameters.Add("@cp", OleDbType.VarChar, 50).Value = prmCP;
                        cmdInsert.Parameters.Add("@telefono", OleDbType.VarChar, 50).Value = prmTELEFONO;
                        cmdInsert.Parameters.Add("@email", OleDbType.VarChar, 50).Value = prmEMAIL;
                        cmdInsert.Parameters.Add("@tipo_cliente", OleDbType.VarChar, 50).Value = prmTIPO_CLIENTE;
                        cmdInsert.ExecuteNonQuery();
                        cmdInsert.Parameters.Clear();
                        cmdInsert.CommandText = "SELECT @@IDENTITY";
                        prmID_CLIENTE = Convert.ToInt32(cmdInsert.ExecuteScalar());
                    }
                    else
                    {
                        cmdInsert.CommandText = "UPDATE CAT_CLIENTE SET " +
                        " NOMBRE=@nombre,RFC=@rfc,CURP=@curp, ID_ESTADO=@id_estado, ID_MUNICIPIO=@id_municipio,ID_LOCALIDAD=@id_localidad,DOMICILIO=@domicilio," +
                        " USER_LOGIN=@user_login,CP=@cp,TELEFONO=@telefono,EMAIL=@email," +
                        " TIPO_CLIENTE=@tipo_cliente,FECHA_VENTA=NOW()" +
                        " WHERE ID_CLIENTE=@id_cliente";
                        cmdInsert.Parameters.Add("@nombre", OleDbType.VarChar, 150).Value = prmNOMBRE;
                        cmdInsert.Parameters.Add("@rfc", OleDbType.VarChar, 50).Value = prmRFC;
                        cmdInsert.Parameters.Add("@curp", OleDbType.VarChar, 50).Value = prmCURP;
                        cmdInsert.Parameters.Add("@id_estado", OleDbType.VarChar, 50).Value = prmID_ESTADO;
                        cmdInsert.Parameters.Add("@id_municipio", OleDbType.VarChar, 50).Value = prmID_MUNICIPIO;
                        cmdInsert.Parameters.Add("@id_localidad", OleDbType.VarChar, 50).Value = prmID_LOCALIDAD;
                        cmdInsert.Parameters.Add("@domicilio", OleDbType.VarChar, 50).Value = prmDOMICILIO;
                        cmdInsert.Parameters.Add("@user_login", OleDbType.VarChar, 50).Value = prmUSER_LOGIN;
                        cmdInsert.Parameters.Add("@cp", OleDbType.VarChar, 50).Value = prmCP;
                        cmdInsert.Parameters.Add("@telefono", OleDbType.VarChar, 50).Value = prmTELEFONO;
                        cmdInsert.Parameters.Add("@email", OleDbType.VarChar, 50).Value = prmEMAIL;
                        cmdInsert.Parameters.Add("@tipo_cliente", OleDbType.VarChar, 50).Value = prmTIPO_CLIENTE;
                        cmdInsert.Parameters.Add("@id_cliente", OleDbType.Integer).Value = prmID_CLIENTE;
                        cmdInsert.ExecuteNonQuery();
                        cmdInsert.Parameters.Clear();
                    }
                    #endregion
                    #region Actualiza IdCliente en la Venta
                    //ACTUALIZAMOS LA CLAVE DEL CLIENTE EN VENTA
                    cmdInsert.CommandText = "UPDATE VENTA SET ID_CLIENTE =@id_cliente,FECHA=@fecha_operacion " +
                        "WHERE FOLIO=@folio ";
                    cmdInsert.Parameters.Add("@id_cliente", OleDbType.Integer).Value = prmID_CLIENTE;
                    cmdInsert.Parameters.Add("@fecha_operacion", OleDbType.Date).Value = prmFECHA_OPERACION;
                    cmdInsert.Parameters.Add("@folio", OleDbType.Integer).Value = varFolio;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Parameters.Clear();
                    #endregion

                    #region inserta detalle de venta
                    //detalle de la venta
                    OleDbCommand cmdRealizaVenta =
                        new OleDbCommand("SELECT * FROM TEMP_VENTA " +
                            " WHERE  USER_LOGIN = @user_login AND ID_CAJA=@id_caja", cnnRealizaVenta);
                    cmdRealizaVenta.Parameters.Add("@user_login", OleDbType.VarChar, 50).Value = prmUSER_LOGIN;
                    cmdRealizaVenta.Parameters.Add("@id_caja", OleDbType.Integer).Value = prmID_CAJA;
                    OleDbDataReader drRealizaVenta;
                    drRealizaVenta = cmdRealizaVenta.ExecuteReader();
                    while (drRealizaVenta.Read())
                    {
                        //PONER AQUÍ EL CÓDIGO PARA CARGAR A LA TABLA VENTAS  
                        varID_PRODUCTO = drRealizaVenta["ID_PRODUCTO"].ToString();
                        varCantidad = (double)drRealizaVenta["CANTIDAD"];
                        varPrecioVenta = Convert.ToDouble(drRealizaVenta["PRECIO"]);
                        varImpuesto = Convert.ToDouble(drRealizaVenta["IMPUESTO"]);
                        //fechaHora
                        varDescuento =  Convert.ToDouble(drRealizaVenta["DESCUENTO"]);
                        varDescuentoMoneda = (Convert.ToDouble(drRealizaVenta["DESCUENTO_MONEDA"]));
                        varPrecioCompra = Convert.ToDouble(drRealizaVenta["PRECIO_COMPRA"]);
                        //cmdInsert.Parameters.Add("@tipo_precio", OleDbType.VarChar, 50).Value = prmTIPO_CLIENTE;
                        //cmdInsert.Parameters.Add("@Id_Moneda", OleDbType.VarChar, 5).Value = prmId_Moneda;
                        //cmdInsert.Parameters.Add("@Id_TipoCambioDia", OleDbType.Integer).Value = prmId_TipoCambioDia;
                        //cmdInsert.Parameters.Add("@Tipo_Cambio", OleDbType.Double).Value = prmTipo_Cambio;
                        varPrecioVentaMoneda = Convert.ToDouble(drRealizaVenta["PRECIO_MONEDA"]);
                        varTOTImpuestoMoneda = Convert.ToDouble(drRealizaVenta["TOTIMPUESTO_MONEDA"]);
                        varTOTImpuesto = Convert.ToDouble(drRealizaVenta["TOTIMPUESTO"]);
                        varTotal = Convert.ToDouble(drRealizaVenta["TOTAL"]);
                        varTotalmoneda = Convert.ToDouble(drRealizaVenta["TOTAL_MONEDA"]);
                        varDescPct = Convert.ToDouble(drRealizaVenta["DESCUENTO_PCT"]);
                        varDescrProducto = drRealizaVenta["DESC_PRODUCTO"].ToString();
                        //Acumula el total , para actualizar total de la venta
                        varTOTAL += varTotal;
                        varSQL_Insert = "INSERT INTO VENTA_DETALLE " + //" (FOLIO,ID_PRODUCTO,CANTIDAD,PRECIO_VENTA,IMPUESTO,DESCUENTO,DESCUENTO_MONEDA, PRECIO_COMPRA,TIPO_PRECIO,ID_MONEDA,ID_TIPOCAMBIODIA,TIPO_CAMBIO, PRECIO_VENTA_MONEDA,IMPUESTO_MONEDA )" +
                        " (FOLIO,FOLIO_FACTURA,ID_PRODUCTO,CANTIDAD,PRECIO_VENTA,IMPUESTO,FECHAHORA,EXISTENCIA_DESPUES,EXISTENCIA_ANTES,DESCUENTO,DESCUENTO_MONEDA,PRECIO_COMPRA,TIPO_PRECIO,ID_MONEDA,ID_TIPOCAMBIODIA,TIPO_CAMBIO,PRECIO_VENTA_MONEDA,TOTIMPUESTO_MONEDA,TOTIMPUESTO,TOTAL,TOTAL_MONEDA,DESCUENTO_PCT,DESC_PRODUCTO)"+
                        " VALUES (@folio,'',@id_producto,@cantidad, @precio,@impuesto,NOW(), 0 ,0 , @descuento,@descuento_Moneda,@precio_compra,@tipo_precio,@Id_Moneda,@Id_TipoCambioDia,@Tipo_Cambio, @precio_moneda,@TOTImpuesto_moneda,@TOTImpuesto,@Total,@totalMoneda, @DescuentoPCT, @DescProducto )";
                        cmdInsert.CommandText = varSQL_Insert;
                        cmdInsert.Parameters.Add("@folio", OleDbType.Integer).Value = varFolio;
                        cmdInsert.Parameters.Add("@id_producto", OleDbType.VarChar, 50).Value = varID_PRODUCTO;
                        cmdInsert.Parameters.Add("@cantidad", OleDbType.Double).Value = varCantidad;
                        cmdInsert.Parameters.Add("@precio", OleDbType.Double).Value = varPrecioVenta;
                        cmdInsert.Parameters.Add("@impuesto", OleDbType.Double).Value = varImpuesto;
                        cmdInsert.Parameters.Add("@descuento", OleDbType.Double).Value = varDescuento;
                        cmdInsert.Parameters.Add("@descuento_Moneda", OleDbType.Double).Value = varDescuentoMoneda;
                        cmdInsert.Parameters.Add("@precio_compra", OleDbType.Double).Value = varPrecioCompra;
                        /*MIguel */
                        cmdInsert.Parameters.Add("@tipo_precio", OleDbType.VarChar, 50).Value = prmTIPO_CLIENTE;
                        cmdInsert.Parameters.Add("@Id_Moneda", OleDbType.VarChar, 5).Value = prmId_Moneda;
                        cmdInsert.Parameters.Add("@Id_TipoCambioDia", OleDbType.Integer).Value = prmId_TipoCambioDia;
                        cmdInsert.Parameters.Add("@Tipo_Cambio", OleDbType.Double).Value = prmTipo_Cambio;
                        cmdInsert.Parameters.Add("@precio_moneda", OleDbType.Double).Value = varPrecioVentaMoneda;
                        cmdInsert.Parameters.Add("@TOTImpuesto_moneda", OleDbType.Double).Value = varTOTImpuestoMoneda;
                        cmdInsert.Parameters.Add("@TOTImpuesto", OleDbType.Double).Value = varTOTImpuesto;
                        cmdInsert.Parameters.Add("@Total",OleDbType.Double).Value = varTotal;
                        cmdInsert.Parameters.Add("@totalMoneda",OleDbType.Double).Value = varTotalmoneda;
                        cmdInsert.Parameters.Add("@DescuentoPCT",OleDbType.Double).Value = varDescPct;
                        cmdInsert.Parameters.Add("@DescProducto", OleDbType.VarChar,50).Value = varDescrProducto;
                        cmdInsert.ExecuteNonQuery();
                        cmdInsert.Parameters.Clear();
                        //AHORA ACTUALIZAREMOS LA EXISTENCIA ANTES DE LA VENTA EN "VENTA_DETALLE"
                        int _EXISTENCIA = 0;
                        cmdInsert.CommandText = "SELECT EXISTENCIA FROM CAT_PRODUCTO WHERE ID_PRODUCTO =@id_producto";
                        cmdInsert.Parameters.Add("@id_producto", OleDbType.VarChar, 50).Value = varID_PRODUCTO;
                        _EXISTENCIA = Convert.ToInt32(cmdInsert.ExecuteScalar());
                        cmdInsert.Parameters.Clear();
                        cmdInsert.CommandText = "UPDATE VENTA_DETALLE SET EXISTENCIA_ANTES =@existencia_antes  " +
                            " WHERE ID_PRODUCTO=@id_producto AND FOLIO =@folio ";
                        cmdInsert.Parameters.Add("@existencia_antes", OleDbType.Double).Value = _EXISTENCIA;
                        cmdInsert.Parameters.Add("@id_producto", OleDbType.VarChar, 50).Value = varID_PRODUCTO;
                        cmdInsert.Parameters.Add("@folio", OleDbType.Integer).Value = varFolio;
                        cmdInsert.ExecuteNonQuery();
                        cmdInsert.Parameters.Clear();
                        //ACTUALIZAMOS LA TABLA CAT_PRODUCTOS
                        varSQL_Update = "UPDATE CAT_PRODUCTO SET " +
                        " EXISTENCIA = EXISTENCIA - @cantidad" +
                        " WHERE ID_PRODUCTO = @id_producto" +
                        " AND INGREDIENTES=FALSE AND ID_PRODUCTO <> '00000'";
                        cmdInsert.Parameters.Add("@cantidad", OleDbType.Double).Value = varCantidad;
                        cmdInsert.Parameters.Add("@id_producto", OleDbType.VarChar, 50).Value = varID_PRODUCTO;
                        cmdInsert.CommandText = varSQL_Update;
                        cmdInsert.ExecuteNonQuery();
                        cmdInsert.Parameters.Clear();
                        //AHORA ACTUALIZAREMOS LA EXISTENCIA EN EL MOMENTO DE LA VENTA EN "VENTA_DETALLE"
                        _EXISTENCIA = 0;
                        cmdInsert.CommandText = "SELECT EXISTENCIA FROM CAT_PRODUCTO WHERE ID_PRODUCTO =@id_producto";
                        cmdInsert.Parameters.Add("@id_producto", OleDbType.VarChar, 50).Value = varID_PRODUCTO;
                        _EXISTENCIA = Convert.ToInt32(cmdInsert.ExecuteScalar());
                        cmdInsert.Parameters.Clear();
                        cmdInsert.CommandText = "UPDATE VENTA_DETALLE SET EXISTENCIA_DESPUES =@existencia_despues " +
                            " WHERE ID_PRODUCTO=@id_producto AND FOLIO =@folio";
                        cmdInsert.Parameters.Add("@existencia_despues", OleDbType.Double).Value = _EXISTENCIA;
                        cmdInsert.Parameters.Add("@id_producto", OleDbType.VarChar, 50).Value = varID_PRODUCTO;
                        cmdInsert.Parameters.Add("@folio", OleDbType.Integer).Value = varFolio;
                        cmdInsert.ExecuteNonQuery();
                        cmdInsert.Parameters.Clear();
                        //ACTUALIZAMOS LAS EXISTENCIAS DE LOS PRODUCTOS QUE SON "INGREDIENTES"
                        cmdInsert.CommandText = "UPDATE CAT_PRODUCTO INNER JOIN CAT_PRODUCTO_INGREDIENTES " +
                            " ON CAT_PRODUCTO.ID_PRODUCTO = CAT_PRODUCTO_INGREDIENTES.ID_PRODUCTO " +
                        " SET CAT_PRODUCTO.EXISTENCIA = CAT_PRODUCTO.EXISTENCIA-(" + varCantidad + "*CAT_PRODUCTO_INGREDIENTES.CANTIDAD)" +
                        " WHERE CAT_PRODUCTO_INGREDIENTES.ID_PRODUCTO_PADRE=@id_producto";
                        cmdInsert.Parameters.Add("@id_producto", OleDbType.VarChar, 50).Value = varID_PRODUCTO;
                        cmdInsert.ExecuteNonQuery();
                        cmdInsert.Parameters.Clear();
                    }
                    #endregion
                    drRealizaVenta.Close();
                    cmdInsert.Parameters.Clear();//limpiamos parametros
                    //ACTUALIZAMOS LA TABLA DE MONTO INICIAl
                    cmdInsert.CommandText = "UPDATE SALE_START_AMOUNT SET SALE_DATE_END=@SALE_DATE_END " +
                        " WHERE ID_POS=pID_POS AND USER_LOGIN=pUSER_LOGIN";
                    cmdInsert.Parameters.Add("@SALE_DATE_END", OleDbType.Date).Value = prmFECHA_OPERACION;
                    cmdInsert.Parameters.Add("pID_POS", OleDbType.SmallInt).Value = prmID_CAJA;
                    cmdInsert.Parameters.Add("pUSER_LOGIN", OleDbType.VarChar, 50).Value = prmUSER_LOGIN;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Parameters.Clear();//limpiamos parametros
                    //borramos la tabla temporal
                    cmdInsert.CommandText = "DELETE FROM TEMP_VENTA " +
                    " WHERE USER_LOGIN = @user_login AND ID_CAJA=@id_Caja";
                    cmdInsert.Parameters.Add("@user_login", OleDbType.VarChar, 50).Value = prmUSER_LOGIN;
                    cmdInsert.Parameters.Add("@id_caja", OleDbType.SmallInt).Value = prmID_CAJA;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Parameters.Clear();//limpiamos parametros
                    //Ventas a Credito
                    if (prmCREDITO)
                    {
                        clsCredito credito = new clsCredito();
                        credito.fnCREDITO(varFolio, 0, varTOTAL, prmUSER_LOGIN, prmEFECTIVO, cnnInsert, myTrans);
                    }

                    //LIBERAMOS LOS OBJETOS
                    myTrans.Commit();
                    cnnInsert.Close();
                    cnnInsert.Dispose();
                    cmdInsert.Dispose();
                    cnnRealizaVenta.Close();
                    cmdRealizaVenta.Dispose();
                    //Ticket de Venta
                    if (Convert.ToBoolean(AppSettings.GetValue("Ticket", "PrintTicket", "true")))
                    {

                        ImprimeTicket(varFolio, true);
                    }

                    //ejecutamos la transacción
                    return (varFolio);
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
                                " was found during undoing transaction", "RealizarVenta");
                        }
                    }
                    MessageBox.Show(e.Message, "Error-RealizaVenta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return (0);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void MoneyCounting(int prmIdSaleStartAmount, double prmCash)
        {

            OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
            int RowCount = 0;//Contador de Registros
            double SaleStartAmount = 0;//Monto inicial de Caja
            int IdMoneyCounting = 0;//Id del corte de Caja
            double TotalSales = 0;//total de las ventas
            double TotalGastos = 0;//total de las ventas
            double TotalCobranza = 0;//total de cobros de crédito
            double TotalContado = 0;
            double TotalCredito = 0;
            int IdPOS = 0;
            string prmUserLogin = "";
            DateTime DateStart = DateTime.Now;
            DateTime DateEnd = DateTime.Now;
            try
            {
                cnn.Open();
                OleDbTransaction tran = cnn.BeginTransaction();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;
                cmd.Transaction = tran;
                try
                {
                    cmd.CommandText = "SELECT COUNT(*) FROM SALE_START_AMOUNT WHERE ID_SALE_START_AMOUNT=@ID";
                    cmd.Parameters.Add("@ID", OleDbType.Integer).Value = prmIdSaleStartAmount;
                    RowCount = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.Parameters.Clear();//limpiamos params
                    if (RowCount == 0) { throw (new Exception("El usuario no tiene abierta caja alguna")); }
                    cmd.CommandText = "SELECT ID_POS,USER_LOGIN,SALE_DATE, SALE_DATE_END, START_AMOUNT FROM SALE_START_AMOUNT WHERE ID_SALE_START_AMOUNT=@ID";
                    cmd.Parameters.Add("@ID", OleDbType.Integer).Value = prmIdSaleStartAmount;
                    OleDbDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        IdPOS = Convert.ToInt32(dr["ID_POS"]);
                        prmUserLogin = dr["USER_LOGIN"].ToString();
                        DateStart = Convert.ToDateTime(dr["SALE_DATE"]);
                        DateEnd = Convert.ToDateTime(dr["SALE_DATE_END"]);
                        SaleStartAmount = Convert.ToDouble(dr["START_AMOUNT"]);
                    }
                    dr.Close();
                    cmd.Parameters.Clear();//limpiamos params

                    //Insertmamos el Registro principal
                    cmd.CommandText = "INSERT INTO MONEY_COUNTING(SALE_DATE,USER_LOGIN,ID_POS,START_AMOUNT,CASH,SALE_DATE_END) VALUES (@SALE_DATE,@USER_LOGIN,@ID_POS,@START_AMOUNT,@CASH,@SALE_DATE_END)";
                    cmd.Parameters.Add("@SALE_DATE", OleDbType.Date).Value = DateStart;
                    cmd.Parameters.Add("@USER_LOGIN", OleDbType.VarChar, 50).Value = prmUserLogin;
                    cmd.Parameters.Add("@ID_POS", OleDbType.Integer).Value = IdPOS;
                    cmd.Parameters.Add("@START_AMOUNT", OleDbType.Double).Value = SaleStartAmount;
                    cmd.Parameters.Add("@CASH", OleDbType.Double).Value = prmCash;
                    cmd.Parameters.Add("@SALE_DATE_END", OleDbType.Date).Value = DateEnd;
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();//limpiamos params
                    //obtenemos el Id
                    cmd.CommandText = "SELECT @@IDENTITY";
                    IdMoneyCounting = Convert.ToInt32(cmd.ExecuteScalar());
                    //INSERTAMOS EL PRIMER DETALLE
                    cmd.CommandText = "INSERT INTO MONEY_COUNTING_DETAIL(ID_MONEY_COUNTING,CONCEPT,CONCEPT_OPERATION,CONCEPT_VALUE) VALUES(@ID_MONEY_COUNTING,@CONCEPT,@CONCEPT_OPERATION,@CONCEPT_VALUE)";
                    cmd.Parameters.Add("@ID_MONEY_COUNTING", OleDbType.Integer).Value = IdMoneyCounting;
                    cmd.Parameters.Add("@CONCEPT", OleDbType.VarChar, 255).Value = "MONTO INICIAL DE CAJA";
                    cmd.Parameters.Add("@CONCEPT_OPERATION", OleDbType.VarChar, 1).Value = "+";
                    cmd.Parameters.Add("@CONCEPT_VALUE", OleDbType.Double).Value = SaleStartAmount;
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();//limpiamos params
                    //obtenemos el total de las ventas
                    cmd.CommandText = "SELECT COUNT(*) FROM VENTA_DETALLE D,VENTA S WHERE S.FOLIO=D.FOLIO AND S.ID_CAJA=@ID_POS AND S.USER_LOGIN=@USER_LOGIN AND S.FECHA BETWEEN  @SALE_DATE AND @SALE_DATE_END ";
                    cmd.Parameters.Add("@ID_POS", OleDbType.Integer).Value = IdPOS;
                    cmd.Parameters.Add("@USER_LOGIN", OleDbType.VarChar, 50).Value = prmUserLogin;
                    cmd.Parameters.Add("@SALE_DATE", OleDbType.Date).Value = DateStart;
                    cmd.Parameters.Add("@SALE_DATE_END", OleDbType.Date).Value = DateEnd;
                    RowCount = Convert.ToInt32(cmd.ExecuteScalar());
                    if (RowCount != 0)
                    {
                        cmd.CommandText = "SELECT SUM((D.CANTIDAD*D.PRECIO_VENTA)-D.DESCUENTO) FROM VENTA_DETALLE D,VENTA S WHERE S.FOLIO=D.FOLIO AND S.ID_CAJA=@ID_POS AND S.USER_LOGIN=@USER_LOGIN AND S.FECHA BETWEEN @SALE_DATE AND @SALE_DATE_END";
                        cmd.Parameters.Add("@ID_POS", OleDbType.Integer).Value = IdPOS;
                        cmd.Parameters.Add("@USER_LOGIN", OleDbType.VarChar, 50).Value = prmUserLogin;
                        cmd.Parameters.Add("@SALE_DATE", OleDbType.Date).Value = DateStart;
                        cmd.Parameters.Add("@SALE_DATE_END", OleDbType.Date).Value = DateEnd;
                        TotalSales = Convert.ToDouble(cmd.ExecuteScalar());
                        cmd.Parameters.Clear();//limpiamos params
                        cmd.CommandText = "INSERT INTO MONEY_COUNTING_DETAIL(ID_MONEY_COUNTING,CONCEPT,CONCEPT_OPERATION,CONCEPT_VALUE) VALUES(@ID_MONEY_COUNTING,@CONCEPT,@CONCEPT_OPERATION,@CONCEPT_VALUE)";
                        cmd.Parameters.Add("@ID_MONEY_COUNTING", OleDbType.Integer).Value = IdMoneyCounting;
                        cmd.Parameters.Add("@CONCEPT", OleDbType.VarChar, 255).Value = "MONTO DE LAS VENTAS";
                        cmd.Parameters.Add("@CONCEPT_OPERATION", OleDbType.VarChar, 1).Value = "+";
                        cmd.Parameters.Add("@CONCEPT_VALUE", OleDbType.Double).Value = TotalSales;
                        cmd.ExecuteNonQuery();
                    }
                    cmd.Parameters.Clear();//limpiamos params
                    //LIBERAMOS LA CAJA
                    cmd.CommandText = "UPDATE CAT_CAJA SET DISPONIBLE=TRUE WHERE ID_CAJA=@ID_POS";
                    cmd.Parameters.Add("@ID_POS", OleDbType.Integer).Value = IdPOS;
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();//limpiamos params
                    //eliminamos el monto inicial de la caja de la tabla SALE_START_AMOUNT
                    cmd.CommandText = "DELETE FROM SALE_START_AMOUNT WHERE ID_SALE_START_AMOUNT=@ID";
                    cmd.Parameters.Add("@ID", OleDbType.Integer).Value = prmIdSaleStartAmount;
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();//limpiamos params
                    //GENERAMOS LA INFORMACIÓN DE LOS GASTOS
                    cmd.CommandText = "SELECT COUNT(*) FROM GASTO WHERE USER_LOGIN=@USER_LOGIN AND FECHA_GASTO BETWEEN @START_DATE AND @SALE_DATE_END AND ACTIVO = TRUE";
                    cmd.Parameters.Add("@USER_LOGIN", OleDbType.VarChar, 50).Value = prmUserLogin;
                    cmd.Parameters.Add("@SALE_DATE", OleDbType.Date).Value = DateStart;
                    cmd.Parameters.Add("@SALE_DATE_END", OleDbType.Date).Value = DateEnd;
                    RowCount = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.Parameters.Clear();
                    if (RowCount != 0)
                    {
                        cmd.CommandText = "SELECT SUM(IMPORTE) FROM GASTO WHERE USER_LOGIN=@USER_LOGIN AND FECHA_GASTO BETWEEN @START_DATE AND @SALE_DATE_END AND ACTIVO = TRUE";
                        cmd.Parameters.Add("@USER_LOGIN", OleDbType.VarChar, 50).Value = prmUserLogin;
                        cmd.Parameters.Add("@SALE_DATE", OleDbType.Date).Value = DateStart;
                        cmd.Parameters.Add("@SALE_DATE_END", OleDbType.Date).Value = DateEnd;
                        TotalGastos = Convert.ToDouble(cmd.ExecuteScalar());
                        cmd.Parameters.Clear();//limpiamos params
                        cmd.CommandText = "INSERT INTO MONEY_COUNTING_DETAIL(ID_MONEY_COUNTING,CONCEPT,CONCEPT_OPERATION,CONCEPT_VALUE) VALUES(@ID_MONEY_COUNTING,@CONCEPT,@CONCEPT_OPERATION,@CONCEPT_VALUE)";
                        cmd.Parameters.Add("@ID_MONEY_COUNTING", OleDbType.Integer).Value = IdMoneyCounting;
                        cmd.Parameters.Add("@CONCEPT", OleDbType.VarChar, 255).Value = "MONTO DE LOS GASTOS";
                        cmd.Parameters.Add("@CONCEPT_OPERATION", OleDbType.VarChar, 1).Value = "-";
                        cmd.Parameters.Add("@CONCEPT_VALUE", OleDbType.Double).Value = -TotalGastos;
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    //obtenemos las ventas(por tipo de pago)
                    cmd.CommandText = "INSERT INTO MONEY_COUNTING_DETAIL(ID_MONEY_COUNTING,CONCEPT,CONCEPT_OPERATION,CONCEPT_VALUE) " +
                        " SELECT @ID_MONEY_COUNTING,TIPO_PAGO, '*',SUM((PRECIO_VENTA * CANTIDAD))AS VENTAS " +
                        " FROM VENTA INNER JOIN VENTA_DETALLE ON VENTA.FOLIO = VENTA_DETALLE.FOLIO " +
                        " WHERE VENTA.FECHA BETWEEN  @SALE_DAT AND @SALE_DATE_END" +
                        " AND VENTA.ID_CAJA =ID_POS GROUP BY TIPO_PAGO";
                    cmd.Parameters.Add("@ID_MONEY_COUNTING", OleDbType.Integer).Value = IdMoneyCounting;
                    cmd.Parameters.Add("@SALE_DATE", OleDbType.Date).Value = DateStart;
                    cmd.Parameters.Add("@SALE_DATE_END", OleDbType.Date).Value = DateEnd;
                    cmd.Parameters.Add("@ID_POS", OleDbType.Integer).Value = IdPOS;
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    //GENERAR INFORMACIÓN SOBRE COBRANZA
                    cmd.CommandText = "SELECT COUNT(*) FROM PAGO_CREDITO WHERE USER_LOGIN=@USER_LOGIN AND FECHA BETWEEN @START_DATE AND @SALE_DATE_END";
                    cmd.Parameters.Add("@USER_LOGIN", OleDbType.VarChar, 50).Value = prmUserLogin;
                    cmd.Parameters.Add("@SALE_DATE", OleDbType.Date).Value = DateStart;
                    cmd.Parameters.Add("@SALE_DATE_END", OleDbType.Date).Value = DateEnd;
                    RowCount = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.Parameters.Clear();
                    if (RowCount != 0)
                    {
                        cmd.CommandText = "SELECT SUM(CANTIDAD) FROM PAGO_CREDITO WHERE USER_LOGIN=@USER_LOGIN AND FECHA BETWEEN @START_DATE AND @SALE_DATE_END";
                        cmd.Parameters.Add("@USER_LOGIN", OleDbType.VarChar, 50).Value = prmUserLogin;
                        cmd.Parameters.Add("@SALE_DATE", OleDbType.Date).Value = DateStart;
                        cmd.Parameters.Add("@SALE_DATE_END", OleDbType.Date).Value = DateEnd;
                        TotalCobranza = Convert.ToDouble(cmd.ExecuteScalar());
                        cmd.Parameters.Clear();//limpiamos params
                        cmd.CommandText = "INSERT INTO MONEY_COUNTING_DETAIL(ID_MONEY_COUNTING,CONCEPT,CONCEPT_OPERATION,CONCEPT_VALUE) VALUES(@ID_MONEY_COUNTING,@CONCEPT,@CONCEPT_OPERATION,@CONCEPT_VALUE)";
                        cmd.Parameters.Add("@ID_MONEY_COUNTING", OleDbType.Integer).Value = IdMoneyCounting;
                        cmd.Parameters.Add("@CONCEPT", OleDbType.VarChar, 255).Value = "MONTO DE LOS COBROS";
                        cmd.Parameters.Add("@CONCEPT_OPERATION", OleDbType.VarChar, 1).Value = "+";
                        cmd.Parameters.Add("@CONCEPT_VALUE", OleDbType.Double).Value = TotalCobranza;
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    //VENTAS DE CONTADO
                    //obtenemos el total de las ventas DE CONTADO
                    cmd.CommandText = "SELECT COUNT(*) FROM VENTA_DETALLE D,VENTA S WHERE S.FOLIO=D.FOLIO AND S.ID_CAJA=@ID_POS AND S.USER_LOGIN=@USER_LOGIN AND S.FECHA BETWEEN  @SALE_DATE AND @SALE_DATE_END  AND S.FOLIO NOT IN(SELECT FOLIO_VENTA FROM CREDITO)";
                    cmd.Parameters.Add("@ID_POS", OleDbType.Integer).Value = IdPOS;
                    cmd.Parameters.Add("@USER_LOGIN", OleDbType.VarChar, 50).Value = prmUserLogin;
                    cmd.Parameters.Add("@SALE_DATE", OleDbType.Date).Value = DateStart;
                    cmd.Parameters.Add("@SALE_DATE_END", OleDbType.Date).Value = DateEnd;
                    RowCount = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.Parameters.Clear();
                    if (RowCount != 0)
                    {
                        cmd.CommandText = "SELECT SUM((D.CANTIDAD*D.PRECIO_VENTA)-D.DESCUENTO) FROM VENTA_DETALLE D,VENTA S WHERE S.FOLIO=D.FOLIO AND S.ID_CAJA=@ID_POS AND S.USER_LOGIN=@USER_LOGIN AND S.FECHA BETWEEN @SALE_DATE AND @SALE_DATE_END AND S.FOLIO NOT IN(SELECT FOLIO_VENTA FROM CREDITO)";
                        cmd.Parameters.Add("@ID_POS", OleDbType.Integer).Value = IdPOS;
                        cmd.Parameters.Add("@USER_LOGIN", OleDbType.VarChar, 50).Value = prmUserLogin;
                        cmd.Parameters.Add("@SALE_DATE", OleDbType.Date).Value = DateStart;
                        cmd.Parameters.Add("@SALE_DATE_END", OleDbType.Date).Value = DateEnd;
                        TotalContado = Convert.ToDouble(cmd.ExecuteScalar());
                        cmd.Parameters.Clear();//limpiamos params
                        cmd.CommandText = "INSERT INTO MONEY_COUNTING_DETAIL(ID_MONEY_COUNTING,CONCEPT,CONCEPT_OPERATION,CONCEPT_VALUE) VALUES(@ID_MONEY_COUNTING,@CONCEPT,@CONCEPT_OPERATION,@CONCEPT_VALUE)";
                        cmd.Parameters.Add("@ID_MONEY_COUNTING", OleDbType.Integer).Value = IdMoneyCounting;
                        cmd.Parameters.Add("@CONCEPT", OleDbType.VarChar, 255).Value = "VENTAS DE CONTADO";
                        cmd.Parameters.Add("@CONCEPT_OPERATION", OleDbType.VarChar, 1).Value = "V";
                        cmd.Parameters.Add("@CONCEPT_VALUE", OleDbType.Double).Value = TotalContado;
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    //obtenemos el total de las ventas DE CREDITO
                    cmd.CommandText = "SELECT COUNT(*) FROM VENTA_DETALLE D,VENTA S WHERE S.FOLIO=D.FOLIO AND S.ID_CAJA=@ID_POS AND S.USER_LOGIN=@USER_LOGIN AND S.FECHA BETWEEN  @SALE_DATE AND @SALE_DATE_END  AND S.FOLIO IN(SELECT FOLIO_VENTA FROM CREDITO)";
                    cmd.Parameters.Add("@ID_POS", OleDbType.Integer).Value = IdPOS;
                    cmd.Parameters.Add("@USER_LOGIN", OleDbType.VarChar, 50).Value = prmUserLogin;
                    cmd.Parameters.Add("@SALE_DATE", OleDbType.Date).Value = DateStart;
                    cmd.Parameters.Add("@SALE_DATE_END", OleDbType.Date).Value = DateEnd;
                    RowCount = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.Parameters.Clear();
                    if (RowCount != 0)
                    {
                        cmd.CommandText = "SELECT SUM((D.CANTIDAD*D.PRECIO_VENTA)-D.DESCUENTO) FROM VENTA_DETALLE D,VENTA S WHERE S.FOLIO=D.FOLIO AND S.ID_CAJA=@ID_POS AND S.USER_LOGIN=@USER_LOGIN AND S.FECHA BETWEEN @SALE_DATE AND @SALE_DATE_END AND S.FOLIO IN(SELECT FOLIO_VENTA FROM CREDITO)";
                        cmd.Parameters.Add("@ID_POS", OleDbType.Integer).Value = IdPOS;
                        cmd.Parameters.Add("@USER_LOGIN", OleDbType.VarChar, 50).Value = prmUserLogin;
                        cmd.Parameters.Add("@SALE_DATE", OleDbType.Date).Value = DateStart;
                        cmd.Parameters.Add("@SALE_DATE_END", OleDbType.Date).Value = DateEnd;
                        TotalCredito = Convert.ToDouble(cmd.ExecuteScalar());
                        cmd.Parameters.Clear();//limpiamos params
                        cmd.CommandText = "INSERT INTO MONEY_COUNTING_DETAIL(ID_MONEY_COUNTING,CONCEPT,CONCEPT_OPERATION,CONCEPT_VALUE) VALUES(@ID_MONEY_COUNTING,@CONCEPT,@CONCEPT_OPERATION,@CONCEPT_VALUE)";
                        cmd.Parameters.Add("@ID_MONEY_COUNTING", OleDbType.Integer).Value = IdMoneyCounting;
                        cmd.Parameters.Add("@CONCEPT", OleDbType.VarChar, 255).Value = "VENTAS A CREDITO";
                        cmd.Parameters.Add("@CONCEPT_OPERATION", OleDbType.VarChar, 1).Value = "V";
                        cmd.Parameters.Add("@CONCEPT_VALUE", OleDbType.Double).Value = TotalCredito;
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    tran.Commit();
                    PrintMoneyCounting(IdMoneyCounting);
                }
                catch (Exception ex) { tran.Rollback(); throw (ex); }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally { cnn.Close(); }
        }

        public void PrintMoneyCounting(int idMoneyCounting)
        {
            Ticket ticket = new Ticket();
            if ((AppSettings.GetValue("Ticket", "TicketImage", "") != "") && (File.Exists(AppSettings.GetValue("Ticket", "TicketImage", ""))))
            {
                ticket.HeaderImage = System.Drawing.Image.FromFile(AppSettings.GetValue("Ticket", "TicketImage", "")); //esta propiedad no es obligatoria 
            }
            ticket.FontName = AppSettings.GetValue("Ticket", "FontName", "Courier New");
            ticket.FontSize = Convert.ToDouble(AppSettings.GetValue("Ticket", "FontSize", "7"));
            ticket.MaxChar = Convert.ToInt32(AppSettings.GetValue("Ticket", "MaxChar", "40"));
            ticket.MaxCharDescription = Convert.ToInt32(AppSettings.GetValue("Ticket", "MaxCharDescription", "20"));
            ticket.DrawItemHeaders = false;
            OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
            //int RowCount = 0;//Contador de Registros
            //double SaleStartAmount = 0;//Monto inicial de Caja
            //int IdMoneyCounting = 0;//Id del corte de Caja
            //double TotalSales = 0;//total de las ventas
            //double TotalGastos = 0;//total de las ventas
            //int IdPOS = 0;
            //string prmUserLogin = "";
            // DateTime DateStart = DateTime.Now;
            // DateTime DateEnd = DateTime.Now;
            double Cash = 0;
            double TotalInPos = 0;

            try
            {
                cnn.Open();
                OleDbTransaction tran = cnn.BeginTransaction();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;
                cmd.Transaction = tran;
                OleDbDataReader dr;
                try
                {
                    //mostramos los DATOS
                    ticket.AddHeaderLine("CORTE DE CAJA");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine(AppSettings.GetValue("Ticket", "HLine1", ""));
                    ticket.AddHeaderLine(AppSettings.GetValue("Ticket", "HLine2", ""));
                    ticket.AddHeaderLine(AppSettings.GetValue("Ticket", "HLine3", ""));
                    ticket.AddHeaderLine(AppSettings.GetValue("Ticket", "HLine4", ""));
                    ticket.AddHeaderLine(AppSettings.GetValue("Ticket", "HLine5", ""));
                    //Datos Generales
                    cmd.CommandText = "SELECT MONEY_COUNTING.ID_MONEY_COUNTING, MONEY_COUNTING.DATE_REG, MONEY_COUNTING.SALE_DATE, MONEY_COUNTING.USER_LOGIN, CAT_CAJA.ID_CAJA, CAT_CAJA.DESC_CAJA, Trim(USERS.NOMBRE)+' '+Trim(USERS.PATERNO)+' '+Trim(USERS.MATERNO) AS USER_FULL_NAME, MONEY_COUNTING.SALE_DATE_END, MONEY_COUNTING.CASH, MONEY_COUNTING.START_AMOUNT " +
                    " FROM USERS INNER JOIN (CAT_CAJA INNER JOIN MONEY_COUNTING ON CAT_CAJA.ID_CAJA = MONEY_COUNTING.ID_POS) ON USERS.USER_LOGIN = MONEY_COUNTING.USER_LOGIN WHERE ID_MONEY_COUNTING=@ID_MONEY_COUNTING";
                    cmd.Parameters.Add("@ID_MONEY_COUNTING", OleDbType.Integer).Value = idMoneyCounting;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        ticket.AddSubHeaderLine("Fechas: " + dr["SALE_DATE"].ToString() + " - " + dr["SALE_DATE_END"].ToString());
                        ticket.AddSubHeaderLine(String.Format("Caja: {0} - {1}", dr["ID_CAJA"].ToString(), dr["DESC_CAJA"].ToString()));
                        ticket.AddSubHeaderLine("Empleado: " + dr["USER_FULL_NAME"].ToString());
                        Cash = Convert.ToDouble(dr["CASH"]);
                    }
                    dr.Close();
                    cmd.Parameters.Clear();//limpiamos params
                    cmd.CommandText = "SELECT * FROM MONEY_COUNTING_DETAIL WHERE ID_MONEY_COUNTING=@ID_MONEY_COUNTING AND CONCEPT_OPERATION IN ('+','-')  ";
                    cmd.Parameters.Add("@ID_MONEY_COUNTING", OleDbType.Integer).Value = idMoneyCounting;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ticket.AddItem(dr["CONCEPT_OPERATION"].ToString(), dr["CONCEPT"].ToString(), String.Format("{0:C}", dr["CONCEPT_VALUE"]));
                        TotalInPos += Convert.ToDouble(dr["CONCEPT_VALUE"]);
                    }
                    dr.Close();
                    //DETALLE
                    bool headDetail = false;
                    cmd.Parameters.Clear();//limpiamos params
                    cmd.CommandText = "SELECT * FROM MONEY_COUNTING_DETAIL WHERE ID_MONEY_COUNTING=@ID_MONEY_COUNTING AND CONCEPT_OPERATION NOT IN ('+','-','V') ORDER BY ID_MONEY_COUNTING_DETAIL ";
                    cmd.Parameters.Add("@ID_MONEY_COUNTING", OleDbType.Integer).Value = idMoneyCounting;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (!headDetail) { ticket.AddItem("---", "DETALLE DE VENTAS", "---"); headDetail = true; }
                        ticket.AddItem(dr["CONCEPT_OPERATION"].ToString(), dr["CONCEPT"].ToString(), String.Format("{0:C}", dr["CONCEPT_VALUE"]));
                    }
                    dr.Close();
                    //TIPO DE VENTA
                    headDetail = false;
                    cmd.Parameters.Clear();//limpiamos params
                    cmd.CommandText = "SELECT * FROM MONEY_COUNTING_DETAIL WHERE ID_MONEY_COUNTING=@ID_MONEY_COUNTING AND CONCEPT_OPERATION IN ('V') ORDER BY ID_MONEY_COUNTING_DETAIL ";
                    cmd.Parameters.Add("@ID_MONEY_COUNTING", OleDbType.Integer).Value = idMoneyCounting;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (!headDetail) { ticket.AddItem("---", "TIPO DE VENTA", "---"); headDetail = true; }
                        ticket.AddItem(dr["CONCEPT_OPERATION"].ToString(), dr["CONCEPT"].ToString(), String.Format("{0:C}", dr["CONCEPT_VALUE"]));
                    }
                    dr.Close();
                    //total
                    ticket.AddTotal("TOTAL: ", String.Format("{0:C}", TotalInPos));
                    ticket.AddTotal("EN CAJA: ", String.Format("{0:C}", Cash));
                    ticket.AddTotal("DIFERENCIA: ", String.Format("{0:C}", Cash - TotalInPos));
                    //confirmamos la transacción
                    tran.Commit();
                }
                catch (Exception ex) { tran.Rollback(); throw (ex); }


                ticket.PrintTicketPreview(AppSettings.GetValue("Ticket", "TicketPrinterName", ""));

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally { cnn.Close(); }
        }

        public static int FnCheckTempVentas(string prmUserLogin, int prmIdCaja)
        {
            //Para cargar la venta tenporal
            int Retorno;
            try
            {
                OleDbConnection cnnGetSale = new OleDbConnection(Class.clsMain.CnnStr);
                string varSQL = "SELECT COUNT(*) FROM TEMP_VENTA  WHERE USER_LOGIN = @user_login  AND ID_CAJA = @id_caja ";
                OleDbCommand cmdGetSale = new OleDbCommand(varSQL, cnnGetSale);
                cmdGetSale.Parameters.Add("@user_login", OleDbType.VarChar, 50).Value = prmUserLogin;
                cmdGetSale.Parameters.Add("@id_Caja", OleDbType.Integer).Value = prmIdCaja;
                cnnGetSale.Open();
                Retorno = Convert.ToInt32(cmdGetSale.ExecuteScalar());
                cmdGetSale.Dispose();
                cnnGetSale.Close();
                cnnGetSale.Dispose();
                return (Retorno);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "fnCheckTempVentas");
                return (0);
            }
        }

        public static double GetSale(string prmUserLogin, int prmIdCaja, string prmIdProducto)
        {
            //Para cargar la venta tenporal
            double Retorno;
            try
            {
                OleDbConnection cnnGetSale = new OleDbConnection(Class.clsMain.CnnStr);
                string varSQL = "SELECT COUNT(*) FROM TEMP_VENTA  WHERE USER_LOGIN = @user_login  AND ID_CAJA = @id_caja AND ID_PRODUCTO = @id_producto";
                OleDbCommand cmdGetSale = new OleDbCommand(varSQL, cnnGetSale);
                cmdGetSale.Parameters.Add("@user_login", OleDbType.VarChar, 50).Value = prmUserLogin;
                cmdGetSale.Parameters.Add("@id_Caja", OleDbType.Integer).Value = prmIdCaja;
                cmdGetSale.Parameters.Add("@id_producto", OleDbType.VarChar, 50).Value = prmIdProducto;
                cnnGetSale.Open();
                Retorno = Convert.ToDouble(cmdGetSale.ExecuteScalar());
                cmdGetSale.Dispose();
                cnnGetSale.Close();
                cnnGetSale.Dispose();
                return (Retorno);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GetSale");
                return (0);
            }
        }

        public bool DeshacerVenta(string prmUserLogin, int prmIdCaja)
        {

            OleDbConnection conDeshacerVenta = new OleDbConnection(Class.clsMain.CnnStr);
            OleDbCommand cmdDeshacerVenta;
            string strSQL_Delete = "DELETE FROM TEMP_VENTA  WHERE USER_LOGIN = @user_login AND ID_CAJA=@id_caja";
            try
            {

                conDeshacerVenta.Open();
                cmdDeshacerVenta = new OleDbCommand(strSQL_Delete, conDeshacerVenta);
                cmdDeshacerVenta.Parameters.Add("@user_login", OleDbType.VarChar, 50).Value = prmUserLogin;
                cmdDeshacerVenta.Parameters.Add("@id_caja", OleDbType.Integer).Value = prmIdCaja;
                cmdDeshacerVenta.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally { conDeshacerVenta.Close(); }

        }

        public void DeshacerVentaa(int prmIdMesa)
        {

            OleDbConnection conDeshacerVenta;
            OleDbCommand cmdDeshacerVenta;
            string strSQL_Delete = "DELETE FROM TEMP_VENTA_MESA " +
                " WHERE ID_MESA=@id_mesa";
            try
            {
                conDeshacerVenta = new OleDbConnection(Class.clsMain.CnnStr);
                conDeshacerVenta.Open();
                cmdDeshacerVenta = new OleDbCommand(strSQL_Delete, conDeshacerVenta);
                cmdDeshacerVenta.Parameters.Add("@id_mesa", OleDbType.Integer).Value = prmIdMesa;
                cmdDeshacerVenta.ExecuteNonQuery();
                cmdDeshacerVenta.Dispose();
                conDeshacerVenta.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Undo Sale");
            }

        }

        public bool FnBuscaTicket(int prmFolioVenta)
        {

            try
            {
                OleDbConnection cnnBuscaTicket = new OleDbConnection(clsMain.CnnStr);
                cnnBuscaTicket.Open();
                string varSQL = "SELECT COUNT(FOLIO) FROM VENTA WHERE FOLIO = @folio_venta";
                OleDbCommand cmdBuscaTicket = new OleDbCommand(varSQL, cnnBuscaTicket);
                cmdBuscaTicket.Parameters.Add("@folio_venta", OleDbType.Integer).Value = prmFolioVenta;
                int var = Convert.ToInt32(cmdBuscaTicket.ExecuteScalar());
                cmdBuscaTicket.Dispose();
                cnnBuscaTicket.Close();
                cnnBuscaTicket.Dispose();
                if (var == 0)
                {
                    //No existe
                    return (false);

                }
                else
                {
                    //si existe
                    return (true);
                }

            }
            catch
            {

                return (false);
            }
        }

        public string FnBuscaClienteTicket(int prmFolioVenta)
        {

            try
            {
                OleDbConnection cnnBuscaTicket = new OleDbConnection(clsMain.CnnStr);
                cnnBuscaTicket.Open();
                string varSQL = "SELECT CAT_CLIENTE.NOMBRE FROM VENTA,CAT_CLIENTE   WHERE VENTA.ID_CLIENTE = CAT_CLIENTE.ID_CLIENTE AND VENTA.FOLIO = @folio_venta";
                OleDbCommand cmdBuscaTicket = new OleDbCommand(varSQL, cnnBuscaTicket);
                cmdBuscaTicket.Parameters.Add("@folio_venta", OleDbType.Integer).Value = prmFolioVenta;
                string var = Convert.ToString(cmdBuscaTicket.ExecuteScalar());
                cmdBuscaTicket.Dispose();
                cnnBuscaTicket.Close();
                cnnBuscaTicket.Dispose();
                return (var);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "fnBuscaClienteTicket");
                return ("");
            }
        }

        public double FnBuscaMontoTicket(int prmFolioVenta)
        {

            try
            {
                OleDbConnection cnnBuscaTicket = new OleDbConnection(clsMain.CnnStr);
                cnnBuscaTicket.Open();
                string varSQL = "SELECT sum(cantidad*precio_venta)   FROM VENTA_DETALLE WHERE FOLIO = @folio_venta group by folio";
                OleDbCommand cmdBuscaTicket = new OleDbCommand(varSQL, cnnBuscaTicket);
                cmdBuscaTicket.Parameters.Add("@folio_venta", OleDbType.Integer).Value = prmFolioVenta;
                double var = Convert.ToDouble(cmdBuscaTicket.ExecuteScalar());
                cmdBuscaTicket.Dispose();
                cnnBuscaTicket.Close();
                cnnBuscaTicket.Dispose();
                return (var);

            }
            catch
            {

                return (0);
            }
        }



        public static void ViewCountStatus(int prmID_CLIENTE)
        {
            try
            {
                DataSet dsReporte = new DataSet(); //Datset para el reporte
                OleDbConnection cnnReporte = new OleDbConnection(Class.clsMain.CnnStr);
                if (cnnReporte.State == ConnectionState.Open)
                    cnnReporte.Close();
                cnnReporte.Open();
                dsReporte.Clear();//limpiamos el dataset
                OleDbDataAdapter daReporte =
                    new OleDbDataAdapter("SELECT * FROM [vCAT_CLIENTE] WHERE ID_CLIENTE= " + prmID_CLIENTE + "", cnnReporte);
                daReporte.Fill(dsReporte, "vCAT_CLIENTE");//llenamos el DataSet con la info de la FACTURA
                OleDbDataAdapter daSubReporte =
                    new OleDbDataAdapter("SELECT * FROM  [vDETALLE_ESTADO_CUENTA] WHERE ID_CLIENTE = " + prmID_CLIENTE + "", cnnReporte);
                daSubReporte.Fill(dsReporte, "vDETALLE_ESTADO_CUENTA");//llenamos el DataSet con la info del Tiket
                //destruimos los objetos utilizados
                if (cnnReporte.State == ConnectionState.Open)
                    cnnReporte.Close();
                daReporte.Dispose();
                daSubReporte.Dispose();
                cnnReporte.Dispose();
                //ya tenemos la info en el DataSet, ahora cargamos el reporte
                //Reports.rptEstadoCuenta mi_rptTicket = new Reports.rptEstadoCuenta();


                //mi_rptTicket.SummaryInfo.ReportTitle = 
                //    AppSettings.GetValue("Ticket","HLine1","") + "\n" +
                //    AppSettings.GetValue("Ticket","HLine2","") + "\n" +
                //    AppSettings.GetValue("Ticket","HLine3","");

                //mi_rptTicket.SummaryInfo.ReportComments = "";



                //mi_rptTicket.SetDataSource(dsReporte);
                //mi_rptTicket.OpenSubreport("rptDetalleEstadoCuenta").SetDataSource(dsReporte.Tables["vDETALLE_ESTADO_CUENTA"]);

                //Forms.frmReports mi_frmReportes = new Forms.frmReports();
                //mi_frmReportes.crvReportes.DisplayGroupTree = false;
                //mi_frmReportes.crvReportes.ReportSource = mi_rptTicket;
                //mi_frmReportes.StartPosition = FormStartPosition.CenterScreen;
                //mi_frmReportes.ShowDialog();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.Source + "\n" +
                    ex.StackTrace, "Loading Ticket Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public static void ImprimeCorteDeCaja(string prmFECHA_INI, string prmFECHA_FIN, string prmUSER_LOGIN, DateTime prmFECHA1, DateTime prmFECHA2, double prmCAJA_CHICA, double prmTOTAL_INGRESO)
        {
            try
            {

                double varTOTAL_VENTAS = 0;
                //double varTOTAL_COBRADO = 0;
                //double varTOTAL_PROPINA = 0;
                //double varDESCUENTOS = 0;
                //double varIVA = 0;



                string varNOMBRE_CAJERO = "";
                double varTOTAL_GASTOS = 0;
                Ticket ticket = new Ticket();
                if ((AppSettings.GetValue("Ticket", "TicketImage", "") != "") && (File.Exists(AppSettings.GetValue("Ticket", "TicketImage", ""))))
                {
                    ticket.HeaderImage = System.Drawing.Image.FromFile(AppSettings.GetValue("Ticket", "TicketImage", "")); //esta propiedad no es obligatoria 
                }
                ticket.FontName = AppSettings.GetValue("Ticket", "FontName", "Courier New");
                ticket.FontSize = Convert.ToDouble(AppSettings.GetValue("Ticket", "FontSize", "7"));
                ticket.MaxChar = Convert.ToInt32(AppSettings.GetValue("Ticket", "MaxChar", "40"));
                ticket.MaxCharDescription = Convert.ToInt32(AppSettings.GetValue("Ticket", "MaxCharDescription", "20"));
                ticket.DrawItemHeaders = false;
                //string varHeaderImage = "D:\\Pictures\tyrodeveloper\\tyrodeveloper2011a.png";
                //if (File.Exists(varHeaderImage))
                //{
                //    ticket.HeaderImage = System.Drawing.Image.FromFile(varHeaderImage); //esta propiedad no es obligatoria 
                //}
                ticket.AddHeaderLine("C O R T E   D E   C A J A ");
                ticket.AddHeaderLine("- - - - - - - - - - - - - - - - - - ");
                ticket.AddHeaderLine(AppSettings.GetValue("Ticket", "HLine1", ""));
                ticket.AddHeaderLine(AppSettings.GetValue("Ticket", "HLine2", ""));
                ticket.AddHeaderLine(AppSettings.GetValue("Ticket", "HLine3", ""));
                ticket.AddHeaderLine(AppSettings.GetValue("Ticket", "HLine4", ""));
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("Fecha de impresión: " + DateTime.Now);
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("Corte de Caja entre: ");
                ticket.AddHeaderLine(prmFECHA1.ToShortDateString() +
                  " " + prmFECHA1.ToShortTimeString() + " y");
                ticket.AddHeaderLine(prmFECHA2.ToShortDateString() +
                " " + prmFECHA2.ToShortTimeString());

                OleDbConnection cnnReporte = new OleDbConnection(Class.clsMain.CnnStr);
                cnnReporte.Open();
                OleDbCommand cmdReporte = new OleDbCommand();
                OleDbDataReader dr;

                cmdReporte.Connection = cnnReporte;
                //OBTENEMOS LA INFORMACIÓN DEL CAJERO:
                cmdReporte.CommandText = "SELECT TRIM(NOMBRE) + ' ' + TRIM(PATERNO) + ' ' + TRIM(MATERNO) AS NOMBRE" +
                    " FROM USERS WHERE USER_LOGIN ='" + prmUSER_LOGIN + "'";
                varNOMBRE_CAJERO = Convert.ToString(cmdReporte.ExecuteScalar());
                //OBTENEMOS TODA LA INFORMACIÓN DE "CONTADO"
                ticket.AddItem("CAJA CHICA", "", String.Format("{0:C}", prmCAJA_CHICA));

                //TOTAL DE VENTAS
                cmdReporte.CommandText = "SELECT SUM((PRECIO_VENTA * CANTIDAD))AS VENTAS " +
                    " FROM VENTA INNER JOIN VENTA_DETALLE ON VENTA.FOLIO = VENTA_DETALLE.FOLIO " +
                    " WHERE VENTA.FECHA BETWEEN #" + prmFECHA_INI + "# AND #" + prmFECHA_FIN + "#" +
                    " AND VENTA.USER_LOGIN ='" + prmUSER_LOGIN + "'";
                dr = cmdReporte.ExecuteReader();
                if (dr.Read())
                {
                    if (dr["VENTAS"] != DBNull.Value) { ticket.AddItem("TOTAL VENTAS:", "", String.Format("{0:C}", dr["VENTAS"])); varTOTAL_VENTAS = Convert.ToDouble(dr["VENTAS"]); }
                    else { ticket.AddItem("TOTAL VENTAS:", "", String.Format("{0:C}", 0)); }
                }
                dr.Close();
                //OBTENEMOS TODA LA INFORMACIÓN DE GASTOS
                cmdReporte.CommandText = "SELECT SUM(IMPORTE) AS GASTO FROM GASTO " +
                           " WHERE FECHA_GASTO BETWEEN #" + prmFECHA_INI + "# AND #" + prmFECHA_FIN + "#" +
                           " AND USER_LOGIN ='" + prmUSER_LOGIN + "' AND ACTIVO <> 0";
                dr = cmdReporte.ExecuteReader();
                if (dr.Read())
                {
                    if (dr["GASTO"] != DBNull.Value) { ticket.AddItem("TOTAL GASTO:", "", String.Format("{0:C}", dr["GASTO"])); varTOTAL_GASTOS = Convert.ToDouble(dr["GASTO"]); }
                    else { ticket.AddItem("TOTAL GASTOS:", "", String.Format("{0:C}", 0)); }
                }
                dr.Close();

                //MOSTRAMOS EL TOTAL
                ticket.AddItem("SALDO:", "", String.Format("{0:C}", (prmCAJA_CHICA + varTOTAL_VENTAS) - varTOTAL_GASTOS));

                //MOSTRAMOS EL DETALLE
                ticket.AddItem("===", "DETALLE VENTAS", "===");




                //obtenemos las ventas
                cmdReporte.CommandText = "SELECT SUM((PRECIO_VENTA * CANTIDAD))AS VENTAS,TIPO_PAGO " +
                    " FROM VENTA INNER JOIN VENTA_DETALLE ON VENTA.FOLIO = VENTA_DETALLE.FOLIO " +
                    " WHERE VENTA.FECHA BETWEEN #" + prmFECHA_INI + "# AND #" + prmFECHA_FIN + "#" +
                    " AND VENTA.USER_LOGIN ='" + prmUSER_LOGIN + "' GROUP BY TIPO_PAGO";
                dr = cmdReporte.ExecuteReader();
                while (dr.Read())
                {

                    ticket.AddItem(dr["TIPO_PAGO"].ToString(), "", String.Format("{0:C}", dr["VENTAS"]));
                    if (dr["VENTAS"] != DBNull.Value)
                    {
                        varTOTAL_VENTAS += Convert.ToDouble(dr["VENTAS"]);
                    }
                }
                dr.Close();
                //COBRADAS
                //cmdReporte.CommandText = "SELECT SUM(COBRADO)AS COBRADO " +
                //    " FROM VENTA " +
                //    " WHERE VENTA.FECHA_REGISTRO BETWEEN #" + prmFECHA_INI + "# AND #" + prmFECHA_FIN + "#" +
                //    " AND VENTA.USER_LOGIN ='" + prmUSER_LOGIN + "' GROUP BY TIPO_PAGO";
                //dr = cmdReporte.ExecuteReader();
                //if (dr.Read())
                //{
                //    if (dr["COBRADO"] != DBNull.Value)
                //    {
                //        ticket.AddItem("COBRADO", "", String.Format("{0:C}", dr["COBRADO"]));
                //        varTOTAL_COBRADO += Convert.ToDouble(dr["COBRADO"]);
                //    }
                //    else {
                //        ticket.AddItem("COBRADO", "", String.Format("{0:C}", 0));
                //    }
                //}
                //dr.Close();

                ////GASTOS
                //cmdReporte.CommandText = "SELECT SUM(IMPORTE) AS GASTO FROM GASTO " +
                //           " WHERE FECHA_GASTO BETWEEN #" + prmFECHA_INI + "# AND #" + prmFECHA_FIN + "#" +
                //           " AND USER_LOGIN ='" + prmUSER_LOGIN + "' AND ACTIVO <> 0";
                //dr = cmdReporte.ExecuteReader();
                //while (dr.Read() && (dr.FieldCount == 1))
                //{
                //    if (dr["GASTO"] != DBNull.Value)
                //    {
                //        varTOTAL_GASTOS = Convert.ToDouble(dr["GASTO"]);
                //    }
                //}
                //dr.Close();

                ////TOTAL DE VENTAS
                //ticket.AddItem("TOT.VENTAS", "", String.Format("{0:C}", varTOTAL_VENTAS));
                ////TOTAL DE GASTOS
                //ticket.AddItem("TOT.GASTOS", "", String.Format("{0:C}", varTOTAL_GASTOS));
                //ticket.AddItem("DIFERENCIA", "", String.Format("{0:C}", varTOTAL_VENTAS-varTOTAL_COBRADO));

                ////obtenemos lapropina
                //cmdReporte.CommandText = "SELECT SUM(PROPINA)AS PROPINA" +
                //    " FROM VENTA  " +
                //    " WHERE VENTA.FECHA BETWEEN #" + prmFECHA_INI + "# AND #" + prmFECHA_FIN + "#" +
                //    " ";
                //dr = cmdReporte.ExecuteReader();                
                //if (dr.Read())
                //{
                //    if (dr["PROPINA"] != DBNull.Value)
                //    {
                //        varTOTAL_PROPINA += Convert.ToDouble(dr["PROPINA"]);
                //    }
                //}
                //dr.Close();
                //ticket.AddItem("PROPINA", "", String.Format("{0:C}", varTOTAL_PROPINA));
                //obtenemos el iva

                //cmdReporte.CommandText = " SELECT SUM( (((PRECIO_VENTA*CANTIDAD) -DESCUENTO)/(1+IMPUESTO)) * IMPUESTO) AS IVA" +
                //        " FROM VENTA_DETALLE,VENTA " +
                //        " WHERE VENTA.FECHA_REGISTRO BETWEEN #" + prmFECHA_INI + "# AND #" + prmFECHA_FIN + "#" +
                //        " AND VENTA.FOLIO = VENTA_DETALLE.FOLIO " +
                //        " AND VENTA.USER_LOGIN ='" + prmUSER_LOGIN + "'" +
                //          "";
                //dr = cmdReporte.ExecuteReader();
                //if (dr.Read()) {
                //    if (dr["IVA"] != DBNull.Value)
                //    {
                //        varIVA = Convert.ToDouble(dr["IVA"]);
                //    }
                //}
                //dr.Close();

                //obtenemos los descuentos
                //cmdReporte.CommandText = " SELECT sum(DESCUENTO) AS DESCUENTO" +
                //      " FROM VENTA_DETALLE,VENTA " +
                //      " WHERE VENTA.FECHA_REGISTRO BETWEEN #" + prmFECHA_INI + "# AND #" + prmFECHA_FIN + "#" +
                //      " AND VENTA.FOLIO = VENTA_DETALLE.FOLIO " +
                //      " AND VENTA.USER_LOGIN ='" + prmUSER_LOGIN + "'" +
                //        "";
                //dr = cmdReporte.ExecuteReader();
                //if (dr.Read()) {
                //    if (dr["DESCUENTO"] != DBNull.Value)
                //    {
                //        varDESCUENTOS = Convert.ToDouble(dr["DESCUENTO"]);
                //    }
                //}
                //dr.Close();

                //ticket.AddItem("DESCUENTOS", "", String.Format("{0:C}", varDESCUENTOS));

                //ticket.AddItem("EN CAJA:", "", String.Format("{0:C}", prmCAJA_CHICA + 
                //    (varTOTAL_VENTAS-varTOTAL_COBRADO)));

                //ticket.AddItem("--", "TOTALES", "--");
                //ticket.AddItem("", "VENTAS", String.Format("{0:C}", varTOTAL_VENTAS));
                //ticket.AddItem("", "PROPINAS", String.Format("{0:C}", varTOTAL_PROPINA));
                //ticket.AddItem("", "IVA", String.Format("{0:C}", varIVA));
                //ticket.AddItem("", "DESCUENTOS", String.Format("{0:C}", varDESCUENTOS));
                //ticket.AddItem("", "", "");


                //ticket.AddTotal("VENTAS:", String.Format("{0:C}", varTOTAL_VENTAS ));
                //ticket.AddTotal("PROPINAS:", String.Format("{0:C}", varTOTAL_PROPINA));
                //ticket.AddTotal("IVA:", String.Format("{0:C}", varIVA));
                //ticket.AddTotal("DESCUENTOS:", String.Format("{0:C}", varDESCUENTOS));
                //ticket.AddTotal("GASTOS", String.Format("{0:C}", varTOTAL_GASTOS));

                //ticket.AddTotal("EN CAJA:", String.Format("{0:C}",
                //    ((varTOTAL_COBRADO) - varTOTAL_GASTOS) + varTOTAL_PROPINA));

                //ticket.AddTotal("EN CAJA:","(COB+PROP)-GTOS");

                ticket.PrintTicketPreview(AppSettings.GetValue("Ticket", "TicketPrinterName", ""));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nEs probable que la consulta no produce resultados",
                    "ImprimeCorteDeCaja",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ImprimeTicket(int prmFolioTicket, bool prmToPrinter)
        {
            OleDbConnection cnnReporte = new OleDbConnection(Class.clsMain.CnnStr);
            try
            {

                double varTotal = 0;
                double varDescuento = 0;
                double varIva = 0;
                double prmEfectivo = 0;
                double varMontoTipoPago = 0;
                string varTipoPago = "";
                string varMoneda = "";
                double varTipoCambio = 1;
                string varNoAutorizacion = "";
                string varDigitosPago = "************";
                Ticket ticket = new Ticket();
                if ((AppSettings.GetValue("Ticket", "TicketImage", "") != "") && (File.Exists(AppSettings.GetValue("Ticket", "TicketImage", ""))))
                {
                    ticket.HeaderImage = System.Drawing.Image.FromFile(AppSettings.GetValue("Ticket", "TicketImage", "")); //esta propiedad no es obligatoria 
                }
                ticket.FontName = AppSettings.GetValue("Ticket", "FontName", "Courier New");
                ticket.FontSize = Convert.ToDouble(AppSettings.GetValue("Ticket", "FontSize", "7"));
                ticket.MaxChar = Convert.ToInt32(AppSettings.GetValue("Ticket", "MaxChar", "40"));
                ticket.MaxCharDescription = Convert.ToInt32(AppSettings.GetValue("Ticket", "MaxCharDescription", "20"));
                //ticket.HeaderImage = "C:\\imagen.jpg"; //esta propiedad no es obligatoria 
                ticket.AddHeaderLine(AppSettings.GetValue("Ticket", "HLine1", ""));
                ticket.AddHeaderLine(AppSettings.GetValue("Ticket", "HLine2", ""));
                ticket.AddHeaderLine(AppSettings.GetValue("Ticket", "HLine3", ""));
                ticket.AddHeaderLine(AppSettings.GetValue("Ticket", "HLine4", ""));
                ticket.AddHeaderLine(AppSettings.GetValue("Ticket", "HLine5", ""));




                cnnReporte.Open();

                OleDbCommand cmdReporte = new OleDbCommand();
                cmdReporte.Connection = cnnReporte;
                cmdReporte.CommandText = "SELECT NO_AUTORIZACION,EFECTIVO_MONEDA, DIGITOS_PAGO, VENTA.ID_MONEDA, VENTA.TIPO_CAMBIO, VENTA.TIPO_PAGO,VENTA.PAGO_MONEDA, VENTA.FOLIO, VENTA.FECHA, VENTA.ID_CAJA AS CAJA, Trim(USERS.NOMBRE)+' '+Trim(USERS.PATERNO)+' '+Trim(USERS.MATERNO) AS CAJERO, CAT_CLIENTE.NOMBRE AS CLIENTE, VENTA.COBRADO, VENTA.COBRADO_MONEDA " +
                " FROM (USERS INNER JOIN (CAT_CLIENTE INNER JOIN VENTA ON CAT_CLIENTE.ID_CLIENTE = VENTA.ID_CLIENTE) ON USERS.USER_LOGIN = VENTA.USER_LOGIN) INNER JOIN VENTA_DETALLE ON VENTA.FOLIO = VENTA_DETALLE.FOLIO " +
                " WHERE VENTA.FOLIO=@FOLIO";
                cmdReporte.Parameters.Add("@FOLIO", OleDbType.Integer).Value = prmFolioTicket;
                OleDbDataReader drReporte;
                drReporte = cmdReporte.ExecuteReader();
                if (drReporte.Read())
                {
                    varMoneda = drReporte["ID_MONEDA"].ToString();
                    varTipoCambio = Convert.ToDouble(drReporte["TIPO_CAMBIO"]);
                    //El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia 
                    //de que al final de cada linea agrega una linea punteada "==========" 
                    ticket.AddSubHeaderLine("Caja # " + drReporte["CAJA"].ToString() + " - Ticket # " + prmFolioTicket.ToString() + "");
                    ticket.AddSubHeaderLine("Le atendió: " + drReporte["CAJERO"].ToString() + "");
                    ticket.AddSubHeaderLine(String.Format("Fecha: {0:dd/MM/yyyy HH:mm}", drReporte["FECHA"]));
                    ticket.AddSubHeaderLine("Cliente: " + drReporte["CLIENTE"].ToString() + "");
                    if (drReporte["COBRADO"] != DBNull.Value)
                    {
                        prmEfectivo = Convert.ToDouble(drReporte["EFECTIVO_MONEDA"]);
                    }
                    if (!string.IsNullOrEmpty(drReporte["TIPO_PAGO"].ToString()))
                    {
                        varTipoPago = drReporte["TIPO_PAGO"].ToString();
                        varMontoTipoPago = Convert.ToDouble(drReporte["PAGO_MONEDA"]);
                        varDigitosPago = varDigitosPago + drReporte["DIGITOS_PAGO"].ToString();
                        varNoAutorizacion = drReporte["NO_AUTORIZACION"].ToString();
                    }
                }

                //Details
                drReporte.Close();
                cmdReporte.CommandText = "SELECT * FROM [v_VENTA_DETALLE_TICKET] WHERE FOLIO= " + prmFolioTicket + "";
                drReporte = cmdReporte.ExecuteReader();
                while (drReporte != null && drReporte.Read())
                {
                    //El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion 
                    //del producto y el tercero es el precio 


                    ticket.AddItem(drReporte["CANTIDAD"].ToString(),
                       drReporte["DESC_PRODUCTO"].ToString(), String.Format("{0:C}",
                       Convert.ToDouble(drReporte["CANTIDAD"]) * Convert.ToDouble(drReporte["PRECIO_VENTA_MONEDA"])));


                    varTotal += Convert.ToDouble(drReporte["TOTAL_MONEDA"]);
                    varDescuento += Convert.ToDouble(drReporte["DESCUENTO_MONEDA"]);
                    varIva +=
                        Convert.ToDouble(drReporte["TOTIMPUESTO_MONEDA"]);
                }
                drReporte.Close();
                cmdReporte.Dispose();
                cnnReporte.Close();
                cnnReporte.Dispose();

                //El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio 
                ticket.AddTotal("SUBTOTAL", String.Format("{0:C}", varTotal + varDescuento));
                ticket.AddTotal("DESCUENTO", String.Format("{0:C}", varDescuento));
                ticket.AddTotal("SUBTOTAL NETO", String.Format("{0:C}", varTotal ));
                ticket.AddTotal("IVA", String.Format("{0:C}", varIva));


                ticket.AddTotal("TOTAL", String.Format("{0:C}", varTotal + varIva));
                ticket.AddTotal("", ""); //Ponemos un total en blanco que sirve de espacio 
// ReSharper disable CompareOfFloatsByEqualityOperator
                if (prmEfectivo!=0)
// ReSharper restore CompareOfFloatsByEqualityOperator
                { 
                    ticket.AddTotal("RECIBIDO EFEC.", String.Format("{0:C}", prmEfectivo)); 
                }
                
// ReSharper disable CompareOfFloatsByEqualityOperator
                if (varMontoTipoPago != 0)
// ReSharper restore CompareOfFloatsByEqualityOperator
                {
                    ticket.AddTotal("RECIBIDO " + varTipoPago + ":", String.Format("{0:C}", varMontoTipoPago));
                    ticket.AddTotal("No. Autorización " ,   varNoAutorizacion);
                    ticket.AddTotal("Cuenta Pago "  , varDigitosPago );
                }
                ticket.AddTotal("CAMBIO", String.Format("{0:C}", (varMontoTipoPago+prmEfectivo )- (varTotal + varIva)));
                ticket.AddTotal("MONEDA", varMoneda);//Ponemos un total en blanco que sirve de espacio 
                ticket.AddTotal("TC", String.Format("{0:C}",varTipoCambio));//Ponemos un total en blanco que sirve de espacio 
                //ticket.AddTotal("USTED AHORRO", "0.00");

                //El metodo AddFooterLine funciona igual que la cabecera 
                ticket.AddFooterLine(AppSettings.GetValue("Ticket", "FLine1", ""));
                ticket.AddFooterLine(AppSettings.GetValue("Ticket", "FLine2", ""));
                ticket.AddFooterLine(AppSettings.GetValue("Ticket", "FLine3", ""));
                ticket.AddFooterLine(AppSettings.GetValue("Ticket", "FLine4", ""));
                ticket.AddFooterLine(AppSettings.GetValue("Ticket", "FLine5", ""));
                //Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
                //parametro de tipo string que debe de ser el nombre de la impresora. 
                if (prmToPrinter)
                {
                    ticket.PrintTicket(AppSettings.GetValue("Ticket", "TicketPrinterName", ""));
                }
                else
                {
                    ticket.PrintTicketPreview(AppSettings.GetValue("Ticket", "TicketPrinterName", ""));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.Source, "ImprimeTicket");
            }
            finally { cnnReporte.Close(); }
        }

        public static void ImprimeFacturaVenta(string prmFolioFactura)
        {
            try
            {
                try
                {
                    Reporting report = new Reporting( );
                    report.CnnStr = Class.clsMain.CnnStr;
                    report.ReportWindowTitle = "Factura";
                    report.ReportTitle = "Factura";
                    report.ReportComments = String.Format("");
                    report.SQL = string.Format("SELECT * FROM vRPT_FACTURA_VENTA WHERE FOLIO_FACTURA='{0}'", prmFolioFactura);
                    report.ReportFileName = String.Format("{0}\\rptFactura.rdlc", AppSettings.GetValue("Config", "ReportsFolder"));
                    report.ReportDataSetName = "dsRpt";
                    //sub reporte
                    report.SubReportDataSetName = "dsRpt";
                    report.SubReportFileName = String.Format("{0}\\rptFacturaDetalle.rdlc", AppSettings.GetValue("Config", "ReportsFolder"));
                    report.SubReportSQL = string.Format("SELECT * FROM vRPT_FACTURA_VENTA_DETALLE WHERE FOLIO_FACTURA='{0}'", prmFolioFactura);

                    report.PrintPreview();
                }
                catch (Exception ex) { throw ex; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Error loading report", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
