using System;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using Microsoft.Win32;

namespace POS
{
    public class cGlobal
    {
        public static bool ComprobarCampo(object Campo)
        {
            bool bRes = true;
            if (Campo != null)
            {
                if (Convert.IsDBNull(Campo))
                {
                    bRes = false;
                }
                else
                {
                    if (Campo.ToString().Trim().Length == 0)
                    {
                        bRes = false;
                    }
                }
            }
            else
            {
                bRes = false;
            }
            return bRes;
        }

        //public static void RemoveFromGridRow(Telerik.WinControls.UI.RadGridView grid)
        //{
        //    if (grid.CurrentRow != null && !(grid.CurrentRow is Telerik.WinControls.UI.GridViewNewRowInfo))
        //    {
        //        grid.Rows.Remove(grid.CurrentRow);
        //        grid.Refresh();
        //    }
        //}

        //public static int GetSafeIDFromGridView(Telerik.WinControls.UI.RadGridView grid)
        //{
        //    try
        //    {
        //        int id = 0;
        //        if (grid.CurrentRow != null && !(grid.CurrentRow is Telerik.WinControls.UI.GridViewNewRowInfo))
        //        {
        //            id = GetSafeID(grid.CurrentRow.Cells[0].Value);
        //        }
        //        return id;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error en GetSafeIDFromGridView, Error: " + ex.Message);
        //    }
        //}

        public static int GetSafeID(object value)
        {
            try
            {
                if (value == null)
                {
                    return 0;
                }
                return Convert.ToInt32(value);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en GetSafeID, Error: " + ex.Message);
            }
        }

        public static string Encrypt(string strText)
        {
            string strEncrKey = "&%#@?,:*";

            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
            try
            {
                byte[] bykey = System.Text.Encoding.UTF8.GetBytes(strEncrKey);
                byte[] InputByteArray = System.Text.Encoding.UTF8.GetBytes(strText);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(bykey, IV), CryptoStreamMode.Write);
                cs.Write(InputByteArray, 0, InputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string Decrypt(string strText)
        {
            string sDecrKey = "&%#@?,:*";

            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
            byte[] inputByteArray = new byte[strText.Length + 1];
            try
            {
                byte[] byKey = System.Text.Encoding.UTF8.GetBytes(sDecrKey);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(strText);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string Encrypt(string strText, string strEncrKey)
        {
            //arreglo de bytes donde guardaremos la llave
            byte[] keyArray;
            //arreglo de bytes donde guardaremos el texto
            //que vamos a encriptar
            byte[] Arreglo_a_Cifrar =
            UTF8Encoding.UTF8.GetBytes(strText);

            //se utilizan las clases de encriptación
            //provistas por el Framework
            //Algoritmo MD5
            MD5CryptoServiceProvider hashmd5 =
            new MD5CryptoServiceProvider();
            //se guarda la llave para que se le realice
            //hashing
            keyArray = hashmd5.ComputeHash(
            UTF8Encoding.UTF8.GetBytes(strEncrKey));

            hashmd5.Clear();

            //Algoritmo 3DAS
            TripleDESCryptoServiceProvider tdes =
            new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            //se empieza con la transformación de la cadena
            ICryptoTransform cTransform =
            tdes.CreateEncryptor();

            //arreglo de bytes donde se guarda la
            //cadena cifrada
            byte[] ArrayResultado =
            cTransform.TransformFinalBlock(Arreglo_a_Cifrar,
            0, Arreglo_a_Cifrar.Length);

            tdes.Clear();

            //se regresa el resultado en forma de una cadena
            return Convert.ToBase64String(ArrayResultado,
            0, ArrayResultado.Length);
        }

        public static string Decrypt(string strText, string sDecrKey)
        {
            byte[] keyArray;
            //convierte el texto en una secuencia de bytes
            byte[] Array_a_Descifrar =
            Convert.FromBase64String(strText);

            //se llama a las clases que tienen los algoritmos
            //de encriptación se le aplica hashing
            //algoritmo MD5
            MD5CryptoServiceProvider hashmd5 =
            new MD5CryptoServiceProvider();

            keyArray = hashmd5.ComputeHash(
            UTF8Encoding.UTF8.GetBytes(sDecrKey));

            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes =
            new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform =
            tdes.CreateDecryptor();

            byte[] resultArray =
            cTransform.TransformFinalBlock(Array_a_Descifrar,
            0, Array_a_Descifrar.Length);

            tdes.Clear();
            //se regresa en forma de cadena
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        public static void SaveSetting(string section, string key, string setting)
        {    // Los datos se guardan en:
            // HKEY_CURRENT_USER\Software\VB and VBA Program Settings
            string appName = "POSCFDI";
            RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"Software\VB and VBA Program Settings\" + appName + "\\" + section);
            rk.SetValue(key, setting);
        }

        public static string GetSetting(string section, string key)
        {
            return GetSetting(section, key, cGlobal.Encrypt(""));
        }

        public static string GetSetting(string section, string key, string sDefault)
        {
            string appName = "Sistema Punto de Venta";

            RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Software\VB and VBA Program Settings\" + appName + "\\" + section);
            string s = sDefault;
            if (rk != null)
            {
                s = (string)rk.GetValue(key);
            }

            return s;
        }

        public static string GetAppPath()
        {
            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\";
        }

    
        public static int ConfiguracionDecimales()
        {
            //string fileName = GetAppPath() + "ConfiguracionLocal.xml";
            //FacturaCFDIConfig.FacturaCFDIConfiguracion config = null;
            //try
            //{
            //    config = new FacturaCFDIConfig.FacturaCFDIConfiguracion();
            //    if (System.IO.File.Exists(fileName))
            //    {
            //        config = FacturaCFDIConfig.FacturaCFDIConfiguracion.LoadFromFile(fileName);
            //        return config.Decimales;
            //    }
            //    else
            //    {
            //        return 2;
            //    }
            //}
            //catch
            //{
            //    return 2;
            //}
            return 2;
        }
    }
}
