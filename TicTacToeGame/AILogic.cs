using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToeDiscordBot.TicTacToeGame
{
    public class AILogic
    {
        private List<Field> gameGrid;
        private int Turn;
        static Random r = new Random();

        public int MakeMove(List<Field> grid, string difficulty, int turn)
        {
            // Updates the local grid & turn every time the MakeMove method is called
            gameGrid = grid;
            Turn = turn;

            // Checks if it is the bots first move

            if (Turn == 0)
            {
                return FirstMove();
            }

            if (difficulty == "hard")
            {

            }

            return 8;
        }

        private int FirstMove()
        {
            if (gameGrid[4].FieldValue == 0)
                return 4;
            else
            {
                int[] options = {0, 2, 6, 8};
                return options[r.Next(options.Length)];
            }
        }
    }
}
