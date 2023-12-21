namespace POSApp.Forms
{
    partial class frmUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsers));
            this.lvUsers = new System.Windows.Forms.ListView();
            this.c_mnuUsers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuActivate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeactivate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRestorePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUSerProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMessage = new Telerik.WinControls.UI.RadLabel();
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.gpoUsers = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblPasswordMessage = new Telerik.WinControls.UI.RadLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnProperties = new System.Windows.Forms.Button();
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.c_mnuUsers.SuspendLayout();
            this.gpoUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // lvUsers
            // 
            this.lvUsers.ContextMenuStrip = this.c_mnuUsers;
            this.lvUsers.FullRowSelect = true;
            this.lvUsers.GridLines = true;
            this.lvUsers.HideSelection = false;
            this.lvUsers.Location = new System.Drawing.Point(12, 82);
            this.lvUsers.Name = "lvUsers";
            this.lvUsers.Size = new System.Drawing.Size(325, 112);
            this.lvUsers.TabIndex = 0;
            this.lvUsers.UseCompatibleStateImageBehavior = false;
            this.lvUsers.SelectedIndexChanged += new System.EventHandler(this.lvUsers_SelectedIndexChanged);
            // 
            // c_mnuUsers
            // 
            this.c_mnuUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddUser,
            this.mnuActivate,
            this.mnuDeactivate,
            this.mnuRestorePassword,
            this.mnuUSerProperties});
            this.c_mnuUsers.Name = "c_mnuUsers";
            this.c_mnuUsers.Size = new System.Drawing.Size(202, 114);
            // 
            // mnuAddUser
            // 
            this.mnuAddUser.Image = ((System.Drawing.Image)(resources.GetObject("mnuAddUser.Image")));
            this.mnuAddUser.Name = "mnuAddUser";
            this.mnuAddUser.Size = new System.Drawing.Size(201, 22);
            this.mnuAddUser.Text = "Agregar usuario";
            this.mnuAddUser.Click += new System.EventHandler(this.mnuAddUser_Click);
            // 
            // mnuActivate
            // 
            this.mnuActivate.Image = ((System.Drawing.Image)(resources.GetObject("mnuActivate.Image")));
            this.mnuActivate.Name = "mnuActivate";
            this.mnuActivate.Size = new System.Drawing.Size(201, 22);
            this.mnuActivate.Text = "Activar usuario";
            this.mnuActivate.Click += new System.EventHandler(this.mnuActivate_Click);
            // 
            // mnuDeactivate
            // 
            this.mnuDeactivate.Image = ((System.Drawing.Image)(resources.GetObject("mnuDeactivate.Image")));
            this.mnuDeactivate.Name = "mnuDeactivate";
            this.mnuDeactivate.Size = new System.Drawing.Size(201, 22);
            this.mnuDeactivate.Text = "Desactivar usuario";
            this.mnuDeactivate.Click += new System.EventHandler(this.mnuDeactivate_Click);
            // 
            // mnuRestorePassword
            // 
            this.mnuRestorePassword.Image = ((System.Drawing.Image)(resources.GetObject("mnuRestorePassword.Image")));
            this.mnuRestorePassword.Name = "mnuRestorePassword";
            this.mnuRestorePassword.Size = new System.Drawing.Size(201, 22);
            this.mnuRestorePassword.Text = "Reestablecer contraseña";
            this.mnuRestorePassword.Click += new System.EventHandler(this.mnuRestorePassword_Click);
            // 
            // mnuUSerProperties
            // 
            this.mnuUSerProperties.Image = ((System.Drawing.Image)(resources.GetObject("mnuUSerProperties.Image")));
            this.mnuUSerProperties.Name = "mnuUSerProperties";
            this.mnuUSerProperties.Size = new System.Drawing.Size(201, 22);
            this.mnuUSerProperties.Text = "Propiedades del usuario";
            this.mnuUSerProperties.Click += new System.EventHandler(this.mnuUSerProperties_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(58, 12);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(279, 37);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "En esta seccion podrá administrar los usuarios para el sistema";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "System Users:";
            // 
            // gpoUsers
            // 
            this.gpoUsers.Controls.Add(this.btnUpdate);
            this.gpoUsers.Controls.Add(this.lblPasswordMessage);
            this.gpoUsers.Location = new System.Drawing.Point(10, 233);
            this.gpoUsers.Name = "gpoUsers";
            this.gpoUsers.Size = new System.Drawing.Size(326, 61);
            this.gpoUsers.TabIndex = 7;
            this.gpoUsers.TabStop = false;
            this.gpoUsers.Text = "Password of";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Image = global::POS.Properties.Resources.key;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.Location = new System.Drawing.Point(225, 19);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(95, 30);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Reestablecer";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblPasswordMessage
            // 
            this.lblPasswordMessage.Location = new System.Drawing.Point(6, 16);
            this.lblPasswordMessage.Name = "lblPasswordMessage";
            this.lblPasswordMessage.Size = new System.Drawing.Size(207, 33);
            this.lblPasswordMessage.TabIndex = 0;
            this.lblPasswordMessage.Text = "Para cambiar el password, selecicone un elemento...";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::POS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(274, 300);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(61, 30);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Cerrar";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnProperties
            // 
            this.btnProperties.Image = global::POS.Properties.Resources.user_edit;
            this.btnProperties.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProperties.Location = new System.Drawing.Point(242, 200);
            this.btnProperties.Name = "btnProperties";
            this.btnProperties.Size = new System.Drawing.Size(95, 30);
            this.btnProperties.TabIndex = 6;
            this.btnProperties.Text = "Propiedades";
            this.btnProperties.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProperties.UseVisualStyleBackColor = true;
            this.btnProperties.Click += new System.EventHandler(this.btnProperties_Click);
            // 
            // picFoto
            // 
            this.picFoto.Image = ((System.Drawing.Image)(resources.GetObject("picFoto.Image")));
            this.picFoto.Location = new System.Drawing.Point(12, 12);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(40, 37);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFoto.TabIndex = 2;
            this.picFoto.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::POS.Properties.Resources.user_delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.Location = new System.Drawing.Point(154, 200);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(82, 30);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Desactivar";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::POS.Properties.Resources.user_add;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.Location = new System.Drawing.Point(80, 200);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(68, 30);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Nuevo";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(349, 333);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gpoUsers);
            this.Controls.Add(this.picFoto);
            this.Controls.Add(this.btnProperties);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvUsers);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmUsers";
            this.ShowInTaskbar = false;
            this.Text = "Usuarios del sistema";
            this.Load += new System.EventHandler(this.frmUsers_Load);
            this.c_mnuUsers.ResumeLayout(false);
            this.gpoUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        
        #endregion

        private System.Windows.Forms.ListView lvUsers;
        private Telerik.WinControls.UI.RadLabel lblMessage;
        private System.Windows.Forms.PictureBox picFoto;
        private Telerik.WinControls.UI.RadLabel label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnProperties;
        private System.Windows.Forms.GroupBox gpoUsers;
        private Telerik.WinControls.UI.RadLabel lblPasswordMessage;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip c_mnuUsers;
        private System.Windows.Forms.ToolStripMenuItem mnuActivate;
        private System.Windows.Forms.ToolStripMenuItem mnuDeactivate;
        private System.Windows.Forms.ToolStripMenuItem mnuRestorePassword;
        private System.Windows.Forms.ToolStripMenuItem mnuUSerProperties;
        private System.Windows.Forms.ToolStripMenuItem mnuAddUser;
    }
}