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
    public partial class EndGame : Form
    {
        static public int id = 1; //initializing players id
        private bool isFirstLoad = true; //did the player save their data
        bool winner; //did the player win
        string score; //players score
        int highScore; //high score
        string name; //players name
        string status; //players status

        SqlCommand cmd; //sql command for inserting score
        SqlCommand cmdMax; //sql command for getting high score
        SqlConnection con; //sql connection to data base

        public EndGame(int score, bool win)
        {
            InitializeComponent();

            //print status
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

            //print score:
            this.score = score.ToString();
            scoreTextBox.Text = this.score;
            

        }



        private void EndGame_Load(object sender, EventArgs e)
        {

        }


        private void idNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            //incresing unique players id by 1;
            id++;
        }
        private void scoreTextBox_TextChanged(object sender, EventArgs e)
        {

        }



        private void statusTextBox_TextChanged(object sender, EventArgs e)
        {



        }



        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            //get players name from name text box
            name = nameTextBox.Text;
        }

        private void scoringDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private int GenerateHighScore()
        {
            //generate high score

            cmdMax = new SqlCommand("SELECT MAX(CAST(score AS INT)) FROM scoring", con);
            highScore = Convert.ToInt32(cmdMax.ExecuteScalar());

            this.tableAdapterManager.UpdateAll(this.modelDataSet);

            con.Close();
            return highScore;
        }

        private void playAgain_Click(object sender, EventArgs e)
        {
            if (!isFirstLoad)
            {
                //open new game

                Main menu = new Main(GenerateHighScore());
                Hide();
                menu.ShowDialog();
                Close();
            }

        }

        private void Quit_Click(object sender, EventArgs e)
        {
            //quiting game and closing all forms
            Hide();
            Close();
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (isFirstLoad)//FirstLoad - already saved 
            {
                //disable save results button
                isFirstLoad = false;
                save.Enabled = false;

                //insert to SQL

                //for Shani:            
                //con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\USERS\\SHASH\\ONEDRIVE\\שולחן העבודה\\BOOBELS\\FUNKYBUBBLES\\SCOREBASE.MDF;Integrated Security=True");
               
                //for Inbal:
                con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\inbal\\Desktop\\bubbles\\bubbles\\ScoreBase.mdf;Integrated Security=True");

                con.Open();

                //inserting players data: name, score, status
                cmd = new SqlCommand("INSERT INTO scoring (name, score, status) VALUES (@name, @score, @status)", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", nameTextBox.Text);
                cmd.Parameters.AddWithValue("@score", this.score);
                cmd.Parameters.AddWithValue("@status", this.status);
                cmd.ExecuteNonQuery();

                this.tableAdapterManager.UpdateAll(this.modelDataSet);
            }
        }
    }
}
