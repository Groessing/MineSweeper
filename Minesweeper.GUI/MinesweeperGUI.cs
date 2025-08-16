using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using DBAccess.Lib;

namespace Minesweeper.GUI
{
    public partial class MinesweeperGUI : Form
    {
        Game g;
        Difficulty difficulty;
        private Stopwatch stopwatch = new Stopwatch();
        int minesCount;
        int clickedFields = 0;
        bool needReload;
        bool isSignedIn;                                //for checking new highschool as long as player is signed in

        public MinesweeperGUI()
        {
            InitializeComponent();
            cBoxDifficulty.Text = "Difficulty";
            lblMinesCount.Text = "";
            needReload = false;
            tbxPlayerName.Visible = false;
        }

        public MinesweeperGUI(string username)
        {
            InitializeComponent();
            cBoxDifficulty.Text = "Difficulty";
            lblMinesCount.Text = "";
            needReload = false;
            tbxPlayerName.Text = username;
            isSignedIn = true;
            tbxPlayerName.Enabled = false;
        }



        /// <summary>
        /// Fills the panel with buttons
        /// </summary>
        private void FillPanel()
        {
            Tuple<int, int, int> values = g._fieldSize[difficulty];
            int x = values.Item1;
            int y = values.Item2;
            minesCount = values.Item3;
            lblMinesCount.Text = "" + minesCount;

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    flpGameField.Controls.Add(g.Buttons[i, j]);
                    g.Buttons[i, j].Click += new System.EventHandler(this.btnGame_Click);
                    g.Buttons[i, j].MouseDown += new MouseEventHandler(this.btnGame_MouseDown);
                    g.Buttons[i, j].Name = "btn" + i + "_" + j;                                 //btnX_Y
                    if (j == g.Buttons.GetLength(1) - 1)
                    {
                        flpGameField.SetFlowBreak(g.Buttons[i, j], true);
                    }
                }
            }
        }



        /// <summary>
        /// All buttons in the panel will be removed
        /// </summary>
        private void ReloadPanel()
        {
            Tuple<int, int, int> values = g._fieldSize[difficulty];
            int x = values.Item1;
            int y = values.Item2;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    flpGameField.Controls.Remove(g.Buttons[i, j]);
                }
            }

           
        }


        /// <summary>
        /// All numbers on every button will be showed
        /// </summary>
        private void ShowAllFields()
        {
            Tuple<int, int, int> values = g._fieldSize[difficulty];
            int x = values.Item1;
            int y = values.Item2;

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (g.Buttons[i, j].HasMine == true)
                    {
                        g.Buttons[i, j].BackColor = Color.Red;
                        g.Buttons[i, j].Text = "M";
                    }

                    else
                    {
                        g.Buttons[i, j].BackColor = Color.Yellow;
                        g.Buttons[i, j].Text = "" + g.Buttons[i, j].MinesAround;
                    }
                }
            }
        }


        /// <summary>
        /// Checks if the player wins or loses
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void CheckWinLoss(int x, int y)
        {
            if ((g.Buttons[x, y].HasMine || minesCount == 0) && (difficulty != Difficulty.Godmode))
            {
                stopwatch.Stop();
                ShowAllFields();
                MessageBox.Show("You lost!");
                
            }
            else
            {
                if((clickedFields == 90 && difficulty == Difficulty.Beginner) || 
                   (clickedFields == 216 && difficulty == Difficulty.Advanced) ||
                   (clickedFields == 381 && difficulty == Difficulty.Expert) ||
                   (clickedFields == 480 && difficulty == Difficulty.Godmode))
                {
                    stopwatch.Stop();
                    MessageBox.Show("You won!");

                    if (isSignedIn)
                    {
                        int newscore = CalculateHighScore();
                        DBManager db = new DBManager();
                        int oldsocre = db.GetOldHighScore(cBoxDifficulty.Text, tbxPlayerName.Text);

                        if (newscore > oldsocre)
                        {
                            db.UpdateHighScore(newscore, cBoxDifficulty.Text, tbxPlayerName.Text);
                        }
                    }

                }
            }
        }


        /// <summary>
        /// Calculates the highscore depending on the difficulty and the time the player took
        /// </summary>
        private int CalculateHighScore()
        {
            int basepoints = 0;
            int difficultyMultiplicator = 0;
            int timeBonus = 0;
            int timeTaken = (int)stopwatch.Elapsed.TotalSeconds;
            if (cBoxDifficulty.Text == "Beginner")
            {
                basepoints = 100;
                difficultyMultiplicator = 1;
                timeBonus = (600 - timeTaken) / 10;
            }
            else if (cBoxDifficulty.Text == "Advanced")
            {
                basepoints = 200;
                difficultyMultiplicator = 2;
                timeBonus = (1200 - timeTaken) / 5;
            }
            else if (cBoxDifficulty.Text == "Expert")
            {
                basepoints = 500;
                difficultyMultiplicator = 3;
                timeBonus = (1800 - timeTaken) / 2;
            }

            if(timeBonus < 0)                  //If the player took longer than max time - gets 0 points as time bonus
            {
                timeBonus = 0;
            }
            return basepoints + timeBonus * difficultyMultiplicator;
        }

        /// <summary>
        /// Recursively uncovers neighboring buttons if the clicked button has zero mines around it
        /// </summary>
        /// <param name="button"></param>
        private void DisplayNeighbors(GameButton button)
        {
            if (button.X < 0 || button.Y < 0 || button.X >= g.Buttons.GetLength(0) || button.Y >= g.Buttons.GetLength(1) || g.Buttons[button.X, button.Y].IsMarked)
            {
                return;
            }


            g.Buttons[button.X, button.Y].Text = "" + g.Buttons[button.X, button.Y].MinesAround;
            g.Buttons[button.X, button.Y].IsMarked = true;


            if (g.Buttons[button.X, button.Y].MinesAround == 0)
            {
                DisplayNeighbors(new GameButton(button.X - 1, button.Y)); 
                DisplayNeighbors(new GameButton(button.X + 1, button.Y)); 
                DisplayNeighbors(new GameButton(button.X, button.Y - 1)); 
                DisplayNeighbors(new GameButton(button.X, button.Y + 1));
                DisplayNeighbors(new GameButton(button.X - 1, button.Y - 1));
                DisplayNeighbors(new GameButton(button.X + 1, button.Y - 1));
                DisplayNeighbors(new GameButton(button.X - 1, button.Y + 1));
                DisplayNeighbors(new GameButton(button.X + 1, button.Y + 1));
            }
          
        }




        /// <summary>
        /// When the field is left clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGame_Click(object sender, EventArgs e)
        {
            GameButton clickedButton = sender as GameButton;
            string[] parts = clickedButton.Name.Split('_');
            int[] coordinates = new int[2];
            coordinates[0] = int.Parse(parts[0].Substring(3));
            coordinates[1] = int.Parse(parts[1]);

            if(!g.Buttons[coordinates[0], coordinates[1]].HasMine)
            {
                clickedButton.Text = "" + g.Buttons[coordinates[0], coordinates[1]].MinesAround;
               // clickedButton.BackColor = Color.Yellow;
                clickedFields++;
            }

            if(g.Buttons[coordinates[0], coordinates[1]].MinesAround == 0 && !g.Buttons[coordinates[0], coordinates[1]].HasMine)
            {
                DisplayNeighbors(clickedButton);
            }

            if(g.Buttons[coordinates[0], coordinates[1]].HasMine && cBoxDifficulty.Text == "Godmode")
            {
                clickedButton.Text = "M";
            }

            CheckWinLoss(coordinates[0], coordinates[1]);
        }


       /// <summary>
       /// When the field is right clicked
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void btnGame_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Button clickedButton = sender as Button;
                if (clickedButton != null)                                          
                {
                    string[] parts = clickedButton.Name.Split('_');
                    int[] coordinates = new int[2];
                    coordinates[0] = int.Parse(parts[0].Substring(3));
                    coordinates[1] = int.Parse(parts[1]);


                    if(!g.Buttons[coordinates[0], coordinates[1]].IsMarkedAsMine)            //If the button is not marked yet
                    {
                        g.Buttons[coordinates[0], coordinates[1]].IsMarkedAsMine = true;
                        g.Buttons[coordinates[0], coordinates[1]].Text = "?";          //Marks as possible mine
                        minesCount--;
                    }

                    else                                                               //If the button is already marked
                    {
                        g.Buttons[coordinates[0], coordinates[1]].IsMarkedAsMine = false;
                        g.Buttons[coordinates[0], coordinates[1]].Text = "";           //Marks as possible mine
                        minesCount++;
                    }
                    lblMinesCount.Text = "" + minesCount;

                }
                CheckWinLoss(0, 0);
            }

           
        }

   


        /// <summary>
        /// When "Start" is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            if(cBoxDifficulty.Text == "Difficulty")
            {
                MessageBox.Show("Please choose a difficulty!");
            }
            else 
            {
                if(needReload)
                {
                    ReloadPanel();
                    stopwatch.Reset();
                    timer1.Stop();
                    lblTime.Text = "00:00";
                }
                stopwatch.Start();
                timer1.Start();
                difficulty = (Difficulty)Enum.Parse(typeof(Difficulty), cBoxDifficulty.Text);
                g = new Game(difficulty);
                g.PlaceMines(difficulty);
                g.PlaceNumbers();
                FillPanel();
                needReload = true;
            }
            
        }

    


        /// <summary>
        /// For Stopwatch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = stopwatch.Elapsed;
            string elapsedTimeString = string.Format("{0:00}:{1:00}", elapsed.Minutes, elapsed.Seconds);
            lblTime.Text = elapsedTimeString;
        }


        /// <summary>
        /// When "Show All Fields" is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowAllFields_Click(object sender, EventArgs e)
        {
            if (cBoxDifficulty.Text == "Difficulty")
            {
                MessageBox.Show("Please choose a difficulty!");
            }
            else
            {
                ShowAllFields();
            }
           
        }

        
    }
}
