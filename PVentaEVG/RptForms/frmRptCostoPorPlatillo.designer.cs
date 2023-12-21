namespace POSApp.Forms
{
    partial class frmRptCostoPorPlatillo
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
            this.cboORDER = new System.Windows.Forms.ComboBox();
            this.cboORDENAR = new System.Windows.Forms.ComboBox();
            this.txtDESC_PRODUCTO = new Telerik.WinControls.UI.RadTextBox();
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.lvRpt = new POSDLL.Windows.Forms.PrintableListView();
            this.barCatProducto = new System.Windows.Forms.ToolStrip();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.lblInfo = new Telerik.WinControls.UI.RadLabel();
            this.barCatProducto.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboORDER
            // 
            this.cboORDER.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboORDER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboORDER.FormattingEnabled = true;
            this.cboORDER.Items.AddRange(new object[] {
            "Ascendente",
            "Descendente"});
            this.cboORDER.Location = new System.Drawing.Point(616, 54);
            this.cboORDER.Name = "cboORDER";
            this.cboORDER.Size = new System.Drawing.Size(125, 21);
            this.cboORDER.TabIndex = 29;
            // 
            // cboORDENAR
            // 
            this.cboORDENAR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboORDENAR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboORDENAR.FormattingEnabled = true;
            this.cboORDENAR.Items.AddRange(new object[] {
            "Clave",
            "Nombre del Artículo",
            "Grupo"});
            this.cboORDENAR.Location = new System.Drawing.Point(486, 54);
            this.cboORDENAR.Name = "cboORDENAR";
            this.cboORDENAR.Size = new System.Drawing.Size(124, 21);
            this.cboORDENAR.TabIndex = 28;
            // 
            // txtDESC_PRODUCTO
            // 
            this.txtDESC_PRODUCTO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDESC_PRODUCTO.Location = new System.Drawing.Point(12, 55);
            this.txtDESC_PRODUCTO.Name = "txtDESC_PRODUCTO";
            this.txtDESC_PRODUCTO.Size = new System.Drawing.Size(468, 20);
            this.txtDESC_PRODUCTO.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Nombre:";
            // 
            // lvRpt
            // 
            this.lvRpt.AllowColumnReorder = true;
            this.lvRpt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvRpt.FitToPage = false;
            this.lvRpt.FullRowSelect = true;
            this.lvRpt.GridLines = true;
            this.lvRpt.HideSelection = false;
            this.lvRpt.Location = new System.Drawing.Point(12, 81);
            this.lvRpt.Name = "lvRpt";
            this.lvRpt.Size = new System.Drawing.Size(729, 223);
            this.lvRpt.TabIndex = 25;
            this.lvRpt.Title = "";
            this.lvRpt.UseCompatibleStateImageBehavior = false;
            // 
            // barCatProducto
            // 
            this.barCatProducto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnActualizar,
            this.toolStripSeparator1,
            this.btnExport,
            this.btnImprimir,
            this.toolStripSeparator3,
            this.btnClose});
            this.barCatProducto.Location = new System.Drawing.Point(0, 0);
            this.barCatProducto.Name = "barCatProducto";
            this.barCatProducto.Size = new System.Drawing.Size(753, 38);
            this.barCatProducto.TabIndex = 24;
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
            // btnImprimir
            // 
            this.btnImprimir.Image = global::POS.Properties.Resources.printer;
            this.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(57, 35);
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnImprimir.ToolTipText = "Clic aquí para imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
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
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(505, 310);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(236, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "De doble clic sobre el  elemento para consultarlo";
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(13, 310);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(51, 13);
            this.lblInfo.TabIndex = 31;
            this.lblInfo.Text = "Registros";
            // 
            // frmRptCostoPorPlatillo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 332);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboORDER);
            this.Controls.Add(this.cboORDENAR);
            this.Controls.Add(this.txtDESC_PRODUCTO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvRpt);
            this.Controls.Add(this.barCatProducto);
            this.Name = "frmRptCostoPorPlatillo";
            this.Text = "Costo por platillo";
            this.Load += new System.EventHandler(this.frmRptCostoPorPlatillo_Load);
            this.barCatProducto.ResumeLayout(false);
            this.barCatProducto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboORDER;
        private System.Windows.Forms.ComboBox cboORDENAR;
        private Telerik.WinControls.UI.RadTextBox txtDESC_PRODUCTO;
        private Telerik.WinControls.UI.RadLabel label1;
        private POSDLL.Windows.Forms.PrintableListView lvRpt;
        private System.Windows.Forms.ToolStrip barCatProducto;
        private System.Windows.Forms.ToolStripButton btnActualizar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.ToolStripButton btnImprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnClose;
        private Telerik.WinControls.UI.RadLabel label2;
        private Telerik.WinControls.UI.RadLabel lblInfo;
    }
}