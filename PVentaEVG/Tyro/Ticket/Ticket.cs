using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace POSDLL.Ticket
{
    public class Ticket
    {
        private ArrayList headerLines = new ArrayList();

        private ArrayList subHeaderLines = new ArrayList();

        private ArrayList items = new ArrayList();

        private ArrayList totales = new ArrayList();

        private ArrayList footerLines = new ArrayList();

        private Image headerImage = null;

        private bool _DrawItemHeaders = true;

        private int count = 0;

        private int maxChar = 40;

        private int maxCharDescription = 20;

        private int imageHeight = 0;

        private float leftMargin = 0f;

        private float topMargin = 3f;

        private string fontName = "Courier New";

        private double fontSize = 9;

        private Font printFont = null;

        private SolidBrush myBrush = new SolidBrush(Color.Black);

        private Graphics gfx = null;

        private string line = null;

        public bool DrawItemHeaders
        {
            set
            {
                this._DrawItemHeaders = value;
            }
        }

        public string FontName
        {
            get
            {
                string str = this.fontName;
                return str;
            }
            set
            {
                if (value != this.fontName)
                {
                    this.fontName = value;
                }
            }
        }

        public double FontSize
        {
            get
            {
                double num = this.fontSize;
                return num;
            }
            set
            {
                if (value != this.fontSize)
                {
                    this.fontSize = value;
                }
            }
        }

        public Image HeaderImage
        {
            get
            {
                Image image = this.headerImage;
                return image;
            }
            set
            {
                if (this.headerImage != value)
                {
                    this.headerImage = value;
                }
            }
        }

        public int MaxChar
        {
            get
            {
                int num = this.maxChar;
                return num;
            }
            set
            {
                if (value != this.maxChar)
                {
                    this.maxChar = value;
                }
            }
        }

        public int MaxCharDescription
        {
            get
            {
                int num = this.maxCharDescription;
                return num;
            }
            set
            {
                if (value != this.maxCharDescription)
                {
                    this.maxCharDescription = value;
                }
            }
        }

        public Ticket()
        {
        }

        public void AddFooterLine(string line)
        {
            this.footerLines.Add(line);
        }

        public void AddHeaderLine(string line)
        {
            this.headerLines.Add(line);
        }

        public void AddItem(string cantidad, string item, string price)
        {
            OrderItem orderItem = new OrderItem('?');
            this.items.Add(orderItem.GenerateItem(cantidad, item, price));
        }

        public void AddSubHeaderLine(string line)
        {
            this.subHeaderLines.Add(line);
        }

        public void AddTotal(string name, string price)
        {
            OrderTotal orderTotal = new OrderTotal('?');
            this.totales.Add(orderTotal.GenerateTotal(name, price));
        }

        private string AlignRightText(int lenght)
        {
            string str = "";
            int num = this.maxChar - lenght;
            for (int i = 0; i < num; i++)
            {
                str = string.Concat(str, " ");
            }
            string str1 = str;
            return str1;
        }

        private string DottedLine()
        {
            string str = "";
            for (int i = 0; i < this.maxChar; i++)
            {
                str = string.Concat(str, "=");
            }
            string str1 = str;
            return str1;
        }

        private void DrawEspacio()
        {
            this.line = "";
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket = this;
            ticket.count = ticket.count + 1;
        }

        private void DrawFooter()
        {
            foreach (string footerLine in this.footerLines)
            {
                if (footerLine.Length <= this.maxChar)
                {
                    this.line = footerLine;
                    this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    Ticket ticket = this;
                    ticket.count = ticket.count + 1;
                }
                else
                {
                    int num = 0;
                    for (int i = footerLine.Length; i > this.maxChar; i = i - this.maxChar)
                    {
                        this.line = footerLine;
                        this.gfx.DrawString(this.line.Substring(num, this.maxChar), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                        Ticket ticket1 = this;
                        ticket1.count = ticket1.count + 1;
                        num = num + this.maxChar;
                    }
                    this.line = footerLine;
                    this.gfx.DrawString(this.line.Substring(num, this.line.Length - num), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    Ticket ticket2 = this;
                    ticket2.count = ticket2.count + 1;
                }
            }
            this.leftMargin = 0f;
            this.DrawEspacio();
        }

        private void DrawHeader()
        {
            foreach (string headerLine in this.headerLines)
            {
                if (headerLine.Length <= this.maxChar)
                {
                    this.line = headerLine;
                    this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    Ticket ticket = this;
                    ticket.count = ticket.count + 1;
                }
                else
                {
                    int num = 0;
                    for (int i = headerLine.Length; i > this.maxChar; i = i - this.maxChar)
                    {
                        this.line = headerLine.Substring(num, this.maxChar);
                        this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                        Ticket ticket1 = this;
                        ticket1.count = ticket1.count + 1;
                        num = num + this.maxChar;
                    }
                    this.line = headerLine;
                    this.gfx.DrawString(this.line.Substring(num, this.line.Length - num), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    Ticket ticket2 = this;
                    ticket2.count = ticket2.count + 1;
                }
            }
            this.DrawEspacio();
        }

        private void DrawImage()
        {
            if (this.headerImage != null)
            {
                try
                {
                    this.gfx.DrawImage(this.headerImage, new Point((int)this.leftMargin, (int)this.YPosition()));
                    double height = (double)this.headerImage.Height / 58 * 15;
                    this.imageHeight = (int)Math.Round(height) + 10;
                }
                catch (Exception exception)
                {
                }
            }
        }

        private void DrawItems()
        {
            OrderItem orderItem = new OrderItem('?');
            if (this._DrawItemHeaders)
            {
                this.gfx.DrawString("CANT  DESCRIPCION                IMPORTE", this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            }
            Ticket ticket = this;
            ticket.count = ticket.count + 1;
            this.DrawEspacio();
            foreach (string item in this.items)
            {
                this.line = orderItem.GetItemCantidad(item);
                this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                this.line = orderItem.GetItemPrice(item);
                this.line = string.Concat(this.AlignRightText(this.line.Length), this.line);
                this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                string itemName = orderItem.GetItemName(item);
                this.leftMargin = 0f;
                if (itemName.Length <= this.maxCharDescription)
                {
                    this.gfx.DrawString(string.Concat("      ", orderItem.GetItemName(item)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    Ticket ticket1 = this;
                    ticket1.count = ticket1.count + 1;
                }
                else
                {
                    int num = 0;
                    for (int i = itemName.Length; i > this.maxCharDescription; i = i - this.maxCharDescription)
                    {
                        this.line = orderItem.GetItemName(item);
                        this.gfx.DrawString(string.Concat("      ", this.line.Substring(num, this.maxCharDescription)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                        Ticket ticket2 = this;
                        ticket2.count = ticket2.count + 1;
                        num = num + this.maxCharDescription;
                    }
                    this.line = orderItem.GetItemName(item);
                    this.gfx.DrawString(string.Concat("      ", this.line.Substring(num, this.line.Length - num)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    Ticket ticket3 = this;
                    ticket3.count = ticket3.count + 1;
                }
            }
            this.leftMargin = 0f;
            this.DrawEspacio();
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket4 = this;
            ticket4.count = ticket4.count + 1;
            this.DrawEspacio();
        }

        private void DrawSubHeader()
        {
            foreach (string subHeaderLine in this.subHeaderLines)
            {
                if (subHeaderLine.Length <= this.maxChar)
                {
                    this.line = subHeaderLine;
                    this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    Ticket ticket = this;
                    ticket.count = ticket.count + 1;
                    this.line = this.DottedLine();
                    this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    Ticket ticket1 = this;
                    ticket1.count = ticket1.count + 1;
                }
                else
                {
                    int num = 0;
                    for (int i = subHeaderLine.Length; i > this.maxChar; i = i - this.maxChar)
                    {
                        this.line = subHeaderLine;
                        this.gfx.DrawString(this.line.Substring(num, this.maxChar), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                        Ticket ticket2 = this;
                        ticket2.count = ticket2.count + 1;
                        num = num + this.maxChar;
                    }
                    this.line = subHeaderLine;
                    this.gfx.DrawString(this.line.Substring(num, this.line.Length - num), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    Ticket ticket3 = this;
                    ticket3.count = ticket3.count + 1;
                }
            }
            this.DrawEspacio();
        }

        private void DrawTotales()
        {
            OrderTotal orderTotal = new OrderTotal('?');
            foreach (string totale in this.totales)
            {
                this.line = orderTotal.GetTotalCantidad(totale);
                this.line = string.Concat(this.AlignRightText(this.line.Length), this.line);
                this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                this.leftMargin = 0f;
                string totalName = orderTotal.GetTotalName(totale) ?? "";
                this.line = totalName;
                this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                Ticket ticket = this;
                ticket.count = ticket.count + 1;
            }
            this.leftMargin = 0f;
            this.DrawEspacio();
            this.DrawEspacio();
        }

        private string GetDefaultPrinter()
        {
            string empty;
            PrinterSettings printerSetting = new PrinterSettings();
            foreach (string installedPrinter in PrinterSettings.InstalledPrinters)
            {
                printerSetting.PrinterName = installedPrinter;
                if (printerSetting.IsDefaultPrinter)
                {
                    empty = installedPrinter;
                    return empty;
                }
            }
            empty = string.Empty;
            return empty;
        }

        private void pr_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            this.gfx = e.Graphics;

            this.count = 0; // 2022-11-01 esto por que no se reseta  y al imprimir el texto esta mas abajo de normal
            imageHeight = 0; // 2022-11-01 esto por que no se reseta  y entra  2 veces al evento
            leftMargin = 0f; // 2022-11-01 esto por que no se reseta  y entra  2 veces al evento
            topMargin = 3f; // 2022-11-01 esto por que no se reseta  y entra  2 veces al evento

            this.DrawImage();
            this.DrawHeader();
            this.DrawSubHeader();
            this.DrawItems();
            this.DrawTotales();
            this.DrawFooter();
            //if (this.headerImage != null)
            //{
            //	this.HeaderImage.Dispose();
            //	this.headerImage.Dispose();
            //}
        }

        public bool PrinterExists(string impresora)
        {
            bool flag;
            foreach (string installedPrinter in PrinterSettings.InstalledPrinters)
            {
                if (impresora == installedPrinter)
                {
                    flag = true;
                    return flag;
                }
            }
            flag = false;
            return flag;
        }

        public void PrintTicket(string impresora)
        {
            this.printFont = new Font(this.fontName, (float)this.fontSize, FontStyle.Regular);
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrinterSettings.PrinterName = impresora;
            printDocument.PrintPage += new PrintPageEventHandler(this.pr_PrintPage);
            printDocument.Print();
        }

        public void PrintTicket()
        {
            this.PrintTicket(this.GetDefaultPrinter());
        }

        public void PrintTicketPreview(string impresora)
        {
            this.printFont = new Font(this.fontName, (float)this.fontSize, FontStyle.Regular);
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrinterSettings.PrinterName = impresora;
            printDocument.PrintPage += new PrintPageEventHandler(this.pr_PrintPage);
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.PrintPreviewControl.Zoom = 1;
            printPreviewDialog.ShowDialog();
        }

        public void PrintTicketPreview()
        {
            this.PrintTicketPreview(this.GetDefaultPrinter());
        }

        private float YPosition()
        {
            float height = this.topMargin + (float)this.count * this.printFont.GetHeight(this.gfx) + (float)this.imageHeight;
            return height;
        }
    }
}