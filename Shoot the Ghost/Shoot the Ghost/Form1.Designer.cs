namespace Shoot_the_Ghost
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pointsToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.levelToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.consecutiveToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblGamePaused = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pointsToolStripStatusLabel,
            this.levelToolStripStatusLabel,
            this.consecutiveToolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 459);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(634, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip";
            // 
            // pointsToolStripStatusLabel
            // 
            this.pointsToolStripStatusLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pointsToolStripStatusLabel.Name = "pointsToolStripStatusLabel";
            this.pointsToolStripStatusLabel.Size = new System.Drawing.Size(78, 17);
            this.pointsToolStripStatusLabel.Text = "Points won: 0";
            // 
            // levelToolStripStatusLabel
            // 
            this.levelToolStripStatusLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.levelToolStripStatusLabel.Name = "levelToolStripStatusLabel";
            this.levelToolStripStatusLabel.Size = new System.Drawing.Size(86, 17);
            this.levelToolStripStatusLabel.Text = "Current level: 1";
            // 
            // consecutiveToolStripStatusLabel
            // 
            this.consecutiveToolStripStatusLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.consecutiveToolStripStatusLabel.Name = "consecutiveToolStripStatusLabel";
            this.consecutiveToolStripStatusLabel.Size = new System.Drawing.Size(115, 17);
            this.consecutiveToolStripStatusLabel.Text = "Consecutive shots: 0";
            // 
            // lblGamePaused
            // 
            this.lblGamePaused.AutoSize = true;
            this.lblGamePaused.BackColor = System.Drawing.Color.Black;
            this.lblGamePaused.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGamePaused.ForeColor = System.Drawing.Color.Red;
            this.lblGamePaused.Location = new System.Drawing.Point(12, 9);
            this.lblGamePaused.Name = "lblGamePaused";
            this.lblGamePaused.Size = new System.Drawing.Size(0, 19);
            this.lblGamePaused.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(634, 481);
            this.Controls.Add(this.lblGamePaused);
            this.Controls.Add(this.statusStrip1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(650, 520);
            this.MinimumSize = new System.Drawing.Size(650, 520);
            this.Name = "Form1";
            this.Text = "Shoot the Ghost";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel pointsToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel levelToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel consecutiveToolStripStatusLabel;
        private System.Windows.Forms.Label lblGamePaused;
    }
}

