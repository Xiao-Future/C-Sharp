using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store
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
    }
}
