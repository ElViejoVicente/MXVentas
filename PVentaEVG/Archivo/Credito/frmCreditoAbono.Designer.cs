namespace POSApp.Forms
{
    partial class frmCreditoAbono
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
            this.txtIMPORTE = new Telerik.WinControls.UI.RadTextBox();
            this.btnCANCEL = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.cboIdPOS = new System.Windows.Forms.ComboBox();
            this.lblIdPOS = new Telerik.WinControls.UI.RadLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cantidad a Abonar:";
            // 
            // txtIMPORTE
            // 
            this.txtIMPORTE.Location = new System.Drawing.Point(15, 69);
            this.txtIMPORTE.Name = "txtIMPORTE";
            this.txtIMPORTE.Size = new System.Drawing.Size(100, 20);
            this.txtIMPORTE.TabIndex = 1;
            // 
            // btnCANCEL
            // 
            this.btnCANCEL.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCANCEL.Image = global::POS.Properties.Resources.cancel;
            this.btnCANCEL.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCANCEL.Location = new System.Drawing.Point(203, 98);
            this.btnCANCEL.Name = "btnCANCEL";
            this.btnCANCEL.Size = new System.Drawing.Size(75, 30);
            this.btnCANCEL.TabIndex = 11;
            this.btnCANCEL.Text = "Cancelar";
            this.btnCANCEL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCANCEL.UseVisualStyleBackColor = true;
            this.btnCANCEL.Click += new System.EventHandler(this.btnCANCEL_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = global::POS.Properties.Resources.accept;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.Location = new System.Drawing.Point(121, 98);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "Aceptar";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cboIdPOS
            // 
            this.cboIdPOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIdPOS.FormattingEnabled = true;
            this.cboIdPOS.Location = new System.Drawing.Point(15, 26);
            this.cboIdPOS.Name = "cboIdPOS";
            this.cboIdPOS.Size = new System.Drawing.Size(263, 21);
            this.cboIdPOS.TabIndex = 91;
            // 
            // lblIdPOS
            // 
            this.lblIdPOS.AutoSize = true;
            this.lblIdPOS.Location = new System.Drawing.Point(12, 9);
            this.lblIdPOS.Name = "lblIdPOS";
            this.lblIdPOS.Size = new System.Drawing.Size(31, 13);
            this.lblIdPOS.TabIndex = 90;
            this.lblIdPOS.Text = "Caja:";
            // 
            // frmCreditoAbono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCANCEL;
            this.ClientSize = new System.Drawing.Size(289, 147);
            this.Controls.Add(this.cboIdPOS);
            this.Controls.Add(this.lblIdPOS);
            this.Controls.Add(this.btnCANCEL);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtIMPORTE);
            this.Controls.Add(this.label1);
            this.Name = "frmCreditoAbono";
            this.Text = "Abono";
            this.Load += new System.EventHandler(this.frmCreditoAbono_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel label1;
        private Telerik.WinControls.UI.RadTextBox txtIMPORTE;
        private System.Windows.Forms.Button btnCANCEL;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cboIdPOS;
        private Telerik.WinControls.UI.RadLabel lblIdPOS;
    }
}