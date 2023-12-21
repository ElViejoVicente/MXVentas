namespace POSApp.Forms
{
    partial class frmCatAdjustTypeItem
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
            this.txtADJUST_TYPE = new Telerik.WinControls.UI.RadTextBox();
            this.lblAdjustType = new Telerik.WinControls.UI.RadLabel();
            this.SuspendLayout();
            // 
            // chkENABLED
            // 
            this.chkENABLED.AutoSize = true;
            this.chkENABLED.Checked = true;
            this.chkENABLED.CheckState = System.Windows.Forms.CheckState.Checked;
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
            // txtADJUST_TYPE
            // 
            this.txtADJUST_TYPE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtADJUST_TYPE.Location = new System.Drawing.Point(15, 26);
            this.txtADJUST_TYPE.Name = "txtADJUST_TYPE";
            this.txtADJUST_TYPE.Size = new System.Drawing.Size(362, 20);
            this.txtADJUST_TYPE.TabIndex = 6;
            // 
            // lblAdjustType
            // 
            this.lblAdjustType.AutoSize = true;
            this.lblAdjustType.Location = new System.Drawing.Point(12, 9);
            this.lblAdjustType.Name = "lblAdjustType";
            this.lblAdjustType.Size = new System.Drawing.Size(78, 13);
            this.lblAdjustType.TabIndex = 5;
            this.lblAdjustType.Text = "Tipo de Ajuste:";
            // 
            // frmCatAdjustTypeItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 90);
            this.Controls.Add(this.chkENABLED);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtADJUST_TYPE);
            this.Controls.Add(this.lblAdjustType);
            this.Name = "frmCatAdjustTypeItem";
            this.Text = "frmCatAdjustTypeItem";
            this.Load += new System.EventHandler(this.frmCatAdjustTypeItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkENABLED;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private Telerik.WinControls.UI.RadTextBox txtADJUST_TYPE;
        private Telerik.WinControls.UI.RadLabel lblAdjustType;
    }
}