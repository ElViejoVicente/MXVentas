using System;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using POS;
using POSDLL;
using POSDLL.Security;
using POSDLL.Ticket;
using ComCFDI_Sdk;
namespace POSApp.Forms
{
    public partial class frmGeneralConfiguration : Telerik.WinControls.UI.RadForm
    {
        public frmGeneralConfiguration()
        {
            InitializeComponent();
           
        }
        PrinterSettings printer = new PrinterSettings();
        EncryptDecrypt cripto = new EncryptDecrypt();
        private void frmConfigApp_Load(object sender, EventArgs e)
        {
           ReadINI();
           CargarDatos();
        }

        void ReadINI()
        {


            //Apariencia
            txtRutaImagen.Text = AppSettings.GetValue("GeneralConfig", "MainBackImage", "");
            //Ticket
            try
            {
                txtReportsFolder.Text = AppSettings.GetValue("Config", "ReportsFolder", "");
                //DataBAse
                txtDataSource.Text = AppSettings.GetValue("Config", "DataSource", "");
                txtDataBasePassword.Text = AppSettings.GetValue("Config", "DataBasePassword", cripto.Encrypt(""));
                //Ticket Printer
                txtPrinterName.Text = AppSettings.GetValue("Ticket", "TicketPrinterName", "");
                //Header
                txtHLine1.Text = AppSettings.GetValue("Ticket", "HLine1", "");
                txtHLine2.Text = AppSettings.GetValue("Ticket", "HLine2", "");
                txtHLine3.Text = AppSettings.GetValue("Ticket", "Hline3", "");
                txtHLine4.Text = AppSettings.GetValue("Ticket", "Hline4", "");
                txtHLine5.Text = AppSettings.GetValue("Ticket", "Hline5", "");
                //Footer
                txtFLine1.Text = AppSettings.GetValue("Ticket", "FLine1", "");
                txtFLine2.Text = AppSettings.GetValue("Ticket", "FLine2", "");
                txtFLine3.Text = AppSettings.GetValue("Ticket", "Fline3", "");
                txtFLine4.Text = AppSettings.GetValue("Ticket", "Fline4", "");
                txtFLine5.Text = AppSettings.GetValue("Ticket", "Fline5", "");
                //Font
                cboFontName.Text = AppSettings.GetValue("Ticket", "FontName", "Courier New"); ;
                cboFontSize.Text = AppSettings.GetValue("Ticket", "FontSize", "7");
                txtMaxChar.Text = AppSettings.GetValue("Ticket", "MaxChar", "40");
                txtMaxCharDescription.Text = AppSettings.GetValue("Ticket", "MaxCharDescription", "20");
                txtTicketImage.Text = AppSettings.GetValue("Ticket", "TicketImage", "");
                //Imprimir Ticket
                chkPrintTicket.Checked = Convert.ToBoolean(AppSettings.GetValue("Ticket", "PrintTicket", "true"));
                //Venta
                txtLIMITE_EFECTIVO.Text = AppSettings.GetValue("Venta", "LIMITE_EFECTIVO", "0");
                txtARTICULOS_FACTURA.Text = AppSettings.GetValue("Venta", "ARTICULOS_FACTURA", "0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la configuración del Ticket\n" + ex.Message,
                    "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        void WriteINI()
        {

            AppSettings.SetValue("Config", "ReportsFolder", txtReportsFolder.Text);
            //DataBase
            AppSettings.SetValue("Config", "DataSource", txtDataSource.Text);
            AppSettings.SetValue("Config", "DataBasePassword",txtDataBasePassword.Text);

            //Apariencia
            AppSettings.SetValue("GeneralConfig", "MainBackImage", txtRutaImagen.Text);
            //Ticket
            try
            {

                //Printer
                AppSettings.SetValue("Ticket", "TicketPrinterName", txtPrinterName.Text);
                //HEader
                AppSettings.SetValue("Ticket", "HLine1", txtHLine1.Text);
                AppSettings.SetValue("Ticket", "HLine2", txtHLine2.Text);
                AppSettings.SetValue("Ticket", "HLine3", txtHLine3.Text);
                AppSettings.SetValue("Ticket", "HLine4", txtHLine4.Text);
                AppSettings.SetValue("Ticket", "HLine5", txtHLine5.Text);
                //Footer
                AppSettings.SetValue("Ticket", "FLine1", txtFLine1.Text);
                AppSettings.SetValue("Ticket", "FLine2", txtFLine2.Text);
                AppSettings.SetValue("Ticket", "FLine3", txtFLine3.Text);
                AppSettings.SetValue("Ticket", "FLine4", txtFLine4.Text);
                AppSettings.SetValue("Ticket", "FLine5", txtFLine5.Text);
                //Font
                AppSettings.SetValue("Ticket", "FontName", cboFontName.Text);
                AppSettings.SetValue("Ticket", "FontSize", cboFontSize.Text);
                AppSettings.SetValue("Ticket", "MaxChar", txtMaxChar.Text);
                AppSettings.SetValue("Ticket", "MaxCharDescription", txtMaxCharDescription.Text);
                AppSettings.SetValue("Ticket", "TicketImage", txtTicketImage.Text);
                //Imprimir Ticket
                AppSettings.SetValue("Ticket", "PrintTicket", chkPrintTicket.Checked.ToString());
                //venta
                AppSettings.SetValue("Venta", "LIMITE_EFECTIVO", txtLIMITE_EFECTIVO.Text);
                AppSettings.SetValue("Venta", "ARTICULOS_FACTURA", txtARTICULOS_FACTURA.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la configuración del Ticket" + "\n" + ex.Message, "Información del Sistema");
            }




        }
        
        private void btnBuscaImagen_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog m_OpenFile = new OpenFileDialog();
            m_OpenFile.Title = "Buscar Imagen";
            m_OpenFile.Filter = "Todos los archivos" + "(*.*)|*.*|"+ "Imagenes soportadas" +"|*.jpg;*.gif";
            m_OpenFile.FilterIndex = 2;
            if (m_OpenFile.ShowDialog() == DialogResult.OK)
            {
                txtRutaImagen.Text = m_OpenFile.FileName.ToString();               
                
            }
          
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (txtARTICULOS_FACTURA.Text == "") { throw (new Exception("Debe indicar el total de articulos por factura"));}
                if (txtLIMITE_EFECTIVO.Text == ""){throw (new Exception("Debe indicar el limite de efectivo")); }
                if (txtPrinterName.Text == "") { throw (new Exception("Debe especificar el nombre de la impresora de Ticket")); }
                if (cboFontSize.Text == "") { throw (new Exception("Debe establecer el tamaño de la fuente")); }
                if (txtMaxChar.Text == "") { throw (new Exception("Debe la cantidad de caracteres por línea")); }
                if (txtMaxCharDescription.Text == "") { throw (new Exception("Debe establecer la cantidad de caracteres de la descripción")); }
                if ((txtTicketImage.Text != "") && (!File.Exists(txtTicketImage.Text))) { throw (new Exception("La imagen del ticket especificada no existe")); }
                if (!Directory.Exists(txtReportsFolder.Text)) { throw (new Exception("Carpeta de reportes no encontrada"));  }
                if (txtDataSource.Text == ""){ txtDataSource.Focus(); throw (new Exception("Falta indicar la base de datos"));  }
                printer.PrinterName = txtPrinterName.Text;
                if (!printer.IsValid){ throw (new Exception("La impresora especificada no es válida")); }
                Guardar();
                WriteINI();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error); }
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void btnSearchPrinter_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDialog _PrintDialog = new PrintDialog();
                DialogResult result = _PrintDialog.ShowDialog();

                // If the result is OK then print the document.
                if (result == DialogResult.OK)
                {
                    txtPrinterName.Text = _PrintDialog.PrinterSettings.PrinterName.ToString();
                }
            }
            catch
            {
                txtPrinterName.Text = "";
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try {
                if (txtPrinterName.Text == "") { throw (new Exception("Debe especificar el nombre de la impresora de Ticket")); }
                if (cboFontSize.Text == "") { throw (new Exception("Debe establecer el tamaño de la fuente")); }
                if (txtMaxChar.Text == "") { throw (new Exception("Debe la cantidad de caracteres por línea")); }
                if (txtMaxCharDescription.Text == "") { throw (new Exception("Debe establecer la cantidad de caracteres de la descripción")); }
                if ((txtTicketImage.Text != "") && (!File.Exists(txtTicketImage.Text))) { throw (new Exception("La imagen del ticket especificada no existe")); }
                printer.PrinterName = txtPrinterName.Text;
                if (!printer.IsValid)
                {
                    throw (new Exception("La impresora no es válida")); 
                }

                Ticket ticket = new Ticket();
                if ((txtTicketImage.Text != "") && (File.Exists(txtTicketImage.Text)))
                {
                    ticket.HeaderImage = Image.FromFile(txtTicketImage.Text); //esta propiedad no es obligatoria 
                }
                ticket.FontName = cboFontName.Text;
                ticket.FontSize = Convert.ToDouble(cboFontSize.Text);
                ticket.MaxChar = Convert.ToInt32(txtMaxChar.Text);
                ticket.MaxCharDescription = Convert.ToInt32(txtMaxCharDescription.Text);
               

                ticket.AddHeaderLine(txtHLine1.Text);
                ticket.AddHeaderLine(txtHLine2.Text);
                ticket.AddHeaderLine(txtHLine3.Text);
                ticket.AddHeaderLine(txtHLine4.Text);
                ticket.AddHeaderLine(txtHLine5.Text);
                //El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia 
                //de que al final de cada linea agrega una linea punteada "==========" 
                ticket.AddSubHeaderLine("Caja # 1 - Ticket # 1");
                ticket.AddSubHeaderLine("Le atendió: Prueba");
                ticket.AddSubHeaderLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());

                //El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion 
                //del producto y el tercero es el precio 
                ticket.AddItem("1", "Articulo Prueba", "15.00");
                ticket.AddItem("1", "Articulo Prueba con una descripción larga", "15.00");
                ticket.AddItem("1", "ARTICULO DE PRUEBA CON MAYUSCULAS CON DESCRIPCIÓN LARGA", "15.00");
                ticket.AddItem("2", "Articulo Prueba", "25.00");

                //El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio 
                ticket.AddTotal("SUBTOTAL", "29.75");
                ticket.AddTotal("IVA", "5.25");
                ticket.AddTotal("TOTAL", "35.00");
                ticket.AddTotal("", ""); //Ponemos un total en blanco que sirve de espacio 
                ticket.AddTotal("RECIBIDO", "50.00");
                ticket.AddTotal("CAMBIO", "15.00");
                ticket.AddTotal("", "");//Ponemos un total en blanco que sirve de espacio 
                ticket.AddTotal("USTED AHORRO", "0.00");

                //El metodo AddFooterLine funciona igual que la cabecera 
                ticket.AddFooterLine(txtFLine1.Text);
                ticket.AddFooterLine(txtFLine2.Text);
                ticket.AddFooterLine(txtFLine3.Text);
                ticket.AddFooterLine(txtFLine4.Text);
                ticket.AddFooterLine(txtFLine5.Text);
                //Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
                //parametro de tipo string que debe de ser el nombre de la impresora. 
                ticket.PrintTicketPreview(txtPrinterName.Text);
            }
            catch(Exception ex){
                MessageBox.Show("Error al mostrar el ticket.\n" + ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReportFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.RootFolder = Environment.SpecialFolder.Desktop;
            DialogResult res = dlg.ShowDialog();
            
            if (res == DialogResult.OK)
            {
                txtReportsFolder.Text = dlg.SelectedPath;
            }
        }
         
        private void btnCnnTest_Click(object sender, EventArgs e)
        {
            WriteINI();
            bool CnnTest = Class.clsMain.CnnTest();
            if (CnnTest)
            {
                MessageBox.Show("Prueba de Conexión Satisfactoria", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTicketImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog m_OpenFile = new OpenFileDialog();
            m_OpenFile.Title = "Buscar Imagen";
            m_OpenFile.Filter = "Todos los archivos" + "(*.*)|*.*|" + "Imagenes soportadas" + "|*.jpg;*.gif";
            m_OpenFile.FilterIndex = 2;
            if (m_OpenFile.ShowDialog() == DialogResult.OK)
            {
                txtTicketImage.Text = m_OpenFile.FileName.ToString();

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            OpenFileDialog m_OpenFile = new OpenFileDialog();
            m_OpenFile.Title = "Buscar base de datos";
            m_OpenFile.Filter = "Todos los archivos" + "(*.*)|*.*|" + "BAse de datos de Microsoft Access" + "|*.mdb;*.mdb";
            m_OpenFile.FilterIndex = 2;
            if (m_OpenFile.ShowDialog() == DialogResult.OK)
            {
            
                txtDataSource.Text = m_OpenFile.FileName;
            }
        }

        private void txtDataSource_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbExaCer_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Certificado *.cer|*.cer";
            if (open.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                txtRutaCer.Text = open.FileName;

                var cert = new ComCFDI_Sdk.Utilerias.Certificados.Certificado();
                cert.LeerCertificado(open.FileName);
                txtVigenciaDesde.Value = Convert.ToDateTime(cert.ValidoDesde);
                txtVigenciaHasta.Value = Convert.ToDateTime(cert.ValidoHasta);
                txtSerie.Text = cert.Serie;
                txtCertificadoBase64.Text = cert.CertificadoBase64;
            }
        }

        private void cmbExaKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Llave privada *.key|*.key";
            if (open.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                txtRutaKey.Text = open.FileName;
            }
        }

        public bool validaLlave(bool showMsg)
        {
            ComCFDI_Sdk.Utilerias.LlavePrivada.Llave llave = new ComCFDI_Sdk.Utilerias.LlavePrivada.Llave();
            if (llave.Validar(txtRutaKey.Text, txtPasswordKey.Text))
            {
                if (showMsg)
                {
                    //Generar llave de cancelación
                    string rutaUSO = System.IO.Path.GetDirectoryName(txtRutaKey.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(txtRutaKey.Text) + ".uso";
                    ComCFDI_Sdk.Utilerias.Extras.LlaveUSO llaveUSO = new ComCFDI_Sdk.Utilerias.Extras.LlaveUSO();
                    if (!llaveUSO.generarLlaveUSO(txtRutaCer.Text, txtRutaKey.Text, txtPasswordKey.Text, rutaUSO, txtPasswordKey.Text))
                    {
                        MessageBox.Show("No fué posible generar la llave de cancelación: " + llaveUSO.MensajeError, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    MessageBox.Show("¡Correcto!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return true;
            }
            else
            {
                MessageBox.Show("Llave o password no válido.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
        }

        private void cmbValidarKey_Click(object sender, EventArgs e)
        {
            if (txtCertificadoBase64.Text.Trim().Length > 0)
            {
                validaLlave(true);
            }
            else
            {
                MessageBox.Show("Seleccione el certificado.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cmbExamLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de imágen *.jpg|*.jpg";
            if (ofd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                txtRutaLogo.Text = ofd.FileName;
            }
        }

        private void cmbExaminar_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                txtRutaArchivos.Text = folder.SelectedPath + "\\";
            }
        }

        private void CargarDatos()
        {
            //Llenar los objetos
            Object _empresa  = new object();
            
            if (_empresa == null)
            {
                MessageBox.Show("No fué posible leer los datos de la empresa.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ////Llenar datos de la empresa
            //txtRFC.Text = _empresa.rfcEmpresa.Trim().ToUpper();
            //txtNombre.Text = _empresa.Nombre;
            //txtRegimenFiscal.Text = _empresa.RegimenFiscal;
            //txtPasswordTimbrado.Text = cGlobal.Decrypt(_empresa.Timbrado_Clave);

            ////llenar datos de la matriz

            ////Generales
            //txtLugarExpedicion.Text = _sucMatriz.LugarExpedicion;
            //txtCalle.Text = _sucMatriz.Calle;
            //txtNumExt.Text = _sucMatriz.NoExterior;
            //txtNumInt.Text = _sucMatriz.NoInterior;
            //txtCP.Value = _sucMatriz.CP;
            //cobColonia.Text = _sucMatriz.Colonia;
            //cobLocalidad.Text = _sucMatriz.Localidad;
            //cobMunicipio.Text = _sucMatriz.Municipio;
            //cobEstado.Text = _sucMatriz.Estado;
            //cobPais.Text = _sucMatriz.Pais;
            //txtReferencia.Text = _sucMatriz.Referencia;
            //txtRutaLogo.Text = _sucMatriz.Logotipo;

            ////Sello digital
            //txtRutaCer.Text = _sucMatriz.Sello_Certificado;
            //txtVigenciaDesde.Value = _sucMatriz.Sello_VigenciaDesde;
            //txtVigenciaHasta.Value = _sucMatriz.Sello_VigenciaHasta;
            //txtSerie.Text = _sucMatriz.Sello_Serie;
            //txtCertificadoBase64.Text = _sucMatriz.Sello_CertificadoBase64;
            //txtRutaKey.Text = _sucMatriz.Sello_Llave;
            //txtPasswordKey.Text = cGlobal.Decrypt(_sucMatriz.Sello_Clave);

            ////Correo electrónico
            //txtServidor.Text = _sucMatriz.Correo_Servidor;
            //txtPuerto.Value = _sucMatriz.Correo_Puerto;
            //txtCorreo.Text = _sucMatriz.Correo_Correo;
            //txtUsuario.Text = _sucMatriz.Correo_Usuario;
            //txtPasswordCorreo.Text = cGlobal.Decrypt(_sucMatriz.Correo_Clave);
            //chkSSL.Checked = _sucMatriz.Correo_RequiereSSL;
            //chkAutenticacion.Checked = _sucMatriz.Correo_RequiereAuth;
            //txtAsunto.Text = _sucMatriz.Correo_Asunto;
            //txtMensaje.Text = _sucMatriz.Correo_Mensaje;

            ////Directorio de trabajo
            //txtRutaArchivos.Text = _sucMatriz.DirectorioTrabajo;

            ////Licencia
            //txtClaveLicencia.Text = _sucMatriz.Licencia;
            //chkTimbrarModoPrueba.Checked = _sucMatriz.Timbrado_ModoPrueba;
        }

        private bool validarCampos()
        {
            if (!cGlobal.ComprobarCampo(txtLugarExpedicion.Text))
            {
                MessageBox.Show("El lugar de expedición es obligatorio.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (!cGlobal.ComprobarCampo(txtCalle.Text))
            {
                MessageBox.Show("La calle es obligatoria", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (!cGlobal.ComprobarCampo(cobMunicipio.Text))
            {
                MessageBox.Show("El municipio es obligatorio", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (!cGlobal.ComprobarCampo(cobEstado.Text))
            {
                MessageBox.Show("El estado es obligatorio", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (!cGlobal.ComprobarCampo(cobPais.Text))
            {
                MessageBox.Show("El país es obligatorio", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (!cGlobal.ComprobarCampo(txtRutaCer.Text))
            {
                MessageBox.Show("El certificado es obligatorio", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (!cGlobal.ComprobarCampo(txtRutaKey.Text))
            {
                MessageBox.Show("El certificado es obligatorio", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (!validaLlave(false))
            {
                return false;
            }

            if (!cGlobal.ComprobarCampo(txtRutaArchivos.Text))
            {
                MessageBox.Show("El directorio de trabajo es obligatorio", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }

        private void Guardar()
        {
            try
            {
                if (!validarCampos()) { return; }

           

                //Llenar datos de la empresa
                string varrfcEmpresa = txtRFC.Text.Trim().ToUpper();
                string varNombre = txtNombre.Text.Trim();
                string varRegimenFiscal = txtRegimenFiscal.Text.Trim();
                string varTimbrado_Clave = cGlobal.Encrypt(txtPasswordTimbrado.Text);

                //llenar datos de la matriz

                //Generales
                string varNombreSucursal = "Matriz";
                bool EsSucursal = chkSucursal.Checked ;
                string varLugarExpedicion = txtLugarExpedicion.Text.Trim();
                string varCalle = txtCalle.Text.Trim();
                string varNoExterior = txtNumExt.Text.Trim();
                string varNoInterior = txtNumInt.Text.Trim();
                string varCP =  txtCP.Text ;
                string varColonia = cobColonia.Text.Trim();
                string varLocalidad = cobLocalidad.Text.Trim();
                string varMunicipio = cobMunicipio.Text.Trim();
                string varEstado = cobEstado.Text.Trim();
                string varPais = cobPais.Text.Trim();
                string varReferencia = txtReferencia.Text.Trim();
                string varLogotipo = txtRutaLogo.Text.Trim();

                //Sello digital
                string varSello_Certificado = txtRutaCer.Text.Trim();
                DateTime Sello_VigenciaDesde = Convert.ToDateTime(txtVigenciaDesde.Value);
                DateTime Sello_VigenciaHasta = Convert.ToDateTime(txtVigenciaHasta.Value);
                string varSello_Serie = txtSerie.Text;
                string varSello_CertificadoBase64 = txtCertificadoBase64.Text;
                string varSello_Llave = txtRutaKey.Text.Trim();
                string varSello_Clave = cGlobal.Encrypt(txtPasswordKey.Text);

                //Correo electrónico
                string varCorreo_Servidor = txtServidor.Text.Trim();
                int Correo_Puerto = Convert.ToInt32(txtPuerto.Value);
                string varCorreo_Correo = txtCorreo.Text.Trim();
                string varCorreo_Usuario = txtUsuario.Text.Trim();
                string varCorreo_Clave = cGlobal.Encrypt(txtPasswordCorreo.Text);
                bool varCorreo_RequiereSSL = chkSSL.Checked;
                bool varCorreo_RequiereAuth = chkAutenticacion.Checked;
                string varCorreo_Asunto = txtAsunto.Text.Trim();
                string varCorreo_Mensaje = txtMensaje.Text;

                //Directorio de trabajo
                string varDirectorioTrabajo = txtRutaArchivos.Text.Trim();

                //Licencia
                string varLicencia = txtClaveLicencia.Text;
                bool varTimbrado_ModoPrueba = chkTimbrarModoPrueba.Checked;

              

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }
}