using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace funkyBubbles
{
    
    public partial class Main : Form
    {
        int high_score;
        public Main(int high_score = 0)
        {
            InitializeComponent();
            this.high_score = high_score;
            highScore.Text = "High Score: " + high_score;
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 game = new Form1();
            Hide();
            game.ShowDialog();
            Close();
        }

        private void highScore_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
