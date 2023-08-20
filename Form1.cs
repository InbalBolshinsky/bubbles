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

        bool game_started; //did the game start

        List<Block> special_balls;// a list of special block that once added to the list become balls
        Ball ball; //ball
        int ball_start_Y; //ball start point y value
        Image ball_image; //ball image

        int lives = 3;//initializing players lives
        int score = 0;//initializing players score
        int point = 10;//points the player gets for hitting block

        int gone = 0; //how may block are gone
        bool win = false;//are ya winning son?

        bool dirX;//direction of each entity on x
        bool dirY;//direction of each entity on y

        int Vel;
        int VelY;

        Block[,] blocks; //an array of blocks on the screen
        Spaceship player; // player

        public Form1()
        {

            InitializeComponent();
            
            player = new Spaceship(Width / 2, Height - (Height / 8), Width / 12, Height / 12); //generating new spaceship
            
            special_balls = new List<Block>(); //creating new list for special blocks
            
            ball_image = Image.FromFile("pics\\ball.png"); //drawing ball
            
            ball_start_Y = Height - Height / 6; //setting balls starting point

            game_started = false;
            Random r = new Random(); //creating new random() object
            Random r_block = new Random();//generates coordinates of special blocks
        
            Vel = 4; 
            VelY = 4; 

            //generating new random coordinates for special blocks:
            int x = r.Next(Width / 4); 
            int y = r.Next(Height / 4); 

            int c_life = r_block.Next(0,COLS -1);
            int r_life = r_block.Next(0,ROWS -1);

            int c_X2 = r_block.Next(0,COLS -1);
            int r_X2 = r_block.Next(0,ROWS -1);

            //check if the random picked the same numbers
            if(c_X2 == c_life && r_X2 == r_life)
                c_X2 = r_block.Next(0, COLS - 1);

            ball = new Ball(Width / 2, ball_start_Y, Width / 50); //creating new ball and positioning it
            dirX = true;
            dirY = false;

            blocks = new Block[ROWS, COLS]; //creating new blocks array

            int diffx = Width / 12; //differense of space between two blocks
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
                    //drawing regular blocks
                    else
                    {
                        blocks[i, j] = new Block(Width / 6 + diffx * j, Height / 10 + diffy * i, Width / 12, Height / 12);
                    }
                }
            }
        }
        
        private void StopTimer() //stopping timer in case of loosing the game
        {       
           timer1.Stop();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //defining a collision for player and ball
            Rectangle ship = player.collision;
            Rectangle boobs = ball.collision;

            if (gone == (ROWS*COLS) || lives == 0 ) //if the player lost or won
            {
                if (gone < (ROWS*COLS))
                    win = false;
                else
                    win = true;

                //stopping timer and generating new endGame form
                StopTimer();
                EndGame end = new EndGame(score, win);
                Hide(); 
                end.ShowDialog();
                Close();
                
            }
           

            ScoreBox.Text = "Lives: " + lives + "  score:" + score; //printing text of current score and players lives

            if (ball.y + ball.collision.Height > Height) //if the ball hits below the ship
            {
                lives--;
                game_started = false;
                dirY = false;

                ball.x= Width / 2; //initializing the ball after death
                ball.y= ball_start_Y;
            }

            //if the ball hits the borders of the screen reverse its direction
            if (ball.y < 0)
                dirY = true;
            if (ball.x + ball.collision.Width > Width)
                dirX = false;
            if (ball.x < 0)
                dirX = true;

            ball.UpdateRec();

            if (game_started)
            {
                //changing ball mooving direction each time the player begins new round
                ball.x += (dirX) ? Vel : -Vel;
                ball.y += (dirY) ? VelY : -VelY;
            }

            if (boobs.IntersectsWith(ship))//if the ball hits the ship reverse its direction
            {
                dirY = false;
            }

            //if the ball hits a block:

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

                            if (blocks[i, j] is Lifeblock ) //if the block is a Lifeblock, give an upgrade
                            {
                                Lifeblock tmp = (Lifeblock)blocks[i, j]; 
                                tmp.upgrade();
                                special_balls.Add(tmp); //add to list
                                gone++; //count block as gone
                            }
                            else if(blocks[i, j] is X2Block) //if the block is a X2Block, give an upgrade
                            {
                                X2Block tmp = (X2Block)blocks[i, j];
                                tmp.upgrade();
                                special_balls.Add(tmp); //add to list
                                gone++; //count block as gone
                            }
                            else
                            {
                                //if its a regular block, dont draw it
                                blocks[i, j] = null;
                                score += point; // add points to score
                                gone++; //count block as gone
                            }


                        }
                    }
                }



            }

            for (int i = 0; i < special_balls.Count; i++) //for each special block added to the list:
            {                  

                if (special_balls[i] != null)
                {
                    special_balls[i].y += 5; //moves the upgrade down
                    special_balls[i].UpdateRec(); //updates ball(special block) size

                    if (special_balls[i].collision.IntersectsWith(player.collision)) //if the plyer catches the upgrade
                    {
                        if (special_balls[i] is Lifeblock) //for Lifeblock add lives
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
                        else if (special_balls[i] is X2Block) //for X2Block double the points added
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

        private void pictureBox1_Paint(object sender, PaintEventArgs e) //drawing the spaceship of player
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
                        blocks[i, j].draw(e.Graphics, 0); //drawing the blocks the player didnt hit
                }
            }
    
            ball.draw(e.Graphics, 0); //drawing the ball
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) //hadlers the mouse move according to moving the spaceship
        {
            player.x = e.X;
            player.UpdateRec();

        }

        private void pictureBox1_Click(object sender, EventArgs e) //if game started once
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
