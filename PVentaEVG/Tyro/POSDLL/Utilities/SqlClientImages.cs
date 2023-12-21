using System;
using System.Data;
using System.Data.SqlClient;

namespace POSDLL.Utilities
{
	public class SqlClientImages
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

		public SqlClientImages()
		{
		}

		public byte[] GetPicture(string tableName, string imageFieldName, string fieldIdName, int fieldIdValue)
		{
			byte[] numArray;
			SqlConnection conn = new SqlConnection(this._connStr);
			try
			{
				try
				{
					conn.Open();
					SqlCommand comm = new SqlCommand();
					comm.Connection = conn;
					object[] objArray = new object[] { imageFieldName, tableName, fieldIdName, fieldIdValue };
					comm.CommandText = string.Format("SELECT {0} FROM {1} where {1}={2} AND {0} IS NOT NULL", objArray);
					SqlDataReader dr = null;
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
			SqlConnection conn = new SqlConnection(this._connStr);
			try
			{
				try
				{
					conn.Open();
					SqlCommand comm = new SqlCommand();
					comm.Connection = conn;
					object[] objArray = new object[] { imageFieldName, tableName, fieldIdName, fieldIdValue };
					comm.CommandText = string.Format("SELECT {0} FROM {1} where {1}='{2}' AND {0} IS NOT NULL", objArray);
					SqlDataReader dr = null;
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
			SqlConnection conn = new SqlConnection(this._connStr);
			try
			{
				try
				{
					conn.Open();
					SqlCommand comm = new SqlCommand();
					comm.Connection = conn;
					string str = string.Format("UPDATE [{0}] SET [{1}]=@IMG WHERE [{2}]=@ID", tableName, fieldImage, fieldId);
					string str1 = str;
					comm.CommandText = str;
					comm.CommandText = str1;
					SqlParameter parImagen = new SqlParameter("@IMG", SqlDbType.Image, (int)picture.Length);
					parImagen.Value = picture;
					comm.Parameters.Add(parImagen);
					SqlParameter parId = new SqlParameter("@ID", fieldIdValue);
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

		public bool SavePicture(byte[] picture, string tableName, string fieldId, string fieldIdValue, string fieldImage, SqlCommand comm)
		{
			bool flag;
			try
			{
				comm.Parameters.Clear();
				comm.CommandText = string.Format("UPDATE [{0}] SET [{1}]=@IMG WHERE [{2}]=@ID", tableName, fieldImage, fieldId);
				SqlParameter parImagen = new SqlParameter("@IMG", SqlDbType.Image, (int)picture.Length);
				parImagen.Value = picture;
				comm.Parameters.Add(parImagen);
				SqlParameter parId = new SqlParameter("@ID", fieldIdValue);
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