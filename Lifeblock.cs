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
        Image image_block;


        public Lifeblock(int x, int y , int sizeX, int sizeY) : base(x, y, sizeX, sizeY)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;

            image_block = Image.FromFile("pics\\block_2.png");


        }


        //public override void draw(Graphics g, int flag)
        //{

        //    g.DrawImage(image_block, x, y, sizeX, sizeY);

        //    //g.FillRectangle(b, collision);
        //}

        public void upgrade()
        { 

            sizeX = 15;
            sizeY = 15;

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