using System;
using System.Data.OleDb;

namespace POSDLL.Utilities
{
	public class OldDbImages
	{
		private string _connStr = "";

		public string ConnStr
		{
			get
			{
				string str = this._connStr;
				return str;
			}
			set
			{
				this._connStr = value;
			}
		}

		public OldDbImages()
		{
		}

		public byte[] GetPicture(string tableName, string imageFieldName, string fieldIdName, int fieldIdValue)
		{
			byte[] numArray;
			OleDbConnection conn = new OleDbConnection(this._connStr);
			try
			{
				try
				{
					conn.Open();
					OleDbCommand comm = new OleDbCommand();
					comm.Connection = conn;
					object[] objArray = new object[] { imageFieldName, tableName, fieldIdName, fieldIdValue };
					comm.CommandText = string.Format("SELECT {0} FROM {1} where {1}={2} AND {0} IS NOT NULL", objArray);
					OleDbDataReader dr = null;
					dr = comm.ExecuteReader();
					byte[] aBytes = null;
					if (dr.Read())
					{
						aBytes = (byte[])dr[imageFieldName];
					}
					conn.Close();
					dr.Close();
					numArray = aBytes;
				}
				catch (Exception exception)
				{
					throw exception;
				}
			}
			finally
			{
				conn.Close();
			}
			return numArray;
		}

		public byte[] GetPicture(string tableName, string imageFieldName, string fieldIdName, string fieldIdValue)
		{
			byte[] numArray;
			OleDbConnection conn = new OleDbConnection(this._connStr);
			try
			{
				try
				{
					conn.Open();
					OleDbCommand comm = new OleDbCommand();
					comm.Connection = conn;
					object[] objArray = new object[] { imageFieldName, tableName, fieldIdName, fieldIdValue };
					comm.CommandText = string.Format("SELECT {0} FROM {1} where {1}='{2}' AND {0} IS NOT NULL", objArray);
					OleDbDataReader dr = null;
					dr = comm.ExecuteReader();
					byte[] aBytes = null;
					if (dr.Read())
					{
						aBytes = (byte[])dr[imageFieldName];
					}
					conn.Close();
					dr.Close();
					numArray = aBytes;
				}
				catch (Exception exception)
				{
					throw exception;
				}
			}
			finally
			{
				conn.Close();
			}
			return numArray;
		}

		public bool SavePicture(byte[] picture, string tableName, string fieldId, string fieldIdValue, string fieldImage)
		{
			bool flag;
			OleDbConnection conn = new OleDbConnection(this._connStr);
			try
			{
				try
				{
					conn.Open();
					OleDbCommand comm = new OleDbCommand();
					comm.Connection = conn;
					string str = string.Format("UPDATE [{0}] SET [{1}]=@IMG WHERE [{2}]=@ID", tableName, fieldImage, fieldId);
					string str1 = str;
					comm.CommandText = str;
					comm.CommandText = str1;
					OleDbParameter parImagen = new OleDbParameter("@IMG", OleDbType.VarBinary, (int)picture.Length);
					parImagen.Value = picture;
					comm.Parameters.Add(parImagen);
					OleDbParameter parId = new OleDbParameter("@ID", fieldIdValue);
					comm.Parameters.Add(parId);
					comm.ExecuteNonQuery();
					flag = true;
				}
				catch (Exception exception)
				{
					throw exception;
				}
			}
			finally
			{
				conn.Close();
			}
			return flag;
		}

		public bool SavePicture(byte[] picture, string tableName, string fieldId, string fieldIdValue, string fieldImage, OleDbCommand comm)
		{
			bool flag;
			try
			{
				comm.Parameters.Clear();
				comm.CommandText = string.Format("UPDATE [{0}] SET [{1}]=@IMG WHERE [{2}]=@ID", tableName, fieldImage, fieldId);
				OleDbParameter parImagen = new OleDbParameter("@IMG", OleDbType.VarBinary, (int)picture.Length);
				parImagen.Value = picture;
				comm.Parameters.Add(parImagen);
				OleDbParameter parId = new OleDbParameter("@ID", fieldIdValue);
				comm.Parameters.Add(parId);
				comm.ExecuteNonQuery();
				comm.Parameters.Clear();
				flag = true;
			}
			catch (Exception exception)
			{
				throw exception;
			}
			return flag;
		}
	}
}