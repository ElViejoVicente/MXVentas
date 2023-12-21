namespace POSApp.Forms
{
    partial class frmRptVentasClienteArticulo
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.dtpFECHA_FIN = new System.Windows.Forms.DateTimePicker();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.dtpFECHA_INI = new System.Windows.Forms.DateTimePicker();
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.txtID_CLIENTE = new Telerik.WinControls.UI.RadTextBox();
            this.label3 = new Telerik.WinControls.UI.RadLabel();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::POS.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(173, 125);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 30);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = global::POS.Properties.Resources.accept;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.Location = new System.Drawing.Point(87, 125);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 30);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "Aceptar";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dtpFECHA_FIN
            // 
            this.dtpFECHA_FIN.CustomFormat = "dd/MM/yyyy";
            this.dtpFECHA_FIN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFECHA_FIN.Location = new System.Drawing.Point(140, 86);
            this.dtpFECHA_FIN.Name = "dtpFECHA_FIN";
            this.dtpFECHA_FIN.Size = new System.Drawing.Size(111, 20);
            this.dtpFECHA_FIN.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Fecha final:";
            // 
            // dtpFECHA_INI
            // 
            this.dtpFECHA_INI.CustomFormat = "dd/MM/yyyy";
            this.dtpFECHA_INI.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFECHA_INI.Location = new System.Drawing.Point(33, 86);
            this.dtpFECHA_INI.Name = "dtpFECHA_INI";
            this.dtpFECHA_INI.Size = new System.Drawing.Size(101, 20);
            this.dtpFECHA_INI.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Fecha inicial:";
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBuscarCliente.Image = global::POS.Properties.Resources.zoom;
            this.btnBuscarCliente.Location = new System.Drawing.Point(193, 23);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(67, 31);
            this.btnBuscarCliente.TabIndex = 19;
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // txtID_CLIENTE
            // 
            this.txtID_CLIENTE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtID_CLIENTE.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.txtID_CLIENTE.Location = new System.Drawing.Point(12, 26);
            this.txtID_CLIENTE.Name = "txtID_CLIENTE";
            this.txtID_CLIENTE.Size = new System.Drawing.Size(175, 31);
            this.txtID_CLIENTE.TabIndex = 18;
            this.txtID_CLIENTE.Text = "1";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label3.Location = new System.Drawing.Point(7, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(245, 23);
            this.label3.TabIndex = 17;
            this.label3.Text = "Clave del cliente:";
            // 
            // frmRptVentasClienteArticulo
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(261, 167);
            this.Controls.Add(this.btnBuscarCliente);
            this.Controls.Add(this.txtID_CLIENTE);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dtpFECHA_FIN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFECHA_INI);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmRptVentasClienteArticulo";
            this.Text = "Ventas por cliente y articulo";
            this.Load += new System.EventHandler(this.frmRptVentasClienteArticulo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DateTimePicker dtpFECHA_FIN;
        private Telerik.WinControls.UI.RadLabel label2;
        private System.Windows.Forms.DateTimePicker dtpFECHA_INI;
        private Telerik.WinControls.UI.RadLabel label1;
        private System.Windows.Forms.Button btnBuscarCliente;
        private Telerik.WinControls.UI.RadTextBox txtID_CLIENTE;
        private Telerik.WinControls.UI.RadLabel label3;
    }
}