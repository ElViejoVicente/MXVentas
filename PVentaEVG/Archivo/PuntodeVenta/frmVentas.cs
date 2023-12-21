using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using POSApp.Class;
using POSDLL;

namespace POSApp.Forms
{
    public partial class frmVentas : Telerik.WinControls.UI.RadForm
    {
        Class.clsVentas _clsVentas = new clsVentas();
        bool _Sales = true;//indicamos que es modo cotización
        string _Title = "";
        string _SalesMode = "";
        double varLIMITE_EFECTIVO = 0;
        int varARTICULOS_FACTURA = 0;
        double varLimiteDeCredito = 0;
        double varCreditoDisponible = 0;
        Boolean varCREDITO_CLIENTE = false;
        int ultimoTicket = 0;
        /*variable para multimoneda*/
        private string _id_Moneda = "";
        private int _id_TipoCambiodia = 0;
        private double _tipo_Cambio = 0;
        /*TABLA DE VENTAS TEMPORALES PARA VENTA EN ESPERA*/
        DataTable ventaEnEspera = new DataTable();
        int clienteEnEspera = 0;
        int idTipoCliente = 0;

        public frmVentas(string prmUSER_LOGIN, int prmID_CAJA)
        {
            InitializeComponent();
            varID_CAJA = prmID_CAJA;
            varUSER_LOGIN = prmUSER_LOGIN;
        }
        //DEclaraciones
        string varUSER_LOGIN = frmLogin._USER_LOGIN;
        int varID_CAJA = 1;
        private void frmVentas_Load(object sender, EventArgs e)
        {
            /*TABLA DE VENTAS TEMPORALES PARA VENTA EN ESPERA*/
            //>Definimos la tabla para las salida Temporal
            DataColumn idColumn = new DataColumn("id", typeof(int));
            idColumn.Unique = true;
            idColumn.AutoIncrement = true;
            idColumn.AutoIncrementSeed = 1;
            idColumn.AutoIncrementStep = 1;
            ventaEnEspera.Columns.Add(idColumn);
            //declaramos el resto de los campos
            ventaEnEspera.Columns.Add("USER_LOGIN", typeof(string));
            ventaEnEspera.Columns.Add("ID_CAJA", typeof(int));
            ventaEnEspera.Columns.Add("ID_PRODUCTO", typeof(string));
            ventaEnEspera.Columns.Add("CANTIDAD", typeof(Double));
            ventaEnEspera.Columns.Add("IMPUESTO", typeof(Double));
            ventaEnEspera.Columns.Add("FECHAHORA", typeof(DateTime));
            ventaEnEspera.Columns.Add("PRECIO", typeof(Double));
            ventaEnEspera.Columns.Add("DESCUENTO", typeof(Double));
            ventaEnEspera.Columns.Add("PRECIO_COMPRA", typeof(Double));
            ventaEnEspera.Columns.Add("ID_TEMP_VENTA", typeof(int));
            ventaEnEspera.Columns.Add("TIPO_PRECIO", typeof(string));
            //agregamos un primary key
            ventaEnEspera.PrimaryKey = new DataColumn[] { ventaEnEspera.Columns["id"] };
            //<termina la deficinicón de la tabla temporal

            cboTIPO_CLIENTE.SelectedIndex = 0;
            txtID_CLIENTE.LostFocus += new EventHandler(txtID_CLIENTE_LostFocus);

            //CBI
            txtID_PRODUCTO.GotFocus += new EventHandler(txtID_PRODUCTO_GotFocus);
            txtCBI.GotFocus += new EventHandler(txtCBI_GotFocus);
            txtID_PRODUCTO.KeyUp += new KeyEventHandler(txtID_PRODUCTO_KeyUp);
            txtCBI.KeyUp += new KeyEventHandler(txtCBI_KeyUp);
            txtCBI.LostFocus += new EventHandler(txtCBI_LostFocus);
            txtID_PRODUCTO.LostFocus += new EventHandler(txtID_PRODUCTO_LostFocus);
            txtCBI.KeyPress += new KeyPressEventHandler(txtCBI_KeyPress);
            //
            varLIMITE_EFECTIVO = Convert.ToDouble(AppSettings.GetValue("Venta", "LIMITE_EFECTIVO", "0"));
            varARTICULOS_FACTURA = Convert.ToInt32(AppSettings.GetValue("Venta", "ARTICULOS_FACTURA", "0"));
            cboTIPO_CLIENTE.Enabled = frmLogin.PERMITIR_CANCELAR;
            cboTIPO_CLIENTE.SelectionChangeCommitted += new EventHandler(cboTIPO_CLIENTE_SelectionChangeCommitted);
            this.KeyUp += new KeyEventHandler(frmVentas_KeyUp);
            txtID_PRODUCTO.Focus();
            #region KeyPressDef
            txtID_CLIENTE.KeyPress += new KeyPressEventHandler(txtID_CLIENTE_KeyPress);
            txtNOMBRE.KeyPress += new KeyPressEventHandler(txtNOMBRE_KeyPress);
            txtRFC.KeyPress += new KeyPressEventHandler(txtRFC_KeyPress);
            txtCURP.KeyPress += new KeyPressEventHandler(txtCURP_KeyPress);
            cboTIPO_CLIENTE.KeyPress += new KeyPressEventHandler(cboTIPO_CLIENTE_KeyPress);
            txtDIRECCION.KeyPress += new KeyPressEventHandler(txtDIRECCION_KeyPress);
            txtCP.KeyPress += new KeyPressEventHandler(txtCP_KeyPress);
            txtTELEFONO.KeyPress += new KeyPressEventHandler(txtTELEFONO_KeyPress);
            txtEMail.KeyPress += new KeyPressEventHandler(txtEMail_KeyPress);
            txtESTADO.KeyPress += new KeyPressEventHandler(txtESTADO_KeyPress);
            txtMUNICIPIO.KeyPress += new KeyPressEventHandler(txtMUNICIPIO_KeyPress);
            txtLOCALIDAD.KeyPress += new KeyPressEventHandler(txtLOCALIDAD_KeyPress);
            #endregion
            try
            {
                _Title = "Ventas, CAJA: " + varID_CAJA.ToString();
                BuscaDatosCliente(Convert.ToInt32(txtID_CLIENTE.Text));
                LlenaMoneda();
                Headers();
                WhenResize();
                ReadData(varUSER_LOGIN, varID_CAJA);

                EditarCliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void frmVentas_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    RealizaVenta();
                    break;
                case Keys.F7:
                    VentaEnEspera();
                    break;
                case Keys.F8:
                    ImprimirUltimoticket();
                    break;
                case Keys.F9:
                    CambiaTipoPrecio();
                    break;
            }
        }
        void CambiaTipoPrecio()
        {
            int totalItems = cboTIPO_CLIENTE.Items.Count;
            if (cboTIPO_CLIENTE.SelectedIndex >= totalItems - 1)
            {
                cboTIPO_CLIENTE.SelectedIndex = 0;
            }
            else
            {
                cboTIPO_CLIENTE.SelectedIndex = cboTIPO_CLIENTE.SelectedIndex + 1;
            }
        }
        void cboTIPO_CLIENTE_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtID_PRODUCTO.Focus();
        }

