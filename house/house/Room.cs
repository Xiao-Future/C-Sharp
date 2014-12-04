using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace house
{
    public class Room:Location
    {
        private string decoration;
        public Room(string name, string decoration)
            : base(name)
        {
            this.decoration = decoration;
        }
        public override string Description
        {
            get
            {
                return base.Description + "你可以看见" + decoration + ".";
            }
        }//覆盖Description属性
    }
    public class RoomWithDoor : Room,IHasExteriorDoor
    {
        private string doorDescription;
        public RoomWithDoor(string name, string decoration, string doorDescription)
            : base(name, decoration)
        {
            this.doorDescription = doorDescription;
        }
        #region IHasExteriorDoor 成员

        public string DoorDescription
        {
            get { return doorDescription; }
        }
        private Location doorLocation;
        public Location DoorLocation
        {
            get
            {
                return doorLocation;
            }
            set
            {
                doorLocation = value;
            }
        }

        #endregion
    }
}
