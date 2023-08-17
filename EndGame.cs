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
        static public int id = 1;
        private bool isFirstLoad = true;
        private bool isSAVED = false;
        bool winner;
        string score;
        int highScore;
        string name;
        string status;
        SqlCommand cmd;
        SqlCommand cmdMax;
        SqlConnection con;
        SqlDataAdapter da;

        bool isGameSaved;

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
            //print score:
            scoreTextBox.Text = this.score;
            

        }



        private void EndGame_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'modelDataSet.scoring' table. You can move, or remove it, as needed.
            //this.scoringTableAdapter.Fill(this.modelDataSet.scoring);

        }


        private void idNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            id++;
        }
        private void scoreTextBox_TextChanged(object sender, EventArgs e)
        {

        }



        private void statusTextBox_TextChanged(object sender, EventArgs e)
        {
            //print status:
            if (winner == true)
                statusTextBox.Text = "Winner";
            else
                statusTextBox.Text = "Loser";



        }



        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
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
            Hide();
            Close();
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (isFirstLoad)//FirstLoad - already saved 
            {
                isFirstLoad = false;
                save.Enabled = false;

                //insert to SQL
                con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\USERS\\SHASH\\ONEDRIVE\\שולחן העבודה\\BOOBELS\\FUNKYBUBBLES\\SCOREBASE.MDF;Integrated Security=True");
                con.Open();


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
