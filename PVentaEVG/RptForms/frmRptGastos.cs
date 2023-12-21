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
    public partial class frmRptGastos : Telerik.WinControls.UI.RadForm
    {
        private static frmRptGastos m_FormDefInstance;
        public static frmRptGastos DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmRptGastos();
                return m_FormDefInstance;
            }
            set { m_FormDefInstance = value; }
        }
        public frmRptGastos()
        {
            InitializeComponent();
        }

        private void frmRptGastos_Load(object sender, EventArgs e)
        {
            txtFECHA_INI.Value = DateTime.Now;
            txtFECHA_FIN.Value = DateTime.Now;
            ReadData(ISODates.MSAccessDateINI(txtFECHA_INI.Value), ISODates.MSAccessDateFIN(txtFECHA_FIN.Value),chkAgrupar.Checked);
        }
        void Encabezados(bool prmAgrupar) {
            lvRpt.Clear();
            lvRpt.Items.Clear();
            lvRpt.View = View.Details;
            if (prmAgrupar) {
                //agrupar
                lvRpt.Columns.Add("Tipo de Gasto",300, HorizontalAlignment.Left);
                lvRpt.Columns.Add("Total",100, HorizontalAlignment.Right);
            }
            else {
                lvRpt.Columns.Add("Folio gasto", 80, HorizontalAlignment.Left);
                lvRpt.Columns.Add("Fecha", 70, HorizontalAlignment.Left);
                lvRpt.Columns.Add("Tipo gasto", 200, HorizontalAlignment.Left);
                lvRpt.Columns.Add("Total", 100, HorizontalAlignment.Right);
            }
        }
        private void ReadData(string prmFECHA_INI, string prmFECHA_FIN, bool prmAgrupar)
        {
            //Este procedimiento lee los datos que se tranferirán y los mostrará en forma de
            //lista en el ListView
            
            try
            {
                Encabezados(prmAgrupar);//mostramoslacuadricula
                string varSQL = "";
                if (prmAgrupar) {
                    varSQL = "SELECT CAT_TIPO_GASTO.DESC_TIPO_GASTO, SUM(GASTO.IMPORTE) AS IMPORTE FROM CAT_TIPO_GASTO INNER JOIN GASTO ON CAT_TIPO_GASTO.ID_TIPO_GASTO = GASTO.ID_TIPO_GASTO WHERE FECHA_GASTO BETWEEN #"+ prmFECHA_INI +"# AND #"+ prmFECHA_FIN +"# GROUP BY CAT_TIPO_GASTO.DESC_TIPO_GASTO;";
                }
                else {
                    varSQL = "SELECT GASTO.FOLIO_GASTO, GASTO.FECHA_GASTO, GASTO.IMPORTE, CAT_TIPO_GASTO.DESC_TIPO_GASTO FROM CAT_TIPO_GASTO INNER JOIN GASTO ON CAT_TIPO_GASTO.ID_TIPO_GASTO = GASTO.ID_TIPO_GASTO WHERE FECHA_GASTO BETWEEN #" + prmFECHA_INI + "# AND #" + prmFECHA_FIN + "#;";
                }
                double varTOTAL = 0;
                //Si la conexion esta abierta la cerramos; en caso contrario, la abrimos
                OleDbConnection cnnReadData = new OleDbConnection(Class.clsMain.CnnStr);
                if (cnnReadData.State == ConnectionState.Open) cnnReadData.Close(); else cnnReadData.Open();
                int I = 0;
                OleDbCommand cmdReadData = new OleDbCommand(varSQL, cnnReadData);
                OleDbDataReader drReadData;
                drReadData = cmdReadData.ExecuteReader();
                lvRpt.Items.Clear();
                while (drReadData.Read())
                {
                    if (prmAgrupar) {
                        lvRpt.Items.Add(drReadData["DESC_TIPO_GASTO"].ToString());
                        lvRpt.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["IMPORTE"]));
                    }
                    else {
                        lvRpt.Items.Add(drReadData["FOLIO_GASTO"].ToString());
                        lvRpt.Items[I].SubItems.Add(String.Format("{0:d}",drReadData["FECHA_GASTO"]));
                        lvRpt.Items[I].SubItems.Add(drReadData["DESC_TIPO_GASTO"].ToString());
                        lvRpt.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["IMPORTE"]));
                    }
                    
                    
                    varTOTAL += Convert.ToDouble(drReadData["IMPORTE"]);
                    I += 1;
                }
                lblInfo.Text = String.Format("Se encontraron {0} registro(s)", I);
                //Agregamos un registro más
                if (I != 0)
                {
                    if (prmAgrupar) {
                        lvRpt.Items.Add("Total:");
                        lvRpt.Items[I].SubItems.Add(String.Format("{0:C}", varTOTAL));
                    }
                    else {
                        lvRpt.Items.Add("");
                        lvRpt.Items[I].SubItems.Add("");
                        lvRpt.Items[I].SubItems.Add("Total:");
                        
                        lvRpt.Items[I].SubItems.Add(String.Format("{0:C}", varTOTAL));
                    }
                    
                    
                   
                    
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ReadData(ISODates.MSAccessDateINI(txtFECHA_INI.Value), ISODates.MSAccessDateFIN(txtFECHA_FIN.Value),chkAgrupar.Checked);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            POSDLL.Utilities.ExportListView exportar = new POSDLL.Utilities.ExportListView();
            exportar.ExportToExcel(lvRpt, "ReporteDeGastos");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            lvRpt.Title = String.Format("Reporte de Gastos entre las fechas: {0} y {1}", 
                txtFECHA_INI.Value.ToShortDateString(), txtFECHA_FIN.Value.ToShortDateString());
            lvRpt.FitToPage = true;
            lvRpt.PrintPreview();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
