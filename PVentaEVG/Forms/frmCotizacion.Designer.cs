namespace POSApp.Forms
{
    partial class frmCotizacion
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
            this.txtID_CLIENTE = new Telerik.WinControls.UI.RadTextBox();
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.label7 = new Telerik.WinControls.UI.RadLabel();
            this.txtIMPUESTO = new Telerik.WinControls.UI.RadTextBox();
            this.txtPRECIO = new Telerik.WinControls.UI.RadTextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lvCotizacion = new System.Windows.Forms.ListView();
            this.txtCANTIDAD = new Telerik.WinControls.UI.RadTextBox();
            this.label8 = new Telerik.WinControls.UI.RadLabel();
            this.btnSearchProduct = new System.Windows.Forms.Button();
            this.txtID_PRODUCTO = new Telerik.WinControls.UI.RadTextBox();
            this.label5 = new Telerik.WinControls.UI.RadLabel();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.chkIVA = new System.Windows.Forms.CheckBox();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // txtID_CLIENTE
            // 
            this.txtID_CLIENTE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtID_CLIENTE.Location = new System.Drawing.Point(13, 27);
            this.txtID_CLIENTE.Name = "txtID_CLIENTE";
            this.txtID_CLIENTE.Size = new System.Drawing.Size(100, 20);
            this.txtID_CLIENTE.TabIndex = 15;
            this.txtID_CLIENTE.Text = "1";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "Clave del cliente:";
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Image = global::POS.Properties.Resources.zoom;
            this.btnBuscarCliente.Location = new System.Drawing.Point(119, 22);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(37, 25);
            this.btnBuscarCliente.TabIndex = 16;
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(217, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Precio:";
            // 
            // txtIMPUESTO
            // 
            this.txtIMPUESTO.Location = new System.Drawing.Point(284, 66);
            this.txtIMPUESTO.Name = "txtIMPUESTO";
            this.txtIMPUESTO.Size = new System.Drawing.Size(38, 20);
            this.txtIMPUESTO.TabIndex = 25;
            this.txtIMPUESTO.Text = "0.16";
            // 
            // txtPRECIO
            // 
            this.txtPRECIO.Location = new System.Drawing.Point(217, 66);
            this.txtPRECIO.Name = "txtPRECIO";
            this.txtPRECIO.Size = new System.Drawing.Size(61, 20);
            this.txtPRECIO.TabIndex = 24;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::POS.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(669, 409);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 30);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::POS.Properties.Resources.disk;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(586, 409);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 30);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "Guardar";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lvCotizacion
            // 
            this.lvCotizacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvCotizacion.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvCotizacion.FullRowSelect = true;
            this.lvCotizacion.GridLines = true;
            this.lvCotizacion.HideSelection = false;
            this.lvCotizacion.Location = new System.Drawing.Point(12, 92);
            this.lvCotizacion.Name = "lvCotizacion";
            this.lvCotizacion.Size = new System.Drawing.Size(734, 311);
            this.lvCotizacion.TabIndex = 28;
            this.lvCotizacion.UseCompatibleStateImageBehavior = false;
            // 
            // txtCANTIDAD
            // 
            this.txtCANTIDAD.Location = new System.Drawing.Point(162, 66);
            this.txtCANTIDAD.Name = "txtCANTIDAD";
            this.txtCANTIDAD.Size = new System.Drawing.Size(49, 20);
            this.txtCANTIDAD.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(159, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Cantidad:";
            // 
            // btnSearchProduct
            // 
            this.btnSearchProduct.Image = global::POS.Properties.Resources.zoom;
            this.btnSearchProduct.Location = new System.Drawing.Point(118, 63);
            this.btnSearchProduct.Name = "btnSearchProduct";
            this.btnSearchProduct.Size = new System.Drawing.Size(38, 23);
            this.btnSearchProduct.TabIndex = 20;
            this.btnSearchProduct.UseVisualStyleBackColor = true;
            this.btnSearchProduct.Click += new System.EventHandler(this.btnSearchProduct_Click);
            // 
            // txtID_PRODUCTO
            // 
            this.txtID_PRODUCTO.Location = new System.Drawing.Point(13, 66);
            this.txtID_PRODUCTO.Name = "txtID_PRODUCTO";
            this.txtID_PRODUCTO.Size = new System.Drawing.Size(99, 20);
            this.txtID_PRODUCTO.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Clave del artículo:";
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Image = global::POS.Properties.Resources.add;
            this.btnAddProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddProduct.Location = new System.Drawing.Point(328, 56);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(74, 30);
            this.btnAddProduct.TabIndex = 26;
            this.btnAddProduct.Text = "Agregar";
            this.btnAddProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // chkIVA
            // 
            this.chkIVA.AutoSize = true;
            this.chkIVA.Checked = true;
            this.chkIVA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIVA.Location = new System.Drawing.Point(284, 48);
            this.chkIVA.Name = "chkIVA";
            this.chkIVA.Size = new System.Drawing.Size(46, 17);
            this.chkIVA.TabIndex = 27;
            this.chkIVA.Text = "IVA:";
            this.chkIVA.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Fecha final:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFin.Location = new System.Drawing.Point(162, 26);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(116, 20);
            this.dtpFechaFin.TabIndex = 32;
            // 
            // frmCotizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 451);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtIMPUESTO);
            this.Controls.Add(this.txtPRECIO);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lvCotizacion);
            this.Controls.Add(this.txtCANTIDAD);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnSearchProduct);
            this.Controls.Add(this.txtID_PRODUCTO);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.chkIVA);
            this.Controls.Add(this.txtID_CLIENTE);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscarCliente);
            this.Name = "frmCotizacion";
            this.Text = "Cotización";
            this.Load += new System.EventHandler(this.frmCotizacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBox txtID_CLIENTE;
        private Telerik.WinControls.UI.RadLabel label1;
        private System.Windows.Forms.Button btnBuscarCliente;
        private Telerik.WinControls.UI.RadLabel label7;
        private Telerik.WinControls.UI.RadTextBox txtIMPUESTO;
        private Telerik.WinControls.UI.RadTextBox txtPRECIO;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListView lvCotizacion;
        private Telerik.WinControls.UI.RadTextBox txtCANTIDAD;
        private Telerik.WinControls.UI.RadLabel label8;
        private System.Windows.Forms.Button btnSearchProduct;
        private Telerik.WinControls.UI.RadTextBox txtID_PRODUCTO;
        private Telerik.WinControls.UI.RadLabel label5;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.CheckBox chkIVA;
        private Telerik.WinControls.UI.RadLabel label2;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
    }
}