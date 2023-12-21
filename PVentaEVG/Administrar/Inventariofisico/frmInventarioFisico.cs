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
    public partial class frmInventarioFisico : Telerik.WinControls.UI.RadForm
    {
        private static frmInventarioFisico m_FormDefInstance;
        public static frmInventarioFisico DefInstance
        {
            get
            {

                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmInventarioFisico();
                return m_FormDefInstance;
            }
            set { m_FormDefInstance = value; }
        }
        public frmInventarioFisico()
        {
            InitializeComponent();
        }

        private void btnBuscaProducto_Click(object sender, EventArgs e)
        {
           
        }
        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmInventarioFisicoElemento _frmInventarioFisicoElemento = new frmInventarioFisicoElemento("");
            _frmInventarioFisicoElemento.StartPosition = FormStartPosition.CenterScreen;
            _frmInventarioFisicoElemento.ShowDialog();
            if (frmInventarioFisicoElemento._Accion) {
                ReadData();
            }
        }

        private void frmInventarioFisico_Load(object sender, EventArgs e)
        {
            lvItems.DoubleClick += new EventHandler(lvItems_DoubleClick);
            Encabezados();
            ReadData();
        }

        void lvItems_DoubleClick(object sender, EventArgs e)
        {
            Editar();
        }
        void Editar() {
            if (lvItems.SelectedItems.Count != 0) {
                string varID_PRODUCTO = lvItems.SelectedItems[0].Text;
                frmInventarioFisicoElemento _frmInventarioFisicoElemento =
                    new frmInventarioFisicoElemento(varID_PRODUCTO);
                _frmInventarioFisicoElemento.StartPosition = FormStartPosition.CenterScreen;
                _frmInventarioFisicoElemento.ShowDialog();
                if (frmInventarioFisicoElemento._Accion)
                {
                    ReadData();
                }
            }
        }
        void Encabezados() {
            lvItems.View = View.Details;
            lvItems.GridLines = true;
            lvItems.HideSelection = false;
            lvItems.FullRowSelect = true;
            lvItems.Columns.Add("Clave artículo",80);
            lvItems.Columns.Add("Descripción",250);
            lvItems.Columns.Add("Cant conteo",70);
            lvItems.Columns.Add("Cant Sistema",75);
            lvItems.Columns.Add("Diferencia",70);
            lvItems.Columns.Add("P.Compra", 75);
            lvItems.Columns.Add("P.Venta", 75);

        }
        private void ReadData()
        {
            //Este procedimiento lee los datos que se tranferirán y los mostrará en forma de
            //lista en el ListView
           
            try
            {
               
                //Si la conexion esta abierta la cerramos; en caso contrario, la abrimos
                OleDbConnection cnnReadData = new OleDbConnection(Class.clsMain.CnnStr);
                cnnReadData.Open();
                int I = 0;
                string varSQL = "SELECT T.ID_PRODUCTO,P.DESC_PRODUCTO,T.CANTIDAD,T.CANTIDAD_ANTES," +
                    "T.CANTIDAD_ANTES-T.CANTIDAD AS CANTIDAD_DIF,T.PRECIO_COMPRA,T.PRECIO_VENTA"+
                    " FROM CAT_PRODUCTO P,TEMP_INVENTARIO_FISICO T " +
                    " WHERE P.ID_PRODUCTO=T.ID_PRODUCTO" +
                    " ORDER BY P.DESC_PRODUCTO";
                OleDbCommand cmdReadData = new OleDbCommand(varSQL, cnnReadData);
                OleDbDataReader drReadData;
                drReadData = cmdReadData.ExecuteReader();
                lvItems.Items.Clear();
                while (drReadData.Read())
                {
                    lvItems.Items.Add(drReadData["ID_PRODUCTO"].ToString());
                   
                    lvItems.Items[I].SubItems.Add(drReadData["DESC_PRODUCTO"].ToString());
                    
                    lvItems.Items[I].SubItems.Add(String.Format("{0:N}", drReadData["CANTIDAD"]));
                    lvItems.Items[I].SubItems.Add(String.Format("{0:N}", drReadData["CANTIDAD_ANTES"]));
                    lvItems.Items[I].SubItems.Add(String.Format("{0:N}", drReadData["CANTIDAD_DIF"]));
                    lvItems.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["PRECIO_COMPRA"]));
                    lvItems.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["PRECIO_VENTA"]));
                    I += 1;
                }
                
                //Agregamos un registro más
               
                drReadData.Close();
                cmdReadData.Dispose();
                cnnReadData.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            if (lvItems.Items.Count != 0)
            {
                DialogResult Resp = new DialogResult();
                Resp = MessageBox.Show("¿Esta seguro de que desea ejecutar la actualización del inventario?\n" +
                    "Esta operación no podrá deshacerse.",
                    "Inventario físico", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (Resp == DialogResult.Yes)
                {
                    //ejecutar proceso
                    if (fnEjecutarProceso())
                    {
                        this.Close();
                    }
                }
            }
            else {
                MessageBox.Show("No hay elementos en la lista",
                    "Inventario físico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        bool fnEjecutarProceso() {
            try {
                bool correcto = false;
                OleDbConnection cnnProc = new OleDbConnection(Class.clsMain.CnnStr);
                cnnProc.Open();
                OleDbTransaction tranProc = cnnProc.BeginTransaction();
                OleDbCommand cmdProc = new OleDbCommand();
                cmdProc.Connection = cnnProc;
                cmdProc.Transaction = tranProc;
                try {
                    //creamos el registro de inventario
                    cmdProc.CommandText = "INSERT INTO INVENTARIO_FISICO (USER_LOGIN)" +
                        " VALUES('"+ frmLogin._USER_LOGIN +"')";
                    cmdProc.ExecuteNonQuery();
                    
                    //obtenemos el folio
                    int varFOLIO_INVENTARIO_FISICO = 0;
                    cmdProc.CommandText = "SELECT @@IDENTITY";
                    varFOLIO_INVENTARIO_FISICO = Convert.ToInt32(cmdProc.ExecuteScalar());
                    //actualizamos la temporal
                    cmdProc.CommandText = "UPDATE TEMP_INVENTARIO_FISICO SET FOLIO_INVENTARIO_FISICO="+ varFOLIO_INVENTARIO_FISICO +"";
                    cmdProc.ExecuteNonQuery();
                    //insertamos el detalle
                    cmdProc.CommandText = "INSERT INTO INVENTARIO_FISICO_DETALLE(FOLIO_INVENTARIO_FISICO,ID_PRODUCTO,CANTIDAD,CANTIDAD_ANTES,PRECIO_COMPRA,PRECIO_VENTA)" +
                    "SELECT FOLIO_INVENTARIO_FISICO,ID_PRODUCTO,CANTIDAD,CANTIDAD_ANTES,PRECIO_COMPRA,PRECIO_VENTA FROM TEMP_INVENTARIO_FISICO";
                    cmdProc.ExecuteNonQuery();
                    //actualizamos las existencias
                    cmdProc.CommandText = "UPDATE CAT_PRODUCTO "+
                        " INNER JOIN TEMP_INVENTARIO_FISICO ON CAT_PRODUCTO.ID_PRODUCTO = TEMP_INVENTARIO_FISICO.ID_PRODUCTO "+
                        " SET CAT_PRODUCTO.EXISTENCIA = [TEMP_INVENTARIO_FISICO].[CANTIDAD];";
                    cmdProc.ExecuteNonQuery();
                    //borramos la temporal
                    cmdProc.CommandText = "DELETE FROM TEMP_INVENTARIO_FISICO";
                    cmdProc.ExecuteNonQuery();
                    //consolidar transacción
                    tranProc.Commit();
                    MessageBox.Show("El inventario ha sido registrado satisfactoriamente", 
                        "Información del sistema",
                        MessageBoxButtons.OK,MessageBoxIcon.Information);
                    correcto = true;
                }
                catch (Exception ex) {
                    //cancelar transacción
                    MessageBox.Show(ex.Message,
                    "fnEjecutarProceso",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tranProc.Rollback();
                    correcto = false;
                }
                return (correcto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, 
                    "fnEjecutarProceso", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ReadData();
        }

        private void mnuImprimirLista_Click(object sender, EventArgs e)
        {
            lvItems.Title = "Inventario físico (Conteo)";
            lvItems.FitToPage = true;
            lvItems.PrintPreview();
        }
        public void ImprimeReporte(string prmSQL,string prmTitle, string prmComments)
        {
            try
            {
                string varSQL = prmSQL;

                DataSet dsReporte = new DataSet(); //Datset para el reporte
                OleDbConnection cnnReporte = new OleDbConnection(Class.clsMain.CnnStr);
                if (cnnReporte.State == ConnectionState.Open)
                    cnnReporte.Close();
                cnnReporte.Open();
                dsReporte.Clear();//limpiamos el dataset
                OleDbDataAdapter daReporte =
                    new OleDbDataAdapter(varSQL, cnnReporte);
                daReporte.Fill(dsReporte, "CAT_PRODUCTO");//llenamos el DataSet con la info de la FACTURA

                //destruimos los objetos utilizados
                if (cnnReporte.State == ConnectionState.Open)
                    cnnReporte.Close();
                daReporte.Dispose();

                cnnReporte.Dispose();
                //ya tenoemos la info en el DataSet, ahora cargamos el reporte
                //Reports.rptListaInventarioFisico _Reporte = new Reports.rptListaInventarioFisico();


                //_Reporte.SummaryInfo.ReportTitle = prmTitle;
                //_Reporte.SummaryInfo.ReportComments = prmComments;
                //_Reporte.SetDataSource(dsReporte);
                //_Reporte.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;

                //Forms.frmReports _frmReportes = new frmReports();
                //_frmReportes.crvReportes.DisplayGroupTree = false;
                //_frmReportes.crvReportes.ReportSource = _Reporte;
                //_frmReportes.StartPosition = FormStartPosition.CenterScreen;
                //_frmReportes.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" +
                    ex.Source, "Loading Ticket Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuImprimirListaConteo_Click(object sender, EventArgs e)
        {
            ImprimeReporte("SELECT ID_PRODUCTO,DESC_PRODUCTO,EXISTENCIA,LOCALIZACION FROM CAT_PRODUCTO ORDER BY LOCALIZACION,DESC_PRODUCTO", "LISTA PARA CONTEO", "");
        }

        private void mnuImprimirListaNoContados_Click(object sender, EventArgs e)
        {
            ImprimeReporte("SELECT ID_PRODUCTO,DESC_PRODUCTO,EXISTENCIA,LOCALIZACION FROM CAT_PRODUCTO " +
                " WHERE ID_PRODUCTO NOT IN(SELECT ID_PRODUCTO FROM TEMP_INVENTARIO_FISICO) ORDER BY LOCALIZACION,DESC_PRODUCTO", "LISTA DE PRODUCTOS PENDIENTES DE CONTAR", "");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}