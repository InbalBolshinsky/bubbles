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
        List<Block> balls;//רשימה מקושרת
        int offset = 20;
        int outball = 0;
        Ball ball;
        Image ball_image;

        int lives = 4;
        int score = 0;
        int point = 10;
        int gone = 0;

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

        int life_i = 0;
        int life_j = 0;

        public Form1()
        {

            InitializeComponent();
            player = new Spaceship(Width / 2, Height - (Height / 8), Width / 12, Height / 12);
            balls = new List<Block>();
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
                    else if (i == 3 && j == 7)
                    {
                        blocks[3, 7] = new X2Block(Width / 6 + diffx * j, Height / 10 + diffy * i, Width / 12, Height / 12);
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
            //timer1_Tick(sender, e);

            dirX = !dirX;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

           

            ScoreBox.Text = "Lives: " + lives + "  score:" + score;

            if (ball.y + ball.collision.Height > Height)
            {
                lives--;
                ball.x= Width / 2;//מאתחל כדור אחרי המוות
                ball.y= Height /2;
            }
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
            RectangleF ball_1 = ball.collision;
            


            if (ball_1.IntersectsWith(ship))
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
                        RectangleF block = blocks[i, j].collision;


                        if (ball_1.IntersectsWith(block))
                        {

                            if (ball_1.Left < block.Left)
                                dirX = false;
                            else
                                dirX = true;

                            if (ball_1.Top > block.Bottom)
                                dirY = true;
                            else
                                dirY = false;

                            if (blocks[i, j] is Lifeblock )
                            {
                                Lifeblock tmp = (Lifeblock)blocks[i, j];
                                tmp.upgrade();
                                balls.Add(tmp);
                                gone++;
                            }
                            else if(blocks[i, j] is X2Block)
                            {
                                X2Block tmp = (X2Block)blocks[i, j];
                                tmp.upgrade();
                                balls.Add(tmp);
                                gone++;
                            }
                            else
                            {
                                blocks[i, j] = null;
                                score += point;
                                gone++;
                            }


                        }
                    }
                }



            }
            for (int i = 0; i < balls.Count; i++)
            {                  

                if (balls[i] != null)
                {
                    balls[i].y += 5;//מוריד את האפגרייד
                    balls[i].UpdateRec();
                    if (balls[i].collision.IntersectsWith(player.collision))
                    {
                        if (balls[i] is Lifeblock)
                        {
                            lives++;
                            for (int a = 0; a < 4; a++)
                            {
                                for (int b = 0; b < 8; b++)
                                {
                                    if(blocks[a,b] == balls[i])
                                        blocks[a, b] = null;
                                }
                            }
                            balls[i] = null;
                        }
                        else if (balls[i] is X2Block)
                        {
                            point = 20;
                            for (int a = 0; a < 4; a++)
                            {
                                for (int b = 0; b < 8; b++)
                                {
                                    if (blocks[a, b] == balls[i])
                                        blocks[a, b] = null;
                                }
                            }
                            balls[i] = null;


                        }
                    }
                }
            }

            if(gone == 32 || lives == 0 || ball_1.Bottom == ship.Top)
            {
                //הפסד
            }

            pictureBox1.Invalidate();

            
        }




        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;

            player.draw(e.Graphics, 0);
            ball.draw(e.Graphics, 0);

            int i = 0;
            int j;
            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 8; j++)
                {
                    if (blocks[i, j] != null)
                        blocks[i, j].draw(e.Graphics, 0);
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
            dirX = !dirX;
        }

        private void ScoreBox_TextChanged(object sender, EventArgs e)
        {
            
        }







        //void WIN()
        //{
        //    timer1.Stop();
        //    MessageBox.Show("YOU WON\nPress the button to contionue to the nest level", "YOU WIN ", MessageBoxButtons.OK);
        //    Form1 f = new Form1();
        //    Hide();
        //    f.ShowDialog();
        //    Close();
        //}
    }
}
