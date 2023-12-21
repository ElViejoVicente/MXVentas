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
    public partial class frmEntradaTemp : Telerik.WinControls.UI.RadForm
    {
        public frmEntradaTemp(string prmFOLIO_FACTURA, string prmUSER_LOGIN)
        {
            InitializeComponent();
            //
            // Nuevo registro
            //      
            varUSER_LOGIN = prmUSER_LOGIN;
            varFOLIO_FACTURA = prmFOLIO_FACTURA;
            varID_PRODUCTO = "";
        }
        public frmEntradaTemp(int prmID)
        {
            //
            // Modificar registro
            //
            InitializeComponent();
            btnSearchProduct.Enabled = false;
            txtID_PRODUCTO.ReadOnly = true;
            this.Text = "Modificar Entrada";
            varID = prmID;
        }
        
        
        string varUSER_LOGIN = "";
        string varFOLIO_FACTURA = "";
        string varID_PRODUCTO = "";
        int varID = 0;
        private void frmTempEntrada_Load(object sender, EventArgs e)
        {
            
                //Significa que es una actualización
                ReadData(varID);
            
        }
        void txtID_PRODUCTO_LostFocus(object sender, System.EventArgs e)
        {
            CheckProduct();
        }

        void txtID_PRODUCTO_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {                
                CheckProduct();                
            }
        }
        void CheckProduct() {
            try
            {
                if (varID_PRODUCTO == "")
                {
                    //es nuevo
                    if (txtID_PRODUCTO.Text != "")
                    {
                        if (!Class.clsProducto.FindProduct(Strings.SafeSqlLikeClauseLiteral(txtID_PRODUCTO.Text)))
                        {
                            MessageBox.Show("El producto no existe en el catalogo.","Información del Sistema");
                            txtID_PRODUCTO.Text = "";                            
                        }
                        else
                        {
                            txtCANTIDAD.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void ReadData(int prmID)
        {
            try
            {
                OleDbConnection cnnReadData = new OleDbConnection(Class.clsMain.CnnStr);
                string varSQL = "SELECT ID_PRODUCTO,CANTIDAD,PRECIO,IMPUESTO FROM TEMP_ENTRADA WHERE ID_TEMP_ENTRADA ="+ prmID +"";
                OleDbCommand cmdReadData = new OleDbCommand(varSQL, cnnReadData);
                OleDbDataReader drReadData;
                if (cnnReadData.State == ConnectionState.Open)
                    cnnReadData.Close();
                cnnReadData.Open();
                drReadData = cmdReadData.ExecuteReader();
                drReadData.Read();
                //mostramos los datos
                txtID_PRODUCTO.Text = drReadData["ID_PRODUCTO"].ToString();
                txtCANTIDAD.Text = drReadData["CANTIDAD"].ToString();
                txtPRECIO.Text = drReadData["PRECIO"].ToString();
                txtIMPUESTO.Text = drReadData["IMPUESTO"].ToString();
                drReadData.Close();
                cmdReadData.Dispose();
                cnnReadData.Close();
                cnnReadData.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
      
        private void Update(int prmID, double prmCANTIDAD, double prmPRECIO, double prmIMPUESTO)
        {
            //Para agregar Nuevo
            string varSQL = "UPDATE TEMP_ENTRADA SET " +
                " CANTIDAD=" + prmCANTIDAD + ",PRECIO=" + prmPRECIO + ",IMPUESTO=" + prmIMPUESTO + " " +
                " WHERE ID_TEMP_ENTRADA="+ prmID +"";
            try
            {
                OleDbConnection cnnUpdate = new OleDbConnection(Class.clsMain.CnnStr);
                if (cnnUpdate.State == ConnectionState.Open)
                    cnnUpdate.Close();
                cnnUpdate.Open();
                OleDbCommand cmdUpdate = new OleDbCommand(varSQL, cnnUpdate);
                cmdUpdate.ExecuteNonQuery();
                cmdUpdate.Dispose();
                cnnUpdate.Close();
                cnnUpdate.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validaciones())
                {
                    
                    
                        Update(varID, Convert.ToDouble(txtCANTIDAD.Text), Convert.ToDouble(txtPRECIO.Text), Convert.ToDouble(txtIMPUESTO.Text));
                        this.Close();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool Validaciones()
        {
            try
            {
                if (Convert.ToString(Strings.SafeSqlLikeClauseLiteral(txtID_PRODUCTO.Text)) == "" || Convert.ToString(txtCANTIDAD.Text) == "" | Convert.ToString(txtPRECIO.Text) == "" | Convert.ToString(txtIMPUESTO.Text) == "")
                {
                    //verificar que los campos no estén vacios
                    MessageBox.Show("Debe llenar todos los campos", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return (false);
                }
                else
                {
                    if (fnBuscaProducto(Strings.SafeSqlLikeClauseLiteral(txtID_PRODUCTO.Text)))
                    {
                        if ((Convert.ToDouble(txtCANTIDAD.Text) == 0) || (Convert.ToDouble(txtPRECIO.Text) == 0))
                        {
                            MessageBox.Show("Cantidad y recio no pueden ser cero (0)", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return (false);
                        }
                        else
                        {
                            return (true);
                        }
                    }
                    else
                    {
                        return (false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false);
            }
        }
        private bool fnBuscaProducto(string prmID_PRODUCTO)
        {

            try
            {
                if (prmID_PRODUCTO == "")
                {
                    MessageBox.Show("Falta la clave del producto", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return (false);
                }
                else
                {
                    OleDbConnection cnnBuscaProducto = new OleDbConnection(Class.clsMain.CnnStr);
                    cnnBuscaProducto.Open();
                    string varSQL = "SELECT ID_PRODUCTO FROM CAT_PRODUCTO WHERE ID_PRODUCTO = '" + prmID_PRODUCTO + "'";
                    DataSet dsBuscaProducto = new DataSet("dsBuscaProducto");
                    dsBuscaProducto.Clear();
                    OleDbDataAdapter daBuscaProducto = new OleDbDataAdapter(varSQL, cnnBuscaProducto);
                    daBuscaProducto.Fill(dsBuscaProducto, "CAT_PRODUCTO");
                    if (dsBuscaProducto.Tables["CAT_PRODUCTO"].Rows.Count == 0)
                    {
                        //No existe
                        MessageBox.Show("No se encontró el producto", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        dsBuscaProducto.Clear();
                        dsBuscaProducto.Dispose();
                        daBuscaProducto.Dispose();
                        cnnBuscaProducto.Close();
                        cnnBuscaProducto.Dispose();
                        return (false);
                    }
                    else
                    {
                        //Si existe						
                        dsBuscaProducto.Clear();
                        dsBuscaProducto.Dispose();
                        daBuscaProducto.Dispose();
                        cnnBuscaProducto.Close();
                        cnnBuscaProducto.Dispose();
                        return (true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtID_PRODUCTO.Text = "";
            }
        }


    }
}