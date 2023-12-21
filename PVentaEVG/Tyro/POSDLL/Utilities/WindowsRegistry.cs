using Microsoft.Win32;
using System;

namespace POSDLL.Utilities
{
	public class WindowsRegistry
	{
		private RegistryKey registryAccess;

		public WindowsRegistry()
		{
		}

		public string ReadValue(string pKey, string pDefault)
		{
			this.registryAccess = Registry.Users;
			string val = "";
			this.registryAccess = this.registryAccess.OpenSubKey(".DEFAULT", true);
			val = this.registryAccess.GetValue(pKey, pDefault).ToString();
			this.registryAccess.Close();
			string str = val;
			return str;
		}

		public void WriteValue(string pKey, string pValue)
		{
			this.registryAccess = Registry.Users;
			this.registryAccess = this.registryAccess.OpenSubKey(".DEFAULT", true);
			this.registryAccess.SetValue(pKey, pValue, RegistryValueKind.String);
			this.registryAccess.Close();
		}
	}
}