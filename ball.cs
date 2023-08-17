using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Security.Policy;


namespace funkyBubbles
{
    class Ball : Entity 
    {
        Image ball;
        public Ball(int x, int y, int sizeX) : base(x, y, sizeX, sizeX)
        {
            b = new SolidBrush(Color.Red);

            ball = Image.FromFile("pics\\ball.png");
        }



        public override void draw(Graphics g, int flag)
        {
            //g.DrawImage(ball, x, y, sizeX, sizeY);
            g.FillEllipse(b,x,y,sizeX,sizeY);
        }

        
    }
}

