﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace KURSOVOI_PROECT_KURS3
{
    public partial class add_subj : Form
    {
        public List<string> subjList = new List<string>();
        public add_subj()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.Items.Count != 30)
            {
                checkedListBox1.Items.Add(textBox1.Text);
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Количество студентов не может быть больше 30!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<int> indexesToRemove = new List<int>();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    indexesToRemove.Add(i);
                }
            }

            for (int i = indexesToRemove.Count - 1; i >= 0; i--)
            {
                checkedListBox1.Items.RemoveAt(indexesToRemove[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                subjList.Add(checkedListBox1.Items[i].ToString());
            }
        }

        private void add_subj_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            if (OFD.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(OFD.FileName);

                while (!sr.EndOfStream)
                {
                    checkedListBox1.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            if (SFD.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(SFD.FileName);

                for(int i = 0;i < checkedListBox1.Items.Count;i++)
                {
                    sw.WriteLine(checkedListBox1.Items[i].ToString());
                }
                sw.Close();
            }
        }
    }
}
