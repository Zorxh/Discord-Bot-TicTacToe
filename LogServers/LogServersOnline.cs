using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicTacToeDiscordBot.LogServers
{
    public class LogServersOnline : BaseCommandModule
    {
        [Command("logservers")]
        public async Task LogServers(CommandContext ctx)
        {
            List<DiscordGuild> servers = GetServerList();

            GoogleSheets sheets = new GoogleSheets();

            sheets.InitSheetsApi();
            sheets.UpdateData(servers);
            
            await ctx.Channel.SendMessageAsync("Server list printed to the owners Google Spreadsheet.");
        }

        public List<DiscordGuild> GetServerList()
        {
            List<DiscordGuild> serverList = new List<DiscordGuild>();

            foreach (var server in Bot.Client.Guilds.Values)
            {
                serverList.Add(server);
            }

            return serverList;
        }

    }
}
