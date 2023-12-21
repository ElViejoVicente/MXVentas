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
    public partial class frmRptMoneyCounting : Telerik.WinControls.UI.RadForm
    {
        
        public frmRptMoneyCounting(bool FromMenu)
        {
            InitializeComponent();
            fromMenu = FromMenu;
        }
        bool fromMenu = false;
        private void frmRptMoneyCounting_Load(object sender, EventArgs e)
        {
            #region CreacionDeEventos

            txt1000.KeyPress += new KeyPressEventHandler(txt1000_KeyPress);
            txt1000.TextChanged += new EventHandler(txt1000_TextChanged);
            txt500.KeyPress += new KeyPressEventHandler(txt500_KeyPress);
            txt500.TextChanged += new EventHandler(txt500_TextChanged);
            txt200.KeyPress += new KeyPressEventHandler(txt200_KeyPress);
            txt200.TextChanged += new EventHandler(txt200_TextChanged);
            txt100.KeyPress += new KeyPressEventHandler(txt100_KeyPress);
            txt100.TextChanged += new EventHandler(txt100_TextChanged);
            txt50.KeyPress += new KeyPressEventHandler(txt50_KeyPress);
            txt50.TextChanged += new EventHandler(txt50_TextChanged);
            txt20.KeyPress += new KeyPressEventHandler(txt20_KeyPress);
            txt20.TextChanged += new EventHandler(txt20_TextChanged);
            txt10.KeyPress += new KeyPressEventHandler(txt10_KeyPress);
            txt10.TextChanged += new EventHandler(txt10_TextChanged);
            txt5.KeyPress += new KeyPressEventHandler(txt5_KeyPress);
            txt5.TextChanged += new EventHandler(txt5_TextChanged);
            txt2.KeyPress += new KeyPressEventHandler(txt2_KeyPress);
            txt2.TextChanged += new EventHandler(txt2_TextChanged);
            txt1.KeyPress += new KeyPressEventHandler(txt1_KeyPress);
            txt1.TextChanged += new EventHandler(txt1_TextChanged);
            txt50C.KeyPress += new KeyPressEventHandler(txt50C_KeyPress);
            txt50C.TextChanged += new EventHandler(txt50C_TextChanged);
            txt20C.KeyPress += new KeyPressEventHandler(txt20C_KeyPress);
            txt20C.TextChanged += new EventHandler(txt20C_TextChanged);
            txt10C.KeyPress += new KeyPressEventHandler(txt10C_KeyPress);
            txt10C.TextChanged += new EventHandler(txt10C_TextChanged);
            txt05C.KeyPress += new KeyPressEventHandler(txt05C_KeyPress);
            txt05C.TextChanged += new EventHandler(txt05C_TextChanged);
            txtOther.KeyPress += new KeyPressEventHandler(txtOther_KeyPress);
            txtOther.TextChanged += new EventHandler(txtOther_TextChanged);
            #endregion
            try
            {
                Inicializa();
                InicializaPOS(cboUserLogin.SelectedValue.ToString());
                if (cboIdPOS.Items.Count == 0) { btnOK.Enabled = false; }
                else { btnOK.Enabled = true; }
                cboUserLogin.SelectionChangeCommitted += new EventHandler(cboUserLogin_SelectionChangeCommitted);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        void cboUserLogin_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                InicializaPOS(cboUserLogin.SelectedValue.ToString());
                if (cboIdPOS.Items.Count == 0) { btnOK.Enabled = false; }
                else { btnOK.Enabled = true; }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        protected void Inicializa()
        {
            OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
            try
            {
                cnn.Open();
                OleDbDataAdapter da = new OleDbDataAdapter();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;
                if (fromMenu)
                {
                    //si el usuario tiene acceso al corte de caja, mostramos todos los usuarios
                    cmd.CommandText = "SELECT USER_LOGIN, TRIM(NOMBRE) + ' ' + TRIM(PATERNO) AS USER_FULL_NAME FROM USERS WHERE [ACTIVO]=TRUE";
                }
                else {
                    cmd.CommandText = "SELECT USER_LOGIN, TRIM(NOMBRE) + ' ' + TRIM(PATERNO) AS USER_FULL_NAME FROM USERS WHERE [ACTIVO]=TRUE AND USER_LOGIN=@USER_LOGIN";
                    cmd.Parameters.Add("@USER_LOGIN", OleDbType.VarChar, 50).Value = frmLogin._USER_LOGIN; ;
                }
                
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "data");
                cboUserLogin.DataSource = ds.Tables["data"];
                cboUserLogin.DisplayMember = "USER_FULL_NAME";
                cboUserLogin.ValueMember = "USER_LOGIN";
            }
            catch (Exception ex) { throw (ex); }
            finally { cnn.Close(); }
        }
        protected void InicializaPOS(string prmUserLogin) {
            OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
            try {
                cnn.Open();
                OleDbDataAdapter da = new OleDbDataAdapter();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "SELECT ID_SALE_START_AMOUNT,DESC_CAJA FROM vSALE_POS WHERE DISPONIBLE=FALSE AND USER_LOGIN=@USER_LOGIN";
                cmd.Parameters.Add("@USER_LOGIN", OleDbType.VarChar, 50).Value =prmUserLogin;
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "data");
                cboIdPOS.DataSource = ds.Tables["data"];
                cboIdPOS.DisplayMember = "DESC_CAJA";
                cboIdPOS.ValueMember = "ID_SALE_START_AMOUNT";
            }
            catch (Exception ex) { throw (ex); }
            finally { cnn.Close(); }
        }
        
        #region Eventos

        void txt05C_TextChanged(object sender, EventArgs e)
        {
            CalculaTotal();
            
        }

        void txt05C_KeyPress(object sender, KeyPressEventArgs e)
        {
    
        }

        void txt10C_TextChanged(object sender, EventArgs e)
        {
            CalculaTotal();
        }

        void txt10C_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        void txt20C_TextChanged(object sender, EventArgs e)
        {
            CalculaTotal();
        }

        void txt20C_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        void txt50C_TextChanged(object sender, EventArgs e)
        {
            CalculaTotal();
        }

        void txt50C_KeyPress(object sender, KeyPressEventArgs e)
        {
      
        }

        void txt1_TextChanged(object sender, EventArgs e)
        {
            CalculaTotal();
        }

        void txt1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        void txt2_TextChanged(object sender, EventArgs e)
        {
            CalculaTotal();
        }

        void txt2_KeyPress(object sender, KeyPressEventArgs e)
        {
    
        }

        void txt5_TextChanged(object sender, EventArgs e)
        {
            CalculaTotal();
        }

        void txt5_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        void txt10_TextChanged(object sender, EventArgs e)
        {
            CalculaTotal();
        }

        void txt10_KeyPress(object sender, KeyPressEventArgs e)
        {
       
        }

        void txt20_TextChanged(object sender, EventArgs e)
        {
            CalculaTotal();
        }

        void txt20_KeyPress(object sender, KeyPressEventArgs e)
        {
;
        }

        void txt50_TextChanged(object sender, EventArgs e)
        {
            CalculaTotal();
        }

        void txt50_KeyPress(object sender, KeyPressEventArgs e)
        {
     ;
        }

        void txt100_TextChanged(object sender, EventArgs e)
        {
            CalculaTotal();
        }

        void txt100_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        void txt200_TextChanged(object sender, EventArgs e)
        {
            CalculaTotal();
        }

        void txt200_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        void txt500_TextChanged(object sender, EventArgs e)
        {
            CalculaTotal();
        }

        void txt500_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        void txt1000_TextChanged(object sender, EventArgs e)
        {
            CalculaTotal();
        }

        void txt1000_KeyPress(object sender, KeyPressEventArgs e)
        {
  
        }
        void txtOther_TextChanged(object sender, EventArgs e)
        {
            CalculaTotal();
        }

        void txtOther_KeyPress(object sender, KeyPressEventArgs e)
        {
         
        }
        #endregion
        void CalculaTotal()
        {
            try
            {
                //validaciones (no vacios)
                if ((txt1000.Text == "") || (txt500.Text == "") || (txt200.Text == "") || (txt100.Text == "") || (txt50.Text == "") || (txt20.Text == "") || (txt10.Text == "") || (txt5.Text == "") || (txt2.Text == "") || (txt1.Text == "") || (txt50C.Text == "") || (txt20C.Text == "") || (txt10C.Text == "") || (txt05C.Text == "")||(txtOther.Text==""))
                {
                    lblTOTAL.Text = "Llene todos los campos";
                    return;
                }
                double varTOTAL = (Convert.ToDouble(txt1000.Text) * 1000) +
                    (Convert.ToDouble(txt500.Text) * 500) +
                    (Convert.ToDouble(txt200.Text) * 200) +
                    (Convert.ToDouble(txt100.Text) * 100) +
                    (Convert.ToDouble(txt50.Text) * 50) +
                    (Convert.ToDouble(txt20.Text) * 20) +
                    (Convert.ToDouble(txt10.Text) * 10) +
                    (Convert.ToDouble(txt5.Text) * 5) +
                    (Convert.ToDouble(txt2.Text) * 2) +
                    (Convert.ToDouble(txt1.Text) * 1) +
                    (Convert.ToDouble(txt50C.Text) * .50) +
                    (Convert.ToDouble(txt20C.Text) * .20) +
                    (Convert.ToDouble(txt10C.Text) * .10) +
                    (Convert.ToDouble(txt05C.Text) * .05) +
                    (Convert.ToDouble(txtOther.Text) * 1);
                lblTOTAL.Text = String.Format("{0:C}", varTOTAL);
            }
            catch (Exception ex)
            {
                lblTOTAL.Text = ex.Message;
                btnOK.Enabled = false;
            }
        }
        void ReadINI()
        {

            txt1000.Text = AppSettings.GetValue("CorteDeCaja", "1000", "0");
            txt500.Text = AppSettings.GetValue("CorteDeCaja", "500", "0");
            txt200.Text = AppSettings.GetValue("CorteDeCaja", "200", "0");
            txt100.Text = AppSettings.GetValue("CorteDeCaja", "100", "0");
            txt50.Text = AppSettings.GetValue("CorteDeCaja", "50", "0");
            txt20.Text = AppSettings.GetValue("CorteDeCaja", "20", "0");
            txt10.Text = AppSettings.GetValue("CorteDeCaja", "10", "0");
            txt5.Text = AppSettings.GetValue("CorteDeCaja", "5", "0");
            txt2.Text = AppSettings.GetValue("CorteDeCaja", "2", "0");
            txt1.Text = AppSettings.GetValue("CorteDeCaja", "1", "0");
            txt50C.Text = AppSettings.GetValue("CorteDeCaja", "50C", "0");
            txt20C.Text = AppSettings.GetValue("CorteDeCaja", "20C", "0");
            txt10C.Text = AppSettings.GetValue("CorteDeCaja", "10C", "0");
            txt05C.Text = AppSettings.GetValue("CorteDeCaja", "05C", "0");
            txtOther.Text = AppSettings.GetValue("CorteDeCaja", "Other", "0");
        }
        void WriteINI()
        {
            //base de datos

            AppSettings.SetValue("CorteDeCaja", "1000", txt1000.Text);
            AppSettings.SetValue("CorteDeCaja", "500", txt500.Text);
            AppSettings.SetValue("CorteDeCaja", "200", txt200.Text);
            AppSettings.SetValue("CorteDeCaja", "100", txt100.Text);
            AppSettings.SetValue("CorteDeCaja", "50", txt50.Text);
            AppSettings.SetValue("CorteDeCaja", "20", txt20.Text);
            AppSettings.SetValue("CorteDeCaja", "10", txt10.Text);
            AppSettings.SetValue("CorteDeCaja", "5", txt5.Text);
            AppSettings.SetValue("CorteDeCaja", "2", txt2.Text);
            AppSettings.SetValue("CorteDeCaja", "1", txt1.Text);
            AppSettings.SetValue("CorteDeCaja", "50C", txt50C.Text);
            AppSettings.SetValue("CorteDeCaja", "20C", txt20C.Text);
            AppSettings.SetValue("CorteDeCaja", "10C", txt10C.Text);
            AppSettings.SetValue("CorteDeCaja", "05C", txt05C.Text);
            AppSettings.SetValue("CorteDeCaja", "Other", txtOther.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try {
                if (cboIdPOS.Items.Count == 0) { MessageBox.Show("El usuario debe tener una caja abierta", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                //validaciones (no vacios)
                if ((txt1000.Text == "") || (txt500.Text == "") || (txt200.Text == "") || (txt100.Text == "") || (txt50.Text == "") || (txt20.Text == "") || (txt10.Text == "") || (txt5.Text == "") || (txt2.Text == "") || (txt1.Text == "") || (txt50C.Text == "") || (txt20C.Text == "") || (txt10C.Text == "") || (txt05C.Text == "") || (txtOther.Text == ""))
                {
                    lblTOTAL.Text = "Llene todos los campos";
                    return;
                }
                double CashBilletes = 
                    (Convert.ToDouble(txt1000.Text) * 1000) +
                     (Convert.ToDouble(txt500.Text) * 500) +
                     (Convert.ToDouble(txt200.Text) * 200) +
                     (Convert.ToDouble(txt100.Text) * 100) +
                     (Convert.ToDouble(txt50.Text) * 50) +
                     (Convert.ToDouble(txt20.Text) * 20);
                double CashCoins = 
                     (Convert.ToDouble(txt10.Text) * 10) +
                     (Convert.ToDouble(txt5.Text) * 5) +
                     (Convert.ToDouble(txt2.Text) * 2) +
                     (Convert.ToDouble(txt1.Text) * 1) +
                     (Convert.ToDouble(txt50C.Text) * .50) +
                     (Convert.ToDouble(txt20C.Text) * .20) +
                     (Convert.ToDouble(txt10C.Text) * .10) +
                     (Convert.ToDouble(txt05C.Text) * .05) +
                     (Convert.ToDouble(txtOther.Text) * 1);
                Class.clsVentas sale = new Class.clsVentas();
                sale.MoneyCounting(Convert.ToInt32(cboIdPOS.SelectedValue), CashBilletes+ CashCoins);
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message,"Información del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error); }
        }
    }
}
