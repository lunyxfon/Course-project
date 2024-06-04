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
using System.IO;

namespace Semenov_Curs.FOrms
{
    public partial class FormCompani : Form
    {
        private string connectionString = "Server=localhost;Port=3306;Database=citi_electrik;Uid=root;Pwd=admin123;";
        private string currentUserLogin;
        public int currentUserId { get; private set; }

        public FormCompani(string login)
        {
            InitializeComponent();
            currentUserLogin = login;
            currentUserId = GetCurrentUserId();
            LoadUserData();
        }

        private void LoadUserData()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT FirstName, LastName, Login, Password FROM users WHERE Login = @Login";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Login", currentUserLogin);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            FirstName.Text = reader["FirstName"].ToString();
                            LastName.Text = reader["LastName"].ToString();
                            Login.Text = reader["Login"].ToString();
                        }
                    }
                }
            }

            LoadUserPhoto();
        }

        private int GetCurrentUserId()
        {
            int userId = 0;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id FROM users WHERE Login = @Login";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Login", currentUserLogin);
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        userId = Convert.ToInt32(result);
                    }
                }
            }

            return userId;
        }

        private void LoadUserPhoto()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Foto FROM profil WHERE user_id = @user_id";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@user_id", currentUserId);
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        string photoPath = result.ToString();
                        if (File.Exists(photoPath))
                        {
                            pictureBoxFoto.Image = Image.FromFile(photoPath);
                        }
                    }
                }
            }
        }

        private void FormCompani_Load(object sender, EventArgs e)
        {
        }

        private void Foto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog.FileName;
                    pictureBoxFoto.Image = Image.FromFile(filePath);
                    SaveImageToDatabase(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке фотографии: " + ex.Message);
                }
            }
        }

        private void SaveImageToDatabase(string filePath)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO profil (user_id, Foto) VALUES (@user_id, @Foto) ON DUPLICATE KEY UPDATE Foto = @Foto";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@user_id", currentUserId);
                    command.Parameters.AddWithValue("@Foto", filePath);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Image uploaded successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to upload image.");
                    }
                }
            }
        }

        private void pictureBoxFoto_Click(object sender, EventArgs e)
        {

        }
    }
}
