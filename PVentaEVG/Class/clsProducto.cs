using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using POSDLL; using POSDLL.Windows.Forms; using POSDLL.Security; using POSDLL.Reporting; using POSDLL.Ticket;
namespace POSApp.Class
{
    public class clsProducto
    {
        public clsProducto() { }
        public clsProducto(string idProducto) { try { id_producto = idProducto; Buscar(false); } catch (Exception ex) { throw (ex); } }
        string id_producto = "";
        public string ID_PRODUCTO { get { return id_producto; } set { id_producto = value; } }

        string desc_producto = "";
        public string DESC_PRODUCTO { get { return desc_producto; } set { desc_producto = value; } }

        double precio_venta = 0;
        public double PRECIO_VENTA { get { return precio_venta; } set { precio_venta = value; } }

        double precio_venta2 = 0;
        public double PRECIO_VENTA2 { get { return precio_venta2; } set { precio_venta2 = value; } }

        double precio_venta3 = 0;
        public double PRECIO_VENTA3 { get { return precio_venta3; } set { precio_venta3 = value; } }

        int id_grupo = 0;
        public int ID_GRUPO { get { return id_grupo; } set { id_grupo = value; } }
        string grupo = "";
        public string GRUPO { get { return grupo; } }

        double impuesto = 0;
        public double IMPUESTO { get { return impuesto; } set { impuesto = value; } }

        byte[] imagen = null;
        public byte[] IMAGEN { get { return imagen; } set { imagen = value; } }

        double cant_min = 0;
        public double CANT_MIN { get { return cant_min; } set { cant_min = value; } }

        double cant_max = 0;
        public double CANT_MAX { get { return cant_max; } set { cant_max = value; } }

        string localizacion = "";
        public string LOCALIZACION { get { return localizacion; } set { localizacion = value; } }

        int id_unidad_medida = 0;
        public int ID_UNIDAD_MEDIDA { get { return id_unidad_medida; } set { id_unidad_medida = value; } }
        string unidad_medida = "";
        public string UNIDAD_MEDIDA { get { return unidad_medida; } }

        string user_login = "";
        public string USER_LOGIN { get { return user_login; } set { user_login = value; } }

        int id_marca = 0;
        public int ID_MARCA { get { return id_marca; } set { id_marca = value; } }
        string marca = "";
        public string MARCA { get { return marca; } }

        double existencia = 0;
        public double EXISTENCIA { get { return existencia; } set { existencia = value; } }

        double precio_compra = 0;
        public double PRECIO_COMPRA { get { return precio_compra; } set { precio_compra = value; } }

        string sust_activa = "";
        public string SUST_ACTIVA { get { return sust_activa; } set { sust_activa = value; } }

        string indicacion = "";
        public string INDICACION { get { return indicacion; } set { indicacion = value; } }

        string nombres_co = "";
        public string NOMBRES_CO { get { return nombres_co; } set { nombres_co = value; } }

        bool c_barras = true;
        public bool C_BARRAS { get { return c_barras; } set { c_barras = value; } }

        string formulacion = "";
        public string FORMULACION { get { return formulacion; } set { formulacion = value; } }

        int id_presentacion = 0;
        public int ID_PRESENTACION { get { return id_presentacion; } set { id_presentacion = value; } }

        double descuento = 0;
        public double DESCUENTO { get { return descuento; } set { descuento = value; } }

        string ruta_imagen = "";
        public string RUTA_IMAGEN { get { return ruta_imagen; } set { ruta_imagen = value; } }

        string caracteristicas = "";
        public string CARACTERISTICAS { get { return caracteristicas; } set { caracteristicas = value; } }

        bool vender_sin_existencia = true;
        public bool VENDER_SIN_EXISTENCIA { get { return vender_sin_existencia; } set { vender_sin_existencia = value; } }

        string tipo_transmision = "";
        public string TIPO_TRANSMISION { get { return tipo_transmision; } set { tipo_transmision = value; } }

        string cve_proveedor = "";
        public string CVE_PROVEEDOR { get { return cve_proveedor; } set { cve_proveedor = value; } }

