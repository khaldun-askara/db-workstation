using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace db_workstation
{
    class database
    {
        private static readonly string sConnStr = new NpgsqlConnectionStringBuilder
        {
            Host = "localhost",
            Port = 5432,
            Database = "normalisation",
            Username = Environment.GetEnvironmentVariable("POSTGRESQL_USERNAME"),
            Password = Environment.GetEnvironmentVariable("POSTGRESQL_PASSWORD"),
            AutoPrepareMinUsages = 2,
            MaxAutoPrepare = 10
        }.ConnectionString;
        public static bool IsLoginExists (string login)
        {
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = $@"SELECT COUNT(*) FROM users WHERE lower(@currentLogin) = lower(login);"
                };
                sCommand.Parameters.AddWithValue("@currentLogin", login);
                return (long)sCommand.ExecuteScalar() > 0;
            }
        }
        public static int ReturnRole(string login)
        {
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = $@"SELECT role_id FROM users WHERE lower(@currentLogin) = lower(login);"
                };
                sCommand.Parameters.AddWithValue("@currentLogin", login);
                var reader = sCommand.ExecuteReader();
                reader.Read();
                return Convert.ToInt32(reader["role_id"]);
            }
        }
        public static void AddUser (string login, string password)
        {
            byte[] salt = login_and_password.GetSalt();
            string salt_str = Convert.ToBase64String(salt);
            string hash_str = Convert.ToBase64String(login_and_password.GetHash(password, salt));
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = $@"INSERT INTO users (login, password_hash, salt, reg_date) VALUES (@login, @password_hash, @salt, current_date)"
                };
                sCommand.Parameters.AddWithValue("@login", login);
                sCommand.Parameters.AddWithValue("@password_hash", hash_str);
                sCommand.Parameters.AddWithValue("@salt", salt_str);
                sCommand.ExecuteNonQuery();
            }
        }
        public static (long, string, string) AddUser(string login, string password, DateTime reg_date, int role_id)
        {
            byte[] salt = login_and_password.GetSalt();
            string salt_str = Convert.ToBase64String(salt);
            string hash_str = Convert.ToBase64String(login_and_password.GetHash(password, salt));
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = $@"INSERT INTO users (login, password_hash, salt, reg_date, role_id) VALUES (@login, @password_hash, @salt, @reg_date, @role_id) RETURNING user_id"
                };
                sCommand.Parameters.AddWithValue("@login", login);
                sCommand.Parameters.AddWithValue("@password_hash", hash_str);
                sCommand.Parameters.AddWithValue("@salt", salt_str);
                sCommand.Parameters.AddWithValue("@reg_date", reg_date);
                sCommand.Parameters.AddWithValue("@role_id", role_id);
                return ((long)sCommand.ExecuteScalar(), hash_str, salt_str);
            }
        }
        public static (string, string) GoodHashAndSalt (string login)
        {
            string goodhash = "", salt = "";
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = $@"SELECT * FROM users WHERE lower(@currentLogin) = lower(login);"
                };
                sCommand.Parameters.AddWithValue("@currentLogin", login);
                using (var reader = sCommand.ExecuteReader())
                {
                    reader.Read();
                    goodhash = (string)reader["password_hash"];
                    salt = (string)reader["salt"];
                }
                return (goodhash, salt);
            }
        }

        public static (string, string) UpdateUser(long id, string login, string password, DateTime reg_date, int role_id)
        {
            if (password == null || password == "")
                using (var sConn = new NpgsqlConnection(sConnStr))
                {
                    sConn.Open();
                    var sCommand = new NpgsqlCommand
                    {
                        Connection = sConn,
                        CommandText = $@"UPDATE users
                                    SET login = @login, reg_date = @reg_date, role_id = @role_id
                                    WHERE user_id = @user_id"
                    };
                    sCommand.Parameters.AddWithValue("@user_id", id);
                    sCommand.Parameters.AddWithValue("@login", login);
                    sCommand.Parameters.AddWithValue("@reg_date", reg_date);
                    sCommand.Parameters.AddWithValue("@role_id", role_id);
                    sCommand.ExecuteNonQuery();
                    return ("", "");
                }
            byte[] salt = login_and_password.GetSalt();
            string salt_str = Convert.ToBase64String(salt);
            string hash_str = Convert.ToBase64String(login_and_password.GetHash(password, salt));
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = $@"UPDATE users
                                    SET login = @login, password_hash = @password_hash, salt = @salt, reg_date = @reg_date, role_id = @role_id
                                    WHERE user_id = @user_id"
                };
                sCommand.Parameters.AddWithValue("@user_id", id);
                sCommand.Parameters.AddWithValue("@login", login);
                sCommand.Parameters.AddWithValue("@password_hash", hash_str);
                sCommand.Parameters.AddWithValue("@salt", salt_str);
                sCommand.Parameters.AddWithValue("@reg_date", reg_date);
                sCommand.Parameters.AddWithValue("@role_id", role_id);
                sCommand.ExecuteNonQuery();
                return (hash_str, salt_str);
            }
        }
        public static void DeleteUsers(long[] ids)
        {
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = @"DELETE FROM users WHERE user_id = ANY(@user_id)"
                };
                sCommand.Parameters.AddWithValue("@user_id", ids);
                sCommand.ExecuteNonQuery();
            }
        }
        public static void InitialiseLV(ListView listview_db)
        {
            listview_db.Clear();
            listview_db.Columns.Add("Логин");
            listview_db.Columns.Add("Хеш пароля");
            listview_db.Columns.Add("Соль");
            listview_db.Columns.Add("Дата регистрации");
            listview_db.Columns.Add("Роль");
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = @"SELECT user_id, login, password_hash, salt, reg_date, role.role_id, role_name FROM users JOIN role ON users.role_id = role.role_id"
                };
                var reader = sCommand.ExecuteReader();
                while (reader.Read())
                {
                    var lvi = new ListViewItem(new[]
                    {
                        (string) reader["login"],
                        (string) reader["password_hash"],
                        (string) reader["salt"],
                        ((DateTime) reader["reg_date"]).ToLongDateString(),
                        (string) reader["role_name"]
                    })
                    {
                        Tag = Tuple.Create((long)reader["user_id"], (DateTime)reader["reg_date"], (int)reader["role_id"])
                    };
                    listview_db.Items.Add(lvi);
                }
            }
            listview_db.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listview_db.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        public static DataTable GetWorkoutType()
        {
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                using (var sCommand = new NpgsqlCommand())
                {
                    sCommand.Connection = sConn;
                    sCommand.CommandText = "SELECT * FROM workout_type";
                    var table = new DataTable();
                    table.Load(sCommand.ExecuteReader());
                    return table;
                }
            }
        }
        public static DataTable GetBranchAddresses()
        {
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                using (var sCommand = new NpgsqlCommand())
                {
                    sCommand.Connection = sConn;
                    sCommand.CommandText = "SELECT branch_id, branch_address FROM branch";
                    var table = new DataTable();
                    table.Load(sCommand.ExecuteReader());
                    return table;
                }
            }
        }
        public static DataTable GetCoachNames()
        {
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                using (var sCommand = new NpgsqlCommand())
                {
                    sCommand.Connection = sConn;
                    sCommand.CommandText = "SELECT coach_id, coach_name FROM coach";
                    var table = new DataTable();
                    table.Load(sCommand.ExecuteReader());
                    return table;
                }
            }
        }
        public static DataTable GetCoachTypes()
        {
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                using (var sCommand = new NpgsqlCommand())
                {
                    sCommand.Connection = sConn;
                    sCommand.CommandText = "SELECT * FROM coach_type";
                    var table = new DataTable();
                    table.Load(sCommand.ExecuteReader());
                    return table;
                }
            }
        }
        public static DataTable GetInventory()
        {
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                using (var sCommand = new NpgsqlCommand())
                {
                    sCommand.Connection = sConn;
                    sCommand.CommandText = "SELECT * FROM inventory";
                    var table = new DataTable();
                    table.Load(sCommand.ExecuteReader());
                    return table;
                }
            }
        }

        public static DataTable GetRoles()
        {
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                using (var sCommand = new NpgsqlCommand())
                {
                    sCommand.Connection = sConn;
                    sCommand.CommandText = "SELECT * FROM role";
                    var table = new DataTable();
                    table.Load(sCommand.ExecuteReader());
                    return table;
                }
            }
        }

        public static void InitializeDGVCoach(DataGridView dgv_coaches)
        {
            dgv_coaches.Rows.Clear();
            dgv_coaches.Columns.Clear();
            dgv_coaches.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "coach_id",
                Visible = false
            });
            dgv_coaches.Columns.Add("coach_name", "ФИО тренера");
            dgv_coaches.Columns.Add(new CalendarColumn
            {
                Name = "coach_birthday",
                HeaderText = "Дата рождения"
            });
            dgv_coaches.Columns.Add("coach_passport", "Номер паспорта");
            dgv_coaches.Columns.Add("coach_tin", "ИНН");
            dgv_coaches.Columns.Add("coach_phone", "Номер телефона");
            dgv_coaches.Columns.Add("coach_salary", "Оклад");
            dgv_coaches.Columns.Add(new DataGridViewComboBoxColumn
            {
                Name = "coach_coach_type_id",
                HeaderText = "Тип тренера",
                DisplayMember = "coach_type_name",
                ValueMember = "coach_type_id",
                DataSource = GetCoachTypes()
            });

            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = "SELECT * FROM coach"
                };
                var reader = sCommand.ExecuteReader();
                while (reader.Read())
                {
                    var coach_data = new Dictionary<string, object>();
                    foreach (var columnsName in new[] { "coach_name",
                                                        "coach_birthday",
                                                        "coach_passport",
                                                        "coach_tin",
                                                        "coach_phone",
                                                        "coach_salary",
                                                        "coach_coach_type_id"})
                    {
                        coach_data[columnsName] = reader[columnsName];
                    }

                    var row_idx = dgv_coaches.Rows.Add(reader["coach_id"],
                                                        reader["coach_name"],
                                                        reader["coach_birthday"],
                                                        reader["coach_passport"],
                                                        reader["coach_tin"],
                                                        reader["coach_phone"],
                                                        reader["coach_salary"],
                                                        reader["coach_coach_type_id"]);
                    dgv_coaches.Rows[row_idx].Tag = coach_data;
                }
            }
        }

        public static void InitializeDGVWorkout(DataGridView dgv_workout)
        {
            dgv_workout.Rows.Clear();
            dgv_workout.Columns.Clear();
            dgv_workout.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "workout_id",
                Visible = false
            });
            dgv_workout.Columns.Add(new DataGridViewComboBoxColumn
            {
                Name = "workout_branch_id",
                HeaderText = "Филиал",
                DisplayMember = "branch_address",
                ValueMember = "branch_id",
                DataSource = GetBranchAddresses()
            });
            dgv_workout.Columns.Add(new DataGridViewComboBoxColumn
            {
                Name = "workout_coach_id",
                HeaderText = "Тренер",
                DisplayMember = "coach_name",
                ValueMember = "coach_id",
                DataSource = GetCoachNames()
            });
            dgv_workout.Columns.Add("workout_name", "Название тренировки");
            dgv_workout.Columns.Add(new DataGridViewComboBoxColumn
            {
                Name = "workout_workout_type_id",
                HeaderText = "Тип тренировки",
                DisplayMember = "workout_type_name",
                ValueMember = "workout_type_id",
                DataSource = GetWorkoutType()
            });
            dgv_workout.Columns.Add("workout_description", "Описание тренировки");
            dgv_workout.Columns.Add("workout_length", "Длительность тренировки (мин)");
            dgv_workout.Columns.Add(new CalendarColumn
            {
                Name = "workout_begin_date",
                HeaderText = "Дата"
            });

            dgv_workout.Columns.Add("workout_begin_time", "Время начала");
            ////dgv_workout.Columns.Add(new TimeColumn
            ////{
            ////    Name = "workout_begin_time",
            ////    HeaderText = "Время начала"
            ////});

            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = "SELECT * FROM workout"
                };
                var reader = sCommand.ExecuteReader();
                while (reader.Read())
                {
                    var workout_data = new Dictionary<string, object>();
                    foreach (var columnsName in new[] { "workout_branch_id",
                                                         "workout_coach_id",
                                                         "workout_name",
                                                         "workout_workout_type_id",
                                                         "workout_description",
                                                         "workout_length",
                                                         "workout_begin_date",
                                                         "workout_begin_time"})
                    {
                        workout_data[columnsName] = reader[columnsName];
                    }

                    var row_idx = dgv_workout.Rows.Add(reader["workout_id"],
                                                        reader["workout_branch_id"],
                                                        reader["workout_coach_id"],
                                                        reader["workout_name"],
                                                        reader["workout_workout_type_id"],
                                                        reader["workout_description"],
                                                        reader["workout_length"],
                                                        reader["workout_begin_date"],
                                                        reader["workout_begin_time"]);
                    dgv_workout.Rows[row_idx].Tag = workout_data;
                }
            }
        }

        public static void InitializeDGVInventory(DataGridView dgv_inventory)
        {
            dgv_inventory.Rows.Clear();
            dgv_inventory.Columns.Clear();
            dgv_inventory.Columns.Add(new DataGridViewComboBoxColumn
            {
                Name = "branch_id",
                HeaderText = "Филиал",
                DisplayMember = "branch_address",
                ValueMember = "branch_id",
                DataSource = GetBranchAddresses()
            });
            dgv_inventory.Columns.Add(new DataGridViewComboBoxColumn
            {
                Name = "inventory_id",
                HeaderText = "Инвентарь",
                DisplayMember = "inventory_name",
                ValueMember = "inventory_id",
                DataSource = GetInventory()
            });
            dgv_inventory.Columns.Add("number", "Количество");
            

            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = "SELECT * FROM number_of_inventory_in_branch"
                };
                var reader = sCommand.ExecuteReader();
                while (reader.Read())
                {
                    var inventory_data = new Dictionary<string, object>();
                    foreach (var columnsName in new[] { "branch_id",
                                                         "inventory_id",
                                                         "number"})
                    {
                        inventory_data[columnsName] = reader[columnsName];
                    }

                    var row_idx = dgv_inventory.Rows.Add(reader["branch_id"],
                                                        reader["inventory_id"],
                                                        reader["number"]);
                    dgv_inventory.Rows[row_idx].Tag = inventory_data;
                }
            }
        }

        public static void InitializeDGVBranch(DataGridView dgv_branch)
        {
            dgv_branch.Rows.Clear();
            dgv_branch.Columns.Clear();
            dgv_branch.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "branch_id",
                Visible = false
            });
            dgv_branch.Columns.Add("branch_address", "Адрес филиала");
            dgv_branch.Columns.Add("branch_phone", "Телефон ресепшена");
            dgv_branch.Columns.Add("branch_area", "Площадь помещения");
            dgv_branch.Columns.Add("branch_working_hours", "Часы работы");

            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = "SELECT * FROM branch"
                };
                var reader = sCommand.ExecuteReader();
                while (reader.Read())
                {
                    var branch_data = new Dictionary<string, object>();
                    foreach (var columnsName in new[] { "branch_address",
                                                         "branch_phone",
                                                         "branch_area",
                                                         "branch_working_hours"})
                    {
                        branch_data[columnsName] = reader[columnsName];
                    }

                    var row_idx = dgv_branch.Rows.Add(reader["branch_id"],
                                                        reader["branch_address"],
                                                        reader["branch_phone"],
                                                        reader["branch_area"],
                                                        reader["branch_working_hours"]);
                    dgv_branch.Rows[row_idx].Tag = branch_data;
                }
            }
        }

        public static int InsertCoach(string coach_name, DateTime coach_birthday,
                                      long coach_passport, long coach_tin,
                                      string coach_phone, int coach_salary,
                                      int coach_coach_type_id)
        {
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = $@"INSERT INTO coach (coach_name,
                                                        coach_birthday,
                                                        coach_passport,
                                                        coach_tin,
                                                        coach_phone,
                                                        coach_salary,
                                                        coach_coach_type_id)
                                    VALUES (@coach_name,
                                            @coach_birthday,
                                            @coach_passport,
                                            @coach_tin,
                                            @coach_phone,
                                            @coach_salary,
                                            @coach_coach_type_id)
                                    RETURNING coach_id"
                };
                sCommand.Parameters.AddWithValue("@coach_name", coach_name);
                sCommand.Parameters.AddWithValue("@coach_birthday", coach_birthday);
                sCommand.Parameters.AddWithValue("@coach_passport", coach_passport);
                sCommand.Parameters.AddWithValue("@coach_tin", coach_tin);
                sCommand.Parameters.AddWithValue("@coach_phone", coach_phone);
                sCommand.Parameters.AddWithValue("@coach_salary", coach_salary);
                sCommand.Parameters.AddWithValue("@coach_coach_type_id", coach_coach_type_id);
                return (int)sCommand.ExecuteScalar();
            }
        }

        public static int InsertBranch(string branch_address, string branch_phone,
                                        int branch_area, string branch_working_hours)
        {
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = $@"INSERT INTO branch (branch_address,
                                                            branch_phone,
                                                            branch_area,
                                                            branch_working_hours)
                                        VALUES (@branch_address,
                                                @branch_phone,
                                                @branch_area,
                                                @branch_working_hours)
                                        RETURNING branch_id"
                };
                sCommand.Parameters.AddWithValue("@branch_address", branch_address);
                sCommand.Parameters.AddWithValue("@branch_phone", branch_phone);
                sCommand.Parameters.AddWithValue("@branch_area", branch_area);
                sCommand.Parameters.AddWithValue("@branch_working_hours", branch_working_hours);
                return (int)sCommand.ExecuteScalar();
            }
        }

        public static int InsertWorkout(int workout_branch_id,
                                         int workout_coach_id, string workout_name,
                                         int workout_workout_type_id, string workout_description,
                                         int workout_length,
                                         DateTime workout_begin_date, string workout_begin_time)
        {
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = @"INSERT INTO workout (workout_branch_id,
                                                         workout_coach_id,
                                                         workout_name,
                                                         workout_workout_type_id,
                                                         workout_description,
                                                         workout_length,
                                                         workout_begin_date,
                                                         workout_begin_time)
                                    VALUES (@workout_branch_id,
                                            @workout_coach_id,
                                            @workout_name,
                                            @workout_workout_type_id,
                                            @workout_description,
                                            @workout_length,
                                            @workout_begin_date,
                                            @workout_begin_time)
                                    RETURNING workout_id;"
                };
                sCommand.Parameters.AddWithValue("@workout_branch_id", workout_branch_id);
                sCommand.Parameters.AddWithValue("@workout_coach_id", workout_coach_id);
                sCommand.Parameters.AddWithValue("@workout_name", workout_name);
                sCommand.Parameters.AddWithValue("@workout_workout_type_id", workout_workout_type_id);
                sCommand.Parameters.AddWithValue("@workout_description", workout_description);
                sCommand.Parameters.AddWithValue("@workout_length", workout_length);
                sCommand.Parameters.AddWithValue("@workout_begin_date", workout_begin_date);
                sCommand.Parameters.AddWithValue("@workout_begin_time", workout_begin_time);
                return (int)sCommand.ExecuteScalar();
            }
        }

        public static void InsertInventory(int branch_id, int inventory_id,
                                         int number)
        {
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = $@"INSERT INTO number_of_inventory_in_branch (branch_id, 
                                                                               inventory_id, 
                                                                               number)
                                    VALUES (@branch_id,
                                            @inventory_id,
                                            @number)"
                };
                sCommand.Parameters.AddWithValue("@branch_id", branch_id);
                sCommand.Parameters.AddWithValue("@inventory_id", inventory_id);
                sCommand.Parameters.AddWithValue("@number", number);
                sCommand.ExecuteNonQuery();
            }
        }

        public static void UpdateCoach(int coach_id, string coach_name,
                                      DateTime coach_birthday, long coach_passport,
                                      long coach_tin, string coach_phone,
                                      int coach_salary, int coach_coach_type_id)
        {
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = $@"UPDATE coach
                                    SET coach_name = @coach_name,
                                        coach_birthday = @coach_birthday,
                                        coach_passport = @coach_passport, 
                                        coach_tin = @coach_tin,
                                        coach_phone = @coach_phone,
                                        coach_salary = @coach_salary,
                                        coach_coach_type_id = @coach_coach_type_id
                                    WHERE coach_id = @coach_id"
                };
                sCommand.Parameters.AddWithValue("@coach_id", coach_id);
                sCommand.Parameters.AddWithValue("@coach_name", coach_name);
                sCommand.Parameters.AddWithValue("@coach_birthday", coach_birthday);
                sCommand.Parameters.AddWithValue("@coach_passport", coach_passport);
                sCommand.Parameters.AddWithValue("@coach_tin", coach_tin);
                sCommand.Parameters.AddWithValue("@coach_phone", coach_phone);
                sCommand.Parameters.AddWithValue("@coach_salary", coach_salary);
                sCommand.Parameters.AddWithValue("@coach_coach_type_id", coach_coach_type_id);
                sCommand.ExecuteNonQuery();
            }
        }

        public static void UpdateBranch(int branch_id, string branch_address, string branch_phone,
                                        int branch_area, string branch_working_hours)
        {
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = $@"UPDATE branch
                                    SET branch_address = @branch_address,
                                        branch_phone = @branch_phone,
                                        branch_area = @branch_area,
                                        branch_working_hours = @branch_working_hours
                                    WHERE branch_id = @branch_id"
                };
                sCommand.Parameters.AddWithValue("@branch_id", branch_id);
                sCommand.Parameters.AddWithValue("@branch_address", branch_address);
                sCommand.Parameters.AddWithValue("@branch_phone", branch_phone);
                sCommand.Parameters.AddWithValue("@branch_area", branch_area);
                sCommand.Parameters.AddWithValue("@branch_working_hours", branch_working_hours);
                sCommand.ExecuteNonQuery();
            }
        }

        public static void UpdateWorkout(int workout_id, int workout_branch_id,
                                         int workout_coach_id, string workout_name,
                                         int workout_workout_type_id, string workout_description,
                                         int workout_length,
                                         DateTime workout_begin_date, string workout_begin_time)
        {
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = @"UPDATE workout
                                    SET workout_name = @workout_name,
                                        workout_branch_id = @workout_branch_id,
                                        workout_coach_id = @workout_coach_id,
                                        workout_workout_type_id = @workout_workout_type_id,
                                        workout_description = @workout_description,
                                        workout_length = @workout_length,
                                        workout_begin_date = @workout_begin_date,
                                        workout_begin_time = @workout_begin_time
                                    WHERE workout_id = @workout_id"
                };
                sCommand.Parameters.AddWithValue("@workout_id", workout_id);
                sCommand.Parameters.AddWithValue("@workout_name", workout_name);
                sCommand.Parameters.AddWithValue("@workout_branch_id", workout_branch_id);
                sCommand.Parameters.AddWithValue("@workout_coach_id", workout_coach_id);
                sCommand.Parameters.AddWithValue("@workout_workout_type_id", workout_workout_type_id);
                sCommand.Parameters.AddWithValue("@workout_description", workout_description);
                sCommand.Parameters.AddWithValue("@workout_length", workout_length);
                sCommand.Parameters.AddWithValue("@workout_begin_date", workout_begin_date);
                sCommand.Parameters.AddWithValue("@workout_begin_time", workout_begin_time);
                sCommand.ExecuteNonQuery();
            }
        }

        public static void UpdateInventory(int old_branch_id, int old_inventory_id,
                                         int new_branch_id, int new_inventory_id,
                                         int number)
        {
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = @"UPDATE number_of_inventory_in_branch
                                    SET branch_id = @new_branch_id,
                                        inventory_id = @new_inventory_id,
                                        number = @number
                                    WHERE branch_id = @old_branch_id AND inventory_id = @old_inventory_id"
                };
                sCommand.Parameters.AddWithValue("@new_branch_id", new_branch_id);
                sCommand.Parameters.AddWithValue("@new_inventory_id", new_inventory_id);
                sCommand.Parameters.AddWithValue("@number", number);
                sCommand.Parameters.AddWithValue("@old_branch_id", old_branch_id);
                sCommand.Parameters.AddWithValue("@old_inventory_id", old_inventory_id);
                sCommand.ExecuteNonQuery();
            }
        }


        public static void DeleteCoach(int coach_id)
        {
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = @"DELETE FROM coach WHERE coach_id = @coach_id"
                };
                sCommand.Parameters.AddWithValue("@coach_id", coach_id);
                sCommand.ExecuteNonQuery();
            }
        }

        public static void DeleteBranch(int branch_id)
        {
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = @"DELETE FROM branch WHERE branch_id = @branch_id"
                };
                sCommand.Parameters.AddWithValue("@branch_id", branch_id);
                sCommand.ExecuteNonQuery();
            }
        }

        public static void DeleteWorkout(int workout_id)
        {
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = @"DELETE FROM workout WHERE workout_id = @workout_id"
                };
                sCommand.Parameters.AddWithValue("@workout_id", workout_id);
                sCommand.ExecuteNonQuery();
            }
        }

        public static void DeleteInventory(int branch_id, int inventory_id)
        {
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = @"DELETE FROM number_of_inventory_in_branch
                                WHERE branch_id = @branch_id AND inventory_id = @inventory_id"
                };
                sCommand.Parameters.AddWithValue("@branch_id", branch_id);
                sCommand.Parameters.AddWithValue("@inventory_id", inventory_id);
                sCommand.ExecuteNonQuery();
            }
        }

        public static bool FindBranchName(string branch_address)
        {
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = @"SELECT COUNT (*) FROM branch WHERE branch_address = @branch_address"
                };
                sCommand.Parameters.AddWithValue("@branch_address", branch_address);
                return ((long)sCommand.ExecuteScalar() > 0);
            }
        }

        public static bool FindBranchInventoryCouple(int branch_id, int inventory_id)
        {
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = @"SELECT COUNT(*) FROM number_of_inventory_in_branch
                                    WHERE branch_id = @branch_id AND inventory_id = @inventory_id"
                };
                sCommand.Parameters.AddWithValue("@branch_id", branch_id);
                sCommand.Parameters.AddWithValue("@inventory_id", inventory_id);
                return ((long)sCommand.ExecuteScalar() > 0);
            }
        }

        public static void Initialize_dgv_timetable_for_coach(DataGridView dgv_timetable_for_coach, int coach_id)
        {
            dgv_timetable_for_coach.Columns.Clear();
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = @"SELECT workout_name,
                                           workout_description,
                                           workout_length,
                                           workout_begin_date,
                                           workout_begin_time,
                                           workout_type_name,
                                           branch_address,
                                           coach_name
                                    FROM workout
                                    JOIN workout_type ON workout.workout_workout_type_id = workout_type.workout_type_id
                                    JOIN branch ON workout.workout_branch_id = branch.branch_id
                                    JOIN coach ON workout.workout_coach_id = coach.coach_id
                                    WHERE coach_id = @coach_id;"
                };
                sCommand.Parameters.AddWithValue("@coach_id", coach_id);
                DataTable source = new DataTable();
                source.Load(sCommand.ExecuteReader());
                dgv_timetable_for_coach.DataSource = source;
            }
            dgv_timetable_for_coach.Columns["workout_name"].HeaderText= "Название тренировки";
            dgv_timetable_for_coach.Columns["workout_description"].HeaderText = "Описание тренировки";
            dgv_timetable_for_coach.Columns["workout_length"].HeaderText = "Длительность тренировки";
            dgv_timetable_for_coach.Columns["workout_begin_date"].HeaderText = "Дата начала";
            dgv_timetable_for_coach.Columns["workout_begin_time"].HeaderText = "Время начала";
            dgv_timetable_for_coach.Columns["workout_type_name"].HeaderText = "Тип тренировки";
            dgv_timetable_for_coach.Columns["branch_address"].HeaderText = "Адрес филиала";
            dgv_timetable_for_coach.Columns["coach_name"].HeaderText = "Имя тренера";

            dgv_timetable_for_coach.ReadOnly = true;
        }

        public static void InitializeDGVtimetable_today(DataGridView dgv_timetable_today)
        {
            dgv_timetable_today.Columns.Clear();
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = @"SELECT workout_name,
                                           workout_description,
                                           workout_length,
                                           workout_begin_date,
                                           workout_begin_time,
                                           workout_type_name,
                                           branch_address,
                                           coach_name
                                    FROM workout
                                    JOIN workout_type ON workout.workout_workout_type_id = workout_type.workout_type_id
                                    JOIN branch ON workout.workout_branch_id = branch.branch_id
                                    JOIN coach ON workout.workout_coach_id = coach.coach_id
                                    WHERE workout_begin_date = current_date AND workout_workout_type_id = 1"
                };
                DataTable source = new DataTable();
                source.Load(sCommand.ExecuteReader());
                dgv_timetable_today.DataSource = source;
            }
            dgv_timetable_today.Columns["workout_name"].HeaderText = "Название тренировки";
            dgv_timetable_today.Columns["workout_description"].HeaderText = "Описание тренировки";
            dgv_timetable_today.Columns["workout_length"].HeaderText = "Длительность тренировки";
            dgv_timetable_today.Columns["workout_begin_date"].HeaderText = "Дата начала";
            dgv_timetable_today.Columns["workout_begin_time"].HeaderText = "Время начала";
            dgv_timetable_today.Columns["workout_type_name"].HeaderText = "Тип тренировки";
            dgv_timetable_today.Columns["branch_address"].HeaderText = "Адрес филиала";
            dgv_timetable_today.Columns["coach_name"].HeaderText = "Имя тренера";

            dgv_timetable_today.ReadOnly = true;
        }
    }
}
