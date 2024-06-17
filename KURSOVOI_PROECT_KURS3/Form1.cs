using Microsoft.Office.Interop.Excel;
using System.Drawing.Printing;
using Spire.Xls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Windows.Forms;

namespace KURSOVOI_PROECT_KURS3
{
    public partial class Form1 : Form
    {

        int p = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "XLSX (*.xlsx)|*.xlsx|XLS (*.xls)|*.xls";

            if (OFD.ShowDialog() == DialogResult.OK)
            {
                //Создаем объект Workbook 
                Spire.Xls.Workbook workbook = new Spire.Xls.Workbook();
                //Загрузить файл Excel 
                workbook.LoadFromFile(OFD.FileName);
                //Создаем объект PrintDialog 
                PrintDialog dialog = new PrintDialog();
                //Укажите диалог настроек принтера.AllowCurrentPage = true;
                dialog.AllowCurrentPage = true;
                dialog.AllowSomePages = true;
                dialog.AllowSelection = true;
                dialog.UseEXDialog = true;
                dialog.PrinterSettings.Duplex = Duplex.Simplex;
                dialog.PrinterSettings.PrintRange = PrintRange.AllPages;

                //Create a PrintDocument object based on the workbook
                PrintDocument printDocument = workbook.PrintDocument;
                //Invoke the print dialog
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }
            }
        }
    }
}
