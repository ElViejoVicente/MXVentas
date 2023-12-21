namespace POSApp.Forms
{
    partial class frmRptGastos
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
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.lblFINI = new Telerik.WinControls.UI.RadLabel();
            this.txtFECHA_INI = new System.Windows.Forms.DateTimePicker();
            this.txtFECHA_FIN = new System.Windows.Forms.DateTimePicker();
            this.lblFFIN = new Telerik.WinControls.UI.RadLabel();
            this.chkAgrupar = new System.Windows.Forms.CheckBox();
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
            this.lvRpt.Location = new System.Drawing.Point(12, 85);
            this.lvRpt.Name = "lvRpt";
            this.lvRpt.Size = new System.Drawing.Size(546, 243);
            this.lvRpt.TabIndex = 5;
            this.lvRpt.Title = "";
            this.lvRpt.UseCompatibleStateImageBehavior = false;
            // 
            // barListaVentas
            // 
            this.barListaVentas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnExportar,
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.btnClose});
            this.barListaVentas.Location = new System.Drawing.Point(0, 0);
            this.barListaVentas.Name = "barListaVentas";
            this.barListaVentas.Size = new System.Drawing.Size(570, 38);
            this.barListaVentas.TabIndex = 4;
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
            // lblFINI
            // 
            this.lblFINI.AutoSize = true;
            this.lblFINI.Location = new System.Drawing.Point(13, 42);
            this.lblFINI.Name = "lblFINI";
            this.lblFINI.Size = new System.Drawing.Size(54, 13);
            this.lblFINI.TabIndex = 6;
            this.lblFINI.Text = "Fecha Ini:";
            // 
            // txtFECHA_INI
            // 
            this.txtFECHA_INI.CustomFormat = "dd/MM/yyyy";
            this.txtFECHA_INI.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFECHA_INI.Location = new System.Drawing.Point(16, 59);
            this.txtFECHA_INI.Name = "txtFECHA_INI";
            this.txtFECHA_INI.Size = new System.Drawing.Size(106, 20);
            this.txtFECHA_INI.TabIndex = 7;
            // 
            // txtFECHA_FIN
            // 
            this.txtFECHA_FIN.CustomFormat = "dd/MM/yyyy";
            this.txtFECHA_FIN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFECHA_FIN.Location = new System.Drawing.Point(128, 59);
            this.txtFECHA_FIN.Name = "txtFECHA_FIN";
            this.txtFECHA_FIN.Size = new System.Drawing.Size(106, 20);
            this.txtFECHA_FIN.TabIndex = 9;
            // 
            // lblFFIN
            // 
            this.lblFFIN.AutoSize = true;
            this.lblFFIN.Location = new System.Drawing.Point(125, 42);
            this.lblFFIN.Name = "lblFFIN";
            this.lblFFIN.Size = new System.Drawing.Size(57, 13);
            this.lblFFIN.TabIndex = 8;
            this.lblFFIN.Text = "Fecha Fin:";
            // 
            // chkAgrupar
            // 
            this.chkAgrupar.AutoSize = true;
            this.chkAgrupar.Location = new System.Drawing.Point(255, 59);
            this.chkAgrupar.Name = "chkAgrupar";
            this.chkAgrupar.Size = new System.Drawing.Size(63, 17);
            this.chkAgrupar.TabIndex = 10;
            this.chkAgrupar.Text = "Agrupar";
            this.chkAgrupar.UseVisualStyleBackColor = true;
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(13, 331);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(51, 13);
            this.lblInfo.TabIndex = 11;
            this.lblInfo.Text = "Registros";
            // 
            // frmRptGastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 356);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.chkAgrupar);
            this.Controls.Add(this.txtFECHA_FIN);
            this.Controls.Add(this.lblFFIN);
            this.Controls.Add(this.txtFECHA_INI);
            this.Controls.Add(this.lblFINI);
            this.Controls.Add(this.lvRpt);
            this.Controls.Add(this.barListaVentas);
            this.Name = "frmRptGastos";
            this.Text = "Reporte de Gastos";
            this.Load += new System.EventHandler(this.frmRptGastos_Load);
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnClose;
        private Telerik.WinControls.UI.RadLabel lblFINI;
        private System.Windows.Forms.DateTimePicker txtFECHA_INI;
        private System.Windows.Forms.DateTimePicker txtFECHA_FIN;
        private Telerik.WinControls.UI.RadLabel lblFFIN;
        private System.Windows.Forms.CheckBox chkAgrupar;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private Telerik.WinControls.UI.RadLabel lblInfo;
    }
}