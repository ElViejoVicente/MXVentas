namespace POSApp.Forms
{
    partial class frmInventarioFisico
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.mnuImprimir = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuImprimirLista = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImprimirListaConteo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImprimirListaNoContados = new System.Windows.Forms.ToolStripMenuItem();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.btnEjecutar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.lvItems = new POSDLL.Windows.Forms.PrintableListView();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.mnuImprimir,
            this.btnActualizar,
            this.btnEjecutar,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(711, 38);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::POS.Properties.Resources.add;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(53, 35);
            this.btnAdd.Text = "Agregar";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // mnuImprimir
            // 
            this.mnuImprimir.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuImprimirLista,
            this.mnuImprimirListaConteo,
            this.mnuImprimirListaNoContados});
            this.mnuImprimir.Image = global::POS.Properties.Resources.printer;
            this.mnuImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuImprimir.Name = "mnuImprimir";
            this.mnuImprimir.Size = new System.Drawing.Size(66, 35);
            this.mnuImprimir.Text = "Imprimir";
            this.mnuImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // mnuImprimirLista
            // 
            this.mnuImprimirLista.Name = "mnuImprimirLista";
            this.mnuImprimirLista.Size = new System.Drawing.Size(287, 22);
            this.mnuImprimirLista.Text = "Imprimir lista";
            this.mnuImprimirLista.Click += new System.EventHandler(this.mnuImprimirLista_Click);
            // 
            // mnuImprimirListaConteo
            // 
            this.mnuImprimirListaConteo.Name = "mnuImprimirListaConteo";
            this.mnuImprimirListaConteo.Size = new System.Drawing.Size(287, 22);
            this.mnuImprimirListaConteo.Text = "Imprimir lista para conteo";
            this.mnuImprimirListaConteo.Click += new System.EventHandler(this.mnuImprimirListaConteo_Click);
            // 
            // mnuImprimirListaNoContados
            // 
            this.mnuImprimirListaNoContados.Name = "mnuImprimirListaNoContados";
            this.mnuImprimirListaNoContados.Size = new System.Drawing.Size(287, 22);
            this.mnuImprimirListaNoContados.Text = "Imprimir lista de elementos no contados";
            this.mnuImprimirListaNoContados.Click += new System.EventHandler(this.mnuImprimirListaNoContados_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Image = global::POS.Properties.Resources.RefreshDocViewHS;
            this.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(63, 35);
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Image = global::POS.Properties.Resources.FormRunHS;
            this.btnEjecutar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(53, 35);
            this.btnEjecutar.Text = "Ejecutar";
            this.btnEjecutar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::POS.Properties.Resources.close;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(43, 35);
            this.toolStripButton1.Text = "Cerrar";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // lvItems
            // 
            this.lvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvItems.FitToPage = false;
            this.lvItems.Location = new System.Drawing.Point(0, 38);
            this.lvItems.Name = "lvItems";
            this.lvItems.Size = new System.Drawing.Size(711, 240);
            this.lvItems.TabIndex = 1;
            this.lvItems.Title = "";
            this.lvItems.UseCompatibleStateImageBehavior = false;
            // 
            // frmInventarioFisico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 278);
            this.Controls.Add(this.lvItems);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmInventarioFisico";
            this.Text = "Inventario físico";
            this.Load += new System.EventHandler(this.frmInventarioFisico_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private POSDLL.Windows.Forms.PrintableListView lvItems;
        private System.Windows.Forms.ToolStripButton btnEjecutar;
        private System.Windows.Forms.ToolStripButton btnActualizar;
        private System.Windows.Forms.ToolStripDropDownButton mnuImprimir;
        private System.Windows.Forms.ToolStripMenuItem mnuImprimirLista;
        private System.Windows.Forms.ToolStripMenuItem mnuImprimirListaConteo;
        private System.Windows.Forms.ToolStripMenuItem mnuImprimirListaNoContados;
        private System.Windows.Forms.ToolStripButton toolStripButton1;

    }
}