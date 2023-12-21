using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using POSDLL;
namespace POSApp.Class
{
    public class AppConfiguration
    {
        public AppConfiguration(string idConfiguration)
        {
            try
            {
                if (id_configuration.Trim() == "")
                {
                    //new_item = true; 
                }
                else { id_configuration = idConfiguration; Load(); }
            }
            catch (Exception ex) { throw ex; }
        }

        //bool new_item = false;

        string id_configuration = "";
        public string IdConfiguration { get { return id_configuration; } set { id_configuration = value; } }

        string description = "";
        public string Description { get { return description; } set { description = value; } }

        object configuration_value = null;
        public object ConfigurationValue { get { return configuration_value; } set { configuration_value = value; } }

        string configuration_group = "";
        public string ConfigurationGroup { get { return configuration_group; } set { configuration_group = value; } }

        object default_value = null;
        public object DefaultValue { get { return default_value; } set { default_value = value; } }

        protected void Load()
        {
            OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
            try
            {
                object retorno = 0;
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "select * from CONFIGURACION where ID_CONFIGURACION=@id_configuration";
                cmd.Parameters.Add("@id_configuration", OleDbType.VarChar, 50).Value = id_configuration;
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    id_configuration = dr["ID_CONFIGURACION"].ToString();
                    description = dr["DESC_CONFIGURACION"].ToString();
                    configuration_value = dr["VALOR"];
                    configuration_group = dr["GRUPO"].ToString();
                    default_value = dr["VALOR_PREDETERMINADO"];
                }
                dr.Close();

            }
            catch (Exception ex) { throw ex; }
            finally { cnn.Close(); }
        }
        /// <summary>
        /// Obtiene o Establece el Id del cliente predeterminado. 
        /// Este valor se almacena en la base de datos.
        /// </summary>
        public static int DEFAULT_CUSTOMER
        {
            get { return Convert.ToInt32(GetConfigurationValue("DEFAULT_CUSTOMER", 0)); }
            set { SetConfigurationValue("DEFAULT_CUSTOMER", "Id del cliente predeterminado", "DEFAULT_SETTINGS", value, 1); }
        }
        /// <summary>
        /// Obtiene o establece la cantidad de horas que puede permanecer abierta una caja. 
        /// Este valor se almacena en la base de datos.
        /// </summary>
        public static int POS_HOURS
        {
            get { return Convert.ToInt32(GetConfigurationValue("POS_HOURS", 0)); }
            set { SetConfigurationValue("POS_HOURS", "Cantidad de horas que la caja puede permanecer abierta", "POS_CONFIG", value, 25); }
        }
        /// <summary>
        /// Obtiene o establece el encabezado del Ticket 1. 
        /// Este valor se almacena en la base de datos.
        /// </summary>
        public static string TicketHLine1
        {
            get { return Convert.ToString(GetConfigurationValue("TicketHLine1", "TyroDeveloper")); }
            set { SetConfigurationValue("TicketHLine1", "Encabezado del Ticket 1", "SALES_TICKET", value, "TyroDeveloper"); }
        }
        /// <summary>
        /// Obtiene o establece el encabezado del Ticket 2. 
        /// Este valor se almacena en la base de datos.
        /// </summary>
        public static string TicketHLine2
        {
            get { return Convert.ToString(GetConfigurationValue("TicketHLine2", "www.tyrodeveloper.com")); }
            set { SetConfigurationValue("TicketHLine2", "Encabezado del Ticket 2", "SALES_TICKET", value, "www.tyrodeveloper.com"); }
        }
        /// <summary>
        /// Obtiene o establece el encabezado del Ticket 3. 
        /// Este valor se almacena en la base de datos.
        /// </summary>
        public static string TicketHLine3
        {
            get { return Convert.ToString(GetConfigurationValue("TicketHLine3", "tyrodeveloper@gmail.com")); }
            set { SetConfigurationValue("TicketHLine3", "Encabezado del Ticket 3", "SALES_TICKET", value, "tyrodeveloper@gmail.com"); }
        }
        /// <summary>
        /// Obtiene o establece el encabezado del Ticket 4. 
        /// Este valor se almacena en la base de datos.
        /// </summary>
        public static string TicketHLine4
        {
            get { return Convert.ToString(GetConfigurationValue("TicketHLine4", "Juan Gabriel Castillo T")); }
            set { SetConfigurationValue("TicketHLine4", "Encabezado del Ticket 4", "SALES_TICKET", value, "Juan Gabriel Castillo T"); }
        }
        /// <summary>
        /// Obtiene o establece el encabezado del Ticket 5. 
        /// Este valor se almacena en la base de datos.
        /// </summary>
        public static string TicketHLine5
        {
            get { return Convert.ToString(GetConfigurationValue("TicketHLine5", "Tamaulipas, México")); }
            set { SetConfigurationValue("TicketHLine5", "Encabezado del Ticket 5", "SALES_TICKET", value, "Tamaulipas, México"); }
        }
        /// <summary>
        /// Obtiene o establece el pié del Ticket 1. 
        /// Este valor se almacena en la base de datos.
        /// </summary>
        public static string TicketFLine1
        {
            get { return Convert.ToString(GetConfigurationValue("TicketFLine1", "Gracias por su compra")); }
            set { SetConfigurationValue("TicketFLine1", "Pié del Ticket 1", "SALES_TICKET", value, "Gracias por su compra"); }
        }
        /// <summary>
        /// Obtiene o establece el pié del Ticket 2. 
        /// Este valor se almacena en la base de datos.
        /// </summary>
        public static string TicketFLine2
        {
            get { return Convert.ToString(GetConfigurationValue("TicketFLine2", "Cuide su economía")); }
            set { SetConfigurationValue("TicketFLine2", "Pié del Ticket 2", "SALES_TICKET", value, "Cuide su economía"); }
        }
        /// <summary>
        /// Obtiene o establece el pié del Ticket 3. 
        /// Este valor se almacena en la base de datos.
        /// </summary>
        public static string TicketFLine3
        {
            get { return Convert.ToString(GetConfigurationValue("TicketFLine3", "")); }
            set { SetConfigurationValue("TicketFLine3", "Pié del Ticket 3", "SALES_TICKET", value, ""); }
        }
        /// <summary>
        /// Obtiene o establece el pié del Ticket 4. 
        /// Este valor se almacena en la base de datos.
        /// </summary>
        public static string TicketFLine4
        {
            get { return Convert.ToString(GetConfigurationValue("TicketFLine4", "")); }
            set { SetConfigurationValue("TicketFLine4", "Pié del Ticket 4", "SALES_TICKET", value, ""); }
        }
        /// <summary>
        /// Obtiene o establece el pié del Ticket 5. 
        /// Este valor se almacena en la base de datos.
        /// </summary>
        public static string TicketFLine5
        {
            get { return Convert.ToString(GetConfigurationValue("TicketFLine5", "")); }
            set { SetConfigurationValue("TicketFLine5", "Pié del Ticket 5", "SALES_TICKET", value, ""); }
        }
        /// <summary>
        /// Obtiene o establece la ruta del archivo de base de datos. 
        /// Este valor se almacena en el equipo local.
        /// </summary>
        public static string DataSource
        {
            get { return AppSettings.GetValue("Config", "DataSource", ""); }
            set { AppSettings.SetValue("Config", "DataSource", value); }
        }
        /// <summary>
        /// Obtiene o establece el lenguaje del sistema. 
        /// Este valor se almacena en el equipo local.
        /// </summary>
        public static string Language
        {
            get { return AppSettings.GetValue("GeneralConfig", "Language", "es-MX"); }
            set { AppSettings.SetValue("GeneralConfig", "Language", value); }
        }
        /// <summary>
        /// Obtiene o establece la ruta de la carpeta que contiene los reportes. 
        /// Este valor se almacena en el equipo local.
        /// </summary>
        public static string ReportsFolder
        {
            get { return AppSettings.GetValue("Config", "ReportsFolder", ""); }
            set { AppSettings.SetValue("Config", "ReportsFolder", value); }
        }
        /// <summary>
        /// Obtiene o establece la ruta de la imagen de fondo para la pantalla principal de sistema. 
        /// Este valor se almacena en el equipo local.
        /// </summary>
        public static string MainBackImage
        {
            get { return AppSettings.GetValue("GeneralConfig", "MainBackImage", ""); }
            set { AppSettings.SetValue("GeneralConfig", "MainBackImage", value); }
        }
        /// <summary>
        /// Obtiene o establece el nombre de la impresora de Ticket. Este valor se almacena en el equipo local.
        /// </summary>
        public static string TicketPrinterName
        {
            get { return AppSettings.GetValue("Ticket", "TicketPrinterName", ""); }
            set { AppSettings.SetValue("Ticket", "TicketPrinterName", value); }
        }
        /// <summary>
        /// Obtiene o establece la impresión de Ticket (Si/No). 
        /// Este valor se almacena en el equipo local.
        /// </summary>
        public static bool PrintTicket
        {
            get { return Convert.ToBoolean(AppSettings.GetValue("Ticket", "PrintTicket", "True")); }
            set { AppSettings.SetValue("Ticket", "PrintTicket", value.ToString()); }
        }
        /// <summary>
        /// Obtiene o establece el tipo de letra para el Ticket. 
        /// Este valor se almacena en la base de datos.
        /// </summary>
        public static string TicketFontName
        {
            get { return Convert.ToString(GetConfigurationValue("TicketFontName", "Courier New")); }
            set { SetConfigurationValue("TicketFontName", "Fuente para el Ticket", "SALES_TICKET", value, "Courier New"); }
        }
        /// <summary>
        /// Obtiene o establece el tamaño de letra para el Ticket. 
        /// Este valor se almacena en la base de datos.
        /// </summary>
        public static double TicketFontSize
        {
            get { return Convert.ToDouble(GetConfigurationValue("TicketFontSize", "8")); }
            set { SetConfigurationValue("TicketFontSize", "Fuente para el Ticket", "SALES_TICKET", value, "8"); }
        }
        /// <summary>
        /// Obtiene o establece la cantidad máxima de caracteres para el Ticket. 
        /// Este valor se almacena en la base de datos.
        /// </summary>
        public static int TicketMaxChar
        {
            get { return Convert.ToInt32(GetConfigurationValue("TicketMaxChar", "40")); }
            set { SetConfigurationValue("TicketMaxChar", "Fuente para el Ticket", "SALES_TICKET", value, "40"); }
        }
        /// <summary>
        /// Obtiene o establece la cantidad máxima de caracteres para la descripción del producto en el Ticket de venta. 
        /// Este valor se almacena en la base de datos.
        /// </summary>
        public static int TicketMaxCharDescription
        {
            get { return Convert.ToInt32(GetConfigurationValue("TicketMaxCharDescription", "20")); }
            set { SetConfigurationValue("TicketMaxCharDescription", "Fuente para el Ticket", "SALES_TICKET", value, "20"); }
        }
        /// <summary>
        /// Obtiene o establece la ruta de la imagen para el Ticket de Venta.
        /// Este valor se almacena en el equipo local.
        /// </summary>
        public static string TicketImage
        {
            get { return AppSettings.GetValue("Ticket", "TicketImage", ""); }
            set { AppSettings.SetValue("Ticket", "TicketImage", value); }
        }

