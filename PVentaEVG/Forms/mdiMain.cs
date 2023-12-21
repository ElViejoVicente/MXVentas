using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSDLL; using POSDLL.Windows.Forms; using POSDLL.Security; using POSDLL.Reporting; using POSDLL.Ticket;
using Microsoft.Reporting.WinForms;
using System.IO;
namespace POSApp.Forms
{
    public partial class mdiMain : Telerik.WinControls.UI.RadForm
    {
        public mdiMain()
        {
            InitializeComponent();
        }
        //Para manipular el ini 
         //Para encryptar strings
        DateTime SalesStartDate = DateTime.Now;
        private void mdiMain_Load(object sender, EventArgs e)
        {
            Class.clsMain.Exit = true;
            this.Text = "Sistema de punto de venta -Terminal: " +
               Forms.frmLogin._NOMBRE + " " +
               Forms.frmLogin._PATERNO + " " +
               Forms.frmLogin._MATERNO;

            //if (!Class.clsMain.Activado())
            //{
            //    MessageBox.Show("El sistema no esta activado o finalizo su periodo de Prueba, por favor solicite su lleva de activacion..", "Información del Sistena", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    mnuVentas.Enabled = false;
            //    RadcmdBar.Enabled = false;
            //    //btnRptCorteDeCaja.Visible = false;
            //    //btnInventario.Enabled = false;
            //    mnuAdministrar.Enabled = false;
            //    mnuReportes.Enabled = false;
            //    mnuCatalogo.Enabled = false;
            //    mnuCatProductos.Enabled = false;
            //    mnuCatMarca.Enabled = false;
            //    mnuCatGrupo.Enabled = false;
            //    mnuCatUnidadesMedida.Enabled = false;
            //    //btnFacturacion.Enabled = false;
            //    mnuCredito.Enabled = false;
            //    //btnBuscarArticulos.Enabled = false;
            //    mnuFacturacion.Enabled = false;
            //    mnuGastos.Enabled = false;
            //    mnuChangePass.Enabled = false;
            //    mnuLogOff.Enabled = false;
            //    return;
            //}
            mnuVentas.Visible = Forms.frmLogin._VENTAS;
            cmdVentas.VisibleInStrip   = Forms.frmLogin._VENTAS;
            cmdCorteCaja.VisibleInStrip = Forms.frmLogin._VENTAS;
            cmdInventario.VisibleInStrip = frmLogin._INVENTARIOS;        
            mnuAdministrar.Visible= Forms.frmLogin._ADMINISTRAR;
            mnuReportes.Visible= Forms.frmLogin._REPORTES;       
            mnuCatalogo.Visible = Forms.frmLogin._CATALOGOS;
            mnuCatProductos.Visible = frmLogin._INVENTARIOS;



            try
            {
                //this.BackgroundImageLayout = ImageLayout.Stretch;
                this.BackgroundImage =
                    Image.FromFile(AppSettings.GetValue("GeneralConfig", "MainBackImage"));
            }
            catch
            {
                this.BackColor = Form.DefaultBackColor;
            }
        }

        
        private void mnuAcercaDe_Click(object sender, EventArgs e)
        {
            frmAbout myForm = new Forms.frmAbout();
            myForm.ShowDialog();  
        }

        private void mnuCatProductos_Click(object sender, EventArgs e)
        {
            ListaProductos();  
        }

        

