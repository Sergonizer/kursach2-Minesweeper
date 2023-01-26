using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form3 : Form
    {
        private bool custom;
        private int size;
        private string seldifficulty;
        private DataTable dt = new DataTable();

        public Form3()
        {
            DataColumn column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Время";
            column.ReadOnly = true;
            dt.Columns.Add(column);
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Игрок";
            column.ReadOnly = true;
            dt.Columns.Add(column);
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Сложность";
            column.ReadOnly = true;
            dt.Columns.Add(column);
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
        }

        private void edit_table()
        {
            dt.Clear();
            FileStream stream = File.OpenRead("highscores.txt");
            StreamReader reader = new(stream);
            string line;
            string difficulty;
            while ((line = reader.ReadLine()) != null)
            {
                string[] curr_line = line.Split(",");
                if (dt.Columns.Count > 3)
                {
                    dt.Columns.RemoveAt(4);
                    dt.Columns.RemoveAt(3);
                }
                if (custom && curr_line[0] != "Custom")
                {
                    continue;
                }
                if (!custom && curr_line[0] == "Custom")
                {
                    continue;
                }
                if (!custom && int.Parse(curr_line[1]) != size)
                {
                    continue;
                }
                difficulty = curr_line[0] == "Easy" ? "Лёгкая" : curr_line[0] == "Normal" ? "Средняя" : curr_line[0] == "Hard" ? "Сложная" : "Своя";
                if (difficulty != seldifficulty)
                {
                    continue;
                }
                DataRow row = dt.NewRow();
                if (custom)
                {
                    DataColumn column = new DataColumn();
                    column.DataType = Type.GetType("System.String");
                    column.ColumnName = "Размер";
                    column.ReadOnly = true;
                    dt.Columns.Add(column);
                    row["Размер"] = $"{int.Parse(curr_line[1])}x{int.Parse(curr_line[2])}";
                    column = new DataColumn();
                    column.DataType = Type.GetType("System.Int32");
                    column.ColumnName = "Количество мин";
                    column.ReadOnly = true;
                    dt.Columns.Add(column);
                    row["Количество мин"] = int.Parse(curr_line[3]);
                }
                row["Время"] = curr_line[4];
                row["Игрок"] = curr_line[5];
                row["Сложность"] = difficulty;
                dt.Rows.Add(row);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.RowHeadersVisible = false;
            }
            reader.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 3)
            {
                custom = true;
                comboBox2.SelectedIndex = 3;
            }
            else
            {
                custom = false;
                if (comboBox2.SelectedIndex == 3)
                    comboBox2.SelectedIndex = 0;
                size = (comboBox1.SelectedIndex + 1) * 5;
            }
            edit_table();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 3)
            {
                custom = true;
                comboBox1.SelectedIndex = 3;
                seldifficulty = "Своя";
            }
            else
            {
                custom = false;
                if (comboBox1.SelectedIndex == 3)
                    comboBox1.SelectedIndex = 0;
                seldifficulty = comboBox2.SelectedIndex == 0 ? "Лёгкая" : comboBox2.SelectedIndex == 1 ? "Средняя" : comboBox2.SelectedIndex == 2 ? "Сложная" : "Своя";
            }
            edit_table();
        }
    }
}
