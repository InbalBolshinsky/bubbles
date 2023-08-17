using System.Drawing;

namespace funkyBubbles
{
    class Block : Entity
    {
        Image image_block;
        Pen outline;
        public Block(float x, float y, int sizeX, int sizeY) : base(x, y, sizeX, sizeY)
        {
            outline= new Pen(Color.White,sizeX/5);
            this.sizeX = sizeX;
            this.sizeY = sizeY;

            this.collision = new RectangleF(x, y, sizeX, sizeY);
            //image_block = Image.FromFile("pics\\block_2.png");
            image_block = Image.FromFile("pics\\block_2.png");
        }

        //kinds of block:
        //1. + life
        //2. + points

        public override void draw(Graphics g, int flag)
        {

            //g.DrawImage(image_block, x, y, sizeX, sizeY);

           g.FillRectangle(b, collision);
            g.DrawRectangle(outline, collision);
        }
    }
}

