namespace POSApp.Forms
{
    partial class frmHistorialPagos
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
            this.barHistorialPagos = new System.Windows.Forms.ToolStrip();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.lvHistorialPagos = new POSDLL.Windows.Forms.PrintableListView();
            this.txtINT_MENSUAL = new Telerik.WinControls.UI.RadTextBox();
            this.label3 = new Telerik.WinControls.UI.RadLabel();
            this.txtCANTIDAD = new Telerik.WinControls.UI.RadTextBox();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.txtCLIENTE = new Telerik.WinControls.UI.RadTextBox();
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.btnClose2 = new System.Windows.Forms.Button();
            this.label4 = new Telerik.WinControls.UI.RadLabel();
            this.txtPAGADO = new Telerik.WinControls.UI.RadTextBox();
            this.label5 = new Telerik.WinControls.UI.RadLabel();
            this.txtRESTO = new Telerik.WinControls.UI.RadTextBox();
            this.barHistorialPagos.SuspendLayout();
            this.SuspendLayout();
            // 
            // barHistorialPagos
            // 
            this.barHistorialPagos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrint,
            this.btnClose});
            this.barHistorialPagos.Location = new System.Drawing.Point(0, 0);
            this.barHistorialPagos.Name = "barHistorialPagos";
            this.barHistorialPagos.Size = new System.Drawing.Size(417, 38);
            this.barHistorialPagos.TabIndex = 0;
            this.barHistorialPagos.Text = "toolStrip1";
            // 
            // btnPrint
            // 
          
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(57, 35);
            this.btnPrint.Text = "Imprimir";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
        
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(43, 35);
            this.btnClose.Text = "Cerrar";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lvHistorialPagos
            // 
            this.lvHistorialPagos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvHistorialPagos.FitToPage = false;
            this.lvHistorialPagos.FullRowSelect = true;
            this.lvHistorialPagos.GridLines = true;
            this.lvHistorialPagos.HideSelection = false;
            this.lvHistorialPagos.Location = new System.Drawing.Point(12, 151);
            this.lvHistorialPagos.Name = "lvHistorialPagos";
            this.lvHistorialPagos.Size = new System.Drawing.Size(393, 227);
            this.lvHistorialPagos.TabIndex = 1;
            this.lvHistorialPagos.Title = "";
            this.lvHistorialPagos.UseCompatibleStateImageBehavior = false;
            // 
            // txtINT_MENSUAL
            // 
            this.txtINT_MENSUAL.Location = new System.Drawing.Point(118, 106);
            this.txtINT_MENSUAL.Name = "txtINT_MENSUAL";
            this.txtINT_MENSUAL.ReadOnly = true;
            this.txtINT_MENSUAL.Size = new System.Drawing.Size(73, 20);
            this.txtINT_MENSUAL.TabIndex = 13;
            this.txtINT_MENSUAL.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Int. Mensual:";
            // 
            // txtCANTIDAD
            // 
            this.txtCANTIDAD.Location = new System.Drawing.Point(12, 106);
            this.txtCANTIDAD.Name = "txtCANTIDAD";
            this.txtCANTIDAD.ReadOnly = true;
            this.txtCANTIDAD.Size = new System.Drawing.Size(100, 20);
            this.txtCANTIDAD.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Cantidad a pagar:";
            // 
            // txtCLIENTE
            // 
            this.txtCLIENTE.Location = new System.Drawing.Point(12, 67);
            this.txtCLIENTE.Name = "txtCLIENTE";
            this.txtCLIENTE.ReadOnly = true;
            this.txtCLIENTE.Size = new System.Drawing.Size(391, 20);
            this.txtCLIENTE.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Cliente:";
            // 
            // btnClose2
            // 
            this.btnClose2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
           
            this.btnClose2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose2.Location = new System.Drawing.Point(342, 385);
            this.btnClose2.Name = "btnClose2";
            this.btnClose2.Size = new System.Drawing.Size(61, 25);
            this.btnClose2.TabIndex = 14;
            this.btnClose2.Text = "Cerrar";
            this.btnClose2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose2.UseVisualStyleBackColor = true;
            this.btnClose2.Click += new System.EventHandler(this.btnClose2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(194, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Pagado:";
            // 
            // txtPAGADO
            // 
            this.txtPAGADO.Location = new System.Drawing.Point(197, 106);
            this.txtPAGADO.Name = "txtPAGADO";
            this.txtPAGADO.ReadOnly = true;
            this.txtPAGADO.Size = new System.Drawing.Size(100, 20);
            this.txtPAGADO.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(300, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Resto:";
            // 
            // txtRESTO
            // 
            this.txtRESTO.Location = new System.Drawing.Point(303, 106);
            this.txtRESTO.Name = "txtRESTO";
            this.txtRESTO.ReadOnly = true;
            this.txtRESTO.Size = new System.Drawing.Size(100, 20);
            this.txtRESTO.TabIndex = 18;
            // 
            // frmHistorialPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose2;
            this.ClientSize = new System.Drawing.Size(415, 420);
            this.Controls.Add(this.txtRESTO);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPAGADO);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClose2);
            this.Controls.Add(this.txtINT_MENSUAL);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCANTIDAD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCLIENTE);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvHistorialPagos);
            this.Controls.Add(this.barHistorialPagos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimumSize = new System.Drawing.Size(423, 449);
            this.Name = "frmHistorialPagos";
            this.ShowInTaskbar = false;
            this.Text = "Historial de pagos";
            this.Load += new System.EventHandler(this.frmHistorialPagos_Load);
            this.barHistorialPagos.ResumeLayout(false);
            this.barHistorialPagos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip barHistorialPagos;
        private POSDLL.Windows.Forms.PrintableListView lvHistorialPagos;
        private Telerik.WinControls.UI.RadTextBox txtINT_MENSUAL;
        private Telerik.WinControls.UI.RadLabel label3;
        private Telerik.WinControls.UI.RadTextBox txtCANTIDAD;
        private Telerik.WinControls.UI.RadLabel label2;
        private Telerik.WinControls.UI.RadTextBox txtCLIENTE;
        private Telerik.WinControls.UI.RadLabel label1;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.Button btnClose2;
        private Telerik.WinControls.UI.RadLabel label4;
        private Telerik.WinControls.UI.RadTextBox txtPAGADO;
        private Telerik.WinControls.UI.RadLabel label5;
        private Telerik.WinControls.UI.RadTextBox txtRESTO;
    }
}