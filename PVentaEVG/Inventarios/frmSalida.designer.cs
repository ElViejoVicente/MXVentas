namespace POSApp.Forms
{
    partial class frmSalida
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
            this.lblID_EMPLEADO = new Telerik.WinControls.UI.RadLabel();
            this.txtID_EMPLEADO = new Telerik.WinControls.UI.RadTextBox();
            this.lblFECHA_SALIDA = new Telerik.WinControls.UI.RadLabel();
            this.txtFECHA_SALIDA = new System.Windows.Forms.DateTimePicker();
            this.btnBuscarEmpleado = new System.Windows.Forms.Button();
            this.lblOBSERVACIONES = new Telerik.WinControls.UI.RadLabel();
            this.txtOBSERVACIONES = new Telerik.WinControls.UI.RadTextBox();
            this.lblID_PRODUCTO = new Telerik.WinControls.UI.RadLabel();
            this.txtID_PRODUCTO = new Telerik.WinControls.UI.RadTextBox();
            this.lblCANTIDAD = new Telerik.WinControls.UI.RadLabel();
            this.txtCANTIDAD = new Telerik.WinControls.UI.RadTextBox();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnSearchProduct = new System.Windows.Forms.Button();
            this.lvArticulos = new System.Windows.Forms.ListView();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblID_EMPLEADO
            // 
            this.lblID_EMPLEADO.AutoSize = true;
            this.lblID_EMPLEADO.Location = new System.Drawing.Point(13, 13);
            this.lblID_EMPLEADO.Name = "lblID_EMPLEADO";
            this.lblID_EMPLEADO.Size = new System.Drawing.Size(57, 13);
            this.lblID_EMPLEADO.TabIndex = 0;
            this.lblID_EMPLEADO.Text = "Empleado:";
            // 
            // txtID_EMPLEADO
            // 
            this.txtID_EMPLEADO.Location = new System.Drawing.Point(16, 30);
            this.txtID_EMPLEADO.Name = "txtID_EMPLEADO";
            this.txtID_EMPLEADO.Size = new System.Drawing.Size(100, 20);
            this.txtID_EMPLEADO.TabIndex = 1;
            // 
            // lblFECHA_SALIDA
            // 
            this.lblFECHA_SALIDA.AutoSize = true;
            this.lblFECHA_SALIDA.Location = new System.Drawing.Point(13, 57);
            this.lblFECHA_SALIDA.Name = "lblFECHA_SALIDA";
            this.lblFECHA_SALIDA.Size = new System.Drawing.Size(40, 13);
            this.lblFECHA_SALIDA.TabIndex = 2;
            this.lblFECHA_SALIDA.Text = "Fecha:";
            // 
            // txtFECHA_SALIDA
            // 
            this.txtFECHA_SALIDA.CustomFormat = "dd/MM/yyyy";
            this.txtFECHA_SALIDA.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFECHA_SALIDA.Location = new System.Drawing.Point(16, 73);
            this.txtFECHA_SALIDA.Name = "txtFECHA_SALIDA";
            this.txtFECHA_SALIDA.Size = new System.Drawing.Size(100, 20);
            this.txtFECHA_SALIDA.TabIndex = 3;
            // 
            // btnBuscarEmpleado
            // 
            this.btnBuscarEmpleado.Image = global::POS.Properties.Resources.zoom;
            this.btnBuscarEmpleado.Location = new System.Drawing.Point(122, 27);
            this.btnBuscarEmpleado.Name = "btnBuscarEmpleado";
            this.btnBuscarEmpleado.Size = new System.Drawing.Size(41, 23);
            this.btnBuscarEmpleado.TabIndex = 2;
            this.btnBuscarEmpleado.UseVisualStyleBackColor = true;
            this.btnBuscarEmpleado.Click += new System.EventHandler(this.btnBuscarEmpleado_Click);
            // 
            // lblOBSERVACIONES
            // 
            this.lblOBSERVACIONES.AutoSize = true;
            this.lblOBSERVACIONES.Location = new System.Drawing.Point(13, 101);
            this.lblOBSERVACIONES.Name = "lblOBSERVACIONES";
            this.lblOBSERVACIONES.Size = new System.Drawing.Size(81, 13);
            this.lblOBSERVACIONES.TabIndex = 5;
            this.lblOBSERVACIONES.Text = "Observaciones:";
            // 
            // txtOBSERVACIONES
            // 
            this.txtOBSERVACIONES.Location = new System.Drawing.Point(16, 117);
            this.txtOBSERVACIONES.MaxLength = 255;
            this.txtOBSERVACIONES.Multiline = true;
            this.txtOBSERVACIONES.Name = "txtOBSERVACIONES";
            this.txtOBSERVACIONES.Size = new System.Drawing.Size(601, 69);
            this.txtOBSERVACIONES.TabIndex = 4;
            // 
            // lblID_PRODUCTO
            // 
            this.lblID_PRODUCTO.AutoSize = true;
            this.lblID_PRODUCTO.Location = new System.Drawing.Point(16, 193);
            this.lblID_PRODUCTO.Name = "lblID_PRODUCTO";
            this.lblID_PRODUCTO.Size = new System.Drawing.Size(53, 13);
            this.lblID_PRODUCTO.TabIndex = 7;
            this.lblID_PRODUCTO.Text = "Producto:";
            // 
            // txtID_PRODUCTO
            // 
            this.txtID_PRODUCTO.Location = new System.Drawing.Point(19, 210);
            this.txtID_PRODUCTO.MaxLength = 20;
            this.txtID_PRODUCTO.Name = "txtID_PRODUCTO";
            this.txtID_PRODUCTO.Size = new System.Drawing.Size(100, 20);
            this.txtID_PRODUCTO.TabIndex = 5;
            // 
            // lblCANTIDAD
            // 
            this.lblCANTIDAD.AutoSize = true;
            this.lblCANTIDAD.Location = new System.Drawing.Point(166, 193);
            this.lblCANTIDAD.Name = "lblCANTIDAD";
            this.lblCANTIDAD.Size = new System.Drawing.Size(52, 13);
            this.lblCANTIDAD.TabIndex = 9;
            this.lblCANTIDAD.Text = "Cantidad:";
            // 
            // txtCANTIDAD
            // 
            this.txtCANTIDAD.Location = new System.Drawing.Point(169, 209);
            this.txtCANTIDAD.MaxLength = 6;
            this.txtCANTIDAD.Name = "txtCANTIDAD";
            this.txtCANTIDAD.Size = new System.Drawing.Size(100, 20);
            this.txtCANTIDAD.TabIndex = 7;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Image = global::POS.Properties.Resources.add;
            this.btnAddProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddProduct.Location = new System.Drawing.Point(275, 204);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(74, 30);
            this.btnAddProduct.TabIndex = 8;
            this.btnAddProduct.Text = "Agregar";
            this.btnAddProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnSearchProduct
            // 
            this.btnSearchProduct.Image = global::POS.Properties.Resources.zoom;
            this.btnSearchProduct.Location = new System.Drawing.Point(122, 208);
            this.btnSearchProduct.Name = "btnSearchProduct";
            this.btnSearchProduct.Size = new System.Drawing.Size(30, 23);
            this.btnSearchProduct.TabIndex = 6;
            this.btnSearchProduct.UseVisualStyleBackColor = true;
            this.btnSearchProduct.Click += new System.EventHandler(this.btnSearchProduct_Click);
            // 
            // lvArticulos
            // 
            this.lvArticulos.FullRowSelect = true;
            this.lvArticulos.GridLines = true;
            this.lvArticulos.HideSelection = false;
            this.lvArticulos.Location = new System.Drawing.Point(19, 237);
            this.lvArticulos.Name = "lvArticulos";
            this.lvArticulos.Size = new System.Drawing.Size(598, 160);
            this.lvArticulos.TabIndex = 9;
            this.lvArticulos.UseCompatibleStateImageBehavior = false;
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = global::POS.Properties.Resources.disk;
            this.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(461, 403);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 30);
            this.btnGrabar.TabIndex = 10;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::POS.Properties.Resources.cancel;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(542, 403);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 30);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmSalida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 440);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.lvArticulos);
            this.Controls.Add(this.btnSearchProduct);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.txtCANTIDAD);
            this.Controls.Add(this.lblCANTIDAD);
            this.Controls.Add(this.txtID_PRODUCTO);
            this.Controls.Add(this.lblID_PRODUCTO);
            this.Controls.Add(this.txtOBSERVACIONES);
            this.Controls.Add(this.lblOBSERVACIONES);
            this.Controls.Add(this.btnBuscarEmpleado);
            this.Controls.Add(this.txtFECHA_SALIDA);
            this.Controls.Add(this.lblFECHA_SALIDA);
            this.Controls.Add(this.txtID_EMPLEADO);
            this.Controls.Add(this.lblID_EMPLEADO);
            this.Name = "frmSalida";
            this.ShowInTaskbar = false;
            this.Text = "Salida";
            this.Load += new System.EventHandler(this.frmSalida_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblID_EMPLEADO;
        private Telerik.WinControls.UI.RadTextBox txtID_EMPLEADO;
        private Telerik.WinControls.UI.RadLabel lblFECHA_SALIDA;
        private System.Windows.Forms.DateTimePicker txtFECHA_SALIDA;
        private System.Windows.Forms.Button btnBuscarEmpleado;
        private Telerik.WinControls.UI.RadLabel lblOBSERVACIONES;
        private Telerik.WinControls.UI.RadTextBox txtOBSERVACIONES;
        private Telerik.WinControls.UI.RadLabel lblID_PRODUCTO;
        private Telerik.WinControls.UI.RadTextBox txtID_PRODUCTO;
        private Telerik.WinControls.UI.RadLabel lblCANTIDAD;
        private Telerik.WinControls.UI.RadTextBox txtCANTIDAD;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnSearchProduct;
        private System.Windows.Forms.ListView lvArticulos;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnCancelar;
    }
}