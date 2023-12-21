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
    public partial class frmFacturasLista : Telerik.WinControls.UI.RadForm
    {
        //controlamos q solo se abra una vez
        private static frmFacturasLista m_FormDefInstance;
        public static frmFacturasLista DefInstance
        {
            get
            {
                //if(m_FormDefInstance==null && m_FormDefInstance.IsDisposed)
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmFacturasLista();
                return m_FormDefInstance;
            }
            set { m_FormDefInstance = value; }
        }
        public frmFacturasLista()
        {
            InitializeComponent();
        }
        
        
        string filtroSQL = "";
        string DescFiltro = "";
        string varSQL = "";
        private void frmListaFacturas_Load(object sender, EventArgs e)
        {
            lvFactura.DoubleClick += new EventHandler(lvFactura_DoubleClick);
            Encabezados();
            ReadData();
        }

        void lvFactura_DoubleClick(object sender, EventArgs e)
        {
            PrintSelected();
        }
        private void Encabezados()
        {
            lvFactura.View = View.Details;
            lvFactura.Columns.Add("Folio factura", 100, HorizontalAlignment.Left);
            lvFactura.Columns.Add("Ticket", 70, HorizontalAlignment.Left);

            lvFactura.Columns.Add("Fecha Factura", 100, HorizontalAlignment.Left);
            lvFactura.Columns.Add("Cliente", 200, HorizontalAlignment.Left);
            lvFactura.Columns.Add("Importe", 120, HorizontalAlignment.Right);

        }
        private void FiltroSQL()
        {
            try
            {
                System.DateTime varFECHA_ACTUAL = System.DateTime.Now;
                bool varFILTRO = Convert.ToBoolean(AppSettings.GetValue("FILTRO_FACTURAS", "FILTRO", Convert.ToString(false)));
                bool varFILTRO_HOY = Convert.ToBoolean(AppSettings.GetValue("FILTRO_FACTURAS", "HOY", Convert.ToString(false)));
                System.DateTime varFECHA_INI = Convert.ToDateTime(AppSettings.GetValue("FILTRO_FACTURAS", "FECHA_INI", Convert.ToString(varFECHA_ACTUAL)));
                System.DateTime varFECHA_FIN = Convert.ToDateTime(AppSettings.GetValue("FILTRO_FACTURAS", "FECHA_FIN", Convert.ToString(varFECHA_ACTUAL)));
                if (varFILTRO)
                {
                    //Se supone que hay un filtro, hay que checar si es para hoy o por un rango de fechas
                    if (varFILTRO_HOY)
                    {
                        //el filtro es para mostrar solo lo de hoy
                        filtroSQL = " AND FECHA_FACTURA BETWEEN #" +
                            ISODates.MSAccessDateINI(DateTime.Now) + "# AND #" + ISODates.MSAccessDateFIN(DateTime.Now) + "# ";
                        DescFiltro = "Información de hoy";
                    }
                    else
                    {
                        //el filtro es por un rango de fechas
                        DescFiltro = String.Format("Iformación entre las fechas {0} y  {1}", varFECHA_INI.Date.ToLongDateString(), varFECHA_FIN.Date.ToLongDateString());
                        filtroSQL = " AND FECHA_FACTURA BETWEEN #" + ISODates.MSAccessDateINI(varFECHA_INI) + "# and   #" + ISODates.MSAccessDateFIN(varFECHA_FIN) + "#";
                    }
                }
                else
                {
                    //no se aplica filtro de nigun tipo
                    DescFiltro = "Sin filtro";
                    filtroSQL = "";
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
                 varSQL = "SELECT FOLIO_VENTA, FOLIO_FACTURA,FECHA_FACTURA,CLIENTE,TOTAL,CANCELAR FROM vFACTURA_VENTA WHERE FOLIO_FACTURA <> '' ";


                //Si la conexion esta abierta la cerramos; en caso contrario, la abrimos
                OleDbConnection cnnReadData = new OleDbConnection(Class.clsMain.CnnStr);
                if (cnnReadData.State == ConnectionState.Open) cnnReadData.Close(); else cnnReadData.Open();
                int I = 0;
                OleDbCommand cmdReadData = new OleDbCommand(varSQL + filtroSQL, cnnReadData);
                OleDbDataReader drReadData;
                drReadData = cmdReadData.ExecuteReader();
                lvFactura.Items.Clear();
                while (drReadData.Read())
                {
                    lvFactura.Items.Add(drReadData["FOLIO_FACTURA"].ToString());
                    lvFactura.Items[I].SubItems.Add(drReadData["FOLIO_VENTA"].ToString());
                    
                    lvFactura.Items[I].SubItems.Add(Convert.ToDateTime(drReadData["FECHA_FACTURA"]).ToShortDateString());
                    lvFactura.Items[I].SubItems.Add(drReadData["CLIENTE"].ToString());
                    lvFactura.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["TOTAL"]));
                    if (Convert.ToBoolean(drReadData["CANCELAR"]))
                    {
                        lvFactura.Items[I].ForeColor = Color.Gray;
                        lvFactura.Items[I].ToolTipText = "CANCELADA";
                    }
                    I += 1;
                }
                this.Text = "Cantidad de Facturas: " + I.ToString() + ", Filtro: " + DescFiltro;
                drReadData.Close();
                cmdReadData.Dispose();
                cnnReadData.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Factura()
        {
            //Código
            int varFOLIO;
            try
            {
                if (lvFactura.SelectedItems.Count != 0)
                {
                    varFOLIO = Convert.ToInt32(lvFactura.SelectedItems[0].Text);
                    Forms.frmFactura myForm = new Forms.frmFactura(varFOLIO);
                    myForm.StartPosition = FormStartPosition.CenterScreen;
                    myForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("You must select an element from the list. \nError Description: \n" + 
                    ex.Message, "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        void NuevaFactura()
        {
            frmFactura _frmFactura = new frmFactura();
            _frmFactura.StartPosition = FormStartPosition.CenterScreen;
            _frmFactura.ShowDialog();
            if (frmFactura._Accion)
            {
                ReadData();
            }
        }
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            NuevaFactura();
        }
       

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ReadData();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            //Filtrar
            Forms.frmFiltro mi_frmFiltroEntrada = new frmFiltro("FILTRO_FACTURAS");
            mi_frmFiltroEntrada.StartPosition = FormStartPosition.CenterScreen;
            mi_frmFiltroEntrada.ShowDialog();
            ReadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrintList_Click(object sender, EventArgs e)
        {
            lvFactura.Title = "Lista de facturas";
            lvFactura.FitToPage = true;
            lvFactura.PrintPreview();
        }

        private void btnPrintSelected_Click(object sender, EventArgs e)
        {
            PrintSelected();
        }
        private void PrintSelected()
        {
            string varFOLIO_FACTURA;
            try
            {
                if (lvFactura.Items.Count != 0)
                {
                    varFOLIO_FACTURA = lvFactura.SelectedItems[0].Text;
                    Class.clsVentas.ImprimeFacturaVenta(varFOLIO_FACTURA);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("You must select an element from the list. \nError Description: \n" + ex.Message, "Invalid Operation" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void mnuPrintSelected_Click(object sender, EventArgs e)
        {
            PrintSelected();
        }

        private void mnuPrintList_Click(object sender, EventArgs e)
        {
            lvFactura.Title = "Lista de facturas";
            lvFactura.FitToPage = true;
            lvFactura.PrintPreview();
        }

        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            ReadData();
        }

        private void mnuAddNew_Click(object sender, EventArgs e)
        {
            NuevaFactura();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            POSDLL.Utilities.ExportListView exportar = new POSDLL.Utilities.ExportListView();
            exportar.ExportToExcel(lvFactura, "ListaDeFacturas");
        }

        private void c_mnuCancelarFactura_Click(object sender, EventArgs e)
        {
            string varFOLIO_FACTURA;
            try
            {
                if (lvFactura.SelectedItems.Count != 0)
                {
                    DialogResult resp =
                        MessageBox.Show("¿Realmente desea cancelar la factura seleccionada?",
                        "Cancelar Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resp == DialogResult.Yes)
                    {
                        varFOLIO_FACTURA = lvFactura.SelectedItems[0].Text;
                        if (fnCancelaFactura(varFOLIO_FACTURA))
                        {
                            MessageBox.Show("La factura ha sido cancelada",
                            "Cancelar Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("You must select an element from the list. \nError Description: \n" + ex.Message, "Invalid Operation" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        bool fnCancelaFactura(string prmFOLIO_FACTURA)
        {
            try
            {
                OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
                cnn.Open();
                OleDbTransaction tran = cnn.BeginTransaction();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;
                cmd.Transaction = tran;
                //comensamos proceso
                try
                {
                    cmd.CommandText = "UPDATE FACTURA_VENTA SET CANCELAR=1 WHERE FOLIO_FACTURA='" + prmFOLIO_FACTURA + "'";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "UPDATE FACTURA_CONTROL SET CANCELAR=1 WHERE FOLIO_FACTURA='" + prmFOLIO_FACTURA + "'";
                    cmd.ExecuteNonQuery();
                }
                catch (OleDbException e)
                {
                    MessageBox.Show("Error en la transacción\n" + e.Message,
                        "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tran.Rollback();
                    cnn.Close();
                    cnn.Dispose();
                    cmd.Dispose();
                    return (false);
                }
                //finalizamos
                tran.Commit();
                cnn.Close();
                cnn.Dispose();
                cmd.Dispose();
                return (true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cancelar la factura\n" + ex.Message,
                    "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false);
            }
        }
      
    }
}