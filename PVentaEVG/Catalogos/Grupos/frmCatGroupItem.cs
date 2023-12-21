using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POSDLL; using POSDLL.Windows.Forms; using POSDLL.Security; using POSDLL.Reporting; using POSDLL.Ticket;
namespace POSApp.Forms
{
    public partial class frmCatGroupItem : Telerik.WinControls.UI.RadForm
    {
        int varID_GRUPO = 0;
        bool varACTION_SUCCESS = false;
        /// <summary>
        /// Gets ID_GRUPO (Read Only)
        /// </summary>
        public int ID_GRUPO {
            get { return varID_GRUPO; }
        }
        public bool ACTION_SUCCESS {
            get { return varACTION_SUCCESS; }
        }
        public frmCatGroupItem(int prmID_GRUPO)
        {
            InitializeComponent();
            varID_GRUPO = prmID_GRUPO;
        }

        private void frmCatGroupItem_Load(object sender, EventArgs e)
        {
            try {
                if (varID_GRUPO != 0) {
                    FindByValue(varID_GRUPO);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Información del Sistema", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected void FindByValue(int prmID_GRUPO)
        {
            OleDbConnection cnn = new OleDbConnection();
            try
            {
                cnn.ConnectionString = Class.clsMain.CnnStr;
                cnn.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT ID_GRUPO, DESC_GRUPO, ENABLED FROM CAT_GRUPO WHERE ID_GRUPO=@ID_GRUPO", cnn);
                
                //PARAMETERS
                cmd.Parameters.Add("@ID_GRUPO", OleDbType.Integer).Value = prmID_GRUPO;

                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtGRUPO.Text = dr["DESC_GRUPO"].ToString();
                    chkENABLED.Checked = Convert.ToBoolean(dr["ENABLED"]);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del Sistema", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cnn.Close();
            }
        }
        protected bool SaveItem(int prmID_GRUPO, string prmGRUPO,int prmENABLED) {
            OleDbConnection cnn = new OleDbConnection();
            try
            {
                cnn.ConnectionString = Class.clsMain.CnnStr;
                cnn.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;

                if (prmID_GRUPO == 0)
                {
                    //new
                    cmd.CommandText = "INSERT INTO CAT_GRUPO([DESC_GRUPO],[ENABLED]) VALUES (@GRUPO,@ENABLED)";
                }
                else { 
                    //edit
                    cmd.CommandText = "UPDATE CAT_GRUPO SET [DESC_GRUPO]=@GRUPO,[ENABLED]=@ENABLED WHERE ID_GRUPO=@ID_GRUPO";
                }
                //PARAMETERS
                cmd.Parameters.Add("@GRUPO", OleDbType.VarChar, 255).Value = prmGRUPO;
                cmd.Parameters.Add("@ENABLED", OleDbType.Boolean).Value = prmENABLED;
                cmd.Parameters.Add("@ID_GRUPO", OleDbType.Integer).Value = prmID_GRUPO;
                //MessageBox.Show(cmd.CommandText);
                cmd.ExecuteNonQuery();
                //Get the Identity ID
                if (prmID_GRUPO == 0)
                {
                    cmd.CommandText = "SELECT @@IDENTITY";
                    varID_GRUPO = Convert.ToInt32(cmd.ExecuteScalar());
                }
                varACTION_SUCCESS = true;
                return (true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                varACTION_SUCCESS = false;
                return (false);
            }
            finally
            {
                cnn.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtGRUPO.Text == "") {
                    MessageBox.Show("Faltan Datos", "Información del Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtGRUPO.BackColor = Color.Yellow;
                    txtGRUPO.Focus();
                    return;
                }
                if (SaveItem(varID_GRUPO, txtGRUPO.Text,
                    Convert.ToInt32(chkENABLED.Checked)))
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
