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
        //constants:
        const int ROWS = 4;
        const int COLS = 8;

        bool game_started;

        List<Block> special_balls;// רשימה מקושרת של בלוקים מיוחדים שהופכים לכדורים ויורדים למטה
        Ball ball;
        int ball_start_Y;
        Image ball_image;

        int lives = 3;//initializing players lives
        int score = 0;//initializing players score
        int point = 10;//points the player gets for hitting block

        int gone = 0; //how may block are gone
        bool win = false;//are ya winning son?

        bool dirX;//direction of each entity on x
        bool dirY;//direction of each entity on y

        int Vel;
        int VelY;

        Block[,] blocks;
        Spaceship player;

        public Form1()
        {

            InitializeComponent();
            player = new Spaceship(Width / 2, Height - (Height / 8), Width / 12, Height / 12);
            special_balls = new List<Block>();
            ball_image = Image.FromFile("pics\\ball.png");
            ball_start_Y = Height - Height / 6;

            game_started = false;
            Random r = new Random();
            Random r_block = new Random();//generates coordinates of special blocks
        
            Vel = 4; 
            VelY = 4; 

            int x = r.Next(Width / 4);
            int y = r.Next(Height / 4); 

            int c_life = r_block.Next(0,COLS -1);
            int r_life = r_block.Next(0,ROWS -1);

            int c_X2 = r_block.Next(0,COLS -1);
            int r_X2 = r_block.Next(0,ROWS -1);

            //check if the random picked the same numbers
            if(c_X2 == c_life && r_X2 == r_life)
                c_X2 = r_block.Next(0, COLS - 1);

            ball = new Ball(Width / 2, ball_start_Y, Width / 50);
            dirX = true;
            dirY = false;

            blocks = new Block[ROWS, COLS];

            int diffx = Width / 12;
            int diffy = Height / 12;
            int i;
            int j;

            for (i = 0; i < ROWS; i++)
            {
                for (j = 0; j < COLS; j++)
                {
                    //drawing random special blocks
                    if (i == r_life && j == c_life)
                    {
                        blocks[r_life,c_life] = new Lifeblock(Width / 6 + diffx * c_life, Height / 10 + diffy * r_life, Width / 12, Height / 12);
                    }
                    else if (i == r_X2 && j == c_X2)
                    {
                        blocks[r_X2, c_X2] = new X2Block(Width / 6 + diffx * c_X2, Height / 10 + diffy * r_X2, Width / 12, Height / 12);
                    }

                    else
                    {

                        blocks[i, j] = new Block(Width / 6 + diffx * j, Height / 10 + diffy * i, Width / 12, Height / 12);
                    }
                }
            }
        }
        
        private void StopTimer()
        {
           timer1.Stop();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            Rectangle ship = player.collision;
            Rectangle boobs = ball.collision;

            if (gone == (ROWS*COLS) || lives == 0 )
            {
                if (gone < (ROWS*COLS))
                    win = false;
                else
                    win = true;

                StopTimer();
                EndGame end = new EndGame(score, win);
                Hide(); 
                end.ShowDialog();
                Close();
                
            }
           

            ScoreBox.Text = "Lives: " + lives + "  score:" + score;

            if (ball.y + ball.collision.Height > Height)
            {
                lives--;
                game_started = false;
                dirY = false;

                ball.x= Width / 2; //מאתחל כדור אחרי המוות
                ball.y= ball_start_Y;
            }


            if (ball.y < 0)
                dirY = true;
            if (ball.x + ball.collision.Width > Width)
                dirX = false;
            if (ball.x < 0)
                dirX = true;

            ball.UpdateRec();

            if (game_started)
            {
                ball.x += (dirX) ? Vel : -Vel;
                ball.y += (dirY) ? VelY : -VelY;
            }

            if (boobs.IntersectsWith(ship))
            {
                dirY = false;
            }

            //with block

            for (int i = 0; i < ROWS; i++)
            {

                for (int j = 0; j < COLS; j++)
                {
                    if (blocks[i, j] != null)
                    {
                        Rectangle block = blocks[i, j].collision;


                        if (boobs.IntersectsWith(block))
                        {

                            if (boobs.Right > block.Left)//ball hits from left
                                dirX = false;

                            if (boobs.Left < block.Right)//ball hits from right
                                dirX = true;

                            if (boobs.Top < block.Bottom)//ball hits from below
                                dirY = false;

                            if (boobs.Bottom > block.Top)//ball hits from above
                                dirY = true;

                            if (blocks[i, j] is Lifeblock )
                            {
                                Lifeblock tmp = (Lifeblock)blocks[i, j];
                                tmp.upgrade();
                                special_balls.Add(tmp);
                                gone++;
                            }
                            else if(blocks[i, j] is X2Block)
                            {
                                X2Block tmp = (X2Block)blocks[i, j];
                                tmp.upgrade();
                                special_balls.Add(tmp);
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

            for (int i = 0; i < special_balls.Count; i++)
            {                  

                if (special_balls[i] != null)
                {
                    special_balls[i].y += 5;//מוריד את האפגרייד
                    special_balls[i].UpdateRec();
                    if (special_balls[i].collision.IntersectsWith(player.collision))
                    {
                        if (special_balls[i] is Lifeblock)
                        {
                            lives++;
                            for (int a = 0; a < ROWS; a++)
                            {
                                for (int b = 0; b < COLS; b++)
                                {
                                    if(blocks[a,b] == special_balls[i])
                                        blocks[a, b] = null;
                                }
                            }
                            special_balls[i] = null;
                        }
                        else if (special_balls[i] is X2Block)
                        {
                            point = 20;
                            for (int a = 0; a < ROWS; a++)
                            {
                                for (int b = 0; b < COLS; b++)
                                {
                                    if (blocks[a, b] == special_balls[i])
                                        blocks[a, b] = null;
                                }
                            }
                            special_balls[i] = null;


                        }
                    }
                }
            }

            pictureBox1.Invalidate();

            
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;

            player.draw(e.Graphics, 0);

            int i = 0;
            int j;
            for (i = 0; i < ROWS; i++)
            {
                for (j = 0; j < COLS; j++)
                {
                    if (blocks[i, j] != null)
                        blocks[i, j].draw(e.Graphics, 0);
                }
            }
    
            ball.draw(e.Graphics, 0);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            player.x = e.X;
            player.UpdateRec();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            game_started = true;
        }

        private void ScoreBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void start_request_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
