namespace POSApp.Forms
{
    partial class frmPedido
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
            this.txtID_PROVEEDOR = new Telerik.WinControls.UI.RadTextBox();
            this.btnSearchProvider = new System.Windows.Forms.Button();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.txtCANTIDAD = new Telerik.WinControls.UI.RadTextBox();
            this.label8 = new Telerik.WinControls.UI.RadLabel();
            this.btnSearchProduct = new System.Windows.Forms.Button();
            this.txtID_PRODUCTO = new Telerik.WinControls.UI.RadTextBox();
            this.label5 = new Telerik.WinControls.UI.RadLabel();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.lvPedido = new System.Windows.Forms.ListView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkIVA = new System.Windows.Forms.CheckBox();
            this.txtIMPUESTO = new Telerik.WinControls.UI.RadTextBox();
            this.txtPRECIO = new Telerik.WinControls.UI.RadTextBox();
            this.label7 = new Telerik.WinControls.UI.RadLabel();
            this.SuspendLayout();
            // 
            // txtID_PROVEEDOR
            // 
            this.txtID_PROVEEDOR.Location = new System.Drawing.Point(15, 26);
            this.txtID_PROVEEDOR.Name = "txtID_PROVEEDOR";
            this.txtID_PROVEEDOR.Size = new System.Drawing.Size(133, 20);
            this.txtID_PROVEEDOR.TabIndex = 0;
            // 
            // btnSearchProvider
            // 
            this.btnSearchProvider.Image = global::POS.Properties.Resources.zoom;
            this.btnSearchProvider.Location = new System.Drawing.Point(154, 23);
            this.btnSearchProvider.Name = "btnSearchProvider";
            this.btnSearchProvider.Size = new System.Drawing.Size(37, 23);
            this.btnSearchProvider.TabIndex = 1;
            this.btnSearchProvider.UseVisualStyleBackColor = true;
            this.btnSearchProvider.Click += new System.EventHandler(this.btnSearchProvider_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Id del Proveedor:";
            // 
            // txtCANTIDAD
            // 
            this.txtCANTIDAD.Location = new System.Drawing.Point(162, 65);
            this.txtCANTIDAD.Name = "txtCANTIDAD";
            this.txtCANTIDAD.Size = new System.Drawing.Size(49, 20);
            this.txtCANTIDAD.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(159, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Cantidad:";
            // 
            // btnSearchProduct
            // 
            this.btnSearchProduct.Image = global::POS.Properties.Resources.zoom;
            this.btnSearchProduct.Location = new System.Drawing.Point(118, 62);
            this.btnSearchProduct.Name = "btnSearchProduct";
            this.btnSearchProduct.Size = new System.Drawing.Size(38, 23);
            this.btnSearchProduct.TabIndex = 3;
            this.btnSearchProduct.UseVisualStyleBackColor = true;
            this.btnSearchProduct.Click += new System.EventHandler(this.btnSearchProduct_Click);
            // 
            // txtID_PRODUCTO
            // 
            this.txtID_PRODUCTO.Location = new System.Drawing.Point(13, 65);
            this.txtID_PRODUCTO.Name = "txtID_PRODUCTO";
            this.txtID_PRODUCTO.Size = new System.Drawing.Size(99, 20);
            this.txtID_PRODUCTO.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Clave del artículo:";
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Image = global::POS.Properties.Resources.add;
            this.btnAddProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddProduct.Location = new System.Drawing.Point(328, 55);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(74, 30);
            this.btnAddProduct.TabIndex = 6;
            this.btnAddProduct.Text = "Agregar";
            this.btnAddProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // lvPedido
            // 
            this.lvPedido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvPedido.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvPedido.FullRowSelect = true;
            this.lvPedido.GridLines = true;
            this.lvPedido.HideSelection = false;
            this.lvPedido.Location = new System.Drawing.Point(12, 91);
            this.lvPedido.Name = "lvPedido";
            this.lvPedido.Size = new System.Drawing.Size(747, 270);
            this.lvPedido.TabIndex = 7;
            this.lvPedido.UseCompatibleStateImageBehavior = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::POS.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(682, 367);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 30);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::POS.Properties.Resources.disk;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(599, 367);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 30);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Guardar";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkIVA
            // 
            this.chkIVA.AutoSize = true;
            this.chkIVA.Checked = true;
            this.chkIVA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIVA.Location = new System.Drawing.Point(284, 47);
            this.chkIVA.Name = "chkIVA";
            this.chkIVA.Size = new System.Drawing.Size(46, 17);
            this.chkIVA.TabIndex = 6;
            this.chkIVA.Text = "IVA:";
            this.chkIVA.UseVisualStyleBackColor = true;
            this.chkIVA.CheckedChanged += new System.EventHandler(this.chkIVA_CheckedChanged);
            // 
            // txtIMPUESTO
            // 
            this.txtIMPUESTO.Location = new System.Drawing.Point(284, 65);
            this.txtIMPUESTO.Name = "txtIMPUESTO";
            this.txtIMPUESTO.Size = new System.Drawing.Size(38, 20);
            this.txtIMPUESTO.TabIndex = 6;
            this.txtIMPUESTO.Text = "0.16";
            // 
            // txtPRECIO
            // 
            this.txtPRECIO.Location = new System.Drawing.Point(217, 65);
            this.txtPRECIO.Name = "txtPRECIO";
            this.txtPRECIO.Size = new System.Drawing.Size(61, 20);
            this.txtPRECIO.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(217, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Precio:";
            // 
            // frmPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 409);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtIMPUESTO);
            this.Controls.Add(this.txtPRECIO);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lvPedido);
            this.Controls.Add(this.txtCANTIDAD);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnSearchProduct);
            this.Controls.Add(this.txtID_PRODUCTO);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.txtID_PROVEEDOR);
            this.Controls.Add(this.btnSearchProvider);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkIVA);
            this.Name = "frmPedido";
            this.Text = "Pedido";
            this.Load += new System.EventHandler(this.frmPedido_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBox txtID_PROVEEDOR;
        private System.Windows.Forms.Button btnSearchProvider;
        private Telerik.WinControls.UI.RadLabel label2;
        private Telerik.WinControls.UI.RadTextBox txtCANTIDAD;
        private Telerik.WinControls.UI.RadLabel label8;
        private System.Windows.Forms.Button btnSearchProduct;
        private Telerik.WinControls.UI.RadTextBox txtID_PRODUCTO;
        private Telerik.WinControls.UI.RadLabel label5;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.ListView lvPedido;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkIVA;
        private Telerik.WinControls.UI.RadTextBox txtIMPUESTO;
        private Telerik.WinControls.UI.RadTextBox txtPRECIO;
        private Telerik.WinControls.UI.RadLabel label7;
    }
}