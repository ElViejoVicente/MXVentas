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
    public partial class frmRptEntradaArticulos : Telerik.WinControls.UI.RadForm
    {
        private static frmRptEntradaArticulos m_FormDefInstance;
        public static frmRptEntradaArticulos DefInstance
        {
            get
            {

                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmRptEntradaArticulos();
                return m_FormDefInstance;
            }
            set { m_FormDefInstance = value; }
        }
        public frmRptEntradaArticulos()
        {
            InitializeComponent();
        }
        string filtroSQL = "";
        string DescFiltro = "";
        private void btnFilter_Click(object sender, EventArgs e)
        {
            //Filtrar
            Forms.frmFiltro mi_frmFiltroVentas = new frmFiltro("FILTRO_ENTRADAS");
            mi_frmFiltroVentas.StartPosition = FormStartPosition.CenterScreen;
            mi_frmFiltroVentas.ShowDialog();
            ReadData();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnPrintList_Click(object sender, EventArgs e)
        {
            //Imprimir
            lvListaVentas.Title = "ENTRADA POR ARTICULO " + DescFiltro;
            lvListaVentas.FitToPage = true;
            lvListaVentas.PrintPreview();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Encabezados()
        {
            lvListaVentas.View = View.Details;
            lvListaVentas.Columns.Add("N°", 75, HorizontalAlignment.Left);
            lvListaVentas.Columns.Add("Item", 75, HorizontalAlignment.Left);
            lvListaVentas.Columns.Add("Description", 200, HorizontalAlignment.Left);
            lvListaVentas.Columns.Add("Cantidad", 100, HorizontalAlignment.Right);
            lvListaVentas.Columns.Add("Precio", 100, HorizontalAlignment.Right);
            lvListaVentas.Columns.Add("Total", 100, HorizontalAlignment.Right);

        }
        private void FiltroSQL()
        {
            try
            {
                System.DateTime varFECHA_ACTUAL = System.DateTime.Now;
                bool varFILTRO = Convert.ToBoolean(AppSettings.GetValue("FILTRO_ENTRADAS", "FILTRO", Convert.ToString(false)));
                bool varFILTRO_HOY = Convert.ToBoolean(AppSettings.GetValue("FILTRO_ENTRADAS", "HOY", Convert.ToString(false)));
                System.DateTime varFECHA_INI = Convert.ToDateTime(AppSettings.GetValue("FILTRO_ENTRADAS", "FECHA_INI", Convert.ToString(varFECHA_ACTUAL)));
                System.DateTime varFECHA_FIN = Convert.ToDateTime(AppSettings.GetValue("FILTRO_ENTRADAS", "FECHA_FIN", Convert.ToString(varFECHA_ACTUAL)));

                if (varFILTRO)
                {
                    //Se supone que hay un filtro, hay que chacer si es para hoy o por un rango de fechas
                    if (varFILTRO_HOY)
                    {
                        //el filtro es para mostrar solo lo de hoy

                        filtroSQL = "SELECT ENTRADA_DETALLE.ID_PRODUCTO, CAT_PRODUCTO.DESC_PRODUCTO, CANTIDAD,ENTRADA_DETALLE.PRECIO_COMPRA,CANTIDAD*ENTRADA_DETALLE.PRECIO_COMPRA AS TOTAL" +
                            " FROM ENTRADA INNER JOIN (CAT_PRODUCTO INNER JOIN ENTRADA_DETALLE ON CAT_PRODUCTO.ID_PRODUCTO = ENTRADA_DETALLE.ID_PRODUCTO) ON ENTRADA.FOLIO_ENTRADA = ENTRADA_DETALLE.FOLIO_ENTRADA " +
                            " WHERE ENTRADA.FECHA_REGISTRO BETWEEN #" + ISODates.MSAccessDateINI(DateTime.Now) + "# AND #" + ISODates.MSAccessDateFIN(DateTime.Now) + "#" +
                            " ";
                        //filtroSQL = filtroSQL = " EXECUTE sp_LISTA_VENTA '" + Class.clsDates.fnConvertToAccessDate(DateTime.Now) + "' ,'" + Class.clsDates.fnConvertToAccessDate(DateTime.Now) + "'";
                        DescFiltro = "SOLO DE " + System.DateTime.Now.ToLongDateString();
                    }
                    else
                    {
                        //el filtro es por un rango de fechas

                        DescFiltro = String.Format("ENTRADAS ENTRE  {0} y  {1}", varFECHA_INI.Date.ToLongDateString(), varFECHA_FIN.Date.ToLongDateString());
                        filtroSQL = "SELECT ENTRADA_DETALLE.ID_PRODUCTO, CAT_PRODUCTO.DESC_PRODUCTO, CANTIDAD,ENTRADA_DETALLE.PRECIO_COMPRA,CANTIDAD*ENTRADA_DETALLE.PRECIO_COMPRA AS TOTAL " +
                            " FROM ENTRADA INNER JOIN (CAT_PRODUCTO INNER JOIN ENTRADA_DETALLE ON CAT_PRODUCTO.ID_PRODUCTO = ENTRADA_DETALLE.ID_PRODUCTO) ON ENTRADA.FOLIO_ENTRADA = ENTRADA_DETALLE.FOLIO_ENTRADA " +
                            " WHERE ENTRADA.FECHA_REGISTRO BETWEEN #" + ISODates.MSAccessDateINI(varFECHA_INI) + "# AND #" + ISODates.MSAccessDateFIN(varFECHA_FIN) + "#" +
                            " ";
                        //filtroSQL = " EXECUTE sp_LISTA_VENTA '" + Class.clsDates.fnConvertToAccessDate(varFECHA_INI) + "' ,'" + Class.clsDates.fnConvertToAccessDate(varFECHA_FIN) + "'";
                    }
                }
                else
                {
                    //no se aplica filtro de nigun tipo

                    DescFiltro = "(TODO)";
                    //filtroSQL = filtroSQL = " EXECUTE sp_LISTA_VENTA '19000101' ,'" + Class.clsDates.fnConvertToAccessDate(DateTime.Now) + "'";
                    filtroSQL = "SELECT ENTRADA_DETALLE.ID_PRODUCTO, CAT_PRODUCTO.DESC_PRODUCTO, CANTIDAD,ENTRADA_DETALLE.PRECIO_COMPRA,CANTIDAD*ENTRADA_DETALLE.PRECIO_COMPRA AS TOTAL " +
                              " FROM ENTRADA INNER JOIN (CAT_PRODUCTO INNER JOIN ENTRADA_DETALLE ON CAT_PRODUCTO.ID_PRODUCTO = ENTRADA_DETALLE.ID_PRODUCTO) ON ENTRADA.FOLIO_ENTRADA = ENTRADA_DETALLE.FOLIO_ENTRADA " +
                              " " +
                              "";
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
                lvListaVentas.Items.Clear();
                while (drReadData.Read())
                {
                    lvListaVentas.Items.Add(Convert.ToString(I + 1));
                    lvListaVentas.Items[I].SubItems.Add(drReadData["ID_PRODUCTO"].ToString());
                    lvListaVentas.Items[I].SubItems.Add(drReadData["DESC_PRODUCTO"].ToString());
                    lvListaVentas.Items[I].SubItems.Add(String.Format("{0:N}", drReadData["CANTIDAD"]));
                    lvListaVentas.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["PRECIO_COMPRA"]));
                    lvListaVentas.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["TOTAL"]));
                    varTOTAL += Convert.ToDouble(drReadData["TOTAL"]);
                    I += 1;
                }
                lblInfo.Text = String.Format("Se encontraron {0} registro(s)", I);
                //this.Text = "Register Numbers: " + I.ToString() + ", Filter: " + DescFiltro;
                //Agregamos un registro más
                if (I > 1) {
                    lvListaVentas.Items.Add("");
                    lvListaVentas.Items[I].SubItems.Add("");
                    lvListaVentas.Items[I].SubItems.Add("");
                    lvListaVentas.Items[I].SubItems.Add("");
                    lvListaVentas.Items[I].SubItems.Add("TOTAL");
                    lvListaVentas.Items[I].SubItems.Add(String.Format("{0:C}", varTOTAL));
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
       

        private void frmRptEntradaArticulos_Load(object sender, EventArgs e)
        {
            Encabezados();
            ReadData();
        }
    }
}