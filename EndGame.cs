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
        int score;
        string name;
        string status;
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=;Integrated Security=True");

        public EndGame(int score, bool win)
        {
            

            InitializeComponent();
            if (win == true)
            {
                winner = true;
                statusTextBox.Text = "YOU WON!";
                this.status = "WIN";
            }
            else
            {
                winner = false;
                statusTextBox.Text = "YOU LOST!"; 
                this.status = "LOOser";
            }
             this.score = score;
            
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
            this.scoringTableAdapter.Fill(this.databaseDataSet.scoring);
            // TODO: This line of code loads data into the 'databaseDataSet.scoring' table. You can move, or remove it, as needed.
            this.scoringTableAdapter.Fill(this.databaseDataSet.scoring);
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
                statusTextBox.Text = "YOU WON!";
            else
                statusTextBox.Text = "YOU LOST!";
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            this.name = nameTextBox.Text;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {           
            string query = "INSERT INTO scoring ( score,name,status) VALUES ( @score,@name,@status)";

            con.Open();
            //SqlDataAdapter sda = new SqlDataAdapter("insert into EndGame(score,name,status)values('"+scoreTextBox+"','"+nameTextBox+ "','" + statusTextBox + "')",con);
            //sda.SelectCommand.ExecuteNonQuery();
            using (SqlCommand command = new SqlCommand(query, con)) 
            {
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@score", score);
                command.Parameters.AddWithValue("@status", status);
                command.ExecuteNonQuery();
            }

            con.Close();
        }
    }
}
