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
    public partial class frmRptSueldos : Telerik.WinControls.UI.RadForm
    {
        private static frmRptSueldos m_FormDefInstance;
        public static frmRptSueldos DefInstance
        {
            get
            {

                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmRptSueldos();
                return m_FormDefInstance;
            }
            set { m_FormDefInstance = value; }
        }
        public frmRptSueldos()
        {
            InitializeComponent();
        }

        private void frmRptSueldos_Load(object sender, EventArgs e)
        {
            Encabezados();
         
            ReadData(ISODates.MSAccessDateINI(txtFECHA_INI.Value), ISODates.MSAccessDateFIN(txtFECHA_FIN.Value));
      
        }
        private void Encabezados()
        {
            lvRpt.View = View.Details;
            lvRpt.Columns.Add("Clave Empleado", 90, HorizontalAlignment.Left);
            lvRpt.Columns.Add("Nombre", 250, HorizontalAlignment.Left);
            lvRpt.Columns.Add("Sueldo", 80, HorizontalAlignment.Right);
            lvRpt.Columns.Add("Préstamos", 80, HorizontalAlignment.Right);
            lvRpt.Columns.Add("Total", 80, HorizontalAlignment.Right);
        }
      
        private void ReadData(string prmFECHA_INI, string prmFECHA_FIN)
        {
            
            try
            {
                
                double varTOTAL = 0;
                double varTOTAL_PRESTAMOS = 0;
                double varTOTAL_SALARIO = 0;
                //Si la conexion esta abierta la cerramos; en caso contrario, la abrimos
                OleDbConnection cnnReadData = new OleDbConnection(Class.clsMain.CnnStr);
                cnnReadData.Open();
                int I = 0;
                /*
                 UPDATE (GASTO INNER JOIN CAT_TIPO_GASTO ON GASTO.ID_TIPO_GASTO = CAT_TIPO_GASTO.ID_TIPO_GASTO) 
                 INNER JOIN RPT_SUELDOS ON CAT_TIPO_GASTO.ID_EMPLEADO = RPT_SUELDOS.ID_EMPLEADO SET RPT_SUELDOS.PRESTAMOS = [GASTO].[IMPORTE];
                 */
                OleDbCommand cmdReadData = new OleDbCommand();
                cmdReadData.Connection = cnnReadData;
                cmdReadData.CommandText = "DELETE FROM RPT_SUELDOS";
                cmdReadData.ExecuteNonQuery();
                cmdReadData.CommandText = "INSERT INTO RPT_SUELDOS(ID_EMPLEADO,NOMBRE,SALARIO,PRESTAMOS,TOTAL)" +
                    "SELECT ID_EMPLEADO, TRIM(NOMBRE)+ ' '+ TRIM(PATERNO)+ ' ' + TRIM(MATERNO),SALARIO,0,0 FROM CAT_EMPLEADO;";
                cmdReadData.ExecuteNonQuery();
                cmdReadData.CommandText = " UPDATE (GASTO INNER JOIN CAT_TIPO_GASTO ON GASTO.ID_TIPO_GASTO = CAT_TIPO_GASTO.ID_TIPO_GASTO) "+
                " INNER JOIN RPT_SUELDOS ON CAT_TIPO_GASTO.ID_EMPLEADO = RPT_SUELDOS.ID_EMPLEADO SET RPT_SUELDOS.PRESTAMOS = RPT_SUELDOS.PRESTAMOS+[GASTO].[IMPORTE] " +
                " WHERE GASTO.FECHA_GASTO BETWEEN #"+ prmFECHA_INI +"# AND #"+ prmFECHA_FIN +"#";
                cmdReadData.ExecuteNonQuery();

                OleDbDataReader drReadData;

                cmdReadData.CommandText = "SELECT * FROM RPT_SUELDOS";
                drReadData = cmdReadData.ExecuteReader();

                lvRpt.Items.Clear();
                while (drReadData.Read())
                {
                    lvRpt.Items.Add(drReadData["ID_EMPLEADO"].ToString());
                    lvRpt.Items[I].SubItems.Add(drReadData["NOMBRE"].ToString());
                    lvRpt.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["SALARIO"]));
                    lvRpt.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["PRESTAMOS"]));
                    lvRpt.Items[I].SubItems.Add(String.Format("{0:C}", Convert.ToDouble(drReadData["SALARIO"]) - Convert.ToDouble(drReadData["PRESTAMOS"])));
                    if (drReadData["TOTAL"] != DBNull.Value)
                    {
                        varTOTAL += Convert.ToDouble(drReadData["TOTAL"]);
                    }
                    if (drReadData["SALARIO"] != DBNull.Value)
                    {
                        varTOTAL_SALARIO += Convert.ToDouble(drReadData["SALARIO"]);
                    }
                    if (drReadData["PRESTAMOS"] != DBNull.Value)
                    {
                        varTOTAL_PRESTAMOS += Convert.ToDouble(drReadData["PRESTAMOS"]);
                    }

                    I += 1;
                }
                lblInfo.Text = String.Format("Se encontraron {0} registro(s)", I);
                if (I != 0)
                {
                    lvRpt.Items.Add("");
                    lvRpt.Items[I].SubItems.Add("Total:");
                    lvRpt.Items[I].SubItems.Add(String.Format("{0:C}", varTOTAL_SALARIO));
                    lvRpt.Items[I].SubItems.Add(String.Format("{0:C}", varTOTAL_PRESTAMOS));
                    lvRpt.Items[I].SubItems.Add(String.Format("{0:C}", varTOTAL_SALARIO - varTOTAL_PRESTAMOS));
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

       
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ReadData(ISODates.MSAccessDateINI(txtFECHA_INI.Value), ISODates.MSAccessDateFIN(txtFECHA_FIN.Value));
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (lvRpt.Items.Count != 0) {
                POSDLL.Utilities.ExportListView exportar = new POSDLL.Utilities.ExportListView();
                exportar.ExportToExcel(lvRpt, "ReporteDeSueldos");
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (lvRpt.Items.Count != 0)
            {
                lvRpt.Title = "Reporte de Sueldos";
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
