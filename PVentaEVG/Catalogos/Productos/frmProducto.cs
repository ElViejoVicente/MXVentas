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
    public partial class frmProducto : Telerik.WinControls.UI.RadForm
    {

        public frmProducto( string prmID_PRODUCTO)
        {
            InitializeComponent();
            producto = new Class.clsProducto(prmID_PRODUCTO);
    
        }

        public Class.clsProducto producto;

        bool _Mostrar = false;
      
        string varID_PRODUCTO = "";
        DataSet dsInicializa = new DataSet();
        //Para manipular el ini
        bool ciclar = false;
        public Boolean Ciclar { get { return ciclar; } }
        public String ID_PRODUCTO { get { return varID_PRODUCTO; } }
        double precioVenta = 0;
        public double PrecioVenta { get { return precioVenta; } }
        double precioVenta2 = 0;
        public double PrecioVenta2 { get { return precioVenta2; } }
        double precioVenta3 = 0;
        public double PrecioVenta3 { get { return precioVenta3; } }
        private void frmProducto_Load(object sender, EventArgs e)
        {
            //iva
            varID_PRODUCTO = producto.ID_PRODUCTO;
            chkIVA.Checked = Convert.ToBoolean(AppSettings.GetValue("frmProducto", "IVA", "true"));
            if (chkIVA.Checked)
            {
                txtIMPUESTO.Enabled = true;
                txtIMPUESTO.Text = "0.16";

            }
            else
            {
                txtIMPUESTO.Enabled = false;
                txtIMPUESTO.Text = "0";
            }

            
            ciclar = false;
            chkVENDER_SIN_EXISTENCIA.Checked = frmLogin._ADMINISTRAR;
            txtPRECIO_VENTA2.KeyPress += new KeyPressEventHandler(txtPRECIO_VENTA2_KeyPress);
            txtPRECIO_VENTA3.KeyPress += new KeyPressEventHandler(txtPRECIO_VENTA3_KeyPress);
            txtPRECIO_VENTA.KeyPress+=new KeyPressEventHandler(txtPRECIO_VENTA_KeyPress);
            LoadCatalog("MARCA", cboID_MARCA);
            LoadCatalog("GRUPO", cboID_GRUPO);
            LoadCatalog("UNIDAD_MEDIDA", cboID_UNIDAD_MEDIDA);
            Inicializa();
            if(varID_PRODUCTO!=""){
                txtID_PRODUCTO.Enabled = false;
                btnVerProveedores.Visible = true;
                txtEXISTENCIA.Enabled = false;
                MostrarDatos();
            }
           
        }
        void MostrarDatos() {
            //mostrar datos
            btnVerProveedores.Visible = true;
            txtID_PRODUCTO.Text = producto.ID_PRODUCTO;
            txtDESC_PRODUCTO.Text = producto.DESC_PRODUCTO;

            txtEXISTENCIA.Text = String.Format("{0:N}", producto.EXISTENCIA);
            txtPRECIO_VENTA.Text = String.Format("{0:N}", producto.PRECIO_VENTA);
            txtPRECIO_VENTA2.Text = String.Format("{0:N}", producto.PRECIO_VENTA2);
            txtPRECIO_VENTA3.Text = String.Format("{0:N}", producto.PRECIO_VENTA3);

            txtPRECIO_COMPRA.Text = String.Format("{0:N}", producto.PRECIO_COMPRA);
            txtIMPUESTO.Text = String.Format("{0:N}", producto.IMPUESTO);
            cboID_GRUPO.SelectedValue = producto.ID_GRUPO;
            cboID_MARCA.SelectedValue = producto.ID_MARCA;
            cboID_UNIDAD_MEDIDA.Text = producto.UNIDAD_MEDIDA;
            txtCANT_MAX.Text = String.Format("{0:N}", producto.CANT_MAX);
            txtCANT_MIN.Text = String.Format("{0:N}", producto.CANT_MIN);
            txtCVE_PROVEEDOR.Text = producto.CVE_PROVEEDOR;
            chkC_BARRAS.Checked = producto.C_BARRAS;
            txtNOMBRES_CO.Text = producto.NOMBRES_CO;

            txtPORC_DESCUENTO.Text = String.Format("{0:N}", producto.DESCUENTO);
            chkVENDER_SIN_EXISTENCIA.Checked = producto.VENDER_SIN_EXISTENCIA;
            txtLOCALIZACION.Text = producto.LOCALIZACION;
            chkHABILITAR_VENTA.Checked = !producto.HABILITAR_VENTA;
        }
        void txtPRECIO_VENTA3_KeyPress(object sender, KeyPressEventArgs e)
        {
         
        }

        void txtPRECIO_VENTA2_KeyPress(object sender, KeyPressEventArgs e)
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
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT ID_" + prmTABLE + ",DESC_" + prmTABLE + " FROM CAT_" + prmTABLE + " WHERE [ENABLED] = TRUE ORDER BY DESC_" + prmTABLE + "", cnn);
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
        private void Inicializa() {
            try {
               
                //abarrotes/farmacia


              
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

       
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ciclar = false;
            this.Close();
        }
        void txtID_PRODUCTO_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDESC_PRODUCTO.Focus();
            }
        }
        void txtID_PRODUCTO_LostFocus(object sender, System.EventArgs e)
        {
            if (txtID_PRODUCTO.Text != "")
            {
                CheckProduct();
            }
        }
        void CheckProduct() {
            try
            {
                if (varID_PRODUCTO == "")
                {
                    if (Class.clsProducto.FindProduct(txtID_PRODUCTO.Text))
                    {
                        if (!_Mostrar)
                        {
                            DialogResult Resp = new DialogResult();
                            Resp = MessageBox.Show("El producto ya existe.\n¿Desea Mostrarlo?",  "Información del Sistema",   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (Resp == DialogResult.Yes)
                            {
                                _Mostrar = true;
                                varID_PRODUCTO = txtID_PRODUCTO.Text;
                                producto.Buscar(varID_PRODUCTO);
                                MostrarDatos();
                                txtID_PRODUCTO.Enabled = false;
                                txtDESC_PRODUCTO.Focus();
                                txtEXISTENCIA.Enabled = false;
                            }
                            else
                            {
                                txtID_PRODUCTO.Text = "";
                                txtID_PRODUCTO.Focus();
                            }
                        }
                    }
                    else
                    {
                        txtDESC_PRODUCTO.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID_PRODUCTO.Text == "") {
                    txtID_PRODUCTO.Focus();
                    throw (new Exception("Debe capturar la clave del producto"));
                }
                if (txtDESC_PRODUCTO.Text == "")
                {
                    txtDESC_PRODUCTO.Focus();
                    throw (new Exception("Debe capturar el nombre del producto"));
                }
                //establecer los valores
                producto.ID_PRODUCTO = txtID_PRODUCTO.Text;
                producto.DESC_PRODUCTO = txtDESC_PRODUCTO.Text;
                producto.PRECIO_VENTA = Convert.ToDouble(txtPRECIO_VENTA.Text);
                producto.PRECIO_VENTA2 = Convert.ToDouble(txtPRECIO_VENTA2.Text);
                producto.PRECIO_VENTA3 = Convert.ToDouble(txtPRECIO_VENTA3.Text);
                producto.ID_GRUPO = Convert.ToInt32(cboID_GRUPO.SelectedValue);
                producto.IMPUESTO = Convert.ToDouble(txtIMPUESTO.Text);
                //if (dr["IMAGEN"] != DBNull.Value) { imagen = (byte[])dr["IMAGEN"]; } else { imagen = null; }
                producto.CANT_MIN = Convert.ToDouble(txtCANT_MIN.Text);
                producto.CANT_MAX = Convert.ToDouble(txtCANT_MAX.Text);
                producto.LOCALIZACION = txtLOCALIZACION.Text;
                producto.ID_UNIDAD_MEDIDA = Convert.ToInt32(cboID_UNIDAD_MEDIDA.SelectedValue);
                producto.USER_LOGIN = frmLogin._USER_LOGIN;
                producto.ID_MARCA = Convert.ToInt32(cboID_MARCA.SelectedValue);
                producto.EXISTENCIA = Convert.ToDouble(txtEXISTENCIA.Text);
                producto.PRECIO_COMPRA = Convert.ToDouble(txtPRECIO_COMPRA.Text);
                producto.SUST_ACTIVA = "";
                producto.INDICACION ="";
                producto.NOMBRES_CO =txtNOMBRES_CO.Text;
                producto.C_BARRAS = chkC_BARRAS.Checked;
                producto.FORMULACION = "";
                producto.ID_PRESENTACION = 0;
                producto.DESCUENTO = Convert.ToDouble(txtPORC_DESCUENTO.Text);
                producto.RUTA_IMAGEN = "";
                producto.CARACTERISTICAS = "";
                producto.VENDER_SIN_EXISTENCIA = chkVENDER_SIN_EXISTENCIA.Checked;
                producto.TIPO_TRANSMISION = "";
                producto.CVE_PROVEEDOR = txtCVE_PROVEEDOR.Text;
                producto.PASO = "";
                producto.INGREDIENTES = false;
                producto.HABILITAR_VENTA = !chkHABILITAR_VENTA.Checked;

                if (varID_PRODUCTO != "")
                {
                    //editar
                    if (producto.Editar())
                    {
                        DialogResult resp = MessageBox.Show("¿Desea seguir agregregando mas productos?", "Agregar nuevo producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resp == DialogResult.Yes) { ciclar = true; } else { ciclar = false; }
                        varID_PRODUCTO = txtID_PRODUCTO.Text;
                        precioVenta = Convert.ToDouble(txtPRECIO_VENTA.Text);
                        precioVenta2 = Convert.ToDouble(txtPRECIO_VENTA2.Text);
                        precioVenta3 = Convert.ToDouble(txtPRECIO_VENTA3.Text);
                        this.Close();
                            
                    }
                }
                else
                {
                    //Nuevo
                    if (producto.Nuevo())
                    {
                        DialogResult resp = MessageBox.Show("¿Desea seguir agregregando mas productos?", "Agregar nuevo producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resp == DialogResult.Yes) { ciclar = true; } else { ciclar = false; }
                        varID_PRODUCTO = txtID_PRODUCTO.Text;
                        precioVenta = Convert.ToDouble(txtPRECIO_VENTA.Text);
                        precioVenta2 = Convert.ToDouble(txtPRECIO_VENTA2.Text);
                        precioVenta3 = Convert.ToDouble(txtPRECIO_VENTA3.Text);
                        this.Close();
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        void txtEXISTENCIA_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
        
        }
        void txtPRECIO_VENTA_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
      
        }
        void txtPRECIO_COMPRA_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
      
        }
        void txtCANT_MAX_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
          
        }
        void txtCANT_MIN_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

        }
        void txtIMPUESTO_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
          
        }
        void frmProducto_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //ValidaTextBox();
            
        }
        void frmProducto_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            ValidaTextBox();
          
        }
        void ValidaTextBox()
        {
            TextBox _TextBox = new TextBox();
            foreach (Control _Control in this.Controls)
            {
                if (_TextBox.GetType() == _Control.GetType())
                {
                    if (_Control.Text == "")
                    {
                        _Control.BackColor = Color.Gold;
                    }
                    else
                    {
                        _Control.BackColor = Color.White;
                    }
                }
            }

        }

        private void btnVerProveedores_Click(object sender, EventArgs e)
        {
            frmProductoComprasPrevias _frmListaComprasPrevias = new frmProductoComprasPrevias(varID_PRODUCTO);
            _frmListaComprasPrevias.StartPosition = FormStartPosition.CenterScreen;
            _frmListaComprasPrevias.ShowDialog();
        }

        private void btnSearchProvider_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaProveedor myForm = new frmBuscaProveedor();
                myForm.StartPosition = FormStartPosition.CenterScreen;
                myForm.ShowDialog();
                if (myForm.varID_PROVEEDOR != "")
                {
                    txtCVE_PROVEEDOR.Text = myForm.varID_PROVEEDOR;
                    

                }
                myForm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btnIngredientes_Click(object sender, EventArgs e)
        {
            if (varID_PRODUCTO != "") {
                frmProductoIngredientes frm = new frmProductoIngredientes(varID_PRODUCTO, txtDESC_PRODUCTO.Text);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
        }

        private void btnAddBrand_Click(object sender, EventArgs e)
        {
            try
            {
                //add brand
                frmCatBrandsItem cat = new frmCatBrandsItem(0);
                cat.ShowInTaskbar = false;
                cat.StartPosition = FormStartPosition.CenterScreen;
                cat.ShowDialog();
                if (cat.ACTION_SUCCESS)
                {
                    LoadCatalog("MARCA", cboID_MARCA);
                    cboID_MARCA.SelectedValue = cat.ID_MARCA.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            try
            {
                //add brand
                frmCatGroupItem cat = new frmCatGroupItem(0);
                cat.ShowInTaskbar = false;
                cat.StartPosition = FormStartPosition.CenterScreen;
                cat.ShowDialog();
                if (cat.ACTION_SUCCESS)
                {
                    LoadCatalog("GRUPO", cboID_GRUPO);
                    cboID_GRUPO.SelectedValue = cat.ID_GRUPO.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddMeasurementUnit_Click(object sender, EventArgs e)
        {
            try
            {
                //add brand
                frmCatMeasurmentUnitItem cat = new frmCatMeasurmentUnitItem(0);
                cat.ShowInTaskbar = false;
                cat.StartPosition = FormStartPosition.CenterScreen;
                cat.ShowDialog();
                if (cat.ACTION_SUCCESS)
                {
                    LoadCatalog("UNIDAD_MEDIDA", cboID_UNIDAD_MEDIDA);
                    cboID_UNIDAD_MEDIDA.SelectedValue = cat.ID_UNIDAD_MEDIDA.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkIVA_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIVA.Checked)
            {
                txtIMPUESTO.Enabled = true;
                txtIMPUESTO.Text = "0.16";
                
            }
            else
            {
                txtIMPUESTO.Enabled = false;
                txtIMPUESTO.Text = "0";
            }
            AppSettings.SetValue("frmProducto", "IVA", chkIVA.Checked.ToString());
        }

       

       

        
    }
}