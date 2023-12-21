namespace POSApp.Administrar.AjustesInventario
{
    partial class frmAjuste
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.dtpFECHA_AJUSTE = new System.Windows.Forms.DateTimePicker();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.btnBuscaProducto = new System.Windows.Forms.Button();
            this.label3 = new Telerik.WinControls.UI.RadLabel();
            this.txtCANTIDAD_AJUSTE = new Telerik.WinControls.UI.RadTextBox();
            this.label4 = new Telerik.WinControls.UI.RadLabel();
            this.cboID_TIPO_AJUSTE = new System.Windows.Forms.ComboBox();
            this.label5 = new Telerik.WinControls.UI.RadLabel();
            this.txtOBSERVACIONES = new Telerik.WinControls.UI.RadTextBox();
            this.btnCANCEL = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblIdProducto = new Telerik.WinControls.UI.RadLabel();
            this.txtIdProducto = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCANTIDAD_AJUSTE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOBSERVACIONES)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIdProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2, 2);
            this.label1.TabIndex = 15;
            // 
            // dtpFECHA_AJUSTE
            // 
            this.dtpFECHA_AJUSTE.CustomFormat = "dd/MM/yyyy";
            this.dtpFECHA_AJUSTE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFECHA_AJUSTE.Location = new System.Drawing.Point(12, 25);
            this.dtpFECHA_AJUSTE.Name = "dtpFECHA_AJUSTE";
            this.dtpFECHA_AJUSTE.Size = new System.Drawing.Size(102, 20);
            this.dtpFECHA_AJUSTE.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Clave de artículo:";
            // 
            // btnBuscaProducto
            // 
            this.btnBuscaProducto.Location = new System.Drawing.Point(267, 69);
            this.btnBuscaProducto.Name = "btnBuscaProducto";
            this.btnBuscaProducto.Size = new System.Drawing.Size(117, 23);
            this.btnBuscaProducto.TabIndex = 4;
            this.btnBuscaProducto.Text = "Buscar Producto";
            this.btnBuscaProducto.UseVisualStyleBackColor = true;
            this.btnBuscaProducto.Click += new System.EventHandler(this.btnBuscaProducto_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(4, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cantidad a ajustar:";
            // 
            // txtCANTIDAD_AJUSTE
            // 
            this.txtCANTIDAD_AJUSTE.Location = new System.Drawing.Point(8, 208);
            this.txtCANTIDAD_AJUSTE.MaxLength = 10;
            this.txtCANTIDAD_AJUSTE.Name = "txtCANTIDAD_AJUSTE";
            this.txtCANTIDAD_AJUSTE.Size = new System.Drawing.Size(100, 20);
            this.txtCANTIDAD_AJUSTE.TabIndex = 6;
            this.txtCANTIDAD_AJUSTE.TabStop = false;
            this.txtCANTIDAD_AJUSTE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCANTIDAD_AJUSTE_KeyPress);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(5, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tipo de ajuste:";
            // 
            // cboID_TIPO_AJUSTE
            // 
            this.cboID_TIPO_AJUSTE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboID_TIPO_AJUSTE.FormattingEnabled = true;
            this.cboID_TIPO_AJUSTE.Location = new System.Drawing.Point(8, 247);
            this.cboID_TIPO_AJUSTE.Name = "cboID_TIPO_AJUSTE";
            this.cboID_TIPO_AJUSTE.Size = new System.Drawing.Size(243, 21);
            this.cboID_TIPO_AJUSTE.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(5, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Observaciones:";
            // 
            // txtOBSERVACIONES
            // 
            this.txtOBSERVACIONES.AutoSize = false;
            this.txtOBSERVACIONES.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOBSERVACIONES.Location = new System.Drawing.Point(8, 287);
            this.txtOBSERVACIONES.MaxLength = 255;
            this.txtOBSERVACIONES.Multiline = true;
            this.txtOBSERVACIONES.Name = "txtOBSERVACIONES";
            this.txtOBSERVACIONES.Size = new System.Drawing.Size(372, 50);
            this.txtOBSERVACIONES.TabIndex = 10;
            this.txtOBSERVACIONES.TabStop = false;
            // 
            // btnCANCEL
            // 
            this.btnCANCEL.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCANCEL.Image = global::POS.Properties.Resources.cancel;
            this.btnCANCEL.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCANCEL.Location = new System.Drawing.Point(305, 343);
            this.btnCANCEL.Name = "btnCANCEL";
            this.btnCANCEL.Size = new System.Drawing.Size(75, 25);
            this.btnCANCEL.TabIndex = 12;
            this.btnCANCEL.Text = "Cancelar";
            this.btnCANCEL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCANCEL.UseVisualStyleBackColor = true;
            this.btnCANCEL.Click += new System.EventHandler(this.btnCANCEL_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = global::POS.Properties.Resources.accept;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.Location = new System.Drawing.Point(228, 343);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(71, 25);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "Aceptar";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblIdProducto
            // 
            this.lblIdProducto.Location = new System.Drawing.Point(13, 73);
            this.lblIdProducto.Name = "lblIdProducto";
            this.lblIdProducto.Size = new System.Drawing.Size(2, 2);
            this.lblIdProducto.TabIndex = 13;
            // 
            // txtIdProducto
            // 
            this.txtIdProducto.Location = new System.Drawing.Point(268, 99);
            this.txtIdProducto.Name = "txtIdProducto";
            this.txtIdProducto.Size = new System.Drawing.Size(116, 20);
            this.txtIdProducto.TabIndex = 14;
            this.txtIdProducto.TabStop = false;
            // 
            // frmAjuste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCANCEL;
            this.ClientSize = new System.Drawing.Size(396, 406);
            this.Controls.Add(this.txtIdProducto);
            this.Controls.Add(this.lblIdProducto);
            this.Controls.Add(this.btnCANCEL);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtOBSERVACIONES);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboID_TIPO_AJUSTE);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCANTIDAD_AJUSTE);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBuscaProducto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFECHA_AJUSTE);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmAjuste";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Ajuste";
            this.Load += new System.EventHandler(this.frmAjuste_Load);
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCANTIDAD_AJUSTE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOBSERVACIONES)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIdProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel label1;
        private System.Windows.Forms.DateTimePicker dtpFECHA_AJUSTE;
        private Telerik.WinControls.UI.RadLabel label2;
        private System.Windows.Forms.Button btnBuscaProducto;
        private Telerik.WinControls.UI.RadLabel label3;
        private Telerik.WinControls.UI.RadTextBox txtCANTIDAD_AJUSTE;
        private Telerik.WinControls.UI.RadLabel label4;
        private System.Windows.Forms.ComboBox cboID_TIPO_AJUSTE;
        private Telerik.WinControls.UI.RadLabel label5;
        private Telerik.WinControls.UI.RadTextBox txtOBSERVACIONES;
        private System.Windows.Forms.Button btnCANCEL;
        private System.Windows.Forms.Button btnOK;
        private Telerik.WinControls.UI.RadLabel lblIdProducto;
        private Telerik.WinControls.UI.RadTextBox txtIdProducto;
    }
}