using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using System.Threading.Tasks;

namespace TicTacToeDiscordBot.TicTacToeGame
{
    public class MultiplayerGame : GameElements
    {
        //private GameElements gameElements;
        private Player p1;
        private Player p2;
        private Grid grid;
        private CommandContext ctx;

        public MultiplayerGame(CommandContext context, DiscordMember playerTwo)
        {
            ctx = context;
            p1 = new Player(ctx.Member.Id, ctx.Member.DisplayName, GameEmoji.X);
            p2 = new Player(playerTwo.Id, playerTwo.DisplayName, GameEmoji.O);
            grid = new Grid(GameEmoji.Field);
        }

        public async Task BeginMultiplayerGame()
        {
            Multiplayer = true;
            EmbedDefaults.SetEmbedDefaultsMP(p1, p2);

            ActivePlayer = p1.Name;

            DiscordEmbedBuilder gameBoard = CreatePlayField(grid.GameGrid);

            DiscordMessage embedMessage = await ctx.Channel.SendMessageAsync(embed: gameBoard).ConfigureAwait(false);
            await AddReactions(embedMessage);

            while (GameActive)
            {
                await MakeMove(embedMessage);
                Turn++;
            }

            await embedMessage.ModifyAsync(embed: new Optional<DiscordEmbed>(CreatePlayField(grid.GameGrid))).ConfigureAwait(false);
            await embedMessage.DeleteAllReactionsAsync();
        }

        public async Task MakeMove(DiscordMessage embed)
        {
            if (GameActive)
            {
                var interactivityp1 = ctx.Client.GetInteractivity();
                var reactionResultp1 = await interactivityp1.WaitForReactionAsync(
                    x => x.Message == embed &&
                         x.User == ctx.User && GameEmoji.OneThroughNine().Contains(x.Emoji)).ConfigureAwait(false);

                ActivePlayer = p2.Name;
                await RemoveChoice(embed, reactionResultp1.Result.Emoji);
                await UpdateField(grid.GameGrid, embed, reactionResultp1.Result.Emoji, p1.PlayerEmoji, 1);
                if (Turn >= 2)
                    CheckWinCondition(p1, grid.GameGrid);
            }

            if (GameActive)
            {
                var interactivityp2 = ctx.Client.GetInteractivity();
                var reactionResultp2 = await interactivityp2.WaitForReactionAsync(
                    x => x.Message == embed &&
                         x.User.Id == p2.Id && GameEmoji.OneThroughNine().Contains(x.Emoji)).ConfigureAwait(false);

                ActivePlayer = p1.Name;
                await RemoveChoice(embed, reactionResultp2.Result.Emoji);
                await UpdateField(grid.GameGrid, embed, reactionResultp2.Result.Emoji, p2.PlayerEmoji, 2);
                if (Turn >= 2)
                    CheckWinCondition(p2, grid.GameGrid);
            }
        }
    }
}
