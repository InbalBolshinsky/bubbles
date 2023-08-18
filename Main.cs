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
        int high_score;
        SqlCommand cmdMax;
        SqlCommand cmdDelete;//command for deleting table data (line 31)
        SqlConnection con;
        bool refresh = true;
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

            if (high_score == 0)
                this.high_score = gethighscore(refresh);
            else
                this.high_score = high_score;
           
            highScore.Text = "High Score: " + this.high_score;
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

        private int gethighscore(bool refresh)
        {

            //for Shani:            
            //con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\USERS\\SHASH\\ONEDRIVE\\שולחן העבודה\\BOOBELS\\FUNKYBUBBLES\\SCOREBASE.MDF;Integrated Security=True");

            //for Inbal:
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\inbal\\Desktop\\bubbles\\bubbles\\ScoreBase.mdf;Integrated Security=True");
            
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
