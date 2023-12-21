namespace POSApp.Forms
{
    partial class frmProductosLista
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
            this.barCatProducto = new System.Windows.Forms.ToolStrip();
            this.btnAddNew = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.btnNuevaEntrada = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.lvCatProducto = new POSDLL.Windows.Forms.PrintableListView();
            this.c_mnuListaProductos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.c_mnuHistorialCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.c_mnuEditar = new System.Windows.Forms.ToolStripMenuItem();
            this.c_mnuExportar = new System.Windows.Forms.ToolStripMenuItem();
            this.c_mnuImprimir = new System.Windows.Forms.ToolStripMenuItem();
            this.c_mnuImprimirEtiqueta = new System.Windows.Forms.ToolStripMenuItem();
            this.c_mnuImprimeSeleccionadoFormato1 = new System.Windows.Forms.ToolStripMenuItem();
            this.c_mnuImprimeSeleccionadoFormato2 = new System.Windows.Forms.ToolStripMenuItem();
            this.c_mnuImprimeSeleccionadoFormato3 = new System.Windows.Forms.ToolStripMenuItem();
            this.c_mnuImprimirTodasEtiquetas = new System.Windows.Forms.ToolStripMenuItem();
            this.c_mnuImprimeEtiquetasTodoFormato1 = new System.Windows.Forms.ToolStripMenuItem();
            this.c_mnuImprimeEtiquetasTodoFormato2 = new System.Windows.Forms.ToolStripMenuItem();
            this.c_mnuImprimeEtiquetasTodoFormato3 = new System.Windows.Forms.ToolStripMenuItem();
            this.cboORDER = new System.Windows.Forms.ComboBox();
            this.cboORDENAR = new System.Windows.Forms.ComboBox();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.txtPALABRA1 = new Telerik.WinControls.UI.RadTextBox();
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.cboCOLMUNAS = new System.Windows.Forms.ComboBox();
            this.label3 = new Telerik.WinControls.UI.RadLabel();
            this.cboCOLUMNAS2 = new System.Windows.Forms.ComboBox();
            this.label4 = new Telerik.WinControls.UI.RadLabel();
            this.label5 = new Telerik.WinControls.UI.RadLabel();
            this.txtPALABRA2 = new Telerik.WinControls.UI.RadTextBox();
            this.cboORDENAR2 = new System.Windows.Forms.ComboBox();
            this.label6 = new Telerik.WinControls.UI.RadLabel();
            this.label7 = new Telerik.WinControls.UI.RadLabel();
            this.lblInfo = new Telerik.WinControls.UI.RadLabel();
            this.barCatProducto.SuspendLayout();
            this.c_mnuListaProductos.SuspendLayout();
            this.SuspendLayout();
            // 
            // barCatProducto
            // 
            this.barCatProducto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddNew,
            this.btnEdit,
            this.btnActualizar,
            this.btnNuevaEntrada,
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.btnExport,
            this.btnImprimir,
            this.toolStripSeparator3,
            this.btnClose});
            this.barCatProducto.Location = new System.Drawing.Point(0, 0);
            this.barCatProducto.MinimumSize = new System.Drawing.Size(743, 36);
            this.barCatProducto.Name = "barCatProducto";
            this.barCatProducto.Size = new System.Drawing.Size(861, 36);
            this.barCatProducto.TabIndex = 0;
            this.barCatProducto.Text = "toolStrip1";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Image = global::POS.Properties.Resources.DocumentHS;
            this.btnAddNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(46, 33);
            this.btnAddNew.Text = "Nuevo";
            this.btnAddNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddNew.ToolTipText = "Clic aquí para agregar un nuevo registro";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::POS.Properties.Resources.pencil;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(41, 33);
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
            this.btnActualizar.Size = new System.Drawing.Size(63, 33);
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnActualizar.ToolTipText = "Clic aquí para actualizar la lista";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnNuevaEntrada
            // 
            this.btnNuevaEntrada.Image = global::POS.Properties.Resources.arrow_down;
            this.btnNuevaEntrada.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevaEntrada.Name = "btnNuevaEntrada";
            this.btnNuevaEntrada.Size = new System.Drawing.Size(88, 33);
            this.btnNuevaEntrada.Text = "Nueva entrada";
            this.btnNuevaEntrada.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNuevaEntrada.ToolTipText = "Clic aquí para agregar una nueva entrada";
            this.btnNuevaEntrada.Click += new System.EventHandler(this.btnNuevaEntrada_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::POS.Properties.Resources.arrow_up;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(79, 33);
            this.toolStripButton1.Text = "Nueva Salida";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 36);
            // 
            // btnExport
            // 
            this.btnExport.Image = global::POS.Properties.Resources.excel;
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(54, 33);
            this.btnExport.Text = "Exportar";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExport.ToolTipText = "Exportar a Microsoft Excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = global::POS.Properties.Resources.printer;
            this.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(57, 33);
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnImprimir.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 36);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::POS.Properties.Resources.close;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(43, 33);
            this.btnClose.Text = "Cerrar";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lvCatProducto
            // 
            this.lvCatProducto.AllowColumnReorder = true;
            this.lvCatProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvCatProducto.ContextMenuStrip = this.c_mnuListaProductos;
            this.lvCatProducto.FitToPage = false;
            this.lvCatProducto.FullRowSelect = true;
            this.lvCatProducto.GridLines = true;
            this.lvCatProducto.HideSelection = false;
            this.lvCatProducto.Location = new System.Drawing.Point(12, 136);
            this.lvCatProducto.Name = "lvCatProducto";
            this.lvCatProducto.Size = new System.Drawing.Size(837, 155);
            this.lvCatProducto.TabIndex = 1;
            this.lvCatProducto.Title = "";
            this.lvCatProducto.UseCompatibleStateImageBehavior = false;
            this.lvCatProducto.DoubleClick += new System.EventHandler(this.lvCatProducto_DoubleClick);
            // 
            // c_mnuListaProductos
            // 
            this.c_mnuListaProductos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_mnuHistorialCompras,
            this.c_mnuEditar,
            this.c_mnuExportar,
            this.c_mnuImprimir,
            this.c_mnuImprimirEtiqueta,
            this.c_mnuImprimirTodasEtiquetas});
            this.c_mnuListaProductos.Name = "c_munListaProductos";
            this.c_mnuListaProductos.Size = new System.Drawing.Size(311, 158);
            // 
            // c_mnuHistorialCompras
            // 
            this.c_mnuHistorialCompras.Image = global::POS.Properties.Resources.calendar;
            this.c_mnuHistorialCompras.Name = "c_mnuHistorialCompras";
            this.c_mnuHistorialCompras.Size = new System.Drawing.Size(310, 22);
            this.c_mnuHistorialCompras.Text = "Ver historial de compras a proveedores";
            this.c_mnuHistorialCompras.Click += new System.EventHandler(this.c_mnuHistorialCompras_Click);
            // 
            // c_mnuEditar
            // 
            this.c_mnuEditar.Image = global::POS.Properties.Resources.pencil;
            this.c_mnuEditar.Name = "c_mnuEditar";
            this.c_mnuEditar.Size = new System.Drawing.Size(310, 22);
            this.c_mnuEditar.Text = "Editar el elemento seleccionado";
            this.c_mnuEditar.Click += new System.EventHandler(this.c_mnuEditar_Click);
            // 
            // c_mnuExportar
            // 
            this.c_mnuExportar.Image = global::POS.Properties.Resources.excel;
            this.c_mnuExportar.Name = "c_mnuExportar";
            this.c_mnuExportar.Size = new System.Drawing.Size(310, 22);
            this.c_mnuExportar.Text = "Exportar lista";
            this.c_mnuExportar.Click += new System.EventHandler(this.c_mnuExportar_Click);
            // 
            // c_mnuImprimir
            // 
            this.c_mnuImprimir.Image = global::POS.Properties.Resources.printer;
            this.c_mnuImprimir.Name = "c_mnuImprimir";
            this.c_mnuImprimir.Size = new System.Drawing.Size(310, 22);
            this.c_mnuImprimir.Text = "Imprimir lista";
            this.c_mnuImprimir.Click += new System.EventHandler(this.c_mnuImprimir_Click);
            // 
            // c_mnuImprimirEtiqueta
            // 
            this.c_mnuImprimirEtiqueta.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_mnuImprimeSeleccionadoFormato1,
            this.c_mnuImprimeSeleccionadoFormato2,
            this.c_mnuImprimeSeleccionadoFormato3});
            this.c_mnuImprimirEtiqueta.Image = global::POS.Properties.Resources.printer;
            this.c_mnuImprimirEtiqueta.Name = "c_mnuImprimirEtiqueta";
            this.c_mnuImprimirEtiqueta.Size = new System.Drawing.Size(310, 22);
            this.c_mnuImprimirEtiqueta.Text = "Imprimir etiqueta del elemento seleccionado";
            this.c_mnuImprimirEtiqueta.Click += new System.EventHandler(this.c_mnuImprimirEtiqueta_Click);
            // 
            // c_mnuImprimeSeleccionadoFormato1
            // 
            this.c_mnuImprimeSeleccionadoFormato1.Name = "c_mnuImprimeSeleccionadoFormato1";
            this.c_mnuImprimeSeleccionadoFormato1.Size = new System.Drawing.Size(164, 22);
            this.c_mnuImprimeSeleccionadoFormato1.Text = "Formato 1";
            this.c_mnuImprimeSeleccionadoFormato1.Visible = false;
            this.c_mnuImprimeSeleccionadoFormato1.Click += new System.EventHandler(this.c_mnuImprimeSeleccionadoFormato1_Click);
            // 
            // c_mnuImprimeSeleccionadoFormato2
            // 
            this.c_mnuImprimeSeleccionadoFormato2.Name = "c_mnuImprimeSeleccionadoFormato2";
            this.c_mnuImprimeSeleccionadoFormato2.Size = new System.Drawing.Size(164, 22);
            this.c_mnuImprimeSeleccionadoFormato2.Text = "Formato 2";
            this.c_mnuImprimeSeleccionadoFormato2.Visible = false;
            this.c_mnuImprimeSeleccionadoFormato2.Click += new System.EventHandler(this.c_mnuImprimeSeleccionadoFormato2_Click);
            // 
            // c_mnuImprimeSeleccionadoFormato3
            // 
            this.c_mnuImprimeSeleccionadoFormato3.Name = "c_mnuImprimeSeleccionadoFormato3";
            this.c_mnuImprimeSeleccionadoFormato3.Size = new System.Drawing.Size(164, 22);
            this.c_mnuImprimeSeleccionadoFormato3.Text = "Codigos de Barra";
            this.c_mnuImprimeSeleccionadoFormato3.Click += new System.EventHandler(this.c_mnuImprimeSeleccionadoFormato3_Click);
            // 
            // c_mnuImprimirTodasEtiquetas
            // 
            this.c_mnuImprimirTodasEtiquetas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_mnuImprimeEtiquetasTodoFormato1,
            this.c_mnuImprimeEtiquetasTodoFormato2,
            this.c_mnuImprimeEtiquetasTodoFormato3});
            this.c_mnuImprimirTodasEtiquetas.Image = global::POS.Properties.Resources.printer;
            this.c_mnuImprimirTodasEtiquetas.Name = "c_mnuImprimirTodasEtiquetas";
            this.c_mnuImprimirTodasEtiquetas.Size = new System.Drawing.Size(310, 22);
            this.c_mnuImprimirTodasEtiquetas.Text = "Imprimir todas las etiquetas";
            this.c_mnuImprimirTodasEtiquetas.Click += new System.EventHandler(this.c_mnuImprimirTodasEtiquetas_Click);
            // 
            // c_mnuImprimeEtiquetasTodoFormato1
            // 
            this.c_mnuImprimeEtiquetasTodoFormato1.Name = "c_mnuImprimeEtiquetasTodoFormato1";
            this.c_mnuImprimeEtiquetasTodoFormato1.Size = new System.Drawing.Size(164, 22);
            this.c_mnuImprimeEtiquetasTodoFormato1.Text = "Formato 1";
            this.c_mnuImprimeEtiquetasTodoFormato1.Visible = false;
            this.c_mnuImprimeEtiquetasTodoFormato1.Click += new System.EventHandler(this.c_mnuImprimeEtiquetasTodoFormato1_Click);
            // 
            // c_mnuImprimeEtiquetasTodoFormato2
            // 
            this.c_mnuImprimeEtiquetasTodoFormato2.Name = "c_mnuImprimeEtiquetasTodoFormato2";
            this.c_mnuImprimeEtiquetasTodoFormato2.Size = new System.Drawing.Size(164, 22);
            this.c_mnuImprimeEtiquetasTodoFormato2.Text = "Formato 2";
            this.c_mnuImprimeEtiquetasTodoFormato2.Visible = false;
            this.c_mnuImprimeEtiquetasTodoFormato2.Click += new System.EventHandler(this.c_mnuImprimeEtiquetasTodoFormato2_Click);
            // 
            // c_mnuImprimeEtiquetasTodoFormato3
            // 
            this.c_mnuImprimeEtiquetasTodoFormato3.Name = "c_mnuImprimeEtiquetasTodoFormato3";
            this.c_mnuImprimeEtiquetasTodoFormato3.Size = new System.Drawing.Size(164, 22);
            this.c_mnuImprimeEtiquetasTodoFormato3.Text = "Codigos de Barra";
            this.c_mnuImprimeEtiquetasTodoFormato3.Click += new System.EventHandler(this.c_mnuImprimeEtiquetasTodoFormato3_Click);
            // 
            // cboORDER
            // 
            this.cboORDER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboORDER.FormattingEnabled = true;
            this.cboORDER.Items.AddRange(new object[] {
            "Ascendente",
            "Descendente"});
            this.cboORDER.Location = new System.Drawing.Point(530, 110);
            this.cboORDER.Name = "cboORDER";
            this.cboORDER.Size = new System.Drawing.Size(125, 21);
            this.cboORDER.TabIndex = 18;
            // 
            // cboORDENAR
            // 
            this.cboORDENAR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboORDENAR.FormattingEnabled = true;
            this.cboORDENAR.Items.AddRange(new object[] {
            "Clave",
            "Nombre del Artículo",
            "Marca",
            "Grupo"});
            this.cboORDENAR.Location = new System.Drawing.Point(400, 68);
            this.cboORDENAR.Name = "cboORDENAR";
            this.cboORDENAR.Size = new System.Drawing.Size(124, 21);
            this.cboORDENAR.TabIndex = 17;
            this.cboORDENAR.SelectedIndexChanged += new System.EventHandler(this.cboORDENAR_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(397, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Ordenar por:";
            // 
            // txtPALABRA1
            // 
            this.txtPALABRA1.Location = new System.Drawing.Point(12, 109);
            this.txtPALABRA1.Name = "txtPALABRA1";
            this.txtPALABRA1.Size = new System.Drawing.Size(192, 20);
            this.txtPALABRA1.TabIndex = 15;
            this.txtPALABRA1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDESC_PRODUCTO_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Palabra a buscar:";
            // 
            // cboCOLMUNAS
            // 
            this.cboCOLMUNAS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCOLMUNAS.FormattingEnabled = true;
            this.cboCOLMUNAS.Location = new System.Drawing.Point(12, 68);
            this.cboCOLMUNAS.Name = "cboCOLMUNAS";
            this.cboCOLMUNAS.Size = new System.Drawing.Size(192, 21);
            this.cboCOLMUNAS.TabIndex = 20;
            this.cboCOLMUNAS.SelectedIndexChanged += new System.EventHandler(this.cboCOLMUNAS_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Buscar por:";
            // 
            // cboCOLUMNAS2
            // 
            this.cboCOLUMNAS2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCOLUMNAS2.FormattingEnabled = true;
            this.cboCOLUMNAS2.Location = new System.Drawing.Point(210, 68);
            this.cboCOLUMNAS2.Name = "cboCOLUMNAS2";
            this.cboCOLUMNAS2.Size = new System.Drawing.Size(184, 21);
            this.cboCOLUMNAS2.TabIndex = 21;
            this.cboCOLUMNAS2.SelectedIndexChanged += new System.EventHandler(this.cboCOLUMNAS2_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(207, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Luego por:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(210, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Palabra a buscar:";
            // 
            // txtPALABRA2
            // 
            this.txtPALABRA2.Location = new System.Drawing.Point(210, 110);
            this.txtPALABRA2.Name = "txtPALABRA2";
            this.txtPALABRA2.Size = new System.Drawing.Size(184, 20);
            this.txtPALABRA2.TabIndex = 24;
            this.txtPALABRA2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPALABRA2_KeyPress);
            // 
            // cboORDENAR2
            // 
            this.cboORDENAR2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboORDENAR2.FormattingEnabled = true;
            this.cboORDENAR2.Items.AddRange(new object[] {
            "Clave",
            "Nombre del Artículo",
            "Marca",
            "Grupo"});
            this.cboORDENAR2.Location = new System.Drawing.Point(400, 110);
            this.cboORDENAR2.Name = "cboORDENAR2";
            this.cboORDENAR2.Size = new System.Drawing.Size(124, 21);
            this.cboORDENAR2.TabIndex = 29;
            this.cboORDENAR2.SelectedIndexChanged += new System.EventHandler(this.cboORDENAR2_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(397, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Luego ordenar por:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(527, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Tipo de orden:";
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(12, 302);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(51, 13);
            this.lblInfo.TabIndex = 32;
            this.lblInfo.Text = "Registros";
            // 
            // frmProductosLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 324);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.txtPALABRA2);
            this.Controls.Add(this.cboCOLUMNAS2);
            this.Controls.Add(this.cboCOLMUNAS);
            this.Controls.Add(this.cboORDENAR2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.barCatProducto);
            this.Controls.Add(this.txtPALABRA1);
            this.Controls.Add(this.cboORDENAR);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboORDER);
            this.Controls.Add(this.lvCatProducto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.MinimumSize = new System.Drawing.Size(751, 350);
            this.Name = "frmProductosLista";
            this.ShowInTaskbar = false;
            this.Text = "Artículos";
            this.Load += new System.EventHandler(this.frmCatProducto_Load);
            this.barCatProducto.ResumeLayout(false);
            this.barCatProducto.PerformLayout();
            this.c_mnuListaProductos.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        
        void txtPALABRA2_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ORDENAR();
            }
        }

        void txtDESC_PRODUCTO_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {
                ORDENAR();
            }
        }

      
       
        #endregion

        private System.Windows.Forms.ToolStrip barCatProducto;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.ToolStripButton btnAddNew;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private POSDLL.Windows.Forms.PrintableListView lvCatProducto;
        private System.Windows.Forms.ToolStripButton btnNuevaEntrada;
        private System.Windows.Forms.ToolStripButton btnActualizar;
        private System.Windows.Forms.ContextMenuStrip c_mnuListaProductos;
        private System.Windows.Forms.ToolStripMenuItem c_mnuHistorialCompras;
        private System.Windows.Forms.ToolStripMenuItem c_mnuEditar;
        private System.Windows.Forms.ToolStripMenuItem c_mnuExportar;
        private System.Windows.Forms.ToolStripMenuItem c_mnuImprimir;
        private System.Windows.Forms.ComboBox cboORDER;
        private System.Windows.Forms.ComboBox cboORDENAR;
        private Telerik.WinControls.UI.RadLabel label2;
        private Telerik.WinControls.UI.RadTextBox txtPALABRA1;
        private Telerik.WinControls.UI.RadLabel label1;
        private System.Windows.Forms.ToolStripMenuItem c_mnuImprimirEtiqueta;
        private System.Windows.Forms.ToolStripMenuItem c_mnuImprimirTodasEtiquetas;
        private System.Windows.Forms.ToolStripMenuItem c_mnuImprimeSeleccionadoFormato1;
        private System.Windows.Forms.ToolStripMenuItem c_mnuImprimeSeleccionadoFormato2;
        private System.Windows.Forms.ToolStripMenuItem c_mnuImprimeSeleccionadoFormato3;
        private System.Windows.Forms.ToolStripMenuItem c_mnuImprimeEtiquetasTodoFormato1;
        private System.Windows.Forms.ToolStripMenuItem c_mnuImprimeEtiquetasTodoFormato2;
        private System.Windows.Forms.ToolStripMenuItem c_mnuImprimeEtiquetasTodoFormato3;
        private System.Windows.Forms.ComboBox cboCOLMUNAS;
        private Telerik.WinControls.UI.RadLabel label3;
        private System.Windows.Forms.ComboBox cboCOLUMNAS2;
        private Telerik.WinControls.UI.RadLabel label4;
        private Telerik.WinControls.UI.RadLabel label5;
        private Telerik.WinControls.UI.RadTextBox txtPALABRA2;
        private System.Windows.Forms.ComboBox cboORDENAR2;
        private Telerik.WinControls.UI.RadLabel label6;
        private Telerik.WinControls.UI.RadLabel label7;
        private System.Windows.Forms.ToolStripButton btnImprimir;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private Telerik.WinControls.UI.RadLabel lblInfo;

    }
}