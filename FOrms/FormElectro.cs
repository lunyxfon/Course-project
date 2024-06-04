using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Text;

namespace Semenov_Curs.FOrms
{
    public partial class FormElectro : Form

    {
        private string connectionString = "Server=localhost;Port=3306;Database=citi_electrik;Uid=root;Pwd=admin123;";
        private DataTable electricityTable;

        public FormElectro()
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
                    string query = "SELECT * FROM electricity";
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridViewElectro.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void FormCompani_Resize(object sender, EventArgs e)
        {
            ResizeDataGridView();
        }
        private void ResizeDataGridView()
        {
            dataGridViewElectro.Width = this.ClientSize.Width ;
            dataGridViewElectro.Height =(int) (this.ClientSize.Height*0.7);
        }


        private void FormElectro_Load(object sender, EventArgs e)
        {
            LoadElectricityData();
            dataGridViewElectro.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ResizeDataGridView();
            dataGridViewElectro.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            textBoxSearch_TextChanged(sender, e);
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text.ToLower();
            StringBuilder filterExpression = new StringBuilder();

            // Перебираем все столбцы датагридвью
            foreach (DataGridViewColumn column in dataGridViewElectro.Columns)
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
    (dataGridViewElectro.DataSource as DataTable).DefaultView.RowFilter = filterExpression.ToString();

        }
    }
}
