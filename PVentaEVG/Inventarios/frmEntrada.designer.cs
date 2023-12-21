namespace POSApp.Forms
{
    partial class frmEntrada
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
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.txtFOLIO_FACTURA = new Telerik.WinControls.UI.RadTextBox();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.label3 = new Telerik.WinControls.UI.RadLabel();
            this.dtpFECHA_FACTURA = new System.Windows.Forms.DateTimePicker();
            this.c_mnuDetalleEntrada = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuModificar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label4 = new Telerik.WinControls.UI.RadLabel();
            this.txtObservaciones = new Telerik.WinControls.UI.RadTextBox();
            this.lvDetalleEntrada = new System.Windows.Forms.ListView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSearchProvider = new System.Windows.Forms.Button();
            this.btnSearchProduct = new System.Windows.Forms.Button();
            this.txtID_PRODUCTO = new Telerik.WinControls.UI.RadTextBox();
            this.label5 = new Telerik.WinControls.UI.RadLabel();
            this.txtIMPUESTO = new Telerik.WinControls.UI.RadTextBox();
            this.txtPRECIO = new Telerik.WinControls.UI.RadTextBox();
            this.label7 = new Telerik.WinControls.UI.RadLabel();
            this.txtCANTIDAD = new Telerik.WinControls.UI.RadTextBox();
            this.label8 = new Telerik.WinControls.UI.RadLabel();
            this.chkGASTO = new System.Windows.Forms.CheckBox();
            this.label9 = new Telerik.WinControls.UI.RadLabel();
            this.txtPORC_AUMENTO = new Telerik.WinControls.UI.RadTextBox();
            this.txtID_PROVEEDOR = new Telerik.WinControls.UI.RadTextBox();
            this.label10 = new Telerik.WinControls.UI.RadLabel();
            this.txtPrecioVenta = new Telerik.WinControls.UI.RadTextBox();
            this.txtPrecioVenta2 = new Telerik.WinControls.UI.RadTextBox();
            this.label11 = new Telerik.WinControls.UI.RadLabel();
            this.txtPrecioVenta3 = new Telerik.WinControls.UI.RadTextBox();
            this.label12 = new Telerik.WinControls.UI.RadLabel();
            this.txtPRECIO_VENTA3 = new Telerik.WinControls.UI.RadTextBox();
            this.label13 = new Telerik.WinControls.UI.RadLabel();
            this.txtPRECIO_VENTA2 = new Telerik.WinControls.UI.RadTextBox();
            this.label14 = new Telerik.WinControls.UI.RadLabel();
            this.txtPRECIO_VENTA = new Telerik.WinControls.UI.RadTextBox();
            this.label15 = new Telerik.WinControls.UI.RadLabel();
            this.chkIVA = new System.Windows.Forms.CheckBox();
            this.label6 = new Telerik.WinControls.UI.RadLabel();
            this.txtIMPORTE = new Telerik.WinControls.UI.RadTextBox();
            this.btnNewProduct = new System.Windows.Forms.Button();
            this.lblDescripcionProducto = new Telerik.WinControls.UI.RadLabel();
            this.txtPrecioAnt = new Telerik.WinControls.UI.RadTextBox();
            this.label16 = new Telerik.WinControls.UI.RadLabel();
            this.c_mnuDetalleEntrada.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Folio de la factura:";
            // 
            // txtFOLIO_FACTURA
            // 
            this.txtFOLIO_FACTURA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFOLIO_FACTURA.Location = new System.Drawing.Point(15, 25);
            this.txtFOLIO_FACTURA.Name = "txtFOLIO_FACTURA";
            this.txtFOLIO_FACTURA.Size = new System.Drawing.Size(133, 20);
            this.txtFOLIO_FACTURA.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Id del Proveedor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fecha de la factura:";
            // 
            // dtpFECHA_FACTURA
            // 
            this.dtpFECHA_FACTURA.CustomFormat = "dd/MM/yyyy";
            this.dtpFECHA_FACTURA.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFECHA_FACTURA.Location = new System.Drawing.Point(15, 64);
            this.dtpFECHA_FACTURA.Name = "dtpFECHA_FACTURA";
            this.dtpFECHA_FACTURA.Size = new System.Drawing.Size(133, 20);
            this.dtpFECHA_FACTURA.TabIndex = 3;
            // 
            // c_mnuDetalleEntrada
            // 
            this.c_mnuDetalleEntrada.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuModificar,
            this.mnuEliminar});
            this.c_mnuDetalleEntrada.Name = "c_mnuDetalleEntrada";
            this.c_mnuDetalleEntrada.Size = new System.Drawing.Size(126, 48);
            // 
            // mnuModificar
            // 
            this.mnuModificar.Image = global::POS.Properties.Resources.pencil1;
            this.mnuModificar.Name = "mnuModificar";
            this.mnuModificar.Size = new System.Drawing.Size(125, 22);
            this.mnuModificar.Text = "Modificar";
            this.mnuModificar.Click += new System.EventHandler(this.mnuModificar_Click);
            // 
            // mnuEliminar
            // 
            this.mnuEliminar.Image = global::POS.Properties.Resources.delete;
            this.mnuEliminar.Name = "mnuEliminar";
            this.mnuEliminar.Size = new System.Drawing.Size(125, 22);
            this.mnuEliminar.Text = "Eliminar";
            this.mnuEliminar.Click += new System.EventHandler(this.mnuEliminar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObservaciones.Location = new System.Drawing.Point(15, 106);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(686, 37);
            this.txtObservaciones.TabIndex = 4;
            // 
            // lvDetalleEntrada
            // 
            this.lvDetalleEntrada.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvDetalleEntrada.ContextMenuStrip = this.c_mnuDetalleEntrada;
            this.lvDetalleEntrada.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvDetalleEntrada.FullRowSelect = true;
            this.lvDetalleEntrada.GridLines = true;
            this.lvDetalleEntrada.HideSelection = false;
            this.lvDetalleEntrada.Location = new System.Drawing.Point(12, 285);
            this.lvDetalleEntrada.Name = "lvDetalleEntrada";
            this.lvDetalleEntrada.Size = new System.Drawing.Size(720, 209);
            this.lvDetalleEntrada.TabIndex = 28;
            this.lvDetalleEntrada.UseCompatibleStateImageBehavior = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::POS.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(658, 501);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 30);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Image = global::POS.Properties.Resources.add;
            this.btnAddProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddProduct.Location = new System.Drawing.Point(455, 196);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(74, 30);
            this.btnAddProduct.TabIndex = 18;
            this.btnAddProduct.Text = "Agregar";
            this.btnAddProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::POS.Properties.Resources.disk;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(585, 501);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(67, 30);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Grabar";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSearchProvider
            // 
            this.btnSearchProvider.Image = global::POS.Properties.Resources.zoom;
            this.btnSearchProvider.Location = new System.Drawing.Point(293, 22);
            this.btnSearchProvider.Name = "btnSearchProvider";
            this.btnSearchProvider.Size = new System.Drawing.Size(37, 23);
            this.btnSearchProvider.TabIndex = 2;
            this.btnSearchProvider.UseVisualStyleBackColor = true;
            this.btnSearchProvider.Click += new System.EventHandler(this.btnSearchProvider_Click);
            // 
            // btnSearchProduct
            // 
            this.btnSearchProduct.Image = global::POS.Properties.Resources.zoom;
            this.btnSearchProduct.Location = new System.Drawing.Point(126, 175);
            this.btnSearchProduct.Name = "btnSearchProduct";
            this.btnSearchProduct.Size = new System.Drawing.Size(38, 23);
            this.btnSearchProduct.TabIndex = 6;
            this.btnSearchProduct.UseVisualStyleBackColor = true;
            this.btnSearchProduct.Click += new System.EventHandler(this.btnSearchProduct_Click);
            // 
            // txtID_PRODUCTO
            // 
            this.txtID_PRODUCTO.Location = new System.Drawing.Point(21, 175);
            this.txtID_PRODUCTO.Name = "txtID_PRODUCTO";
            this.txtID_PRODUCTO.Size = new System.Drawing.Size(99, 20);
            this.txtID_PRODUCTO.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Clave del artículo:";
            // 
            // txtIMPUESTO
            // 
            this.txtIMPUESTO.Location = new System.Drawing.Point(403, 173);
            this.txtIMPUESTO.Name = "txtIMPUESTO";
            this.txtIMPUESTO.Size = new System.Drawing.Size(38, 20);
            this.txtIMPUESTO.TabIndex = 11;
            this.txtIMPUESTO.Text = "0.16";
            // 
            // txtPRECIO
            // 
            this.txtPRECIO.Location = new System.Drawing.Point(336, 173);
            this.txtPRECIO.Name = "txtPRECIO";
            this.txtPRECIO.Size = new System.Drawing.Size(61, 20);
            this.txtPRECIO.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(336, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Precio:";
            // 
            // txtCANTIDAD
            // 
            this.txtCANTIDAD.Location = new System.Drawing.Point(170, 173);
            this.txtCANTIDAD.Name = "txtCANTIDAD";
            this.txtCANTIDAD.Size = new System.Drawing.Size(49, 20);
            this.txtCANTIDAD.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(167, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Cantidad:";
            // 
            // chkGASTO
            // 
            this.chkGASTO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkGASTO.AutoSize = true;
            this.chkGASTO.Checked = true;
            this.chkGASTO.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGASTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGASTO.ForeColor = System.Drawing.Color.Red;
            this.chkGASTO.Location = new System.Drawing.Point(12, 509);
            this.chkGASTO.Name = "chkGASTO";
            this.chkGASTO.Size = new System.Drawing.Size(142, 21);
            this.chkGASTO.TabIndex = 20;
            this.chkGASTO.Text = "Registrar Gasto";
            this.chkGASTO.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(161, 512);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "% Precio Venta:";
            // 
            // txtPORC_AUMENTO
            // 
            this.txtPORC_AUMENTO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPORC_AUMENTO.BackColor = System.Drawing.Color.Yellow;
            this.txtPORC_AUMENTO.Location = new System.Drawing.Point(243, 509);
            this.txtPORC_AUMENTO.MaxLength = 3;
            this.txtPORC_AUMENTO.Name = "txtPORC_AUMENTO";
            this.txtPORC_AUMENTO.Size = new System.Drawing.Size(37, 20);
            this.txtPORC_AUMENTO.TabIndex = 21;
            this.txtPORC_AUMENTO.Text = "0";
            // 
            // txtID_PROVEEDOR
            // 
            this.txtID_PROVEEDOR.Location = new System.Drawing.Point(154, 25);
            this.txtID_PROVEEDOR.Name = "txtID_PROVEEDOR";
            this.txtID_PROVEEDOR.Size = new System.Drawing.Size(133, 20);
            this.txtID_PROVEEDOR.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 202);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Precio Venta:";
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Enabled = false;
            this.txtPrecioVenta.Location = new System.Drawing.Point(21, 219);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(100, 20);
            this.txtPrecioVenta.TabIndex = 12;
            // 
            // txtPrecioVenta2
            // 
            this.txtPrecioVenta2.Enabled = false;
            this.txtPrecioVenta2.Location = new System.Drawing.Point(126, 219);
            this.txtPrecioVenta2.Name = "txtPrecioVenta2";
            this.txtPrecioVenta2.Size = new System.Drawing.Size(100, 20);
            this.txtPrecioVenta2.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(126, 202);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Precio Trab:";
            // 
            // txtPrecioVenta3
            // 
            this.txtPrecioVenta3.Enabled = false;
            this.txtPrecioVenta3.Location = new System.Drawing.Point(230, 219);
            this.txtPrecioVenta3.Name = "txtPrecioVenta3";
            this.txtPrecioVenta3.Size = new System.Drawing.Size(100, 20);
            this.txtPrecioVenta3.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(230, 202);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Precio Mayoreo:";
            // 
            // txtPRECIO_VENTA3
            // 
            this.txtPRECIO_VENTA3.Location = new System.Drawing.Point(230, 259);
            this.txtPRECIO_VENTA3.Name = "txtPRECIO_VENTA3";
            this.txtPRECIO_VENTA3.Size = new System.Drawing.Size(100, 20);
            this.txtPRECIO_VENTA3.TabIndex = 17;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(230, 242);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 13);
            this.label13.TabIndex = 17;
            this.label13.Text = "Precio Mayoreo:";
            // 
            // txtPRECIO_VENTA2
            // 
            this.txtPRECIO_VENTA2.Location = new System.Drawing.Point(126, 259);
            this.txtPRECIO_VENTA2.Name = "txtPRECIO_VENTA2";
            this.txtPRECIO_VENTA2.Size = new System.Drawing.Size(100, 20);
            this.txtPRECIO_VENTA2.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(126, 242);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = "Precio Trab:";
            // 
            // txtPRECIO_VENTA
            // 
            this.txtPRECIO_VENTA.Location = new System.Drawing.Point(21, 259);
            this.txtPRECIO_VENTA.Name = "txtPRECIO_VENTA";
            this.txtPRECIO_VENTA.Size = new System.Drawing.Size(100, 20);
            this.txtPRECIO_VENTA.TabIndex = 15;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(21, 242);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 13);
            this.label15.TabIndex = 15;
            this.label15.Text = "Precio Venta:";
            // 
            // chkIVA
            // 
            this.chkIVA.AutoSize = true;
            this.chkIVA.Checked = true;
            this.chkIVA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIVA.Location = new System.Drawing.Point(403, 155);
            this.chkIVA.Name = "chkIVA";
            this.chkIVA.Size = new System.Drawing.Size(46, 17);
            this.chkIVA.TabIndex = 10;
            this.chkIVA.Text = "IVA:";
            this.chkIVA.UseVisualStyleBackColor = true;
            this.chkIVA.CheckedChanged += new System.EventHandler(this.chkIVA_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(227, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Importe:";
            // 
            // txtIMPORTE
            // 
            this.txtIMPORTE.Location = new System.Drawing.Point(230, 173);
            this.txtIMPORTE.MaxLength = 10;
            this.txtIMPORTE.Name = "txtIMPORTE";
            this.txtIMPORTE.Size = new System.Drawing.Size(100, 20);
            this.txtIMPORTE.TabIndex = 8;
            // 
            // btnNewProduct
            // 
            this.btnNewProduct.Image = global::POS.Properties.Resources.add;
            this.btnNewProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewProduct.Location = new System.Drawing.Point(612, 196);
            this.btnNewProduct.Name = "btnNewProduct";
            this.btnNewProduct.Size = new System.Drawing.Size(119, 30);
            this.btnNewProduct.TabIndex = 29;
            this.btnNewProduct.Text = "Nuevo Articulo";
            this.btnNewProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewProduct.UseVisualStyleBackColor = true;
            this.btnNewProduct.Click += new System.EventHandler(this.btnNewProduct_Click);
            // 
            // lblDescripcionProducto
            // 
            //this.lblDescripcionProducto.TextAlign = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDescripcionProducto.Location = new System.Drawing.Point(455, 170);
            this.lblDescripcionProducto.Name = "lblDescripcionProducto";
            this.lblDescripcionProducto.Size = new System.Drawing.Size(276, 23);
            this.lblDescripcionProducto.TabIndex = 30;
            // 
            // txtPrecioAnt
            // 
            this.txtPrecioAnt.Enabled = false;
            this.txtPrecioAnt.Location = new System.Drawing.Point(336, 219);
            this.txtPrecioAnt.Name = "txtPrecioAnt";
            this.txtPrecioAnt.Size = new System.Drawing.Size(61, 20);
            this.txtPrecioAnt.TabIndex = 32;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(336, 203);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 13);
            this.label16.TabIndex = 31;
            this.label16.Text = "Precio Ant:";
            // 
            // frmEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(747, 536);
            this.Controls.Add(this.txtPrecioAnt);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lblDescripcionProducto);
            this.Controls.Add(this.txtIMPORTE);
            this.Controls.Add(this.btnNewProduct);
            this.Controls.Add(this.chkIVA);
            this.Controls.Add(this.txtPRECIO_VENTA3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPORC_AUMENTO);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtPRECIO_VENTA2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtPRECIO_VENTA);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtPrecioVenta3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtPrecioVenta2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtPrecioVenta);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtID_PROVEEDOR);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.chkGASTO);
            this.Controls.Add(this.lvDetalleEntrada);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtPRECIO);
            this.Controls.Add(this.txtCANTIDAD);
            this.Controls.Add(this.txtIMPUESTO);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSearchProduct);
            this.Controls.Add(this.txtID_PRODUCTO);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpFECHA_FACTURA);
            this.Controls.Add(this.txtFOLIO_FACTURA);
            this.Controls.Add(this.btnSearchProvider);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmEntrada";
            this.ShowInTaskbar = false;
            this.Text = "Entradas";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmEntrada_Closing);
            this.Load += new System.EventHandler(this.frmEntrada_Load);
            this.c_mnuDetalleEntrada.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

        #endregion

        private Telerik.WinControls.UI.RadLabel label1;
        private Telerik.WinControls.UI.RadTextBox txtFOLIO_FACTURA;
        private Telerik.WinControls.UI.RadLabel label2;
        private System.Windows.Forms.Button btnSearchProvider;
        private Telerik.WinControls.UI.RadLabel label3;
        private System.Windows.Forms.DateTimePicker dtpFECHA_FACTURA;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip c_mnuDetalleEntrada;
        private System.Windows.Forms.ToolStripMenuItem mnuModificar;
        private System.Windows.Forms.ToolStripMenuItem mnuEliminar;
        private Telerik.WinControls.UI.RadLabel label4;
        private Telerik.WinControls.UI.RadTextBox txtObservaciones;
        private System.Windows.Forms.ListView lvDetalleEntrada;
        private System.Windows.Forms.Button btnSearchProduct;
        private Telerik.WinControls.UI.RadTextBox txtID_PRODUCTO;
        private Telerik.WinControls.UI.RadLabel label5;
        private Telerik.WinControls.UI.RadTextBox txtIMPUESTO;
        private Telerik.WinControls.UI.RadTextBox txtPRECIO;
        private Telerik.WinControls.UI.RadLabel label7;
        private Telerik.WinControls.UI.RadTextBox txtCANTIDAD;
        private Telerik.WinControls.UI.RadLabel label8;
        private System.Windows.Forms.CheckBox chkGASTO;
        private Telerik.WinControls.UI.RadLabel label9;
        private Telerik.WinControls.UI.RadTextBox txtPORC_AUMENTO;
        private Telerik.WinControls.UI.RadTextBox txtID_PROVEEDOR;
        private Telerik.WinControls.UI.RadLabel label10;
        private Telerik.WinControls.UI.RadTextBox txtPrecioVenta;
        private Telerik.WinControls.UI.RadTextBox txtPrecioVenta2;
        private Telerik.WinControls.UI.RadLabel label11;
        private Telerik.WinControls.UI.RadTextBox txtPrecioVenta3;
        private Telerik.WinControls.UI.RadLabel label12;
        private Telerik.WinControls.UI.RadTextBox txtPRECIO_VENTA3;
        private Telerik.WinControls.UI.RadLabel label13;
        private Telerik.WinControls.UI.RadTextBox txtPRECIO_VENTA2;
        private Telerik.WinControls.UI.RadLabel label14;
        private Telerik.WinControls.UI.RadTextBox txtPRECIO_VENTA;
        private Telerik.WinControls.UI.RadLabel label15;
        private System.Windows.Forms.CheckBox chkIVA;
        private Telerik.WinControls.UI.RadLabel label6;
        private Telerik.WinControls.UI.RadTextBox txtIMPORTE;
        private System.Windows.Forms.Button btnNewProduct;
        private Telerik.WinControls.UI.RadLabel lblDescripcionProducto;
        private Telerik.WinControls.UI.RadTextBox txtPrecioAnt;
        private Telerik.WinControls.UI.RadLabel label16;
    }
}