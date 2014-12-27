using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CaculateCapacity
{
    public partial class Form1 : Form
    {
        const double c = 0.000000001;

        double u, Il, Iu;
        double[,] p;
        double[] pi = new double[2] { 0.5, 0.5 };
        double[] q = new double[2];
        double[] a = new double[2];

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double compareNum = 0;
            p = new double[,] { { double.Parse(textBox1.Text.ToString()), double.Parse(textBox2.Text.ToString()) }, { double.Parse(textBox3.Text.ToString()), double.Parse(textBox4.Text.ToString()) } };
            do
            {
                u = 0;
                Il = 0;
                Iu = 0;
                compareNum = 0;
                for (int i = 0; i < 2; i++)
                {
                    q[i] = pi[0] * p[0, i] + pi[1] * p[1, i];
                }
                for (int i = 0; i < 2; i++)
                {
                    double sum = 0;
                    for (int j = 0; j < 2; j++)
                    {
                        sum += p[i, j] * Math.Log((p[i, j] / q[j]),Math.E);
                    }
                    a[i] = Math.Pow(Math.E, sum);
                }
                for (int i = 0; i < 2; i++)
                {
                    u += pi[i] * a[i];
                }
                Il = Math.Log(u, 2);
                for (int i = 0; i < 2; i++)
                {
                    if (a[i] > compareNum)
                    {
                        compareNum = a[i];
                    }
                }
                Iu = Math.Log(compareNum, 2);
                if ((Iu - Il) > c)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        pi[i] = pi[i] * a[i] / u;
                    }
                }
            } while ((Iu - Il) > c);
            MessageBox.Show("输出信道容量的值C = " + Il + "比特/符号\r\n" + "P = (" + pi[0] + " ， " + pi[1] + ")");
        }

    }
}
