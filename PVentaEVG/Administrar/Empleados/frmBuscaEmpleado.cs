using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using POSDLL;

namespace POSApp.Forms
{
    public partial class frmBuscaEmpleado : Telerik.WinControls.UI.RadForm
    {
        public frmBuscaEmpleado()
        {
            InitializeComponent();
        }
        public static string varID_EMPLEADO = "";
        private void frmBuscaEmpleado_Load(object sender, EventArgs e)
        {
            Encabezados();
        }
        void lvEmpleados_DoubleClick(object sender, System.EventArgs e)
        {
            Empleado();
        }

        void lvEmpleados_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            Empleado();
        }
        private void Encabezados()
        {
            lvEmpleados.View = View.Details;
            lvEmpleados.Columns.Add("Clave de empleado", 0, HorizontalAlignment.Left);
            lvEmpleados.Columns.Add("Nombre", 300, HorizontalAlignment.Left);           

        }
        private void ReadData(string prmNOMBRE)
        {
            //Este procedimiento lee los datos que se tranferirán y los mostrará en forma de
            //lista en el ListView
            try
            {
                //Si la conexion esta abierta la cerramos; en caso contrario, la abrimos
                OleDbConnection cnnReadData = new OleDbConnection(Class.clsMain.CnnStr);
                if (cnnReadData.State == ConnectionState.Open) cnnReadData.Close(); else cnnReadData.Open();
                int I = 0;
                OleDbCommand cmdReadData = new OleDbCommand("SELECT ID_EMPLEADO, NOMBRE FROM vCAT_EMPLEADO" +
                    " WHERE NOMBRE like '%" + prmNOMBRE + "%'", cnnReadData);
                OleDbDataReader drReadData;
                drReadData = cmdReadData.ExecuteReader();
                lvEmpleados.Items.Clear();
                while (drReadData.Read())
                {
                    lvEmpleados.Items.Add(drReadData["ID_EMPLEADO"].ToString());
                    lvEmpleados.Items[I].SubItems.Add(drReadData["NOMBRE"].ToString());                    
                    I += 1;

                }
                lblInfo.Text = String.Format("Se encontraron {0} registro(s)", I);
                drReadData.Close();
                cmdReadData.Dispose();
                cnnReadData.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Empleado()
        {
            try
            {
                if (lvEmpleados.Items.Count != 0)
                {
                    varID_EMPLEADO = lvEmpleados.SelectedItems[0].Text;
                }
                else
                {
                    varID_EMPLEADO= "";
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("You must select an element from the list. "+
                    "\nError Description: \n" + ex.Message, 
                    "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ReadData(Strings.SafeSqlLikeClauseLiteral(txtNOMBRE.Text));
        }
        void txtNOMBRE_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ReadData(Strings.SafeSqlLikeClauseLiteral(txtNOMBRE.Text));
            }
        }
    }
}