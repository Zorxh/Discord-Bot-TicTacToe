using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToeDiscordBot.TicTacToeGame
{
    public class AILogic
    {
        private List<Field> gameGrid;
        private int turnCounter;
        static Random r = new Random();

        public int MakeMove(List<Field> grid, string difficulty, int turn)
        {
            // Updates the local grid & turn every time the MakeMove method is called
            gameGrid = new List<Field>(grid);
            turnCounter = turn;

            // Checks if it is the bots first move

            if (turnCounter == 0)
            {
                return FirstMove();
            }

            if (difficulty == "hard" && turnCounter > 0)
            {
                int hardBot = InitHardBot();

                if(hardBot != -1)
                    return InitHardBot();

                return PlaceRandomInEmpty();
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

        private int PlaceRandomInEmpty()
        {
            int selction;
            do
            {
                selction = r.Next(gameGrid.Count);
            } while (gameGrid[selction].FieldValue != 0);


            return selction;
        }

        private int InitHardBot()
        {
            int winGamePossible = CanBlockOrWin(2);

            if (winGamePossible != -1)
                return winGamePossible;

            int blockPlayerPossible = CanBlockOrWin(1);

            if (blockPlayerPossible != -1)
                return blockPlayerPossible;



            return -1;
        }

        /*private int CounterStrat1()
        {
            if (gameGrid[3 & 8].FieldValue == 1 && gameGrid[0 & 1 & 2 & 5 & 6 & 7].FieldValue == 0)
                return 6;
        }*/

        // I'm sure this can be optimized in some way
        private int CanBlockOrWin(int num)
        {
            // Horizontal row 1
            if (gameGrid[0 & 1].FieldValue == num && gameGrid[2].FieldValue == 0 ||
                gameGrid[0 & 2].FieldValue == num && gameGrid[2].FieldValue == num ||
                gameGrid[0].FieldValue == 0 && gameGrid[1 & 2].FieldValue == num)
            {
                if (gameGrid[0].FieldValue == 0)
                    return 0;
                else if (gameGrid[1].FieldValue == 0)
                    return 1;
                else
                    return 2;
            }

            // Horizontal row 2
            if (gameGrid[3].FieldValue == num && gameGrid[4].FieldValue == num && gameGrid[5].FieldValue == 0 ||
                gameGrid[3].FieldValue == num && gameGrid[4].FieldValue == 0 && gameGrid[5].FieldValue == num ||
                gameGrid[3].FieldValue == 0 && gameGrid[4].FieldValue == num && gameGrid[5].FieldValue == num)
            {
                if (gameGrid[3].FieldValue == 0)
                    return 3;
                else if (gameGrid[4].FieldValue == 0)
                    return 4;
                else
                    return 5;
            }

            // Horizontal row 3
            if (gameGrid[6].FieldValue == num && gameGrid[7].FieldValue == num && gameGrid[8].FieldValue == 0 ||
                gameGrid[6].FieldValue == num && gameGrid[7].FieldValue == 0 && gameGrid[8].FieldValue == num ||
                gameGrid[6].FieldValue == 0 && gameGrid[7].FieldValue == num && gameGrid[8].FieldValue == num)
            {
                if (gameGrid[6].FieldValue == 0)
                    return 6;
                else if (gameGrid[7].FieldValue == 0)
                    return 7;
                else
                    return 8;
            }

            // Vertical row 1
            if (gameGrid[0].FieldValue == num && gameGrid[3].FieldValue == num && gameGrid[6].FieldValue == 0 ||
                gameGrid[0].FieldValue == num && gameGrid[3].FieldValue == 0 && gameGrid[6].FieldValue == num ||
                gameGrid[0].FieldValue == 0 && gameGrid[3].FieldValue == num && gameGrid[6].FieldValue == num)
            {
                if (gameGrid[0].FieldValue == 0)
                    return 0;
                else if (gameGrid[3].FieldValue == 0)
                    return 3;
                else
                    return 6;
            }

            // Vertical row 2
            if (gameGrid[1].FieldValue == num && gameGrid[4].FieldValue == num && gameGrid[7].FieldValue == 0 ||
                gameGrid[1].FieldValue == num && gameGrid[4].FieldValue == 0 && gameGrid[7].FieldValue == num ||
                gameGrid[1].FieldValue == 0 && gameGrid[4].FieldValue == num && gameGrid[7].FieldValue == num)
            {
                if (gameGrid[1].FieldValue == 0)
                    return 1;
                else if (gameGrid[4].FieldValue == 0)
                    return 4;
                else
                    return 7;
            }

            // Vertical row 3
            if (gameGrid[2].FieldValue == num && gameGrid[5].FieldValue == num && gameGrid[8].FieldValue == 0 ||
                gameGrid[2].FieldValue == num && gameGrid[5].FieldValue == 0 && gameGrid[8].FieldValue == num ||
                gameGrid[2].FieldValue == 0 && gameGrid[5].FieldValue == num && gameGrid[8].FieldValue == num)
            {
                if (gameGrid[2].FieldValue == 0)
                    return 2;
                else if (gameGrid[5].FieldValue == 0)
                    return 5;
                else
                    return 8;
            }

            // Diagonal row 1
            if (gameGrid[0].FieldValue == num && gameGrid[4].FieldValue == num && gameGrid[8].FieldValue == 0 ||
                gameGrid[0].FieldValue == num && gameGrid[4].FieldValue == 0 && gameGrid[8].FieldValue == num ||
                gameGrid[0].FieldValue == 0 && gameGrid[4].FieldValue == num && gameGrid[8].FieldValue == num)
            {
                if (gameGrid[0].FieldValue == 0)
                    return 0;
                else if (gameGrid[4].FieldValue == 0)
                    return 4;
                else
                    return 8;
            }

            // Diagonal row 2
            if (gameGrid[2].FieldValue == num && gameGrid[4].FieldValue == num && gameGrid[6].FieldValue == 0 ||
                gameGrid[2].FieldValue == num && gameGrid[4].FieldValue == 0 && gameGrid[6].FieldValue == num ||
                gameGrid[2].FieldValue == 0 && gameGrid[4].FieldValue == num && gameGrid[6].FieldValue == num)
            {
                if (gameGrid[2].FieldValue == 0)
                    return 2;
                else if (gameGrid[4].FieldValue == 0)
                    return 4;
                else
                    return 6;
            }

            return -1;
        }
    }
}
