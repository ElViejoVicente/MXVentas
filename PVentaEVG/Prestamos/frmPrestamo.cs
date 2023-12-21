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
    public partial class frmPrestamo : Telerik.WinControls.UI.RadForm
    {
        public frmPrestamo()
        {
            InitializeComponent();
        }
        bool succcess = false;
        public Boolean Success { get { return succcess; } }
        int varID_CAJA = 0;
        private void frmPrestamo_Load(object sender, EventArgs e)
        {
            mdiMain frm = new mdiMain();
   

            txtImporte.KeyPress += new KeyPressEventHandler(txtImporte_KeyPress);
            try {
                Inicializa();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
    
        }
        protected void Inicializa() {
            OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
            try {
                cnn.Open();
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT ID_EMPLEADO, NOMBRE+' '+PATERNO+' '+MATERNO AS EMPLEADO FROM CAT_EMPLEADO ORDER BY PATERNO,MATERNO,NOMBRE",cnn);
                DataTable dt= new DataTable();
                da.Fill(dt);
                cboID_EMPLEADO.DataSource = dt;
                cboID_EMPLEADO.DisplayMember = "EMPLEADO";
                cboID_EMPLEADO.ValueMember = "ID_EMPLEADO";
            }
            catch (Exception ex) { throw (ex); }
            finally { cnn.Close(); }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            succcess = false;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try {
                if (varID_CAJA == 0) {

                    throw (new Exception("no se seleccionó una caja"));
                 
                }
                if (txtImporte.Text == "") {
                    throw (new Exception("Error en el Importe no debe estar vacío"));
                }
                if (Convert.ToDouble(txtImporte.Text) <=0)
                {
                    throw(new Exception("Error en el Importe del Préstamo"));
                }
                succcess = Prestamo(cboID_EMPLEADO.SelectedValue.ToString(),Convert.ToDouble(txtImporte.Text));
                if (succcess) { this.Close(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected bool Prestamo(string prmID_EMPLEADO, double prmIMPORTE) {
            OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
            try
            {
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "INSERT INTO PRESTAMO(ID_EMPLEADO,USER_LOGIN,IMPORTE,ID_CAJA,FECHA_PRESTAMO) VALUES (@ID_EMPLEADO,@USER_LOGIN,@IMPORTE,@ID_CAJA,NOW())";
                cmd.Parameters.Add("@ID_EMPLEADO", OleDbType.VarChar, 50).Value = prmID_EMPLEADO;
                cmd.Parameters.Add("@USER_LOGIN", OleDbType.VarChar, 50).Value = frmLogin._USER_LOGIN;
                cmd.Parameters.Add("@IMPORTE", OleDbType.Double).Value = prmIMPORTE;
                cmd.Parameters.Add("@ID_CAJA", OleDbType.Integer).Value = varID_CAJA ;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex) { throw (ex); }
            finally { cnn.Close(); }
        }
    }
}
