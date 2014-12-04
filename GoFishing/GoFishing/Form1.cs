using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GoFishing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Game game;

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty (textName.Text))
            {
                MessageBox.Show("请输入姓名","不能开始游戏");
                return;
            }
            game =new Game(textName .Text ,new string[] {"小明","小华"},textProgress);
            buttonStart.Enabled = false;
            textName.Enabled = false;
            buttonAsk.Enabled = true;
            UpdateForm();
        }
        private void UpdateForm()
        {
            listHand.Items.Clear();
            // string[] a= game.GetPlayerCardNames();
            // MessageBox.Show(a [0]);
            foreach (String cardName in game.GetPlayerCardNames())
            {
                listHand.Items.Add(cardName);
            }
            textBooks.Text = game.DescribeBooks();
            textProgress.Text += game.DescribePlayerHands();
            textProgress.SelectionStart = textProgress.Text.Length;
            textProgress.ScrollToCaret();
        }

        private void buttonAsk_Click(object sender, EventArgs e)
        {
            textProgress.Text = "";
            if (listHand .SelectedIndex<0)
            {
                MessageBox.Show("请选择一张牌");
                return;
            }
            if (game.PlayOneRound(listHand.SelectedIndex) )
            {
                textProgress.Text += " 赢家是" + game.GetWinnerName();
                textBooks.Text = game.DescribeBooks();
                buttonAsk.Enabled = false;
            }
            else
            {
                UpdateForm();

            }
        }

        private void Intraducaion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("游戏简介\r\n套牌：拥有相同的值的四个花色的牌\r\n这里总共有56张扑克牌，游戏开始所有玩家将会得到5张初始牌\r\n轮到你的回合时，你出示手中的任意一张牌\r\n如果你的对手有，则把相同值的牌给你，如果没有，那么你从牌堆上摸一张牌。\r\n胜利条件：所有牌摸完之后，拥有套牌最多的选手获胜");
        }        
    }
}
