namespace POSApp.Forms
{
    partial class frmVentasPOS
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
            this.txtUserName = new Telerik.WinControls.UI.RadTextBox();
            this.lblUserName = new Telerik.WinControls.UI.RadLabel();
            this.cboIdPOS = new System.Windows.Forms.ComboBox();
            this.lblIdPOS = new Telerik.WinControls.UI.RadLabel();
            this.lblStartAmount = new Telerik.WinControls.UI.RadLabel();
            this.txtStartAmount = new Telerik.WinControls.UI.RadTextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUserName
            // 
            this.txtUserName.Enabled = false;
            this.txtUserName.Location = new System.Drawing.Point(15, 25);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(228, 20);
            this.txtUserName.TabIndex = 11;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(12, 9);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(46, 13);
            this.lblUserName.TabIndex = 14;
            this.lblUserName.Text = "Usuario:";
            // 
            // cboIdPOS
            // 
            this.cboIdPOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIdPOS.FormattingEnabled = true;
            this.cboIdPOS.Items.AddRange(new object[] {
            "POS 1",
            "POS 2",
            "POS 3"});
            this.cboIdPOS.Location = new System.Drawing.Point(15, 64);
            this.cboIdPOS.Name = "cboIdPOS";
            this.cboIdPOS.Size = new System.Drawing.Size(228, 21);
            this.cboIdPOS.TabIndex = 12;
            // 
            // lblIdPOS
            // 
            this.lblIdPOS.AutoSize = true;
            this.lblIdPOS.Location = new System.Drawing.Point(12, 48);
            this.lblIdPOS.Name = "lblIdPOS";
            this.lblIdPOS.Size = new System.Drawing.Size(31, 13);
            this.lblIdPOS.TabIndex = 13;
            this.lblIdPOS.Text = "Caja:";
            // 
            // lblStartAmount
            // 
            this.lblStartAmount.AutoSize = true;
            this.lblStartAmount.Location = new System.Drawing.Point(15, 88);
            this.lblStartAmount.Name = "lblStartAmount";
            this.lblStartAmount.Size = new System.Drawing.Size(70, 13);
            this.lblStartAmount.TabIndex = 15;
            this.lblStartAmount.Text = "Monto Inicial:";
            // 
            // txtStartAmount
            // 
            this.txtStartAmount.Location = new System.Drawing.Point(18, 104);
            this.txtStartAmount.Name = "txtStartAmount";
            this.txtStartAmount.Size = new System.Drawing.Size(103, 20);
            this.txtStartAmount.TabIndex = 16;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::POS.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(162, 144);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 30);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCANCEL_Click);
            // 
            // btnOk
            // 
            this.btnOk.Image = global::POS.Properties.Resources.accept;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.Location = new System.Drawing.Point(77, 144);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(79, 30);
            this.btnOk.TabIndex = 18;
            this.btnOk.Text = "Aceptar";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmSalePOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 187);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtStartAmount);
            this.Controls.Add(this.lblStartAmount);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.cboIdPOS);
            this.Controls.Add(this.lblIdPOS);
            this.Name = "frmSalePOS";
            this.Text = "Abrir Caja";
            this.Load += new System.EventHandler(this.frmSalePOS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBox txtUserName;
        private Telerik.WinControls.UI.RadLabel lblUserName;
        private System.Windows.Forms.ComboBox cboIdPOS;
        private Telerik.WinControls.UI.RadLabel lblIdPOS;
        private Telerik.WinControls.UI.RadLabel lblStartAmount;
        private Telerik.WinControls.UI.RadTextBox txtStartAmount;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}