        #region FacturacionElectronica_UMBRALL
        public static string Umbrall_CDF_LugarExpedicion
        {
            get { return Convert.ToString(GetConfigurationValue("Umbrall_CDF_LugarExpedicion", "")); }
            set { SetConfigurationValue("Umbrall_CDF_LugarExpedicion", "", "Umbrall", value, ""); }
        }
        public static string Umbrall_CDF_RFCEmisor
        {
            get { return Convert.ToString(GetConfigurationValue("Umbrall_CDF_RFCEmisor", "")); }
            set { SetConfigurationValue("Umbrall_CDF_RFCEmisor", "", "Umbrall", value, ""); }
        }
        public static string Umbrall_CDF_NombreEmisor
        {
            get { return Convert.ToString(GetConfigurationValue("Umbrall_CDF_NombreEmisor", "")); }
            set { SetConfigurationValue("Umbrall_CDF_NombreEmisor", "", "Umbrall", value, ""); }
        }
        public static string Umbrall_CDF_CalleEmisor
        {
            get { return Convert.ToString(GetConfigurationValue("Umbrall_CDF_CalleEmisor", "")); }
            set { SetConfigurationValue("Umbrall_CDF_CalleEmisor", "", "Umbrall", value, ""); }
        }
        public static string Umbrall_CDF_CPEmisor
        {
            get { return Convert.ToString(GetConfigurationValue("Umbrall_CDF_CPEmisor", "")); }
            set { SetConfigurationValue("Umbrall_CDF_CPEmisor", "", "Umbrall", value, ""); }
        }
        public static string Umbrall_CDF_ColoniaEmisor
        {
            get { return Convert.ToString(GetConfigurationValue("Umbrall_CDF_ColoniaEmisor", "")); }
            set { SetConfigurationValue("Umbrall_CDF_ColoniaEmisor", "", "Umbrall", value, ""); }
        }
        public static string Umbrall_CDF_EstadoEmisor
        {
            get { return Convert.ToString(GetConfigurationValue("Umbrall_CDF_EstadoEmisor", "")); }
            set { SetConfigurationValue("Umbrall_CDF_EstadoEmisor", "", "Umbrall", value, ""); }
        }
        public static string Umbrall_CDF_LocalidadEmisor
        {
            get { return Convert.ToString(GetConfigurationValue("Umbrall_CDF_LocalidadEmisor", "")); }
            set { SetConfigurationValue("Umbrall_CDF_LocalidadEmisor", "", "Umbrall", value, ""); }
        }
        public static string Umbrall_CDF_MunicipioEmisor
        {
            get { return Convert.ToString(GetConfigurationValue("Umbrall_CDF_MunicipioEmisor", "")); }
            set { SetConfigurationValue("Umbrall_CDF_MunicipioEmisor", "", "Umbrall", value, ""); }
        }
        public static string Umbrall_CDF_NoExteriorEmisor
        {
            get { return Convert.ToString(GetConfigurationValue("Umbrall_CDF_NoExteriorEmisor", "")); }
            set { SetConfigurationValue("Umbrall_CDF_NoExteriorEmisor", "", "Umbrall", value, ""); }
        }
        public static string Umbrall_CDF_PaisEmisor
        {
            get { return Convert.ToString(GetConfigurationValue("Umbrall_CDF_PaisEmisor", "")); }
            set { SetConfigurationValue("Umbrall_CDF_PaisEmisor", "", "Umbrall", value, ""); }
        }
        public static string Umbrall_CDF_PasswordEmisor
        {
            get { return Convert.ToString(GetConfigurationValue("Umbrall_CDF_PasswordEmisor", "")); }
            set { SetConfigurationValue("Umbrall_CDF_PasswordEmisor", "", "Umbrall", value, ""); }
        }
        public static string Umbrall_ArchivoCER
        {
            get { return Convert.ToString(GetConfigurationValue("Umbrall_ArchivoCER", "")); }
            set { SetConfigurationValue("Umbrall_ArchivoCER", "", "Umbrall", value, ""); }
        }
        public static string Umbrall_ArchivoKEY
        {
            get { return Convert.ToString(GetConfigurationValue("Umbrall_ArchivoKEY", "")); }
            set { SetConfigurationValue("Umbrall_ArchivoKEY", "", "Umbrall", value, ""); }
        }
        public static string Umbrall_PasswordKEY
        {
            get { return Convert.ToString(GetConfigurationValue("Umbrall_PasswordKEY", "")); }
            set { SetConfigurationValue("Umbrall_PasswordKEY", "", "Umbrall", value, ""); }
        }
        #endregion



