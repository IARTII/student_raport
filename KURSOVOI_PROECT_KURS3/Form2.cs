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

namespace KURSOVOI_PROECT_KURS3
{
    public partial class Form2 : Form
    {
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

        class Raport
        {
            public DateTime StartWeek { get; set; }
            public DateTime EndWeek { get; set; }
            public Raport(DateTime StartWeek)
            {
                this.StartWeek = StartWeek;
                EndWeek = StartWeek.AddDays(6);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("Выбранные данные:");
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

        private void button1_Click(object sender, EventArgs e)
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
            listBox1.Items.Add("Выбранная неделя:  " + monthCalendar1);
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
                File.Copy(@"C:\Users\ART1\source\repos\KURSOVOI_PROECT_KURS3\KURSOVOI_PROECT_KURS3\bin\Debug\net8.0-windows\шаблон_рапортичка.xlsx", SFD.FileName);
                fileOutputStream = SFD.FileName;
                MessageBox.Show("Файл успешно сохранен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                

                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                Workbook excelWorkbook = excelApp.Workbooks.Open(fileOutputStream);
                Worksheet worksheet = excelWorkbook.Sheets[1];

                //2 12
                worksheet.Cells[2, 22].Value += textBox1.Text;
                worksheet.Cells[2, 27].Value += textBox2.Text;
                worksheet.Cells[2, 12].Value += startWeekDate;
                worksheet.Cells[2, 15].Value += endWeekDate;

                excelWorkbook.Save();
                excelWorkbook.Close();
                excelApp.Quit();
            }
        }
    }
}
