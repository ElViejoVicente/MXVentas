using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace POSDLL.Windows.Forms
{
	[ToolboxBitmap("PrintableListView.bmp")]
	public class PrintableListView : ListView
	{
		private PrintDocument m_printDoc = new PrintDocument();

		private PageSetupDialog m_setupDlg = new PageSetupDialog();

		private PrintPreviewDialog m_previewDlg = new PrintPreviewDialog();

		private PrintDialog m_printDlg = new PrintDialog();

		private int m_nPageNumber = 1;

		private int m_nStartRow = 0;

		private int m_nStartCol = 0;

		private bool m_bPrintSel = false;

		private bool m_bFitToPage = false;

		private float m_fListWidth = 0f;

		private float[] m_arColsWidth;

		private float m_fDpi = 96f;

		private string m_strTitle = "";

		private System.ComponentModel.Container components = null;

		public bool FitToPage
		{
			get
			{
				bool mBFitToPage = this.m_bFitToPage;
				return mBFitToPage;
			}
			set
			{
				this.m_bFitToPage = value;
			}
		}

		public string Title
		{
			get
			{
				string mStrTitle = this.m_strTitle;
				return mStrTitle;
			}
			set
			{
				this.m_strTitle = value;
			}
		}

		public PrintableListView()
		{
			this.InitializeComponent();
			this.m_printDoc.BeginPrint += new PrintEventHandler(this.OnBeginPrint);
			this.m_printDoc.PrintPage += new PrintPageEventHandler(this.OnPrintPage);
			this.m_setupDlg.Document = this.m_printDoc;
			this.m_previewDlg.Document = this.m_printDoc;
			this.m_printDlg.Document = this.m_printDoc;
			this.m_printDlg.AllowSomePages = false;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.components != null)
				{
					this.components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private ListViewItem GetItem(int index)
		{
			ListViewItem listViewItem;
			listViewItem = (this.m_bPrintSel ? base.SelectedItems[index] : base.Items[index]);
			ListViewItem listViewItem1 = listViewItem;
			return listViewItem1;
		}

		private int GetItemsCount()
		{
			int num;
			num = (this.m_bPrintSel ? base.SelectedItems.Count : base.Items.Count);
			int num1 = num;
			return num1;
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
		}

		private void OnBeginPrint(object sender, PrintEventArgs e)
		{
			this.PreparePrint();
		}

		private void OnPrintPage(object sender, PrintPageEventArgs e)
		{
			RectangleF rectangleF;
			ColumnHeader item;
			StringFormat stringFormat;
			RectangleF rectangleF1;
			Rectangle marginBounds;
			bool flag;
			bool flag1;
			bool flag2;
			string str;
			System.Drawing.Font font;
			bool flag3;
			int itemsCount = this.GetItemsCount();
			flag = (itemsCount == 0 ? false : this.m_nStartRow < itemsCount);
			if (flag)
			{
				int num = 0;
				float left = 0f;
				float top = 0f;
				float single = 4f;
				float width = 1f;
				float height = 0f;
				float mArColsWidth = 0f;
				bool flag4 = false;
				Graphics graphics = e.Graphics;
				if (graphics.VisibleClipBounds.X >= 0f)
				{
					float left1 = (float)e.MarginBounds.Left;
					float width1 = (float)e.PageBounds.Width;
					RectangleF visibleClipBounds = graphics.VisibleClipBounds;
					float single1 = left1 - (width1 - visibleClipBounds.Width) / 2f;
					float top1 = (float)e.MarginBounds.Top;
					float height1 = (float)e.PageBounds.Height;
					visibleClipBounds = graphics.VisibleClipBounds;
					float height2 = top1 - (height1 - visibleClipBounds.Height) / 2f;
					float width2 = (float)e.MarginBounds.Width;
					marginBounds = e.MarginBounds;
					rectangleF = new RectangleF(single1, height2, width2, (float)marginBounds.Height);
				}
				else
				{
					rectangleF = e.MarginBounds;
					rectangleF = new RectangleF(rectangleF.X / this.m_fDpi * 100f, rectangleF.Y / this.m_fDpi * 100f, rectangleF.Width / this.m_fDpi * 100f, rectangleF.Height / this.m_fDpi * 100f);
				}
				RectangleF rectangleF2 = RectangleF.Inflate(rectangleF, 0f, -2f * this.Font.GetHeight(graphics));
				StringFormat stringFormat1 = new StringFormat();
				stringFormat1.Alignment = StringAlignment.Center;
				graphics.DrawString(this.m_strTitle, this.Font, Brushes.Black, rectangleF, stringFormat1);
				stringFormat1.LineAlignment = StringAlignment.Far;
				graphics.DrawString(string.Concat("Page ", this.m_nPageNumber), this.Font, Brushes.Black, rectangleF, stringFormat1);
				flag1 = (this.m_nStartCol != 0 || !this.m_bFitToPage ? true : this.m_fListWidth <= rectangleF2.Width);
				if (!flag1)
				{
					width = rectangleF2.Width / this.m_fListWidth;
				}
				rectangleF = new RectangleF(rectangleF.X / width, rectangleF.Y / width, rectangleF.Width / width, rectangleF.Height / width);
				rectangleF2 = new RectangleF(rectangleF2.X / width, rectangleF2.Y / width, rectangleF2.Width / width, rectangleF2.Height / width);
				graphics.ScaleTransform(width, width);
				graphics.PageUnit = GraphicsUnit.Inch;
				graphics.PageScale = 0.01f;
				num = 0;
				top = rectangleF2.Top;
				Brush solidBrush = new SolidBrush(Color.LightGray);
				System.Drawing.Font font1 = new System.Drawing.Font(this.Font, FontStyle.Bold);
				height = font1.GetHeight(graphics) * 3f;
				left = rectangleF2.Left;
				int mNStartCol = this.m_nStartCol;
				while (mNStartCol < base.Columns.Count)
				{
					item = base.Columns[mNStartCol];
					mArColsWidth = this.m_arColsWidth[mNStartCol];
					if (left + mArColsWidth > rectangleF2.Right)
					{
						if (mNStartCol == this.m_nStartCol)
						{
							flag4 = true;
						}
						num = mNStartCol;
						break;
					}
					else
					{
						graphics.FillRectangle(solidBrush, left, top, mArColsWidth, height);
						graphics.DrawRectangle(Pens.Black, left, top, mArColsWidth, height);
						stringFormat = new StringFormat();
						if (item.TextAlign == HorizontalAlignment.Left)
						{
							stringFormat.Alignment = StringAlignment.Near;
						}
						else if (item.TextAlign != HorizontalAlignment.Center)
						{
							stringFormat.Alignment = StringAlignment.Far;
						}
						else
						{
							stringFormat.Alignment = StringAlignment.Center;
						}
						stringFormat.LineAlignment = StringAlignment.Center;
						stringFormat.FormatFlags = StringFormatFlags.NoWrap;
						stringFormat.Trimming = StringTrimming.EllipsisCharacter;
						rectangleF1 = new RectangleF(left + single, top, mArColsWidth - 1f - 2f * single, height);
						graphics.DrawString(item.Text, font1, Brushes.Black, rectangleF1, stringFormat);
						left = left + mArColsWidth;
						mNStartCol++;
					}
				}
				top = top + height;
				int mNStartRow = this.m_nStartRow;
				bool flag5 = false;
				while (true)
				{
					flag2 = (flag5 ? false : mNStartRow < itemsCount);
					if (!flag2)
					{
						break;
					}
					ListViewItem listViewItem = this.GetItem(mNStartRow);
					marginBounds = listViewItem.Bounds;
					height = (float)marginBounds.Height / this.m_fDpi * 100f + 5f;
					if (top + height <= rectangleF2.Bottom)
					{
						left = rectangleF2.Left;
						mNStartCol = this.m_nStartCol;
						while (mNStartCol < base.Columns.Count)
						{
							item = base.Columns[mNStartCol];
							mArColsWidth = this.m_arColsWidth[mNStartCol];
							if (left + mArColsWidth > rectangleF2.Right)
							{
								num = mNStartCol;
								break;
							}
							else
							{
								graphics.DrawRectangle(Pens.Black, left, top, mArColsWidth, height);
								stringFormat = new StringFormat();
								if (item.TextAlign == HorizontalAlignment.Left)
								{
									stringFormat.Alignment = StringAlignment.Near;
								}
								else if (item.TextAlign != HorizontalAlignment.Center)
								{
									stringFormat.Alignment = StringAlignment.Far;
								}
								else
								{
									stringFormat.Alignment = StringAlignment.Center;
								}
								stringFormat.LineAlignment = StringAlignment.Center;
								stringFormat.FormatFlags = StringFormatFlags.NoWrap;
								stringFormat.Trimming = StringTrimming.EllipsisCharacter;
								str = (mNStartCol == 0 ? listViewItem.Text : listViewItem.SubItems[mNStartCol].Text);
								string str1 = str;
								font = (mNStartCol == 0 ? listViewItem.Font : listViewItem.SubItems[mNStartCol].Font);
								System.Drawing.Font font2 = font;
								rectangleF1 = new RectangleF(left + single, top, mArColsWidth - 1f - 2f * single, height);
								graphics.DrawString(str1, font2, Brushes.Black, rectangleF1, stringFormat);
								left = left + mArColsWidth;
								mNStartCol++;
							}
						}
						top = top + height;
						mNStartRow++;
					}
					else
					{
						flag5 = true;
					}
				}
				if (num == 0)
				{
					this.m_nStartRow = mNStartRow;
				}
				this.m_nStartCol = num;
				PrintableListView mNPageNumber = this;
				mNPageNumber.m_nPageNumber = mNPageNumber.m_nPageNumber + 1;
				PrintPageEventArgs printPageEventArg = e;
				flag3 = (flag4 || this.m_nStartRow <= 0 || this.m_nStartRow >= itemsCount ? this.m_nStartCol > 0 : true);
				printPageEventArg.HasMorePages = flag3;
				if (!e.HasMorePages)
				{
					this.m_nPageNumber = 1;
					this.m_nStartRow = 0;
					this.m_nStartCol = 0;
				}
				solidBrush.Dispose();
			}
			else
			{
				e.HasMorePages = false;
			}
		}

		public void PageSetup()
		{
			this.m_setupDlg.ShowDialog();
		}

		private void PreparePrint()
		{
			this.m_fListWidth = 0f;
			this.m_arColsWidth = new float[base.Columns.Count];
			Graphics graphic = base.CreateGraphics();
			this.m_fDpi = graphic.DpiX;
			graphic.Dispose();
			for (int i = 0; i < base.Columns.Count; i++)
			{
				ColumnHeader item = base.Columns[i];
				float width = (float)item.Width / this.m_fDpi * 100f + 1f;
				PrintableListView mFListWidth = this;
				mFListWidth.m_fListWidth = mFListWidth.m_fListWidth + width;
				this.m_arColsWidth[i] = width;
			}
			PrintableListView printableListView = this;
			printableListView.m_fListWidth = printableListView.m_fListWidth + 1f;
		}

		public void Print()
		{
			this.m_printDlg.AllowSelection = base.SelectedItems.Count > 0;
			if (this.m_printDlg.ShowDialog(this) == DialogResult.OK)
			{
				this.m_printDoc.DocumentName = this.m_strTitle;
				this.m_bPrintSel = this.m_printDlg.PrinterSettings.PrintRange == PrintRange.Selection;
				this.m_nPageNumber = 1;
				this.m_printDoc.Print();
			}
		}

		public void PrintPreview()
		{
			this.m_printDoc.DocumentName = "List View";
			this.m_nPageNumber = 1;
			this.m_bPrintSel = false;
			this.m_previewDlg.ShowDialog(this);
		}
	}
}