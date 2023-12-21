namespace POSApp.Forms
{
    partial class frmCreditoPago
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
            this.lblNombreCliente = new Telerik.WinControls.UI.RadLabel();
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.txtIMPORTE = new Telerik.WinControls.UI.RadTextBox();
            this.lvPagos = new POSDLL.Windows.Forms.PrintableListView();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.dtpFECHA_PAGO = new System.Windows.Forms.DateTimePicker();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreCliente.Location = new System.Drawing.Point(13, 13);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(353, 79);
            this.lblNombreCliente.TabIndex = 0;
            this.lblNombreCliente.Text = "DIARTI: $100,000";
            this.lblNombreCliente.Click += new System.EventHandler(this.lblNombreCliente_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Importe a pagar:";
            // 
            // txtIMPORTE
            // 
            this.txtIMPORTE.Location = new System.Drawing.Point(12, 147);
            this.txtIMPORTE.Name = "txtIMPORTE";
            this.txtIMPORTE.Size = new System.Drawing.Size(100, 20);
            this.txtIMPORTE.TabIndex = 2;
            // 
            // lvPagos
            // 
            this.lvPagos.FitToPage = false;
            this.lvPagos.Location = new System.Drawing.Point(12, 173);
            this.lvPagos.Name = "lvPagos";
            this.lvPagos.Size = new System.Drawing.Size(350, 214);
            this.lvPagos.TabIndex = 4;
            this.lvPagos.Title = "";
            this.lvPagos.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fecha:";
            // 
            // dtpFECHA_PAGO
            // 
            this.dtpFECHA_PAGO.CustomFormat = "dd/MM/yyyy";
            this.dtpFECHA_PAGO.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFECHA_PAGO.Location = new System.Drawing.Point(12, 108);
            this.dtpFECHA_PAGO.Name = "dtpFECHA_PAGO";
            this.dtpFECHA_PAGO.Size = new System.Drawing.Size(100, 20);
            this.dtpFECHA_PAGO.TabIndex = 1;
            // 
            // btnAplicar
            // 
            this.btnAplicar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAplicar.Location = new System.Drawing.Point(118, 142);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(75, 25);
            this.btnAplicar.TabIndex = 3;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // frmCreditoPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 399);
            this.Controls.Add(this.dtpFECHA_PAGO);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvPagos);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.txtIMPORTE);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNombreCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmCreditoPago";
            this.ShowInTaskbar = false;
            this.Text = "Pago de crédito";
            this.Load += new System.EventHandler(this.frmCreditoPago_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblNombreCliente;
        private Telerik.WinControls.UI.RadLabel label1;
        private Telerik.WinControls.UI.RadTextBox txtIMPORTE;
        private System.Windows.Forms.Button btnAplicar;
        private POSDLL.Windows.Forms.PrintableListView lvPagos;
        private Telerik.WinControls.UI.RadLabel label2;
        private System.Windows.Forms.DateTimePicker dtpFECHA_PAGO;
    }
}