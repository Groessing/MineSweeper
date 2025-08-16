using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBAccess.Lib;
namespace Minesweeper.GUI
{
    public partial class Anmeldung : Form
    {
        DBManager dbm;
        MinesweeperGUI minesweeper = new MinesweeperGUI();
        public Anmeldung()
        {
            InitializeComponent();
            lvwPlayers.View = View.Details;
            lvwPlayers.Columns.Add("Name", 100);
            lvwPlayers.Columns.Add("Level", 100);
            lvwPlayers.Columns.Add("Highscore", 100);
            lvwPlayers.Columns.Add("Date", 100);
        }


        /// <summary>
        /// Signs in and checks for existing playername
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                dbm = new DBManager();
                string lowerCaseName = tbxName.Text.ToLower();
                List<string> list = dbm.FindPlayer(lowerCaseName);
                if (list != null)
                {
                    dbm.ShowPlayer(lowerCaseName);
                    lvwPlayers.Items.Clear();
                    foreach (Player player in dbm.players)
                    {
                        ListViewItem item = new ListViewItem("" + player.Name);
                        item.SubItems.Add(player.Level);
                        lvwPlayers.Items.Add(item);
                        item.SubItems.Add("" + player.Highscore);
                        item.SubItems.Add("" + player.Date);
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("Player not found! Create a one?", "Warning", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        dbm.CreatePlayer(lowerCaseName);
                    }
                    else if (result == DialogResult.No)
                    {
                        MinesweeperGUI mineGUI = new MinesweeperGUI();
                        this.Hide();
                        mineGUI.FormClosed += (s, args) => this.Close();
                        mineGUI.Show();
                    }
                }
            }
           catch
            {
                MessageBox.Show("Error to connect to database!");
            }
           
        }


        /// <summary>
        /// Starts after finding playername successfully
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnContinue_Click(object sender, EventArgs e)
        {
            string lowerCaseName = tbxName.Text.ToLower();
            MinesweeperGUI mineGUI = new MinesweeperGUI(lowerCaseName);
            this.Hide();
            mineGUI.FormClosed += (s, args) => this.Close();
            mineGUI.Show();
        }


        /// <summary>
        /// Starts without any playername
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartWithoutRegistration_Click(object sender, EventArgs e)
        {
            MinesweeperGUI mineGUI = new MinesweeperGUI();
            this.Hide();
            mineGUI.FormClosed += (s, args) => this.Close();
            mineGUI.Show();
        }
    }
}
