using POSDLL; using POSDLL.Windows.Forms; using POSDLL.Security; using POSDLL.Reporting; using POSDLL.Ticket;
namespace POSApp.Forms
{
    partial class frmVentaCancelar
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
            this.btnBuscarTicket = new System.Windows.Forms.Button();
            this.txtFOLIO_VENTA = new Telerik.WinControls.UI.RadTextBox();
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.btnView = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.txtMotivoCancelacion = new Telerik.WinControls.UI.RadTextBox();
            this.SuspendLayout();
            // 
            // btnBuscarTicket
            // 
            this.btnBuscarTicket.Image = global::POS.Properties.Resources.zoom;
            this.btnBuscarTicket.Location = new System.Drawing.Point(118, 29);
            this.btnBuscarTicket.Name = "btnBuscarTicket";
            this.btnBuscarTicket.Size = new System.Drawing.Size(38, 23);
            this.btnBuscarTicket.TabIndex = 12;
            this.btnBuscarTicket.UseVisualStyleBackColor = true;
            this.btnBuscarTicket.Click += new System.EventHandler(this.btnBuscarTicket_Click);
            // 
            // txtFOLIO_VENTA
            // 
            this.txtFOLIO_VENTA.Location = new System.Drawing.Point(12, 32);
            this.txtFOLIO_VENTA.Name = "txtFOLIO_VENTA";
            this.txtFOLIO_VENTA.Size = new System.Drawing.Size(100, 20);
            this.txtFOLIO_VENTA.TabIndex = 11;
            this.txtFOLIO_VENTA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFOLIO_VENTA_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Ticket de venta";
            // 
            // btnView
            // 
            this.btnView.Image = global::POS.Properties.Resources.SearchFolderHS;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.Location = new System.Drawing.Point(12, 187);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(61, 25);
            this.btnView.TabIndex = 13;
            this.btnView.Text = "Ver";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnOk
            // 
            this.btnOk.Image = global::POS.Properties.Resources.accept;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.Location = new System.Drawing.Point(79, 187);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(77, 25);
            this.btnOk.TabIndex = 14;
            this.btnOk.Text = "Aceptar";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::POS.Properties.Resources.cancel;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(162, 187);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(71, 25);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Cerrar";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Motivo de Cancelación:";
            // 
            // txtMotivoCancelacion
            // 
            this.txtMotivoCancelacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMotivoCancelacion.Location = new System.Drawing.Point(12, 76);
            this.txtMotivoCancelacion.MaxLength = 150;
            this.txtMotivoCancelacion.Multiline = true;
            this.txtMotivoCancelacion.Name = "txtMotivoCancelacion";
            this.txtMotivoCancelacion.Size = new System.Drawing.Size(220, 105);
            this.txtMotivoCancelacion.TabIndex = 17;
            // 
            // frmVentaCancelar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(244, 251);
            this.Controls.Add(this.txtMotivoCancelacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnBuscarTicket);
            this.Controls.Add(this.txtFOLIO_VENTA);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "frmVentaCancelar";
            this.ShowInTaskbar = false;
            this.Text = "Cancelar venta";
            this.Load += new System.EventHandler(this.frmCancelarVenta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void txtFOLIO_VENTA_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
      
        }

        #endregion

        private System.Windows.Forms.Button btnBuscarTicket;
        private Telerik.WinControls.UI.RadTextBox txtFOLIO_VENTA;
        private Telerik.WinControls.UI.RadLabel label1;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClose;
        private Telerik.WinControls.UI.RadLabel label2;
        private Telerik.WinControls.UI.RadTextBox txtMotivoCancelacion;
    }
}