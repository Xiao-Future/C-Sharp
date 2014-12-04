using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace poker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            Card card = new Card((Card.Suits)random.Next(4), (Card.Values)random.Next(1, 14));
            MessageBox.Show(card.Name);
        }

        private void random5Cards_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Five random cards");
            List<Card> cards = new List<Card>();
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                cards.Add(new Card((Card.Suits)random.Next(4), (Card.Values)random.Next(1, 14)));
                Console.WriteLine(cards[i].Name);
            }
            Console .WriteLine("Those same cards,sorted:");
            cards.Sort(new CardCompare_byValue ());
            foreach(Card card in cards)
            {
                Console.WriteLine(card.Name);
            }
        }
    }
}
