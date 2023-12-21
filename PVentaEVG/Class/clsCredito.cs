using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POSDLL; using POSDLL.Windows.Forms; using POSDLL.Security; using POSDLL.Reporting; using POSDLL.Ticket;
namespace POSApp.Class
{
    public class clsCredito
    {
        public bool fnCREDITO(int prmFOLIO_VENTA, double prmINT_MENSUAL, double prmCANTIDAD, string prmUSER_LOGIN, double prmPRIMER_PAGO,   OleDbConnection cnnCREDITO, OleDbTransaction myTran)
        {
            int RowCount = 0;
            int IdCliente = 0;
            double LimCredito = 0;
            bool Credito = false;
            double SaldoActual = 0;


            try
            {
                OleDbCommand cmdCREDITO = new OleDbCommand();
                cmdCREDITO.Connection = cnnCREDITO;
                cmdCREDITO.Transaction = myTran;
                //Validamos si existe la venta
                if (prmCANTIDAD <= prmPRIMER_PAGO) { throw (new Exception("Error, los datos no pueden considerarse como un crédito.\nLa cantidad a pagar es menor que el primer pago")); }
                cmdCREDITO.CommandText = "SELECT COUNT(*) FROM VENTA WHERE FOLIO=@FOLIO_VENTA";
                cmdCREDITO.Parameters.Add("@FOLIO_VENTA", OleDbType.Integer).Value = prmFOLIO_VENTA;
                RowCount = Convert.ToInt32(cmdCREDITO.ExecuteScalar());
                if (RowCount == 0) { throw (new Exception("El folio de la venta no existe")); }
                cmdCREDITO.Parameters.Clear();
                //obtenemos el ID del Cliente
                cmdCREDITO.CommandText = "SELECT ID_CLIENTE FROM VENTA WHERE FOLIO=@FOLIO_VENTA";
                cmdCREDITO.Parameters.Add("@FOLIO_VENTA", OleDbType.Integer).Value = prmFOLIO_VENTA;
                IdCliente = Convert.ToInt32(cmdCREDITO.ExecuteScalar());
                cmdCREDITO.Parameters.Clear();
                //Validamos si el cliente tiene Credito
                cmdCREDITO.CommandText = "SELECT CREDITO,LIM_CREDITO FROM CAT_CLIENTE WHERE ID_CLIENTE=@ID_CLIENTE";
                cmdCREDITO.Parameters.Add("@ID_CLIENTE", OleDbType.Integer).Value = IdCliente;
                OleDbDataReader dr = cmdCREDITO.ExecuteReader();
                if (dr.Read())
                {
                    LimCredito = Convert.ToDouble(dr["LIM_CREDITO"]);
                    Credito = Convert.ToBoolean(dr["CREDITO"]);
                }
                dr.Close();
                cmdCREDITO.Parameters.Clear();
                if (!Credito) { throw (new Exception("El Cliente no tiene habilitado el Crédito")); }
                //Validamos si el cliente tiene suficiente Crédito
                //Primero obtenemos su saldo actual
                cmdCREDITO.CommandText = "spSALDO_CLIENTE";
                cmdCREDITO.CommandType = CommandType.StoredProcedure;
                cmdCREDITO.Parameters.Add("@ID_CLIENTE", OleDbType.Integer).Value = IdCliente;
                dr = cmdCREDITO.ExecuteReader();
                if (dr.Read())
                {
                    SaldoActual = Convert.ToDouble(dr["RESTO"]);
                }
                dr.Close();
                cmdCREDITO.CommandType = CommandType.Text;
                cmdCREDITO.Parameters.Clear();
                if (((SaldoActual + prmCANTIDAD) - prmPRIMER_PAGO) > LimCredito) { throw (new Exception(String.Format("El Cliente supera su límite crediticio\n\nLímite de Crédito: {0:C}\nSaldo Actual: {1:C}\nCrédito solicitado: {2:C}", LimCredito, SaldoActual, prmCANTIDAD - prmPRIMER_PAGO))); }
                //verificamos que el credito no se repita
                cmdCREDITO.CommandText = "SELECT COUNT(*) FROM CREDITO WHERE FOLIO_VENTA=@FOLIO_VENTA";
                cmdCREDITO.Parameters.Add("@FOLIO_VENTA", OleDbType.Integer).Value = prmFOLIO_VENTA;
                RowCount = Convert.ToInt32(cmdCREDITO.ExecuteScalar());
                if (RowCount != 0) { throw (new Exception("Ya se ha registrado éste credito. El ticket solo puede registrarse una vez")); }
                cmdCREDITO.Parameters.Clear();
                //INSERTAMOS EL CREDITO
                cmdCREDITO.CommandText = "INSERT INTO CREDITO (FOLIO_VENTA,INT_MENSUAL,CANTIDAD,USER_LOGIN,PAGADO) VALUES(@FOLIO_VENTA,@INT_MENSUAL,@CANTIDAD,@USER_LOGIN,@PAGADO)";
                cmdCREDITO.Parameters.Add("@FOLIO_VENTA", OleDbType.Integer).Value = prmFOLIO_VENTA;
                cmdCREDITO.Parameters.Add("@INT_MENSUAL", OleDbType.Double).Value = prmINT_MENSUAL;
                cmdCREDITO.Parameters.Add("@CANTIDAD", OleDbType.Double).Value = prmCANTIDAD;
                cmdCREDITO.Parameters.Add("@USER_LOGIN", OleDbType.VarChar, 50).Value = prmUSER_LOGIN;
                cmdCREDITO.Parameters.Add("@PAGADO", OleDbType.Double).Value = prmPRIMER_PAGO;
                cmdCREDITO.ExecuteNonQuery();
                cmdCREDITO.Parameters.Clear();
                //PAGO
                cmdCREDITO.CommandText = "INSERT INTO PAGO_CREDITO (FOLIO_VENTA,CANTIDAD,USER_LOGIN,OBSERVACIONES) VALUES(@FOLIO_VENTA,@CANTIDAD,@USER_LOGIN,@OBSERVACIONES)";
                cmdCREDITO.Parameters.Add("@FOLIO_VENTA", OleDbType.Integer).Value = prmFOLIO_VENTA;
                cmdCREDITO.Parameters.Add("@CANTIDAD", OleDbType.Double).Value = prmPRIMER_PAGO;
                cmdCREDITO.Parameters.Add("@USER_LOGIN", OleDbType.VarChar, 50).Value = prmUSER_LOGIN;
                cmdCREDITO.Parameters.Add("@OBSERVACIONES", OleDbType.VarChar, 50).Value = "PRIMER PAGO";
                cmdCREDITO.ExecuteNonQuery();
                cmdCREDITO.Parameters.Clear();
                //ACTUALIZAMOS LAFECHA DE PAGO DEL CLIENTE
                cmdCREDITO.CommandText = "UPDATE CAT_CLIENTE SET FECHA_PAGO=NOW() WHERE ID_CLIENTE=@ID";
                cmdCREDITO.Parameters.Add("@ID", OleDbType.Integer).Value = IdCliente;
                cmdCREDITO.ExecuteNonQuery();
                cmdCREDITO.Parameters.Clear();
                //imprimimos el ticket
                if (Convert.ToBoolean(AppSettings.GetValue("Ticket", "PrintTicket", "false")))
                {
                    ImprimeTicketCredito(prmFOLIO_VENTA, myTran, cnnCREDITO);
                }

                return (true);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
     
        public  void ImprimeTicketCredito(int prmFolioCredito, OleDbTransaction tran, OleDbConnection cnn)
        {
          
            try
            {

                Ticket ticket = new Ticket();
                if ((AppSettings.GetValue("Ticket", "TicketImage", "") != "") && (System.IO.File.Exists(AppSettings.GetValue("Ticket", "TicketImage", ""))))
                {
                    ticket.HeaderImage = System.Drawing.Image.FromFile(AppSettings.GetValue("Ticket", "TicketImage", "")); //esta propiedad no es obligatoria 
                }
                ticket.FontName = AppSettings.GetValue("Ticket", "FontName", "Courier New");
                ticket.FontSize = Convert.ToDouble(AppSettings.GetValue("Ticket", "FontSize", "7"));
                ticket.MaxChar = Convert.ToInt32(AppSettings.GetValue("Ticket", "MaxChar", "40"));
                ticket.MaxCharDescription = Convert.ToInt32(AppSettings.GetValue("Ticket", "MaxCharDescription", "20"));
                ticket.DrawItemHeaders = false;
               
                ticket.AddHeaderLine("TICKET DE CRÉDITO");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine(AppSettings.GetValue("Ticket", "HLine1", ""));
                ticket.AddHeaderLine(AppSettings.GetValue("Ticket", "HLine2", ""));
                ticket.AddHeaderLine(AppSettings.GetValue("Ticket", "HLine3", ""));
                ticket.AddHeaderLine(AppSettings.GetValue("Ticket", "HLine4", ""));
                ticket.AddHeaderLine(AppSettings.GetValue("Ticket", "HLine5", ""));
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("Fecha de impresión: " + DateTime.Now);
                ticket.AddHeaderLine("");

               
                OleDbCommand cmdReporte = new OleDbCommand();
                cmdReporte.Connection = cnn;
                cmdReporte.Transaction = tran;
                cmdReporte.CommandText = "SELECT * FROM vCREDITO WHERE FOLIO_VENTA=@ID ";
                cmdReporte.Parameters.Add("@ID", OleDbType.Integer).Value = prmFolioCredito;
                OleDbDataReader dr = cmdReporte.ExecuteReader();
                if (dr.Read()) {
                    ticket.AddHeaderLine("Folio Venta: " + dr["FOLIO_VENTA"].ToString());
                    ticket.AddHeaderLine("Fecha Crédito: " + dr["FECHA"].ToString());
                    ticket.AddHeaderLine("Cajero: " + dr["EMPLEADO"].ToString());
                    ticket.AddHeaderLine("Cliente: " + dr["NOMBRE"].ToString());
                    ticket.AddHeaderLine("Importe del Crédito: " + String.Format("{0:C}", dr["CANTIDAD"]));
                    ticket.AddHeaderLine("Primer Pago: " + String.Format("{0:C}", dr["PAGADO"]));
                    ticket.AddHeaderLine("Resto: " + String.Format("{0:C}", dr["RESTO"]));
                }
                dr.Close();

                ticket.AddFooterLine("Firma del Cliente");

                ticket.PrintTicket(AppSettings.GetValue("Ticket", "TicketPrinterName", ""));

            }
            catch (Exception ex)
            {
                throw (ex);
            }
           
        }

        public void ImprimeTicketCredito(int prmFolioCredito)
        {
            OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
            try
            {

                cnn.Open();
                Ticket ticket = new Ticket();
                if ((AppSettings.GetValue("Ticket", "TicketImage", "") != "") && (System.IO.File.Exists(AppSettings.GetValue("Ticket", "TicketImage", ""))))
                {
                    ticket.HeaderImage = System.Drawing.Image.FromFile(AppSettings.GetValue("Ticket", "TicketImage", "")); //esta propiedad no es obligatoria 
                }
                ticket.FontName = AppSettings.GetValue("Ticket", "FontName", "Courier New");
                ticket.FontSize = Convert.ToDouble(AppSettings.GetValue("Ticket", "FontSize", "7"));
                ticket.MaxChar = Convert.ToInt32(AppSettings.GetValue("Ticket", "MaxChar", "40"));
                ticket.MaxCharDescription = Convert.ToInt32(AppSettings.GetValue("Ticket", "MaxCharDescription", "20"));
                ticket.DrawItemHeaders = false;

                ticket.AddHeaderLine("TICKET DE CRÉDITO");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine(AppSettings.GetValue("Ticket", "HLine1", ""));
                ticket.AddHeaderLine(AppSettings.GetValue("Ticket", "HLine2", ""));
                ticket.AddHeaderLine(AppSettings.GetValue("Ticket", "HLine3", ""));
                ticket.AddHeaderLine(AppSettings.GetValue("Ticket", "HLine4", ""));
                ticket.AddHeaderLine(AppSettings.GetValue("Ticket", "HLine5", ""));
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("Fecha de impresión: " + DateTime.Now);
                ticket.AddHeaderLine("");


                OleDbCommand cmdReporte = new OleDbCommand();
                cmdReporte.Connection = cnn;

                cmdReporte.CommandText = "SELECT * FROM vCREDITO WHERE FOLIO_VENTA=@ID ";
                cmdReporte.Parameters.Add("@ID", OleDbType.Integer).Value = prmFolioCredito;
                OleDbDataReader dr = cmdReporte.ExecuteReader();
                if (dr.Read())
                {
                    ticket.AddHeaderLine("Folio Venta: " + dr["FOLIO_VENTA"].ToString());
                    ticket.AddHeaderLine("Fecha Crédito: " + dr["FECHA"].ToString());
                    ticket.AddHeaderLine("Cajero: " + dr["EMPLEADO"].ToString());
                    ticket.AddHeaderLine("Cliente: " + dr["NOMBRE"].ToString());
                    ticket.AddHeaderLine("Importe del Crédito: " + String.Format("{0:C}", dr["CANTIDAD"]));
                    ticket.AddHeaderLine("Primer Pago: " + String.Format("{0:C}", dr["PAGADO"]));
                    ticket.AddHeaderLine("Resto: " + String.Format("{0:C}", dr["RESTO"]));
                }
                dr.Close();

                ticket.AddFooterLine("Firma del Cliente");

                ticket.PrintTicket(AppSettings.GetValue("Ticket", "TicketPrinterName", ""));

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally { cnn.Close(); }

        }

        public void ImprimeTicketAbono(int prmFolioCredito, OleDbTransaction tran, OleDbConnection cnn)
        {

            try
            {

                Ticket ticket = new Ticket();
                if ((AppSettings.GetValue("Ticket", "TicketImage", "") != "") && (System.IO.File.Exists(AppSettings.GetValue("Ticket", "TicketImage", ""))))
                {
                    ticket.HeaderImage = System.Drawing.Image.FromFile(AppSettings.GetValue("Ticket", "TicketImage", "")); //esta propiedad no es obligatoria 
                }
                ticket.FontName = AppSettings.GetValue("Ticket", "FontName", "Courier New");
                ticket.FontSize = Convert.ToDouble(AppSettings.GetValue("Ticket", "FontSize", "7"));
                ticket.MaxChar = Convert.ToInt32(AppSettings.GetValue("Ticket", "MaxChar", "40"));
                ticket.MaxCharDescription = Convert.ToInt32(AppSettings.GetValue("Ticket", "MaxCharDescription", "20"));
                ticket.DrawItemHeaders = false;

                ticket.AddHeaderLine("TICKET DE ABONO A CRÉDITO");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine(AppSettings.GetValue("Ticket", "HLine1", ""));
                ticket.AddHeaderLine(AppSettings.GetValue("Ticket", "HLine2", ""));
                ticket.AddHeaderLine(AppSettings.GetValue("Ticket", "HLine3", ""));
                ticket.AddHeaderLine(AppSettings.GetValue("Ticket", "HLine4", ""));
                ticket.AddHeaderLine(AppSettings.GetValue("Ticket", "HLine5", ""));
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("Fecha de impresión: " + DateTime.Now);
                ticket.AddHeaderLine("");


                OleDbCommand cmdReporte = new OleDbCommand();
                cmdReporte.Connection = cnn;
                cmdReporte.Transaction = tran;
                cmdReporte.CommandText = "SELECT * FROM vPAGO_CREDITO WHERE FOLIO_PAGO_CREDITO=@ID ";
                cmdReporte.Parameters.Add("@ID", OleDbType.Integer).Value = prmFolioCredito;
                OleDbDataReader dr = cmdReporte.ExecuteReader();
                if (dr.Read())
                {
                    ticket.AddHeaderLine("Folio Venta: " + dr["FOLIO_VENTA"].ToString());
                    ticket.AddHeaderLine("Fecha Crédito: " + dr["FECHA"].ToString());
                    ticket.AddHeaderLine("Cajero: " + dr["EMPLEADO"].ToString());
                    ticket.AddHeaderLine("Cliente: " + dr["NOMBRE"].ToString());
                    ticket.AddHeaderLine("Importe del Crédito: " + String.Format("{0:C}", dr["CANTIDAD"]));
                    ticket.AddHeaderLine("Abono: " + String.Format("{0:C}", dr["ABONO"]));
                    ticket.AddHeaderLine("Resto: " + String.Format("{0:C}", dr["RESTO"]));
                }
                dr.Close();




                ticket.PrintTicketPreview(AppSettings.GetValue("Ticket", "TicketPrinterName", ""));

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

      

        public void ImprimeTicketAbono(int prmFolioCredito)
        {
            OleDbConnection cnn = new OleDbConnection(Class.clsMain.CnnStr);
            try
            {
                cnn.Open();
                Ticket ticket = new Ticket();
                if ((AppSettings.GetValue("Ticket", "TicketImage", "") != "") && (System.IO.File.Exists(AppSettings.GetValue("Ticket", "TicketImage", ""))))
                {
                    ticket.HeaderImage = System.Drawing.Image.FromFile(AppSettings.GetValue("Ticket", "TicketImage", "")); //esta propiedad no es obligatoria 
                }
                ticket.FontName = AppSettings.GetValue("Ticket", "FontName", "Courier New");
                ticket.FontSize = Convert.ToDouble(AppSettings.GetValue("Ticket", "FontSize", "7"));
                ticket.MaxChar = Convert.ToInt32(AppSettings.GetValue("Ticket", "MaxChar", "40"));
                ticket.MaxCharDescription = Convert.ToInt32(AppSettings.GetValue("Ticket", "MaxCharDescription", "20"));
                ticket.DrawItemHeaders = false;

                ticket.AddHeaderLine("TICKET DE ABONO A CRÉDITO");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine(AppSettings.GetValue("Ticket", "HLine1", ""));
                ticket.AddHeaderLine(AppSettings.GetValue("Ticket", "HLine2", ""));
                ticket.AddHeaderLine(AppSettings.GetValue("Ticket", "HLine3", ""));
                ticket.AddHeaderLine(AppSettings.GetValue("Ticket", "HLine4", ""));
                ticket.AddHeaderLine(AppSettings.GetValue("Ticket", "HLine5", ""));
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("Fecha de impresión: " + DateTime.Now);
                ticket.AddHeaderLine("");


                OleDbCommand cmdReporte = new OleDbCommand();
                cmdReporte.Connection = cnn;
       
                cmdReporte.CommandText = "SELECT * FROM vPAGO_CREDITO WHERE FOLIO_PAGO_CREDITO=@ID ";
                cmdReporte.Parameters.Add("@ID", OleDbType.Integer).Value = prmFolioCredito;
                OleDbDataReader dr = cmdReporte.ExecuteReader();
                if (dr.Read())
                {
                    ticket.AddHeaderLine("Folio Venta: " + dr["FOLIO_VENTA"].ToString());
                    ticket.AddHeaderLine("Fecha Crédito: " + dr["FECHA"].ToString());
                    ticket.AddHeaderLine("Cajero: " + dr["EMPLEADO"].ToString());
                    ticket.AddHeaderLine("Cliente: " + dr["NOMBRE"].ToString());
                    ticket.AddHeaderLine("Importe del Crédito: " + String.Format("{0:C}", dr["CANTIDAD"]));
                    ticket.AddHeaderLine("Abono: " + String.Format("{0:C}", dr["ABONO"]));
                    ticket.AddHeaderLine("Resto: " + String.Format("{0:C}", dr["RESTO"]));
                }
                dr.Close();




                ticket.PrintTicketPreview(AppSettings.GetValue("Ticket", "TicketPrinterName", ""));

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally { cnn.Close(); }

        }
    }
}
