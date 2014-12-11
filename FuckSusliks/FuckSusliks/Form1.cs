using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FuckSusliks
{
    public partial class Form1 : Form
    {
        bool start = false;
        Mole mole;
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            mole = new Mole(random, new Mole.PopUp(MoleCallBack));
            timer1.Interval = random.Next(500, 1000);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (start)
            {
                timer1.Stop();
                ToggleMole();
            }
        }

        private void ToggleMole()
        {
            if (mole.Hidden == true)
            {
                mole.show();
            }
            else
            {
                mole.HideAgain(int.Parse(numericUpDown1.Value.ToString()));
            }
            timer1.Interval = random.Next(500, 1000);
            timer1.Start();
        }
        private void MoleCallBack(int MoleNumber, bool show)
        {
            if (MoleNumber < 0)
            {
                timer1.Stop();
                return;
            }
            Button button;
            switch (MoleNumber)
            {
                case 0: button = button1; break;
                case 1: button = button2; break;
                case 2: button = button3; break;
                case 3: button = button4; break;
                default: button = button5; break;
            }
            if (show == true)
            {
                if (random.Next(2) == 1)
                {
                    button.Text = "Hit me";
                    button.BackColor = Color.Red;
                }
                else
                {
                    button.Text = "Don't hit";
                    button.BackColor = Color.Blue;
                }
            }
            else
            {
                button.Text = "";
                button.BackColor = SystemColors.Control;
            }
            timer1.Interval = random.Next(500, 1000);
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.Red)
            {
                mole.Smacked(0, int.Parse(numericUpDown1.Value.ToString()));
                button1.Text = "Bingo!";
            }
            else
            {
                mole.WrongSmacked(0, int.Parse(numericUpDown1.Value.ToString()));
                button1.Text = "Boo!";
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.Red)
            {
                mole.Smacked(2, int.Parse(numericUpDown1.Value.ToString()));
                button3.Text = "Bingo!";
            }
            else
            {
                mole.WrongSmacked(2, int.Parse(numericUpDown1.Value.ToString()));
                button3.Text = "Boo!";
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.Red)
            {
                mole.Smacked(1, int.Parse(numericUpDown1.Value.ToString()));
                button2.Text = "Bingo!";
            }
            else
            {
                mole.WrongSmacked(1, int.Parse(numericUpDown1.Value.ToString()));
                button2.Text = "Boo!";
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (button4.BackColor == Color.Red)
            {
                mole.Smacked(3, int.Parse(numericUpDown1.Value.ToString()));
                button4.Text = "Bingo!";
            }
            else
            {
                mole.WrongSmacked(3, int.Parse(numericUpDown1.Value.ToString()));
                button4.Text = "Boo!";
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (button5.BackColor == Color.Red)
            {
                mole.Smacked(4, int.Parse(numericUpDown1.Value.ToString()));
                button5.Text = "Bingo!";
            }
            else
            {
                mole.WrongSmacked(4, int.Parse(numericUpDown1.Value.ToString()));
                button5.Text = "Boo!";
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            start = true;
        }
    }
}
