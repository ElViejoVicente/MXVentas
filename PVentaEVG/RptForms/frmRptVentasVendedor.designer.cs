namespace POSApp.Forms
{
    partial class frmRptVentasVendedor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.barListaVentas = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrint = new System.Windows.Forms.ToolStripSplitButton();
            this.btnPrintList = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrintSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.lvListaVentas = new POSDLL.Windows.Forms.PrintableListView();
            this.c_mnuListaVentas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrintList = new System.Windows.Forms.ToolStripMenuItem();
            this.lblInfo = new Telerik.WinControls.UI.RadLabel();
            this.barListaVentas.SuspendLayout();
            this.c_mnuListaVentas.SuspendLayout();
            this.SuspendLayout();
            // 
            // barListaVentas
            // 
            this.barListaVentas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.btnFilter,
            this.toolStripSeparator1,
            this.btnPrint,
            this.toolStripSeparator2,
            this.btnClose});
            this.barListaVentas.Location = new System.Drawing.Point(0, 0);
            this.barListaVentas.Name = "barListaVentas";
            this.barListaVentas.Size = new System.Drawing.Size(533, 38);
            this.barListaVentas.TabIndex = 3;
            this.barListaVentas.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::POS.Properties.Resources.RefreshDocViewHS;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(63, 35);
            this.btnRefresh.Text = "Actualizar";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Image = global::POS.Properties.Resources.Filter2HS;
            this.btnFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(92, 35);
            this.btnFilter.Text = "Establecer filtro";
            this.btnFilter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // btnPrint
            // 
            this.btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrint.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrintList,
            this.btnPrintSelected});
            this.btnPrint.Image = global::POS.Properties.Resources.printer;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(32, 35);
            this.btnPrint.Text = "Opciones de impresión";
            // 
            // btnPrintList
            // 
            this.btnPrintList.Image = global::POS.Properties.Resources.PrintPreviewHS;
            this.btnPrintList.Name = "btnPrintList";
            this.btnPrintList.Size = new System.Drawing.Size(236, 22);
            this.btnPrintList.Text = "Imprimir lista";
            this.btnPrintList.Click += new System.EventHandler(this.btnPrintList_Click);
            // 
            // btnPrintSelected
            // 
            this.btnPrintSelected.Image = global::POS.Properties.Resources.PrintPreviewHS;
            this.btnPrintSelected.Name = "btnPrintSelected";
            this.btnPrintSelected.Size = new System.Drawing.Size(236, 22);
            this.btnPrintSelected.Text = "Imprimir el ticket seleccionado";
            this.btnPrintSelected.Click += new System.EventHandler(this.btnPrintSelected_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::POS.Properties.Resources.close;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(43, 35);
            this.btnClose.Text = "Cerrar";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lvListaVentas
            // 
            this.lvListaVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvListaVentas.FitToPage = false;
            this.lvListaVentas.FullRowSelect = true;
            this.lvListaVentas.GridLines = true;
            this.lvListaVentas.HideSelection = false;
            this.lvListaVentas.Location = new System.Drawing.Point(12, 41);
            this.lvListaVentas.Name = "lvListaVentas";
            this.lvListaVentas.Size = new System.Drawing.Size(509, 203);
            this.lvListaVentas.TabIndex = 4;
            this.lvListaVentas.Title = "";
            this.lvListaVentas.UseCompatibleStateImageBehavior = false;
            // 
            // c_mnuListaVentas
            // 
            this.c_mnuListaVentas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRefresh,
            this.mnuPrintList});
            this.c_mnuListaVentas.Name = "c_mnuListaFactura";
            this.c_mnuListaVentas.Size = new System.Drawing.Size(145, 48);
            // 
            // mnuRefresh
            // 
            this.mnuRefresh.Image = global::POS.Properties.Resources.RefreshDocViewHS;
            this.mnuRefresh.Name = "mnuRefresh";
            this.mnuRefresh.Size = new System.Drawing.Size(144, 22);
            this.mnuRefresh.Text = "Actualizar";
            // 
            // mnuPrintList
            // 
            this.mnuPrintList.Image = global::POS.Properties.Resources.PrintPreviewHS;
            this.mnuPrintList.Name = "mnuPrintList";
            this.mnuPrintList.Size = new System.Drawing.Size(144, 22);
            this.mnuPrintList.Text = "Imprimir lista";
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(13, 247);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(51, 13);
            this.lblInfo.TabIndex = 5;
            this.lblInfo.Text = "Registros";
            // 
            // frmRptVentasVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 272);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lvListaVentas);
            this.Controls.Add(this.barListaVentas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimumSize = new System.Drawing.Size(539, 300);
            this.Name = "frmRptVentasVendedor";
            this.ShowInTaskbar = false;
            this.Text = "Ventas por empleado";
            this.Load += new System.EventHandler(this.frmRptVentasVendedor_Load);
            this.barListaVentas.ResumeLayout(false);
            this.barListaVentas.PerformLayout();
            this.c_mnuListaVentas.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip barListaVentas;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSplitButton btnPrint;
        private System.Windows.Forms.ToolStripMenuItem btnPrintList;
        private System.Windows.Forms.ToolStripMenuItem btnPrintSelected;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnClose;
        private POSDLL.Windows.Forms.PrintableListView lvListaVentas;
        private System.Windows.Forms.ContextMenuStrip c_mnuListaVentas;
        private System.Windows.Forms.ToolStripMenuItem mnuRefresh;
        private System.Windows.Forms.ToolStripMenuItem mnuPrintList;
        private Telerik.WinControls.UI.RadLabel lblInfo;

    }
}