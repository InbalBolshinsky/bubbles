using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace funkyBubbles
{
    class Ball : Entity 
    {
        Image ball;
        public Ball(float x, float y, int size) : base(x, y, size)
        {
            this.radius = size;
            b = new SolidBrush(Color.Red);

            ball = Image.FromFile("pics\\ball.png");
        }



        public override void draw(Graphics g)
        {
        g.DrawImage(ball, x-100, y-100, 100, 100);

        }

        
    }
}

