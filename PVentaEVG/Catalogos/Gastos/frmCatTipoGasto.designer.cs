namespace POSApp.Forms
{
    partial class frmCatTipoGasto
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
            this.grdCatMarca = new System.Windows.Forms.DataGridView();
            this.barCatMarca = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.colID_TIPO_GASTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDESC_TIPO_GASTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtID_EMPLEADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdCatMarca)).BeginInit();
            this.barCatMarca.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdCatMarca
            // 
            this.grdCatMarca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCatMarca.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID_TIPO_GASTO,
            this.colDESC_TIPO_GASTO,
            this.txtID_EMPLEADO});
            this.grdCatMarca.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCatMarca.Location = new System.Drawing.Point(0, 38);
            this.grdCatMarca.Name = "grdCatMarca";
            this.grdCatMarca.Size = new System.Drawing.Size(656, 224);
            this.grdCatMarca.TabIndex = 5;
            // 
            // barCatMarca
            // 
            this.barCatMarca.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnCancel,
            this.btnClose});
            this.barCatMarca.Location = new System.Drawing.Point(0, 0);
            this.barCatMarca.Name = "barCatMarca";
            this.barCatMarca.Size = new System.Drawing.Size(656, 38);
            this.barCatMarca.TabIndex = 4;
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
            // colID_TIPO_GASTO
            // 
            this.colID_TIPO_GASTO.DataPropertyName = "ID_TIPO_GASTO";
            this.colID_TIPO_GASTO.HeaderText = "Clave";
            this.colID_TIPO_GASTO.Name = "colID_TIPO_GASTO";
            this.colID_TIPO_GASTO.ReadOnly = true;
            // 
            // colDESC_TIPO_GASTO
            // 
            this.colDESC_TIPO_GASTO.DataPropertyName = "DESC_TIPO_GASTO";
            this.colDESC_TIPO_GASTO.HeaderText = "Tipo de Gasto";
            this.colDESC_TIPO_GASTO.Name = "colDESC_TIPO_GASTO";
            this.colDESC_TIPO_GASTO.Width = 300;
            // 
            // txtID_EMPLEADO
            // 
            this.txtID_EMPLEADO.DataPropertyName = "ID_EMPLEADO";
            this.txtID_EMPLEADO.HeaderText = "Empleado";
            this.txtID_EMPLEADO.Name = "txtID_EMPLEADO";
            // 
            // frmCatTipoGasto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 262);
            this.Controls.Add(this.grdCatMarca);
            this.Controls.Add(this.barCatMarca);
            this.Name = "frmCatTipoGasto";
            this.Text = "Tipos de Gasto";
            this.Load += new System.EventHandler(this.frmCatTipoGasto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdCatMarca)).EndInit();
            this.barCatMarca.ResumeLayout(false);
            this.barCatMarca.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdCatMarca;
        private System.Windows.Forms.ToolStrip barCatMarca;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID_TIPO_GASTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDESC_TIPO_GASTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtID_EMPLEADO;
    }
}