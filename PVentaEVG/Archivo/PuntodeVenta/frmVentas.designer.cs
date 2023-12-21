using POSDLL; using POSDLL.Windows.Forms; using POSDLL.Security; using POSDLL.Reporting; using POSDLL.Ticket;
namespace POSApp.Forms
{
    partial class frmVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVentas));
            this.lvVenta = new System.Windows.Forms.ListView();
            this.c_mnuVentas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.c_mnuEditar = new System.Windows.Forms.ToolStripMenuItem();
            this.lblID_PRODUCTO = new Telerik.WinControls.UI.RadLabel();
            this.txtID_PRODUCTO = new Telerik.WinControls.UI.RadTextBox();
            this.lblCANTIDAD = new Telerik.WinControls.UI.RadLabel();
            this.txtCANTIDAD = new Telerik.WinControls.UI.RadTextBox();
            this.lblGRAND_TOTAL = new Telerik.WinControls.UI.RadLabel();
            this.lblMensaje = new Telerik.WinControls.UI.RadLabel();
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.txtID_CLIENTE = new Telerik.WinControls.UI.RadTextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnRealizarVenta = new System.Windows.Forms.Button();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTipoCambio = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.cboMoneda = new Telerik.WinControls.UI.RadDropDownList();
            this.lblCredito = new Telerik.WinControls.UI.RadLabel();
            this.cboTIPO_CLIENTE = new System.Windows.Forms.ComboBox();
            this.label11 = new Telerik.WinControls.UI.RadLabel();
            this.txtLOCALIDAD = new Telerik.WinControls.UI.RadTextBox();
            this.txtMUNICIPIO = new Telerik.WinControls.UI.RadTextBox();
            this.txtESTADO = new Telerik.WinControls.UI.RadTextBox();
            this.label9 = new Telerik.WinControls.UI.RadLabel();
            this.label8 = new Telerik.WinControls.UI.RadLabel();
            this.label7 = new Telerik.WinControls.UI.RadLabel();
            this.txtEMail = new Telerik.WinControls.UI.RadTextBox();
            this.txtMail = new Telerik.WinControls.UI.RadLabel();
            this.txtTELEFONO = new Telerik.WinControls.UI.RadTextBox();
            this.label6 = new Telerik.WinControls.UI.RadLabel();
            this.txtCP = new Telerik.WinControls.UI.RadTextBox();
            this.label5 = new Telerik.WinControls.UI.RadLabel();
            this.txtCURP = new Telerik.WinControls.UI.RadTextBox();
            this.label10 = new Telerik.WinControls.UI.RadLabel();
            this.txtDIRECCION = new Telerik.WinControls.UI.RadTextBox();
            this.label4 = new Telerik.WinControls.UI.RadLabel();
            this.txtNOMBRE = new Telerik.WinControls.UI.RadTextBox();
            this.label3 = new Telerik.WinControls.UI.RadLabel();
            this.txtRFC = new Telerik.WinControls.UI.RadTextBox();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.chkEditarCliente = new System.Windows.Forms.CheckBox();
            this.btnAplicarDescuento = new System.Windows.Forms.Button();
            this.lblCBI = new Telerik.WinControls.UI.RadLabel();
            this.txtCBI = new Telerik.WinControls.UI.RadTextBox();
            this.lblInfo = new Telerik.WinControls.UI.RadLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnVentaEnEspera = new System.Windows.Forms.Button();
            this.btnReimprimirTicket = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblSubTotal_moneda = new Telerik.WinControls.UI.RadLabel();
            this.lblIVA = new Telerik.WinControls.UI.RadLabel();
            this.lblDesc = new Telerik.WinControls.UI.RadLabel();
            this.c_mnuVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblID_PRODUCTO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID_PRODUCTO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCANTIDAD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCANTIDAD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGRAND_TOTAL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMensaje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID_CLIENTE)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCambio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCredito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLOCALIDAD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMUNICIPIO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtESTADO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEMail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTELEFONO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCURP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDIRECCION)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNOMBRE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRFC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCBI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCBI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfo)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSubTotal_moneda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIVA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lvVenta
            // 
            this.lvVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvVenta.ContextMenuStrip = this.c_mnuVentas;
            this.lvVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lvVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lvVenta.FullRowSelect = true;
            this.lvVenta.GridLines = true;
            this.lvVenta.HideSelection = false;
            this.lvVenta.Location = new System.Drawing.Point(12, 205);
            this.lvVenta.Name = "lvVenta";
            this.lvVenta.Size = new System.Drawing.Size(1060, 241);
            this.lvVenta.TabIndex = 14;
            this.lvVenta.UseCompatibleStateImageBehavior = false;
            this.lvVenta.DoubleClick += new System.EventHandler(this.lvVenta_DblClick);
            // 
            // c_mnuVentas
            // 
            this.c_mnuVentas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_mnuEditar});
            this.c_mnuVentas.Name = "c_mnuVentas";
            this.c_mnuVentas.Size = new System.Drawing.Size(230, 26);
            // 
            // c_mnuEditar
            // 
            this.c_mnuEditar.Image = ((System.Drawing.Image)(resources.GetObject("c_mnuEditar.Image")));
            this.c_mnuEditar.Name = "c_mnuEditar";
            this.c_mnuEditar.Size = new System.Drawing.Size(229, 22);
            this.c_mnuEditar.Text = "Editar elemento seleccionado";
            this.c_mnuEditar.Click += new System.EventHandler(this.c_mnuEditar_Click);
            // 
            // lblID_PRODUCTO
            // 
            this.lblID_PRODUCTO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblID_PRODUCTO.BackColor = System.Drawing.Color.Transparent;
            this.lblID_PRODUCTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblID_PRODUCTO.Location = new System.Drawing.Point(11, 468);
            this.lblID_PRODUCTO.Name = "lblID_PRODUCTO";
            this.lblID_PRODUCTO.Size = new System.Drawing.Size(112, 22);
            this.lblID_PRODUCTO.TabIndex = 1;
            this.lblID_PRODUCTO.Text = "Clave artículo:";
            // 
            // txtID_PRODUCTO
            // 
            this.txtID_PRODUCTO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtID_PRODUCTO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtID_PRODUCTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtID_PRODUCTO.Location = new System.Drawing.Point(11, 497);
            this.txtID_PRODUCTO.Name = "txtID_PRODUCTO";
            this.txtID_PRODUCTO.Size = new System.Drawing.Size(105, 24);
            this.txtID_PRODUCTO.TabIndex = 15;
            this.txtID_PRODUCTO.TabStop = false;
            this.txtID_PRODUCTO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtID_PRODUCTO_KeyDown);
            this.txtID_PRODUCTO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtID_PRODUCTO_KeyPress);
            // 
            // lblCANTIDAD
            // 
            this.lblCANTIDAD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCANTIDAD.BackColor = System.Drawing.Color.Transparent;
            this.lblCANTIDAD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblCANTIDAD.Location = new System.Drawing.Point(145, 468);
            this.lblCANTIDAD.Name = "lblCANTIDAD";
            this.lblCANTIDAD.Size = new System.Drawing.Size(78, 22);
            this.lblCANTIDAD.TabIndex = 3;
            this.lblCANTIDAD.Text = "Cantidad:";
            this.lblCANTIDAD.Click += new System.EventHandler(this.lblCANTIDAD_Click);
            // 
            // txtCANTIDAD
            // 
            this.txtCANTIDAD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCANTIDAD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtCANTIDAD.Location = new System.Drawing.Point(122, 497);
            this.txtCANTIDAD.Name = "txtCANTIDAD";
            this.txtCANTIDAD.Size = new System.Drawing.Size(100, 24);
            this.txtCANTIDAD.TabIndex = 16;
            this.txtCANTIDAD.TabStop = false;
            this.txtCANTIDAD.Text = "1";
            this.txtCANTIDAD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCANTIDAD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCANTIDAD_KeyDown);
            this.txtCANTIDAD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCANTIDAD_KeyPress);
            // 
            // lblGRAND_TOTAL
            // 
            this.lblGRAND_TOTAL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGRAND_TOTAL.BackColor = System.Drawing.Color.Transparent;
            this.lblGRAND_TOTAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGRAND_TOTAL.Location = new System.Drawing.Point(911, 593);
            this.lblGRAND_TOTAL.Name = "lblGRAND_TOTAL";
            this.lblGRAND_TOTAL.Size = new System.Drawing.Size(85, 36);
            this.lblGRAND_TOTAL.TabIndex = 5;
            this.lblGRAND_TOTAL.Text = "Total:";
            this.lblGRAND_TOTAL.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMensaje
            // 
            this.lblMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMensaje.BackColor = System.Drawing.Color.Transparent;
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblMensaje.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Location = new System.Drawing.Point(362, 456);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(55, 16);
            this.lblMensaje.TabIndex = 7;
            this.lblMensaje.Text = "Mensajes";
            this.lblMensaje.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(5, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Clave del cliente:";
            // 
            // txtID_CLIENTE
            // 
            this.txtID_CLIENTE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtID_CLIENTE.Location = new System.Drawing.Point(6, 37);
            this.txtID_CLIENTE.Name = "txtID_CLIENTE";
            this.txtID_CLIENTE.Size = new System.Drawing.Size(100, 18);
            this.txtID_CLIENTE.TabIndex = 1;
            this.txtID_CLIENTE.TabStop = false;
            this.txtID_CLIENTE.Text = "1";
            this.txtID_CLIENTE.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtID_CLIENTE_KeyDown);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Image = global::POS.Properties.Resources.cart_delete;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(115, 44);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 35);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Image = global::POS.Properties.Resources.zoom;
            this.btnBuscarCliente.Location = new System.Drawing.Point(112, 32);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(37, 25);
            this.btnBuscarCliente.TabIndex = 2;
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnModificar.Image = global::POS.Properties.Resources.pencil;
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificar.Location = new System.Drawing.Point(10, 44);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 35);
            this.btnModificar.TabIndex = 20;
            this.btnModificar.Text = "&Modificar";
            this.btnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnCerrar.Image = global::POS.Properties.Resources.close;
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Location = new System.Drawing.Point(391, 44);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(91, 35);
            this.btnCerrar.TabIndex = 24;
            this.btnCerrar.Text = "&Cerrar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnRealizarVenta
            // 
            this.btnRealizarVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRealizarVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnRealizarVenta.Image = global::POS.Properties.Resources.money;
            this.btnRealizarVenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRealizarVenta.Location = new System.Drawing.Point(391, 6);
            this.btnRealizarVenta.Name = "btnRealizarVenta";
            this.btnRealizarVenta.Size = new System.Drawing.Size(91, 34);
            this.btnRealizarVenta.TabIndex = 23;
            this.btnRealizarVenta.Text = "Cobrar [F5]  ";
            this.btnRealizarVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRealizarVenta.Click += new System.EventHandler(this.btnRealizarVenta_Click);
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBuscarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnBuscarProducto.Image = global::POS.Properties.Resources.SearchFolderHS;
            this.btnBuscarProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarProducto.Location = new System.Drawing.Point(10, 6);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(90, 34);
            this.btnBuscarProducto.TabIndex = 19;
            this.btnBuscarProducto.Text = "&Buscar [F2]";
            this.btnBuscarProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarProducto.Click += new System.EventHandler(this.btnBuscarProducto_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtTipoCambio);
            this.groupBox1.Controls.Add(this.radLabel2);
            this.groupBox1.Controls.Add(this.radLabel1);
            this.groupBox1.Controls.Add(this.cboMoneda);
            this.groupBox1.Controls.Add(this.lblCredito);
            this.groupBox1.Controls.Add(this.cboTIPO_CLIENTE);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtLOCALIDAD);
            this.groupBox1.Controls.Add(this.txtMUNICIPIO);
            this.groupBox1.Controls.Add(this.txtESTADO);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtEMail);
            this.groupBox1.Controls.Add(this.txtMail);
            this.groupBox1.Controls.Add(this.txtTELEFONO);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCP);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCURP);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtDIRECCION);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNOMBRE);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtRFC);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtID_CLIENTE);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnBuscarCliente);
            this.groupBox1.Controls.Add(this.chkEditarCliente);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1061, 187);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
            // 
            // txtTipoCambio
            // 
            this.txtTipoCambio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTipoCambio.Location = new System.Drawing.Point(741, 87);
            this.txtTipoCambio.Name = "txtTipoCambio";
            this.txtTipoCambio.ReadOnly = true;
            this.txtTipoCambio.Size = new System.Drawing.Size(83, 20);
            this.txtTipoCambio.TabIndex = 6;
            this.txtTipoCambio.TabStop = false;
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(738, 63);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(86, 18);
            this.radLabel2.TabIndex = 36;
            this.radLabel2.Text = "Tipo de cambio:";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(738, 19);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(50, 18);
            this.radLabel1.TabIndex = 52;
            this.radLabel1.Text = "Moneda:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboMoneda.Location = new System.Drawing.Point(738, 37);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(125, 20);
            this.cboMoneda.TabIndex = 51;
            this.cboMoneda.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cboMoneda_SelectedIndexChanged);
            // 
            // lblCredito
            // 
            this.lblCredito.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblCredito.Location = new System.Drawing.Point(266, 161);
            this.lblCredito.Name = "lblCredito";
            this.lblCredito.Size = new System.Drawing.Size(43, 18);
            this.lblCredito.TabIndex = 49;
            this.lblCredito.Text = "Credito";
            this.lblCredito.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboTIPO_CLIENTE
            // 
            this.cboTIPO_CLIENTE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTIPO_CLIENTE.FormattingEnabled = true;
            this.cboTIPO_CLIENTE.Items.AddRange(new object[] {
            "PP",
            "PT",
            "PM"});
            this.cboTIPO_CLIENTE.Location = new System.Drawing.Point(314, 80);
            this.cboTIPO_CLIENTE.Name = "cboTIPO_CLIENTE";
            this.cboTIPO_CLIENTE.Size = new System.Drawing.Size(63, 21);
            this.cboTIPO_CLIENTE.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(311, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 18);
            this.label11.TabIndex = 48;
            this.label11.Text = "Tipo Cte:";
            // 
            // txtLOCALIDAD
            // 
            this.txtLOCALIDAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLOCALIDAD.Location = new System.Drawing.Point(6, 161);
            this.txtLOCALIDAD.Name = "txtLOCALIDAD";
            this.txtLOCALIDAD.Size = new System.Drawing.Size(253, 20);
            this.txtLOCALIDAD.TabIndex = 13;
            this.txtLOCALIDAD.TabStop = false;
            // 
            // txtMUNICIPIO
            // 
            this.txtMUNICIPIO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMUNICIPIO.Location = new System.Drawing.Point(485, 118);
            this.txtMUNICIPIO.Name = "txtMUNICIPIO";
            this.txtMUNICIPIO.Size = new System.Drawing.Size(181, 20);
            this.txtMUNICIPIO.TabIndex = 12;
            this.txtMUNICIPIO.TabStop = false;
            // 
            // txtESTADO
            // 
            this.txtESTADO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtESTADO.Location = new System.Drawing.Point(268, 120);
            this.txtESTADO.Name = "txtESTADO";
            this.txtESTADO.Size = new System.Drawing.Size(211, 20);
            this.txtESTADO.TabIndex = 11;
            this.txtESTADO.TabStop = false;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(3, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 18);
            this.label9.TabIndex = 47;
            this.label9.Text = "Localidad:";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(484, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 18);
            this.label8.TabIndex = 46;
            this.label8.Text = "Municipio:";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(265, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 18);
            this.label7.TabIndex = 45;
            this.label7.Text = "Estado:";
            // 
            // txtEMail
            // 
            this.txtEMail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEMail.Location = new System.Drawing.Point(165, 119);
            this.txtEMail.Name = "txtEMail";
            this.txtEMail.Size = new System.Drawing.Size(94, 20);
            this.txtEMail.TabIndex = 10;
            this.txtEMail.TabStop = false;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(162, 103);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(38, 18);
            this.txtMail.TabIndex = 44;
            this.txtMail.Text = "E mail:";
            // 
            // txtTELEFONO
            // 
            this.txtTELEFONO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTELEFONO.Location = new System.Drawing.Point(63, 119);
            this.txtTELEFONO.Name = "txtTELEFONO";
            this.txtTELEFONO.Size = new System.Drawing.Size(100, 20);
            this.txtTELEFONO.TabIndex = 9;
            this.txtTELEFONO.TabStop = false;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(60, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 18);
            this.label6.TabIndex = 43;
            this.label6.Text = "Teléfono:";
            // 
            // txtCP
            // 
            this.txtCP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCP.Location = new System.Drawing.Point(6, 119);
            this.txtCP.Name = "txtCP";
            this.txtCP.Size = new System.Drawing.Size(51, 20);
            this.txtCP.TabIndex = 8;
            this.txtCP.TabStop = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(5, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 18);
            this.label5.TabIndex = 41;
            this.label5.Text = "CP:";
            // 
            // txtCURP
            // 
            this.txtCURP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCURP.Location = new System.Drawing.Point(112, 80);
            this.txtCURP.Name = "txtCURP";
            this.txtCURP.Size = new System.Drawing.Size(192, 20);
            this.txtCURP.TabIndex = 5;
            this.txtCURP.TabStop = false;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(109, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 18);
            this.label10.TabIndex = 36;
            this.label10.Text = "CURP:";
            // 
            // txtDIRECCION
            // 
            this.txtDIRECCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDIRECCION.Location = new System.Drawing.Point(383, 80);
            this.txtDIRECCION.Name = "txtDIRECCION";
            this.txtDIRECCION.Size = new System.Drawing.Size(283, 20);
            this.txtDIRECCION.TabIndex = 7;
            this.txtDIRECCION.TabStop = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(380, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 18);
            this.label4.TabIndex = 35;
            this.label4.Text = "Dirección:";
            // 
            // txtNOMBRE
            // 
            this.txtNOMBRE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNOMBRE.Location = new System.Drawing.Point(155, 37);
            this.txtNOMBRE.Name = "txtNOMBRE";
            this.txtNOMBRE.Size = new System.Drawing.Size(511, 20);
            this.txtNOMBRE.TabIndex = 3;
            this.txtNOMBRE.TabStop = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(152, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 18);
            this.label3.TabIndex = 33;
            this.label3.Text = "Nombre:";
            // 
            // txtRFC
            // 
            this.txtRFC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRFC.Location = new System.Drawing.Point(6, 80);
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.Size = new System.Drawing.Size(100, 20);
            this.txtRFC.TabIndex = 4;
            this.txtRFC.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 18);
            this.label2.TabIndex = 30;
            this.label2.Text = "RFC:";
            // 
            // chkEditarCliente
            // 
            this.chkEditarCliente.AutoSize = true;
            this.chkEditarCliente.Location = new System.Drawing.Point(206, 21);
            this.chkEditarCliente.Name = "chkEditarCliente";
            this.chkEditarCliente.Size = new System.Drawing.Size(89, 17);
            this.chkEditarCliente.TabIndex = 50;
            this.chkEditarCliente.Text = "Editar Datos";
            this.chkEditarCliente.UseVisualStyleBackColor = true;
            this.chkEditarCliente.CheckedChanged += new System.EventHandler(this.chkEditarCliente_CheckedChanged);
            // 
            // btnAplicarDescuento
            // 
            this.btnAplicarDescuento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAplicarDescuento.Image = global::POS.Properties.Resources.money_delete;
            this.btnAplicarDescuento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAplicarDescuento.Location = new System.Drawing.Point(115, 6);
            this.btnAplicarDescuento.Name = "btnAplicarDescuento";
            this.btnAplicarDescuento.Size = new System.Drawing.Size(92, 34);
            this.btnAplicarDescuento.TabIndex = 30;
            this.btnAplicarDescuento.Text = "Descuento";
            this.btnAplicarDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAplicarDescuento.UseVisualStyleBackColor = true;
            this.btnAplicarDescuento.Click += new System.EventHandler(this.btnAplicarDescuento_Click);
            // 
            // lblCBI
            // 
            this.lblCBI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCBI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCBI.ForeColor = System.Drawing.Color.Green;
            this.lblCBI.Location = new System.Drawing.Point(266, 499);
            this.lblCBI.Name = "lblCBI";
            this.lblCBI.Size = new System.Drawing.Size(168, 22);
            this.lblCBI.TabIndex = 31;
            this.lblCBI.Text = "[F6] para habilitar CBI";
            // 
            // txtCBI
            // 
            this.txtCBI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCBI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCBI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCBI.Location = new System.Drawing.Point(12, 497);
            this.txtCBI.MaxLength = 13;
            this.txtCBI.Name = "txtCBI";
            this.txtCBI.Size = new System.Drawing.Size(211, 24);
            this.txtCBI.TabIndex = 32;
            this.txtCBI.TabStop = false;
            this.txtCBI.Visible = false;
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInfo.Location = new System.Drawing.Point(14, 452);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(52, 18);
            this.lblInfo.TabIndex = 33;
            this.lblInfo.Text = "Registros";
            this.lblInfo.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 527);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(515, 111);
            this.tabControl1.TabIndex = 34;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnVentaEnEspera);
            this.tabPage1.Controls.Add(this.btnReimprimirTicket);
            this.tabPage1.Controls.Add(this.btnBuscarProducto);
            this.tabPage1.Controls.Add(this.btnModificar);
            this.tabPage1.Controls.Add(this.btnAplicarDescuento);
            this.tabPage1.Controls.Add(this.btnCancel);
            this.tabPage1.Controls.Add(this.btnRealizarVenta);
            this.tabPage1.Controls.Add(this.btnCerrar);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(507, 85);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Opciones Básicas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnVentaEnEspera
            // 
            this.btnVentaEnEspera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVentaEnEspera.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnVentaEnEspera.Image = global::POS.Properties.Resources.clock;
            this.btnVentaEnEspera.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentaEnEspera.Location = new System.Drawing.Point(221, 44);
            this.btnVentaEnEspera.Name = "btnVentaEnEspera";
            this.btnVentaEnEspera.Size = new System.Drawing.Size(158, 35);
            this.btnVentaEnEspera.TabIndex = 32;
            this.btnVentaEnEspera.Text = "Venta en Espera [F7]";
            this.btnVentaEnEspera.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVentaEnEspera.Click += new System.EventHandler(this.btnVentaEnEspera_Click);
            // 
            // btnReimprimirTicket
            // 
            this.btnReimprimirTicket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReimprimirTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnReimprimirTicket.Image = global::POS.Properties.Resources.printer;
            this.btnReimprimirTicket.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReimprimirTicket.Location = new System.Drawing.Point(221, 6);
            this.btnReimprimirTicket.Name = "btnReimprimirTicket";
            this.btnReimprimirTicket.Size = new System.Drawing.Size(158, 34);
            this.btnReimprimirTicket.TabIndex = 31;
            this.btnReimprimirTicket.Text = "Reimpresión de Ticket";
            this.btnReimprimirTicket.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReimprimirTicket.Click += new System.EventHandler(this.btnReimprimirTicket_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1053, 74);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Opciones Adicionales";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblSubTotal_moneda
            // 
            this.lblSubTotal_moneda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubTotal_moneda.BackColor = System.Drawing.Color.Transparent;
            this.lblSubTotal_moneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal_moneda.Location = new System.Drawing.Point(860, 467);
            this.lblSubTotal_moneda.Name = "lblSubTotal_moneda";
            this.lblSubTotal_moneda.Size = new System.Drawing.Size(136, 36);
            this.lblSubTotal_moneda.TabIndex = 35;
            this.lblSubTotal_moneda.Text = "SubTotal:";
            this.lblSubTotal_moneda.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIVA
            // 
            this.lblIVA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIVA.BackColor = System.Drawing.Color.Transparent;
            this.lblIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIVA.Location = new System.Drawing.Point(930, 551);
            this.lblIVA.Name = "lblIVA";
            this.lblIVA.Size = new System.Drawing.Size(66, 36);
            this.lblIVA.TabIndex = 6;
            this.lblIVA.Text = "IVA:";
            this.lblIVA.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDesc
            // 
            this.lblDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDesc.BackColor = System.Drawing.Color.Transparent;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Location = new System.Drawing.Point(911, 509);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(85, 36);
            this.lblDesc.TabIndex = 36;
            this.lblDesc.Text = "Desc:";
            this.lblDesc.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 639);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblIVA);
            this.Controls.Add(this.lblSubTotal_moneda);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtCBI);
            this.Controls.Add(this.lblCBI);
            this.Controls.Add(this.lvVenta);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.lblGRAND_TOTAL);
            this.Controls.Add(this.txtCANTIDAD);
            this.Controls.Add(this.lblCANTIDAD);
            this.Controls.Add(this.txtID_PRODUCTO);
            this.Controls.Add(this.lblID_PRODUCTO);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(800, 545);
            this.Name = "frmVentas";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowInTaskbar = false;
            this.Text = "Ventas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVentas_FormClosing);
            this.Load += new System.EventHandler(this.frmVentas_Load);
            this.Resize += new System.EventHandler(this.frmVentas_Resize);
            this.c_mnuVentas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblID_PRODUCTO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID_PRODUCTO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCANTIDAD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCANTIDAD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGRAND_TOTAL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMensaje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID_CLIENTE)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCambio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCredito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLOCALIDAD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMUNICIPIO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtESTADO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEMail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTELEFONO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCURP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDIRECCION)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNOMBRE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRFC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCBI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCBI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfo)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSubTotal_moneda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIVA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

       

       

        #endregion

        private System.Windows.Forms.ListView lvVenta;
        private Telerik.WinControls.UI.RadLabel lblID_PRODUCTO;
        private Telerik.WinControls.UI.RadTextBox txtID_PRODUCTO;
        private Telerik.WinControls.UI.RadLabel lblCANTIDAD;
        private Telerik.WinControls.UI.RadTextBox txtCANTIDAD;
        private Telerik.WinControls.UI.RadLabel lblGRAND_TOTAL;
        private Telerik.WinControls.UI.RadLabel lblMensaje;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.Button btnRealizarVenta;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnModificar;
        private Telerik.WinControls.UI.RadLabel label1;
        private Telerik.WinControls.UI.RadTextBox txtID_CLIENTE;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ContextMenuStrip c_mnuVentas;
        private System.Windows.Forms.ToolStripMenuItem c_mnuEditar;
        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadTextBox txtCURP;
        private Telerik.WinControls.UI.RadLabel label10;
        private Telerik.WinControls.UI.RadTextBox txtDIRECCION;
        private Telerik.WinControls.UI.RadLabel label4;
        private Telerik.WinControls.UI.RadTextBox txtNOMBRE;
        private Telerik.WinControls.UI.RadLabel label3;
        private Telerik.WinControls.UI.RadTextBox txtRFC;
        private Telerik.WinControls.UI.RadLabel label2;
        private Telerik.WinControls.UI.RadTextBox txtEMail;
        private Telerik.WinControls.UI.RadLabel txtMail;
        private Telerik.WinControls.UI.RadTextBox txtTELEFONO;
        private Telerik.WinControls.UI.RadLabel label6;
        private Telerik.WinControls.UI.RadTextBox txtCP;
        private Telerik.WinControls.UI.RadLabel label5;
        private Telerik.WinControls.UI.RadTextBox txtLOCALIDAD;
        private Telerik.WinControls.UI.RadTextBox txtMUNICIPIO;
        private Telerik.WinControls.UI.RadTextBox txtESTADO;
        private Telerik.WinControls.UI.RadLabel label9;
        private Telerik.WinControls.UI.RadLabel label8;
        private Telerik.WinControls.UI.RadLabel label7;
        private System.Windows.Forms.ComboBox cboTIPO_CLIENTE;
        private Telerik.WinControls.UI.RadLabel label11;
        private System.Windows.Forms.Button btnAplicarDescuento;
        private Telerik.WinControls.UI.RadLabel lblCredito;
        private Telerik.WinControls.UI.RadLabel lblCBI;
        private Telerik.WinControls.UI.RadTextBox txtCBI;
        private Telerik.WinControls.UI.RadLabel lblInfo;
        private System.Windows.Forms.CheckBox chkEditarCliente;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnReimprimirTicket;
        private System.Windows.Forms.Button btnVentaEnEspera;
        private Telerik.WinControls.UI.RadDropDownList cboMoneda;
        private Telerik.WinControls.UI.RadTextBox txtTipoCambio;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel lblSubTotal_moneda;
        private Telerik.WinControls.UI.RadLabel lblIVA;
        private Telerik.WinControls.UI.RadLabel lblDesc;
    }
}