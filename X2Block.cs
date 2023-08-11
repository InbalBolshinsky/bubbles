using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace funkyBubbles
{
    class X2Block : Block
    {
        Image image_X2;


        public X2Block(float x, float y, int sizeX, int sizeY) : base(x, y, sizeX, sizeY)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;

            this.collision = new RectangleF(x, y, sizeX, sizeY);
            image_X2 = Image.FromFile("pics\\redHeart.jpg");

        }

        public void upgrade()
        {
         
            sizeX = 7;
            sizeY = 7;
            UpdateRec();
        }



    }
}
