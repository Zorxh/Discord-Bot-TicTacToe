using System;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;
using TicTacToeDiscordBot.External_Dependencies;
using TicTacToeDiscordBot.Models;

namespace TicTacToeDiscordBot.Commands
{
    public class TrackScores : BaseCommandModule
    {
        ScoreDatabase sdb = new ScoreDatabase();

        [Command("score")]
        public async Task Score(CommandContext ctx, string userMention = null)
        {
            if (!string.IsNullOrEmpty(userMention))
            {
                string userMentionParsed =
                    userMention.Replace("<", "").Replace(">", "").Replace("@", "").Replace("!", "");

                Console.WriteLine(userMentionParsed);
                PlayerInDb player = sdb.FetchPreviousResults(userMentionParsed);

                if (!string.IsNullOrEmpty(player.UserId))
                {
                    string message =
                        $"{userMention}'s stats:\nWins: {player.Wins}\nLosses: {player.Losses}\nTies {player.Ties}";

                    await ctx.Channel.SendMessageAsync(message);
                }
                else
                {
                    await ctx.Channel.SendMessageAsync("The requested user is not yet registered in the Database. Play at least one game for the data to be registered.");
                }

                
            }
            else
            {
                string memberId = ctx.Member.Id.ToString();
                Console.WriteLine(memberId);

                PlayerInDb player = sdb.FetchPreviousResults(memberId);
                if(!string.IsNullOrEmpty(player.UserId))
                { 
                    string message =
                        $"{ctx.Member.Mention}'s stats:\nWins: {player.Wins}\nLosses: {player.Losses}\nTies {player.Ties}";

                    await ctx.Channel.SendMessageAsync(message);
                }
                else
                {
                    await ctx.Channel.SendMessageAsync("The requested user is not yet registered in the Database. Play at least one game for the data to be registered.");
                }
            }
        }
    }
}
