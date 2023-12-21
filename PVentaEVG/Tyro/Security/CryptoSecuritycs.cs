using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace POSDLL.Security
{
    class CryptoSecuritycs
    {
        private CryptoProvider algorithm;
        private CryptoAction cAction;

        internal enum CryptoAction
        {
            Encrypt,
            Desencrypt
        }

        internal enum CryptoProvider
        {
            DES,
            TripleDES,
            RC2,
            Rijndael
        }

        internal CryptoSecuritycs(CryptoProvider alg, CryptoAction action)
        {

            this.algorithm = alg;
            this.cAction = action;
        }

        internal CryptoSecuritycs() { }

        public ICryptoTransform GetServiceProvider(byte[] Key, byte[] IV)
        {
            ICryptoTransform transform = null;


            switch (this.algorithm)
            {

                case CryptoProvider.DES:

                    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                    switch (cAction)
                    {
                        case CryptoAction.Encrypt:

                            transform = des.CreateEncryptor(Key, IV);
                            break;
                        case CryptoAction.Desencrypt:
                            // creamos el objeto descifrador.
                            transform = des.CreateDecryptor(Key, IV);
                            break;
                    }

                    return transform;

                case CryptoProvider.TripleDES:
                    TripleDESCryptoServiceProvider des3 = new TripleDESCryptoServiceProvider();
                    switch (cAction)
                    {
                        case CryptoAction.Encrypt:
                            transform = des3.CreateEncryptor(Key, IV);
                            break;
                        case CryptoAction.Desencrypt:
                            transform = des3.CreateDecryptor(Key, IV);
                            break;
                    }
                    return transform;

                case CryptoProvider.RC2:
                    RC2CryptoServiceProvider rc2 = new RC2CryptoServiceProvider();
                    switch (cAction)
                    {
                        case CryptoAction.Encrypt:
                            transform = rc2.CreateEncryptor(Key, IV);
                            break;
                        case CryptoAction.Desencrypt:
                            transform = rc2.CreateDecryptor(Key, IV);
                            break;
                    }
                    return transform;

                case CryptoProvider.Rijndael:
                    Rijndael rijndael = new RijndaelManaged();
                    switch (cAction)
                    {
                        case CryptoAction.Encrypt:
                            transform = rijndael.CreateEncryptor(Key, IV);
                            break;
                        case CryptoAction.Desencrypt:
                            transform = rijndael.CreateDecryptor(Key, IV);
                            break;
                    }
                    return transform;
                default:

                    throw new CryptographicException("Error al inicializar al proveedor de cifrado");
            }
        }
    }
}
