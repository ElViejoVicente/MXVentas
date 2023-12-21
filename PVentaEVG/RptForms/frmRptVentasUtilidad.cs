using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POSDLL; using POSDLL.Windows.Forms; using POSDLL.Security; using POSDLL.Reporting; using POSDLL.Ticket;
namespace POSApp.Forms
{
    public partial class frmRptVentasUtilidad : Telerik.WinControls.UI.RadForm
    {
        private static frmRptVentasUtilidad m_FormDefInstance;
        public static frmRptVentasUtilidad DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmRptVentasUtilidad();
                return m_FormDefInstance;
            }
            set { m_FormDefInstance = value; }
        }
        public frmRptVentasUtilidad()
        {
            InitializeComponent();
        }
        string filtroSQL = "";
        string DescFiltro = "";
        private void frmRptVentasUtilidad_Load(object sender, EventArgs e)
        {
            Encabezados();
            ReadData();
        }
        private void Encabezados()
        {
            lvListaVentas.View = View.Details;
            lvListaVentas.Columns.Add("Ticket", 50, HorizontalAlignment.Left);
            lvListaVentas.Columns.Add("Fecha", 150, HorizontalAlignment.Left);
            lvListaVentas.Columns.Add("Caja", 50, HorizontalAlignment.Center);
            lvListaVentas.Columns.Add("Cajero", 175, HorizontalAlignment.Left);
            lvListaVentas.Columns.Add("Status", 50, HorizontalAlignment.Left);
            lvListaVentas.Columns.Add("Total", 95, HorizontalAlignment.Right);
            lvListaVentas.Columns.Add("Costo", 95, HorizontalAlignment.Right);
            lvListaVentas.Columns.Add("Utilidad", 95, HorizontalAlignment.Right);

        }
        private void FiltroSQL()
        {
            try
            {
                System.DateTime varFECHA_ACTUAL = System.DateTime.Now;
                bool varFILTRO = Convert.ToBoolean(AppSettings.GetValue("FILTRO_VENTAS", "FILTRO", Convert.ToString(false)));
                bool varFILTRO_HOY = Convert.ToBoolean(AppSettings.GetValue("FILTRO_VENTAS", "HOY", Convert.ToString(false)));
                System.DateTime varFECHA_INI = Convert.ToDateTime(AppSettings.GetValue("FILTRO_VENTAS", "FECHA_INI", Convert.ToString(varFECHA_ACTUAL)));
                System.DateTime varFECHA_FIN = Convert.ToDateTime(AppSettings.GetValue("FILTRO_VENTAS", "FECHA_FIN", Convert.ToString(varFECHA_ACTUAL)));
                if (varFILTRO)
                {
                    //Se supone que hay un filtro, hay que chacer si es para hoy o por un rango de fechas
                    if (varFILTRO_HOY)
                    {
                        //el filtro es para mostrar solo lo de hoy
                        filtroSQL = filtroSQL = " SELECT FOLIO,FECHA,ID_CAJA,CAJERO, STATUS,(TOTAL-DESCUENTO) AS TOTAL,(TOTAL_COMPRA-DESCUENTO) AS COSTO FROM  V_LISTA_VENTA WHERE FECHA BETWEEN #" + ISODates.MSAccessDateINI(DateTime.Now) + "# AND #" + ISODates.MSAccessDateFIN(DateTime.Now) + "#";
                        DescFiltro = " SOLO DE " + System.DateTime.Now.ToLongDateString();
                    }
                    else
                    {
                        //el filtro es por un rango de fechas
                        DescFiltro = String.Format(" ENTRE {0} y  {1}", varFECHA_INI.Date.ToLongDateString(), varFECHA_FIN.Date.ToLongDateString());
                        filtroSQL = " SELECT FOLIO,FECHA,ID_CAJA,CAJERO, STATUS,(TOTAL-DESCUENTO) AS TOTAL,(TOTAL_COMPRA-DESCUENTO) AS COSTO FROM V_LISTA_VENTA WHERE FECHA BETWEEN #" + ISODates.MSAccessDateINI(varFECHA_INI) + "# AND #" + ISODates.MSAccessDateFIN(varFECHA_FIN) + "#";
                    }
                }
                else
                {
                    //no se aplica filtro de nigun tipo
                    DescFiltro = "(TODO)";
                    filtroSQL = filtroSQL = " SELECT FOLIO,FECHA,ID_CAJA,CAJERO, STATUS,(TOTAL-DESCUENTO) AS TOTAL,(TOTAL_COMPRA-DESCUENTO) AS COSTO FROM  V_LISTA_VENTA ";
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
                double varCOSTO = 0;
                double varUTILIDAD = 0;
                //Si la conexion esta abierta la cerramos; en caso contrario, la abrimos
                OleDbConnection cnnReadData = new OleDbConnection(Class.clsMain.CnnStr);
                if (cnnReadData.State == ConnectionState.Open) cnnReadData.Close(); else cnnReadData.Open();
                int I = 0;
                OleDbCommand cmdReadData = new OleDbCommand(filtroSQL, cnnReadData);
                OleDbDataReader drReadData;
                drReadData = cmdReadData.ExecuteReader();
                lvListaVentas.Items.Clear();
                while (drReadData.Read())
                {
                    lvListaVentas.Items.Add(drReadData["FOLIO"].ToString());
                    lvListaVentas.Items[I].SubItems.Add(drReadData["FECHA"].ToString());
                    lvListaVentas.Items[I].SubItems.Add(drReadData["ID_CAJA"].ToString());
                    lvListaVentas.Items[I].SubItems.Add(drReadData["CAJERO"].ToString());
                    lvListaVentas.Items[I].SubItems.Add(drReadData["STATUS"].ToString());
                    lvListaVentas.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["TOTAL"]));
                    lvListaVentas.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["COSTO"]));
                    lvListaVentas.Items[I].SubItems.Add(String.Format("{0:C}", Convert.ToDouble(drReadData["TOTAL"]) - Convert.ToDouble(drReadData["COSTO"])));

                    if (Convert.ToDouble(drReadData["TOTAL"]) == 0)
                    {
                        lvListaVentas.Items[I].ForeColor = Color.Gray;
                        lvListaVentas.Items[I].ToolTipText = "CANCELADA";
                    }
                    else {
                        varTOTAL += Convert.ToDouble(drReadData["TOTAL"]);
                        varCOSTO += Convert.ToDouble(drReadData["COSTO"]);
                        varUTILIDAD += Convert.ToDouble(drReadData["TOTAL"]) - Convert.ToDouble(drReadData["COSTO"]);
                    }
                    I += 1;
                }
                lblInfo.Text = String.Format("Se encontraron {0} registro(s)", I);
                //this.Text = "LISTA DE VENTAS: " + I.ToString() + ", FILTRO: " + DescFiltro;
                //Agregamos un registro más
                if (I != 0)
                {
                    lvListaVentas.Items.Add("");
                    lvListaVentas.Items[I].SubItems.Add("");
                    lvListaVentas.Items[I].SubItems.Add("");
                    lvListaVentas.Items[I].SubItems.Add("");
                    lvListaVentas.Items[I].SubItems.Add("Total:");
                    lvListaVentas.Items[I].SubItems.Add(String.Format("{0:C}", varTOTAL));
                    lvListaVentas.Items[I].SubItems.Add(String.Format("{0:C}", varCOSTO));
                    lvListaVentas.Items[I].SubItems.Add(String.Format("{0:C}", varUTILIDAD));
                    
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(lvListaVentas.Items.Count!=0){
            lvListaVentas.FitToPage = true;
            lvListaVentas.Title = "Ventas con utilidad";
            lvListaVentas.PrintPreview();
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (lvListaVentas.Items.Count != 0) {
                POSDLL.Utilities.ExportListView exportar = new POSDLL.Utilities.ExportListView();
                exportar.ExportToExcel(lvListaVentas, "VentasConUtilidad");
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            //Filtrar
            Forms.frmFiltro mi_frmFiltroVentas = new frmFiltro("FILTRO_VENTAS");
            mi_frmFiltroVentas.StartPosition = FormStartPosition.CenterScreen;
            mi_frmFiltroVentas.ShowDialog();
            ReadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ReadData();
        }
    }
}
