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
    public partial class frmProductosLista : Telerik.WinControls.UI.RadForm
    {
        //controlamos q solo se abra una vez
        private static frmProductosLista m_FormDefInstance;
        public static frmProductosLista DefInstance
        {
            get
            {
                //if(m_FormDefInstance==null && m_FormDefInstance.IsDisposed)
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmProductosLista();
                return m_FormDefInstance;
            }
            set { m_FormDefInstance = value; }
        }
        public frmProductosLista()
        {
            InitializeComponent();
        }
      
        private void frmCatProducto_Load(object sender, EventArgs e)
        {
            if (frmLogin._INVENTARIOS)
            {
                Inicializa();
                Encabezados();
               // ORDENAR();
            }
            else {
                MessageBox.Show("No cuenta con suficientes provilegios para accesar a esta función",
                    "Información del sistema",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                barCatProducto.Enabled = false;
                c_mnuListaProductos.Enabled = false;
                txtPALABRA1.Enabled = false;
                cboORDENAR.Enabled = false;
                cboORDER.Enabled = false;
            }
            
        }
        private void Inicializa()
        {
            try
            {
                DataSet dsInicializa = new DataSet();
                OleDbConnection cnnInicializa = new OleDbConnection(Class.clsMain.CnnStr);
                cnnInicializa.Open();
                //MARCA
                OleDbDataAdapter daCol = 
                    new OleDbDataAdapter("SELECT * FROM COLUMNAS WHERE CLASIFICACION='BUSCA_PRODUCTO' ORDER BY ORDENAR", cnnInicializa);
                dsInicializa.Clear();
                daCol.Fill(dsInicializa, "COLUMNAS");
                daCol.Fill(dsInicializa, "COLUMNAS2");
                cboCOLMUNAS.DataSource = dsInicializa.Tables["COLUMNAS"];
                cboCOLMUNAS.DisplayMember = "DESC_COLUMNA";
                cboCOLMUNAS.ValueMember = "COLUMNA";
                //el otro
                cboCOLUMNAS2.DataSource = dsInicializa.Tables["COLUMNAS2"];
                cboCOLUMNAS2.DisplayMember = "DESC_COLUMNA";
                cboCOLUMNAS2.ValueMember = "COLUMNA";
                cboCOLUMNAS2.SelectedIndex = 1;
                daCol.Dispose();


                cnnInicializa.Close();
                cnnInicializa.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void Encabezados() {
            lvCatProducto.Clear();
            lvCatProducto.View = View.Details;
            lvCatProducto.Columns.Add("Clave", 50, HorizontalAlignment.Left);  
            lvCatProducto.Columns.Add("Nombre del artículo", 250, HorizontalAlignment.Left);
            lvCatProducto.Columns.Add("Medida", 100, HorizontalAlignment.Left);
            lvCatProducto.Columns.Add("Grupo", 100, HorizontalAlignment.Left);
           
            lvCatProducto.Columns.Add("Exist", 50, HorizontalAlignment.Right);
            
            
            
           
        }
        private void ORDENAR()
        {
            try
            {
                if (cboORDENAR.Text != "")
                {
                    ReadData(fnGetOrder(cboORDENAR.Text) + " " +
                        fnGetAscOrder(cboORDER.Text),
                        Strings.SafeSqlLikeClauseLiteral(txtPALABRA1.Text),
                        cboCOLMUNAS.SelectedValue.ToString(),
                        Strings.SafeSqlLikeClauseLiteral(txtPALABRA2.Text),
                        cboCOLUMNAS2.SelectedValue.ToString(), fnGetOrder(cboORDENAR2.Text));
                }
                else
                {
                    ReadData(" ID_PRODUCTO ASC ", 
                        Strings.SafeSqlLikeClauseLiteral(txtPALABRA1.Text),
                        cboCOLMUNAS.SelectedValue.ToString(),
                        Strings.SafeSqlLikeClauseLiteral(txtPALABRA2.Text),
                        cboCOLUMNAS2.SelectedValue.ToString(), fnGetOrder(cboORDENAR2.Text));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        string fnGetOrder(string prmCAMPO)
        {
            string retorno = "";
            switch (prmCAMPO)
            {
                case "Clave":
                    //
                    retorno = "ID_PRODUCTO";
                    break;
                case "Nombre del Artículo":
                    //
                    retorno = "DESC_PRODUCTO";
                    break;
                case "Marca":
                    //
                    retorno = "DESC_MARCA";
                    break;
               
                case "Grupo":
                    //
                    retorno = "DESC_GRUPO";
                    break;
               
                default:
                    retorno = "ID_PRODUCTO";
                    break;
            }
            return (retorno);
        }
        string fnGetAscOrder(string prmCAMPO)
        {
            string retorno = "";
            switch (prmCAMPO)
            {
                case "Ascendente":
                    //
                    retorno = " ASC ";
                    break;
                case "Descendente":
                    //
                    retorno = " DESC ";
                    break;
                default:
                    retorno = " ASC ";
                    break;
            }
            return (retorno);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            Exportar();
        }
        void Exportar() {
            if (lvCatProducto.Items.Count != 0)
            {
                //exportar a excel
                POSDLL.Utilities.ExportListView exportar = new POSDLL.Utilities.ExportListView();
                exportar.ExportToExcel(lvCatProducto, "ListaDeArticulos");
            }
            else { MessageBox.Show("No hay elementos para exportar"); }
        }
        void lvCatProducto_DoubleClick(object sender, System.EventArgs e)
        {
            Editar();
        }

        void ReadData(string prmORDERBY, string prmPALABRA1, string prmCOLUMNA,
            string prmPALABRA2,string prmCOLUMNA2, string prmORDERBY2)
        {
            try
            {
                
              
                OleDbConnection cnnReadData = new OleDbConnection(Class.clsMain.CnnStr);
                string varSQL = "SELECT P.ID_PRODUCTO, " +
                    " P.DESC_PRODUCTO," +
                    " M.DESC_MARCA," +
                    " P.EXISTENCIA, P.PRECIO_VENTA, P.PRECIO_VENTA2,P.PRECIO_VENTA3,P.SUST_ACTIVA," +
                    " P.IMPUESTO,G.DESC_GRUPO,ME.DESC_UNIDAD_MEDIDA " +
                    " " +
                    " FROM  CAT_PRODUCTO P,CAT_MARCA M,CAT_GRUPO G,CAT_UNIDAD_MEDIDA ME " +
                    " WHERE P.ID_MARCA = M.ID_MARCA AND ME.ID_UNIDAD_MEDIDA=P.ID_UNIDAD_MEDIDA  AND " + prmCOLUMNA + " like '%" + prmPALABRA1 + "%' " +
                    " AND " + prmCOLUMNA2 + " LIKE '%" + prmPALABRA2 + "%' " +
                    " AND G.ID_GRUPO = P.ID_GRUPO" + 
                    "" +
                    "  ORDER BY " + prmORDERBY + ","+ prmORDERBY2 +"";
                int I = 0;
                OleDbCommand cmdReadData = new OleDbCommand(varSQL, cnnReadData);
                OleDbDataReader drReadData;
                if (cnnReadData.State == ConnectionState.Open)
                    cnnReadData.Close();
                cnnReadData.Open();
                drReadData = cmdReadData.ExecuteReader();                
                lvCatProducto.Items.Clear();
                while (drReadData.Read())
                {
                    lvCatProducto.Items.Add(drReadData["ID_PRODUCTO"].ToString());
                    lvCatProducto.Items[I].SubItems.Add(drReadData["DESC_PRODUCTO"].ToString());
                    lvCatProducto.Items[I].SubItems.Add(drReadData["DESC_UNIDAD_MEDIDA"].ToString());
                    lvCatProducto.Items[I].SubItems.Add(drReadData["DESC_GRUPO"].ToString());                    
                    lvCatProducto.Items[I].SubItems.Add(String.Format("{0:N}",drReadData["EXISTENCIA"]));
                    lvCatProducto.Items[I].SubItems.Add(String.Format("{0:C}",drReadData["PRECIO_VENTA"]));
                    lvCatProducto.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["PRECIO_VENTA2"]));
                    lvCatProducto.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["PRECIO_VENTA3"]));
                    lvCatProducto.Items[I].SubItems.Add(String.Format("{0:P}",drReadData["IMPUESTO"]));                   
                    I += 1;
                }
                lblInfo.Text = String.Format("Se encontraron {0} registro(s)", I);
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

        

        void btnAddNew_Click(object sender, System.EventArgs e)
        {
            _AddNew();
        }

        void _AddNew() {
            bool ciclar = true;
            while (ciclar)
            {
                Forms.frmProducto _frmProducto = new frmProducto("");
                _frmProducto.StartPosition = FormStartPosition.CenterScreen;
                _frmProducto.ShowDialog();
                ciclar = _frmProducto.Ciclar;
                if (_frmProducto.producto.Success)
                {
                    ORDENAR();
                }
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Editar();
        }
        void Editar() {
            try {
                if (lvCatProducto.Items.Count != 0) {
                    Forms.frmProducto _frmProducto = new frmProducto(lvCatProducto.SelectedItems[0].Text);
                    _frmProducto.StartPosition = FormStartPosition.CenterScreen;
                    _frmProducto.Text = "Edit";
                    _frmProducto.ShowDialog();
                    if (_frmProducto.producto.Success)
                    {
                        ORDENAR();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            
        }

        private void btnNuevaEntrada_Click(object sender, EventArgs e)
        {
            Forms.frmEntrada _frmEntrada = new Forms.frmEntrada();
            _frmEntrada.StartPosition = FormStartPosition.CenterScreen;
            _frmEntrada.ShowDialog();
        }

       
        void PrintList() {
            lvCatProducto.FitToPage = true;
            lvCatProducto.Title = "Inventario a la fecha: " + 
                DateTime.Now.ToLongDateString(); ;
            lvCatProducto.PrintPreview();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ORDENAR();
        }

        private void c_mnuHistorialCompras_Click(object sender, EventArgs e)
        {
            HistorialCompras();
        }
        void HistorialCompras() {
            try
            {
                if (lvCatProducto.SelectedItems.Count != 0)
                {
                    frmProductoComprasPrevias _frmListaComprasPrevias =
                        new frmProductoComprasPrevias(lvCatProducto.SelectedItems[0].Text);
                    _frmListaComprasPrevias.StartPosition = FormStartPosition.CenterScreen;
                    _frmListaComprasPrevias.ShowDialog();
                }
                else {
                    MessageBox.Show("Debe seleccionar un elemento.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void c_mnuEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }



        private void c_mnuExportar_Click(object sender, EventArgs e)
        {
            Exportar();
        }

        private void c_mnuImprimir_Click(object sender, EventArgs e)
        {
            PrintList();
        }

     

        private void cboORDENAR_SelectedIndexChanged(object sender, EventArgs e)
        {
            ORDENAR();
        }
    
        private void c_mnuImprimirEtiqueta_Click(object sender, EventArgs e)
        {
           
        }

        private void c_mnuImprimirTodasEtiquetas_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvCatProducto.Items.Count != 0)
                {
                    ImprimeReporte(lvCatProducto.SelectedItems[0].Text, "",1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void c_mnuImprimeSeleccionadoFormato1_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvCatProducto.Items.Count != 0)
                {
                    MessageBox.Show("No disponible");
                    //ImprimeReporte(lvCatProducto.SelectedItems[0].Text, "", 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
           
        }

        private void c_mnuImprimeSeleccionadoFormato2_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvCatProducto.Items.Count != 0)
                {
                    MessageBox.Show("No disponible");
                    //ImprimeReporte(lvCatProducto.SelectedItems[0].Text, "", 2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void c_mnuImprimeSeleccionadoFormato3_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvCatProducto.Items.Count != 0)
                {
                    //código de barras
                    ImprimeReporte(lvCatProducto.SelectedItems[0].Text, "", 3);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void c_mnuImprimeEtiquetasTodoFormato3_Click(object sender, EventArgs e)
        {
            try
            {
                

                    ImprimeReporte("", "", 3);
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void c_mnuImprimeEtiquetasTodoFormato2_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("No disponible");

                //    ImprimeReporte("", "", 2);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void c_mnuImprimeEtiquetasTodoFormato1_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("No disponible");

                //    ImprimeReporte("", "", 1);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }


        private void cboORDENAR2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ORDENAR();
        }

        private void cboCOLMUNAS_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPALABRA1.Focus();
        }

        private void cboCOLUMNAS2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPALABRA2.Focus();
        }


        public void ImprimeReporte(string prmID_PRODUCTO, string prmComments, int prmReporte)
        {
            try
            {
                string varSQL = "";
                string _FileName = AppSettings.GetValue("Config", "ReportsFolder", Application.StartupPath);
                switch (prmReporte)
                {
                    case 1:
                        _FileName += "";
                        break;
                    case 2:
                        _FileName += "";
                        break;
                    case 3:
                        _FileName += "\\rptProductosCBarras.rdlc";
                        break;
                }
                if (!File.Exists(_FileName)) {
                    MessageBox.Show(String.Format("No se encuentra el archivo {0}\nRevise por favor.", _FileName), "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (prmID_PRODUCTO == "")
                {
                    //toos
                    varSQL = "SELECT '*' + ID_PRODUCTO + '*'  as ID_PRODUCTO,PRECIO_VENTA,DESC_PRODUCTO " +
                        " FROM CAT_PRODUCTO ";
                }
                else
                {
                    //solo uno
                    varSQL = "SELECT '*' + ID_PRODUCTO + '*'  as ID_PRODUCTO,PRECIO_VENTA,DESC_PRODUCTO " +
                        " FROM CAT_PRODUCTO WHERE ID_PRODUCTO = '" + prmID_PRODUCTO + "'";
                }
                DataSet dsReporte = new DataSet(); //Datset para el reporte
                OleDbConnection cnnReporte = new OleDbConnection(Class.clsMain.CnnStr);
                cnnReporte.Open();
                dsReporte.Clear();//limpiamos el dataset
                OleDbDataAdapter daReporte =
                    new OleDbDataAdapter(varSQL, cnnReporte);
                daReporte.Fill(dsReporte, "rptProductos");//llenamos el DataSet con la info de la FACTURA
                daReporte.Dispose();

                cnnReporte.Dispose();
                //ya tenoemos la info en el DataSet, ahora cargamos el reporte

                if (dsReporte.Tables["rptProductos"].Rows.Count == 0)
                {
                    cnnReporte.Close();
                    MessageBox.Show("No hay datos para mostrar.","Información del sistema");
                    return;
                }

                Forms.frmReports frm = new Forms.frmReports();

                frm.rvDoc.LocalReport.DataSources.Clear();
                frm.rvDoc.LocalReport.Dispose();
                frm.rvDoc.Reset();
                frm.rvDoc.LocalReport.DataSources.Add(new ReportDataSource("rptProductos", dsReporte.Tables["rptProductos"]));
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            PrintList();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            Forms.frmSalida _frmEntrada = new Forms.frmSalida();
            _frmEntrada.StartPosition = FormStartPosition.CenterScreen;
            _frmEntrada.ShowDialog();
        }
        
    }
}