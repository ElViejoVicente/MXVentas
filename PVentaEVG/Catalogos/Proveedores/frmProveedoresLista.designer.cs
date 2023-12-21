namespace POSApp.Forms
{
    partial class frmProveedoresLista
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
            this.barCatProveedor = new System.Windows.Forms.ToolStrip();
            this.btnAddNew = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.btnExportar = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.cboORDER = new System.Windows.Forms.ComboBox();
            this.cboORDENAR = new System.Windows.Forms.ComboBox();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.txtNOMBRE = new Telerik.WinControls.UI.RadTextBox();
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.lvCatProveedor = new POSDLL.Windows.Forms.PrintableListView();
            this.c_mnuListaArticulos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.c_mnuNuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.c_mnuEditar = new System.Windows.Forms.ToolStripMenuItem();
            this.c_mnuImprimir = new System.Windows.Forms.ToolStripMenuItem();
            this.lblInfo = new Telerik.WinControls.UI.RadLabel();
            this.barCatProveedor.SuspendLayout();
            this.c_mnuListaArticulos.SuspendLayout();
            this.SuspendLayout();
            // 
            // barCatProveedor
            // 
            this.barCatProveedor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddNew,
            this.btnEdit,
            this.btnActualizar,
            this.btnExportar,
            this.btnPrint,
            this.toolStripSeparator3,
            this.btnClose});
            this.barCatProveedor.Location = new System.Drawing.Point(0, 0);
            this.barCatProveedor.Name = "barCatProveedor";
            this.barCatProveedor.Size = new System.Drawing.Size(573, 38);
            this.barCatProveedor.TabIndex = 2;
            this.barCatProveedor.Text = "toolStrip1";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Image = global::POS.Properties.Resources.DocumentHS;
            this.btnAddNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(46, 35);
            this.btnAddNew.Text = "Nuevo";
            this.btnAddNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddNew.ToolTipText = "Clic aquí para agregar un nuevo proveedor";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::POS.Properties.Resources.pencil;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(41, 35);
            this.btnEdit.Text = "Editar";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEdit.ToolTipText = "Clic aquí para editar el elemento seleccionado";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Image = global::POS.Properties.Resources.RefreshDocViewHS;
            this.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(63, 35);
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnActualizar.ToolTipText = "Clic aquí para actializar la lista";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
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
            // btnPrint
            // 
            this.btnPrint.Image = global::POS.Properties.Resources.printer;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(57, 35);
            this.btnPrint.Text = "Imprimir";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrint.ToolTipText = "Clic aquí para imprimir la lista";
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
            // cboORDER
            // 
            this.cboORDER.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboORDER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboORDER.FormattingEnabled = true;
            this.cboORDER.Items.AddRange(new object[] {
            "ASCENDENTE",
            "DESCENDENTE"});
            this.cboORDER.Location = new System.Drawing.Point(439, 67);
            this.cboORDER.Name = "cboORDER";
            this.cboORDER.Size = new System.Drawing.Size(125, 21);
            this.cboORDER.TabIndex = 13;
            this.cboORDER.SelectionChangeCommitted += new System.EventHandler(this.cboORDER_SelectionChangeCommitted);
            // 
            // cboORDENAR
            // 
            this.cboORDENAR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboORDENAR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboORDENAR.FormattingEnabled = true;
            this.cboORDENAR.Items.AddRange(new object[] {
            "CLAVE DEL PROVEEDOR",
            "RFC",
            "NOMBRE DEL PROVEEDOR"});
            this.cboORDENAR.Location = new System.Drawing.Point(309, 67);
            this.cboORDENAR.Name = "cboORDENAR";
            this.cboORDENAR.Size = new System.Drawing.Size(124, 21);
            this.cboORDENAR.TabIndex = 12;
            this.cboORDENAR.SelectionChangeCommitted += new System.EventHandler(this.cboORDENAR_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(306, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Ordenar por:";
            // 
            // txtNOMBRE
            // 
            this.txtNOMBRE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNOMBRE.Location = new System.Drawing.Point(15, 68);
            this.txtNOMBRE.Name = "txtNOMBRE";
            this.txtNOMBRE.Size = new System.Drawing.Size(288, 20);
            this.txtNOMBRE.TabIndex = 10;
            this.txtNOMBRE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNOMBRE_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nombre del proveedor:";
            // 
            // lvCatProveedor
            // 
            this.lvCatProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvCatProveedor.ContextMenuStrip = this.c_mnuListaArticulos;
            this.lvCatProveedor.FitToPage = false;
            this.lvCatProveedor.FullRowSelect = true;
            this.lvCatProveedor.GridLines = true;
            this.lvCatProveedor.HideSelection = false;
            this.lvCatProveedor.Location = new System.Drawing.Point(15, 97);
            this.lvCatProveedor.Name = "lvCatProveedor";
            this.lvCatProveedor.Size = new System.Drawing.Size(549, 126);
            this.lvCatProveedor.TabIndex = 8;
            this.lvCatProveedor.Title = "";
            this.lvCatProveedor.UseCompatibleStateImageBehavior = false;
            // 
            // c_mnuListaArticulos
            // 
            this.c_mnuListaArticulos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_mnuNuevo,
            this.c_mnuEditar,
            this.c_mnuImprimir});
            this.c_mnuListaArticulos.Name = "c_mnuListaArticulos";
            this.c_mnuListaArticulos.Size = new System.Drawing.Size(236, 92);
            // 
            // c_mnuNuevo
            // 
            this.c_mnuNuevo.Image = global::POS.Properties.Resources.DocumentHS;
            this.c_mnuNuevo.Name = "c_mnuNuevo";
            this.c_mnuNuevo.Size = new System.Drawing.Size(235, 22);
            this.c_mnuNuevo.Text = "Nuevo";
            this.c_mnuNuevo.Click += new System.EventHandler(this.c_mnuNuevo_Click);
            // 
            // c_mnuEditar
            // 
            this.c_mnuEditar.Image = global::POS.Properties.Resources.pencil;
            this.c_mnuEditar.Name = "c_mnuEditar";
            this.c_mnuEditar.Size = new System.Drawing.Size(235, 22);
            this.c_mnuEditar.Text = "Editar el elemento selecionado";
            this.c_mnuEditar.Click += new System.EventHandler(this.c_mnuEditar_Click);
            // 
            // c_mnuImprimir
            // 
            this.c_mnuImprimir.Image = global::POS.Properties.Resources.printer;
            this.c_mnuImprimir.Name = "c_mnuImprimir";
            this.c_mnuImprimir.Size = new System.Drawing.Size(235, 22);
            this.c_mnuImprimir.Text = "Imprimir";
            this.c_mnuImprimir.Click += new System.EventHandler(this.c_mnuImprimir_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(15, 230);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(51, 13);
            this.lblInfo.TabIndex = 14;
            this.lblInfo.Text = "Registros";
            // 
            // frmProveedoresLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 256);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.cboORDER);
            this.Controls.Add(this.cboORDENAR);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNOMBRE);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvCatProveedor);
            this.Controls.Add(this.barCatProveedor);
            this.MinimumSize = new System.Drawing.Size(523, 284);
            this.Name = "frmProveedoresLista";
            this.ShowInTaskbar = false;
            this.Text = "Proveedores";
            this.Load += new System.EventHandler(this.frmCatProveedores_Load);
            this.barCatProveedor.ResumeLayout(false);
            this.barCatProveedor.PerformLayout();
            this.c_mnuListaArticulos.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

        #endregion

        private System.Windows.Forms.ToolStrip barCatProveedor;
        private System.Windows.Forms.ToolStripButton btnAddNew;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ComboBox cboORDER;
        private System.Windows.Forms.ComboBox cboORDENAR;
        private Telerik.WinControls.UI.RadLabel label2;
        private Telerik.WinControls.UI.RadTextBox txtNOMBRE;
        private Telerik.WinControls.UI.RadLabel label1;
        private POSDLL.Windows.Forms.PrintableListView lvCatProveedor;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ContextMenuStrip c_mnuListaArticulos;
        private System.Windows.Forms.ToolStripMenuItem c_mnuNuevo;
        private System.Windows.Forms.ToolStripMenuItem c_mnuEditar;
        private System.Windows.Forms.ToolStripMenuItem c_mnuImprimir;
        private System.Windows.Forms.ToolStripButton btnActualizar;
        private System.Windows.Forms.ToolStripButton btnExportar;
        private Telerik.WinControls.UI.RadLabel lblInfo;
    }
}