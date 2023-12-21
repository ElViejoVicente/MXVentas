namespace POSApp.Forms
{
    partial class frmRptSueldos
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
            this.lvRpt = new POSDLL.Windows.Forms.PrintableListView();
            this.barListaVentas = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportar = new System.Windows.Forms.ToolStripButton();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.txtFECHA_FIN = new System.Windows.Forms.DateTimePicker();
            this.lblFFIN = new Telerik.WinControls.UI.RadLabel();
            this.txtFECHA_INI = new System.Windows.Forms.DateTimePicker();
            this.lblFINI = new Telerik.WinControls.UI.RadLabel();
            this.lblInfo = new Telerik.WinControls.UI.RadLabel();
            this.barListaVentas.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvRpt
            // 
            this.lvRpt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvRpt.FitToPage = false;
            this.lvRpt.FullRowSelect = true;
            this.lvRpt.GridLines = true;
            this.lvRpt.HideSelection = false;
            this.lvRpt.Location = new System.Drawing.Point(12, 86);
            this.lvRpt.Name = "lvRpt";
            this.lvRpt.Size = new System.Drawing.Size(717, 183);
            this.lvRpt.TabIndex = 6;
            this.lvRpt.Title = "";
            this.lvRpt.UseCompatibleStateImageBehavior = false;
            // 
            // barListaVentas
            // 
            this.barListaVentas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnExportar,
            this.btnImprimir,
            this.toolStripSeparator2,
            this.btnClose});
            this.barListaVentas.Location = new System.Drawing.Point(0, 0);
            this.barListaVentas.Name = "barListaVentas";
            this.barListaVentas.Size = new System.Drawing.Size(741, 38);
            this.barListaVentas.TabIndex = 5;
            this.barListaVentas.Text = "toolStrip1";
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
            // btnImprimir
            // 
            this.btnImprimir.Image = global::POS.Properties.Resources.printer;
            this.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(57, 35);
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
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
            this.btnClose.Size = new System.Drawing.Size(43, 35);
            this.btnClose.Text = "Cerrar";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtFECHA_FIN
            // 
            this.txtFECHA_FIN.CustomFormat = "dd/MM/yyyy";
            this.txtFECHA_FIN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFECHA_FIN.Location = new System.Drawing.Point(124, 60);
            this.txtFECHA_FIN.Name = "txtFECHA_FIN";
            this.txtFECHA_FIN.Size = new System.Drawing.Size(106, 20);
            this.txtFECHA_FIN.TabIndex = 13;
            // 
            // lblFFIN
            // 
            this.lblFFIN.AutoSize = true;
            this.lblFFIN.Location = new System.Drawing.Point(121, 43);
            this.lblFFIN.Name = "lblFFIN";
            this.lblFFIN.Size = new System.Drawing.Size(57, 13);
            this.lblFFIN.TabIndex = 12;
            this.lblFFIN.Text = "Fecha Fin:";
            // 
            // txtFECHA_INI
            // 
            this.txtFECHA_INI.CustomFormat = "dd/MM/yyyy";
            this.txtFECHA_INI.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFECHA_INI.Location = new System.Drawing.Point(12, 60);
            this.txtFECHA_INI.Name = "txtFECHA_INI";
            this.txtFECHA_INI.Size = new System.Drawing.Size(106, 20);
            this.txtFECHA_INI.TabIndex = 11;
            // 
            // lblFINI
            // 
            this.lblFINI.AutoSize = true;
            this.lblFINI.Location = new System.Drawing.Point(9, 43);
            this.lblFINI.Name = "lblFINI";
            this.lblFINI.Size = new System.Drawing.Size(54, 13);
            this.lblFINI.TabIndex = 10;
            this.lblFINI.Text = "Fecha Ini:";
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(13, 272);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(51, 13);
            this.lblInfo.TabIndex = 14;
            this.lblInfo.Text = "Registros";
            // 
            // frmRptSueldos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 297);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.txtFECHA_FIN);
            this.Controls.Add(this.lblFFIN);
            this.Controls.Add(this.txtFECHA_INI);
            this.Controls.Add(this.lblFINI);
            this.Controls.Add(this.lvRpt);
            this.Controls.Add(this.barListaVentas);
            this.Name = "frmRptSueldos";
            this.Text = "Reporte de Sueldos";
            this.Load += new System.EventHandler(this.frmRptSueldos_Load);
            this.barListaVentas.ResumeLayout(false);
            this.barListaVentas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private POSDLL.Windows.Forms.PrintableListView lvRpt;
        private System.Windows.Forms.ToolStrip barListaVentas;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnExportar;
        private System.Windows.Forms.ToolStripButton btnImprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.DateTimePicker txtFECHA_FIN;
        private Telerik.WinControls.UI.RadLabel lblFFIN;
        private System.Windows.Forms.DateTimePicker txtFECHA_INI;
        private Telerik.WinControls.UI.RadLabel lblFINI;
        private Telerik.WinControls.UI.RadLabel lblInfo;
    }
}