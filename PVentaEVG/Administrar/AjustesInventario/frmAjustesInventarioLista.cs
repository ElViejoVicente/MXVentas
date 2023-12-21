using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using POSApp.Administrar.AjustesInventario;
using POSDLL;

namespace POSApp.Forms
{
    public partial class frmAjustesInventarioLista : Telerik.WinControls.UI.RadForm
    {
        private static frmAjustesInventarioLista m_FormDefInstance;
        public static frmAjustesInventarioLista DefInstance
        {
            get
            {

                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmAjustesInventarioLista();
                return m_FormDefInstance;
            }
            set { m_FormDefInstance = value; }
        }
        public frmAjustesInventarioLista()
        {
            InitializeComponent();
           
     
        }
        string filtroSQL = "";
        string DescFiltro = "";
        
        Class.clsVentas _clsVentas = new Class.clsVentas();
        private void frmListaAjustesInventario_Load(object sender, EventArgs e)
        {
            Encabezados();
            FiltroSQL();
            ReadData(filtroSQL);
        }
        void lvCatProducto_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            
          


        }
        void Encabezados()
        {
            lvCatProducto.View = View.Details;
            lvCatProducto.Columns.Add("Folio", 50, HorizontalAlignment.Left);
            lvCatProducto.Columns.Add("Fecha", 100, HorizontalAlignment.Left);
            lvCatProducto.Columns.Add("Artículo", 200, HorizontalAlignment.Left);
            lvCatProducto.Columns.Add("Cant. Antes", 90, HorizontalAlignment.Right);
            lvCatProducto.Columns.Add("Ajuste", 50, HorizontalAlignment.Right);
            lvCatProducto.Columns.Add("Cant. Después",100, HorizontalAlignment.Right);
            lvCatProducto.Columns.Add("Tipo de Ajuste", 100, HorizontalAlignment.Left);
            lvCatProducto.Columns.Add("Observaciones", 100, HorizontalAlignment.Left);
        }
        private void FiltroSQL()
        {
            try
            {
                System.DateTime varFECHA_ACTUAL = System.DateTime.Now;
                bool varFILTRO = Convert.ToBoolean(AppSettings.GetValue("FILTRO_AJUSTES", "FILTRO", Convert.ToString(false)));
                bool varFILTRO_HOY = Convert.ToBoolean(AppSettings.GetValue("FILTRO_AJUSTES", "HOY", Convert.ToString(false)));
                System.DateTime varFECHA_INI = Convert.ToDateTime(AppSettings.GetValue("FILTRO_AJUSTES", "FECHA_INI", Convert.ToString(varFECHA_ACTUAL)));
                System.DateTime varFECHA_FIN = Convert.ToDateTime(AppSettings.GetValue("FILTRO_AJUSTES", "FECHA_FIN", Convert.ToString(varFECHA_ACTUAL)));
                if (varFILTRO)
                {
                    //Se supone que hay un filtro, hay que chacer si es para hoy o por un rango de fechas
                    if (varFILTRO_HOY)
                    {
                        //el filtro es para mostrar solo lo de hoy
                        filtroSQL = filtroSQL = " SELECT * FROM  vAJUSTES_INVENTARIO WHERE FECHA_AJUSTE BETWEEN #" + ISODates.MSAccessDateINI(DateTime.Now) + "# AND #" + ISODates.MSAccessDateFIN(DateTime.Now) + "# ORDER BY FOLIO_AJUSTE";
                        DescFiltro = "SOLO: " + System.DateTime.Now.ToLongDateString();
                    }
                    else
                    {
                        //el filtro es por un rango de fechas
                        DescFiltro = String.Format("Info entre {0} y  {1}", varFECHA_INI.Date.ToLongDateString(), varFECHA_FIN.Date.ToLongDateString());
                        filtroSQL = " SELECT * FROM vAJUSTES_INVENTARIO WHERE FECHA_AJUSTE BETWEEN #" + ISODates.MSAccessDateINI(varFECHA_INI) + "# AND #" + ISODates.MSAccessDateFIN(varFECHA_FIN) + "# ORDER BY FOLIO_AJUSTE";
                    }
                }
                else
                {
                    //no se aplica filtro de nigun tipo
                    DescFiltro = "(All INFO)";
                    filtroSQL = filtroSQL = " SELECT * FROM  vAJUSTES_INVENTARIO  ORDER BY FOLIO_AJUSTE";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                filtroSQL = "SELECT * FROM  vAJUSTES_INVENTARIO ORDER BY FOLIO_AJUSTE";
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAjuste _frmAjuste = new frmAjuste(0);
            _frmAjuste.StartPosition = FormStartPosition.CenterScreen;
            _frmAjuste.ShowDialog();
            FiltroSQL();
            ReadData(filtroSQL);
        }

        void ReadData(string prmSQL)
        {
            try
            {
                OleDbConnection cnnReadData = new OleDbConnection(Class.clsMain.CnnStr);
                string varSQL = prmSQL;
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
                    lvCatProducto.Items.Add(drReadData["FOLIO_AJUSTE"].ToString());
                    lvCatProducto.Items[I].SubItems.Add(Convert.ToDateTime(drReadData["FECHA_AJUSTE"]).ToShortDateString());
                    lvCatProducto.Items[I].SubItems.Add(drReadData["DESC_PRODUCTO"].ToString());
                    lvCatProducto.Items[I].SubItems.Add(String.Format("{0:N}", drReadData["CANTIDAD_ANTES"]));
                    lvCatProducto.Items[I].SubItems.Add(String.Format("{0:N}", drReadData["CANTIDAD_AJUSTE"]));
                    lvCatProducto.Items[I].SubItems.Add(String.Format("{0:N}", drReadData["CANTIDAD_DESPUES"]));
                    lvCatProducto.Items[I].SubItems.Add(drReadData["DESC_TIPO_AJUSTE"].ToString());
                    lvCatProducto.Items[I].SubItems.Add(drReadData["OBSERVACIONES"].ToString());
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
       
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            FiltroSQL();
            ReadData(filtroSQL);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            FiltroSQL();
          
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            //Filtrar
            Forms.frmFiltro mi_frmFiltroVentas = new frmFiltro("FILTRO_AJUSTES");
            mi_frmFiltroVentas.StartPosition = FormStartPosition.CenterScreen;
            mi_frmFiltroVentas.ShowDialog();
            FiltroSQL();
            ReadData(filtroSQL);
        }


       


        private void btnPrint_Click(object sender, EventArgs e)
        {
            lvCatProducto.Title = "Lista de ajustes al inventario: Fecha de impresión:" + DateTime.Now;
            lvCatProducto.FitToPage = true;
            lvCatProducto.PrintPreview();
        }
    }
}