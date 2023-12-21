namespace POSApp.Forms
{
    partial class frmProductoComprasPrevias
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
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.lvCatProducto = new POSDLL.Windows.Forms.PrintableListView();
            this.barCatProducto.SuspendLayout();
            this.SuspendLayout();
            // 
            // barCatProducto
            // 
            this.barCatProducto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnActualizar,
            this.btnPrint,
            this.toolStripSeparator3,
            this.btnClose});
            this.barCatProducto.Location = new System.Drawing.Point(0, 0);
            this.barCatProducto.Name = "barCatProducto";
            this.barCatProducto.Size = new System.Drawing.Size(637, 38);
            this.barCatProducto.TabIndex = 2;
            this.barCatProducto.Text = "toolStrip1";
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
            this.lvCatProducto.CheckBoxes = true;
            this.lvCatProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCatProducto.FitToPage = false;
            this.lvCatProducto.FullRowSelect = true;
            this.lvCatProducto.GridLines = true;
            this.lvCatProducto.HideSelection = false;
            this.lvCatProducto.Location = new System.Drawing.Point(0, 38);
            this.lvCatProducto.Name = "lvCatProducto";
            this.lvCatProducto.Size = new System.Drawing.Size(637, 235);
            this.lvCatProducto.TabIndex = 3;
            this.lvCatProducto.Title = "";
            this.lvCatProducto.UseCompatibleStateImageBehavior = false;
            this.lvCatProducto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvCatProducto_KeyUp);
            // 
            // frmListaComprasPrevias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 273);
            this.Controls.Add(this.lvCatProducto);
            this.Controls.Add(this.barCatProducto);
            this.Name = "frmListaComprasPrevias";
            this.Text = "Compras previas";
            this.Load += new System.EventHandler(this.frmListaComprasPrevias_Load);
            this.barCatProducto.ResumeLayout(false);
            this.barCatProducto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip barCatProducto;
        private System.Windows.Forms.ToolStripButton btnActualizar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnClose;
        private POSDLL.Windows.Forms.PrintableListView lvCatProducto;
        private System.Windows.Forms.ToolStripButton btnPrint;
    }
}