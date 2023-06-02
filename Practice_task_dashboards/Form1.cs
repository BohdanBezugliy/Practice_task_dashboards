using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice_task_dashboards
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var item in chart1.Series)
            {
                comboBox1.Items.Add("Графік " + item.Name);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var item in chart1.Series)
            {
                item.Points.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            double Xmin, Xmax, Step;
            try
            {
                Xmin = double.Parse(textBox2.Text);
                Xmax = double.Parse(textBox3.Text);
                Step = double.Parse(textBox4.Text);
                int count = (int)Math.Ceiling((Xmax - Xmin)/Step)+1;
                double[] x = new double[count];
                double[] y1 = new double[count];
                double[] y2 = new double[count];
                double[] y3 = new double[count];
                double[] y4 = new double[count];
                double[] y5 = new double[count];
                for (int i = 0; i < count; i++)
                {
                    x[i] = Xmin + Step * i;
                    y1[i] = Math.Sin(x[i]);
                    y2[i] = Math.Cos(x[i]);
                    y3[i] = Math.Cos(x[i])+2*x[i];
                    y4[i] = Math.Sqrt(x[i]);
                    y5[i] = (x[i]+4)+Math.Pow(x[i],2);
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            textBox1.Text += "x[" + i.ToString() + "] = " + Convert.ToString(x[i]) + "   " + "y1[" + i.ToString() + "] = " + Convert.ToString(Math.Round(y1[i], 5)) + Environment.NewLine;
                            break;
                        case 1:
                            textBox1.Text += "x[" + i.ToString() + "] = " + Convert.ToString(x[i]) + "   " + "y2[" + i.ToString() + "] = " + Convert.ToString(Math.Round(y2[i], 5)) + Environment.NewLine;
                            break;
                        case 2:
                            textBox1.Text += "x[" + i.ToString() + "] = " + Convert.ToString(x[i]) + "   " + "y3[" + i.ToString() + "] = " + Convert.ToString(Math.Round(y3[i], 5)) + Environment.NewLine;
                            break;
                        case 3:
                            textBox1.Text += "x[" + i.ToString() + "] = " + Convert.ToString(x[i]) + "   " + "y4[" + i.ToString() + "] = " + Convert.ToString(Math.Round(y4[i], 5)) + Environment.NewLine;
                            break;
                        case 4:
                            textBox1.Text += "x[" + i.ToString() + "] = " + Convert.ToString(x[i]) + "   " + "y5[" + i.ToString() + "] = " + Convert.ToString(Math.Round(y5[i], 5)) + Environment.NewLine;
                            break;
                        default:
                            textBox1.Text = "Графік не обраний!";
                            break;
                    }
                }
                chart1.ChartAreas[0].AxisX.Minimum = Xmin;
                chart1.ChartAreas[0].AxisX.Maximum = Xmax;
                chart1.ChartAreas[0].AxisX.MajorGrid.Interval = Step;
                if (checkBox1.Checked)
                {
                    chart1.Series[0].Points.DataBindXY(x, y1);
                }
                if (checkBox2.Checked)
                {
                    chart1.Series[1].Points.DataBindXY(x, y2);
                }
                if (checkBox3.Checked)
                {
                    chart1.Series[2].Points.DataBindXY(x, y3);
                }
                if (checkBox4.Checked)
                {
                    chart1.Series[3].Points.DataBindXY(x, y4);
                }
                if (checkBox5.Checked)
                {
                    chart1.Series[4].Points.DataBindXY(x, y5);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Некоректне введення!", "Помилка");
            }
        }
    }
}
