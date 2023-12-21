using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;
using ComCFDI_Sdk.Utilerias.CBB;
using ComCFDI_Sdk.Utilerias.CadenaOriginal;
using ComCFDI_Sdk.Utilerias.Certificados;
using ComCFDI_Sdk.Utilerias.LeerXml;
using ComCFDI_Sdk.Utilerias.SelloDigital;
using ComCFDI_Sdk.Utilerias.TimbreFiscal;
using ComCFDI_Sdk.WS;
using POSDLL;
using System.IO;
using EasyCFDI.Comprobante;

namespace POSApp.Forms
{
    public partial class frmFactura : Telerik.WinControls.UI.RadForm
    {
        public frmFactura()
        {
            InitializeComponent();
            varFOLIO_VENTA = 0;
        }
        public frmFactura(int prmFOLIO_VENTA)
        {
            InitializeComponent();
            varFOLIO_VENTA = prmFOLIO_VENTA;
        }
        public static bool _Accion = false;
        int varFOLIO_VENTA = 0;
        private void frmFactura_Load(object sender, EventArgs e)
        {
            txtFOLIO_VENTA.KeyPress += new KeyPressEventHandler(txtFOLIO_VENTA_KeyPress);
            txtID_CLIENTE.KeyPress += new KeyPressEventHandler(txtID_CLIENTE_KeyPress);
            txtFOLIO_FACTURA.Text = fnFOLIO_FACTURA_NEXT();
        }
        private string fnFOLIO_FACTURA_NEXT()
        {
            try
            {
                OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
                cnn.Open();
                string ret = "";

                OleDbCommand cmd = new OleDbCommand("SELECT TOP 1 FOLIO_FACTURA FROM FACTURA_CONTROL ORDER BY FECHA_FACTURA DESC ", cnn);
                ret = cmd.ExecuteScalar().ToString();
                cnn.Close();
                cmd.Dispose();
                cnn.Dispose();
                //generamos el folio

                ret = Convert.ToString(Convert.ToInt32(ret) + 1);
                return (ret);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return ("");
            }
        }
        void txtID_CLIENTE_KeyPress(object sender, KeyPressEventArgs e)
        {
       
        }

        void txtFOLIO_VENTA_KeyPress(object sender, KeyPressEventArgs e)
        {
       
        }

