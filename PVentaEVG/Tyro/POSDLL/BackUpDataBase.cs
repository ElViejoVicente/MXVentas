using JRO;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace POSDLL
{
	public class BackUpDataBase
	{
		public BackUpDataBase()
		{
		}

        public void Backup(string prmOrigen, string prmDestino)
        {
            try
            {
                JetEngine variable = (JetEngine)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("DE88C160-FF2C-11D1-BB6F-00C04FAE22DA")));
                variable.CompactDatabase(prmOrigen, prmDestino);
                MessageBox.Show(string.Concat("Proceso ejecutado con éxito.\nArchivo: ", prmDestino), "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                MessageBox.Show(exception.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

		public void RespaldarMSSQLServer(string databaseFileName, string filePath, string CnnStr, string DataBaseName)
		{
			try
			{
				string str = databaseFileName;
				bool flag = true;
				string[] dataBaseName = new string[] { "backup database ", DataBaseName, " to disk ='", str, "' " };
				string str1 = string.Concat(dataBaseName);
				Cursor.Current = Cursors.WaitCursor;
				if (!Directory.Exists(filePath))
				{
					Directory.CreateDirectory(filePath);
				}
				else if (File.Exists(str))
				{
					if (MessageBox.Show("Do you want to replace it?", "Backup", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
					{
						flag = false;
					}
					else
					{
						File.Delete(str);
					}
				}
				if (flag)
				{
					SqlConnection sqlConnection = new SqlConnection(CnnStr);
					sqlConnection.Open();
					MessageBox.Show(str1);
					(new SqlCommand(str1, sqlConnection)).ExecuteNonQuery();
					sqlConnection.Close();
					MessageBox.Show("The support of the database was successfully performed", "Back", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(string.Concat(exception.Message, " ", exception.InnerException));
			}
		}
	}
}