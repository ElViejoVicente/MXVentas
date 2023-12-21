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
    public partial class frmRptTicket : Telerik.WinControls.UI.RadForm
    {
        public frmRptTicket()
        {
            InitializeComponent();
        }
        public static int varFOLIO_VENTA = 0;   
        private void frmRptTicket_Load(object sender, EventArgs e)
        {
            this.KeyUp += new KeyEventHandler(frmRptTicket_KeyUp);
            txtNOMBRE.KeyPress += new KeyPressEventHandler(txtNOMBRE_KeyPress);
            lvBuscaCliente.DoubleClick += new EventHandler(lvBuscaCliente_DoubleClick);
            Encabezados();
            txtFECHA_INI.Value = DateTime.Now;
            txtFECHA_FIN.Value = DateTime.Now;
        }

        void frmRptTicket_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyData== Keys.Escape){this.Close();}
        }

        void lvBuscaCliente_DoubleClick(object sender, EventArgs e)
        {
            Seleccionar();
        }

        void txtNOMBRE_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    if (!(txtNOMBRE.Text == ""))
                    {
                        ReadData(txtNOMBRE.Text,txtFECHA_INI.Value, txtFECHA_FIN.Value);
                    }
                    break;
            }
        }
        private void Encabezados()
        {
            lvBuscaCliente.View = View.Details;
            lvBuscaCliente.Columns.Add("Ticket", 50, HorizontalAlignment.Left);
            lvBuscaCliente.Columns.Add("Nombre del cliente", 350, HorizontalAlignment.Left);
            lvBuscaCliente.Columns.Add("Total", 100, HorizontalAlignment.Right);
        }
        private void ReadData(string prmNOMBRE, DateTime prmFECHA_INI, DateTime prmFECHA_FIN)
        {
            //Este procedimiento lee los datos que se tranferirán y los mostrará en forma de
            //lista en el ListView
            try
            {
                //Si la conexion esta abierta la cerramos; en caso contrario, la abrimos
                OleDbConnection cnnReadData = new OleDbConnection(Class.clsMain.CnnStr);
                if (cnnReadData.State == ConnectionState.Open) cnnReadData.Close(); else cnnReadData.Open();
                int I = 0;
                string varSQL = "SELECT VENTA.FOLIO, CAT_CLIENTE.NOMBRE AS CLIENTE, VENTA_DETALLE.TOTAL" +
                    " FROM CAT_CLIENTE, VENTA, (SELECT VENTA_DETALLE.FOLIO, SUM(CANTIDAD*PRECIO_VENTA) AS TOTAL FROM VENTA_DETALLE GROUP BY VENTA_DETALLE.FOLIO)  AS VENTA_DETALLE" +
                    " WHERE CAT_CLIENTE.ID_CLIENTE=VENTA.ID_CLIENTE And VENTA_DETALLE.FOLIO=VENTA.FOLIO" +
                    " AND CAT_CLIENTE.NOMBRE LIKE '%'+ @buscar +'%'" +
                    " AND VENTA.FECHA BETWEEN @fecha_ini and @fecha_fin";
                OleDbCommand cmdReadData = new OleDbCommand(varSQL, cnnReadData);
                cmdReadData.Parameters.Add("@buscar", OleDbType.VarChar, 50).Value = prmNOMBRE;
                cmdReadData.Parameters.Add("@fecha_ini", OleDbType.Date).Value = new DateTime(prmFECHA_INI.Year,prmFECHA_INI.Month,prmFECHA_INI.Day);
                cmdReadData.Parameters.Add("@fecha_fin", OleDbType.Date).Value = new DateTime(prmFECHA_FIN.Year, prmFECHA_FIN.Month, prmFECHA_FIN.Day, 23, 59, 59);
                OleDbDataReader drReadData;
                drReadData = cmdReadData.ExecuteReader();
                lvBuscaCliente.Items.Clear();
                while (drReadData.Read())
                {
                    lvBuscaCliente.Items.Add(drReadData["FOLIO"].ToString());
                    lvBuscaCliente.Items[I].SubItems.Add(drReadData["CLIENTE"].ToString());
                    lvBuscaCliente.Items[I].SubItems.Add(drReadData["TOTAL"].ToString());
                    I += 1;
                }
                lblInfo.Text = String.Format("Se encontraron {0} registro(s)", I);
                drReadData.Close();
                cmdReadData.Dispose();
                cnnReadData.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Seleccionar()
        {
            try
            {
                if (lvBuscaCliente.SelectedItems.Count != 0)
                {
                    varFOLIO_VENTA = Convert.ToInt32(lvBuscaCliente.SelectedItems[0].Text);
                    Class.clsVentas ventas = new Class.clsVentas();
                    ventas.ImprimeTicket(varFOLIO_VENTA, false);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("You must select an element from the list. \nError Description: \n" + ex.Message, "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ReadData(txtNOMBRE.Text, txtFECHA_INI.Value, txtFECHA_FIN.Value);
        }
    }
}
