using System.Drawing;

namespace funkyBubbles
{
    class Block : Entity
    {
        Image number1;
        public Block(float x, float y, int sizeX,int sizeY) : base(x, y, sizeX, sizeY)
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
            // int diffx = 400;
            // int diffy = 400;
            // int i, j;


            //Block[] blocks = new Block[32];

            // int t = 0;
            // for (i = 0; i < 4;i++)
            // {

            //     diffx = 400;
            //     for (j = 0; j < 8;t++,t++, j++)
            //     {
            //         g.DrawImage(Board[i,j].number1, x - diffx, y - diffy, 100, 60);
            //         g.DrawImage(blocks[t].number1, x - diffx, y - diffy, 100, 60);
            //         diffx -= 100;

            //     }
            //     diffy -= 70;

            g.DrawImage(number1, x, y, sizeX, sizeY);

        }


    }
    }

