using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace POSDLL.Windows.Forms
{
	[ToolboxBitmap(typeof(PictureBox))]
	public class PictureBoxCustom : PictureBox
	{
		public byte[] ImageByteArray
		{
			get
			{
				byte[] byteArray = this.ImageToByteArray();
				return byteArray;
			}
			set
			{
				if (value != null)
				{
					base.Image = System.Drawing.Image.FromStream(new MemoryStream(value));
				}
			}
		}

		public PictureBoxCustom()
		{
		}

		public byte[] ImageToByteArray()
		{
			byte[] array;
			if (base.Image == null)
			{
				array = null;
			}
			else
			{
				MemoryStream memoryStream = new MemoryStream();
				base.Image.Save(memoryStream, base.Image.RawFormat);
				memoryStream.Position = (long)0;
				array = memoryStream.ToArray();
			}
			return array;
		}
	}
}