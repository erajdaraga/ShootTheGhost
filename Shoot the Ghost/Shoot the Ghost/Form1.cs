using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shoot_the_Ghost
{
    public partial class Form1 : Form
    {
        public Scene scene;
        public bool isPaused;
        public Form1()
        {
            scene = new Scene();
            InitializeComponent();
            isPaused = false;
            timer1.Interval = 70;
            timer1.Start();
            DoubleBuffered = true;
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            scene.ShootBullet(new Point(e.X, e.Y));
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
            scene.Update();
            
            if (scene.GameOver())
            {
                AskToPlayAgain();  
            }
            pointsToolStripStatusLabel.Text = "Points won: " + scene.Score;
            levelToolStripStatusLabel.Text = "Current level: " + scene.CurrentLevel;
            consecutiveToolStripStatusLabel.Text = "Consecutive: " + scene.ConsecutiveShots;
        }

        private void AskToPlayAgain()
        {
            timer1.Stop();
            DialogResult dialogResult = MessageBox.Show("You lost! Play again?", "Game over", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                scene = new Scene();
                timer1.Start();
            }
            else if (dialogResult == DialogResult.No)
            {
                this.Close();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P && isPaused == true)
            {
                isPaused = false;
                timer1.Enabled = true;
                lblGamePaused.Text = "";
            }
            else if (e.KeyCode == Keys.P && isPaused == false)
            {
                isPaused = true;
                timer1.Enabled = false;
                lblGamePaused.Text = "GAME PAUSED";
            }
        }
    }
}
