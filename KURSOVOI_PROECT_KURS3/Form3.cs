﻿using System;
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

        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
