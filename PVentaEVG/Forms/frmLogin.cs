//Directivas Using

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
/* Comentarios:
 * Programador: Lic. Juan Gabriel Castillo T.
 * Carrera:     Licenciado en Computación Administrativa
 * Matricula:   9921868
 * Fecha:       14 de Marzo del 2006
 * Materia:     Lenguaje Visual
 */
using POSDLL;
using POSDLL.Windows.Forms;
using POSDLL.Security;
using POSDLL.Reporting;
using POSDLL.Ticket;

namespace POSApp.Forms
{
    public partial class frmLogin : Telerik.WinControls.UI.RadForm
    {
        public frmLogin()
        {
            //Contructor por defecto
            InitializeComponent();
        }

        //Declaraciones
        private int Intentos = 0;
        public static bool _Logged = false;
        public static string _USER_LOGIN = "";
        public static string _PATERNO = "";
        public static string _MATERNO = "";
        public static string _NOMBRE = "";
        public static bool _VENTAS = false;
        public static bool _CATALOGOS = false;
        public static bool _REPORTES = false;
        public static bool _INVENTARIOS = false;
        public static bool _ADMINISTRAR = false;
        public static bool PERMITIR_CANCELAR = false;

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //Form_Load
            Class.clsMain.Exit = true;
            // ajustamos la el centrado del control login 

            AdjustLocation();
        }

        //Funciones y procedimientos

        private bool fnLogin(string prmUSER_NAME, string prmPASSWORD)
        {
            bool Retorno = false;
            string varSQL = "SELECT USER_LOGIN, PATERNO, " +
                            " MATERNO, NOMBRE,VENTAS,CATALOGOS,REPORTES,INVENTARIOS,ADMINISTRAR,CANCELAR" +
                            " FROM USERS" +
                            " WHERE USER_LOGIN='" + prmUSER_NAME + "' " +
                            " AND USER_PASSWORD ='" + prmPASSWORD + "' " +
                            " AND ACTIVO <> 0";
            OleDbConnection cnnLogin =
                new OleDbConnection(Class.clsMain.CnnStr);
            OleDbCommand cmdLogin = new OleDbCommand(varSQL, cnnLogin);

            try
            {
                
                cnnLogin.Open();
                OleDbDataReader drLogin = cmdLogin.ExecuteReader();
                if (drLogin.Read())
                {
                    _USER_LOGIN = drLogin["USER_LOGIN"].ToString();
                    _PATERNO = drLogin["PATERNO"].ToString();
                    _MATERNO = drLogin["MATERNO"].ToString();
                    _NOMBRE = drLogin["NOMBRE"].ToString();
                    _VENTAS = Convert.ToBoolean(drLogin["VENTAS"]);
                    _ADMINISTRAR = Convert.ToBoolean(drLogin["ADMINISTRAR"]);
                    _REPORTES = Convert.ToBoolean(drLogin["REPORTES"]);
                    _CATALOGOS = Convert.ToBoolean(drLogin["CATALOGOS"]);
                    _INVENTARIOS = Convert.ToBoolean(drLogin["INVENTARIOS"]);
                    PERMITIR_CANCELAR = Convert.ToBoolean(drLogin["CANCELAR"]);
                    Retorno = true;
                }
                else
                {
                    Intentos += 1;
                    throw new Exception("Nombre de usurio o contraseña incorrectos");
                }
                return (Retorno);
            }

            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                cnnLogin.Close();
            }
        }




        private void lblDataBase_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmGeneralConfiguration _frmConfigApp = new Forms.frmGeneralConfiguration();
            _frmConfigApp.StartPosition = FormStartPosition.CenterScreen;
            _frmConfigApp.tabConfigApp.SelectedIndex = 0;
            _frmConfigApp.ShowDialog();
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _Logged = false;
            Class.clsMain.Exit = true;
            this.Close();
        }

        private void btnSession_Click(object sender, EventArgs e)
        {
            try
            {
                EncryptDecrypt _clsEncryptDecrypt = new EncryptDecrypt();
                if (Intentos >= 3)
                {
                    _Logged = false;
                    MessageBox.Show("Número de intentos excedidos",
                                    "System Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                else
                {

                    if (fValidaCampos())
                    {
                        _Logged = fnLogin(Strings.SafeSqlLikeClauseLiteral(txtUser.Text),
                                    _clsEncryptDecrypt.Encrypt(txtPass.Text));
                        if (_Logged)
                        {
                            this.Close();
                        }

                    }

                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Información del sistema",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Boolean fValidaCampos()
        {
            Boolean bContinuar = true;

            errLogin.Clear();

            if (txtUser.Text == String.Empty)
            {
                errLogin.SetError(txtUser, "Ingrese su nombre de usuario.");
                bContinuar = false;
            }
            if (txtPass.Text == String.Empty)
            {
                errLogin.SetError(txtPass, "Ingrese su contraseña.");
                bContinuar = false;

            }

            return bContinuar;

        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras en este campo.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void AdjustLocation()
        {
            // Adjust the position relative to main form
            int dx = (this.Width - pnLogin.Width) / 2;
            int dy = (this.Height - pnLogin.Height) / 2;
            Point loc = new Point(this.Location.X, this.Location.Y);
            loc.Offset(dx, dy);
            pnLogin.Location = loc;
        }
    }
}