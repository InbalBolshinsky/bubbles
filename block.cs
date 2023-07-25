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
            b = new SolidBrush(Color.Red);

            number1= Image.FromFile("pics\\block.png");

        }

        public abstract void draw(Graphics g)
        {
            g.DrawImage(block, x -200, y +500, 150, 100);
        }
    }
}
