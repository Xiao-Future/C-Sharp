using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace house
{
    public class Outside:Location
    {
        private bool hot;
        public bool Hot { get { return hot; } }
        public Outside(string name, bool hot)
            : base(name)
        {
            this.hot = hot;
        }
        public override string Description
        {
            get
            {
                string NewDescription = base.Description;
                if (hot)
                {
                    NewDescription += "这里很热";
                }
                return NewDescription;
            }
        }//覆盖Description属性
    }
    public class OutsideWithDoor : Outside,IHasExteriorDoor
    {
        private string doorDescription;
        public OutsideWithDoor(string name, bool hot, string doorDescription)
            : base(name, hot)
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
        public override string Description
        {
            get
            {
                return base.Description + "你可以看见" + doorDescription + ".";
            }
        }
    }
}
