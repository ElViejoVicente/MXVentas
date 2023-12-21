using System;
using System.Data;
using System.Data.OleDb;
using POSApp.Class;

using POSDLL; using POSDLL.Windows.Forms; using POSDLL.Security; using POSDLL.Reporting; using POSDLL.Ticket;
/// <summary>
/// Summary description for clsEmpleado
/// </summary>
public class clsEmpleado
{
	public clsEmpleado()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static bool fnBuscaEmpleado(string prmID_EMPLEADO)
    {
      
        try
        {
            OleDbConnection cnnBuscaEmpleado = new OleDbConnection(clsMain.CnnStr);
            cnnBuscaEmpleado.Open();
            string varSQL = "SELECT ID_EMPLEADO,LTRIM(RTRIM(NOMBRE)) + ' ' + LTRIM(RTRIM(PATERNO)) + ' ' + LTRIM(RTRIM(MATERNO)) AS NOMBRE " +
                " FROM CAT_EMPLEADO WHERE ID_EMPLEADO = '" + prmID_EMPLEADO + "'";
            DataSet dsBuscaEmpleado = new DataSet("dsBuscaEmpleado");
            dsBuscaEmpleado.Clear();
            OleDbDataAdapter daBuscaEmpleado = new OleDbDataAdapter(varSQL, cnnBuscaEmpleado);
            daBuscaEmpleado.Fill(dsBuscaEmpleado, "CAT_EMPLEADO");
            if (dsBuscaEmpleado.Tables["CAT_EMPLEADO"].Rows.Count == 0)
            {
                //No existe              
                dsBuscaEmpleado.Clear();
                dsBuscaEmpleado.Dispose();
                daBuscaEmpleado.Dispose();
                cnnBuscaEmpleado.Close();
                cnnBuscaEmpleado.Dispose();
                return (false);
            }
            else
            {
                //Si existe
                dsBuscaEmpleado.Clear();
                dsBuscaEmpleado.Dispose();
                daBuscaEmpleado.Dispose();
                cnnBuscaEmpleado.Close();
                cnnBuscaEmpleado.Dispose();
                return (true);
            }            
        }
        catch
        {
           
            return (false);
        }
    }
}
