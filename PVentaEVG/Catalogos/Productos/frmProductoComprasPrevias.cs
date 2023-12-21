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
    public partial class frmProductoComprasPrevias : Telerik.WinControls.UI.RadForm
    {
        public frmProductoComprasPrevias(string prmID_PRODUCTO)
        {
            InitializeComponent();
            varID_PRODUCTO= prmID_PRODUCTO;
        }
        string varID_PRODUCTO="";
        private void frmListaComprasPrevias_Load(object sender, EventArgs e)
        {
            Encabezados();
            ReadData(varID_PRODUCTO);
        }
        void Encabezados()
        {
            lvCatProducto.View = View.Details;
            lvCatProducto.Columns.Add("N°",0, HorizontalAlignment.Left);
            lvCatProducto.Columns.Add("Nombre del Proveedor", 200, HorizontalAlignment.Left);
            lvCatProducto.Columns.Add("Fecha de compra", 100, HorizontalAlignment.Left);

            lvCatProducto.Columns.Add("Precio Unitario", 100, HorizontalAlignment.Right);
           
        }
        void ReadData(string prmID_PRODUCTO)
        {
            try
            {
                OleDbConnection cnnReadData = new OleDbConnection(Class.clsMain.CnnStr);
                string varSQL = "SELECT * FROM vCOMPRAS_PROVEEDOR WHERE ID_PRODUCTO = '"+ prmID_PRODUCTO +"'";
                int I = 0;
                OleDbCommand cmdReadData = new OleDbCommand(varSQL, cnnReadData);
                OleDbDataReader drReadData;
                if (cnnReadData.State == ConnectionState.Open)
                    cnnReadData.Close();
                cnnReadData.Open();
                drReadData = cmdReadData.ExecuteReader();
                lvCatProducto.Items.Clear();
                while (drReadData.Read())
                {
                    lvCatProducto.Items.Add(Convert.ToString(I+1));
                    lvCatProducto.Items[I].SubItems.Add(drReadData["DESC_PROVEEDOR"].ToString());
                    lvCatProducto.Items[I].SubItems.Add(Convert.ToDateTime(drReadData["FECHA_FACTURA"]).ToShortDateString());                   
                    
                    lvCatProducto.Items[I].SubItems.Add(String.Format("{0:C}", drReadData["PRECIO_COMPRA"]));                   
                    I += 1;
                }
                drReadData.Close();
                cmdReadData.Dispose();
                cnnReadData.Close();
                cnnReadData.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ReadData(varID_PRODUCTO);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void lvCatProducto_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) {
                this.Close();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            lvCatProducto.Title = "Lista de compras previas";
            lvCatProducto.FitToPage = true;
            lvCatProducto.PrintPreview();
        }
    }
}