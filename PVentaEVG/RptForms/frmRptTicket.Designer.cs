namespace POSApp.Forms
{
    partial class frmRptTicket
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
            this.lblInfo = new Telerik.WinControls.UI.RadLabel();
            this.txtFECHA_FIN = new System.Windows.Forms.DateTimePicker();
            this.label3 = new Telerik.WinControls.UI.RadLabel();
            this.txtFECHA_INI = new System.Windows.Forms.DateTimePicker();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lvBuscaCliente = new POSDLL.Windows.Forms.PrintableListView();
            this.txtNOMBRE = new Telerik.WinControls.UI.RadTextBox();
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.label4 = new Telerik.WinControls.UI.RadLabel();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(7, 336);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(51, 13);
            this.lblInfo.TabIndex = 27;
            this.lblInfo.Text = "Registros";
            // 
            // txtFECHA_FIN
            // 
            this.txtFECHA_FIN.CustomFormat = "dd/MM/yyyy";
            this.txtFECHA_FIN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFECHA_FIN.Location = new System.Drawing.Point(111, 67);
            this.txtFECHA_FIN.Name = "txtFECHA_FIN";
            this.txtFECHA_FIN.Size = new System.Drawing.Size(94, 20);
            this.txtFECHA_FIN.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(108, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Fin:";
            // 
            // txtFECHA_INI
            // 
            this.txtFECHA_INI.CustomFormat = "dd/MM/yyyy";
            this.txtFECHA_INI.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFECHA_INI.Location = new System.Drawing.Point(11, 67);
            this.txtFECHA_INI.Name = "txtFECHA_INI";
            this.txtFECHA_INI.Size = new System.Drawing.Size(94, 20);
            this.txtFECHA_INI.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Inicio:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Image = global::POS.Properties.Resources.zoom;
            this.btnBuscar.Location = new System.Drawing.Point(556, 20);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(33, 23);
            this.btnBuscar.TabIndex = 22;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lvBuscaCliente
            // 
            this.lvBuscaCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvBuscaCliente.FitToPage = false;
            this.lvBuscaCliente.FullRowSelect = true;
            this.lvBuscaCliente.GridLines = true;
            this.lvBuscaCliente.HideSelection = false;
            this.lvBuscaCliente.Location = new System.Drawing.Point(7, 93);
            this.lvBuscaCliente.Name = "lvBuscaCliente";
            this.lvBuscaCliente.Size = new System.Drawing.Size(582, 240);
            this.lvBuscaCliente.TabIndex = 21;
            this.lvBuscaCliente.Title = "";
            this.lvBuscaCliente.UseCompatibleStateImageBehavior = false;
            // 
            // txtNOMBRE
            // 
            this.txtNOMBRE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNOMBRE.Location = new System.Drawing.Point(10, 23);
            this.txtNOMBRE.Name = "txtNOMBRE";
            this.txtNOMBRE.Size = new System.Drawing.Size(540, 20);
            this.txtNOMBRE.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Nombre del cliente:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(356, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(228, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "De doble clic sobre el ticket que desea imprimir";
            // 
            // frmRptTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 356);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.txtFECHA_FIN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFECHA_INI);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lvBuscaCliente);
            this.Controls.Add(this.txtNOMBRE);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "frmRptTicket";
            this.Text = "Imprimir Ticket";
            this.Load += new System.EventHandler(this.frmRptTicket_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblInfo;
        private System.Windows.Forms.DateTimePicker txtFECHA_FIN;
        private Telerik.WinControls.UI.RadLabel label3;
        private System.Windows.Forms.DateTimePicker txtFECHA_INI;
        private Telerik.WinControls.UI.RadLabel label2;
        private System.Windows.Forms.Button btnBuscar;
        private POSDLL.Windows.Forms.PrintableListView lvBuscaCliente;
        private Telerik.WinControls.UI.RadTextBox txtNOMBRE;
        private Telerik.WinControls.UI.RadLabel label1;
        private Telerik.WinControls.UI.RadLabel label4;
    }
}