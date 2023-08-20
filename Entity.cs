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
        public int x, y;//place of entity

        public int Dir = 0;//direction of entity
        public int lastDir = 1;//direction change for entity
        public int sizeX,sizeY;//size of entity
        public Rectangle collision; //collision of entity

        public Brush b = new SolidBrush(Color.Blue);

        public Entity(int x, int y, int sizeX,int sizeY)
        {
            //setting entitys place
            this.x = x;
            this.y = y;

            //setting entitys size
            this.sizeX = sizeX;
            this.sizeY = sizeY; 

            this.collision = new Rectangle(x, y, sizeX, sizeY); //setting collision for entity

        }



        public void UpdateRec()
        {
            //setting and updating entitys size
            collision.X = x;
            collision.Y = y;

            collision.Width = sizeX;
            collision.Height = sizeY;


        }

        //drawing entity
        public abstract void draw(Graphics g, int flag);

    }
}
