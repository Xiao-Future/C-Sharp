using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace house
{
    public partial class Form1 : Form
    {
        Location currentLocation;
        RoomWithDoor livingRoom;
        Room diningRoom;
        RoomWithDoor kitchen;
        OutsideWithDoor frontYard;
        OutsideWithDoor backYard;
        Outside garden;
        public Form1()
        {
            InitializeComponent();
            CreateObjects();
            MoveToANewLocation(livingRoom);
        }
        private void CreateObjects()
        {
            livingRoom = new RoomWithDoor("卧室", "古老的地毯", "黄铜色把手的橡木门");
            diningRoom = new Room("餐厅","一个水晶吊灯");
            kitchen = new RoomWithDoor("厨房", "不锈钢的厨具", "一个屏风门");
            frontYard = new OutsideWithDoor("前院", false, "黄铜色把手的橡木门");
            backYard = new OutsideWithDoor("后院", true, "一个屏风门");
            garden = new Outside("花园", false);

            frontYard.Exits = new Location[] { backYard ,garden};
            backYard.Exits = new Location[] { frontYard, garden };
            garden.Exits = new Location[] { frontYard, backYard };
            livingRoom.Exits = new Location[] { diningRoom };
            diningRoom.Exits = new Location[] { livingRoom, kitchen };
            kitchen.Exits = new Location[] { diningRoom };

            livingRoom.DoorLocation = frontYard;
            frontYard.DoorLocation = livingRoom;
            kitchen.DoorLocation = backYard;
            backYard.DoorLocation = kitchen;
        }//定义各个房间和院子的性质
        private void MoveToANewLocation(Location newLocation)
        {
            currentLocation = newLocation;
            exits.Items.Clear();
            for (int i = 0; i < currentLocation.Exits.Length; i++)
            {
                exits.Items.Add(currentLocation.Exits[i].Name);
            }
            exits.SelectedIndex = 0;
            description.Text = currentLocation.Description;
            if (currentLocation is IHasExteriorDoor)
            {
                goThroughTheDoor.Visible = true;
            }
            else
                goThroughTheDoor.Visible = false;
        }//Combox的定义

        private void Gohere_Click(object sender, EventArgs e)
        {
            MoveToANewLocation(currentLocation.Exits[exits.SelectedIndex]);
        }

        private void goThroughTheDoor_Click(object sender, EventArgs e)
        {
            IHasExteriorDoor hasDoor = currentLocation as IHasExteriorDoor;
            MoveToANewLocation(hasDoor.DoorLocation);
        }  
    }
}
