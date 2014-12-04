﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace poker
{
    class CardCompare_byValue:IComparer<Card>
    {

        #region IComparer<Card> 成员

        public int Compare(Card x, Card y)
        {
            if (x.Value<y.Value)
            {
                return -1;
            }
            else if (x.Value>y.Value)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        #endregion
    }
}
