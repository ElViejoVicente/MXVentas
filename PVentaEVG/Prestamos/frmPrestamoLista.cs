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
    public partial class frmPrestamoLista : Telerik.WinControls.UI.RadForm
    {
        private static frmPrestamoLista m_FormDefInstance;
        public static frmPrestamoLista DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmPrestamoLista();
                return m_FormDefInstance;
            }
            set { m_FormDefInstance = value; }
        }
        public frmPrestamoLista()
        {
            InitializeComponent();
        }

        private void frmPrestamoLista_Load(object sender, EventArgs e)
        {
            Encabezados();
            ReadData(txtFechaIni.Value, txtFechaFin.Value);
        }
        private void Encabezados()
        {
            lvPrestamos.View = View.Details;
            lvPrestamos.Columns.Add("Folio", 50, HorizontalAlignment.Left);
            lvPrestamos.Columns.Add("Empleado", 250, HorizontalAlignment.Left);
            lvPrestamos.Columns.Add("Fecha", 90, HorizontalAlignment.Left);
            lvPrestamos.Columns.Add("Monto", 75, HorizontalAlignment.Right);
            lvPrestamos.Columns.Add("Pagado", 75, HorizontalAlignment.Right);
            lvPrestamos.Columns.Add("Restante", 75, HorizontalAlignment.Right);
            
        }
        void ReadData(DateTime prmDateStart, DateTime prmDateEnd)
        {
            OleDbConnection cnnReadData = new OleDbConnection(Class.clsMain.CnnStr);
            try
            {

                string varSQL = "SELECT PRESTAMO.ID_PRESTAMO, PRESTAMO.ID_EMPLEADO, PRESTAMO.IMPORTE, PRESTAMO.PAGADO, "+
                    " CAT_EMPLEADO.NOMBRE+''+CAT_EMPLEADO.PATERNO+''+CAT_EMPLEADO.MATERNO AS EMPLEADO, IMPORTE-PAGADO AS RESTO, PRESTAMO.FECHA_PRESTAMO "+
                    " FROM PRESTAMO INNER JOIN CAT_EMPLEADO ON PRESTAMO.ID_EMPLEADO = CAT_EMPLEADO.ID_EMPLEADO " +
                    " WHERE FECHA_PRESTAMO BETWEEN @FECHA_INI AND @FECHA_FIN";


                int I = 0;
                OleDbCommand cmdReadData = new OleDbCommand();
                cmdReadData.Connection = cnnReadData;
                cmdReadData.CommandText= varSQL;
                cmdReadData.Parameters.Add("@FECHA_INI",OleDbType.Date).Value= prmDateStart;
                cmdReadData.Parameters.Add("@FECHA_FIN",OleDbType.Date).Value= prmDateEnd;
                OleDbDataReader drReadData;
                cnnReadData.Open();
                drReadData = cmdReadData.ExecuteReader();
                lvPrestamos.Items.Clear();
                while (drReadData.Read())
                {
                    lvPrestamos.Items.Add(drReadData["ID_PRESTAMO"].ToString());
                    lvPrestamos.Items[I].SubItems.Add(drReadData["EMPLEADO"].ToString());
                    lvPrestamos.Items[I].SubItems.Add(String.Format("{0:dd/MM/yyyy}", drReadData["FECHA_PRESTAMO"]));
                    lvPrestamos.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["IMPORTE"]));
                    lvPrestamos.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["PAGADO"]));
                    lvPrestamos.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["RESTO"]));
                    I += 1;
                }
                drReadData.Close();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { cnnReadData.Close(); }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            ReadData(txtFechaIni.Value, txtFechaFin.Value);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NuevoPrestamo();
        }
        protected void NuevoPrestamo() {
            frmPrestamo frm = new frmPrestamo();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
            if (frm.Success) {
                ReadData(txtFechaIni.Value, txtFechaFin.Value);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
