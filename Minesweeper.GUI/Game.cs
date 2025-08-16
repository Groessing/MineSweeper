using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.GUI
{
    internal class Game
    {
        private Random _rnd;
        private GameButton[,] _buttons;
        public Dictionary<Difficulty, Tuple<int, int, int>> _fieldSize = new Dictionary<Difficulty, Tuple<int, int, int>>();
        public GameButton[,] Buttons { get => _buttons; set => _buttons = value; }


        /// <summary>
        /// Initializes a new instance of the Game class
        /// </summary>
        /// <param name="difficulty"></param>
        public Game(Difficulty difficulty)
        {
            _rnd = new Random();
            _fieldSize.Add(Difficulty.Beginner, Tuple.Create(10, 10, 10));
            _fieldSize.Add(Difficulty.Advanced, Tuple.Create(16, 16, 40));
            _fieldSize.Add(Difficulty.Expert, Tuple.Create(16, 30, 99));
            _fieldSize.Add(Difficulty.Godmode, Tuple.Create(16, 30, 99));


            Tuple<int, int, int> values = _fieldSize[difficulty];
            int x = values.Item1;
            int y = values.Item2;
            _buttons = new GameButton[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    _buttons[i, j] = new GameButton(i, j);
                }
            }
        }


        /// <summary>
        /// Places mines at random positions
        /// </summary>
        /// <param name="difficulty"></param>
        public void PlaceMines(Difficulty difficulty)
        {
            Tuple<int, int, int> values = _fieldSize[difficulty];
            int x = values.Item1;
            int y = values.Item2;
            int minesCount = values.Item3;
            int count = 0;
            while (count < minesCount)
            {
                int randX = _rnd.Next(x);
                int randY = _rnd.Next(y);

                if (Buttons[randX, randY].HasMine == false)
                {
                    Buttons[randX, randY].HasMine = true;
                    count++;
                }

            }
        }


        /// <summary>
        /// Places numbers on every field where there is not a mine
        /// </summary>
        public void PlaceNumbers()
        {
            int rows = Buttons.GetLength(0);
            int cols = Buttons.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    GameButton currentButton = Buttons[i, j];
                    if (!currentButton.HasMine)
                    {
                        int adjacentMines = CountAdjacentMines(i, j);
                        currentButton.MinesAround = adjacentMines;
                    }
                }
            }
        }



        /// <summary>
        /// Counts the adjacent mines
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int CountAdjacentMines(int x, int y)
        {
            int count = 0;
            int rows = Buttons.GetLength(0);
            int cols = Buttons.GetLength(1);

            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    if (dx == 0 && dy == 0)
                        continue;

                    int ni = x + dx;
                    int nj = y + dy;
                    if (ni >= 0 && ni < rows && nj >= 0 && nj < cols && Buttons[ni, nj].HasMine)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

    }
}
