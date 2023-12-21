namespace POSApp.Forms
{
    partial class frmFactura
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
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.txtFOLIO_VENTA = new Telerik.WinControls.UI.RadTextBox();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.txtFOLIO_FACTURA = new Telerik.WinControls.UI.RadTextBox();
            this.label3 = new Telerik.WinControls.UI.RadLabel();
            this.dtpFECHA_FACTURA = new System.Windows.Forms.DateTimePicker();
            this.label4 = new Telerik.WinControls.UI.RadLabel();
            this.txtOBSERVACIONES = new Telerik.WinControls.UI.RadTextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBuscarTicket = new System.Windows.Forms.Button();
            this.label5 = new Telerik.WinControls.UI.RadLabel();
            this.txtID_CLIENTE = new Telerik.WinControls.UI.RadTextBox();
            this.btnBuscaCliente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ticket (s) separados por coma;";
            // 
            // txtFOLIO_VENTA
            // 
            this.txtFOLIO_VENTA.Location = new System.Drawing.Point(12, 25);
            this.txtFOLIO_VENTA.MaxLength = 15;
            this.txtFOLIO_VENTA.Name = "txtFOLIO_VENTA";
            this.txtFOLIO_VENTA.Size = new System.Drawing.Size(150, 20);
            this.txtFOLIO_VENTA.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Folio de factura:";
            // 
            // txtFOLIO_FACTURA
            // 
            this.txtFOLIO_FACTURA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFOLIO_FACTURA.Location = new System.Drawing.Point(15, 113);
            this.txtFOLIO_FACTURA.MaxLength = 10;
            this.txtFOLIO_FACTURA.Name = "txtFOLIO_FACTURA";
            this.txtFOLIO_FACTURA.Size = new System.Drawing.Size(100, 20);
            this.txtFOLIO_FACTURA.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha de facturación:";
            // 
            // dtpFECHA_FACTURA
            // 
            this.dtpFECHA_FACTURA.CustomFormat = "dd/MM/yyyy";
            this.dtpFECHA_FACTURA.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFECHA_FACTURA.Location = new System.Drawing.Point(15, 152);
            this.dtpFECHA_FACTURA.Name = "dtpFECHA_FACTURA";
            this.dtpFECHA_FACTURA.Size = new System.Drawing.Size(126, 20);
            this.dtpFECHA_FACTURA.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Observaciones:";
            // 
            // txtOBSERVACIONES
            // 
            this.txtOBSERVACIONES.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOBSERVACIONES.Location = new System.Drawing.Point(15, 202);
            this.txtOBSERVACIONES.Multiline = true;
            this.txtOBSERVACIONES.Name = "txtOBSERVACIONES";
            this.txtOBSERVACIONES.Size = new System.Drawing.Size(268, 70);
            this.txtOBSERVACIONES.TabIndex = 7;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::POS.Properties.Resources.cancel;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(201, 290);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(83, 30);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Cancelar";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::POS.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(116, 290);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 30);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Aceptar";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBuscarTicket
            // 
            this.btnBuscarTicket.Location = new System.Drawing.Point(168, 24);
            this.btnBuscarTicket.Name = "btnBuscarTicket";
            this.btnBuscarTicket.Size = new System.Drawing.Size(25, 20);
            this.btnBuscarTicket.TabIndex = 2;
            this.btnBuscarTicket.Text = "...";
            this.btnBuscarTicket.UseVisualStyleBackColor = true;
            this.btnBuscarTicket.Click += new System.EventHandler(this.btnBuscarTicket_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Cliente:";
            // 
            // txtID_CLIENTE
            // 
            this.txtID_CLIENTE.Location = new System.Drawing.Point(12, 69);
            this.txtID_CLIENTE.MaxLength = 10;
            this.txtID_CLIENTE.Name = "txtID_CLIENTE";
            this.txtID_CLIENTE.Size = new System.Drawing.Size(150, 20);
            this.txtID_CLIENTE.TabIndex = 3;
            // 
            // btnBuscaCliente
            // 
            this.btnBuscaCliente.Location = new System.Drawing.Point(168, 69);
            this.btnBuscaCliente.Name = "btnBuscaCliente";
            this.btnBuscaCliente.Size = new System.Drawing.Size(25, 20);
            this.btnBuscaCliente.TabIndex = 4;
            this.btnBuscaCliente.Text = "...";
            this.btnBuscaCliente.UseVisualStyleBackColor = true;
            this.btnBuscaCliente.Click += new System.EventHandler(this.btnBuscaCliente_Click);
            // 
            // frmFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(292, 343);
            this.Controls.Add(this.btnBuscaCliente);
            this.Controls.Add(this.txtID_CLIENTE);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnBuscarTicket);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtOBSERVACIONES);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpFECHA_FACTURA);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFOLIO_FACTURA);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFOLIO_VENTA);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmFactura";
            this.ShowInTaskbar = false;
            this.Text = "Facturar";
            this.Load += new System.EventHandler(this.frmFactura_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel label1;
        private Telerik.WinControls.UI.RadTextBox txtFOLIO_VENTA;
        private Telerik.WinControls.UI.RadLabel label2;
        private Telerik.WinControls.UI.RadTextBox txtFOLIO_FACTURA;
        private Telerik.WinControls.UI.RadLabel label3;
        private System.Windows.Forms.DateTimePicker dtpFECHA_FACTURA;
        private Telerik.WinControls.UI.RadLabel label4;
        private Telerik.WinControls.UI.RadTextBox txtOBSERVACIONES;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBuscarTicket;
        private Telerik.WinControls.UI.RadLabel label5;
        private Telerik.WinControls.UI.RadTextBox txtID_CLIENTE;
        private System.Windows.Forms.Button btnBuscaCliente;
    }
}