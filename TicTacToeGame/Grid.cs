using System.Collections.Generic;
using System.Linq;
using DSharpPlus.Entities;

namespace TicTacToeDiscordBot.TicTacToeGame
{
    public class Grid
    {
        public List<Field> GameGrid = new List<Field>();

        public Grid(DiscordEmoji fieldEmoji)
        {

            GameGrid.AddRange(new List<Field>
            {
                new Field(fieldEmoji, 0), new Field(fieldEmoji, 0), new Field(fieldEmoji, 0),
                new Field(fieldEmoji, 0), new Field(fieldEmoji, 0), new Field(fieldEmoji, 0),
                new Field(fieldEmoji, 0), new Field(fieldEmoji, 0), new Field(fieldEmoji, 0)
            });
        }
    }
}
