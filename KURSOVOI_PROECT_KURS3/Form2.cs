using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Microsoft.Office.Interop.Excel;
using System.Security.Cryptography;
using System.IO;

namespace KURSOVOI_PROECT_KURS3
{
    public partial class Form2 : Form
    {
        List<string> subj = new List<string>();
        int c = 0; //переключатель для выхода из программы
        string startWeekDate;
        string endWeekDate;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("Выбранные данные:");
            string[] lines = File.ReadAllLines(@"..\..\..\Log\LastLog.txt");
            textBox1.Text = lines[0];
            textBox2.Text = lines[1];
            textBox3.Text = lines[2];
            listBox1.Items.Add("ФИО Старосты: " + textBox1.Text);
            listBox1.Items.Add("ФИО Куратора: " + textBox2.Text);
            listBox1.Items.Add("Группа: " + textBox3.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string currentItem = listBox1.Items[i].ToString();

                if (currentItem.Contains("Старосты"))
                {
                    listBox1.Items.RemoveAt(i);
                    i--; // Уменьшаем счетчик, так как после удаления элементов сдвигаются
                }
            }
            listBox1.Items.Add("ФИО Старосты: " + textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string currentItem = listBox1.Items[i].ToString();

                if (currentItem.Contains("Куратора"))
                {
                    listBox1.Items.RemoveAt(i);
                    i--; // Уменьшаем счетчик, так как после удаления элементов сдвигаются
                }
            }
            listBox1.Items.Add("ФИО Куратора: " + textBox2.Text);
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string currentItem = listBox1.Items[i].ToString();

                if (currentItem.Contains("неделя"))
                {
                    listBox1.Items.RemoveAt(i);
                    i--; // Уменьшаем счетчик, так как после удаления элементов сдвигаются
                }
            }
            DateTime dt1 = Convert.ToDateTime(e.Start.ToLongDateString());
            DateTime dt2 = dt1.AddDays(5);
            startWeekDate = dt1.Day + "." + dt1.Month + "." + dt1.Year;
            endWeekDate = dt2.Day + "." + dt2.Month + "." + dt2.Year;
            listBox1.Items.Add(String.Format("Выбранная неделя: " + dt1.Day + "." + dt1.Month + "." + dt1.Year + " - " + dt2.Day + "." + dt2.Month + "." + dt2.Year));
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileOutputStream;
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "XLSX (*.xlsx)|*.xlsx|XLS (*.xls)|*.xls";

            if (SFD.ShowDialog() == DialogResult.OK)
            {
                File.Copy(@"..\..\..\шаблон_рапортичка.xlsx", SFD.FileName);
                fileOutputStream = SFD.FileName;
                MessageBox.Show("Файл успешно сохранен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);


                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                Workbook excelWorkbook = excelApp.Workbooks.Open(fileOutputStream);
                Worksheet worksheet = excelWorkbook.Sheets[1];

                //2 12
                worksheet.Cells[3, 2].Value += textBox3.Text;
                worksheet.Cells[2, 22].Value += textBox1.Text;
                worksheet.Cells[2, 27].Value += textBox2.Text;
                worksheet.Cells[2, 11].Value += "c " + startWeekDate;
                worksheet.Cells[2, 16].Value += endWeekDate;

                int j = 0;
                for (int i = 6; i < 35; i++)
                {
                    try
                    {
                        worksheet.Cells[i, 2].Value += subj[j];
                    }
                    catch
                    {

                    }
                    j++;
                }

                excelWorkbook.Save();
                excelWorkbook.Close();
                excelApp.Quit();

                StreamWriter sw = new StreamWriter(@"..\..\..\Log\LastLog.txt");

                sw.WriteLine(textBox1.Text);
                sw.WriteLine(textBox2.Text);
                sw.WriteLine(textBox3.Text);
                sw.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            add_subj a1 = new add_subj();
            DialogResult dr = a1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                listBox1.Items.Add("Список студентов:");
                for (int i = 0; i < a1.subjList.Count; i++)
                {
                    listBox1.Items.Add(a1.subjList[i]);
                    subj.Add(a1.subjList[i]);
                }
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string currentItem = listBox1.Items[i].ToString();

                if (currentItem.Contains("Группа"))
                {
                    listBox1.Items.RemoveAt(i);
                    i--; // Уменьшаем счетчик, так как после удаления элементов сдвигаются
                }
            }
            listBox1.Items.Add("Группа: " + textBox3.Text);
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
