using POSDLL; using POSDLL.Windows.Forms; using POSDLL.Security; using POSDLL.Reporting; using POSDLL.Ticket;
namespace POSApp.Forms
{
    partial class frmVentaModificar
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
            this.txtID_PRODUCTO = new Telerik.WinControls.UI.RadTextBox();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.txtDESC_PRODUCTO = new Telerik.WinControls.UI.RadTextBox();
            this.label3 = new Telerik.WinControls.UI.RadLabel();
            this.txtPRECIO = new Telerik.WinControls.UI.RadTextBox();
            this.label5 = new Telerik.WinControls.UI.RadLabel();
            this.txtCANTIDAD = new Telerik.WinControls.UI.RadTextBox();
            this.label6 = new Telerik.WinControls.UI.RadLabel();
            this.txtTOTAL = new Telerik.WinControls.UI.RadTextBox();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label9 = new Telerik.WinControls.UI.RadLabel();
            this.txtNVA_CANTIDAD = new Telerik.WinControls.UI.RadTextBox();
            this.lblDescuento = new Telerik.WinControls.UI.RadLabel();
            this.txtDESCUENTO = new Telerik.WinControls.UI.RadTextBox();
            this.label4 = new Telerik.WinControls.UI.RadLabel();
            this.txtMAX_DESCUENTO = new Telerik.WinControls.UI.RadTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clave del artículo:";
            // 
            // txtID_PRODUCTO
            // 
            this.txtID_PRODUCTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID_PRODUCTO.Location = new System.Drawing.Point(12, 26);
            this.txtID_PRODUCTO.Name = "txtID_PRODUCTO";
            this.txtID_PRODUCTO.ReadOnly = true;
            this.txtID_PRODUCTO.Size = new System.Drawing.Size(295, 20);
            this.txtID_PRODUCTO.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descripción:";
            // 
            // txtDESC_PRODUCTO
            // 
            this.txtDESC_PRODUCTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDESC_PRODUCTO.Location = new System.Drawing.Point(12, 72);
            this.txtDESC_PRODUCTO.Multiline = true;
            this.txtDESC_PRODUCTO.Name = "txtDESC_PRODUCTO";
            this.txtDESC_PRODUCTO.ReadOnly = true;
            this.txtDESC_PRODUCTO.Size = new System.Drawing.Size(295, 69);
            this.txtDESC_PRODUCTO.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Precio de venta:";
            // 
            // txtPRECIO
            // 
            this.txtPRECIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPRECIO.Location = new System.Drawing.Point(12, 160);
            this.txtPRECIO.Name = "txtPRECIO";
            this.txtPRECIO.Size = new System.Drawing.Size(100, 20);
            this.txtPRECIO.TabIndex = 8;
            this.txtPRECIO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(118, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Cantidad:";
            // 
            // txtCANTIDAD
            // 
            this.txtCANTIDAD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCANTIDAD.Location = new System.Drawing.Point(118, 160);
            this.txtCANTIDAD.Name = "txtCANTIDAD";
            this.txtCANTIDAD.ReadOnly = true;
            this.txtCANTIDAD.Size = new System.Drawing.Size(83, 20);
            this.txtCANTIDAD.TabIndex = 10;
            this.txtCANTIDAD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(206, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Total:";
            // 
            // txtTOTAL
            // 
            this.txtTOTAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTOTAL.Location = new System.Drawing.Point(207, 160);
            this.txtTOTAL.Name = "txtTOTAL";
            this.txtTOTAL.ReadOnly = true;
            this.txtTOTAL.Size = new System.Drawing.Size(100, 20);
            this.txtTOTAL.TabIndex = 11;
            this.txtTOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = global::POS.Properties.Resources.accept;
            this.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(82, 323);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(73, 30);
            this.btnGrabar.TabIndex = 4;
            this.btnGrabar.Text = "Guardar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Image = global::POS.Properties.Resources.cancel;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(161, 323);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 30);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 242);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(292, 24);
            this.label9.TabIndex = 19;
            this.label9.Text = "Nueva cantidad:";
            this.label9.TextAlignment  = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNVA_CANTIDAD
            // 
            this.txtNVA_CANTIDAD.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNVA_CANTIDAD.ForeColor = System.Drawing.Color.Red;
            this.txtNVA_CANTIDAD.Location = new System.Drawing.Point(12, 269);
            this.txtNVA_CANTIDAD.Name = "txtNVA_CANTIDAD";
            this.txtNVA_CANTIDAD.Size = new System.Drawing.Size(295, 29);
            this.txtNVA_CANTIDAD.TabIndex = 1;
            this.txtNVA_CANTIDAD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNVA_CANTIDAD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNVA_CANTIDAD_KeyPress);
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Location = new System.Drawing.Point(118, 187);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(62, 13);
            this.lblDescuento.TabIndex = 20;
            this.lblDescuento.Text = "Descuento:";
            // 
            // txtDESCUENTO
            // 
            this.txtDESCUENTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDESCUENTO.Location = new System.Drawing.Point(121, 204);
            this.txtDESCUENTO.Name = "txtDESCUENTO";
            this.txtDESCUENTO.Size = new System.Drawing.Size(80, 20);
            this.txtDESCUENTO.TabIndex = 21;
            this.txtDESCUENTO.Text = "0";
            this.txtDESCUENTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Descuento máximo:";
            // 
            // txtMAX_DESCUENTO
            // 
            this.txtMAX_DESCUENTO.Location = new System.Drawing.Point(12, 203);
            this.txtMAX_DESCUENTO.Name = "txtMAX_DESCUENTO";
            this.txtMAX_DESCUENTO.ReadOnly = true;
            this.txtMAX_DESCUENTO.Size = new System.Drawing.Size(100, 20);
            this.txtMAX_DESCUENTO.TabIndex = 23;
            this.txtMAX_DESCUENTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmModificaVenta
            // 
            this.AcceptButton = this.btnGrabar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(319, 365);
            this.ControlBox = false;
            this.Controls.Add(this.txtMAX_DESCUENTO);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDESCUENTO);
            this.Controls.Add(this.lblDescuento);
            this.Controls.Add(this.txtNVA_CANTIDAD);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.txtTOTAL);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCANTIDAD);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPRECIO);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDESC_PRODUCTO);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtID_PRODUCTO);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmModificaVenta";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmModificaVenta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void txtNVA_CANTIDAD_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
           
        }

        #endregion

        private Telerik.WinControls.UI.RadLabel label1;
        private Telerik.WinControls.UI.RadTextBox txtID_PRODUCTO;
        private Telerik.WinControls.UI.RadLabel label2;
        private Telerik.WinControls.UI.RadTextBox txtDESC_PRODUCTO;
        private Telerik.WinControls.UI.RadLabel label3;
        private Telerik.WinControls.UI.RadTextBox txtPRECIO;
        private Telerik.WinControls.UI.RadLabel label5;
        private Telerik.WinControls.UI.RadTextBox txtCANTIDAD;
        private Telerik.WinControls.UI.RadLabel label6;
        private Telerik.WinControls.UI.RadTextBox txtTOTAL;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnCancelar;
        private Telerik.WinControls.UI.RadLabel label9;
        private Telerik.WinControls.UI.RadTextBox txtNVA_CANTIDAD;
        private Telerik.WinControls.UI.RadLabel lblDescuento;
        private Telerik.WinControls.UI.RadTextBox txtDESCUENTO;
        private Telerik.WinControls.UI.RadLabel label4;
        private Telerik.WinControls.UI.RadTextBox txtMAX_DESCUENTO;
    }
}