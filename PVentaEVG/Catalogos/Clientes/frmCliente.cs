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
    public partial class frmCliente : Telerik.WinControls.UI.RadForm
    {
        public static bool _Accion = false;
        public frmCliente()
        {
            InitializeComponent();
            varID_CLIENTE = 0;
        }
        public frmCliente(int prmID_CLIENTE)
        {
            InitializeComponent();
            varID_CLIENTE = prmID_CLIENTE;
        }
        int varID_CLIENTE = 0;
        DateTime UltimoPago = DateTime.Now;
        int DiasCredito = 0;
        private void frmCliente_Load(object sender, EventArgs e)
        {
            
            try
            {
                
                if (varID_CLIENTE!=0)
                {
                    ReadData(varID_CLIENTE);
                }
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void ReadData(int prmID_CLIENTE)
        {
            OleDbConnection cnnReadData = new OleDbConnection(Class.clsMain.CnnStr);
            try
            {

                cnnReadData.Open();
                string varSQL = "SELECT * FROM CAT_CLIENTE WHERE ID_CLIENTE=" + prmID_CLIENTE + "";
                OleDbCommand cmdReadData = new OleDbCommand(varSQL, cnnReadData);
                OleDbDataReader drReadData;
                drReadData = cmdReadData.ExecuteReader();
                if (drReadData.Read())
                {
                    //Mostramos los datos      
                    txtRFC.Text = drReadData["RFC"].ToString();
                    txtCURP.Text = drReadData["CURP"].ToString();
                    txtNOMBRE.Text = drReadData["NOMBRE"].ToString();
                    txtDIRECCION.Text = drReadData["DOMICILIO"].ToString();
                    txtTELEFONO.Text = drReadData["TELEFONO"].ToString();
                    txtCP.Text = drReadData["CP"].ToString();
                    txtEMail.Text = drReadData["EMAIL"].ToString();
                    txtESTADO.Text =
                        drReadData["ID_ESTADO"].ToString();

                    txtMUNICIPIO.Text =
                        drReadData["ID_MUNICIPIO"].ToString();
                    txtLOCALIDAD.Text =
                        drReadData["ID_LOCALIDAD"].ToString();
              
                    txtLIM_CREDITO.Text = drReadData["LIM_CREDITO"].ToString();
                    UltimoPago = Convert.ToDateTime(drReadData["FECHA_PAGO"]);
                    txtFECHA_PAGO.Text = String.Format("{0:dd/MM/yyyy}",drReadData["FECHA_PAGO"]);
                    txtFECHA_VENTA.Text = String.Format("{0:dd/MM/yyyy}",drReadData["FECHA_VENTA"]);
                    txtDIAS_CREDITO.Text = drReadData["DIAS_CREDITO"].ToString();
                    DiasCredito = Convert.ToInt32(drReadData["DIAS_CREDITO"]);
                }
                drReadData.Close();
                cmdReadData.CommandText = "spSALDO_CLIENTE";
                cmdReadData.CommandType = CommandType.StoredProcedure;
                cmdReadData.Parameters.Add("prmID_CLIENTE", OleDbType.Integer).Value = prmID_CLIENTE;
                drReadData = cmdReadData.ExecuteReader();
                if (drReadData.Read()) {
                    txtSALDO.Text = String.Format("{0:C}", drReadData["RESTO"]);
                    txtCREDITO_DISPONIBLE.Text = 
                        String.Format("{0:C}", Convert.ToDouble(txtLIM_CREDITO.Text) - Convert.ToDouble(drReadData["RESTO"]));
                    TimeSpan tim = DateTime.Now.Subtract(UltimoPago);
                    if (tim.Days > DiasCredito) {
                        txtSALDO_VENCIDO.Text = String.Format("{0:C}", drReadData["RESTO"]);
                    }
                    else {
                        txtSALDO_VENCIDO.Text = String.Format("{0:C}", 0);
                    }
                }
                drReadData.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { cnnReadData.Close(); }
        }
      

       
        private bool fnCAT_CLIENTE(int prmID_CLIENTE, string prmRFC, string prmCURP,string prmNOMBRE, string prmDOMICILIO,
      string prmID_ESTADO, string prmID_MUNICIPIO, string prmID_LOCALIDAD, string prmUSER_LOGIN, string prmCP, 
            string prmTELEFONO, string prmEMAIL, string prmTIPO_CLIENTE, int prmCREDITO, double prmLIM_CREDITO, int prmDIAS_CREDITO)
        {
            try
            {
                OleDbConnection cnnCAT_CLIENTE = new OleDbConnection(Class.clsMain.CnnStr);
                cnnCAT_CLIENTE.Open();
                string varSQL_Insert = "INSERT INTO CAT_CLIENTE (NOMBRE,RFC,CURP,ID_ESTADO,"+
                    " ID_MUNICIPIO,ID_LOCALIDAD,DOMICILIO,USER_LOGIN,CP,TELEFONO,EMAIL,TIPO_CLIENTE,CREDITO,LIM_CREDITO,DIAS_CREDITO) "+
                    " VALUES('" + prmNOMBRE + "','" + prmRFC + "','"+ prmCURP +"'," +
                    "'" + prmID_ESTADO + "'," +
                    " '" + prmID_MUNICIPIO + "','" + prmID_LOCALIDAD + "','" + prmDOMICILIO + "'," +
                    "'" + prmUSER_LOGIN + "','" + prmCP + "','" + prmTELEFONO + "','" + prmEMAIL + "','" + prmTIPO_CLIENTE + "'," + prmCREDITO + "," + prmLIM_CREDITO + "," + prmDIAS_CREDITO + ")";
                string varSQL_Update = "UPDATE CAT_CLIENTE SET " +
                    " NOMBRE='" + prmNOMBRE + "',RFC='" + prmRFC + "',CURP='" + prmCURP + "'," +
                    " ID_ESTADO='" + prmID_ESTADO + "'," +
                    " ID_MUNICIPIO='" + prmID_MUNICIPIO + "',ID_LOCALIDAD='" + prmID_LOCALIDAD + "',DOMICILIO='" + prmDOMICILIO + "'," +
                    " USER_LOGIN='" + prmUSER_LOGIN + "',CP='" + prmCP + "',TELEFONO='" + prmTELEFONO + "',EMAIL='" + prmEMAIL + "'," +
                    " CREDITO=" + prmCREDITO + ",LIM_CREDITO=" + prmLIM_CREDITO + ", DIAS_CREDITO=" + prmDIAS_CREDITO + "" +
                    " WHERE ID_CLIENTE=" + prmID_CLIENTE + "";
                OleDbCommand cmdCAT_CLIENTE = new OleDbCommand();
                cmdCAT_CLIENTE.Connection = cnnCAT_CLIENTE;
                if (varID_CLIENTE == 0)
                {
                    //Nuevo
                    cmdCAT_CLIENTE.CommandText = varSQL_Insert;
                }
                else { 
                    //Editar
                    cmdCAT_CLIENTE.CommandText = varSQL_Update;
                }
                cmdCAT_CLIENTE.ExecuteNonQuery();
                cmdCAT_CLIENTE.Dispose();
                cnnCAT_CLIENTE.Close();
                cnnCAT_CLIENTE.Dispose();
                return (true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "NUEVO");
                return (false);
            }


        }
        void Grabar()
        {
            try
            {
                if (fnCAT_CLIENTE(varID_CLIENTE,
                           Strings.SafeSqlLikeClauseLiteral(txtRFC.Text),
                           Strings.SafeSqlLikeClauseLiteral(txtCURP.Text),
                           Strings.SafeSqlLikeClauseLiteral(txtNOMBRE.Text),
                           Strings.SafeSqlLikeClauseLiteral(txtDIRECCION.Text),
                           Strings.SafeSqlLikeClauseLiteral(txtESTADO.Text), 
                           Strings.SafeSqlLikeClauseLiteral(txtMUNICIPIO.Text),
                           Strings.SafeSqlLikeClauseLiteral(txtLOCALIDAD.Text),
                           frmLogin._USER_LOGIN,
                           Strings.SafeSqlLikeClauseLiteral(txtCP.Text),
                           Strings.SafeSqlLikeClauseLiteral(txtTELEFONO.Text),
                           Strings.SafeSqlLikeClauseLiteral(txtEMail.Text),
                           "PP",1,
                           Convert.ToDouble(txtLIM_CREDITO.Text),
                           Convert.ToInt32(txtDIAS_CREDITO.Text)))
                {
                    _Accion = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
              //Si se están editando los datos
            Grabar();
         

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}