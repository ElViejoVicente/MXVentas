namespace POSApp.Forms
{
    partial class frmEntradasLista
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
            this.barListaEntradas = new System.Windows.Forms.ToolStrip();
            this.btnAddNew = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnExportar = new System.Windows.Forms.ToolStripButton();
            this.btnFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrint = new System.Windows.Forms.ToolStripSplitButton();
            this.btnPrintList = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrintSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.lvEntrada = new POSDLL.Windows.Forms.PrintableListView();
            this.c_mnuListaFactura = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConsultaFactura = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrintList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrintSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.cboCOLMUNAS = new System.Windows.Forms.ComboBox();
            this.cboORDER = new System.Windows.Forms.ComboBox();
            this.label7 = new Telerik.WinControls.UI.RadLabel();
            this.barListaEntradas.SuspendLayout();
            this.c_mnuListaFactura.SuspendLayout();
            this.SuspendLayout();
            // 
            // barListaEntradas
            // 
            this.barListaEntradas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddNew,
            this.btnRefresh,
            this.btnExportar,
            this.btnFilter,
            this.toolStripSeparator1,
            this.btnPrint,
            this.toolStripSeparator2,
            this.btnClose});
            this.barListaEntradas.Location = new System.Drawing.Point(0, 0);
            this.barListaEntradas.Name = "barListaEntradas";
            this.barListaEntradas.Size = new System.Drawing.Size(784, 38);
            this.barListaEntradas.TabIndex = 0;
            this.barListaEntradas.Text = "toolStrip1";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Image = global::POS.Properties.Resources.DocumentHS;
            this.btnAddNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(88, 35);
            this.btnAddNew.Text = "Nueva entrada";
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
            // lvEntrada
            // 
            this.lvEntrada.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvEntrada.ContextMenuStrip = this.c_mnuListaFactura;
            this.lvEntrada.FitToPage = false;
            this.lvEntrada.FullRowSelect = true;
            this.lvEntrada.GridLines = true;
            this.lvEntrada.HideSelection = false;
            this.lvEntrada.Location = new System.Drawing.Point(0, 86);
            this.lvEntrada.Name = "lvEntrada";
            this.lvEntrada.Size = new System.Drawing.Size(784, 187);
            this.lvEntrada.TabIndex = 1;
            this.lvEntrada.Title = "";
            this.lvEntrada.UseCompatibleStateImageBehavior = false;
            this.lvEntrada.DoubleClick += new System.EventHandler(this.lvEntrada_DoubleClick);
            this.lvEntrada.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvEntrada_KeyPress);
            // 
            // c_mnuListaFactura
            // 
            this.c_mnuListaFactura.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddNew,
            this.mnuRefresh,
            this.mnuConsultaFactura,
            this.mnuPrintList,
            this.mnuPrintSelected});
            this.c_mnuListaFactura.Name = "c_mnuListaFactura";
            this.c_mnuListaFactura.Size = new System.Drawing.Size(237, 136);
            // 
            // mnuAddNew
            // 
            this.mnuAddNew.Image = global::POS.Properties.Resources.DocumentHS;
            this.mnuAddNew.Name = "mnuAddNew";
            this.mnuAddNew.Size = new System.Drawing.Size(236, 22);
            this.mnuAddNew.Text = "Agregar nueva entrada";
            this.mnuAddNew.Click += new System.EventHandler(this.mnuAddNew_Click);
            // 
            // mnuRefresh
            // 
            this.mnuRefresh.Image = global::POS.Properties.Resources.RefreshDocViewHS;
            this.mnuRefresh.Name = "mnuRefresh";
            this.mnuRefresh.Size = new System.Drawing.Size(236, 22);
            this.mnuRefresh.Text = "Actualizar";
            this.mnuRefresh.Click += new System.EventHandler(this.mnuRefresh_Click);
            // 
            // mnuConsultaFactura
            // 
            this.mnuConsultaFactura.Image = global::POS.Properties.Resources.PrintPreviewHS;
            this.mnuConsultaFactura.Name = "mnuConsultaFactura";
            this.mnuConsultaFactura.Size = new System.Drawing.Size(236, 22);
            this.mnuConsultaFactura.Text = "Consultar factura seleccionada";
            this.mnuConsultaFactura.Click += new System.EventHandler(this.mnuConsultaFactura_Click);
            // 
            // mnuPrintList
            // 
            this.mnuPrintList.Image = global::POS.Properties.Resources.printer;
            this.mnuPrintList.Name = "mnuPrintList";
            this.mnuPrintList.Size = new System.Drawing.Size(236, 22);
            this.mnuPrintList.Text = "Imprimir lista";
            this.mnuPrintList.Click += new System.EventHandler(this.mnuPrintList_Click);
            // 
            // mnuPrintSelected
            // 
            this.mnuPrintSelected.Image = global::POS.Properties.Resources.printer;
            this.mnuPrintSelected.Name = "mnuPrintSelected";
            this.mnuPrintSelected.Size = new System.Drawing.Size(236, 22);
            this.mnuPrintSelected.Text = "Imprimir factura seleccionada";
            this.mnuPrintSelected.Click += new System.EventHandler(this.mnuPrintSelected_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ordenar por:";
            // 
            // cboCOLMUNAS
            // 
            this.cboCOLMUNAS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCOLMUNAS.FormattingEnabled = true;
            this.cboCOLMUNAS.Location = new System.Drawing.Point(16, 59);
            this.cboCOLMUNAS.Name = "cboCOLMUNAS";
            this.cboCOLMUNAS.Size = new System.Drawing.Size(258, 21);
            this.cboCOLMUNAS.TabIndex = 3;
            // 
            // cboORDER
            // 
            this.cboORDER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboORDER.FormattingEnabled = true;
            this.cboORDER.Items.AddRange(new object[] {
            "Ascendente",
            "Descendente"});
            this.cboORDER.Location = new System.Drawing.Point(280, 59);
            this.cboORDER.Name = "cboORDER";
            this.cboORDER.Size = new System.Drawing.Size(123, 21);
            this.cboORDER.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(277, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Tipo de orden:";
            // 
            // frmEntradasLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 273);
            this.Controls.Add(this.cboORDER);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboCOLMUNAS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvEntrada);
            this.Controls.Add(this.barListaEntradas);
            this.Name = "frmEntradasLista";
            this.ShowInTaskbar = false;
            this.Text = "Entradas";
            this.Load += new System.EventHandler(this.frmListaEntradas_Load);
            this.barListaEntradas.ResumeLayout(false);
            this.barListaEntradas.PerformLayout();
            this.c_mnuListaFactura.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.ToolStrip barListaEntradas;
        private System.Windows.Forms.ToolStripButton btnAddNew;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnFilter;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSplitButton btnPrint;
        private System.Windows.Forms.ToolStripMenuItem btnPrintList;
        private System.Windows.Forms.ToolStripMenuItem btnPrintSelected;
        private POSDLL.Windows.Forms.PrintableListView lvEntrada;
        private System.Windows.Forms.ContextMenuStrip c_mnuListaFactura;
        private System.Windows.Forms.ToolStripMenuItem mnuConsultaFactura;
        private System.Windows.Forms.ToolStripMenuItem mnuPrintList;
        private System.Windows.Forms.ToolStripMenuItem mnuPrintSelected;
        private System.Windows.Forms.ToolStripMenuItem mnuRefresh;
        private System.Windows.Forms.ToolStripMenuItem mnuAddNew;
        private System.Windows.Forms.ToolStripButton btnExportar;
        private Telerik.WinControls.UI.RadLabel label1;
        private System.Windows.Forms.ComboBox cboCOLMUNAS;
        private System.Windows.Forms.ComboBox cboORDER;
        private Telerik.WinControls.UI.RadLabel label7;
    }
}