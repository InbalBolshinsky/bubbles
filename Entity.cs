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
        public float x, y;

        public int Dir = 0;
        public int lastDir = 1;
        public float radius;
        public RectangleF collision;

        public Brush b = new SolidBrush(Color.Yellow);

        public Entity(float x, float y, int size)
        {
            this.x = x;
            this.y = y;
            this.radius = size;
            this.collision = new RectangleF(x - size / 2, y - size / 2, size, size);

        }

        ////public void move(float speed)
        ////{
        ////    switch (Dir)
        ////    {
        ////        case 1:
        ////            x -= speed;
        ////            break;
        ////        case 2:
        ////            y -= speed;
        ////            break;
        ////        case 3:
        ////            x += speed;
        ////            break;
        ////        case 4:
        ////            y += speed;
        ////            break;
        ////    }

        ////    if (Dir != 0)
        ////        lastDir = Dir;
        ////}



        public void UpdateRec(int epsilon)
        {
            switch (Dir)
            {
                case 1:
                    collision.X = x - radius - epsilon;
                    collision.Y = y - radius;
                    break;
                case 2:
                    collision.X = x - radius;
                    collision.Y = y - radius - epsilon;
                    break;
                case 3:
                    collision.X = x - radius + epsilon;
                    collision.Y = y - radius;
                    break;
                case 4:
                    collision.X = x - radius;
                    collision.Y = y - radius + epsilon;
                    break;

                default:
                    collision.X = x - radius;
                    collision.Y = y - radius;
                    break;
            }
        }

        public abstract void draw(Graphics g);



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
