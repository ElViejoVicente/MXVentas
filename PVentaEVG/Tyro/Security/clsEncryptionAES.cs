using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace POSDLL.Security
{
    public class clsEncryptionAES
    {
        private String sKey;
        private String sIV;
        private CryptoProvider algorithm;

        //algoritmos de encriptacion
        public enum CryptoProvider
        {
            DES,
            TripleDES,
            RC2,
            Rijndael
        }

        public clsEncryptionAES()
        {
            this.sKey = "13031987";
            this.sIV = "mxitsyst";
            this.algorithm = CryptoProvider.Rijndael;

        }

        public clsEncryptionAES(CryptoProvider alg)
        {
            this.sKey = "13031987";
            this.sIV = "mxitsyst";
            this.algorithm = alg;

        }

        public String Encode(String sCadenaOriginal)
        {
            try
            {
                MemoryStream memStream = null;

                if (!String.IsNullOrEmpty(sKey) && !String.IsNullOrEmpty(sIV))
                {
                    byte[] key = MakeKeyByteArray();
                    byte[] IV = MakeIVByteArray();

                    byte[] textoPlano = Encoding.UTF8.GetBytes(sCadenaOriginal);

                    memStream = new MemoryStream(sCadenaOriginal.Length * 2);

                    CryptoSecuritycs cryptoProvider = new CryptoSecuritycs((CryptoSecuritycs.CryptoProvider)this.algorithm, CryptoSecuritycs.CryptoAction.Encrypt);
                    ICryptoTransform transform = cryptoProvider.GetServiceProvider(key, IV);
                    CryptoStream cs = new CryptoStream(memStream, transform, CryptoStreamMode.Write);

                    cs.Write(textoPlano, 0, textoPlano.Length);
                    cs.Close();

                }
                else
                {
                    throw new Exception("Error al inicializar la clave y el vector");

                }

                return Convert.ToBase64String(memStream.ToArray());

            }
            catch (Exception)
            {

                throw;
            }

        }

        private byte[] MakeIVByteArray()
        {
            try
            {

                switch (this.algorithm)
                {
                    case CryptoProvider.Rijndael:
                        // verificamos que la longitud no sea menor que 16 bytes,
                        if (sIV.Length < 16)
                            sIV = sIV.PadRight(16); // de ser así, completamos la cadena hasta un valor válido
                        else if (sIV.Length > 16)// si la cadena supera los 16 bytes,						
                            sIV = sIV.Substring(0, 16); // truncamos la cadena dejándola en 16 bytes.
                        break;

                    case CryptoProvider.RC2:
                        break;
                }

                return Encoding.UTF8.GetBytes(sIV);

            }
            catch (Exception)
            {

                throw;
            }
        }

        private byte[] MakeKeyByteArray()
        {
            try
            {
                switch (this.algorithm)
                {
                    case CryptoProvider.Rijndael:
                        // verificamos que la longitud de la cadena no sea menor a 16 bytes
                        if (sKey.Length < 16)
                            sKey = sKey.PadRight(16); // de ser así, completamos la cadena hasta esos 16 bytes.
                        else if (sKey.Length > 16)// si la longitud es mayor a 16 bytes,			
                            sKey = sKey.Substring(0, 16); // truncamos la cadena dejándola en 8 bytes.
                        break;

                    case CryptoProvider.RC2:
                        if (sKey.Length < 8)
                            sKey = sKey.PadRight(8);
                        else if (sKey.Length > 8)
                            sKey = sKey.Substring(0, 8);
                        break;
                }

                return Encoding.UTF8.GetBytes(sKey);


            }
            catch (Exception)
            {

                throw;
            }
        }

        public String Decode(String sCadenaCodificada)
        {
            MemoryStream memStream = null;

            try
            {
                if (!String.IsNullOrEmpty(sKey) && !String.IsNullOrEmpty(sIV))
                {
                    byte[] key = MakeKeyByteArray();
                    byte[] IV = MakeIVByteArray();
                    byte[] textoCifrado = Convert.FromBase64String(sCadenaCodificada);

                    memStream = new MemoryStream(sCadenaCodificada.Length);

                    CryptoSecuritycs cryptoProvider =
                        new CryptoSecuritycs((CryptoSecuritycs.CryptoProvider)this.algorithm,
                        CryptoSecuritycs.CryptoAction.Desencrypt);

                    ICryptoTransform transform = cryptoProvider.GetServiceProvider(key, IV);
                    CryptoStream cs = new CryptoStream(memStream, transform, CryptoStreamMode.Write);

                    cs.Write(textoCifrado, 0, textoCifrado.Length);
                    cs.Close();
                }
                else

                    throw new Exception("Error al inicializar la clave y el vector.");

            }
            catch
            {
                throw;
            }

            return Encoding.UTF8.GetString(memStream.ToArray());

        }
    }
}
