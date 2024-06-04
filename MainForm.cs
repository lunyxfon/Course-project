using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Semenov_Curs
{
    public partial class MainForm : Form
    {
        private string currentUser;
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        private string connectionString = "Server=localhost;Port=3306;Database=citi_electrik;Uid=root;Pwd=admin123;";
        private string currentUserLogin;
        public string CurrentUser
    {
        get { return currentUser; }
        set
        {
            currentUser = value;
                // Обновляем текст Label для отображения информации о пользователе
                labelName.Text = $"{value}";
        }
    }
        private Color SelectThemeColor()
        {
            int index=random.Next(ThemeColors.ColorList.Count);
            while (tempIndex == index)
            {
                index=random.Next(ThemeColors.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColors.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if(btnSender != null)
            {
                if(currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color= SelectThemeColor();
                    currentButton=(Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    btnCloseChild.Visible = true;


                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType()== typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(64, 64, 64);
                    previousBtn.ForeColor = Color.Gainsboro;
                   

                }
            }

        }
        public MainForm(string login)
        {
            InitializeComponent();
            random = new Random();
            btnCloseChild.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            currentUserLogin = login;
            LoadUserData();

        }

        public MainForm()
        {
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void MainForm_Load(object sender, EventArgs e)
        {
           
            labelName.AutoSize = false;
            // Вызываем метод, чтобы правильно установить начальные размеры Label
            AdjustLabelSize();
        }
        private void LoadUserData()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT FirstName, LastName FROM users WHERE Login = @Login";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Login", currentUserLogin);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                labelName.Text = $"{reader["FirstName"]} {reader["LastName"]}";
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных пользователя: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    
        private  string GetLoggedInUserId(string login, string password)
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
      


        private void Form1_Resize(object sender, EventArgs e)
        {
            // Вызываем метод для изменения размеров Label при изменении размеров формы
            AdjustLabelSize();
        }
        private void AdjustLabelSize()
        {
            // Устанавливаем новые размеры Label в зависимости от размеров формы
            labelName.Width = this.ClientSize.Width;
            labelName.Left = 0; // Делаем Label прижатым к левому краю формы
        }
        public void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock= DockStyle.Fill;
            this.panelDesctop.Controls.Add(childForm);
            this.panelDesctop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            labelHome.Text = childForm.Text;
        }
        private void buttonzakazchik_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FOrms.FormZacashciki(), sender);
        }

        private void buttonPostavhik_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FOrms.FormPostavshiki(), sender);
        }

        private void buttonpotrebitel_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FOrms.FormPotrebiteli(), sender);
        }

        private void buttonelectrik_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FOrms.FormElectro(), sender);
        }

        private void buttonotchet_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FOrms.FormOtcheti(), sender);
        }

        private void buttoncompani_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FOrms.FormCompani(currentUserLogin), sender);
        }

        private void labelHome_Click(object sender, EventArgs e)
        {

        }

        private void labelName_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnCloseChild_Click(object sender, EventArgs e)
        {
            if(activeForm!=null)
                activeForm.Close();
            Reset();
        }
        private void Reset()
        {
            DisableButton();
            labelHome.Text = "HOME";
          
            currentButton = null;
            btnCloseChild.Visible = false;
        }

        private void panelDesctop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void panelTitlebar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void bntMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonnastroyki_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FOrms.FormNastroyki(), sender);
        }

        private void buttonCloseMain_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            // Отображение формы входа
            loginForm.Show();
            // Закрытие текущей формы
            this.Close();
        }

        private void labelName_Click_1(object sender, EventArgs e)
        {

        }
    }
}
