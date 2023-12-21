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
    public partial class frmCatBrandsItem : Telerik.WinControls.UI.RadForm
    {
        int varID_MARCA = 0;
        bool varACTION_SUCCESS = false;
        /// <summary>
        /// Gets ID_MARCA (Read Only)
        /// </summary>
        public int ID_MARCA
        {
            get { return varID_MARCA; }
        }
        public bool ACTION_SUCCESS
        {
            get { return varACTION_SUCCESS; }
        }
        public frmCatBrandsItem(int prmID_MARCA)
        {
            InitializeComponent();
            varID_MARCA = prmID_MARCA;
        }

        private void frmCatBrandsItem_Load(object sender, EventArgs e)
        {
            try
            {
                if (varID_MARCA != 0)
                {
                    FindByValue(varID_MARCA);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected void FindByValue(int prmID_MARCA)
        {
            OleDbConnection cnn = new OleDbConnection();
            try
            {
                cnn.ConnectionString = Class.clsMain.CnnStr;
                cnn.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT ID_MARCA, DESC_MARCA, ENABLED FROM CAT_MARCA WHERE ID_MARCA=@ID_MARCA", cnn);

                //PARAMETERS
                cmd.Parameters.Add("@ID_MARCA", OleDbType.Integer).Value = prmID_MARCA;

                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtMARCA.Text = dr["DESC_MARCA"].ToString();
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
        protected bool SaveItem(int prmID_MARCA, string prmMARCA, int prmENABLED)
        {
            OleDbConnection cnn = new OleDbConnection();
            try
            {
                cnn.ConnectionString = Class.clsMain.CnnStr;
                cnn.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;

                if (prmID_MARCA == 0)
                {
                    //new
                    cmd.CommandText = "INSERT INTO CAT_MARCA([DESC_MARCA],[ENABLED]) VALUES (@MARCA,@ENABLED)";
                }
                else
                {
                    //edit
                    cmd.CommandText = "UPDATE CAT_MARCA SET [DESC_MARCA]=@MARCA,[ENABLED]=@ENABLED WHERE ID_MARCA=@ID_MARCA";
                }
                //PARAMETERS
                cmd.Parameters.Add("@MARCA", OleDbType.VarChar, 255).Value = prmMARCA;
                cmd.Parameters.Add("@ENABLED", OleDbType.Boolean).Value = prmENABLED;
                cmd.Parameters.Add("@ID_MARCA", OleDbType.Integer).Value = prmID_MARCA;
                //MessageBox.Show(cmd.CommandText);
                cmd.ExecuteNonQuery();
                //Get the Identity ID
                if (prmID_MARCA == 0)
                {
                    cmd.CommandText = "SELECT @@IDENTITY";
                    varID_MARCA = Convert.ToInt32(cmd.ExecuteScalar());
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMARCA.Text == "")
                {
                    MessageBox.Show("Faltan Datos", "Información del Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMARCA.BackColor = Color.Yellow;
                    txtMARCA.Focus();
                    return;
                }
                if (SaveItem(varID_MARCA, txtMARCA.Text,
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
