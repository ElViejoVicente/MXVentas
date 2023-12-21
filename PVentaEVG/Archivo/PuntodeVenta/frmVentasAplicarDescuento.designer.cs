namespace POSApp.Forms
{
    partial class frmVentasAplicarDescuento
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
            this.lblMensaje = new Telerik.WinControls.UI.RadLabel();
            this.btnCalcelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.txtPORC_DESCUENTO = new Telerik.WinControls.UI.RadTextBox();
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.SuspendLayout();
            // 
            // lblMensaje
            // 
            this.lblMensaje.BorderVisible = true;// = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMensaje.ForeColor = System.Drawing.Color.Blue;
            this.lblMensaje.Location = new System.Drawing.Point(12, 49);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(237, 48);
            this.lblMensaje.TabIndex = 11;
            this.lblMensaje.TextAlignment  = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCalcelar
            // 
            this.btnCalcelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCalcelar.Image = global::POS.Properties.Resources.cancel;
            this.btnCalcelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCalcelar.Location = new System.Drawing.Point(177, 100);
            this.btnCalcelar.Name = "btnCalcelar";
            this.btnCalcelar.Size = new System.Drawing.Size(75, 25);
            this.btnCalcelar.TabIndex = 10;
            this.btnCalcelar.Text = "Cancelar";
            this.btnCalcelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCalcelar.UseVisualStyleBackColor = true;
            this.btnCalcelar.Click += new System.EventHandler(this.btnCalcelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = global::POS.Properties.Resources.accept;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(96, 100);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 25);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Image = global::POS.Properties.Resources.delete;
            this.btnQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitar.Location = new System.Drawing.Point(15, 100);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(75, 25);
            this.btnQuitar.TabIndex = 8;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // txtPORC_DESCUENTO
            // 
            this.txtPORC_DESCUENTO.Location = new System.Drawing.Point(15, 26);
            this.txtPORC_DESCUENTO.MaxLength = 3;
            this.txtPORC_DESCUENTO.Name = "txtPORC_DESCUENTO";
            this.txtPORC_DESCUENTO.Size = new System.Drawing.Size(75, 20);
            this.txtPORC_DESCUENTO.TabIndex = 7;
            this.txtPORC_DESCUENTO.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Porcentaje:";
            // 
            // frmVentasAplicarDescuento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 134);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.btnCalcelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.txtPORC_DESCUENTO);
            this.Controls.Add(this.label1);
            this.Name = "frmVentasAplicarDescuento";
            this.ShowInTaskbar = false;
            this.Text = "Aplicar Descuento";
            this.Load += new System.EventHandler(this.frmVentasAplicarDescuento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblMensaje;
        private System.Windows.Forms.Button btnCalcelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnQuitar;
        private Telerik.WinControls.UI.RadTextBox txtPORC_DESCUENTO;
        private Telerik.WinControls.UI.RadLabel label1;
    }
}