namespace POSApp.Forms
{
    partial class frmFacturasLista
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
            this.barListaFacturas = new System.Windows.Forms.ToolStrip();
            this.btnAddNew = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportar = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripSplitButton();
            this.btnPrintList = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrintSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.lvFactura = new POSDLL.Windows.Forms.PrintableListView();
            this.c_mnuListaFactura = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrintList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrintSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.c_mnuCancelarFactura = new System.Windows.Forms.ToolStripMenuItem();
            this.barListaFacturas.SuspendLayout();
            this.c_mnuListaFactura.SuspendLayout();
            this.SuspendLayout();
            // 
            // barListaFacturas
            // 
            this.barListaFacturas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddNew,
            this.btnRefresh,
            this.btnFilter,
            this.toolStripSeparator1,
            this.btnExportar,
            this.btnPrint,
            this.toolStripSeparator2,
            this.btnClose});
            this.barListaFacturas.Location = new System.Drawing.Point(0, 0);
            this.barListaFacturas.Name = "barListaFacturas";
            this.barListaFacturas.Size = new System.Drawing.Size(744, 38);
            this.barListaFacturas.TabIndex = 1;
            this.barListaFacturas.Text = "toolStrip1";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Image = global::POS.Properties.Resources.DocumentHS;
            this.btnAddNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(81, 35);
            this.btnAddNew.Text = "Nueva facura";
            this.btnAddNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
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
            // btnExportar
            // 
            this.btnExportar.Image = global::POS.Properties.Resources.excel;
            this.btnExportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(54, 35);
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrintList,
            this.btnPrintSelected});
            this.btnPrint.Image = global::POS.Properties.Resources.printer;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(69, 35);
            this.btnPrint.Text = "Imprimir";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnPrintList
            // 
            this.btnPrintList.Image = global::POS.Properties.Resources.PrintPreviewHS;
            this.btnPrintList.Name = "btnPrintList";
            this.btnPrintList.Size = new System.Drawing.Size(257, 22);
            this.btnPrintList.Text = "Imprimir lista";
            this.btnPrintList.Click += new System.EventHandler(this.btnPrintList_Click);
            // 
            // btnPrintSelected
            // 
            this.btnPrintSelected.Image = global::POS.Properties.Resources.PrintPreviewHS;
            this.btnPrintSelected.Name = "btnPrintSelected";
            this.btnPrintSelected.Size = new System.Drawing.Size(257, 22);
            this.btnPrintSelected.Text = "Imprimir el elemento seleccionado";
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
            this.btnClose.Size = new System.Drawing.Size(40, 35);
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lvFactura
            // 
            this.lvFactura.ContextMenuStrip = this.c_mnuListaFactura;
            this.lvFactura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFactura.FitToPage = false;
            this.lvFactura.FullRowSelect = true;
            this.lvFactura.GridLines = true;
            this.lvFactura.HideSelection = false;
            this.lvFactura.Location = new System.Drawing.Point(0, 38);
            this.lvFactura.Name = "lvFactura";
            this.lvFactura.Size = new System.Drawing.Size(744, 233);
            this.lvFactura.TabIndex = 2;
            this.lvFactura.Title = "";
            this.lvFactura.UseCompatibleStateImageBehavior = false;
            // 
            // c_mnuListaFactura
            // 
            this.c_mnuListaFactura.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddNew,
            this.mnuRefresh,
            this.mnuPrintList,
            this.mnuPrintSelected,
            this.c_mnuCancelarFactura});
            this.c_mnuListaFactura.Name = "c_mnuListaFactura";
            this.c_mnuListaFactura.Size = new System.Drawing.Size(232, 136);
            // 
            // mnuAddNew
            // 
            this.mnuAddNew.Image = global::POS.Properties.Resources.DocumentHS;
            this.mnuAddNew.Name = "mnuAddNew";
            this.mnuAddNew.Size = new System.Drawing.Size(231, 22);
            this.mnuAddNew.Text = "Agregar nueva factura";
            this.mnuAddNew.Click += new System.EventHandler(this.mnuAddNew_Click);
            // 
            // mnuRefresh
            // 
            this.mnuRefresh.Image = global::POS.Properties.Resources.RefreshDocViewHS;
            this.mnuRefresh.Name = "mnuRefresh";
            this.mnuRefresh.Size = new System.Drawing.Size(231, 22);
            this.mnuRefresh.Text = "Actualizar";
            this.mnuRefresh.Click += new System.EventHandler(this.mnuRefresh_Click);
            // 
            // mnuPrintList
            // 
            this.mnuPrintList.Image = global::POS.Properties.Resources.PrintPreviewHS;
            this.mnuPrintList.Name = "mnuPrintList";
            this.mnuPrintList.Size = new System.Drawing.Size(231, 22);
            this.mnuPrintList.Text = "Imprimir lista";
            this.mnuPrintList.Click += new System.EventHandler(this.mnuPrintList_Click);
            // 
            // mnuPrintSelected
            // 
            this.mnuPrintSelected.Image = global::POS.Properties.Resources.PrintPreviewHS;
            this.mnuPrintSelected.Name = "mnuPrintSelected";
            this.mnuPrintSelected.Size = new System.Drawing.Size(231, 22);
            this.mnuPrintSelected.Text = "Imprimir factura seleccionada";
            this.mnuPrintSelected.Click += new System.EventHandler(this.mnuPrintSelected_Click);
            // 
            // c_mnuCancelarFactura
            // 
            this.c_mnuCancelarFactura.Image = global::POS.Properties.Resources.delete;
            this.c_mnuCancelarFactura.Name = "c_mnuCancelarFactura";
            this.c_mnuCancelarFactura.Size = new System.Drawing.Size(231, 22);
            this.c_mnuCancelarFactura.Text = "Cancelar factura";
            this.c_mnuCancelarFactura.Click += new System.EventHandler(this.c_mnuCancelarFactura_Click);
            // 
            // frmListaFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 271);
            this.Controls.Add(this.lvFactura);
            this.Controls.Add(this.barListaFacturas);
            this.Name = "frmListaFacturas";
            this.Text = "Lista de facturas";
            this.Load += new System.EventHandler(this.frmListaFacturas_Load);
            this.barListaFacturas.ResumeLayout(false);
            this.barListaFacturas.PerformLayout();
            this.c_mnuListaFactura.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip barListaFacturas;
        private System.Windows.Forms.ToolStripButton btnAddNew;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSplitButton btnPrint;
        private System.Windows.Forms.ToolStripMenuItem btnPrintList;
        private System.Windows.Forms.ToolStripMenuItem btnPrintSelected;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnClose;
        private POSDLL.Windows.Forms.PrintableListView lvFactura;
        private System.Windows.Forms.ContextMenuStrip c_mnuListaFactura;
        private System.Windows.Forms.ToolStripMenuItem mnuAddNew;
        private System.Windows.Forms.ToolStripMenuItem mnuRefresh;
        private System.Windows.Forms.ToolStripMenuItem mnuPrintList;
        private System.Windows.Forms.ToolStripMenuItem mnuPrintSelected;
        private System.Windows.Forms.ToolStripButton btnExportar;
        private System.Windows.Forms.ToolStripMenuItem c_mnuCancelarFactura;
    }
}