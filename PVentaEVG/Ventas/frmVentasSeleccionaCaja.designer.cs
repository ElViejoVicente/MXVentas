namespace POSApp.Forms
{
    partial class frmVentasSeleccionaCaja
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
            this.btnCANCEL = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblID_CAJA = new Telerik.WinControls.UI.RadLabel();
            this.cboID_CAJA = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCANCEL
            // 
            this.btnCANCEL.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCANCEL.Image = global::POS.Properties.Resources.cancel;
            this.btnCANCEL.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCANCEL.Location = new System.Drawing.Point(215, 52);
            this.btnCANCEL.Name = "btnCANCEL";
            this.btnCANCEL.Size = new System.Drawing.Size(81, 30);
            this.btnCANCEL.TabIndex = 7;
            this.btnCANCEL.Text = "Cancelar";
            this.btnCANCEL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCANCEL.UseVisualStyleBackColor = true;
            this.btnCANCEL.Click += new System.EventHandler(this.btnCANCEL_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = global::POS.Properties.Resources.accept;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.Location = new System.Drawing.Point(137, 52);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(72, 30);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "Aceptar";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblID_CAJA
            // 
            this.lblID_CAJA.AutoSize = true;
            this.lblID_CAJA.Location = new System.Drawing.Point(12, 9);
            this.lblID_CAJA.Name = "lblID_CAJA";
            this.lblID_CAJA.Size = new System.Drawing.Size(110, 13);
            this.lblID_CAJA.TabIndex = 8;
            this.lblID_CAJA.Text = "Seleccione una CAJA";
            // 
            // cboID_CAJA
            // 
            this.cboID_CAJA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboID_CAJA.FormattingEnabled = true;
            this.cboID_CAJA.Items.AddRange(new object[] {
            "POS 1",
            "POS 2",
            "POS 3"});
            this.cboID_CAJA.Location = new System.Drawing.Point(12, 25);
            this.cboID_CAJA.Name = "cboID_CAJA";
            this.cboID_CAJA.Size = new System.Drawing.Size(284, 21);
            this.cboID_CAJA.TabIndex = 9;
            // 
            // frmSeleccionaCaja
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCANCEL;
            this.ClientSize = new System.Drawing.Size(306, 92);
            this.Controls.Add(this.cboID_CAJA);
            this.Controls.Add(this.lblID_CAJA);
            this.Controls.Add(this.btnCANCEL);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmSeleccionaCaja";
            this.ShowInTaskbar = false;
            this.Text = "Seleccionar punto de venta";
            this.Load += new System.EventHandler(this.frmSeleccionaCaja_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCANCEL;
        private System.Windows.Forms.Button btnOK;
        private Telerik.WinControls.UI.RadLabel lblID_CAJA;
        private System.Windows.Forms.ComboBox cboID_CAJA;
    }
}