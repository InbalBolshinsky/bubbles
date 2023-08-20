using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace funkyBubbles
{
    class Lifeblock : Block //Lifeblock inherits from Block
    {
        Image image_block;


        public Lifeblock(int x, int y , int sizeX, int sizeY) : base(x, y, sizeX, sizeY)
        {
            // setting the size for Lifeblock
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