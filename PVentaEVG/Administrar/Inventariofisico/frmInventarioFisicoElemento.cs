using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSDLL; using POSDLL.Windows.Forms; using POSDLL.Security; using POSDLL.Reporting; using POSDLL.Ticket;
namespace POSApp.Forms
{
    public partial class frmInventarioFisicoElemento : Telerik.WinControls.UI.RadForm
    {
        public frmInventarioFisicoElemento()
        {
            InitializeComponent();
        }
        public frmInventarioFisicoElemento(string prmID_PRODUCTO)
        {
            InitializeComponent();
            
            varID_PRODUCTO = prmID_PRODUCTO;
            txtID_PRODUCTO.Text = varID_PRODUCTO;
            string Info =
                       Class.clsProducto.FindProductDetailsString(Strings.SafeSqlLikeClauseLiteral(txtID_PRODUCTO.Text));
            lblDetails.Text = Info;

        }
        string varID_PRODUCTO = "";
        public static bool _Accion = false;
        private void btnBuscaProducto_Click(object sender, EventArgs e)
        {
            BuscaProducto();
        }
        void BuscaProducto()
        {
            try
            {

                frmBuscaProducto myForm = new frmBuscaProducto();
                myForm.StartPosition = FormStartPosition.CenterScreen;
                myForm.ShowDialog();
                if (!(myForm.producto.ID_PRODUCTO == ""))
                {
                    txtID_PRODUCTO.Text = myForm.producto.ID_PRODUCTO;
                    if (txtID_PRODUCTO.Text != "")
                    {
                        string Info =
                            Class.clsProducto.FindProductDetailsString(Strings.SafeSqlLikeClauseLiteral(txtID_PRODUCTO.Text));
                        lblDetails.Text = Info;
                    }
                    txtCANTIDAD_AJUSTE.Focus();
                }
                myForm.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnBuscaProducto",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtID_PRODUCTO.Text = "";
            }
        }

        private void frmInventarioFisicoElemento_Load(object sender, EventArgs e)
        {
            txtID_PRODUCTO.LostFocus += new EventHandler(txtID_PRODUCTO_LostFocus);
            txtCANTIDAD_AJUSTE.KeyPress += new KeyPressEventHandler(txtCANTIDAD_AJUSTE_KeyPress);
            txtID_PRODUCTO.KeyPress += new KeyPressEventHandler(txtID_PRODUCTO_KeyPress);
        }

        void txtID_PRODUCTO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtCANTIDAD_AJUSTE.Focus();
            }
        }

        void txtCANTIDAD_AJUSTE_KeyPress(object sender, KeyPressEventArgs e)
        {
     
            
        }
        bool fnTempInventariofisico(string prmID_PRODUCTO,string prmUSER_LOGIN,double prmCANTIDAD) {
            try {
                OleDbConnection cnnTemp = new OleDbConnection(Class.clsMain.CnnStr);
                cnnTemp.Open();
                OleDbTransaction TRAN = cnnTemp.BeginTransaction();
                string varSQL="";
                OleDbCommand cmdTemp = new OleDbCommand();
                cmdTemp.Connection = cnnTemp;
                cmdTemp.Transaction = TRAN;
                varSQL = "SELECT COUNT(*) FROM CAT_PRODUCTO " +
                     " WHERE ID_PRODUCTO='" + prmID_PRODUCTO + "'";
                cmdTemp.CommandText = varSQL;
                try
                {
                    if (Convert.ToInt32(cmdTemp.ExecuteScalar()) != 0)
                    {
                        varSQL = "SELECT COUNT(*) FROM TEMP_INVENTARIO_FISICO " +
                         " WHERE ID_PRODUCTO='" + prmID_PRODUCTO + "'";
                        cmdTemp.CommandText = varSQL;
                        if (Convert.ToInt32(cmdTemp.ExecuteScalar()) == 0)
                        {
                            //nuevo
                            varSQL = "INSERT INTO TEMP_INVENTARIO_FISICO(ID_PRODUCTO,USER_LOGIN,CANTIDAD)" +
                                " VALUES('" + prmID_PRODUCTO + "','" + prmUSER_LOGIN + "'," + prmCANTIDAD + ")";
                        }
                        else
                        {
                            //editar
                            varSQL = "UPDATE TEMP_INVENTARIO_FISICO SET CANTIDAD=" + prmCANTIDAD + "," +
                               " USER_LOGIN='" + prmUSER_LOGIN + "'" +
                               " WHERE ID_PRODUCTO='" + prmID_PRODUCTO + "'";
                        }
                        cmdTemp.CommandText = varSQL;
                        cmdTemp.ExecuteNonQuery();

                        //cantidad_antes,precio_compra,precio_venta
                        varSQL = "UPDATE TEMP_INVENTARIO_FISICO " +
                        " INNER JOIN CAT_PRODUCTO ON CAT_PRODUCTO.ID_PRODUCTO = TEMP_INVENTARIO_FISICO.ID_PRODUCTO " +
                        " SET TEMP_INVENTARIO_FISICO.CANTIDAD_ANTES = [CAT_PRODUCTO].[EXISTENCIA]," +
                        " TEMP_INVENTARIO_FISICO.PRECIO_COMPRA = [CAT_PRODUCTO].[PRECIO_COMPRA]," +
                        " TEMP_INVENTARIO_FISICO.PRECIO_VENTA = [CAT_PRODUCTO].[PRECIO_VENTA]" +
                        " WHERE CAT_PRODUCTO.ID_PRODUCTO ='"+ prmID_PRODUCTO +"'";
                        cmdTemp.CommandText = varSQL;
                        cmdTemp.ExecuteNonQuery();
                    }
                    TRAN.Commit();
                }
                catch(Exception ex) {
                    MessageBox.Show(ex.Message, "fnTempInventariofisico",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TRAN.Rollback();
                }
                cnnTemp.Close();
                cmdTemp.Dispose();
                cnnTemp.Dispose();
                return (true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "fnTempInventariofisico",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false);
            }
        }
        void txtID_PRODUCTO_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (txtID_PRODUCTO.Text != "")
                {
                    string Info =
                        Class.clsProducto.FindProductDetailsString(Strings.SafeSqlLikeClauseLiteral(txtID_PRODUCTO.Text));
                    lblDetails.Text = Info;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnBuscaProducto",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtID_PRODUCTO.Text = "";
            }
        }

        private void btnCANCEL_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtCANTIDAD_AJUSTE.Text != "") && (txtID_PRODUCTO.Text != ""))
                {
                    _Accion =
                        fnTempInventariofisico(Strings.SafeSqlLikeClauseLiteral(txtID_PRODUCTO.Text),
                        frmLogin._USER_LOGIN,
                        Convert.ToDouble(txtCANTIDAD_AJUSTE.Text));
                    if (_Accion)
                    {
                        this.Close();
                    }
                }
                else {
                    MessageBox.Show("La clave del articulo y la cantidad son obligatorios", "btnOK_Click",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnOK_Click",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }
    }
}