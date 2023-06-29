using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vet_Center
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string q = "Разработка базы данных предметной области: Ветеринарный центр\nВыполнил: Жуков А. В.\nГруппа: ИВТз-201";
            MessageBox.Show(q, "О программе");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2_Формы form2_Формы = new Form2_Формы();
            form2_Формы.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2_Отчеты form2_Отчеты = new Form2_Отчеты();
            form2_Отчеты.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2_Учетные_данные form2_Учетные_Данные = new Form2_Учетные_данные();
            form2_Учетные_Данные.Show();
        }
    }
}
