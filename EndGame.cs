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
        static public  int id=0 ;
        private bool isFirstLoad = true;
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

            //scoreTextBox.Text = score.ToString();
        }


        private void scoringBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            if (isFirstLoad)
            {
                isFirstLoad = false;
                scoringBindingNavigatorSaveItem.Enabled = false;

                this.Validate();
                this.scoringBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.modelDataSet);
            }
        }

        private void EndGame_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'modelDataSet.scoring' table. You can move, or remove it, as needed.
            this.scoringTableAdapter.Fill(this.modelDataSet.scoring);

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (isFirstLoad)
            {            
                isFirstLoad = false;
                bindingNavigatorAddNewItem.Enabled = false;
            }
        }

        private void idNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            //id++;
        }

        private void statusTextBox_TextChanged(object sender, EventArgs e)
        {
            if (winner == true)
                statusTextBox.Text = "Winner";
            else
                statusTextBox.Text = "Loser";
        }

        private void scoreTextBox_TextChanged(object sender, EventArgs e)
        {
            scoreTextBox.Text = "not a null";
        }

        private void idTextBox_TextChanged(object sender, EventArgs e)
        {
            idTextBox.Text = id.ToString();
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
    }
}
