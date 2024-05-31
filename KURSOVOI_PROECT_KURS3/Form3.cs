using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OfficeOpenXml.ExcelErrorValue;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KURSOVOI_PROECT_KURS3
{
    public partial class Form3 : Form
    {
        int c = 0; //переключатель для выхода из программы
        string startWeekDate;
        string endWeekDate;
        public string fileInputStream;
        int d1 = 3;
        int d2 = 7;
        List<string> Time_of_subj = new List<string>();
        int rowIndex1;
        List<string> student_surname = new List<string>();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Понедельник");
            comboBox1.Items.Add("Вторник");
            comboBox1.Items.Add("Среда");
            comboBox1.Items.Add("Четверг");
            comboBox1.Items.Add("Пятница");
            comboBox1.Items.Add("Суббота");


            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "XLSX (*.xlsx)|*.xlsx|XLS (*.xls)|*.xls";

            if (OFD.ShowDialog() == DialogResult.OK)
            {
                fileInputStream = OFD.FileName;
            }
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (c == 0)
            {
                System.Windows.Forms.Application.OpenForms[0].Show();
            }
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            c = 1;
            System.Windows.Forms.Application.OpenForms[0].Show();
            this.Close();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            add_subjTime asT = new add_subjTime();
            if (asT.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                Workbook excelWorkbook = excelApp.Workbooks.Open(fileInputStream);
                Worksheet worksheet = excelWorkbook.Sheets[1];

                Time_of_subj = asT.subjects_time;

                switch (asT.Day_of_Week)
                {
                    case 0:
                        d1 = 3;
                        d2 = 7;
                        break;
                    case 1:
                        d1 = 8;
                        d2 = 12;
                        break;
                    case 2:
                        d1 = 13;
                        d2 = 17;
                        break;
                    case 3:
                        d1 = 18;
                        d2 = 22;
                        break;
                    case 4:
                        d1 = 23;
                        d2 = 28;
                        break;
                }

                int j = 0;
                try
                {
                    for (int i = d1; i < d2 + 1; i++)
                    {
                        worksheet.Cells[36, i].Value = asT.subjects_time[j].ToString();
                        j++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


                excelWorkbook.Save();
                excelWorkbook.Close();
                excelApp.Quit();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    d1 = 3;
                    d2 = 7;
                    break;
                case 1:
                    d1 = 8;
                    d2 = 12;
                    break;
                case 2:
                    d1 = 13;
                    d2 = 17;
                    break;
                case 3:
                    d1 = 18;
                    d2 = 22;
                    break;
                case 4:
                    d1 = 23;
                    d2 = 28;
                    break;
            }

            dataGridView1.Rows.Clear();

            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook excelWorkbook = excelApp.Workbooks.Open(fileInputStream);
            Worksheet worksheet = excelWorkbook.Sheets[1];

            try
            {
                Time_of_subj.Clear();
                for (int i = d1; i < d2 + 1; i++)
                {
                    Time_of_subj.Add(worksheet.Cells[36, i].Value);
                }

                for (int i = 6; i < 35; i++)
                {
                    if (worksheet.Cells[i, 2].Value != "")
                    {
                        student_surname.Add(worksheet.Cells[i, 2].Value);
                    }
                }

                foreach (var value in student_surname)
                {
                    if (value != null)
                    {
                        int rowIndex = dataGridView1.Rows.Add();

                        // Добавляем значение в первый столбец (индекс 0) новой строки
                        dataGridView1.Rows[rowIndex].Cells[0].Value = value;
                    }
                }
                rowIndex1 = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowIndex1].Cells[0].Value = "Предмет";

                int j = 0;
                for (int i = 1; i < Time_of_subj.Count; i++)
                {
                    dataGridView1.Rows[rowIndex1].Cells[i].Value = Time_of_subj[j];
                    j++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.Source + ex.StackTrace);
            }

            excelWorkbook.Save();
            excelWorkbook.Close();
            excelApp.Quit();
        }
    }
}
