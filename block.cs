using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace funkyBubbles
{
    class Block : Entity
    {
        Image number1;
         public  Block(float x, float y, int size) : base(x, y, size)
         { 
            this.radius = size;
            b = new SolidBrush(Color.Blue);

            number1= Image.FromFile("pics\\block_2.png");
        }



        public override void draw(Graphics g)
        {
            int diffx =400;
            int diffy =400;
            int i, j;

            Block[,] Board = new Block[8,4];

            for(i =0;i< 4; i++)
            {
                diffx = 400;
                for (j = 0; j < 8; j++)
                {
                   // g.DrawImage(Board[i,j].number1, x - diffx, y - diffy, 100, 60);
                    g.DrawImage(number1, x - diffx, y - diffy, 100, 60);
                    diffx -= 100;
                    
                }
                diffy -= 70;
            }
           
            
        }
    }
}
