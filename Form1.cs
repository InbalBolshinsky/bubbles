﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace funkyBubbles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            player = new Spaceship(Width / 2, Height - (Height / 8), Width / 12);
            
        }
        Rectangle spaceship;
        Rectangle block;
        Graphics g;
        Spaceship player;
        Block regolar;

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            spaceship = new Rectangle(100, 100, 50, 20);
            g = this.CreateGraphics();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            player.draw(e.Graphics);
        }
    }
}
