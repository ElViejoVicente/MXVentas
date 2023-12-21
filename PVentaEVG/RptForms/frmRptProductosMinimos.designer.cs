namespace POSApp.Forms
{
    partial class frmRptProductosMinimos
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
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.cboCOLMUNAS = new System.Windows.Forms.ComboBox();
            this.label3 = new Telerik.WinControls.UI.RadLabel();
            this.cboORDER = new System.Windows.Forms.ComboBox();
            this.cboORDENAR = new System.Windows.Forms.ComboBox();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.txtDESC_PRODUCTO = new Telerik.WinControls.UI.RadTextBox();
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.cboORDENAR2 = new System.Windows.Forms.ComboBox();
            this.label4 = new Telerik.WinControls.UI.RadLabel();
            this.label5 = new Telerik.WinControls.UI.RadLabel();
            this.lvCatProducto = new POSDLL.Windows.Forms.PrintableListView();
            this.lblInfo = new Telerik.WinControls.UI.RadLabel();
            this.barCatProducto.SuspendLayout();
            this.SuspendLayout();
            // 
            // barCatProducto
            // 
            this.barCatProducto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnActualizar,
            this.btnExport,
            this.toolStripButton1,
            this.toolStripSeparator3,
            this.btnClose});
            this.barCatProducto.Location = new System.Drawing.Point(0, 0);
            this.barCatProducto.Name = "barCatProducto";
            this.barCatProducto.Size = new System.Drawing.Size(764, 38);
            this.barCatProducto.TabIndex = 7;
            this.barCatProducto.Text = "toolStrip1";
            this.barCatProducto.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.barCatProducto_ItemClicked);
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
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::POS.Properties.Resources.printer;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(57, 35);
            this.toolStripButton1.Text = "Imprimir";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
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
            // cboCOLMUNAS
            // 
            this.cboCOLMUNAS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCOLMUNAS.FormattingEnabled = true;
            this.cboCOLMUNAS.Location = new System.Drawing.Point(12, 66);
            this.cboCOLMUNAS.Name = "cboCOLMUNAS";
            this.cboCOLMUNAS.Size = new System.Drawing.Size(254, 21);
            this.cboCOLMUNAS.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Buscar por:";
            // 
            // cboORDER
            // 
            this.cboORDER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboORDER.FormattingEnabled = true;
            this.cboORDER.Items.AddRange(new object[] {
            "Ascendente",
            "Descendente"});
            this.cboORDER.Location = new System.Drawing.Point(567, 107);
            this.cboORDER.Name = "cboORDER";
            this.cboORDER.Size = new System.Drawing.Size(125, 21);
            this.cboORDER.TabIndex = 5;
            this.cboORDER.SelectedIndexChanged += new System.EventHandler(this.cboORDER_SelectedIndexChanged);
            // 
            // cboORDENAR
            // 
            this.cboORDENAR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboORDENAR.FormattingEnabled = true;
            this.cboORDENAR.Items.AddRange(new object[] {
            "Clave",
            "Nombre del Artículo",
            "Marca",
            "Grupo",
            "PRESENTACION",
            "SUSTANCIA ACTIVA",
            "Indicación"});
            this.cboORDENAR.Location = new System.Drawing.Point(307, 107);
            this.cboORDENAR.Name = "cboORDENAR";
            this.cboORDENAR.Size = new System.Drawing.Size(124, 21);
            this.cboORDENAR.TabIndex = 3;
            this.cboORDENAR.SelectedIndexChanged += new System.EventHandler(this.cboORDENAR_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(304, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Ordenar por:";
            // 
            // txtDESC_PRODUCTO
            // 
            this.txtDESC_PRODUCTO.Location = new System.Drawing.Point(12, 107);
            this.txtDESC_PRODUCTO.Name = "txtDESC_PRODUCTO";
            this.txtDESC_PRODUCTO.Size = new System.Drawing.Size(288, 20);
            this.txtDESC_PRODUCTO.TabIndex = 2;
            this.txtDESC_PRODUCTO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDESC_PRODUCTO_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Palabra a buscar:";
            // 
            // cboORDENAR2
            // 
            this.cboORDENAR2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboORDENAR2.FormattingEnabled = true;
            this.cboORDENAR2.Items.AddRange(new object[] {
            "Clave",
            "Nombre del Artículo",
            "Marca",
            "Grupo",
            "PRESENTACION",
            "SUSTANCIA ACTIVA",
            "Indicación"});
            this.cboORDENAR2.Location = new System.Drawing.Point(437, 107);
            this.cboORDENAR2.Name = "cboORDENAR2";
            this.cboORDENAR2.Size = new System.Drawing.Size(124, 21);
            this.cboORDENAR2.TabIndex = 4;
            this.cboORDENAR2.SelectedIndexChanged += new System.EventHandler(this.cboORDENAR2_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(434, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Luego por:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(567, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Tipo de orden:";
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
            this.lvCatProducto.Location = new System.Drawing.Point(12, 134);
            this.lvCatProducto.Name = "lvCatProducto";
            this.lvCatProducto.Size = new System.Drawing.Size(738, 243);
            this.lvCatProducto.TabIndex = 6;
            this.lvCatProducto.Title = "";
            this.lvCatProducto.UseCompatibleStateImageBehavior = false;
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(12, 380);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(51, 13);
            this.lblInfo.TabIndex = 31;
            this.lblInfo.Text = "Registros";
            // 
            // frmRptProductosMinimos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 405);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboORDENAR2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboCOLMUNAS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboORDER);
            this.Controls.Add(this.cboORDENAR);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDESC_PRODUCTO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvCatProducto);
            this.Controls.Add(this.barCatProducto);
            this.MinimumSize = new System.Drawing.Size(770, 433);
            this.Name = "frmRptProductosMinimos";
            this.Text = "Lista de artículos con existencia crítica";
            this.Load += new System.EventHandler(this.frmListaProductosMinimos_Load);
            this.barCatProducto.ResumeLayout(false);
            this.barCatProducto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void txtDESC_PRODUCTO_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {
                ORDENAR();
            }
        }

        #endregion

        private System.Windows.Forms.ToolStrip barCatProducto;
        private System.Windows.Forms.ToolStripButton btnActualizar;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnClose;
        private POSDLL.Windows.Forms.PrintableListView lvCatProducto;
        private System.Windows.Forms.ComboBox cboCOLMUNAS;
        private Telerik.WinControls.UI.RadLabel label3;
        private System.Windows.Forms.ComboBox cboORDER;
        private System.Windows.Forms.ComboBox cboORDENAR;
        private Telerik.WinControls.UI.RadLabel label2;
        private Telerik.WinControls.UI.RadTextBox txtDESC_PRODUCTO;
        private Telerik.WinControls.UI.RadLabel label1;
        private System.Windows.Forms.ComboBox cboORDENAR2;
        private Telerik.WinControls.UI.RadLabel label4;
        private Telerik.WinControls.UI.RadLabel label5;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private Telerik.WinControls.UI.RadLabel lblInfo;
    }
}