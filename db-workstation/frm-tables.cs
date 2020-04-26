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
    public enum Role
    {
        Guest,
        Operator,
        Admin
    }
    public partial class frm_tables : Form
    {
        public frm_tables(Role user_role = Role.Guest)
        {
            InitializeComponent();
            InitializetbC_FCLUB(user_role);
        }

        public void InitializetbC_FCLUB(Role user_role)
        {
            // инициализация всех дгв, кроме users
            database.InitializeDGVWorkout(dgv_workout);
            database.InitializeDGVCoach(dgv_coach);
            database.InitializeDGVBranch(dgv_branch);
            database.InitializeDGVInventory(dgv_inventory);

            //запросы???
            cmB_choose_coach.DisplayMember = "coach_name";
            cmB_choose_coach.ValueMember = "coach_id";
            cmB_choose_coach.DataSource = database.GetCoachNames();
            database.InitializeDGVtimetable_today(dgv_timetable_today);


            switch (user_role)
            {
                case (Role.Guest): tbC_FCLUB.TabPages.Remove(tbP_users);
                    dgv_workout.ReadOnly = dgv_coach.ReadOnly = dgv_branch.ReadOnly = dgv_inventory.ReadOnly = true; break;
                case (Role.Admin): database.InitialiseLV(lv_main); break;
                case (Role.Operator): tbC_FCLUB.TabPages.Remove(tbP_users); break;
            }
        }

        private void dgv_workout_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            long temp = 0;

            var row = dgv_workout.Rows[e.RowIndex];
            if (!dgv_workout.IsCurrentRowDirty)
                return;
            row.ErrorText = "";

            var cellsWithStringErrors = new[] {row.Cells["workout_name"],
                                                   row.Cells["workout_description"],
                                                row.Cells["workout_begin_time"]};
            foreach (var cell in cellsWithStringErrors)
            {
                cell.ErrorText = "";
                if (string.IsNullOrWhiteSpace((string)cell.Value))
                {
                    cell.ErrorText = "Значение не может быть пустым";
                    e.Cancel = true;
                }
            }

            var cellsWithNumberErrors = new[] { row.Cells["workout_length"] };
            foreach (var cell in cellsWithNumberErrors)
            {
                cell.ErrorText = "";
                if (!Int64.TryParse(Convert.ToString(cell.Value), out temp))
                {
                    cell.ErrorText = "Введите число";
                    e.Cancel = true;
                }
            }

            var cellsWithComboBoxErrors = new[] {row.Cells["workout_workout_type_id"],
                                                row.Cells["workout_coach_id"],
                                                row.Cells["workout_branch_id"]};
            foreach (var cell in cellsWithComboBoxErrors)
            {
                cell.ErrorText = "";
                if (cell.Value == null)
                {
                    cell.ErrorText = "Выберите значение!";
                    e.Cancel = true;
                }
            }

            if (!e.Cancel)
            {
                Dictionary<string, object> workout_data;
                var workout_id = (int?)row.Cells["workout_id"].Value;
                if (workout_id.HasValue)
                {
                    database.UpdateWorkout(Convert.ToInt32(row.Cells["workout_id"].Value),
                                            Convert.ToInt32(row.Cells["workout_branch_id"].Value),
                                            Convert.ToInt32(row.Cells["workout_coach_id"].Value),
                                            (string)row.Cells["workout_name"].Value,
                                            Convert.ToInt32(row.Cells["workout_workout_type_id"].Value),
                                            (string)row.Cells["workout_description"].Value,
                                            Convert.ToInt32(row.Cells["workout_length"].Value),
                                            (DateTime)row.Cells["workout_begin_date"].Value,
                                            (string)row.Cells["workout_begin_time"].Value);
                    workout_data = ((Dictionary<string, object>)row.Tag);
                }
                else
                {
                    row.Cells["workout_id"].Value = database.InsertWorkout(Convert.ToInt32(row.Cells["workout_branch_id"].Value),
                                            Convert.ToInt32(row.Cells["workout_coach_id"].Value),
                                            (string)row.Cells["workout_name"].Value,
                                            Convert.ToInt32(row.Cells["workout_workout_type_id"].Value),
                                            (string)row.Cells["workout_description"].Value,
                                            Convert.ToInt32(row.Cells["workout_length"].Value),
                                            (DateTime)row.Cells["workout_begin_date"].Value,
                                            (string)row.Cells["workout_begin_time"].Value);
                    workout_data = new Dictionary<string, object>();
                }
                foreach (var columnsName in new[] { "workout_branch_id",
                                                         "workout_coach_id",
                                                         "workout_name",
                                                         "workout_workout_type_id",
                                                         "workout_description",
                                                         "workout_length",
                                                         "workout_begin_date",
                                                         "workout_begin_time"})
                {
                    workout_data[columnsName] = row.Cells[columnsName].Value;
                }
                row.Tag = workout_data;
            }
        }

        private void dgv_coach_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            long temp = 0;

            // возврат, если строка не менялась
            var row = dgv_coach.Rows[e.RowIndex];
            if (!dgv_coach.IsCurrentRowDirty)
                return;
            row.ErrorText = "";

            // проверка текстовых значений
            var cellsWithStringErrors = new[] {row.Cells["coach_name"],
                                                   row.Cells["coach_phone"]};
            foreach (var cell in cellsWithStringErrors)
            {
                cell.ErrorText = "";
                if (string.IsNullOrWhiteSpace((string)cell.Value))
                {
                    cell.ErrorText = "Значение не может быть пустым";
                    e.Cancel = true;
                }
            }

            // проверка числовых значений
            var cellsWithNumberErrors = new[] {row.Cells["coach_passport"],
                                                row.Cells["coach_tin"],
                                                row.Cells["coach_salary"]};
            foreach (var cell in cellsWithNumberErrors)
            {
                cell.ErrorText = "";
                if (!Int64.TryParse(Convert.ToString(cell.Value), out temp))
                {
                    cell.ErrorText = "Введите число";
                    e.Cancel = true;
                }
            }

            // проверка комбобокса
            row.Cells["coach_coach_type_id"].ErrorText = "";
            if (row.Cells["coach_coach_type_id"].Value == null)
            {
                row.Cells["coach_coach_type_id"].ErrorText = "Выберите значение!";
                e.Cancel = true;
            }

            if (!e.Cancel)
            {
                Dictionary<string, object> coach_data;
                var coach_id = (int?)row.Cells["coach_id"].Value;
                if (coach_id.HasValue)
                {
                    database.UpdateCoach(Convert.ToInt32(row.Cells["coach_id"].Value),
                                              (string)row.Cells["coach_name"].Value,
                                              (DateTime)row.Cells["coach_birthday"].Value,
                                              Convert.ToInt64(row.Cells["coach_passport"].Value),
                                              Convert.ToInt64(row.Cells["coach_tin"].Value),
                                              (string)row.Cells["coach_phone"].Value,
                                              Convert.ToInt32(row.Cells["coach_salary"].Value),
                                              Convert.ToInt32(row.Cells["coach_coach_type_id"].Value));
                    coach_data = ((Dictionary<string, object>)row.Tag);
                }
                else
                {
                    row.Cells["coach_id"].Value = database.InsertCoach((string)row.Cells["coach_name"].Value,
                                               (DateTime)row.Cells["coach_birthday"].Value,
                                               Convert.ToInt64(row.Cells["coach_passport"].Value),
                                               Convert.ToInt64(row.Cells["coach_tin"].Value),
                                               (string)row.Cells["coach_phone"].Value,
                                               Convert.ToInt32(row.Cells["coach_salary"].Value),
                                               Convert.ToInt32(row.Cells["coach_coach_type_id"].Value));
                    coach_data = new Dictionary<string, object>();
                }
                foreach (var columnsName in new[] { "coach_name",
                                                        "coach_birthday",
                                                        "coach_passport",
                                                        "coach_tin",
                                                        "coach_phone",
                                                        "coach_salary",
                                                        "coach_coach_type_id"})
                {
                    coach_data[columnsName] = row.Cells[columnsName].Value;
                }
                row.Tag = coach_data;
            }
        }

        private void dgv_coach_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var coach_id = (int?)e.Row.Cells["coach_id"].Value;
            if (coach_id.HasValue)
                database.DeleteCoach(coach_id.Value);
        }

        private void dgv_coach_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && dgv_coach.IsCurrentRowDirty)
            {
                dgv_coach.CancelEdit();
                if (dgv_coach.CurrentRow.Cells["coach_id"].Value != null)
                {
                    dgv_coach.CurrentRow.ErrorText = "";
                    foreach (var kvp in (Dictionary<string, object>)dgv_coach.CurrentRow.Tag)
                    {
                        if (kvp.Key == "coach_coach_type_id") continue;
                        dgv_coach.CurrentRow.Cells[kvp.Key].Value = kvp.Value;
                        dgv_coach.CurrentRow.Cells[kvp.Key].ErrorText = "";
                    }
                    ((DataGridViewComboBoxCell)dgv_coach.CurrentRow.Cells["coach_coach_type_id"]).Value = ((Dictionary<string, object>)dgv_coach.CurrentRow.Tag)["coach_coach_type_id"];
                }
                else
                {
                    dgv_coach.Rows.Remove(dgv_coach.CurrentRow);
                }
            }
        }

        private void dgv_workout_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var workout_id = (int?)e.Row.Cells["workout_id"].Value;
            if (workout_id.HasValue)
                database.DeleteWorkout(workout_id.Value);
        }

        private void dgv_workout_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && dgv_workout.IsCurrentRowDirty)
            {
                dgv_workout.CancelEdit();
                if (dgv_workout.CurrentRow.Cells["workout_id"].Value != null)
                {
                    dgv_workout.CurrentRow.ErrorText = "";
                    foreach (var kvp in (Dictionary<string, object>)dgv_workout.CurrentRow.Tag)
                    {
                        if (kvp.Key == "workout_workout_type_id" || kvp.Key == "workout_coach_id" || kvp.Key == "workout_branch_id") continue;
                        dgv_workout.CurrentRow.Cells[kvp.Key].Value = kvp.Value;
                        dgv_workout.CurrentRow.Cells[kvp.Key].ErrorText = "";
                    }
                    ((DataGridViewComboBoxCell)dgv_workout.CurrentRow.Cells["workout_workout_type_id"]).Value =
                                ((Dictionary<string, object>)dgv_workout.CurrentRow.Tag)["workout_workout_type_id"];
                    ((DataGridViewComboBoxCell)dgv_workout.CurrentRow.Cells["workout_coach_id"]).Value =
                                ((Dictionary<string, object>)dgv_workout.CurrentRow.Tag)["workout_coach_id"];
                    ((DataGridViewComboBoxCell)dgv_workout.CurrentRow.Cells["workout_branch_id"]).Value =
                                ((Dictionary<string, object>)dgv_workout.CurrentRow.Tag)["workout_branch_id"];
                }
                else
                {
                    dgv_workout.Rows.Remove(dgv_workout.CurrentRow);
                }
            }
        }

        private void dgv_branch_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var branch_id = (int?)e.Row.Cells["branch_id"].Value;
            if (branch_id.HasValue)
                database.DeleteBranch(branch_id.Value);
        }

        private void dgv_branch_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            long temp = 0;

            var row = dgv_branch.Rows[e.RowIndex];
            if (!dgv_branch.IsCurrentRowDirty)
                return;
            row.ErrorText = "";

            var cellsWithStringErrors = new[] {row.Cells["branch_address"],
                                                   row.Cells["branch_phone"],
                                                row.Cells["branch_working_hours"]};
            foreach (var cell in cellsWithStringErrors)
            {
                cell.ErrorText = "";
                if (string.IsNullOrWhiteSpace((string)cell.Value))
                {
                    cell.ErrorText = "Значение не может быть пустым";
                    e.Cancel = true;
                }
            }

            var cellsWithNumberErrors = new[] { row.Cells["branch_area"] };
            foreach (var cell in cellsWithNumberErrors)
            {
                cell.ErrorText = "";
                if (!Int64.TryParse(Convert.ToString(cell.Value), out temp))
                {
                    cell.ErrorText = "Введите число";
                    e.Cancel = true;
                }
            }

            if (row.Tag != null
                && (string)row.Cells["branch_address"].Value != (string)((Dictionary<string, object>)row.Tag)["branch_address"]
                && database.FindBranchName((string)row.Cells["branch_address"].Value)
                || row.Tag == null && database.FindBranchName((string)row.Cells["branch_address"].Value))
            {
                row.Cells["branch_address"].ErrorText = "Филиал по данному адресу уже существует.";
                e.Cancel = true;
            }

            if (!e.Cancel)
            {
                Dictionary<string, object> branch_data;
                var branch_id = (int?)row.Cells["branch_id"].Value;
                if (branch_id.HasValue)
                {
                    database.UpdateBranch(Convert.ToInt32(row.Cells["branch_id"].Value),
                                            (string)row.Cells["branch_address"].Value,
                                            (string)row.Cells["branch_phone"].Value,
                                            Convert.ToInt32(row.Cells["branch_area"].Value),
                                            (string)row.Cells["branch_working_hours"].Value);
                    branch_data = ((Dictionary<string, object>)row.Tag);
                }
                else
                {
                    row.Cells["branch_id"].Value = database.InsertBranch((string)row.Cells["branch_address"].Value,
                                            (string)row.Cells["branch_phone"].Value,
                                            Convert.ToInt32(row.Cells["branch_area"].Value),
                                            (string)row.Cells["branch_working_hours"].Value);
                    branch_data = new Dictionary<string, object>();
                }
                foreach (var columnsName in new[] { "branch_address",
                                                         "branch_phone",
                                                         "branch_area",
                                                         "branch_working_hours"})
                {
                    branch_data[columnsName] = row.Cells[columnsName].Value;
                }
                row.Tag = branch_data;
            }
        }

        private void dgv_branch_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && dgv_branch.IsCurrentRowDirty)
            {
                dgv_branch.CancelEdit();
                if (dgv_branch.CurrentRow.Cells["branch_id"].Value != null)
                {
                    dgv_branch.CurrentRow.ErrorText = "";
                    foreach (var kvp in (Dictionary<string, object>)dgv_branch.CurrentRow.Tag)
                    {
                        dgv_branch.CurrentRow.Cells[kvp.Key].Value = kvp.Value;
                        dgv_branch.CurrentRow.Cells[kvp.Key].ErrorText = "";
                    }
                }
                else
                {
                    dgv_branch.Rows.Remove(dgv_branch.CurrentRow);
                }
            }
        }

        private void dgv_inventory_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            long temp = 0;

            var row = dgv_inventory.Rows[e.RowIndex];
            if (!dgv_inventory.IsCurrentRowDirty)
                return;
            row.ErrorText = "";


            var cellsWithNumberErrors = new[] { row.Cells["number"] };
            foreach (var cell in cellsWithNumberErrors)
            {
                cell.ErrorText = "";
                if (!Int64.TryParse(Convert.ToString(cell.Value), out temp))
                {
                    cell.ErrorText = "Введите число";
                    e.Cancel = true;
                }
            }

            var cellsWithComboBoxErrors = new[] {row.Cells["branch_id"],
                                                row.Cells["inventory_id"]};
            foreach (var cell in cellsWithComboBoxErrors)
            {
                cell.ErrorText = "";
                if (cell.Value == null)
                {
                    cell.ErrorText = "Выберите значение!";
                    e.Cancel = true;
                }
            }

            if (row.Tag != null
                && ((int)row.Cells["branch_id"].Value != (int)((Dictionary<string, object>)row.Tag)["branch_id"]
                || (int)row.Cells["inventory_id"].Value != (int)((Dictionary<string, object>)row.Tag)["inventory_id"])
                && database.FindBranchInventoryCouple((int)row.Cells["branch_id"].Value, (int)row.Cells["inventory_id"].Value)
                || row.Tag == null && database.FindBranchInventoryCouple((int)row.Cells["branch_id"].Value, (int)row.Cells["inventory_id"].Value))
            {
                row.ErrorText = "Информация о количестве этого инвентаря в этом филиале уже существует.";
                e.Cancel = true;
            }

            if (!e.Cancel)
            {
                Dictionary<string, object> inventory_data;
                if (row.Tag != null)
                {
                    database.UpdateInventory(Convert.ToInt32(((Dictionary<string, object>)row.Tag)["branch_id"]),
                                            Convert.ToInt32(((Dictionary<string, object>)row.Tag)["inventory_id"]),
                                            Convert.ToInt32(row.Cells["branch_id"].Value),
                                            Convert.ToInt32(row.Cells["inventory_id"].Value),
                                            Convert.ToInt32(row.Cells["number"].Value));
                    inventory_data = ((Dictionary<string, object>)row.Tag);
                }
                else
                {
                    database.InsertInventory(Convert.ToInt32(row.Cells["branch_id"].Value),
                                            Convert.ToInt32(row.Cells["inventory_id"].Value),
                                            Convert.ToInt32(row.Cells["number"].Value));
                    inventory_data = new Dictionary<string, object>();
                }
                foreach (var columnsName in new[] { "branch_id",
                                                         "inventory_id",
                                                         "number"})
                {
                    inventory_data[columnsName] = row.Cells[columnsName].Value;
                }
                row.Tag = inventory_data;
            }
        }

        private void dgv_inventory_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && dgv_inventory.IsCurrentRowDirty)
            {
                dgv_inventory.CancelEdit();
                if (dgv_inventory.CurrentRow.Tag != null)
                {
                    dgv_inventory.CurrentRow.ErrorText = "";
                    foreach (var kvp in (Dictionary<string, object>)dgv_inventory.CurrentRow.Tag)
                    {
                        if (kvp.Key == "branch_id" || kvp.Key == "inventory_id") continue;
                        dgv_inventory.CurrentRow.Cells[kvp.Key].Value = kvp.Value;
                        dgv_inventory.CurrentRow.Cells[kvp.Key].ErrorText = "";
                    }
                    ((DataGridViewComboBoxCell)dgv_inventory.CurrentRow.Cells["branch_id"]).Value =
                                ((Dictionary<string, object>)dgv_inventory.CurrentRow.Tag)["branch_id"];
                    ((DataGridViewComboBoxCell)dgv_inventory.CurrentRow.Cells["inventory_id"]).Value =
                                ((Dictionary<string, object>)dgv_inventory.CurrentRow.Tag)["inventory_id"];
                }
                else
                {
                    dgv_inventory.Rows.Remove(dgv_inventory.CurrentRow);
                }
            }
        }

        private void dgv_inventory_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var branch_id = (int?)e.Row.Cells["branch_id"].Value;
            var inventory_id = (int?)e.Row.Cells["inventory_id"].Value;
            if (branch_id.HasValue && inventory_id.HasValue)
                database.DeleteInventory(branch_id.Value, inventory_id.Value);
        }

        private void cmB_choose_coach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmB_choose_coach.SelectedItem == null)
                return;
            database.Initialize_dgv_timetable_for_coach(dgv_timetable_for_coach, (int)cmB_choose_coach.SelectedValue);
        }

        private void tbC_FCLUB_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cur_item = tbC_FCLUB.SelectedIndex;
            switch(cur_item)
            {
                case 0:
                    database.InitializeDGVWorkout(dgv_workout);
                    break;
                case 1:
                    database.InitializeDGVCoach(dgv_coach);
                    break;
                case 2:
                    database.InitializeDGVBranch(dgv_branch);
                    break;
                case 3:
                    database.InitializeDGVInventory(dgv_inventory);
                    break;
                case 4:
                    cmB_choose_coach.DataSource = database.GetCoachNames();
                    break;
                case 5:
                    database.InitializeDGVtimetable_today(dgv_timetable_today);
                    break;
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm_insert = new frm_insertupdate(frm_insertupdate.ActionType.Insert);
            if (frm_insert.ShowDialog() != DialogResult.OK)
                return;
            (long, string, string) add_result = (0, "", "");
            try
            {
                add_result = database.AddUser(
                frm_insert.Login,
                frm_insert.Password,
                frm_insert.Reg_date,
                frm_insert.Role_id);
            }
            catch
            {
                MessageBox.Show("Ой! Что-то пошло не так! Попробуйте снова! (｡╯3╰｡)");
                return;
            }
            var lvi = new ListViewItem(new[]
                    {
                        frm_insert.Login,
                        add_result.Item2,
                        add_result.Item3,
                        ((DateTime) frm_insert.Reg_date).ToLongDateString(),
                        frm_insert.Role_name
                    })
            {
                Tag = Tuple.Create(add_result.Item1, frm_insert.Reg_date, frm_insert.Role_id)
            };
            lv_main.Items.Add(lvi);
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem curr_user in lv_main.SelectedItems)
            {
                var curr_tag = (Tuple<long, DateTime, int>)curr_user.Tag;
                long user_id = curr_tag.Item1;
                DateTime reg_date = curr_tag.Item2;
                int role_id = curr_tag.Item3;
                var frm_insert = new frm_insertupdate(frm_insertupdate.ActionType.Update);
                frm_insert.Login = frm_insert.Old_login = curr_user.SubItems[0].Text;
                frm_insert.Reg_date = reg_date;
                frm_insert.Role_id = role_id;
                if (frm_insert.ShowDialog() != DialogResult.OK)
                    continue;
                (string, string) hash_ahd_salt = ("", "");
                try
                {
                    hash_ahd_salt = database.UpdateUser(user_id,
                    frm_insert.Login,
                    frm_insert.Password,
                    frm_insert.Reg_date,
                    frm_insert.Role_id);
                }
                catch
                {
                    MessageBox.Show("Ой! Что-то пошло не так! Попробуйте снова! (｡╯3╰｡)");
                    return;
                }
                curr_user.SubItems[0].Text = frm_insert.Login;
                if (hash_ahd_salt.Item1 != "")
                {
                    curr_user.SubItems[1].Text = hash_ahd_salt.Item1;
                    curr_user.SubItems[2].Text = hash_ahd_salt.Item2;
                }
                curr_user.SubItems[3].Text = frm_insert.Reg_date.ToLongDateString();
                curr_user.SubItems[4].Text = frm_insert.Role_name;
                curr_user.Tag = Tuple.Create(user_id, frm_insert.Reg_date, frm_insert.Role_id);
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lv_main.SelectedItems.Count <= 0)
                return;
            var frm_delete = new frm_confirm_delete();
            if (frm_delete.ShowDialog() != DialogResult.OK)
                return;
            long[] id_for_delete = lv_main.SelectedItems.Cast<ListViewItem>()
                .Select(x => ((Tuple<long, DateTime>)x.Tag).Item1).ToArray();
            try
            {
                database.DeleteUsers(id_for_delete);
            }
            catch
            {
                MessageBox.Show("Ой! Что-то пошло не так! Попробуйте снова! (｡╯3╰｡)");
                return;
            }
            foreach (ListViewItem curr_user in lv_main.SelectedItems)
                lv_main.Items.Remove(curr_user);
        }
    }

}
