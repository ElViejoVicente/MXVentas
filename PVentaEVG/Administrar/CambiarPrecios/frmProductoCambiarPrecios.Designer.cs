namespace POSApp.Forms
{
    partial class frmProductoCambiarPrecios
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
            this.cboID_GRUPO = new System.Windows.Forms.ComboBox();
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.txtPORC = new Telerik.WinControls.UI.RadTextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.chkGrupo = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cboID_GRUPO
            // 
            this.cboID_GRUPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboID_GRUPO.FormattingEnabled = true;
            this.cboID_GRUPO.Location = new System.Drawing.Point(15, 25);
            this.cboID_GRUPO.Name = "cboID_GRUPO";
            this.cboID_GRUPO.Size = new System.Drawing.Size(297, 21);
            this.cboID_GRUPO.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "%";
            // 
            // txtPORC
            // 
            this.txtPORC.Location = new System.Drawing.Point(18, 70);
            this.txtPORC.MaxLength = 5;
            this.txtPORC.Name = "txtPORC";
            this.txtPORC.Size = new System.Drawing.Size(100, 20);
            this.txtPORC.TabIndex = 24;
            this.txtPORC.Text = "0";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::POS.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(238, 79);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Image = global::POS.Properties.Resources.accept;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.Location = new System.Drawing.Point(160, 79);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(72, 30);
            this.btnOK.TabIndex = 25;
            this.btnOK.Text = "Aceptar";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // chkGrupo
            // 
            this.chkGrupo.AutoSize = true;
            this.chkGrupo.Checked = true;
            this.chkGrupo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGrupo.Location = new System.Drawing.Point(15, 2);
            this.chkGrupo.Name = "chkGrupo";
            this.chkGrupo.Size = new System.Drawing.Size(55, 17);
            this.chkGrupo.TabIndex = 27;
            this.chkGrupo.Text = "Grupo";
            this.chkGrupo.UseVisualStyleBackColor = true;
            this.chkGrupo.CheckedChanged += new System.EventHandler(this.chkGrupo_CheckedChanged);
            // 
            // frmProductoCambiarPrecios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(325, 121);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtPORC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboID_GRUPO);
            this.Controls.Add(this.chkGrupo);
            this.Name = "frmProductoCambiarPrecios";
            this.Text = "Cambiar precios";
            this.Load += new System.EventHandler(this.frmProductoCambiarPrecios_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboID_GRUPO;
        private Telerik.WinControls.UI.RadLabel label1;
        private Telerik.WinControls.UI.RadTextBox txtPORC;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox chkGrupo;
    }
}