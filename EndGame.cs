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


namespace funkyBubbles
{

    public partial class EndGame : Form
    {
        bool winner;
        string score;
        string name;
        string status;
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True");


        public EndGame(int score, bool win)
        {
            InitializeComponent();
            if (win == true)
            {
                winner = true;
                statusTextBox.Text = "YOU WON!";
                this.status = "Winner";
            }
            else
            {
                winner = false;
                statusTextBox.Text = "YOU LOST!";
                this.status = "Loser";
            }
            this.score = score.ToString();

            scoreTextBox.Text = score.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 end = new Form1();
            Hide();
            end.ShowDialog();
            Close();
        }

        private void EndGame_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseDataSet.scoring' table. You can move, or remove it, as needed.
            // this.scoringTableAdapter.Fill(this.databaseDataSet.scoring);
            if (winner == true)
                textBox1.Text = "YOU WON!";
            else
                textBox1.Text = "YOU LOST!";


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void scoreTextBox_TextChanged(object sender, EventArgs e)
        {
            scoreTextBox.Text = score.ToString();
        }

        private void statusTextBox_TextChanged(object sender, EventArgs e)
        {
            if (winner == true)
                statusTextBox.Text = "Winner";
            else
                statusTextBox.Text = "Loser";
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            this.name = nameTextBox.Text;
        }

        private void bind_data()
        {
            SqlCommand cmd;
            string sql = "Select * from scoring";
            cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string query = "INSERT INTO dbo.scoring (score,name,status) VALUES (@score, @name, @status)";

            con.Open();
            //SqlDataAdapter sda = new SqlDataAdapter("insert into EndGame(score,name,status)values('"+scoreTextBox+"','"+nameTextBox+ "','" + statusTextBox + "')",con);
            //sda.SelectCommand.ExecuteNonQuery();

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@score", score);
                command.Parameters.AddWithValue("@status", status);
                bind_data();
                command.ExecuteNonQuery();
            }
           
            con.Close();
        }

        private void replay_Click(object sender, EventArgs e)
        {
            Main newGame = new Main();
            Hide();
            newGame.ShowDialog();
            Close();
        }
    }
}
