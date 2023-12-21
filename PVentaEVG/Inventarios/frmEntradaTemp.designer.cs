using POSDLL; using POSDLL.Windows.Forms; using POSDLL.Security; using POSDLL.Reporting; using POSDLL.Ticket;
namespace POSApp.Forms
{
    partial class frmEntradaTemp
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
            this.btnSearchProduct = new System.Windows.Forms.Button();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.txtCANTIDAD = new Telerik.WinControls.UI.RadTextBox();
            this.label3 = new Telerik.WinControls.UI.RadLabel();
            this.txtPRECIO = new Telerik.WinControls.UI.RadTextBox();
            this.label4 = new Telerik.WinControls.UI.RadLabel();
            this.txtIMPUESTO = new Telerik.WinControls.UI.RadTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clave del artículo:";
            // 
            // txtID_PRODUCTO
            // 
            this.txtID_PRODUCTO.Location = new System.Drawing.Point(12, 25);
            this.txtID_PRODUCTO.Name = "txtID_PRODUCTO";
            this.txtID_PRODUCTO.Size = new System.Drawing.Size(206, 20);
            this.txtID_PRODUCTO.TabIndex = 1;
            this.txtID_PRODUCTO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtID_PRODUCTO_KeyPress);
            this.txtID_PRODUCTO.LostFocus += new System.EventHandler(this.txtID_PRODUCTO_LostFocus);
            // 
            // btnSearchProduct
            // 
            this.btnSearchProduct.Image = global::POS.Properties.Resources.zoom;
            this.btnSearchProduct.Location = new System.Drawing.Point(224, 22);
            this.btnSearchProduct.Name = "btnSearchProduct";
            this.btnSearchProduct.Size = new System.Drawing.Size(38, 23);
            this.btnSearchProduct.TabIndex = 2;
            this.btnSearchProduct.UseVisualStyleBackColor = true;
            this.btnSearchProduct.Click += new System.EventHandler(this.btnSearchProduct_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cantidad:";
            // 
            // txtCANTIDAD
            // 
            this.txtCANTIDAD.Location = new System.Drawing.Point(12, 77);
            this.txtCANTIDAD.Name = "txtCANTIDAD";
            this.txtCANTIDAD.Size = new System.Drawing.Size(100, 20);
            this.txtCANTIDAD.TabIndex = 4;
            this.txtCANTIDAD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCANTIDAD_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Precio:";
            // 
            // txtPRECIO
            // 
            this.txtPRECIO.Location = new System.Drawing.Point(118, 77);
            this.txtPRECIO.Name = "txtPRECIO";
            this.txtPRECIO.Size = new System.Drawing.Size(100, 20);
            this.txtPRECIO.TabIndex = 6;
            this.txtPRECIO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPRECIO_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(221, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "IVA";
            // 
            // txtIMPUESTO
            // 
            this.txtIMPUESTO.Location = new System.Drawing.Point(224, 77);
            this.txtIMPUESTO.Name = "txtIMPUESTO";
            this.txtIMPUESTO.Size = new System.Drawing.Size(38, 20);
            this.txtIMPUESTO.TabIndex = 8;
            this.txtIMPUESTO.Text = "0.16";
            this.txtIMPUESTO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIMPUESTO_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::POS.Properties.Resources.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(94, 112);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 30);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Aceptar";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::POS.Properties.Resources.cancel;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(179, 112);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(83, 30);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Cancelar";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmTempEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(274, 154);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtIMPUESTO);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPRECIO);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCANTIDAD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSearchProduct);
            this.Controls.Add(this.txtID_PRODUCTO);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmTempEntrada";
            this.ShowInTaskbar = false;
            this.Text = "Entradas";
            this.Load += new System.EventHandler(this.frmTempEntrada_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

        void txtIMPUESTO_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
           
        }

        void txtPRECIO_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
          
        }

        void txtCANTIDAD_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
        }

        #endregion

        private Telerik.WinControls.UI.RadLabel label1;
        private Telerik.WinControls.UI.RadTextBox txtID_PRODUCTO;
        private System.Windows.Forms.Button btnSearchProduct;
        private Telerik.WinControls.UI.RadLabel label2;
        private Telerik.WinControls.UI.RadTextBox txtCANTIDAD;
        private Telerik.WinControls.UI.RadLabel label3;
        private Telerik.WinControls.UI.RadTextBox txtPRECIO;
        private Telerik.WinControls.UI.RadLabel label4;
        private Telerik.WinControls.UI.RadTextBox txtIMPUESTO;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}