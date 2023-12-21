using System;
using System.Drawing;
using System.Windows.Forms;

namespace POSDLL.Windows.Forms
{
	[ToolboxBitmap("TextBoxOnlyNumeric.bmp")]
	public class TextBoxOnlyNumeric : TextBox
	{
		private bool allowNegativeValues = true;

		private bool allowDecimalValues = true;

		private int decimalLength = 3;

		public bool AllowDecimalValues
		{
			get
			{
				bool flag = this.allowDecimalValues;
				return flag;
			}
			set
			{
				this.allowDecimalValues = value;
			}
		}

		public bool AllowNegativeValues
		{
			get
			{
				bool flag = this.allowNegativeValues;
				return flag;
			}
			set
			{
				this.allowNegativeValues = value;
			}
		}

		public int DecimalLength
		{
			get
			{
				int num = this.decimalLength;
				return num;
			}
			set
			{
				this.decimalLength = value;
			}
		}

		public TextBoxOnlyNumeric()
		{
		}

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			bool flag;
			bool flag1;
			bool flag2;
			bool flag3;
			bool flag4;
			bool flag5;
			base.OnKeyPress(e);
			if (e.KeyChar != '\b')
			{
				if (!this.allowDecimalValues)
				{
					flag5 = (e.KeyChar == '.' ? false : e.KeyChar != ',');
					if (!flag5)
					{
						e.Handled = true;
						return;
					}
				}
				if (base.Text.Length == 0)
				{
					if (e.KeyChar == Convert.ToChar("-"))
					{
						if (!this.allowNegativeValues)
						{
							e.Handled = true;
						}
						else
						{
							e.Handled = false;
						}
						return;
					}
				}
				bool flag6 = false;
				int num = 0;
				int num1 = 0;
				while (num1 < base.Text.Length)
				{
					flag = (base.Text[num1] == '.' ? false : base.Text[num1] != ',');
					if (!flag)
					{
						flag6 = true;
					}
					if (!flag6)
					{
						flag1 = true;
					}
					else
					{
						int num2 = num;
						num = num2 + 1;
						flag1 = num2 < this.decimalLength;
					}
					if (flag1)
					{
						num1++;
					}
					else
					{
						e.Handled = true;
						return;
					}
				}
				flag2 = (e.KeyChar < '0' ? true : e.KeyChar > '9');
				if (flag2)
				{
					flag3 = (e.KeyChar == '.' ? false : e.KeyChar != ',');
					if (flag3)
					{
						e.Handled = true;
					}
					else
					{
						KeyPressEventArgs keyPressEventArg = e;
						flag4 = (flag6 ? true : false);
						keyPressEventArg.Handled = flag4;
					}
				}
				else
				{
					e.Handled = false;
				}
			}
			else
			{
				e.Handled = false;
			}
		}
	}
}