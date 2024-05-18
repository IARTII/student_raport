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

namespace KURSOVOI_PROECT_KURS3
{
    public partial class Form2 : Form
    {
        int c = 0; //переключатель для выхода из программы
        public Form2()
        {
            InitializeComponent();
        }
 
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (c == 0)
            {
                Application.OpenForms[0].Show();
            }
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            c = 1;
            Application.OpenForms[0].Show();
            this.Close();
        }

        class Raport
        {
            public DateTime StartWeek { get; set; }
            public DateTime EndWeek;
            public Raport(DateTime StartWeek)
            {
                this.StartWeek = StartWeek;
                EndWeek = StartWeek.AddDays(6);
            }

        }
    }
}
