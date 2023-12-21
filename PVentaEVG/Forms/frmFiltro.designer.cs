namespace POSApp.Forms
{
    partial class frmFiltro
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtpFECHA_FIN = new System.Windows.Forms.DateTimePicker();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.dtpFECHA_INI = new System.Windows.Forms.DateTimePicker();
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.chkHoy = new System.Windows.Forms.CheckBox();
            this.chkFiltro = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::POS.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(163, 123);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 30);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::POS.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(84, 123);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 30);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Aceptar";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtpFECHA_FIN
            // 
            this.dtpFECHA_FIN.CustomFormat = "dd/MM/yyyy";
            this.dtpFECHA_FIN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFECHA_FIN.Location = new System.Drawing.Point(12, 97);
            this.dtpFECHA_FIN.Name = "dtpFECHA_FIN";
            this.dtpFECHA_FIN.Size = new System.Drawing.Size(229, 20);
            this.dtpFECHA_FIN.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Fecha final:";
            // 
            // dtpFECHA_INI
            // 
            this.dtpFECHA_INI.CustomFormat = "dd/MM/yyyy";
            this.dtpFECHA_INI.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFECHA_INI.Location = new System.Drawing.Point(12, 58);
            this.dtpFECHA_INI.Name = "dtpFECHA_INI";
            this.dtpFECHA_INI.Size = new System.Drawing.Size(229, 20);
            this.dtpFECHA_INI.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Fecha inicial:";
            // 
            // chkHoy
            // 
            this.chkHoy.AutoSize = true;
            this.chkHoy.Location = new System.Drawing.Point(125, 12);
            this.chkHoy.Name = "chkHoy";
            this.chkHoy.Size = new System.Drawing.Size(116, 17);
            this.chkHoy.TabIndex = 9;
            this.chkHoy.Text = "Información de hoy";
            this.chkHoy.UseVisualStyleBackColor = true;
            this.chkHoy.CheckedChanged += new System.EventHandler(this.chkHoy_CheckedChanged);
            // 
            // chkFiltro
            // 
            this.chkFiltro.AutoSize = true;
            this.chkFiltro.Location = new System.Drawing.Point(12, 12);
            this.chkFiltro.Name = "chkFiltro";
            this.chkFiltro.Size = new System.Drawing.Size(63, 17);
            this.chkFiltro.TabIndex = 8;
            this.chkFiltro.Text = "Sin filtro";
            this.chkFiltro.UseVisualStyleBackColor = true;
            this.chkFiltro.CheckedChanged += new System.EventHandler(this.chkFiltro_CheckedChanged);
            // 
            // frmFiltro
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 165);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpFECHA_FIN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFECHA_INI);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkHoy);
            this.Controls.Add(this.chkFiltro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmFiltro";
            this.ShowInTaskbar = false;
            this.Text = "Filtro";
            this.Load += new System.EventHandler(this.frmFiltro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtpFECHA_FIN;
        private Telerik.WinControls.UI.RadLabel label2;
        private System.Windows.Forms.DateTimePicker dtpFECHA_INI;
        private Telerik.WinControls.UI.RadLabel label1;
        private System.Windows.Forms.CheckBox chkHoy;
        private System.Windows.Forms.CheckBox chkFiltro;
    }
}