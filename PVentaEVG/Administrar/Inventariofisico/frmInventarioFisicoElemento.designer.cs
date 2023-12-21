namespace POSApp.Forms
{
    partial class frmInventarioFisicoElemento
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCANCEL = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtCANTIDAD_AJUSTE = new Telerik.WinControls.UI.RadTextBox();
            this.label3 = new Telerik.WinControls.UI.RadLabel();
            this.btnBuscaProducto = new System.Windows.Forms.Button();
            this.txtID_PRODUCTO = new Telerik.WinControls.UI.RadTextBox();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.lblDetails = new Telerik.WinControls.UI.RadLabel();
            this.SuspendLayout();
            // 
            // btnCANCEL
            // 
            this.btnCANCEL.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCANCEL.Image = global::POS.Properties.Resources.cancel;
            this.btnCANCEL.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCANCEL.Location = new System.Drawing.Point(88, 216);
            this.btnCANCEL.Name = "btnCANCEL";
            this.btnCANCEL.Size = new System.Drawing.Size(75, 30);
            this.btnCANCEL.TabIndex = 22;
            this.btnCANCEL.Text = "Cancelar";
            this.btnCANCEL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCANCEL.UseVisualStyleBackColor = true;
            this.btnCANCEL.Click += new System.EventHandler(this.btnCANCEL_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = global::POS.Properties.Resources.accept;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.Location = new System.Drawing.Point(11, 216);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(71, 30);
            this.btnOK.TabIndex = 21;
            this.btnOK.Text = "Aceptar";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtCANTIDAD_AJUSTE
            // 
            this.txtCANTIDAD_AJUSTE.Location = new System.Drawing.Point(12, 190);
            this.txtCANTIDAD_AJUSTE.MaxLength = 10;
            this.txtCANTIDAD_AJUSTE.Name = "txtCANTIDAD_AJUSTE";
            this.txtCANTIDAD_AJUSTE.Size = new System.Drawing.Size(100, 20);
            this.txtCANTIDAD_AJUSTE.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Cantidad:";
            // 
            // btnBuscaProducto
            // 
            this.btnBuscaProducto.Location = new System.Drawing.Point(118, 148);
            this.btnBuscaProducto.Name = "btnBuscaProducto";
            this.btnBuscaProducto.Size = new System.Drawing.Size(32, 23);
            this.btnBuscaProducto.TabIndex = 18;
            this.btnBuscaProducto.Text = "...";
            this.btnBuscaProducto.UseVisualStyleBackColor = true;
            this.btnBuscaProducto.Click += new System.EventHandler(this.btnBuscaProducto_Click);
            // 
            // txtID_PRODUCTO
            // 
            this.txtID_PRODUCTO.Location = new System.Drawing.Point(12, 151);
            this.txtID_PRODUCTO.Name = "txtID_PRODUCTO";
            this.txtID_PRODUCTO.Size = new System.Drawing.Size(100, 20);
            this.txtID_PRODUCTO.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Clave de artículo:";
            // 
            // lblDetails
            // 
            //this.lblDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetails.Location = new System.Drawing.Point(12, 9);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(384, 121);
            this.lblDetails.TabIndex = 15;
            this.lblDetails.Text = "Información";
            // 
            // frmInventarioFisicoElemento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 262);
            this.Controls.Add(this.btnCANCEL);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtCANTIDAD_AJUSTE);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBuscaProducto);
            this.Controls.Add(this.txtID_PRODUCTO);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmInventarioFisicoElemento";
            this.ShowInTaskbar = false;
            this.Text = "Elemento";
            this.Load += new System.EventHandler(this.frmInventarioFisicoElemento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCANCEL;
        private System.Windows.Forms.Button btnOK;
        private Telerik.WinControls.UI.RadTextBox txtCANTIDAD_AJUSTE;
        private Telerik.WinControls.UI.RadLabel label3;
        private System.Windows.Forms.Button btnBuscaProducto;
        private Telerik.WinControls.UI.RadTextBox txtID_PRODUCTO;
        private Telerik.WinControls.UI.RadLabel label2;
        private Telerik.WinControls.UI.RadLabel lblDetails;
    }
}