using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Second_task
{
    public partial class Form1 : Form
    {
        int mGist, mRound, minAge, minYear;
        private void button3_Click(object sender, EventArgs e)
        {
            int[] C =new int[mGist];
            int[] D = new int[mGist];
            minYear -= mGist;
            for (int i = 0; i < mGist; i++)
            {
                C[i] = Convert.ToInt32(dataGridView1.Rows[0].Cells[i].Value);
                D[i] = minYear;
                minYear++;
                if (C[i] < 0)
                {
                    MessageBox.Show("Серед введених елементів є від'ємні!", "Помилка");
                }
            }
            chart1.Series[0].Points.DataBindXY(D,C);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int[] Age = new int[mRound];
            int[] Count = new int[mRound];
            minAge -=mRound;
            for (int i = 0; i < mRound; i++)
            {
                Count[i]= Convert.ToInt32(dataGridView2.Rows[0].Cells[i].Value);
                Age[i] = minAge;
                minAge++;
                if (Count[i] < 0)
                {
                    MessageBox.Show("Серед введених елементів є від'ємні!", "Помилка");
                }
            }
            chart1.Series[1].Legend = "Legend2";
            chart1.Legends["Legend2"].Position.Auto = false;
            chart1.Legends["Legend2"].Position = new ElementPosition(85, 51.5f, 10, 30);
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            chart1.Series[1].Points.DataBindXY(Age, Count);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                mRound = Convert.ToInt32(textBox3.Text);
                minAge = Convert.ToInt32(textBox4.Text);
                if (minAge < 10)
                {
                    MessageBox.Show("Мінімальний вік менший за 10 років!", "Помилка");
                }
                else
                {
                    dataGridView2.ColumnCount = mRound;
                    dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    for (int i = 0; i < mRound; i++)
                    {
                        dataGridView2.Columns[i].Width = 110;
                        dataGridView2.Columns[i].HeaderText = minAge.ToString() + " років";
                        minAge++;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Некоректно введені дані!", "Помилка");
            }
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                minYear = Convert.ToInt32(textBox1.Text);
                mGist = Convert.ToInt32(textBox2.Text);
                if (minYear < 2000)
                {
                    MessageBox.Show("Рік початку курсів - 2000-й!", "Помилка");
                }
                else
                {
                    dataGridView1.ColumnCount = mGist;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    for (int i = 0; i < mGist; i++)
                    {
                        dataGridView1.Columns[i].Width = 110;
                        dataGridView1.Columns[i].HeaderText = minYear.ToString() + " рік";
                        minYear++;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Некоректно введені дані!","Помилка");
            }
        }
    }
}
