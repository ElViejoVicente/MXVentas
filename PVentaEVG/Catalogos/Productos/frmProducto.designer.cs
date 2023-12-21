using POSDLL; using POSDLL.Windows.Forms; using POSDLL.Security; using POSDLL.Reporting; using POSDLL.Ticket;
namespace POSApp.Forms
{
    partial class frmProducto
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
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.txtID_PRODUCTO = new Telerik.WinControls.UI.RadTextBox();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.txtDESC_PRODUCTO = new Telerik.WinControls.UI.RadTextBox();
            this.label4 = new Telerik.WinControls.UI.RadLabel();
            this.txtEXISTENCIA = new Telerik.WinControls.UI.RadTextBox();
            this.lblPRECIO_VENTA = new Telerik.WinControls.UI.RadLabel();
            this.txtPRECIO_VENTA = new Telerik.WinControls.UI.RadTextBox();
            this.txtIMPUESTO = new Telerik.WinControls.UI.RadTextBox();
            this.lblID_MARCA = new Telerik.WinControls.UI.RadLabel();
            this.cboID_MARCA = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblID_GRUPO = new Telerik.WinControls.UI.RadLabel();
            this.cboID_GRUPO = new System.Windows.Forms.ComboBox();
            this.lblPRECIO_COMPRA = new Telerik.WinControls.UI.RadLabel();
            this.txtPRECIO_COMPRA = new Telerik.WinControls.UI.RadTextBox();
            this.lblNOMBRES_CO = new Telerik.WinControls.UI.RadLabel();
            this.txtNOMBRES_CO = new Telerik.WinControls.UI.RadTextBox();
            this.chkC_BARRAS = new System.Windows.Forms.CheckBox();
            this.lblCANT_MAX = new Telerik.WinControls.UI.RadLabel();
            this.txtCANT_MAX = new Telerik.WinControls.UI.RadTextBox();
            this.lblCANT_MIN = new Telerik.WinControls.UI.RadLabel();
            this.txtCANT_MIN = new Telerik.WinControls.UI.RadTextBox();
            this.btnVerProveedores = new System.Windows.Forms.Button();
            this.chkHABILITAR_VENTA = new System.Windows.Forms.CheckBox();
            this.lblPORC_DESCUENTO = new Telerik.WinControls.UI.RadLabel();
            this.txtPORC_DESCUENTO = new Telerik.WinControls.UI.RadTextBox();
            this.chkVENDER_SIN_EXISTENCIA = new System.Windows.Forms.CheckBox();
            this.label3 = new Telerik.WinControls.UI.RadLabel();
            this.txtLOCALIZACION = new Telerik.WinControls.UI.RadTextBox();
            this.label5 = new Telerik.WinControls.UI.RadLabel();
            this.txtCVE_PROVEEDOR = new Telerik.WinControls.UI.RadTextBox();
            this.txtPRECIO_VENTA2 = new Telerik.WinControls.UI.RadTextBox();
            this.label7 = new Telerik.WinControls.UI.RadLabel();
            this.txtPRECIO_VENTA3 = new Telerik.WinControls.UI.RadTextBox();
            this.label8 = new Telerik.WinControls.UI.RadLabel();
            this.btnSearchProvider = new System.Windows.Forms.Button();
            this.label6 = new Telerik.WinControls.UI.RadLabel();
            this.cboID_UNIDAD_MEDIDA = new System.Windows.Forms.ComboBox();
            this.btnAddMeasurementUnit = new System.Windows.Forms.Button();
            this.btnAddBrand = new System.Windows.Forms.Button();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.chkIVA = new System.Windows.Forms.CheckBox();
            this.btnIngredientes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clave de artículo:";
            // 
            // txtID_PRODUCTO
            // 
            this.txtID_PRODUCTO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtID_PRODUCTO.Location = new System.Drawing.Point(12, 25);
            this.txtID_PRODUCTO.Name = "txtID_PRODUCTO";
            this.txtID_PRODUCTO.Size = new System.Drawing.Size(203, 20);
            this.txtID_PRODUCTO.TabIndex = 1;
            this.txtID_PRODUCTO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtID_PRODUCTO_KeyPress);
            this.txtID_PRODUCTO.LostFocus += new System.EventHandler(this.txtID_PRODUCTO_LostFocus);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre del artículo:";
            // 
            // txtDESC_PRODUCTO
            // 
            this.txtDESC_PRODUCTO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDESC_PRODUCTO.Location = new System.Drawing.Point(12, 64);
            this.txtDESC_PRODUCTO.Name = "txtDESC_PRODUCTO";
            this.txtDESC_PRODUCTO.Size = new System.Drawing.Size(338, 20);
            this.txtDESC_PRODUCTO.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Exist:";
            // 
            // txtEXISTENCIA
            // 
            this.txtEXISTENCIA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEXISTENCIA.Location = new System.Drawing.Point(12, 108);
            this.txtEXISTENCIA.Name = "txtEXISTENCIA";
            this.txtEXISTENCIA.Size = new System.Drawing.Size(56, 20);
            this.txtEXISTENCIA.TabIndex = 6;
            this.txtEXISTENCIA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEXISTENCIA_KeyPress);
            // 
            // lblPRECIO_VENTA
            // 
            this.lblPRECIO_VENTA.AutoSize = true;
            this.lblPRECIO_VENTA.Location = new System.Drawing.Point(74, 92);
            this.lblPRECIO_VENTA.Name = "lblPRECIO_VENTA";
            this.lblPRECIO_VENTA.Size = new System.Drawing.Size(58, 13);
            this.lblPRECIO_VENTA.TabIndex = 8;
            this.lblPRECIO_VENTA.Text = "P. Público:";
            // 
            // txtPRECIO_VENTA
            // 
            this.txtPRECIO_VENTA.Location = new System.Drawing.Point(77, 108);
            this.txtPRECIO_VENTA.MaxLength = 15;
            this.txtPRECIO_VENTA.Name = "txtPRECIO_VENTA";
            this.txtPRECIO_VENTA.Size = new System.Drawing.Size(55, 20);
            this.txtPRECIO_VENTA.TabIndex = 7;
            this.txtPRECIO_VENTA.Text = "0";
            // 
            // txtIMPUESTO
            // 
            this.txtIMPUESTO.Location = new System.Drawing.Point(183, 147);
            this.txtIMPUESTO.Name = "txtIMPUESTO";
            this.txtIMPUESTO.Size = new System.Drawing.Size(56, 20);
            this.txtIMPUESTO.TabIndex = 13;
            this.txtIMPUESTO.Text = "0.16";
            this.txtIMPUESTO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIMPUESTO_KeyPress);
            // 
            // lblID_MARCA
            // 
            this.lblID_MARCA.AutoSize = true;
            this.lblID_MARCA.Location = new System.Drawing.Point(12, 215);
            this.lblID_MARCA.Name = "lblID_MARCA";
            this.lblID_MARCA.Size = new System.Drawing.Size(40, 13);
            this.lblID_MARCA.TabIndex = 12;
            this.lblID_MARCA.Text = "Marca:";
            // 
            // cboID_MARCA
            // 
            this.cboID_MARCA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboID_MARCA.FormattingEnabled = true;
            this.cboID_MARCA.Location = new System.Drawing.Point(15, 230);
            this.cboID_MARCA.Name = "cboID_MARCA";
            this.cboID_MARCA.Size = new System.Drawing.Size(297, 21);
            this.cboID_MARCA.TabIndex = 15;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Image = global::POS.Properties.Resources.accept;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.Location = new System.Drawing.Point(197, 386);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(72, 30);
            this.btnOK.TabIndex = 22;
            this.btnOK.Text = "Aceptar";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::POS.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(275, 386);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblID_GRUPO
            // 
            this.lblID_GRUPO.AutoSize = true;
            this.lblID_GRUPO.Location = new System.Drawing.Point(12, 256);
            this.lblID_GRUPO.Name = "lblID_GRUPO";
            this.lblID_GRUPO.Size = new System.Drawing.Size(36, 13);
            this.lblID_GRUPO.TabIndex = 20;
            this.lblID_GRUPO.Text = "Grupo";
            // 
            // cboID_GRUPO
            // 
            this.cboID_GRUPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboID_GRUPO.FormattingEnabled = true;
            this.cboID_GRUPO.Location = new System.Drawing.Point(15, 272);
            this.cboID_GRUPO.Name = "cboID_GRUPO";
            this.cboID_GRUPO.Size = new System.Drawing.Size(297, 21);
            this.cboID_GRUPO.TabIndex = 16;
            // 
            // lblPRECIO_COMPRA
            // 
            this.lblPRECIO_COMPRA.AutoSize = true;
            this.lblPRECIO_COMPRA.Location = new System.Drawing.Point(12, 131);
            this.lblPRECIO_COMPRA.Name = "lblPRECIO_COMPRA";
            this.lblPRECIO_COMPRA.Size = new System.Drawing.Size(61, 13);
            this.lblPRECIO_COMPRA.TabIndex = 23;
            this.lblPRECIO_COMPRA.Text = "P.  compra:";
            // 
            // txtPRECIO_COMPRA
            // 
            this.txtPRECIO_COMPRA.Location = new System.Drawing.Point(12, 147);
            this.txtPRECIO_COMPRA.Name = "txtPRECIO_COMPRA";
            this.txtPRECIO_COMPRA.Size = new System.Drawing.Size(65, 20);
            this.txtPRECIO_COMPRA.TabIndex = 10;
            this.txtPRECIO_COMPRA.Text = "0";
            this.txtPRECIO_COMPRA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPRECIO_COMPRA_KeyPress);
            // 
            // lblNOMBRES_CO
            // 
            this.lblNOMBRES_CO.AutoSize = true;
            this.lblNOMBRES_CO.Location = new System.Drawing.Point(11, 297);
            this.lblNOMBRES_CO.Name = "lblNOMBRES_CO";
            this.lblNOMBRES_CO.Size = new System.Drawing.Size(134, 13);
            this.lblNOMBRES_CO.TabIndex = 32;
            this.lblNOMBRES_CO.Text = "Nombres complementarios:";
            // 
            // txtNOMBRES_CO
            // 
            this.txtNOMBRES_CO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNOMBRES_CO.Location = new System.Drawing.Point(14, 313);
            this.txtNOMBRES_CO.Name = "txtNOMBRES_CO";
            this.txtNOMBRES_CO.Size = new System.Drawing.Size(339, 20);
            this.txtNOMBRES_CO.TabIndex = 17;
            // 
            // chkC_BARRAS
            // 
            this.chkC_BARRAS.AutoSize = true;
            this.chkC_BARRAS.Location = new System.Drawing.Point(227, 12);
            this.chkC_BARRAS.Name = "chkC_BARRAS";
            this.chkC_BARRAS.Size = new System.Drawing.Size(123, 17);
            this.chkC_BARRAS.TabIndex = 2;
            this.chkC_BARRAS.Text = "Sin código de barras";
            this.chkC_BARRAS.UseVisualStyleBackColor = true;
            // 
            // lblCANT_MAX
            // 
            this.lblCANT_MAX.AutoSize = true;
            this.lblCANT_MAX.Location = new System.Drawing.Point(83, 131);
            this.lblCANT_MAX.Name = "lblCANT_MAX";
            this.lblCANT_MAX.Size = new System.Drawing.Size(30, 13);
            this.lblCANT_MAX.TabIndex = 35;
            this.lblCANT_MAX.Text = "Max:";
            // 
            // txtCANT_MAX
            // 
            this.txtCANT_MAX.Location = new System.Drawing.Point(83, 147);
            this.txtCANT_MAX.Name = "txtCANT_MAX";
            this.txtCANT_MAX.Size = new System.Drawing.Size(40, 20);
            this.txtCANT_MAX.TabIndex = 11;
            this.txtCANT_MAX.Text = "0";
            this.txtCANT_MAX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCANT_MAX_KeyPress);
            // 
            // lblCANT_MIN
            // 
            this.lblCANT_MIN.AutoSize = true;
            this.lblCANT_MIN.Location = new System.Drawing.Point(127, 131);
            this.lblCANT_MIN.Name = "lblCANT_MIN";
            this.lblCANT_MIN.Size = new System.Drawing.Size(27, 13);
            this.lblCANT_MIN.TabIndex = 37;
            this.lblCANT_MIN.Text = "Min:";
            // 
            // txtCANT_MIN
            // 
            this.txtCANT_MIN.Location = new System.Drawing.Point(130, 147);
            this.txtCANT_MIN.Name = "txtCANT_MIN";
            this.txtCANT_MIN.Size = new System.Drawing.Size(47, 20);
            this.txtCANT_MIN.TabIndex = 12;
            this.txtCANT_MIN.Text = "0";
            this.txtCANT_MIN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCANT_MIN_KeyPress);
            // 
            // btnVerProveedores
            // 
            this.btnVerProveedores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerProveedores.Image = global::POS.Properties.Resources.openfolderHS;
            this.btnVerProveedores.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVerProveedores.Location = new System.Drawing.Point(11, 386);
            this.btnVerProveedores.Name = "btnVerProveedores";
            this.btnVerProveedores.Size = new System.Drawing.Size(131, 30);
            this.btnVerProveedores.TabIndex = 21;
            this.btnVerProveedores.Text = "Ver proveedores";
            this.btnVerProveedores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerProveedores.UseVisualStyleBackColor = true;
            this.btnVerProveedores.Visible = false;
            this.btnVerProveedores.Click += new System.EventHandler(this.btnVerProveedores_Click);
            // 
            // chkHABILITAR_VENTA
            // 
            this.chkHABILITAR_VENTA.AutoSize = true;
            this.chkHABILITAR_VENTA.ForeColor = System.Drawing.Color.Red;
            this.chkHABILITAR_VENTA.Location = new System.Drawing.Point(227, 27);
            this.chkHABILITAR_VENTA.Name = "chkHABILITAR_VENTA";
            this.chkHABILITAR_VENTA.Size = new System.Drawing.Size(68, 17);
            this.chkHABILITAR_VENTA.TabIndex = 3;
            this.chkHABILITAR_VENTA.Text = "Cancelar";
            this.chkHABILITAR_VENTA.UseVisualStyleBackColor = true;
            // 
            // lblPORC_DESCUENTO
            // 
            this.lblPORC_DESCUENTO.AutoSize = true;
            this.lblPORC_DESCUENTO.Location = new System.Drawing.Point(242, 131);
            this.lblPORC_DESCUENTO.Name = "lblPORC_DESCUENTO";
            this.lblPORC_DESCUENTO.Size = new System.Drawing.Size(46, 13);
            this.lblPORC_DESCUENTO.TabIndex = 39;
            this.lblPORC_DESCUENTO.Text = "% Desc:";
            // 
            // txtPORC_DESCUENTO
            // 
            this.txtPORC_DESCUENTO.Location = new System.Drawing.Point(245, 147);
            this.txtPORC_DESCUENTO.Name = "txtPORC_DESCUENTO";
            this.txtPORC_DESCUENTO.Size = new System.Drawing.Size(56, 20);
            this.txtPORC_DESCUENTO.TabIndex = 14;
            this.txtPORC_DESCUENTO.Text = "0";
            this.txtPORC_DESCUENTO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDESCUENTO_KeyPress);
            // 
            // chkVENDER_SIN_EXISTENCIA
            // 
            this.chkVENDER_SIN_EXISTENCIA.AutoSize = true;
            this.chkVENDER_SIN_EXISTENCIA.Location = new System.Drawing.Point(227, 43);
            this.chkVENDER_SIN_EXISTENCIA.Name = "chkVENDER_SIN_EXISTENCIA";
            this.chkVENDER_SIN_EXISTENCIA.Size = new System.Drawing.Size(126, 17);
            this.chkVENDER_SIN_EXISTENCIA.TabIndex = 4;
            this.chkVENDER_SIN_EXISTENCIA.Text = "Vender sin existencia";
            this.chkVENDER_SIN_EXISTENCIA.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 341);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Localización:";
            // 
            // txtLOCALIZACION
            // 
            this.txtLOCALIZACION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLOCALIZACION.Location = new System.Drawing.Point(15, 356);
            this.txtLOCALIZACION.Name = "txtLOCALIZACION";
            this.txtLOCALIZACION.Size = new System.Drawing.Size(100, 20);
            this.txtLOCALIZACION.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(119, 340);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "Clave Proveedor:";
            // 
            // txtCVE_PROVEEDOR
            // 
            this.txtCVE_PROVEEDOR.Location = new System.Drawing.Point(122, 356);
            this.txtCVE_PROVEEDOR.Name = "txtCVE_PROVEEDOR";
            this.txtCVE_PROVEEDOR.Size = new System.Drawing.Size(100, 20);
            this.txtCVE_PROVEEDOR.TabIndex = 19;
            // 
            // txtPRECIO_VENTA2
            // 
            this.txtPRECIO_VENTA2.Location = new System.Drawing.Point(138, 108);
            this.txtPRECIO_VENTA2.MaxLength = 15;
            this.txtPRECIO_VENTA2.Name = "txtPRECIO_VENTA2";
            this.txtPRECIO_VENTA2.Size = new System.Drawing.Size(55, 20);
            this.txtPRECIO_VENTA2.TabIndex = 8;
            this.txtPRECIO_VENTA2.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(135, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 48;
            this.label7.Text = "P. Interno:";
            // 
            // txtPRECIO_VENTA3
            // 
            this.txtPRECIO_VENTA3.Location = new System.Drawing.Point(197, 108);
            this.txtPRECIO_VENTA3.MaxLength = 15;
            this.txtPRECIO_VENTA3.Name = "txtPRECIO_VENTA3";
            this.txtPRECIO_VENTA3.Size = new System.Drawing.Size(61, 20);
            this.txtPRECIO_VENTA3.TabIndex = 9;
            this.txtPRECIO_VENTA3.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(194, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 50;
            this.label8.Text = "P. Mayoreo:";
            // 
            // btnSearchProvider
            // 
            this.btnSearchProvider.Image = global::POS.Properties.Resources.zoom;
            this.btnSearchProvider.Location = new System.Drawing.Point(228, 354);
            this.btnSearchProvider.Name = "btnSearchProvider";
            this.btnSearchProvider.Size = new System.Drawing.Size(37, 23);
            this.btnSearchProvider.TabIndex = 51;
            this.btnSearchProvider.UseVisualStyleBackColor = true;
            this.btnSearchProvider.Click += new System.EventHandler(this.btnSearchProvider_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 54;
            this.label6.Text = "Unidad de Medida:";
            // 
            // cboID_UNIDAD_MEDIDA
            // 
            this.cboID_UNIDAD_MEDIDA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboID_UNIDAD_MEDIDA.FormattingEnabled = true;
            this.cboID_UNIDAD_MEDIDA.Location = new System.Drawing.Point(14, 191);
            this.cboID_UNIDAD_MEDIDA.Name = "cboID_UNIDAD_MEDIDA";
            this.cboID_UNIDAD_MEDIDA.Size = new System.Drawing.Size(298, 21);
            this.cboID_UNIDAD_MEDIDA.TabIndex = 55;
            // 
            // btnAddMeasurementUnit
            // 
            this.btnAddMeasurementUnit.Image = global::POS.Properties.Resources.add;
            this.btnAddMeasurementUnit.Location = new System.Drawing.Point(319, 191);
            this.btnAddMeasurementUnit.Name = "btnAddMeasurementUnit";
            this.btnAddMeasurementUnit.Size = new System.Drawing.Size(35, 23);
            this.btnAddMeasurementUnit.TabIndex = 57;
            this.btnAddMeasurementUnit.UseVisualStyleBackColor = true;
            this.btnAddMeasurementUnit.Click += new System.EventHandler(this.btnAddMeasurementUnit_Click);
            // 
            // btnAddBrand
            // 
            this.btnAddBrand.Image = global::POS.Properties.Resources.add;
            this.btnAddBrand.Location = new System.Drawing.Point(319, 230);
            this.btnAddBrand.Name = "btnAddBrand";
            this.btnAddBrand.Size = new System.Drawing.Size(35, 23);
            this.btnAddBrand.TabIndex = 58;
            this.btnAddBrand.UseVisualStyleBackColor = true;
            this.btnAddBrand.Click += new System.EventHandler(this.btnAddBrand_Click);
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Image = global::POS.Properties.Resources.add;
            this.btnAddGroup.Location = new System.Drawing.Point(319, 272);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(35, 23);
            this.btnAddGroup.TabIndex = 59;
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // chkIVA
            // 
            this.chkIVA.AutoSize = true;
            this.chkIVA.Location = new System.Drawing.Point(183, 131);
            this.chkIVA.Name = "chkIVA";
            this.chkIVA.Size = new System.Drawing.Size(43, 17);
            this.chkIVA.TabIndex = 10;
            this.chkIVA.Text = "IVA";
            this.chkIVA.UseVisualStyleBackColor = true;
            this.chkIVA.CheckedChanged += new System.EventHandler(this.chkIVA_CheckedChanged);
            // 
            // btnIngredientes
            // 
            this.btnIngredientes.Image = global::POS.Properties.Resources.cake_plus;
            this.btnIngredientes.Location = new System.Drawing.Point(319, 145);
            this.btnIngredientes.Name = "btnIngredientes";
            this.btnIngredientes.Size = new System.Drawing.Size(35, 23);
            this.btnIngredientes.TabIndex = 60;
            this.btnIngredientes.UseVisualStyleBackColor = true;
            this.btnIngredientes.Click += new System.EventHandler(this.btnIngredientes_Click);
            // 
            // frmProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(365, 428);
            this.Controls.Add(this.btnIngredientes);
            this.Controls.Add(this.btnAddGroup);
            this.Controls.Add(this.btnAddBrand);
            this.Controls.Add(this.btnAddMeasurementUnit);
            this.Controls.Add(this.cboID_UNIDAD_MEDIDA);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSearchProvider);
            this.Controls.Add(this.txtPRECIO_VENTA3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPRECIO_VENTA2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCVE_PROVEEDOR);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLOCALIZACION);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkVENDER_SIN_EXISTENCIA);
            this.Controls.Add(this.txtPORC_DESCUENTO);
            this.Controls.Add(this.lblPORC_DESCUENTO);
            this.Controls.Add(this.chkHABILITAR_VENTA);
            this.Controls.Add(this.btnVerProveedores);
            this.Controls.Add(this.txtCANT_MIN);
            this.Controls.Add(this.lblCANT_MIN);
            this.Controls.Add(this.txtCANT_MAX);
            this.Controls.Add(this.lblCANT_MAX);
            this.Controls.Add(this.chkC_BARRAS);
            this.Controls.Add(this.txtNOMBRES_CO);
            this.Controls.Add(this.lblNOMBRES_CO);
            this.Controls.Add(this.txtPRECIO_COMPRA);
            this.Controls.Add(this.lblPRECIO_COMPRA);
            this.Controls.Add(this.cboID_GRUPO);
            this.Controls.Add(this.lblID_GRUPO);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cboID_MARCA);
            this.Controls.Add(this.lblID_MARCA);
            this.Controls.Add(this.txtIMPUESTO);
            this.Controls.Add(this.txtPRECIO_VENTA);
            this.Controls.Add(this.lblPRECIO_VENTA);
            this.Controls.Add(this.txtEXISTENCIA);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDESC_PRODUCTO);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtID_PRODUCTO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkIVA);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmProducto";
            this.ShowInTaskbar = false;
            this.Text = "Artículo";
            this.Load += new System.EventHandler(this.frmProducto_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmProducto_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmProducto_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void txtDESCUENTO_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
           
        }

       

      

        #endregion

        private Telerik.WinControls.UI.RadLabel label1;
        private Telerik.WinControls.UI.RadTextBox txtID_PRODUCTO;
        private Telerik.WinControls.UI.RadLabel label2;
        private Telerik.WinControls.UI.RadTextBox txtDESC_PRODUCTO;
        private Telerik.WinControls.UI.RadLabel label4;
        private Telerik.WinControls.UI.RadTextBox txtEXISTENCIA;
        private Telerik.WinControls.UI.RadLabel lblPRECIO_VENTA;
        private Telerik.WinControls.UI.RadTextBox txtPRECIO_VENTA;
        private Telerik.WinControls.UI.RadTextBox txtIMPUESTO;
        private Telerik.WinControls.UI.RadLabel lblID_MARCA;
        private System.Windows.Forms.ComboBox cboID_MARCA;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private Telerik.WinControls.UI.RadLabel lblID_GRUPO;
        private System.Windows.Forms.ComboBox cboID_GRUPO;
        private Telerik.WinControls.UI.RadLabel lblPRECIO_COMPRA;
        private Telerik.WinControls.UI.RadTextBox txtPRECIO_COMPRA;
        private Telerik.WinControls.UI.RadLabel lblNOMBRES_CO;
        private Telerik.WinControls.UI.RadTextBox txtNOMBRES_CO;
        private System.Windows.Forms.CheckBox chkC_BARRAS;
        private Telerik.WinControls.UI.RadLabel lblCANT_MAX;
        private Telerik.WinControls.UI.RadTextBox txtCANT_MAX;
        private Telerik.WinControls.UI.RadLabel lblCANT_MIN;
        private Telerik.WinControls.UI.RadTextBox txtCANT_MIN;
        private System.Windows.Forms.Button btnVerProveedores;
        private System.Windows.Forms.CheckBox chkHABILITAR_VENTA;
        private Telerik.WinControls.UI.RadLabel lblPORC_DESCUENTO;
        private Telerik.WinControls.UI.RadTextBox txtPORC_DESCUENTO;
        private System.Windows.Forms.CheckBox chkVENDER_SIN_EXISTENCIA;
        private Telerik.WinControls.UI.RadLabel label3;
        private Telerik.WinControls.UI.RadTextBox txtLOCALIZACION;
        private Telerik.WinControls.UI.RadLabel label5;
        private Telerik.WinControls.UI.RadTextBox txtCVE_PROVEEDOR;
        private Telerik.WinControls.UI.RadTextBox txtPRECIO_VENTA2;
        private Telerik.WinControls.UI.RadLabel label7;
        private Telerik.WinControls.UI.RadTextBox txtPRECIO_VENTA3;
        private Telerik.WinControls.UI.RadLabel label8;
        private System.Windows.Forms.Button btnSearchProvider;
        private Telerik.WinControls.UI.RadLabel label6;
        private System.Windows.Forms.ComboBox cboID_UNIDAD_MEDIDA;
        private System.Windows.Forms.Button btnAddMeasurementUnit;
        private System.Windows.Forms.Button btnAddBrand;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.CheckBox chkIVA;
        private System.Windows.Forms.Button btnIngredientes;
    }
}