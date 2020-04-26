namespace db_workstation
{
    partial class frm_tables
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
            this.tbC_FCLUB = new System.Windows.Forms.TabControl();
            this.tbP_workout = new System.Windows.Forms.TabPage();
            this.dgv_workout = new System.Windows.Forms.DataGridView();
            this.tbP_coach = new System.Windows.Forms.TabPage();
            this.dgv_coach = new System.Windows.Forms.DataGridView();
            this.tbP_branch = new System.Windows.Forms.TabPage();
            this.dgv_branch = new System.Windows.Forms.DataGridView();
            this.tbP_inventory = new System.Windows.Forms.TabPage();
            this.dgv_inventory = new System.Windows.Forms.DataGridView();
            this.tbP_timetable_for_coach = new System.Windows.Forms.TabPage();
            this.tbLP_choose_coach = new System.Windows.Forms.TableLayoutPanel();
            this.dgv_timetable_for_coach = new System.Windows.Forms.DataGridView();
            this.pnl_choose_coach = new System.Windows.Forms.Panel();
            this.lbl_choose_coach = new System.Windows.Forms.Label();
            this.cmB_choose_coach = new System.Windows.Forms.ComboBox();
            this.tbP_timetable_group_workouts = new System.Windows.Forms.TabPage();
            this.dgv_timetable_today = new System.Windows.Forms.DataGridView();
            this.tbP_users = new System.Windows.Forms.TabPage();
            this.lv_main = new System.Windows.Forms.ListView();
            this.menuStrip_main = new System.Windows.Forms.MenuStrip();
            this.правкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbC_FCLUB.SuspendLayout();
            this.tbP_workout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_workout)).BeginInit();
            this.tbP_coach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_coach)).BeginInit();
            this.tbP_branch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_branch)).BeginInit();
            this.tbP_inventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_inventory)).BeginInit();
            this.tbP_timetable_for_coach.SuspendLayout();
            this.tbLP_choose_coach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_timetable_for_coach)).BeginInit();
            this.pnl_choose_coach.SuspendLayout();
            this.tbP_timetable_group_workouts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_timetable_today)).BeginInit();
            this.tbP_users.SuspendLayout();
            this.menuStrip_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbC_FCLUB
            // 
            this.tbC_FCLUB.Controls.Add(this.tbP_workout);
            this.tbC_FCLUB.Controls.Add(this.tbP_coach);
            this.tbC_FCLUB.Controls.Add(this.tbP_branch);
            this.tbC_FCLUB.Controls.Add(this.tbP_inventory);
            this.tbC_FCLUB.Controls.Add(this.tbP_timetable_for_coach);
            this.tbC_FCLUB.Controls.Add(this.tbP_timetable_group_workouts);
            this.tbC_FCLUB.Controls.Add(this.tbP_users);
            this.tbC_FCLUB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbC_FCLUB.Location = new System.Drawing.Point(0, 0);
            this.tbC_FCLUB.Name = "tbC_FCLUB";
            this.tbC_FCLUB.SelectedIndex = 0;
            this.tbC_FCLUB.Size = new System.Drawing.Size(1211, 631);
            this.tbC_FCLUB.TabIndex = 0;
            this.tbC_FCLUB.SelectedIndexChanged += new System.EventHandler(this.tbC_FCLUB_SelectedIndexChanged);
            // 
            // tbP_workout
            // 
            this.tbP_workout.Controls.Add(this.dgv_workout);
            this.tbP_workout.Location = new System.Drawing.Point(4, 25);
            this.tbP_workout.Name = "tbP_workout";
            this.tbP_workout.Padding = new System.Windows.Forms.Padding(3);
            this.tbP_workout.Size = new System.Drawing.Size(1203, 602);
            this.tbP_workout.TabIndex = 0;
            this.tbP_workout.Text = "Тренировки";
            this.tbP_workout.UseVisualStyleBackColor = true;
            // 
            // dgv_workout
            // 
            this.dgv_workout.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_workout.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_workout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_workout.Location = new System.Drawing.Point(3, 3);
            this.dgv_workout.Name = "dgv_workout";
            this.dgv_workout.RowHeadersWidth = 51;
            this.dgv_workout.RowTemplate.Height = 24;
            this.dgv_workout.Size = new System.Drawing.Size(1197, 596);
            this.dgv_workout.TabIndex = 0;
            this.dgv_workout.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_workout_RowValidating);
            this.dgv_workout.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgv_workout_UserDeletingRow);
            this.dgv_workout.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgv_workout_PreviewKeyDown);
            // 
            // tbP_coach
            // 
            this.tbP_coach.Controls.Add(this.dgv_coach);
            this.tbP_coach.Location = new System.Drawing.Point(4, 25);
            this.tbP_coach.Name = "tbP_coach";
            this.tbP_coach.Padding = new System.Windows.Forms.Padding(3);
            this.tbP_coach.Size = new System.Drawing.Size(1203, 602);
            this.tbP_coach.TabIndex = 1;
            this.tbP_coach.Text = "Тренера";
            this.tbP_coach.UseVisualStyleBackColor = true;
            // 
            // dgv_coach
            // 
            this.dgv_coach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_coach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_coach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_coach.Location = new System.Drawing.Point(3, 3);
            this.dgv_coach.Name = "dgv_coach";
            this.dgv_coach.RowHeadersWidth = 51;
            this.dgv_coach.RowTemplate.Height = 24;
            this.dgv_coach.Size = new System.Drawing.Size(1197, 596);
            this.dgv_coach.TabIndex = 1;
            this.dgv_coach.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_coach_RowValidating);
            this.dgv_coach.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgv_coach_UserDeletingRow);
            this.dgv_coach.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgv_coach_PreviewKeyDown);
            // 
            // tbP_branch
            // 
            this.tbP_branch.Controls.Add(this.dgv_branch);
            this.tbP_branch.Location = new System.Drawing.Point(4, 25);
            this.tbP_branch.Name = "tbP_branch";
            this.tbP_branch.Padding = new System.Windows.Forms.Padding(3);
            this.tbP_branch.Size = new System.Drawing.Size(1203, 602);
            this.tbP_branch.TabIndex = 2;
            this.tbP_branch.Text = "Филиалы";
            this.tbP_branch.UseVisualStyleBackColor = true;
            // 
            // dgv_branch
            // 
            this.dgv_branch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_branch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_branch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_branch.Location = new System.Drawing.Point(3, 3);
            this.dgv_branch.Name = "dgv_branch";
            this.dgv_branch.RowHeadersWidth = 51;
            this.dgv_branch.RowTemplate.Height = 24;
            this.dgv_branch.Size = new System.Drawing.Size(1197, 596);
            this.dgv_branch.TabIndex = 1;
            this.dgv_branch.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_branch_RowValidating);
            this.dgv_branch.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgv_branch_UserDeletingRow);
            this.dgv_branch.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgv_branch_PreviewKeyDown);
            // 
            // tbP_inventory
            // 
            this.tbP_inventory.Controls.Add(this.dgv_inventory);
            this.tbP_inventory.Location = new System.Drawing.Point(4, 25);
            this.tbP_inventory.Name = "tbP_inventory";
            this.tbP_inventory.Padding = new System.Windows.Forms.Padding(3);
            this.tbP_inventory.Size = new System.Drawing.Size(1203, 602);
            this.tbP_inventory.TabIndex = 3;
            this.tbP_inventory.Text = "Инвентарь";
            this.tbP_inventory.UseVisualStyleBackColor = true;
            // 
            // dgv_inventory
            // 
            this.dgv_inventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_inventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_inventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_inventory.Location = new System.Drawing.Point(3, 3);
            this.dgv_inventory.Name = "dgv_inventory";
            this.dgv_inventory.RowHeadersWidth = 51;
            this.dgv_inventory.RowTemplate.Height = 24;
            this.dgv_inventory.Size = new System.Drawing.Size(1197, 596);
            this.dgv_inventory.TabIndex = 1;
            this.dgv_inventory.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_inventory_RowValidating);
            this.dgv_inventory.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgv_inventory_UserDeletingRow);
            this.dgv_inventory.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgv_inventory_PreviewKeyDown);
            // 
            // tbP_timetable_for_coach
            // 
            this.tbP_timetable_for_coach.Controls.Add(this.tbLP_choose_coach);
            this.tbP_timetable_for_coach.Location = new System.Drawing.Point(4, 25);
            this.tbP_timetable_for_coach.Name = "tbP_timetable_for_coach";
            this.tbP_timetable_for_coach.Padding = new System.Windows.Forms.Padding(3);
            this.tbP_timetable_for_coach.Size = new System.Drawing.Size(1203, 602);
            this.tbP_timetable_for_coach.TabIndex = 4;
            this.tbP_timetable_for_coach.Text = "Расписание тренеров";
            this.tbP_timetable_for_coach.UseVisualStyleBackColor = true;
            // 
            // tbLP_choose_coach
            // 
            this.tbLP_choose_coach.ColumnCount = 1;
            this.tbLP_choose_coach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbLP_choose_coach.Controls.Add(this.dgv_timetable_for_coach, 0, 1);
            this.tbLP_choose_coach.Controls.Add(this.pnl_choose_coach, 0, 0);
            this.tbLP_choose_coach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLP_choose_coach.Location = new System.Drawing.Point(3, 3);
            this.tbLP_choose_coach.Name = "tbLP_choose_coach";
            this.tbLP_choose_coach.RowCount = 2;
            this.tbLP_choose_coach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.57718F));
            this.tbLP_choose_coach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.42282F));
            this.tbLP_choose_coach.Size = new System.Drawing.Size(1197, 596);
            this.tbLP_choose_coach.TabIndex = 0;
            // 
            // dgv_timetable_for_coach
            // 
            this.dgv_timetable_for_coach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_timetable_for_coach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_timetable_for_coach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_timetable_for_coach.Location = new System.Drawing.Point(3, 71);
            this.dgv_timetable_for_coach.Name = "dgv_timetable_for_coach";
            this.dgv_timetable_for_coach.RowHeadersWidth = 51;
            this.dgv_timetable_for_coach.RowTemplate.Height = 24;
            this.dgv_timetable_for_coach.Size = new System.Drawing.Size(1191, 522);
            this.dgv_timetable_for_coach.TabIndex = 5;
            // 
            // pnl_choose_coach
            // 
            this.pnl_choose_coach.Controls.Add(this.lbl_choose_coach);
            this.pnl_choose_coach.Controls.Add(this.cmB_choose_coach);
            this.pnl_choose_coach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_choose_coach.Location = new System.Drawing.Point(3, 3);
            this.pnl_choose_coach.Name = "pnl_choose_coach";
            this.pnl_choose_coach.Size = new System.Drawing.Size(1191, 62);
            this.pnl_choose_coach.TabIndex = 2;
            // 
            // lbl_choose_coach
            // 
            this.lbl_choose_coach.AutoSize = true;
            this.lbl_choose_coach.Location = new System.Drawing.Point(29, 22);
            this.lbl_choose_coach.Name = "lbl_choose_coach";
            this.lbl_choose_coach.Size = new System.Drawing.Size(137, 17);
            this.lbl_choose_coach.TabIndex = 4;
            this.lbl_choose_coach.Text = "Выберите тренера:";
            // 
            // cmB_choose_coach
            // 
            this.cmB_choose_coach.FormattingEnabled = true;
            this.cmB_choose_coach.Location = new System.Drawing.Point(172, 19);
            this.cmB_choose_coach.Name = "cmB_choose_coach";
            this.cmB_choose_coach.Size = new System.Drawing.Size(274, 24);
            this.cmB_choose_coach.TabIndex = 3;
            this.cmB_choose_coach.SelectedIndexChanged += new System.EventHandler(this.cmB_choose_coach_SelectedIndexChanged);
            // 
            // tbP_timetable_group_workouts
            // 
            this.tbP_timetable_group_workouts.Controls.Add(this.dgv_timetable_today);
            this.tbP_timetable_group_workouts.Location = new System.Drawing.Point(4, 25);
            this.tbP_timetable_group_workouts.Name = "tbP_timetable_group_workouts";
            this.tbP_timetable_group_workouts.Padding = new System.Windows.Forms.Padding(3);
            this.tbP_timetable_group_workouts.Size = new System.Drawing.Size(1203, 602);
            this.tbP_timetable_group_workouts.TabIndex = 5;
            this.tbP_timetable_group_workouts.Text = "Расписание групповых тренировок (сегодня)";
            this.tbP_timetable_group_workouts.UseVisualStyleBackColor = true;
            // 
            // dgv_timetable_today
            // 
            this.dgv_timetable_today.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_timetable_today.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_timetable_today.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_timetable_today.Location = new System.Drawing.Point(3, 3);
            this.dgv_timetable_today.Name = "dgv_timetable_today";
            this.dgv_timetable_today.RowHeadersWidth = 51;
            this.dgv_timetable_today.RowTemplate.Height = 24;
            this.dgv_timetable_today.Size = new System.Drawing.Size(1197, 596);
            this.dgv_timetable_today.TabIndex = 1;
            // 
            // tbP_users
            // 
            this.tbP_users.Controls.Add(this.lv_main);
            this.tbP_users.Controls.Add(this.menuStrip_main);
            this.tbP_users.Location = new System.Drawing.Point(4, 25);
            this.tbP_users.Name = "tbP_users";
            this.tbP_users.Padding = new System.Windows.Forms.Padding(3);
            this.tbP_users.Size = new System.Drawing.Size(1203, 602);
            this.tbP_users.TabIndex = 6;
            this.tbP_users.Text = "Пользователи АРМ";
            this.tbP_users.UseVisualStyleBackColor = true;
            // 
            // lv_main
            // 
            this.lv_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_main.FullRowSelect = true;
            this.lv_main.HideSelection = false;
            this.lv_main.Location = new System.Drawing.Point(3, 31);
            this.lv_main.Name = "lv_main";
            this.lv_main.Size = new System.Drawing.Size(1197, 568);
            this.lv_main.TabIndex = 3;
            this.lv_main.UseCompatibleStateImageBehavior = false;
            this.lv_main.View = System.Windows.Forms.View.Details;
            // 
            // menuStrip_main
            // 
            this.menuStrip_main.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.правкаToolStripMenuItem});
            this.menuStrip_main.Location = new System.Drawing.Point(3, 3);
            this.menuStrip_main.Name = "menuStrip_main";
            this.menuStrip_main.Size = new System.Drawing.Size(1197, 28);
            this.menuStrip_main.TabIndex = 2;
            this.menuStrip_main.Text = "menuStrip1";
            // 
            // правкаToolStripMenuItem
            // 
            this.правкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.изменитьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
            this.правкаToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.правкаToolStripMenuItem.Text = "Правка";
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.добавитьToolStripMenuItem_Click);
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.изменитьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // frm_tables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 631);
            this.Controls.Add(this.tbC_FCLUB);
            this.Name = "frm_tables";
            this.Text = "Фитнес-клуб \"Оригинальное название\"";
            this.tbC_FCLUB.ResumeLayout(false);
            this.tbP_workout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_workout)).EndInit();
            this.tbP_coach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_coach)).EndInit();
            this.tbP_branch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_branch)).EndInit();
            this.tbP_inventory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_inventory)).EndInit();
            this.tbP_timetable_for_coach.ResumeLayout(false);
            this.tbLP_choose_coach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_timetable_for_coach)).EndInit();
            this.pnl_choose_coach.ResumeLayout(false);
            this.pnl_choose_coach.PerformLayout();
            this.tbP_timetable_group_workouts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_timetable_today)).EndInit();
            this.tbP_users.ResumeLayout(false);
            this.tbP_users.PerformLayout();
            this.menuStrip_main.ResumeLayout(false);
            this.menuStrip_main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbC_FCLUB;
        private System.Windows.Forms.TabPage tbP_workout;
        private System.Windows.Forms.TabPage tbP_coach;
        private System.Windows.Forms.DataGridView dgv_workout;
        private System.Windows.Forms.DataGridView dgv_coach;
        private System.Windows.Forms.TabPage tbP_branch;
        private System.Windows.Forms.DataGridView dgv_branch;
        private System.Windows.Forms.TabPage tbP_inventory;
        private System.Windows.Forms.DataGridView dgv_inventory;
        private System.Windows.Forms.TabPage tbP_timetable_for_coach;
        private System.Windows.Forms.TabPage tbP_timetable_group_workouts;
        private System.Windows.Forms.DataGridView dgv_timetable_today;
        private System.Windows.Forms.TableLayoutPanel tbLP_choose_coach;
        private System.Windows.Forms.Panel pnl_choose_coach;
        private System.Windows.Forms.Label lbl_choose_coach;
        private System.Windows.Forms.ComboBox cmB_choose_coach;
        private System.Windows.Forms.TabPage tbP_users;
        private System.Windows.Forms.ListView lv_main;
        private System.Windows.Forms.MenuStrip menuStrip_main;
        private System.Windows.Forms.ToolStripMenuItem правкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgv_timetable_for_coach;
    }
}