using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Google.Protobuf;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Asn1.X500;

namespace DBAccess.Lib
{
    public class DBManager
    {
        string connStr = "server=localhost;user=root;database=minesweeper;port=3306;";
        MySqlConnection conn;
        public List<Player> players = new List<Player>();
       
        public DBManager()
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
        }

        /// <summary>
        /// Search for the playername
        /// </summary>
        /// <param name="playername"></param>
        /// <returns></returns>
        public List<string> FindPlayer(string playername)
        {
            List<string> playernames = new List<string>();
            string sql = "SELECT * FROM Player";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            bool playernameExists = false;
            while (reader.Read())
            {
                playernames.Add(reader["Name"].ToString());
            }
            reader.Close();
            foreach (string pn in playernames)
            {
                if (pn == playername)
                {
                    playernameExists = true;
                    break;
                }
            }
            if(playernameExists)
            {
                return playernames;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Creates player when doesn't exist yet
        /// </summary>
        /// <param name="playername"></param>
        public void CreatePlayer(string playername)
        {
            string sql = $"INSERT INTO Player (Name, Level) VALUES ('{playername}', 'Beginner'), ('{playername}', 'Advanced'), ('{playername}', 'Expert')";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Shows the player's name, level, highscore and date after signed in successfully
        /// </summary>
        /// <param name="name"></param>
        public void ShowPlayer(string name)
        {
            string sql = $"SELECT * FROM Player  WHERE Name='{name}'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            int highscore;
        
            while (reader.Read())
            {
                if (reader.IsDBNull(reader.GetOrdinal("Highscore")))                //If it's null in database
                {
                    highscore = -1;
                }
                else
                {
                    highscore = Convert.ToInt32(reader["Highscore"]);
                }

                Player p = new Player
                (
                    reader["Name"].ToString(),
                    reader["Level"].ToString(),
                    highscore,
                    reader["Scoredate"].ToString()
                );
                players.Add(p);
            }
            reader.Close();
        }


        /// <summary>
        /// Updates the Highscore if it's higher than previous one
        /// </summary>
        /// <param name="newscore"></param>
        /// <param name="difficulty"></param>
        /// <param name="name"></param>
        public void UpdateHighScore(int newscore, string difficulty, string name)
        {
            DateTime date = DateTime.Now;
            string dateString = date.ToString("dd/MM/yyyy");
            string sql = $"UPDATE player SET Highscore='{newscore}', Scoredate='{dateString}' WHERE Name='{name}' AND Level='{difficulty}'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }



        /// <summary>
        /// Gets the current highscore stored in table and returns it
        /// </summary>
        /// <param name="difficulty"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public int GetOldHighScore(string difficulty, string name)
        {
            string sql = $"SELECT Highscore FROM Player WHERE Level='{difficulty}' AND Name='{name}'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            int score = -1;
            while (reader.Read())
            {
                if (!reader.IsDBNull(reader.GetOrdinal("Highscore")))                //If it's null in database
                {
                    score = Convert.ToInt32(reader["Highscore"]);
                }
              
            }

            reader.Close();
            return score;
        }
    }
}
