namespace POSApp.Forms
{
    partial class frmCatTipoAjuste
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
            this.barCatMarca = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.grdCatMarca = new System.Windows.Forms.DataGridView();
            this.colID_TIPO_AJUSTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDESC_TIPO_AJUSTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barCatMarca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCatMarca)).BeginInit();
            this.SuspendLayout();
            // 
            // barCatMarca
            // 
            this.barCatMarca.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnCancel,
            this.btnClose});
            this.barCatMarca.Location = new System.Drawing.Point(0, 0);
            this.barCatMarca.Name = "barCatMarca";
            this.barCatMarca.Size = new System.Drawing.Size(466, 38);
            this.barCatMarca.TabIndex = 2;
            this.barCatMarca.Text = "toolStrip1";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::POS.Properties.Resources.disk;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(53, 35);
            this.btnSave.Text = "Guardar";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::POS.Properties.Resources.cancel;
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(57, 35);
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancel.ToolTipText = "Cancelar última edición";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            // grdCatMarca
            // 
            this.grdCatMarca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCatMarca.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID_TIPO_AJUSTE,
            this.colDESC_TIPO_AJUSTE});
            this.grdCatMarca.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCatMarca.Location = new System.Drawing.Point(0, 38);
            this.grdCatMarca.Name = "grdCatMarca";
            this.grdCatMarca.Size = new System.Drawing.Size(466, 314);
            this.grdCatMarca.TabIndex = 3;
            // 
            // colID_TIPO_AJUSTE
            // 
            this.colID_TIPO_AJUSTE.DataPropertyName = "ID_TIPO_AJUSTE";
            this.colID_TIPO_AJUSTE.HeaderText = "Clave";
            this.colID_TIPO_AJUSTE.Name = "colID_TIPO_AJUSTE";
            // 
            // colDESC_TIPO_AJUSTE
            // 
            this.colDESC_TIPO_AJUSTE.DataPropertyName = "DESC_TIPO_AJUSTE";
            this.colDESC_TIPO_AJUSTE.HeaderText = "Tipo de ajuste";
            this.colDESC_TIPO_AJUSTE.Name = "colDESC_TIPO_AJUSTE";
            this.colDESC_TIPO_AJUSTE.Width = 300;
            // 
            // frmCatTipoAjuste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 352);
            this.Controls.Add(this.grdCatMarca);
            this.Controls.Add(this.barCatMarca);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmCatTipoAjuste";
            this.Text = "Tipos de ajuste";
            this.Load += new System.EventHandler(this.frmCatTipoAjuste_Load);
            this.barCatMarca.ResumeLayout(false);
            this.barCatMarca.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCatMarca)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip barCatMarca;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.DataGridView grdCatMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID_TIPO_AJUSTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDESC_TIPO_AJUSTE;
    }
}