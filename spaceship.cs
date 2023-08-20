using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace funkyBubbles
{
    class Spaceship : Entity //spaceship class inherits from entity
    {
        Image sship;
        public Spaceship(int x, int y, int sizeX, int sizeY) : base(x, y, sizeX, sizeY)
        { 
         
            b = new SolidBrush(Color.Yellow);//darwing ship

            sship = Image.FromFile("pics\\sship.png");//getting the image file for ship
        }

        public override void draw(Graphics g, int flag)
        {
            g.DrawImage(sship, x, y, sizeX, sizeY);//drawing the ship
        }

    }
}

