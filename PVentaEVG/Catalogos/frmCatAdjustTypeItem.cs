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
    public partial class frmCatAdjustTypeItem : Telerik.WinControls.UI.RadForm
    {
        int varID_ADJUST_TYPE = 0;
        bool varACTION_SUCCESS = false;
        /// <summary>
        /// Gets ID_ADJUST_TYPE (Read Only)
        /// </summary>
        public int ID_ADJUST_TYPE
        {
            get { return varID_ADJUST_TYPE; }
        }
        public bool ACTION_SUCCESS
        {
            get { return varACTION_SUCCESS; }
        }
        public frmCatAdjustTypeItem(int prmID_ADJUST_TYPE)
        {
            InitializeComponent();
            varID_ADJUST_TYPE = prmID_ADJUST_TYPE;
        }

        private void frmCatAdjustTypeItem_Load(object sender, EventArgs e)
        {
            try
            {
                if (varID_ADJUST_TYPE != 0)
                {
                    FindByValue(varID_ADJUST_TYPE);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected void FindByValue(int prmID_ADJUST_TYPE)
        {
            OleDbConnection cnn = new OleDbConnection();
            try
            {
                cnn.ConnectionString = Class.clsMain.CnnStr;
                cnn.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT ID_ADJUST_TYPE, ADJUST_TYPE, ENABLED FROM CAT_ADJUST_TYPE WHERE ID_ADJUST_TYPE=@ID_ADJUST_TYPE", cnn);

                //PARAMETERS
                cmd.Parameters.Add("@ID_ADJUST_TYPE", OleDbType.Integer).Value = prmID_ADJUST_TYPE;

                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtADJUST_TYPE.Text = dr["ADJUST_TYPE"].ToString();
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
        protected bool SaveItem(int prmID_ADJUST_TYPE, string prmADJUST_TYPE, int prmENABLED)
        {
            OleDbConnection cnn = new OleDbConnection();
            try
            {
                cnn.ConnectionString = Class.clsMain.CnnStr;
                cnn.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;

                if (prmID_ADJUST_TYPE == 0)
                {
                    //new
                    cmd.CommandText = "INSERT INTO CAT_ADJUST_TYPE([ADJUST_TYPE],[ENABLED]) VALUES (@ADJUST_TYPE,@ENABLED)";
                }
                else
                {
                    //edit
                    cmd.CommandText = "UPDATE CAT_ADJUST_TYPE SET [ADJUST_TYPE]=@ADJUST_TYPE,[ENABLED]=@ENABLED WHERE ID_ADJUST_TYPE=@ID_ADJUST_TYPE";
                }
                //PARAMETERS
                cmd.Parameters.Add("@ADJUST_TYPE", OleDbType.VarChar, 255).Value = prmADJUST_TYPE;
                cmd.Parameters.Add("@ENABLED", OleDbType.Boolean).Value = prmENABLED;
                cmd.Parameters.Add("@ID_ADJUST_TYPE", OleDbType.Integer).Value = prmID_ADJUST_TYPE;
                //MessageBox.Show(cmd.CommandText);
                cmd.ExecuteNonQuery();
                //Get the Identity ID
                if (prmID_ADJUST_TYPE == 0)
                {
                    cmd.CommandText = "SELECT @@IDENTITY";
                    varID_ADJUST_TYPE = Convert.ToInt32(cmd.ExecuteScalar());
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
                if (txtADJUST_TYPE.Text == "")
                {
                    MessageBox.Show("Faltan Datos", "Información del Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtADJUST_TYPE.BackColor = Color.Yellow;
                    txtADJUST_TYPE.Focus();
                    return;
                }
                if (SaveItem(varID_ADJUST_TYPE, txtADJUST_TYPE.Text,
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
