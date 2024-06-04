using System;
using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Text;


namespace Semenov_Curs.FOrms
{
    public partial class FormZacashciki : Form
    {
        private string connectionString = "Server=localhost;Port=3306;Database=citi_electrik;Uid=root;Pwd=admin123;";
        private DataTable customersTable;


        public FormZacashciki()
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
                    string query = "SELECT * FROM customers";
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridViewZakazchiki.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void FormZacashciki_Load(object sender, EventArgs e)
        {
            LoadElectricityData();
            dataGridViewZakazchiki.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewZakazchiki.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text.ToLower();
            StringBuilder filterExpression = new StringBuilder();

            // Перебираем все столбцы датагридвью
            foreach (DataGridViewColumn column in dataGridViewZakazchiki.Columns)
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
    (dataGridViewZakazchiki.DataSource as DataTable).DefaultView.RowFilter = filterExpression.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1_TextChanged(sender, e);
        }
    }
}
