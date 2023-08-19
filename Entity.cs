using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace funkyBubbles
{
    public abstract class Entity
    {
        public int x, y;

        public int Dir = 0;
        public int lastDir = 1;
        public int sizeX,sizeY;
        public Rectangle collision;

        public Brush b = new SolidBrush(Color.Blue);

        public Entity(int x, int y, int sizeX,int sizeY)
        {
            this.x = x;
            this.y = y;

            this.sizeX = sizeX;
            this.sizeY = sizeY; 

            this.collision = new Rectangle(x, y, sizeX, sizeY);

        }



        public void UpdateRec()
        {
            collision.X = x;
            collision.Y = y;

            collision.Width = sizeX;
            collision.Height = sizeY;


        }

        public abstract void draw(Graphics g, int flag);



        ////draws the collisions
        ////public void DRAWCOL(Graphics g)
        ////{
        ////    g.FillRectangle(b, collision);
        ////}

        //////sets the size of the drawing and collision
        ////public void setSize(float nR)
        ////{
        ////    radius = nR;
        ////    collision.Width = collision.Height = radius * 2;
        ////}
    }
}
