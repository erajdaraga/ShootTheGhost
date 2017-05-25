using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoot_the_Ghost
{
    class Ghost
    {
        public float Duration { get; set; }
        public float Delay { get; set; }
        public Point TopLeftPoint { get; set; }
        private Rectangle rectangle { get; set; }
        private Image image { get; set; }
        private string imageName { get; set; }
        public bool isDead { get; set; }

        public Ghost(String ghostType, Point point)
        {
            if(ghostType=="ghost1") image = Shoot_the_Ghost.Properties.Resources.ghost1;
            else image = Shoot_the_Ghost.Properties.Resources.ghost2;            
            imageName = ghostType; TopLeftPoint = point;
            setDelay(); setDuration();
        }

        public Ghost(String ghostType, int position)
        {
            if (ghostType == "ghost1") image = Shoot_the_Ghost.Properties.Resources.ghost1;
            else image = Shoot_the_Ghost.Properties.Resources.ghost2;
            imageName = ghostType;
            if (position == 1)
            {
                TopLeftPoint = new Point(100, 300);
            }
            else if (position == 2)
            {
                TopLeftPoint = new Point(234, 55);
            }
            else if (position == 3)
            {
                TopLeftPoint = new Point(400, 240);
            }
            setDelay(); setDuration();
        }

        public void setDelay()
        {
            Delay = Utility.GetRandomGhostAppearing();
        }

        public void setDuration()
        {
            Duration = Utility.GetRandomGhostDuration();
        }

        public bool isShot(Point point)
        {
            Size size = new Size(image.Width, image.Height);
            Rectangle rectangle = new Rectangle(TopLeftPoint, size);
            isDead = rectangle.Contains(point);
            if (isDead) Dead();
            return rectangle.Contains(point);
        }

        public bool isStillHere()
        {
            return Duration > 0;
        }

        public void Draw(Graphics g)
        {
            Size size = new Size(image.Width, image.Height);
            g.DrawImage(image, TopLeftPoint);  
            Rectangle rectangle = new Rectangle(TopLeftPoint, size);
            Pen pen = new Pen(Color.Black, 1);
            g.DrawRectangle(pen, rectangle);        
            pen.Dispose();
            
        }

        public void Transitioning()
        {
            if (!isDead)
            {
                if(imageName == "ghost1") image = Shoot_the_Ghost.Properties.Resources.transitionghost1;
                else image = Shoot_the_Ghost.Properties.Resources.transitionghost2;
            }
            else
            {
                if (imageName == "ghost1") image = Shoot_the_Ghost.Properties.Resources.transitiondeadghost1;
                else image = Shoot_the_Ghost.Properties.Resources.transitiondeadghost2;
            }
            
        }

        public void Disappearing()
        {
            if (!isDead)
            {
                if(imageName=="ghost1") image = Shoot_the_Ghost.Properties.Resources.disappearingghost1;
                else image = Shoot_the_Ghost.Properties.Resources.disappearingghost2;
            }
        }

        private void Dead()
        {
            Duration = 5;
            if (imageName == "ghost1") image = Shoot_the_Ghost.Properties.Resources.deadghost1;
            else image = Shoot_the_Ghost.Properties.Resources.deadghost2;
        }
    }
}
