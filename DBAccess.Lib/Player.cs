using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess.Lib
{
    public class Player
    {
        private string _name;
        private string _level;
        private int? _highscore;
        private string _date;

       

        public string Name { get => _name; set => _name = value; }
        public string Level { get => _level; set => _level = value; }
        public int? Highscore { get => _highscore; set => _highscore = value; }
        public string Date { get => _date; set => _date = value; }


        
        public Player(string name, string level, int? highscore, string date)
        {
            _name = name;
            _level = level;
            _highscore = highscore;
            _date = date;
        }
    }
}
