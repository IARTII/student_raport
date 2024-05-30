namespace KURSOVOI_PROECT_KURS3
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            сохранитьToolStripMenuItem = new ToolStripMenuItem();
            выйтиToolStripMenuItem = new ToolStripMenuItem();
            справкаToolStripMenuItem = new ToolStripMenuItem();
            помощьToolStripMenuItem = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
            Студенты = new DataGridViewTextBoxColumn();
            пара1 = new DataGridViewTextBoxColumn();
            пара2 = new DataGridViewTextBoxColumn();
            пара3 = new DataGridViewTextBoxColumn();
            пара4 = new DataGridViewTextBoxColumn();
            пара5 = new DataGridViewTextBoxColumn();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 396);
            button1.Name = "button1";
            button1.Size = new Size(175, 42);
            button1.TabIndex = 0;
            button1.Text = "Добавить расписание";
            button1.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, справкаToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { сохранитьToolStripMenuItem, выйтиToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(59, 24);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.Size = new Size(224, 26);
            сохранитьToolStripMenuItem.Text = "Сохранить";
            сохранитьToolStripMenuItem.Click += сохранитьToolStripMenuItem_Click;
            // 
            // выйтиToolStripMenuItem
            // 
            выйтиToolStripMenuItem.Name = "выйтиToolStripMenuItem";
            выйтиToolStripMenuItem.Size = new Size(224, 26);
            выйтиToolStripMenuItem.Text = "Выйти";
            выйтиToolStripMenuItem.Click += выйтиToolStripMenuItem_Click;
            // 
            // справкаToolStripMenuItem
            // 
            справкаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { помощьToolStripMenuItem });
            справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            справкаToolStripMenuItem.Size = new Size(81, 24);
            справкаToolStripMenuItem.Text = "Справка";
            // 
            // помощьToolStripMenuItem
            // 
            помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            помощьToolStripMenuItem.Size = new Size(152, 26);
            помощьToolStripMenuItem.Text = "Помощь";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Студенты, пара1, пара2, пара3, пара4, пара5 });
            dataGridView1.Location = new Point(310, 31);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(478, 407);
            dataGridView1.TabIndex = 2;
            // 
            // Студенты
            // 
            Студенты.HeaderText = "Студенты";
            Студенты.MinimumWidth = 6;
            Студенты.Name = "Студенты";
            Студенты.Width = 125;
            // 
            // пара1
            // 
            пара1.HeaderText = "пара1";
            пара1.MinimumWidth = 3;
            пара1.Name = "пара1";
            пара1.Width = 60;
            // 
            // пара2
            // 
            пара2.HeaderText = "пара2";
            пара2.MinimumWidth = 6;
            пара2.Name = "пара2";
            пара2.Width = 60;
            // 
            // пара3
            // 
            пара3.HeaderText = "пара3";
            пара3.MinimumWidth = 6;
            пара3.Name = "пара3";
            пара3.Width = 60;
            // 
            // пара4
            // 
            пара4.HeaderText = "пара4";
            пара4.MinimumWidth = 6;
            пара4.Name = "пара4";
            пара4.Width = 60;
            // 
            // пара5
            // 
            пара5.HeaderText = "пара5";
            пара5.MinimumWidth = 6;
            пара5.Name = "пара5";
            пара5.Width = 60;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form3";
            Text = "Form3";
            FormClosing += Form3_FormClosing;
            Load += Form3_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem сохранитьToolStripMenuItem;
        private ToolStripMenuItem выйтиToolStripMenuItem;
        private ToolStripMenuItem справкаToolStripMenuItem;
        private ToolStripMenuItem помощьToolStripMenuItem;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Студенты;
        private DataGridViewTextBoxColumn пара1;
        private DataGridViewTextBoxColumn пара2;
        private DataGridViewTextBoxColumn пара3;
        private DataGridViewTextBoxColumn пара4;
        private DataGridViewTextBoxColumn пара5;
    }
}