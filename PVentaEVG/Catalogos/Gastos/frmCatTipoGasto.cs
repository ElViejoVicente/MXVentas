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
    public partial class frmCatTipoGasto : Telerik.WinControls.UI.RadForm
    {
        //controlamos q solo se abra una vez
        private static frmCatTipoGasto m_FormDefInstance;
        public static frmCatTipoGasto DefInstance
        {
            get
            {
          
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmCatTipoGasto();
                return m_FormDefInstance;
            }
            set { m_FormDefInstance = value; }
        }
        public frmCatTipoGasto()
        {
            InitializeComponent();
        }
        static OleDbConnection cnnCat;
        static OleDbCommand cmdCat;
        static OleDbDataAdapter daCat;
        static OleDbCommandBuilder cbCat;
        DataSet dsCat;
        private void frmCatTipoGasto_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(frmCatTipoGasto_FormClosing);
            grdCatMarca.CellClick += new DataGridViewCellEventHandler(grdCatMarca_CellClick);
            Inicializa();
        }

        void grdCatMarca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2)
                {
                    frmBuscaEmpleado _frmBuscaEmpleado = new frmBuscaEmpleado();
                    _frmBuscaEmpleado.StartPosition = FormStartPosition.CenterScreen;
                    _frmBuscaEmpleado.ShowDialog();
                    if (!(frmBuscaEmpleado.varID_EMPLEADO == ""))
                    {
                        grdCatMarca.Rows[e.RowIndex].Cells["txtID_EMPLEADO"].Value = frmBuscaEmpleado.varID_EMPLEADO;
                    }
                    _frmBuscaEmpleado.Dispose(); 
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnBuscar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            

        }

        void frmCatTipoGasto_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

                if (cnnCat.State == ConnectionState.Open)
                {
                    cnnCat.Close();
                }
                cnnCat.Dispose();
                daCat.Dispose();
                cmdCat.Dispose();
                cbCat.Dispose();
                dsCat.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Inicializa()
        {
            try
            {
                cnnCat = new OleDbConnection(Class.clsMain.CnnStr);
                cmdCat = new OleDbCommand();
                daCat = new OleDbDataAdapter(cmdCat);
                cbCat = new OleDbCommandBuilder(daCat);
                dsCat = new DataSet();
                cmdCat.CommandText = "SELECT ID_TIPO_GASTO,DESC_TIPO_GASTO,ID_EMPLEADO FROM CAT_TIPO_GASTO ORDER BY DESC_TIPO_GASTO";
                cmdCat.Connection = cnnCat;
                cnnCat.Open();
                daCat.Fill(dsCat, "CAT_TIPO_GASTO");
                grdCatMarca.DataSource = dsCat.Tables["CAT_TIPO_GASTO"];

                cnnCat.Close();
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
                this.BindingContext[dsCat, "CAT_TIPO_GASTO"].EndCurrentEdit();
                cnnCat.Open();
                daCat.Update(dsCat, "CAT_TIPO_GASTO");
                cnnCat.Close();
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
                this.BindingContext[dsCat, "CAT_TIPO_GASTO"].CancelCurrentEdit();
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
