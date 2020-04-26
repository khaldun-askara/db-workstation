namespace db_workstation
{
    partial class frm_insertupdate
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
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.dtp_reg_date = new System.Windows.Forms.DateTimePicker();
            this.txtB_password = new System.Windows.Forms.TextBox();
            this.txtB_login = new System.Windows.Forms.TextBox();
            this.lbl_reg_date = new System.Windows.Forms.Label();
            this.lbl_password = new System.Windows.Forms.Label();
            this.lbl_login = new System.Windows.Forms.Label();
            this.erp_login = new System.Windows.Forms.ErrorProvider(this.components);
            this.erp_password = new System.Windows.Forms.ErrorProvider(this.components);
            this.cmB_role = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.erp_login)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp_password)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(104, 356);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(336, 55);
            this.btn_cancel.TabIndex = 15;
            this.btn_cancel.Text = "Отмена";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_OK.Location = new System.Drawing.Point(104, 295);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(336, 55);
            this.btn_OK.TabIndex = 14;
            this.btn_OK.Text = "Добавить/Изменить";
            this.btn_OK.UseVisualStyleBackColor = true;
            // 
            // dtp_reg_date
            // 
            this.dtp_reg_date.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtp_reg_date.Location = new System.Drawing.Point(104, 209);
            this.dtp_reg_date.Name = "dtp_reg_date";
            this.dtp_reg_date.Size = new System.Drawing.Size(336, 22);
            this.dtp_reg_date.TabIndex = 13;
            this.dtp_reg_date.Value = new System.DateTime(2020, 3, 22, 17, 7, 6, 0);
            // 
            // txtB_password
            // 
            this.txtB_password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtB_password.Location = new System.Drawing.Point(104, 164);
            this.txtB_password.Name = "txtB_password";
            this.txtB_password.Size = new System.Drawing.Size(336, 22);
            this.txtB_password.TabIndex = 12;
            this.txtB_password.TextChanged += new System.EventHandler(this.txtB_password_TextChanged);
            // 
            // txtB_login
            // 
            this.txtB_login.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtB_login.Location = new System.Drawing.Point(104, 119);
            this.txtB_login.MaxLength = 50;
            this.txtB_login.Name = "txtB_login";
            this.txtB_login.Size = new System.Drawing.Size(336, 22);
            this.txtB_login.TabIndex = 11;
            this.txtB_login.TextChanged += new System.EventHandler(this.txtB_login_TextChanged);
            // 
            // lbl_reg_date
            // 
            this.lbl_reg_date.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_reg_date.AutoSize = true;
            this.lbl_reg_date.Location = new System.Drawing.Point(101, 189);
            this.lbl_reg_date.Name = "lbl_reg_date";
            this.lbl_reg_date.Size = new System.Drawing.Size(129, 17);
            this.lbl_reg_date.TabIndex = 10;
            this.lbl_reg_date.Text = "Дата регистрации";
            // 
            // lbl_password
            // 
            this.lbl_password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_password.AutoSize = true;
            this.lbl_password.Location = new System.Drawing.Point(101, 144);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(155, 17);
            this.lbl_password.TabIndex = 9;
            this.lbl_password.Text = "Пароль/Новый пароль";
            // 
            // lbl_login
            // 
            this.lbl_login.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_login.AutoSize = true;
            this.lbl_login.Location = new System.Drawing.Point(101, 99);
            this.lbl_login.Name = "lbl_login";
            this.lbl_login.Size = new System.Drawing.Size(47, 17);
            this.lbl_login.TabIndex = 8;
            this.lbl_login.Text = "Логин";
            // 
            // erp_login
            // 
            this.erp_login.ContainerControl = this;
            // 
            // erp_password
            // 
            this.erp_password.ContainerControl = this;
            // 
            // cmB_role
            // 
            this.cmB_role.FormattingEnabled = true;
            this.cmB_role.Location = new System.Drawing.Point(104, 248);
            this.cmB_role.Name = "cmB_role";
            this.cmB_role.Size = new System.Drawing.Size(336, 24);
            this.cmB_role.TabIndex = 16;
            // 
            // frm_insertupdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 472);
            this.Controls.Add(this.cmB_role);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.dtp_reg_date);
            this.Controls.Add(this.txtB_password);
            this.Controls.Add(this.txtB_login);
            this.Controls.Add(this.lbl_reg_date);
            this.Controls.Add(this.lbl_password);
            this.Controls.Add(this.lbl_login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_insertupdate";
            this.Text = "frm_insertupdate";
            ((System.ComponentModel.ISupportInitialize)(this.erp_login)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp_password)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.DateTimePicker dtp_reg_date;
        private System.Windows.Forms.TextBox txtB_password;
        private System.Windows.Forms.TextBox txtB_login;
        private System.Windows.Forms.Label lbl_reg_date;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.Label lbl_login;
        private System.Windows.Forms.ErrorProvider erp_login;
        private System.Windows.Forms.ErrorProvider erp_password;
        private System.Windows.Forms.ComboBox cmB_role;
    }
}