using DSharpPlus.Entities;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace TicTacToeDiscordBot.TicTacToeGame
{
    public class GameElements
    {
        public bool GameActive = true;
        public string ActivePlayer;
        public bool Multiplayer;
        public string Winner;
        public int Turn;

        // Creates an embedded message with the game board. 
        public DiscordEmbedBuilder CreatePlayField(List<Field> g)
        {
            string descriptionString = $"";
            string bottomMessage = $"\n\n";
            DiscordEmbedBuilder newEmbed;

            for (int i = 0; i < g.Count; i++)
            {
                descriptionString += $"{i + 1} " + g[i].FieldEmoji + "    ";
                if (i == 2 || i == 5)
                    descriptionString += "\n\n";
            }

            if (GameActive)
                bottomMessage += $"Waiting for {ActivePlayer} to make a move.";

            else if (GameActive == false && !string.IsNullOrEmpty(Winner))
                bottomMessage += $"{Winner} has won the game.";
            
            else if (GameActive == false && string.IsNullOrEmpty(Winner))
                bottomMessage += $"The game resulted in a tie";
            

            if(Multiplayer)
            { 
                newEmbed = new DiscordEmbedBuilder
                {
                    Title = EmbedDefaults.Title,
                    Description = EmbedDefaults.PlayerAndEmoji + "\n\n" +
                                  descriptionString + bottomMessage,
                    Color = DiscordColor.Green
                };
            }
            else
            {
                newEmbed = new DiscordEmbedBuilder
                {
                    Title = EmbedDefaults.Title,
                    Description = EmbedDefaults.PlayerAndEmoji + "\n\n" +
                                  descriptionString + bottomMessage,
                    Color = DiscordColor.Green
                };
            }

            return newEmbed;
        }

        //
        public async Task AddReactions(DiscordMessage embed)
        {
            foreach(DiscordEmoji discordEmoji in GameEmoji.OneThroughNine())
                await embed.CreateReactionAsync(discordEmoji);
        }

        public async Task RemoveChoice(DiscordMessage embed, DiscordEmoji demoji)
        {
            await embed.DeleteReactionsEmojiAsync(demoji).ConfigureAwait(false);
        }

        public async Task UpdateField(List<Field> grid, DiscordMessage embed, DiscordEmoji demoji, DiscordEmoji playerEmoji, int playerValue)
        {
            for (int i = 0; i < 9; i++)
            {
                if (demoji == GameEmoji.OneThroughNine()[i])
                {
                    grid[i].FieldEmoji = playerEmoji;
                    grid[i].FieldValue = playerValue;
                }
            }

            await embed.ModifyAsync(embed: new Optional<DiscordEmbed>(CreatePlayField(grid))).ConfigureAwait(false);
        }

        public void CheckWinCondition(string playerName, List<Field> grid)
        {
            // Horizontal row 1
            if (grid[0].FieldValue == grid[1].FieldValue && grid[1].FieldValue == grid[2].FieldValue && grid[0].FieldValue != 0)
            {
                Winner = playerName;
                GameActive = false;
            }

            // Horizontal row 2
            if (grid[3].FieldValue == grid[4].FieldValue && grid[4].FieldValue == grid[5].FieldValue && grid[3].FieldValue != 0)
            {
                Winner = playerName;
                GameActive = false;
            }

            // Horizontal row 3
            if (grid[6].FieldValue == grid[7].FieldValue && grid[7].FieldValue == grid[8].FieldValue && grid[6].FieldValue != 0)
            {
                Winner = playerName;
                GameActive = false;
            }

            // Vertical row 1
            if (grid[0].FieldValue == grid[3].FieldValue && grid[3].FieldValue == grid[6].FieldValue && grid[0].FieldValue != 0)
            {
                Winner = playerName;
                GameActive = false;
            }

            // Vertical row 2
            if (grid[1].FieldValue == grid[4].FieldValue && grid[4].FieldValue == grid[7].FieldValue && grid[1].FieldValue != 0)
            {
                Winner = playerName;
                GameActive = false;
            }

            // Vertical row 3
            if (grid[2].FieldValue == grid[5].FieldValue && grid[5].FieldValue == grid[8].FieldValue && grid[2].FieldValue != 0)
            {
                Winner = playerName;
                GameActive = false;
            }

            // Diagonal row 1
            if (grid[0].FieldValue == grid[4].FieldValue && grid[4].FieldValue == grid[8].FieldValue && grid[0].FieldValue != 0)
            {
                Winner = playerName;
                GameActive = false;
            }

            // Diagonal row 2
            if (grid[2].FieldValue == grid[4].FieldValue && grid[4].FieldValue == grid[6].FieldValue && grid[2].FieldValue != 0)
            {
                Winner = playerName;
                GameActive = false;
            }

            if (grid[0].FieldValue != 0 && grid[1].FieldValue != 0 && grid[2].FieldValue != 0 &&
                grid[3].FieldValue != 0 && grid[4].FieldValue != 0 && grid[5].FieldValue != 0 &&
                grid[6].FieldValue != 0 && grid[7].FieldValue != 0 && grid[8].FieldValue != 0)
                GameActive = false;
        }
    }
}
