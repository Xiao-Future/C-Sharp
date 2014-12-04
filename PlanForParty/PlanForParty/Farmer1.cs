using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanForParty
{
    class Farmer1
    {
        public int BagsOfFeed { get; private set; }
        private int feedMultiplier;
        public Farmer1(int numberOfCows,int feedMultiplier)
        {this.feedMultiplier=feedMultiplier;
        NumberOfCows=numberOfCows;}
        public int FeedMultiplier { get { return feedMultiplier; } }
        private int numberOfCows;
        public int NumberOfCows
        {
            get { return numberOfCows; }
            set { numberOfCows = value; BagsOfFeed = numberOfCows * FeedMultiplier; }
        }
    }
}