        private void mnuVentas_Click(object sender, EventArgs e)
        {
            Ventas();
        }
        void Ventas()
        {
            int varIdPOS = fnCajaUSuario(frmLogin._USER_LOGIN);
            TimeSpan tim = DateTime.Now.Subtract(SalesStartDate);
            //MessageBox.Show(String.Format("Days: {0}\nHours: {1}", tim.Days.ToString(), tim.Hours.ToString()));
            if (tim.Hours > 13) {
                MessageBox.Show("Antes de continuar con el registro de ventas,\nes necesario hacer el corte de caja.",
                    "Información del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            if (varIdPOS != 0)
            {
                //si el usuario ya tiene una caja abierta
                frmVentas _frmSale = new frmVentas(frmLogin._USER_LOGIN,varIdPOS);
                _frmSale.StartPosition = FormStartPosition.CenterScreen;
                _frmSale.WindowState = FormWindowState.Maximized;
                _frmSale.ShowInTaskbar = false;
                _frmSale.ShowDialog();
            }
            else
            {
                //si el usuario aun no abre una caja
                frmVentasPOS _frmSalePOS = new frmVentasPOS();
                _frmSalePOS.StartPosition = FormStartPosition.CenterScreen;
                _frmSalePOS.ShowInTaskbar = false;
                _frmSalePOS.ShowDialog();
                if (_frmSalePOS.IdPOS != 0)
                {
                    frmVentas _frmSale = new frmVentas(frmLogin._USER_LOGIN,_frmSalePOS.IdPOS);
                    _frmSale.StartPosition = FormStartPosition.CenterScreen;
                    _frmSale.WindowState = FormWindowState.Maximized;
                    _frmSale.ShowInTaskbar = false;
                    _frmSale.ShowDialog();
                }
            }
        }
        
        public int fnCajaUSuario(string prmUSER_LOGIN)
        {
            SalesStartDate = DateTime.Now;
            OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
            object ret = 0;
            try
            {
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT ID_CAJA,SALE_DATE FROM vSALE_POS WHERE USER_LOGIN=@USER_LOGIN AND DISPONIBLE=FALSE";
                //Parámetros
                cmd.Parameters.Add("@USER_LOGIN", OleDbType.VarChar, 50).Value = prmUSER_LOGIN;
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr["ID_CAJA"] == DBNull.Value) { ret = 0; }
                    else
                    {
                        ret = Convert.ToInt32(dr["ID_CAJA"]);
                    }
                    if (dr["SALE_DATE"] == DBNull.Value) { SalesStartDate = DateTime.Now; }
                    else
                    {
                        SalesStartDate = Convert.ToDateTime(dr["SALE_DATE"]);
                    }
                }
                dr.Close();
                cmd.Parameters.Clear();
                return (Convert.ToInt32(ret));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (0);
            }
            finally
            {
                cnn.Close();
            }
        }
        private void mnuCatMarca_Click(object sender, EventArgs e)
        {
            frmCatBrandsList.DefInstance.MdiParent = this;
            frmCatBrandsList.DefInstance.Show();
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            Forms.frmAbout _frmAbout = new Forms.frmAbout();
            _frmAbout.StartPosition = FormStartPosition.CenterScreen;
            _frmAbout.ShowDialog();
        }

      

        

        private void mnuUsers_Click(object sender, EventArgs e)
        {
            Forms.frmUsers.DefInstance.MdiParent = this;
            Forms.frmUsers.DefInstance.Show();
        }

        private void mnuNuevaEntrada_Click(object sender, EventArgs e)
        {
            Forms.frmEntrada _frmEntrada = new Forms.frmEntrada();
            _frmEntrada.MdiParent = this;
            _frmEntrada.StartPosition = FormStartPosition.Manual;
            _frmEntrada.Show();

            //Forms.frmFactura _frmEntrada = new Forms.frmFactura();
            //_frmEntrada.MdiParent = this;
            //_frmEntrada.StartPosition = FormStartPosition.Manual;
            //_frmEntrada.Show();
        }

        private void mnuListaEntradas_Click(object sender, EventArgs e)
        {
            frmEntradasLista _frmListaEntradas = new frmEntradasLista();
            _frmListaEntradas.StartPosition = FormStartPosition.Manual;
            _frmListaEntradas.MdiParent = this;
            _frmListaEntradas.Show();
        }

        private void mnuRptVentas_Click(object sender, EventArgs e)
        { 
            frmRptVentas oFrm = new frmRptVentas();
            oFrm.MdiParent = this;
            oFrm.WindowState = FormWindowState.Maximized;
            oFrm.Show();
        }

