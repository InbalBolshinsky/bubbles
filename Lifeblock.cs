using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace funkyBubbles
{
    class Lifeblock : Block
    {
        Image number1;
        

        public Lifeblock(float x, float y, int sizeX, int sizeY) : base(x, y, sizeX, sizeY)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;

            this.collision = new RectangleF(x, y, sizeX, sizeY);
            number1 = Image.FromFile("pics\\block_2.png");


        }

        public void upgrade()
        {
            number1= Image.FromFile("pics\\ball.png");

            sizeX = 7;
            sizeY = 7;
            UpdateRec();
            //while (1)
            //{
            //    y += 5;
            //}
            //valY = 4;
            ////bool dirX;//direction of each entity on x
            ////bool dirY;//direction of each entity on y
            //dirY = true;
            ////int Vel;
            ////int VelY;
            ////Vel = 4; 
            ////VelY = 4;





        }
    
    }



















}