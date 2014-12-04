using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GoFishing
{
    public class Player
    {
        private string name;
        public string Name { get { return name; } }
        private Random random;
        private Deck cards;
        private TextBox textBoxOnForm;
        public Player(String name, Random random, TextBox textBoxOnForm)
        {
            this.name = name;
            this.random = random;
            this.textBoxOnForm = textBoxOnForm;
            this.cards=new Deck (new Card[]{});
            textBoxOnForm.Text += Name + "加入了游戏\r\n";

        }//构造函数更新4个私有空间，增加一行到TextBox，如“Joe has just jioned the game”，name要是私有的，在每行加到TextBox后面的要分行（"\r\n"）
        public List<Card.Values> PullOutBooks() 
        {
            List<Card.Values> Books = new List<Card.Values>();
            for (int i = 0; i <= 13; i++)
            {
                Card.Values value = (Card.Values)i;
                int howMany = 0;
                for (int card = 0; card < cards.Count; card++)
                {
                    if (cards.Peek(card).Value==value)
                    {
                        howMany++;
                    }
                }
                if (howMany == 4)
                {
                    Books.Add(value);
                    for (int card = cards.Count - 1; card >= 0; card--)
                    {
                        cards.Deal(card);
                    }
                } 
            }
            return Books;
        }//
        public Card.Values GetRandomValue()
        {
            Card randomCard=cards.Peek(random.Next(cards.Count));
            return randomCard.Value;
        }//随机的得到一个随机的值，但是比较是包含在deck中的值
        public Deck DoYouHaveAny(Card.Values value)
        {
            Deck cardsIHave = cards.PullOutValues(value);
            textBoxOnForm.Text += Name + "有" + cardsIHave.Count +"张"+ Card.Plural(value)+"\r\n";
            return cardsIHave;
        }//当对手询问我是否有一个确定值的牌的时候，使用Deck.PullOutValues()来输出值，增加一行到TextBox：joe have 3 sixes(使用Card.Plural()静态方法
        public void AskForACard(List<Player> players, int myIndex, Deck stock)
        {
            Card.Values randomValue = GetRandomValue();
            AskForACard(players, myIndex, stock,randomValue);
        }//AskForACard函数的重载-从deck中用GetRandomValue()选取一个随机的牌,并使用AskForACard要这张牌
        public void AskForACard(List<Player> players, int myIndex, Deck stock, Card.Values value)
        {
            textBoxOnForm.Text += Name + "询问是否有人有" + Card.Plural(value) + "\r\n";
            int totalCardGiven = 0;
            for (int i = 0; i < players.Count; i++)
            {
                if (i != myIndex)
                {
                    Deck CardsGiven = players[i].DoYouHaveAny(value);
                    totalCardGiven += CardsGiven.Count;
                    while (CardsGiven.Count>0)
                    {
                        cards.Add(CardsGiven.Deal());
                    }
                }
            }
            if (totalCardGiven == 0)
            {
                textBoxOnForm.Text += Name + "从牌堆中摸一张牌\r\n";
                cards.Add(stock.Deal());
            }
        }//问别的玩家要一张相应的牌。首先增加“Joe asks if anyone has a Queen”,然后以此为参数遍历players这个list，并且问每个玩家他是否有相应的牌（用DoYouHaveAny()）
        //给一张deck里的牌，增加到my deck里，保持跟踪有多少牌添加进来了。如果大家都没有牌，你需要从牌堆中获得一张牌，要加上一句话“Joe had to draw form the stock”
        public int CardCount{get{return cards.Count;}}
        public void TakeCard(Card card) { cards.Add(card); }
        public string[] GetCardNames() { return cards.GetCardNames(); }
        public Card Peek(int carNumber) { return cards.Peek(carNumber); }
        public void SortHand() { cards.SortByValue(); }
    }
}