        private void mnuVentasArticulo_Click(object sender, EventArgs e)
        { 
            frmRptVentasArticulo oFrm = new frmRptVentasArticulo();
            oFrm.MdiParent = this;
            oFrm.WindowState = FormWindowState.Maximized;
            oFrm.Show();
        }

        private void mnuRptTendenciaVentas_Click(object sender, EventArgs e)
        {
            frmRptTendenciaVenta oRptTendenciaVenta = new frmRptTendenciaVenta();
            oRptTendenciaVenta.MdiParent = this;
            oRptTendenciaVenta.WindowState = FormWindowState.Maximized;
            oRptTendenciaVenta.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            ListaProductos();
        }
        void ListaProductos() {

            frmProductosLista oFrmProductosLista = new frmProductosLista();
            oFrmProductosLista.MdiParent = this;
            oFrmProductosLista.WindowState = FormWindowState.Maximized;
            oFrmProductosLista.Show();
        }
        void ListaFacturas()
        {
            frmFacturasLista oFacturasLista = new frmFacturasLista();
            oFacturasLista.MdiParent = this;
            oFacturasLista.WindowState = FormWindowState.Maximized;
            oFacturasLista.Show();
            
        }
        private void btnVentas_Click(object sender, EventArgs e)
        {
            Ventas();
        }

        private void mnuCatClientes_Click(object sender, EventArgs e)
        {
            frmClientesLista oFrm = new frmClientesLista();
            oFrm.MdiParent = this;
            oFrm.WindowState = FormWindowState.Maximized;
            oFrm.Show();
        }

        private void mnuCatProveedores_Click(object sender, EventArgs e)
        {
            frmProveedoresLista oFrm = new frmProveedoresLista();
            oFrm.MdiParent = this;
            oFrm.WindowState = FormWindowState.Maximized;
            oFrm.Show();
        }

       
        private void mnuRptVentasVendedor_Click(object sender, EventArgs e)
        {
            frmRptVentasVendedor oFrm = new frmRptVentasVendedor();
            oFrm.MdiParent = this;
            oFrm.WindowState = FormWindowState.Maximized;
            oFrm.Show();
        }

        private void mnuCatEmpleado_Click(object sender, EventArgs e)
        {
            frmEmpleadosLista oFrm = new frmEmpleadosLista();
            oFrm.MdiParent = this;
            oFrm.WindowState = FormWindowState.Maximized;
            oFrm.Show();
        }

 

        private void mnuConfiguracionGeneral_Click(object sender, EventArgs e)
        {
            frmGeneralConfiguration _frmConfigApp = new frmGeneralConfiguration();
            _frmConfigApp.StartPosition = FormStartPosition.CenterScreen;
            _frmConfigApp.ShowDialog();
        }

        private void mnuCancelarVenta_Click(object sender, EventArgs e)
        {
            frmVentaCancelar _frmCancelarVenta = new frmVentaCancelar();
            _frmCancelarVenta.StartPosition = FormStartPosition.CenterScreen;
            _frmCancelarVenta.ShowDialog();
        }

        private void mnuFacturar_Click(object sender, EventArgs e)
        {
            //Forms.frmListaProductos myForm = new Forms.frmListaProductos();
            //myForm.MdiParent = this;
            //myForm.Show();  
        }

       

        private void mnuChangePass_Click(object sender, EventArgs e)
        {
            frmUserRestorePass _frmRestorePass = new frmUserRestorePass(frmLogin._USER_LOGIN);
            _frmRestorePass.StartPosition = FormStartPosition.CenterScreen;
            _frmRestorePass.ShowDialog();
        }

        private void btnFacturacion_Click(object sender, EventArgs e)
        {
            ListaFacturas();
        }

        private void mnuFacturacion_Click(object sender, EventArgs e)
        {
            ListaFacturas();
        }

