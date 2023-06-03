using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Third_task
{
    public partial class Form1 : Form
    {
        int m;
        double sum;
        public Form1()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Кількість категорій витрат не введена!","Помилка");
            }
            else
            {
                m=Int32.Parse(textBox1.Text);
                if(m>10)
                {
                    MessageBox.Show("Кількість категорій витрат більша за 10!", "Помилка");
                }
                else
                {
                    dataGridView1.ColumnCount = m;
                    for (int i = 0; i < m; i++)
                    {
                        dataGridView1.Columns[i].Width = 110;
                        dataGridView1.ColumnHeadersDefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleCenter;
                        dataGridView1.Columns[i].HeaderText = "Витрати категорії " + (i+1).ToString();
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            sum = 0;
            double[] A = new double[m];
            string[] B = new string[m];
            for(int i = 0; i < m;i++)
            {
                A[i] = Convert.ToDouble(dataGridView1.Rows[0].Cells[i].Value);
                B[i] = "Витрати категорії " + (i + 1).ToString();
                sum += A[i];
                if (A[i] <= 0)
                {
                    MessageBox.Show("Серед елементів є негативні або нульові!", "Помилка");
                }
            }
            if (sum != 100)
            {
                MessageBox.Show("Сума відсоткового вмісту повинна дорівнювати 100%! Перевірте дані", "Помилка");
            }
            else
            {
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                chart1.Series[0].Points.DataBindXY(B, A);
                chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
            }
        }
    }
}
