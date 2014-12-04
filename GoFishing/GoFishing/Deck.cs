using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoFishing
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
        }//创建一副牌
        public Deck(Card[] initialCards)
        {
            cards = new List<Card>(initialCards);
        }//Deck函数的重载，将加载的扑克数组组成一副牌
        public int Count { get { return cards.Count; } }//得到某一张扑克牌在数组的序号
        public void Add(Card cardToAdd)
        {
            cards.Add(cardToAdd);
        }//在cards中增加所需要的牌
        public Card Deal(int index)
        {
            Card CardToDeal = cards[index];
            cards.RemoveAt(index);
            return CardToDeal;
        }//出牌！出相应输入序号对应的牌
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
                CardNames[i] = cards[i].Suit+ Card.Plural(cards[i].Value);
            }
            return CardNames;
        }//显示包含的每张牌的名字
        public void Sort()
        {
            cards.Sort(new CardCompare_bySuit());
        }//将牌按照牌种排序
        public Card Peek(int cardNumber)
        {
            return cards[cardNumber];
        }//查看牌堆中的某张牌
        public Card Deal()
        {
            return Deal(0);
        }//重载Deal函数，不传入数则发最上面的牌
        public bool ContainsValue(Card.Values value)
        {
            foreach (Card card in cards)
            {
                if (card.Value==value)
                {
                    return true;
                }
            }
            return false;
        }//判断牌堆中是否有这张牌
        public Deck PullOutValues(Card.Values value)
        {
            Deck deckToReturn = new Deck(new Card[] { });
            for (int i = cards.Count-1; i >= 0; i--)
            {
                if (cards[i].Value==value)
                {
                    deckToReturn.Add(Deal(i));
                }
            }
            return deckToReturn;
        }//查看牌堆中是否有与该牌大小一样的牌，并取出放到一个新的牌堆中
        public bool HasBook(Card.Values value)
        {
            int NumberOfCards = 0;
            foreach (Card card in cards)
            {
                if (card.Value==value)
                {
                    NumberOfCards++;
                }
            }
            if (NumberOfCards==4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }//检查一副牌是否包含一套四张牌
        public void SortByValue()
        {
            cards.Sort(new CardCompare_byValue());
        }//将牌按值排序
    }
}
