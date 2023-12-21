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
    public partial class frmProductoIngredientes : Telerik.WinControls.UI.RadForm
    {
        public frmProductoIngredientes(string prmID_PRODUCTO, string prmDESC_PRODUCTO)
        {
            InitializeComponent();
            varID_PRODUCTO_PADRE = prmID_PRODUCTO;
            lblTitulo.Text = String.Format("INGREDIENTES DE: \"{0}\"", prmDESC_PRODUCTO);
            
        }
        string varID_PRODUCTO_PADRE = "";
        private void frmProductoIngredientes_Load(object sender, EventArgs e)
        {
            txtCANTIDAD.KeyPress += new KeyPressEventHandler(txtCANTIDAD_KeyPress);
            lvIngredientes.DoubleClick += new EventHandler(lvIngredientes_DoubleClick);
            Encabezados();
            ReadData(varID_PRODUCTO_PADRE);
        }

        void lvIngredientes_DoubleClick(object sender, EventArgs e)
        {
            try {
                
                if (lvIngredientes.SelectedItems.Count != 0)
                {
                    int varID_PRODUCTO_INGREDIENTE = Convert.ToInt32(lvIngredientes.SelectedItems[0].Text);
                    //aqui mandamos llamr la ventana de editar
                    frmProductoIngredienteEditar frm = new frmProductoIngredienteEditar(varID_PRODUCTO_INGREDIENTE);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
                    if (frm._Accion) {
                        ReadData(varID_PRODUCTO_PADRE);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Encabezados() {
            lvIngredientes.Clear();
            lvIngredientes.View = View.Details;
            lvIngredientes.Columns.Add("Id",0);
            lvIngredientes.Columns.Add("Articulo", 80,HorizontalAlignment.Left);
            lvIngredientes.Columns.Add("Descripción", 300, HorizontalAlignment.Left);
            lvIngredientes.Columns.Add("Medida", 100, HorizontalAlignment.Left);
            lvIngredientes.Columns.Add("Cantidad", 80, HorizontalAlignment.Right);
        }

        void ReadData(string prmID_PRODUCTO_PADRE) {
            try {
                OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT ID_PRODUCTO_INGREDIENTE,I.ID_PRODUCTO,P.DESC_PRODUCTO,I.CANTIDAD,M.DESC_UNIDAd_MEDIDA " +
                    " FROM CAT_PRODUCTO P, CAT_PRODUCTO_INGREDIENTES I,CAT_UNIDAd_MEDIDA M "+
                    " WHERE P.ID_PRODUCTO=I.ID_PRODUCTO AND M.ID_UNIDAD_MEDIDA=P.ID_UNIDAD_MEDIDA AND I.ID_PRODUCTO_PADRE='"+ prmID_PRODUCTO_PADRE +"'", cnn);
                OleDbDataReader dr = cmd.ExecuteReader();
                int I = 0;
                lvIngredientes.Items.Clear();
                while (dr.Read()) {
                    lvIngredientes.Items.Add(dr["ID_PRODUCTO_INGREDIENTE"].ToString());
                    lvIngredientes.Items[I].SubItems.Add(dr["ID_PRODUCTO"].ToString());
                    lvIngredientes.Items[I].SubItems.Add(dr["DESC_PRODUCTO"].ToString());
                    lvIngredientes.Items[I].SubItems.Add(dr["DESC_UNIDAD_MEDIDA"].ToString());
                    lvIngredientes.Items[I].SubItems.Add(String.Format("{0:N}",dr["CANTIDAD"]));
                    I++;
                }
                dr.Close();
                cnn.Close();
                cmd.Dispose();
                cnn.Dispose();
            
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool Agregar(string prmID_PRODUCTO_PADRE,string prmID_PRODUCTO, double prmCANTIDAD)
        {
            try
            {
                OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
                cnn.Open();
                string varSQL = "SELECT COUNT(ID_PRODUCTO) FROM CAT_PRODUCTO_INGREDIENTES "+
                    " WHERE ID_PRODUCTO='"+ prmID_PRODUCTO +"' AND ID_PRODUCTO_PADRE='"+ prmID_PRODUCTO_PADRE +"'";
                OleDbCommand cmd = new OleDbCommand(varSQL, cnn);
                int contador = Convert.ToInt32(cmd.ExecuteScalar());
                if (contador == 0)
                {
                    cmd.CommandText = "INSERT INTO CAT_PRODUCTO_INGREDIENTES(ID_PRODUCTO_PADRE,ID_PRODUCTO,CANTIDAD) " +
                          " VALUES ('" + prmID_PRODUCTO_PADRE + "','" + prmID_PRODUCTO + "'," + prmCANTIDAD + ")";
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("No se puede duplicar el producto. " +
                     "\nSi desea modificar la cantidad, de doble clic sobre el elemento de la lista para editar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
                cnn.Close();
                cmd.Dispose();
                cnn.Dispose();
                return (true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false);
            }
        }
        void txtCANTIDAD_KeyPress(object sender, KeyPressEventArgs e)
        {
     
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtID_PRODUCTO.Text == "") || (txtCANTIDAD.Text == ""))
                {
                    MessageBox.Show("Falta la clave del producto o la cantidad", 
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (varID_PRODUCTO_PADRE == txtID_PRODUCTO.Text) {
                    MessageBox.Show("La clave del producto padre y el hijo son iguales",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Agregar(varID_PRODUCTO_PADRE, txtID_PRODUCTO.Text, Convert.ToDouble(txtCANTIDAD.Text)))
                {
                    ReadData(varID_PRODUCTO_PADRE);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
