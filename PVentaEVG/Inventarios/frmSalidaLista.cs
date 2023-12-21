using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POSDLL; using POSDLL.Windows.Forms; using POSDLL.Security; using POSDLL.Reporting; using POSDLL.Ticket;
using System.Data.OleDb;
using System.IO;
using Microsoft.Reporting;
using Microsoft.Reporting.WinForms;
namespace POSApp.Forms
{
    public partial class frmSalidaLista : Telerik.WinControls.UI.RadForm
    {
        //contolamos q solo se abra una vez
        private static frmSalidaLista m_FormDefInstance;
        public static frmSalidaLista DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmSalidaLista();
                return m_FormDefInstance;
            }
            set { m_FormDefInstance = value; }
        }
        public frmSalidaLista()
        {
            InitializeComponent();
        }
        string DescFiltro = "";
        string filtroSQL = "";
        private void frmSalidaLista_Load(object sender, EventArgs e)
        {
            lvSalida.DoubleClick += new EventHandler(lvSalida_DoubleClick);
            Inicializa();
            Encabezados();
            ReadData(cboCOLMUNAS.SelectedValue.ToString(), fnGetAscOrder(cboORDER.Text));
        }

        void lvSalida_DoubleClick(object sender, EventArgs e)
        {
            PrintSelected();
        }
        private void btnFilter_Click(object sender, EventArgs e)
        {
            //Filtrar
            Forms.frmFiltro mi_frmFiltroEntrada = new frmFiltro("FILTRO_SALIDAS");
            mi_frmFiltroEntrada.StartPosition = FormStartPosition.CenterScreen;
            mi_frmFiltroEntrada.ShowDialog();
            ReadData(cboCOLMUNAS.SelectedValue.ToString(), fnGetAscOrder(cboORDER.Text));
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
        private void Inicializa()
        {
            try
            {
                DataSet dsInicializa = new DataSet();
                OleDbConnection cnnInicializa = new OleDbConnection(Class.clsMain.CnnStr);
                cnnInicializa.Open();
                //MARCA
                OleDbDataAdapter daCol = new OleDbDataAdapter("SELECT * FROM COLUMNAS WHERE CLASIFICACION='SALIDAS'", cnnInicializa);
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
        private void Encabezados()
        {
            lvSalida.View = View.Details;
            lvSalida.Columns.Add("Folio", 90, HorizontalAlignment.Left);
            lvSalida.Columns.Add("Empleado", 280, HorizontalAlignment.Left);
            lvSalida.Columns.Add("Fecha Salida", 100, HorizontalAlignment.Left);
            lvSalida.Columns.Add("Observaciones", 250, HorizontalAlignment.Left);

        }
        private void FiltroSQL()
        {
            try
            {
                System.DateTime varFECHA_ACTUAL = System.DateTime.Now;
                bool varFILTRO = Convert.ToBoolean(AppSettings.GetValue("FILTRO_SALIDAS", "FILTRO", Convert.ToString(false)));
                bool varFILTRO_HOY = Convert.ToBoolean(AppSettings.GetValue("FILTRO_SALIDAS", "HOY", Convert.ToString(false)));
                System.DateTime varFECHA_INI = Convert.ToDateTime(AppSettings.GetValue("FILTRO_SALIDAS", "FECHA_INI", Convert.ToString(varFECHA_ACTUAL)));
                System.DateTime varFECHA_FIN = Convert.ToDateTime(AppSettings.GetValue("FILTRO_SALIDAS", "FECHA_FIN", Convert.ToString(varFECHA_ACTUAL)));
                if (varFILTRO)
                {
                    //Se supone que hay un filtro, hay que checar si es para hoy o por un rango de fechas
                    if (varFILTRO_HOY)
                    {
                        //el filtro es para mostrar solo lo de hoy
                        filtroSQL = " AND FECHA_SALIDA between #" + ISODates.MSAccessDateINI(DateTime.Now) + "#  and #" + ISODates.MSAccessDateFIN(DateTime.Now) + "#";
                        DescFiltro = "Información de hoy";
                    }
                    else
                    {
                        //el filtro es por un rango de fechas
                        DescFiltro = String.Format("Información entre las fechas  {0} y  {1}", varFECHA_INI.Date.ToLongDateString(), varFECHA_FIN.Date.ToLongDateString());
                        filtroSQL = " AND FECHA_SALIDA BETWEEN #" + ISODates.MSAccessDateINI(varFECHA_INI) + "# and   #" + ISODates.MSAccessDateFIN(varFECHA_FIN) + "#";
                    }
                }
                else
                {
                    //no se aplica filtro de nigun tipo
                    DescFiltro = "Sin filtro";
                    filtroSQL = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                filtroSQL = "";
            }
        }
        private void ReadData(string prmCAMPO, string prmORDEN)
        {
            //Este procedimiento lee los datos que se tranferirán y los mostrará en forma de
            //lista en el ListView
            FiltroSQL();
            try
            {
                string varSQL = "SELECT FOLIO_SALIDA,EMPLEADO,FECHA_SALIDA,OBSERVACIONES  " +
                    " FROM vSALIDA WHERE FOLIO_SALIDA IN(SELECT DISTINCT FOLIO_SALIDA FROM SALIDA_DETALLE) ";



                //Si la conexion esta abierta la cerramos; en caso contrario, la abrimos
                OleDbConnection cnnReadData = new OleDbConnection(Class.clsMain.CnnStr);
                if (cnnReadData.State == ConnectionState.Open) cnnReadData.Close(); else cnnReadData.Open();
                int I = 0;
                OleDbCommand cmdReadData = new OleDbCommand(varSQL + filtroSQL + " ORDER BY " + prmCAMPO + " " + prmORDEN + "", cnnReadData);
                OleDbDataReader drReadData;
                drReadData = cmdReadData.ExecuteReader();
                lvSalida.Items.Clear();
                while (drReadData.Read())
                {
                    lvSalida.Items.Add(drReadData["FOLIO_SALIDA"].ToString());
                    lvSalida.Items[I].SubItems.Add(drReadData["EMPLEADO"].ToString());
                    lvSalida.Items[I].SubItems.Add(String.Format("{0:d}",drReadData["FECHA_SALIDA"]));
                    lvSalida.Items[I].SubItems.Add(drReadData["OBSERVACIONES"].ToString());
                    I += 1;
                }
                this.Text = "Salidas: " + I.ToString() + ", Filtro: " + DescFiltro;
                drReadData.Close();
                cmdReadData.Dispose();
                cnnReadData.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ReadData(cboCOLMUNAS.SelectedValue.ToString(), fnGetAscOrder(cboORDER.Text));
        }
        private void PrintSelected()
        {
            int varFOLIO;
            try
            {
                if (lvSalida.Items.Count != 0)
                {
                    varFOLIO = Convert.ToInt32(lvSalida.SelectedItems[0].Text);
                    ImprimeSalida(varFOLIO);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("You must select an element from the list. \nError Description: \n" + ex.Message, "Invalid Operation" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public static void ImprimeSalida(int prmFOLIO_SALIDA)
        {
            try
            {
               
                string _fileName = AppSettings.GetValue("Config", "ReportsFolder", Application.StartupPath);
                _fileName += "\\rptSalida.rdlc";
                if (!File.Exists(_fileName))
                {
                    MessageBox.Show(String.Format("No se encuentra \n{0}\nRevise por favor", _fileName));
                    return;
                }
                //AHORA MOSTRAMOS EL REPORTE
                OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
                cnn.Open();
                DataSet dsReporte = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM [vSALIDA_DETALLE] WHERE FOLIO_SALIDA= " + prmFOLIO_SALIDA + "", cnn);
                da.Fill(dsReporte, "dsRptSalidaDetalle");
                if (dsReporte.Tables["dsRptSalidaDetalle"].Rows.Count == 0)
                {
                    cnn.Close();
                    MessageBox.Show("No hay Datos en la factura");
                    return;
                }

                Forms.frmReports frm = new Forms.frmReports();

                frm.rvDoc.LocalReport.DataSources.Clear();
                frm.rvDoc.LocalReport.Dispose();
                frm.rvDoc.Reset();
                frm.rvDoc.LocalReport.DataSources.Add(new ReportDataSource("dsRptSalidaDetalle", dsReporte.Tables["dsRptSalidaDetalle"]));
                frm.rvDoc.LocalReport.ReportPath = _fileName;
                //parametros
                List<ReportParameter> param = new List<ReportParameter>();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM vSALIDA WHERE FOLIO_SALIDA=" + prmFOLIO_SALIDA + "", cnn);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ReportParameter pFOLIO_SALIDA = new ReportParameter();
                    pFOLIO_SALIDA.Name = "prmFOLIO_SALIDA";
                    pFOLIO_SALIDA.Values.Add(prmFOLIO_SALIDA.ToString());
                    param.Add(pFOLIO_SALIDA);
                    ReportParameter pFECHA_SALIDA = new ReportParameter();
                    pFECHA_SALIDA.Name = "prmFECHA_SALIDA";
                    pFECHA_SALIDA.Values.Add(dr["FECHA_SALIDA"].ToString());
                    param.Add(pFECHA_SALIDA);
                   
                    ReportParameter pEMPLEADO = new ReportParameter();
                    pEMPLEADO.Name = "prmEMPLEADO";
                    pEMPLEADO.Values.Add(dr["EMPLEADO"].ToString());
                    param.Add(pEMPLEADO);
                    ReportParameter pOBSERVACIONES = new ReportParameter();
                    pOBSERVACIONES.Name = "prmOBSERVACIONES";
                    pOBSERVACIONES.Values.Add(dr["OBSERVACIONES"].ToString());
                    param.Add(pOBSERVACIONES);
                    
                   
                }
                dr.Close();
                //agregamos los parametros a la coleccion
                frm.rvDoc.LocalReport.SetParameters(param);
                frm.rvDoc.RefreshReport();
                frm.ShowDialog();
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading report", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnPrintSelected_Click(object sender, EventArgs e)
        {
            PrintSelected();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void c_mnuImprimirSeleccionado_Click(object sender, EventArgs e)
        {
            PrintSelected();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmSalida frm = new frmSalida();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }
    }
}
