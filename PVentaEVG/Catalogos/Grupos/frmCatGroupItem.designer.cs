namespace POSApp.Forms
{
    partial class frmCatGroupItem
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
            this.lblGroup = new Telerik.WinControls.UI.RadLabel();
            this.txtGRUPO = new Telerik.WinControls.UI.RadTextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkENABLED = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(12, 9);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(39, 13);
            this.lblGroup.TabIndex = 0;
            this.lblGroup.Text = "Grupo:";
            // 
            // txtGRUPO
            // 
            this.txtGRUPO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGRUPO.Location = new System.Drawing.Point(15, 26);
            this.txtGRUPO.Name = "txtGRUPO";
            this.txtGRUPO.Size = new System.Drawing.Size(362, 20);
            this.txtGRUPO.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Image = global::POS.Properties.Resources.accept;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(209, 52);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(81, 30);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Aceptar";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::POS.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(296, 52);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 30);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkENABLED
            // 
            this.chkENABLED.AutoSize = true;
            this.chkENABLED.Checked = true;
            this.chkENABLED.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkENABLED.Location = new System.Drawing.Point(15, 53);
            this.chkENABLED.Name = "chkENABLED";
            this.chkENABLED.Size = new System.Drawing.Size(73, 17);
            this.chkENABLED.TabIndex = 2;
            this.chkENABLED.Text = "Habilitado";
            this.chkENABLED.UseVisualStyleBackColor = true;
            // 
            // frmCatGroupItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(385, 90);
            this.Controls.Add(this.chkENABLED);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtGRUPO);
            this.Controls.Add(this.lblGroup);
            this.Name = "frmCatGroupItem";
            this.Text = "Grupo";
            this.Load += new System.EventHandler(this.frmCatGroupItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblGroup;
        private Telerik.WinControls.UI.RadTextBox txtGRUPO;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkENABLED;
    }
}