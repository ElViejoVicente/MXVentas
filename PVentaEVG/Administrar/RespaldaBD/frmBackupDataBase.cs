using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSDLL; using POSDLL.Windows.Forms; using POSDLL.Security; using POSDLL.Reporting; using POSDLL.Ticket;
namespace POSApp.Forms
{
    public partial class frmBackupDataBase : Telerik.WinControls.UI.RadForm
    {
        public frmBackupDataBase()
        {
            InitializeComponent();
        }
        string varFileName = "";
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folder = new FolderBrowserDialog();
                if (folder.ShowDialog() == DialogResult.OK)
                {
                    //si el usuario presiona OK
                    Preparar(folder.SelectedPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
              "Información del sistema-btnAbrir_Click",
              MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        void Preparar(string prmPath)
        {
            try
            {
                varFileName = prmPath + "\\" + Strings.fnFileNameGenerator("respaldo.mdb");

                if (varFileName != "")
                {
                    //si no está vacío
                    txtFileName.Text = varFileName;
                    btnOK.Enabled = true;
                }
                else
                {
                    btnOK.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
               "Información del sistema-Preparar",
               MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                string varCnnNueva = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + varFileName;
                POSDLL.BackUpDataBase _RespaldarBaseDeDatos = new  BackUpDataBase();
                _RespaldarBaseDeDatos.Backup(Class.clsMain.CnnStr, varCnnNueva);
                this.Close();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message,
               "Información del sistema",
               MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void frmBackupDataBase_Load(object sender, EventArgs e)
        {
            MessageBox.Show("¡ATENCION!\n"+
                "Este proceso requiere que el sistema no esté ejecutando otro proceso.",
                "Información del sistema",
                MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }
    }
}