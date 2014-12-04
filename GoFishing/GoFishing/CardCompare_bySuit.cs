using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoFishing
{
    public class CardCompare_bySuit:IComparer<Card>
    {

        #region IComparer<Card> 成员

        public int Compare(Card x, Card y)
        {
            if (x.Value<y.Value)
            {
                return -1;
            }
            if (x.Value>y.Value)
            {
                return 1;
            }
            if (x.Suit < y.Suit)
            {
                return -1;
            }
            if (x.Suit > y.Suit)
            {
                return 1;
            }
            return 0;
        }

        #endregion
    }
}
