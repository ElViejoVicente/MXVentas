using System.Configuration;

namespace POSDLL
{
	public class AppSettings
	{
		public AppSettings()
		{
		}

		public static string GetValue(string seccion, string clave, string predeterminado)
		{
			string str;
			string item = "";
			try
			{
				item = ConfigurationManager.AppSettings[string.Concat(seccion, ".", clave)];
				if (item == "")
				{
					item = predeterminado;
				}
				str = item;
			}
			catch
			{
				str = predeterminado;
			}
			return str;
		}

		public static string GetValue(string seccion, string clave)
		{
			string str;
			string item = "";
			try
			{
				item = ConfigurationManager.AppSettings[string.Concat(seccion, ".", clave)];
				if (item == "")
				{
					item = "";
				}
				str = item;
			}
			catch
			{
				str = "";
			}
			return str;
		}

		private void InitializeComponent()
		{
		}

		public static void SetValue(string seccion, string clave, string valor)
		{
			Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			configuration.AppSettings.Settings.Remove(string.Concat(seccion, ".", clave));
			configuration.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection("appSettings");
			configuration.AppSettings.Settings.Add(string.Concat(seccion, ".", clave), valor);
			configuration.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection("appSettings");
		}
	}
}