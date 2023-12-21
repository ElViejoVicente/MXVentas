using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace POSApp.Class
{
    public class clsPedido
    {
        public bool AddItemTmp(string prmIdProduct, double prmQuantity, double prmPrice, double prmTax, string prmUserLogin)
        {
            OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
            try
            {
                cnn.Open();
                OleDbTransaction tran = cnn.BeginTransaction();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;
                cmd.Transaction = tran;

                //producto


                int RowCount = 0;

                try
                {
                    cmd.CommandText = "SELECT COUNT(*) FROM CAT_PRODUCTO WHERE ID_PRODUCTO=@ID_PRODUCT";
                    //parameters
                    cmd.Parameters.Add("@ID_PRODUCT", OleDbType.VarChar, 50).Value = prmIdProduct;
                    RowCount = Convert.ToInt32(cmd.ExecuteScalar());

                    cmd.Parameters.Clear();
                    if (RowCount == 0)
                    {
                        throw (new Exception("El producto no existe"));
                    }

                    //validamos si existe
                    cmd.CommandText = "SELECT COUNT(*) FROM PEDIDO_DETALLE_TMP WHERE USER_LOGIN=@USER_LOGIN AND ID_PRODUCTO=@ID_PRODUCTO";
                    cmd.Parameters.Add("@USER_LOGIN", OleDbType.VarChar, 50).Value = prmUserLogin;
                    cmd.Parameters.Add("@ID_PRODUCTO", OleDbType.VarChar, 50).Value = prmIdProduct;
                    RowCount = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.Parameters.Clear();//QUITAMOS PARAMETROS
                    if (RowCount != 0)
                    {
                        //ACTUALIZAMOS
                        cmd.CommandText = "UPDATE PEDIDO_DETALLE_TMP SET [CANTIDAD]=[CANTIDAD]+@QUANTITY WHERE  USER_LOGIN=@USER_LOGIN AND ID_PRODUCTO=@ID_PRODUCTO";
                        cmd.Parameters.Add("@QUANTITY", OleDbType.Double).Value = prmQuantity;
                        cmd.Parameters.Add("@USER_LOGIN", OleDbType.VarChar, 50).Value = prmUserLogin;
                        cmd.Parameters.Add("@ID_PRODUCT", OleDbType.VarChar, 50).Value = prmIdProduct;
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        //INSERTAMOS
                        cmd.CommandText = "INSERT INTO PEDIDO_DETALLE_TMP(ID_PRODUCTO, CANTIDAD,PRECIO_COMPRA,IMPUESTO,USER_LOGIN) VALUES(@ID_PRODUCTO, @CANTIDAD,@PRECIO_VENTA,@IMPUESTO,@USER_LOGIN)";


                        cmd.Parameters.Add("@ID_PRODUCT", OleDbType.VarChar, 50).Value = prmIdProduct;
                        cmd.Parameters.Add("@CANTIDAD", OleDbType.Double).Value = prmQuantity;
                        cmd.Parameters.Add("@PRECIO_VENTA", OleDbType.Double).Value = prmPrice;
                        cmd.Parameters.Add("@TAX", OleDbType.Double).Value = prmTax;
                        cmd.Parameters.Add("@USER_LOGIN", OleDbType.VarChar, 50).Value = prmUserLogin;


                        cmd.ExecuteNonQuery();
                    }

                    cmd.Parameters.Clear();


                    tran.Commit();//confirmamos transaccion
                    return (true);
                }
                catch (Exception ex1)
                {

                    tran.Rollback();//cancelamos transaccion

                    throw (ex1);
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                cnn.Close();
            }
        }
        public void ListItems(ListView lv, string prmUserLogin)
        {
            OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
            try
            {
                cnn.Open();
                //encabezados
                lv.Columns.Clear();
                lv.Items.Clear();
                lv.View = View.Details;
                lv.FullRowSelect = true;
                lv.HideSelection = false;
                lv.GridLines = true;
                lv.Columns.Add("", 0);
                lv.Columns.Add("Id Producto", 100);
                lv.Columns.Add("Descripción", 300);
                lv.Columns.Add("Cantidad", 100, HorizontalAlignment.Right);
                lv.Columns.Add("Precio", 100, HorizontalAlignment.Right);
                lv.Columns.Add("Total", 100, HorizontalAlignment.Right);
                //termina encabezados
                int i = 0;
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT T.ID_PEDIDO_DETALLE_TMP,P.ID_PRODUCTO,P.DESC_PRODUCTO,T.CANTIDAD,T.PRECIO_COMPRA,(T.CANTIDAD*T.PRECIO_COMPRA) AS TOTAL " +
                    " FROM CAT_PRODUCTO P , PEDIDO_DETALLE_TMP T " +
                    " WHERE P.ID_PRODUCTO=T.ID_PRODUCTO " +
                    " AND T.USER_LOGIN=@user_login";
                cmd.Parameters.Add("@user_login", OleDbType.VarChar, 50).Value = prmUserLogin;
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lv.Items.Add(dr["ID_PEDIDO_DETALLE_TMP"].ToString());
                    lv.Items[i].SubItems.Add(dr["ID_PRODUCTO"].ToString());
                    lv.Items[i].SubItems.Add(dr["DESC_PRODUCTO"].ToString());
                    lv.Items[i].SubItems.Add(String.Format("{0:N}", dr["CANTIDAD"]));
                    lv.Items[i].SubItems.Add(String.Format("{0:C}", dr["PRECIO_COMPRA"]));
                    lv.Items[i].SubItems.Add(String.Format("{0:C}", dr["TOTAL"]));
                    i += 1;
                }
                dr.Close();
            }
            catch (Exception ex) { throw (ex); }
            finally { cnn.Close(); }
        }
        public int Save(string prmIdProveedor, string prmUserLogin, string prmComments)
        {
            OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
            try
            {
                int varFolio = 0;
                int RowCount = 0;
                cnn.Open();
                OleDbTransaction tran = cnn.BeginTransaction();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Transaction = tran;
                cmd.Connection = cnn;
                try
                {
                    cmd.CommandText = "SELECT COUNT(*) FROM CAT_PROVEEDOR WHERE ID_PROVEEDOR=@ID_PROVEEDOR";
                    cmd.Parameters.Add("@ID_PROVEEDOR", OleDbType.VarChar, 50).Value = prmIdProveedor;
                    RowCount = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.Parameters.Clear();
                    if (RowCount == 0)
                    {
                        throw (new Exception("El proveedor no existe"));
                    }
                    //validamos si hay registros
                    cmd.CommandText = "SELECT COUNT(*) FROM PEDIDO_DETALLE_TMP WHERE USER_LOGIN=@USER_LOGIN";
                    cmd.Parameters.Add("@USER_LOGIN", OleDbType.VarChar, 50).Value = prmUserLogin;
                    RowCount = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.Parameters.Clear();
                    if (RowCount == 0)
                    {
                        throw (new Exception("No hay registros"));
                    }
                    cmd.CommandText = "INSERT INTO PEDIDO(FECHA_REGISTRO, FECHA_PEDIDO, USER_LOGIN, OBSERVACIONES, ID_PROVEEDOR) " +
                        " VALUES (now(), now(), @user_login, @comments, @id_provider)";
                    //parametros
                    cmd.Parameters.Add("@user_login", OleDbType.VarChar, 50).Value = prmUserLogin;
                    cmd.Parameters.Add("@comments", OleDbType.VarChar, 255).Value = prmComments;
                    cmd.Parameters.Add("@id_provider", OleDbType.VarChar, 50).Value = prmIdProveedor;

                    //EJECUTAMOS Y OBTENEMOS EL ID GENERADO
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();//limpiamos parametros
                    cmd.CommandText = "SELECT @@IDENTITY";
                    varFolio = Convert.ToInt32(cmd.ExecuteScalar());
                    //INSERTAMOS EL DETALLE DE LA VENTA
                    cmd.CommandText = "INSERT INTO PEDIDO_DETALLE(ID_PEDIDO,ID_PRODUCTO,CANTIDAD,PRECIO_COMPRA,IMPUESTO)" +
                        "SELECT @ID_PEDIDO,ID_PRODUCTO,CANTIDAD,PRECIO_COMPRA,IMPUESTO FROM PEDIDO_DETALLE_TMP WHERE  USER_LOGIN =@user_login";
                    cmd.Parameters.Add("@ID_PEDIDO", OleDbType.Integer).Value = varFolio;
                    cmd.Parameters.Add("@user_login", OleDbType.VarChar, 50).Value = prmUserLogin;
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();//limpiamos parametros

                    //liminamos la tabla temporal
                    cmd.CommandText = "DELETE FROM PEDIDO_DETALLE_TMP WHERE  USER_LOGIN=pUSER_LOGIN";
                    cmd.Parameters.Add("pUSER_LOGIN", OleDbType.VarChar, 50).Value = prmUserLogin;
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();//limpiamos parametros

                    tran.Commit();
                }
                catch (OleDbException ex1)
                {
                    tran.Rollback();
                    throw (ex1);

                }
                return (varFolio);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                cnn.Close();
            }
        }
    }
}
