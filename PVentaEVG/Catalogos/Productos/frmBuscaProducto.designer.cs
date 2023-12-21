namespace POSApp.Forms
{
    partial class frmBuscaProducto
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
            this.txtDESC_PRODUCTO = new Telerik.WinControls.UI.RadTextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lvProductos = new POSDLL.Windows.Forms.PrintableListView();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.cboCOLMUNAS = new System.Windows.Forms.ComboBox();
            this.cboORDER = new System.Windows.Forms.ComboBox();
            this.cboORDENAR = new System.Windows.Forms.ComboBox();
            this.label3 = new Telerik.WinControls.UI.RadLabel();
            this.lblInfo = new Telerik.WinControls.UI.RadLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Palabra a buscar:";
            // 
            // txtDESC_PRODUCTO
            // 
            this.txtDESC_PRODUCTO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDESC_PRODUCTO.Location = new System.Drawing.Point(15, 65);
            this.txtDESC_PRODUCTO.Name = "txtDESC_PRODUCTO";
            this.txtDESC_PRODUCTO.Size = new System.Drawing.Size(356, 20);
            this.txtDESC_PRODUCTO.TabIndex = 1;
            this.txtDESC_PRODUCTO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDESC_PRODUCTO_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Image = global::POS.Properties.Resources.zoom;
            this.btnBuscar.Location = new System.Drawing.Point(641, 62);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(33, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lvProductos
            // 
            this.lvProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvProductos.FitToPage = false;
            this.lvProductos.FullRowSelect = true;
            this.lvProductos.GridLines = true;
            this.lvProductos.HideSelection = false;
            this.lvProductos.Location = new System.Drawing.Point(15, 91);
            this.lvProductos.Name = "lvProductos";
            this.lvProductos.Size = new System.Drawing.Size(735, 237);
            this.lvProductos.TabIndex = 3;
            this.lvProductos.Title = "";
            this.lvProductos.UseCompatibleStateImageBehavior = false;
            this.lvProductos.DoubleClick += new System.EventHandler(this.lvProductos_DoubleClick);
            this.lvProductos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvProductos_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Buscar por:";
            // 
            // cboCOLMUNAS
            // 
            this.cboCOLMUNAS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCOLMUNAS.FormattingEnabled = true;
            this.cboCOLMUNAS.Location = new System.Drawing.Point(15, 25);
            this.cboCOLMUNAS.Name = "cboCOLMUNAS";
            this.cboCOLMUNAS.Size = new System.Drawing.Size(254, 21);
            this.cboCOLMUNAS.TabIndex = 5;
            // 
            // cboORDER
            // 
            this.cboORDER.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboORDER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboORDER.FormattingEnabled = true;
            this.cboORDER.Items.AddRange(new object[] {
            "Ascendente",
            "Descendente"});
            this.cboORDER.Location = new System.Drawing.Point(510, 64);
            this.cboORDER.Name = "cboORDER";
            this.cboORDER.Size = new System.Drawing.Size(125, 21);
            this.cboORDER.TabIndex = 21;
            this.cboORDER.SelectedIndexChanged += new System.EventHandler(this.cboORDER_SelectedIndexChanged);
            // 
            // cboORDENAR
            // 
            this.cboORDENAR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboORDENAR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboORDENAR.FormattingEnabled = true;
            this.cboORDENAR.Items.AddRange(new object[] {
            "Clave",
            "Nombre del Artículo",
            "Marca",
            "Grupo"});
            this.cboORDENAR.Location = new System.Drawing.Point(380, 64);
            this.cboORDENAR.Name = "cboORDENAR";
            this.cboORDENAR.Size = new System.Drawing.Size(124, 21);
            this.cboORDENAR.TabIndex = 20;
            this.cboORDENAR.SelectedIndexChanged += new System.EventHandler(this.cboORDENAR_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(377, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Ordenar por:";
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(15, 331);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(51, 13);
            this.lblInfo.TabIndex = 22;
            this.lblInfo.Text = "Registros";
            // 
            // frmBuscaProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 356);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.cboORDER);
            this.Controls.Add(this.cboORDENAR);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboCOLMUNAS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvProductos);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtDESC_PRODUCTO);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(666, 382);
            this.Name = "frmBuscaProducto";
            this.ShowInTaskbar = false;
            this.Text = "Buscar artículo";
            this.Load += new System.EventHandler(this.frmBuscaProducto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private Telerik.WinControls.UI.RadLabel label1;
        private Telerik.WinControls.UI.RadTextBox txtDESC_PRODUCTO;
        private System.Windows.Forms.Button btnBuscar;
        private POSDLL.Windows.Forms.PrintableListView lvProductos;
        private Telerik.WinControls.UI.RadLabel label2;
        private System.Windows.Forms.ComboBox cboCOLMUNAS;
        private System.Windows.Forms.ComboBox cboORDER;
        private System.Windows.Forms.ComboBox cboORDENAR;
        private Telerik.WinControls.UI.RadLabel label3;
        private Telerik.WinControls.UI.RadLabel lblInfo;
    }
}