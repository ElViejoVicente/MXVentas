using System;
using System.Drawing;
using System.Windows.Forms;

namespace POSDLL.Windows.Forms
{
	[ToolboxBitmap("TextBoxOnlyLetter.bmp")]
	public class TextBoxOnlyLetter : TextBox
	{
		public TextBoxOnlyLetter()
		{
		}

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			base.OnKeyPress(e);
			if (char.IsLetter(e.KeyChar))
			{
				e.Handled = false;
			}
			else if (char.IsControl(e.KeyChar))
			{
				e.Handled = false;
			}
			else if (!char.IsSeparator(e.KeyChar))
			{
				e.Handled = true;
			}
			else
			{
				e.Handled = false;
			}
		}
	}
}