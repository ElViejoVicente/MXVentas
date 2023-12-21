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
    public partial class frmCatMeasurmentUnitItem : Telerik.WinControls.UI.RadForm
    {
        int varID_UNIDAD_MEDIDA = 0;
        bool varACTION_SUCCESS = false;
        /// <summary>
        /// Gets ID_UNIDAD_MEDIDA (Read Only)
        /// </summary>
        public int ID_UNIDAD_MEDIDA
        {
            get { return varID_UNIDAD_MEDIDA; }
        }
        public bool ACTION_SUCCESS
        {
            get { return varACTION_SUCCESS; }
        }
        public frmCatMeasurmentUnitItem(int prmID_UNIDAD_MEDIDA)
        {
            InitializeComponent();
            varID_UNIDAD_MEDIDA = prmID_UNIDAD_MEDIDA;
        }

        private void frmCatMeasurmentUnitItem_Load(object sender, EventArgs e)
        {
            try
            {
                if (varID_UNIDAD_MEDIDA != 0)
                {
                    FindByValue(varID_UNIDAD_MEDIDA);
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

                OleDbCommand cmd = new OleDbCommand("SELECT ID_UNIDAD_MEDIDA, DESC_UNIDAD_MEDIDA, ENABLED FROM CAT_UNIDAD_MEDIDA WHERE ID_UNIDAD_MEDIDA=@ID_UNIDAD_MEDIDA", cnn);

                //PARAMETERS
                cmd.Parameters.Add("@ID_UNIDAD_MEDIDA", OleDbType.Integer).Value = prmID_GROUP;

                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtUNIDAD_MEDIDA.Text = dr["DESC_UNIDAD_MEDIDA"].ToString();
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
        protected bool SaveItem(int prmID_UNIDAD_MEDIDA, string prmUNIDAD_MEDIDA, int prmENABLED)
        {
            OleDbConnection cnn = new OleDbConnection();
            try
            {
                cnn.ConnectionString = Class.clsMain.CnnStr;
                cnn.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;

                if (prmID_UNIDAD_MEDIDA == 0)
                {
                    //new
                    cmd.CommandText = "INSERT INTO CAT_UNIDAD_MEDIDA([DESC_UNIDAD_MEDIDA],[ENABLED]) VALUES (@UNIDAD_MEDIDA,@ENABLED)";
                }
                else
                {
                    //edit
                    cmd.CommandText = "UPDATE CAT_UNIDAD_MEDIDA SET [DESC_UNIDAD_MEDIDA]=@UNIDAD_MEDIDA,[ENABLED]=@ENABLED WHERE ID_UNIDAD_MEDIDA=@ID_UNIDAD_MEDIDA";
                }
                //PARAMETERS
                cmd.Parameters.Add("@UNIDAD_MEDIDA", OleDbType.VarChar, 255).Value = prmUNIDAD_MEDIDA;
                cmd.Parameters.Add("@ENABLED", OleDbType.Boolean).Value = prmENABLED;
                cmd.Parameters.Add("@ID_UNIDAD_MEDIDA", OleDbType.Integer).Value = prmID_UNIDAD_MEDIDA;
                //MessageBox.Show(cmd.CommandText);
                cmd.ExecuteNonQuery();
                //Get the Identity ID
                if (prmID_UNIDAD_MEDIDA == 0)
                {
                    cmd.CommandText = "SELECT @@IDENTITY";
                    varID_UNIDAD_MEDIDA = Convert.ToInt32(cmd.ExecuteScalar());
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
                if (txtUNIDAD_MEDIDA.Text == "")
                {
                    MessageBox.Show("Faltan Datos", "Información del Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUNIDAD_MEDIDA.BackColor = Color.Yellow;
                    txtUNIDAD_MEDIDA.Focus();
                    return;
                }
                if (SaveItem(varID_UNIDAD_MEDIDA, txtUNIDAD_MEDIDA.Text,
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
