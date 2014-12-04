using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace house
{
    public abstract class Location//基类
    {
        private string name;
        public Location(string name)
        {
            this.name = name;
        }
        public string Name
        {
            get { return name; }
        }
        public Location[] Exits;
        public virtual string Description//描述房间属性
        {
            get 
            {
                string description = "你现在处于 " + name + " 在这里你可以通过出口到达";
                for (int i = 0; i < Exits.Length; i++)
                {
                    description += "" + Exits[i].Name;
                    if (i!=Exits.Length-1)
                    {
                        description += ",";
                    }
                }
                description += ".";
                return description;
            }
        }
    }
    public interface IHasExteriorDoor//建立接口
    {
        string DoorDescription{get;}
        Location DoorLocation { get; set; }
    }
}
