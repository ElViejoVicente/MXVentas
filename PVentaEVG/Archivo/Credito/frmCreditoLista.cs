using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSDLL; using POSDLL.Windows.Forms; using POSDLL.Security; using POSDLL.Reporting; using POSDLL.Ticket;
using Microsoft.Reporting.WinForms;
namespace POSApp.Forms
{
    public partial class frmCreditoLista : Telerik.WinControls.UI.RadForm
    {
        private static frmCreditoLista m_FormDefInstance;
        public static frmCreditoLista DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmCreditoLista();
                return m_FormDefInstance;
            }
            set { m_FormDefInstance = value; }
        }
        public frmCreditoLista()
        {
            InitializeComponent();
        }
        Class.clsVentas _clsVentas = new Class.clsVentas();
        private void frmVentasCredito_Load(object sender, EventArgs e)
        {
            Encabezados();
            ReadData(Convert.ToInt32(cboFiltro.SelectedIndex), ISODates.MSAccessDateINI(txtFechaIni.Value),ISODates.MSAccessDateFIN(txtFechaFin.Value));
        }
        void txtFOLIO_VENTA_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
     
        }
        public void ImprimeReporte(int prmID_CLIENTE)
        {
            try
            {
                string varSQL = "";
                string _FileName = AppSettings.GetValue("Config", "ReportsFolder", Application.StartupPath);
                _FileName += "\\rptHistorialCrediticioCliente.rdlc";
                if (!File.Exists(_FileName))
                {
                    MessageBox.Show(String.Format("No se encuentra el archivo {0}\nRevise por favor.", _FileName), "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                varSQL = "EXECUTE spHISTORIAL_CREDITICIO_CLIENTE "+ prmID_CLIENTE +"";

                DataSet dsReporte = new DataSet(); //Datset para el reporte
                OleDbConnection cnnReporte = new OleDbConnection(Class.clsMain.CnnStr);
                cnnReporte.Open();
                dsReporte.Clear();//limpiamos el dataset
                OleDbDataAdapter daReporte =
                    new OleDbDataAdapter(varSQL, cnnReporte);
                daReporte.Fill(dsReporte, "dsRptHistorialCrediticioCliente");//llenamos el DataSet con la info de la FACTURA
                daReporte.Dispose();

                cnnReporte.Dispose();
                //ya tenoemos la info en el DataSet, ahora cargamos el reporte

                if (dsReporte.Tables["dsRptHistorialCrediticioCliente"].Rows.Count == 0)
                {
                    cnnReporte.Close();
                    MessageBox.Show("No hay datos para mostrar.", "Información del sistema");
                    return;
                }

                Forms.frmReports frm = new Forms.frmReports();

                frm.rvDoc.LocalReport.DataSources.Clear();
                frm.rvDoc.LocalReport.Dispose();
                frm.rvDoc.Reset();
                frm.rvDoc.LocalReport.DataSources.Add(new ReportDataSource("dsRptHistorialCrediticioCliente", dsReporte.Tables["dsRptHistorialCrediticioCliente"]));
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
        /*
        public void ImprimeReporte(int prmID_CLIENTE, string prmComments)
        {
            try
            {
                DataSet dsReporte = new DataSet(); //Datset para el reporte
                OleDbConnection cnnReporte = new OleDbConnection(Class.clsMain.CnnStr);
                if (cnnReporte.State == ConnectionState.Open)
                    cnnReporte.Close();
                cnnReporte.Open();
                dsReporte.Clear();//limpiamos el dataset
                OleDbDataAdapter daReporte = new OleDbDataAdapter("EXECUTE spHISTORIAL_CREDITICIO_CLIENTE " +
                    " "+ prmID_CLIENTE +"", cnnReporte);
                daReporte.Fill(dsReporte, "spHISTORIAL_CREDITICIO");//llenamos el DataSet con la info de la FACTURA



                //destruimos los objetos utilizados
                if (cnnReporte.State == ConnectionState.Open)
                    cnnReporte.Close();
                daReporte.Dispose();

                cnnReporte.Dispose();
                //ya tenoemos la info en el DataSet, ahora cargamos el reporte
                Reports.rptHistorialCrediticio mi_rptTicket = new Reports.rptHistorialCrediticio();
                mi_rptTicket.SummaryInfo.ReportTitle = "Créditos";
                mi_rptTicket.SummaryInfo.ReportComments = prmComments;
                mi_rptTicket.SetDataSource(dsReporte);

                Forms.frmReports mi_frmReportes = new frmReports();
                mi_frmReportes.crvReportes.DisplayGroupTree = false;
                mi_frmReportes.crvReportes.ReportSource = mi_rptTicket;
                mi_frmReportes.StartPosition = FormStartPosition.CenterScreen;
                mi_frmReportes.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar el reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
         */
        private void Encabezados() {
            lvVentasCredito.View = View.Details;
            lvVentasCredito.Columns.Add("Ticket", 50, HorizontalAlignment.Left);
            lvVentasCredito.Columns.Add("Cliente", 250, HorizontalAlignment.Left);
            lvVentasCredito.Columns.Add("Monto", 75, HorizontalAlignment.Right);
            lvVentasCredito.Columns.Add("Pagado", 75, HorizontalAlignment.Right);
            lvVentasCredito.Columns.Add("Restante", 75, HorizontalAlignment.Right);
            cboFiltro.SelectedIndex = 2;
        }
        void ReadData(int prmFiltro, string prmDateStart, string prmDateEnd)
        {            
            try
            {
                OleDbConnection cnnReadData = new OleDbConnection(Class.clsMain.CnnStr);
                string varSQL = "";
                switch (prmFiltro) { 
                    case 0:
                        //Todo:
                        varSQL = "SELECT * FROM vCREDITO WHERE FECHA BETWEEN #"+ prmDateStart +"# AND #"+ prmDateEnd +"#";
                        break;
                    case 1:
                        //Solo pagados:
                        varSQL = "SELECT *  FROM vCREDITO WHERE RESTO =0 AND FECHA BETWEEN #" + prmDateStart + "# AND #" + prmDateEnd + "#";
                        break;
                    case 2:
                        //SOLO PENDIENTES DE PAGO
                        varSQL = "SELECT *  FROM vCREDITO WHERE RESTO <> 0 AND FECHA BETWEEN #" + prmDateStart + "# AND #" + prmDateEnd + "#";
                        break;
                    default:
                        //
                        varSQL = "SELECT * FROM vCREDITO WHERE FECHA BETWEEN #" + prmDateStart + "# AND #" + prmDateEnd + "#";
                        break;
                }
                 
                
                int I = 0;
                OleDbCommand cmdReadData = new OleDbCommand(varSQL, cnnReadData);
                OleDbDataReader drReadData;
                if (cnnReadData.State == ConnectionState.Open)
                    cnnReadData.Close();
                cnnReadData.Open();
                drReadData = cmdReadData.ExecuteReader();
                lvVentasCredito.Items.Clear();
                while (drReadData.Read())
                {
                    lvVentasCredito.Items.Add(drReadData["FOLIO_VENTA"].ToString());
                    lvVentasCredito.Items[I].SubItems.Add(drReadData["NOMBRE"].ToString());
                    lvVentasCredito.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["CANTIDAD"]));
                    lvVentasCredito.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["PAGADO"]));
                    lvVentasCredito.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["RESTO"]));                    
                    I += 1;
                }
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFOLIO_VENTA.Text == "") {
                    MessageBox.Show("Falta el folio del Ticket de Venta",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtFOLIO_VENTA.Focus();
                    return;
                }
                if ((_clsVentas.FnBuscaTicket(Convert.ToInt32(txtFOLIO_VENTA.Text))))
                {
                    //aqui
                    frmCredito _frmCredito = new frmCredito(Convert.ToInt32(txtFOLIO_VENTA.Text));
                    _frmCredito.StartPosition = FormStartPosition.CenterScreen;
                    _frmCredito.ShowDialog();
                    if (frmCredito._Accion)
                    {
                        ReadData(Convert.ToInt32(cboFiltro.SelectedIndex), ISODates.MSAccessDateINI(txtFechaIni.Value), ISODates.MSAccessDateFIN(txtFechaFin.Value));
                    }
                }
                else
                {
                    MessageBox.Show("El folio de Ticket no existe",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        void lvVentasCredito_DoubleClick(object sender, System.EventArgs e)
        {
            Abonar();
        }
        private void mnuAbonar_Click(object sender, EventArgs e)
        {
            Abonar();
        }
        void Abonar() {
            //Código         
            try
            {
                if (lvVentasCredito.SelectedItems.Count != 0)
                {
                    frmCreditoAbono _frmPago = new frmCreditoAbono(Convert.ToInt32(lvVentasCredito.SelectedItems[0].Text));
                    _frmPago.StartPosition = FormStartPosition.CenterScreen;
                    _frmPago.ShowDialog();
                    if (_frmPago.Success)
                    {
                        ReadData(Convert.ToInt32(cboFiltro.SelectedIndex), ISODates.MSAccessDateINI(txtFechaIni.Value), ISODates.MSAccessDateFIN(txtFechaFin.Value));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione un elemento de la lista." +
                    " \nDescription Error: \n" + ex.Message,
                    "Invalid Operation [frmVentasCredito.Abonar]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        void AbonoMultiple()
        {
            //Código         
            try
            {
                if (lvVentasCredito.Items.Count != 0)
                {
                    frmCreditoAbonoMultiple _frmPago = new frmCreditoAbonoMultiple(Convert.ToInt32(lvVentasCredito.SelectedItems[0].Text));
                    _frmPago.StartPosition = FormStartPosition.CenterScreen;
                    _frmPago.ShowDialog();
                    if (_frmPago.Success)
                    {
                        ReadData(Convert.ToInt32(cboFiltro.SelectedIndex), 
                            ISODates.MSAccessDateINI(txtFechaIni.Value), ISODates.MSAccessDateFIN(txtFechaFin.Value));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione un elemento de la lista." +
                    " \nDescription Error: \n" + ex.Message,
                    "Invalid Operation [frmVentasCredito.Abonar]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        void HistorialCrediticio()
        {
            //Código         
            try
            {
                if (lvVentasCredito.Items.Count != 0)
                {

                    int _ID_CLIENTE = fnObtenIDCliente(Convert.ToInt32(lvVentasCredito.SelectedItems[0].Text));

                    ImprimeReporte(_ID_CLIENTE);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione un elemento de la lista." +
                    " \nDescription Error: \n" + ex.Message,
                    "Invalid Operation [frmVentasCredito.Abonar]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
       
        void Historial()
        {
            //Código         
            try
            {
                if (lvVentasCredito.Items.Count != 0)
                {
                    frmHistorialPagos _frmPago = new frmHistorialPagos(Convert.ToInt32(lvVentasCredito.SelectedItems[0].Text));
                    _frmPago.StartPosition = FormStartPosition.CenterScreen;
                    _frmPago.ShowDialog();                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione un elemento de la lista." +
                    " \nDescription Error: \n" + ex.Message,
                    "Invalid Operation [frmVentasCredito.Abonar]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHistorialPagos_Click(object sender, EventArgs e)
        {
            Historial();
        }      

        private void btnPrint_Click(object sender, EventArgs e)
        {
            lvVentasCredito.Title = "Credito";
            lvVentasCredito.PrintPreview();
        }

        private void btnBuscaTicket_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaTicket myForm = new frmBuscaTicket();
                myForm.StartPosition = FormStartPosition.CenterScreen;
                myForm.ShowDialog();
                if (frmBuscaTicket.varFOLIO_VENTA != 0)
                {
                    txtFOLIO_VENTA.Text = frmBuscaTicket.varFOLIO_VENTA.ToString();

                }
                myForm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReadData(Convert.ToInt32(cboFiltro.SelectedIndex), ISODates.MSAccessDateINI(txtFechaIni.Value), ISODates.MSAccessDateFIN(txtFechaFin.Value));
        }
        int fnObtenIDCliente(int prmFolioVenta) {
            try {
                OleDbConnection cnnRead= new OleDbConnection(Class.clsMain.CnnStr);
                cnnRead.Open();
                OleDbCommand cmdRead= 
                    new OleDbCommand("SELECT ID_CLIENTE FROM VENTA WHERE FOLIO="+ prmFolioVenta +"",cnnRead);
                int _return = 0;
                _return = Convert.ToInt32(cmdRead.ExecuteScalar());
                cnnRead.Close();
                cmdRead.Dispose();
                cnnRead.Dispose();
                return (_return);
            }
            catch (Exception ex) { 
                MessageBox.Show(ex.Message,"Error");
                return (0);
            }
        }

        private void c_mnuHistorialCrediticio_Click(object sender, EventArgs e)
        {
            HistorialCrediticio();
        }

      

        private void c_mnuEliminaCuenta_Click(object sender, EventArgs e)
        {
            EliminaCuenta();
        }
        void EliminaCuenta()
        {
            try
            {
                if (!frmLogin.PERMITIR_CANCELAR)
                {
                    MessageBox.Show("Requiere permisos para ejecutar esta acción. Consulte con su administrador", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                DialogResult Resp = new DialogResult();
                Resp = MessageBox.Show("¿Desea eliminar la cuenta seleccionada?" +
                    "\nSi la cuenta tiene abonos, también se eliminarán." +
                    "\nSe recomienda revisar la cuenta antes de continuar",
                    "Eliminar cuenta", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (Resp == DialogResult.Yes)
                {
                    //cancelar la cuenta
                    CancelaCuenta(Convert.ToInt32(lvVentasCredito.SelectedItems[0].Text));
                    ReadData(Convert.ToInt32(cboFiltro.SelectedIndex), ISODates.MSAccessDateINI(txtFechaIni.Value), ISODates.MSAccessDateFIN(txtFechaFin.Value));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void CambiaCliente()
        {
            try
            {
                if (!frmLogin.PERMITIR_CANCELAR)
                {
                    MessageBox.Show("Requiere permisos para ejecutar esta acción. Consulte con su administrador", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult Resp = new DialogResult();
                Resp = MessageBox.Show("¿Desea cambiar el cliente de la cuenta seleccionada?" +
                    "",
                    "Cambiar cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (Resp == DialogResult.Yes)
                {
                    //cancelar la cuenta
                    //CancelaCuenta(Convert.ToInt32(lvVentasCredito.SelectedItems[0].Text));
                    frmVentaCambioCliente _frmVentaCambioCliente =
                        new frmVentaCambioCliente(Convert.ToInt32(lvVentasCredito.SelectedItems[0].Text));
                    _frmVentaCambioCliente.StartPosition = FormStartPosition.CenterScreen;
                    _frmVentaCambioCliente.ShowDialog();
                    ReadData(Convert.ToInt32(cboFiltro.SelectedIndex), ISODates.MSAccessDateINI(txtFechaIni.Value), ISODates.MSAccessDateFIN(txtFechaFin.Value));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void CancelaCuenta(int prmFOLIO_VENTA) {
            try {
                OleDbConnection cnnCancel = new OleDbConnection(Class.clsMain.CnnStr);
                cnnCancel.Open();
                OleDbTransaction tranCancel = cnnCancel.BeginTransaction();
                OleDbCommand cmdCancel = new OleDbCommand();
                cmdCancel.Connection = cnnCancel;
                cmdCancel.Transaction = tranCancel;
                try {
                    //abonos
                    
                    cmdCancel.CommandText = "DELETE FROM PAGO_CREDITO WHERE FOLIO_VENTA="+ prmFOLIO_VENTA +"";
                    cmdCancel.ExecuteNonQuery();
                    //cuenta
                    cmdCancel.CommandText = "DELETE FROM CREDITO WHERE FOLIO_VENTA="+ prmFOLIO_VENTA +"";
                    cmdCancel.ExecuteNonQuery();
                    tranCancel.Commit();
                }
                catch {
                    tranCancel.Rollback();
                }
                cnnCancel.Close();
                cnnCancel.Dispose();
                cmdCancel.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void c_mnuCambiarCliente_Click(object sender, EventArgs e)
        {
            CambiaCliente();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            ReadData(Convert.ToInt32(cboFiltro.SelectedIndex), ISODates.MSAccessDateINI(txtFechaIni.Value), ISODates.MSAccessDateFIN(txtFechaFin.Value));
        }

        private void mnuAbonoMultiple_Click(object sender, EventArgs e)
        {
            AbonoMultiple();
        }
    }
    
}