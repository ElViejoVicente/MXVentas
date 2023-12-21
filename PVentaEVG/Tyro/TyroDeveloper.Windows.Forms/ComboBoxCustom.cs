using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace POSDLL.Windows.Forms
{
	[ToolboxBitmap(typeof(ComboBox))]
	public class ComboBoxCustom : ComboBox
	{
		private object selectedValue = null;

		private string selectedText = "";

		public new string SelectedText
		{
			get
			{
				string text = ((ComboBoxItem)base.SelectedItem).Text;
				return text;
			}
			set
			{
				this.selectedText = value;
				this.SelectItem(value);
			}
		}

		public new object SelectedValue
		{
			get
			{
				object value = null;
				if (this.SelectedIndex >= 0)
				{
					value = ((ComboBoxItem)base.SelectedItem).Value;
				}
				object obj = value;
				return obj;
			}
			set
			{
				this.selectedValue = value;
				this.SelectItem(value);
			}
		}

		public ComboBoxCustom()
		{
			base.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
		}

		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			base.OnDrawItem(e);
			if (e.Index >= 0)
			{
				e.DrawBackground();
				ComboBoxItem item = (ComboBoxItem)base.Items[e.Index];
				item.Index = e.Index;
				Brush solidBrush = new SolidBrush(item.ForeColor);
				if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
				{
					solidBrush = Brushes.Yellow;
				}
				Graphics graphics = e.Graphics;
				string text = item.Text;
				System.Drawing.Font font = this.Font;
				float x = (float)e.Bounds.X;
				Rectangle bounds = e.Bounds;
				graphics.DrawString(text, font, solidBrush, x, (float)bounds.Y);
			}
		}

		protected void SelectItem(object param)
		{
			foreach (ComboBoxItem item in base.Items)
			{
				if (item.Value.ToString() == param.ToString())
				{
					base.SelectedItem = item;
					break;
				}
			}
		}

		protected void SelectItem(string param)
		{
			foreach (ComboBoxItem item in base.Items)
			{
				if (item.Text == param)
				{
					base.SelectedItem = item;
					break;
				}
			}
		}
	}
}