using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToeDiscordBot.TicTacToeGame
{
    public class TicTacToe : BaseCommandModule
    {
        [Command("tictactoe")]
        [Aliases("ttt", "krydsogbolle", "kob")]
        public async Task TicTacToeGame(CommandContext ctx, string userMention)
        {
            DiscordMember playerTwo = null;

            List<DiscordMember> dmList = await GetMemberList(ctx);

            await Task.WhenAny(GetMemberList(ctx));

            foreach (DiscordMember discordMember in dmList)
            {
                if (discordMember.Mention == userMention)
                {
                    GameEmoji.InitEmoji(ctx);
                    playerTwo = discordMember;
                    MultiplayerGame mp = new MultiplayerGame(ctx, playerTwo);
                    await mp.BeginMultiplayerGame();
                }
            }

            if (playerTwo == null)
                await ctx.Channel.SendMessageAsync("The requested player could not be found. Please try again with another user.");
        }


        public async Task<List<DiscordMember>> GetMemberList(CommandContext ctx)
        {
            List<DiscordMember> memberList = await Task.Run(() => ctx.Channel.Users.ToList());

            return memberList;
        }
    }
}
