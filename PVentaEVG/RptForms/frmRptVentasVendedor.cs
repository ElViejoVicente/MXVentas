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
    public partial class frmRptVentasVendedor : Telerik.WinControls.UI.RadForm
    {
        private static frmRptVentasVendedor m_FormDefInstance;
        public static frmRptVentasVendedor DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmRptVentasVendedor();
                return m_FormDefInstance;
            }
            set { m_FormDefInstance = value; }
        }
        public frmRptVentasVendedor()
        {
            InitializeComponent();
        }
     
        Class.clsVentas _clsVentas = new Class.clsVentas();
        private void frmRptVentasVendedor_Load(object sender, EventArgs e)
        {
            Encabezados();
            ReadData();
        }
        string filtroSQL = "";
        string DescFiltro = "";        
        private void Encabezados()
        {
            lvListaVentas.View = View.Details;
            lvListaVentas.Columns.Add("N°", 90, HorizontalAlignment.Left);
            lvListaVentas.Columns.Add("Nombre", 175, HorizontalAlignment.Left);
            lvListaVentas.Columns.Add("Login", 75, HorizontalAlignment.Left);
            lvListaVentas.Columns.Add("Total", 150, HorizontalAlignment.Right);
            lvListaVentas.Columns.Add("Descuentos", 150, HorizontalAlignment.Right);

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
                        filtroSQL ="SELECT ltrim(rtrim(users.nombre))+' '+ltrim(rtrim(users.paterno))+' '+ltrim(rtrim(users.materno)) AS NOMBRE,"+
                            " sum(VENTA_DETALLE.cantidad*VENTA_DETALLE.precio_venta) AS TOTAL, sum(VENTA_DETALLE.descuento) as DESCUENTOS,"+
                            " venta.USER_LOGIN " +
                            " FROM VENTA_DETALLE, venta, users " +
                            " WHERE VENTA_DETALLE.folio=venta.folio "+ 
                            " And venta.user_login=users.user_login " +
                            " And VENTA.FECHA BETWEEN #"+ ISODates.MSAccessDateINI(DateTime.Now) +"# And #"+  ISODates.MSAccessDateFIN(DateTime.Now) +"# "+
                            " GROUP BY users.nombre, users.paterno, users.materno, venta.USER_LOGIN;";
                            //" EXECUTE spVENTAS_VENDEDOR '" + Class.clsDates.fnConvertToAccessDate(DateTime.Now) + "' ,'" + Class.clsDates.fnConvertToAccessDate(DateTime.Now) + "'";
                        DescFiltro = "Información de " + System.DateTime.Now.ToLongDateString();
                    }
                    else
                    {
                        //el filtro es por un rango de fechas
                        DescFiltro = String.Format("Información de ventas entre {0} y  {1}", varFECHA_INI.Date.ToLongDateString(), varFECHA_FIN.Date.ToLongDateString());
                        filtroSQL = "SELECT ltrim(rtrim(users.nombre))+' '+ltrim(rtrim(users.paterno))+' '+ltrim(rtrim(users.materno)) AS NOMBRE,"+
                            " sum(VENTA_DETALLE.cantidad*VENTA_DETALLE.precio_venta) AS TOTAL,sum(VENTA_DETALLE.descuento) as DESCUENTOS,"+
                            " venta.USER_LOGIN " +
                            " FROM VENTA_DETALLE, venta, users " +
                            " WHERE VENTA_DETALLE.folio=venta.folio " +
                            " And venta.user_login=users.user_login " +
                            " And VENTA.FECHA BETWEEN #" + ISODates.MSAccessDateINI(varFECHA_INI) + "# And  #" + ISODates.MSAccessDateFIN(varFECHA_FIN) + "# " +
                            " GROUP BY users.nombre, users.paterno, users.materno, venta.USER_LOGIN;";
                    }
                }
                else
                {
                    //no se aplica filtro de nigun tipo
                    DescFiltro = "(Toda la información)";
                    filtroSQL = "SELECT ltrim(rtrim(users.nombre))+' '+ltrim(rtrim(users.paterno))+' '+ltrim(rtrim(users.materno)) AS NOMBRE,"+
                        " sum(VENTA_DETALLE.cantidad*VENTA_DETALLE.precio_venta) AS TOTAL,"+
                        " venta.USER_LOGIN,sum(VENTA_DETALLE.DESCUENTO)AS DESCUENTOS " +
                            " FROM VENTA_DETALLE, venta, users " +
                            " WHERE VENTA_DETALLE.folio=venta.folio " +
                            " And venta.user_login=users.user_login " +
                            " " +
                            " GROUP BY users.nombre, users.paterno, users.materno, venta.USER_LOGIN;";
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
                double varDESCUENTOS = 0;
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
                    lvListaVentas.Items[I].SubItems.Add(drReadData["NOMBRE"].ToString());
                    lvListaVentas.Items[I].SubItems.Add(drReadData["USER_LOGIN"].ToString()); 
                    lvListaVentas.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["TOTAL"]));
                    lvListaVentas.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["DESCUENTOS"]));
                    varTOTAL += Convert.ToDouble(drReadData["TOTAL"]);
                    varDESCUENTOS += Convert.ToDouble(drReadData["DESCUENTOS"]);
                    I += 1;
                }
                lblInfo.Text = String.Format("Se encontraron {0} registro(s)", I);
                //this.Text = "Cantidad de registros: " + I.ToString() + ", Filtro: " + DescFiltro;
                //Agregamos un registro más
                if (I != 0)
                {
                    lvListaVentas.Items.Add("");
                    lvListaVentas.Items[I].SubItems.Add("");
                    lvListaVentas.Items[I].SubItems.Add("Total:");
                    lvListaVentas.Items[I].SubItems.Add(String.Format("{0:C}", varTOTAL));
                    lvListaVentas.Items[I].SubItems.Add(String.Format("{0:C}", varDESCUENTOS));
                    lvListaVentas.Items.Add("");
                    lvListaVentas.Items[I + 1].SubItems.Add("");
                    lvListaVentas.Items[I + 1].SubItems.Add("");
                    lvListaVentas.Items[I + 1].SubItems.Add("Grand Total:");
                    lvListaVentas.Items[I + 1].SubItems.Add(String.Format("{0:C}",varTOTAL- varDESCUENTOS));
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
            Forms.frmFiltro mi_frmFiltroVentas = new frmFiltro("FILTRO_VENTAS");
            mi_frmFiltroVentas.StartPosition = FormStartPosition.CenterScreen;
            mi_frmFiltroVentas.ShowDialog();
            ReadData();
        }       
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        
        private void PrintSelected()
        {
            int varFOLIO;
            try
            {
                if (lvListaVentas.Items.Count != 0)
                {
                    varFOLIO = Convert.ToInt32(lvListaVentas.SelectedItems[0].Text);                    
                    _clsVentas.ImprimeTicket(varFOLIO,false);                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("You must select an element from the list. \nError Description: \n" + ex.Message, "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
       
        private void mnuPrintSelected_Click(object sender, EventArgs e)
        {
            PrintSelected();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ReadData();
        }

        private void btnPrintList_Click(object sender, EventArgs e)
        {
            //Imprimir
            lvListaVentas.Title = "Ventas por Empleado" + DescFiltro;
            lvListaVentas.FitToPage = true;
            lvListaVentas.PrintPreview();
        }

        private void btnPrintSelected_Click(object sender, EventArgs e)
        {

        }

       
        
    }
}