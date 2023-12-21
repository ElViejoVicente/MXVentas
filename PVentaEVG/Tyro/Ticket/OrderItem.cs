using System;

namespace POSDLL.Ticket
{
	public class OrderItem
	{
		private char[] delimitador = new char[] { '?' };

		public OrderItem(char delimit)
		{
            char[]  chrArray = new char[] { delimit };
			this.delimitador = chrArray;
		}

		public string GenerateItem(string cantidad, string itemName, string price)
		{
			object[] objArray = new object[] { cantidad, this.delimitador[0], itemName, this.delimitador[0], price };
			string str = string.Concat(objArray);
			return str;
		}

		public string GetItemCantidad(string orderItem)
		{
			string str = orderItem.Split(this.delimitador)[0];
			return str;
		}

		public string GetItemName(string orderItem)
		{
			string str = orderItem.Split(this.delimitador)[1];
			return str;
		}

		public string GetItemPrice(string orderItem)
		{
			string str = orderItem.Split(this.delimitador)[2];
			return str;
		}
	}
}