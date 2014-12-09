using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseBall
{
    public class Fan
    {
        public Fan(Ball ball)
        {
            ball.BallInPlay += new EventHandler(ball_BallInPlay);
        }

        void ball_BallInPlay(object sender, EventArgs e)
        {
            if (e is BallEventArgs)
            {
                BallEventArgs ballEventArgs = e as BallEventArgs;
                if ((ballEventArgs.Distance > 400) && (ballEventArgs.Trajectory > 30))
                {
                    HomeRun();
                }
                else
                {
                    WooHoo();
                }
            }
        }

        private void HomeRun()
        {
            Console.WriteLine("Fun:Home run! I'm going for the ball");
        }

        private void WooHoo()
        {
            Console.WriteLine("Fun:Woo-hoo! Yeah!");
        }
    }
}
