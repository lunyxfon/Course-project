using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Text;


namespace Semenov_Curs.FOrms
{
    public partial class FormPotrebiteli : Form
    {
        private string connectionString = "Server=localhost;Port=3306;Database=citi_electrik;Uid=root;Pwd=admin123;";
        private DataTable consumersTable;
        public FormPotrebiteli()
        {
            InitializeComponent();
            LoadElectricityData();
        }

        private void LoadElectricityData()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM consumers";
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridViewPotrebiteli.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void FormPotrebiteli_Load(object sender, EventArgs e)
        {
            LoadElectricityData();
            dataGridViewPotrebiteli.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPotrebiteli.DefaultCellStyle.ForeColor = Color.Black;

        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text.ToLower();
            StringBuilder filterExpression = new StringBuilder();

            // Перебираем все столбцы датагридвью
            foreach (DataGridViewColumn column in dataGridViewPotrebiteli.Columns)
            {
                // Добавляем условие для каждого столбца
                if (column.Visible)
                {
                    if (filterExpression.Length > 0)
                        filterExpression.Append(" OR ");

                    filterExpression.Append(string.Format("CONVERT([{0}],'System.String') LIKE '%{1}%'", column.DataPropertyName, searchText));
                }
            }

    // Применяем фильтр ко всем столбцам
    (dataGridViewPotrebiteli.DataSource as DataTable).DefaultView.RowFilter = filterExpression.ToString();

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            textBoxSearch_TextChanged(sender, e);
        }
    }
}
