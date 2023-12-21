namespace POSApp.Forms
{
    partial class frmSalidaLista
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
            this.barListaSalidas = new System.Windows.Forms.ToolStrip();
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
            this.lvSalida = new POSDLL.Windows.Forms.PrintableListView();
            this.cboORDER = new System.Windows.Forms.ComboBox();
            this.label7 = new Telerik.WinControls.UI.RadLabel();
            this.cboCOLMUNAS = new System.Windows.Forms.ComboBox();
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.c_mnuSalidas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.c_mnuImprimirSeleccionado = new System.Windows.Forms.ToolStripMenuItem();
            this.barListaSalidas.SuspendLayout();
            this.c_mnuSalidas.SuspendLayout();
            this.SuspendLayout();
            // 
            // barListaSalidas
            // 
            this.barListaSalidas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddNew,
            this.btnRefresh,
            this.btnExportar,
            this.btnFilter,
            this.toolStripSeparator1,
            this.btnPrint,
            this.toolStripSeparator2,
            this.btnClose});
            this.barListaSalidas.Location = new System.Drawing.Point(0, 0);
            this.barListaSalidas.Name = "barListaSalidas";
            this.barListaSalidas.Size = new System.Drawing.Size(761, 38);
            this.barListaSalidas.TabIndex = 1;
            this.barListaSalidas.Text = "toolStrip1";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Image = global::POS.Properties.Resources.DocumentHS;
            this.btnAddNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(78, 35);
            this.btnAddNew.Text = "Nueva salida";
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
            this.btnPrintList.Name = "btnPrintList";
            this.btnPrintList.Size = new System.Drawing.Size(257, 22);
            this.btnPrintList.Text = "Imprimir lista";
            // 
            // btnPrintSelected
            // 
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
            // lvSalida
            // 
            this.lvSalida.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSalida.ContextMenuStrip = this.c_mnuSalidas;
            this.lvSalida.FitToPage = false;
            this.lvSalida.FullRowSelect = true;
            this.lvSalida.GridLines = true;
            this.lvSalida.HideSelection = false;
            this.lvSalida.Location = new System.Drawing.Point(12, 95);
            this.lvSalida.Name = "lvSalida";
            this.lvSalida.Size = new System.Drawing.Size(737, 349);
            this.lvSalida.TabIndex = 2;
            this.lvSalida.Title = "";
            this.lvSalida.UseCompatibleStateImageBehavior = false;
            // 
            // cboORDER
            // 
            this.cboORDER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboORDER.FormattingEnabled = true;
            this.cboORDER.Items.AddRange(new object[] {
            "Ascendente",
            "Descendente"});
            this.cboORDER.Location = new System.Drawing.Point(276, 68);
            this.cboORDER.Name = "cboORDER";
            this.cboORDER.Size = new System.Drawing.Size(123, 21);
            this.cboORDER.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(273, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Tipo de orden:";
            // 
            // cboCOLMUNAS
            // 
            this.cboCOLMUNAS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCOLMUNAS.FormattingEnabled = true;
            this.cboCOLMUNAS.Location = new System.Drawing.Point(12, 68);
            this.cboCOLMUNAS.Name = "cboCOLMUNAS";
            this.cboCOLMUNAS.Size = new System.Drawing.Size(258, 21);
            this.cboCOLMUNAS.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Ordenar por:";
            // 
            // c_mnuSalidas
            // 
            this.c_mnuSalidas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_mnuImprimirSeleccionado});
            this.c_mnuSalidas.Name = "c_mnuSalidas";
            this.c_mnuSalidas.Size = new System.Drawing.Size(121, 26);
            // 
            // c_mnuImprimirSeleccionado
            // 
            this.c_mnuImprimirSeleccionado.Image = global::POS.Properties.Resources.printer;
            this.c_mnuImprimirSeleccionado.Name = "c_mnuImprimirSeleccionado";
            this.c_mnuImprimirSeleccionado.Size = new System.Drawing.Size(152, 22);
            this.c_mnuImprimirSeleccionado.Text = "Imprimir";
            this.c_mnuImprimirSeleccionado.Click += new System.EventHandler(this.c_mnuImprimirSeleccionado_Click);
            // 
            // frmSalidaLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 456);
            this.Controls.Add(this.cboORDER);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboCOLMUNAS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvSalida);
            this.Controls.Add(this.barListaSalidas);
            this.Name = "frmSalidaLista";
            this.Text = "Salidas";
            this.Load += new System.EventHandler(this.frmSalidaLista_Load);
            this.barListaSalidas.ResumeLayout(false);
            this.barListaSalidas.PerformLayout();
            this.c_mnuSalidas.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip barListaSalidas;
        private System.Windows.Forms.ToolStripButton btnAddNew;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnExportar;
        private System.Windows.Forms.ToolStripButton btnFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSplitButton btnPrint;
        private System.Windows.Forms.ToolStripMenuItem btnPrintList;
        private System.Windows.Forms.ToolStripMenuItem btnPrintSelected;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnClose;
        private POSDLL.Windows.Forms.PrintableListView lvSalida;
        private System.Windows.Forms.ComboBox cboORDER;
        private Telerik.WinControls.UI.RadLabel label7;
        private System.Windows.Forms.ComboBox cboCOLMUNAS;
        private Telerik.WinControls.UI.RadLabel label1;
        private System.Windows.Forms.ContextMenuStrip c_mnuSalidas;
        private System.Windows.Forms.ToolStripMenuItem c_mnuImprimirSeleccionado;
    }
}