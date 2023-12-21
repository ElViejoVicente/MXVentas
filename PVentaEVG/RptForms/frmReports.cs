using System;
using System.Windows.Forms;

namespace POSApp.Forms
{
    public partial class frmReports : Telerik.WinControls.UI.RadForm
    {
        public frmReports()
        {
            InitializeComponent();
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(frmReports_FormClosing);
            this.rvDoc.RefreshReport();
        }

        void frmReports_FormClosing(object sender, FormClosingEventArgs e)
        {
            rvDoc.LocalReport.ReleaseSandboxAppDomain();
        }

        
        
    }
}