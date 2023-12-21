namespace POSApp.Forms
{
    partial class frmProductoIngredientes
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
            this.lblTitulo = new Telerik.WinControls.UI.RadLabel();
            this.btnSearchProduct = new System.Windows.Forms.Button();
            this.txtCANTIDAD = new Telerik.WinControls.UI.RadTextBox();
            this.lblCANTIDAD = new Telerik.WinControls.UI.RadLabel();
            this.txtID_PRODUCTO = new Telerik.WinControls.UI.RadTextBox();
            this.lblID_PRODUCTO = new Telerik.WinControls.UI.RadLabel();
            this.btnAgregarArticulo = new System.Windows.Forms.Button();
            this.lvIngredientes = new POSDLL.Windows.Forms.PrintableListView();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Blue;
            this.lblTitulo.Location = new System.Drawing.Point(13, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(311, 17);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Ingredientes de: \"COXTEL DE CAMARON\"";
            // 
            // btnSearchProduct
            // 
            this.btnSearchProduct.Image = global::POS.Properties.Resources.zoom;
            this.btnSearchProduct.Location = new System.Drawing.Point(119, 48);
            this.btnSearchProduct.Name = "btnSearchProduct";
            this.btnSearchProduct.Size = new System.Drawing.Size(30, 23);
            this.btnSearchProduct.TabIndex = 7;
            this.btnSearchProduct.UseVisualStyleBackColor = true;
            this.btnSearchProduct.Click += new System.EventHandler(this.btnSearchProduct_Click);
            // 
            // txtCANTIDAD
            // 
            this.txtCANTIDAD.Location = new System.Drawing.Point(155, 52);
            this.txtCANTIDAD.MaxLength = 6;
            this.txtCANTIDAD.Name = "txtCANTIDAD";
            this.txtCANTIDAD.Size = new System.Drawing.Size(100, 20);
            this.txtCANTIDAD.TabIndex = 9;
            // 
            // lblCANTIDAD
            // 
            this.lblCANTIDAD.AutoSize = true;
            this.lblCANTIDAD.Location = new System.Drawing.Point(155, 37);
            this.lblCANTIDAD.Name = "lblCANTIDAD";
            this.lblCANTIDAD.Size = new System.Drawing.Size(52, 13);
            this.lblCANTIDAD.TabIndex = 8;
            this.lblCANTIDAD.Text = "Cantidad:";
            // 
            // txtID_PRODUCTO
            // 
            this.txtID_PRODUCTO.Location = new System.Drawing.Point(13, 52);
            this.txtID_PRODUCTO.MaxLength = 20;
            this.txtID_PRODUCTO.Name = "txtID_PRODUCTO";
            this.txtID_PRODUCTO.Size = new System.Drawing.Size(100, 20);
            this.txtID_PRODUCTO.TabIndex = 5;
            // 
            // lblID_PRODUCTO
            // 
            this.lblID_PRODUCTO.AutoSize = true;
            this.lblID_PRODUCTO.Location = new System.Drawing.Point(13, 37);
            this.lblID_PRODUCTO.Name = "lblID_PRODUCTO";
            this.lblID_PRODUCTO.Size = new System.Drawing.Size(53, 13);
            this.lblID_PRODUCTO.TabIndex = 6;
            this.lblID_PRODUCTO.Text = "Producto:";
            // 
            // btnAgregarArticulo
            // 
            this.btnAgregarArticulo.Image = global::POS.Properties.Resources.add;
            this.btnAgregarArticulo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarArticulo.Location = new System.Drawing.Point(261, 43);
            this.btnAgregarArticulo.Name = "btnAgregarArticulo";
            this.btnAgregarArticulo.Size = new System.Drawing.Size(136, 28);
            this.btnAgregarArticulo.TabIndex = 10;
            this.btnAgregarArticulo.Text = "Agregar Articulo";
            this.btnAgregarArticulo.UseVisualStyleBackColor = true;
            this.btnAgregarArticulo.Click += new System.EventHandler(this.btnAgregarArticulo_Click);
            // 
            // lvIngredientes
            // 
            this.lvIngredientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvIngredientes.FitToPage = false;
            this.lvIngredientes.FullRowSelect = true;
            this.lvIngredientes.GridLines = true;
            this.lvIngredientes.HideSelection = false;
            this.lvIngredientes.Location = new System.Drawing.Point(13, 79);
            this.lvIngredientes.Name = "lvIngredientes";
            this.lvIngredientes.Size = new System.Drawing.Size(575, 174);
            this.lvIngredientes.TabIndex = 11;
            this.lvIngredientes.Title = "";
            this.lvIngredientes.UseCompatibleStateImageBehavior = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.Image = global::POS.Properties.Resources.close;
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.Location = new System.Drawing.Point(513, 259);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 25);
            this.btnCerrar.TabIndex = 12;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "De doble clic para editar o eliminar.";
            // 
            // frmProductoIngredientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 294);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lvIngredientes);
            this.Controls.Add(this.btnAgregarArticulo);
            this.Controls.Add(this.btnSearchProduct);
            this.Controls.Add(this.txtCANTIDAD);
            this.Controls.Add(this.lblCANTIDAD);
            this.Controls.Add(this.txtID_PRODUCTO);
            this.Controls.Add(this.lblID_PRODUCTO);
            this.Controls.Add(this.lblTitulo);
            this.Name = "frmProductoIngredientes";
            this.ShowInTaskbar = false;
            this.Text = "Ingredientes";
            this.Load += new System.EventHandler(this.frmProductoIngredientes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblTitulo;
        private System.Windows.Forms.Button btnSearchProduct;
        private Telerik.WinControls.UI.RadTextBox txtCANTIDAD;
        private Telerik.WinControls.UI.RadLabel lblCANTIDAD;
        private Telerik.WinControls.UI.RadTextBox txtID_PRODUCTO;
        private Telerik.WinControls.UI.RadLabel lblID_PRODUCTO;
        private System.Windows.Forms.Button btnAgregarArticulo;
        private POSDLL.Windows.Forms.PrintableListView lvIngredientes;
        private System.Windows.Forms.Button btnCerrar;
        private Telerik.WinControls.UI.RadLabel label1;
    }
}