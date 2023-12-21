namespace POSApp.Forms
{
    partial class frmPrestamoLista
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
            this.toolPrestamos = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.txtFechaIni = new System.Windows.Forms.DateTimePicker();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.txtFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label3 = new Telerik.WinControls.UI.RadLabel();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.lvPrestamos = new POSDLL.Windows.Forms.PrintableListView();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.toolPrestamos.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolPrestamos
            // 
            this.toolPrestamos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnClose});
            this.toolPrestamos.Location = new System.Drawing.Point(0, 0);
            this.toolPrestamos.Name = "toolPrestamos";
            this.toolPrestamos.Size = new System.Drawing.Size(691, 38);
            this.toolPrestamos.TabIndex = 0;
            this.toolPrestamos.Text = "toolStrip1";
            // 
            // btnNew
            // 
            this.btnNew.Image = global::POS.Properties.Resources.DocumentHS;
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(46, 35);
            this.btnNew.Text = "Nuevo";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtFechaIni
            // 
            this.txtFechaIni.CustomFormat = "dd/MM/yyyy";
            this.txtFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFechaIni.Location = new System.Drawing.Point(15, 65);
            this.txtFechaIni.Name = "txtFechaIni";
            this.txtFechaIni.Size = new System.Drawing.Size(111, 20);
            this.txtFechaIni.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Inicio:";
            // 
            // txtFechaFin
            // 
            this.txtFechaFin.CustomFormat = "dd/MM/yyyy";
            this.txtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFechaFin.Location = new System.Drawing.Point(136, 64);
            this.txtFechaFin.Name = "txtFechaFin";
            this.txtFechaFin.Size = new System.Drawing.Size(111, 20);
            this.txtFechaFin.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(133, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Fin:";
            // 
            // btnAplicar
            // 
            this.btnAplicar.Image = global::POS.Properties.Resources.FormRunHS;
            this.btnAplicar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAplicar.Location = new System.Drawing.Point(253, 51);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(100, 33);
            this.btnAplicar.TabIndex = 20;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // lvPrestamos
            // 
            this.lvPrestamos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvPrestamos.FitToPage = false;
            this.lvPrestamos.FullRowSelect = true;
            this.lvPrestamos.GridLines = true;
            this.lvPrestamos.HideSelection = false;
            this.lvPrestamos.Location = new System.Drawing.Point(15, 91);
            this.lvPrestamos.Name = "lvPrestamos";
            this.lvPrestamos.Size = new System.Drawing.Size(664, 159);
            this.lvPrestamos.TabIndex = 21;
            this.lvPrestamos.Title = "";
            this.lvPrestamos.UseCompatibleStateImageBehavior = false;
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
            // frmPrestamoLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 262);
            this.Controls.Add(this.lvPrestamos);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.txtFechaIni);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFechaFin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.toolPrestamos);
            this.Name = "frmPrestamoLista";
            this.Text = "Préstamos";
            this.Load += new System.EventHandler(this.frmPrestamoLista_Load);
            this.toolPrestamos.ResumeLayout(false);
            this.toolPrestamos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolPrestamos;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.DateTimePicker txtFechaIni;
        private Telerik.WinControls.UI.RadLabel label2;
        private System.Windows.Forms.DateTimePicker txtFechaFin;
        private Telerik.WinControls.UI.RadLabel label3;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.ToolStripButton btnClose;
        private POSDLL.Windows.Forms.PrintableListView lvPrestamos;
    }
}