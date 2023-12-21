namespace POSApp.Forms
{
    partial class frmBuscaProveedor
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
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.txtDESC_PROVEEDOR = new Telerik.WinControls.UI.RadTextBox();
            this.lvBuscaProveedor = new POSDLL.Windows.Forms.PrintableListView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblInfo = new Telerik.WinControls.UI.RadLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre del proveedor:";
            // 
            // txtDESC_PROVEEDOR
            // 
            this.txtDESC_PROVEEDOR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDESC_PROVEEDOR.Location = new System.Drawing.Point(15, 25);
            this.txtDESC_PROVEEDOR.Name = "txtDESC_PROVEEDOR";
            this.txtDESC_PROVEEDOR.Size = new System.Drawing.Size(604, 20);
            this.txtDESC_PROVEEDOR.TabIndex = 1;
            this.txtDESC_PROVEEDOR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDESC_PROVEEDOR_KeyPress);
            // 
            // lvBuscaProveedor
            // 
            this.lvBuscaProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvBuscaProveedor.FitToPage = false;
            this.lvBuscaProveedor.FullRowSelect = true;
            this.lvBuscaProveedor.GridLines = true;
            this.lvBuscaProveedor.HideSelection = false;
            this.lvBuscaProveedor.Location = new System.Drawing.Point(12, 51);
            this.lvBuscaProveedor.Name = "lvBuscaProveedor";
            this.lvBuscaProveedor.Size = new System.Drawing.Size(646, 188);
            this.lvBuscaProveedor.TabIndex = 2;
            this.lvBuscaProveedor.Title = "";
            this.lvBuscaProveedor.UseCompatibleStateImageBehavior = false;
            this.lvBuscaProveedor.DoubleClick += new System.EventHandler(this.lvBuscaProveedor_DoubleClick);
            this.lvBuscaProveedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvBuscaProveedor_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Image = global::POS.Properties.Resources.zoom;
            this.btnBuscar.Location = new System.Drawing.Point(625, 25);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(33, 23);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(12, 242);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(51, 13);
            this.lblInfo.TabIndex = 6;
            this.lblInfo.Text = "Registros";
            // 
            // frmBuscaProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 267);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lvBuscaProveedor);
            this.Controls.Add(this.txtDESC_PROVEEDOR);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmBuscaProveedor";
            this.ShowInTaskbar = false;
            this.Text = "Buscar proveedor:";
            this.Load += new System.EventHandler(this.frmBuscaProveedor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

        

        #endregion

        private Telerik.WinControls.UI.RadLabel label1;
        private Telerik.WinControls.UI.RadTextBox txtDESC_PROVEEDOR;
        private POSDLL.Windows.Forms.PrintableListView lvBuscaProveedor;
        private System.Windows.Forms.Button btnBuscar;
        private Telerik.WinControls.UI.RadLabel lblInfo;
    }
}