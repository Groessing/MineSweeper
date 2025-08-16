using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.GUI
{
    internal class GameButton : System.Windows.Forms.Button
    {
        public int X { get; }
        public int Y { get; }

        public bool HasMine { get; set; }

        public bool IsMarked { get; set; }

        public int MinesAround { get; set; }

        public bool IsMarkedAsMine { get; set; }


        /// <summary>
        /// Initializes a new instance of the GameButton class
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public GameButton(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Size = new System.Drawing.Size(30, 30);
        }


        /// <summary>
        /// Returns a string that represents the current object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{X},{Y}";
        }
    }
}
