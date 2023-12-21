namespace POSApp.Forms
{
    partial class frmUserRestorePass
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
            this.lblNEW_PASS = new Telerik.WinControls.UI.RadLabel();
            this.txtNEW_PASS = new Telerik.WinControls.UI.RadTextBox();
            this.lblRE_PASS = new Telerik.WinControls.UI.RadLabel();
            this.txtRE_PASS = new Telerik.WinControls.UI.RadTextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNEW_PASS
            // 
            this.lblNEW_PASS.AutoSize = true;
            this.lblNEW_PASS.Location = new System.Drawing.Point(12, 9);
            this.lblNEW_PASS.Name = "lblNEW_PASS";
            this.lblNEW_PASS.Size = new System.Drawing.Size(98, 13);
            this.lblNEW_PASS.TabIndex = 0;
            this.lblNEW_PASS.Text = "Nueva contraseña:";
            // 
            // txtNEW_PASS
            // 
            this.txtNEW_PASS.Location = new System.Drawing.Point(15, 25);
            this.txtNEW_PASS.Name = "txtNEW_PASS";
            this.txtNEW_PASS.PasswordChar = '*';
            this.txtNEW_PASS.Size = new System.Drawing.Size(222, 20);
            this.txtNEW_PASS.TabIndex = 1;
            // 
            // lblRE_PASS
            // 
            this.lblRE_PASS.AutoSize = true;
            this.lblRE_PASS.Location = new System.Drawing.Point(12, 48);
            this.lblRE_PASS.Name = "lblRE_PASS";
            this.lblRE_PASS.Size = new System.Drawing.Size(133, 13);
            this.lblRE_PASS.TabIndex = 2;
            this.lblRE_PASS.Text = "Repetir nueva contraseña:";
            // 
            // txtRE_PASS
            // 
            this.txtRE_PASS.Location = new System.Drawing.Point(15, 64);
            this.txtRE_PASS.Name = "txtRE_PASS";
            this.txtRE_PASS.PasswordChar = '*';
            this.txtRE_PASS.Size = new System.Drawing.Size(222, 20);
            this.txtRE_PASS.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Image = global::POS.Properties.Resources.accept;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.Location = new System.Drawing.Point(87, 95);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(72, 30);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "Accept";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::POS.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(165, 95);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmRestorePass
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(249, 137);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtRE_PASS);
            this.Controls.Add(this.lblRE_PASS);
            this.Controls.Add(this.txtNEW_PASS);
            this.Controls.Add(this.lblNEW_PASS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmRestorePass";
            this.ShowInTaskbar = false;
            this.Text = "Reestablecer contraseña:";
            this.Load += new System.EventHandler(this.frmRestorePass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblNEW_PASS;
        private Telerik.WinControls.UI.RadTextBox txtNEW_PASS;
        private Telerik.WinControls.UI.RadLabel lblRE_PASS;
        private Telerik.WinControls.UI.RadTextBox txtRE_PASS;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}