        void txtCBI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SaveTemp_VentasCBI();
                txtCBI.Focus();
            }
        }

        void txtID_PRODUCTO_LostFocus(object sender, EventArgs e)
        {
            lblCBI.Text = "";
        }

        void txtCBI_LostFocus(object sender, EventArgs e)
        {
            lblCBI.Text = "";
        }

        void txtCBI_KeyUp(object sender, KeyEventArgs e)
        {
            //SI es [F6] deshabilitamos "txtCBI" y habilitamos "txtID_PRODUCTO"
            if (e.KeyData == Keys.F6) { txtCBI.Visible = false; txtID_PRODUCTO.Visible = true; lblID_PRODUCTO.Text = "Clave del artículo: "; txtCANTIDAD.Visible = true; lblCANTIDAD.Visible = true; txtID_PRODUCTO.Focus(); }
        }

        void txtID_PRODUCTO_KeyUp(object sender, KeyEventArgs e)
        {
            //SI es [F6] deshabilitamos "txtID_PRODUCTO" y habilitamos "txtCBI"
            if (e.KeyData == Keys.F6) { txtID_PRODUCTO.Visible = false; lblID_PRODUCTO.Text = "Código de Barras Integral: "; txtCANTIDAD.Visible = false; lblCANTIDAD.Visible = false; txtCBI.Visible = true; txtCBI.Focus(); }
        }

        void txtCBI_GotFocus(object sender, EventArgs e)
        {
            lblCBI.Text = "[F6] Para deshabilitar código de barras integral";
        }

        void txtID_PRODUCTO_GotFocus(object sender, EventArgs e)
        {
            lblCBI.Text = "[F6] Para habilitar código de barras integral";
        }

        #region KeyPressCode

        void txtLOCALIDAD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtID_PRODUCTO.Focus();
            }
        }

        void txtMUNICIPIO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtLOCALIDAD.Focus();
            }
        }

        void txtESTADO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtMUNICIPIO.Focus();
            }
        }

        void txtEMail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtESTADO.Focus();
            }
        }

        void txtTELEFONO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtEMail.Focus();
            }
        }

        void txtCP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtTELEFONO.Focus();
            }
        }

        void txtDIRECCION_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtCP.Focus();
            }
        }

        void cboTIPO_CLIENTE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDIRECCION.Focus();
            }
        }

        void txtCURP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cboTIPO_CLIENTE.Focus();
            }
        }

        void txtRFC_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                txtCURP.Focus();
            }
        }

        void txtNOMBRE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtRFC.Focus();
            }
        }
        void txtID_CLIENTE_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                if (txtNOMBRE.Enabled) { txtNOMBRE.Focus(); }
                else { btnBuscarCliente.Focus(); }

            }
        }
        void txtCANTIDAD_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                SaveTemp();
            }
        }
        void txtID_PRODUCTO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SaveTemp();
            }
        }
        #endregion
        void lvVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ModificaVenta();
            }
        }
        void txtID_CLIENTE_LostFocus(object sender, EventArgs e)
        {
            //
            if (txtID_CLIENTE.Text == "")
            {
                MessageBox.Show("Falta la clave del cliente", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtID_CLIENTE.Focus();
                return;
            }
            else
            {
                if (BuscaDatosCliente(Convert.ToInt32(txtID_CLIENTE.Text)))
                {
                    if (txtID_PRODUCTO.Visible)
                    {
                        txtID_PRODUCTO.Focus();
                    }
                    else
                    {
                        txtCBI.Focus();
                    }
                }
            }

        }
        void BuscaCliente()
        {
            try
            {
                frmBuscarCliente myForm = new frmBuscarCliente();
                myForm.StartPosition = FormStartPosition.CenterScreen;
                myForm.ShowDialog();
                if (!(frmBuscarCliente.varID_CLIENTE == 0))
                {
                    txtID_CLIENTE.Text = frmBuscarCliente.varID_CLIENTE.ToString();
                    BuscaDatosCliente(Convert.ToInt32(txtID_CLIENTE.Text));
                    if (txtID_PRODUCTO.Visible)
                    {
                        txtID_PRODUCTO.Focus();
                    }
                    else
                    {
                        txtCBI.Focus();
                    }
                }
                myForm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnBuscaCliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtID_CLIENTE.Text = "";
            }
        }
        void frmVentas_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            int Valor = Class.clsVentas.FnCheckTempVentas(frmLogin._USER_LOGIN, varID_CAJA);
            if (Valor != 0)
            {
                DialogResult Resp = new DialogResult();
                Resp = MessageBox.Show("Hay articulos en la lista de ventas, " +
                    "si cierra el sistema se eliminarán.\n¿Desea continuar?",
                    "Información del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (Resp == DialogResult.Yes)
                {
                    //eliminar los artículos 
                    _clsVentas.DeshacerVenta(frmLogin._USER_LOGIN, varID_CAJA);
                }
                else
                {
                    //Se cancela cerrar la pantalla
                    e.Cancel = true;
                }
            }
        }
        private void frmVentas_Resize(object sender, EventArgs e)
        {
            WhenResize();
        }
        void txtID_CLIENTE_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    //aqui
                    BuscaCliente();
                    break;
            }
        }


        void txtCANTIDAD_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.F2:
                    //aqui
                    BuscaProducto();
                    break;
            }
        }
        void txtID_PRODUCTO_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.F2:
                    //aqui
                    BuscaProducto();
                    break;
            }

        }
        void lvVenta_DblClick(object sender, EventArgs e)
        {
            ModificaVenta();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificaVenta();
        }
        void ModificaVenta()
        {
            //Código para modificar la venta
            string varID_PRODUCTO;
            try
            {
                if (lvVenta.SelectedItems.Count != 0)
                {
                    varID_PRODUCTO = lvVenta.SelectedItems[0].Text;
                    Forms.frmVentaModificar myForm =
                        new Forms.frmVentaModificar(varUSER_LOGIN, varID_CAJA, varID_PRODUCTO);
                    myForm.ShowDialog();
                    if (frmVentaModificar._Accion)
                    {
                        ReadData(varUSER_LOGIN, varID_CAJA);
                        txtID_PRODUCTO.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione un elemento de la lista. \nDescription Error: \n" +
                    ex.Message, "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void SaveTemp()
        {
            lblMensaje.Text = "";

            if (txtID_CLIENTE.Text == "")
            {
                MessageBox.Show("Falta la clave del cliente", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtID_CLIENTE.Focus();
                return;
            }
            try
            {
                if (!((txtID_PRODUCTO.Text == "") || (txtCANTIDAD.Text == "")))
                {

                    //Inserttar código aqui

                    SaveTemp_Ventas(Strings.SafeSqlLikeClauseLiteral(txtID_PRODUCTO.Text), Convert.ToDouble(txtCANTIDAD.Text), cboTIPO_CLIENTE.Text);
                    txtCANTIDAD.Text = "1";
                    txtID_PRODUCTO.Text = "";
                    if (txtID_PRODUCTO.Visible)
                    {
                        txtID_PRODUCTO.Focus();
                    }
                    else
                    {
                        txtCBI.Focus();
                    }
                }
                else
                {
                    lblMensaje.Text = "Debe introducir una cantidad y una clave de artículo";
                    throw (new Exception("Debe introducir una cantidad y una clave de artículo"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del Sistema",
                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        void SaveTemp_Ventas(string prmID_PRODUCTO, double prmCANTIDAD, string prmTIPO_CLIENTE)
        {
            try
            {

                clsVentas.Temp_Ventas(varUSER_LOGIN, varID_CAJA, prmID_PRODUCTO, prmCANTIDAD, prmTIPO_CLIENTE, _id_Moneda, _id_TipoCambiodia, _tipo_Cambio);
                ReadData(varUSER_LOGIN, varID_CAJA);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void SaveTemp_VentasCBI()
        {
            try
            {
                if (txtCBI.Text.Length != 13)
                {
                    lblMensaje.Text = "El CBI debe de ser de 13 caracteres";
                    throw (new Exception("El CBI debe de ser de 13 caracteres"));

                }
                string idProducto = txtCBI.Text.Substring(1, 6);
                string cantidad = txtCBI.Text.Substring(7, 5);

                //MessageBox.Show(String.Format("CBI:\n{0}\n{1}", idProducto, cantidad.ToString()));
                clsVentas.Temp_Ventas(varUSER_LOGIN, varID_CAJA, idProducto, (Convert.ToDouble(cantidad) / 1000), cboTIPO_CLIENTE.Text, _id_Moneda, _id_TipoCambiodia, _tipo_Cambio);
                ReadData(varUSER_LOGIN, varID_CAJA);
                txtCBI.Text = "";
                txtCBI.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Headers()
        {
            //Encabezados del litView
            lvVenta.View = View.Details;
            lvVenta.Columns.Add("", 0, HorizontalAlignment.Left);
            lvVenta.Columns.Add("No", 50, HorizontalAlignment.Left);
            lvVenta.Columns.Add("Artículo", 100, HorizontalAlignment.Left);
            lvVenta.Columns.Add("Descripción", this.Width - 650, HorizontalAlignment.Left);
            lvVenta.Columns.Add("Cant", 75, HorizontalAlignment.Right);
            lvVenta.Columns.Add("Precio", 150, HorizontalAlignment.Right);
            lvVenta.Columns.Add("Descuento", 100, HorizontalAlignment.Right);
            //lvVenta.Columns.Add("Impuesto", 100, HorizontalAlignment.Right);
            lvVenta.Columns.Add("Total", 100, HorizontalAlignment.Right);
        }
        void ReadData(string prmUSER_LOGIN, int prmID_CAJA)
        {
            lblMensaje.Text = "";
            OleDbConnection cnnReadData = new OleDbConnection(Class.clsMain.CnnStr);
            double varDESCUENTO = 0.0, varDESCUENTO_MONEDA = 0.0;
            double varGRAND_TOTAL = 0.0, varGRAND_TOTALMONEDA = 0.0, varIVA=0.0, varSubtotal=0.0;
            string varId_Moneda = "";
            btnCancel.Enabled = false;
            btnModificar.Enabled = false;
            try
            {

                string varSQL = "SELECT * FROM TEMP_VENTA " +
                 "  WHERE USER_LOGIN = @user_login AND ID_CAJA = @id_caja ORDER BY ID_TEMP_VENTA DESC";
                int I = 0;
                OleDbCommand cmdReadData = new OleDbCommand(varSQL, cnnReadData);
                cmdReadData.Parameters.Add("@user_login", OleDbType.VarChar, 50).Value = prmUSER_LOGIN;
                cmdReadData.Parameters.Add("@id_caja", OleDbType.Integer).Value = prmID_CAJA;
                OleDbDataReader drReadData;

                cnnReadData.Open();
                drReadData = cmdReadData.ExecuteReader();
                lvVenta.Items.Clear();
                while (drReadData.Read())
                {
                    lvVenta.Items.Add(drReadData["ID_PRODUCTO"].ToString());
                    lvVenta.Items[I].SubItems.Add(String.Format("{0}", I + 1));
                    lvVenta.Items[I].SubItems.Add(drReadData["ID_PRODUCTO"].ToString());
                    lvVenta.Items[I].SubItems.Add(drReadData["DESC_PRODUCTO"].ToString());
                    lvVenta.Items[I].SubItems.Add(drReadData["CANTIDAD"].ToString());
                    lvVenta.Items[I].SubItems.Add(String.Format("{0} - {1:C}", drReadData["TIPO_PRECIO"], drReadData["PRECIO_MONEDA"]));
                    lvVenta.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["DESCUENTO_MONEDA"]));
                    //lvVenta.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["IMPUESTO_MONEDA"]));
                    lvVenta.Items[I].SubItems.Add(String.Format("{0:C}", Convert.ToDouble(drReadData["TOTAL_MONEDA"]) ));
                    //Obtenemos el Grand Total y el Iva
                    varGRAND_TOTAL += Convert.ToDouble(drReadData["TOTAL"]);
                    varGRAND_TOTALMONEDA += Convert.ToDouble(drReadData["TOTAL_MONEDA"]);
                    
                    //limite de efectivo
                    if (varLIMITE_EFECTIVO > 0)
                    {
                        if (varGRAND_TOTAL >= varLIMITE_EFECTIVO)
                        {
                            MessageBox.Show("ATENCIÓN\nLA VENTA TOTAL EXCEDE EL LIMITE DE EFECTIVO PERMITIDO PARA UNA SOLA FACTURA" +
                            string.Format("\nLIMITE DE EFECTIVO PERMITIDO: {0}\nTOTAL EN LA VENTA ACTUAL: {1}", varLIMITE_EFECTIVO.ToString("c"), varGRAND_TOTAL.ToString("c")),
                            "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    if (varARTICULOS_FACTURA > 0)
                    {
                        if (I >= varARTICULOS_FACTURA)
                        {
                            MessageBox.Show("ATENCIÓN\nHA EXEDIDO EL LIMITE DE ARTICULOS POR FACTURA" +
                            string.Format("\nLIMITE DE ARTICULOS: {0}\nCANTIDAD DE ARTICULOS: {1}", varARTICULOS_FACTURA.ToString(), I.ToString()),
                            "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    varIVA += Convert.ToDouble(drReadData["TOTIMPUESTO_MONEDA"]);
                    varDESCUENTO += Convert.ToDouble(drReadData["DESCUENTO"]);
                    varDESCUENTO_MONEDA += Convert.ToDouble(drReadData["DESCUENTO_MONEDA"]);
                    varId_Moneda = drReadData["ID_MONEDA"].ToString();
                    
                    I += 1;
                    btnCancel.Enabled = true;

                    btnModificar.Enabled = true;
                }
                lblInfo.Text = String.Format("{0} registro(s)", I);
                drReadData.Close();
                cmdReadData.Dispose();
                varSubtotal = varGRAND_TOTALMONEDA + varDESCUENTO_MONEDA;

                lblIVA.Text = String.Format("IVA: {0:C}", varIVA);
                lblGRAND_TOTAL.Text = String.Format("Total: {0:C}", varGRAND_TOTALMONEDA + varIVA);
                lblDesc.Text = String.Format("Desc: {0:C}", varDESCUENTO_MONEDA);
                cboMoneda.ListElement.SelectedValue = varId_Moneda;
                lblSubTotal_moneda.Text = String.Format("SubTotal: {1:C},{0}", _id_Moneda, varSubtotal);

                LimpiaDatosVenta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally { cnnReadData.Close(); }
        }
        private bool BuscaDatosCliente(int prmID_CLIENTE)
        {
            OleDbConnection cnnReadData = new OleDbConnection(Class.clsMain.CnnStr);
            try
            {

                cnnReadData.Open();
                string varSQL = "SELECT * FROM CAT_CLIENTE WHERE ID_CLIENTE=@id";
                OleDbCommand cmdReadData = new OleDbCommand(varSQL, cnnReadData);
                cmdReadData.Parameters.Add("@id", OleDbType.Integer).Value = prmID_CLIENTE;
                OleDbDataReader drReadData;
                drReadData = cmdReadData.ExecuteReader();
                while (drReadData.Read())
                {
                    //Mostramos los datos      
                    txtRFC.Text = drReadData["RFC"].ToString();
                    txtCURP.Text = drReadData["CURP"].ToString();
                    txtNOMBRE.Text = drReadData["NOMBRE"].ToString();
                    txtDIRECCION.Text = drReadData["DOMICILIO"].ToString();
                    txtTELEFONO.Text = drReadData["TELEFONO"].ToString();
                    txtCP.Text = drReadData["CP"].ToString();
                    txtEMail.Text = drReadData["EMAIL"].ToString();
                    txtESTADO.Text =
                        drReadData["ID_ESTADO"].ToString();

                    txtMUNICIPIO.Text =
                        drReadData["ID_MUNICIPIO"].ToString();
                    txtLOCALIDAD.Text =
                        drReadData["ID_LOCALIDAD"].ToString();

                    varLimiteDeCredito = Convert.ToDouble(drReadData["LIM_CREDITO"]);
                    varCREDITO_CLIENTE = Convert.ToBoolean(drReadData["CREDITO"]);
                }
                drReadData.Close();
                cmdReadData.Parameters.Clear();
                varCreditoDisponible = varLimiteDeCredito;
                cmdReadData.CommandText = "spSALDO_CLIENTE";
                cmdReadData.CommandType = CommandType.StoredProcedure;
                cmdReadData.Parameters.Add("prmID_CLIENTE", OleDbType.Integer).Value = prmID_CLIENTE;
                drReadData = cmdReadData.ExecuteReader();
                if (drReadData.Read())
                {

                    varCreditoDisponible = varLimiteDeCredito - Convert.ToDouble(drReadData["RESTO"]);


                }
                drReadData.Close();
                cmdReadData.Dispose();
                //Credito
                lblCredito.Text = "Crédito {A}: {B} de {C}";

                if (varCREDITO_CLIENTE) { lblCredito.Text = lblCredito.Text.Replace("{A}", "SI"); }
                else { lblCredito.Text = lblCredito.Text.Replace("{A}", "NO"); }

                lblCredito.Text = lblCredito.Text.Replace("{B}", String.Format("{0:C}", varCreditoDisponible));
                lblCredito.Text = lblCredito.Text.Replace("{C}", String.Format("{0:C}", varLimiteDeCredito));

                return (true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return (false);
            }
            finally { cnnReadData.Close(); }
        }
        void LimpiaCliente()
        {
            txtID_CLIENTE.Text = "0";
            txtRFC.Text = "";
            txtCURP.Text = "";
            txtNOMBRE.Text = "";
            txtDIRECCION.Text = "";
            txtTELEFONO.Text = "";
            txtCP.Text = "";
            txtEMail.Text = "";
            txtESTADO.Text = "";
            txtMUNICIPIO.Text = "";
            txtLOCALIDAD.Text = "";

        }
        void WhenResize()
        {
            //Este se ejecutara cuando hagamos resize al control
            //lvVenta.Height  = this.Height  - 270;
            lvVenta.Clear();
            Headers();
            ReadData(varUSER_LOGIN, varID_CAJA);
        }

        void LimpiaDatosVenta()
        {
            if (lvVenta.Items.Count == 0)
            {
                btnCancel.Enabled = true;
                btnModificar.Enabled = true;
                c_mnuEditar.Enabled = false;
                cboMoneda.Enabled = true;
                lblIVA.Text = String.Format("IVA: {0:C}", 0);
                lblGRAND_TOTAL.Text = String.Format("Total: {0:C}", 0);
                lblDesc.Text = String.Format("Desc: {0:C}", 0);
                cboMoneda.ListElement.SelectedValue = 0;
                lblSubTotal_moneda.Text = String.Format("SubTotal: {1:C},{0}", _id_Moneda, 0);
                
            }
            else
            {
                cboMoneda.Enabled = false;
            }
        }

        private void btnRealizarVenta_Click(object sender, EventArgs e)
        {
            RealizaVenta();
        }

        private void RealizaVenta()
        {
            try
            {
                if (lvVenta.Items.Count != 0 && _Sales)
                {
                    frmVentasCobrar frm = new frmVentasCobrar(varUSER_LOGIN, varID_CAJA,
                        Convert.ToInt32(txtID_CLIENTE.Text),
                           Strings.SafeSqlLikeClauseLiteral(txtRFC.Text),
                           Strings.SafeSqlLikeClauseLiteral(txtCURP.Text),
                           Strings.SafeSqlLikeClauseLiteral(txtNOMBRE.Text),
                           Strings.SafeSqlLikeClauseLiteral(txtDIRECCION.Text),
                           Strings.SafeSqlLikeClauseLiteral(txtESTADO.Text),
                           Strings.SafeSqlLikeClauseLiteral(txtMUNICIPIO.Text),
                           Strings.SafeSqlLikeClauseLiteral(txtLOCALIDAD.Text),
                           Strings.SafeSqlLikeClauseLiteral(txtCP.Text),
                           Strings.SafeSqlLikeClauseLiteral(txtTELEFONO.Text),
                           Strings.SafeSqlLikeClauseLiteral(txtEMail.Text),
                           cboTIPO_CLIENTE.Text, varCreditoDisponible, _id_Moneda,
                            _id_TipoCambiodia, _tipo_Cambio);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
                    if (frmVentasCobrar._Accion)
                    {
                        ultimoTicket = frm.FOLIO_VENTA;
                        txtID_CLIENTE.Text = "1";
                        BuscaDatosCliente(Convert.ToInt32(txtID_CLIENTE.Text));
                        lvVenta.Items.Clear();
                        txtID_PRODUCTO.Text = "";
                        if (txtID_PRODUCTO.Visible)
                        {
                            txtID_PRODUCTO.Focus();
                        }
                        else
                        {
                            txtCBI.Focus();
                        }
                        lblInfo.Text = "";
                        cboTIPO_CLIENTE.SelectedIndex = 0;
                        LimpiaDatosVenta();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            BuscaProducto();
        }
        void BuscaProducto()
        {
            try
            {

                //si es modo cotización
                frmBuscaProducto myForm = new frmBuscaProducto();
                myForm.StartPosition = FormStartPosition.CenterScreen;
                myForm.ShowDialog();
                if (!(myForm.producto.ID_PRODUCTO == ""))
                {
                    txtID_PRODUCTO.Text = myForm.producto.ID_PRODUCTO;
                    if (txtID_PRODUCTO.Visible)
                    {
                        txtID_PRODUCTO.Focus();
                    }
                    else
                    {
                        txtCBI.Focus();
                    }
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
        private void lblCANTIDAD_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            BuscaCliente();
        }

        /*
         void VenderCotizar() {
             try
             {
                 bool _continue = true;
                 if (lvVenta.Items.Count != 0) {
                     DialogResult Resp = new DialogResult();
                     Resp = MessageBox.Show("Esta operación borrará todos los registros que tiene en la lista de venta."+
                         "\n¿Desea Continuar?", _SalesMode, MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
                     if (Resp == DialogResult.Yes)
                     {
                         //cancelar la venta 
                         _continue = true;
                         _clsVentas.DeshacerVenta(frmLogin._USER_LOGIN, varID_CAJA);
                         ReadData(frmLogin._USER_LOGIN, varID_CAJA);
                     }
                     else {
                         _continue = false;
                     }
                 }
                 if (!_Sales && _continue)
                 {
                     //Si es modo cotización, cambiar a modo ventas
                     _Sales = true;
                     btnSalesMode.Text = "Vender";
                     _SalesMode = " -Modo Ventas-";
                     this.Text = _Title + _SalesMode;
                     this.BackColor = DefaultBackColor;
                 }
                 else
                 {
                     if (_continue)
                     {
                         //si es modo ventas, cambiar a modo cotización
                         _Sales = false;
                         _SalesMode = " -Modo Cotización-";
                         btnSalesMode.Text = "Cotizar";
                         this.Text = _Title + _SalesMode;
                         this.BackColor = Color.Orange;
                     }
                 }
                 btnRealizarVenta.Enabled = _Sales;
                 //btnBuscarProducto.Enabled = !_Sales;
                 if (txtID_PRODUCTO.Visible)
                 {
                     txtID_PRODUCTO.Focus();
                 }
                 else
                 {
                     txtCBI.Focus();
                 }
                
             }
             catch (Exception ex) {
                 MessageBox.Show(ex.Message, "Información del Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             }
         }
         */
        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelaVenta();
        }
        void CancelaVenta()
        {
            try
            {
                if (!frmLogin.PERMITIR_CANCELAR)
                {
                    MessageBox.Show("Requiere permisos para ejecutar esta acción. Consulte con su administrador", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult Resp = new DialogResult();
                Resp = MessageBox.Show("¿Desea eliminar todos los registros?", _SalesMode, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (Resp == DialogResult.Yes)
                {
                    //cancelar la venta
                    _clsVentas.DeshacerVenta(frmLogin._USER_LOGIN, varID_CAJA);
                    ReadData(frmLogin._USER_LOGIN, varID_CAJA);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del Sistema",
                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void c_mnuEditar_Click(object sender, EventArgs e)
        {
            ModificaVenta();
        }

        private void btnAplicarDescuento_Click(object sender, EventArgs e)
        {
            if (!frmLogin.PERMITIR_CANCELAR)
            {
                MessageBox.Show("Requiere permisos para ejecutar esta acción. Consulte con su administrador", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (lvVenta.Items.Count != 0)
            {
                frmVentasAplicarDescuento frm = new frmVentasAplicarDescuento(frmLogin._USER_LOGIN, varID_CAJA);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
                if (frm._Accion)
                {
                    ReadData(frmLogin._USER_LOGIN, varID_CAJA);
                }
            }
            else
            {
                MessageBox.Show("No hay articulos en la venta", "Información del Sistema",
                      MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void chkEditarCliente_CheckedChanged(object sender, EventArgs e)
        {
            EditarCliente();
        }
        void EditarCliente()
        {
            txtNOMBRE.Enabled = chkEditarCliente.Checked;
            txtRFC.Enabled = chkEditarCliente.Checked;
            txtCURP.Enabled = chkEditarCliente.Checked;
            txtDIRECCION.Enabled = chkEditarCliente.Checked;
            txtCP.Enabled = chkEditarCliente.Checked;
            txtTELEFONO.Enabled = chkEditarCliente.Checked;
            txtEMail.Enabled = chkEditarCliente.Checked;
            txtESTADO.Enabled = chkEditarCliente.Checked;
            txtMUNICIPIO.Enabled = chkEditarCliente.Checked;
            txtLOCALIDAD.Enabled = chkEditarCliente.Checked;


        }

        private void btnReimprimirTicket_Click(object sender, EventArgs e)
        {
            frmRptTicket frm = new frmRptTicket();
            frm.ShowInTaskbar = false;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void btnVentaEnEspera_Click(object sender, EventArgs e)
        {
            VentaEnEspera();
        }
        void VentaEnEspera()
        {
            try
            {
                if (ventaEnEspera.Rows.Count == 0)
                {
                    //cargar
                    if (lvVenta.Items.Count == 0) { throw (new Exception("No hay articulos en la lista de ventas")); }
                    if (txtID_CLIENTE.Text == "") { throw (new Exception("Debe especificar un cliente")); }
                    DialogResult resp = MessageBox.Show("¿Realmente desea poner estos articulos en espera?", "Información del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resp == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (VentaEnEsperaCargar(varUSER_LOGIN, varID_CAJA))
                        {
                            idTipoCliente = cboTIPO_CLIENTE.SelectedIndex;
                            cboTIPO_CLIENTE.SelectedIndex = 0;
                            clienteEnEspera = Convert.ToInt32(txtID_CLIENTE.Text);
                            _clsVentas.DeshacerVenta(frmLogin._USER_LOGIN, varID_CAJA);
                            ReadData(varUSER_LOGIN, varID_CAJA);
                            txtID_CLIENTE.Text = "1";
                            BuscaDatosCliente(Convert.ToInt32(txtID_CLIENTE.Text));
                        }
                    }
                }
                else
                {
                    //descargar
                    //if (lvVenta.Items.Count != 0) { throw (new Exception("La lista de articulos debe de estar vacía")); }
                    DialogResult resp = MessageBox.Show("¿Realmente desea recuperar los articulos que tiene en espera y cargarlos a la venta actual?", "Información del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resp == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (VentaEnEsperaDescargar(varUSER_LOGIN, varID_CAJA))
                        {
                            cboTIPO_CLIENTE.SelectedIndex = idTipoCliente;
                            txtID_CLIENTE.Text = clienteEnEspera.ToString();
                            BuscaDatosCliente(Convert.ToInt32(txtID_CLIENTE.Text));
                            ReadData(varUSER_LOGIN, varID_CAJA);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        protected bool VentaEnEsperaCargar(string prmUSER_LOGIN, int prmID_CAJA)
        {
            OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
            try
            {
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT * FROM TEMP_VENTA WHERE USER_LOGIN=@user_login AND ID_CAJA=@id_caja";
                cmd.Parameters.Add("@user_login", OleDbType.VarChar, 50).Value = prmUSER_LOGIN;
                cmd.Parameters.Add("@id_caja", OleDbType.Integer).Value = prmID_CAJA;
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DataRow row = ventaEnEspera.NewRow();
                    row["USER_LOGIN"] = dr["USER_LOGIN"].ToString();
                    row["ID_CAJA"] = Convert.ToInt32(dr["ID_CAJA"]);
                    row["ID_PRODUCTO"] = dr["ID_PRODUCTO"].ToString();
                    row["CANTIDAD"] = Convert.ToDouble(dr["CANTIDAD"]);
                    row["IMPUESTO"] = Convert.ToDouble(dr["IMPUESTO"]);
                    row["FECHAHORA"] = Convert.ToDateTime(dr["FECHAHORA"]);
                    row["PRECIO"] = Convert.ToDouble(dr["PRECIO"]);
                    row["DESCUENTO"] = Convert.ToDouble(dr["DESCUENTO"]);
                    row["PRECIO_COMPRA"] = Convert.ToDouble(dr["PRECIO_COMPRA"]);
                    row["ID_TEMP_VENTA"] = Convert.ToInt32(dr["ID_TEMP_VENTA"]);
                    row["TIPO_PRECIO"] = Convert.ToString(dr["TIPO_PRECIO"]);
                    ventaEnEspera.Rows.Add(row);
                    /*
        ventaEnEspera.Columns.Add("USER_LOGIN", typeof(string));
        ventaEnEspera.Columns.Add("ID_CAJA", typeof(int));
        ventaEnEspera.Columns.Add("ID_PRODUCTO", typeof(string));
        ventaEnEspera.Columns.Add("CANTIDAD", typeof(Double));
        ventaEnEspera.Columns.Add("IMPUESTO", typeof(Double));
        ventaEnEspera.Columns.Add("FECHA_HORA", typeof(DateTime));
        ventaEnEspera.Columns.Add("PRECIO", typeof(Double));
        ventaEnEspera.Columns.Add("DESCUENTO", typeof(Double));
        ventaEnEspera.Columns.Add("PRECIO_COMPRA", typeof(Double));
        ventaEnEspera.Columns.Add("ID_TEMP_VENTA", typeof(int));
                     */
                }
                dr.Close();
                return true;
            }
            catch (Exception ex) { throw ex; }
            finally { cnn.Close(); }
        }
        protected bool VentaEnEsperaDescargar(string prmUSER_LOGJN, int prmID_CAJA)
        {
            OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
            int RowCount = 0;
            try
            {
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;
                OleDbTransaction tran = cnn.BeginTransaction();
                cmd.Transaction = tran;
                try
                {
                    for (int i = 0; i < ventaEnEspera.Rows.Count; i++)
                    {

                        SaveTemp_Ventas(Convert.ToString(ventaEnEspera.Rows[i]["ID_PRODUCTO"]),
                                        Convert.ToDouble(ventaEnEspera.Rows[i]["CANTIDAD"]),
                                        cboTIPO_CLIENTE.Text);
                        //cmd.CommandText = "SELECT COUNT(*) FROM TEMP_VENTA WHERE ID_PRODUCTO=@ID_PRODUCTO AND USER_LOGIN=@USER_LOGIN AND ID_CAJA=@ID_CAJA";
                        //cmd.Parameters.Add("@ID_PRODUCTO", OleDbType.VarChar, 50).Value = Convert.ToString(ventaEnEspera.Rows[i]["ID_PRODUCTO"]);
                        //cmd.Parameters.Add("@USER_LOGIN", OleDbType.VarChar, 50).Value = Convert.ToString(ventaEnEspera.Rows[i]["USER_LOGIN"]);
                        //cmd.Parameters.Add("@ID_CAJA", OleDbType.Integer).Value = Convert.ToInt32(ventaEnEspera.Rows[i]["ID_CAJA"]);
                        //RowCount = Convert.ToInt32(cmd.ExecuteScalar());
                        //cmd.Parameters.Clear();
                        //if (RowCount == 0)
                        //{
                        //    //nuevo
                        //    cmd.CommandText = "INSERT INTO TEMP_VENTA(USER_LOGIN,ID_CAJA,ID_PRODUCTO,CANTIDAD,IMPUESTO,FECHAHORA,PRECIO,DESCUENTO,PRECIO_COMPRA, TIPO_PRECIO) " +
                        //        " VALUES(@USER_LOGIN,@ID_CAJA,@ID_PRODUCTO,@CANTIDAD,@IMPUESTO,@FECHAHORA,@PRECIO,@DESCUENTO,@PRECIO_COMPRA, @TIPO_PRECIO)";
                        //    //PARAMS
                        //    cmd.Parameters.Add("@USER_LOGIN", OleDbType.VarChar, 50).Value = Convert.ToString(ventaEnEspera.Rows[i]["USER_LOGIN"]);
                        //    cmd.Parameters.Add("@ID_CAJA", OleDbType.Integer).Value = Convert.ToInt32(ventaEnEspera.Rows[i]["ID_CAJA"]);
                        //    cmd.Parameters.Add("@ID_PRODUCTO", OleDbType.VarChar, 50).Value = Convert.ToString(ventaEnEspera.Rows[i]["ID_PRODUCTO"]);
                        //    cmd.Parameters.Add("@CANTIDAD", OleDbType.Double).Value = Convert.ToDouble(ventaEnEspera.Rows[i]["CANTIDAD"]);
                        //    cmd.Parameters.Add("@IMPUESTO", OleDbType.Double).Value = Convert.ToDouble(ventaEnEspera.Rows[i]["IMPUESTO"]);
                        //    cmd.Parameters.Add("@FECHAHORA", OleDbType.Date).Value = Convert.ToDateTime(ventaEnEspera.Rows[i]["FECHAHORA"]);
                        //    cmd.Parameters.Add("@PRECIO", OleDbType.Double).Value = Convert.ToDouble(ventaEnEspera.Rows[i]["PRECIO"]);
                        //    cmd.Parameters.Add("@DESCUENTO", OleDbType.Double).Value = Convert.ToDouble(ventaEnEspera.Rows[i]["DESCUENTO"]);
                        //    cmd.Parameters.Add("@PRECIO_COMPRA", OleDbType.Double).Value = Convert.ToDouble(ventaEnEspera.Rows[i]["PRECIO_COMPRA"]);
                        //    cmd.Parameters.Add("@TIPO_PRECIO", OleDbType.VarChar, 50).Value = Convert.ToString(ventaEnEspera.Rows[i]["TIPO_PRECIO"]);
                        //    cmd.ExecuteNonQuery();
                        //    cmd.Parameters.Clear();
                        //}
                        //else
                        //{
                        //    //update
                        //    cmd.CommandText = "UPDATE TEMP_VENTA SET" +
                        //        "  CANTIDAD=CANTIDAD + @CANTIDAD " +
                        //        " WHERE ID_PRODUCTO=@ID_PRODUCTO AND USER_LOGIN=@USER_LOGIN AND ID_CAJA=@ID_CAJA"; ;
                        //    //PARAMS
                        //    cmd.Parameters.Add("@CANTIDAD", OleDbType.Double).Value = Convert.ToDouble(ventaEnEspera.Rows[i]["CANTIDAD"]);
                        //    cmd.Parameters.Add("@ID_PRODUCTO", OleDbType.VarChar, 50).Value = Convert.ToString(ventaEnEspera.Rows[i]["ID_PRODUCTO"]);
                        //    cmd.Parameters.Add("@USER_LOGIN", OleDbType.VarChar, 50).Value = Convert.ToString(ventaEnEspera.Rows[i]["USER_LOGIN"]);
                        //    cmd.Parameters.Add("@ID_CAJA", OleDbType.Integer).Value = Convert.ToInt32(ventaEnEspera.Rows[i]["ID_CAJA"]);


                        //    cmd.ExecuteNonQuery();
                        //    cmd.Parameters.Clear();
                        //}
                    }


                    tran.Commit();
                }
                catch (OleDbException ex1) { tran.Rollback(); throw ex1; }
                ventaEnEspera.Rows.Clear();//vaciar la tabla temporal
                return true;
            }
            catch (Exception ex) { throw ex; }
            finally { cnn.Close(); }
        }
        protected void ImprimirUltimoticket()
        {
            if (ultimoTicket != 0)
            {
                DialogResult resp = MessageBox.Show("¿Desea obtener una vista previa del ticket antes de imprimirlo?", "Imprimir Ticket", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (resp != System.Windows.Forms.DialogResult.Cancel)
                {
                    if (resp == System.Windows.Forms.DialogResult.Yes)
                    {
                        _clsVentas.ImprimeTicket(ultimoTicket, false);
                    }
                    else
                    {
                        _clsVentas.ImprimeTicket(ultimoTicket, true);
                    }
                }
            }
        }

        private void cboMoneda_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            RadListElement SelectElement = ((RadDropDownList)sender).ListElement;
            //MessageBox.Show(SelectElement.SelectedValue.ToString());
            TipoCambioDia(SelectElement.SelectedValue.ToString());

        }

        private void LlenaMoneda()
        {
            OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
            try
            {
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT ID_MONEDA,DESCR_MONEDA FROM CAT_MONEDA ";
                OleDbDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cboMoneda.Items.Add(new RadListDataItem(dr["DESCR_MONEDA"].ToString(), dr["ID_MONEDA"].ToString()));
                }
                dr.Close();
                cboMoneda.SelectedIndex = 0;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally { cnn.Close(); }
        }

        private void TipoCambioDia(string Id_Moneda)
        {
            OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
            try
            {
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT * FROM TIPO_CAMBIODIA Where ID_MONEDA=@Id_moneda AND ACTIVO = TRUE";
                cmd.Parameters.Add("@Id_moneda", OleDbType.VarChar, 5).Value = Id_Moneda;
                OleDbDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    //MessageBox.Show(dr["TIPO_CAMBIO"].ToString() + "-" + dr["ID_TIPOCAMBIODIA"].ToString());
                    _id_Moneda = Id_Moneda;
                    _id_TipoCambiodia = int.Parse(dr["ID_TIPOCAMBIODIA"].ToString());
                    _tipo_Cambio = double.Parse(dr["TIPO_CAMBIO"].ToString());
                    txtTipoCambio.Text = dr["TIPO_CAMBIO"].ToString();
                }


                dr.Close();
                cboMoneda.SelectedIndex = 0;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            finally { cnn.Close(); }
        }



    }
}