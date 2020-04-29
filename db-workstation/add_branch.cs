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
    public partial class add_branch : Form
    {
        public add_branch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool is_cancel = false;
            int temp;
            errorProvider1.SetError(txtB_address, "");
            errorProvider2.SetError(txtB_phone, "");
            errorProvider3.SetError(txtB_area, "");
            errorProvider4.SetError(txtB_working_hours, "");

            var txtboxes = new[] { txtB_address, txtB_phone, txtB_area, txtB_working_hours };
            foreach (var txtbox in txtboxes)
                txtbox.Text = login_and_password.DelSpaces(txtbox.Text);

            if (string.IsNullOrWhiteSpace(txtB_address.Text))
            {
                errorProvider1.SetError(txtB_address, "Значение не может быть пустым");
                is_cancel = true;
            }
            if (!is_cancel && database.FindBranchName(txtB_address.Text))
            {
                errorProvider1.SetError(txtB_address, "Филиал по данному адресу уже существует");
                is_cancel = true;
            }
            if (!Int32.TryParse(txtB_area.Text, out temp))
            {
                errorProvider3.SetError(txtB_area, "Введите число");
                is_cancel = true;
            }
            if (string.IsNullOrWhiteSpace(txtB_phone.Text))
            {
                errorProvider2.SetError(txtB_phone, "Значение не может быть пустым");
                is_cancel = true;
            }
            if (string.IsNullOrWhiteSpace(txtB_working_hours.Text))
            {
                errorProvider4.SetError(txtB_working_hours, "Значение не может быть пустым");
                is_cancel = true;
            }

            if (is_cancel)
                return;

            database.InsertBranch(txtB_address.Text, txtB_phone.Text, temp, txtB_working_hours.Text);
            this.DialogResult = DialogResult.OK;
        }
    }
}
