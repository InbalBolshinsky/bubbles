using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace funkyBubbles
{
    public partial class Form1 : Form
    {
        int offset = 20;
        int outball = 0;
        Ball ball;
        Image ball_image;

        int lives = 3;

        bool dirX;//direction of each entity on x
        bool dirY;//direction of each entity on y

        int sizeMult = 15;
        int Vel;
        int VelY;

        Block[,] blocks;
        Rectangle spaceship;
        Rectangle block;
        Graphics g;
        Spaceship player;

        public Form1()
        {

            InitializeComponent();
            player = new Spaceship(Width / 2, Height - (Height / 8), Width / 12, Height / 12);

            ball_image = Image.FromFile("pics\\ball.png");

            Random r = new Random();
            Vel = 4; //r.Next(5) + 2;
            VelY = 4; // r.Next(5) + 2;


            int x = r.Next(Width / 4);
            int y = r.Next(Height / 4);

            ball = new Ball(Width / 2, Height, Width / 30);
            dirX = true;
            dirY = false;

            blocks = new Block[4, 8];

            int diffx = Width / 12;
            int diffy = Height / 12;
            int i;
            int j;


            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 8; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        blocks[0, 0] = new Lifeblock(Width / 6 + diffx * j, Height / 10 + diffy * i, Width / 12, Height / 12);
                    }
                    else
                    {

                        blocks[i, j] = new Block(Width / 6 + diffx * j, Height / 10 + diffy * i, Width / 12, Height / 12);
                    }
                }
            }
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            ScoreBox.Text = "Lives: " + lives;

            if (ball.y + ball.collision.Height > Height)
                dirY = false;
            if (ball.y < 0)
                dirY = true;
            if (ball.x + ball.collision.Width > Width)
                dirX = false;
            if (ball.x < 0)
                dirX = true;

            ball.UpdateRec();

            ball.x += (dirX) ? Vel : -Vel;
            ball.y += (dirY) ? VelY : -VelY;


            RectangleF ship = player.collision;
            RectangleF boob = ball.collision;

            if (boob.IntersectsWith(ship))
            {
                dirY = false;
            }

            //with block

            for (int i = 0; i < 4; i++)
            {

                for (int j = 0; j < 8; j++)
                {
                    if (blocks[i, j] != null)
                    {
                        RectangleF brocoly = blocks[i, j].collision;


                        if (boob.IntersectsWith(brocoly))
                        {

                            if (boob.Left < brocoly.Left)
                                dirX = false;
                            else
                                dirX = true;

                            if (boob.Top > brocoly.Bottom)
                                dirY = true;
                            else
                                dirY = false;

                            if (blocks[i, j] is Lifeblock)
                            {
                                Lifeblock tmp = (Lifeblock)blocks[i, j];
                                tmp.upgrade();
                            }
                            else
                            {
                                blocks[i, j] = null;
                            }


                        }
                    }
                }




                pictureBox1.Invalidate();
            }
        }






            private void Form1_Load(object sender, EventArgs e)
            {

            }

            private void pictureBox1_Paint(object sender, PaintEventArgs e)
            {
                //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;

                player.draw(e.Graphics);
                ball.draw(e.Graphics);

                int i = 0;
                int j;
                for (i = 0; i < 4; i++)
                {
                    for (j = 0; j < 8; j++)
                    {
                        if (blocks[i, j] != null)
                            blocks[i, j].draw(e.Graphics);
                    }
                }
            }

            private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
            {

            }

            private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
            {
                player.x = e.X;
                player.y = e.Y;
                player.UpdateRec();
            }

            private void pictureBox1_Click(object sender, EventArgs e)
            {

            }
        }
}
