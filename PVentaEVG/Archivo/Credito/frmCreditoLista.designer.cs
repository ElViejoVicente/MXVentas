namespace POSApp.Forms
{
    partial class frmCreditoLista
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreditoLista));
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.txtFOLIO_VENTA = new Telerik.WinControls.UI.RadTextBox();
            this.lvVentasCredito = new POSDLL.Windows.Forms.PrintableListView();
            this.c_mnuVentasCredito = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAbonar = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHistorialPagos = new System.Windows.Forms.ToolStripMenuItem();
            this.c_mnuHistorialCrediticio = new System.Windows.Forms.ToolStripMenuItem();
            this.c_mnuEliminaCuenta = new System.Windows.Forms.ToolStripMenuItem();
            this.c_mnuCambiarCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnBuscaTicket = new System.Windows.Forms.Button();
            this.cboFiltro = new System.Windows.Forms.ComboBox();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.txtFechaIni = new System.Windows.Forms.DateTimePicker();
            this.txtFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label3 = new Telerik.WinControls.UI.RadLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.mnuAbonoMultiple = new System.Windows.Forms.ToolStripMenuItem();
            this.c_mnuVentasCredito.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ticket de venta:";
            // 
            // txtFOLIO_VENTA
            // 
            this.txtFOLIO_VENTA.Location = new System.Drawing.Point(9, 32);
            this.txtFOLIO_VENTA.Name = "txtFOLIO_VENTA";
            this.txtFOLIO_VENTA.Size = new System.Drawing.Size(100, 20);
            this.txtFOLIO_VENTA.TabIndex = 1;
            this.txtFOLIO_VENTA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFOLIO_VENTA_KeyPress);
            // 
            // lvVentasCredito
            // 
            this.lvVentasCredito.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvVentasCredito.ContextMenuStrip = this.c_mnuVentasCredito;
            this.lvVentasCredito.FitToPage = false;
            this.lvVentasCredito.FullRowSelect = true;
            this.lvVentasCredito.GridLines = true;
            this.lvVentasCredito.HideSelection = false;
            this.lvVentasCredito.Location = new System.Drawing.Point(15, 118);
            this.lvVentasCredito.Name = "lvVentasCredito";
            this.lvVentasCredito.Size = new System.Drawing.Size(584, 144);
            this.lvVentasCredito.TabIndex = 5;
            this.lvVentasCredito.Title = "";
            this.lvVentasCredito.UseCompatibleStateImageBehavior = false;
            this.lvVentasCredito.DoubleClick += new System.EventHandler(this.lvVentasCredito_DoubleClick);
            // 
            // c_mnuVentasCredito
            // 
            this.c_mnuVentasCredito.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbonar,
            this.btnHistorialPagos,
            this.c_mnuHistorialCrediticio,
            this.c_mnuEliminaCuenta,
            this.c_mnuCambiarCliente,
            this.mnuAbonoMultiple});
            this.c_mnuVentasCredito.Name = "c_mnuVentasCredito";
            this.c_mnuVentasCredito.Size = new System.Drawing.Size(188, 158);
            // 
            // mnuAbonar
            // 
            this.mnuAbonar.Image = ((System.Drawing.Image)(resources.GetObject("mnuAbonar.Image")));
            this.mnuAbonar.Name = "mnuAbonar";
            this.mnuAbonar.Size = new System.Drawing.Size(187, 22);
            this.mnuAbonar.Text = "Abonar";
            this.mnuAbonar.Click += new System.EventHandler(this.mnuAbonar_Click);
            // 
            // btnHistorialPagos
            // 
            this.btnHistorialPagos.Image = ((System.Drawing.Image)(resources.GetObject("btnHistorialPagos.Image")));
            this.btnHistorialPagos.Name = "btnHistorialPagos";
            this.btnHistorialPagos.Size = new System.Drawing.Size(187, 22);
            this.btnHistorialPagos.Text = "Ver historial de pagos";
            this.btnHistorialPagos.Click += new System.EventHandler(this.btnHistorialPagos_Click);
            // 
            // c_mnuHistorialCrediticio
            // 
            this.c_mnuHistorialCrediticio.Image = ((System.Drawing.Image)(resources.GetObject("c_mnuHistorialCrediticio.Image")));
            this.c_mnuHistorialCrediticio.Name = "c_mnuHistorialCrediticio";
            this.c_mnuHistorialCrediticio.Size = new System.Drawing.Size(187, 22);
            this.c_mnuHistorialCrediticio.Text = "Historial crediticio";
            this.c_mnuHistorialCrediticio.Click += new System.EventHandler(this.c_mnuHistorialCrediticio_Click);
            // 
            // c_mnuEliminaCuenta
            // 
            this.c_mnuEliminaCuenta.Image = ((System.Drawing.Image)(resources.GetObject("c_mnuEliminaCuenta.Image")));
            this.c_mnuEliminaCuenta.Name = "c_mnuEliminaCuenta";
            this.c_mnuEliminaCuenta.Size = new System.Drawing.Size(187, 22);
            this.c_mnuEliminaCuenta.Text = "Eliminar cuenta";
            this.c_mnuEliminaCuenta.Click += new System.EventHandler(this.c_mnuEliminaCuenta_Click);
            // 
            // c_mnuCambiarCliente
            // 
            this.c_mnuCambiarCliente.Image = ((System.Drawing.Image)(resources.GetObject("c_mnuCambiarCliente.Image")));
            this.c_mnuCambiarCliente.Name = "c_mnuCambiarCliente";
            this.c_mnuCambiarCliente.Size = new System.Drawing.Size(187, 22);
            this.c_mnuCambiarCliente.Text = "Cambiar de cliente";
            this.c_mnuCambiarCliente.Click += new System.EventHandler(this.c_mnuCambiarCliente_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = global::POS.Properties.Resources.printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.Location = new System.Drawing.Point(439, 270);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 30);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "Imprimir";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::POS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(520, 270);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(79, 30);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Cerrar";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::POS.Properties.Resources.add;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.Location = new System.Drawing.Point(6, 58);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 33);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnBuscaTicket
            // 
            this.btnBuscaTicket.Image = global::POS.Properties.Resources.zoom;
            this.btnBuscaTicket.Location = new System.Drawing.Point(115, 30);
            this.btnBuscaTicket.Name = "btnBuscaTicket";
            this.btnBuscaTicket.Size = new System.Drawing.Size(38, 23);
            this.btnBuscaTicket.TabIndex = 9;
            this.btnBuscaTicket.UseVisualStyleBackColor = true;
            this.btnBuscaTicket.Click += new System.EventHandler(this.btnBuscaTicket_Click);
            // 
            // cboFiltro
            // 
            this.cboFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltro.FormattingEnabled = true;
            this.cboFiltro.Items.AddRange(new object[] {
            "MOSTRAR TODO",
            "MOSTRAR PAGADOS",
            "MOSTRAR PENDIENTES DE PAGO"});
            this.cboFiltro.Location = new System.Drawing.Point(6, 65);
            this.cboFiltro.Name = "cboFiltro";
            this.cboFiltro.Size = new System.Drawing.Size(235, 21);
            this.cboFiltro.TabIndex = 11;
            this.cboFiltro.SelectedIndexChanged += new System.EventHandler(this.cboFiltro_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Inicio:";
            // 
            // txtFechaIni
            // 
            this.txtFechaIni.CustomFormat = "dd/MM/yyyy";
            this.txtFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFechaIni.Location = new System.Drawing.Point(6, 29);
            this.txtFechaIni.Name = "txtFechaIni";
            this.txtFechaIni.Size = new System.Drawing.Size(111, 20);
            this.txtFechaIni.TabIndex = 13;
            // 
            // txtFechaFin
            // 
            this.txtFechaFin.CustomFormat = "dd/MM/yyyy";
            this.txtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFechaFin.Location = new System.Drawing.Point(127, 28);
            this.txtFechaFin.Name = "txtFechaFin";
            this.txtFechaFin.Size = new System.Drawing.Size(111, 20);
            this.txtFechaFin.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(124, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Fin:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFOLIO_VENTA);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnBuscaTicket);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agregar nuevo Crédito";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAplicar);
            this.groupBox2.Controls.Add(this.txtFechaIni);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtFechaFin);
            this.groupBox2.Controls.Add(this.cboFiltro);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(221, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(378, 100);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtro";
            // 
            // btnAplicar
            // 
            this.btnAplicar.Image = global::POS.Properties.Resources.FormRunHS;
            this.btnAplicar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAplicar.Location = new System.Drawing.Point(272, 53);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(100, 33);
            this.btnAplicar.TabIndex = 16;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // mnuAbonoMultiple
            // 
            this.mnuAbonoMultiple.Name = "mnuAbonoMultiple";
            this.mnuAbonoMultiple.Size = new System.Drawing.Size(187, 22);
            this.mnuAbonoMultiple.Text = "Abono multiple";
            this.mnuAbonoMultiple.Click += new System.EventHandler(this.mnuAbonoMultiple_Click);
            // 
            // frmCreditoLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(611, 305);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvVentasCredito);
            this.Controls.Add(this.btnPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimumSize = new System.Drawing.Size(592, 309);
            this.Name = "frmCreditoLista";
            this.ShowInTaskbar = false;
            this.Text = "Credito";
            this.Load += new System.EventHandler(this.frmVentasCredito_Load);
            this.c_mnuVentasCredito.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

       


        #endregion

        private Telerik.WinControls.UI.RadLabel label1;
        private Telerik.WinControls.UI.RadTextBox txtFOLIO_VENTA;
        private POSDLL.Windows.Forms.PrintableListView lvVentasCredito;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ContextMenuStrip c_mnuVentasCredito;
        private System.Windows.Forms.ToolStripMenuItem mnuAbonar;
        private System.Windows.Forms.ToolStripMenuItem btnHistorialPagos;
        private System.Windows.Forms.Button btnBuscaTicket;
        private System.Windows.Forms.ComboBox cboFiltro;
        private System.Windows.Forms.ToolStripMenuItem c_mnuHistorialCrediticio;
        private System.Windows.Forms.ToolStripMenuItem c_mnuEliminaCuenta;
        private System.Windows.Forms.ToolStripMenuItem c_mnuCambiarCliente;
        private Telerik.WinControls.UI.RadLabel label2;
        private System.Windows.Forms.DateTimePicker txtFechaIni;
        private System.Windows.Forms.DateTimePicker txtFechaFin;
        private Telerik.WinControls.UI.RadLabel label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.ToolStripMenuItem mnuAbonoMultiple;
    }
}