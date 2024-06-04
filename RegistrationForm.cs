using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using BCrypt.Net;


namespace Semenov_Curs
{
    public partial class RegistrationForm : Form
    {
        private string connectionString = "Server=localhost;Port=3306;Database=citi_electrik;Uid=root;Pwd=admin123;";

        private bool firstClick = true;
        private Point mouseOffset;
        public RegistrationForm()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
       

            // Устанавливаем подсказку для логина
            SetPlaceholderText(FirstName, "Введите имя...");
            SetPlaceholderText(LastName, "Введите фамилию...");
            SetPlaceholderText(Username, "Введите логин...");
            SetPlaceholderText(Password, "Введите пароль...");
            SetPlaceholderText(RepitPasswordtextBox, "Повторите пароль...");

            RepitPasswordtextBox.UseSystemPasswordChar = false;
            RepitPasswordtextBox.MouseClick += RepitPassword_MouseClick;
            RepitPasswordtextBox.Enter += RepitPassword_Enter;
            RepitPasswordtextBox.Leave += RepitPassword_Leave;

            ShowPassword.Text = "Показать пароль";
            ShowPassword.CheckedChanged += ShowPassword_CheckedChanged;


            Username.MouseClick += TextBox1_MouseClick;
            Username.Enter += TextBox1_Enter;
            Username.Leave += TextBox1_Leave;
            Password.MouseClick += TextBox2_MouseClick;
            Password.Enter += TextBox2_Enter;
            Password.Leave += TextBox2_Leave;
           
            Registr.MouseDown += Label_MouseDown;
            Registr.MouseMove += Label_MouseMove;

            FirstName.MouseClick += TextBox3_MouseClick;
            FirstName.Enter += TextBox3_Enter;
            FirstName.Leave += TextBox3_Leave;
            LastName.MouseClick += TextBox4_MouseClick;
            LastName.Enter += TextBox4_Enter;
            LastName.Leave += TextBox4_Leave;
        }
        private void Label_MouseDown(object sender, MouseEventArgs e)
        {
            // Запоминаем смещение мыши относительно левого верхнего угла формы
            mouseOffset = new Point(-e.X, -e.Y);
        }
        private void RepitPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (RepitPasswordtextBox.Text == "Повторите пароль..." && firstClick)
            {
                RepitPasswordtextBox.Text = "";
                RepitPasswordtextBox.ForeColor = SystemColors.WindowText;
                RepitPasswordtextBox.UseSystemPasswordChar = true;
                firstClick = false;
                Username.ReadOnly = false;
            }
        }
        private void RepitPassword_Enter(object sender, EventArgs e)
        {
            if (RepitPasswordtextBox.Text == "Повторите пароль...")
            {
                RepitPasswordtextBox.Text = "";
                RepitPasswordtextBox.ForeColor = SystemColors.WindowText;
                RepitPasswordtextBox.UseSystemPasswordChar = true;
                RepitPasswordtextBox.SelectionStart = 0;
            }
        }
        private void RepitPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RepitPasswordtextBox.Text))
            {
                SetPlaceholderText(RepitPasswordtextBox, "Повторите пароль...");
            }
        }
        private void ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = ShowPassword.Checked;
            Password.UseSystemPasswordChar = !isChecked;
            RepitPasswordtextBox.UseSystemPasswordChar = !isChecked;
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
                Password.ForeColor = SystemColors.WindowText;
                Password.UseSystemPasswordChar = true; 
                Password.SelectionStart = 0; // Убираем выделение текста
            }
        }
        private void TextBox3_Enter(object sender, EventArgs e)
        {
            // Скрываем подсказку при получении фокуса
            if (FirstName.Text == "Введите имя...")
            {
                FirstName.Text = "";
                FirstName.ForeColor = SystemColors.WindowText; // Восстанавливаем цвет текста
                FirstName.SelectionStart = 0; // Убираем выделение текста
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
        private void TextBox4_Enter(object sender, EventArgs e)
        {
            // Скрываем подсказку при получении фокуса
            if (LastName.Text == "Введите фамилию...")
            {
                LastName.Text = "";
                LastName.ForeColor = SystemColors.WindowText; // Восстанавливаем цвет текста
                LastName.SelectionStart = 0; // Убираем выделение текста
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
        private void TextBox3_Leave(object sender, EventArgs e)
        {
            // Отображаем подсказку при потере фокуса, если поле пустое
            if (string.IsNullOrWhiteSpace(FirstName.Text))
            {
                SetPlaceholderText(FirstName, "Введите имя...");
            }
        }
        private void TextBox4_Leave(object sender, EventArgs e)
        {
            // Отображаем подсказку при потере фокуса, если поле пустое
            if (string.IsNullOrWhiteSpace(LastName.Text))
            {
                SetPlaceholderText(LastName, "Введите фамилию...");
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
        private void TextBox3_MouseClick(object sender, MouseEventArgs e)
        {
            // Скрываем подсказку при клике на текстовое поле, если подсказка присутствует
            if (FirstName.Text == "Введите имя..." && firstClick)
            {
                FirstName.Text = "";
                FirstName.ForeColor = SystemColors.WindowText; // Восстанавливаем цвет текста
                FirstName.SelectionStart = 0; // Убираем выделение текста
                firstClick = false;
                Username.ReadOnly = false; // Разрешаем ввод текста

            }
        }
        private void TextBox4_MouseClick(object sender, MouseEventArgs e)
        {
            // Скрываем подсказку при клике на текстовое поле, если подсказка присутствует
            if (LastName.Text == "Введите фамилию..." && firstClick)
            {
                LastName.Text = "";
                LastName.ForeColor = SystemColors.WindowText; // Восстанавливаем цвет текста
                LastName.SelectionStart = 0; // Убираем выделение текста
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


        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            Username.HideSelection = true;
            Username.TabStop = false;
            Password.HideSelection = true;
            Password.TabStop = false;
            FirstName.HideSelection = true;
            FirstName.TabStop = false;
            LastName.HideSelection = true;
            LastName.TabStop = false;
        }

        private void buttonback_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            // Отображаем форму
            form.Show();
        }

        private void SaveDataToDatabase()
        {
            if (string.IsNullOrWhiteSpace(FirstName.Text) || string.IsNullOrWhiteSpace(LastName.Text) ||
                string.IsNullOrWhiteSpace(Username.Text) || string.IsNullOrWhiteSpace(Password.Text) ||
                string.IsNullOrWhiteSpace(RepitPasswordtextBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Password.Text != RepitPasswordtextBox.Text)
            {
                MessageBox.Show("Пароли не совпадают.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(Password.Text);

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO users (FirstName, LastName, Login, Password) " +
                                   "VALUES (@FirstName, @LastName, @Login, @Password)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", FirstName.Text);
                        command.Parameters.AddWithValue("@LastName", LastName.Text);
                        command.Parameters.AddWithValue("@Login", Username.Text);
                        command.Parameters.AddWithValue("@Password", hashedPassword);

                        command.ExecuteNonQuery();

                        MessageBox.Show("Данные успешно сохранены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Ошибка при сохранении данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void buttonRegister_Click(object sender, EventArgs e)
        {
            SaveDataToDatabase();
            Form1 form = new Form1();
            this.Hide();
            // Отображаем форму
            form.Show();

        }

        private void Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void RepitPasswordtextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
