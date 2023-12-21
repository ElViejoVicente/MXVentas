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
    public partial class frmGasto : Telerik.WinControls.UI.RadForm
    {
        public frmGasto()
        {
            InitializeComponent();
        }
        public frmGasto(double prmIMPORTE)
        {
            InitializeComponent();
            varIMPORTE = prmIMPORTE;
        }
        public static bool _Accion = false;
        double varIMPORTE = 0;
        private void frmGasto_Load(object sender, EventArgs e)
        {
            txtIMPORTE.KeyPress += new KeyPressEventHandler(txtIMPORTE_KeyPress);
            if (varIMPORTE != 0) {
                MessageBox.Show("Registre el gasto de esta entrada", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIMPORTE.Text = varIMPORTE.ToString() ;
            }
            Inicializa();
        }
        void Inicializa() {
            try {
                OleDbConnection cnnIni = new OleDbConnection(Class.clsMain.CnnStr);
                cnnIni.Open();
                DataSet dsIni = new DataSet();
                OleDbDataAdapter daIni = new OleDbDataAdapter("SELECT * FROM CAT_TIPO_GASTO", cnnIni);
                daIni.Fill(dsIni, "CAT_TIPO_GASTO");
                cboID_TIPO_GASTO.DataSource = dsIni.Tables["CAT_TIPO_GASTO"];
                cboID_TIPO_GASTO.DisplayMember = "DESC_TIPO_GASTO";
                cboID_TIPO_GASTO.ValueMember = "ID_TIPO_GASTO";
                cnnIni.Close();
                dsIni.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Inicializa");
               
            }
        }
        void txtIMPORTE_KeyPress(object sender, KeyPressEventArgs e)
        {
         
        }
        private bool fnGASTO(double prmIMPORTE, string prmUSER_LOGIN, 
            string prmOBSERVACIONES, string prmFECHA_GASTO,int prmID_TIPO_GASTO)
        {
            try
            {
                OleDbConnection cnnPAGO = new OleDbConnection(Class.clsMain.CnnStr);
                cnnPAGO.Open();
                string varSQL = "INSERT INTO GASTO (IMPORTE,OBSERVACIONES,USER_LOGIN,FECHA_GASTO,ID_TIPO_GASTO)" +
                    " values(" + prmIMPORTE + ",'"+ prmOBSERVACIONES +"','" + prmUSER_LOGIN + "',#"+ prmFECHA_GASTO +"#,"+ prmID_TIPO_GASTO +")";
                OleDbCommand cmdPAGO = new OleDbCommand(varSQL, cnnPAGO);
                cmdPAGO.ExecuteNonQuery();
                cmdPAGO.CommandText = "UPDATE SALE_START_AMOUNT SET SALE_DATE_END=now() WHERE USER_LOGIN='"+ prmUSER_LOGIN +"'"; ;
                cmdPAGO.ExecuteNonQuery();
                cmdPAGO.Dispose();
                cnnPAGO.Close();
                cnnPAGO.Dispose();
                _Accion = true;
                return (true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "fnPaid");
                return (false);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtIMPORTE.Text != "")
            {
                if (fnGASTO(Convert.ToDouble(txtIMPORTE.Text),
                    frmLogin._USER_LOGIN,
                    Strings.SafeSqlLikeClauseLiteral(txtOBSERVACIONES.Text),
                    ISODates.MSAccessDate(dtpFECHA_GASTO.Value),
                    Convert.ToInt32(cboID_TIPO_GASTO.SelectedValue)))
                {
                    this.Close();
                }
            }
            else {
                MessageBox.Show("Falta el importe","Información del sistema");
            }
        }
    }
}