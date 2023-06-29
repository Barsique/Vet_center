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
    public partial class Form2_Хозяева : Form
    {
        public Form2_Хозяева()
        {
            InitializeComponent();
        }





        SqlConnection sqlConnection;
        public int Id;
        public string Column;


        private void Хозяева(object sender, EventArgs e)
        {
            string connectoinString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Vaio\Desktop\Новая папка\Vet_Center\Vet_Center\Vet_Center.mdf"";Integrated Security=True";

            sqlConnection = new SqlConnection(connectoinString);
            sqlConnection.Open();
        }




        void GetList(DataGridView dataGridView)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * From Хозяева", sqlConnection);
            DataSet dataset = new DataSet();
            sqlDataAdapter.Fill(dataset, "Хозяева");
            dataGridView.DataSource = dataset.Tables["Хозяева"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var text1 = textBox1.Text;
                var text5 = textBox5.Text;
                var text3 = textBox3.Text;
                var text4 = textBox4.Text;
                string q = $"INSERT INTO Хозяева (ФИО, Дата_рождения, Телефон, Паспортные_данные) VALUES (N'{text1}',N'{text5}',N'{text3}',N'{text4}')";
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


        private void Удалить_Click(object sender, EventArgs e)
        {
            string Message;
            Message = "Вы действительно хотите удалить выделенную запись?";
            if (MessageBox.Show(Message, "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }
            string q = $"DELETE FROM Хозяева WHERE id = '{textBox6.Text}'";
            SqlCommand command = new SqlCommand(q, sqlConnection);
            command.ExecuteNonQuery();
            GetList(dataGridView1);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)  // Фильтрация
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"ФИО like '%{textBox7.Text}%'OR Адрес like '%{textBox7.Text}%'";
        }



        private void Изменить_Click(object sender, EventArgs e)
        {
            DateTime date = new DateTime();
            var a = dateTimePicker1.Value;
            date = DateTime.Parse(a.ToString("dd-MM-yyyy"));
            string Message;
            Message = "Вы действительно хотите изменить выделенную запись?";
            if (MessageBox.Show(Message, "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {

                return;
            }
            string q;
            if (Column == "Birthday")
            {
                q = $"UPDATE Хозяева set {Column} = '{date.ToString("yyyy-MM-dd")}' WHERE id = {Id}";
            }
            else { q = $"UPDATE Хозяева set {Column} = N'{textBox2.Text}' WHERE id = {Id}"; }
            SqlCommand command = new SqlCommand(q, sqlConnection);
            command.ExecuteNonQuery();
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
            if (Column == "Birthday") { textBox2.Visible = false; dateTimePicker1.Visible = true; }
            else { textBox2.Visible = true; dateTimePicker1.Visible = false; }
        }
    }
}
