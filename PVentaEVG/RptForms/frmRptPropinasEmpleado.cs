using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POSDLL; using POSDLL.Windows.Forms; using POSDLL.Security; using POSDLL.Reporting; using POSDLL.Ticket;
namespace POSApp.Forms
{
    public partial class frmRptPropinasEmpleado : Telerik.WinControls.UI.RadForm
    {
        private static frmRptPropinasEmpleado m_FormDefInstance;
        public static frmRptPropinasEmpleado DefInstance
        {
            get
            {

                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmRptPropinasEmpleado();
                return m_FormDefInstance;
            }
            set { m_FormDefInstance = value; }
        }
        public frmRptPropinasEmpleado()
        {
            InitializeComponent();
        }
        string filtroSQL = "";
        string DescFiltro = "";
        private void frmRptPropinasEmpleado_Load(object sender, EventArgs e)
        {
            Encabezados();
            ReadData();
        }
        private void Encabezados()
        {
            lvRpt.View = View.Details;
            lvRpt.Columns.Add("Clave Empleado", 90, HorizontalAlignment.Left);
            lvRpt.Columns.Add("Nombre", 175, HorizontalAlignment.Left);
            lvRpt.Columns.Add("Total", 50, HorizontalAlignment.Center);


        }
        private void FiltroSQL()
        {
            try
            {
                System.DateTime varFECHA_ACTUAL = System.DateTime.Now;
                bool varFILTRO = Convert.ToBoolean(AppSettings.GetValue("FILTRO_REPORTES", "FILTRO", Convert.ToString(false)));
                bool varFILTRO_HOY = Convert.ToBoolean(AppSettings.GetValue("FILTRO_REPORTES", "HOY", Convert.ToString(false)));
                System.DateTime varFECHA_INI = Convert.ToDateTime(AppSettings.GetValue("FILTRO_REPORTES", "FECHA_INI", Convert.ToString(varFECHA_ACTUAL)));
                System.DateTime varFECHA_FIN = Convert.ToDateTime(AppSettings.GetValue("FILTRO_REPORTES", "FECHA_FIN", Convert.ToString(varFECHA_ACTUAL)));
                if (varFILTRO)
                {
                    //Se supone que hay un filtro, hay que chacer si es para hoy o por un rango de fechas
                    if (varFILTRO_HOY)
                    {
                        //el filtro es para mostrar solo lo de hoy
                        filtroSQL = filtroSQL = "SELECT V.ID_EMPLEADO, E.NOMBRE,SUM(V.PROPINA) AS TOTAL FROM VENTA V,CAT_EMPLEADO E "+
                            " WHERE V.ID_EMPLEADO=E.ID_EMPLEADO AND FECHA BETWEEN #" + ISODates.MSAccessDateINI(DateTime.Now) + "# AND #" + ISODates.MSAccessDateFIN(DateTime.Now) + "#" +
                            " GROUP BY  V.ID_EMPLEADO, E.NOMBRE";
                        DescFiltro = " SOLO DE " + System.DateTime.Now.ToLongDateString();
                    }
                    else
                    {
                        //el filtro es por un rango de fechas
                        DescFiltro = String.Format(" ENTRE {0} y  {1}", varFECHA_INI.Date.ToLongDateString(), varFECHA_FIN.Date.ToLongDateString());
                        filtroSQL = " SELECT V.ID_EMPLEADO, E.NOMBRE,SUM(V.PROPINA) AS TOTAL FROM VENTA V,CAT_EMPLEADO E "+
                            " WHERE V.ID_EMPLEADO=E.ID_EMPLEADO AND  FECHA BETWEEN #" + ISODates.MSAccessDateINI(varFECHA_INI) + "# AND #" + ISODates.MSAccessDateFIN(varFECHA_FIN) + "#" +
                            " GROUP BY  V.ID_EMPLEADO, E.NOMBRE";
                    }
                }
                else
                {
                    //no se aplica filtro de nigun tipo
                    DescFiltro = "(TODO)";
                    filtroSQL = filtroSQL = " SELECT V.ID_EMPLEADO, E.NOMBRE,SUM(V.PROPINA) AS TOTAL FROM VENTA V,CAT_EMPLEADO E "+
                        " WHERE V.ID_EMPLEADO=E.ID_EMPLEADO GROUP BY  V.ID_EMPLEADO, E.NOMBRE";
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
                cnnReadData.Open();
                int I = 0;
                OleDbCommand cmdReadData = new OleDbCommand(filtroSQL, cnnReadData);
                OleDbDataReader drReadData;
                drReadData = cmdReadData.ExecuteReader();
                lvRpt.Items.Clear();
                while (drReadData.Read())
                {
                    lvRpt.Items.Add(drReadData["ID_EMPLEADO"].ToString());
                    lvRpt.Items[I].SubItems.Add(drReadData["NOMBRE"].ToString());
                    lvRpt.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["TOTAL"]));
                    
                    varTOTAL += Convert.ToDouble(drReadData["TOTAL"]);
                 
                   
                    I += 1;
                }
                lblInfo.Text = String.Format("Se encontraron {0} registro(s)", I);
                //this.Text = "PROPINAS: " + I.ToString() + ", FILTRO: " + DescFiltro;
                //Agregamos un registro más
                if (I != 0)
                {
                    lvRpt.Items.Add("");
                    lvRpt.Items[I].SubItems.Add("Total:");
                    lvRpt.Items[I].SubItems.Add(String.Format("{0:C}", varTOTAL));
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

        private void btnFilter_Click(object sender, EventArgs e)
        {
            //Filtrar
            Forms.frmFiltro mi_frmFiltroVentas = new frmFiltro("FILTRO_REPORTES");
            mi_frmFiltroVentas.StartPosition = FormStartPosition.CenterScreen;
            mi_frmFiltroVentas.ShowDialog();
            ReadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ReadData();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (lvRpt.Items.Count != 0)
            {
                
                POSDLL.Utilities.ExportListView exportar = new POSDLL.Utilities.ExportListView();
                
                exportar.ExportToExcel(lvRpt, "PropinasPorEmpleado");
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (lvRpt.Items.Count != 0)
            {
                lvRpt.Title = "Propinas por empleado";
                lvRpt.FitToPage = true;
                lvRpt.PrintPreview();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
