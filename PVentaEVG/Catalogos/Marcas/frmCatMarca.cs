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
    public partial class frmCatMarca : Telerik.WinControls.UI.RadForm
    {
        //controlamos q solo se abra una vez
        private static frmCatMarca m_FormDefInstance;
        public static frmCatMarca DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmCatMarca();
                return m_FormDefInstance;
            }
            set { m_FormDefInstance = value; }
        }
        public frmCatMarca()
        {
            InitializeComponent();
        }
        static OleDbConnection cnnCatMarca;
        static OleDbCommand cmdCatMarca;
        static OleDbDataAdapter daCatMarca;
        static OleDbCommandBuilder cbCatMarca;
        DataSet dsCatMarca;
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Inicializa()
        {
            try
            {
                cnnCatMarca = new OleDbConnection(Class.clsMain.CnnStr);
                cmdCatMarca = new OleDbCommand();
                daCatMarca = new OleDbDataAdapter(cmdCatMarca);
                cbCatMarca = new OleDbCommandBuilder(daCatMarca);
                dsCatMarca = new DataSet("dsCatMarca");
                cmdCatMarca.CommandText = "SELECT ID_MARCA,DESC_MARCA FROM CAT_MARCA ORDER BY DESC_MARCA";
                cmdCatMarca.Connection = cnnCatMarca;
                cnnCatMarca.Open();
                daCatMarca.Fill(dsCatMarca, "CAT_MARCA");
                grdCatMarca.DataSource = dsCatMarca.Tables["CAT_MARCA"];

                cnnCatMarca.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void frmCatMarca_Load(object sender, EventArgs e)
        {
            Inicializa();
        }
        void frmCatMarca_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            try {
                if (cnnCatMarca.State == ConnectionState.Open) {
                    cnnCatMarca.Close();
                }
                cnnCatMarca.Dispose();
                daCatMarca.Dispose();
                cmdCatMarca.Dispose();
                cbCatMarca.Dispose();
                dsCatMarca.Dispose();
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
                this.BindingContext[dsCatMarca, "CAT_MARCA"].EndCurrentEdit();
                cnnCatMarca.Open();
                daCatMarca.Update(dsCatMarca, "CAT_MARCA");
                cnnCatMarca.Close();
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
                this.BindingContext[dsCatMarca, "CAT_MARCA"].CancelCurrentEdit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}