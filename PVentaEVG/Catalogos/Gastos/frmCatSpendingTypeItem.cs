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
    public partial class frmCatSpendingTypeItem : Telerik.WinControls.UI.RadForm
    {
        int varID_SPENDING_TYPE = 0;
        bool varACTION_SUCCESS = false;
        /// <summary>
        /// Gets ID_SPENDING_TYPE (Read Only)
        /// </summary>
        public int ID_ID_SPENDING_TYPE {
            get { return varID_SPENDING_TYPE; }
        }
        public bool ACTION_SUCCESS {
            get { return varACTION_SUCCESS; }
        }

        public frmCatSpendingTypeItem(int prmID_SPENDING_TYPE)
        {
            InitializeComponent();
            varID_SPENDING_TYPE = prmID_SPENDING_TYPE;
        }

        private void frmCatSpendingTypeItem_Load(object sender, EventArgs e)
        {
            try
            {
                if (varID_SPENDING_TYPE != 0)
                {
                    FindByValue(varID_SPENDING_TYPE);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected void FindByValue(int prmID_GROUP)
        {
            OleDbConnection cnn = new OleDbConnection();
            try
            {
                cnn.ConnectionString = Class.clsMain.CnnStr;
                cnn.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT ID_SPENDING_TYPE, SPENDING_TYPE, ENABLED FROM CAT_SPENDING_TYPE WHERE ID_SPENDING_TYPE=@ID_SPENDING_TYPE", cnn);

                //PARAMETERS
                cmd.Parameters.Add("@ID_SPENDING_TYPE", OleDbType.Integer).Value = prmID_GROUP;

                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtSPENDING_TYPE.Text = dr["SPENDING_TYPE"].ToString();
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
        protected bool SaveItem(int prmID_SPENDING_TYPE, string prmSPENDING_TYPE, int prmENABLED)
        {
            OleDbConnection cnn = new OleDbConnection();
            try
            {
                cnn.ConnectionString = Class.clsMain.CnnStr;
                cnn.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;

                if (prmID_SPENDING_TYPE == 0)
                {
                    //new
                    cmd.CommandText = "INSERT INTO CAT_SPENDING_TYPE([SPENDING_TYPE],[ENABLED]) VALUES (@SPENDING_TYPE,@ENABLED)";
                }
                else
                {
                    //edit
                    cmd.CommandText = "UPDATE CAT_SPENDING_TYPE SET [SPENDING_TYPE]=@SPENDING_TYPE,[ENABLED]=@ENABLED WHERE ID_SPENDING_TYPE=@ID_SPENDING_TYPE";
                }
                //PARAMETERS
                cmd.Parameters.Add("@SPENDING_TYPE", OleDbType.VarChar, 255).Value = prmSPENDING_TYPE;
                cmd.Parameters.Add("@ENABLED", OleDbType.Boolean).Value = prmENABLED;
                cmd.Parameters.Add("@ID_SPENDING_TYPE", OleDbType.Integer).Value = prmID_SPENDING_TYPE;
                //MessageBox.Show(cmd.CommandText);
                cmd.ExecuteNonQuery();
                //Get the Identity ID
                if (prmID_SPENDING_TYPE == 0)
                {
                    cmd.CommandText = "SELECT @@IDENTITY";
                    varID_SPENDING_TYPE = Convert.ToInt32(cmd.ExecuteScalar());
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
                if (txtSPENDING_TYPE.Text == "")
                {
                    MessageBox.Show("Faltan Datos", "Información del Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSPENDING_TYPE.BackColor = Color.Yellow;
                    txtSPENDING_TYPE.Focus();
                    return;
                }
                if (SaveItem(varID_SPENDING_TYPE, txtSPENDING_TYPE.Text,
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
