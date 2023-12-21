using System;
using System.Data;
using System.Data.OleDb;
using POSApp.Class;
using POSDLL; using POSDLL.Windows.Forms; using POSDLL.Security; using POSDLL.Reporting; using POSDLL.Ticket;

/// <summary>
/// Summary description for clsProveedor
/// </summary>
public class clsProveedor
{
	public clsProveedor()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static bool fnBuscaProveedor(string prmID_PROVEEDOR)
    {

        try
        {
            OleDbConnection cnnBuscaProveedor = new OleDbConnection(clsMain.CnnStr);
            cnnBuscaProveedor.Open();
            string varSQL = "SELECT COUNT(*) FROM CAT_PROVEEDOR WHERE ID_PROVEEDOR = '" + prmID_PROVEEDOR + "'";
            OleDbCommand cmdBuscaProveedor = new OleDbCommand(varSQL, cnnBuscaProveedor);
            int Valor = Convert.ToInt32(cmdBuscaProveedor.ExecuteScalar());
            cnnBuscaProveedor.Close();
            cnnBuscaProveedor.Dispose();
            cmdBuscaProveedor.Dispose();
            if (Valor == 0)
            {
                //No existe           
                return (false);
            }
            else
            {
                //Si existe                
                return (true);
            }
            
        }
        catch 
        {            
            return (false);
        }
    }
}
