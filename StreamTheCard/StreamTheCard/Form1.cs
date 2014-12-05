using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace StreamTheCard
{
    [Serializable]
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random random = new Random();
        private Deck RandomDeck(int Number)
        {
            Deck myDeck = new Deck(new Card[]{});
            for (int i = 0; i < Number; i++)
			{
                myDeck.Add(new Card((Card.Suits)random.Next(4),(Card.Values)random.Next(1,14)));
			}
            return myDeck;
        }
        private void DealCards(Deck DeckToDeal, string Title)
        {
            Console.WriteLine(Title);
            while (DeckToDeal.Count>0)
            {
                Card nextCard = DeckToDeal.Deal(0);
                Console.WriteLine(nextCard.Name);
            }
            Console.WriteLine("--------------------");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Deck deckToWrite = RandomDeck(5);
            using (Stream output = File.Create(@"D:\Deck1.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(output, deckToWrite);
            }
            DealCards(deckToWrite, "What i just wrote to the file");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Deck deckFromFile;
            using (Stream input = File.OpenRead(@"D:\Deck1.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                deckFromFile= (Deck)bf.Deserialize(input);
            }
            DealCards(deckFromFile, "What i read from the file");
        }
    }
}
