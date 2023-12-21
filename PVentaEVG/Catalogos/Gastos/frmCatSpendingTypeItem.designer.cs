namespace POSApp.Forms
{
    partial class frmCatSpendingTypeItem
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
            this.chkENABLED = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtSPENDING_TYPE = new Telerik.WinControls.UI.RadTextBox();
            this.lblSpendingType = new Telerik.WinControls.UI.RadLabel();
            this.SuspendLayout();
            // 
            // chkENABLED
            // 
            this.chkENABLED.AutoSize = true;
            this.chkENABLED.Location = new System.Drawing.Point(15, 53);
            this.chkENABLED.Name = "chkENABLED";
            this.chkENABLED.Size = new System.Drawing.Size(73, 17);
            this.chkENABLED.TabIndex = 7;
            this.chkENABLED.Text = "Habilitado";
            this.chkENABLED.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::POS.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(296, 52);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 30);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Image = global::POS.Properties.Resources.accept;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(209, 52);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(81, 30);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "Aceptar";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtSPENDING_TYPE
            // 
            this.txtSPENDING_TYPE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSPENDING_TYPE.Location = new System.Drawing.Point(15, 26);
            this.txtSPENDING_TYPE.Name = "txtSPENDING_TYPE";
            this.txtSPENDING_TYPE.Size = new System.Drawing.Size(362, 20);
            this.txtSPENDING_TYPE.TabIndex = 6;
            // 
            // lblSpendingType
            // 
            this.lblSpendingType.AutoSize = true;
            this.lblSpendingType.Location = new System.Drawing.Point(12, 9);
            this.lblSpendingType.Name = "lblSpendingType";
            this.lblSpendingType.Size = new System.Drawing.Size(77, 13);
            this.lblSpendingType.TabIndex = 5;
            this.lblSpendingType.Text = "Tipo de Gasto:";
            // 
            // frmCatSpendingTypeItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(385, 90);
            this.Controls.Add(this.chkENABLED);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtSPENDING_TYPE);
            this.Controls.Add(this.lblSpendingType);
            this.Name = "frmCatSpendingTypeItem";
            this.Text = "CatSpendingTypeItem";
            this.Load += new System.EventHandler(this.frmCatSpendingTypeItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkENABLED;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private Telerik.WinControls.UI.RadTextBox txtSPENDING_TYPE;
        private Telerik.WinControls.UI.RadLabel lblSpendingType;
    }
}