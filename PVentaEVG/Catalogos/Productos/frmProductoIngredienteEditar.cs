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
    public partial class frmProductoIngredienteEditar : Telerik.WinControls.UI.RadForm
    {
        public frmProductoIngredienteEditar(int prmID_PRODUCTO_INGREDIENTE)
        {
            InitializeComponent();
            varID_PRODUCTO_INGREDIENTE = prmID_PRODUCTO_INGREDIENTE;
        }
        int varID_PRODUCTO_INGREDIENTE;
        public bool _Accion = false;
        private void frmProductoIngredienteEditar_Load(object sender, EventArgs e)
        {
            txtCANTIDAD.KeyPress += new KeyPressEventHandler(txtCANTIDAD_KeyPress);
            ReadData(varID_PRODUCTO_INGREDIENTE);
        }

        void txtCANTIDAD_KeyPress(object sender, KeyPressEventArgs e)
        {
    
        }
        void ReadData(int prmID_PRODUCTO_INGREDIENTE)
        {
            try
            {
                OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT CANTIDAD FROM CAT_PRODUCTO_INGREDIENTES WHERE ID_PRODUCTO_INGREDIENTE="+ prmID_PRODUCTO_INGREDIENTE +"", cnn);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtCANTIDAD.Text = dr["CANTIDAD"].ToString();
                 
                }
                dr.Close();
                cnn.Close();
                cmd.Dispose();
                cnn.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool Grabar(int prmID_PRODUCTO_INGREDIENTE, double prmCANTIDAD)
        {
            try
            {
                OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
                cnn.Open();
                string varSQL = "UPDATE CAT_PRODUCTO_INGREDIENTES SET CANTIDAD="+ prmCANTIDAD +" WHERE ID_PRODUCTO_INGREDIENTE="+ prmID_PRODUCTO_INGREDIENTE +"";
                OleDbCommand cmd = new OleDbCommand(varSQL, cnn);
                cmd.ExecuteNonQuery();
                
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
        bool Eliminar(int prmID_PRODUCTO_INGREDIENTE)
        {
            try
            {
                OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
                cnn.Open();
                string varSQL = "DELETE FROM CAT_PRODUCTO_INGREDIENTES  WHERE ID_PRODUCTO_INGREDIENTE=" + prmID_PRODUCTO_INGREDIENTE + "";
                OleDbCommand cmd = new OleDbCommand(varSQL, cnn);
                cmd.ExecuteNonQuery();

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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try {
                //grabar
                if (Grabar(varID_PRODUCTO_INGREDIENTE, Convert.ToInt32(txtCANTIDAD.Text))) {
                    _Accion = true;
                    MessageBox.Show("Información Actualizada correctamente", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try {
                DialogResult resp = MessageBox.Show("¿Desea eliminar el registro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.Yes) { 
                //eliminar
                    if (Eliminar(varID_PRODUCTO_INGREDIENTE)) {
                        _Accion = true;
                        MessageBox.Show("El registro se eliminó correctamente", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
