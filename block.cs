using System.Drawing;

namespace funkyBubbles
{
    class Block : Entity //block inherits from entity
    {
        
        Pen outline; //outline for drawing a block
        public Block(int x, int y , int sizeX, int sizeY) : base(x, y, sizeX, sizeY)
        {
            outline= new Pen(Color.Black,sizeX/10);
            //setting block size
            this.sizeX = sizeX;
            this.sizeY = sizeY;
        }

        //kinds of block:
        //1. + life
        //2. + points

        public override void draw(Graphics g, int flag)
        {
           //drawing block
           g.FillRectangle(b, collision);
           g.DrawRectangle(outline, collision);
        }
    }
}

