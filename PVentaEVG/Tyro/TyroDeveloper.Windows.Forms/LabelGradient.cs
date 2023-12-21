using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace POSDLL.Windows.Forms
{
	[ToolboxBitmap("LabelGradient.bmp")]
	public class LabelGradient : Label
	{
		protected Color gradientColorOne = SystemColors.ButtonHighlight;

		protected Color gradientColorTwo = SystemColors.ButtonFace;

		protected LinearGradientMode lgm = LinearGradientMode.Vertical;

		protected Border3DStyle b3dstyle = Border3DStyle.Flat;

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override Color BackColor
		{
			get
			{
				Color color = new Color();
				Color color1 = color;
				return color1;
			}
			set
			{
			}
		}

		[Category("Appearance")]
		[DefaultValue(typeof(Border3DStyle), "Bump")]
		[Description("BorderStyle")]
		public new Border3DStyle BorderStyle
		{
			get
			{
				Border3DStyle border3DStyle = this.b3dstyle;
				return border3DStyle;
			}
			set
			{
				this.b3dstyle = value;
				base.Invalidate();
			}
		}

		[Category("Appearance")]
		[DefaultValue(typeof(Color), "White")]
		[Description("The first gradient color.")]
		public Color GradientColorOne
		{
			get
			{
				Color color = this.gradientColorOne;
				return color;
			}
			set
			{
				this.gradientColorOne = value;
				base.Invalidate();
			}
		}

		[Category("Appearance")]
		[DefaultValue(typeof(Color), "Blue")]
		[Description("The second gradient color.")]
		public Color GradientColorTwo
		{
			get
			{
				Color color = this.gradientColorTwo;
				return color;
			}
			set
			{
				this.gradientColorTwo = value;
				base.Invalidate();
			}
		}

		[Category("Appearance")]
		[DefaultValue(typeof(LinearGradientMode), "ForwardDiagonal")]
		[Description("Gradient Mode")]
		public LinearGradientMode GradientMode
		{
			get
			{
				LinearGradientMode linearGradientMode = this.lgm;
				return linearGradientMode;
			}
			set
			{
				this.lgm = value;
				base.Invalidate();
			}
		}

		public LabelGradient()
		{
		}

		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			Graphics graphics = pevent.Graphics;
			Rectangle rectangle = new Rectangle(0, 0, base.Width, base.Height);
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle, this.gradientColorOne, this.gradientColorTwo, this.lgm);
			try
			{
				graphics.FillRectangle(linearGradientBrush, rectangle);
			}
			finally
			{
				if (linearGradientBrush != null)
				{
					((IDisposable)linearGradientBrush).Dispose();
				}
			}
			ControlPaint.DrawBorder3D(graphics, rectangle, this.b3dstyle);
		}
	}
}