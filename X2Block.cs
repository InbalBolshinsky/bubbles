using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace funkyBubbles
{
    class X2Block : Block //X2Block inherits from Block
    {
        Image image_block;


        public X2Block(int x, int y , int sizeX, int sizeY) : base(x, y, sizeX, sizeY)
        {
            // setting the size for X2Block
            this.sizeX = sizeX;
            this.sizeY = sizeY;

            image_block = Image.FromFile("pics\\block_2.png");// getting image file to draw block

        }

        public void upgrade()
        {
            //updating special block size when the ball hits it
            sizeX = 15;
            sizeY = 15;
            UpdateRec();
        }



    }
}
