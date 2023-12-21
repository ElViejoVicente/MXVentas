namespace POSApp.Forms
{
    partial class frmLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.lblDataBase = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnLogin = new System.Windows.Forms.Panel();
            this.wbProcesando = new Telerik.WinControls.UI.RadWaitingBar();
            this.lblTituloSistema = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbUserLogo = new System.Windows.Forms.PictureBox();
            this.lbMensajeLogin = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lbPassword = new System.Windows.Forms.Label();
            this.lbUsuario = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.btnSession = new System.Windows.Forms.Button();
            this.errLogin = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.pnLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wbProcesando)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDataBase
            // 
            this.lblDataBase.AutoSize = true;
            this.lblDataBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDataBase.Location = new System.Drawing.Point(0, 0);
            this.lblDataBase.Name = "lblDataBase";
            this.lblDataBase.Size = new System.Drawing.Size(81, 13);
            this.lblDataBase.TabIndex = 6;
            this.lblDataBase.TabStop = true;
            this.lblDataBase.Text = "Configuración";
            this.lblDataBase.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDataBase_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblDataBase);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 659);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1427, 99);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(1158, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 21);
            this.label1.TabIndex = 11;
            this.label1.Text = "©2022  Consultoria IT.";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1427, 81);
            this.panel2.TabIndex = 8;
            // 
            // pnLogin
            // 
            this.pnLogin.BackColor = System.Drawing.Color.White;
            this.pnLogin.Controls.Add(this.wbProcesando);
            this.pnLogin.Controls.Add(this.lblTituloSistema);
            this.pnLogin.Controls.Add(this.pictureBox1);
            this.pnLogin.Controls.Add(this.pbUserLogo);
            this.pnLogin.Controls.Add(this.lbMensajeLogin);
            this.pnLogin.Controls.Add(this.btnCancelar);
            this.pnLogin.Controls.Add(this.lbPassword);
            this.pnLogin.Controls.Add(this.lbUsuario);
            this.pnLogin.Controls.Add(this.txtPass);
            this.pnLogin.Controls.Add(this.txtUser);
            this.pnLogin.Controls.Add(this.btnSession);
            this.pnLogin.Location = new System.Drawing.Point(384, 164);
            this.pnLogin.Name = "pnLogin";
            this.pnLogin.Size = new System.Drawing.Size(727, 440);
            this.pnLogin.TabIndex = 9;
            // 
            // wbProcesando
            // 
            this.wbProcesando.Location = new System.Drawing.Point(48, 400);
            this.wbProcesando.Name = "wbProcesando";
            this.wbProcesando.Size = new System.Drawing.Size(355, 19);
            this.wbProcesando.TabIndex = 29;
            this.wbProcesando.Text = "radWaitingBar1";
            this.wbProcesando.Visible = false;
            this.wbProcesando.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.Dash;
            // 
            // lblTituloSistema
            // 
            this.lblTituloSistema.AutoSize = true;
            this.lblTituloSistema.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloSistema.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTituloSistema.Location = new System.Drawing.Point(62, 129);
            this.lblTituloSistema.Name = "lblTituloSistema";
            this.lblTituloSistema.Size = new System.Drawing.Size(323, 28);
            this.lblTituloSistema.TabIndex = 28;
            this.lblTituloSistema.Text = "Sistema de punto de venta";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::POS.Properties.Resources.LogoConsultoria;
            this.pictureBox1.Location = new System.Drawing.Point(136, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(168, 105);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // pbUserLogo
            // 
            this.pbUserLogo.Image = global::POS.Properties.Resources.user_login;
            this.pbUserLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbUserLogo.InitialImage")));
            this.pbUserLogo.Location = new System.Drawing.Point(451, 159);
            this.pbUserLogo.Name = "pbUserLogo";
            this.pbUserLogo.Size = new System.Drawing.Size(232, 197);
            this.pbUserLogo.TabIndex = 26;
            this.pbUserLogo.TabStop = false;
            // 
            // lbMensajeLogin
            // 
            this.lbMensajeLogin.AutoSize = true;
            this.lbMensajeLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMensajeLogin.ForeColor = System.Drawing.Color.Gold;
            this.lbMensajeLogin.Location = new System.Drawing.Point(48, 376);
            this.lbMensajeLogin.Name = "lbMensajeLogin";
            this.lbMensajeLogin.Size = new System.Drawing.Size(72, 21);
            this.lbMensajeLogin.TabIndex = 27;
            this.lbMensajeLogin.Text = "Evento...";
            this.lbMensajeLogin.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(267, 320);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(136, 36);
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassword.Location = new System.Drawing.Point(44, 251);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(96, 21);
            this.lbPassword.TabIndex = 24;
            this.lbPassword.Text = "Contraseña:";
            // 
            // lbUsuario
            // 
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsuario.Location = new System.Drawing.Point(44, 184);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(157, 21);
            this.lbUsuario.TabIndex = 23;
            this.lbUsuario.Text = "Nombre de Usuario:";
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.Location = new System.Drawing.Point(48, 278);
            this.txtPass.MaxLength = 20;
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '#';
            this.txtPass.Size = new System.Drawing.Size(355, 33);
            this.txtPass.TabIndex = 22;
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.Location = new System.Drawing.Point(48, 211);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(355, 33);
            this.txtUser.TabIndex = 21;
            this.txtUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUser_KeyPress);
            // 
            // btnSession
            // 
            this.btnSession.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSession.Location = new System.Drawing.Point(48, 320);
            this.btnSession.Name = "btnSession";
            this.btnSession.Size = new System.Drawing.Size(136, 36);
            this.btnSession.TabIndex = 19;
            this.btnSession.Text = "Iniciar";
            this.btnSession.UseVisualStyleBackColor = true;
            this.btnSession.Click += new System.EventHandler(this.btnSession_Click);
            // 
            // errLogin
            // 
            this.errLogin.ContainerControl = this;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::POS.Properties.Resources.mxVentaLogin;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1427, 758);
            this.Controls.Add(this.pnLogin);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar sesión...";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnLogin.ResumeLayout(false);
            this.pnLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wbProcesando)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblDataBase;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnLogin;
        private System.Windows.Forms.Label lblTituloSistema;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbUserLogo;
        private System.Windows.Forms.Label lbMensajeLogin;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label lbUsuario;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Button btnSession;
        private System.Windows.Forms.ErrorProvider errLogin;
        private Telerik.WinControls.UI.RadWaitingBar wbProcesando;
        private System.Windows.Forms.Label label1;
    }
}