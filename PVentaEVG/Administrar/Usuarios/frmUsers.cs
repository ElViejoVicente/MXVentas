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
    public partial class frmUsers : Telerik.WinControls.UI.RadForm
    {
        private static frmUsers m_FormDefInstance;
        public static frmUsers DefInstance
        {
            get
            {

                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmUsers();
                return m_FormDefInstance;
            }
            set { m_FormDefInstance = value; }
        }
        public frmUsers()
        {
            InitializeComponent();
        }
        //Para manipular el ini 
         //Para encryptar
        private void frmUsers_Load(object sender, EventArgs e)
        {
            Encabezados();
            ReadData();
        }
        void lvUsers_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lvUsers.Items.Count != 0)
            {
                //frmRestorePass _frmRestorePass = new frmRestorePass(Convert.ToString(lvUsers.SelectedItems[0].Text));
                if (lvUsers.SelectedItems.Count != 0)
                {
                    gpoUsers.Text = "Password de [" + Convert.ToString(lvUsers.SelectedItems[0].Text) +"]";
                    lblPasswordMessage.Text = "Establecer password de: " + Convert.ToString(lvUsers.SelectedItems[0].Text);
                }
            }
        }

        private void Encabezados()
        {
            lvUsers.View = View.Details;
            lvUsers.Columns.Add("Login", 100, HorizontalAlignment.Left);
            lvUsers.Columns.Add("Activo", 100, HorizontalAlignment.Left);
            lvUsers.Columns.Add("Administrar", 100, HorizontalAlignment.Left);
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void NewUser() {
            frmUser _frmUser = new frmUser();
            _frmUser.StartPosition = FormStartPosition.CenterScreen;
            _frmUser.ShowDialog();
            if (frmUser._Accion)
            {
                ReadData();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            RestorePass();
            
            
        }
        void RestorePass() {
            //Código         
            try
            {
                if (lvUsers.Items.Count != 0)
                {
                    frmUserRestorePass _frmRestorePass = new frmUserRestorePass(Convert.ToString(lvUsers.SelectedItems[0].Text));
                    _frmRestorePass.StartPosition = FormStartPosition.CenterScreen;
                    _frmRestorePass.ShowDialog();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe seleccionar un elemento de la lista. \nError Description: \n" + ex.Message, "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnProperties_Click(object sender, EventArgs e)
        {
            UserProperties();
        }
        void UserProperties() {
            //Código         
            try
            {
                if (lvUsers.Items.Count != 0)
                {
                    frmUser _frmUser = new frmUser(Convert.ToString(lvUsers.SelectedItems[0].Text));
                    _frmUser.StartPosition = FormStartPosition.CenterScreen;
                    _frmUser.ShowDialog();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe seleccionar un elemento de la lista. \nError Description: \n" + ex.Message, "Operación no válida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void ReadData()
        {
            //Este procedimiento lee los datos que se tranferirán y los mostrará en forma de
            //lista en el ListView           
            try
            {
                string varSQL = "SELECT USER_LOGIN, ACTIVO,ADMINISTRAR FROM USERS";
                //Si la conexion esta abierta la cerramos; en caso contrario, la abrimos
                OleDbConnection cnnReadData = new OleDbConnection(Class.clsMain.CnnStr);
                if (cnnReadData.State == ConnectionState.Open) cnnReadData.Close(); else cnnReadData.Open();
                int I = 0;
                OleDbCommand cmdReadData = new OleDbCommand(varSQL, cnnReadData);
                OleDbDataReader drReadData;
                drReadData = cmdReadData.ExecuteReader();
                lvUsers.Items.Clear();
                while (drReadData.Read())
                {
                    lvUsers.Items.Add(drReadData["USER_LOGIN"].ToString());
                    lvUsers.Items[I].SubItems.Add(drReadData["ACTIVO"].ToString());
                    lvUsers.Items[I].SubItems.Add(drReadData["ADMINISTRAR"].ToString());
                   
                    I += 1;
                }
                
                drReadData.Close();
                cmdReadData.Dispose();
                cnnReadData.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeactivateUser();
        }
        void ActivateUser()
        {

            try
            {
                if (lvUsers.Items.Count != 0)
                {
                    DialogResult Resp = new DialogResult();
                    Resp = MessageBox.Show("Está seguro de ACTIVAR a: [" + Convert.ToString(lvUsers.SelectedItems[0].Text) + "]", "Activar Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Resp == DialogResult.Yes)
                    {
                        //eliminar el elemento
                        ActivateUser(Convert.ToString(lvUsers.SelectedItems[0].Text));
                        ReadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("You must select an element from the list. \nError Description: \n" + ex.Message, "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        void DeactivateUser() {

            try
            {
                if (lvUsers.Items.Count != 0)
                {
                    DialogResult Resp = new DialogResult();
                    Resp = MessageBox.Show("Está seguro de DESACTIVAR a [" + Convert.ToString(lvUsers.SelectedItems[0].Text) + "]", "Desactivar Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Resp == DialogResult.Yes)
                    {
                        //eliminar el elemento
                        Delete(Convert.ToString(lvUsers.SelectedItems[0].Text));
                        ReadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe seleccionar un elemento de la lista. \nError Description: \n" + ex.Message, "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void Delete(string prmUserLogin)
        {
            //Función para el inicio de sesión, regresará false en caso de fallar
            try
            {

                OleDbConnection cnnDelete = new OleDbConnection(Class.clsMain.CnnStr);
                cnnDelete.Open();
                string varSQL = "UPDATE USERS SET ACTIVO= 0 WHERE USER_LOGIN='" + prmUserLogin + "' ";
                OleDbCommand cmdDelete = new OleDbCommand(varSQL, cnnDelete);
                cmdDelete.ExecuteNonQuery();
                MessageBox.Show("El usuario [" + prmUserLogin + "] ha sido desactivado.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmdDelete.Dispose();
                cnnDelete.Close();
                cnnDelete.Dispose();
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                

            }
        }
        private void ActivateUser(string prmUserLogin)
        {
            //Función para el inicio de sesión, regresará false en caso de fallar
            try
            {

                OleDbConnection cnnDelete = new OleDbConnection(Class.clsMain.CnnStr);
                cnnDelete.Open();
                string varSQL = "UPDATE USERS SET ACTIVO= 1 WHERE USER_LOGIN='" + prmUserLogin + "' ";
                OleDbCommand cmdDelete = new OleDbCommand(varSQL, cnnDelete);
                cmdDelete.ExecuteNonQuery();
                MessageBox.Show("el usuario [" + prmUserLogin + "] ha sido activado.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmdDelete.Dispose();
                cnnDelete.Close();
                cnnDelete.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }
        private void mnuRestorePassword_Click(object sender, EventArgs e)
        {
            RestorePass();
        }

        private void mnuDeactivate_Click(object sender, EventArgs e)
        {
            DeactivateUser();
        }

        private void mnuUSerProperties_Click(object sender, EventArgs e)
        {
            UserProperties();
        }

        private void mnuAddUser_Click(object sender, EventArgs e)
        {
            NewUser();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NewUser();
        }

        private void mnuActivate_Click(object sender, EventArgs e)
        {
            ActivateUser();
        }
    }
}