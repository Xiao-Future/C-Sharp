using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FuckSusliks
{
    class Mole
    {
        public delegate void PopUp(int hole, bool show);
        private PopUp popUpCallback;
        private bool hidden;
        public bool Hidden { get { return hidden; } }
        private int timesHit = 0;
        private int timesShown = 0;
        private int hole = 0;
        Random random;
        public Mole(Random random, PopUp popUpCallback)
        {
            if (popUpCallback == null)
            {
                throw new ArgumentException("popUpCallback can't be null");
            }
            this.random = random;
            this.popUpCallback = popUpCallback;
            hidden = true;
        }
        public void show()
        {
            timesShown++;
            hidden = false;
            hole = random.Next(5);
            popUpCallback(hole, true);
        }
        public void HideAgain(int numberOfSusliks)
        {
            hidden = true;
            popUpCallback(hole, false);
            CheckForOver(numberOfSusliks);
        }

        public void Smacked(int holeSmacked, int numberOfSusliks)
        {
            //if (holeSmacked == hole)
            if (hole == holeSmacked)
            {
                timesHit++;
                hidden = true;
                CheckForOver(numberOfSusliks);
                popUpCallback(hole, false);
            }
        }
        public void WrongSmacked(int holeSmacked, int numberOfSusliks)
        {
            //if (holeSmacked == hole)
            if (hole == holeSmacked)
            {
               // MessageBox.Show("heh");
                timesHit--;
                hidden = true;
                CheckForOver(numberOfSusliks);
                popUpCallback(hole, false);
            }
        }
        private void CheckForOver(int numberOfSusliks)
        {
            if (timesShown >= numberOfSusliks)
            {
                popUpCallback(-1, false);
                MessageBox.Show("You scored " + timesHit, " Game,over!");
                Application.Exit();
            }
        }
    }
}
