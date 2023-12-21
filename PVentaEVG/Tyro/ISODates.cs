using System;

namespace POSDLL
{
	public class ISODates
	{
		public ISODates()
		{
		}

		public static string MesALetra(int prmMes)
		{
			string str = "";
			switch (prmMes)
			{
				case 1:
				{
					str = "Enero";
					break;
				}
				case 2:
				{
					str = "Febrero";
					break;
				}
				case 3:
				{
					str = "Marzo";
					break;
				}
				case 4:
				{
					str = "Abril";
					break;
				}
				case 5:
				{
					str = "Mayo";
					break;
				}
				case 6:
				{
					str = "Junio";
					break;
				}
				case 7:
				{
					str = "Julio";
					break;
				}
				case 8:
				{
					str = "Agosto";
					break;
				}
				case 9:
				{
					str = "Septiembre";
					break;
				}
				case 10:
				{
					str = "Octubre";
					break;
				}
				case 11:
				{
					str = "Noviembre";
					break;
				}
				case 12:
				{
					str = "Diciembre";
					break;
				}
				default:
				{
					str = "";
					break;
				}
			}
			string str1 = str;
			return str1;
		}

		public static string MSAccessDate(DateTime prmDate)
		{
			string[] str = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
			string[] strArrays = str;
			string str1 = "01";
			string str2 = "00";
			string str3 = "00";
			string str4 = "00";
			int day = prmDate.Day;
			str1 = day.ToString();
			if (str1.Length == 1)
			{
				str1 = string.Concat("0", str1);
			}
			day = prmDate.Hour;
			str2 = day.ToString();
			if (str2.Length == 1)
			{
				str2 = string.Concat("0", str2);
			}
			day = prmDate.Minute;
			str3 = day.ToString();
			if (str3.Length == 1)
			{
				str3 = string.Concat("0", str3);
			}
			day = prmDate.Second;
			str4 = day.ToString();
			if (str4.Length == 1)
			{
				str4 = string.Concat("0", str4);
			}
			str = new string[] { strArrays[prmDate.Month - 1], "-", str1, "-", null, null, null, null, null, null, null };
			day = prmDate.Year;
			str[4] = day.ToString();
			str[5] = " ";
			str[6] = str2;
			str[7] = ":";
			str[8] = str3;
			str[9] = ":";
			str[10] = str4;
			string str5 = string.Concat(str);
			return str5;
		}

		public static string MSAccessDateFIN(DateTime prmDate)
		{
			string[] str = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
			string[] strArrays = str;
			string str1 = "01";
			int day = prmDate.Day;
			str1 = day.ToString();
			if (str1.Length == 1)
			{
				str1 = string.Concat("0", str1);
			}
			str = new string[] { strArrays[prmDate.Month - 1], "-", str1, "-", null, null };
			day = prmDate.Year;
			str[4] = day.ToString();
			str[5] = " 23:59:59";
			string str2 = string.Concat(str);
			return str2;
		}

		public static string MSAccessDateINI(DateTime prmDate)
		{
			string[] str = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
			string[] strArrays = str;
			string str1 = "01";
			int day = prmDate.Day;
			str1 = day.ToString();
			if (str1.Length == 1)
			{
				str1 = string.Concat("0", str1);
			}
			str = new string[] { strArrays[prmDate.Month - 1], "-", str1, "-", null, null };
			day = prmDate.Year;
			str[4] = day.ToString();
			str[5] = " 00:00:00";
			string str2 = string.Concat(str);
			return str2;
		}

		public static string SQLServerDate(DateTime prmDate)
		{
			string str = "1900";
			string str1 = "01";
			string str2 = "01";
			string str3 = "00";
			string str4 = "00";
			string str5 = "00";
			int year = prmDate.Year;
			str = year.ToString();
			year = prmDate.Month;
			str1 = year.ToString();
			if (str1.Length == 1)
			{
				str1 = string.Concat("0", str1);
			}
			year = prmDate.Day;
			str2 = year.ToString();
			if (str2.Length == 1)
			{
				str2 = string.Concat("0", str2);
			}
			year = prmDate.Hour;
			str3 = year.ToString();
			if (str3.Length == 1)
			{
				str3 = string.Concat("0", str3);
			}
			year = prmDate.Minute;
			str4 = year.ToString();
			if (str4.Length == 1)
			{
				str4 = string.Concat("0", str4);
			}
			year = prmDate.Second;
			str5 = year.ToString();
			if (str5.Length == 1)
			{
				str5 = string.Concat("0", str5);
			}
			string[] strArrays = new string[] { str, str1, str2, " ", str3, ":", str4, ":", str5 };
			string str6 = string.Concat(strArrays);
			return str6;
		}

		public static string SQLServerDateFIN(DateTime prmDate)
		{
			string str = "1900";
			string str1 = "01";
			string str2 = "01";
			int year = prmDate.Year;
			str = year.ToString();
			year = prmDate.Month;
			str1 = year.ToString();
			if (str1.Length == 1)
			{
				str1 = string.Concat("0", str1);
			}
			year = prmDate.Day;
			str2 = year.ToString();
			if (str2.Length == 1)
			{
				str2 = string.Concat("0", str2);
			}
			string str3 = string.Concat(str, str1, str2, " 23:59:59");
			return str3;
		}

		public static string SQLServerDateINI(DateTime prmDate)
		{
			string str = "1900";
			string str1 = "01";
			string str2 = "01";
			int year = prmDate.Year;
			str = year.ToString();
			year = prmDate.Month;
			str1 = year.ToString();
			if (str1.Length == 1)
			{
				str1 = string.Concat("0", str1);
			}
			year = prmDate.Day;
			str2 = year.ToString();
			if (str2.Length == 1)
			{
				str2 = string.Concat("0", str2);
			}
			string str3 = string.Concat(str, str1, str2, " 00:00:00");
			return str3;
		}
	}
}