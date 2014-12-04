using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoFishing
{
    public class Card
    {
        public enum Suits
        {
            草花,
            黑桃,
            方片,
            红桃,
        }
        public enum Values
        {
            Ace=1,
            Two=2,
            Three=3,
            Four=4,
            Five=5,
            Six=6,
            Seven=7,
            Eight=8,
            Nine=9,
            Ten=10,
            Jack=11,
            Queen=12,
            King=13,
        }
       /* public enum Values:sbyte
        {
            1,
            2,
            3 = 3,
            4 = 4,
            5 = 5,
            6 = 6,
            7 = 7,
            8 = 8,
            9 = 9,
            10 = 10,
            J = 11,
            Q = 12,
            K = 13,
        }*/
        public Suits Suit;
        public Values Value;
        public Card(Suits Suit,Values Value)
        {
            this.Suit = Suit;
            this.Value = Value;
        }
        public string Name
        {
            get { return Suit.ToString()+ Value.ToString(); }
        }//卡牌显示
        public static string Plural(Card.Values value)
        {
            if (value == Values.Ace)
            {
                return "A";
            }
            else if (value == Values.Two)
            {
                return "2";
            }
            else if (value == Values.Three)
            {
                return "3";
            }
            else if (value == Values.Four)
            {
                return "4";
            }
            else if (value == Values.Five)
            {
                return "5";
            }
            else if (value == Values.Six)
            {
                return "6";
            }
            else if (value == Values.Seven)
            {
                return "7";
            }
            else if (value == Values.Eight)
            {
                return "8";
            }
            else if (value == Values.Nine)
            {
                return "9";
            }
            else if (value == Values.Ten)
            {
                return "10";
            }
            else if (value == Values.Jack)
            {
                return "J";
            }
            else if (value == Values.Queen)
            {
                return "Q";
            }
            else            {
                return "K";
            }

        }
    }
}
