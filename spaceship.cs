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

        public Spaceship(float x, float y, int size) : base(x, y, size)
        {
            this.radius = size;
            b = new SolidBrush(Color.Yellow);

            sship = Image.FromFile("pics\\sship.png");
            
            

            
        }

        public override void draw (Graphics g)
        {
            g.DrawImage(sship, x-75, y-50,150,100);
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

