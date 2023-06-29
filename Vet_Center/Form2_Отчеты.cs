using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vet_Center
{
    public partial class Form2_Отчеты : Form
    {
        public Form2_Отчеты()
        {
            InitializeComponent();
        }

        SqlConnection sqlConnection;

        void GetList(DataGridView dataGridView, string table)
        {

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"Select * From {table}", sqlConnection);
            DataSet dataset = new DataSet();
            sqlDataAdapter.Fill(dataset, $"{table}");
            dataGridView.DataSource = dataset.Tables[$"{table}"];
        }

        private void Отчет_load(object sender, EventArgs e)
        {
            string connectoinString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Vaio\Desktop\Новая папка\Vet_Center\Vet_Center\Vet_Center.mdf"";Integrated Security=True";

            sqlConnection = new SqlConnection(connectoinString);
            sqlConnection.Open();
            GetList(dataGridView2, "Животные");
            GetList(dataGridView3, "Должность");
            GetList(dataGridView5, "Хозяева");
            GetList(dataGridView6, "Сотрудник");
        }
    }
}
