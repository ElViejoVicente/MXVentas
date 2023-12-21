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
    public partial class frmCatTipoAjuste : Telerik.WinControls.UI.RadForm
    {
        //controlamos q solo se abra una vez
        private static frmCatTipoAjuste m_FormDefInstance;
        public static frmCatTipoAjuste DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmCatTipoAjuste();
                return m_FormDefInstance;
            }
            set { m_FormDefInstance = value; }
        }
        public frmCatTipoAjuste()
        {
            InitializeComponent();
        }
        static OleDbConnection cnnCatTAjuste;
        static OleDbCommand cmdCatTAjuste;
        static OleDbDataAdapter daCatTAjuste;
        static OleDbCommandBuilder cbCatTAjuste;
        DataSet dsCatTAjuste;
        private void frmCatTipoAjuste_Load(object sender, EventArgs e)
        {
            Inicializa();
        }
        private void Inicializa()
        {
            try
            {
                cnnCatTAjuste = new OleDbConnection(Class.clsMain.CnnStr);
                cmdCatTAjuste = new OleDbCommand();
                daCatTAjuste = new OleDbDataAdapter(cmdCatTAjuste);
                cbCatTAjuste = new OleDbCommandBuilder(daCatTAjuste);
                dsCatTAjuste = new DataSet();
                cmdCatTAjuste.CommandText = "SELECT ID_TIPO_AJUSTE,DESC_TIPO_AJUSTE FROM CAT_TIPO_AJUSTE ORDER BY DESC_TIPO_AJUSTE";
                cmdCatTAjuste.Connection = cnnCatTAjuste;
                cnnCatTAjuste.Open();
                daCatTAjuste.Fill(dsCatTAjuste, "CAT_TIPO_AJUSTE");
                grdCatMarca.DataSource = dsCatTAjuste.Tables["CAT_TIPO_AJUSTE"];

                cnnCatTAjuste.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void frmCatTipoAjuste_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            try
            {
                if (cnnCatTAjuste.State == ConnectionState.Open)
                {
                    cnnCatTAjuste.Close();
                }
                cnnCatTAjuste.Dispose();
                daCatTAjuste.Dispose();
                cmdCatTAjuste.Dispose();
                cbCatTAjuste.Dispose();
                dsCatTAjuste.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                grdCatMarca.EndEdit();
                this.BindingContext[dsCatTAjuste, "CAT_TIPO_AJUSTE"].EndCurrentEdit();
                cnnCatTAjuste.Open();
                daCatTAjuste.Update(dsCatTAjuste, "CAT_TIPO_AJUSTE");
                cnnCatTAjuste.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                grdCatMarca.CancelEdit();
                this.BindingContext[dsCatTAjuste, "CAT_TIPO_AJUSTE"].CancelCurrentEdit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}