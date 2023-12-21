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
    public partial class frmRptVentasArticuloCantidad : Telerik.WinControls.UI.RadForm
    {
        private static frmRptVentasArticuloCantidad m_FormDefInstance;
        public static frmRptVentasArticuloCantidad DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmRptVentasArticuloCantidad();
                return m_FormDefInstance;
            }
            set { m_FormDefInstance = value; }
        }
        public frmRptVentasArticuloCantidad()
        {
            InitializeComponent();
        }
        
        
        string filtroSQL = "";
        string DescFiltro = "";

        private void frmListaVentasArticulo_Load(object sender, EventArgs e)
        {
            Encabezados();
            ReadData();
        }
        private void Encabezados()
        {
            lvListaVentas.View = View.Details;
            lvListaVentas.Columns.Add("N°", 75, HorizontalAlignment.Left);
            lvListaVentas.Columns.Add("Item", 75, HorizontalAlignment.Left);
            lvListaVentas.Columns.Add("Description", 200, HorizontalAlignment.Left);
            lvListaVentas.Columns.Add("Cantidad", 100, HorizontalAlignment.Right);
           


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

                        filtroSQL = "SELECT VENTA_DETALLE.ID_PRODUCTO, CAT_PRODUCTO.DESC_PRODUCTO,SUM(CANTIDAD) AS CANTIDAD"+
                            " FROM VENTA INNER JOIN (CAT_PRODUCTO INNER JOIN VENTA_DETALLE ON CAT_PRODUCTO.ID_PRODUCTO = VENTA_DETALLE.ID_PRODUCTO) ON VENTA.FOLIO = VENTA_DETALLE.FOLIO "+
                            " WHERE VENTA_DETALLE.CANTIDAD<>0 AND  VENTA.FECHA BETWEEN #" + ISODates.MSAccessDateINI(DateTime.Now) + "# AND #" + ISODates.MSAccessDateFIN(DateTime.Now) + "#" +
                            " GROUP BY VENTA_DETALLE.ID_PRODUCTO, CAT_PRODUCTO.DESC_PRODUCTO;";
                        //filtroSQL = filtroSQL = " EXECUTE sp_LISTA_VENTA '" + Class.clsDates.fnConvertToAccessDate(DateTime.Now) + "' ,'" + Class.clsDates.fnConvertToAccessDate(DateTime.Now) + "'";
                        DescFiltro = "SOLO DE " + System.DateTime.Now.ToLongDateString();
                    }
                    else
                    {
                        //el filtro es por un rango de fechas
                       
                        DescFiltro = String.Format("VENTAS ENTRE  {0} y  {1}", varFECHA_INI.Date.ToLongDateString(), varFECHA_FIN.Date.ToLongDateString());
                        filtroSQL = "SELECT VENTA_DETALLE.ID_PRODUCTO, CAT_PRODUCTO.DESC_PRODUCTO,SUM(CANTIDAD) AS CANTIDAD " +
                            " FROM VENTA INNER JOIN (CAT_PRODUCTO INNER JOIN VENTA_DETALLE ON CAT_PRODUCTO.ID_PRODUCTO = VENTA_DETALLE.ID_PRODUCTO) ON VENTA.FOLIO = VENTA_DETALLE.FOLIO " +
                            " WHERE VENTA_DETALLE.CANTIDAD<>0  AND VENTA.FECHA BETWEEN #" + ISODates.MSAccessDateINI(varFECHA_INI) + "# AND #" + ISODates.MSAccessDateFIN(varFECHA_FIN) + "#" +
                            " GROUP BY VENTA_DETALLE.ID_PRODUCTO, CAT_PRODUCTO.DESC_PRODUCTO;";
                        //filtroSQL = " EXECUTE sp_LISTA_VENTA '" + Class.clsDates.fnConvertToAccessDate(varFECHA_INI) + "' ,'" + Class.clsDates.fnConvertToAccessDate(varFECHA_FIN) + "'";
                    }
                }
                else
                {
                    //no se aplica filtro de nigun tipo
                   
                    DescFiltro = "(TODO)";
                    //filtroSQL = filtroSQL = " EXECUTE sp_LISTA_VENTA '19000101' ,'" + Class.clsDates.fnConvertToAccessDate(DateTime.Now) + "'";
                    filtroSQL = "SELECT VENTA_DETALLE.ID_PRODUCTO, CAT_PRODUCTO.DESC_PRODUCTO,SUM(CANTIDAD) AS CANTIDAD " +
                              " FROM VENTA INNER JOIN (CAT_PRODUCTO INNER JOIN VENTA_DETALLE ON CAT_PRODUCTO.ID_PRODUCTO = VENTA_DETALLE.ID_PRODUCTO) ON VENTA.FOLIO = VENTA_DETALLE.FOLIO " +
                              " WHERE VENTA_DETALLE.CANTIDAD<>0 " +
                              " GROUP BY VENTA_DETALLE.ID_PRODUCTO, CAT_PRODUCTO.DESC_PRODUCTO;";
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
                    lvListaVentas.Items.Add(Convert.ToString(I+1));
                    lvListaVentas.Items[I].SubItems.Add(drReadData["ID_PRODUCTO"].ToString());
                    lvListaVentas.Items[I].SubItems.Add(drReadData["DESC_PRODUCTO"].ToString());
                    lvListaVentas.Items[I].SubItems.Add(String.Format("{0:N}", drReadData["CANTIDAD"]));
                    
                  
                    I += 1;
                }
                lblInfo.Text = String.Format("Se encontraron {0} registro(s)", I);
                //this.Text = "Register Numbers: " + I.ToString() + ", Filter: " + DescFiltro;
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

        private void btnFilter_Click(object sender, EventArgs e)
        {
            //Filtrar
            Forms.frmFiltro mi_frmFiltroVentas = new frmFiltro("FILTRO_VENTAS");
            mi_frmFiltroVentas.StartPosition = FormStartPosition.CenterScreen;
            mi_frmFiltroVentas.ShowDialog();
            ReadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrintList_Click(object sender, EventArgs e)
        {
            //Imprimir
            lvListaVentas.Title = "VENTA POR ARTICULO " + DescFiltro;
            lvListaVentas.FitToPage = true;
            lvListaVentas.PrintPreview();
        }

        private void mnuPrintList_Click(object sender, EventArgs e)
        {
            //Imprimir
            lvListaVentas.Title = "VENTA POR ARTICULO" + DescFiltro;
            lvListaVentas.FitToPage = true;
            lvListaVentas.PrintPreview();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            
        }
        

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ReadData();
        }

    }
}