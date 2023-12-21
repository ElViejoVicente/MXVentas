using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSDLL; using POSDLL.Windows.Forms; using POSDLL.Security; using POSDLL.Reporting; using POSDLL.Ticket;
namespace POSApp.Forms
{
    public partial class frmFiltro : Telerik.WinControls.UI.RadForm
    {
        public frmFiltro(string prmFILTRO)
        {
            InitializeComponent();
            varFILTRO = prmFILTRO;
        }
        
        string varFILTRO = "";
        private void frmFiltro_Load(object sender, EventArgs e)
        {
            dtpFECHA_INI.Value = Convert.ToDateTime(AppSettings.GetValue(varFILTRO, "FECHA_INI", Convert.ToString(System.DateTime.Now)));
            dtpFECHA_FIN.Value = Convert.ToDateTime(AppSettings.GetValue(varFILTRO, "FECHA_FIN", Convert.ToString(System.DateTime.Now)));
            chkFiltro.Checked = !Convert.ToBoolean(AppSettings.GetValue(varFILTRO, "FILTRO", Convert.ToString(false)));
            chkHoy.Checked = Convert.ToBoolean(AppSettings.GetValue(varFILTRO, "HOY", Convert.ToString(false)));

            //chkHoy.Checked=!chkFiltro.Checked;
            //chkHoy.Enabled=!chkFiltro.Checked;
            if (chkFiltro.Checked)
            {
                //SI no hay filtro, se motraría todo
                chkHoy.Enabled = false;
                chkHoy.Checked = false;
                dtpFECHA_INI.Enabled = false;
                dtpFECHA_FIN.Enabled = false;
            }
            else
            {
                //SI hay filtro hay que ver si se aplica filtro para hoy o por rango
                if (chkHoy.Checked)
                {
                    //EL filtro es solo para hoy
                    dtpFECHA_INI.Enabled = false;
                    dtpFECHA_FIN.Enabled = false;
                }
                else
                {
                    //Existe un filtro para un  rango de fechas
                    dtpFECHA_INI.Enabled = true;
                    dtpFECHA_FIN.Enabled = true;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dtpFECHA_INI.Value <= dtpFECHA_FIN.Value)
            {
                AppSettings.SetValue(varFILTRO, "FECHA_INI", Convert.ToString(dtpFECHA_INI.Value - dtpFECHA_INI.Value.TimeOfDay));
                AppSettings.SetValue(varFILTRO, "FECHA_FIN", Convert.ToString(Convert.ToDateTime(dtpFECHA_FIN.Value - dtpFECHA_FIN.Value.TimeOfDay).AddHours(23.999)));
                AppSettings.SetValue(varFILTRO, "FILTRO", Convert.ToString(!Convert.ToBoolean(chkFiltro.Checked)));
                AppSettings.SetValue(varFILTRO, "HOY", Convert.ToString(Convert.ToBoolean(chkHoy.Checked)));

                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect Date.\nStart date can not be greater than the end date", "Date Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void chkHoy_CheckedChanged(object sender, EventArgs e)
        {
            dtpFECHA_INI.Enabled = !chkHoy.Checked;
            dtpFECHA_FIN.Enabled = !chkHoy.Checked;
        }

        private void chkFiltro_CheckedChanged(object sender, EventArgs e)
        {
            chkHoy.Checked = !chkFiltro.Checked;
            chkHoy.Enabled = !chkFiltro.Checked;
            dtpFECHA_INI.Enabled = chkFiltro.Checked && chkHoy.Checked;
            dtpFECHA_FIN.Enabled = chkFiltro.Checked && chkHoy.Checked;		
        }
    }
}