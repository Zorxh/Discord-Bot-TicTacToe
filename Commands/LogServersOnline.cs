using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicTacToeDiscordBot.External_Dependencies;

namespace TicTacToeDiscordBot.Commands
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

            Console.WriteLine("List of servers have been written to owners Google Spreadsheet.");

            await Task.CompletedTask;
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
