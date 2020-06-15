using DSharpPlus.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;

namespace TicTacToeDiscordBot.TicTacToeGame
{
    public class GameElements
    {
        public bool GameActive = true;
        public bool Multiplayer;
        public string Winner;
        private int turn;

        public DiscordEmbedBuilder CreatePlayField(List<Field> g, Player p1, Player p2 = null, AI ai = null)
        {
            string descriptionString = $"";
            string winnerMessage = "";
            DiscordEmbedBuilder newEmbed;

            for (int i = 0; i < g.Count; i++)
            {
                descriptionString += $"{i + 1} " + g[i].FieldValue + "    ";
                if (i == 2 || i == 5)
                    descriptionString += "\n\n";
            }

            if (GameActive == false && !string.IsNullOrEmpty(Winner))
            {
                winnerMessage = $"\n\n{Winner} has won the game.";
            }
            else if (GameActive == false && string.IsNullOrEmpty(Winner))
            {
                winnerMessage = $"\n\nThe game resulted in a tie";
            }

            if(Multiplayer)
            { 
                newEmbed = new DiscordEmbedBuilder
                {
                    Title = $"{p1.Name} challenged you a game of Tic Tac Toe!",
                    Description = $"{p1.Name}: {p1.PlayerEmoji}\n" +
                                  $"{p2.Name}: {p2.PlayerEmoji}\n\n" +
                                  descriptionString + winnerMessage,
                    Color = DiscordColor.Green
                };
            }
            else
            {
                newEmbed = new DiscordEmbedBuilder // Needs to be tweaked for Singleplayer
                {
                    Title = $"{p1.Name} challenged the bot to a game of Tic Tac Toe!",
                    Description = $"{p1.Name}: {p1.PlayerEmoji}\n" +
                                  $"{p2.Name}: {p2.PlayerEmoji}\n\n" +
                                  descriptionString + winnerMessage,
                    Color = DiscordColor.Green
                };
            }

            return newEmbed;
        }
    }
}