        /// <summary>
        /// Obtener un valor de la configuración que se encuentre almacenado en la base de datos
        /// </summary>
        /// <param name="idConfiguration">Id</param>
        /// <param name="defaultValue">Valor predeterminado en caso que no exista o que suceda un error</param>
        /// <returns></returns>
        public static object GetConfigurationValue(string idConfiguration, object defaultValue)
        {
            OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
            try
            {
                object retorno = 0;
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "select VALOR from CONFIGURACION where ID_CONFIGURACION=@id_configuration";
                cmd.Parameters.Add("@id_configuration", OleDbType.VarChar, 50).Value = idConfiguration;
                retorno = cmd.ExecuteScalar();
                return retorno;
            }
            catch { return defaultValue; }
            finally { cnn.Close(); }
        }
        /// <summary>
        /// Establecer un valor de configuración y se almacena en la base de datos.
        /// </summary>
        /// <param name="idConfiguration">Id único. Si no existe, se insertará como nuevo, si existe se actualizará.</param>
        /// <param name="description">Texto descriptivo de la configuración</param>
        /// <param name="configurationGroup">Grupo. Para agrupar las configuraciones.</param>
        /// <param name="configurationValue">Valor que se desea almacenar</param>
        /// <param name="defaultValue">Valor predeterminado. Aplica para aquellos casos en los que es un valor nuevo.</param>
        /// <returns></returns>
        public static bool SetConfigurationValue(string idConfiguration, string description, string configurationGroup, object configurationValue, object defaultValue)
        {
            OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
            int RowCount = 0;
            try
            {
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;

                cmd.CommandText = "select count(*) from CONFIGURACION where ID_CONFIGURACION=@id_configuration";
                cmd.Parameters.Add("@id_configuration", OleDbType.VarChar, 50).Value = idConfiguration;
                RowCount = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Parameters.Clear();
                if (RowCount == 0)
                {
                    cmd.CommandText = "insert into CONFIGURACION(ID_CONFIGURACION,DESC_CONFIGURACION,VALOR,GRUPO,VALOR_PREDETERMINADO) " +
                        " values(@id_configuration,@description,@configuration_value,@configuration_group,@default_value)";
                    cmd.Parameters.Add("@id_configuration", OleDbType.VarChar, 50).Value = idConfiguration;
                    cmd.Parameters.Add("@description", OleDbType.VarChar, 255).Value = description;
                    cmd.Parameters.Add("@configuration_value", OleDbType.VarChar, 255).Value = configurationValue;
                    cmd.Parameters.Add("@configuration_group", OleDbType.VarChar, 255).Value = configurationGroup;
                    cmd.Parameters.Add("@default_value", OleDbType.VarChar, 255).Value = configurationValue;
                }
                else
                {
                    cmd.CommandText = "update CONFIGURACION set " +
                        " VALOR=@configuration_value," +
                        " DESC_CONFIGURACION=@description," +
                        " GRUPO=@configuration_group " +
                        " where ID_CONFIGURACION=@id_configuration";
                    cmd.Parameters.Add("@configuration_value", OleDbType.VarChar, 255).Value = configurationValue;
                    cmd.Parameters.Add("@description", OleDbType.VarChar, 255).Value = description;
                    cmd.Parameters.Add("@configuration_group", OleDbType.VarChar, 255).Value = configurationGroup;
                    cmd.Parameters.Add("@id_configuration", OleDbType.VarChar, 50).Value = idConfiguration;
                }
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { cnn.Close(); }
        }

    }
}
