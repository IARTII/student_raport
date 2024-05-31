using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KURSOVOI_PROECT_KURS3
{
    public partial class add_subjTime : Form
    {
        public List<string> subjects_time = new List<string>();
        public int Day_of_Week = 0;
        public add_subjTime()
        {
            InitializeComponent();
        }

        private void add_subjTime_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Понедельник");
            comboBox1.Items.Add("Вторник");
            comboBox1.Items.Add("Среда");
            comboBox1.Items.Add("Четверг");
            comboBox1.Items.Add("Пятница");
            comboBox1.Items.Add("Суббота");
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            subjects_time.Add(textBox1.Text);
            subjects_time.Add(textBox2.Text);
            subjects_time.Add(textBox3.Text);
            subjects_time.Add(textBox4.Text);
            subjects_time.Add(textBox5.Text);

            Day_of_Week = comboBox1.SelectedIndex;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
