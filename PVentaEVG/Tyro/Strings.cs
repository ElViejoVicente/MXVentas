using System;

namespace POSDLL
{
	public class Strings
	{
		public Strings()
		{
		}

		public static string fnFileNameGenerator(string prmExtension)
		{
			string[] str = new string[7];
			int year = DateTime.Now.Year;
			str[0] = year.ToString();
			year = DateTime.Now.Month;
			str[1] = year.ToString();
			year = DateTime.Now.Day;
			str[2] = year.ToString();
			year = DateTime.Now.Hour;
			str[3] = year.ToString();
			year = DateTime.Now.Minute;
			str[4] = year.ToString();
			year = DateTime.Now.Second;
			str[5] = year.ToString();
			str[6] = prmExtension;
			string str1 = string.Concat(str);
			return str1;
		}

		public static string SafeSqlLikeClauseLiteral(string prmSQLString)
		{
			string str = prmSQLString.Replace("'", "''");
			return str;
		}
	}
}