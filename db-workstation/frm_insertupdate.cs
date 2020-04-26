using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace db_workstation
{
    public partial class frm_insertupdate : Form
    {
        private bool check_old_log_not_need = false;
        private string old_login = "";
        public enum ActionType
        {
            Insert,
            Update
        }
        public string Old_login
        {
            set { old_login = value; }
        }
        public string Login
        {
            get { return txtB_login.Text; }
            set { txtB_login.Text = value; }
        }
        public int Role_id
        {
            get { return (int)cmB_role.SelectedValue; }
            set { cmB_role.SelectedItem = value; }
        }
        public string Role_name
        {
            get { return (string)cmB_role.Text; }
        }
        public string Password
        {
            get { return txtB_password.Text; }
        }
        public DateTime Reg_date
        {
            get { return dtp_reg_date.Value; }
            set { dtp_reg_date.Value = value; }
        }
        private void EnableRegBTN()
        {
            bool something_wrong = false;
            erp_login.SetError(txtB_login, "");
            erp_login.SetError(txtB_password, "");

            //проверка стирания строк
            if (txtB_login.Text == "" || txtB_login.Text == null)
            {
                erp_login.SetError(txtB_login, "");
                something_wrong = true;
            }
            else
            {
                //проверка корректности и существования логина
                if (!login_and_password.CorrectLogin(txtB_login.Text))
                {
                    something_wrong = true;
                    erp_login.SetError(txtB_login, "Некорректный логин! Доспустимые символы: символы, изображённые на классической русско-английской раскладке клавиатуре, а также любые пробельные символы.");
                }
                // если добавление, то check_old_log_not_need по умолчанию true, и у нас всегда там true
                // если инзменение, то оно false, и результат зависит от старого логина
                if ((txtB_login.Text != old_login || check_old_log_not_need) && database.IsLoginExists
                    (login_and_password.DelSpaces
                    (txtB_login.Text)))
                {
                    something_wrong = true;
                    erp_login.SetError(txtB_login, "Логин занят.");
                }
            }
            if (txtB_password.Text == "" || txtB_password.Text == null)
            {
                erp_login.SetError(txtB_password, "");
                something_wrong = something_wrong || check_old_log_not_need;
                //something_wrong = true;
            }
            else
            {
                // проверка сложности пароля
                if (login_and_password.PasswordScore
                    (login_and_password.DelBorderSpaces
                    (txtB_password.Text)) <= 2)
                {
                    something_wrong = true;
                    erp_login.SetError(txtB_password, "Пароль слишком простой.");
                }
            }

            if (something_wrong)
            {
                btn_OK.Enabled = false;
                return;
            }
            btn_OK.Enabled = true;
        }
        public frm_insertupdate(ActionType action)
        {
            InitializeComponent();
            btn_OK.Enabled = false;
            switch (action)
            {
                case ActionType.Insert:
                    lbl_password.Text = "Пароль";
                    btn_OK.Text = "Добавить";
                    check_old_log_not_need = true;
                    break;
                case ActionType.Update:
                    lbl_password.Text = "Новый пароль";
                    btn_OK.Text = "Изменить";
                    check_old_log_not_need = false;
                    break;
            }

            cmB_role.DisplayMember = "role_name";
            cmB_role.ValueMember = "role_id";
            cmB_role.DataSource = database.GetRoles();
        }
        private void txtB_login_TextChanged(object sender, EventArgs e)
        {
            EnableRegBTN();
        }
        private void txtB_password_TextChanged(object sender, EventArgs e)
        {
            EnableRegBTN();
        }
    }
}