        private void btnBuscarTicket_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaTicket myForm = new frmBuscaTicket();
                myForm.StartPosition = FormStartPosition.CenterScreen;
                myForm.ShowDialog();
                if (frmBuscaTicket.varFOLIO_VENTA != 0)
                {
                    if (txtFOLIO_VENTA.Text == "")
                    {
                        txtFOLIO_VENTA.Text =    frmBuscaTicket.varFOLIO_VENTA.ToString();
                    }
                    else {
                        txtFOLIO_VENTA.Text =  txtFOLIO_VENTA.Text + "," +  frmBuscaTicket.varFOLIO_VENTA.ToString();
                    }

                }
                myForm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((txtFOLIO_VENTA.Text != "") && (txtFOLIO_FACTURA.Text != "") && txtID_CLIENTE.Text != "")
            {
                if (fnFACTURA(txtFOLIO_VENTA.Text,  txtFOLIO_FACTURA.Text, dtpFECHA_FACTURA.Value,  txtOBSERVACIONES.Text, frmLogin._USER_LOGIN, Convert.ToInt32(txtID_CLIENTE.Text)))
                {
                    this.Close();
                }
            }
            else {
                MessageBox.Show("Faltan Datos", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool fnFACTURA(string prmFOLIO_VENTA,string prmFOLIO_FACTURA, DateTime  prmFECHA_FACTURA, string prmOBSERVACIONES, string prmUSER_LOGIN, int prmID_CLIENTE)
        {
            OleDbConnection cnnPAGO = new OleDbConnection(Class.clsMain.CnnStr);
            cnnPAGO.Open();
            OleDbCommand cmdPAGO = new OleDbCommand();
            OleDbTransaction tran = cnnPAGO.BeginTransaction();
            cmdPAGO.Connection = cnnPAGO;
            cmdPAGO.Transaction = tran;
            int RowCount = 0;
            string[] folios = null;
            try
            {
                #region movimientos de ticket a factura
                if (prmFOLIO_VENTA == "") {
                    throw (new Exception("Error en el folio"));
                }

                folios = prmFOLIO_VENTA.Split(',');

               
                foreach (string f in folios)
                {
                    RowCount = 0;//Reiniciar contador
                    //checamos que el ticket exista
                    cmdPAGO.CommandText = "SELECT COUNT(*) FROM VENTA WHERE FOLIO =@folio";
                    cmdPAGO.Parameters.Add("@folio", OleDbType.Integer).Value = f;
                    RowCount = Convert.ToInt32(cmdPAGO.ExecuteScalar());
                    cmdPAGO.Parameters.Clear();
                    if (RowCount == 0)
                    {
                        throw (new Exception(String.Format("El Ticket {0} no existe", f)));
                    }
                    RowCount = 0;//Reiniciar contador
                    //checamos que tenga articulos en ceros
                    cmdPAGO.CommandText = "SELECT COUNT(*) FROM VENTA_DETALLE WHERE FOLIO =@folio AND CANTIDAD=0";
                    cmdPAGO.Parameters.Add("@folio", OleDbType.Integer).Value = f;
                    RowCount = Convert.ToInt32(cmdPAGO.ExecuteScalar());
                    cmdPAGO.Parameters.Clear();
                    if (RowCount >= 1)
                    {
                        throw (new Exception(String.Format("el Ticket {0} no tiene artículos", f)));
                    }

                    RowCount = 0;//Reiniciar  ontador
                    cmdPAGO.CommandText = "SELECT COUNT(*) FROM FACTURA_CONTROL WHERE FOLIO_VENTA=@folio AND CANCELAR=FALSE";
                    cmdPAGO.Parameters.Add("@folio", OleDbType.Integer).Value = f;
                    RowCount = Convert.ToInt32(cmdPAGO.ExecuteScalar());
                    cmdPAGO.Parameters.Clear();
                    if (RowCount >= 1)
                    {
                        throw (new Exception(string.Format("El Ticket {0} ya ha sido facturado", f)));
                    }
                    
                }


                cmdPAGO.CommandText = "INSERT INTO FACTURA_VENTA (FOLIO_VENTA,FOLIO_FACTURA,FECHA_FACTURA,OBSERVACIONES,USER_LOGIN,ID_CLIENTE) " +
                    " VALUES (@FOLIO_VENTA,@FOLIO_FACTURA,@FECHA_FACTURA,@OBSERVACIONES,@USER_LOGIN,@ID_CLIENTE)";
                cmdPAGO.Parameters.Add("@FOLIO_VENTA", OleDbType.VarChar,255).Value = prmFOLIO_VENTA;
                cmdPAGO.Parameters.Add("@FOLIO_FACTURA", OleDbType.VarChar, 50).Value = prmFOLIO_FACTURA;
                cmdPAGO.Parameters.Add("@FECHA_FACTURA", OleDbType.Date).Value = prmFECHA_FACTURA;
                cmdPAGO.Parameters.Add("@OBSERVACIONES", OleDbType.VarChar, 255).Value = prmOBSERVACIONES;
                cmdPAGO.Parameters.Add("@USER_LOGIN", OleDbType.VarChar, 50).Value = prmUSER_LOGIN;
                cmdPAGO.Parameters.Add("@ID_CLIENTE", OleDbType.Integer).Value = prmID_CLIENTE;
                cmdPAGO.ExecuteNonQuery();
                cmdPAGO.Parameters.Clear();

                //FACTURA CONTROL
                foreach (string f in folios)
                {
                    cmdPAGO.CommandText = "INSERT INTO FACTURA_CONTROL(FOLIO_FACTURA,FOLIO_VENTA,FECHA_FACTURA,OBSERVACIONES) VALUES(@FOLIO_FACTURA,@FOLIO_VENTA,@FECHA_FACTURA,@OBSERVACIONES)";
                    cmdPAGO.Parameters.Add("@FOLIO_FACTURA", OleDbType.VarChar, 50).Value = prmFOLIO_FACTURA;
                    cmdPAGO.Parameters.Add("@FOLIO_VENTA", OleDbType.Integer).Value = f;
                    cmdPAGO.Parameters.Add("@FECHA_FACTURA", OleDbType.Date).Value = prmFECHA_FACTURA;
                    cmdPAGO.Parameters.Add("@OBSERVACIONES", OleDbType.VarChar, 255).Value = prmOBSERVACIONES;
                    cmdPAGO.ExecuteNonQuery();
                    cmdPAGO.Parameters.Clear();
                }


                //actualizo
                cmdPAGO.CommandText = "UPDATE VENTA_DETALLE SET FOLIO_FACTURA = '' WHERE FOLIO_FACTURA = @FOLIO_FACTURA";
                cmdPAGO.Parameters.Add("@FOLIO_FACTURA", OleDbType.VarChar, 50).Value = prmFOLIO_FACTURA;
                cmdPAGO.ExecuteNonQuery();
                cmdPAGO.Parameters.Clear();
                //ACTUALIZAMOS EL FOLIO_FACTURA EN LA TABLA VENTA_DETALLE
                cmdPAGO.CommandText = String.Format("UPDATE VENTA_DETALLE SET FOLIO_FACTURA=@FOLIO_FACTURA  WHERE FOLIO in({0})", prmFOLIO_VENTA);
                cmdPAGO.Parameters.Add("@FOLIO_FACTURA", OleDbType.VarChar, 50).Value = prmFOLIO_FACTURA;
                cmdPAGO.ExecuteNonQuery();
                cmdPAGO.Parameters.Clear();
                //actualizamos el cliente en nlas ventas
                cmdPAGO.CommandText = String.Format("UPDATE VENTA SET ID_CLIENTE=@ID_CLIENTE  WHERE FOLIO in ({0})", prmFOLIO_VENTA);
                cmdPAGO.Parameters.Add("@ID_CLIENTE", OleDbType.Integer).Value = prmID_CLIENTE;
          
                cmdPAGO.ExecuteNonQuery();
                cmdPAGO.Parameters.Clear();
                //INSERTAMOS EL DETALLE DE LA FACTURA
                cmdPAGO.CommandText = "INSERT INTO FACTURA_VENTA_DETALLE ( FOLIO_FACTURA, ID_PRODUCTO, CANTIDAD, PRECIO_VENTA, IMPUESTO, DESCUENTO )" +
                " SELECT FOLIO_FACTURA, VENTA_DETALLE.ID_PRODUCTO, VENTA_DETALLE.CANTIDAD, VENTA_DETALLE.PRECIO_VENTA, VENTA_DETALLE.IMPUESTO, VENTA_DETALLE.DESCUENTO " +
                " FROM VENTA_DETALLE WHERE FOLIO_FACTURA=@FOLIO_FACTURA";
                cmdPAGO.Parameters.Add("@FOLIO_FACTURA", OleDbType.VarChar, 50).Value = prmFOLIO_FACTURA;
                cmdPAGO.ExecuteNonQuery();
                cmdPAGO.Parameters.Clear();
                //establecemos la cantidad con letra
                NumeroALetra _CantidadLetra = new NumeroALetra();
                string varCantLetra = "";
                double varCantNum= 0;
                cmdPAGO.CommandText = String.Format("SELECT Sum((((VENTA_DETALLE.PRECIO_VENTA*VENTA_DETALLE.CANTIDAD)-DESCUENTO))) AS TOTAL FROM VENTA_DETALLE WHERE FOLIO in({0});", prmFOLIO_VENTA);
                varCantNum = Convert.ToDouble(cmdPAGO.ExecuteScalar());
                cmdPAGO.Parameters.Clear();
                //MessageBox.Show(varCantNum.ToString());
                varCantLetra = "(" + _CantidadLetra.ConvertirCadena(varCantNum, "PESOS", "M.N.").ToUpper() + ")";
                //actualizamos la caNTIDAD
                cmdPAGO.CommandText = "UPDATE FACTURA_VENTA SET CANT_LETRA=@CANT_LETRA  WHERE FOLIO_FACTURA =@FOLIO_FACTURA";
                cmdPAGO.Parameters.Add("@CANT_LETRA", OleDbType.VarChar, 255).Value = varCantLetra;
                cmdPAGO.Parameters.Add("@FOLIO_FACTURA", OleDbType.VarChar, 50).Value = prmFOLIO_FACTURA;
                cmdPAGO.ExecuteNonQuery();
                cmdPAGO.Parameters.Clear();
                //ACTUALIZAMOS EL DESCUENTO
                double varDescuento = 0;
                cmdPAGO.CommandText = String.Format("SELECT SUM(DESCUENTO) FROM VENTA_DETALLE WHERE FOLIO in ({0})",prmFOLIO_VENTA);
                varDescuento = Convert.ToDouble(cmdPAGO.ExecuteScalar());
                cmdPAGO.CommandText = "UPDATE FACTURA_VENTA SET DESCUENTO=@VAR_DESCUENTO WHERE FOLIO_FACTURA=@FOLIO_FACTURA";
                cmdPAGO.Parameters.Add("@VAR_DESCUENTO", OleDbType.Double).Value = varDescuento;
                cmdPAGO.Parameters.Add("@FOLIO_FACTURA", OleDbType.VarChar, 50).Value = prmFOLIO_FACTURA;
                cmdPAGO.ExecuteNonQuery();
                cmdPAGO.Parameters.Clear();
                //GRABAMOS COMO FACTURADA
                cmdPAGO.CommandText = String.Format("UPDATE VENTA SET STATUS = 'F' WHERE FOLIO in ({0})", prmFOLIO_VENTA);
            
                cmdPAGO.ExecuteNonQuery();
                cmdPAGO.Parameters.Clear();

                //Facturacion electronica
#endregion

                #region FacturaElectronica_Umbrall
                //facturacion electronica
                string rutaCertificado = String.Format("{0}\\{1}", Application.StartupPath, Class.AppConfiguration.Umbrall_ArchivoCER);
                string rutaKey = String.Format("{0}\\{1}", Application.StartupPath, Class.AppConfiguration.Umbrall_ArchivoKEY);
                string passwordKey = Class.AppConfiguration.Umbrall_PasswordKEY;


                if (!File.Exists(rutaCertificado)) { throw (new Exception(string.Format("No existe {0}", rutaCertificado))); }
                if (!File.Exists(rutaKey)) { throw (new Exception(string.Format("No existe {0}", rutaKey))); }

                string mensajeError;

                Comprobante cfdi = new Comprobante();

                cfdi.version = "3.2";
                //cfd.serie = "A";    //Opcional
                cfdi.folio = prmFOLIO_FACTURA;    //Opcional

                /*Cambiar estos datos de la fecha cuando sean pruebas*/
                cfdi.fecha = prmFECHA_FACTURA;//***REAL
                //cfd.fecha = new DateTime(2012, 1, 18, 23, 7, 30);//***PRUEBAS


                cfdi.formaDePago = "Pago en una sola exhibición";

                //Lectura del certificado de sello digital
                //uConnectorCOM.Utilerias.Certificados.Certificado cert = new uConnectorCOM.Utilerias.Certificados.Certificado();
                var cert = new Certificado();
                if (!cert.LeerCertificado(rutaCertificado))
                {
                    //mensajeError = cert.MensajeError;
                    throw (new Exception(cert.MensajeError));
                }

                cfdi.noCertificado = cert.Serie;
                cfdi.certificado = cert.CertificadoBase64;    //Opcional

                cfdi.condicionesDePago = "Contado";    //Opcional
                cfdi.subTotal = Math.Round(varCantNum * (1 - .16), 2);//*************ATENCION

                //Para que se muestre el descueto debe asignar
                //El siguiente atributo como verdadero
                cfdi.descuentoSpecified = true;
                cfdi.descuento = 0;    //Opcional //*************ATENCION
                cfdi.motivoDescuento = "Pronto pago";    //Opcional

                cfdi.TipoCambio = "1";    //Opcional
                cfdi.Moneda = "MXN";    //Opcional

                cfdi.total = Math.Round(varCantNum, 2); //*************ATENCION

                cfdi.tipoDeComprobante = EasyCFDI.Comprobante.ComprobanteTipoDeComprobante.ingreso;

                cfdi.metodoDePago = "Efectivo";

                cfdi.LugarExpedicion = Class.AppConfiguration.Umbrall_CDF_LugarExpedicion;//Proveniente de la configuracion en la base de datos

                //Datos del Emisor
                var Emisor = new EasyCFDI.Comprobante.ComprobanteEmisor();
                Emisor.rfc = Class.AppConfiguration.Umbrall_CDF_RFCEmisor;//Proveniente de la configuracion en la base de datos
                Emisor.nombre = Class.AppConfiguration.Umbrall_CDF_NombreEmisor;   //Proveniente de la configuracion en la base de datos

                //Domicilio Fiscal
                var domicilioEmisor = new EasyCFDI.Comprobante.t_UbicacionFiscal();
                domicilioEmisor.calle = Class.AppConfiguration.Umbrall_CDF_CalleEmisor;//Proveniente de la configuracion en la base de datos
                domicilioEmisor.codigoPostal = Class.AppConfiguration.Umbrall_CDF_CPEmisor;//Proveniente de la configuracion en la base de datos
                domicilioEmisor.colonia = Class.AppConfiguration.Umbrall_CDF_ColoniaEmisor;//Proveniente de la configuracion en la base de datos
                domicilioEmisor.estado = Class.AppConfiguration.Umbrall_CDF_EstadoEmisor;//Proveniente de la configuracion en la base de datos
                domicilioEmisor.localidad = Class.AppConfiguration.Umbrall_CDF_LocalidadEmisor;//Proveniente de la configuracion en la base de datos
                domicilioEmisor.municipio = Class.AppConfiguration.Umbrall_CDF_MunicipioEmisor;//Proveniente de la configuracion en la base de datos
                domicilioEmisor.noExterior = Class.AppConfiguration.Umbrall_CDF_NoExteriorEmisor;//Proveniente de la configuracion en la base de datos
                domicilioEmisor.pais = Class.AppConfiguration.Umbrall_CDF_PaisEmisor;//Proveniente de la configuracion en la base de datos

                ////Expedido En (Aplica cuando se trata de una sucursal)
                //uCFDI.Comprobante.t_Ubicacion expedidoEn = new uCFDI.Comprobante.t_Ubicacion();
                //expedidoEn.calle = "Jacinto Lopez";
                //expedidoEn.codigoPostal = "85000";
                //expedidoEn.colonia = "Cortinas";
                //expedidoEn.estado = "Sonora";
                //expedidoEn.localidad = "Obregon";
                //expedidoEn.municipio = "Cajeme";
                //expedidoEn.noExterior = "100";
                //expedidoEn.noInterior = "A";
                //expedidoEn.pais = "México";

                ////Asignar el expedidoEn
                //Emisor.ExpedidoEn = expedidoEn;

                //Asignar el domicilio al emisor
                Emisor.DomicilioFiscal = domicilioEmisor;

                //Puede ser consultado en el portal del sat
                //Es obligatorio y debe tener al menos 1
                var regimenFiscal1 = new  ComprobanteEmisorRegimenFiscal();
                regimenFiscal1.Regimen = "Intermedio";

                //Asignar el regimen fiscal dentro del emisor
                Emisor.RegimenFiscal = new  ComprobanteEmisorRegimenFiscal[] { regimenFiscal1 };
                //Asignar el emisor al CFD
                cfdi.Emisor = Emisor;

                cmdPAGO.CommandText = "SELECT * FROM vFACTURA_VENTA WHERE FOLIO_FACTURA=@FOLIO_FACTURA";
                cmdPAGO.Parameters.Add("@FOLIO_FACTURA", OleDbType.VarChar, 50).Value = prmFOLIO_FACTURA;
                OleDbDataReader dr = cmdPAGO.ExecuteReader();
                if (dr.Read()) {
                    //Crear receptor del comprobante
                     var Receptor = new  ComprobanteReceptor();
                    Receptor.rfc = dr["RFC"].ToString();
                    Receptor.nombre = dr["CLIENTE"].ToString();
                    //Crear domicilio del receptor
                    var domicilioReceptor = new  t_Ubicacion();
                    domicilioReceptor.calle = dr["DOMICILIO"].ToString(); ;
                    domicilioReceptor.codigoPostal = dr["CP"].ToString();
                    domicilioReceptor.colonia = dr["COLONIA"].ToString();
                    domicilioReceptor.estado = dr["ID_ESTADO"].ToString();
                    domicilioReceptor.localidad = dr["ID_LOCALIDAD"].ToString();
                    domicilioReceptor.municipio = dr["ID_MUNICIPIO"].ToString();
                    domicilioReceptor.noExterior = dr["NO_EXTERIOR"].ToString();
                    domicilioReceptor.pais = dr["PAIS"].ToString();
                    //Asignar el domiclio al receptor
                    Receptor.Domicilio = domicilioReceptor;
                    //Asignar el Receptor al CFD
                    cfdi.Receptor = Receptor;
                }
                else { throw(new Exception("Error al generar los datos del receptor"));}
                dr.Close();
                cmdPAGO.Parameters.Clear();
                cmdPAGO.CommandText = "SELECT * FROM vFACTURA_VENTA_DETALLE WHERE FOLIO_FACTURA=@FOLIO_FACTURA";
                cmdPAGO.Parameters.Add("@FOLIO_FACTURA", OleDbType.VarChar, 50).Value = prmFOLIO_FACTURA;
                dr = cmdPAGO.ExecuteReader();
                List< ComprobanteConcepto> conceptos = new List< ComprobanteConcepto>();
                double totalIVA = 0;
                while (dr.Read()) {
                    //Asignamos los conceptos
                    //Crear los conceptos del comprobante
                     ComprobanteConcepto concepto1 = new  ComprobanteConcepto();
                    concepto1.descripcion =dr["DESC_PRODUCTO"].ToString();
                    concepto1.cantidad = Math.Round(Convert.ToDouble(dr["CANTIDAD"]), 2);
                    concepto1.valorUnitario = Math.Round(Convert.ToDouble(dr["PRECIO_VENTA"]) * (1 - Convert.ToDouble(dr["IMPUESTO"])), 2);
                    concepto1.importe = Math.Round((Convert.ToDouble(dr["PRECIO_VENTA"]) * Convert.ToDouble(dr["CANTIDAD"]))
                        * (1 - Convert.ToDouble(dr["IMPUESTO"])), 2);
                    concepto1.noIdentificacion = dr["ID_PRODUCTO"].ToString();
                    concepto1.unidad = dr["DESC_UNIDAD_MEDIDA"].ToString();
                    conceptos.Add(concepto1);
                    totalIVA += (Convert.ToDouble(dr["PRECIO_VENTA"]) * Convert.ToDouble(dr["CANTIDAD"])) * Convert.ToDouble(dr["IMPUESTO"]);
                }
                dr.Close();
                cmdPAGO.Parameters.Clear();
                cfdi.Conceptos = conceptos.ToArray();

                /**
                 * COMPLEMENTO IEDU
                //Crear complemento CONCEPTO
                uCFDI.Comprobante.ComprobanteConceptoComplementoConcepto complemento = new uCFDI.Comprobante.ComprobanteConceptoComplementoConcepto();

                //Agregar IEDU
                Complementos.Conceptos.iedu.instEducativas complementoIEDU = new Complementos.Conceptos.iedu.instEducativas();
                complementoIEDU.version = "1.0";
                complementoIEDU.nombreAlumno = "Nombre del alumno";
                complementoIEDU.CURP = "CURP DEL ALUMNO";
                complementoIEDU.nivelEducativo = Complementos.Conceptos.iedu.instEducativasNivelEducativo.Secundaria;
                complementoIEDU.autRVOE = "Autorizacion SEP";
                complementoIEDU.rfcPago = "RFC DE QUIEN HACE EL PAGO";

                System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                xmlDoc.InnerXml = complementoIEDU.Serialize();

                complemento.Any = new System.Xml.XmlElement[] { xmlDoc.DocumentElement };

                //Asignamos el complemento
                Concepto1.Items = new object[] { complemento };
                 * */

                //Crear impuestos
                var ImpuestoTrasladadoIVA = new  ComprobanteImpuestosTraslado();
                ImpuestoTrasladadoIVA.importe = Math.Round(totalIVA, 2);
                ImpuestoTrasladadoIVA.impuesto =  ComprobanteImpuestosTrasladoImpuesto.IVA;
                ImpuestoTrasladadoIVA.tasa = 16;

                //Asignamos los impuestos
                ComprobanteImpuestos impuestos = new  ComprobanteImpuestos();
                impuestos.Traslados = new ComprobanteImpuestosTraslado[] { ImpuestoTrasladadoIVA };
                impuestos.totalImpuestosTrasladados = Math.Round(totalIVA, 2);

                cfdi.Impuestos = impuestos;

                //Crear cadena original
                 var generaCadena = new CadenaOriginal();
                if (!generaCadena.GenerarCadenaV3(cfdi))
                {
                    //mensajeError = generaCadena.MensajeError;
                    throw (new Exception(generaCadena.MensajeError));
                }

                string cadenaOriginal;
                cadenaOriginal = generaCadena.Cadena;

              

                //Generar Sello digital
                 SelloDigital generarSello = new  SelloDigital();
                if (!generarSello.GenerarSelloDigital(rutaKey, passwordKey, cadenaOriginal))
                {
                    //mensajeError = generarSello.MensajeError;
                    throw (new Exception(generarSello.MensajeError));
                }

                cfdi.sello = generarSello.Sello;

                //Crear servicio de timbrado
                var WebService = new  CfdiWSFinkok();
                
                //Enviar a timbrar
                //Parámetros
                //CFD corresponde al objeto comprobante
                //123Demo corresponde al Password del cliente para timbrar
                //True / False Corresponde a timbrar en modo prueba o modo producción (Real)
                if (!WebService.GenerarCFDi(cfdi, Class.AppConfiguration.Umbrall_CDF_PasswordEmisor, true))//La contraseña está almacenada en la base de datos
                {
                    //mensajeError = WebService.MensajeError();
                    throw (new Exception(WebService.MensajeError()));
                }

                //Guardar la respuesta
                //Pude guardarlo como XML
                WebService.GuardarXmlTimbrado(string.Format(@"{0}\{1}.xml", Application.StartupPath, prmFOLIO_FACTURA));
                //ó .zip
                //WebService.GuardarXmlZip("C:\RutaDelXmlZipeado.zip")


                //Para leer el timbre fiscal una vez timbrado el comprobante es de la siguiente manera
                //El comprobante debe leerse desde el XML ya Timbrado
                Comprobante cfdi0 = new EasyCFDI.Comprobante.Comprobante();

                //Creamos un lector de XML
                LeerXml lectorXML = new LeerXml();

                //Lo que hace este lector es llenar el objeto nuevo cfdi con los datos
                if (!lectorXML.LeerXmlV3(string.Format(@"{0}\{1}.xml", Application.StartupPath, prmFOLIO_FACTURA)))
                {
                    throw (new Exception(lectorXML.MensajeError));
                }
                else
                {
                    cfdi0 = lectorXML.Cfdi;
                }

                //Creamos el objeto que lee el timbre fiscal
                TimbreFiscal timbre = new TimbreFiscal();
                if (!timbre.LeerTimbreFiscal(cfdi0))
                {
                    mensajeError = timbre.MensajeError;
                }

                //    'Aqui puedo leer el timbre fiscal
                //    Dim sVersion As String
                //    sVersion = timbre.version
                //    Dim sUuid As String
                //    sUuid = timbre.UUID
                //    Dim sSelloSat As String
                //    sSelloSat timbre.selloSAT
                //    Dim snoCertificadoSAT As String
                //    snoCertificadoSAT = timbre.noCertificadoSAT

                //    'Esta fecha esta en formato yyyy-MM-ddTHH:mm:ss
                //    'Ejm. 2012-01-06T15:11:30
                //    Dim fechaTimbrado As String
                //    fechaTimbrado = timbre.fechaTimbrado

                //    'Cadena de texto para la generación del CBB
                //    Dim CadenaCBB As String
                //    CadenaCBB = timbre.CadenaCBB

                //Generación del CBB
                 GeneradorCBB generaCBB = new GeneradorCBB();

                //Permite guardar en formato BMP, JPG, PNG, cambiando la extensión del archivo y el último parámetro
                if (!generaCBB.GuardarCBB(timbre.CadenaCBB, String.Format(@"{0}\CBB.jpg", Application.StartupPath), FormatoCBB.Jpeg))
                {
                    throw (new Exception(mensajeError = generaCBB.MensajeError));
                }

                if (!File.Exists(String.Format(@"{0}\CBB.jpg", Application.StartupPath))) { throw new Exception("Error CBB"); }
                var imageCBB = File.ReadAllBytes(String.Format(@"{0}\CBB.jpg", Application.StartupPath));
                
                //GRABAR DATOS DE FACTURACIÓN ELECTRONICA
                cmdPAGO.Parameters.Clear();
                cmdPAGO.CommandText = "UPDATE FACTURA_VENTA SET "+
                    " CBB=@CBB," +
                    " FOLIO_FISCAL=@FOLIO_FISCAL," +
                    " NSERIE_CSD=@NSERIE_CSD," +
                    " SELLO_CFDI=@SELLO_CFDI," +
                    " SELLO_SAT=@SELLO_SAT," + 
                    " CADENA_ORIGINAL=@CADENA_ORIGINAL"+
                    " WHERE FOLIO_FACTURA=@FOLIO_FACTURA";
                cmdPAGO.Parameters.Add("@CBB", OleDbType.Binary).Value = imageCBB;
                cmdPAGO.Parameters.Add("@FOLIO_FISCAL", OleDbType.VarChar, 255).Value = timbre.Uuid;//Ok
                cmdPAGO.Parameters.Add("@NSERIE_CSD", OleDbType.VarChar, 255).Value = timbre.NoCertificadoSAT;
                cmdPAGO.Parameters.Add("@SELLO_DIGITAL", OleDbType.LongVarWChar).Value = timbre.SelloCFD;//Ok
                cmdPAGO.Parameters.Add("@SELLO_SAT", OleDbType.LongVarWChar).Value = timbre.SelloSAT;//Ok
                cmdPAGO.Parameters.Add("@CADENA_ORIGINAL", OleDbType.LongVarWChar).Value = cadenaOriginal;//Ok
                cmdPAGO.Parameters.Add("@FOLIO_FACTURA",OleDbType.VarChar,50).Value=prmFOLIO_FACTURA;
                cmdPAGO.ExecuteNonQuery();
                cmdPAGO.Parameters.Clear();
                #endregion


                tran.Commit();
                cmdPAGO.Dispose();
                cnnPAGO.Close();
                cnnPAGO.Dispose();
                _Accion = true;
                return (true);
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show(ex.Message +"\nOrigen: " +ex.Source, "fnFACTURA");
                return (false);
            }
        }

        private void btnBuscaCliente_Click(object sender, EventArgs e)
        {
            BuscaCliente();
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
                    
                    txtID_CLIENTE.Focus();
                }
                myForm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnBuscaCliente",    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtID_CLIENTE.Text = "";
            }
        }
    }
}