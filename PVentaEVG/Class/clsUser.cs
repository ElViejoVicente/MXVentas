using System;
using System.Data;
using System.Data.OleDb;
using POSApp.Class;
using POSDLL; using POSDLL.Windows.Forms; using POSDLL.Security; using POSDLL.Reporting; using POSDLL.Ticket;
/// <summary>
/// Summary description for clsUser
/// </summary>
public class clsUser
{
	public clsUser()
	{
		//
		// TODO: Add constructor logic here
		//
        
	}
    /// <summary>
    /// Función para saber si un usuario existe
    /// </summary>
    /// <param name="prmUSER_LOGIN">Nombre del usuario a buscar</param>
    /// <returns></returns>
    public static bool fnBuscaUsuario(string prmUSER_LOGIN)
    {

        try
        {
            OleDbConnection cnnBuscaUsuario = new OleDbConnection(clsMain.CnnStr);
            cnnBuscaUsuario.Open();
            string varSQL = "SELECT COUNT(*) FROM USERS WHERE USER_LOGIN = '" + prmUSER_LOGIN+ "'";
            OleDbCommand cmdBuscaUsuario = new OleDbCommand(varSQL, cnnBuscaUsuario);
            int Valor = Convert.ToInt32(cmdBuscaUsuario.ExecuteScalar());
            cnnBuscaUsuario.Close();
            cnnBuscaUsuario.Dispose();
            cmdBuscaUsuario.Dispose();
            if (Valor!= 0)
            {
                //Si           
                return (true);
            }
            else
            {
                //No existe
                return (false);
            }
        }
        catch
        {
            //Error
            return (false);
        }
    }
    public static string fnBuscaID_EMPLEADO(string prmUSER_LOGIN)
    {

        try
        {
            OleDbConnection cnnBuscaUsuario = new OleDbConnection(clsMain.CnnStr);
            cnnBuscaUsuario.Open();
            string varSQL = "SELECT ID_EMPLEADO FROM USERS WHERE USER_LOGIN = '" + prmUSER_LOGIN + "'";
            OleDbCommand cmdBuscaUsuario = new OleDbCommand(varSQL, cnnBuscaUsuario);
            string Valor = Convert.ToString(cmdBuscaUsuario.ExecuteScalar());
            cmdBuscaUsuario.Dispose();
            cnnBuscaUsuario.Close();
            cnnBuscaUsuario.Dispose();
            return (Valor);
        }
        catch
        {
            //Error
            return ("");
        }
    }
}
