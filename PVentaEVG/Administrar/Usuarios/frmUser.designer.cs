namespace POSApp.Forms
{
    partial class frmUser
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
            this.tabUsers = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.txtNOMBRE = new Telerik.WinControls.UI.RadTextBox();
            this.label4 = new Telerik.WinControls.UI.RadLabel();
            this.txtMATERNO = new Telerik.WinControls.UI.RadTextBox();
            this.label3 = new Telerik.WinControls.UI.RadLabel();
            this.txtPATERNO = new Telerik.WinControls.UI.RadTextBox();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.txtUSER_LOGIN = new Telerik.WinControls.UI.RadTextBox();
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.tabPermisos = new System.Windows.Forms.TabPage();
            this.chkCANCELAR = new System.Windows.Forms.CheckBox();
            this.chkDESCUENTOS = new System.Windows.Forms.CheckBox();
            this.chkACTIVO = new System.Windows.Forms.CheckBox();
            this.chkADMINISTRAR = new System.Windows.Forms.CheckBox();
            this.chkINVENTARIOS = new System.Windows.Forms.CheckBox();
            this.chkREPORTES = new System.Windows.Forms.CheckBox();
            this.chkCATALOGOS = new System.Windows.Forms.CheckBox();
            this.chkVENTAS = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabUsers.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabPermisos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // tabUsers
            // 
            this.tabUsers.Controls.Add(this.tabGeneral);
            this.tabUsers.Controls.Add(this.tabPermisos);
            this.tabUsers.Location = new System.Drawing.Point(12, 12);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.SelectedIndex = 0;
            this.tabUsers.Size = new System.Drawing.Size(328, 212);
            this.tabUsers.TabIndex = 0;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.txtNOMBRE);
            this.tabGeneral.Controls.Add(this.label4);
            this.tabGeneral.Controls.Add(this.txtMATERNO);
            this.tabGeneral.Controls.Add(this.label3);
            this.tabGeneral.Controls.Add(this.txtPATERNO);
            this.tabGeneral.Controls.Add(this.label2);
            this.tabGeneral.Controls.Add(this.txtUSER_LOGIN);
            this.tabGeneral.Controls.Add(this.label1);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(320, 186);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // txtNOMBRE
            // 
            this.txtNOMBRE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNOMBRE.Location = new System.Drawing.Point(13, 155);
            this.txtNOMBRE.Name = "txtNOMBRE";
            this.txtNOMBRE.Size = new System.Drawing.Size(144, 20);
            this.txtNOMBRE.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Nombre:";
            // 
            // txtMATERNO
            // 
            this.txtMATERNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMATERNO.Location = new System.Drawing.Point(13, 111);
            this.txtMATERNO.Name = "txtMATERNO";
            this.txtMATERNO.Size = new System.Drawing.Size(144, 20);
            this.txtMATERNO.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Materno:";
            // 
            // txtPATERNO
            // 
            this.txtPATERNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPATERNO.Location = new System.Drawing.Point(13, 67);
            this.txtPATERNO.Name = "txtPATERNO";
            this.txtPATERNO.Size = new System.Drawing.Size(144, 20);
            this.txtPATERNO.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Paterno:";
            // 
            // txtUSER_LOGIN
            // 
            this.txtUSER_LOGIN.Location = new System.Drawing.Point(13, 24);
            this.txtUSER_LOGIN.Name = "txtUSER_LOGIN";
            this.txtUSER_LOGIN.Size = new System.Drawing.Size(144, 20);
            this.txtUSER_LOGIN.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Nombre de usuario";
            // 
            // tabPermisos
            // 
            this.tabPermisos.Controls.Add(this.chkCANCELAR);
            this.tabPermisos.Controls.Add(this.chkDESCUENTOS);
            this.tabPermisos.Controls.Add(this.chkACTIVO);
            this.tabPermisos.Controls.Add(this.chkADMINISTRAR);
            this.tabPermisos.Controls.Add(this.chkINVENTARIOS);
            this.tabPermisos.Controls.Add(this.chkREPORTES);
            this.tabPermisos.Controls.Add(this.chkCATALOGOS);
            this.tabPermisos.Controls.Add(this.chkVENTAS);
            this.tabPermisos.Location = new System.Drawing.Point(4, 22);
            this.tabPermisos.Name = "tabPermisos";
            this.tabPermisos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPermisos.Size = new System.Drawing.Size(320, 186);
            this.tabPermisos.TabIndex = 1;
            this.tabPermisos.Text = "Permisos";
            this.tabPermisos.UseVisualStyleBackColor = true;
            // 
            // chkCANCELAR
            // 
            this.chkCANCELAR.AutoSize = true;
            this.chkCANCELAR.Location = new System.Drawing.Point(116, 72);
            this.chkCANCELAR.Name = "chkCANCELAR";
            this.chkCANCELAR.Size = new System.Drawing.Size(179, 17);
            this.chkCANCELAR.TabIndex = 15;
            this.chkCANCELAR.Text = "PERMITIR CANCELAR/CREDITO";
            this.chkCANCELAR.UseVisualStyleBackColor = true;
            // 
            // chkDESCUENTOS
            // 
            this.chkDESCUENTOS.AutoSize = true;
            this.chkDESCUENTOS.Location = new System.Drawing.Point(6, 118);
            this.chkDESCUENTOS.Name = "chkDESCUENTOS";
            this.chkDESCUENTOS.Size = new System.Drawing.Size(86, 17);
            this.chkDESCUENTOS.TabIndex = 14;
            this.chkDESCUENTOS.Text = "Descuentos";
            this.chkDESCUENTOS.UseVisualStyleBackColor = true;
            // 
            // chkACTIVO
            // 
            this.chkACTIVO.AutoSize = true;
            this.chkACTIVO.Location = new System.Drawing.Point(116, 49);
            this.chkACTIVO.Name = "chkACTIVO";
            this.chkACTIVO.Size = new System.Drawing.Size(80, 17);
            this.chkACTIVO.TabIndex = 13;
            this.chkACTIVO.Text = "Habilitado";
            this.chkACTIVO.UseVisualStyleBackColor = true;
            // 
            // chkADMINISTRAR
            // 
            this.chkADMINISTRAR.AutoSize = true;
            this.chkADMINISTRAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkADMINISTRAR.ForeColor = System.Drawing.Color.Red;
            this.chkADMINISTRAR.Location = new System.Drawing.Point(116, 26);
            this.chkADMINISTRAR.Name = "chkADMINISTRAR";
            this.chkADMINISTRAR.Size = new System.Drawing.Size(112, 17);
            this.chkADMINISTRAR.TabIndex = 5;
            this.chkADMINISTRAR.Text = "ADMINISTRAR";
            this.chkADMINISTRAR.UseVisualStyleBackColor = true;
            // 
            // chkINVENTARIOS
            // 
            this.chkINVENTARIOS.AutoSize = true;
            this.chkINVENTARIOS.Location = new System.Drawing.Point(6, 95);
            this.chkINVENTARIOS.Name = "chkINVENTARIOS";
            this.chkINVENTARIOS.Size = new System.Drawing.Size(78, 17);
            this.chkINVENTARIOS.TabIndex = 4;
            this.chkINVENTARIOS.Text = "Inventario";
            this.chkINVENTARIOS.UseVisualStyleBackColor = true;
            // 
            // chkREPORTES
            // 
            this.chkREPORTES.AutoSize = true;
            this.chkREPORTES.Location = new System.Drawing.Point(6, 72);
            this.chkREPORTES.Name = "chkREPORTES";
            this.chkREPORTES.Size = new System.Drawing.Size(72, 17);
            this.chkREPORTES.TabIndex = 2;
            this.chkREPORTES.Text = "Reportes";
            this.chkREPORTES.UseVisualStyleBackColor = true;
            // 
            // chkCATALOGOS
            // 
            this.chkCATALOGOS.AutoSize = true;
            this.chkCATALOGOS.Location = new System.Drawing.Point(6, 49);
            this.chkCATALOGOS.Name = "chkCATALOGOS";
            this.chkCATALOGOS.Size = new System.Drawing.Size(78, 17);
            this.chkCATALOGOS.TabIndex = 1;
            this.chkCATALOGOS.Text = "Catálogos";
            this.chkCATALOGOS.UseVisualStyleBackColor = true;
            // 
            // chkVENTAS
            // 
            this.chkVENTAS.AutoSize = true;
            this.chkVENTAS.Location = new System.Drawing.Point(6, 26);
            this.chkVENTAS.Name = "chkVENTAS";
            this.chkVENTAS.Size = new System.Drawing.Size(61, 17);
            this.chkVENTAS.TabIndex = 0;
            this.chkVENTAS.Text = "Ventas";
            this.chkVENTAS.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::POS.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(250, 230);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 30);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = global::POS.Properties.Resources.accept;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.Location = new System.Drawing.Point(161, 230);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(83, 30);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "Aceptar";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 273);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabUsers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmUser";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowInTaskbar = false;
            this.Text = "Usuario";
            this.Load += new System.EventHandler(this.frmUser_Load);
            this.tabUsers.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.tabPermisos.ResumeLayout(false);
            this.tabPermisos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabUsers;
        private System.Windows.Forms.TabPage tabGeneral;
        private Telerik.WinControls.UI.RadTextBox txtUSER_LOGIN;
        private Telerik.WinControls.UI.RadLabel label1;
        private System.Windows.Forms.TabPage tabPermisos;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox chkACTIVO;
        private System.Windows.Forms.CheckBox chkADMINISTRAR;
        private System.Windows.Forms.CheckBox chkINVENTARIOS;
        private System.Windows.Forms.CheckBox chkREPORTES;
        private System.Windows.Forms.CheckBox chkCATALOGOS;
        private System.Windows.Forms.CheckBox chkVENTAS;
        private System.Windows.Forms.CheckBox chkDESCUENTOS;
        private Telerik.WinControls.UI.RadTextBox txtNOMBRE;
        private Telerik.WinControls.UI.RadLabel label4;
        private Telerik.WinControls.UI.RadTextBox txtMATERNO;
        private Telerik.WinControls.UI.RadLabel label3;
        private Telerik.WinControls.UI.RadTextBox txtPATERNO;
        private Telerik.WinControls.UI.RadLabel label2;
        private System.Windows.Forms.CheckBox chkCANCELAR;

    }
}