using System.Drawing;

namespace funkyBubbles
{
    class Block : Entity
    {
        Image number1;
        public Block(float x, float y, int sizeX, int sizeY) : base(x, y, sizeX, sizeY)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;

            this.collision = new RectangleF(x, y, sizeX, sizeY);
            number1 = Image.FromFile("pics\\block_2.png");
        }

        //kinds of block:
        //1. + life
        //2. + points

        public override void draw(Graphics g)
        {

            g.DrawImage(number1, x, y, sizeX, sizeY);
            //g.FillRectangle(b, collision);
        }

        
        
    }
}

