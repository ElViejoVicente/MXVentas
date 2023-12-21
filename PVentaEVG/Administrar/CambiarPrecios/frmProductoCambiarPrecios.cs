using System;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace POSApp.Forms
{
    public partial class frmProductoCambiarPrecios : Telerik.WinControls.UI.RadForm
    {
        public frmProductoCambiarPrecios()
        {
            InitializeComponent();
        }

        private void frmProductoCambiarPrecios_Load(object sender, EventArgs e)
        {
            txtPORC.KeyPress += new KeyPressEventHandler(txtPORC_KeyPress);
            LoadCatalog("GRUPO", cboID_GRUPO);
        }

        void txtPORC_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
        protected void LoadCatalog(string prmTABLE, ComboBox cbo)
        {
            OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
            try
            {
                cbo.DataSource = null;
                cbo.Items.Clear();
                cbo.ValueMember = "";
                cbo.DisplayMember = "";
                cnn.Open();
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT ID_" + prmTABLE + ",DESC_" + prmTABLE + " FROM CAT_" + prmTABLE + " WHERE [ENABLED] = TRUE", cnn);
                DataSet dt = new DataSet();
                da.Fill(dt, prmTABLE);
                cbo.DataSource = dt.Tables[prmTABLE];
                cbo.ValueMember = "ID_" + prmTABLE;
                cbo.DisplayMember = "DESC_" + prmTABLE;
                da.Dispose();
                dt.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + prmTABLE, "Información del Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            CambiarPrecios();
        }
        protected void CambiarPrecios() {
            string ConfirmMsg = "";
            if (txtPORC.Text == "") {
                MessageBox.Show("Debe indicar el porcentaje", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double porcDesc = Convert.ToDouble(txtPORC.Text);
            if (Math.Abs(porcDesc)>=100)
            {
                MessageBox.Show("El porcentaje no puede ser mayor o igual a 100", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Math.Abs(porcDesc) ==0)
            {
                MessageBox.Show("El porcentaje no puede ser igual a cero", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (porcDesc > 0)
            {
                ConfirmMsg = String.Format("¿Realmente desea AUMENTAR el precio un {0} %?\nGrupo: {1}", Math.Abs(porcDesc).ToString(),cboID_GRUPO.Text);
            }
            else {
                ConfirmMsg = String.Format("¿Realmente desea REDUCIR el precio un {0} %?\nGrupo: {1}", Math.Abs(porcDesc).ToString(), cboID_GRUPO.Text);
            }
            
            try {
                DialogResult resp = MessageBox.Show(ConfirmMsg, "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.Yes)
                {
                    CambiarPrecios(porcDesc, Convert.ToInt32(cboID_GRUPO.SelectedValue), chkGrupo.Checked);
                    MessageBox.Show("Se modificaron los precios correctamente", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message , "Información del Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        protected void CambiarPrecios(double prmPorc, int prmIdGrupo,bool prmGrupo) {
            OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
            try {
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;
                if (prmGrupo)
                {
                    cmd.CommandText = "UPDATE CAT_PRODUCTO SET " +
                        " PRECIO_VENTA=(PRECIO_VENTA*(1+(" + prmPorc + "/100)))," +
                        " PRECIO_VENTA2=(PRECIO_VENTA2*(1+(" + prmPorc + "/100)))," +
                        " PRECIO_VENTA3=(PRECIO_VENTA3*(1+(" + prmPorc + "/100)))" +
                        " WHERE ID_GRUPO=@ID_GRUPO";
                    cmd.Parameters.Add("@ID_GRUPO", OleDbType.Integer).Value = prmIdGrupo;
                }
                else {
                    cmd.CommandText = "UPDATE CAT_PRODUCTO SET " +
                            " PRECIO_VENTA=(PRECIO_VENTA*(1+(" + prmPorc + "/100)))," +
                            " PRECIO_VENTA2=(PRECIO_VENTA2*(1+(" + prmPorc + "/100)))," +
                            " PRECIO_VENTA3=(PRECIO_VENTA3*(1+(" + prmPorc + "/100)))";
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally { cnn.Close(); }
        }

        private void chkGrupo_CheckedChanged(object sender, EventArgs e)
        {
            cboID_GRUPO.Enabled = chkGrupo.Checked;
        }
    }
}
