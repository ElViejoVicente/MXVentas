namespace POSApp.Forms
{
    partial class frmRptCorteDeCaja
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.dtpFECHA_FIN = new System.Windows.Forms.DateTimePicker();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.dtpFECHA_INI = new System.Windows.Forms.DateTimePicker();
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.label3 = new Telerik.WinControls.UI.RadLabel();
            this.cboUSER_LOGIN = new System.Windows.Forms.ComboBox();
            this.label4 = new Telerik.WinControls.UI.RadLabel();
            this.txt1000 = new Telerik.WinControls.UI.RadTextBox();
            this.label5 = new Telerik.WinControls.UI.RadLabel();
            this.txt500 = new Telerik.WinControls.UI.RadTextBox();
            this.label6 = new Telerik.WinControls.UI.RadLabel();
            this.txt200 = new Telerik.WinControls.UI.RadTextBox();
            this.label7 = new Telerik.WinControls.UI.RadLabel();
            this.txt100 = new Telerik.WinControls.UI.RadTextBox();
            this.txt50 = new Telerik.WinControls.UI.RadTextBox();
            this.label8 = new Telerik.WinControls.UI.RadLabel();
            this.txt20 = new Telerik.WinControls.UI.RadTextBox();
            this.label9 = new Telerik.WinControls.UI.RadLabel();
            this.label10 = new Telerik.WinControls.UI.RadLabel();
            this.txt10 = new Telerik.WinControls.UI.RadTextBox();
            this.label11 = new Telerik.WinControls.UI.RadLabel();
            this.txt5 = new Telerik.WinControls.UI.RadTextBox();
            this.label12 = new Telerik.WinControls.UI.RadLabel();
            this.txt2 = new Telerik.WinControls.UI.RadTextBox();
            this.label13 = new Telerik.WinControls.UI.RadLabel();
            this.txt1 = new Telerik.WinControls.UI.RadTextBox();
            this.label14 = new Telerik.WinControls.UI.RadLabel();
            this.txt50C = new Telerik.WinControls.UI.RadTextBox();
            this.label15 = new Telerik.WinControls.UI.RadLabel();
            this.txt20C = new Telerik.WinControls.UI.RadTextBox();
            this.label16 = new Telerik.WinControls.UI.RadLabel();
            this.txt10C = new Telerik.WinControls.UI.RadTextBox();
            this.lbl05C = new Telerik.WinControls.UI.RadLabel();
            this.txt05C = new Telerik.WinControls.UI.RadTextBox();
            this.lblTOTAL = new Telerik.WinControls.UI.RadLabel();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::POS.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(199, 338);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 30);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = global::POS.Properties.Resources.accept;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.Location = new System.Drawing.Point(111, 338);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 30);
            this.btnOK.TabIndex = 16;
            this.btnOK.Text = "Aceptar";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dtpFECHA_FIN
            // 
            this.dtpFECHA_FIN.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFECHA_FIN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFECHA_FIN.Location = new System.Drawing.Point(152, 25);
            this.dtpFECHA_FIN.Name = "dtpFECHA_FIN";
            this.dtpFECHA_FIN.Size = new System.Drawing.Size(127, 20);
            this.dtpFECHA_FIN.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Fecha final (dd/mm/aaaa):";
            // 
            // dtpFECHA_INI
            // 
            this.dtpFECHA_INI.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFECHA_INI.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFECHA_INI.Location = new System.Drawing.Point(15, 25);
            this.dtpFECHA_INI.Name = "dtpFECHA_INI";
            this.dtpFECHA_INI.Size = new System.Drawing.Size(131, 20);
            this.dtpFECHA_INI.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Fecha inicial (dd/mm/aaaa):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Seleccione un cajero:";
            // 
            // cboUSER_LOGIN
            // 
            this.cboUSER_LOGIN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUSER_LOGIN.FormattingEnabled = true;
            this.cboUSER_LOGIN.Location = new System.Drawing.Point(12, 64);
            this.cboUSER_LOGIN.Name = "cboUSER_LOGIN";
            this.cboUSER_LOGIN.Size = new System.Drawing.Size(267, 21);
            this.cboUSER_LOGIN.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "$ 1000";
            // 
            // txt1000
            // 
            this.txt1000.Location = new System.Drawing.Point(58, 94);
            this.txt1000.Name = "txt1000";
            this.txt1000.Size = new System.Drawing.Size(61, 20);
            this.txt1000.TabIndex = 21;
            this.txt1000.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "$ 500";
            // 
            // txt500
            // 
            this.txt500.Location = new System.Drawing.Point(58, 120);
            this.txt500.Name = "txt500";
            this.txt500.Size = new System.Drawing.Size(61, 20);
            this.txt500.TabIndex = 23;
            this.txt500.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "$ 200";
            // 
            // txt200
            // 
            this.txt200.Location = new System.Drawing.Point(58, 146);
            this.txt200.Name = "txt200";
            this.txt200.Size = new System.Drawing.Size(61, 20);
            this.txt200.TabIndex = 25;
            this.txt200.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "$ 100";
            // 
            // txt100
            // 
            this.txt100.Location = new System.Drawing.Point(58, 172);
            this.txt100.Name = "txt100";
            this.txt100.Size = new System.Drawing.Size(61, 20);
            this.txt100.TabIndex = 27;
            this.txt100.Text = "0";
            // 
            // txt50
            // 
            this.txt50.Location = new System.Drawing.Point(58, 198);
            this.txt50.Name = "txt50";
            this.txt50.Size = new System.Drawing.Size(61, 20);
            this.txt50.TabIndex = 28;
            this.txt50.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 201);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "$ 50";
            // 
            // txt20
            // 
            this.txt20.Location = new System.Drawing.Point(58, 224);
            this.txt20.Name = "txt20";
            this.txt20.Size = new System.Drawing.Size(61, 20);
            this.txt20.TabIndex = 30;
            this.txt20.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 227);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "$ 20";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 253);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "$ 10";
            // 
            // txt10
            // 
            this.txt10.Location = new System.Drawing.Point(58, 250);
            this.txt10.Name = "txt10";
            this.txt10.Size = new System.Drawing.Size(61, 20);
            this.txt10.TabIndex = 32;
            this.txt10.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(186, 97);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(22, 13);
            this.label11.TabIndex = 35;
            this.label11.Text = "$ 5";
            // 
            // txt5
            // 
            this.txt5.Location = new System.Drawing.Point(214, 94);
            this.txt5.Name = "txt5";
            this.txt5.Size = new System.Drawing.Size(61, 20);
            this.txt5.TabIndex = 34;
            this.txt5.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(186, 123);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(22, 13);
            this.label12.TabIndex = 37;
            this.label12.Text = "$ 2";
            // 
            // txt2
            // 
            this.txt2.Location = new System.Drawing.Point(214, 120);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(61, 20);
            this.txt2.TabIndex = 36;
            this.txt2.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(186, 149);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(22, 13);
            this.label13.TabIndex = 39;
            this.label13.Text = "$ 1";
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(214, 146);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(61, 20);
            this.txt1.TabIndex = 38;
            this.txt1.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(177, 175);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 13);
            this.label14.TabIndex = 41;
            this.label14.Text = "$ .50";
            // 
            // txt50C
            // 
            this.txt50C.Location = new System.Drawing.Point(214, 172);
            this.txt50C.Name = "txt50C";
            this.txt50C.Size = new System.Drawing.Size(61, 20);
            this.txt50C.TabIndex = 40;
            this.txt50C.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(177, 201);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(31, 13);
            this.label15.TabIndex = 43;
            this.label15.Text = "$ .20";
            // 
            // txt20C
            // 
            this.txt20C.Location = new System.Drawing.Point(214, 198);
            this.txt20C.Name = "txt20C";
            this.txt20C.Size = new System.Drawing.Size(61, 20);
            this.txt20C.TabIndex = 42;
            this.txt20C.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(177, 228);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(31, 13);
            this.label16.TabIndex = 45;
            this.label16.Text = "$ .10";
            // 
            // txt10C
            // 
            this.txt10C.Location = new System.Drawing.Point(214, 224);
            this.txt10C.Name = "txt10C";
            this.txt10C.Size = new System.Drawing.Size(61, 20);
            this.txt10C.TabIndex = 44;
            this.txt10C.Text = "0";
            // 
            // lbl05C
            // 
            this.lbl05C.AutoSize = true;
            this.lbl05C.Location = new System.Drawing.Point(177, 257);
            this.lbl05C.Name = "lbl05C";
            this.lbl05C.Size = new System.Drawing.Size(31, 13);
            this.lbl05C.TabIndex = 47;
            this.lbl05C.Text = "$ .05";
            // 
            // txt05C
            // 
            this.txt05C.Location = new System.Drawing.Point(214, 253);
            this.txt05C.Name = "txt05C";
            this.txt05C.Size = new System.Drawing.Size(61, 20);
            this.txt05C.TabIndex = 46;
            this.txt05C.Text = "0";
            // 
            // lblTOTAL
            // 
            //this.lblTOTAL.TextAlign = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTOTAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTOTAL.Location = new System.Drawing.Point(12, 289);
            this.lblTOTAL.Name = "lblTOTAL";
            this.lblTOTAL.Size = new System.Drawing.Size(263, 46);
            this.lblTOTAL.TabIndex = 48;
            this.lblTOTAL.Text = "$ 0";
            this.lblTOTAL.TextAlignment  = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmRptCorteDeCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(287, 380);
            this.Controls.Add(this.lblTOTAL);
            this.Controls.Add(this.lbl05C);
            this.Controls.Add(this.txt05C);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txt10C);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txt20C);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txt50C);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt20);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt50);
            this.Controls.Add(this.txt100);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt200);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt500);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt1000);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboUSER_LOGIN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dtpFECHA_FIN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFECHA_INI);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmRptCorteDeCaja";
            this.Text = "Corte de caja";
            this.Load += new System.EventHandler(this.frmRptCorteDeCaja_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DateTimePicker dtpFECHA_FIN;
        private Telerik.WinControls.UI.RadLabel label2;
        private System.Windows.Forms.DateTimePicker dtpFECHA_INI;
        private Telerik.WinControls.UI.RadLabel label1;
        private Telerik.WinControls.UI.RadLabel label3;
        private System.Windows.Forms.ComboBox cboUSER_LOGIN;
        private Telerik.WinControls.UI.RadLabel label4;
        private Telerik.WinControls.UI.RadTextBox txt1000;
        private Telerik.WinControls.UI.RadLabel label5;
        private Telerik.WinControls.UI.RadTextBox txt500;
        private Telerik.WinControls.UI.RadLabel label6;
        private Telerik.WinControls.UI.RadTextBox txt200;
        private Telerik.WinControls.UI.RadLabel label7;
        private Telerik.WinControls.UI.RadTextBox txt100;
        private Telerik.WinControls.UI.RadTextBox txt50;
        private Telerik.WinControls.UI.RadLabel label8;
        private Telerik.WinControls.UI.RadTextBox txt20;
        private Telerik.WinControls.UI.RadLabel label9;
        private Telerik.WinControls.UI.RadLabel label10;
        private Telerik.WinControls.UI.RadTextBox txt10;
        private Telerik.WinControls.UI.RadLabel label11;
        private Telerik.WinControls.UI.RadTextBox txt5;
        private Telerik.WinControls.UI.RadLabel label12;
        private Telerik.WinControls.UI.RadTextBox txt2;
        private Telerik.WinControls.UI.RadLabel label13;
        private Telerik.WinControls.UI.RadTextBox txt1;
        private Telerik.WinControls.UI.RadLabel label14;
        private Telerik.WinControls.UI.RadTextBox txt50C;
        private Telerik.WinControls.UI.RadLabel label15;
        private Telerik.WinControls.UI.RadTextBox txt20C;
        private Telerik.WinControls.UI.RadLabel label16;
        private Telerik.WinControls.UI.RadTextBox txt10C;
        private Telerik.WinControls.UI.RadLabel lbl05C;
        private Telerik.WinControls.UI.RadTextBox txt05C;
        private Telerik.WinControls.UI.RadLabel lblTOTAL;
    }
}