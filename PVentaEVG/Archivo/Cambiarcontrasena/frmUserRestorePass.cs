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
    public partial class frmUserRestorePass : Telerik.WinControls.UI.RadForm
    {
        public frmUserRestorePass(string prmUSER_LOGIN)
        {
            InitializeComponent();
            varUSER_LOGIN = prmUSER_LOGIN;
        }
        //Para manipular el ini 
         //Para encryptar
        string varUSER_LOGIN = "";
        private void frmRestorePass_Load(object sender, EventArgs e)
        {

        }
        private bool ChangePass(string prmUserLogin, string prmNewPassword)
        {
            //Función para el inicio de sesión, regresará false en caso de fallar
            try
            {

                OleDbConnection cnnChangePass = new OleDbConnection(Class.clsMain.CnnStr);
                cnnChangePass.Open();
                string varSQL = "UPDATE USERS SET [USER_PASSWORD] = '" + prmNewPassword + "' WHERE USER_LOGIN='" + prmUserLogin + "' ";
                OleDbCommand cmdChangePass = new OleDbCommand(varSQL, cnnChangePass);
                cmdChangePass.ExecuteNonQuery();
                MessageBox.Show("El Password de ["+ prmUserLogin +"] ha sido actualizado","System Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                cmdChangePass.Dispose();
                cnnChangePass.Close();
                cnnChangePass.Dispose();
                return (true);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false);

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            EncryptDecrypt _clsEncryptDecrypt = new EncryptDecrypt();
            if ((txtNEW_PASS.Text == "") || (txtRE_PASS.Text == ""))
            {
                MessageBox.Show("Empty password is not allowed", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else {
                if (txtNEW_PASS.Text != txtRE_PASS.Text)
                {
                    MessageBox.Show("Reenting Password Error","System Information",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                else { 
                    //aqui
                    if (ChangePass(varUSER_LOGIN, 
                        _clsEncryptDecrypt.Encrypt(txtNEW_PASS.Text)))
                    {
                        this.Close();
                    }
                }
            }
        }
    }
}