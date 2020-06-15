using System.Collections.Generic;
using System.Linq;
using DSharpPlus.Entities;

namespace TicTacToeDiscordBot.TicTacToeGame
{
    public class Grid
    {
        public List<Field> GameGrid;

        public Grid(DiscordEmoji fieldEmoji)
        {
            Field Field1 = new Field(fieldEmoji, 0);
            Field Field2 = new Field(fieldEmoji, 0);
            Field Field3 = new Field(fieldEmoji, 0);
            Field Field4 = new Field(fieldEmoji, 0);
            Field Field5 = new Field(fieldEmoji, 0);
            Field Field6 = new Field(fieldEmoji, 0);
            Field Field7 = new Field(fieldEmoji, 0);
            Field Field8 = new Field(fieldEmoji, 0);
            Field Field9 = new Field(fieldEmoji, 0);

            GameGrid.AddRange(new List<Field>
            {
                Field1, Field2, Field3, 
                Field4, Field5, Field6, 
                Field7, Field8, Field9
            });
        }
    }
}
