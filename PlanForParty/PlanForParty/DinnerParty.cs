using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanForParty
{
    class DinnerParty
    {
        public const int CostOfFoodPerson = 25;
        private int numberOfPeople;
        public int NumberOfPeople
        {
            get { return numberOfPeople; }
            set { numberOfPeople = value;
            CalculateCostOfDecorations(fancyDecorations);
            }
        }
        private bool fancyDecorations;
        public decimal CostOfBeveragesPerson;
        public decimal CostOfDecorations = 0;
        public DinnerParty(int numberOfPeople, bool healthyOption, bool fancyDecorations)
        {
            this.NumberOfPeople = numberOfPeople;
            this.fancyDecorations = fancyDecorations;
            SetHealthyOption(healthyOption);
            CalculateCostOfDecorations(fancyDecorations);
        }
        public void SetHealthyOption(bool healthyOption)
        {
            if (healthyOption)
            {
                CostOfBeveragesPerson = 5.00M;
            }
            else 
            {
                CostOfBeveragesPerson = 20.00M;
            }
        }
        public void CalculateCostOfDecorations(bool fancy)
        {
            if (fancy)
            {
                CostOfDecorations = (NumberOfPeople * 15.00M) + 50M;
            }
            else
            {
                CostOfDecorations = (NumberOfPeople * 7.50M) + 30M;
            }
        }
        public decimal CalculateCost(bool healthyOption)
        {
            decimal totalCost = CostOfDecorations + ((CostOfBeveragesPerson + CostOfFoodPerson) * NumberOfPeople);
            if (healthyOption)
            {
                return totalCost * 0.95M;
            }
            else
            {
                return totalCost;
            }
        }
    }
}
