namespace POSApp.Forms
{
    partial class frmCreditoAbonoMultiple
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
            this.lblDatos = new Telerik.WinControls.UI.RadLabel();
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.txtIMPORTE = new Telerik.WinControls.UI.RadTextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cboIdPOS = new System.Windows.Forms.ComboBox();
            this.lblIdPOS = new Telerik.WinControls.UI.RadLabel();
            this.SuspendLayout();
            // 
            // lblDatos
            // 
            //this.lblDatos.TextAlign = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDatos.Location = new System.Drawing.Point(13, 13);
            this.lblDatos.Name = "lblDatos";
            this.lblDatos.Size = new System.Drawing.Size(347, 94);
            this.lblDatos.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Importe:";
            // 
            // txtIMPORTE
            // 
            this.txtIMPORTE.Location = new System.Drawing.Point(13, 165);
            this.txtIMPORTE.Name = "txtIMPORTE";
            this.txtIMPORTE.Size = new System.Drawing.Size(100, 20);
            this.txtIMPORTE.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.Image = global::POS.Properties.Resources.accept;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(188, 201);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(83, 30);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Aceptar";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::POS.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(277, 201);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 30);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cboIdPOS
            // 
            this.cboIdPOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIdPOS.FormattingEnabled = true;
            this.cboIdPOS.Location = new System.Drawing.Point(16, 124);
            this.cboIdPOS.Name = "cboIdPOS";
            this.cboIdPOS.Size = new System.Drawing.Size(344, 21);
            this.cboIdPOS.TabIndex = 91;
            // 
            // lblIdPOS
            // 
            this.lblIdPOS.AutoSize = true;
            this.lblIdPOS.Location = new System.Drawing.Point(13, 107);
            this.lblIdPOS.Name = "lblIdPOS";
            this.lblIdPOS.Size = new System.Drawing.Size(31, 13);
            this.lblIdPOS.TabIndex = 90;
            this.lblIdPOS.Text = "Caja:";
            // 
            // frmCreditoAbonoMultiple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 250);
            this.Controls.Add(this.cboIdPOS);
            this.Controls.Add(this.lblIdPOS);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtIMPORTE);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDatos);
            this.Name = "frmCreditoAbonoMultiple";
            this.Text = "Abonar";
            this.Load += new System.EventHandler(this.frmCreditoAbonoMultiple_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblDatos;
        private Telerik.WinControls.UI.RadLabel label1;
        private Telerik.WinControls.UI.RadTextBox txtIMPORTE;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cboIdPOS;
        private Telerik.WinControls.UI.RadLabel lblIdPOS;
    }
}