        private void mnuProductosExistenciaCritica_Click(object sender, EventArgs e)
        { 
            frmRptProductosMinimos oFrm = new frmRptProductosMinimos();
            oFrm.MdiParent = this;
            oFrm.WindowState = FormWindowState.Maximized;
            oFrm.Show();

        }

        private void mnuRptComprobanteFiscal_Click(object sender, EventArgs e)
        {
            //Forms.frmRptComprobanteFiscal _frmRptComprobanteFiscal = new frmRptComprobanteFiscal();
            //_frmRptComprobanteFiscal.MdiParent = this;
            //_frmRptComprobanteFiscal.Show();
        }

        private void mnuCancelarVentaToda_Click(object sender, EventArgs e)
        {
            
        }

        

        private void mnuAjustesInventario_Click(object sender, EventArgs e)
        {
            
            frmAjustesInventarioLista oFrm = new frmAjustesInventarioLista();
            oFrm.MdiParent = this;
            oFrm.WindowState = FormWindowState.Maximized;
            oFrm.Show();
        }

        private void mnuCatGrupo_Click(object sender, EventArgs e)
        {
            frmCatGroupList oFrm = new frmCatGroupList();
            oFrm.MdiParent = this;
            oFrm.WindowState = FormWindowState.Maximized;
            oFrm.Show();
        }

        private void mnuCatUnidadesMedida_Click(object sender, EventArgs e)
        { 
            frmCatMeasurmentUnitList oFrm = new frmCatMeasurmentUnitList();
            oFrm.MdiParent = this;
            oFrm.WindowState = FormWindowState.Maximized;
            oFrm.Show();
        }

        private void mnuCatFormulacion_Click(object sender, EventArgs e)
        {
            //frmCatFormulacion _frmCatFormulacion = new frmCatFormulacion();
            //_frmCatFormulacion.MdiParent = this;
            //_frmCatFormulacion.Show();
        }

        private void mnuCatPresentacion_Click(object sender, EventArgs e)
        {
            //frmCatPresentacion _frmCatPresentacion = new frmCatPresentacion();
            //_frmCatPresentacion.MdiParent = this;
            //_frmCatPresentacion.Show();
        }

        private void mnuSustanciasActivas_Click(object sender, EventArgs e)
        {
            //frmCatSustanciaActiva _frmCatSustanciaActiva = new frmCatSustanciaActiva();
            //_frmCatSustanciaActiva.MdiParent = this;
            //_frmCatSustanciaActiva.Show();
        }

        private void mnuCorteDeCaja_Click(object sender, EventArgs e)
        {
           
        }

        private void mnuDevolucionesSobreVenta_Click(object sender, EventArgs e)
        {
            
        }

        private void artículosSinCódigoDeBarrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptArticulosSinCodigo oFrm = new frmRptArticulosSinCodigo();
            oFrm.MdiParent = this;
            oFrm.WindowState = FormWindowState.Maximized;
            oFrm.Show();
        }

        private void btnBuscarArticulos_Click(object sender, EventArgs e)
        { 
            frmBuscaProducto oFrm = new frmBuscaProducto();
            oFrm.MdiParent = this;
            oFrm.WindowState = FormWindowState.Maximized;
            oFrm.Show();

        }

        private void mnuCatIndicacion_Click(object sender, EventArgs e)
        {
            //frmCatIndicacion _frmCatIndicacion = new frmCatIndicacion();
            //_frmCatIndicacion.MdiParent = this;
            //_frmCatIndicacion.Show();
        }

        private void mnuCatTipoAjuste_Click(object sender, EventArgs e)
        {
            frmCatTipoAjuste.DefInstance.MdiParent = this;
            frmCatTipoAjuste.DefInstance.Show();
        }

       