        string paso = "";
        public string PASO { get { return paso; } set { paso = value; } }

        bool ingredientes = true;
        public bool INGREDIENTES { get { return ingredientes; } set { ingredientes = value; } }

        bool habilitar_venta = true;
        public bool HABILITAR_VENTA { get { return habilitar_venta; } set { habilitar_venta = value; } }

        bool succes = false;
        public bool Success { get { return succes; } }


        void Buscar(bool mostrarErrores){
            OleDbConnection cnnFindProductDetails = new OleDbConnection(Class.clsMain.CnnStr);
            try
            {
                cnnFindProductDetails.Open();
                OleDbCommand cmdFindProductDetails = new OleDbCommand();
                cmdFindProductDetails.Connection = cnnFindProductDetails;
                cmdFindProductDetails.CommandText = "SELECT P.*, G.DESC_GRUPO, u.DESC_UNIDAD_MEDIDA, M.DESC_MARCA" +
                      " FROM  CAT_PRODUCTO P,CAT_MARCA M, CAT_GRUPO G, CAT_UNIDAD_MEDIDA U " +
                      " WHERE P.ID_MARCA = M.ID_MARCA " +
                      " AND P.ID_PRODUCTO = @id" +
                      " AND P.ID_GRUPO=G.ID_GRUPO AND U.ID_UNIDAD_MEDIDA = P.ID_UNIDAD_MEDIDA";
                cmdFindProductDetails.Parameters.Add("@id", OleDbType.VarChar, 50).Value = id_producto;
                OleDbDataReader dr = cmdFindProductDetails.ExecuteReader();
                if (dr.Read())
                {
                    //aqui
                    id_producto = dr["ID_PRODUCTO"].ToString();
                    desc_producto = dr["DESC_PRODUCTO"].ToString();
                    precio_venta = Convert.ToDouble(dr["PRECIO_VENTA"]);
                    precio_venta2 = Convert.ToDouble(dr["PRECIO_VENTA2"]);
                    precio_venta3 = Convert.ToDouble(dr["PRECIO_VENTA3"]);
                    id_grupo = Convert.ToInt32(dr["ID_GRUPO"]);
                    grupo = dr["DESC_GRUPO"].ToString();
                    impuesto = Convert.ToDouble(dr["IMPUESTO"]);
                    if (dr["IMAGEN"] != DBNull.Value) { imagen = (byte[])dr["IMAGEN"]; } else { imagen = null; }
                    cant_min = Convert.ToDouble(dr["CANT_MIN"]);
                    cant_max = Convert.ToDouble(dr["CANT_MAX"]);
                    localizacion = dr["LOCALIZACION"].ToString();
                    id_unidad_medida = Convert.ToInt32(dr["ID_UNIDAD_MEDIDA"]);
                    unidad_medida = dr["DESC_UNIDAD_MEDIDA"].ToString();
                    user_login = dr["USER_LOGIN"].ToString();
                    id_marca = Convert.ToInt32(dr["ID_MARCA"]);
                    marca = dr["DESC_MARCA"].ToString();
                    existencia = Convert.ToDouble(dr["EXISTENCIA"]);
                    precio_compra = Convert.ToDouble(dr["PRECIO_COMPRA"]);
                    sust_activa = dr["SUST_ACTIVA"].ToString();
                    indicacion = dr["INDICACION"].ToString();
                    nombres_co = dr["NOMBRES_CO"].ToString();
                    c_barras = Convert.ToBoolean(dr["C_BARRAS"]);
                    formulacion = dr["FORMULACION"].ToString();
                    id_presentacion = Convert.ToInt32(dr["ID_PRESENTACION"]);
                    descuento = Convert.ToDouble(dr["DESCUENTO"]);
                    ruta_imagen = dr["RUTA_IMAGEN"].ToString();
                    caracteristicas = dr["CARACTERISTICAS"].ToString();
                    vender_sin_existencia = Convert.ToBoolean(dr["VENDER_SIN_EXISTENCIA"]);
                    tipo_transmision = dr["TIPO_TRANSMISION"].ToString();
                    cve_proveedor = dr["CVE_PROVEEDOR"].ToString();
                    paso = dr["PASO"].ToString();
                    ingredientes = Convert.ToBoolean(dr["INGREDIENTES"]);
                    habilitar_venta = Convert.ToBoolean(dr["HABILITAR_VENTA"]);
                }
                else { if (mostrarErrores) { throw (new Exception("El producto no existe")); } }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally { cnnFindProductDetails.Close(); }
        }

        public bool Nuevo() {
            OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
            try {
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "INSERT INTO CAT_PRODUCTO (ID_PRODUCTO,DESC_PRODUCTO,ID_MARCA, " +
                   "EXISTENCIA,PRECIO_VENTA,IMPUESTO,USER_LOGIN,ID_GRUPO, PRECIO_COMPRA," +
                   "NOMBRES_CO,C_BARRAS,ID_PRESENTACION,CANT_MAX,CANT_MIN,DESCUENTO," +
                   "VENDER_SIN_EXISTENCIA,LOCALIZACION,PRECIO_VENTA2,CVE_PROVEEDOR,PRECIO_VENTA3,INGREDIENTES,ID_UNIDAD_MEDIDA,HABILITAR_VENTA)" +
                   " VALUES ('" + id_producto + "','" + desc_producto + "'," + id_marca + "," +
                   "" + existencia + "," + precio_venta + "," + impuesto + ",'" + user_login + "'," + id_grupo + "," + precio_compra + "," +
                   "'" + nombres_co + "'," + c_barras + "," + id_presentacion + "," + cant_max + "," + cant_min + "," + descuento + "," +
                   "" + vender_sin_existencia + ",'" + localizacion + "'," + precio_venta2 + ",'" + cve_proveedor + "'," + precio_venta3 + ","+
                   "" + ingredientes + "," + id_unidad_medida + "," + habilitar_venta + ")";

                cmd.ExecuteNonQuery();
                succes = true;
                return true;
            }
            catch (Exception ex) { throw (ex); }
            finally { cnn.Close(); }
        }

        public bool Editar()
        {
            OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
            try
            {
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "UPDATE CAT_PRODUCTO SET " +
                    " DESC_PRODUCTO='" + desc_producto + "'," +
                    " ID_MARCA=" + id_marca + "," +
                    " PRECIO_VENTA=" + precio_venta + ",IMPUESTO = " + impuesto + "," +
                    " USER_LOGIN='" + user_login + "', ID_GRUPO=" + id_grupo + ", " +
                    " PRECIO_COMPRA = " + precio_compra + "," +
                    " NOMBRES_CO='" + nombres_co + "', C_BARRAS=" + c_barras + "," +
                    " ID_PRESENTACION='" + id_presentacion + "'," +
                    " CANT_MAX= " + cant_max + ", CANT_MIN = " + cant_min + "," +
                    " DESCUENTO=" + descuento + ",VENDER_SIN_EXISTENCIA=" + vender_sin_existencia + "," +
                    " LOCALIZACION='" + localizacion + "',PRECIO_VENTA3=" + precio_venta3 + "," +
                    " PRECIO_VENTA2=" + precio_venta2 + ",CVE_PROVEEDOR='" + cve_proveedor + "'," +
                    " INGREDIENTES=" + ingredientes + ",ID_UNIDAD_MEDIDA=" + id_unidad_medida + "," +
                    " HABILITAR_VENTA=" + habilitar_venta + "" +
                    " WHERE ID_PRODUCTO = '" + id_producto + "'";
                cmd.ExecuteNonQuery();
                succes = true;
                return true;
            }
            catch (Exception ex) { throw (ex); }
            finally { cnn.Close(); }
        }
        public void Buscar(string idProducto){
            try {
                id_producto = idProducto;
                Buscar(true);
            }
            catch (Exception ex) { throw(ex);}
        }
        
        public static double[] FindProductDetails(string prmID_PRODUCTO)
        {
            double[] Retorno = { 0, 0 };//precio_venta, impuesto
            OleDbConnection cnnFindProductDetails = new OleDbConnection(Class.clsMain.CnnStr);
            try
            {
                cnnFindProductDetails.Open();
                OleDbCommand cmdFindProductDetails = new OleDbCommand();
                cmdFindProductDetails.Connection = cnnFindProductDetails;
                cmdFindProductDetails.CommandText = "SELECT PRECIO_VENTA,IMPUESTO FROM CAT_PRODUCTO WHERE ID_PRODUCTO = @id";
                cmdFindProductDetails.Parameters.Add("@id", OleDbType.VarChar, 50).Value = prmID_PRODUCTO;
                OleDbDataReader dr = cmdFindProductDetails.ExecuteReader();
                if(dr.Read()){
                    Retorno[0] = Convert.ToDouble(dr["PRECIO_VENTA"]);
                    Retorno[1] = Convert.ToDouble(dr["IMPUESTO"]);
                }
                dr.Close();

             
              
                return (Retorno);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally { cnnFindProductDetails.Close(); }
        }
        public static string FindProductDetailsString(string prmID_PRODUCTO)
        {
            OleDbConnection cnnFindProductDetails = new OleDbConnection(Class.clsMain.CnnStr);
            string _retorno = "";
            try
            {
                cnnFindProductDetails.Open();
                OleDbCommand cmdFindProductDetails = new OleDbCommand();
                cmdFindProductDetails.Connection = cnnFindProductDetails;
                cmdFindProductDetails.CommandText = "SELECT P.*,M.DESC_UNIDAD_MEDIDA FROM CAT_PRODUCTO P, CAT_UNIDAD_MEDIDA M  WHERE P.ID_UNIDAD_MEDIDA=M.ID_UNIDAD_MEDIDA AND ID_PRODUCTO = @id";
                cmdFindProductDetails.Parameters.Add("@id", OleDbType.VarChar, 50).Value = prmID_PRODUCTO;


                _retorno = "CLAVE: {ID_PRODUCTO}\nDESCRIPCIÓN: {DESC_PRODUCTO}\nEXISTENCIA: {EXISTENCIA}\nPRECIO DE VENTA: {PRECIO_VENTA}\nIMPUESTO: {IMPUESTO}";
                OleDbDataReader dr = cmdFindProductDetails.ExecuteReader();
                if (dr.Read())
                {
                    _retorno = _retorno.Replace("{ID_PRODUCTO}", prmID_PRODUCTO);
                    _retorno = _retorno.Replace("{DESC_PRODUCTO}", dr["DESC_PRODUCTO"].ToString());
                    _retorno = _retorno.Replace("{EXISTENCIA}", String.Format("{0:N}", dr["EXISTENCIA"]) + " (" + dr["DESC_UNIDAD_MEDIDA"].ToString() + ")");
                    _retorno = _retorno.Replace("{PRECIO_VENTA}", String.Format("{0:C}", dr["PRECIO_VENTA"]));
                    _retorno = _retorno.Replace("{IMPUESTO}", String.Format("{0:C}", dr["IMPUESTO"]));
                }
                else
                {
                    _retorno = "ARTICULO NO ENCONTRADO";
                }
                dr.Close();
               
                return (_retorno);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally { cnnFindProductDetails.Close(); }
        }
        public static bool FindProduct(string prmID_PRODUCTO)
        {
            OleDbConnection cnnFindProductDetails = new OleDbConnection(Class.clsMain.CnnStr);
            bool Retorno =false;
            try
            {
                cnnFindProductDetails.Open();
                OleDbCommand cmdFindProductDetails = new OleDbCommand();
                cmdFindProductDetails.Connection = cnnFindProductDetails;
                cmdFindProductDetails.CommandText ="SELECT ID_PRODUCTO FROM CAT_PRODUCTO WHERE ID_PRODUCTO = @id";
                cmdFindProductDetails.Parameters.Add("@id", OleDbType.VarChar, 50).Value = prmID_PRODUCTO;
               
                OleDbDataReader drFind = cmdFindProductDetails.ExecuteReader();
                while (drFind.Read())
                {
                    Retorno = true;
                }
                drFind.Close();
                cmdFindProductDetails.Dispose();
               
                return (Retorno);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally { cnnFindProductDetails.Close(); }
        } 
    }
}
