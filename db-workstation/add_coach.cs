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
    public partial class add_coach : Form
    {
        public add_coach()
        {
            InitializeComponent();
            cmB_coach_type.DataSource = database.GetCoachTypes();
            cmB_coach_type.ValueMember = "coach_type_id";
            cmB_coach_type.DisplayMember = "coach_type_name";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool is_cancel = false;
            int temp;
            long passport, tin;
            errorProvider1.SetError(txtB_coach_name, "");
            errorProvider3.SetError(txtB_coach_passport, "");
            errorProvider4.SetError(txtB_coach_tin, "");
            errorProvider5.SetError(txtB_coach_phone, "");
            errorProvider6.SetError(txtB_coach_salary, "");
            errorProvider7.SetError(cmB_coach_type, "");

            var txtboxes = new[] { txtB_coach_name, txtB_coach_passport,
                txtB_coach_tin, txtB_coach_phone, txtB_coach_salary};
            foreach (var txtbox in txtboxes)
                txtbox.Text = login_and_password.DelSpaces(txtbox.Text);

            if (string.IsNullOrWhiteSpace(txtB_coach_name.Text))
            {
                errorProvider1.SetError(txtB_coach_name, "Значение не может быть пустым");
                is_cancel = true;
            }
            if (!Int64.TryParse(txtB_coach_passport.Text, out passport))
            {
                errorProvider3.SetError(txtB_coach_passport, "Введите число");
                is_cancel = true;
            }
            if (!Int64.TryParse(txtB_coach_tin.Text, out tin))
            {
                errorProvider4.SetError(txtB_coach_tin, "Введите число");
                is_cancel = true;
            }
            if (string.IsNullOrWhiteSpace(txtB_coach_phone.Text))
            {
                errorProvider5.SetError(txtB_coach_phone, "Значение не может быть пустым");
                is_cancel = true;
            }
            if (!Int32.TryParse(txtB_coach_salary.Text, out temp))
            {
                errorProvider6.SetError(txtB_coach_salary, "Введите число");
                is_cancel = true;
            }
            
            if (cmB_coach_type.SelectedItem == null)
            {
                errorProvider7.SetError(cmB_coach_type, "Выберите значение!");
                is_cancel = true;
            }

            if (is_cancel)
                return;

            database.InsertCoach(txtB_coach_name.Text,
                                 dtP_coach_birthday.Value,
                                 passport,
                                 tin,
                                 txtB_coach_phone.Text,
                                 temp,
                                 (int)cmB_coach_type.SelectedValue);
            this.DialogResult = DialogResult.OK;
        }
    }
}
