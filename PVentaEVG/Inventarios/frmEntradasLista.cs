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
    public partial class frmEntradasLista : Telerik.WinControls.UI.RadForm
    {
        public frmEntradasLista()
        {
            InitializeComponent();
        }
        
        
        string filtroSQL = "";
        string DescFiltro = "";
        private void frmListaEntradas_Load(object sender, EventArgs e)
        {
            Inicializa();
            Encabezados();
            ReadData(cboCOLMUNAS.SelectedValue.ToString(),fnGetAscOrder(cboORDER.Text));

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
        private void Inicializa()
        {
            try
            {
                DataSet dsInicializa = new DataSet();
                OleDbConnection cnnInicializa = new OleDbConnection(Class.clsMain.CnnStr);
                cnnInicializa.Open();
                //MARCA
                OleDbDataAdapter daCol = new OleDbDataAdapter("SELECT * FROM COLUMNAS WHERE CLASIFICACION='ENTRADAS'", cnnInicializa);
                dsInicializa.Clear();
                daCol.Fill(dsInicializa, "COLUMNAS");
                cboCOLMUNAS.DataSource = dsInicializa.Tables["COLUMNAS"];
                cboCOLMUNAS.DisplayMember = "DESC_COLUMNA";
                cboCOLMUNAS.ValueMember = "COLUMNA";
                daCol.Dispose();


                cnnInicializa.Close();
                cnnInicializa.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Encabezados()
        {
            lvEntrada.View = View.Details;
            lvEntrada.Columns.Add("Folio", 90, HorizontalAlignment.Left);
            lvEntrada.Columns.Add("Proveedor", 280, HorizontalAlignment.Left);
            lvEntrada.Columns.Add("Factura", 85, HorizontalAlignment.Left);
            lvEntrada.Columns.Add("Fecha Factura", 150, HorizontalAlignment.Left);
            //lvEntrada.Columns.Add("Amount", 100, HorizontalAlignment.Left);
            lvEntrada.Columns.Add("Observaciones", 250, HorizontalAlignment.Left);

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
                    //Se supone que hay un filtro, hay que checar si es para hoy o por un rango de fechas
                    if (varFILTRO_HOY)
                    {
                        //el filtro es para mostrar solo lo de hoy
                        filtroSQL = " AND FECHA_FACTURA between #" + ISODates.MSAccessDateINI(DateTime.Now) + "#  and #" + ISODates.MSAccessDateFIN(DateTime.Now) + "#";
                        DescFiltro = "Información de hoy";
                    }
                    else
                    {
                        //el filtro es por un rango de fechas
                        DescFiltro = String.Format("Información entre las fechas  {0} y  {1}", varFECHA_INI.Date.ToLongDateString(), varFECHA_FIN.Date.ToLongDateString());
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
        private void ReadData(string prmCAMPO, string prmORDEN)
        {
            //Este procedimiento lee los datos que se tranferirán y los mostrará en forma de
            //lista en el ListView
            FiltroSQL();
            try
            {
                string varSQL = "SELECT FOLIO_ENTRADA,DESC_PROVEEDOR,FOLIO_FACTURA,FECHA_FACTURA,OBSERVACIONES  " +
                    " FROM vENTRADA WHERE FOLIO_ENTRADA IN(SELECT DISTINCT FOLIO_ENTRADA FROM ENTRADA_DETALLE) ";
                    


                //Si la conexion esta abierta la cerramos; en caso contrario, la abrimos
               OleDbConnection cnnReadData = new OleDbConnection(Class.clsMain.CnnStr);
                if (cnnReadData.State == ConnectionState.Open) cnnReadData.Close(); else cnnReadData.Open();
                int I = 0;
                OleDbCommand cmdReadData = new OleDbCommand(varSQL + filtroSQL +" ORDER BY "+ prmCAMPO +" "+ prmORDEN +"", cnnReadData);
                OleDbDataReader drReadData;
                drReadData = cmdReadData.ExecuteReader();
                lvEntrada.Items.Clear();
                while (drReadData.Read())
                {
                    lvEntrada.Items.Add(drReadData["FOLIO_ENTRADA"].ToString());
                    lvEntrada.Items[I].SubItems.Add(drReadData["DESC_PROVEEDOR"].ToString());
                    lvEntrada.Items[I].SubItems.Add(drReadData["FOLIO_FACTURA"].ToString());
                    lvEntrada.Items[I].SubItems.Add(drReadData["FECHA_FACTURA"].ToString());
                    lvEntrada.Items[I].SubItems.Add(drReadData["OBSERVACIONES"].ToString());
                    //lvEntrada.Items[I].SubItems.Add("$ " + drReadData[4].ToString());
                    //lvEntrada.Items[I].SubItems.Add(drReadData[5].ToString());
                    I += 1;
                }
                this.Text = "Entries Numbers: " + I.ToString() + ", Filter: " + DescFiltro;
                drReadData.Close();
                cmdReadData.Dispose();
                cnnReadData.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Entrada()
        {
            //Código
            int varFOLIO;
            try
            {
                if (lvEntrada.Items.Count != 0)
                {
                    varFOLIO = Convert.ToInt32(lvEntrada.SelectedItems[0].Text);
                    Forms.frmEntrada myForm = new Forms.frmEntrada(varFOLIO);
                    myForm.StartPosition = FormStartPosition.CenterScreen;
                    myForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("You must select an element from the list. \nError Description: \n" + ex.Message, "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            //nuevo
            frmEntrada myForm = new frmEntrada();
            myForm.StartPosition = FormStartPosition.CenterScreen;
            myForm.ShowDialog();
            ReadData(cboCOLMUNAS.SelectedValue.ToString(), fnGetAscOrder(cboORDER.Text));
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ReadData(cboCOLMUNAS.SelectedValue.ToString(), fnGetAscOrder(cboORDER.Text));
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            //Filtrar
            Forms.frmFiltro mi_frmFiltroEntrada = new frmFiltro("FILTRO_ENTRADAS");
            mi_frmFiltroEntrada.StartPosition = FormStartPosition.CenterScreen;
            mi_frmFiltroEntrada.ShowDialog();
            ReadData(cboCOLMUNAS.SelectedValue.ToString(), fnGetAscOrder(cboORDER.Text));
        }

        private void btnPrintList_Click(object sender, EventArgs e)
        {
            //Imprimir
            lvEntrada.Title = "Entries";
            lvEntrada.FitToPage = true;
            lvEntrada.PrintPreview();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void lvEntrada_DoubleClick(object sender, System.EventArgs e)
        {
            Entrada();
        }

        void lvEntrada_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) { Entrada(); }
        }

        private void btnPrintSelected_Click(object sender, EventArgs e)
        {

            PrintSelected();
        }
        private void PrintSelected() {
            int varFOLIO;
            try
            {
                if (lvEntrada.Items.Count != 0)
                {
                    varFOLIO = Convert.ToInt32(lvEntrada.SelectedItems[0].Text);
                    Forms.frmEntrada myForm = new Forms.frmEntrada();
                    myForm.ImprimeFacturaEntrada(varFOLIO);
                    myForm.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("You must select an element from the list. \nError Description: \n" + ex.Message, "Invalid Operation" + ex.Message,MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void mnuPrintSelected_Click(object sender, EventArgs e)
        {
            PrintSelected();
        }

        private void mnuPrintList_Click(object sender, EventArgs e)
        {
            //Imprimir
            lvEntrada.Title = "Entries";
            lvEntrada.FitToPage = true;
            lvEntrada.PrintPreview();
        }

        private void mnuConsultaFactura_Click(object sender, EventArgs e)
        {
            Entrada();
        }

        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            ReadData(cboCOLMUNAS.SelectedValue.ToString(), fnGetAscOrder(cboORDER.Text));
        }

        private void mnuAddNew_Click(object sender, EventArgs e)
        {
            //nuevo
            frmEntrada myForm = new frmEntrada();
            myForm.StartPosition = FormStartPosition.CenterScreen;
            myForm.ShowDialog();
            ReadData(cboCOLMUNAS.SelectedValue.ToString(), fnGetAscOrder(cboORDER.Text));
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            POSDLL.Utilities.ExportListView exportar = new POSDLL.Utilities.ExportListView();
            exportar.ExportToExcel(lvEntrada, "EntradasListado");
        }
        

    }
}