using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SimulationEnvironment
{
    [Serializable]
    public class Hive
    {
        public double Honey { get; private set; }
        public Bee.BeeMessage MessageSender;

        private Dictionary<string, Point> locations;
        private int beeCount = 0;
        private World world;

        private const int InitialBees = 6;
        private const double InitialHoney = 3.2;
        private const double MaximumHoney = 15.0;
        private const double NectarHoneyRatio = 0.25;
        private const int MaximumBees = 8;
        private const double MinimumHoneyForCreatingBees = 4.0;//蜂巢中的一些常量

        public Point GetLocation(string location)
        {
            if (locations.Keys.Contains(location))
            {
                return locations[location];
            }
            else
            {
                throw new ArgumentException("Unknow location"+location);
            }
        }

        public void InitializeLocations()
        {
            locations = new Dictionary<string, Point>();
            locations.Add("Entrance",new Point(600,100));
            locations.Add("Nursery", new Point(95, 174));
            locations.Add("HoneyFactory", new Point(157, 98));
            locations.Add("Exit", new Point(194, 213));
        }

        public Hive(World world,Bee.BeeMessage MessageSender)
        {
            this.MessageSender = MessageSender;
            Honey = InitialHoney;
            this.world = world;
            InitializeLocations();
            Random random =new Random();
            for (int i = 0; i < InitialBees; i++)
            {
                AddBee(random);
            }
        }

        public bool AddHoney(double nectar)
        {
            double honeyToAdd = nectar * NectarHoneyRatio;
            if (honeyToAdd + Honey > MaximumHoney)
            {
                return false;
            }
            Honey += honeyToAdd;
            return true;
        }

        public bool ConsumeHoney(double amount)
        {
            if (amount > Honey)
            {
                return false;
            }
            else
            {
                Honey -= amount;
                return true;
            }
        }

        private void AddBee(Random random)
        {
            beeCount++;
            int r1 = random.Next(100) - 50;
            int r2 = random.Next(100) - 50;
            Point startPoint = new Point(locations["Nursery"].X + r1, locations["Nursery"].Y + r2);
            Bee newBee = new Bee(beeCount, startPoint, this, world);
            newBee.MessageSender += this.MessageSender;
            world.Bees.Add(newBee);//有系统之后，还需要把蜜蜂添加的系统中
        }

        public void Go(Random random)
        {
            if (world.Bees.Count < MaximumBees && Honey > MinimumHoneyForCreatingBees && random.Next(10) == 1)//
            {
                AddBee(random);
            }
        }
    }
}
