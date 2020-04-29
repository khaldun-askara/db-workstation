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
    public partial class add_inventory : Form
    {
        public add_inventory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool is_cancel = false;
            errorProvider1.SetError(txtB_inventory_name, "");

            var txtboxes = new[] { txtB_inventory_name };
            foreach (var txtbox in txtboxes)
                txtbox.Text = login_and_password.DelSpaces(txtbox.Text);

            if (string.IsNullOrWhiteSpace(txtB_inventory_name.Text))
            {
                errorProvider1.SetError(txtB_inventory_name, "Значение не может быть пустым");
                is_cancel = true;
            }
            if (is_cancel)
                return;

            database.InsertInventory(txtB_inventory_name.Text);
            this.DialogResult = DialogResult.OK;
        }
    }
}
