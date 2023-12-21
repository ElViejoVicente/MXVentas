using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace POSApp.Forms
{
    public partial class frmHistorialPagos : Telerik.WinControls.UI.RadForm
    {
        public frmHistorialPagos(int prmFOLIO_CREDITO)
        {
            InitializeComponent();
            varFOLIO_CREDITO = prmFOLIO_CREDITO;
        }
        int varFOLIO_CREDITO = 0;
        private void frmHistorialPagos_Load(object sender, EventArgs e)
        {
            Encabezados();
            ReadData(varFOLIO_CREDITO);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void Encabezados() {
            lvHistorialPagos.View = View.Details;
            lvHistorialPagos.Columns.Add("Folio de pago", 0, HorizontalAlignment.Left);
            lvHistorialPagos.Columns.Add("Fecha de pago", 200, HorizontalAlignment.Left);
            lvHistorialPagos.Columns.Add("Importe", 100, HorizontalAlignment.Right);
        }
        private void btnClose2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void ReadData(int prmFOLIO_CREDITO)
        {
            try
            {
                OleDbConnection cnnReadData = new OleDbConnection(Class.clsMain.CnnStr);
                cnnReadData.Open();
                OleDbCommand cmdReadData = new OleDbCommand("SELECT * "+
                    " FROM vCREDITO " +
                    " WHERE FOLIO_VENTA=" + prmFOLIO_CREDITO + "",
                    cnnReadData);
                OleDbDataReader drReadData;
                drReadData = cmdReadData.ExecuteReader();
                while (drReadData.Read())
                {
                    txtCLIENTE.Text = drReadData["NOMBRE"].ToString();
                    txtCANTIDAD.Text = String.Format("{0:C}", drReadData["CANTIDAD"]);
                    txtPAGADO.Text = String.Format("{0:C}", drReadData["PAGADO"]);
                    txtINT_MENSUAL.Text = drReadData["INT_MENSUAL"].ToString() + "%";
                    txtRESTO.Text = String.Format("{0:C}", drReadData["RESTO"]);
                }
                drReadData.Close();
                cmdReadData.CommandText = "SELECT FOLIO_PAGO_CREDITO, FECHA, CANTIDAD "+
                    " FROM PAGO_CREDITO WHERE FOLIO_VENTA = "+ prmFOLIO_CREDITO +"";
                drReadData = cmdReadData.ExecuteReader();
                int I = 0;
                lvHistorialPagos.Items.Clear();
                while (drReadData.Read())
                {
                    lvHistorialPagos.Items.Add(drReadData["FOLIO_PAGO_CREDITO"].ToString());
                    lvHistorialPagos.Items[I].SubItems.Add(drReadData["FECHA"].ToString());
                    lvHistorialPagos.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["CANTIDAD"]));        
                    I += 1;
                }

                cmdReadData.Dispose();
                cnnReadData.Close();
                cnnReadData.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            lvHistorialPagos.Title = 
                "Cliente: " + txtCLIENTE.Text +
                ", Total a pagar: " + txtCANTIDAD.Text +
                ", Pagado: " + txtPAGADO.Text +
                ", Restante: " + txtRESTO.Text;
            lvHistorialPagos.PrintPreview();
        }
    }
}