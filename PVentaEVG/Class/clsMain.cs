using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using POSDLL;
using POSDLL.Windows.Forms;
using POSDLL.Security;
using POSDLL.Reporting;
using POSDLL.Ticket;
using System.Management;
using POSDLL.Utilities;
namespace POSApp.Class
{
    public class clsMain
    {

        
        //Para ciclar o no el sistema
        static bool exit = false;
        public static Boolean Exit { get { return exit; } set { exit = value; } }
        //Registro

        static WindowsRegistry reg = new WindowsRegistry();
        //Encriptar
        static EncryptDecrypt cripto = new EncryptDecrypt();
        [STAThread]
        static void Main()
        {
            //DateTime expirationDate = new DateTime(2013, 1, 25);//FEcha de Caducidad
            //if (DateTime.Now > expirationDate)
            //{
            //    MessageBox.Show("Periodo de Prueba finalizado\n\nSistema Desarrollado por: www.tyrodeveloper.com\n\nContáctanos: tyrodeveloper@gmail.com", "www.tyrodeveloper.com", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //MessageBox.Show("Versión de Prueba\n\nSistema Desarrollado por: www.tyrodeveloper.com\n\nContáctanos: tyrodeveloper@gmail.com", "www.tyrodeveloper.com", MessageBoxButtons.OK, MessageBoxIcon.Information);


            if (AppSettings.GetValue("Config", "ProcessorId", "") == "")
            {
                AppSettings.SetValue("Config", "ProcessorId", CPUInfo());
            }

            //Fecha de primer incio
            //comentado para probar MSalazar
            //if (reg.ReadValue("POS_StartConf", "") == "")
            //{
            //    reg.WriteValue("POS_StartConf", cripto.Encrypt(DateTime.Now.ToShortDateString()));
            //}
            while (!exit)
            {
                Inicializa();
                Application.EnableVisualStyles();
                Forms.frmLogin loginForm = new Forms.frmLogin();
                Application.Run(loginForm);

                if (Forms.frmLogin._Logged == true)
                {
                    Forms.mdiMain mainForm = new Forms.mdiMain();
                    Application.Run(mainForm);
                }
                else
                {
                    Application.Exit();

                }
            }
        }
        public static bool CnnTest()
        {
            #region "comentado Msalazar"
            OleDbConnection cnn = new OleDbConnection(CnnStr);
            bool ret = false;
            try
            {
                cnn.Open();
                if (cnn.State == ConnectionState.Open)
                {
                    ret = true;
                }
                return (ret);
            }
            catch
            {
                MessageBox.Show("Error en la configuración de la conexión", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return (false);
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            #endregion

            #region modificaciones para SQL Msalazar
            //bool ret = false;
            //// SqlConnection that will be used to execute the sql commands
            //SqlConnection connection = null;
            //try
            //{
            //    connection = new SqlConnection(CnnStr);
            //    connection.Open();
            //     //connection = GetConnection(CnnStr);
            //    if (connection.State == ConnectionState.Open)
            //    {
            //        connection.Close();
            //        ret= true;
            //    }

                
            //}
            //catch
            //{
            //    MessageBox.Show("The connection with the database can´t be established", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    ret = false;
            //}

            //finally
            //{
            //    if (connection != null && connection.State == ConnectionState.Open)
            //    {
            //        connection.Close();
            //        connection.Dispose();
            //    }
                
            //}
            //return ret;
            #endregion
        }
        public static string CnnStr
        {
            get
            {
                return ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppSettings.GetValue("Config", "DataSource", "")) + ";Jet OLEDB:Database Password=" + AppSettings.GetValue("Config", "DataBasePassword", "");
            }
            #region Modificaciones para SQL MAsalazar
            //get
            //{
            //    return
            //        ("Data Source=MALTRAKALIEN\\SQL2008R2;Initial Catalog=POS;Persist Security Info=True;User ID=dev;Password=dev");
            //}
            #endregion
        }
        /// <summary>
        /// Indica si el sistema ha superado el periodo de prueba
        /// </summary>
        /// <returns></returns>
        public static bool Activado()
        {
            try
            {
                bool activar = false;
                // validamos que en equipo exista una llave de activacion
                String sActivationKey = reg.ReadValue("POS_ActivationKey", "");
                if (String.IsNullOrEmpty(sActivationKey))
                {
                    // si no se encuntra llave en el equipo se procede a bloquear el mismo.
                    return (false);
                }
                
                Dictionary<String, String> CamposLLave = new Dictionary<string, string>();

                String sCadena = fDesencriptaCadena(sActivationKey);

                String[] sCandenaCampos = sCadena.Split('~');

                foreach (var item in sCandenaCampos)
                {
                    CamposLLave.Add(item.Split('/')[0].ToString(), item.Split('/')[1].ToString());

                }

                if (CamposLLave["Key"].ToString() == "666666")
                {
                    return (false);
                }


                if (CamposLLave["Edicion"].ToString() == "DEMO")
                {
                    return (false);
                }

                if (CamposLLave["Edicion"].ToString() == "TRIAL 1 DAY")
                {
                    
                    DateTime d1 =  DateTime.Parse(CamposLLave["FechaValor"]);
                    DateTime d2 = DateTime.Now;

                    TimeSpan ts = d2 - d1;
                    DateTime d = DateTime.MinValue + ts;

                    int dias = d.Day - 1;
                    int meses = d.Month - 1;
                    int años = d.Year - 1;

                    if (dias>=1)
                    {
                        activar = false;
                    }
                    else
                    {
                        activar = true;
                    }

                    
                }

                if (CamposLLave["Edicion"].ToString() == "TRIAL 30 DAYS")
                {
                    DateTime d1 = DateTime.Parse(CamposLLave["FechaValor"]);
                    DateTime d2 = DateTime.Now;

                    TimeSpan ts = d2 - d1;
                    DateTime d = DateTime.MinValue + ts;

                    int dias = d.Day - 1;
                    int meses = d.Month - 1;
                    int años = d.Year - 1;

                    if (dias >= 30)
                    {
                        activar = false;
                    }
                    else
                    {
                        activar = true;
                    }
                }

                if (CamposLLave["Edicion"].ToString() == "TRIAL 60 DAYS")
                {
                    DateTime d1 = DateTime.Parse(CamposLLave["FechaValor"]);
                    DateTime d2 = DateTime.Now;

                    TimeSpan ts = d2 - d1;
                    DateTime d = DateTime.MinValue + ts;

                    int dias = d.Day - 1;
                    int meses = d.Month - 1;
                    int años = d.Year - 1;

                    if (dias >= 60)
                    {
                        activar = false;
                    }
                    else
                    {
                        activar = true;
                    }
                }
                //reg.WriteValue("POS_ActivationKey", "TestMxitSolutions");


                //validamos el id del procesador
                string processorId = CamposLLave["CpuId"].ToString();
                if (processorId != CPUInfo())
                {
                    activar = false;
                }
               
                if (activar)
                { 
                    return true; 
                }
                else
                {
                    return (false);
                }

                
            }
            catch
            {
                //SI HA OCURRIDO UN ERROR
                return (false);
            }
        }
        public static string CPUInfo()
        {
            string cpuInfo = string.Empty;
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                if (cpuInfo == "")
                {
                    //Get only the first CPU's ID
                    cpuInfo = mo.Properties["processorID"].Value.ToString();
                    break;
                }
            }
            return cpuInfo;
        }
        /// <summary>
        /// Función para saber si el usuario tiene acceso a una opción del sistema
        /// </summary>
        /// <param name="prmUSER_LOGIN">Nombre de usuario del sistema</param>
        /// <param name="prmOPCION">Opción a la que se desea verificar el acceso</param>
        /// <returns></returns>
        public static bool fnCheckAccess(string prmUSER_LOGIN, string prmOPCION)
        {
            try
            {
                OleDbConnection cnnCheckAccess = new OleDbConnection(CnnStr);
                cnnCheckAccess.Open();
                string varSQL = "SELECT " + prmOPCION + " FROM USERS WHERE USER_LOGIN ='" + prmUSER_LOGIN + "'";
                OleDbCommand cmdCheckAccess = new OleDbCommand(varSQL, cnnCheckAccess);
                bool retorno = Convert.ToBoolean(cmdCheckAccess.ExecuteScalar());
                cmdCheckAccess.Dispose();
                cnnCheckAccess.Close();
                cnnCheckAccess.Dispose();
                return (retorno);
            }
            catch
            {

                return (false);
            }
        }
        static void Inicializa()
        {

            //Filtro para entradas
            AppSettings.SetValue("FILTRO_ENTRADAS", "FECHA_INI", Convert.ToString(System.DateTime.Now - System.DateTime.Now.TimeOfDay));
            AppSettings.SetValue("FILTRO_ENTRADAS", "FECHA_FIN", Convert.ToString(System.DateTime.Now - System.DateTime.Now.TimeOfDay));
            AppSettings.SetValue("FILTRO_ENTRADAS", "FILTRO", Convert.ToString(true));
            AppSettings.SetValue("FILTRO_ENTRADAS", "HOY", Convert.ToString(true));
            //filtro para salidas
            AppSettings.SetValue("FILTRO_VENTAS", "FECHA_INI", Convert.ToString(System.DateTime.Now - System.DateTime.Now.TimeOfDay));
            AppSettings.SetValue("FILTRO_VENTAS", "FECHA_FIN", Convert.ToString(System.DateTime.Now - System.DateTime.Now.TimeOfDay));
            AppSettings.SetValue("FILTRO_VENTAS", "FILTRO", Convert.ToString(true));
            AppSettings.SetValue("FILTRO_VENTAS", "HOY", Convert.ToString(true));
            //filtro para FACTURAS
            AppSettings.SetValue("FILTRO_FACTURAS", "FECHA_INI", Convert.ToString(System.DateTime.Now - System.DateTime.Now.TimeOfDay));
            AppSettings.SetValue("FILTRO_FACTURAS", "FECHA_FIN", Convert.ToString(System.DateTime.Now - System.DateTime.Now.TimeOfDay));
            AppSettings.SetValue("FILTRO_FACTURAS", "FILTRO", Convert.ToString(true));
            AppSettings.SetValue("FILTRO_FACTURAS", "HOY", Convert.ToString(true));
            //filtro para AJUSTES
            AppSettings.SetValue("FILTRO_AJUSTES", "FECHA_INI", Convert.ToString(System.DateTime.Now - System.DateTime.Now.TimeOfDay));
            AppSettings.SetValue("FILTRO_AJUSTES", "FECHA_FIN", Convert.ToString(System.DateTime.Now - System.DateTime.Now.TimeOfDay));
            AppSettings.SetValue("FILTRO_AJUSTES", "FILTRO", Convert.ToString(true));
            AppSettings.SetValue("FILTRO_AJUSTES", "HOY", Convert.ToString(true));
            //filtro para TRASPASOS
            AppSettings.SetValue("FILTRO_TRASPASO", "FECHA_INI", Convert.ToString(System.DateTime.Now - System.DateTime.Now.TimeOfDay));
            AppSettings.SetValue("FILTRO_TRASPASO", "FECHA_FIN", Convert.ToString(System.DateTime.Now - System.DateTime.Now.TimeOfDay));
            AppSettings.SetValue("FILTRO_TRASPASO", "FILTRO", Convert.ToString(true));
            AppSettings.SetValue("FILTRO_TRASPASO", "HOY", Convert.ToString(true));
            //filtro para GASTOS
            AppSettings.SetValue("FILTRO_GASTOS", "FECHA_INI", Convert.ToString(System.DateTime.Now - System.DateTime.Now.TimeOfDay));
            AppSettings.SetValue("FILTRO_GASTOS", "FECHA_FIN", Convert.ToString(System.DateTime.Now - System.DateTime.Now.TimeOfDay));
            AppSettings.SetValue("FILTRO_GASTOS", "FILTRO", Convert.ToString(true));
            AppSettings.SetValue("FILTRO_GASTOS", "HOY", Convert.ToString(true));
            //filtro para GASTOS
            AppSettings.SetValue("FILTRO_REPORTES", "FECHA_INI", Convert.ToString(System.DateTime.Now - System.DateTime.Now.TimeOfDay));
            AppSettings.SetValue("FILTRO_REPORTES", "FECHA_FIN", Convert.ToString(System.DateTime.Now - System.DateTime.Now.TimeOfDay));
            AppSettings.SetValue("FILTRO_REPORTES", "FILTRO", Convert.ToString(true));
            AppSettings.SetValue("FILTRO_REPORTES", "HOY", Convert.ToString(true));
        }

        private static String fDesencriptaCadena(String sCadena)
        {
            try
            {
                var Aes = new POSDLL.Security.clsEncryptionAES();
                return Aes.Decode(sCadena);

            }
            catch (Exception)
            {

                throw new Exception("Error la cadena de solicitud no es la correcta"); ;
            }
        }



    }

}