        private void mnuVentanasCascada_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);

        }

        private void mnuVentanasVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }

        private void mnuVentanasHorizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }



        private void mnuBackupDataBase_Click(object sender, EventArgs e)
        {
            frmBackupDataBase _frmBackupDataBase = new frmBackupDataBase();
            _frmBackupDataBase.StartPosition = FormStartPosition.CenterScreen;
            _frmBackupDataBase.ShowDialog();
        }

        private void mnuCorteCaja_Click(object sender, EventArgs e)
        {
            //dESDE EL MENU
            MoneyCounting(true);
        }

        void MoneyCounting(bool FromMenu)
        {
            frmRptMoneyCounting frm = new frmRptMoneyCounting(FromMenu);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void mnuRptVentasClienteArticulo_Click(object sender, EventArgs e)
        { 
            frmRptVentasClienteArticulo oFrm = new frmRptVentasClienteArticulo();
            oFrm.MdiParent = this;
            oFrm.WindowState = FormWindowState.Maximized;
            oFrm.Show();
        }

        private void mnuGastos_Click(object sender, EventArgs e)
        { 
            frmGastoLista oFrm = new frmGastoLista();
            oFrm.MdiParent = this;
            oFrm.WindowState = FormWindowState.Maximized;
            oFrm.Show();
        }

       

        private void frmRptVentaArticuloCantidad_Click(object sender, EventArgs e)
        { 
            frmRptVentasArticuloCantidad oFrm = new frmRptVentasArticuloCantidad();
            oFrm.MdiParent = this;
            oFrm.WindowState = FormWindowState.Maximized;
            oFrm.Show();
        
        }

        private void mnuRptEntradas_Click(object sender, EventArgs e)
        { 
            frmRptEntradaArticulos oFrm = new frmRptEntradaArticulos();
            oFrm.MdiParent = this;
            oFrm.WindowState = FormWindowState.Maximized;
            oFrm.Show();
        }

        private void mnuInventariofisico_Click(object sender, EventArgs e)
        { 
            frmInventarioFisico oFrm = new frmInventarioFisico();
            oFrm.MdiParent = this;
            oFrm.WindowState = FormWindowState.Maximized;
            oFrm.Show();
        }

        private void mnuRptValorInventario_Click(object sender, EventArgs e)
        {
            ImprimeReporte("Valor de inventario","");
        }

        public void ImprimeReporte(string prmTitle,string prmComments)
        {
            try
            {
                string varSQL = "";
                string _FileName = AppSettings.GetValue("Config", "ReportsFolder", Application.StartupPath);
                _FileName += "\\rptValorInventario.rdlc";
                if (!File.Exists(_FileName))
                {
                    MessageBox.Show(String.Format("No se encuentra el archivo {0}\nRevise por favor.", _FileName), "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                varSQL = "SELECT ID_PRODUCTO,DESC_PRODUCTO,EXISTENCIA,PRECIO_VENTA FROM CAT_PRODUCTO";

                DataSet dsReporte = new DataSet(); //Datset para el reporte
                OleDbConnection cnnReporte = new OleDbConnection(Class.clsMain.CnnStr);
                cnnReporte.Open();
                dsReporte.Clear();//limpiamos el dataset
                OleDbDataAdapter daReporte =
                    new OleDbDataAdapter(varSQL, cnnReporte);
                daReporte.Fill(dsReporte, "rptValorInventario");//llenamos el DataSet con la info de la FACTURA
                daReporte.Dispose();

                cnnReporte.Dispose();
                //ya tenoemos la info en el DataSet, ahora cargamos el reporte

                if (dsReporte.Tables["rptValorInventario"].Rows.Count == 0)
                {
                    cnnReporte.Close();
                    MessageBox.Show("No hay datos para mostrar.", "Información del sistema");
                    return;
                }

                Forms.frmReports frm = new Forms.frmReports();

                frm.rvDoc.LocalReport.DataSources.Clear();
                frm.rvDoc.LocalReport.Dispose();
                frm.rvDoc.Reset();
                frm.rvDoc.LocalReport.DataSources.Add(new ReportDataSource("rptValorInventario", dsReporte.Tables["rptValorInventario"]));
                frm.rvDoc.LocalReport.ReportPath = _FileName;
               
               
                frm.rvDoc.RefreshReport();
                frm.ShowDialog();

                cnnReporte.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loading Ticket Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //"SELECT * FROM vVALOR_INVENTARIO_GRUPO";
        public void ImprimeReporteGrupo(string prmTitle, string prmComments)
        {
            try
            {
                string varSQL = "";
                string _FileName = AppSettings.GetValue("Config", "ReportsFolder", Application.StartupPath);
                _FileName += "\\rptValorInvGrupo.rdlc";
                if (!File.Exists(_FileName))
                {
                    MessageBox.Show(String.Format("No se encuentra el archivo {0}\nRevise por favor.", _FileName), "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                varSQL = "SELECT * FROM vVALOR_INVENTARIO_GRUPO";

                DataSet dsReporte = new DataSet(); //Datset para el reporte
                OleDbConnection cnnReporte = new OleDbConnection(Class.clsMain.CnnStr);
                cnnReporte.Open();
                dsReporte.Clear();//limpiamos el dataset
                OleDbDataAdapter daReporte =
                    new OleDbDataAdapter(varSQL, cnnReporte);
                daReporte.Fill(dsReporte, "rptValorInvGrupo");//llenamos el DataSet con la info de la FACTURA
                daReporte.Dispose();

                cnnReporte.Dispose();
                //ya tenoemos la info en el DataSet, ahora cargamos el reporte

                if (dsReporte.Tables["rptValorInvGrupo"].Rows.Count == 0)
                {
                    cnnReporte.Close();
                    MessageBox.Show("No hay datos para mostrar.", "Información del sistema");
                    return;
                }

                Forms.frmReports frm = new Forms.frmReports();

                frm.rvDoc.LocalReport.DataSources.Clear();
                frm.rvDoc.LocalReport.Dispose();
                frm.rvDoc.Reset();
                frm.rvDoc.LocalReport.DataSources.Add(new ReportDataSource("rptValorInvGrupo", dsReporte.Tables["rptValorInvGrupo"]));
                frm.rvDoc.LocalReport.ReportPath = _FileName;


                frm.rvDoc.RefreshReport();
                frm.ShowDialog();

                cnnReporte.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loading Ticket Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuRptInventariosFisicos_Click(object sender, EventArgs e)
        { 
            frmRptInventarioFisico oFrm = new frmRptInventarioFisico();
            oFrm.MdiParent = this;
            oFrm.WindowState = FormWindowState.Maximized;
            oFrm.Show();
        }

        private void mnuRptValorInventarioGrupo_Click(object sender, EventArgs e)
        {
            ImprimeReporteGrupo("VALOR DEL INVENTARIO", "");
        }

        

       

        private void mnuFacturarServicio_Click(object sender, EventArgs e)
        {
            //frmFacturaServicioListas _frm = new frmFacturaServicioListas();
            //_frm.MdiParent = this;
            //_frm.Show();
        }

        private void mnuDevolucionesSobreVenta_Click_1(object sender, EventArgs e)
        {
            //frmDevolucionesSobreVenta _frm = new frmDevolucionesSobreVenta();
            //_frm.StartPosition = FormStartPosition.CenterScreen;
            //_frm.MdiParent = this;
            //_frm.Show();
        }

        

        private void mnuSeguimientoVentasClienteArticulo_Click(object sender, EventArgs e)
        { 
            frmRptVentasClienteArticulo oFrm = new frmRptVentasClienteArticulo();
            oFrm.MdiParent = this;
            oFrm.WindowState = FormWindowState.Maximized;
            oFrm.Show();
        }

        private void mnuRptGastos_Click(object sender, EventArgs e)
        { 
            frmRptGastos oFrm = new frmRptGastos();
            oFrm.MdiParent = this;
            oFrm.WindowState = FormWindowState.Maximized;
            oFrm.Show();
        }

        private void mnuCatTipoGasto_Click(object sender, EventArgs e)
        { 
            frmCatTipoGasto oFrm = new frmCatTipoGasto();
            oFrm.MdiParent = this;
            oFrm.WindowState = FormWindowState.Maximized;
            oFrm.Show();
        }

        private void mnuRptCostoPorPlatillo_Click(object sender, EventArgs e)
        { 
            frmRptCostoPorPlatillo oFrm = new frmRptCostoPorPlatillo();
            oFrm.MdiParent = this;
            oFrm.WindowState = FormWindowState.Maximized;
            oFrm.Show();
        }

       

        private void mnuRptVentasUtilidad_Click(object sender, EventArgs e)
        { 
            frmRptVentasUtilidad oFrm = new frmRptVentasUtilidad();
            oFrm.MdiParent = this;
            oFrm.WindowState = FormWindowState.Maximized;
            oFrm.Show();
        }

      

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Class.clsMain.Exit = true;
            this.Close();
        }

        private void propinasPorEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            frmRptPropinasEmpleado oFrm = new frmRptPropinasEmpleado();
            oFrm.MdiParent = this;
            oFrm.WindowState = FormWindowState.Maximized;
            oFrm.Show();
        }

        private void mnuRptTiposPago_Click(object sender, EventArgs e)
        { 
            frmRptTiposPago oFrm = new frmRptTiposPago();
            oFrm.MdiParent = this;
            oFrm.WindowState = FormWindowState.Maximized;
            oFrm.Show();
        }

        private void mnuRptSueldos_Click(object sender, EventArgs e)
        { 
            frmRptSueldos oFrm = new frmRptSueldos();
            oFrm.MdiParent = this;
            oFrm.WindowState = FormWindowState.Maximized;
            oFrm.Show();
        }

        private void mnuRptSalidas_Click(object sender, EventArgs e)
        { 
            frmRptSalidaArticulos oFrm = new frmRptSalidaArticulos();
            oFrm.MdiParent = this;
            oFrm.WindowState = FormWindowState.Maximized;
            oFrm.Show();
        }

        private void mnuCredito_Click(object sender, EventArgs e)
        { 
            frmCreditoLista oFrm = new frmCreditoLista();
            oFrm.MdiParent = this;
            oFrm.WindowState = FormWindowState.Maximized;
            oFrm.Show();
        }

        private void btnLogOff_Click(object sender, EventArgs e)
        {
            Class.clsMain.Exit = false;
            this.Close();
        }

        private void mnuActivationKey_Click(object sender, EventArgs e)
        {
            frmActivationKey frm = new frmActivationKey();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            if (frm.Success) {
                MessageBox.Show("Se reiniciará la aplicación para validar los cambios", 
                    "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Class.clsMain.Exit = false;
                this.Close();
            }
        }

     

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MoneyCounting(false);
        }

        private void mnuCambiarPrecios_Click(object sender, EventArgs e)
        {
            frmProductoCambiarPrecios frm = new frmProductoCambiarPrecios();
            frm.ShowInTaskbar = false;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void mnuPrestamos_Click(object sender, EventArgs e)
        { 
            frmPrestamoLista oFrm = new frmPrestamoLista();
            oFrm.MdiParent = this;
            oFrm.WindowState = FormWindowState.Maximized;
            oFrm.Show();
        }

        private void btnPedido_Click(object sender, EventArgs e)
        { 
            frmPedido oFrm = new frmPedido();
            oFrm.MdiParent = this;
            oFrm.WindowState = FormWindowState.Maximized;
            oFrm.Show();
        }

        private void btnCotizacion_Click(object sender, EventArgs e)
        { 
            frmCotizacion oFrm = new frmCotizacion();
            oFrm.MdiParent = this;
            oFrm.WindowState = FormWindowState.Maximized;
            oFrm.Show();
        }

        private void mnuRptCorteDeCajaReimprimir_Click(object sender, EventArgs e)
        { 
            frmRptMoneyCountingList oFrm = new frmRptMoneyCountingList();
            oFrm.MdiParent = this;
            oFrm.WindowState = FormWindowState.Maximized;
            oFrm.Show();
        }

      
        

       
    }
}