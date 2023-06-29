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
    public partial class Form2_Формы : Form
    {
        public Form2_Формы()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2_Должность form2_Должность = new Form2_Должность();
            form2_Должность.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2_Сотрудник form2_Сотрудник = new Form2_Сотрудник();
            form2_Сотрудник.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2_Хозяева form2_Хозяева = new Form2_Хозяева();
            form2_Хозяева.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2_Животные form2_Животные = new Form2_Животные();
            form2_Животные.Show();
        }

        

       
    }
}
