using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            List<string> student_surname = new List<string>();

            string fileInputStream;
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "XLSX (*.xlsx)|*.xlsx|XLS (*.xls)|*.xls";

            if (OFD.ShowDialog() == DialogResult.OK)
            {
                fileInputStream = OFD.FileName;

                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                Workbook excelWorkbook = excelApp.Workbooks.Open(fileInputStream);
                Worksheet worksheet = excelWorkbook.Sheets[1];

                for(int i = 6; i < 35; i++)
                {
                    if(worksheet.Cells[i, 2].Value != "")
                    {
                        student_surname.Add(worksheet.Cells[i, 2].Value);
                    }
                }

                foreach (var value in student_surname)
                {

                    int rowIndex = dataGridView1.Rows.Add();

                    // Добавляем значение в первый столбец (индекс 0) новой строки
                    dataGridView1.Rows[rowIndex].Cells[0].Value = value;
                }

                excelWorkbook.Save();
                excelWorkbook.Close();
                excelApp.Quit();
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
    }
}
