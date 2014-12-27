using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CaculateAnsysWendy
{
    public partial class Form1 : Form
    {
        const double yJ = 0, yK = 0.25, yI = 0;
        const double xI = 0, xJ = 0.125, xK = 0.125;
        const double w = 0.25, l = 0.125;
        const double G = 1100000, Theta = 0.005;

        double pi, pj, pk, oi, oj, ok;
        double s;//三角形面积
        Caculate k1, k2, k3, d1, d2, d3, f1, f2, f3, k, f;
        double[,] data1, data2, data4;
        double[] da1, da2,da3;
        string show;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            show = "荷载矩阵为：(";
            pi = yJ - yK;
            pj = yK - yI;
            pk = yI - yJ;
            oi = xK - xJ;
            oj = xI - xK;
            ok = xJ - xI;//计算系数贝塔和Theta

            s = (xI * (yJ - yK) + xJ * (yK - yI) + xK * (yI - yJ)) / 2;//三角形面积

            data1 = new double[,] { { pi * pi, pi * pj, pi * pk }, { pi * pj, pj * pj, pj * pk }, { pi * pk, pj * pk, pk * pk } };
            data2 = new double[,] { { oi * oi, oi * oj, oi * ok }, { oi * oj, oj * oj, oj * ok }, { oi * ok, oj * ok, ok * ok } };
            d1 = new Caculate(data1);
            d2 = new Caculate(data2);
            k1 = 0.25 / s * d1 + 0.25 / s * d2;
            k3 = k1;//计算单元1和3的刚度矩阵

            data1 = new double[,] { { 2, -2, -1, 1 }, { -2, 2, 1, -1 }, { -1, 1, 2, -2 }, { 1, -1, -2, 2 } };
            data2 = new double[,] { { 2, 1, -1, -2 }, { 1, 2, -2, -1 }, { -1, -2, 2, 1 }, { -2, -1, 1, 2 } };
            d1 = new Caculate(data1);
            d2 = new Caculate(data2);
            k2 = w / 6 / l * d1 + w / 6 / l * d2;//计算单元2的刚度矩阵

            da1=new double[]{1,1,1};
            d3=new Caculate(da1);
            f1 = 2 * G * Theta * s / 3 * d3;
            f3 = f1;
            da2 = new double[] { 1, 1, 1, 1 };
            d1 = new Caculate(da2);
            f2 = 2 * G * Theta * s / 4 * d1;//计算荷载矩阵

            da3 = new double[] { f1[0, 0], f1[0, 1] + f2[0, 0], f2[0, 1], f1[0, 2] + f2[0, 2] + f3[0, 2], f2[0, 3] + f3[0, 1], f3[0, 2] };//组装荷载矩阵
            for (int i = 0; i < 6; i++)
            {
                show += da3[i].ToString() + ", ";
            }
            show += "）";
            MessageBox.Show(show);
        }
    }
}
