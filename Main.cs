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
using System.Data.SqlClient;
using System.Data.Sql;

namespace funkyBubbles

{
    
    public partial class Main : Form
    {
        int high_score; //high score
        SqlCommand cmdMax; //sql command to get high score
        SqlCommand cmdDelete; //sql command for deleting table data (line 31)
        SqlConnection con; //sql connection to data base
        
        public Main(int high_score = 0)
        {
            InitializeComponent();

            //if we want to clear table data completly use this code:
            /*
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\inbal\\Desktop\\bubbles\\bubbles\\ScoreBase.mdf;Integrated Security=True");
            con.Open();
            cmdDelete = new SqlCommand("TRUNCATE TABLE scoring", con);
            cmdDelete.ExecuteNonQuery();
            con.Close();
            */

            //get high score:
            if (high_score == 0)
                this.high_score = gethighscore(); //for second or more time playing
            else
                this.high_score = high_score; //for first time playing

            highScore.Text = "High Score: " + this.high_score; //display high score
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //open new game
            Form1 game = new Form1();
            Hide();
            game.ShowDialog();
            Close();
        }

        private int gethighscore()
        {

            //for Shani:            
            //con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\USERS\\SHASH\\ONEDRIVE\\שולחן העבודה\\BOOBELS\\FUNKYBUBBLES\\SCOREBASE.MDF;Integrated Security=True");

            //for Inbal:
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\inbal\\Desktop\\bubbles\\bubbles\\ScoreBase.mdf;Integrated Security=True");
            
            //generating high score from sql data base
            con.Open();
            cmdMax = new SqlCommand("SELECT MAX(CAST(score AS INT)) FROM scoring", con);
            high_score = Convert.ToInt32(cmdMax.ExecuteScalar());
            con.Close();
            return high_score;
        }

        private void highScore_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
