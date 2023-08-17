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
        SqlCommand cmd;
        SqlCommand cmdMax;
        SqlConnection con;
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
        //private int gethighscore ()
        //{
        //    con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\USERS\\SHASH\\ONEDRIVE\\שולחן העבודה\\BOOBELS\\FUNKYBUBBLES\\SCOREBASE.MDF;Integrated Security=True");
        //    cmdMax = new SqlCommand("SELECT MAX(CAST(score AS INT)) FROM scoring", con);
        //    highScore = Convert.ToInt32(cmdMax.ExecuteScalar());

        //    this.tableAdapterManager.UpdateAll(this.modelDataSet);

        //    con.Close();
        //    return highScore;
        //}
        private void highScore_TextChanged(object sender, EventArgs e)
        {
           //if(high_score ==0)
           // {
           //     high_score = gethighscore();
           // }
        }
    }
}
