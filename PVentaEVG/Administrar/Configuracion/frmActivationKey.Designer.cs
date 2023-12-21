namespace POSApp.Forms
{
    partial class frmActivationKey
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
            this.btnOK = new System.Windows.Forms.Button();
            this.txtCurrentKey = new Telerik.WinControls.UI.RadTextBox();
            this.lblCLAVE_CANCELACION_VENTA = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtCadenaSol = new Telerik.WinControls.UI.RadTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblCliente = new Telerik.WinControls.UI.RadLabel();
            this.txtCliente = new Telerik.WinControls.UI.RadTextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCLAVE_CANCELACION_VENTA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCadenaSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::POS.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(143, 343);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = global::POS.Properties.Resources.accept;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.Location = new System.Drawing.Point(61, 343);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(76, 30);
            this.btnOK.TabIndex = 22;
            this.btnOK.Text = "Aceptar";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtCurrentKey
            // 
            this.txtCurrentKey.AutoSize = false;
            this.txtCurrentKey.Location = new System.Drawing.Point(61, 272);
            this.txtCurrentKey.Multiline = true;
            this.txtCurrentKey.Name = "txtCurrentKey";
            this.txtCurrentKey.Size = new System.Drawing.Size(682, 65);
            this.txtCurrentKey.TabIndex = 21;
            // 
            // lblCLAVE_CANCELACION_VENTA
            // 
            this.lblCLAVE_CANCELACION_VENTA.Location = new System.Drawing.Point(61, 248);
            this.lblCLAVE_CANCELACION_VENTA.Name = "lblCLAVE_CANCELACION_VENTA";
            this.lblCLAVE_CANCELACION_VENTA.Size = new System.Drawing.Size(106, 18);
            this.lblCLAVE_CANCELACION_VENTA.TabIndex = 20;
            this.lblCLAVE_CANCELACION_VENTA.Text = "Clave de Activación:";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(61, 100);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(116, 18);
            this.radLabel1.TabIndex = 24;
            this.radLabel1.Text = "Cadena de Activacion:";
            // 
            // txtCadenaSol
            // 
            this.txtCadenaSol.AutoSize = false;
            this.txtCadenaSol.Location = new System.Drawing.Point(61, 124);
            this.txtCadenaSol.Multiline = true;
            this.txtCadenaSol.Name = "txtCadenaSol";
            this.txtCadenaSol.ReadOnly = true;
            this.txtCadenaSol.Size = new System.Drawing.Size(682, 68);
            this.txtCadenaSol.TabIndex = 25;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(668, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "Copiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblCliente
            // 
            this.lblCliente.Location = new System.Drawing.Point(61, 25);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(43, 18);
            this.lblCliente.TabIndex = 27;
            this.lblCliente.Text = "Cliente:";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(61, 49);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(682, 20);
            this.txtCliente.TabIndex = 26;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(668, 75);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 28;
            this.button2.Text = "Solicitar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmActivationKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 387);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtCadenaSol);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtCurrentKey);
            this.Controls.Add(this.lblCLAVE_CANCELACION_VENTA);
            this.Name = "frmActivationKey";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Clave de Activación";
            this.Load += new System.EventHandler(this.frmActivationKey_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCLAVE_CANCELACION_VENTA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCadenaSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private Telerik.WinControls.UI.RadTextBox txtCurrentKey;
        private Telerik.WinControls.UI.RadLabel lblCLAVE_CANCELACION_VENTA;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtCadenaSol;
        private System.Windows.Forms.Button button1;
        private Telerik.WinControls.UI.RadLabel lblCliente;
        private Telerik.WinControls.UI.RadTextBox txtCliente;
        private System.Windows.Forms.Button button2;
    }
}