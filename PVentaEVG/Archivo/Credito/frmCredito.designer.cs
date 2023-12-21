namespace POSApp.Forms
{
    partial class frmCredito
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
            this.txtCLIENTE = new Telerik.WinControls.UI.RadTextBox();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.txtCANTIDAD = new Telerik.WinControls.UI.RadTextBox();
            this.label4 = new Telerik.WinControls.UI.RadLabel();
            this.txtPAGO = new Telerik.WinControls.UI.RadTextBox();
            this.btnCANCEL = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre del cliente:";
            // 
            // txtCLIENTE
            // 
            this.txtCLIENTE.Location = new System.Drawing.Point(12, 25);
            this.txtCLIENTE.Name = "txtCLIENTE";
            this.txtCLIENTE.ReadOnly = true;
            this.txtCLIENTE.Size = new System.Drawing.Size(268, 20);
            this.txtCLIENTE.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cantidad a pagar:";
            // 
            // txtCANTIDAD
            // 
            this.txtCANTIDAD.Location = new System.Drawing.Point(12, 64);
            this.txtCANTIDAD.Name = "txtCANTIDAD";
            this.txtCANTIDAD.ReadOnly = true;
            this.txtCANTIDAD.Size = new System.Drawing.Size(100, 20);
            this.txtCANTIDAD.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Primer pago:";
            // 
            // txtPAGO
            // 
            this.txtPAGO.Location = new System.Drawing.Point(15, 103);
            this.txtPAGO.Name = "txtPAGO";
            this.txtPAGO.Size = new System.Drawing.Size(100, 20);
            this.txtPAGO.TabIndex = 7;
            // 
            // btnCANCEL
            // 
            this.btnCANCEL.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCANCEL.Image = global::POS.Properties.Resources.cancel;
            this.btnCANCEL.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCANCEL.Location = new System.Drawing.Point(204, 134);
            this.btnCANCEL.Name = "btnCANCEL";
            this.btnCANCEL.Size = new System.Drawing.Size(75, 30);
            this.btnCANCEL.TabIndex = 9;
            this.btnCANCEL.Text = "Cancelar";
            this.btnCANCEL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCANCEL.UseVisualStyleBackColor = true;
            this.btnCANCEL.Click += new System.EventHandler(this.btnCANCEL_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = global::POS.Properties.Resources.accept;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.Location = new System.Drawing.Point(127, 134);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(71, 30);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "Aceptar";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCANCEL;
            this.ClientSize = new System.Drawing.Size(292, 174);
            this.ControlBox = false;
            this.Controls.Add(this.btnCANCEL);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtPAGO);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCANTIDAD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCLIENTE);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmCredito";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.frmCredito_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel label1;
        private Telerik.WinControls.UI.RadTextBox txtCLIENTE;
        private Telerik.WinControls.UI.RadLabel label2;
        private Telerik.WinControls.UI.RadTextBox txtCANTIDAD;
        private Telerik.WinControls.UI.RadLabel label4;
        private Telerik.WinControls.UI.RadTextBox txtPAGO;
        private System.Windows.Forms.Button btnCANCEL;
        private System.Windows.Forms.Button btnOK;
    }
}