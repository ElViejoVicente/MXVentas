using System;

namespace POSDLL.Windows.Forms
{
	public class KeyboardEventArgs : EventArgs
	{
		private readonly string pvtKeyboardKeyPressed;

		public string KeyboardKeyPressed
		{
			get
			{
				string str = this.pvtKeyboardKeyPressed;
				return str;
			}
		}

		public KeyboardEventArgs(string KeyboardKeyPressed)
		{
			this.pvtKeyboardKeyPressed = KeyboardKeyPressed;
		}
	}
}