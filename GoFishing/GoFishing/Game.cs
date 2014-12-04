using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GoFishing
{
    public class Game
    {
        private List<Player> players;
        private Dictionary<Card.Values, Player> books;
        private Deck stock;
        private TextBox textBoxOnForm;
        //private string description;
        //public string Description { get { return description; } } 
        public Game(string playerName, string[] opponentNames, TextBox textBoxOnForm)
        {
            Random random = new Random();
            this.textBoxOnForm = textBoxOnForm;
            players = new List<Player>();
            players.Add(new Player(playerName, random, textBoxOnForm));
            foreach (string player in opponentNames)
            {
                players.Add(new Player(player,random,textBoxOnForm));
            }
            books=new Dictionary<Card.Values,Player>();
            stock=new Deck();
            Deal();
            players[0].SortHand();
        }
        private void Deal()
        {
            stock.Shuffle();
            for (int i = 0; i < 5; i++)
            {
                foreach (Player player in players)
                {
                    player.TakeCard(stock.Deal());
                }
            }
            foreach (Player player in players)
            {
                player.PullOutBooks();
            }
        }//游戏开始，只在开始时调用。洗牌，然后给每个玩家发五张牌，然后用foreach循环为每个玩家调用PullOutBooks()函数
        public bool PlayOneRound(int selectedPlayerCard)
        {
            Card.Values cardToAskFor = players[0].Peek(selectedPlayerCard).Value;
            for (int i = 0; i < players.Count; i++)
            {
                if (i == 0)
                {
                    players[0].AskForACard(players, 0, stock, cardToAskFor);
                }
                else
                {
                    players[i].AskForACard(players, i, stock);
                }
                if (PullOutBooks(players[i]))
                {
                    textBoxOnForm.Text += players[i].Name + "重新抓手牌\r\n";
                    int card = 1;
                    while (card<=5 && stock.Count>0)
                    {
                        players[i].TakeCard(stock.Deal());
                        card++;
                    }
                }
                players[i].SortHand();
                if (stock.Count == 0)
                {
                    textBoxOnForm.Text += "牌摸完了，游戏结束！";
                    return true;
                }

            }
            return false;
        }//玩一轮！以玩家选择的手牌为参数，得到该牌的大小。遍历所有玩家，然后调用每个人的AskForACard方法，从人类玩家开始（Players[0]）.然后调用PullOutBooks(),一旦返回
        //true，玩家就可以用尽卡片。在所有玩家进行完后，排序人类玩家的手牌。然后检测牌堆看是否还有牌，如果有，充值TextBox说：“The stock is out of cards.Game Over!”
        //返回true，否则游戏继续，返回false
        public bool PullOutBooks(Player player)
        {
            List<Card.Values> BooksPulled = player.PullOutBooks();
            foreach (Card.Values value in BooksPulled)
            {
                books.Add(value, player);
            }
            if (player.CardCount == 0)
            {
                return true;
            }
            return false;
        }//放出一个玩家的套牌，如果玩家手牌没有了，就返回true，否则返回false。每个套牌都要添加到套牌字典中。如果一个玩家在他用所有的他的牌组成套牌并用尽手牌后获得胜利
        public string DescribeBooks()
        {
            string whoHasWhichBooks = "";
            foreach (Card.Values value in books.Keys)
            {
                whoHasWhichBooks += books[value].Name + "有" + Card.Plural(value) + "的套牌\r\n";
            }
            return whoHasWhichBooks;
        }//根据Books dictionary返回一个长字符串形容每个人的套牌：Joe has a book of sixes.\r\n Ed has a book of Aces
        public string GetWinnerName()
        {
            Dictionary<string, int> winners = new Dictionary<string, int>();
            foreach (Card.Values value in books.Keys)
            {
                string name = books[value].Name;
                if (winners.ContainsKey(name))
                {
                    winners[name]++;
                }
                else
                {
                    winners.Add(name, 1);
                }
            }
            int mostBooks = 0;
            foreach (string name in winners.Keys)
            {
                if (winners[name] > mostBooks)
                {
                    mostBooks = winners[name];
                }
            }
            bool tie = false;
            string winnerList = "";
            foreach (string  name in winners.Keys)
            {
                if (winners[name]==mostBooks)
                {
                    if (!String.IsNullOrEmpty(winnerList))
                    {
                        winnerList += "和";
                        tie = true;
                    }
                    winnerList += name;
                }
            }
            winnerList += "有" + mostBooks + "套牌";
            if (tie)
            {
                return "有多个赢家" + winnerList;
            }
            else
                return winnerList;
        }//游戏结束！使用自己的dictionary（winners）来追踪每个玩家结束的时候有多少套牌。首先在Books.Keys用一个foreach循环来找到winner dictionary中每个玩家结束有多少Books
        //，然后这个循环通过dictionary找到最大book的玩家。最后列出一个赢家列表比如“Joe and Ed”，如果有一个winner，返回“Ed with 3 books”，否则返回“a tie between 
        //Joe and Bob with 2 books”
        public string[] GetPlayerCardNames()
        {
            return players[0].GetCardNames();
        }
        public string DescribePlayerHands()
        {
            string description = "";
            for (int i = 0; i < players.Count; i++)
            {
                description += players[i].Name + "有" + players[i].CardCount + "张牌\r\n";
            }
            description += "牌堆中还有" + stock.Count + "张牌\r\n";
            return description;
        }

    }
}
