namespace POSApp.Forms
{
    partial class frmVentasCobrar
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtDigitos = new Telerik.WinControls.UI.RadTextBox();
            this.txtPago = new Telerik.WinControls.UI.RadTextBox();
            this.chkCREDITO = new System.Windows.Forms.CheckBox();
            this.txtNO_AUTORIZACION = new Telerik.WinControls.UI.RadTextBox();
            this.lblNO_AUTORIZACION = new Telerik.WinControls.UI.RadLabel();
            this.cboTIPO_PAGO = new System.Windows.Forms.ComboBox();
            this.label12 = new Telerik.WinControls.UI.RadLabel();
            this.txtOBSERVACIONES = new Telerik.WinControls.UI.RadTextBox();
            this.lblOBSERVACIONES = new Telerik.WinControls.UI.RadLabel();
            this.dtpFECHA_OPERACION = new System.Windows.Forms.DateTimePicker();
            this.label3 = new Telerik.WinControls.UI.RadLabel();
            this.txtCambio = new Telerik.WinControls.UI.RadTextBox();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.txtEfectivo = new Telerik.WinControls.UI.RadTextBox();
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.txtTotal = new Telerik.WinControls.UI.RadTextBox();
            this.lblTotal = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDigitos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNO_AUTORIZACION)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNO_AUTORIZACION)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOBSERVACIONES)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOBSERVACIONES)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCambio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEfectivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Enabled = false;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.Location = new System.Drawing.Point(105, 373);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(119, 54);
            this.btnOk.TabIndex = 39;
            this.btnOk.Text = "Aceptar";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(269, 373);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(131, 54);
            this.btnCancel.TabIndex = 40;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.txtDigitos);
            this.radGroupBox1.Controls.Add(this.txtPago);
            this.radGroupBox1.Controls.Add(this.chkCREDITO);
            this.radGroupBox1.Controls.Add(this.btnCancel);
            this.radGroupBox1.Controls.Add(this.txtNO_AUTORIZACION);
            this.radGroupBox1.Controls.Add(this.btnOk);
            this.radGroupBox1.Controls.Add(this.lblNO_AUTORIZACION);
            this.radGroupBox1.Controls.Add(this.cboTIPO_PAGO);
            this.radGroupBox1.Controls.Add(this.label12);
            this.radGroupBox1.Controls.Add(this.txtOBSERVACIONES);
            this.radGroupBox1.Controls.Add(this.lblOBSERVACIONES);
            this.radGroupBox1.Controls.Add(this.dtpFECHA_OPERACION);
            this.radGroupBox1.Controls.Add(this.label3);
            this.radGroupBox1.Controls.Add(this.txtCambio);
            this.radGroupBox1.Controls.Add(this.label2);
            this.radGroupBox1.Controls.Add(this.txtEfectivo);
            this.radGroupBox1.Controls.Add(this.label1);
            this.radGroupBox1.Controls.Add(this.txtTotal);
            this.radGroupBox1.Controls.Add(this.lblTotal);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(10, 13);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(504, 452);
            this.radGroupBox1.TabIndex = 6;
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(339, 160);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(85, 26);
            this.radLabel1.TabIndex = 36;
            this.radLabel1.Text = "4 Digitos";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDigitos
            // 
            this.txtDigitos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDigitos.ForeColor = System.Drawing.Color.Red;
            this.txtDigitos.Location = new System.Drawing.Point(430, 159);
            this.txtDigitos.MaxLength = 4;
            this.txtDigitos.Name = "txtDigitos";
            this.txtDigitos.Size = new System.Drawing.Size(66, 27);
            this.txtDigitos.TabIndex = 36;
            this.txtDigitos.TabStop = false;
            this.txtDigitos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPago
            // 
            this.txtPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.txtPago.ForeColor = System.Drawing.Color.Red;
            this.txtPago.Location = new System.Drawing.Point(330, 114);
            this.txtPago.Name = "txtPago";
            this.txtPago.NullText = "0";
            this.txtPago.Size = new System.Drawing.Size(166, 36);
            this.txtPago.TabIndex = 34;
            this.txtPago.TabStop = false;
            this.txtPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPago.TextChanged += new System.EventHandler(this.txtEfectivo_TextChanged);
            this.txtPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEfectivo_KeyPress);
            this.txtPago.Leave += new System.EventHandler(this.txtEfectivo_Leave);
            // 
            // chkCREDITO
            // 
            this.chkCREDITO.AutoSize = true;
            this.chkCREDITO.Location = new System.Drawing.Point(13, 252);
            this.chkCREDITO.Name = "chkCREDITO";
            this.chkCREDITO.Size = new System.Drawing.Size(117, 17);
            this.chkCREDITO.TabIndex = 37;
            this.chkCREDITO.Text = "VENTA A CREDITO";
            this.chkCREDITO.UseVisualStyleBackColor = true;
            // 
            // txtNO_AUTORIZACION
            // 
            this.txtNO_AUTORIZACION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNO_AUTORIZACION.Enabled = false;
            this.txtNO_AUTORIZACION.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNO_AUTORIZACION.Location = new System.Drawing.Point(163, 159);
            this.txtNO_AUTORIZACION.MaxLength = 15;
            this.txtNO_AUTORIZACION.Name = "txtNO_AUTORIZACION";
            this.txtNO_AUTORIZACION.Size = new System.Drawing.Size(147, 27);
            this.txtNO_AUTORIZACION.TabIndex = 35;
            this.txtNO_AUTORIZACION.TabStop = false;
            // 
            // lblNO_AUTORIZACION
            // 
            this.lblNO_AUTORIZACION.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNO_AUTORIZACION.Location = new System.Drawing.Point(5, 156);
            this.lblNO_AUTORIZACION.Name = "lblNO_AUTORIZACION";
            this.lblNO_AUTORIZACION.Size = new System.Drawing.Size(152, 26);
            this.lblNO_AUTORIZACION.TabIndex = 44;
            this.lblNO_AUTORIZACION.Text = "No Autorizacion:";
            // 
            // cboTIPO_PAGO
            // 
            this.cboTIPO_PAGO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTIPO_PAGO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTIPO_PAGO.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTIPO_PAGO.FormattingEnabled = true;
            this.cboTIPO_PAGO.Items.AddRange(new object[] {
            "NINGUNO",
            "CHEQUE",
            "TRANS. ELECTRONICA",
            "TARJETA CREDITO",
            "TARJETA DEBITO"});
            this.cboTIPO_PAGO.Location = new System.Drawing.Point(163, 115);
            this.cboTIPO_PAGO.Name = "cboTIPO_PAGO";
            this.cboTIPO_PAGO.Size = new System.Drawing.Size(147, 33);
            this.cboTIPO_PAGO.TabIndex = 33;
            this.cboTIPO_PAGO.SelectedIndexChanged += new System.EventHandler(this.cboTIPO_PAGO_SelectionChangeCommitted);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.label12.Location = new System.Drawing.Point(54, 112);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 36);
            this.label12.TabIndex = 43;
            this.label12.Text = "Pago 2:";
            // 
            // txtOBSERVACIONES
            // 
            this.txtOBSERVACIONES.AutoSize = false;
            this.txtOBSERVACIONES.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOBSERVACIONES.Location = new System.Drawing.Point(13, 299);
            this.txtOBSERVACIONES.MaxLength = 255;
            this.txtOBSERVACIONES.Multiline = true;
            this.txtOBSERVACIONES.Name = "txtOBSERVACIONES";
            this.txtOBSERVACIONES.Size = new System.Drawing.Size(483, 40);
            this.txtOBSERVACIONES.TabIndex = 38;
            this.txtOBSERVACIONES.TabStop = false;
            // 
            // lblOBSERVACIONES
            // 
            this.lblOBSERVACIONES.Location = new System.Drawing.Point(13, 275);
            this.lblOBSERVACIONES.Name = "lblOBSERVACIONES";
            this.lblOBSERVACIONES.Size = new System.Drawing.Size(81, 18);
            this.lblOBSERVACIONES.TabIndex = 40;
            this.lblOBSERVACIONES.Text = "Observaciones:";
            // 
            // dtpFECHA_OPERACION
            // 
            this.dtpFECHA_OPERACION.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFECHA_OPERACION.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFECHA_OPERACION.Location = new System.Drawing.Point(5, 34);
            this.dtpFECHA_OPERACION.Name = "dtpFECHA_OPERACION";
            this.dtpFECHA_OPERACION.Size = new System.Drawing.Size(125, 20);
            this.dtpFECHA_OPERACION.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(5, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 18);
            this.label3.TabIndex = 38;
            this.label3.Text = "Fecha de operación (dd/mm/aaaa):";
            this.label3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCambio
            // 
            this.txtCambio.Enabled = false;
            this.txtCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.txtCambio.Location = new System.Drawing.Point(330, 204);
            this.txtCambio.Name = "txtCambio";
            this.txtCambio.Size = new System.Drawing.Size(166, 36);
            this.txtCambio.TabIndex = 36;
            this.txtCambio.TabStop = false;
            this.txtCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.label2.Location = new System.Drawing.Point(199, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 36);
            this.label2.TabIndex = 37;
            this.label2.Text = "Cambio:";
            this.label2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.txtEfectivo.ForeColor = System.Drawing.Color.Red;
            this.txtEfectivo.Location = new System.Drawing.Point(330, 66);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.NullText = "0";
            this.txtEfectivo.Size = new System.Drawing.Size(166, 36);
            this.txtEfectivo.TabIndex = 32;
            this.txtEfectivo.TabStop = false;
            this.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEfectivo.TextChanged += new System.EventHandler(this.txtEfectivo_TextChanged);
            this.txtEfectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEfectivo_KeyPress);
            this.txtEfectivo.Leave += new System.EventHandler(this.txtEfectivo_Leave);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.label1.Location = new System.Drawing.Point(123, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 36);
            this.label1.TabIndex = 35;
            this.label1.Text = "Pago Efectivo:";
            this.label1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(330, 24);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(166, 36);
            this.txtTotal.TabIndex = 34;
            this.txtTotal.TabStop = false;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.lblTotal.Location = new System.Drawing.Point(233, 24);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(81, 36);
            this.lblTotal.TabIndex = 33;
            this.lblTotal.Text = "Total:";
            this.lblTotal.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmVentasCobrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(518, 471);
            this.ControlBox = false;
            this.Controls.Add(this.radGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmVentasCobrar";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowInTaskbar = false;
            this.Text = "Cobro";
            this.Load += new System.EventHandler(this.frmCobrar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDigitos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNO_AUTORIZACION)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNO_AUTORIZACION)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOBSERVACIONES)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOBSERVACIONES)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCambio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEfectivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

       

       

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private System.Windows.Forms.CheckBox chkCREDITO;
        private Telerik.WinControls.UI.RadTextBox txtNO_AUTORIZACION;
        private Telerik.WinControls.UI.RadLabel lblNO_AUTORIZACION;
        private System.Windows.Forms.ComboBox cboTIPO_PAGO;
        private Telerik.WinControls.UI.RadLabel label12;
        private Telerik.WinControls.UI.RadTextBox txtOBSERVACIONES;
        private Telerik.WinControls.UI.RadLabel lblOBSERVACIONES;
        private System.Windows.Forms.DateTimePicker dtpFECHA_OPERACION;
        private Telerik.WinControls.UI.RadLabel label3;
        private Telerik.WinControls.UI.RadTextBox txtCambio;
        private Telerik.WinControls.UI.RadLabel label2;
        private Telerik.WinControls.UI.RadTextBox txtEfectivo;
        private Telerik.WinControls.UI.RadLabel label1;
        private Telerik.WinControls.UI.RadTextBox txtTotal;
        private Telerik.WinControls.UI.RadLabel lblTotal;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtDigitos;
        private Telerik.WinControls.UI.RadTextBox txtPago;
    }
}