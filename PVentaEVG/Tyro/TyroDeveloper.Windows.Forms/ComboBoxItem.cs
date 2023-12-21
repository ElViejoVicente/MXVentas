using System;
using System.Drawing;

namespace POSDLL.Windows.Forms
{
	public class ComboBoxItem
	{
		private string text = "";

		private object val;

		private Color foreColor = Color.Black;

		private int index = 0;

		private object tag = null;

		public Color ForeColor
		{
			get
			{
				Color color = this.foreColor;
				return color;
			}
			set
			{
				this.foreColor = value;
			}
		}

		public int Index
		{
			get
			{
				int num = this.index;
				return num;
			}
			set
			{
				this.index = value;
			}
		}

		public object Tag
		{
			get
			{
				object obj = this.tag;
				return obj;
			}
			set
			{
				this.tag = value;
			}
		}

		public string Text
		{
			get
			{
				string str = this.text;
				return str;
			}
			set
			{
				this.text = value;
			}
		}

		public object Value
		{
			get
			{
				object obj = this.val;
				return obj;
			}
			set
			{
				this.val = value;
			}
		}

		public ComboBoxItem()
		{
		}

		public ComboBoxItem(string pText, object pValue)
		{
			this.text = pText;
			this.val = pValue;
		}

		public ComboBoxItem(string pText, object pValue, Color pColor)
		{
			this.text = pText;
			this.val = pValue;
			this.foreColor = pColor;
		}

		public override string ToString()
		{
			string str = this.text;
			return str;
		}
	}
}