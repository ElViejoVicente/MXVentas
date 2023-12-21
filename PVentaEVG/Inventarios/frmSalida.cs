using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POSDLL; using POSDLL.Windows.Forms; using POSDLL.Security; using POSDLL.Reporting; using POSDLL.Ticket;
using System.Data.OleDb;
namespace POSApp.Forms
{
    public partial class frmSalida : Telerik.WinControls.UI.RadForm
    {
        public frmSalida()
        {
            InitializeComponent();
        }
        public bool _Accion = false;
        private void frmSalida_Load(object sender, EventArgs e)
        {
            txtCANTIDAD.KeyPress += new KeyPressEventHandler(txtCANTIDAD_KeyPress);
            ReadData(frmLogin._USER_LOGIN);
        }

        void txtCANTIDAD_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
        private void btnBuscarEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaEmpleado _frmBuscaEmpleado = new frmBuscaEmpleado();
                _frmBuscaEmpleado.StartPosition = FormStartPosition.CenterScreen;
                _frmBuscaEmpleado.ShowDialog();
                if (!(frmBuscaEmpleado.varID_EMPLEADO == ""))
                {
                    txtID_EMPLEADO.Text = frmBuscaEmpleado.varID_EMPLEADO;
                    txtID_EMPLEADO.Focus();
                }
                _frmBuscaEmpleado.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnBuscar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtID_EMPLEADO.Text = "";
            }
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaProducto myForm = new frmBuscaProducto();
                myForm.StartPosition = FormStartPosition.CenterScreen;
                myForm.ShowDialog();
                if (!(myForm.producto.ID_PRODUCTO == ""))
                {
                    txtID_PRODUCTO.Text = myForm.producto.ID_PRODUCTO;
                }
                myForm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtID_PRODUCTO.Text = "";
            }
        }

        bool fnTempEntrada(string prmID_PRODUCTO, double prmCANTIDAD, string prmUSER_LOGIN) {
            try {
                double contar = 0;
                double existencia = 0;
                OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;
                //buscamos el articulo
                cmd.CommandText = "SELECT COUNT(*) FROM CAT_PRODUCTO WHERE ID_PRODUCTO='"+ prmID_PRODUCTO +"'";
                contar = Convert.ToDouble(cmd.ExecuteScalar());
                if (contar != 0)
                {
                    cmd.CommandText = "SELECT EXISTENCIA FROM CAT_PRODUCTO WHERE ID_PRODUCTO='" + prmID_PRODUCTO + "'";
                    existencia = Convert.ToDouble(cmd.ExecuteScalar());
                }
                else {
                    MessageBox.Show("El producto no existe", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                cmd.CommandText = "SELECT COUNT(*) FROM SALIDA_DETALLE_TEMP WHERE ID_PRODUCTO='"+ prmID_PRODUCTO +"' AND USER_LOGIN='"+ prmUSER_LOGIN +"'";
                contar = Convert.ToDouble(cmd.ExecuteScalar());
                if (contar == 0) { 
                    //nuevo
                    cmd.CommandText = "INSERT INTO SALIDA_DETALLE_TEMP(ID_PRODUCTO,CANTIDAD,USER_LOGIN,EXISTENCIA) VALUES('"+prmID_PRODUCTO +"',"+ prmCANTIDAD +",'"+ prmUSER_LOGIN +"',"+ existencia +")";
                }
                else { 
                    //editar
                    cmd.CommandText = "UPDATE SALIDA_DETALLE_TEMP SET CANTIDAD = CANTIDAD + " + prmCANTIDAD + ",EXISTENCIA="+ existencia +" WHERE ID_PRODUCTO='" + prmID_PRODUCTO + "' AND USER_LOGIN='" + prmUSER_LOGIN + "'";
                }
                
                cmd.ExecuteNonQuery();
                cnn.Close();
                cnn.Dispose();
                cmd.Dispose();

                return (true);
            }
            catch (Exception ex) {
                MessageBox.Show("Error\n" + ex.Message, "Información del Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false);
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (txtCANTIDAD.Text == "") {
                MessageBox.Show("Falta la cantidad" , "Información del Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCANTIDAD.Focus();
                return;
            }
            if (txtID_PRODUCTO.Text == "") {
                MessageBox.Show("Falta la clave de producto", "Información del Sistema",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtID_EMPLEADO.Focus();
                return;
            }
            if(fnTempEntrada(Strings.SafeSqlLikeClauseLiteral(txtID_PRODUCTO.Text),Convert.ToDouble(txtCANTIDAD.Text),frmLogin._USER_LOGIN)){
                ReadData(frmLogin._USER_LOGIN);
            }
        }
        void Encabezados() {
            lvArticulos.View = View.Details;
            lvArticulos.Columns.Clear();            
            lvArticulos.Items.Clear();
            lvArticulos.Columns.Add("id", 0);
            lvArticulos.Columns.Add("No", 45);
            lvArticulos.Columns.Add("Producto", 100, HorizontalAlignment.Left);
            lvArticulos.Columns.Add("Descripción", 250, HorizontalAlignment.Left);
            lvArticulos.Columns.Add("Existencia", 90, HorizontalAlignment.Right);
            lvArticulos.Columns.Add("Salida", 90, HorizontalAlignment.Right);
        }
        void ReadData(string prmUSER_LOGIN) {
            try {
                Encabezados();
                OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT T.FOLIO_SALIDA_DETALLE_TEMP,P.ID_PRODUCTO,P.DESC_PRODUCTO,T.CANTIDAD,T.EXISTENCIA"+
                    " FROM CAT_PRODUCTO P,SALIDA_DETALLE_TEMP T WHERE T.ID_PRODUCTO=P.ID_PRODUCTO AND T.USER_LOGIN='"+ prmUSER_LOGIN +"'", cnn);
                OleDbDataReader dr = cmd.ExecuteReader();
                int i = 0;
                while (dr.Read()) {
                    lvArticulos.Items.Add(dr["FOLIO_SALIDA_DETALLE_TEMP"].ToString());
                    lvArticulos.Items[i].SubItems.Add(String.Format("{0}", i + 1));
                    lvArticulos.Items[i].SubItems.Add(dr["ID_PRODUCTO"].ToString());
                    lvArticulos.Items[i].SubItems.Add(dr["DESC_PRODUCTO"].ToString());
                    lvArticulos.Items[i].SubItems.Add(String.Format("{0:N}",dr["EXISTENCIA"]));
                    lvArticulos.Items[i].SubItems.Add(String.Format("{0:N}", dr["CANTIDAD"]));
                    if (Convert.ToDouble(dr["EXISTENCIA"]) < Convert.ToDouble(dr["CANTIDAD"])) { 
                    //pintar de rojo la fila
                        lvArticulos.Items[i].ForeColor = Color.Red;
                        lvArticulos.Items[i].ToolTipText = "No hay suficientes existencias";
                    }
                    i++;
                }
                dr.Close();
                cnn.Close();
                cnn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Información del Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }
        bool fnSalida(string prmID_EMPLEADO, string prmFECHA_SALIDA, string prmOBSERVACIONES,string prmUSER_LOGIN) {
            try {
                OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
                cnn.Open();
                OleDbTransaction tran = cnn.BeginTransaction();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;
                cmd.Transaction = tran;
                //empezamos proceso de salida
                try {
                    //insertamos la salida
                    cmd.CommandText = "INSERT INTO SALIDA(FECHA_SALIDA,ID_EMPLEADO,OBSERVACIONES,USER_LOGIN)" +
                        " VALUES(#"+ prmFECHA_SALIDA +"#,'"+ prmID_EMPLEADO +"','"+ prmOBSERVACIONES +"','"+ prmUSER_LOGIN +"')";
                    cmd.ExecuteNonQuery();
                    //OBTENEMOS EL FOLIO DE LA SALIDA
                    cmd.CommandText = "SELECT @@IDENTITY";
                    int folioSalida = Convert.ToInt32(cmd.ExecuteScalar());
                    //INSERTAMOS EL DETALLE
                    cmd.CommandText = "INSERT INTO SALIDA_DETALLE(FOLIO_SALIDA,ID_PRODUCTO,CANTIDAD,EXISTENCIA)" +
                        "SELECT "+ folioSalida +",ID_PRODUCTO,CANTIDAD,EXISTENCIA FROM SALIDA_DETALLE_TEMP WHERE USER_LOGIN='"+ prmUSER_LOGIN +"'";
                    cmd.ExecuteNonQuery();
                    //ACTUALIZAMOS LAS EXISTENCIAS
                    cmd.CommandText = "UPDATE CAT_PRODUCTO INNER JOIN SALIDA_DETALLE_TEMP ON CAT_PRODUCTO.ID_PRODUCTO = SALIDA_DETALLE_TEMP.ID_PRODUCTO"+
                        " SET CAT_PRODUCTO.EXISTENCIA = CAT_PRODUCTO.EXISTENCIA-SALIDA_DETALLE_TEMP.CANTIDAD" +
                        " WHERE SALIDA_DETALLE_TEMP.USER_LOGIN='" + prmUSER_LOGIN + "'";
                    cmd.ExecuteNonQuery();
                    //BORRAMOS LA TABLA TEMPORAL
                    cmd.CommandText = "DELETE FROM SALIDA_DETALLE_TEMP WHERE USER_LOGIN='" + prmUSER_LOGIN + "'";
                    cmd.ExecuteNonQuery();

                }
                catch (OleDbException e) {
                    MessageBox.Show("Error en la transacción de salida\n" + e.Message, "Información del Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tran.Rollback();
                    cnn.Close();
                    return (false);
                }
                //terminamos proceso de salida
                tran.Commit();
                cnn.Close();
                cnn.Dispose();
                tran.Dispose();
                cmd.Dispose();
                MessageBox.Show("Salida registrada correctamente.","Información del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Information  );
                return (true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Información del Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtID_EMPLEADO.Text == "") {
                MessageBox.Show("Falta la clave del empleado", "Información del Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtID_EMPLEADO.Focus();
                return;
            }
            if (txtFECHA_SALIDA.Value > DateTime.Now) {
                MessageBox.Show("Error en la fecha de salida", "Información del Sistema",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFECHA_SALIDA.Focus();
                return;
            }
            if (fnSalida(Strings.SafeSqlLikeClauseLiteral(txtID_EMPLEADO.Text), 
                ISODates.MSAccessDateINI(txtFECHA_SALIDA.Value), 
                Strings.SafeSqlLikeClauseLiteral(txtOBSERVACIONES.Text), frmLogin._USER_LOGIN)) {
                _Accion = true;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
