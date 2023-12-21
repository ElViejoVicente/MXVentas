/*
 * Created by SharpDevelop.
 * User: Santos
 * Date: 14/11/2005
 * Time: 04:41 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;


namespace POSDLL
{
    public class NumeroALetra
    {
        private string[] sUnidades = {"", "un", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve", "diez", 
									"once", "doce", "trece", "catorce", "quince", "dieciseis", "diecisiete", "dieciocho", "diecinueve", "veinte", 
									"veintiún", "veintidos", "veintitres", "veinticuatro", "veinticinco", "veintiseis", "veintisiete", "veintiocho", "veintinueve"};

        private string[] sDecenas = { "", "diez", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa" };

        private string[] sCentenas = { "", "ciento", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos", "setecientos", "ochocientos", "novecientos" };


        private string sResultado = "";


        public string ConvertirCadena(string sNumero)
        {
            double dNumero;
            double dNumAux = 0;
            char x;
            string sAux;

            sResultado = " ";
            try
            {
                dNumero = Convert.ToDouble(sNumero);
            }
            catch
            {
                return "";
            }

            if (dNumero > 999999999999)
                return "";

            if (dNumero > 999999999)
            {
                dNumAux = dNumero % 1000000000000;
                sResultado += Numeros(dNumAux, 1000000000) + " mil ";
            }

            if (dNumero > 999999)
            {
                dNumAux = dNumero % 1000000000;
                sResultado += Numeros(dNumAux, 1000000) + " millones ";
            }

            if (dNumero > 999)
            {
                dNumAux = dNumero % 1000000;
                sResultado += Numeros(dNumAux, 1000) + " mil ";
            }

            dNumAux = dNumero % 1000;
            sResultado += Numeros(dNumAux, 1);


            //Enseguida verificamos si contiene punto, si es así, los convertimos a texto.
            sAux = dNumero.ToString();

            if (sAux.IndexOf(".") >= 0)
                sResultado += ObtenerDecimales(sAux);

            //Las siguientes líneas convierten el primer caracter a mayúscula.
            sAux = sResultado;
            x = char.ToUpper(sResultado[1]);
            sResultado = x.ToString();

            for (int i = 2; i < sAux.Length; i++)
                sResultado += sAux[i].ToString();

            return sResultado ;
        }


        public string ConvertirCadena(double dNumero,string prmMONEDA, string prmSIGLAS)
        {
            double dNumAux = 0;
            char x;
            string sAux;

            sResultado = " ";

            if (dNumero > 999999999999)
                return "";

            if (dNumero > 999999999)
            {
                dNumAux = dNumero % 1000000000000;
                sResultado += Numeros(dNumAux, 1000000000) + " mil ";
            }

            if (dNumero > 999999)
            {
                dNumAux = dNumero % 1000000000;
                sResultado += Numeros(dNumAux, 1000000) + " millones ";
            }

            if (dNumero > 999)
            {
                dNumAux = dNumero % 1000000;
                sResultado += Numeros(dNumAux, 1000) + " mil ";
            }

            dNumAux = dNumero % 1000;
            sResultado += Numeros(dNumAux, 1);


            //Enseguida verificamos si contiene punto, si es así, los convertimos a texto.
            sAux = dNumero.ToString();
            string varDecimales = "";
            if (sAux.IndexOf(".") >= 0)
            {
                varDecimales = " "+ prmMONEDA +" " +ObtenerDecimales(sAux + "0");
            }
            else {
                varDecimales = " "+ prmMONEDA +" 00/100 "+ prmSIGLAS +"";
            }
            sResultado += varDecimales;
            //Las siguientes líneas convierten el primer caracter a mayúscula.
            sAux = sResultado;
            x = char.ToUpper(sResultado[1]);
            sResultado = x.ToString();

            for (int i = 2; i < sAux.Length; i++)
                sResultado += sAux[i].ToString();

            return sResultado;
        }


        private string Numeros(double dNumAux, double dFactor)
        {
            double dCociente = dNumAux / dFactor;
            double dNumero = 0;
            int iNumero = 0;
            string sNumero = "";
            string sTexto = "";

            if (dCociente >= 100)
            {
                dNumero = dCociente / 100;
                sNumero = dNumero.ToString();
                iNumero = int.Parse(sNumero[0].ToString());
                sTexto += this.sCentenas[iNumero] + " ";
            }

            dCociente = dCociente % 100;
            if (dCociente >= 30)
            {
                dNumero = dCociente / 10;
                sNumero = dNumero.ToString();
                iNumero = int.Parse(sNumero[0].ToString());
                if (iNumero > 0)
                    sTexto += this.sDecenas[iNumero] + " ";

                dNumero = dCociente % 10;
                sNumero = dNumero.ToString();
                iNumero = int.Parse(sNumero[0].ToString());
                if (iNumero > 0)
                    sTexto += "y " + this.sUnidades[iNumero] + " ";
            }

            else
            {
                dNumero = dCociente;
                sNumero = dNumero.ToString();
                if (sNumero.Length > 1)
                    if (sNumero[1] != '.')
                        iNumero = int.Parse(sNumero[0].ToString() + sNumero[1].ToString());
                    else
                        iNumero = int.Parse(sNumero[0].ToString());
                else
                    iNumero = int.Parse(sNumero[0].ToString());
                sTexto += this.sUnidades[iNumero] + " ";
            }

            return sTexto;
        }


        private string ObtenerDecimales(string sNumero)
        {
            string[] sNumPuntos;
            string sTexto = "";
            double dNumero = 0;

            sNumPuntos = sNumero.Split('.');


            dNumero = Convert.ToDouble(sNumPuntos[1]);
            //sTexto = "punto " + Numeros(dNumero, 1);
            sTexto = sNumPuntos[1].Substring(0,2) + "/100 M.N";
            
            return sTexto;
        }
    }
}