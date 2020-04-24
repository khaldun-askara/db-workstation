namespace db_workstation
{
    partial class frm_reg_and_auth
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_auth = new System.Windows.Forms.Button();
            this.pnl_reg_or_auth = new System.Windows.Forms.Panel();
            this.btn_guest = new System.Windows.Forms.Button();
            this.btn_reg = new System.Windows.Forms.Button();
            this.pnl_auth = new System.Windows.Forms.Panel();
            this.btn_auth_OK = new System.Windows.Forms.Button();
            this.lbl_password_auth = new System.Windows.Forms.Label();
            this.lbl_login_auth = new System.Windows.Forms.Label();
            this.txtB_password_auth = new System.Windows.Forms.TextBox();
            this.txtB_login_auth = new System.Windows.Forms.TextBox();
            this.erP_login = new System.Windows.Forms.ErrorProvider(this.components);
            this.erP_password = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnl_reg = new System.Windows.Forms.Panel();
            this.btn_reg_OK = new System.Windows.Forms.Button();
            this.lbl_password_reg = new System.Windows.Forms.Label();
            this.lbl_login_reg = new System.Windows.Forms.Label();
            this.txtB_password_reg = new System.Windows.Forms.TextBox();
            this.txtB_login_reg = new System.Windows.Forms.TextBox();
            this.btn_again = new System.Windows.Forms.Button();
            this.pnl_reg_or_auth.SuspendLayout();
            this.pnl_auth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erP_login)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erP_password)).BeginInit();
            this.pnl_reg.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_auth
            // 
            this.btn_auth.Location = new System.Drawing.Point(37, 48);
            this.btn_auth.Name = "btn_auth";
            this.btn_auth.Size = new System.Drawing.Size(284, 69);
            this.btn_auth.TabIndex = 0;
            this.btn_auth.Text = "Вход";
            this.btn_auth.UseVisualStyleBackColor = true;
            this.btn_auth.Click += new System.EventHandler(this.btn_auth_Click);
            // 
            // pnl_reg_or_auth
            // 
            this.pnl_reg_or_auth.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnl_reg_or_auth.Controls.Add(this.btn_guest);
            this.pnl_reg_or_auth.Controls.Add(this.btn_reg);
            this.pnl_reg_or_auth.Controls.Add(this.btn_auth);
            this.pnl_reg_or_auth.Location = new System.Drawing.Point(143, 52);
            this.pnl_reg_or_auth.Name = "pnl_reg_or_auth";
            this.pnl_reg_or_auth.Size = new System.Drawing.Size(359, 345);
            this.pnl_reg_or_auth.TabIndex = 1;
            // 
            // btn_guest
            // 
            this.btn_guest.Location = new System.Drawing.Point(37, 244);
            this.btn_guest.Name = "btn_guest";
            this.btn_guest.Size = new System.Drawing.Size(284, 69);
            this.btn_guest.TabIndex = 2;
            this.btn_guest.Text = "Войти как гость";
            this.btn_guest.UseVisualStyleBackColor = true;
            // 
            // btn_reg
            // 
            this.btn_reg.Location = new System.Drawing.Point(37, 149);
            this.btn_reg.Name = "btn_reg";
            this.btn_reg.Size = new System.Drawing.Size(284, 69);
            this.btn_reg.TabIndex = 1;
            this.btn_reg.Text = "Регистрация";
            this.btn_reg.UseVisualStyleBackColor = true;
            this.btn_reg.Click += new System.EventHandler(this.btn_reg_Click);
            // 
            // pnl_auth
            // 
            this.pnl_auth.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnl_auth.Controls.Add(this.btn_auth_OK);
            this.pnl_auth.Controls.Add(this.lbl_password_auth);
            this.pnl_auth.Controls.Add(this.lbl_login_auth);
            this.pnl_auth.Controls.Add(this.txtB_password_auth);
            this.pnl_auth.Controls.Add(this.txtB_login_auth);
            this.pnl_auth.Location = new System.Drawing.Point(94, 63);
            this.pnl_auth.Name = "pnl_auth";
            this.pnl_auth.Size = new System.Drawing.Size(456, 323);
            this.pnl_auth.TabIndex = 2;
            // 
            // btn_auth_OK
            // 
            this.btn_auth_OK.Location = new System.Drawing.Point(114, 193);
            this.btn_auth_OK.Name = "btn_auth_OK";
            this.btn_auth_OK.Size = new System.Drawing.Size(228, 71);
            this.btn_auth_OK.TabIndex = 4;
            this.btn_auth_OK.Text = "Войти";
            this.btn_auth_OK.UseVisualStyleBackColor = true;
            this.btn_auth_OK.Click += new System.EventHandler(this.btn_auth_OK_Click);
            // 
            // lbl_password_auth
            // 
            this.lbl_password_auth.AutoSize = true;
            this.lbl_password_auth.Location = new System.Drawing.Point(83, 118);
            this.lbl_password_auth.Name = "lbl_password_auth";
            this.lbl_password_auth.Size = new System.Drawing.Size(57, 17);
            this.lbl_password_auth.TabIndex = 3;
            this.lbl_password_auth.Text = "Пароль";
            // 
            // lbl_login_auth
            // 
            this.lbl_login_auth.AutoSize = true;
            this.lbl_login_auth.Location = new System.Drawing.Point(83, 59);
            this.lbl_login_auth.Name = "lbl_login_auth";
            this.lbl_login_auth.Size = new System.Drawing.Size(47, 17);
            this.lbl_login_auth.TabIndex = 2;
            this.lbl_login_auth.Text = "Логин";
            // 
            // txtB_password_auth
            // 
            this.txtB_password_auth.Location = new System.Drawing.Point(86, 138);
            this.txtB_password_auth.Name = "txtB_password_auth";
            this.txtB_password_auth.Size = new System.Drawing.Size(284, 22);
            this.txtB_password_auth.TabIndex = 1;
            this.txtB_password_auth.TextChanged += new System.EventHandler(this.txtB_password_auth_TextChanged);
            // 
            // txtB_login_auth
            // 
            this.txtB_login_auth.Location = new System.Drawing.Point(86, 79);
            this.txtB_login_auth.MaxLength = 50;
            this.txtB_login_auth.Name = "txtB_login_auth";
            this.txtB_login_auth.Size = new System.Drawing.Size(284, 22);
            this.txtB_login_auth.TabIndex = 0;
            this.txtB_login_auth.TextChanged += new System.EventHandler(this.txtB_login_auth_TextChanged);
            // 
            // erP_login
            // 
            this.erP_login.ContainerControl = this;
            // 
            // erP_password
            // 
            this.erP_password.ContainerControl = this;
            // 
            // pnl_reg
            // 
            this.pnl_reg.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnl_reg.Controls.Add(this.btn_reg_OK);
            this.pnl_reg.Controls.Add(this.lbl_password_reg);
            this.pnl_reg.Controls.Add(this.lbl_login_reg);
            this.pnl_reg.Controls.Add(this.txtB_password_reg);
            this.pnl_reg.Controls.Add(this.txtB_login_reg);
            this.pnl_reg.Location = new System.Drawing.Point(94, 63);
            this.pnl_reg.Name = "pnl_reg";
            this.pnl_reg.Size = new System.Drawing.Size(456, 323);
            this.pnl_reg.TabIndex = 5;
            // 
            // btn_reg_OK
            // 
            this.btn_reg_OK.Location = new System.Drawing.Point(114, 193);
            this.btn_reg_OK.Name = "btn_reg_OK";
            this.btn_reg_OK.Size = new System.Drawing.Size(228, 71);
            this.btn_reg_OK.TabIndex = 4;
            this.btn_reg_OK.Text = "Зарегистрироваться";
            this.btn_reg_OK.UseVisualStyleBackColor = true;
            this.btn_reg_OK.Click += new System.EventHandler(this.btn_reg_OK_Click);
            // 
            // lbl_password_reg
            // 
            this.lbl_password_reg.AutoSize = true;
            this.lbl_password_reg.Location = new System.Drawing.Point(83, 118);
            this.lbl_password_reg.Name = "lbl_password_reg";
            this.lbl_password_reg.Size = new System.Drawing.Size(57, 17);
            this.lbl_password_reg.TabIndex = 3;
            this.lbl_password_reg.Text = "Пароль";
            // 
            // lbl_login_reg
            // 
            this.lbl_login_reg.AutoSize = true;
            this.lbl_login_reg.Location = new System.Drawing.Point(83, 59);
            this.lbl_login_reg.Name = "lbl_login_reg";
            this.lbl_login_reg.Size = new System.Drawing.Size(47, 17);
            this.lbl_login_reg.TabIndex = 2;
            this.lbl_login_reg.Text = "Логин";
            // 
            // txtB_password_reg
            // 
            this.txtB_password_reg.Location = new System.Drawing.Point(86, 138);
            this.txtB_password_reg.Name = "txtB_password_reg";
            this.txtB_password_reg.Size = new System.Drawing.Size(284, 22);
            this.txtB_password_reg.TabIndex = 1;
            this.txtB_password_reg.TextChanged += new System.EventHandler(this.txtB_password_reg_TextChanged);
            // 
            // txtB_login_reg
            // 
            this.txtB_login_reg.Location = new System.Drawing.Point(86, 79);
            this.txtB_login_reg.MaxLength = 50;
            this.txtB_login_reg.Name = "txtB_login_reg";
            this.txtB_login_reg.Size = new System.Drawing.Size(284, 22);
            this.txtB_login_reg.TabIndex = 0;
            this.txtB_login_reg.TextChanged += new System.EventHandler(this.txtB_login_reg_TextChanged);
            // 
            // btn_again
            // 
            this.btn_again.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_again.Location = new System.Drawing.Point(255, 392);
            this.btn_again.Name = "btn_again";
            this.btn_again.Size = new System.Drawing.Size(138, 45);
            this.btn_again.TabIndex = 5;
            this.btn_again.Text = "Назад";
            this.btn_again.UseVisualStyleBackColor = true;
            this.btn_again.Click += new System.EventHandler(this.btn_again_Click);
            // 
            // frm_reg_and_auth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 449);
            this.Controls.Add(this.btn_again);
            this.Controls.Add(this.pnl_auth);
            this.Controls.Add(this.pnl_reg);
            this.Controls.Add(this.pnl_reg_or_auth);
            this.Name = "frm_reg_and_auth";
            this.Text = "Авторизация";
            this.pnl_reg_or_auth.ResumeLayout(false);
            this.pnl_auth.ResumeLayout(false);
            this.pnl_auth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erP_login)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erP_password)).EndInit();
            this.pnl_reg.ResumeLayout(false);
            this.pnl_reg.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_auth;
        private System.Windows.Forms.Panel pnl_reg_or_auth;
        private System.Windows.Forms.Panel pnl_auth;
        private System.Windows.Forms.Button btn_reg;
        private System.Windows.Forms.Button btn_auth_OK;
        private System.Windows.Forms.Label lbl_password_auth;
        private System.Windows.Forms.Label lbl_login_auth;
        private System.Windows.Forms.TextBox txtB_password_auth;
        private System.Windows.Forms.TextBox txtB_login_auth;
        private System.Windows.Forms.ErrorProvider erP_login;
        private System.Windows.Forms.ErrorProvider erP_password;
        private System.Windows.Forms.Panel pnl_reg;
        private System.Windows.Forms.Button btn_reg_OK;
        private System.Windows.Forms.Label lbl_password_reg;
        private System.Windows.Forms.Label lbl_login_reg;
        private System.Windows.Forms.TextBox txtB_password_reg;
        private System.Windows.Forms.TextBox txtB_login_reg;
        private System.Windows.Forms.Button btn_again;
        private System.Windows.Forms.Button btn_guest;
    }
}

