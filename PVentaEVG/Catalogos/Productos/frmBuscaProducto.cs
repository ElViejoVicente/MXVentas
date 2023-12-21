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
    public partial class frmBuscaProducto : Telerik.WinControls.UI.RadForm
    {
        public frmBuscaProducto()
        {
            InitializeComponent();
        }
        string idProducto="";


        public Class.clsProducto producto = new Class.clsProducto();

        private void frmBuscaProducto_Load(object sender, EventArgs e)
        {
            Encabezados();
            Inicializa();
        }
        
        private void Inicializa()
        {
            try
            {
                DataSet dsInicializa = new DataSet();
                OleDbConnection cnnInicializa = new OleDbConnection(Class.clsMain.CnnStr);
                cnnInicializa.Open();
                //MARCA
                OleDbDataAdapter daCol = new OleDbDataAdapter("SELECT * FROM COLUMNAS WHERE CLASIFICACION='BUSCA_PRODUCTO' ORDER BY ORDENAR", cnnInicializa);
                dsInicializa.Clear();
                daCol.Fill(dsInicializa, "COLUMNAS");
                cboCOLMUNAS.DataSource = dsInicializa.Tables["COLUMNAS"];
                cboCOLMUNAS.DisplayMember = "DESC_COLUMNA";
                cboCOLMUNAS.ValueMember = "COLUMNA";
                daCol.Dispose();
                

                cnnInicializa.Close();
                cnnInicializa.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void txtDESC_PRODUCTO_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    if (!(txtDESC_PRODUCTO.Text == ""))
                    {
                        ORDENAR();
                    }
                    break;
                case (char)Keys.Escape:
                    idProducto = "";
                    this.Close();
                    break;
            }
        
        
        }
        private void ORDENAR()
        {
            try
            {
                if (cboORDENAR.Text != "")
                {
                    ReadData(fnGetOrder(cboORDENAR.Text) + " " +
                        fnGetAscOrder(cboORDER.Text),
                        Strings.SafeSqlLikeClauseLiteral(txtDESC_PRODUCTO.Text), cboCOLMUNAS.SelectedValue.ToString());
                }
                else
                {
                    ReadData(" ID_PRODUCTO ASC ", Strings.SafeSqlLikeClauseLiteral(txtDESC_PRODUCTO.Text), cboCOLMUNAS.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        string fnGetOrder(string prmCAMPO)
        {
            string retorno = "";
            switch (prmCAMPO)
            {
                case "Clave":
                    //
                    retorno = "ID_PRODUCTO";
                    break;
                case "Nombre del Artículo":
                    //
                    retorno = "DESC_PRODUCTO";
                    break;
                case "Marca":
                    //
                    retorno = "DESC_MARCA";
                    break;
               
                case "Grupo":
                    //
                    retorno = "DESC_GRUPO";
                    break;
                
                default:
                    retorno = "";
                    break;
            }
            return (retorno);
        }
        string fnGetAscOrder(string prmCAMPO)
        {
            string retorno = "";
            switch (prmCAMPO)
            {
                case "Ascendente":
                    //
                    retorno = " ASC ";
                    break;
                case "Descendente":
                    //
                    retorno = " DESC ";
                    break;
                default:
                    retorno = " ASC ";
                    break;
            }
            return (retorno);
        }
        void lvProductos_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    Seleccionar();
                    break;
                case (char)Keys.Escape:
                    idProducto = "";
                    this.Close();
                    break;
            }

        }
        void lvProductos_DoubleClick(object sender, System.EventArgs e)
        {          
                Seleccionar();           

        }
        private void Encabezados()
        {
            lvProductos.View = View.Details;       
            lvProductos.View = View.Details;
            lvProductos.Columns.Add("Clave", 50, HorizontalAlignment.Left);

            //todos
            lvProductos.Columns.Add("Nombre del artículo", 290, HorizontalAlignment.Left);
            lvProductos.Columns.Add("Medida", 100, HorizontalAlignment.Left);
            lvProductos.Columns.Add("Grupo", 100, HorizontalAlignment.Left);
            lvProductos.Columns.Add("Exist", 70, HorizontalAlignment.Right);
            lvProductos.Columns.Add("P.Público", 70, HorizontalAlignment.Right);
            //lvProductos.Columns.Add("P.Trab", 70, HorizontalAlignment.Right);
            //lvProductos.Columns.Add("P.May", 70, HorizontalAlignment.Right);
            //lvProductos.Columns.Add("P.Comp", 70, HorizontalAlignment.Right);

        }
        private void ReadData(string prmORDERBY, string prmDESC_PRODUCTO, string prmCOLUMNA)
        {
            //Este procedimiento lee los datos que se tranferirán y los mostrará en forma de
            //lista en el ListView
            try
            {
                
                //Si la conexion esta abierta la cerramos; en caso contrario, la abrimos
                OleDbConnection cnnReadData = new OleDbConnection(Class.clsMain.CnnStr);
                if (cnnReadData.State == ConnectionState.Open) cnnReadData.Close(); else cnnReadData.Open();
                int I = 0;
                string varSQL = "SELECT P.ID_PRODUCTO, " +
                    " P.DESC_PRODUCTO," +
                    " M.DESC_MARCA," +
                    " P.EXISTENCIA, P.PRECIO_VENTA,P.PRECIO_VENTA2,P.PRECIO_VENTA3,P.SUST_ACTIVA,P.FORMULACION,P.INDICACION," +
                    " P.IMPUESTO,G.DESC_GRUPO,ME.DESC_UNIDAD_MEDIDA,P.PRECIO_COMPRA " +
                    " " +
                    " FROM  CAT_PRODUCTO P,CAT_MARCA M,CAT_GRUPO G, CAT_UNIDAD_MEDIDA ME " +
                    " WHERE P.ID_MARCA = M.ID_MARCA AND ME.ID_UNIDAD_MEDIDA =P.ID_UNIDAd_MEDIDA  AND " + prmCOLUMNA + " like '%" + prmDESC_PRODUCTO + "%' " +
                    " AND G.ID_GRUPO = P.ID_GRUPO " +
                    " AND P.HABILITAR_VENTA =TRUE " +
                    "  ORDER BY " + prmORDERBY ;

                OleDbCommand cmdReadData = new OleDbCommand(varSQL, cnnReadData);
                OleDbDataReader drReadData;
                drReadData = cmdReadData.ExecuteReader();
                lvProductos.Items.Clear();
                while (drReadData.Read())
                {
                    lvProductos.Items.Add(drReadData["ID_PRODUCTO"].ToString());
                    //todos
                    lvProductos.Items[I].SubItems.Add(drReadData["DESC_PRODUCTO"].ToString());
                    lvProductos.Items[I].SubItems.Add(drReadData["DESC_UNIDAD_MEDIDA"].ToString());
                    lvProductos.Items[I].SubItems.Add(drReadData["DESC_GRUPO"].ToString());
                    lvProductos.Items[I].SubItems.Add(String.Format("{0:N}", drReadData["EXISTENCIA"]));
                    lvProductos.Items[I].SubItems.Add(String.Format("{0:N}", drReadData["PRECIO_VENTA"]));
                    lvProductos.Items[I].SubItems.Add(String.Format("{0:N}", drReadData["PRECIO_VENTA2"]));
                    lvProductos.Items[I].SubItems.Add(String.Format("{0:N}", drReadData["PRECIO_VENTA3"]));
                    lvProductos.Items[I].SubItems.Add(String.Format("{0:N}", drReadData["PRECIO_COMPRA"]));
                   
                    I += 1;
                   
                }
           


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
                if (lvProductos.SelectedItems.Count != 0)
                {
                    
                    idProducto = lvProductos.SelectedItems[0].Text;
                    producto.Buscar(idProducto);

                }
                else
                {
                    idProducto = "";
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("You must select an element from the list. \nError Description: \n" + ex.Message, 
                    "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ORDENAR();
        }

        private void cboORDENAR_SelectedIndexChanged(object sender, EventArgs e)
        {
            ORDENAR();
        }

        private void cboORDER_SelectedIndexChanged(object sender, EventArgs e)
        {
            ORDENAR();
        }

    }
}