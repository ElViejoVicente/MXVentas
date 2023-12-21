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
    public partial class frmUser : Telerik.WinControls.UI.RadForm
    {
        public frmUser()
        {
            InitializeComponent();
            varUSER_LOGIN = "";
        }
        public frmUser( string prmUSER_LOGIN)
        {
            InitializeComponent();
            varUSER_LOGIN = prmUSER_LOGIN;
        }
        string varUSER_LOGIN = "";
        public static bool _Accion = false;
        
        

        private void frmUser_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Class.clsMain.fnCheckAccess(frmLogin._USER_LOGIN, "ADMINISTRAR"))
                {
                    this.Close();
                }
                else
                {
                    //aqui por si se trata de una modificación                    
                    if ((varUSER_LOGIN != ""))
                    {
                        //se va a modificar
                        txtUSER_LOGIN.Enabled = false;
                        ReadData(varUSER_LOGIN);
                    }
                    else
                    {
                        
                    }
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void Grabar()
        {
            EncryptDecrypt _clsEncryptDecrypt = new EncryptDecrypt(); 
            try
            {
                if (fnUsers(txtUSER_LOGIN.Text,
                    Strings.SafeSqlLikeClauseLiteral(txtPATERNO.Text), 
                    Strings.SafeSqlLikeClauseLiteral(txtMATERNO.Text),
                    Strings.SafeSqlLikeClauseLiteral(txtNOMBRE.Text),
                    _clsEncryptDecrypt.Encrypt("Restaurante2011"),
                        Convert.ToInt32(chkADMINISTRAR.Checked),
                        Convert.ToInt32(chkVENTAS.Checked), Convert.ToInt32(chkCATALOGOS.Checked),
                        Convert.ToInt32(chkREPORTES.Checked), 
                        Convert.ToInt32(chkINVENTARIOS.Checked),
                        Convert.ToInt32(chkACTIVO.Checked), Convert.ToInt32(chkDESCUENTOS.Checked),
                        Convert.ToInt32(chkCANCELAR.Checked)))
                {
                    _Accion = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool fnUsers(string prmUSER_LOGIN, string prmPATERNO, string prmMATERNO, string prmNOMBRE, 
            string prmUSER_PASSWORD, int prmADMINISTRAR, int prmVENTAS, int prmCATALOGOS,
        int prmREPORTES,  int prmINVENTARIOS,  int prmACTIVO,int prmDESCUENTOS, int prmCANCELAR)
        {
            try
            {
                OleDbConnection cnnUsers = new OleDbConnection(Class.clsMain.CnnStr);
                cnnUsers.Open();
                string varSQL_Insert = "INSERT INTO USERS (USER_LOGIN,PATERNO,MATERNO,NOMBRE,USER_PASSWORD,"+
                    " ADMINISTRAR,VENTAS,CATALOGOS, REPORTES,INVENTARIOS,ACTIVO,DESCUENTOS,CANCELAR) "+
                    " VALUES('" + prmUSER_LOGIN + "','" + prmPATERNO + "','" + prmMATERNO + "','" + prmNOMBRE + "','" + prmUSER_PASSWORD + "'," +
                    " " + prmADMINISTRAR + "," + prmVENTAS + "," + prmCATALOGOS + "," +
                    " " + prmREPORTES + "," + prmINVENTARIOS + ","+ prmACTIVO +","+ prmDESCUENTOS +","+ prmCANCELAR +")";

                string varSQL_Update = "UPDATE USERS SET PATERNO='" + prmPATERNO + "',MATERNO='" + prmMATERNO + "',NOMBRE='" + prmNOMBRE + "'," +
                    " ADMINISTRAR=" + prmADMINISTRAR + ",VENTAS=" + prmVENTAS + ",CATALOGOS=" + prmCATALOGOS + "," +
                    " REPORTES=" + prmREPORTES + " ,INVENTARIOS=" + prmINVENTARIOS + "," +
                    " ACTIVO=" + prmACTIVO + ", DESCUENTOS="+ prmDESCUENTOS +",CANCELAR="+ prmCANCELAR +" " +
                    " WHERE USER_LOGIN='"+ prmUSER_LOGIN +"'";              
                OleDbCommand cmdUsers = new OleDbCommand();
                cmdUsers.Connection = cnnUsers;
                if (varUSER_LOGIN == "")
                {
                    //insert                   
                    cmdUsers.CommandText = varSQL_Insert;
                }
                else {
                    //update
                    cmdUsers.CommandText = varSQL_Update;
                }
                cmdUsers.ExecuteNonQuery();
                cmdUsers.Dispose();
                cnnUsers.Close();
                cnnUsers.Dispose();
                return (true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return (false);
            }

        }

        private void ReadData(string prmUSER_LOGIN)
        {
            try
            {
                OleDbConnection cnnReadData = new OleDbConnection(Class.clsMain.CnnStr);
                cnnReadData.Open();
                string varSQL = "SELECT * FROM USERS WHERE USER_LOGIN ='" + prmUSER_LOGIN + "'";
                OleDbCommand cmdReadData = new OleDbCommand(varSQL, cnnReadData);
                OleDbDataReader drReadData;
                drReadData = cmdReadData.ExecuteReader();
                drReadData.Read();
                //Mostramos los datos      
                txtUSER_LOGIN.Text = drReadData["USER_LOGIN"].ToString();
                txtPATERNO.Text = drReadData["PATERNO"].ToString();
                txtMATERNO.Text = drReadData["MATERNO"].ToString();
                txtNOMBRE.Text = drReadData["NOMBRE"].ToString(); 
                chkADMINISTRAR.Checked = Convert.ToBoolean(drReadData["ADMINISTRAR"]);
                chkVENTAS.Checked = Convert.ToBoolean(drReadData["VENTAS"]);
                chkCATALOGOS.Checked = Convert.ToBoolean(drReadData["CATALOGOS"]);
                chkREPORTES.Checked = Convert.ToBoolean(drReadData["REPORTES"]);
               
                chkINVENTARIOS.Checked = Convert.ToBoolean(drReadData["INVENTARIOS"]);
               
                chkACTIVO.Checked = Convert.ToBoolean(drReadData["ACTIVO"]);
                chkDESCUENTOS.Checked = Convert.ToBoolean(drReadData["DESCUENTOS"]);
                chkCANCELAR.Checked = Convert.ToBoolean(drReadData["CANCELAR"]);

                drReadData.Close();
                cmdReadData.Dispose();
                cnnReadData.Close();
                cnnReadData.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                btnOK.Enabled = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Validaciones())
            {
                Grabar();
            }
        }
        bool Validaciones() {
            if (txtUSER_LOGIN.Text != "")
            {
                return (true);
            }
            else {
                MessageBox.Show("Introduce Username");
                return (false);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}