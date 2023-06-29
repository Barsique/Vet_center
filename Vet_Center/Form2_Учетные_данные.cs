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
    public partial class Form2_Учетные_данные : Form
    {
        public Form2_Учетные_данные()
        {
            InitializeComponent();
        }

        SqlConnection sqlConnection;
        public int Id;
        public string Column;
        private void Пользователь_Load(object sender, EventArgs e)
        {
            string connectoinString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Vaio\Desktop\Новая папка\Vet_Center\Vet_Center\Vet_Center.mdf"";Integrated Security=True";

            sqlConnection = new SqlConnection(connectoinString);
            sqlConnection.Open();
        }

        void GetList(DataGridView dataGridView)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * From Пользователь", sqlConnection);
            DataSet dataset = new DataSet();
            sqlDataAdapter.Fill(dataset, "Пользователь");
            dataGridView.DataSource = dataset.Tables["Пользователь"];
        }
        private void Добавить_Click(object sender, EventArgs e) // Добавить
        {
            try
            {
                var text1 = textBox1.Text;
                var text2 = textBox2.Text;
                var text3 = textBox3.Text;
                var text4 = textBox4.Text;
                var text5 = textBox5.Text;
                var text6 = textBox6.Text;
                string q = $"INSERT INTO Пользователь (Пароль, Роль, ФИО, Должность, Телефон, Email) VALUES ('{text1}',N'{text2}',N'{text3}',N'{text4}','{text5}',N'{text6}')";
                SqlCommand command = new SqlCommand(q, sqlConnection);
                MessageBox.Show(command.ExecuteNonQuery().ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            GetList(dataGridView1);
        }
        private void tabPage1_Enter(object sender, EventArgs e)
        {
            GetList(dataGridView1);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = e.RowIndex;
            Id = Convert.ToInt32(dataGridView1[0, id].Value);
            Column = dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].HeaderText.ToString();
            string a = "Ячейка выбрана";
            if (Column != null)
            {
                MessageBox.Show(a, "Сообщение");
            }
        }
        private void Изменить_Click(object sender, EventArgs e) // КНОПКА ИЗМЕНИТЬ
        {
            string Message;
            Message = "Вы действительно хотите изменить выделенную запись?";
            if (MessageBox.Show(Message, "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }
            string q = $"UPDATE Пользователь set {Column} = N'{textBox8.Text}' WHERE id = {Id}";
            SqlCommand command = new SqlCommand(q, sqlConnection);
            command.ExecuteNonQuery();
            GetList(dataGridView1);
        }
        private void Удалить_Click(object sender, EventArgs e) // КНОПКА УДАЛИТЬ
        {
            string Message;
            Message = "Вы действительно хотите удалить выделенную запись?";
            if (MessageBox.Show(Message, "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }
            string q = $"DELETE FROM Пользователь WHERE id = '{textBox9.Text}'";
            SqlCommand command = new SqlCommand(q, sqlConnection);
            command.ExecuteNonQuery();
            GetList(dataGridView1);
        }
        private void textBox7_TextChanged(object sender, EventArgs e)  // Фильтрация
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Роль like '%{textBox10.Text}%' OR ФИО like '%{textBox10.Text}%' OR Должность like '%{textBox10.Text}%'";
        }
    }
}
