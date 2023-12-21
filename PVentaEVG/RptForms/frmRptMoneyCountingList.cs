using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POSApp.Forms
{
    public partial class frmRptMoneyCountingList : Telerik.WinControls.UI.RadForm
    {
        private static frmRptMoneyCountingList m_FormDefInstance;
        public static frmRptMoneyCountingList DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmRptMoneyCountingList();
                return m_FormDefInstance;
            }
            set { m_FormDefInstance = value; }
        }
        public frmRptMoneyCountingList()
        {
            InitializeComponent();
        }

        private void frmRptMoneyCountingList_Load(object sender, EventArgs e)
        {
            try {
                lvRpt.DoubleClick += new EventHandler(lvRpt_DoubleClick);
                ReadData(txtFechaInicio.Value, txtFechaFin.Value);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        void lvRpt_DoubleClick(object sender, EventArgs e)
        {
            Print();
        }
        void Print() {
            try
            {
                if (lvRpt.SelectedItems.Count != 0) {
                    int id = Convert.ToInt32(lvRpt.SelectedItems[0].Tag);
                    Class.clsVentas ventas = new Class.clsVentas();
                    ventas.PrintMoneyCounting(id);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        void ReadData(DateTime fechaIni, DateTime fechaFin) {
            OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
            try {
                lvRpt.View = View.Details;
                lvRpt.FullRowSelect = true;
                lvRpt.HideSelection = false;
                lvRpt.GridLines = true;
                lvRpt.Clear();
                lvRpt.Columns.Add("Id", 70);
                lvRpt.Columns.Add("Caja",100);
                lvRpt.Columns.Add("Usuario", 250);
                lvRpt.Columns.Add("Fecha", 130);
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT * FROM vMONEY_COUNTING WHERE SALE_DATE_END BETWEEN @fecha_ini and @fecha_fin";
                cmd.Parameters.Add("@fecha_ini", OleDbType.Date).Value = new DateTime(fechaIni.Year, fechaIni.Month, fechaIni.Day);
                cmd.Parameters.Add("@fecha_fin", OleDbType.Date).Value = new DateTime(fechaFin.Year, fechaFin.Month, fechaFin.Day).AddDays(1);
                int i = 0;
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    lvRpt.Items.Add(dr["ID_MONEY_COUNTING"].ToString());
                    lvRpt.Items[i].SubItems.Add(String.Format("{0}",dr["DESC_CAJA"]));
                    lvRpt.Items[i].SubItems.Add(String.Format("{0}", dr["USER_FULL_NAME"]));
                    lvRpt.Items[i].SubItems.Add(String.Format("{0:dd/MM/yyyy HH:mm}", dr["SALE_DATE_END"]));
                    lvRpt.Items[i].Tag = dr["ID_MONEY_COUNTING"];
                    i++;
                }
                dr.Close();
            }
            catch (Exception ex) { throw ex; }
            finally { cnn.Close(); }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                ReadData(txtFechaInicio.Value, txtFechaFin.Value);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
