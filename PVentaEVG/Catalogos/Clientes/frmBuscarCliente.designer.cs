namespace POSApp.Forms
{
    partial class frmBuscarCliente
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
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lvBuscaCliente = new POSDLL.Windows.Forms.PrintableListView();
            this.txtNOMBRE = new Telerik.WinControls.UI.RadTextBox();
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.lblInfo = new Telerik.WinControls.UI.RadLabel();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Image = global::POS.Properties.Resources.zoom;
            this.btnBuscar.Location = new System.Drawing.Point(561, 26);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(33, 23);
            this.btnBuscar.TabIndex = 9;
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
            this.lvBuscaCliente.Location = new System.Drawing.Point(12, 55);
            this.lvBuscaCliente.Name = "lvBuscaCliente";
            this.lvBuscaCliente.Size = new System.Drawing.Size(582, 188);
            this.lvBuscaCliente.TabIndex = 8;
            this.lvBuscaCliente.Title = "";
            this.lvBuscaCliente.UseCompatibleStateImageBehavior = false;
            this.lvBuscaCliente.DoubleClick += new System.EventHandler(this.lvBuscaCliente_DoubleClick);
            this.lvBuscaCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvBuscaCliente_KeyPress);
            // 
            // txtNOMBRE
            // 
            this.txtNOMBRE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNOMBRE.Location = new System.Drawing.Point(15, 29);
            this.txtNOMBRE.Name = "txtNOMBRE";
            this.txtNOMBRE.Size = new System.Drawing.Size(540, 20);
            this.txtNOMBRE.TabIndex = 7;
            this.txtNOMBRE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNOMBRE_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nombre del cliente:";
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(12, 246);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(51, 13);
            this.lblInfo.TabIndex = 10;
            this.lblInfo.Text = "Registros";
            // 
            // frmBuscarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 271);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lvBuscaCliente);
            this.Controls.Add(this.txtNOMBRE);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmBuscarCliente";
            this.ShowInTaskbar = false;
            this.Text = "Buscar cliente";
            this.Load += new System.EventHandler(this.frmBuscarCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void lvBuscaCliente_DoubleClick(object sender, System.EventArgs e)
        {
            Cliente();
        }

        void lvBuscaCliente_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            Cliente();
        }

        

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private POSDLL.Windows.Forms.PrintableListView lvBuscaCliente;
        private Telerik.WinControls.UI.RadTextBox txtNOMBRE;
        private Telerik.WinControls.UI.RadLabel label1;
        private Telerik.WinControls.UI.RadLabel lblInfo;
    }
}