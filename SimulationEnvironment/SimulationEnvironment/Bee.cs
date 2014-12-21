using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SimulationEnvironment
{
    [Serializable]
    public class Bee
    {
        public enum BeeState
        {
            Idle,
            FlyingToFlower,
            GatheringNectar,
            ReturningToHive,
            MakingHoney,
            Retired
        }//蜜蜂的状态表

        private const double HoneyConsumed = 0.5;
        private const int MoveRate = 3;
        private const double MinimumFlowerNectar = 1.5;
        private const int CareerSpan = 1000;

        public int Age { get; private set; }
        public bool InsideHive { get; private set; }
        public double NectarCollected { get; private set; }
        public BeeState CurrentState { get; private set; }
        public delegate void BeeMessage(int ID, string Message);
        public BeeMessage MessageSender;

        private Point location;
        public Point Location { get { return location; } }
        private int ID;
        private Flower destinationFlower;
        private Hive hive;
        private World world;

        public Bee(int id, Point Initiallocation, Hive hive, World world)
        {
            this.ID = id;//没错吧
            Age = 0;
            location = Initiallocation;
            InsideHive = true;
            CurrentState = BeeState.Idle;
            destinationFlower = null;
            NectarCollected = 0;
            this.hive = hive;
            this.world = world;
        }

        private bool MoveTowardsLocation(Point destination)
        {
            if (destination != null)
            {
                if (Math.Abs(destination.X-location.X) <= MoveRate && Math.Abs(destination.Y-location.Y) <= MoveRate)
                {
                    return true;
                }
                if (destination.X > location.X)
                {
                    location.X += MoveRate;
                }
                else if (destination.X < location.X)
                {
                    location.X -= MoveRate;
                }
                if (destination.Y > location.Y)
                {
                    location.Y += MoveRate;
                }
                else if (destination.Y < location.Y)
                {
                    location.Y -= MoveRate;
                }
            }
            return false;
        }

        public void Go(Random random)
        {
            Age++;
            BeeState oldState = CurrentState;
            switch (CurrentState)
            {
                case BeeState.Idle:
                    if (Age > CareerSpan)
                    {
                        CurrentState = BeeState.Retired;
                    }
                    else if(world.Flowers.Count > 0 && hive.ConsumeHoney(HoneyConsumed))
                    {
                        Flower flower = world.Flowers[random.Next(world.Flowers.Count)];
                        if (flower.Nectar >= MinimumFlowerNectar && flower.Alive)
                        {
                            destinationFlower = flower;
                            CurrentState=BeeState.FlyingToFlower;
                        }
                        //Retired后是什么
                    }
                    break;
                case BeeState.FlyingToFlower:
                    if (!world.Flowers.Contains(destinationFlower))
                    {
                        CurrentState = BeeState.ReturningToHive;
                    }//没有有花粉的花了 回家
                    else if (InsideHive)
                    {
                        if (MoveTowardsLocation(hive.GetLocation("Exit")))
                        {
                            InsideHive = false;
                            location = hive.GetLocation("Entrance");
                        }
                    }
                    else
                    {
                        if (MoveTowardsLocation(destinationFlower.Location))
                        {
                            CurrentState=BeeState.GatheringNectar;
                        }//移动到花朵上采蜜
                    }
                    break;
                case BeeState.GatheringNectar:
                    double nectar = destinationFlower.HarvestNectar();
                    if (nectar > 0)
                    {
                        NectarCollected += nectar;
                    }
                    else
                    {
                        CurrentState = BeeState.ReturningToHive;
                    }
                    break;
                case BeeState.ReturningToHive:
                    if (!InsideHive)
                    {
                        if (MoveTowardsLocation(hive.GetLocation("Entrance")))
                        {
                            InsideHive = true;
                            location = hive.GetLocation("Exit");
                        }
                        //回家
                    }
                    else
                    {
                        if (MoveTowardsLocation(hive.GetLocation("HoneyFactory")))
                        {
                            CurrentState = BeeState.MakingHoney;
                        }
                        //回家干啥呢
                    }
                    break;
                case BeeState.MakingHoney:
                    if (NectarCollected < 0.5)
                    {
                        NectarCollected = 0;
                        CurrentState = BeeState.Idle;
                    }
                    else
                    {
                        if (hive.AddHoney(0.5))
                        {
                            NectarCollected -= 0.5;
                        }
                        else
                        {
                            NectarCollected = 0;
                        }
                        //制造蜂蜜
                    }
                    break;
                case BeeState.Retired:
                    //休息吧
                    break;
            }
            if (oldState != CurrentState && MessageSender != null)
            {
                MessageSender(ID, CurrentState.ToString());
            }
        }
    }
}
