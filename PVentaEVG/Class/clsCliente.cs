using System;
using System.Data;
using System.Data.OleDb;
using POSApp.Class;
using Maltrak;
using System.Windows.Forms;
using POSDLL; using POSDLL.Windows.Forms; using POSDLL.Security; using POSDLL.Reporting; using POSDLL.Ticket;
/// <summary>
/// Summary description for clsCliente
/// </summary>
public class clsCliente
{
    
	public clsCliente()
	{
		//
		// TODO: Add constructor logic here
		//

	}
   
    public static bool fnBuscaCliente(int prmID_CLIENTE)
    {

        try
        {
            var oDAL = new DAL(@"Data Source=MALTRAKALIEN\SQL2008R2;Initial Catalog=FacturacionMS;Persist Security Info=True;User ID=dev;Password=dev",@"C:\Proyectos\DiarTI\Diarti PV");
            //OleDbConnection cnnBuscaCliente = new OleDbConnection(clsMain.CnnStr);
            //cnnBuscaCliente.Open();
            string varSQL = "SELECT COUNT(ID_CLIENTE) FROM CAT_CLIENTE WHERE ID_CLIENTE = "+ prmID_CLIENTE +"";
            oDAL.ExecuteScalarStr(varSQL);
            //OleDbCommand cmdBuscaCliente = new OleDbCommand(varSQL, cnnBuscaCliente);
            //int var = Convert.ToInt32(cmdBuscaCliente.ExecuteScalar());
            int var = Convert.ToInt32(oDAL.ExecuteScalarStr(varSQL));
            //cmdBuscaCliente.Dispose();
            //cnnBuscaCliente.Close();
            //cnnBuscaCliente.Dispose();
            if (var == 0)
            {
                //No existe
                return (false);

            }
            else {
                //si existe
                return (true);
            }

        }
        catch
        {

            return (false);
        }
    }
    public static string fnBuscaNombreCliente(int prmID_CLIENTE)
    {

        try
        {
            //OleDbConnection cnnBuscaCliente = new OleDbConnection(clsMain.CnnStr);
            //cnnBuscaCliente.Open();
            //string varSQL = "SELECT NOMBRE FROM CAT_CLIENTE WHERE ID_CLIENTE = " + prmID_CLIENTE + "";
            //OleDbCommand cmdBuscaCliente = new OleDbCommand(varSQL, cnnBuscaCliente);
            //string var = Convert.ToString(cmdBuscaCliente.ExecuteScalar());
            //cmdBuscaCliente.Dispose();
            //cnnBuscaCliente.Close();
            //cnnBuscaCliente.Dispose();

             var oDAL = new DAL(@"Data Source=MALTRAKALIEN\SQL2008R2;Initial Catalog=FacturacionMS;Persist Security Info=True;User ID=dev;Password=dev",@"C:\Proyectos\DiarTI\Diarti PV");
            string varSQL ="SELECT NOMBRE FROM CAT_CLIENTE WHERE ID_CLIENTE = " + prmID_CLIENTE + "";
            oDAL.ExecuteScalarStr(varSQL);
            string var = Convert.ToString(oDAL.ExecuteScalarStr(varSQL));

            return (var);

        }
        catch
        {

            return ("");
        }
    }    
    public static double fnBuscaLimCredito(int prmID_CLIENTE)
    {
        try
        {
            //OleDbConnection cnnBuscaLimCredito = new OleDbConnection(clsMain.CnnStr);
            //cnnBuscaLimCredito.Open();
            //string varSQL = "SELECT LIM_CREDITO FROM CAT_CLIENTE WHERE ID_CLIENTE = " + prmID_CLIENTE + "";
            //OleDbCommand cmdBuscaLimCredito = new OleDbCommand(varSQL, cnnBuscaLimCredito);
            //double varRetorno = Convert.ToDouble(cmdBuscaLimCredito.ExecuteScalar());
            //cmdBuscaLimCredito.Dispose();
            //cnnBuscaLimCredito.Close();
            //cnnBuscaLimCredito.Dispose();
            var oDAL = new DAL(@"Data Source=MALTRAKALIEN\SQL2008R2;Initial Catalog=FacturacionMS;Persist Security Info=True;User ID=dev;Password=dev", @"C:\Proyectos\DiarTI\Diarti PV");
            string varSQL = "SELECT LIM_CREDITO FROM CAT_CLIENTE WHERE ID_CLIENTE = " + prmID_CLIENTE + "";
           oDAL.ExecuteScalarStr(varSQL);
           double varRetorno = Convert.ToDouble(oDAL.ExecuteScalarStr(varSQL));
            
            return (varRetorno);
        }
        catch
        {
            return (0);
        }
    }

}
