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
    public partial class frmGastoLista : Telerik.WinControls.UI.RadForm
    {
        private static frmGastoLista m_FormDefInstance;
        public static frmGastoLista DefInstance
        {
            get
            {

                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmGastoLista();
                return m_FormDefInstance;
            }
            set { m_FormDefInstance = value; }
        }
        public frmGastoLista()
        {
            InitializeComponent();
        }
        string filtroSQL = "";
        string DescFiltro = "";
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmGasto _frmGasto = new frmGasto();
            _frmGasto.StartPosition = FormStartPosition.CenterScreen;
            _frmGasto.ShowDialog();
            if (frmGasto._Accion) {
                ReadData();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGastoLista_Load(object sender, EventArgs e)
        {
            Encabezados();
            ReadData();
        }
        private void Encabezados()
        {
            lvCatProducto.View = View.Details;
            lvCatProducto.Columns.Add("Folio", 50, HorizontalAlignment.Left);
            lvCatProducto.Columns.Add("Fecha", 80, HorizontalAlignment.Left);
            lvCatProducto.Columns.Add("Tipo", 200, HorizontalAlignment.Left);
            lvCatProducto.Columns.Add("Observaciones", 200, HorizontalAlignment.Left);
            lvCatProducto.Columns.Add("Importe", 90, HorizontalAlignment.Right);
           


        }
        private void FiltroSQL()
        {
            try
            {
                System.DateTime varFECHA_ACTUAL = System.DateTime.Now;
                bool varFILTRO = Convert.ToBoolean(AppSettings.GetValue("FILTRO_GASTOS", "FILTRO", Convert.ToString(false)));
                bool varFILTRO_HOY = Convert.ToBoolean(AppSettings.GetValue("FILTRO_GASTOS", "HOY", Convert.ToString(false)));
                System.DateTime varFECHA_INI = Convert.ToDateTime(AppSettings.GetValue("FILTRO_GASTOS", "FECHA_INI", Convert.ToString(varFECHA_ACTUAL)));
                System.DateTime varFECHA_FIN = Convert.ToDateTime(AppSettings.GetValue("FILTRO_GASTOS", "FECHA_FIN", Convert.ToString(varFECHA_ACTUAL)));
                if (varFILTRO)
                {
                    //Se supone que hay un filtro, hay que chacer si es para hoy o por un rango de fechas
                    if (varFILTRO_HOY)
                    {
                        //el filtro es para mostrar solo lo de hoy
                        filtroSQL = filtroSQL = " SELECT FOLIO_GASTO,FECHA_GASTO,IMPORTE,DESC_TIPO_GASTO,OBSERVACIONES "+
                            " FROM  GASTO,CAT_TIPO_GASTO "+
                            " WHERE GASTO.ID_TIPO_GASTO =CAT_TIPO_GASTO.ID_TIPO_GASTO "+
                            " AND FECHA_GASTO BETWEEN #" + ISODates.MSAccessDateINI(DateTime.Now) + "# AND #" + ISODates.MSAccessDateFIN(DateTime.Now) + "#";
                        DescFiltro = " SOLO DE " + System.DateTime.Now.ToLongDateString();
                    }
                    else
                    {
                        //el filtro es por un rango de fechas
                        DescFiltro = String.Format(" ENTRE {0} y  {1}", varFECHA_INI.Date.ToLongDateString(), varFECHA_FIN.Date.ToLongDateString());
                        filtroSQL = " SELECT FOLIO_GASTO,FECHA_GASTO,IMPORTE,DESC_TIPO_GASTO,OBSERVACIONES " +
                            " FROM  GASTO,CAT_TIPO_GASTO " +
                            " WHERE GASTO.ID_TIPO_GASTO =CAT_TIPO_GASTO.ID_TIPO_GASTO " +
                            " AND FECHA_GASTO BETWEEN #" + ISODates.MSAccessDateINI(varFECHA_INI) + "# AND #" + ISODates.MSAccessDateFIN(varFECHA_FIN) + "#";
                    }
                }
                else
                {
                    //no se aplica filtro de nigun tipo
                    DescFiltro = "(TODO)";
                    filtroSQL = filtroSQL = " SELECT FOLIO_GASTO,FECHA_GASTO,IMPORTE,DESC_TIPO_GASTO,OBSERVACIONES " +
                            " FROM  GASTO,CAT_TIPO_GASTO " +
                            " WHERE GASTO.ID_TIPO_GASTO =CAT_TIPO_GASTO.ID_TIPO_GASTO ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                filtroSQL = "";
            }
        }
        private void ReadData()
        {
            //Este procedimiento lee los datos que se tranferirán y los mostrará en forma de
            //lista en el ListView
            FiltroSQL();
            try
            {
                string varSQL = filtroSQL;
                double varTOTAL = 0;
                
                //Si la conexion esta abierta la cerramos; en caso contrario, la abrimos
                OleDbConnection cnnReadData = new OleDbConnection(Class.clsMain.CnnStr);
                if (cnnReadData.State == ConnectionState.Open) cnnReadData.Close(); else cnnReadData.Open();
                int I = 0;
                OleDbCommand cmdReadData = new OleDbCommand(filtroSQL, cnnReadData);
                OleDbDataReader drReadData;
                drReadData = cmdReadData.ExecuteReader();
                lvCatProducto.Items.Clear();
                while (drReadData.Read())
                {
                    lvCatProducto.Items.Add(drReadData["FOLIO_GASTO"].ToString());
                    lvCatProducto.Items[I].SubItems.Add(String.Format("{0:d}",drReadData["FECHA_GASTO"]));
                    lvCatProducto.Items[I].SubItems.Add(drReadData["DESC_TIPO_GASTO"].ToString());
                    lvCatProducto.Items[I].SubItems.Add(drReadData["OBSERVACIONES"].ToString());
                    lvCatProducto.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["IMPORTE"]));
                    
                    varTOTAL += Convert.ToDouble(drReadData["IMPORTE"]);
                   
                    I += 1;
                }
                this.Text = "LISTA DE GASTOS: " + I.ToString() + ", FILTRO: " + DescFiltro;
                //Agregamos un registro más
                if (I != 0)
                {
                    lvCatProducto.Items.Add("");
                    lvCatProducto.Items[I].SubItems.Add("");
                    lvCatProducto.Items[I].SubItems.Add("");
                    lvCatProducto.Items[I].SubItems.Add("Total:");
                    lvCatProducto.Items[I].SubItems.Add(String.Format("{0:C}", varTOTAL));
                    
                    //
                   
                }
                drReadData.Close();
                cmdReadData.Dispose();
                cnnReadData.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ReadData();
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            //Filtrar
            Forms.frmFiltro mi_frmFiltroVentas = new frmFiltro("FILTRO_GASTOS");
            mi_frmFiltroVentas.StartPosition = FormStartPosition.CenterScreen;
            mi_frmFiltroVentas.ShowDialog();
            ReadData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            POSDLL.Utilities.ExportListView exportar = new POSDLL.Utilities.ExportListView();
            exportar.ExportToExcel(lvCatProducto, "ListaDeGastos");
        }


        private void btnPrintList_Click(object sender, EventArgs e)
        {
            //Imprimir
            lvCatProducto.Title = "GASTOS " + DescFiltro;
            lvCatProducto.FitToPage = true;
            lvCatProducto.PrintPreview();
        }
    }
}