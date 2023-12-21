using System;

namespace POSDLL.Ticket
{
	public class OrderTotal
	{
		private char[] delimitador = new char[] { '?' };

		public OrderTotal(char delimit)
		{
            char[] chrArray = new char[] { delimit };
			this.delimitador = chrArray;
		}

		public string GenerateTotal(string totalName, string price)
		{
			string str = string.Concat(totalName, this.delimitador[0], price);
			return str;
		}

		public string GetTotalCantidad(string totalItem)
		{
			string str = totalItem.Split(this.delimitador)[1];
			return str;
		}

		public string GetTotalName(string totalItem)
		{
			string str = totalItem.Split(this.delimitador)[0];
			return str;
		}
	}
}