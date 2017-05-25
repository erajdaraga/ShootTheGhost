 using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoot_the_Ghost
{
    public class Scene
    {
        private List<Bullet> Bullets;
        private List<Ghost> Ghosts;
        public int ConsecutiveShots { get; private set; }
        public int CurrentLevel { get; private set; }
        public int Score { get; private set; }
        private Image[] Lives;
        private int AvailableLives;
        

        public Scene()
        {
            Bullets = new List<Bullet>(); Ghosts = new List<Ghost>();
            ConsecutiveShots = 0; Score = 0; CurrentLevel = 1;
            Lives = new Image[5]; Utility.Reset();
            SetScene();
        }        

        public void Update()
        {
            TickTock();
            for(int i=Bullets.Count-1; i>=0; i--)
            {
                Bullet bullet = Bullets[i];
                bullet.MoveBullet();
                bullet.Update();
                if (bullet.HasArrived())
                {
                    CheckShot(bullet);
                    Bullets.RemoveAt(i);
                    
                }
            }
        }

        public void Draw(Graphics g)
        {
            g.Clear(Color.Black);
            DrawLives(g);
            foreach(Ghost ghost in Ghosts)
            {
                if(ghost.Delay<=0)ghost.Draw(g);
            }
            foreach (Bullet bullet in Bullets) bullet.Draw(g);
        }

        public void ShootBullet(Point goal)
        {
            Bullet bullet = new Bullet();
            bullet.SetGoal(goal);
            Bullets.Add(bullet);
        }

        private void GhostAppears(Point position)
        {
            Random rand = new Random();
            int number = rand.Next(2) + 1;
            Ghost ghost = new Ghost("ghost" + number, position);
            Ghosts.Add(ghost);
        }

        public void TickTock()
        {
            for(int i=Ghosts.Count-1; i>=0; i--)
            {
                Ghost ghost = Ghosts[i];
                if(ghost.Delay>0)
                {
                    ghost.Delay --;
                }
                else
                {
                    ghost.Duration--;
                    if (!ghost.isStillHere())
                    {
                        if (!ghost.isDead)
                        {
                            AvailableLives--;
                            ConsecutiveShots = 0;
                            UpdateLives();
                        }
                        Ghosts.Add(new Ghost("ghost" + Utility.getRandomGhostType(), ghost.TopLeftPoint));
                        Ghosts.RemoveAt(i);                     
                    }
                    else if (ghost.Duration < 25) 
                    {
                        ghost.Transitioning();
                        if (ghost.Duration < 15) ghost.Disappearing();
                    }
                }
                
            }
        }

        public void SetScene()
        {
            AvailableLives = 5;
            UpdateLives();
            for(int i=1; i<=3; i++)
            {
                //AppearingQueue.Add(new AppearingGhosts(i));
                Ghosts.Add(new Ghost("ghost" + Utility.getRandomGhostType(), i));
            }
            
        }

        private void CheckShot(Bullet bullet)
        {
            int ghostsHit = 0;
            foreach (Ghost ghost in Ghosts)
            {
                if(ghost.Delay <= 0)
                {
                    if (ghost.isShot(bullet.CurrentPoint))
                        {
                            if (ghost.isStillHere())
                            {
                                ConsecutiveShots++;
                                ghostsHit++;
                                Score += CurrentLevel * 10;
                                CheckToLevelUp();
                            }
                            else ConsecutiveShots = 0;
                        }
                
                    }
                    if (ghostsHit == 0) ConsecutiveShots = 0;
                    //if (Ghosts.Count == 0) ConsecutiveShots = 0;
                }
                
        }


        private void CheckToLevelUp()
        {
            if (ConsecutiveShots == 10)
            {
                Utility.LevelUp();
                CurrentLevel++;
                if (AvailableLives < 5) AvailableLives++;
                ConsecutiveShots = 0;
                UpdateLives();
            }
        }

        private void UpdateLives()
        {
            for(int i=AvailableLives-1; i>=0; i--)
            {
                Lives[i] = Shoot_the_Ghost.Properties.Resources.life;
            }
            for(int i=0; i<5-AvailableLives; i++)
            {
                Lives[i] = Shoot_the_Ghost.Properties.Resources.lostlife;
            }
        }

        private void DrawLives(Graphics g)
        {
            int count = 590;
            for(int i=0; i<5; i++)
            {
                g.DrawImage(Lives[i], new Point(count, 10));
                count -= 35;
            }
        }

        public bool GameOver()
        {
            return AvailableLives == 0;
        }
    }
}
