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
    public partial class frmEmpleado : Telerik.WinControls.UI.RadForm
    {
        public frmEmpleado()
        {
            InitializeComponent();
            varID_EMPLEADO = "";
        }
        public frmEmpleado(string prmID_EMPLEADO)
        {
            InitializeComponent();
            varID_EMPLEADO = prmID_EMPLEADO;
        }
        string varID_EMPLEADO="";
        public static bool _Accion = false;
        private void frmEmpleado_Load(object sender, EventArgs e)
        {
            try
            {
                if (varID_EMPLEADO == "")
                {

                    //btnFoto.Visible = false;
                    //imgFoto.Visible = false;
                    txtID_EMPLEADO.Text = "";
                    //txtID_EMPLEADO.Enabled = false;
                    Inicializa();
                   

                }
                else
                {
                    //aqui si vamos a modificar                    
                    //btnFoto.Visible = true;
                    txtID_EMPLEADO.Text = varID_EMPLEADO;
                    txtID_EMPLEADO.Enabled = false;
                    Inicializa();
                    ReadData(varID_EMPLEADO);
                    //imgFoto.ImageUrl = "imageclient.asp?ID_CLIENTE=" + Request.Params["ID_CLIENTE"];
                    //imgFoto.Width = 90;
                    //imgFoto.Height = 100;

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        void Inicializa()
        {
            try
            {
                // ESTE ES EL CODIGO PARA INICIALIZAR EL FORMULARIO   
                OleDbConnection cnnInicializa = new OleDbConnection(Class.clsMain.CnnStr);
                if (cnnInicializa.State == ConnectionState.Open)
                {
                    cnnInicializa.Open();
                }
                else
                {
                    cnnInicializa.Close();
                }
                DataSet dsSexo = new DataSet("dsSexo");
                OleDbDataAdapter daSexo =
                    new OleDbDataAdapter("SELECT ID_SEXO,DESC_SEXO FROM CAT_SEXO", cnnInicializa);
                dsSexo.Clear();
                daSexo.Fill(dsSexo, "CAT_SEXO");
                cboID_SEXO.DataSource = dsSexo.Tables["CAT_SEXO"];
                cboID_SEXO.DisplayMember = "DESC_SEXO";
                cboID_SEXO.ValueMember = "ID_SEXO";
                daSexo.Dispose();

                /**/
                //CODIGO para el estado civil
                DataSet dsEdoCivil = new DataSet("dsEdoCivil");
                OleDbDataAdapter daEdoCivil =
                    new OleDbDataAdapter("SELECT ID_ESTADO_CIVIL,DESC_ESTADO_CIVIL FROM CAT_ESTADO_CIVIL", cnnInicializa);
                dsEdoCivil.Clear();
                daEdoCivil.Fill(dsEdoCivil, "CAT_ESTADO_CIVIL");
                cboID_ESTADO_CIVIL.DataSource = dsEdoCivil.Tables["CAT_ESTADO_CIVIL"];
                cboID_ESTADO_CIVIL.DisplayMember = "DESC_ESTADO_CIVIL";
                cboID_ESTADO_CIVIL.ValueMember = "ID_ESTADO_CIVIL";              
                daEdoCivil.Dispose();
                
                cnnInicializa.Close();
                cnnInicializa.Dispose();
                


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Initializing");
            }
        }

        
        private void ReadData(string prmID_EMPLEADO)
        {
            try
            {
                OleDbConnection cnnReadData = new OleDbConnection(Class.clsMain.CnnStr);
                cnnReadData.Open();
                string varSQL = "SELECT * FROM CAT_EMPLEADO WHERE ID_EMPLEADO ='" + prmID_EMPLEADO + "'";
                OleDbCommand cmdReadData = new OleDbCommand(varSQL, cnnReadData);
                OleDbDataReader drReadData;
                drReadData = cmdReadData.ExecuteReader();
                drReadData.Read();
                //Mostramos los datos      
                txtCURP.Text = drReadData["CURP"].ToString();
                dtpFECHA_NAC.Value = Convert.ToDateTime(drReadData["FECHA_NAC"]);
                txtPATERNO.Text = drReadData["PATERNO"].ToString();
                txtMATERNO.Text = drReadData["MATERNO"].ToString();
                txtNOMBRE.Text = drReadData["NOMBRE"].ToString();
                txtDOMICILIO.Text = drReadData["DOMICILIO"].ToString();
                cboID_SEXO.SelectedValue =drReadData["ID_SEXO"].ToString();
                txtESTADO.Text =drReadData["ID_ESTADO"].ToString();
                
                txtMUNICIPIO.Text =drReadData["ID_MUNICIPIO"].ToString();
                
                txtLOCALIDAD.Text =drReadData["ID_LOCALIDAD"].ToString();
                cboID_ESTADO_CIVIL.SelectedValue =drReadData["ID_ESTADO_CIVIL"].ToString();
                chkACTIVO.Checked = Convert.ToBoolean(drReadData["ACTIVO"]);
                txtSALARIO.Text = drReadData["SALARIO"].ToString();
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
        private bool fnCAT_EMPLEADO(string prmID_EMPLEADO, string prmCURP, string prmPATERNO, string prmMATERNO, string prmNOMBRE, string prmDOMICILIO,
            int prmID_SEXO, string prmFECHA_NAC, string prmID_ESTADO, string prmID_MUNICIPIO, string prmID_LOCALIDAD, string prmUSER_LOGIN, int prmID_ESTADO_CIVIL,
            int prmACTIVO,double prmSALARIO)
        {
            try
            {
                OleDbConnection cnnCAT_EMPLEADO = new OleDbConnection(Class.clsMain.CnnStr);
                cnnCAT_EMPLEADO.Open();
                string varSQL_Update = "UPDATE CAT_EMPLEADO SET PATERNO='" + prmPATERNO + "'," +
                    "MATERNO='" + prmMATERNO + "',NOMBRE='" + prmNOMBRE + "',CURP='" + prmCURP + "'," +
                    " FECHA_NAC=#" + prmFECHA_NAC + "#,ID_SEXO=" + prmID_SEXO + ",ID_ESTADO_CIVIL=" + prmID_ESTADO_CIVIL + ", ID_ESTADO='" + prmID_ESTADO + "'," +
                    " ID_MUNICIPIO='" + prmID_MUNICIPIO + "',ID_LOCALIDAD='" + prmID_LOCALIDAD + "',DOMICILIO='" + prmDOMICILIO + "',USER_LOGIN='" + prmUSER_LOGIN + "'," +
                    "ACTIVO=" + prmACTIVO + ",SALARIO=" + prmSALARIO + "" +
                    " WHERE ID_EMPLEADO='"+ prmID_EMPLEADO +"'";
                string varSQL_Insert = "INSERT INTO CAT_EMPLEADO (ID_EMPLEADO,PATERNO,MATERNO,NOMBRE,CURP,"+
                    " FECHA_NAC,ID_SEXO,ID_ESTADO_CIVIL,ID_ESTADO,ID_MUNICIPIO,ID_LOCALIDAD,DOMICILIO,USER_LOGIN,ACTIVO,SALARIO)" +
                    " VALUES('" + prmID_EMPLEADO + "','" + prmPATERNO + "'," +
                    " '" + prmMATERNO + "','" + prmNOMBRE + "','" + prmCURP + "'," +
                    " #" + prmFECHA_NAC + "#," + prmID_SEXO + "," + prmID_ESTADO_CIVIL + ",'" + prmID_ESTADO + "'," +
                    " '" + prmID_MUNICIPIO + "','" + prmID_LOCALIDAD + "','" + prmDOMICILIO + "','" + prmUSER_LOGIN + "'," + prmACTIVO + "," + prmSALARIO + ")";
                string varSQL_Busca = "SELECT COUNT(ID_EMPLEADO) FROM CAT_EMPLEADO WHERE ID_EMPLEADO='"+ prmID_EMPLEADO +"'";
                OleDbCommand cmdCAT_EMPLEADO = new OleDbCommand();
                cmdCAT_EMPLEADO.Connection = cnnCAT_EMPLEADO;
                
                if (varID_EMPLEADO== "")
                {
                    //nuevo
                    cmdCAT_EMPLEADO.CommandText = varSQL_Insert;
                }
                else { 
                    //edición
                    cmdCAT_EMPLEADO.CommandText = varSQL_Update;
                }
                cmdCAT_EMPLEADO.ExecuteNonQuery();
                cmdCAT_EMPLEADO.Dispose();
                cnnCAT_EMPLEADO.Close();
                cnnCAT_EMPLEADO.Dispose();
                _Accion = true;
                return (true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "fnCAT_EMPLEADO");
                return (false);
            }


        }
        bool Validaciones() {
            if (txtID_EMPLEADO.Text == "")
            {
                MessageBox.Show("Debe introducir la clave de empleado", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtID_EMPLEADO.Focus();
                return (false);
               
            }
            else if (txtSALARIO.Text == "")
            {
                MessageBox.Show("Falta el salario","Faltan Datos",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                txtSALARIO.Focus();
                return (false);

            }
            else {
                return (true);
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (varID_EMPLEADO != "")
            {
                //Si se están editando los datos
                if (Validaciones())
                {
                    Grabar();
                }
            }
            else
            {
                //si es un registro nuevo
                if (Validaciones())
                {
                    if (clsEmpleado.fnBuscaEmpleado(Strings.SafeSqlLikeClauseLiteral(txtID_EMPLEADO.Text)))
                    {
                        //la clave de empleado ya existe
                        MessageBox.Show("¡¡¡La clave del empleado ya existe!!!","Datos duplicados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        Grabar();
                    }
                }
            }
        }
        void Grabar()
        {
            try
            {
                if (fnCAT_EMPLEADO(Strings.SafeSqlLikeClauseLiteral(txtID_EMPLEADO.Text),
                           Strings.SafeSqlLikeClauseLiteral(txtCURP.Text),
                           Strings.SafeSqlLikeClauseLiteral(txtPATERNO.Text),
                           Strings.SafeSqlLikeClauseLiteral(txtMATERNO.Text),
                           Strings.SafeSqlLikeClauseLiteral(txtNOMBRE.Text),
                           Strings.SafeSqlLikeClauseLiteral(txtDOMICILIO.Text),
                           Convert.ToInt32(cboID_SEXO.SelectedValue), 
                           ISODates.MSAccessDateINI(dtpFECHA_NAC.Value),
                           Strings.SafeSqlLikeClauseLiteral(txtESTADO.Text), 
                           Strings.SafeSqlLikeClauseLiteral(txtMUNICIPIO.Text),
                           Strings.SafeSqlLikeClauseLiteral(txtLOCALIDAD.Text), frmLogin._USER_LOGIN, 
                           Convert.ToInt32(cboID_ESTADO_CIVIL.SelectedValue),
                           Convert.ToInt32(chkACTIVO.Checked), Convert.ToDouble(txtSALARIO.Text)))
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}