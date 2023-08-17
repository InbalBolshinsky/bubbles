using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace funkyBubbles
{
    class Spaceship : Entity
    {
        Image sship;
       // Image misspac_rot;

        //Image misspac_c;
        //Image misspac_rot_c;

        Image[] deathFrames;

        public bool isClosed;
        int animInt;

        public Spaceship(int x, int y, int sizeX, int sizeY) : base(x, y, sizeX, sizeY)
        {
         
            b = new SolidBrush(Color.Yellow);

            sship = Image.FromFile("pics\\sship.png");
        }

        public override void draw(Graphics g, int flag)
        {
            g.DrawImage(sship, x, y, sizeX, sizeY);
        }


        ////public void deathAnim(int frame, Graphics g)
        ////{
           
        ////}


        ////public void Animate()
        ////{
        ////    if (Dir != 0)
        ////    {
        ////        animInt++;

        ////        if (animInt == 5)
        ////        {
        ////            isClosed = !(isClosed);
        ////            animInt = 0;
        ////        }
        ////    }

        ////}

        



    }
}

