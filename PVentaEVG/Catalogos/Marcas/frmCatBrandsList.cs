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
    public partial class frmCatBrandsList : Telerik.WinControls.UI.RadForm
    {
        private static frmCatBrandsList m_FormDefInstance;
        public static frmCatBrandsList DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmCatBrandsList();
                return m_FormDefInstance;
            }
            set { m_FormDefInstance = value; }
        }
        public frmCatBrandsList()
        {
            InitializeComponent();
        }

        private void frmCatBrandsList_Load(object sender, EventArgs e)
        {
            //events
            lvCatalog.DoubleClick += new EventHandler(lvCatalog_DoubleClick);
            HeadersListView();
            ListCatalog();
        }
        void lvCatalog_DoubleClick(object sender, EventArgs e)
        {
            SelectToEditItem();
        }
        protected void HeadersListView()
        {
            lvCatalog.Clear();
            lvCatalog.View = View.Details;
            lvCatalog.GridLines = true;
            lvCatalog.HideSelection = false;
            lvCatalog.FullRowSelect = true;
            lvCatalog.Columns.Add("Id", 0, HorizontalAlignment.Left);
            lvCatalog.Columns.Add("Marca", 200, HorizontalAlignment.Left);
            lvCatalog.Columns.Add("Habilitado", 100, HorizontalAlignment.Left);
        }
        protected void ListCatalog()
        {
            OleDbConnection cnn = new OleDbConnection();
            try
            {
                cnn.ConnectionString = Class.clsMain.CnnStr;
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT ID_MARCA, DESC_MARCA, ENABLED FROM CAT_MARCA ORDER BY DESC_MARCA", cnn);
                OleDbDataReader dr = cmd.ExecuteReader();
                int i = 0;
                lvCatalog.Items.Clear();
                while (dr.Read())
                {
                    lvCatalog.Items.Add(dr["ID_MARCA"].ToString());
                    lvCatalog.Items[i].SubItems.Add(dr["DESC_MARCA"].ToString());
                    lvCatalog.Items[i].SubItems.Add(dr["ENABLED"].ToString());
                    i++;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cnn.Close();
            }
        }
        protected void SelectToEditItem()
        {
            try
            {
                if (lvCatalog.SelectedItems.Count != 0)
                {
                    int id = Convert.ToInt32(lvCatalog.SelectedItems[0].Text);
                    frmCatBrandsItem cat = new frmCatBrandsItem(id);
                    cat.StartPosition = FormStartPosition.CenterScreen;
                    cat.ShowInTaskbar = false;
                    cat.ShowDialog();
                    if (cat.ACTION_SUCCESS)
                    {
                        ListCatalog();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un elemento de la lista",
                        "Información del Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Información del Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected void AddNew()
        {
            frmCatBrandsItem cat = new frmCatBrandsItem(0);
            cat.StartPosition = FormStartPosition.CenterScreen;
            cat.ShowInTaskbar = false;
            cat.ShowDialog();
            if (cat.ACTION_SUCCESS)
            {
                ListCatalog();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AddNew();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SelectToEditItem();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ListCatalog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            lvCatalog.Title = this.Text;
            lvCatalog.FitToPage = true;
            lvCatalog.PrintPreview();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            POSDLL.Utilities.ExportListView exportar = new POSDLL.Utilities.ExportListView();
            exportar.ExportToExcel(lvCatalog, this.Text);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
