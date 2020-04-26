using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace db_workstation
{
    public partial class frm_reg_and_auth : Form
    {
        private void Again()
        {
            pnl_reg_or_auth.Visible = true;
            pnl_auth.Visible = pnl_reg.Visible = false;
            txtB_login_auth.Text = txtB_password_auth.Text = "";
            txtB_login_reg.Text = txtB_password_reg.Text = "";
            btn_auth_OK.Enabled = btn_reg_OK.Enabled = false;
            btn_again.Visible = false;
        }
        private void btn_again_Click(object sender, EventArgs e)
        {
            Again();
        }
        public frm_reg_and_auth()
        {
            InitializeComponent();
            Again();
        }
        private void btn_auth_Click(object sender, EventArgs e)
        {
            pnl_reg_or_auth.Visible = false;
            btn_again.Visible = true;
            pnl_auth.Visible = true;
        }
        private void btn_reg_Click(object sender, EventArgs e)
        {
            pnl_reg_or_auth.Visible = false;
            btn_again.Visible = true;
            pnl_reg.Visible = true;
        }
        private void EnableRegBTN()
        {
            bool something_wrong = false;
            erP_login.SetError(txtB_login_reg, "");
            erP_login.SetError(txtB_password_reg, "");

            //проверка стирания строк
            if (txtB_login_reg.Text == "" || txtB_login_reg.Text == null)
            {
                erP_login.SetError(txtB_login_reg, "");
                something_wrong = true;
            }
            else
            {
                //проверка корректности и существования логина
                if (!login_and_password.CorrectLogin(txtB_login_reg.Text))
                {
                    something_wrong = true;
                    erP_login.SetError(txtB_login_reg, "Некорректный логин! Доспустимые символы: символы, изображённые на классической русско-английской раскладке клавиатуре, а также любые пробельные символы.");
                }
                if (database.IsLoginExists
                    (login_and_password.DelSpaces
                    (txtB_login_reg.Text)))
                {
                    something_wrong = true;
                    erP_login.SetError(txtB_login_reg, "Логин занят.");
                }
            }
            if (txtB_password_reg.Text == "" || txtB_password_reg.Text == null)
            {
                erP_login.SetError(txtB_password_reg, "");
                something_wrong = true;
            }
            else
            {
                // проверка сложности пароля
                if (login_and_password.PasswordScore
                    (login_and_password.DelBorderSpaces
                    (txtB_password_reg.Text)) <=2)
                {
                    something_wrong = true;
                    erP_login.SetError(txtB_password_reg, "Пароль слишком простой.");
                }
            }

            if (something_wrong)
            {
                btn_reg_OK.Enabled = false;
                return;
            }
            btn_reg_OK.Enabled = true;
        }
        private void txtB_login_reg_TextChanged(object sender, EventArgs e)
        {
            EnableRegBTN();
        }
        private void txtB_password_reg_TextChanged(object sender, EventArgs e)
        {
            EnableRegBTN();
        }
        private void btn_reg_OK_Click(object sender, EventArgs e)
        {
            string correct_login = (login_and_password.DelSpaces(txtB_login_reg.Text));
            string correct_password = (login_and_password.DelBorderSpaces(txtB_password_reg.Text));
            btn_reg_OK.Text = "Подождите...";
            try
            {
                database.AddUser(correct_login, correct_password);
            }
            catch
            {
                MessageBox.Show("Ой! Что-то пошло не так! Попробуйте снова! (｡╯3╰｡)");
                Again();
                btn_reg_OK.Text = "Зарегистрироваться";
                return;
            }
            btn_reg_OK.Text = "Зарегистрироваться";
            MessageBox.Show("Регистрация прошла успешно!");
            Again();
        }
        private void txtB_login_auth_TextChanged(object sender, EventArgs e)
        {
            btn_auth_OK.Enabled = true;
        }
        private void txtB_password_auth_TextChanged(object sender, EventArgs e)
        {
            btn_auth_OK.Enabled = true;
        }
        private void btn_auth_OK_Click(object sender, EventArgs e)
        {
            string correct_login = (login_and_password.DelSpaces(txtB_login_auth.Text));
            string correct_password = (login_and_password.DelBorderSpaces(txtB_password_auth.Text));
            if (!database.IsLoginExists(correct_login))
            {
                MessageBox.Show("Неверный логин или пароль!");
                return;
            }
            try
            {
                (string, string) goodhash_salt = database.GoodHashAndSalt(correct_login);
                if (!login_and_password.VerifyPassword(correct_password, goodhash_salt.Item2, goodhash_salt.Item1))
                {
                    MessageBox.Show("Неверный логин или пароль!");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Ой! Что-то пошло не так! Попробуйте снова! (｡╯3╰｡)");
                Again();
                return;
            }
            MessageBox.Show("Аутентификация прошла успешно!");
            frm_tables arm;
            int role_id = database.ReturnRole(correct_login);
            switch (role_id)
            {
                case 1: arm = new frm_tables(Role.Admin); break;
                case 2: arm = new frm_tables(Role.Operator); break;
                default: arm = new frm_tables(); break;
            }
            this.Hide();
            arm.ShowDialog();
            this.Show();
            Again();
        }

        private void btn_guest_Click(object sender, EventArgs e)
        {
            frm_tables arm = new frm_tables();
            this.Hide();
            arm.ShowDialog();
            this.Show();
            Again();
        }
    }
}
