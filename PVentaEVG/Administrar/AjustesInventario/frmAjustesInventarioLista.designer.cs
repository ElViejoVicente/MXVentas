namespace POSApp.Forms
{
    partial class frmAjustesInventarioLista
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.barCatProducto = new System.Windows.Forms.ToolStrip();
            this.btnAddNew = new System.Windows.Forms.ToolStripButton();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.btnFiltro = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.lvCatProducto = new POSDLL.Windows.Forms.PrintableListView();
            this.lblInfo = new Telerik.WinControls.UI.RadLabel();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.barCatProducto.SuspendLayout();
            this.SuspendLayout();
            // 
            // barCatProducto
            // 
            this.barCatProducto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddNew,
            this.btnActualizar,
            this.btnFiltro,
            this.toolStripSeparator1,
            this.btnExport,
            this.btnPrint,
            this.toolStripSeparator3,
            this.btnClose});
            this.barCatProducto.Location = new System.Drawing.Point(0, 0);
            this.barCatProducto.Name = "barCatProducto";
            this.barCatProducto.Size = new System.Drawing.Size(758, 38);
            this.barCatProducto.TabIndex = 1;
            this.barCatProducto.Text = "toolStrip1";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Image = global::POS.Properties.Resources.DocumentHS;
            this.btnAddNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(46, 35);
            this.btnAddNew.Text = "Nuevo";
            this.btnAddNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddNew.ToolTipText = "Clic aquí para agregar un nuevo registro";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Image = global::POS.Properties.Resources.RefreshDocViewHS;
            this.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(63, 35);
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnActualizar.ToolTipText = "Clic aquí para actualizar la lista";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnFiltro
            // 
            this.btnFiltro.Image = global::POS.Properties.Resources.Filter2HS;
            this.btnFiltro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFiltro.Name = "btnFiltro";
            this.btnFiltro.Size = new System.Drawing.Size(38, 35);
            this.btnFiltro.Text = "Filtro";
            this.btnFiltro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFiltro.Click += new System.EventHandler(this.btnFiltro_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // btnExport
            // 
            this.btnExport.Image = global::POS.Properties.Resources.excel;
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(44, 35);
            this.btnExport.Text = "Export";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExport.ToolTipText = "Exportar a Microsoft Excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
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
            // lvCatProducto
            // 
            this.lvCatProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvCatProducto.FitToPage = false;
            this.lvCatProducto.FullRowSelect = true;
            this.lvCatProducto.GridLines = true;
            this.lvCatProducto.HideSelection = false;
            this.lvCatProducto.Location = new System.Drawing.Point(12, 41);
            this.lvCatProducto.Name = "lvCatProducto";
            this.lvCatProducto.Size = new System.Drawing.Size(734, 204);
            this.lvCatProducto.TabIndex = 2;
            this.lvCatProducto.Title = "";
            this.lvCatProducto.UseCompatibleStateImageBehavior = false;
            this.lvCatProducto.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvCatProducto_ColumnClick);
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(13, 248);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(51, 13);
            this.lblInfo.TabIndex = 3;
            this.lblInfo.Text = "Registros";
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::POS.Properties.Resources.printer;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(57, 35);
            this.btnPrint.Text = "Imprimir";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmAjustesInventarioLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 273);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lvCatProducto);
            this.Controls.Add(this.barCatProducto);
            this.Name = "frmAjustesInventarioLista";
            this.Text = "Ajustes al Inventario";
            this.Load += new System.EventHandler(this.frmListaAjustesInventario_Load);
            this.barCatProducto.ResumeLayout(false);
            this.barCatProducto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.ToolStrip barCatProducto;
        private System.Windows.Forms.ToolStripButton btnAddNew;
        private System.Windows.Forms.ToolStripButton btnActualizar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnClose;
        private POSDLL.Windows.Forms.PrintableListView lvCatProducto;
        private System.Windows.Forms.ToolStripButton btnFiltro;
        private Telerik.WinControls.UI.RadLabel lblInfo;
        private System.Windows.Forms.ToolStripButton btnPrint;
    }
}