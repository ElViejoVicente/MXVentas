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
    public partial class frmProveedor : Telerik.WinControls.UI.RadForm
    {
        public frmProveedor()
        {
            InitializeComponent();
            varID_PROVEEDOR = "";
        }
        public frmProveedor(string prmID_PROVEEDOR)
        {
            InitializeComponent();
            varID_PROVEEDOR = prmID_PROVEEDOR;
        }
        string varID_PROVEEDOR = "";
        private void frmProveedor_Load(object sender, EventArgs e)
        {
            try
            {
                if (varID_PROVEEDOR == "")
                {
                    //btnFoto.Visible = false;
                    //imgFoto.Visible = false;
                   
                    
                }
                else
                {
                    //aqui si vamos a modificar                   
                    //btnFoto.Visible = true;
                    txtID_PROVEEDOR.Text = varID_PROVEEDOR;
                    txtID_PROVEEDOR.Enabled = false;
                    
                    ReadData(varID_PROVEEDOR);
                    //imgFoto.ImageUrl = "imageprovider.asp?ID_PROVEEDOR=" + Request.Params["ID_PROVEEDOR"];
                    //imgFoto.Width = 90;
                    //imgFoto.Height = 100;
                    
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void ReadData(string prmID_PROVEEDOR)
        {
            try
            {
                OleDbConnection cnnReadData = new OleDbConnection(Class.clsMain.CnnStr);
                cnnReadData.Open();
                string varSQL = "SELECT * FROM CAT_PROVEEDOR WHERE ID_PROVEEDOR='" + prmID_PROVEEDOR + "'";
                OleDbCommand cmdReadData = new OleDbCommand(varSQL, cnnReadData);
                OleDbDataReader drReadData;
                drReadData = cmdReadData.ExecuteReader();
                drReadData.Read();
                //Mostramos los datos      
                txtRFC.Text = drReadData["RFC"].ToString();
                txtNOMBRE.Text = drReadData["DESC_PROVEEDOR"].ToString();
                txtATENCION.Text = drReadData["VENTAS"].ToString();
                txtDIRECCION.Text = drReadData["DIRECCION"].ToString();
                txtTELEFONO.Text = drReadData["TELEFONO1"].ToString();
                txtTELEFONO2.Text = drReadData["TELEFONO2"].ToString();
                txtTELEFONO3.Text = drReadData["TELEFONO3"].ToString();
                txtFAX1.Text = drReadData["FAX1"].ToString();
                txtFAX2.Text = drReadData["FAX2"].ToString();
                txtCP.Text = drReadData["CP"].ToString();
                txtNOTAS.Text = drReadData["NOTAS"].ToString();
                txtN_CLIENTE.Text = drReadData["N_CLIENTE"].ToString();
                //banco
                txtBANCO1.Text = drReadData["BANCO"].ToString();
                txtN_CUENTA1.Text = drReadData["N_CUENTA"].ToString();
                txtSUCURSAL1.Text = drReadData["SUCURSAL"].ToString();
                txtREFERENCIA1.Text = drReadData["REFERENCIA"].ToString();
                txtBANCO2.Text = drReadData["BANCO2"].ToString();
                txtN_CUENTA2.Text = drReadData["N_CUENTA2"].ToString();
                txtSUCURSAL2.Text = drReadData["SUCURSAL2"].ToString();
                txtREFERENCIA2.Text = drReadData["REFERENCIA2"].ToString();


                txtESTADO.Text =drReadData["ID_ESTADO"].ToString();
                
                txtMUNICIPIO.Text =drReadData["ID_MUNICIPIO"].ToString();

                txtLOCALIDAD.Text =drReadData["ID_LOCALIDAD"].ToString();
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
        private bool fnCatProveedor(string prmID_PROVEEDOR,string  prmDESC_PROVEEDOR,string prmVENTAS,string prmDIRECCION,string prmTELEFONO1,string prmTELEFONO2,string prmTELEFONO3, 
string prmFAX1,string  prmFAX2,string  prmBANCO,string  prmN_CUENTA,string prmREFERENCIA,string prmSUCURSAL,string prmBANCO2,string prmN_CUENTA2,string prmSUCURSAL2, 
string prmREFERENCIA2,string  prmN_CLIENTE,string prmATENCION,string prmCIUDAD,string prmCP,string prmNOTAS,string prmRFC,string prmID_ESTADO,string prmID_MUNICIPIO,
string prmID_LOCALIDAD, string prmUSER_LOGIN)
        {
            try
            {
                OleDbConnection cnnAddNew = new OleDbConnection(Class.clsMain.CnnStr);
                string varSQL = "";
                if (varID_PROVEEDOR == "") {
                //nuevo
                    varSQL = "INSERT INTO CAT_PROVEEDOR(ID_PROVEEDOR, DESC_PROVEEDOR, VENTAS, DIRECCION, TELEFONO1, TELEFONO2, TELEFONO3, " +
                        "FAX1, FAX2, BANCO, N_CUENTA, REFERENCIA, SUCURSAL, BANCO2, N_CUENTA2, SUCURSAL2, " +
                        "REFERENCIA2, N_CLIENTE, ATENCION, CIUDAD, CP, NOTAS, RFC, ID_ESTADO, ID_MUNICIPIO," +
                        "ID_LOCALIDAD,  USER_LOGIN)" +
                        " VALUES ('" + prmID_PROVEEDOR + "', '" + prmDESC_PROVEEDOR + "', '" + prmVENTAS + "', '" + prmDIRECCION + "', '" + prmTELEFONO1 + "', '" + prmTELEFONO2 + "', '" + prmTELEFONO3 + "', " +
                        "'" + prmFAX1 + "', '" + prmFAX2 + "', '" + prmBANCO + "', '" + prmN_CUENTA + "', '" + prmREFERENCIA + "', '" + prmSUCURSAL + "', '" + prmBANCO2 + "', '" + prmN_CUENTA2 + "', '" + prmSUCURSAL2 + "', " +
                        "'" + prmREFERENCIA2 + "', '" + prmN_CLIENTE + "', '" + prmATENCION + "', '" + prmCIUDAD + "', '" + prmCP + "', '" + prmNOTAS + "', '" + prmRFC + "', '" + prmID_ESTADO + "', '" + prmID_MUNICIPIO + "'," +
                        "'" + prmID_LOCALIDAD + "',  '" + prmUSER_LOGIN + "')";
                }
                else {
                //editar
                    varSQL = "UPDATE CAT_PROVEEDOR SET "+
                         "ID_PROVEEDOR='" + prmID_PROVEEDOR + "',DESC_PROVEEDOR= '" + prmDESC_PROVEEDOR + "',VENTAS= '" + prmVENTAS + "',DIRECCION= '" + prmDIRECCION + "',TELEFONO1= '" + prmTELEFONO1 + "',TELEFONO2= '" + prmTELEFONO2 + "',TELEFONO3= '" + prmTELEFONO3 + "', " +
                        "FAX1='" + prmFAX1 + "', FAX2='" + prmFAX2 + "',BANCO= '" + prmBANCO + "',N_CUENTA= '" + prmN_CUENTA + "',REFERENCIA= '" + prmREFERENCIA + "',SUCURSAL= '" + prmSUCURSAL + "',BANCO2= '" + prmBANCO2 + "',N_CUENTA2= '" + prmN_CUENTA2 + "',SUCURSAL2= '" + prmSUCURSAL2 + "', " +
                        "REFERENCIA2='" + prmREFERENCIA2 + "',N_CLIENTE= '" + prmN_CLIENTE + "',ATENCION= '" + prmATENCION + "',CIUDAD= '" + prmCIUDAD + "',CP= '" + prmCP + "',NOTAS= '" + prmNOTAS + "',RFC= '" + prmRFC + "',ID_ESTADO= '" + prmID_ESTADO + "',ID_MUNICIPIO= '" + prmID_MUNICIPIO + "'," +
                        "ID_LOCALIDAD='" + prmID_LOCALIDAD + "',USER_LOGIN= '" + prmUSER_LOGIN + "'" +
                        " WHERE ID_PROVEEDOR='"+ prmID_PROVEEDOR +"'";
                }
                cnnAddNew.Open();
                OleDbCommand cmdAddNew = new OleDbCommand(varSQL, cnnAddNew);
                cmdAddNew.ExecuteNonQuery();
                cnnAddNew.Close();
                cmdAddNew.Dispose();
                cnnAddNew.Dispose();
                return (true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false);
            }
        }


        void Grabar()
        {
            try
            {
                if (fnCatProveedor(txtID_PROVEEDOR.Text,txtNOMBRE.Text,txtATENCION.Text,txtDIRECCION.Text,txtTELEFONO.Text,
                    txtTELEFONO2.Text,txtTELEFONO3.Text,txtFAX1.Text,txtFAX2.Text,txtBANCO1.Text,txtN_CUENTA1.Text,txtREFERENCIA1.Text,
                    txtSUCURSAL1.Text,txtBANCO2.Text,txtN_CUENTA2.Text,txtSUCURSAL2.Text,txtREFERENCIA2.Text,txtN_CLIENTE.Text,
                    txtATENCION.Text,"CIUDAD",txtCP.Text,txtNOTAS.Text,txtRFC.Text,txtESTADO.Text,
                    txtMUNICIPIO.Text,txtLOCALIDAD.Text,frmLogin._USER_LOGIN))
                {
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
            if (varID_PROVEEDOR != "")
            {
                //Si se están editando los datos
                Grabar();
            }
            else
            {
                //si es un registro nuevo
                if (clsProveedor.fnBuscaProveedor(Strings.SafeSqlLikeClauseLiteral(txtID_PROVEEDOR.Text)))
                {
                    //la clave de empleado ya existe
                    MessageBox.Show("¡¡¡El proveedor ya existe!!!");
                }
                else
                {
                    Grabar();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

 
        

       
    }
}