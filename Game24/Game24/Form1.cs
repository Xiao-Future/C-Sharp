/*-------------24点小游戏--------------
 *                            --By Shaw
 * 24点小游戏，拥有计算与闯关功能
 * 成功的实现了去除冗余结果和重复计算
 * 是目前网上比较过程序里较为精确的一个
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Game24
{
    public partial class Form1 : Form
    {
        Operator operators;
        Caculate caculates;
        Caculate compete;
        DateTime start;
        DateTime end;
        
        public List<int> randomNumber;
        public List<double> number = new List<double>();
        public int[] judgeNumber = new int[4];

        private int levelNow = 0;

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1;
            timer1.Tick+=new EventHandler(GameStart);
            timer1.Enabled = false;
            timer2.Interval = 1;
            timer2.Tick += new EventHandler(GameOver);
            timer2.Enabled = false;
            operators = new Operator(textInput.Text);
        }

        private void buttonGiveUp_Click(object sender, EventArgs e)
        {
            compete = new Caculate((int)numericUpDown1.Value, (int)numericUpDown2.Value, (int)numericUpDown3.Value, (int)numericUpDown4.Value);
            toolStripButtonTeach.Visible = true;
            buttonConfirm.Visible = false;
            buttonGiveUp.Visible = false;
            toolStripButtonGame.Visible = false;
            labelPleaseInput.Visible = false;
            textInput.Visible = false;
            timer1.Enabled = false;
            listBox1.Items.Clear();
            number = compete.ReSort();
            for (int i = 0; i < compete.Caculate24(number).Count; i++)
            {
                if (compete.Caculate24(number)[i] != "")
                {
                    listBox1.Items.Add(compete.Caculate24(number)[i]); 
                }
            }
            MessageBox.Show("最后闯关等级为" + levelNow, "游戏结束", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listBox1.Items.Clear();
            timer1.Interval = 1;
            timer1.Enabled = false;
            timer2.Enabled = false;
            levelNow = 0;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            judgeNumber = operators.GotTheNumberOfInput(textInput.Text);
            if (operators.JudgeThe24(textInput.Text,randomNumber,judgeNumber))
            {
                MessageBox.Show("Bingo!");
                levelNow++;
                timer1.Interval = 1;
            }
            else
            {
                MessageBox.Show("Wrong!");
            }
        }

        private void toolStripButtonStart_Click(object sender, EventArgs e)
        {
            toolStripButtonTeach.Visible = false;
            buttonConfirm.Visible = true;
            buttonGiveUp.Visible = true;
            toolStripButtonGame.Visible = true;
            labelPleaseInput.Visible = true;
            textInput.Visible = true;
            buttonCaculate.Visible = false;
        }

        private void buttonCaculate_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            caculates = new Caculate((int)numericUpDown1.Value, (int)numericUpDown2.Value, (int)numericUpDown3.Value, (int)numericUpDown4.Value);
            number = caculates.ReSort();
            for (int i = 0; i < caculates.Caculate24(number).Count; i++)
            {
                if (caculates.Caculate24(number)[i] != "")
                {
                    listBox1.Items.Add(caculates.Caculate24(number)[i]);
                }
            }
        }

        private void toolStripButtonTeach_Click(object sender, EventArgs e)
        {
            buttonCaculate.Visible = true;
        }

        private void toolStripButtonGame_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定开始游戏?", "游戏开始", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                toolStripButtonGame.Visible = false;
                timer1.Enabled = true;
                timer2.Enabled = true;
                start = DateTime.Now;
            }
        }

        public void GameStart(object sender, EventArgs e)
        {
            timer1.Interval = 60000;
            randomNumber = operators.RandomTheNumber();
            numericUpDown1.Value = randomNumber[0];
            numericUpDown2.Value = randomNumber[1];
            numericUpDown3.Value = randomNumber[2];
            numericUpDown4.Value = randomNumber[3];
            compete = new Caculate((int)numericUpDown1.Value, (int)numericUpDown2.Value, (int)numericUpDown3.Value, (int)numericUpDown4.Value);
            toolStripStatusLabel1.Text = "等级： " + levelNow;
            
        }

        public void GameOver(object sender, EventArgs e)
        {
            end = DateTime.Now;
            int endTime = int.Parse(end.Second.ToString());
            int startTime =int.Parse(start.Second.ToString());
            if (endTime - startTime > 59)
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                MessageBox.Show("最后闯关等级为" + levelNow, "游戏结束", MessageBoxButtons.OK, MessageBoxIcon.Information);
                levelNow = 0;
            }
        }

    }
}
