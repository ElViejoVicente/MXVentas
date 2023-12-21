namespace POSApp.Forms
{
    partial class frmClientesLista
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
            this.barCatCliente = new System.Windows.Forms.ToolStrip();
            this.btnAddNew = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.lvCatCliente = new POSDLL.Windows.Forms.PrintableListView();
            this.c_mnuCatCliente = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.c_mnuPrintList = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.txtNOMBRE = new Telerik.WinControls.UI.RadTextBox();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.cboORDENAR = new System.Windows.Forms.ComboBox();
            this.cboORDER = new System.Windows.Forms.ComboBox();
            this.lblInfo = new Telerik.WinControls.UI.RadLabel();
            this.barCatCliente.SuspendLayout();
            this.c_mnuCatCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // barCatCliente
            // 
            this.barCatCliente.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddNew,
            this.btnEdit,
            this.toolStripSeparator1,
            this.btnExportar,
            this.toolStripButton1,
            this.toolStripSeparator3,
            this.btnClose});
            this.barCatCliente.Location = new System.Drawing.Point(0, 0);
            this.barCatCliente.Name = "barCatCliente";
            this.barCatCliente.Size = new System.Drawing.Size(696, 38);
            this.barCatCliente.TabIndex = 1;
            this.barCatCliente.Text = "toolStrip1";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Image = global::POS.Properties.Resources.DocumentHS;
            this.btnAddNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(46, 35);
            this.btnAddNew.Text = "Nuevo";
            this.btnAddNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
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
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
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
            // lvCatCliente
            // 
            this.lvCatCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvCatCliente.ContextMenuStrip = this.c_mnuCatCliente;
            this.lvCatCliente.FitToPage = false;
            this.lvCatCliente.FullRowSelect = true;
            this.lvCatCliente.GridLines = true;
            this.lvCatCliente.HideSelection = false;
            this.lvCatCliente.Location = new System.Drawing.Point(12, 93);
            this.lvCatCliente.Name = "lvCatCliente";
            this.lvCatCliente.Size = new System.Drawing.Size(672, 192);
            this.lvCatCliente.TabIndex = 2;
            this.lvCatCliente.Title = "";
            this.lvCatCliente.UseCompatibleStateImageBehavior = false;
            this.lvCatCliente.DoubleClick += new System.EventHandler(this.lvCatCliente_DoubleClick);
            this.lvCatCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvCatCliente_KeyPress);
            // 
            // c_mnuCatCliente
            // 
            this.c_mnuCatCliente.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddNew,
            this.mnuEdit,
            this.c_mnuPrintList});
            this.c_mnuCatCliente.Name = "c_mnuCatCliente";
            this.c_mnuCatCliente.Size = new System.Drawing.Size(242, 70);
            // 
            // mnuAddNew
            // 
            this.mnuAddNew.Image = global::POS.Properties.Resources.DocumentHS;
            this.mnuAddNew.Name = "mnuAddNew";
            this.mnuAddNew.Size = new System.Drawing.Size(241, 22);
            this.mnuAddNew.Text = "Agregar un nuevo elemento";
            this.mnuAddNew.Click += new System.EventHandler(this.mnuAddNew_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Image = global::POS.Properties.Resources.pencil;
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(241, 22);
            this.mnuEdit.Text = "Editar el elemento seleccionado";
            this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
            // 
            // c_mnuPrintList
            // 
            this.c_mnuPrintList.Image = global::POS.Properties.Resources.printer;
            this.c_mnuPrintList.Name = "c_mnuPrintList";
            this.c_mnuPrintList.Size = new System.Drawing.Size(241, 22);
            this.c_mnuPrintList.Text = "Imprimir lista";
            this.c_mnuPrintList.Click += new System.EventHandler(this.c_mnuPrintList_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nombre del cliente";
            // 
            // txtNOMBRE
            // 
            this.txtNOMBRE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNOMBRE.Location = new System.Drawing.Point(12, 64);
            this.txtNOMBRE.Name = "txtNOMBRE";
            this.txtNOMBRE.Size = new System.Drawing.Size(411, 20);
            this.txtNOMBRE.TabIndex = 4;
            this.txtNOMBRE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNOMBRE_KeyPress);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(426, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ordenar por:";
            // 
            // cboORDENAR
            // 
            this.cboORDENAR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboORDENAR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboORDENAR.FormattingEnabled = true;
            this.cboORDENAR.Items.AddRange(new object[] {
            "ID Cliente",
            "RFC",
            "Nombre",
            "Tipo"});
            this.cboORDENAR.Location = new System.Drawing.Point(429, 63);
            this.cboORDENAR.Name = "cboORDENAR";
            this.cboORDENAR.Size = new System.Drawing.Size(124, 21);
            this.cboORDENAR.TabIndex = 6;
            this.cboORDENAR.SelectionChangeCommitted += new System.EventHandler(this.cboORDENAR_SelectionChangeCommitted);
            // 
            // cboORDER
            // 
            this.cboORDER.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboORDER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboORDER.FormattingEnabled = true;
            this.cboORDER.Items.AddRange(new object[] {
            "ASCENDENTE",
            "DESCENDENTE"});
            this.cboORDER.Location = new System.Drawing.Point(559, 63);
            this.cboORDER.Name = "cboORDER";
            this.cboORDER.Size = new System.Drawing.Size(125, 21);
            this.cboORDER.TabIndex = 7;
            this.cboORDER.SelectionChangeCommitted += new System.EventHandler(this.cboORDER_SelectionChangeCommitted);
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(13, 288);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(51, 13);
            this.lblInfo.TabIndex = 8;
            this.lblInfo.Text = "Registros";
            // 
            // frmClientesLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 313);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.cboORDER);
            this.Controls.Add(this.cboORDENAR);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNOMBRE);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvCatCliente);
            this.Controls.Add(this.barCatCliente);
            this.MinimumSize = new System.Drawing.Size(559, 316);
            this.Name = "frmClientesLista";
            this.ShowInTaskbar = false;
            this.Text = "Cliente";
            this.Load += new System.EventHandler(this.frmCatClientes_Load);
            this.barCatCliente.ResumeLayout(false);
            this.barCatCliente.PerformLayout();
            this.c_mnuCatCliente.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

   

       
        

       

        #endregion

        private System.Windows.Forms.ToolStrip barCatCliente;
        private System.Windows.Forms.ToolStripButton btnAddNew;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnClose;
        private POSDLL.Windows.Forms.PrintableListView lvCatCliente;
        private Telerik.WinControls.UI.RadLabel label1;
        private Telerik.WinControls.UI.RadTextBox txtNOMBRE;
        private Telerik.WinControls.UI.RadLabel label2;
        private System.Windows.Forms.ComboBox cboORDENAR;
        private System.Windows.Forms.ComboBox cboORDER;
        private System.Windows.Forms.ContextMenuStrip c_mnuCatCliente;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuAddNew;
        private System.Windows.Forms.ToolStripMenuItem c_mnuPrintList;
        private System.Windows.Forms.ToolStripButton btnExportar;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private Telerik.WinControls.UI.RadLabel lblInfo;
    }
}