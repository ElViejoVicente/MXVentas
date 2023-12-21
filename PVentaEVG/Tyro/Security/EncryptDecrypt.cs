using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace POSDLL.Security
{
	public class EncryptDecrypt
	{
		private string passPhrase = "Pas5pr@se";

		private string saltValue = "s@1tValue";

		private string hashAlgorithm = "SHA1";

		private int passwordIterations = 2;

		private string initVector = "@1B2c3D4e5F6g7H8";

		private int keySize = 256;

		public EncryptDecrypt()
		{
		}

		public string Decrypt(string cipherText)
		{
			string str;
			try
			{
				byte[] bytes = Encoding.ASCII.GetBytes(this.initVector);
				byte[] numArray = Encoding.ASCII.GetBytes(this.saltValue);
				byte[] numArray1 = Convert.FromBase64String(cipherText);
				PasswordDeriveBytes passwordDeriveByte = new PasswordDeriveBytes(this.passPhrase, numArray, this.hashAlgorithm, this.passwordIterations);
				byte[] bytes1 = passwordDeriveByte.GetBytes(this.keySize / 8);
				RijndaelManaged rijndaelManaged = new RijndaelManaged();
				rijndaelManaged.Mode = CipherMode.CBC;
				ICryptoTransform cryptoTransform = rijndaelManaged.CreateDecryptor(bytes1, bytes);
				MemoryStream memoryStream = new MemoryStream(numArray1);
				CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Read);
				byte[] numArray2 = new byte[(int)numArray1.Length];
				int num = cryptoStream.Read(numArray2, 0, (int)numArray2.Length);
				memoryStream.Close();
				cryptoStream.Close();
				str = Encoding.UTF8.GetString(numArray2, 0, num);
			}
			catch
			{
				str = "";
			}
			return str;
		}

		public string Encrypt(string plainText)
		{
			string base64String;
			try
			{
				byte[] bytes = Encoding.ASCII.GetBytes(this.initVector);
				byte[] numArray = Encoding.ASCII.GetBytes(this.saltValue);
				byte[] bytes1 = Encoding.UTF8.GetBytes(plainText);
				PasswordDeriveBytes passwordDeriveByte = new PasswordDeriveBytes(this.passPhrase, numArray, this.hashAlgorithm, this.passwordIterations);
				byte[] numArray1 = passwordDeriveByte.GetBytes(this.keySize / 8);
				RijndaelManaged rijndaelManaged = new RijndaelManaged();
				rijndaelManaged.Mode = CipherMode.CBC;
				ICryptoTransform cryptoTransform = rijndaelManaged.CreateEncryptor(numArray1, bytes);
				MemoryStream memoryStream = new MemoryStream();
				CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write);
				cryptoStream.Write(bytes1, 0, (int)bytes1.Length);
				cryptoStream.FlushFinalBlock();
				byte[] array = memoryStream.ToArray();
				memoryStream.Close();
				cryptoStream.Close();
				base64String = Convert.ToBase64String(array);
			}
			catch
			{
				base64String = "";
			}
			return base64String;
		}
	}
}