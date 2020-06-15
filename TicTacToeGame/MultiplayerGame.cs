using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;

namespace TicTacToeDiscordBot.TicTacToeGame
{
    public class MultiplayerGame
    {
        private GameElements gameElements;
        private Player p1;
        private Player p2;
        private Grid grid;
        private CommandContext ctx;

        public MultiplayerGame(CommandContext context, DiscordMember playerTwo)
        {
            gameElements = new GameElements();
            p1 = new Player(ctx.Member.Id, ctx.Member.DisplayName, GameEmoji.X);
            p2 = new Player(playerTwo.Id, playerTwo.DisplayName, GameEmoji.O);
            grid = new Grid(GameEmoji.Field);
            ctx = context;
        }

        public async Task BeginMultiplayerGame()
        {
            DiscordEmbedBuilder gameBoard = gameElements.CreatePlayField(grid.GameGrid, p1, p2);

            DiscordMessage embedMessage = await ctx.Channel.SendMessageAsync(embed: gameBoard).ConfigureAwait(false);

        }
    }
}
