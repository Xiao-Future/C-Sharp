using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data;

namespace Test
{
    public partial class Form1 : Form
    {
        DataTable da = new DataTable();
        int c = 0, d = 0, j = 0, f = 0, h = 0;
        string[] a = new string[2] { "(2+3)+4+5=24", "3+(2+4)+5=24" };
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string aaa = da.Compute("6*6", "false").ToString();
            if (da.Compute("6*4","false").ToString()=="24")
            {
                MessageBox.Show("Bingo!");
            }
        }
        public int[] XX(string a)
        {
            int[] aa = new int[5];
            char[] b = a.ToCharArray();
            for (int i = 0; i < b.Length; i++)
            {
                string g = b[i].ToString();
                switch (g)
                {
                    case "+": aa[0]++; break;
                    case "-": aa[1]++; break;
                    case "x": aa[2]++; break;
                    case "÷": aa[3]++; break;
                    case "(": aa[4]++; break;
                    default: break;
                }
            }
            return aa;
        }
    }
}
