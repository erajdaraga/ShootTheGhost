using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoot_the_Ghost
{
    class Bullet
    {
        public int Speed { private get; set; } //aka the Y coordinate for how the bullet approaches
        private Point GoalPoint {  get;  set; }
        public Point CurrentPoint { get; set; }
        public Point NextPoint { get; set; }
        public Point StartPoint { get; set; }

        public Bullet()
        {
            CurrentPoint = GoalPoint = StartPoint = new Point(325, 520); //bottom center of the window
            SetSpeed(40);
        }

        public void MoveBullet()
        {
            //calculating the next point
            //this works bcs the bullet is always moving up with respect to (x,y)
            //its not working when fully horizontal

            int newYCoord=0, newXCoord=0;
            if (HasArrived()) return;

            else if(CurrentPoint.X == GoalPoint.X) //if point is horizontal to goal
            {
                newXCoord = CurrentPoint.X;
                newYCoord = CalculateY();
            }
            else if(CurrentPoint.Y == GoalPoint.Y) //if point is vertical to goal
            {
                newYCoord = CurrentPoint.Y;
                newXCoord = CalculateX();
            }
            else //if it's not horizontal or vertical to goal
            {
                newYCoord = CalculateY();
                double slope = CalculateSlope();
                newXCoord = CalculateX(slope, CalculateB(slope), newYCoord);
            }
            
            NextPoint = new Point(newXCoord, newYCoord);
        }

        public void Update()
        {
            if (goalHasBeenSet())
            {
                CurrentPoint = NextPoint;
            }
        }

        public bool HasArrived()
        {
            if (CurrentPoint.X == GoalPoint.X && CurrentPoint.Y == GoalPoint.Y && goalHasBeenSet()) return true;
            return false;
        }

        public void Draw(Graphics g)
        {
            Pen p = new Pen(Color.Aquamarine, 10);
            Pen initial = new Pen(Color.DarkGray, 7);
            Pen moving = new Pen(Color.LightGray, 5);
            //g.DrawEllipse(initial, GoalPoint.X, GoalPoint.Y, 5, 5);
            
            g.DrawEllipse(initial, CurrentPoint.X, CurrentPoint.Y, 7, 6);
            g.DrawEllipse(moving, CurrentPoint.X, CurrentPoint.Y, 2, 2);
            p.Dispose(); initial.Dispose();
            moving.Dispose();
            //g.DrawLine(p, StartPoint, GoalPoint);
        }

        private int CalculateY()
        {
            if (Math.Abs(CurrentPoint.Y - GoalPoint.Y) <= Speed)
            {
                return GoalPoint.Y;
            }
            else
            {
                if (CurrentPoint.Y - GoalPoint.Y < 0)
                {
                    return CurrentPoint.Y + Speed;
                }
                else if (CurrentPoint.Y - GoalPoint.Y > Speed)
                {
                    return CurrentPoint.Y - Speed;
                }
            }
            return 0;
        }

        private int CalculateX()
        {
            if (Math.Abs(CurrentPoint.X - GoalPoint.X) <= Speed)
            {
                return GoalPoint.X;
            }
            else
            {
                if (CurrentPoint.X - GoalPoint.X < 0)
                {
                    return CurrentPoint.X + Speed;
                }
                else if (CurrentPoint.X - GoalPoint.X > Speed)
                {
                    return CurrentPoint.X - Speed;
                }
            }
            return 0;
        }

        private int CalculateX(double slope, double b, int newYCoord)
        {
            
            return (int)((newYCoord - b) * 1.0 / slope);
        }

        private double CalculateSlope()
        {
            return (CurrentPoint.Y - GoalPoint.Y) * 1.0 / (CurrentPoint.X - GoalPoint.X);
        }

        private double CalculateB(double slope)
        {
            return GoalPoint.Y - slope * GoalPoint.X;
        }

        private void SetSpeed(int speed)
        {
            Speed = speed;
        }

        public void SetGoal(Point point)
        {
            GoalPoint = point;
        }

        public bool goalHasBeenSet()
        {
            return GoalPoint != StartPoint;
        }
    }
}
