using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;

namespace TicTacToeDiscordBot.TicTacToeGame
{
    public class SingleplayerGame : GameElements
    {
        private Player p1;
        private AI ai;
        private Grid grid;
        private CommandContext ctx;

        public SingleplayerGame(CommandContext context, DiscordMember playerTwo, string difficulty)
        {
            ctx = context;
            p1 = new Player(ctx.Member.Id, ctx.Member.DisplayName, GameEmoji.X);
            ai = new AI(playerTwo.Id, playerTwo.DisplayName, GameEmoji.O, difficulty);
            grid = new Grid(GameEmoji.Field);
        }

        public async Task BeginSingleplayerGame()
        {
            Multiplayer = false;
            EmbedDefaults.SetEmbedDefaultsSP(p1, ai);

            ActivePlayer = p1.Name;

            DiscordEmbedBuilder gameBoard = CreatePlayField(grid.GameGrid);

            DiscordMessage embedMessage = await ctx.Channel.SendMessageAsync(embed: gameBoard).ConfigureAwait(false);
            await AddReactions(embedMessage);

            while (GameActive)
            {
                //await MakeMove(embedMessage);
                Turn++;
            }

            await embedMessage.ModifyAsync(embed: new Optional<DiscordEmbed>(CreatePlayField(grid.GameGrid))).ConfigureAwait(false);
            await embedMessage.DeleteAllReactionsAsync();
        }
    }
}
