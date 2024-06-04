using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace Semenov_Curs
{
    public partial class Form1 : Form
    {
        private bool firstClick = true;
        private Point mouseOffset;
        private string connectionString = "Server=localhost;Port=3306;Database=citi_electrik;Uid=root;Pwd=admin123;";
        public int CurrentUserId { get; private set; }




        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            radioButtonShowPassword.CheckedChanged += new EventHandler(radioButtonShowPassword_CheckedChanged);


            // Устанавливаем подсказку для логина
            SetPlaceholderText(Username, "Введите логин...");
            // Устанавливаем подсказку для пароля
            SetPlaceholderText(Password, "Введите пароль...");

            // Привязываем обработчики событий для управления подсказкой
            Username.MouseClick += TextBox1_MouseClick;
            Username.Enter += TextBox1_Enter;
            Username.Leave += TextBox1_Leave;
            Password.MouseClick += TextBox2_MouseClick;
            Password.Enter += TextBox2_Enter;
            Password.Leave += TextBox2_Leave;
            Registr.MouseDown += Label_MouseDown;
            Registr.MouseMove += Label_MouseMove;

        }
       
       
    

    private void Label_MouseDown(object sender, MouseEventArgs e)
        {
            // Запоминаем смещение мыши относительно левого верхнего угла формы
            mouseOffset = new Point(-e.X, -e.Y);
        }

        private void Label_MouseMove(object sender, MouseEventArgs e)
        {
            // Проверяем, была ли нажата левая кнопка мыши
            if (e.Button == MouseButtons.Left)
            {
                // Получаем новую позицию формы, основываясь на текущем положении мыши и смещении
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }
        }

        private void SetPlaceholderText(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;
            textBox.SelectionStart = 0; // Убираем выделение текста
        }

        private void TextBox2_Enter(object sender, EventArgs e)
        {
            // Скрываем подсказку при получении фокуса
            if (Password.Text == "Введите пароль...")
            {
                Password.Text = "";
                Password.ForeColor = SystemColors.WindowText; // Восстанавливаем цвет текста
                Password.UseSystemPasswordChar = true;
                Password.SelectionStart = 0; // Убираем выделение текста
            }
        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {
            // Скрываем подсказку при получении фокуса
            if (Username.Text == "Введите логин...")
            {
                Username.Text = "";
                Username.ForeColor = SystemColors.WindowText; // Восстанавливаем цвет текста
                Username.SelectionStart = 0; // Убираем выделение текста
            }
        }
        private void TextBox2_Leave(object sender, EventArgs e)
        {
            // Отображаем подсказку при потере фокуса, если поле пустое
            if (string.IsNullOrWhiteSpace(Password.Text))
            {
                SetPlaceholderText(Password, "Введите пароль...");
            }
        }
        private void TextBox1_Leave(object sender, EventArgs e)
        {
            // Отображаем подсказку при потере фокуса, если поле пустое
            if (string.IsNullOrWhiteSpace(Username.Text))
            {
                SetPlaceholderText(Username, "Введите логин...");
            }
        }
        private void TextBox2_MouseClick(object sender, MouseEventArgs e)
        {
            // Скрываем подсказку при клике на текстовое поле, если подсказка присутствует
            if (Password.Text == "Введите пароль..." && firstClick)
            {
                Password.Text = "";
                Password.ForeColor = SystemColors.WindowText; // Восстанавливаем цвет текста
                Password.SelectionStart = 0; // Убираем выделение текста
                firstClick = false;
                Username.ReadOnly = false; // Разрешаем ввод текста

            }
        }
        private void TextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            // Скрываем подсказку при клике на текстовое поле, если подсказка присутствует
            if (Username.Text == "Введите логин..." && firstClick)
            {
                Username.Text = "";
                Username.ForeColor = SystemColors.WindowText; // Восстанавливаем цвет текста
                Username.SelectionStart = 0; // Убираем выделение текста
                firstClick = false;
                Username.ReadOnly = false; // Разрешаем ввод текста

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Username.HideSelection = true;
            Username.TabStop = false;
            Password.HideSelection = true;
            Password.TabStop = false;
           

        }

      
  

        private void Username_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
                }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void OpenRegistr_Click(object sender, EventArgs e)
        {
            RegistrationForm form2 = new RegistrationForm();
            this.Hide();
            // Отображаем форму
            form2.Show();
        }
        private string GetLoggedInUserId(string login, string password)
        {
            string userId = null;

            // Подключаемся к базе данных и выполняем запрос
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT id FROM users WHERE Login = @Login AND Password = @Password";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Login", login);
                        command.Parameters.AddWithValue("@Password", password);

                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            userId = result.ToString();
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Ошибка при получении id пользователя: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            return userId;
        }
        private void OpenFormCiti_Click(object sender, EventArgs e)
        {
            string login = Username.Text;
            string password =Password.Text;

            if (CheckLogin(login, password))
            {
                MainForm mainForm = new MainForm(login);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //private string GetUserInfo(string login)
        //{
        //    using (MySqlConnection connection = new MySqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();

        //            string query = "SELECT FirstName, LastName FROM users WHERE Login = @Login";

        //            using (MySqlCommand command = new MySqlCommand(query, connection))
        //            {
        //                command.Parameters.AddWithValue("@Login", login);

        //                using (MySqlDataReader reader = command.ExecuteReader())
        //                {
        //                    if (reader.Read())
        //                    {
        //                        // Получаем данные о пользователе
        //                        string firstName = reader.GetString("FirstName");
        //                        string lastName = reader.GetString("LastName");
        //                        return $"{firstName} {lastName}";
        //                    }
        //                }
        //            }
        //        }
        //        catch (MySqlException ex)
        //        {
        //            MessageBox.Show("Ошибка при получении информации о пользователе: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }

        //    return "Unknown User";
        //}
        private bool CheckLogin(string login, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                   

                    string query = "SELECT Password FROM users WHERE Login = @Login";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Login", login);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedHashedPassword = reader["Password"].ToString();
                                bool passwordMatch = BCrypt.Net.BCrypt.Verify(password, storedHashedPassword);
                                if (passwordMatch)
                                {
                                    MessageBox.Show("Данные верны.");
                                    return true;
                                }
                                else
                                {
                                    MessageBox.Show("Пароль не совпадает.");
                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Логин не найден.");
                                return false;
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Ошибка при проверке входа: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private void radioButtonShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonShowPassword.Checked)
            {
                Password.UseSystemPasswordChar = false;
            }
            else
            {
                Password.UseSystemPasswordChar = true;
            }
        }
    }
    }



    
