namespace POSApp.Forms
{
    partial class frmGasto
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
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.cboID_TIPO_GASTO = new System.Windows.Forms.ComboBox();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.dtpFECHA_GASTO = new System.Windows.Forms.DateTimePicker();
            this.label3 = new Telerik.WinControls.UI.RadLabel();
            this.txtIMPORTE = new Telerik.WinControls.UI.RadTextBox();
            this.label4 = new Telerik.WinControls.UI.RadLabel();
            this.txtOBSERVACIONES = new Telerik.WinControls.UI.RadTextBox();
            this.btnCANCEL = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo de pago:";
            // 
            // cboID_TIPO_GASTO
            // 
            this.cboID_TIPO_GASTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboID_TIPO_GASTO.FormattingEnabled = true;
            this.cboID_TIPO_GASTO.Location = new System.Drawing.Point(16, 30);
            this.cboID_TIPO_GASTO.Name = "cboID_TIPO_GASTO";
            this.cboID_TIPO_GASTO.Size = new System.Drawing.Size(256, 21);
            this.cboID_TIPO_GASTO.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha del Gasto:";
            // 
            // dtpFECHA_GASTO
            // 
            this.dtpFECHA_GASTO.CustomFormat = "dd/MM/yyyy HH:MM";
            this.dtpFECHA_GASTO.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFECHA_GASTO.Location = new System.Drawing.Point(16, 74);
            this.dtpFECHA_GASTO.Name = "dtpFECHA_GASTO";
            this.dtpFECHA_GASTO.Size = new System.Drawing.Size(169, 20);
            this.dtpFECHA_GASTO.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Importe:";
            // 
            // txtIMPORTE
            // 
            this.txtIMPORTE.Location = new System.Drawing.Point(16, 118);
            this.txtIMPORTE.Name = "txtIMPORTE";
            this.txtIMPORTE.Size = new System.Drawing.Size(100, 20);
            this.txtIMPORTE.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Observaciones:";
            // 
            // txtOBSERVACIONES
            // 
            this.txtOBSERVACIONES.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOBSERVACIONES.Location = new System.Drawing.Point(16, 162);
            this.txtOBSERVACIONES.Multiline = true;
            this.txtOBSERVACIONES.Name = "txtOBSERVACIONES";
            this.txtOBSERVACIONES.Size = new System.Drawing.Size(256, 75);
            this.txtOBSERVACIONES.TabIndex = 9;
            // 
            // btnCANCEL
            // 
            this.btnCANCEL.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCANCEL.Image = global::POS.Properties.Resources.cancel;
            this.btnCANCEL.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCANCEL.Location = new System.Drawing.Point(191, 243);
            this.btnCANCEL.Name = "btnCANCEL";
            this.btnCANCEL.Size = new System.Drawing.Size(81, 30);
            this.btnCANCEL.TabIndex = 11;
            this.btnCANCEL.Text = "Cancelar";
            this.btnCANCEL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCANCEL.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Image = global::POS.Properties.Resources.accept;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.Location = new System.Drawing.Point(109, 243);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(76, 30);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "Aceptar";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmGasto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 285);
            this.Controls.Add(this.btnCANCEL);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtOBSERVACIONES);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIMPORTE);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpFECHA_GASTO);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboID_TIPO_GASTO);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmGasto";
            this.ShowInTaskbar = false;
            this.Text = "Gasto";
            this.Load += new System.EventHandler(this.frmGasto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel label1;
        private System.Windows.Forms.ComboBox cboID_TIPO_GASTO;
        private Telerik.WinControls.UI.RadLabel label2;
        private System.Windows.Forms.DateTimePicker dtpFECHA_GASTO;
        private Telerik.WinControls.UI.RadLabel label3;
        private Telerik.WinControls.UI.RadTextBox txtIMPORTE;
        private Telerik.WinControls.UI.RadLabel label4;
        private Telerik.WinControls.UI.RadTextBox txtOBSERVACIONES;
        private System.Windows.Forms.Button btnCANCEL;
        private System.Windows.Forms.Button btnOK;
    }
}