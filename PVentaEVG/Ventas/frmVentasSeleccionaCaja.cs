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
    public partial class frmVentasSeleccionaCaja : Telerik.WinControls.UI.RadForm
    {
        public frmVentasSeleccionaCaja()
        {
            InitializeComponent();
        }
        public static int _ID_CAJA = 0;
        private void btnCANCEL_Click(object sender, EventArgs e)
        {
            _ID_CAJA = 0;
            this.Close();
        }

        private void frmSeleccionaCaja_Load(object sender, EventArgs e)
        {
            Inicializa();
        }
        void Inicializa()
        {
            try
            {
                // ESTE ES EL CODIGO PARA INICIALIZAR EL FORMULARIO   
                OleDbConnection cnnInicializa = new OleDbConnection(Class.clsMain.CnnStr);
                if (cnnInicializa.State == ConnectionState.Open)
                {
                    cnnInicializa.Open();
                }
                else
                {
                    cnnInicializa.Close();
                }
                //LLENAMOS EL 
                DataSet dsCaja = new DataSet("dsCaja");
                OleDbDataAdapter daCaja = 
                    new OleDbDataAdapter("SELECT ID_CAJA,DESC_CAJA FROM CAT_CAJA "+
                    "WHERE DISPONIBLE <> 0", cnnInicializa);
                daCaja.Fill(dsCaja, "CAT_CAJA");
                //LLENAMOS EL COMBO 
                cboID_CAJA.DataSource = dsCaja.Tables["CAT_CAJA"];
                cboID_CAJA.DisplayMember = "DESC_CAJA";
                cboID_CAJA.ValueMember = "ID_CAJA";
                cnnInicializa.Close();
                cnnInicializa.Dispose();
                daCaja.Dispose();
                cboID_CAJA.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Inicializing");
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cboID_CAJA.Text != "")
            {
                //AQUI
                _ID_CAJA = Convert.ToInt32(cboID_CAJA.SelectedValue);
                this.Close();
            }
            else {
                MessageBox.Show("Seleccione CAJA");
            }
        }
    }
}