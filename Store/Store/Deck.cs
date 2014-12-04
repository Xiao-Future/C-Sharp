using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store
{
    public class Deck
    {
        private List<Card> cards;
        private Random randon = new Random();
        public Deck()
        {
            cards = new List<Card>();
            for (int suit = 0; suit <= 3; suit++)
            {
                for (int value = 0; value <= 13; value++)
                {
                    cards.Add(new Card((Card.Suits)suit, (Card.Values)value));
                }
            }
        }
        public Deck(Card[] initialCards)
        {
            cards = new List<Card>(initialCards);
        }
        public int Count { get { return cards.Count; } }
        public void Add(Card cardToAdd)
        {
            cards.Add(cardToAdd);
        }
        public Card Deal(int index)
        {
            Card CardToDeal = cards[index];
            cards.RemoveAt(index);
            return CardToDeal;
        }
        public void Shuffle()
        {
            List<Card> NewCards = new List<Card>();
            while (cards.Count>0)
            {
                int CardToMove = randon.Next(cards.Count);
                NewCards.Add(cards[CardToMove]);
                cards.RemoveAt(CardToMove);
            }
            cards = NewCards;
        }//洗牌
        public string[] GetCardNames()
        {
            string[] CardNames = new string[cards.Count];
            for (int i = 0; i < cards.Count; i++)
            {
                CardNames[i] = cards[i].Name;
            }
            return CardNames;
        }//显示包含的每张牌的名字
        public void Sort()
        {
            cards.Sort(new CardCompare_bySuit());
        }
    }
}
