namespace POSApp.Forms
{
    partial class frmBuscaEmpleado
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
            this.lvEmpleados = new POSDLL.Windows.Forms.PrintableListView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtNOMBRE = new Telerik.WinControls.UI.RadTextBox();
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.lblInfo = new Telerik.WinControls.UI.RadLabel();
            this.SuspendLayout();
            // 
            // lvEmpleados
            // 
            this.lvEmpleados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvEmpleados.FitToPage = false;
            this.lvEmpleados.FullRowSelect = true;
            this.lvEmpleados.GridLines = true;
            this.lvEmpleados.HideSelection = false;
            this.lvEmpleados.Location = new System.Drawing.Point(12, 52);
            this.lvEmpleados.Name = "lvEmpleados";
            this.lvEmpleados.Size = new System.Drawing.Size(632, 213);
            this.lvEmpleados.TabIndex = 7;
            this.lvEmpleados.Title = "";
            this.lvEmpleados.UseCompatibleStateImageBehavior = false;
            this.lvEmpleados.DoubleClick += new System.EventHandler(this.lvEmpleados_DoubleClick);
            this.lvEmpleados.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvEmpleados_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Image = global::POS.Properties.Resources.zoom;
            this.btnBuscar.Location = new System.Drawing.Point(611, 23);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(33, 23);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtNOMBRE
            // 
            this.txtNOMBRE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNOMBRE.Location = new System.Drawing.Point(12, 26);
            this.txtNOMBRE.Name = "txtNOMBRE";
            this.txtNOMBRE.Size = new System.Drawing.Size(593, 20);
            this.txtNOMBRE.TabIndex = 5;
            this.txtNOMBRE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNOMBRE_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nombre del empleado:";
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(13, 268);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(51, 13);
            this.lblInfo.TabIndex = 8;
            this.lblInfo.Text = "Registros";
            // 
            // frmBuscaEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 293);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lvEmpleados);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtNOMBRE);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmBuscaEmpleado";
            this.ShowInTaskbar = false;
            this.Text = "Buscar empleado";
            this.Load += new System.EventHandler(this.frmBuscaEmpleado_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

       

        #endregion

        private POSDLL.Windows.Forms.PrintableListView lvEmpleados;
        private System.Windows.Forms.Button btnBuscar;
        private Telerik.WinControls.UI.RadTextBox txtNOMBRE;
        private Telerik.WinControls.UI.RadLabel label1;
        private Telerik.WinControls.UI.RadLabel lblInfo;
    }
}